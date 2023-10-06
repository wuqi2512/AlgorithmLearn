namespace Algorithm.Sort
{
    public static partial class SortAlgorithm
    {
        public static void SelectionSort(IComparable[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (Less(array[j], array[minIndex]))
                        minIndex = j;
                }
                Exchange(array, i, minIndex);
            }
        }
    }
}
