namespace Algorithm.Sort
{
    public static partial class SortAlgorithm
    {
        /// <summary>
        /// 希尔排序
        /// <para> 描述：改进于插入排序，加快元素的移动。将数组分成若干子序列，对每个子序列进行插入排序，然后合并子序列 </para>
        /// <para> 特点：性能取决于如何划分子序列，不适合小规模数组 </para>
        /// </summary>
        public static void ShellSort(IComparable[] array)
        {
            int h = 1;
            while (h < array.Length / 3)
            {
                h *= 3;
            }

            while (h >= 1)
            {
                // 插入排序
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = i; j >= h && Less(array[j], array[j - h]); j--)
                    {
                        Exchange(array, j, j - h);
                    }
                }
                h /= 3;
            }
        }
    }
}
