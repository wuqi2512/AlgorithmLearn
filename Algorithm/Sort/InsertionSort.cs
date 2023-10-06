namespace Algorithm.Sort
{
    public static partial class SortAlgorithm
    {
        public static void InsertionSort(IComparable[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                IComparable current = array[i];
                int j = i;
                while (j >= 1 && Less(current, array[j - 1]))
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = current;
            }
        }

        public static void InsertionSubarray(IComparable[] array, int low, int high)
        {
            if (low < 0 || high >= array.Length || low >= high)
                return;

            for (int i = low; i <= high; i++)
            {
                IComparable current = array[i];
                int j = i;
                while (j >= low + 1 && Less(current, array[j - 1]))
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = current;
            }
        }
    }
}
