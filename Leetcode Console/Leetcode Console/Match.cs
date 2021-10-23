using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode_Console
{
    internal class Match
    {

        public void Start()
        {
            List<List<string>> tasks = new List<List<string>>() {
                new List<string>() { "result1",     "ab",           ".*c",          "false" },
                new List<string>() { "result2",     "aaaab",        "a*b",          "true" },
                new List<string>() { "result3",     "ab",           ".*..",         "false" },
                new List<string>() { "result4",     "a",            "a.",           "false" },
                new List<string>() { "result5",     "a",            ".*..a*",       "false" },
                new List<string>() { "result6",     "abbbbcd",      "ab*bcd",       "true" },
                new List<string>() { "result7",     "aa",           "a*",           "true" },
                new List<string>() { "result8",     "aab",          "c*a*b",        "true" },
                new List<string>() { "result9",     "mississippi",  "mis*is*ip*.",  "true" },
                new List<string>() { "result10",    "aaa",          "aaaa",         "false" },
                new List<string>() { "result11",    "aaa",          "a.a",          "true" },
                new List<string>() { "result12",    "aaa",          "a*a",          "true" },
                new List<string>() { "result13",    "a",            "ab*",          "true" },
                new List<string>() { "result14",    "a",            "ab*a",         "false" },
                new List<string>() { "result15",    "ab",           ".*..c*",       "true" },
                new List<string>() { "result16",    "abxxxxxxabxxxxxab",             "ab.*....a..*b",             "true" },
                new List<string>() { "result17",    "",             "",             "unset" },
                new List<string>() { "result18",    "",             "",             "unset" },
                new List<string>() { "result19",    "",             "",             "unset" },
                new List<string>() { "result20",    "",             "",             "unset" },
            };

            //bool result17 = new Match().isMatch("ab", ".*..c*");
            //bool result17a = true;
            //Console.WriteLine($"RESULT15 : {result16} - {result16a}");

            if (true)
            {
                var s = tasks.Where(x => x[3] != "unset").Last()[1];
                var p = tasks.Where(x => x[3] != "unset").Last()[2];
                Console.WriteLine($"S = '{s}' && P = '{p}'\n");
                var r = new Match().isMatch(s, p);
                Console.WriteLine($"result = {r} -> should be: {tasks.Where(x => x[3] != "unset").Last()[3]} |||| {tasks.Where(x => x[3] != "unset").Last()[3] == r.ToString().ToLower()}");
            }
            else if (false)
            {
                var s = tasks.Where(x => x[0] == "result17").Last()[1];
                var p = tasks.Where(x => x[0] == "result17").Last()[2];
                Console.WriteLine($"S = '{s}' && P = '{p}'\n");
                var r = new Match().isMatch(s, p);
                Console.WriteLine($"result = {r} -> should be: {tasks.Where(x => x[0] == "result17").Last()[3]} ||||  {tasks.Where(x => x[0] == "result17").Last()[3] == r.ToString().ToLower()}");
            }
            else
            {
                var m = new Match();
                List<string> answers = new List<string>();
                foreach (var task in tasks.Where(x => x[3] != "unset"))
                {
                    var r = m.isMatch(task[1], task[2]);
                    answers.Add($"result = {r} -> should be: {task[3]}");
                    Console.WriteLine($"{task[0]} = {r} -> should be: {task[3]} |||| {r.ToString().ToLower() == task[3]}");
                }
            }
        }
        public bool isMatch(string s, string p)
        {
            int sIndex = s.Length - 1;
            int i = p.Length - 1;
            return Chunking(s, p,sIndex, i);
        }

        private static bool Chunking(string s, string p, int sIndex, int i)
        {
            List<string> chunks = new List<string>();
            int lastChunk = i + 1;
            while(i >= 0)
            {
                if(p[i] == '*')
                {
                    i--;
                    var subString = p.Substring(i, lastChunk-i);
                    chunks.Add(subString);
                    lastChunk = i;
                }else
                {
                    var pChar = p[i];
                    if(i - 1 < 0 || p[i - 1] == '*')
                    {
                        var subString = p.Substring(i, lastChunk - i);
                        chunks.Add(subString);
                        lastChunk = i;
                    }
                }
                i--;
            }
            foreach(var c in chunks)
            {
                Console.WriteLine(c);
            }
                return true;
        }
    }
}
