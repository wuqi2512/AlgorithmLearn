namespace Algorithm.Sort
{
    public static partial class SortAlgorithm
    {
        public static void QuickSort(IComparable[] array)
        {
            Quick_Recursion(array, 0, array.Length - 1);
        }

        private static int Partition(IComparable[] array, int low, int high)
        {
            int i = low, j = high + 1;
            IComparable v = array[low];
            while (true)
            {
                while (Less(array[++i], v)) // 增量减量运算符必须为前缀的，下面的也是
                    if (i == high)
                        break;
                while (Less(v, array[--j]))
                    if (j == low)
                        break;
                if (i >= j)
                    break;
                Exchange(array, i, j);
            }
            Exchange(array, low, j);
            return j;
        }

        private static void Quick_Recursion(IComparable[] array, int low, int high)
        {
            // 改良：切换到插入排序
            if (low + 15 >= high)
            {
                InsertionSubarray(array, low, high);
                return;
            }
            int i = Partition(array, low, high);
            Quick_Recursion(array, low, i - 1);
            Quick_Recursion(array, i + 1, high);
        }
    }
}