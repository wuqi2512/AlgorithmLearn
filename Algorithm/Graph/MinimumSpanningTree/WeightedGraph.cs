namespace Algorithm.Graph.MinimumSpanningTree
{
    /// <summary>
    /// 加权无向图
    /// </summary>
    public class WeightedGraph
    {
        public int VertexCount { get; private set; }
        public int EdgeCount { get; private set; }
        private HashSet<Edge>[] adj;

        public WeightedGraph(int vCount)
        {
            VertexCount = vCount;
            adj = new HashSet<Edge>[vCount];
            for (int i = 0; i < adj.Length; i++)
            {
                adj[i] = new HashSet<Edge>();
            }
        }

        public void AddEdge(int v, int w, float weight)
        {
            Edge edge = new Edge(v, w, weight);
            if (v == w)
            {
                adj[v].Add(edge);
            }
            else
            {
                adj[v].Add(edge);
                adj[w].Add(edge);
            }
            EdgeCount++;
        }

        public IEnumerable<Edge> GetAdjacentEdge(int vertex)
        {
            return adj[vertex];
        }

        public IEnumerable<Edge> Edges()
        {
            for (int i = 0; i < VertexCount; i++)
            {
                foreach (Edge e in adj[i])
                {
                    if (i > e.OtherVertex(i))
                        yield return e;
                }
            }
        }
    }
}
