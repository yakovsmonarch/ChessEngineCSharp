using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineCSharp
{
    class Fen
    {
        public Fen(string fenText)
        {
            this.fen = fenText.Trim();
            fenBoard = fen.Split()[0].Split('/');
            FenToPosition(fenBoard);
            this.FenPosStruct = new FenPos(fenText);
        }

        string[] fenBoard;
        string fen = String.Empty;
        string[] position = new string[64];
		
        public FenPos FenPosStruct;
        public string PrintFen()
        {
            StringBuilder sb = new StringBuilder();
            //string[] temp = fen.Split();
            //fenBoard = temp[0].Split('/');
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

        public string ShowField(int numField)
        {
            if (numField < 0 || numField > 63)
                return "Error numField...";
            return position[numField];
        }

        public string[] FenToPosition()
        {
            return this.position;
        }

        private void FenToPosition(string[] fenPosition)
        {
        	Array.Reverse(fenPosition);
            int j = 0;
            for (int i = 0; i < 8; i++)
            {
                foreach (char c in fenPosition[i])
                {
                    int numEmptyField;
                    if (int.TryParse(c.ToString(), out numEmptyField) == true)
                    {
                        for (int emptyFld = 0; emptyFld < numEmptyField; emptyFld++)
                        {
                            position[j++] = ".";
                        }
                    }
                    else
                    {
                        position[j++] = c.ToString();
                    }
                }
            }
        }

        
        public struct FenPos
        {
        	public FenPos(string fenStr)
        	{
        		fenStr = fenStr.Trim();
        		string[] arrayFen = fenStr.Split();
        		this.PositionFigure = arrayFen[0];
        		this.CurrentColorStep = arrayFen[1];
        		this.PossibilityOfCastling = arrayFen[2];
        		this.PawnJump = arrayFen[3];
        		this.Rule50Step = int.Parse(arrayFen[4]);
        		this.UpcomingMove = int.Parse(arrayFen[5]);
        	}
        	
        	public string PositionFigure;
        	public string CurrentColorStep;
        	public string PossibilityOfCastling;
        	public string PawnJump;
        	public int Rule50Step;
        	public int UpcomingMove;
        	
        	private string[] FenposToArray(string posFig)
        	{
        		int j = 0;
        		string[] fenLine = posFig.Split('/');
        		string[] pos64 = new string[64];
        		for(int i = 0; i < 8; i++)
        		{
        			int num;
        			if(int.TryParse(fenLine[i], out num) == true)
        			{
        				for(int n = 0; n < num; n++)
        				{
        					pos64[j++] = ".";
        				}
        			}
        			else
        			{
        				pos64[j++] = fenLine[i];
        			}
        			
        		}
        		return pos64;
        	}
        	
        	public string OutFen()
        	{
        		string[] _fenArray64 = FenposToArray(PositionFigure);
        		string fen = String.Empty;
        		int emptyNum = 0;
        		for(int i = 0; i < 64; i++)
        		{
        			if(i % 8 == 0 && i > 0)
        			{
        				if(emptyNum > 0)
        				{
        					fen += emptyNum.ToString();
        					emptyNum = 0;
        				}
        				
        				fen += "/";
        			}
        			if(_fenArray64[i] == ".")
        			{
        				emptyNum++;
        				continue;
        			}
        			
        			if(emptyNum > 0)
        			{
        				fen += emptyNum.ToString();
        				emptyNum = 0;
        			}
        			
        			fen += _fenArray64[i];
        		}
        		return fen;
        	}
        }
        
    }
}
