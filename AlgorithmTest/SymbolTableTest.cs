using Algorithm.SymbolTable;
using AlgorithmLearn.SymbolTable;
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
            var datas = SortTest.GenerateRandomIntArray(min, max, length, true);
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
            int[] deleteIndex = SortTest.GenerateRandomIntArray(0, dic.Count, dic.Count / 2, false);
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

            // 打印数据
            PrintDataTable(CreateDataTable(dic, sts));
        }


        public static void PrintDataTable(DataTable dt)
        {
            int padNum = 10;

            string titleStr = string.Empty;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string columnName = dt.Columns[i].ColumnName;
                if (columnName.Length >= padNum)
                {
                    columnName = columnName.Substring(0, padNum - 2);
                }
                titleStr += columnName.PadLeft(padNum);
            }
            Console.WriteLine(titleStr);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string columnStr = string.Empty;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string? value = dt.Rows[i][j].ToString();
                    if (string.IsNullOrEmpty(value)) value = "null";
                    columnStr += value.PadLeft(padNum);
                }
                Console.WriteLine(columnStr);
            }
        }

        public static DataTable CreateDataTable(Dictionary<int, int> dic, ISymbolTable<int, int>[] sts)
        {
            DataTable dataTable = new DataTable("Table");

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
