using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using x.Graph.Core.Default;
using x.Graph.Core.Tests.Support;

namespace x.Graph.Core.Tests.Default
{
    public class GraphFixture
    {
        [TestFixture]
        public class Constructor
        {
            [Test]
            public void Creates_Graph_Of_Double()
            {
                Test<double>();
            }

            [Test]
            public void Creates_Graph_Of_String()
            {
                Test<string>();
            }

            [Test]
            public void Creates_Graph_Of_Item()
            {
                Test<DummyItem>();
            }

            private void Test<T>()
            {
                //Arrange, Act
                var graph = new Graph<T>();

                //Assert
                Assert.NotNull(graph);
                Assert.AreEqual(0, graph.NodeCount);
                Assert.AreEqual(0, graph.EdgeCount);
            }
        }

        [TestFixture]
        public class AddNode
        {
            [TestCaseSource(typeof(DataOfDouble))]
            public void Creates_And_Adds_To_Graph_Node_Of_Double(double uniqueId)
            {
                Creates_And_Adds_To_Graph_Node_Of_<double>(uniqueId);
            }

            [TestCaseSource(typeof(DataOfString))]
            public void Creates_And_Adds_To_Graph_Node_Of_String(string uniqueId)
            {
                Creates_And_Adds_To_Graph_Node_Of_<string>(uniqueId);
            }

            [TestCaseSource(typeof(DataOfItem))]
            public void Creates_And_Adds_To_Graph_Node_Of_Item(DummyItem uniqueId)
            {
                Creates_And_Adds_To_Graph_Node_Of_<DummyItem>(uniqueId);
            }

            private void Creates_And_Adds_To_Graph_Node_Of_<T>(T uniqueId)
            {
                //Arrange
                var graph = new Graph<T>();

                //Act
                var node = graph.AddNode(uniqueId);

                //Assert
                Assert.NotNull(node);
                Assert.AreEqual(uniqueId, node.UniqueId);
                Assert.AreEqual(1, graph.NodeCount);
                Assert.AreEqual(0, graph.EdgeCount);
            }

            //-----------------------------

            [Test]
            public void Throws_Ex_If_Id_Is_In_Use_Of_Double()
            {
                Throws_Ex_If_Id_Is_In_Use<double>(33.02);
            }

            [Test]
            public void Throws_Ex_If_Id_Is_In_Use_Of_String()
            {
                Throws_Ex_If_Id_Is_In_Use<string>("blah");
            }

            [Test]
            public void Throws_Ex_If_Id_Is_In_Use_Of_Item()
            {
                Throws_Ex_If_Id_Is_In_Use<DummyItem>(new DummyItem(0, ""));
            }

            private void Throws_Ex_If_Id_Is_In_Use<T>(T uniqueId)
            {
                //Arrange
                var graph = new Graph<T>();
                var node = graph.AddNode(uniqueId);

                //Act, Assert
                Assert.Throws<ArgumentException>(() => graph.AddNode(uniqueId));
            }

            //-----------------------------

            [Test]
            public void Throws_Ex_If_Id_Is_Null()
            {
                //Arrange
                var graph = new Graph<string>();

                //Act, Assert
                Assert.Throws<ArgumentNullException>(() => graph.AddNode(null));
            }
        }

        [TestFixture]
        public class GetNode
        {
            [TestCaseSource(typeof(DataOfDouble))]
            public void GetNode_Returns_Node_By_Id_Of_Double(double uniqueId)
            {
                GetNode_Returns_Node_By_Id_Of_<double>(uniqueId);
            }

            [TestCaseSource(typeof(DataOfString))]
            public void GetNode_Returns_Node_By_Id_Of_String(string uniqueId)
            {
                GetNode_Returns_Node_By_Id_Of_<string>(uniqueId);
            }

            [TestCaseSource(typeof(DataOfItem))]
            public void GetNode_Returns_Node_By_Id_Of_Item(DummyItem uniqueId)
            {
                GetNode_Returns_Node_By_Id_Of_<DummyItem>(uniqueId);
            }

            private void GetNode_Returns_Node_By_Id_Of_<T>(T uniqueId)
            {
                //Arrange
                var graph = new Graph<T>();
                var nodeActual = graph.AddNode(uniqueId);

                //Act
                var node = graph.GetNode(uniqueId);

                //Assert
                Assert.NotNull(node);
                Assert.AreSame(nodeActual, node);
            }

            //-----------------------------

            [TestCaseSource(typeof(ArrayOfDoubles))]
            public void GetNode_Returns_Null_If_Id_Is_Not_In_Graph_For_Id_Of_Double(double [] uniqueIds)
            {
                GetNode_Returns_Null_If_Id_Is_Not_In_Graph_For_Id_Of_<double>(uniqueIds);
            }

            [TestCaseSource(typeof(ArrayOfStrings))]
            public void GetNode_Returns_Null_If_Id_Is_Not_In_Graph_For_Id_Of_String(string [] uniqueIds)
            {
                GetNode_Returns_Null_If_Id_Is_Not_In_Graph_For_Id_Of_<string>(uniqueIds);
            }

            [TestCaseSource(typeof(ArrayOfItems))]
            public void GetNode_Returns_Null_If_Id_Is_Not_In_Graph_For_Id_Of_Item(DummyItem [] uniqueIds)
            {
                GetNode_Returns_Null_If_Id_Is_Not_In_Graph_For_Id_Of_<DummyItem>(uniqueIds);
            }

            private void GetNode_Returns_Null_If_Id_Is_Not_In_Graph_For_Id_Of_<T>(T [] uniqueIds)
            {
                //Arrange
                var graph = new Graph<T>();
                T targetId = default(T);
                for(int i=0; i<uniqueIds.Length-1; i++)
                {
                    if(i == 0)
                    {
                        // use the first id in the array as the id of the target node 
                        // to try and retrieve
                        targetId = uniqueIds[0];
                    }
                    else
                        graph.AddNode(uniqueIds[i]);
                }

                //Act
                var node = graph.GetNode(targetId);

                //Assert
                Assert.Null(node);
            }

            //-----------------------------

            [Test]
            public void Throws_Ex_If_Id_Is_Null()
            {
                //Arrange
                var graph = new Graph<string>();

                //Act, Assert
                Assert.Throws<ArgumentNullException>(() => graph.GetNode(null));
            }
        }

        [TestFixture]
        public class Getter
        {
            [TestCaseSource(typeof(DataOfDouble))]
            public void Getter_Returns_Node_By_Id_Of_Double(double uniqueId)
            {
                Getter_Returns_Node_By_Id_Of_<double>(uniqueId);
            }

            [TestCaseSource(typeof(DataOfString))]
            public void Getter_Returns_Node_By_Id_Of_String(string uniqueId)
            {
                Getter_Returns_Node_By_Id_Of_<string>(uniqueId);
            }

            [TestCaseSource(typeof(DataOfItem))]
            public void Getter_Returns_Node_By_Id_Of_Item(DummyItem uniqueId)
            {
                Getter_Returns_Node_By_Id_Of_<DummyItem>(uniqueId);
            }

            private void Getter_Returns_Node_By_Id_Of_<T>(T uniqueId)
            {
                //Arrange
                var graph = new Graph<T>();
                var nodeActual = graph.AddNode(uniqueId);

                //Act
                var node = graph[uniqueId];

                //Assert
                Assert.NotNull(node);
                Assert.AreSame(nodeActual, node);
            }

            //-----------------------------

            [TestCaseSource(typeof(ArrayOfDoubles))]
            public void Getter_Returns_Null_If_Id_Is_Not_In_Graph_For_Id_Of_Double(double[] uniqueIds)
            {
                Getter_Returns_Null_If_Id_Is_Not_In_Graph_For_Id_Of_<double>(uniqueIds);
            }

            [TestCaseSource(typeof(ArrayOfStrings))]
            public void Getter_Returns_Null_If_Id_Is_Not_In_Graph_For_Id_Of_String(string[] uniqueIds)
            {
                Getter_Returns_Null_If_Id_Is_Not_In_Graph_For_Id_Of_<string>(uniqueIds);
            }

            [TestCaseSource(typeof(ArrayOfItems))]
            public void Getter_Returns_Null_If_Id_Is_Not_In_Graph_For_Id_Of_Item(DummyItem[] uniqueIds)
            {
                Getter_Returns_Null_If_Id_Is_Not_In_Graph_For_Id_Of_<DummyItem>(uniqueIds);
            }

            private void Getter_Returns_Null_If_Id_Is_Not_In_Graph_For_Id_Of_<T>(T[] uniqueIds)
            {
                //Arrange
                var graph = new Graph<T>();
                T targetId = default(T);
                for (int i = 0; i < uniqueIds.Length; i++)
                {
                    if (i == 0)
                    {
                        // use the first id in the array as the id of the target node 
                        // to try and retrieve
                        targetId = uniqueIds[0];
                    }
                    else
                        graph.AddNode(uniqueIds[i]);
                }

                //Act
                var node = graph[targetId];

                //Assert
                Assert.Null(node);
            }

            //-----------------------------

            [Test]
            public void Throws_Ex_If_Id_Is_Null()
            {
                //Arrange
                var graph = new Graph<string>();

                //Act, Assert
                INode<string> node = null;
                Assert.Throws<ArgumentNullException>(() => node = graph[null]);
            }
        }

        [TestFixture]
        public class Nodes
        {
            [TestCaseSource(typeof(ArrayOfDoubles))]
            public void Nodes_Returns_Node_Enumerator_Of_Double(double[] uniqueIds)
            {
                Nodes_Returns_Node_Enumerator_Of_<double>(uniqueIds);
            }

            [TestCaseSource(typeof(ArrayOfStrings))]
            public void Nodes_Returns_Node_Enumerator_Of_String(string[] uniqueIds)
            {
                Nodes_Returns_Node_Enumerator_Of_<string>(uniqueIds);
            }

            [TestCaseSource(typeof(ArrayOfItems))]
            public void Nodes_Returns_Node_Enumerator_Of_Item(DummyItem[] uniqueIds)
            {
                Nodes_Returns_Node_Enumerator_Of_<DummyItem>(uniqueIds);
            }

            private void Nodes_Returns_Node_Enumerator_Of_<T>(T[] uniqueIds)
            {
                //Arrange
                var graph = new Graph<T>();
                for (int i = 0; i < uniqueIds.Length; i++)
                {
                    graph.AddNode(uniqueIds[i]);
                }

                //Act, Assert
                bool contains = false;
                int ctr = 0;
                foreach(var node in graph.Nodes)
                {
                    contains = uniqueIds.Contains(node.UniqueId);
                    // assert that each node corresponds to the input uniqueIds
                    Assert.True(contains);
                    ctr++;
                }

                // assert that all uniqueIds have been accounted for
                Assert.AreEqual(ctr, graph.Nodes.Count());
            }

            //-----------------------------

            [Test]
            public void Nodes_Returns_Empty_Enumerator_For_Empty_Graph()
            {
                //Arrange
                var graph = new Graph<string>();

                //Act, Assert
                foreach (var node in graph.Nodes)
                {
                    Assert.Fail();
                }
            }
        }

        [TestFixture]
        public class RemoveNode
        {
            [TestCaseSource(typeof(ArrayOfDoubles))]
            public void RemoveNode_Removes_The_Node_With_It_Matching_Id_Of_Double(double[] uniqueIds)
            {
                RemoveNode_Removes_The_Node_With_It_Matching_Id_Of_<double>(uniqueIds);
            }

            [TestCaseSource(typeof(ArrayOfStrings))]
            public void RemoveNode_Removes_The_Node_With_It_Matching_Id_Of_String(string[] uniqueIds)
            {
                RemoveNode_Removes_The_Node_With_It_Matching_Id_Of_<string>(uniqueIds);
            }

            [TestCaseSource(typeof(ArrayOfItems))]
            public void RemoveNode_Removes_The_Node_With_It_Matching_Id_Of_Item(DummyItem[] uniqueIds)
            {
                RemoveNode_Removes_The_Node_With_It_Matching_Id_Of_<DummyItem>(uniqueIds);
            }

            private void RemoveNode_Removes_The_Node_With_It_Matching_Id_Of_<T>(T[] uniqueIds)
            {
                //Arrange
                var graph = new Graph<T>();
                T targetId = default(T);
                for (int i = 0; i < uniqueIds.Length; i++)
                {
                    if (i == 0)
                    {
                        // use the first id in the array as the id of the node to remove
                        targetId = uniqueIds[0];
                    }
                    else
                        graph.AddNode(uniqueIds[i]);
                }

                //Act
                graph.RemoveNode(targetId);

                //Assert
                Assert.AreEqual(uniqueIds.Length - 1, graph.Nodes.Count());
                var node = graph.GetNode(targetId);
                Assert.Null(node);
            }
        }
    }
}
