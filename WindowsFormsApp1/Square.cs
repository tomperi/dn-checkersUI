using System;
using System.Drawing;
using System.Windows.Forms;

namespace checkersGUI
{
    public class Square : Button
    {
        private Position m_Position;
        private bool m_Active;
        private bool m_Clicked;

        public Square(Position i_Position)
        {
            m_Active = false;
            m_Clicked = false;
            m_Position = i_Position;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            Top = m_Position.Row * BoardGUI.k_ButtonSize;
            Left = m_Position.Col * BoardGUI.k_ButtonSize;
            Name = "Square" + m_Position.Row + m_Position.Col;
            Size = new System.Drawing.Size(BoardGUI.k_ButtonSize, BoardGUI.k_ButtonSize);
            BackColor = Color.Black;
            ForeColor = Color.White;
            BackgroundImage = Properties.Resources.back1;
            Text = "X";
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
    }

}