using System;
using System.IO;

namespace AdventCode.Day4
{
    struct Interval
    {
        public int min;
        public int max;

        public Interval(string s)
        {
            string[] splitted = s.Split('-');
            min = int.Parse(splitted[0]);
            max = int.Parse(splitted[1]);
        }

        /// <summary>
        /// Test if this interval contains tested interval
        /// </summary>
        /// <param name="tested"> tested interval </param>
        /// <returns></returns>
        public bool Contains(Interval tested)
        {
            return tested.min >= min && tested.max <= max;
        }

        /// <summary>
        /// test if this interval overlaps tested interval
        /// </summary>
        /// <param name="tested"></param>
        /// <returns></returns>
        public bool Overlaps(Interval tested)
        {
            return (min >= tested.min && min <= tested.max) || (max >= tested.min && max <= tested.max);
        }
    }

    class Day4Algorithm
    {
        public void Day4Part1()
        {
            string txtInput = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Day4Input.txt"));
            string[] pairs = txtInput.Split('\n');
            int result = 0;
            foreach (string pair in pairs) 
            {
                string[] intervals = pair.Split(',');
                for (int i = 0; i < intervals.Length; i = i + 2)
                {
                    Interval first = new Interval(intervals[i]);
                    Interval second = new Interval(intervals[i + 1]);
                    if (first.Contains(second) || second.Contains(first))
                    {
                        result++;
                    }
                }
            }

            Console.WriteLine(result);
        }

        public void Day4Part2()
        {
            string txtInput = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Day4Input.txt"));
            string[] pairs = txtInput.Split('\n');
            int result = 0;
            foreach (string pair in pairs)
            {
                string[] intervals = pair.Split(',');
                for (int i = 0; i < intervals.Length; i = i + 2)
                {
                    Interval first = new Interval(intervals[i]);
                    Interval second = new Interval(intervals[i + 1]);
                    if (first.Overlaps(second) || first.Contains(second))
                    {
                        result++;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}