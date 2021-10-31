using BenchmarkDotNet.Running;
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
            var summary = BenchmarkRunner.Run<ContainerWithMostWater> ();
            new ContainerWithMostWater().Start();
        }

        
    }
}
