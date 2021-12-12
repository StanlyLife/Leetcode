using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_Console.ThreeSum
{
    public class _3Sum
    {
        public void Start()
        {
            int[] nums = { -1, 0, 1, 2, -1, -4 };
            int[,] result = Sum(nums);
            Console.WriteLine(result);
        }

        public int[,] Sum(int[] nums)
        {
            int i = 0;
            List<List<int>> list = new List<List<int>>();   
            while(nums.Length > 0)
            {
                var nums2 = nums.Skip(1).ToArray();
                while (nums2.Length > 0)
                {
                    for (int k = 1; k < nums2.Length; k++)
                    {
                        if (k == 0) continue;
                        if (nums[0] + nums2[0] + nums2[k] == 0 && !ListContains(new List<int>() { nums[0], nums2[0], nums2[k] }, list)) list.Add(new List<int>() {nums[0], nums2[0],nums2[k] });
                    }
                    nums2 = nums2.Skip(1).ToArray();
                }
                nums = nums.Skip(1).ToArray();
                i++;
            }

            return new int[,]{ { -1, 0, 1, 2, -1, -4 } , { -1, 0, 1, 2, -1, -4 } };
        }
        public bool ListContains(List<int> nums, List<List<int>> list)
        {
            var x = nums;
            x.Sort();
            var sortedList = list;
            foreach(var l in sortedList)
            {
                l.Sort();
            }
            if(list.Contains(x))
                return true;
            return false;
        }
    }
}
