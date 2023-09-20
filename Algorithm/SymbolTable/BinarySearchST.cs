namespace Algorithm.SymbolTable
{
    public class BinarySearchST<TKey, TValue> : ISymbolTable<TKey, TValue> where TKey : IComparable
    {
        private TKey[] keys;
        private TValue[] values;
        private int count;

        public BinarySearchST(int capacity = 32)
        {
            keys = new TKey[capacity];
            values = new TValue[capacity];
        }

        public void Remove(TKey key)
        {
            int i = BinarySearch(keys, key, 0, count - 1);
            if (i < 0)
                return;
            else
            {
                for (int j = i; j < count; j++)
                {
                    keys[j] = keys[j + 1];
                    values[j] = values[j + 1];
                }
                count--;
            }
        }

        private void Resize(int capacity)
        {
            TKey[] newKeys = new TKey[capacity];
            TValue[] newValues = new TValue[capacity];

            for (int i = 0; i < count; i++)
            {
                newKeys[i] = keys[i];
                newValues[i] = values[i];
            }
            keys = newKeys;
            values = newValues;
        }

        public TValue Get(TKey key)
        {
            if (count == 0)
                return default;
            int i = BinarySearch(keys, key, 0, count - 1);
            if (i < count && key.CompareTo(keys[i]) == 0)
                return values[i];
            else
                return default;
        }

        public void Add(TKey key, TValue value)
        {
            if (count == keys.Length)
            {
                Resize(count * 2);
            }

            int rs = BinarySearch(keys, key, 0, count - 1);
            if (rs < count && key.CompareTo(keys[rs]) == 0)
            {
                values[rs] = value;
                return;
            }
            for (int i = count; i > rs; i--)
            {
                keys[i] = keys[i - 1];
                values[i] = values[i - 1];
            }
            keys[rs] = key;
            values[rs] = value;
            count++;
        }

        public int Count()
        {
            return count;
        }

        private int BinarySearch(TKey[] array, TKey key, int low, int high)
        {
            // if (high < low || low < 0 || high > array.Length)
            //    return -1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                int comp = key.CompareTo(array[mid]);
                if (comp < 0)
                    high = mid - 1;
                else if (comp > 0)
                    low = mid + 1;
                else
                    return mid;
            }

            // return -1;
            return low;
        }
    }
}
