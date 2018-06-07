using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Text;
using checkers;

namespace checkersGUI
{
    public class MainGame : Form
    {
        public enum eGameStatus
        {
            Playing,
            Win,
            Draw,
            Forfit
        }

        public enum eBoardSize
        {
            Small = 6,
            Medium = 8,
            Large = 10
        }

        // Game Settings
        internal const int k_MaxNameSize = 20;
        internal const int k_ButtonSize = 50;

        // MainGame Form Controls
        private FormGameSettings formGameSettings;
        private Label labelPlayer1Name;
        private Label labelPlayer2Name;
        private Label labelPlayer1Score;
        private Label labelPlayer2Score;
        private GroupboxBoardGUI groupboxBoardGui;

        // Default UI Settings
        private readonly Font defaultFont = new Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));

        // Game Variables 
        private readonly Player r_Player1;
        private readonly Player r_Player2;
        private Board m_Board;
        private int m_BoardSize;
        private Player m_CurrentPlayer;
        private List<Move> m_PossibleMove;
        private bool m_CloseGame;

        public MainGame()
        {
            r_Player1 = new Player(ePlayerPosition.BottomPlayer);
            r_Player2 = new Player(ePlayerPosition.TopPlayer);
            m_CurrentPlayer = r_Player1;
            Load += Run;
        }

        private void Run(object i_Sender, EventArgs i_E)
        {
            getUserSettings();
            initGame();
            initializeComponent();
            getMove();
        }
        
        private void initGame()
        {
            m_Board = new Board(m_BoardSize);
            m_Board.LabelPointsListener += UpdatePointsLabel;
            eGameStatus gameStatus = eGameStatus.Playing;
            ePlayerPosition winner = ePlayerPosition.BottomPlayer;
            r_Player1.ClearMoveHistory();
            r_Player2.ClearMoveHistory();
            m_CurrentPlayer = r_Player1;
            Move previousMove = null;
            m_CloseGame = false;
        }

        private void getUserSettings()
        {
            formGameSettings = new FormGameSettings();
            if (formGameSettings.ShowDialog() == DialogResult.OK)
            {
                // Do something with the settings
                m_BoardSize = (int) formGameSettings.BoardSize;
                r_Player1.Name = formGameSettings.Player1Name;
                r_Player2.Name = formGameSettings.Player2Name;
                r_Player2.PlayerType = formGameSettings.Player2Type;
            }
            else
            {
                // TODO: Close the entire app
                m_CloseGame = true;
                Close();
            }
        }

        private void initializeComponent()
        {
            labelPlayer1Name = new Label();
            labelPlayer2Name = new Label();
            labelPlayer1Score = new Label();
            labelPlayer2Score = new Label();
            groupboxBoardGui = new GroupboxBoardGUI(m_Board);
            SuspendLayout();

            // labelPlayer1Name
            labelPlayer1Name.Width = 110;
            labelPlayer1Name.Height = 20;
            labelPlayer1Name.Top = 15;
            labelPlayer1Name.Font = defaultFont;
            labelPlayer1Name.TextAlign = ContentAlignment.MiddleCenter;
            labelPlayer1Name.Name = "labelPlayer1Name";
            labelPlayer1Name.Text = string.Format("{0}:", r_Player1.Name);

            // labelPlayer2Name
            labelPlayer2Name.Width = labelPlayer1Name.Width;
            labelPlayer2Name.Height = labelPlayer1Name.Height;
            labelPlayer2Name.Top = labelPlayer1Name.Top;
            labelPlayer2Name.Font = defaultFont;
            labelPlayer2Name.TextAlign = ContentAlignment.MiddleCenter;
            labelPlayer2Name.Name = "labelPlayer2Name";
            labelPlayer2Name.Text = string.Format("{0}:", r_Player2.Name);

            // labelPlayer1Score
            labelPlayer1Score.Width = 50;
            labelPlayer1Score.Height = 20;
            labelPlayer1Score.Top = labelPlayer1Name.Top + 25;
            labelPlayer1Score.Font = defaultFont;
            labelPlayer1Score.TextAlign = ContentAlignment.MiddleCenter;
            labelPlayer1Score.Text = m_Board.GetPlayerScore(ePlayerPosition.BottomPlayer).ToString();

            // labelPlayer2Score
            labelPlayer2Score.Width = 50;
            labelPlayer2Score.Height = 20;
            labelPlayer2Score.Top = labelPlayer1Score.Top;
            labelPlayer2Score.Font = defaultFont;
            labelPlayer2Score.TextAlign = ContentAlignment.MiddleCenter;
            labelPlayer2Score.Text = m_Board.GetPlayerScore(ePlayerPosition.TopPlayer).ToString();

            // boardGui
            groupboxBoardGui.Top = 75;
            groupboxBoardGui.Left = 30;
    
            // Position the elements
            labelPlayer1Name.Left = groupboxBoardGui.Left + (groupboxBoardGui.Width / 4) - (labelPlayer1Name.Width / 2);
            labelPlayer2Name.Left = groupboxBoardGui.Left + (groupboxBoardGui.Width * 3 / 4) - (labelPlayer2Name.Width / 2);
            labelPlayer1Score.Left = labelPlayer1Name.Left + labelPlayer1Score.Width / 2;
            labelPlayer2Score.Left = labelPlayer2Name.Left + labelPlayer2Score.Width / 2;

            // MainGame
            // Add all Controls
            Controls.Add(this.labelPlayer2Name);
            Controls.Add(this.labelPlayer1Name);
            Controls.Add(labelPlayer1Score);
            Controls.Add(labelPlayer2Score);
            Controls.Add(groupboxBoardGui);

            // MainGame properties
            Width = groupboxBoardGui.Width + 70;
            Height = groupboxBoardGui.Height + 130;
            Name = "MainGame";
            Text = "Damka";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        private void getMove()
        {
            Debug.WriteLine(m_CurrentPlayer.PlayerPosition);
            Move previousMove = m_CurrentPlayer.GetLastMove();
            if (m_CurrentPlayer.PlayerType == Player.ePlayerType.Human)
            {
                m_PossibleMove = m_Board.GetPossibleMoves(m_CurrentPlayer.PlayerPosition, m_CurrentPlayer.GetLastMove());
                Debug.WriteLine("Possible moves " + m_PossibleMove);
            }
            else
            {
                Debug.WriteLine("Computer makes a move");
                Move newMove = m_Board.GetRandomMove(m_CurrentPlayer.PlayerPosition, previousMove);
                PreformMove(newMove.Begin, newMove.End);
            }
        }

        public void PreformMove(Position i_Start, Position i_End)
        {
            Move newMove = new Move(i_Start, i_End, m_CurrentPlayer.PlayerPosition);
            m_Board.MovePiece(ref newMove, m_CurrentPlayer.GetLastMove(), out checkersGUI.Move.eMoveStatus moveStatus);
            if (moveStatus == checkersGUI.Move.eMoveStatus.Illegal)
            {
                Debug.WriteLine("Error handling move");
            }
            else
            {
                Debug.WriteLine("Move the pieceGUI");
                Square startSquare = groupboxBoardGui.BoardMatrixGui[i_Start.Row, i_Start.Col];
                Square endSquare = groupboxBoardGui.BoardMatrixGui[i_End.Row, i_End.Col];
                if (startSquare.PieceGUI != null)
                {
                    startSquare.PieceGUI.MovePiece(endSquare);
                    if (endSquare.Position.Row == 0 || endSquare.Position.Row == m_BoardSize -1)
                    {
                        endSquare.setKing();
                    }
                }

                if (moveStatus != checkersGUI.Move.eMoveStatus.AnotherJumpPossible)
                {

                    changeActivePlayer();
                }
            }

            checkGameStatus();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        { 
            base.OnFormClosing(e);

            Debug.WriteLine(e.CloseReason);

            if (!m_CloseGame &&
                MessageBox.Show(this, "Are you sure you want to quit?", "Quit Game", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                m_CloseGame = false;
            }
        }

        private void checkGameStatus()
        {
            Debug.WriteLine("Check game status");
            eGameStatus gameStatus = m_Board.GetGameStatus(m_CurrentPlayer, out ePlayerPosition winner);
            if (gameStatus == eGameStatus.Playing)
            {
                Debug.WriteLine("Another round! Hurray!");
                getMove();
            }
            else
            {
                Debug.WriteLine("Game end " + gameStatus);
                concludeSingleGame(gameStatus, winner);
            }
        }

        private void changeActivePlayer()
        {
            m_CurrentPlayer = (m_CurrentPlayer == r_Player1) ? r_Player2 : r_Player1;
        }

        private void concludeSingleGame(eGameStatus i_GameStatus, ePlayerPosition i_Winner)
        {
            int player1Points = m_Board.GetPlayerScore(r_Player1.PlayerPosition);
            int player2Points = m_Board.GetPlayerScore(r_Player2.PlayerPosition);

            r_Player1.Points += player1Points;
            r_Player2.Points += player2Points;

            StringBuilder endGame = new StringBuilder();

            switch (i_GameStatus)
            {
                case eGameStatus.Draw:
                    endGame.Append("Game has ended in a draw!");
                    break;
                case eGameStatus.Win:
                    string winner = (r_Player1.PlayerPosition == i_Winner) ? r_Player1.Name : r_Player2.Name;
                    endGame.Append(string.Format("{0} has won!", winner));
                    break;
            }

            endGame.Append(Environment.NewLine);
            endGame.Append("Total number of points so far - ");
            endGame.Append(Environment.NewLine);
            endGame.Append(string.Format("{0} : {1} --- {2} : {3}", r_Player1.Name, r_Player1.Points, r_Player2.Name, r_Player2.Points));
            endGame.Append(Environment.NewLine);
            endGame.Append("Player another game?");

            if (MessageBox.Show(endGame.ToString(), "Game Over", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Debug.WriteLine("Player another game");
                playAnotherGame();
            }
            else
            {
                Debug.Write("Closing the game");
                closeGame();
                // Close the app
            }
        }

        private void closeGame()
        {
            m_CloseGame = true;
            Debug.WriteLine("Thank you for playing!");
            MessageBox.Show("Thank you for playing", "Damka", MessageBoxButtons.OK);
            Close();
        }

        private void playAnotherGame()
        {
            initGame();
            groupboxBoardGui.NewBoard(m_Board);
            getMove();
        }

        public void UpdatePointsLabel()
        {
            labelPlayer1Score.Text = m_Board.GetPlayerScore(ePlayerPosition.BottomPlayer).ToString();
            labelPlayer2Score.Text = m_Board.GetPlayerScore(ePlayerPosition.TopPlayer).ToString();
        }
    }
}