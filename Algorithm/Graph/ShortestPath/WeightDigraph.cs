namespace Algorithm.Graph.ShortestPath
{
    /// <summary>
    /// 加权有向图
    /// </summary>
    public class WeightedDigraph
    {
        public int VertexCount { get; private set; }
        public int EdgeCount { get; private set; }
        private HashSet<DirectedEdge>[] adj;

        public WeightedDigraph(int vCount)
        {
            VertexCount = vCount;
            adj = new HashSet<DirectedEdge>[vCount];
            for (int i = 0; i < adj.Length; i++)
            {
                adj[i] = new HashSet<DirectedEdge>();
            }
        }

        public void AddEdge(int from, int to, float weight)
        {
            DirectedEdge edge = new DirectedEdge(from, to, weight);
            adj[from].Add(edge);
            EdgeCount++;
        }

        public IEnumerable<DirectedEdge> GetAdjacentEdge(int vertex)
        {
            return adj[vertex];
        }

        public IEnumerable<DirectedEdge> Edges()
        {
            for (int i = 0; i < VertexCount; i++)
            {
                foreach (DirectedEdge e in adj[i])
                {
                    yield return e;
                }
            }
        }
    }
}
