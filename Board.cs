using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineCSharp
{
    class Board
    {
    	private Fen _fen;
    	
    	public Board(Fen fen)
    	{
    		_fen = fen;
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
    	
    	private char NumToLetter(int x)
    	{
    		switch(x)
    		{
    			case 0:
    				return 'a';
    			case 1:
    				return 'b';
    			case 2:
    				return 'c';
    			case 3:
    				return 'd';
    			case 4:
    				return 'e';
    			case 5:
    				return 'f';
    			case 6:
    				return 'g';
    			case 7:
    				return 'h';
    		}
    		return '-';
    	}
    	
    	private bool TakingFiece(string startFigure, string stopFigure)
    	{
            if (stopFigure == ".") 
                return false;

    		return true;
    	}
    	
    	private string DetectShape(string step, int x, int y)
    	{
    		string[] position64chars = _fen.FenPosStruct.FenposToArray();
    		int numField = ConvertToNumField(step, x, y);
    		
    		return position64chars[numField];
    	}

		private int ConvertToNumField(string step, int i, int j)
		{
			if(step == "-")
				return -1;
			int x = LetterToNum(step[i]),
				y = 8 - int.Parse(step[j].ToString()) ;
			return y * 8 + x;
		}
		
    	private string ColorStep(string step)
    	{
    		string[] position64chars = _fen.FenPosStruct.FenposToArray();
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
    	
    	private string CoordToStep(int numField)
    	{
    		int y = 8 - numField / 8,
    			x = numField % 8;
    			
    		return NumToLetter(x).ToString() + y.ToString();
    	}

        private string[] MovePawn(string[] b, int start, int stop, string step)
        {
            b[stop] = b[start];
            b[start] = ".";

            if (b[stop] == "P")
            {
                if(stop < 8 && stop > -1)
                {
                	b[stop] = step[4].ToString();
                } 
                else
                {
                	string pawnJump = _fen.FenPosStruct.PawnJump.Trim();
                	int fieldJump = ConvertToNumField(pawnJump, 0, 1);
                	if( pawnJump != "-" && fieldJump == stop && b[fieldJump+8] == "p" )
                	{
                		b[fieldJump + 8] = ".";
                		_fen.FenPosStruct.PawnJump = "-";
                	}
                	else
	                {
	                	if((start - stop) == 16 && (b[stop - 1] == "p" || b[stop + 1] == "p")  )
	                	{
	                		_fen.FenPosStruct.PawnJump = CoordToStep(stop + 8);
	                	}
	                	else
	                	{
	                		_fen.FenPosStruct.PawnJump = "-";
	                	}
                	}
                }
            }
            else
            {
                if (b[stop] == "p" )
                {
                    if(stop < 64 && stop > 54)
                    {
                    	b[stop] = step[4].ToString();
                    }
					else
					{
						string pawnJump = _fen.FenPosStruct.PawnJump.Trim();
						int fieldJump = ConvertToNumField(pawnJump, 0, 1);
	                	if(pawnJump != "-" && fieldJump == stop && b[fieldJump-8] == "P" )
	                	{
	                		b[fieldJump - 8] = ".";
	                		_fen.FenPosStruct.PawnJump = "-";
	                	}
	                	else
	                	{
	                		if((stop - start) == 16 && (b[stop - 1] == "P" || b[stop + 1] == "P")  )
	                		{
	                			_fen.FenPosStruct.PawnJump = CoordToStep(stop - 8);
	                		}
	                		else
	                		{
	                			_fen.FenPosStruct.PawnJump = "-";
	                		}
	                	}
					}
                }
            }

            return b;
        }
        
        private string[] MoveKing(string[] b , int start, int stop, string step)
        {
        	if(b[start] == "K")
        	{
        		if(stop != 62 && stop != 58)
        		{
		            b[stop] = b[start];
		            b[start] = ".";
		            return b;
        		}
        		
        		if(start == 60 && stop == 62)
        		{
        			b[stop] = b[start];
        			b[start] = ".";
        			b[61] = b[63];
        			b[63] = ".";
        			return b;
        		}
        		else
        		if(start == 60 && stop == 58)
        		{
        			b[stop] = b[start];
        			b[start] = ".";
        			b[59] = b[56];
        			b[56] = ".";
        			return b;
        		}
        	}
        	else
        	if(b[start] == "k")
        	{
        		if(stop != 6 && stop != 2)
        		{
		            b[stop] = b[start];
		            b[start] = ".";
		            return b;
        		}
        		
        		if(start == 4 && stop == 6)
        		{
        			b[stop] = b[start];
        			b[start] = ".";
        			b[5] = b[7];
        			b[7] = ".";
        			return b;
        		}
        		else
        		if(start == 4 && stop == 2)
        		{
        			b[stop] = b[start];
        			b[start] = ".";
        			b[3] = b[0];
        			b[0] = ".";
        			return b;
        		}
        	}
        	
        	return b;
        }

        private string[] MoveInArray64(string step)
        {
            int start = ConvertToNumField(step, 0, 1),
                stop = ConvertToNumField(step, 2, 3);
            string[] b = _fen.FenPosStruct.FenposToArray();
            if (b.Length != 64)
                return null;
            
            CatingChange(b, start, stop);

            if (b[start] == "P" || b[start] == "p")
            {
                 b = MovePawn(b, start, stop, step);
            }
            if (b[start] == "K" || b[start] == "k")
            {
            	MoveKing(b, start, stop, step);
            }
            else
            {
                b[stop] = b[start];
                b[start] = ".";
            }

            return b;
        }

        private void CatingChange(string[] b, int start, int stop)
        {
            if (_fen.FenPosStruct.PossibilityOfCastling == "-") return;

            if (b[start] == "K")
            {
                _fen.FenPosStruct.PossibilityOfCastling = _fen.FenPosStruct.PossibilityOfCastling.Replace("K", string.Empty);
                _fen.FenPosStruct.PossibilityOfCastling = _fen.FenPosStruct.PossibilityOfCastling.Replace("Q", string.Empty);
            }
            if (b[start] == "k")
            {
                _fen.FenPosStruct.PossibilityOfCastling = _fen.FenPosStruct.PossibilityOfCastling.Replace("k", string.Empty);
                _fen.FenPosStruct.PossibilityOfCastling = _fen.FenPosStruct.PossibilityOfCastling.Replace("q", string.Empty);
            }
            if(_fen.FenPosStruct.PossibilityOfCastling == string.Empty)
            {
            	_fen.FenPosStruct.PossibilityOfCastling = "-";
            	return;
            }
            
            if(b[start] == "R")
            {
                if(start == 63)
                {
                    _fen.FenPosStruct.PossibilityOfCastling = _fen.FenPosStruct.PossibilityOfCastling.Replace("K", string.Empty);
                }
                if(start == 56)
                {
                    _fen.FenPosStruct.PossibilityOfCastling = _fen.FenPosStruct.PossibilityOfCastling.Replace("Q", string.Empty);
                }
            }
            if (b[start] == "r")
            {
                if (start == 7)
                {
                    _fen.FenPosStruct.PossibilityOfCastling = _fen.FenPosStruct.PossibilityOfCastling.Replace("k", string.Empty);
                }
                if (start == 0)
                {
                    _fen.FenPosStruct.PossibilityOfCastling = _fen.FenPosStruct.PossibilityOfCastling.Replace("q", string.Empty);
                }
            }
            if(b[stop] == "R")
            {
                if(stop == 63)
                {
                    _fen.FenPosStruct.PossibilityOfCastling = _fen.FenPosStruct.PossibilityOfCastling.Replace("K", string.Empty);
                }
                if (stop == 56)
                {
                    _fen.FenPosStruct.PossibilityOfCastling = _fen.FenPosStruct.PossibilityOfCastling.Replace("Q", string.Empty);
                }
            }
            if(b[stop] == "r")
            {
                if(stop == 7)
                {
                    _fen.FenPosStruct.PossibilityOfCastling = _fen.FenPosStruct.PossibilityOfCastling.Replace("k", string.Empty);
                }
                if (stop == 0)
                {
                    _fen.FenPosStruct.PossibilityOfCastling = _fen.FenPosStruct.PossibilityOfCastling.Replace("q", string.Empty);
                }
            }

        }

        public string FenChanged(string step)
        {
            string elemFieldStart = ColorStep(step).Trim();
            if (elemFieldStart == "w")
            {
                _fen.FenPosStruct.CurrentColorStep = "b";
            }
            else
            {
                _fen.FenPosStruct.CurrentColorStep = "w";
                _fen.FenPosStruct.UpcomingMove += 1;
            }

            string figStart = DetectShape(step, 0, 1),
            figStop = DetectShape(step, 2, 3);

            if (figStart == "p" || figStart == "P" || TakingFiece(figStart, figStop) == true)
            {
                _fen.FenPosStruct.Rule50Step = 0;
            }
            else
            {
                _fen.FenPosStruct.Rule50Step += 1;
            }



            return _fen.FenPosStruct.OutFen(MoveInArray64(step));

        }
    }
}