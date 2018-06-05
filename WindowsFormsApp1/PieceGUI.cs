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

        private void MovePiece(Square i_Square)
        {
            // Move the piece to a new square
            throw new NotImplementedException();
        }

        // Paint background with underlying graphics from other controls
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            Graphics g = e.Graphics;

            if (Parent != null)
            {
                // Take each control in turn
                int index = Parent.Controls.GetChildIndex(this);
                for (int i = Parent.Controls.Count - 1; i > index; i--)
                {
                    Control c = Parent.Controls[i];

                    // Check it's visible and overlaps this control
                    if (c.Bounds.IntersectsWith(Bounds) && c.Visible)
                    {
                        // Load appearance of underlying control and redraw it on this background
                        Bitmap bmp = new Bitmap(c.Width, c.Height, g);
                        c.DrawToBitmap(bmp, c.ClientRectangle);
                        g.TranslateTransform(c.Left - Left, c.Top - Top);
                        g.DrawImageUnscaled(bmp, Point.Empty);
                        g.TranslateTransform(Left - c.Left, Top - c.Top);
                        bmp.Dispose();
                    }
                }
            }
        }
    }
}