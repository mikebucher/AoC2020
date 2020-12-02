using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string strReadFile = @"C:\Dev\AoC2020\Day2.txt";
            int result = 0;
            int lowerBound = 0;
            int higherBound = 0;
            char requirement;
            string password;

            var fileLines = File.ReadAllLines(strReadFile).ToList();

            foreach (var line in fileLines)
            {
                bool req1 = false;
                bool req2 = false;
                
                var array = line.Split(' ');

                var limits = array[0].Split('-');
                lowerBound = Convert.ToInt32(limits[0]) - 1;
                higherBound = Convert.ToInt32(limits[1]) - 1;

                requirement = char.Parse(array[1].Split(':')[0]);

                password = array[2];

                if (password.IndexOf(requirement, lowerBound) == lowerBound) req1 = true;
                if (password.IndexOf(requirement, higherBound) == higherBound) req2 = true;

                if ((req1 && !req2) || (!req1 && req2)) result++;
            }

            Console.WriteLine("Result: " + result.ToString());
            Console.ReadKey();
        }
    }
}
