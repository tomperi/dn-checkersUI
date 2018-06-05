using System;
using System.Drawing;
using System.Windows.Forms;
using checkersGUI.Properties;

namespace checkersGUI
{
    public class PieceGUI : PictureBox
    {
        private readonly Bitmap k_Player1Regular = Resources.player1regular;
        private readonly Bitmap k_Player1King = Resources.player1king;
        private readonly Bitmap k_Player2Regular = Resources.player2regular;
        private readonly Bitmap k_Player2King = Resources.player2king;

        private ePieceSymbol m_PieceSymbol;
        private Square m_ParentSquare;

        public PieceGUI(ePieceSymbol i_PieceSymbol, Square i_ParentSquare)
        {
            m_PieceSymbol = i_PieceSymbol;
            m_ParentSquare = i_ParentSquare;
            Parent = i_ParentSquare;
            initializeComponent();
        }

        private void initializeComponent()
        {
            setPieceSymbol(m_PieceSymbol);
            Width = MainGame.k_ButtonSize / 2;
            Height = MainGame.k_ButtonSize / 2;
            Left = m_ParentSquare.Left + Width / 2;
            Top = m_ParentSquare.Top + Height / 2;
            SizeMode = PictureBoxSizeMode.StretchImage;
            BackColor = Color.Transparent;
        }

        private void setPieceSymbol(ePieceSymbol i_PieceSymbol)
        {
            switch (i_PieceSymbol)
            {
                case ePieceSymbol.Player1Regular:
                    Image = k_Player1Regular;
                    break;
                case ePieceSymbol.Player1King:
                    Image = k_Player1King;
                    break;
                case ePieceSymbol.Player2Regular:
                    Image = k_Player2Regular;
                    break;
                case ePieceSymbol.Player2King:
                    Image = k_Player2King;
                    break;
            }
        }

        public void SetKing()
        {
            if (m_PieceSymbol == ePieceSymbol.Player1Regular)
            {
                setPieceSymbol(ePieceSymbol.Player1King);
            }
            else if (m_PieceSymbol == ePieceSymbol.Player2Regular)
            {
                setPieceSymbol(ePieceSymbol.Player2King);
            }
        }

        public void MovePiece(Square i_Square)
        {
            m_ParentSquare.PieceGUI = null;
            m_ParentSquare = i_Square;
            m_ParentSquare.PieceGUI = this;
            Top = m_ParentSquare.Top + Width / 2;
            Left = m_ParentSquare.Left + Width / 2;
        }

        public void KillPiece()
        {
            Hide();
        }
    }
}