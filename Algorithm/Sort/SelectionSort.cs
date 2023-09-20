namespace Algorithm.Sort
{
    public static partial class SortAlgorithm
    {
        /// <summary>
        /// 选择排序
        /// <para> 描述：每次从剩下的元素中选出最小的放到最前面 </para>
        /// <para> 特点：时间复杂度与输入的初始状态无关，只与数组长度有关 </para>
        /// </summary>
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
