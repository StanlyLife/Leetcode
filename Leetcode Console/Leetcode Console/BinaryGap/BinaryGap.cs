using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_Console.BinaryGap
{
    public class BinaryGapC
    {

        public void Start()
        {
            solution(1041);
        }

        public int solution(int N)
        {
            string binary = Convert.ToString(N, 2);
            Console.WriteLine(binary);
            var ba = binary.ToCharArray();
            var state = false;
            var counts = new List<int>();
            var counter = 0;
            for (int i = 0; i < ba.Length; i++){
                if(ba[i] == '1')
                {
                    if(i + 1 < ba.Length && ba[i + 1] == '0')
                    {
                        if(i - 1 >= 0 && ba[i - 1] == '0')
                        {
                            counts.Add(counter);
                            counter = 0;
                        }else
                        {
                            state = true;
                        }
                    }else
                    {
                        state = false;
                        counts.Add(counter);
                    }
                }else
                {
                    if (state) {
                        counter++;
                    }else
                    {
                        counter = 0;
                    }
                }
            }
            
            return counts.Any() ? counts.Max() : 0;
        }

    }
}
