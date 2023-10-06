namespace Algorithm.Misc
{
    public class WeightedUnionFind
    {
        private int[] id;
        private int[] size;
        public int Count { get; private set; }

        public WeightedUnionFind(int n)
        {
            id = new int[n];
            for (int i = 0; i < id.Length; i++)
            {
                id[i] = i;
            }
            size = new int[n];
            for (int i = 0; i < size.Length; i++)
            {
                size[i] = 1;
            }
            Count = n;
        }

        public void Union(int f, int s)
        {
            int fRoot = Find(f);
            int sRoot = Find(s);

            if (fRoot == sRoot)
                return;

            // id[sRoot] = fRoot;
            if (size[fRoot] > size[sRoot])
            {
                id[sRoot] = fRoot;
                size[fRoot] += size[sRoot];
            }
            else
            {
                id[fRoot] = sRoot;
                size[sRoot] += size[fRoot];
            }
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
