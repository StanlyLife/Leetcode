using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Leetcode_Console.Codillio
{
    public class Problem
    {

        public void Start()
        {
            solution(0);
            //new DocumentProcessor().Analyze(", A . 1 B 2 C a&^&&%%$##%%^&5656 3 a 4 b 5 c 6 &8&%%$67 jkkk sssff , A . 1 B 2 C a&^&&%%$##%%^&5656 3 a 4 b 5 c 6 &8&%%$67 jkkk sssff , A . 1 B 2 C a&^&&%%$##%%^&5656 3 a 4 b 5 c 6 &8&%%$67 jkkk sssff , A . 1 B 2 C a&^&&%%$##%%^&5656 3 a 4 b 5 c 6 &8&%%$67 jkkk sssff , A . 1 B 2 C a&^&&%%$##%%^&5656 3 a 4 b 5 c 6 &8&%%$67 jkkk sssff , A . 1 B 2 C a&^&&%%$##%%^&5656 3 a 4 b 5 c 6 &8&%%$67 jkkk sssff , A . 1 B 2 C a&^&&%%$##%%^&5656 3 a 4 b 5 c 6 &8&%%$67 jkkk sssff , A . 1 B 2 C a&^&&%%$##%%^&5656 3 a 4 b 5 c 6 &8&%%$67%^&%&^%67457687643576438756438756$%$%$%%4343 jkkk sssff , A . 1 B 2 C a&^&&%%$##%%^&5656 3 a 4 b 5 c 6 &8&%%$67 jkkk sssff , A . 1 B 2 C a&^&&%%$##%%^&5656 3 a 4 b 5 c 6 &8&%%$67 jkkk sssff");
            //new DocumentProcessor().Analyze(", A . 1 B 2    C a&  ^&&%%$##%%^&5656   3 a 4       b 5 c 6");
            //new BattleShip().Start();

        }

        public class BattleShip{
            public void Start()
            {
                var result = solution(new string[] { ".##.#", "#.#..", "#...#", "#.##." });
                //var result =  solution(new string[]{ ".#..#", "##..#", "...#." });
                //var result =  solution(new string[]{ "##.", "#.#", ".##" });
                var r = result;
            }
            public int[] solution(string[] B)
            {


                List<int> BoatLenghts = new List<int>();  
                for(int i = 0; i < B.Length; i++)
                {
                    for(int j = 0; j < B[i].Length; j++)
                    {
                        if (B[i][j] == '#')
                        {
                            BoatLenghts.Add(AmountOfSiblings(i,j,B));
                        }
                        else Console.Write(".");

                    }
                }
                return new int[] { BoatLenghts.Where(x => x == 1).Count(), BoatLenghts.Where(x => x == 2).Count(), BoatLenghts.Where(x => x == 3).Count() };
            }

            public int AmountOfSiblings(int i, int j, string[] B)
            {

                var grid = B[i];
                var gridArray  = grid.ToCharArray();
                gridArray[j] = '.';
                 var s =   new string(gridArray);
                grid = s;
                B[i] = grid;

                if(B.Length == 0 || B[i].Length == 0)
                {
                    return 0;
                }

                var siblings = 1;
                if (i != 0 && B[i - 1][j] == '#')
                    siblings += AmountOfSiblings(i-1,j,B);
                if (i != B.Length - 1 && B[i + 1][j] == '#')
                    siblings += AmountOfSiblings(i+1,j,B);

                if (j != 0 && B[i][j - 1] == '#')
                     siblings += AmountOfSiblings(i , j - 1, B);
                if (j != B[i].Length - 1 && B[i][j + 1] == '#')
                    siblings += AmountOfSiblings(i, j + 1, B);

                return siblings;
            }

         }

        public class DocumentProcessor 
        {
            public Stats Analyze(string document)
            {
                if (string.IsNullOrWhiteSpace(document))
                    throw new ArgumentNullException();
                Stats stats = new Stats();
                string[] wordArray = document.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                var orderedWordArray = wordArray.OrderByDescending(w => w.Length);
                stats.NumberOfAllWords = wordArray.Length;
                stats.NumberOfWordsThatContainOnlyDigits = wordArray.Where(x => IsNumber(x)).ToArray().Length;
                stats.NumberOfWordsStartingWithSmallLetter = wordArray.Where(x =>  IsLowercase(x[0]) && !IsNumber(x[0].ToString())).ToArray().Length;
                stats.NumberOfWordsStartingWithCapitalLetter = wordArray.Where(x => IsCapital(x[0]) && !IsNumber(x[0].ToString())).ToArray().Length;
                stats.TheLongestWord = orderedWordArray.FirstOrDefault();
                stats.TheShortestWord = orderedWordArray.FirstOrDefault(x => x.Length == orderedWordArray.LastOrDefault().Length);
                return stats;
            }

            private static bool IsLowercase(char c){return Regex.IsMatch(c.ToString(), @"^[a-z]");}
            private static bool IsCapital(char c){return Regex.IsMatch(c.ToString(), @"^[A-Z]");}
            bool IsNumber(string documentString)
            {
                foreach (char c in documentString)
                    if (c < '0' || c > '9')
                        return false;
                return true;
            }


        }
        public class Stats
        {
            // Total number of all words in the document
            public int NumberOfAllWords { get; set; }

            // Returns number of words that consist only from digits e.g. 13455, 98374
            public int NumberOfWordsThatContainOnlyDigits { get; set; }

            // Returns number of words that start with a lower letter e.g. a, d, z
            public int NumberOfWordsStartingWithSmallLetter { get; set; }

            // Returns number of words that start with a capital letter e.g. A, D, Z
            public int NumberOfWordsStartingWithCapitalLetter { get; set; }

            // Returns the first longest word in the document
            public string TheLongestWord { get; set; }

            // Returns the first shortest word in the document
            public string TheShortestWord { get; set; }
        }

        public void solution(int N)
        {
            string s = "";
            for(int i = 0; i < N; i++)
            {
                s += "L";
                if (i == N - 1) Console.WriteLine(s);
                else Console.WriteLine("L");
            }
        }
    }
}
