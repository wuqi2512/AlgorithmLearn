namespace Algorithm.Graph.MinimumSpanningTree
{
    public static partial class MST
    {
        /// <summary>
        /// 起始顶点为0
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static Edge[] Prime(WeightedGraph graph)
        {
            Edge[] edgeTo = new Edge[graph.VertexCount - 1]; // 最小生成树的边
            float[] weights = new float[graph.VertexCount];
            bool[] mark = new bool[graph.VertexCount];
            PriorityQueue<int, float> queue = new PriorityQueue<int, float>();
            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = float.MaxValue;
            }

            weights[0] = 0;
            queue.Enqueue(0, 0);

            while (queue.Count > 0)
            {
                int min = queue.Dequeue();
                mark[min] = true;
                foreach (var edge in graph.GetAdjacentEdge(min))
                {
                    int other = edge.OtherVertex(min);
                    if (mark[other])
                    {
                        continue;
                    }

                    if (edge.Weight < weights[other])
                    {
                        edgeTo[other - 1] = edge;
                        weights[other] = edge.Weight;
                        queue.Enqueue(other, weights[other]);
                    }
                }
            }

            return edgeTo;
        }
    }
}
