namespace Algorithm.SymbolTable
{
    public interface ISymbolTable<TKey, TValue>
    {
        public void Add(TKey key, TValue value);

        public TValue Get(TKey key);

        public void Remove(TKey key);

        public int Count();
    }
}
