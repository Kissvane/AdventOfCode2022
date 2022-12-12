using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventCode.Day1
{
    class Day1
    {
        public void Execute()
        {
            string input = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "inputDay1.txt"));
            string[] array = input.Split("\n");
            List<int> list = new List<int> { 0 };
            //int maximum = 0;
            int wantedElfIndex = 0;
            int index = 0;
            foreach (string line in array)
            {
                if (string.IsNullOrEmpty(line.Trim()))
                {
                    list.Add(0);
                }
                else
                {
                    if (!int.TryParse(line, out int test))
                    {
                        Console.WriteLine($" BAD INPUT --- {index}");
                    }
                    list[list.Count - 1] += int.Parse(line);
                }
                index++;
            }

            List<int> orderedList = list.OrderByDescending(x => x).ToList();
            int topThreeTotal = 0;
            for (int i = 0; i < 3; i++)
            {
                topThreeTotal += orderedList[i];
            }

            //Console.WriteLine($"INDEX {index}");
            //Console.WriteLine($"ELF {wantedElfIndex} CARRYING {maximum}");
            Console.WriteLine($"TOP 3 CARRYING {topThreeTotal}");
        }
    }
}
