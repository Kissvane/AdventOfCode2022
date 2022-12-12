using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventCode.Day3
{
    class Day3
    {
        public void Day3Part1()
        {
            string input = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "test.txt"));

            string[] array = input.Split("\n");
            int result = 0;
            foreach (string line in array)
            {
                string s1 = line.Substring(0, line.Length / 2);
                string s2 = line.Substring(line.Length / 2);
                string intersection = Intersection(s1, s2);
                Console.WriteLine($"{s1} {s2} {intersection}");
                foreach (char c in intersection)
                {
                    result += CalculatePriority(c);
                }
            }

            Console.Write(result);
        }

        public void Day3Part2()
        {
            string input = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "inputDay3.txt"));
            string[] array = input.Split("\n");
            int result = 0;
            for (int i = 0; i < array.Length; i = i + 3)
            {
                string s1 = array[i];
                string s2 = array[i + 1];
                string s3 = array[i + 2];
                string intersection = Intersection(s1, s2, s3);
                foreach (char c in intersection)
                {
                    result += CalculatePriority(c);
                }
            }

            Console.Write($"RESULTAT {result}");
        }

        string Intersection(params string[] args)
        {
            string intersection = "";
            List<HashSet<char>> hashsets = new List<HashSet<char>>();

            foreach (string s in args)
            {
                Console.WriteLine(s);
                HashSet<char> hashset = new HashSet<char>();
                foreach (char c in s)
                {
                    if (char.IsLetter(c)) hashset.Add(c);
                }
                hashsets.Add(hashset);
            }

            foreach (char c in hashsets[0])
            {
                bool add = true;
                for (int i = 1; i < hashsets.Count; i++)
                {
                    if (!hashsets[i].Contains(c))
                    {
                        add = false;
                        break;
                    }
                }

                if (add) intersection += c;
            }

            Console.WriteLine(intersection);

            return intersection;
        }

        int CalculatePriority(char c)
        {
            if (char.IsUpper(c))
            {
                return (int)c - 38;
            }
            else
            {
                return (int)c - 96;
            }
        }
    }
}
