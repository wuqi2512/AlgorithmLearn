namespace Algorithm.Sort
{
    public static partial class SortAlgorithm
    {
        /// <summary>
        /// 原地自顶向下的归并排序
        /// <para> 描述：使用内存反转(O(1))实现自顶向下的归并排序，本算法中使用 Array.Reverse()(O(n)) 实现内存反转的效果 </para>
        /// <para> 特点： </para>
        /// </summary>
        public static void InPlace_MergeSort(IComparable[] array)
        {
            InPlace_MergeRecursion(array, 0, array.Length - 1);
        }
        public static void InPlace_MergeRecursion(IComparable[] array, int low, int high)
        {
            // 子序列规模较小时使用插入排序使其有序
            if (high - low <= 15)
            {
                InsertionSubarray(array, low, high);
                return;
            }

            int mid = low + (high - low) / 2;
            InPlace_MergeRecursion(array, low, mid);
            InPlace_MergeRecursion(array, mid + 1, high);

            // 测试子序列是否有序
            if (Less(array[mid], array[mid + 1]))
                return;

            InPlace_MergeSubarray(array, low, mid, high);
        }
        public static void InPlace_MergeSubarray(IComparable[] array, int low, int mid, int high)
        {
            int i = low;
            int j = mid + 1;

            while (i < j && j <= high)
            {
                while (i < j && Less(array[i], array[j]))
                {
                    i++;
                }
                int temp = j;
                while (j <= high && Less(array[j], array[i]))
                {
                    j++;
                }

                MemoryReversal(array, i, temp - i, j - temp);

                i += j - temp;
            }
        }
        public static void MemoryReversal(IComparable[] array, int start, int length1, int length2)
        {
            Array.Reverse(array, start, length1);
            Array.Reverse(array, start + length1, length2);
            Array.Reverse(array, start, length2 + length1);
        }


        /// <summary>
        /// 自顶向下的归并排序
        /// <para> 描述：用递归实现的归并排序 </para>
        /// <para> 特点： </para>
        /// </summary>
        public static void TopDown_MergeSort(IComparable[] array)
        {
            IComparable[] auxiliary = new IComparable[array.Length];
            TopDown_MergeRecursion(array, auxiliary, 0, array.Length - 1);
        }
        public static void TopDown_MergeRecursion(IComparable[] array, IComparable[] auxiliary, int low, int high)
        {
            // 子序列规模较小时使用插入排序使其有序
            if (high - low <= 15)
            {
                InsertionSubarray(array, low, high);
                return;
            }

            int mid = low + (high - low) / 2;
            TopDown_MergeRecursion(array, auxiliary, low, mid);
            TopDown_MergeRecursion(array, auxiliary, mid + 1, high);
            MergeSubarray(array, auxiliary, low, mid, high);
        }
        public static void MergeSubarray(IComparable[] array, IComparable[] auxiliary, int low, int mid, int high)
        {
            int i = low;
            int j = mid + 1;

            Array.Copy(array, low, auxiliary, low, high - low + 1);

            for (int k = low; k <= high; k++)
            {
                if (i > mid)
                    array[k] = auxiliary[j++];
                else if (j > high)
                    array[k] = auxiliary[i++];
                else if (Less(auxiliary[j], auxiliary[i]))
                    array[k] = auxiliary[j++];
                else
                    array[k] = auxiliary[i++];
            }
        }


        /// <summary>
        /// 自底向上的排序
        /// <para> 描述：用迭代实现的归并排序 </para>
        /// <para> 特点：适合用于链表排序，能实现为原地排序 </para>
        /// </summary>
        public static void BottomUp_MergeSort(IComparable[] array)
        {
            IComparable[] auxiliary = new IComparable[array.Length];
            for (int i = 1; i < array.Length; i += i)
            {
                for (int j = 0; j < array.Length - i; j += i + i)
                {
                    MergeSubarray(array, auxiliary, j, j + i - 1, Math.Min(array.Length - 1, j + i + i - 1));
                }
            }
        }
    }
}
