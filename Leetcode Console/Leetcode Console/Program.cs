using BenchmarkDotNet.Running;
using Leetcode_Console.BinaryGap;
using Leetcode_Console.Codillio;
using Leetcode_Console.Longest_common_prefix;
using Leetcode_Console.Longest_Palindromic_Substring;
using Leetcode_Console.Ole;
using Leetcode_Console.Recursion;
using Leetcode_Console.ShortestComboGapReplace;
using Leetcode_Console.ThreeSum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode_Console
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //new Match().Start();
            //new ContainerWithMostWater().Start();
            //new LongestCommonPrefix().start();
            //new BinaryGapC().Start();
            //new ShortestComboGapReplacer().Start();
            //new RecursionTraining().Start();
            //new RegularExpressionMatching().Start();
            //new LPS().Start();
            //new _3Sum().Start();
            //new Problem().Start();
            RunOle();
        }
        public static void RunOle()
        {
            List<string> l = new List<string>() { "aa", "aaaaaaaaaa", "aaaaaa", };
            //List<string> l = new List<string>() { "xxxxx","xxxxxxxx","xxxxxxxxx", "xxxxxxx", "lpk", "zyyggqfiz", "sbf", "tr", "tgluvn"};
            l.Sort();
            l.Reverse();

            for(int i = l.Count() - 1;  0 <= i; i--)
            {
                Console.WriteLine(l[i]);
            }

        }




    }
}
