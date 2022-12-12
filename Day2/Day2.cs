using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventCode.Day2
{
    class Day2
    {
        public enum PLAY { ROCK = 0, PAPER = 1, SCISSORS = 2 };
        public void Execute()
        {
            string input = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "inputDay2.txt"));
            string[] array = input.Split("\n");
            int result = 0;
            int result2 = 0;
            foreach (string line in array)
            {
                result += CalculateGamePoint(line.Replace(" ", ""));
                result2 += CalculateGamePoint2(line.Replace(" ", ""));
            }
            Console.WriteLine(result);
            Console.WriteLine(result2);
        }

        int VictoryPoint(string game)
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
            else if (game[1] == 'X')
            {
                player = PLAY.ROCK;
            }

            int difference = (int)player - (int)opponent;

            if ((int)player == (int)opponent)
                return 3;
            else if ((int)player == ((int)opponent + 1) % 3)
                return 6;
            else
                return 0;
        }

        int VictoryPoint2(string game)
        {
            if (game[1] == 'Y')
                return 3;
            else if (game[1] == 'Z')
                return 6;
            else
                return 0;
        }

        int ShapePoint(string game)
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

            return (int)player + 1;
        }

        int CalculateNeededShapePoint(string game)
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
                player = (PLAY)(((int)opponent + 1) % 3);
            }

            return (int)player + 1;
        }

        int CalculateGamePoint(string game)
        {
            return VictoryPoint(game) + ShapePoint(game);
        }

        int CalculateGamePoint2(string game)
        {
            return VictoryPoint2(game) + CalculateNeededShapePoint(game);
        }
    }
}
