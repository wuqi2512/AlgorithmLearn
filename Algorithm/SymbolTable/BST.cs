namespace Algorithm.SymbolTable
{
    /// <summary>
    /// 用链表，递归实现的二叉搜索树
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class BST<TKey, TValue> : ISymbolTable<TKey, TValue> where TKey : IComparable
    {
        private Node Root;
        private int count;

        public TValue Get(TKey key)
        {
            Node c = Root;
            while (c != null)
            {
                int cmp = key.CompareTo(c.Key);
                if (cmp < 0)
                    c = c.Left;
                else if (cmp > 0)
                    c = c.Right;
                else
                    return c.Value;
            }
            return default;
        }

        /// <summary>
        /// 添加；如果已存在key，会修改为新value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(TKey key, TValue value)
        {
            if (Root == null)
            {
                Root = new Node(key, value);
                count++;
                return;
            }
            Node current = Root;
            while (current != null)
            {
                int cmp = key.CompareTo(current.Key);
                if (cmp < 0)
                {
                    if (current.Left == null)
                    {
                        current.Left = new Node(key, value);
                        count++;
                        return;
                    }
                    current = current.Left;
                }
                else if (cmp > 0)
                {
                    if (current.Right == null)
                    {
                        current.Right = new Node(key, value);
                        count++;
                        return;
                    }
                    current = current.Right;
                }
                else
                {
                    current.Value = value;
                    return;
                }
            }
        }

        public void Remove(TKey key)
        {
            // 树为空
            if (Root == null)
                return;

            Node parent = null;
            Node current = Root;
            while (current != null)
            {
                parent = current;
                int cmp = key.CompareTo(current.Key);
                if (cmp < 0)
                    current = current.Left;
                else if (cmp > 0)
                    current = current.Right;
                else
                    break;
            }
            if (current == null)
            {
                return;
            }
            // 删除节点一侧为空或两侧都为空
            if (current.Left == null || current.Right == null)
            {
                Node child = current.Left == null ? current.Right : current.Left;
                // 删除节点一侧为空
                if (child != null)
                {
                    current.Key = child.Key;
                    current.Value = child.Value;
                    current.Left = child.Left;
                    current.Right = child.Right;
                }
                // 删除节点两侧都为空
                else
                {
                    if (current == Root)
                    {
                        Root = null;
                    }
                    else if (parent.Left == current)
                    {
                        parent.Left = null;
                    }
                    else
                    {
                        parent.Right = null;
                    }
                }
            }
            else
            {
                Node minP = current;
                Node min = current.Right;
                while (min.Left != null)
                {
                    minP = min;
                    min = min.Left;
                }
                current.Key = min.Key;
                current.Value = min.Value;
                if (min.Right != null)
                {
                    min.Key = min.Right.Key;
                    min.Value = min.Right.Value;
                    min.Left = min.Right.Left;
                    min.Right = min.Right.Right;
                }
                else
                {
                    if (minP.Left == min)
                        minP.Left = null;
                    else
                        minP.Right = null;
                }
            }
            count--;
        }

        public int Count()
        {
            return count;
        }

        private class Node
        {
            public TKey Key;
            public TValue Value;
            public Node Left;
            public Node Right;

            public Node(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}
