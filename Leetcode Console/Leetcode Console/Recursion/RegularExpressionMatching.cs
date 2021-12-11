using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_Console.Recursion
{
    public  class RegularExpressionMatching
    {
        dynamic[] obj = {
            new { s = "mississ", p = "mis*is*"},
            new { s = "aa", p = "a"},
            new { s = "aaa", p = "aaaa"},
            new { s = "a", p = "a*b*c*d*"},
            new { s = "b", p = "a*b*c*d*"},
            new { s = "bc", p = "a*b*c*d*"},
            new { s = "abc", p = "a*b*c*d*"},
        };
        public void Start()
        {
            foreach(var o in obj)
            {

                var result = recursion(new string(o.s.ToCharArray().Reverse().ToArray()), new string(o.p.ToCharArray().Reverse().ToArray()));
                Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                Console.WriteLine(result);
            }
        }


        public bool recursion(string s, string p)
        {
            if(s == "" && p == "") return true;
            if ((s != "" && p == "")) return false;
            if (p[0] == '*') return HandleStars(s,p);
            if (s != "" && (p[0] == '.' || s[0] == p[0])) return recursion(s.Length > 0 ? s.Substring(1) : "",p.Substring(1));

            return false;
        }
        public bool HandleStars(string s, string p)
        {
            for (int i = 0; i <= s.Length; i++)
            {
                var result = recursion(s.Substring(i), p.Substring(2));
                if (result) return true;
                if ((i == s.Length || s[i] != p[1]) && p[1] != '.') i = s.Length;
            }
            return false;
        }


        //public static string Reverse(string s)
        //{
        //    char[] charArray = s.ToCharArray();
        //    Array.Reverse(charArray);
        //    return new string(charArray);
        //}

        //public bool HandleStars(string s, string p)
        //{

        //    List<string> options = new List<string>();

        //    for (int i = 0; i <= s.Length; i++)
        //    {
        //        options.Add(s.Substring(i));
        //        if ((i == s.Length || s[i] != p[1]) && p[1] != '.')
        //            i = s.Length;
        //    }

        //    foreach (var option in options)
        //    {
        //        var result = recursion(option, p.Substring(2));
        //        if(result)
        //            return true;
        //    } 
        //    return false;
        //}

        //private static List<string> GetOptions(string s, string p)
        //{
        //    List<string> options = new List<string>();

        //    for (int i = 0; i <= s.Length; i++)
        //    {
        //        options.Add(s.Substring(i));
        //        if ((i == s.Length || s[i] != p[1]) && p[1] != '.')
        //            i = s.Length;
        //    }


        //    return options;
        //}
    }
}
