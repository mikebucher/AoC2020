using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileLines = File.ReadAllLines(@"C:\Dev\AoC2020\Day6.txt").ToList();
            List<char> answers = new List<char>();
            int result = 0;
            int i = 0;
            List<char> questions = new List<char>();

            foreach (var line in fileLines)
            {
                if(!String.IsNullOrEmpty(line))
                {
                    foreach (char letter in line)
                    {
                        answers.Add(letter);
                        if (!questions.Contains(letter)) questions.Add(letter);
                    }
                    i++;
                }
                else
                {
                    foreach (var letter in questions)
                    {
                        if (answers.Count(x => x == letter) == i) result++; 
                    }
                    answers = new List<char>();
                    questions = new List<char>();
                    i = 0;
                }
            }
            foreach (var letter in questions)
            {
                if (answers.Count(x => x == letter) == i) result++;
            }

            Console.WriteLine("Result: " + result.ToString());
            Console.ReadLine();
        }
    }
}
