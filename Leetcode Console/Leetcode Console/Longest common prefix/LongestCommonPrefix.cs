using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode_Console.Longest_common_prefix
{
    public class LongestCommonPrefix
    {
        public void start()
        {
            var strs = new string[] { "floier", "flow", "floght", "fliwra" };
            //var strs = new string[] { "aaa", "aa", "aaa" };
            //var strs = new string[] { "c","cccd", "deec" ,"acc", "ccc", "cdccdscc" };
            //var strs = new string[] { "racecar", "car", "dog" };
            Console.WriteLine(GetLongestCommonPrefix(strs)); 
        }
        public string GetLongestCommonPrefix(string[] strs)
        {
            strs = strs.OrderBy(x => x.Length).ToArray();
            var misStrs = strs.Where(x => x.Substring(0, strs[0].Length) != strs[0]).ToArray();

            for (int i = strs[0].Length; i != 0; i--)
            {
                var match = true;
                for(int j = 0; j < misStrs.Length; j++)
                {
                    if(misStrs[j].Substring(0,i) != strs[0].Substring(0, i))
                    {
                        match = false;
                        j = misStrs.Length;
                    }
                }
                if (match)
                {
                    return strs[0].Substring(0, i);
                }
            }
            return "";
        }
    }
}
