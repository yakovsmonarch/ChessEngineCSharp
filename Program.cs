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
        	string inputFen = Console.ReadLine();
            Fen fen = new Fen(inputFen);
            Console.WriteLine( fen.FenPosStruct.OutFen() );

            Console.ReadLine();
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




    }
}
