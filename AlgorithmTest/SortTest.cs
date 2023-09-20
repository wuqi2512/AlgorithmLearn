using Algorithm.Sort;
using System.Diagnostics;
using System.Reflection;

namespace AlgorithmTest
{
    [TestClass]
    public class SortTest
    {
        [TestMethod]
        [DataRow(1000, 10000, 1000)]
        public void TestAllSortAlgorithm(int min, int max, int length)
        {
            var array = GenerateRandomIntArray(min, max, 1000, false);
            Stopwatch timer = new Stopwatch();

            MethodInfo[] methods = typeof(SortAlgorithm).GetMethods();
            Console.WriteLine($"Range: [{min}, {max}), Length: {length}");
            foreach (MethodInfo method in methods)
            {
                if (method.Name.EndsWith("Sort"))
                {
                    var copy = new IComparable[array.Length];
                    Array.Copy(array, copy, array.Length);
                    SortMethodTest(method, copy, timer);

                    Console.Write($"{method.Name}:".PadRight(20) + timer.ElapsedTicks.ToString().PadLeft(10) + " Ticks ");
                    Console.Write($"{SortAlgorithm.IsSorted(copy)}:  ");
                    for (int i = 0; i < array.Length; i++)
                    {
                        Console.Write(array[i] + "  ");
                        if (i == 99)
                        {
                            Console.Write(" ...");
                            break;
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        public static long SortMethodTest(MethodInfo method, IComparable[] array, Stopwatch timer)
        {
            timer.Restart();
            method.Invoke(null, new object[] { array });
            timer.Stop();

            return timer.ElapsedTicks;
        }

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
    }
}