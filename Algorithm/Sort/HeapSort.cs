namespace Algorithm.Sort
{
    public static partial class SortAlgorithm
    {
        /// <summary>
        /// 从零开始
        /// </summary>
        /// <param name="array"></param>
        public static void HeapSort(IComparable[] array)
        {
            int length = array.Length - 1;
            for (int i = (length - 1) / 2; i >= 0; i--)
            {
                Sink(array, i, length);
            }

            while (length >= 1)
            {
                Exchange(array, 0, length--);
                Sink(array, 0, length);
            }
        }

        private static void Sink(IComparable[] array, int index, int lastIndex)
        {
            while (index * 2 + 1 <= lastIndex)
            {
                int i = index * 2 + 1;
                if (i < lastIndex && Less(array[i], array[i + 1]))
                    i++;
                if (!Less(array[index], array[i]))
                    break;
                Exchange(array, index, i);
                index = i;
            }
        }
    }
}
