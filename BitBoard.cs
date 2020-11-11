using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineCSharp
{
    class BitBoard
    {
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

        private ulong[] _board = new ulong[12];

        public BitBoard(string[] position)
        {
            InitBoard(position);
        }

        private void InitBoard(string[] position)
        {
            for (int i = 0; i < position.Length; i++)
            {
                switch (position[i])
                {
                    case "P":
                        _board[(int)Piece.whitePawns] += (ulong)Math.Pow(2, i);
                        break;
                    case "N":
                        _board[(int)Piece.whiteKnights] += (ulong)Math.Pow(2, i);
                        break;
                    case "B":
                        _board[(int)Piece.whiteBishops] += (ulong)Math.Pow(2, i);
                        break;
                    case "R":
                        _board[(int)Piece.whiteRooks] += (ulong)Math.Pow(2, i);
                        break;
                    case "Q":
                        _board[(int)Piece.whiteQueens] += (ulong)Math.Pow(2, i);
                        break;
                    case "K":
                        _board[(int)Piece.whiteKing] += (ulong)Math.Pow(2, i);
                        break;

                    case "p":
                        _board[(int)Piece.blackPawns] += (ulong)Math.Pow(2, i);
                        break;
                    case "n":
                        _board[(int)Piece.blackKnights] += (ulong)Math.Pow(2, i);
                        break;
                    case "b":
                        _board[(int)Piece.blackBishops] += (ulong)Math.Pow(2, i);
                        break;
                    case "r":
                        _board[(int)Piece.blackRooks] += (ulong)Math.Pow(2, i);
                        break;
                    case "q":
                        _board[(int)Piece.blackQueens] += (ulong)Math.Pow(2, i);
                        break;
                    case "k":
                        _board[(int)Piece.blackKing] += (ulong)Math.Pow(2, i);
                        break;
                }
            }
        }

        public ulong ShowElementBoard(int field)
        {
            return _board[field];
        }
    }
}
