namespace Algorithm.Graph.ShortestPath
{
    public static partial class SP
    {
        public static DirectedEdge[] Dijkstra(WeightedDigraph graph, int sourceVertex)
        {
            DirectedEdge[] edgeTo = new DirectedEdge[graph.VertexCount - 1];
            float[] distTo = new float[graph.VertexCount];
            for (int i = 0; i < distTo.Length; i++)
            {
                distTo[i] = float.MaxValue;
            }
            PriorityQueue<int, float> queue = new PriorityQueue<int, float>();

            distTo[0] = 0f;
            queue.Enqueue(sourceVertex, 0f);

            while (queue.Count > 0)
            {
                int min = queue.Dequeue();

                foreach (var edge in graph.GetAdjacentEdge(min))
                {
                    int to = edge.To;
                    if (distTo[to] > distTo[min] + edge.Weight)
                    {
                        distTo[to] = distTo[min] + edge.Weight;
                        edgeTo[to - 1] = edge;
                        queue.Enqueue(to, distTo[to]);
                    }
                }
            }

            return edgeTo;
        }
    }
}
