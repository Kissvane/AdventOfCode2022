using System.IO;
using System.Linq;

namespace AdventCodeDay1
{
    class Program
    {
        // See https://aka.ms/new-console-template for more information
        static void Main(string[] args)
        {
            Day3Part1();
            Day3Part2();
        }

        #region DAY1
        static void Day1()
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
        #endregion

        #region DAY2
        public enum PLAY { ROCK = 0, PAPER = 1, SCISSORS = 2 };
        static void Day2()
        {
            string input = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "inputDay2.txt"));
            string[] array = input.Split("\n");
            int result = 0;
            int result2 = 0;
            foreach(string line in array)
            {
                result += CalculateGamePoint(line.Replace(" ",""));
                result2 += CalculateGamePoint2(line.Replace(" ", ""));
            }
            Console.WriteLine(result);
            Console.WriteLine(result2);
        }

        static int VictoryPoint(string game)
        {
            PLAY opponent = PLAY.SCISSORS;
            if (game[0] == 'A')
            {
                opponent = PLAY.ROCK;
            }
            else if (game[0] == 'B')
            {
                opponent = PLAY.PAPER;
            }

            PLAY player = PLAY.SCISSORS;
            if (game[1] == 'Y')
            {
                player = PLAY.PAPER;
            }
            else if(game[1] == 'X')
            {
                player = PLAY.ROCK;
            }

            int difference = (int)player - (int)opponent;

            if ((int)player == (int)opponent)
                return 3;
            else if ((int)player == ((int)opponent+1)%3)
                return 6;
            else
                return 0;
        }

        static int VictoryPoint2(string game)
        {
            if (game[1] == 'Y')
                return 3;
            else if (game[1] == 'Z')
                return 6;
            else
                return 0;
        }

        static int ShapePoint(string game)
        {
            PLAY player = PLAY.SCISSORS;
            if (game[1] == 'Y')
            {
                player = PLAY.PAPER;
            }
            else if (game[1] == 'X')
            {
                player = PLAY.ROCK;
            }

            return (int)player+1;
        }

        static int CalculateNeededShapePoint(string game)
        {
            PLAY opponent = PLAY.SCISSORS;
            if (game[0] == 'A')
            {
                opponent = PLAY.ROCK;
            }
            else if (game[0] == 'B')
            {
                opponent = PLAY.PAPER;
            }

            PLAY player = PLAY.SCISSORS;
            if (game[1] == 'Y')//draw
            {
                player = opponent;
            }
            else if (game[1] == 'X')//loose
            {
                player = (int)opponent - 1 >= 0 ? (PLAY)((int)opponent - 1) : PLAY.SCISSORS;

            }
            else//win
            {
                player = (PLAY)(((int)opponent + 1)%3);
            }

            return (int)player+1;
        }

        static int CalculateGamePoint(string game)
        {
            return VictoryPoint(game) + ShapePoint(game);
        }

        static int CalculateGamePoint2(string game)
        {
            return VictoryPoint2(game) + CalculateNeededShapePoint(game);
        }
        #endregion

        #region DAY3

        static void Day3Part1()
        {
            string input = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "test.txt"));

            string[] array = input.Split("\n");
            int result = 0;
            foreach (string line in array)
            {
                string s1 = line.Substring(0,line.Length/2);
                string s2 = line.Substring(line.Length / 2);
                string intersection = Intersection(s1,s2);
                Console.WriteLine($"{s1} {s2} {intersection}");
                foreach (char c in intersection)
                {
                    result += CalculatePriority(c);
                }
            }

            Console.Write(result);
        }

        static void Day3Part2()
        {
            string input = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "inputDay3.txt"));
            string[] array = input.Split("\n");
            int result = 0;
            for(int i = 0; i < array.Length; i = i+3)
            {
                string s1 = array[i];
                string s2 = array[i+1];
                string s3 = array[i+2];
                string intersection = Intersection(s1, s2, s3);
                foreach (char c in intersection)
                {
                    result += CalculatePriority(c);
                }
            }

            Console.Write($"RESULTAT {result}");
        }

        static string Intersection(params string[] args)
        {
            string intersection = "";
            List<HashSet<char>> hashsets = new List<HashSet<char>>();

            foreach (string s in args)
            {
                Console.WriteLine(s);
                HashSet<char> hashset = new HashSet<char>();
                foreach (char c in s)
                {
                    if(char.IsLetter(c)) hashset.Add(c);
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

                if(add) intersection += c;
            }

            Console.WriteLine(intersection);

            return intersection;
        }

        static int CalculatePriority(char c)
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

        #endregion
    }
}

