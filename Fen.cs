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
                posFig = SlashEmpty(posFig);

                string line = posFig.Replace("/", "");
                string[] pos64 = new string[64];
                for (int i = 1; i <= 8; i++)
                {
                    string pointField = string.Empty;
                    for(int p = 0; p < i; p++)
                    {
                        pointField += ".";
                    }
                    line = (line.Replace(i.ToString(), pointField)).Trim();
                }
                char[] chLine = line.ToCharArray();
                for(int j = 0; j < 64; j++)
                {
                    pos64[j] = chLine[j].ToString();
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
        				
        				fen += @"/";
        			}
        			if(_fenArray64[i] == ".")
        			{
        				emptyNum++;
                        if(i == 63)
                        {
                            fen += emptyNum.ToString();
                        }
        				continue;
        			}
        			
        			if(emptyNum > 0)
        			{
        				fen += emptyNum.ToString();
        				emptyNum = 0;
        			}
        			
        			fen += _fenArray64[i];
        		}

                fen += " " + ValidCurrentColorStep(CurrentColorStep);
                fen += " " + ValidPossibilityOfCastling(PossibilityOfCastling);
                fen += " " + PawnJump;
                fen += " " + Rule50Step;
                fen += " " + UpcomingMove;

                return fen;
        	}

            private string ValidCurrentColorStep(string colorStep)
            {
                return colorStep.ToLower();
            }

            private string ValidPossibilityOfCastling(string castlingFigures)
            {
                if (castlingFigures == "-")
                    return "-";

                char[] figCastings = castlingFigures.ToCharArray();
                const string casting = "KQkq";
                string outCast = string.Empty;
                for(int i = 0; i < casting.Length; i++)
                    foreach(char c in figCastings)
                        if(casting[i] == c)
                        {
                            outCast += c.ToString();
                            break;
                        }

                return outCast;
            }

            public string SlashEmpty(string posFig)
            {
                string[] arr = posFig.Split('/');
                for(int i = 0; i < 8; i++)
                {
                    int n;
                    if(arr[i].Length == 1 && int.TryParse(arr[i], out n) == false)
                    {
                        arr[i] += "7";
                    }
                    if(arr[i] == string.Empty)
                    {
                        arr[i] = "8";
                    }
                }
                string outPosFig = string.Empty;
                foreach(string s in arr)
                {
                    outPosFig += s + "/";
                }
                //return outPosFig.Substring(0, outPosFig.Length-1) + " ";
                return outPosFig;
            }

        }
        
    }
}
