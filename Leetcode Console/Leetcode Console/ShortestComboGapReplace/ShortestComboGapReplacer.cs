using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_Console.ShortestComboGapReplace
{
    public class ShortestComboGapReplacer
    {
        /*
         * This code is optimized for runtime, not readability
         */
        public void Start()
        {
            Console.WriteLine(solution("??b??"));
        }

        public int solution(string S)
        {
            var a = S.ToCharArray();
            int longestLength = 1;
            List<int> LongestLengths = new List<int>();
            for(int i = 0; i < a.Length; i++)
            {
                StringReplace(S, a, i);
                if(i == 0) { continue; }
                if(a[i] == a[i - 1])
                {
                    longestLength++;
                }else
                {
                    LongestLengths.Add(longestLength);
                    longestLength = 1;
                }
            }
            LongestLengths.Add(longestLength);
            Console.WriteLine(new String(a));
            return LongestLengths.Any() ? LongestLengths.Max() : 0;
        }

        private void StringReplace(string S, char[] a, int i)
        {
            if (a[i] == '?')
            {
                var left = '?';
                var right = left;
                if(i != 0)
                    left = a[i - 1];
                if(i != S.Length - 1)
                    right = a[i + 1];

                if(left == '?' && right == '?')
                {
                    a[i] = countQuestionMarksUntilChar(i, S);
                }
                else
                if (left == '?') { a[i] = right == 'a' ? 'b' : 'a'; } else
                if (right == '?') { a[i] = left == 'a' ? 'b' : 'a'; } else
                {
                    var countLeft = countSide(i, "l", S);
                    var countRight = countSide(i, "r", S);
                    if (left == right) { a[i] = left == 'a' ? 'b' : 'a'; }
                    else { a[i] = countLeft > countRight ? right : left; }
                }
            }
        }
        private char countQuestionMarksUntilChar(int index, string S)
        {
            var a = S.ToCharArray();
            var counter = 0;
            while(a[index] != '?' && index != 0 && index != a.Length - 1)
            {counter++; index++; }
            if(a[index] == 'a')
            {
                if (counter % 2 == 0)
                    return 'a';
                return 'b';
            }
            else
            {
                if (counter % 2 == 0)
                    return 'b';
                return 'a';
            }
        }

        public int countSide(int index, string lr, string S)
        {
            var a = S.ToCharArray();
            var counter = 0;
            if(lr == "l")
            {
                index--;
                var i = index;
                while(a[index] == a[i] && i > 0)
                {
                    counter++;
                    i--;
                }
            }
            if (lr == "r")
            {
                index++;
                var i = index;
                while (a[index] == a[i] && i < a.Length - 1)
                {
                    counter++;
                    i++;
                }
            }

            return counter;
        }
    }
}
