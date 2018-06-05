using System.Collections.Generic;
using System.Windows.Forms;

namespace checkersGUI
{
    public class GroupboxBoardGUI : GroupBox
    {
        private readonly int m_Size;
        private readonly Square[,] r_BoardMatrix;

        public GroupboxBoardGUI(Board i_Board)
        {
            r_BoardMatrix = new Square[i_Board.Size, i_Board.Size];
            m_Size = i_Board.Size;
            initializeComponent(i_Board);
        }

        private void initializeComponent(Board i_Board)
        {
            // Add a button for every black square on the board
            for (int i = 0; i < m_Size; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    if (i % 2 + j % 2 == 1)
                    {
                        // Create an empty button
                        // TODO: Merge both squares into one class
                        Square newSquare = new Square(new Position(i, j));
                        r_BoardMatrix[i, j] = newSquare;
                        Controls.Add(newSquare);

                        if (i_Board.BoardMatrix[i, j] != null)
                        {
                            // Create a new piece
                            PieceGUI newPiece = new PieceGUI(i_Board.BoardMatrix[i, j].PieceSymbol, newSquare);
                            newSquare.AssignPiece(newPiece);
                            Controls.Add(newPiece);
                            newPiece.BringToFront();
                        }
                    }
                    else
                    {
                        // Create a placeholder square you can not change
                        DisabledSquare newDisabledSquare = new DisabledSquare(new Position(i, j));
                        Controls.Add(newDisabledSquare);
                    }
                }
            }

            // Change the group size according to the amount of buttons
            Width = m_Size * MainGame.k_ButtonSize; // TODO: Change according to the button size
            Height = m_Size * MainGame.k_ButtonSize; 
        }
    }
}