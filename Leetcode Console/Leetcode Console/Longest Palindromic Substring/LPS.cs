using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_Console.Longest_Palindromic_Substring
{
    public class LPS
    {
        public void Start()
        {
            /*Recursive*/
            var resultRecursive = LongestPalindrome("ac");
            /*Iterative*/
            var resultIterative = LongestPalindrome("ac");
            Console.WriteLine(resultIterative);
        }
        #region Iterative
        public string LongestPalindrome(string s)
        {
            string lp = "";
            for(int i = 0; i < s.Length; i++)
            {
                var even = LongestPalindromeOdd(s, i);
                var odd = LongestPalindromeEven(s, i);
                var result = even.Length > odd.Length ? even : odd;
                lp = result.Length > lp.Length ? result : lp;
            }
            return lp;
        }

        public string LongestPalindromeOdd(string s, int index)
        {
            string lp = "";
            int indexReverse = index;
            while(indexReverse >= 0 && index <= s.Length - 1 && s[index] == s[indexReverse])
            {
                lp = s.Substring(indexReverse, index - indexReverse + 1);
                index++;
                indexReverse--;
            }
            return lp;
        }
        public string LongestPalindromeEven(string s, int index)
        {
            string lp = "";
            int indexReverse = index;
            index++;
            while (indexReverse >= 0 && index <= s.Length - 1 && s[index] == s[indexReverse])
            {
                lp = s.Substring(indexReverse, index - indexReverse + 1);
                index++;
                indexReverse--;
            }
            return lp;
        }
        #endregion

        #region recursivee
        public string LongestPalindromeRecursion(string s)
        {
            if (s.Length == 1) { return ""; }
            if (s == Reverse(s)) return s;
            var a = LongestPalindrome(s.Substring(1, s.Length - 1));
            var b = LongestPalindrome(s.Substring(0, s.Length - 1));
            return a.Length > b.Length ? a : b;
        }
        public string Reverse(string srtVarable)
        {
            return new string(srtVarable.Reverse().ToArray());
        }
        #endregion
    }
}
