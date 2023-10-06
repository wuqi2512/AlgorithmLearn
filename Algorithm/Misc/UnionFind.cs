namespace Algorithm.Misc
{
    public class UnionFind
    {
        private int[] id;
        public int Count { get; private set; }

        public UnionFind(int n)
        {
            id = new int[n];
            for (int i = 0; i < id.Length; i++)
            {
                id[i] = i;
            }
            Count = n;
        }

        public void Union(int f, int s)
        {
            int fRoot = Find(f);
            int sRoot = Find(s);

            if (fRoot == sRoot)
                return;

            id[sRoot] = fRoot;
            Count--;
        }

        public int Find(int f)
        {
            while (f != id[f])
            {
                f = id[f];
            }

            return f;
        }

        public bool Connected(int f, int s)
        {
            return Find(f) == Find(s);
        }
    }
}