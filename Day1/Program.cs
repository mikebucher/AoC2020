using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string strReadFile = @"C:\Dev\AoC2020\Day1.txt";
            int result = 0;

            var fileLines = File.ReadAllLines(strReadFile).ToList();

            List<int> numbers = new List<int>();

            foreach (var item in fileLines)
            {
                numbers.Add(Convert.ToInt32(item));
            }


            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < numbers.Count; j++)
                {
                    for (int k = 0; k < numbers.Count; k++)
                    {
                        if(i != j && i != k && j != k)
                        {
                            if((numbers[i] + numbers[j] + numbers[k]) == 2020)
                            {
                                result = numbers[i] * numbers[j] * numbers[k];
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Result: " + result.ToString());
            Console.ReadKey();
        }
    }
}
