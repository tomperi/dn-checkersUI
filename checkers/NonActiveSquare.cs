using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace checkers
{
    public class NonActiveSquare : Button
    {
        private ePlayerPosition m_Player;
        private ePieceSymbol m_PieceSymbol;
        private bool m_Activated;
        private Position m_Position;

        public NonActiveSquare(ePlayerPosition i_Player, ePieceSymbol i_PieceSymbol, bool i_Activated, Position i_Position)
        {
            m_Player = i_Player;
            m_PieceSymbol = i_PieceSymbol;
            m_Activated = i_Activated;
            m_Position = i_Position;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            Enabled = false;
            Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            Location = new System.Drawing.Point(12 * m_Position.Row, 33 * m_Position.Col);
            Name = "DisabledButton" + m_Position.Row + m_Position.Col;
            Size = new System.Drawing.Size(24, 24);
            TabIndex = 2;
            UseVisualStyleBackColor = true;
        }
    }

    /*
public enum eSquareStatus
{
    Empty,
    TopPlayer,
    BottomPlayer
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

*/
}