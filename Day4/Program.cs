using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileLines = File.ReadAllLines(@"C:\Dev\AoC2020\Day4.txt").ToList();
            Passport temp = new Passport();
            List<Passport> list = new List<Passport>();
            Type myType = typeof(Passport);
            int result = 0;

            foreach (var line in fileLines)
            {
                if (!String.IsNullOrEmpty(line))
                {
                    var split = line.Split(' ');
                    foreach (var part in split)
                    {
                        var info = part.Split(':');
                        PropertyInfo propInfo = myType.GetProperty(info[0]);
                        propInfo.SetValue(temp, info[1]);
                    }
                }
                else
                {
                    list.Add(temp);
                    temp = new Passport();
                }
            }

            foreach (var item in list)
            {
                bool valid = true;
                bool additionalValidation = true;

                valid = !String.IsNullOrEmpty(item.byr) && 
                    !String.IsNullOrEmpty(item.ecl) &&
                    !String.IsNullOrEmpty(item.eyr) &&
                    !String.IsNullOrEmpty(item.hcl) &&
                    !String.IsNullOrEmpty(item.hgt) &&
                    !String.IsNullOrEmpty(item.iyr) &&
                    !String.IsNullOrEmpty(item.pid);

                if (valid)
                {
                    additionalValidation = Convert.ToInt32(item.byr) >= 1920 && Convert.ToInt32(item.byr) <= 2002;

                    if (additionalValidation)
                    {
                        additionalValidation = Convert.ToInt32(item.iyr) >= 2010 && Convert.ToInt32(item.iyr) <= 2020;
                    }
                    if (additionalValidation)
                    {
                        additionalValidation = Convert.ToInt32(item.eyr) >= 2020 && Convert.ToInt32(item.eyr) <= 2030;
                    }
                    if (additionalValidation)
                    {
                        if (item.hgt.Contains("in"))
                        {
                            additionalValidation = Convert.ToInt32(item.hgt.Split('i')[0]) >= 59 && Convert.ToInt32(item.hgt.Split('i')[0]) <= 76;
                        }
                        else if (item.hgt.Contains("cm"))
                        {
                            additionalValidation = Convert.ToInt32(item.hgt.Split('c')[0]) >= 150 && Convert.ToInt32(item.hgt.Split('c')[0]) <= 193;
                        }
                        else
                        {
                            additionalValidation = false;
                        }
                    }
                    if (additionalValidation)
                    {
                        additionalValidation = item.hcl.Contains("#") && item.hcl.Length == 7;
                    }
                    if (additionalValidation)
                    {
                        char[] validchars = new char[] {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'a', 'b', 'c', 'd', 'e', 'f'};
                        for (int i = 1; i < 7; i++)
                        {
                            if (additionalValidation)
                            {
                                additionalValidation = validchars.Contains(item.hcl[i]);
                            }
                        }
                    }
                    if (additionalValidation)
                    {
                        string[] validcolours = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
                        additionalValidation = validcolours.Contains(item.ecl);
                    }
                    if (additionalValidation)
                    {
                        additionalValidation = item.pid.Length == 9;
                        int ignoreMe;
                        if (additionalValidation) additionalValidation = Int32.TryParse(item.pid, out ignoreMe);
                    }
                }

                if (valid && additionalValidation) result++;
            }

            Console.WriteLine("Result: " + result.ToString());
            Console.ReadLine();
        }
    }
    class Passport
    {
        public string ecl { get; set; }
        public string byr { get; set; }
        public string iyr { get; set; }
        public string pid { get; set; }
        public string hgt { get; set; }
        public string eyr { get; set; }
        public string hcl { get; set; }
        public string cid { get; set; }
    }
}
