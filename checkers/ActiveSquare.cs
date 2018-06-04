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
        private const int k_BoardTopOffset = 30;
        private const int k_BoardLeftOffset = 30;

        private ePlayerPosition? m_Player;
        private ePieceSymbol? m_PieceSymbol;
        private bool m_HasPieceOn;
        private Position m_Position;

        public ActiveSquare(ePlayerPosition i_Player, ePieceSymbol i_PieceSymbol, bool i_HasPieceOn, Position i_Position)
        {
            m_Player = i_Player;
            m_PieceSymbol = i_PieceSymbol;
            m_HasPieceOn = i_HasPieceOn;
            m_Position = i_Position;
            InitializeComponent();
        }

        public ActiveSquare(bool i_HasPieceOn, Position i_Position)
        {
            m_HasPieceOn = i_HasPieceOn;
            m_Position = i_Position;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            Enabled = true;
            Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            // Location = new System.Drawing.Point(24 * m_Position.Row + 50, 24 * m_Position.Col + 50);
            Top = m_Position.Row * 24 + k_BoardTopOffset;
            Left = m_Position.Col * 24 + k_BoardLeftOffset;
            Name = "Button" + m_Position.Row + m_Position.Col;
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

        private void move()
        {

        }

        private void highlight(Color i_Color)
        {
            // Change to enum with options - moveable, not moveable etc
        }
    }
}