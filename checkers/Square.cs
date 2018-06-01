using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace checkers
{
    public class Square : Button
    {
        public enum eSquareStatus
        {
            Empty,
            TopPlayer,
            BottomPlayer
        }

        public Square(ePlayerPosition i_Player)
        {
            
        }

        public void ChangeStatus(eSquareStatus i_Status)
        {
            switch (i_Status)
            {
                case (eSquareStatus.Empty):
                    Text = "";
                    Enabled = false;
                    break;
                case (eSquareStatus.BottomPlayer):
                    Text = "B";
                    Enabled = true;
                    break;
                case (eSquareStatus.TopPlayer):
                    Text = "U";
                    Enabled = true;
                    break;
            }
        }

        public void HighlightSquare(bool i_Hightlight)
        {
            if (i_Hightlight)
            {
                BackColor = Color.MediumVioletRed;
            }
            else
            {
                BackColor = Color.White;
            }
        }
    }
}