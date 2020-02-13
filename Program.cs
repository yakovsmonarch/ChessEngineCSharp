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
        	string step = Console.ReadLine();
        	
        	Fen fen = new Fen(inputFen);
        	
        	Board board = new Board(fen);
        	Console.WriteLine(board.FenChanged(step));

            Console.ReadLine();
        }




    }
}
