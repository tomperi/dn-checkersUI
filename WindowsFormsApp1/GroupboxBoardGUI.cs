using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace checkersGUI
{
    public class GroupboxBoardGui : GroupBox
    {
        private readonly int r_Size;
        private readonly Square[,] r_BoardMatrixGui;
        private Board m_Board;
        private Position m_StartMove;
        private Position m_EndMove;

        public Square[,] BoardMatrixGui
        {
            get
            {
                return r_BoardMatrixGui;
            }
        }

        public GroupboxBoardGui(Board i_Board)
        {
            r_BoardMatrixGui = new Square[i_Board.Size, i_Board.Size];
            m_Board = i_Board;
            r_Size = i_Board.Size;
            initializeComponent();
        }

        private void initializeComponent()
        {
            // Add a button for every black square on the board
            for (int i = 0; i < r_Size; i++)
            {
                for (int j = 0; j < r_Size; j++)
                {
                    if ((i % 2) + (j % 2) == 1)
                    {
                        // Create an empty button
                        Square newSquare = new Square(new Position(i, j), true);
                        newSquare.Click += squareClicked;
                        r_BoardMatrixGui[i, j] = newSquare;
                        m_Board.MoveStartListener += newSquare.MoveStartPossible;
                        m_Board.RemovePieceListener += newSquare.RemovePiece;
                        Controls.Add(newSquare);

                        if (m_Board.BoardMatrix[i, j] == null)
                        {
                            continue;
                        }

                        // Create a new piece
                        PieceGui newPiece = new PieceGui(m_Board.BoardMatrix[i, j].PieceSymbol, newSquare);
                        newSquare.AssignPiece(newPiece);
                        Controls.Add(newPiece);
                        newPiece.BringToFront();
                    }
                    else
                    {
                        // Create a placeholder square you can not change
                        Square newDisabledSquare = new Square(new Position(i, j), false);
                        Controls.Add(newDisabledSquare);
                    }
                }
            }

            // Change the group size according to the amount of buttons
            Width = r_Size * MainGame.k_ButtonSize;
            Height = r_Size * MainGame.k_ButtonSize; 
        }

        public void NewBoard(Board i_Board)
        {
            m_Board = i_Board;

            foreach (Square square in r_BoardMatrixGui)
            {
                if (square != null)
                {
                    square.PieceGUI?.Hide();
                    square.Hide();
                }
            }

            initializeComponent();
        }

        private void squareClicked(object i_Sender, EventArgs i_E)
        {
            DeactivateAllIrrelevantSquares();
            foreach (Square square in BoardMatrixGui)
            {
                if (square != i_Sender)
                {
                    continue;
                }

                if (square.MoveStart)
                {
                    square.Highlight();
                    m_StartMove = square.Position;
                    foreach (Move move in m_Board.PossibleMovesForPiece(square.Position))
                    {
                        BoardMatrixGui[move.End.Row, move.End.Col].MoveEndPossible();
                    }
                }
                else if (square.MoveEnd)
                {
                    m_EndMove = square.Position;
                    Debug.WriteLine($"Make a move from {m_StartMove} to {m_EndMove}");
                    if ((Parent as MainGame) != null)
                    {
                        ((MainGame)Parent).PreformMove(m_StartMove, m_EndMove);
                    }
                }
            }
        }
        
        public void DeactivateAllIrrelevantSquares()
        {
            foreach (Square square in BoardMatrixGui)
            {
                if (square == null)
                {
                    continue;
                }

                if (square.MoveStart || square.MoveEnd)
                {
                    square.DefaultBackground();
                }
                else
                {
                    square.BackToBasic();
                }
            }
        }
    }
}