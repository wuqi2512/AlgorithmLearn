namespace Algorithm.Sort
{
    public static partial class SortAlgorithm
    {
        /// <summary>
        /// 插入排序
        /// <para> 描述：分为已排序部分和未排序部分，从未排序部分取出第一个元素插入到已排序部分的合适位置 </para>
        /// <para> 特点：对部分有序的数组效果更好，适合小规模数组，常用于一些高级排序算法 </para>
        /// </summary>
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
