namespace Algorithm.Search
{
    public static partial class SearchAlgorithm
    {
        public static int BinarySearch(IComparable[] array, IComparable key)
        {
            int low = 0;
            int high = array.GetUpperBound(0);
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                int comp = key.CompareTo(mid);
                if (comp < 0)
                    high = mid - 1;
                else if (comp > 0)
                    low = mid + 1;
                else
                    return mid;
            }

            return -1;
        }

        public static int BinarySearch(IComparable[] array, IComparable key, int low, int high)
        {
            if (high < low || low < 0 || high > array.Length)
                return -1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                int comp = key.CompareTo(mid);
                if (comp < 0)
                    high = mid - 1;
                else if (comp > 0)
                    low = mid + 1;
                else
                    return mid;
            }

            return -1;
        }
    }
}
