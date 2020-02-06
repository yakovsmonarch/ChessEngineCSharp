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

        static string[] fenBoard;
        private static string PrintFen(string fen)
        {
            StringBuilder sb = new StringBuilder();
            string[] temp = fen.Split();
            fenBoard = temp[0].Split('/');
            sb.Append("  +-----------------+" + Environment.NewLine);

            for (int i = 0; i < fenBoard.Length; i++)
            {
                Char[] fig = fenBoard[i].ToCharArray();
                sb.Append((fenBoard.Length - i).ToString() + " | ");
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

        private static ulong[] FigureToNum(string[] fenBoard)
        {
            ulong[] board = new ulong[12];
            for(int i = 0; i < board.Length; i++)
                if (SumNumToBoard(fenBoard, out board) == false) continue;
            
            return board;
        }

        private static bool SumNumToBoard(string[] fenBoard, out ulong[] board)
        {


            throw new NotImplementedException();
        }

        enum Piece
        {
            whitePawns,
            whiteKnights,
            whiteBishops,
            whiteRooks,
            whiteQueens,
            whiteKing,

            blackPawns,
            blackKnights,
            blackBishops,
            blackRooks,
            blackQueens,
            blackKing
        }


    }
}
