using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineCSharp
{
    class BitBoard
    {
        public BitBoard(string[] position)
        {
            InitBoard(position);
        }

        public ulong ShowElementBoard(int field)
        {
            return board[field];
        }

        ulong[] board = new ulong[12];

        private void InitBoard(string[] position)
        {
            for (int i = 0; i < position.Length; i++)
            {
                switch (position[i])
                {
                    case "P":
                        board[(int)Piece.whitePawns] += (ulong)Math.Pow(2, i);
                        break;
                    case "N":
                        board[(int)Piece.whiteKnights] += (ulong)Math.Pow(2, i);
                        break;
                    case "B":
                        board[(int)Piece.whiteBishops] += (ulong)Math.Pow(2, i);
                        break;
                    case "R":
                        board[(int)Piece.whiteRooks] += (ulong)Math.Pow(2, i);
                        break;
                    case "Q":
                        board[(int)Piece.whiteQueens] += (ulong)Math.Pow(2, i);
                        break;
                    case "K":
                        board[(int)Piece.whiteKing] += (ulong)Math.Pow(2, i);
                        break;

                    case "p":
                        board[(int)Piece.blackPawns] += (ulong)Math.Pow(2, i);
                        break;
                    case "n":
                        board[(int)Piece.blackKnights] += (ulong)Math.Pow(2, i);
                        break;
                    case "b":
                        board[(int)Piece.blackBishops] += (ulong)Math.Pow(2, i);
                        break;
                    case "r":
                        board[(int)Piece.blackRooks] += (ulong)Math.Pow(2, i);
                        break;
                    case "q":
                        board[(int)Piece.blackQueens] += (ulong)Math.Pow(2, i);
                        break;
                    case "k":
                        board[(int)Piece.blackKing] += (ulong)Math.Pow(2, i);
                        break;
                }
            }
        }

        public enum Piece
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
