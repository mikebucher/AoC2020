using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileLines = File.ReadAllLines(@"C:\Dev\AoC2020\Day5.txt").ToList();
            int result = 0;
            List<int> seats = new List<int>();


            foreach (var line in fileLines)
            {
                string row = line.Substring(0, 7);
                string column = line.Substring(7, 3);

                row = row.Replace('F', '0');
                row = row.Replace('B', '1');
                column = column.Replace('L', '0');
                column = column.Replace('R', '1');

                int rowNumber = Convert.ToInt32(row, 2);
                int columnNumber = Convert.ToInt32(column, 2);

                int seatId = (rowNumber * 8) + columnNumber;
                seats.Add(seatId);
            }

            seats.Sort();
            int temp = seats[0] - 1;

            foreach (var item in seats)
            {
                if(item != temp + 1)
                {
                    result = item - 1;
                    break;
                }
                else
                {
                    temp = item;
                }
            }

            Console.WriteLine("Result: " + result.ToString());
            Console.ReadLine();
        }
    }
}
