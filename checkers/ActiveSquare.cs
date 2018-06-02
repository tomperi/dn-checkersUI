using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace checkers
{
    public class ActiveSquare : Button
    {
        private const char k_Player1Regular = 'O';
        private const char k_Player1King = 'U';
        private const char k_Player2Regular = 'X';
        private const char k_Player2King = 'K';

        private ePlayerPosition m_Player;
        private ePieceSymbol m_PieceSymbol;
        private bool m_Activated;
        private Position m_Position;

        public ActiveSquare(ePlayerPosition i_Player, ePieceSymbol i_PieceSymbol, bool i_Activated, Position i_Position)
        {
            m_Player = i_Player;
            m_PieceSymbol = i_PieceSymbol;
            m_Activated = i_Activated;
            m_Position = i_Position;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            Enabled = true;
            Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            Location = new System.Drawing.Point(12 * m_Position.Row, 33 * m_Position.Col);
            Name = "DisabledButton" + m_Position.Row + m_Position.Col;
            Text = getSymbol().ToString();
            Size = new System.Drawing.Size(24, 24);
            TabIndex = 2;
            UseVisualStyleBackColor = true;
        }

        private char getSymbol()
        {
            char pieceSymbol = ' ';
            switch (m_PieceSymbol)
            {
                case ePieceSymbol.Player1Regular:
                    pieceSymbol = k_Player1Regular;
                    break;
                case ePieceSymbol.Player1King:
                    pieceSymbol = k_Player1King;
                    break;
                case ePieceSymbol.Player2Regular:
                    pieceSymbol = k_Player2Regular;
                    break;
                case ePieceSymbol.Player2King:
                    pieceSymbol = k_Player2King;
                    break;
            }

            return pieceSymbol;
        }
    }
}