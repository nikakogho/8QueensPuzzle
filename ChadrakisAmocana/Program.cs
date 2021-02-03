using System;
using System.Collections.Generic;
using System.Linq;

namespace ChadrakisAmocana
{
    class Board
    {
        public int[,] tiles = new int[8, 8];

        public Board()
        {
            for(int x = 0; x < 8; x++)
            {
                for(int y = 0; y < 8; y++)
                {
                    tiles[x, y] = 0;
                }
            }
        }
    }
    
    class Program
    {
        static bool ShouldProceed(int x, int ourY, int[] busies, int busyEnd)
        {
            for(int i = 0; i < busyEnd; i++)
            {
                if (x == busies[i] || (Math.Abs(x - busies[i]) == Math.Abs(ourY - i))) return false;
            }

            return true;
        }

        static void NextX(List<Board> possibles, int[] XValues, int index)
        {
            for(int x = 0; x < 8; x++)
            {
                if (!ShouldProceed(x, index, XValues, index)) continue;

                int[] xValues = (int[])XValues.Clone();

                xValues[index] = x;

                if (index < 7) NextX(possibles, xValues, index + 1);
                else
                {
                    Board board = new Board();

                    for(int y = 0; y < 8; y++)
                    {
                        board.tiles[XValues[y], y] = 1;
                    }

                    possibles.Add(board);
                }
            }
        }

        static List<Board> GetPossibleBoards()
        {
            List<Board> possibles = new List<Board>();
            NextX(possibles, new int[8], 0);

            return possibles;
        }

        static void Main()
        {
            List<Board> possibleBoards = GetPossibleBoards();

            foreach(Board board in possibleBoards)
            {
                for(int y = 0; y < 8; y++)
                {
                    for(int x = 0; x < 8; x++)
                    {
                        Console.Write(board.tiles[x,y]);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Total : {possibleBoards.Count} boards");

            Console.ReadKey();
        }
    }
}
