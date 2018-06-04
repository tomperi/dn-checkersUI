using System.Drawing;
using System.Windows.Forms;

namespace checkersGUI
{
    public class DisabledSquare : Button
    {
        private Position m_Position;

        public DisabledSquare(Position i_Position)
        {
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
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.back2;
            Enabled = false;
        }
    }

}