namespace Algorithm.SymbolTable
{
    public class LinearProbingHashST<TKey, TValue> : ISymbolTable<TKey, TValue>
    {
        private TKey[] keys;
        private TValue[] values;
        private int count;
        private int capacity;

        public LinearProbingHashST(int capacity = 32)
        {
            keys = new TKey[capacity];
            values = new TValue[capacity];
            this.capacity = capacity;
        }

        public void Add(TKey key, TValue value)
        {
            if (count >= capacity / 2)
            {
                Resize(capacity * 2);
            }

            int i;
            for (i = Hash(key); !keys[i].Equals(default(TKey)); i = (i + 1) % capacity)
            {
                if (key.Equals(keys[i]))
                {
                    values[i] = value;
                    return;
                }
            }
            keys[i] = key;
            values[i] = value;
            count++;
        }

        public int Count()
        {
            return count;
        }

        public TValue Get(TKey key)
        {
            for (int i = Hash(key); !keys[i].Equals(default(TKey)); i = (i + 1) % capacity)
            {
                if (key.Equals(keys[i]))
                {
                    return values[i];
                }
            }
            return default;
        }

        public void Remove(TKey key)
        {
            if (Get(key).Equals(default(TValue)))
                return;

            int i = Hash(key);
            while (!key.Equals(keys[i]))
                i = (i + 1) % capacity;
            keys[i] = default;
            values[i] = default;
            count--;

            i = (i + 1) % capacity;
            while (!keys[i].Equals(default(TKey)))
            {
                TKey keyTemp = keys[i];
                TValue valTemp = values[i];
                keys[i] = default;
                values[i] = default;
                count--;
                Add(keyTemp, valTemp);
                i = (i + 1) % capacity;
            }

            if (count > 0 && count == capacity / 8)
            {
                Resize(capacity / 2);
            }
        }

        private int Hash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) % capacity;
        }

        private void Resize(int newCapacity)
        {
            var newST = new LinearProbingHashST<TKey, TValue>(newCapacity);
            for (int i = 0; i < capacity; i++)
            {
                if (!keys[i].Equals(default(TKey)))
                    newST.Add(keys[i], values[i]);
            }

            keys = newST.keys;
            values = newST.values;
            capacity = newST.capacity;
        }
    }
}
