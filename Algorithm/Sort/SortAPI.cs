namespace Algorithm.Sort
{
    public static partial class SortAlgorithm
    {
        public static bool Less(IComparable left, IComparable right)
        {
            return left.CompareTo(right) < 0;
        }

        public static void Exchange(IComparable[] array, int from, int to)
        {
            IComparable temp = array[from];
            array[from] = array[to];
            array[to] = temp;
        }

        public static bool IsSorted(IComparable[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (Less(array[i], array[i - 1]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
