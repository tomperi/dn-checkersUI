using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace checkersGUI
{
    public class GroupboxBoardGUI : GroupBox
    {
        private readonly int m_Size;
        private readonly Square[,] r_BoardMatrixGUI;
        private Board m_Board;
        private Position m_StartMove;
        private Position m_EndMove;

        public GroupboxBoardGUI(Board i_Board)
        {
            r_BoardMatrixGUI = new Square[i_Board.Size, i_Board.Size];
            m_Board = i_Board;
            m_Size = i_Board.Size;
            initializeComponent();
        }

        public Square[,] BoardMatrixGui
        {
            get
            {
                return r_BoardMatrixGUI;
            }
        }

        private void initializeComponent()
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
                        Square newSquare = new Square(new Position(i, j), true);
                        newSquare.Click += squareClicked;
                        r_BoardMatrixGUI[i, j] = newSquare;
                        m_Board.MoveStartListener += newSquare.squareStartPossible;
                        m_Board.RemovePieceListener += newSquare.removePiece;
                        Controls.Add(newSquare);

                        if (m_Board.BoardMatrix[i, j] != null)
                        {
                            // Create a new piece
                            PieceGUI newPiece = new PieceGUI(m_Board.BoardMatrix[i, j].PieceSymbol, newSquare);
                            newSquare.AssignPiece(newPiece);
                            Controls.Add(newPiece);
                            newPiece.BringToFront();
                        }
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
            Width = m_Size * MainGame.k_ButtonSize;
            Height = m_Size * MainGame.k_ButtonSize; 
        }

        public void NewBoard(Board i_Board)
        {
            m_Board = i_Board;
            foreach (Square square in r_BoardMatrixGUI)
            {
                if (square != null)
                {
                    square.PieceGUI?.Hide();
                    square?.Hide();
                }
            }
            initializeComponent();
        }

        private void squareClicked(object i_Sender, EventArgs i_E)
        {
            DeactivateAllIrrelevantSquares();
            foreach (Square square in BoardMatrixGui)
            {
                if (square == i_Sender)
                {
                    if (square.MoveStart)
                    {
                        square.Highlight();
                        m_StartMove = square.Position;
                        foreach (Move move in m_Board.PossibleMovesForPiece(square.Position))
                        {
                            BoardMatrixGui[move.End.Row, move.End.Col].moveEnd();
                        }
                    }
                    else if (square.MoveEnd)
                    {
                        m_EndMove = square.Position;
                        Debug.WriteLine($"Make a move from {m_StartMove} to {m_EndMove}");
                        if ((Parent as MainGame) != null)
                        {
                            (Parent as MainGame).PreformMove(m_StartMove, m_EndMove);
                        }
                    }
                }
            }
        }
        
        public void DeactivateAllIrrelevantSquares()
        {
            foreach (Square square in BoardMatrixGui)
            {
                if (square != null)
                {
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
}