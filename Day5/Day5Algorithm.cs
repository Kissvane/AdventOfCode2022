using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode.Day5
{
    internal class Day5Algorithm
    {
        public void Day5Part1()
        {
            string txtInput = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "inputDay5.txt"));
            string[] firstSplit = txtInput.Split("\n");
            int endOfinitialState = 0;
            for (int i = 0; i < firstSplit.Length; i++)
            {
                if (string.IsNullOrEmpty(firstSplit[i].Trim()))
                {
                    endOfinitialState = i; 
                }
            }

            //Console.WriteLine($"END OF INITIAL STATE {endOfinitialState}");

            List<Stack<char>> cargo = ParseInitialState(firstSplit, endOfinitialState);
            ProceedToMoves(firstSplit, endOfinitialState + 1,cargo);
        }

        public void Day5Part2()
        {
            string txtInput = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "inputDay5.txt"));
            string[] firstSplit = txtInput.Split("\n");
            int endOfinitialState = 0;
            for (int i = 0; i < firstSplit.Length; i++)
            {
                if (string.IsNullOrEmpty(firstSplit[i].Trim()))
                {
                    endOfinitialState = i;
                }
            }

            //Console.WriteLine($"END OF INITIAL STATE {endOfinitialState}");

            List<Stack<char>> cargo = ParseInitialState(firstSplit, endOfinitialState);
            ProceedToMoves2(firstSplit, endOfinitialState + 1, cargo);
        }

        List<Stack<char>> ParseInitialState(string[] data, int endOfinitialState)
        { 
            string lastLine = data[endOfinitialState-1];
            Console.WriteLine(lastLine);
            string[] lastLineSplittedByColumn = lastLine.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            int maxColumnNumber = lastLineSplittedByColumn.Length;
            //Console.WriteLine($"MAX COLUMN NUMBER {maxColumnNumber}");
            /*foreach (string i in lastLineSplittedByColumn)
            {
                Console.WriteLine(i);
            }*/

            List<Stack<char>> cargo = new List<Stack<char>>();
            for (int i = 0; i < maxColumnNumber; i++)
            {
                cargo.Add(new Stack<char>());
            }


            for (int i = endOfinitialState - 2; i >= 0; i--)
            {
                string currentLine = data[i];
                //Console.WriteLine($"LINE {i} {currentLine}");
                for (int k = 0; k < maxColumnNumber; k++)
                {
                    char content = currentLine[(k * 4) + 1];
                    if (content.Equals(' ')) continue;
                    cargo[k].Push(content);
                }
            }

            return cargo; 
        }

        void ProceedToMoves(string[] data, int startOfMoves, List<Stack<char>> cargo)
        {
            //PARSE MOVE
            //string[] moves = s.Split("\n");
            for (int i = startOfMoves; i < data.Length; i++)
            {
                string move = data[i];
                //Console.WriteLine($"MOVE {move}");
                string[] parsedMove = move.Split(' ');
                int crateNumberMoved = int.Parse(parsedMove[1]);
                int departureColumn = int.Parse(parsedMove[3]) - 1;
                int arrivalColumn = int.Parse(parsedMove[5]) - 1;
                Move(cargo, departureColumn, arrivalColumn, crateNumberMoved);
            }

            string result = "";
            //GET THE MESSAGE
            foreach (Stack<char> stack in cargo)
            {
                result += stack.Peek();
            }

            Console.WriteLine(result);

        }

        void ProceedToMoves2(string[] data, int startOfMoves, List<Stack<char>> cargo)
        {
            //PARSE MOVE
            //string[] moves = s.Split("\n");
            for (int i = startOfMoves; i < data.Length; i++)
            {
                string move = data[i];
                //Console.WriteLine($"MOVE {move}");
                string[] parsedMove = move.Split(' ');
                int crateNumberMoved = int.Parse(parsedMove[1]);
                int departureColumn = int.Parse(parsedMove[3]) - 1;
                int arrivalColumn = int.Parse(parsedMove[5]) - 1;
                Move2(cargo, departureColumn, arrivalColumn, crateNumberMoved);
            }

            string result = "";
            //GET THE MESSAGE
            foreach (Stack<char> stack in cargo)
            {
                result += stack.Peek();
            }

            Console.WriteLine(result);

        }

        void Move(List<Stack<char>> cargo, int departureCoulmn, int arrivalColumn, int crateNumberMoved)
        {
            for (int i = 0; i < crateNumberMoved; i++) 
            {
                char moved = cargo[departureCoulmn].Pop();
                cargo[arrivalColumn].Push(moved);
            }
        }

        void Move2(List<Stack<char>> cargo, int departureCoulmn, int arrivalColumn, int crateNumberMoved)
        {
            List<char> test = new List<char>();

            for (int i = 0; i < crateNumberMoved; i++)
            {
                char moved = cargo[departureCoulmn].Pop();
                test.Add(moved);
            }

            test.Reverse();

            foreach(char c in test)
            {
                cargo[arrivalColumn].Push(c);
            }
            
        }
    }
}
