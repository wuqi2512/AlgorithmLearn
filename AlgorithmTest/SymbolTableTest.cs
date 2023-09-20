using Algorithm.SymbolTable;
using System.Data;

namespace AlgorithmTest
{
    [TestClass]
    public class SymbolTableTest
    {
        [TestMethod]
        [DataRow(1000, 1200, 1000)]
        public void TestAllST(int min, int max, int length)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            ISymbolTable<int, int>[] sts = new ISymbolTable<int, int>[] { new BST<int, int>(), new BinarySearchST<int, int>(), new LinearProbingHashST<int, int>() };

            // 添加数据
            var datas = Util.GenerateRandomIntArray(min, max, length, true);
            foreach (var key in datas)
            {
                if (dic.ContainsKey(key))
                    dic[key]++;
                else
                    dic[key] = 1;

                foreach (var st in sts)
                {
                    if (st.Get(key) != default(int))
                        st.Add(key, st.Get(key) + 1);
                    else
                        st.Add(key, 1);
                }
            }
            // 删除数据
            int[] deleteIndex = Util.GenerateRandomIntArray(0, dic.Count, dic.Count / 2, false);
            int[] deleteKeys = new int[deleteIndex.Length];
            for (int i = 0; i < deleteIndex.Length; i++)
                deleteKeys[i] = dic.ElementAt(deleteIndex[i]).Key;
            foreach (var key in deleteKeys)
            {
                dic.Remove(key);
                foreach (var st in sts)
                {
                    st.Remove(key);
                }
            }

            Console.WriteLine($"Range: [{min},{max}), Length: {length}");
            string table = Util.DataTableToVerticalTableText(CreateDataTable(dic, sts), 10);
            Console.WriteLine(table);
        }

        private DataTable CreateDataTable(Dictionary<int, int> dic, ISymbolTable<int, int>[] sts)
        {
            DataTable dataTable = new DataTable("SymbolTaleTestTable");

            dataTable.Columns.Add("Key");
            dataTable.Columns.Add("Dictionary");
            for (int j = 0; j < sts.Length; j++)
                dataTable.Columns.Add(sts[j].GetType().Name);

            var sortedDic = dic.OrderByDescending(p => p.Value).ToList();
            string[] temp = new string[sts.Length + 2];
            for (int i = 0; i < sortedDic.Count; i++)
            {
                int key = sortedDic[i].Key;
                temp[0] = key.ToString();
                temp[1] = dic[key].ToString();
                for (int j = 2; j < temp.Length; j++)
                    temp[j] = sts[j - 2].Get(key).ToString();
                dataTable.Rows.Add(temp);
            }

            temp[0] = "Count";
            temp[1] = dic.Count.ToString();
            for (int j = 2; j < temp.Length; j++)
                temp[j] = sts[j - 2].Count().ToString();
            dataTable.Rows.Add(temp);

            return dataTable;
        }
    }
}
