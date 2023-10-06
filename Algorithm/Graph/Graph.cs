namespace Algorithm.Graph
{
    /// <summary>
    /// 无平行边和自环，无向图
    /// </summary>
    public class Graph
    {
        public int VertexCount { get; private set; }
        public int EdgeCount { get; private set; }
        private HashSet<int>[] adj;

        public Graph(int vCount)
        {
            VertexCount = vCount;
            adj = new HashSet<int>[vCount];
            for (int i = 0; i < adj.Length; i++)
                adj[i] = new HashSet<int>();
        }

        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v);
            EdgeCount++;
        }

        public IEnumerable<int> GetAdjacentVertex(int vertex)
        {
            return adj[vertex];
        }

        public static void DFS(Graph graph, int sourceVertex)
        {
            bool[] mark = new bool[graph.VertexCount];
            Stack<int> stack = new Stack<int>();
            stack.Push(sourceVertex);

            while (stack.Count > 0)
            {
                int currentVertex = stack.Pop();
                foreach (int v in graph.GetAdjacentVertex(currentVertex))
                {
                    if (!mark[v])
                    {
                        mark[v] = true;
                        stack.Push(v);
                    }
                }
            }
        }

        public static void BFS(Graph graph, int sourceVertex)
        {
            bool[] mark = new bool[graph.VertexCount];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(sourceVertex);

            while (queue.Count > 0)
            {
                int currentVertex = queue.Dequeue();
                foreach (int v in graph.GetAdjacentVertex(currentVertex))
                {
                    if (!mark[v])
                    {
                        mark[v] = true;
                        queue.Enqueue(v);
                    }
                }
            }
        }
    }
}
