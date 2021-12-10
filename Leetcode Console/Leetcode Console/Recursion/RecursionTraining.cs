using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_Console.Recursion
{
    public class RecursionTraining
    {
        public int[] a = { 5, 2, 8, 6, 3, 6, 9 };
        public void Start()
        {
            //var t = Recursion(5);
            var index = 0;
            var t = LongestIncreasingSubSequence(a[index],index, index);

        }
        private int LongestIncreasingSubSequence(int number, int index, int oldIndex)
        {
            var IndexList = new List<int>();
            if(oldIndex == a.Length - 1 && index == a.Length - 1)
                return 0;
            if (index == a.Length - 1)
                return LongestIncreasingSubSequence(a[oldIndex + 1], oldIndex + 1, oldIndex + 1);
            if (number < a[index])
            {
                IndexList.Add(index);
                Console.WriteLine($"num: {number} < {a[index]}");
                return LongestIncreasingSubSequence(a[index], index + 1, oldIndex);
            }
            if (number >= a[index])
                return LongestIncreasingSubSequence(number, index + 1, oldIndex);

            foreach(int i in IndexList)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Finnished");
            return 1;
        }
        private int PartitionsPerPart(int n, int m)
        {
            if(n == 1)
                return 1;
            if (m == 0 || n < 0)
                return 0;
            return PartitionsPerPart(n-m, m) + PartitionsPerPart(n, m-1);
        }

        private int UniquePaths(int length, int height)
        {
            if(length == 1 || height == 1)
                return 1;
            return UniquePaths(length, height - 1) + UniquePaths(length - 1, height);
        }

        public int Recursion(int num)
        {
            if(num == 0) { return 0; }
            return num + Recursion(num - 1);
        }
    }
}
