using System;
using System.Collections.Generic;
using System.Linq;

namespace CodesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //List<int> predators = new List<int>(new int[] { -1, 8, 6, 0, 7, 3, 8, 9, -1, 6 });
            List<int> predators = new List<int>(new int[] { -1, 0, 1 });
            minimumGroups(predators);
        }
        public static int minimumGroups(List<int> predators)
        {
            int count = 1;
            List<int> array = predators.Select((s, i) => new { i, s }).Where(t => t.s == -1).Select(t => t.i).ToList();
            while (array.Any())
            {
                List<int> array2 = new List<int>();
                array2.AddRange(array);
                array.Clear();
                foreach (var item in array2)
                {
                    array.AddRange(predators.Select((s, i) => new { i, s }).Where(t => t.s == item).Select(t => t.i).ToList());

                }
                if (array.Any())
                    count++;
            }
            return count;
        }
    }
}
