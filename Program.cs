using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string fen = Console.ReadLine();
            string[] temp = fen.Split();
            string[] board = temp[0].Split('/');
            Console.WriteLine("  +-----------------+");
            for(int i = 0; i < board.Length; i++)
            {
                Char[] fig = board[i].ToCharArray();
                Console.Write("{0} {1}", board.Length-i, "| ");
                for(int j = 0; j < fig.Length; j++)
                {
                    int num;
                    if (int.TryParse(fig[j].ToString(), out num) == true)
                    {
                        for (int pointEmpty = 0; pointEmpty < num; pointEmpty++)
                        {
                            Console.Write(". ");
                        }
                    }
                    else
                    {
                        Console.Write(fig[j] + " ");
                    }
                    
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("  +-----------------+");
            Console.Write("    ");
            for(char latChar = 'a'; latChar <= 'h'; latChar++)
            {
                Console.Write(latChar + " ");
            }

            Console.ReadKey();
        }
    }
}
