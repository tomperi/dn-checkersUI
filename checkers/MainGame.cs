using System.Windows.Forms;
using System.Drawing;

namespace checkers
{
    public class MainGame : Form
    {
        private Label player2Score;
        private Label player1Score;

        public MainGame(Piece[,] i_Board)
        {
            InitializeComponent(i_Board);
        }

        private void InitializeComponent(Piece[,] i_Board)
        {
            this.player1Score = new System.Windows.Forms.Label();
            this.player2Score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // player1Score
            // 
            this.player1Score.AutoSize = true;
            this.player1Score.Location = new System.Drawing.Point(40, 13);
            this.player1Score.Name = "player1Score";
            this.player1Score.Size = new System.Drawing.Size(91, 13);
            this.player1Score.TabIndex = 0;
            this.player1Score.Text = "Player 1: <Score>";
            // 
            // player2Score
            // 
            this.player2Score.AutoSize = true;
            this.player2Score.Location = new System.Drawing.Point(156, 13);
            this.player2Score.Name = "player2Score";
            this.player2Score.Size = new System.Drawing.Size(91, 13);
            this.player2Score.TabIndex = 1;
            this.player2Score.Text = "Player 2: <Score>";
            // 
            // MainGame
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.player2Score);
            this.Controls.Add(this.player1Score);
            this.Name = "MainGame";
            this.Text = "Damka";
            this.ResumeLayout(false);
            this.PerformLayout();

            int dimension = i_Board.GetLength(0);

            // Print the board
            /* TODO: Method not completed
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    if (i_Board[i, j] != null)
                    {
                        currentPieceSymbol = getPieceSymbol(i_Board[i, j]);
                        Square
                    }
                    else
                    {

                    }

                    boardStringBuilder.Append(" " + currentPieceSymbol + " |");
                }

                currentLabel++;
                boardStringBuilder.Append(createLineSeperator(dimension));
            }
            */
        }
    }
}