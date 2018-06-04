using System.Collections.Generic;
using System.Windows.Forms;

namespace checkersGUI
{
    public class BoardGUI : GroupBox
    {
        internal const int k_ButtonSize = 80;
        private int m_Size;
        private List<Square> m_ListOfSquares;

        public BoardGUI(int i_Size)
        {
            m_ListOfSquares = new List<Square>();
            m_Size = i_Size;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Add a button for every black square on the board
            for (int i = 0; i < m_Size; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    if (i % 2 + j % 2 == 1)
                    {
                        // Create an empty button
                        Square newSquare = new Square(new Position(i, j));
                        m_ListOfSquares.Add(newSquare);
                        Controls.Add(newSquare);
                    }
                    else
                    {
                        DisabledSquare newDisabledSquare = new DisabledSquare(new Position(i, j));
                        Controls.Add(newDisabledSquare);
                    }
                }
            }

            // Change the group size according to the amount of buttons
            Width = m_Size * k_ButtonSize; // TODO: Change according to the button size
            Height = m_Size * k_ButtonSize; 
        }
    }
}