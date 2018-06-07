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
            initializeComponent();
        }

        private void initializeComponent()
        {
            SuspendLayout();
            Top = m_Position.Row * MainGame.k_ButtonSize;
            Left = m_Position.Col * MainGame.k_ButtonSize;
            Name = "Square" + m_Position.Row + m_Position.Col;
            Size = new Size(MainGame.k_ButtonSize, MainGame.k_ButtonSize);
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.darkTile;
            BackgroundImageLayout = ImageLayout.Stretch;
            Enabled = false;
        }
    }
}