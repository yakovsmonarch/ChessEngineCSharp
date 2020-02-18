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
    	
    	private bool TakingFiece(string startFigure, string stopFigure)
    	{
            if (stopFigure == ".") 
                return false;

    		return true;
    	}
    	
    	private string DetectShape(string step, int x, int y)
    	{
    		string[] position64chars = fen.FenPosStruct.FenposToArray();
    		int numField = ConvertToNumField(step, x, y);
    		
    		return position64chars[numField];
    	}

		private int ConvertToNumField(string step, int i, int j)
		{
			int x = LetterToNum(step[i]),
				y = 8 - int.Parse(step[j].ToString()) ;
			return y * 8 + x;
		}
		
    	private string ColorStep(string step)
    	{
    		string[] position64chars = fen.FenPosStruct.FenposToArray();
    		int numField = ConvertToNumField(step, 0, 1);
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

        private string[] MoveInArray64(string step)
        {
            int start = ConvertToNumField(step, 0, 1),
                stop = ConvertToNumField(step, 2, 3);
            string[] b = fen.FenPosStruct.FenposToArray();
            if (b.Length != 64)
                return null;

            b[stop] = b[start];
            b[start] = ".";

            return b;
        }
    	
    	public string FenChanged(string step)
    	{
    		string elemFieldStart = ColorStep(step).Trim();
    		if(elemFieldStart == "w")
    		{
    			fen.FenPosStruct.CurrentColorStep = "b";
    		}
    		else
    		{
    			fen.FenPosStruct.CurrentColorStep = "w";
                fen.FenPosStruct.UpcomingMove += 1;
    		}
    		
    		string figStart = DetectShape(step, 0, 1),
    		figStop = DetectShape(step, 2, 3);

    		if(figStart == "p" || figStart == "P" || TakingFiece(figStart, figStop) == true)
            {
                fen.FenPosStruct.Rule50Step = 0;
            }
            else 
            {
                fen.FenPosStruct.Rule50Step += 1;
            }
            
    		return fen.FenPosStruct.OutFen(MoveInArray64(step));
    		
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
