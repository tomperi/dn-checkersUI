using System;
using System.Drawing;
using System.Windows.Forms;

namespace checkersGUI
{
    public class Square : Button
    {
        private bool m_Active; // TODO: Relevant? Use Enabled?
        private bool m_Clicked;
        private Position m_Position;
        private PieceGUI m_PieceGUI;

        public PieceGUI PieceGUI
        {
            get => m_PieceGUI;
            set => m_PieceGUI = value;
        }

        public Square(Position i_Position)
        {
            m_Active = false;
            m_Clicked = false;
            m_Position = i_Position;
            PieceGUI = null;
            initializeComponent();
        }

        private void initializeComponent()
        {
            SuspendLayout();
            Enabled = false;
            Top = m_Position.Row * MainGame.k_ButtonSize;
            Left = m_Position.Col * MainGame.k_ButtonSize;
            Name = "Square" + m_Position.Row + m_Position.Col;
            Width = MainGame.k_ButtonSize;
            Height = Width;
            BackgroundImage = Properties.Resources.back1;
            BackgroundImageLayout = ImageLayout.Stretch;
            Click += square_Click;
        }

        private void square_Click(object i_Sender, EventArgs i_EventArgs)
        {
            if (!m_Clicked)
            {
                onFirstClick();
            }
            else
            {
                onSecondClick();
            }

            m_Clicked = !m_Clicked;
        }

        private void onFirstClick()
        {
            BackColor = Color.LightBlue;
        }

        private void onSecondClick()
        {
            BackColor = Color.Black;
        }

        public void AssignPiece(PieceGUI i_PieceGui)
        {
            m_PieceGUI = i_PieceGui;
        }
    }

}