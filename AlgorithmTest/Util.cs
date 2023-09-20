using System.Data;
using System.Text;

namespace AlgorithmTest
{
    public static class Util
    {

        public static int[] GenerateRandomIntArray(int min, int max, int length, bool canBeRepeated)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            List<int> list = new List<int>();
            for (int i = 0; i < length; i++)
            {
                int toAdd = random.Next(min, max);
                if (!canBeRepeated && list.Contains(toAdd))
                {
                    i--;
                    continue;
                }
                list.Add(toAdd);
            }

            return list.ToArray();
        }


        public static string DataTableToVerticalTableText(DataTable dt, int padNum)
        {
            StringBuilder sb = new StringBuilder();

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
            sb.AppendLine(titleStr);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string rowStr = string.Empty;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string? str = dt.Rows[i][j].ToString();
                    if (str == null)
                        str = string.Empty;
                    if (str.Length >= padNum)
                        str = str.Substring(0, padNum - 2);
                    rowStr += str.PadLeft(padNum);
                }
                sb.AppendLine(rowStr);
            }

            return sb.ToString();
        }
    }
}
