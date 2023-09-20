using System.Data;
using System.Diagnostics;
using static Algorithm.Sort.SortAlgorithm;

namespace AlgorithmTest
{
    [TestClass]
    public class SortTest
    {
        [TestMethod]
        [DataRow(1000, 10000, 1000)]
        public void TestAllSortAlgorithm(int min, int max, int length)
        {
            var array = Util.GenerateRandomIntArray(min, max, 1000, false);
            Stopwatch timer = new Stopwatch();
            Action<IComparable[]>[] sorts = new Action<IComparable[]>[]
            {
                HeapSort,
                InsertionSort,
                InPlace_MergeSort,
                TopDown_MergeSort,
                BottomUp_MergeSort,
                QuickSort,
                SelectionSort,
                ShellSort,
            };

            long[] time = new long[sorts.Length];
            bool[] success = new bool[sorts.Length];
            string[] arrayStr = new string[sorts.Length];
            int NumberPad = max.ToString().Length + 2;

            for (int i = 0; i < sorts.Length; i++)
            {
                var copyArray = new IComparable[array.Length];
                Array.Copy(array, copyArray, array.Length);

                timer.Restart();
                sorts[i].Invoke(copyArray);
                timer.Stop();

                time[i] = timer.ElapsedTicks;
                success[i] = IsSorted(copyArray);
                string temp = string.Empty;
                for (int j = 0; j < copyArray.Length && j < 100; j++)
                {
                    temp += copyArray[j].ToString().PadLeft(NumberPad);
                }
                arrayStr[i] = temp;
            }

            Console.WriteLine($"Range: [{min}, {max}), Length: {length}");
            string table = Util.DataTableToVerticalTableText(CreateDataTable(sorts, time, success), 15);
            Console.WriteLine(table);

            for (int i = 0; i < sorts.Length; i++)
            {
                Console.Write(sorts[i].Method.Name.PadRight(20));
                Console.WriteLine(arrayStr[i]);
            }
        }

        private DataTable CreateDataTable(Action<IComparable[]>[] sorts, long[] time, bool[] success)
        {
            DataTable dataTable = new DataTable("SortTestTable");

            dataTable.Columns.Add("Algorithm");
            dataTable.Columns.Add("Ticks");
            dataTable.Columns.Add("Success");

            for (int i = 0; i < sorts.Length; i++)
            {
                dataTable.Rows.Add(sorts[i].Method.Name, time[i], success[i]);
            }

            return dataTable;
        }
    }
}