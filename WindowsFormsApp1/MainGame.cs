using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using checkers;

namespace checkersGUI
{
    public class MainGame : Form
    {
        public enum eBoardSize
        {
            Small = 6,
            Medium = 8,
            Large = 10
        }

        private FormGameSettings formGameSettings;
        private Label labelPlayer2Score;
        private Label labelPlayer1Score;
        private BoardGUI boardGUI;

        public MainGame()
        {
            GetUserSettings();
            InitializeComponent();
        }

        private void GetUserSettings()
        {
            formGameSettings = new FormGameSettings();
            if (formGameSettings.ShowDialog() == DialogResult.OK)
            {
                // Do something with the settings
            }
            else
            {
                // Close the entire app
            }

        }

        private void InitializeComponent()
        {
            labelPlayer1Score = new System.Windows.Forms.Label();
            labelPlayer2Score = new System.Windows.Forms.Label();
            boardGUI = new BoardGUI(8);
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

            // boardGui
            boardGUI.Top = 50;
            boardGUI.Left = 50;

            // MainGame
            ClientSize = new System.Drawing.Size(284, 261);
            Controls.Add(this.labelPlayer2Score);
            Controls.Add(this.labelPlayer1Score);
            Controls.Add(boardGUI);
            Name = "MainGame";
            Text = "Damka";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}