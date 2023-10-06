namespace Algorithm.Graph.MinimumSpanningTree
{
    public class Edge
    {
        public int V;
        public int W;
        public float Weight;

        public Edge(int v, int w, float weight)
        {
            V = v;
            W = w;
            Weight = weight;
        }

        public int OtherVertex(int vertex)
        {
            return vertex == V ? W : V;
        }
    }
}
