namespace Algorithm.Graph.ShortestPath
{
    public class DirectedEdge
    {
        public int From;
        public int To;
        public float Weight;

        public DirectedEdge(int from, int to, float weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }
    }
}