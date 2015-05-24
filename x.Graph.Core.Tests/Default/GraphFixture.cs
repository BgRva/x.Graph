using System;
using System.Collections;
using System.Collections.Generic;
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

            [Test]
            public void Throws_Ex_If_No_Matching_Node_Of_Double()
            {
                Throws_Ex_If_No_Matching_Node_Of_<double>(33.02, 44.0);
            }

            [Test]
            public void Throws_Ex_If_No_Matching_Node_Of_String()
            {
                Throws_Ex_If_No_Matching_Node_Of_<string>("blah", "lah");
            }

            [Test]
            public void Throws_Ex_If_No_Matching_Node_Of_Item()
            {
                Throws_Ex_If_No_Matching_Node_Of_<DummyItem>(new DummyItem(0, ""), new DummyItem(0, ""));
            }

            private void Throws_Ex_If_No_Matching_Node_Of_<T>(T uniqueId, T uniqueId2)
            {
                //Arrange
                var graph = new Graph<T>();
                var node = graph.AddNode(uniqueId);

                //Act, Assert
                Assert.Throws<KeyNotFoundException>(() => graph.GetNode(uniqueId2));
            }
        }
    }
}
