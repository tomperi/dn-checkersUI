﻿using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace checkers
{
    public class MainGame : Form
    {
        private Label labelPlayer2Score;
        private Label labelPlayer1Score;
        private List<ActiveSquare> listOfSquares;

        public MainGame(Piece[,] i_Board)
        {
            listOfSquares = new List<ActiveSquare>();
            InitializeComponent(i_Board);
        }

        private void InitializeComponent(Piece[,] i_Board)
        {
            labelPlayer1Score = new System.Windows.Forms.Label();
            labelPlayer2Score = new System.Windows.Forms.Label();
            SuspendLayout();

            // labelPlayer1Score
            labelPlayer1Score.AutoSize = true;
            labelPlayer1Score.Location = new System.Drawing.Point(40, 13);
            labelPlayer1Score.Name = "labelPlayer1Score";
            labelPlayer1Score.Size = new System.Drawing.Size(91, 13);
            labelPlayer1Score.TabIndex = 0;
            labelPlayer1Score.Text = "Player 1: <Score>";

            // labelPlayer2Score
            labelPlayer2Score.AutoSize = true;
            labelPlayer2Score.Location = new System.Drawing.Point(156, 13);
            labelPlayer2Score.Name = "labelPlayer2Score";
            labelPlayer2Score.Size = new System.Drawing.Size(91, 13);
            labelPlayer2Score.TabIndex = 1;
            labelPlayer2Score.Text = "Player 2: <Score>";

            // MainGame
            ClientSize = new System.Drawing.Size(284, 261);
            Controls.Add(this.labelPlayer2Score);
            Controls.Add(this.labelPlayer1Score);
            Name = "MainGame";
            Text = "Damka";
            ResumeLayout(false);
            PerformLayout();

            int dimension = i_Board.GetLength(0);

            // Print the board
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    if (i_Board[i, j] != null)
                    {
                        // Create an empty button
                        ActiveSquare newSquare = new ActiveSquare(i_Board[i, j].PlayerPosition, i_Board[i, j].PieceSymbol, true, new Position(i, j));
                        listOfSquares.Add(newSquare);
                        Controls.Add(newSquare);
                    }
                    else
                    {
                        // Create a non empty button
                        ActiveSquare newSquare = new ActiveSquare(false, new Position(i, j));
                        listOfSquares.Add(newSquare);
                        Controls.Add(newSquare);
                    }
                    
                }
            }
        }
    }
}