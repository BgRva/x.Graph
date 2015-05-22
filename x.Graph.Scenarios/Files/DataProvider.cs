namespace x.Graph.Scenarios.Files
{
    public static class DataProvider
    {
        public static string GetScenario(int id)
        {
            return Properties.Resources.ResourceManager.GetString(
                string.Format("scenario_{0:000}", id));
        }

        public static string GetNodeData<T>(int id)
        {
            return Properties.Resources.ResourceManager.GetString(
                string.Format("node_{0:000}_{1}", id, typeof(T).Name.ToLower()));
        }

        public static string GetEdgeData<T>(int id)
        {
            return Properties.Resources.ResourceManager.GetString(
                string.Format("edge_{0:000}_{1}", id, typeof(T).Name.ToLower()));
        }
    }
}
