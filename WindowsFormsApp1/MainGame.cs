using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
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
        private Label labelPlayer2Score;
        private Label labelPlayer1Score;
        private GroupboxBoardGUI groupboxBoardGui;

        // Game Variables 
        private readonly Player r_Player1;
        private readonly Player r_Player2;
        private Board m_Board;
        private int m_BoardSize;
        private Player m_CurrentPlayer;

        public MainGame()
        {
            r_Player1 = new Player(ePlayerPosition.BottomPlayer);
            r_Player2 = new Player(ePlayerPosition.TopPlayer);
            m_CurrentPlayer = r_Player1;
            Run();
        }

        public void Run()
        {
            getUserSettings();
            initGame();
            initializeComponent();
            playGame();
        }
        
        private void initGame()
        {
            m_Board = new Board(m_BoardSize);
            eGameStatus gameStatus = eGameStatus.Playing;
            ePlayerPosition winner = ePlayerPosition.BottomPlayer;
            r_Player1.ClearMoveHistory();
            r_Player2.ClearMoveHistory();
            m_CurrentPlayer = r_Player1;
            Move previousMove = null;
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
                // Close the entire app
            }
        }

        private void initializeComponent()
        {
            labelPlayer1Score = new Label();
            labelPlayer2Score = new Label();
            groupboxBoardGui = new GroupboxBoardGUI(m_Board);
            SuspendLayout();

            // labelPlayer1Score
            labelPlayer1Score.AutoSize = true;
            labelPlayer1Score.Top = 15;
            labelPlayer1Score.Left = groupboxBoardGui.Width / 4;
            labelPlayer1Score.Name = "labelPlayer1Score";
            labelPlayer1Score.Size = new Size(91, 13); // Todo: change to height/width
            labelPlayer1Score.TabIndex = 0;
            labelPlayer1Score.Text = "Player 1: <Score>";

            // labelPlayer2Score
            labelPlayer2Score.AutoSize = true;
            labelPlayer2Score.Top = labelPlayer1Score.Top;
            labelPlayer2Score.Left = groupboxBoardGui.Width * 3 / 4;
            labelPlayer2Score.Name = "labelPlayer2Score";
            labelPlayer2Score.Size = new Size(91, 13); // Todo: change to height/width
            labelPlayer2Score.TabIndex = 1;
            labelPlayer2Score.Text = "Player 2: <Score>";

            // boardGui
            groupboxBoardGui.Top = 50;
            groupboxBoardGui.Left = 30;

            // MainGame
            // Add all Controls
            Controls.Add(this.labelPlayer2Score);
            Controls.Add(this.labelPlayer1Score);
            Controls.Add(groupboxBoardGui);

            // MainGame properties
            Width = groupboxBoardGui.Width + 70;
            Height = groupboxBoardGui.Height + 100;
            Name = "MainGame";
            Text = "Damka";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        private void playGame()
        {
            eGameStatus gameStatus = eGameStatus.Playing;
            ePlayerPosition winner = ePlayerPosition.BottomPlayer;
            r_Player1.ClearMoveHistory();
            r_Player2.ClearMoveHistory();
            m_CurrentPlayer = r_Player1;
            Move previousMove = null;

            while (gameStatus == eGameStatus.Playing)
            {
                // Get a players move and preform it
                Move currentMove = getMove(out Move.eMoveStatus currentMoveStatus);
                m_CurrentPlayer.AddMove(currentMove);

                // If the player can not preform another jump, change player
                if (currentMoveStatus == Move.eMoveStatus.AnotherJumpPossible)
                {
                    previousMove = m_CurrentPlayer.GetLastMove();
                }
                else
                {
                    changeActivePlayer();
                    previousMove = null;
                }

                gameStatus = m_Board.GetGameStatus(m_CurrentPlayer, out winner);
            }
        }

        private Move getMove(out Move.eMoveStatus o_CurrentMoveStatus)
        {
            o_CurrentMoveStatus = checkersGUI.Move.eMoveStatus.AnotherJumpPossible;
            Move newMove = null;
            Move previousMove = m_CurrentPlayer.GetLastMove();
            if (m_CurrentPlayer.PlayerType == Player.ePlayerType.Human)
            {
                
            }
            else
            {
                newMove = m_Board.GetRandomMove(m_CurrentPlayer.PlayerPosition, previousMove);
                m_Board.MovePiece(ref newMove, previousMove, out o_CurrentMoveStatus);
            }
            
            return newMove;
        }

        private void changeActivePlayer()
        {
            m_CurrentPlayer = (m_CurrentPlayer == r_Player1) ? r_Player2 : r_Player1;
        }
    }
}