using System.Drawing;
using System.Windows.Forms;

namespace checkers
{
    public class GameSettingsForm : Form
    {
        private RadioButton boardSizeSix;
        private RadioButton boardSizeEight;
        private RadioButton boardSizeTen;
        private Label players;
        private Label player1NameLabel;
        private CheckBox player2Type;
        private TextBox player2NameTextBox;
        private TextBox player1NameTextBox;
        private Button submitSettings;
        private Label boardSizeLabel;

        private Font r_titleFont;
        private Font r_textFont;

        public GameSettingsForm()
        {
            InitializeComponent();
        }

        public GameManager.eBoardSize BoardSize
        {
            get
            {
                GameManager.eBoardSize boardSize = GameManager.eBoardSize.Medium;
                if (boardSizeSix.Checked)
                {
                    boardSize = GameManager.eBoardSize.Small;
                }
                else if (boardSizeEight.Checked)
                {
                    boardSize = GameManager.eBoardSize.Medium;
                }
                else if (boardSizeTen.Checked)
                {
                    boardSize = GameManager.eBoardSize.Large;
                }

                return boardSize;
            }
        }

        public string Player1Name
        {
            get
            {
                return player1NameTextBox.Text;
            }
        }

        public string Player2Name
        {
            get
            {
                return player2NameTextBox.Text;
            }
        }

        public Player.ePlayerType Player2Type
        {
            get
            {
                Player.ePlayerType playerType = Player.ePlayerType.Computer;
                if (player2Type.Checked)
                {
                    playerType = Player.ePlayerType.Human;
                }
                else
                {
                    playerType = Player.ePlayerType.Computer;
                }

                return playerType;
            }
        }

        private void InitializeComponent()
        {
            this.boardSizeLabel = new System.Windows.Forms.Label();
            this.boardSizeSix = new System.Windows.Forms.RadioButton();
            this.boardSizeEight = new System.Windows.Forms.RadioButton();
            this.boardSizeTen = new System.Windows.Forms.RadioButton();
            this.players = new System.Windows.Forms.Label();
            this.player1NameLabel = new System.Windows.Forms.Label();
            this.player2Type = new System.Windows.Forms.CheckBox();
            this.player2NameTextBox = new System.Windows.Forms.TextBox();
            this.player1NameTextBox = new System.Windows.Forms.TextBox();
            this.submitSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // boardSizeLabel
            // 
            this.boardSizeLabel.AutoSize = true;
            this.boardSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.boardSizeLabel.Location = new System.Drawing.Point(13, 13);
            this.boardSizeLabel.Name = "boardSizeLabel";
            this.boardSizeLabel.Size = new System.Drawing.Size(96, 18);
            this.boardSizeLabel.TabIndex = 0;
            this.boardSizeLabel.Text = "Board Size:";
            // 
            // boardSizeSix
            // 
            this.boardSizeSix.AutoSize = true;
            this.boardSizeSix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.boardSizeSix.Location = new System.Drawing.Point(27, 39);
            this.boardSizeSix.Name = "boardSizeSix";
            this.boardSizeSix.Size = new System.Drawing.Size(56, 21);
            this.boardSizeSix.TabIndex = 1;
            this.boardSizeSix.TabStop = true;
            this.boardSizeSix.Text = "6 x 6";
            this.boardSizeSix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.boardSizeSix.UseVisualStyleBackColor = true;
            // 
            // boardSizeEight
            // 
            this.boardSizeEight.AutoSize = true;
            this.boardSizeEight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.boardSizeEight.Location = new System.Drawing.Point(94, 39);
            this.boardSizeEight.Name = "boardSizeEight";
            this.boardSizeEight.Size = new System.Drawing.Size(56, 21);
            this.boardSizeEight.TabIndex = 2;
            this.boardSizeEight.TabStop = true;
            this.boardSizeEight.Text = "8 x 8";
            this.boardSizeEight.UseVisualStyleBackColor = true;
            // 
            // boardSizeTen
            // 
            this.boardSizeTen.AutoSize = true;
            this.boardSizeTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.boardSizeTen.Location = new System.Drawing.Point(158, 39);
            this.boardSizeTen.Name = "boardSizeTen";
            this.boardSizeTen.Size = new System.Drawing.Size(72, 21);
            this.boardSizeTen.TabIndex = 3;
            this.boardSizeTen.TabStop = true;
            this.boardSizeTen.Text = "10 x 10";
            this.boardSizeTen.UseVisualStyleBackColor = true;
            // 
            // players
            // 
            this.players.AutoSize = true;
            this.players.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.players.Location = new System.Drawing.Point(16, 72);
            this.players.Name = "players";
            this.players.Size = new System.Drawing.Size(69, 18);
            this.players.TabIndex = 4;
            this.players.Text = "Players:";
            // 
            // player1NameLabel
            // 
            this.player1NameLabel.AutoSize = true;
            this.player1NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.player1NameLabel.Location = new System.Drawing.Point(26, 100);
            this.player1NameLabel.Name = "player1NameLabel";
            this.player1NameLabel.Size = new System.Drawing.Size(64, 17);
            this.player1NameLabel.TabIndex = 5;
            this.player1NameLabel.Text = "Player 1:";
            // 
            // player2Type
            // 
            this.player2Type.AutoSize = true;
            this.player2Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.player2Type.Location = new System.Drawing.Point(29, 130);
            this.player2Type.Name = "player2Type";
            this.player2Type.Size = new System.Drawing.Size(83, 21);
            this.player2Type.TabIndex = 6;
            this.player2Type.Text = "Player 2:";
            this.player2Type.UseVisualStyleBackColor = true;
            this.player2Type.CheckedChanged += new System.EventHandler(this.player2Type_CheckedChanged);
            // 
            // player2NameTextBox
            // 
            this.player2NameTextBox.Enabled = false;
            this.player2NameTextBox.Location = new System.Drawing.Point(115, 130);
            this.player2NameTextBox.MaxLength = 20;
            this.player2NameTextBox.Name = "player2NameTextBox";
            this.player2NameTextBox.Size = new System.Drawing.Size(100, 23);
            this.player2NameTextBox.TabIndex = 7;
            this.player2NameTextBox.Text = "[Computer]";
            // 
            // player1NameTextBox
            // 
            this.player1NameTextBox.Location = new System.Drawing.Point(115, 100);
            this.player1NameTextBox.MaxLength = 20;
            this.player1NameTextBox.Name = "player1NameTextBox";
            this.player1NameTextBox.Size = new System.Drawing.Size(100, 23);
            this.player1NameTextBox.TabIndex = 8;
            // 
            // submitSettings
            // 
            this.submitSettings.Location = new System.Drawing.Point(140, 167);
            this.submitSettings.Name = "submitSettings";
            this.submitSettings.Size = new System.Drawing.Size(75, 23);
            this.submitSettings.TabIndex = 9;
            this.submitSettings.Text = "Done";
            this.submitSettings.UseVisualStyleBackColor = true;
            this.submitSettings.Click += new System.EventHandler(this.submitSettings_Click);
            // 
            // GameSettingsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(240, 208);
            this.Controls.Add(this.submitSettings);
            this.Controls.Add(this.player1NameTextBox);
            this.Controls.Add(this.player2NameTextBox);
            this.Controls.Add(this.player2Type);
            this.Controls.Add(this.player1NameLabel);
            this.Controls.Add(this.players);
            this.Controls.Add(this.boardSizeTen);
            this.Controls.Add(this.boardSizeEight);
            this.Controls.Add(this.boardSizeSix);
            this.Controls.Add(this.boardSizeLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Game Settings";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void player2Type_CheckedChanged(object sender, System.EventArgs e)
        {
            player2NameTextBox.Enabled = !player2NameTextBox.Enabled;
            if (player2NameTextBox.Enabled)
            {
                player2NameTextBox.Text = "";
            }
            else
            {
                player2NameTextBox.Text = "[Computer]";
            }
        }

        private void submitSettings_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}