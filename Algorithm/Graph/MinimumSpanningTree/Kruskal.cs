using Algorithm.Graph.MinimumSpanningTree;
using Algorithm.Misc;

namespace Algorithm.Graph.MinimumSpanningTree
{
    public static partial class MST
    {
        public static Edge[] Kruskal(WeightedGraph graph)
        {
            List<Edge> edges = new List<Edge>(); // 最小生成树的边
            PriorityQueue<Edge, float> queue = new PriorityQueue<Edge, float>();
            foreach (Edge edge in graph.Edges())
            {
                queue.Enqueue(edge, edge.Weight);
            }
            WeightedUnionFind uf = new WeightedUnionFind(graph.VertexCount);

            while (queue.Count > 0 && edges.Count < graph.VertexCount - 1)
            {
                Edge min = queue.Dequeue();

                int f = min.V;
                int s = min.W;

                if (uf.Connected(f, s))
                {
                    continue;
                }
                uf.Union(f, s);
                edges.Add(min);
            }

            return edges.ToArray();
        }
    }
}