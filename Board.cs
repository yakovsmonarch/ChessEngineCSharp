using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineCSharp
{
    class Board
    {
    	Fen fen;
    	
    	public Board(Fen fen)
    	{
    		this.fen = fen;
    	}
    	
    	private int LetterToNum(char letter)
    	{
    		switch(letter)
    		{
    			case 'a':
    				return 0;
    			case 'b':
    				return 1;
    			case 'c':
    				return 2;
    			case 'd':
    				return 3;
    			case 'e':
    				return 4;
    			case 'f':
    				return 5;
    			case 'g':
    				return 6;
    			case 'h':
    				return 7;
    				
    			default: return -1;
    		}
    	}

		private int ConvertToNumField(string step)
		{
			int x = LetterToNum(step[0]),
				y = 8 - int.Parse(step[1].ToString()) ;
			return y * 8 + x;
		}
		
    	private string ColorStep(string step)
    	{
    		string[] position64chars = fen.FenPosStruct.FenposToArray();
    		int numField = ConvertToNumField(step);
    		switch (position64chars[numField])
                {
                    case "P":
    					return "w";
                    case "N":
                        return "w";
                    case "B":
                        return "w";
                    case "R":
                        return "w";
                    case "Q":
                        return "w";
                    case "K":
                        return "w";

                    case "p":
                        return "b";
                    case "n":
                        return "b";
                    case "b":
                        return "b";
                    case "r":
                        return "b";
                    case "q":
                        return "b";
                    case "k":
                        return "b";
                }
    		return "-";
    	}
    	
    	public string FenChanged(string step)
    	{
    		if(ColorStep(step).Trim() == "w")
    		{
    			fen.FenPosStruct.CurrentColorStep = "b";
    		}
    		else
    		{
    			fen.FenPosStruct.CurrentColorStep = "w";
                fen.FenPosStruct.UpcomingMove += 1;
    		}
    		
    		return fen.FenPosStruct.OutFen();
    		
    	}
    	
    	#region BitBoard * на будущее
    	/*
    	public Board(string[] position)
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
            for(int i = 0; i < position.Length; i++)
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
        */
    	#endregion
    }
}
