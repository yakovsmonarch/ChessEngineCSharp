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
        }

        string[] fenBoard;
        string fen = String.Empty;
        string[] position = new string[64];

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

        
    }
}
