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
            Console.WriteLine(PrintFen(Console.ReadLine()));
            Console.ReadLine();
        }

        private static string PrintFen(string fen)
        {
            StringBuilder sb = new StringBuilder();
            string[] temp = fen.Split();
            string[] board = temp[0].Split('/');
            sb.Append("  +-----------------+" + Environment.NewLine);

            for (int i = 0; i < board.Length; i++)
            {
                Char[] fig = board[i].ToCharArray();
                sb.Append((board.Length - i).ToString() + " | ");
                for (int j = 0; j < fig.Length; j++)
                {
                    int num;
                    if (int.TryParse(fig[j].ToString(), out num) == true)
                    {
                        for (int pointEmpty = 0; pointEmpty < num; pointEmpty++)
                        {
                            sb.Append(". ");
                        }
                    }
                    else
                    {
                        sb.Append(fig[j] + " ");
                    }

                }
                sb.Append("|" + Environment.NewLine);
            }
            sb.Append("  +-----------------+" + Environment.NewLine);
            sb.Append("    ");
            for (char latChar = 'a'; latChar <= 'h'; latChar++)
            {
                sb.Append(latChar + " ");
            }

            return sb.ToString();
        }

        private static ulong FigureToNum(int n)
        {
            return (ulong)Math.Pow(2, n);
        }
    }
}
