namespace Algorithm.Sort
{
    public static partial class SortAlgorithm
    {
        public static void QuickSort(IComparable[] array)
        {
            int i = Partition(array);
            InsertionSubarray(array, 0, i - 1);
            InsertionSubarray(array, i + 1, array.Length - 1);
        }

        private static int Partition(IComparable[] array)
        {
            int i = 0, j = array.Length;
            IComparable v = array[0];
            while (true)
            {
                while (Less(array[++i], v)) // 增量减量运算符必须为前缀的
                    if (i >= array.Length)
                        break;
                while (Less(v, array[--j]))
                    if (j <= 0)
                        break;
                if (i >= j)
                    break;
                Exchange(array, i, j);
            }
            Exchange(array, 0, j);
            return j;
        }
    }
}