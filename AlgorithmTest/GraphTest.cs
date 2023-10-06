using Algorithm.Graph.MinimumSpanningTree;
using Algorithm.Graph.ShortestPath;
using System.Text;

namespace AlgorithmTest
{
    [TestClass]
    public class GraphTest
    {
        #region MST Test

        [TestMethod]
        public void MSTTest()
        {
            string graphStr = "8 " +
                "4 5 0.35 4 7 0.37 " +
                "5 7 0.28 0 7 0.16 " +
                "1 5 0.32 0 4 0.38 " +
                "2 3 0.17 1 7 0.19 " +
                "0 2 0.26 1 2 0.36 " +
                "1 3 0.29 2 7 0.34 " +
                "6 2 0.40 3 6 0.52 " +
                "6 0 0.58 6 4 0.93";

            WeightedGraph graph = StringToWeightedGraph(graphStr);
            Console.WriteLine("WeightedGraph:");
            Console.WriteLine(WeightedGraphToString(graph));

            Edge[] mst = MST.Prime(graph);
            Console.WriteLine("Prime:");
            Console.WriteLine(EdgesToString(mst));

            mst = MST.Kruskal(graph);
            Console.WriteLine("Kruskal:");
            Console.WriteLine(EdgesToString(mst));
        }

        private static WeightedGraph StringToWeightedGraph(string graphStr)
        {
            string[] strs = graphStr.Split(' ', '\n');
            WeightedGraph graph = new WeightedGraph(int.Parse(strs[0]));
            for (int i = 1; i < strs.Length; i += 3)
            {
                graph.AddEdge(int.Parse(strs[i]), int.Parse(strs[i + 1]), float.Parse(strs[i + 2]));
            }
            return graph;
        }

        private static string WeightedGraphToString(WeightedGraph graph)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Vertex: {0}, Edge: {1}\n", graph.VertexCount, graph.EdgeCount);
            foreach (var edge in graph.Edges())
            {
                sb.AppendFormat("{0}-{1}  {2}\n", edge.V, edge.W, edge.Weight);
            }

            return sb.ToString();
        }

        private static string EdgesToString(Edge[] edges)
        {
            StringBuilder sb = new StringBuilder();

            float totalWeight = 0f;
            foreach (var edge in edges)
            {
                sb.AppendFormat("{0}-{1}  {2}\n", edge.V, edge.W, edge.Weight);
                totalWeight += edge.Weight;
            }
            sb.AppendFormat("TotalWeight: {0}\n", totalWeight);

            return sb.ToString();
        }

        #endregion

        #region SP Test

        [TestMethod]
        public void SPTest()
        {
            string graphStr = "8 " +
            "4 5 0.35 5 4 0.35 4 7 0.37 " +
            "5 7 0.28 7 5 0.28 " +
            "5 1 0.32 0 4 0.38 " +
            "0 2 0.26 7 3 0.37 " +
            "1 3 0.29 2 7 0.34 " +
            "6 2 0.40 3 6 0.52 " +
            "6 0 0.58 6 4 0.93";

            WeightedDigraph graph = StringToWeightedDigraph(graphStr);
            Console.WriteLine("WeightedDigraph:");
            Console.WriteLine(WeightedDigraphToString(graph));

            var sp = SP.Dijkstra(graph, 0);
            Console.WriteLine("Dijkstra:");
            Console.WriteLine(DirectedEdgesToString(sp));
        }

        private static WeightedDigraph StringToWeightedDigraph(string graphStr)
        {
            string[] strs = graphStr.Split(' ', '\n');
            WeightedDigraph graph = new WeightedDigraph(int.Parse(strs[0]));
            for (int i = 1; i < strs.Length; i += 3)
            {
                graph.AddEdge(int.Parse(strs[i]), int.Parse(strs[i + 1]), float.Parse(strs[i + 2]));
            }
            return graph;
        }

        private static string WeightedDigraphToString(WeightedDigraph graph)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Vertex: {0}, Edge: {1}\n", graph.VertexCount, graph.EdgeCount);
            foreach (var edge in graph.Edges())
            {
                sb.AppendFormat("{0}->{1}  {2}\n", edge.From, edge.To, edge.Weight);
            }

            return sb.ToString();
        }

        private static string DirectedEdgesToString(DirectedEdge[] edges)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var edge in edges)
            {
                sb.AppendFormat("{0}->{1}  {2}\n", edge.From, edge.To, edge.Weight);
            }

            return sb.ToString();
        }

        #endregion
    }
}
