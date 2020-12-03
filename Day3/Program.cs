using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string strReadFile = @"C:\Dev\AoC2020\Day3.txt";
            var fileLines = File.ReadAllLines(strReadFile).ToList();

            int slope1 = 0;
            int slope2 = 0;
            int slope3 = 0;
            int slope4 = 0;
            int slope5 = 0;

            int mod = fileLines[0].Length;
            int x = 0;
            for (int y = 0; y < fileLines.Count; y++)
            {
                string currentLine = fileLines[y];
                if (currentLine[x % mod] == '#') slope1++;
                x += 1;
            }

            x = 0;
            for (int y = 0; y < fileLines.Count; y++)
            {
                string currentLine = fileLines[y];
                if (currentLine[x % mod] == '#') slope2++;
                x += 3;
            }

            x = 0;
            for (int y = 0; y < fileLines.Count; y++)
            {
                string currentLine = fileLines[y];
                if (currentLine[x % mod] == '#') slope3++;
                x += 5;
            }

            x = 0;
            for (int y = 0; y < fileLines.Count; y++)
            {
                string currentLine = fileLines[y];
                if (currentLine[x % mod] == '#') slope4++;
                x += 7;
            }

            x = 0;
            for (int y = 0; y < fileLines.Count; y+=2)
            {
                string currentLine = fileLines[y];
                if (currentLine[x % mod] == '#') slope5++;
                x += 1;
            }

            //result1 Is wrong here, it results in an integer overflow for some reason. I left it in, because I thought it was interesting
            long result1 = slope1 * slope2 * slope3 * slope4 * slope5;
            long result2 = slope1 * slope2;
            result2 *= slope3;
            result2 *= slope4;
            result2 *= slope5;

            //Result: -253582568
            Console.WriteLine("Result: " + result1.ToString());
            //Result: 8336352024
            Console.WriteLine("Result: " + result2.ToString());
            Console.ReadLine();
        }
    }
}
