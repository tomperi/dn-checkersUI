using System.Drawing;
using System.Windows.Forms;
using checkersGUI;

namespace checkers
{
    public class FormGameSettings : Form
    {
        private RadioButton radioButtonBoardSizeSix;
        private RadioButton radioButtonBoardSizeEight;
        private RadioButton radioButtonBoardSizeTen;
        private Label labelPlayers;
        private Label labelPlayer1Name;
        private CheckBox checkboxPlayer2Type;
        private TextBox textBoxPlayer2Name;
        private TextBox textBoxPlayer1Name;
        private Button buttonSubmitSettings;
        private Label labelBoardSize;

        private Font r_titleFont;
        private Font r_textFont;

        public FormGameSettings()
        {
            InitializeComponent();
        }

        public MainGame.eBoardSize BoardSize
        {
            get
            {
                MainGame.eBoardSize boardSize = MainGame.eBoardSize.Medium;
                if (radioButtonBoardSizeSix.Checked)
                {
                    boardSize = MainGame.eBoardSize.Small;
                }
                else if (radioButtonBoardSizeEight.Checked)
                {
                    boardSize = MainGame.eBoardSize.Medium;
                }
                else if (radioButtonBoardSizeTen.Checked)
                {
                    boardSize = MainGame.eBoardSize.Large;
                }

                return boardSize;
            }
        }

        public string Player1Name
        {
            get
            {
                return textBoxPlayer1Name.Text;
            }
        }

        public string Player2Name
        {
            get
            {
                string player2Name;

                if (checkboxPlayer2Type.Checked)
                {
                    player2Name = textBoxPlayer2Name.Text;
                }
                else
                {
                    player2Name = "Computer";
                }

                return player2Name;
            }
        }

        public Player.ePlayerType Player2Type
        {
            get
            {
                Player.ePlayerType playerType = Player.ePlayerType.Computer;
                if (checkboxPlayer2Type.Checked)
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
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.radioButtonBoardSizeSix = new System.Windows.Forms.RadioButton();
            this.radioButtonBoardSizeEight = new System.Windows.Forms.RadioButton();
            this.radioButtonBoardSizeTen = new System.Windows.Forms.RadioButton();
            this.labelPlayers = new System.Windows.Forms.Label();
            this.labelPlayer1Name = new System.Windows.Forms.Label();
            this.checkboxPlayer2Type = new System.Windows.Forms.CheckBox();
            this.textBoxPlayer2Name = new System.Windows.Forms.TextBox();
            this.textBoxPlayer1Name = new System.Windows.Forms.TextBox();
            this.buttonSubmitSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelBoardSize
            // 
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelBoardSize.Location = new System.Drawing.Point(13, 13);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(96, 18);
            this.labelBoardSize.TabIndex = 0;
            this.labelBoardSize.Text = "Board Size:";
            // 
            // radioButtonBoardSizeSix
            // 
            this.radioButtonBoardSizeSix.AutoSize = true;
            this.radioButtonBoardSizeSix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioButtonBoardSizeSix.Location = new System.Drawing.Point(27, 39);
            this.radioButtonBoardSizeSix.Name = "radioButtonBoardSizeSix";
            this.radioButtonBoardSizeSix.Size = new System.Drawing.Size(56, 21);
            this.radioButtonBoardSizeSix.TabIndex = 1;
            this.radioButtonBoardSizeSix.TabStop = true;
            this.radioButtonBoardSizeSix.Text = "6 x 6";
            this.radioButtonBoardSizeSix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioButtonBoardSizeSix.UseVisualStyleBackColor = true;
            // 
            // radioButtonBoardSizeEight
            // 
            this.radioButtonBoardSizeEight.AutoSize = true;
            this.radioButtonBoardSizeEight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioButtonBoardSizeEight.Location = new System.Drawing.Point(94, 39);
            this.radioButtonBoardSizeEight.Name = "radioButtonBoardSizeEight";
            this.radioButtonBoardSizeEight.Size = new System.Drawing.Size(56, 21);
            this.radioButtonBoardSizeEight.TabIndex = 2;
            this.radioButtonBoardSizeEight.TabStop = true;
            this.radioButtonBoardSizeEight.Text = "8 x 8";
            this.radioButtonBoardSizeEight.UseVisualStyleBackColor = true;
            // 
            // radioButtonBoardSizeTen
            // 
            this.radioButtonBoardSizeTen.AutoSize = true;
            this.radioButtonBoardSizeTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioButtonBoardSizeTen.Location = new System.Drawing.Point(158, 39);
            this.radioButtonBoardSizeTen.Name = "radioButtonBoardSizeTen";
            this.radioButtonBoardSizeTen.Size = new System.Drawing.Size(72, 21);
            this.radioButtonBoardSizeTen.TabIndex = 3;
            this.radioButtonBoardSizeTen.TabStop = true;
            this.radioButtonBoardSizeTen.Text = "10 x 10";
            this.radioButtonBoardSizeTen.UseVisualStyleBackColor = true;
            // 
            // labelPlayers
            // 
            this.labelPlayers.AutoSize = true;
            this.labelPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelPlayers.Location = new System.Drawing.Point(16, 72);
            this.labelPlayers.Name = "labelPlayers";
            this.labelPlayers.Size = new System.Drawing.Size(69, 18);
            this.labelPlayers.TabIndex = 4;
            this.labelPlayers.Text = "Players:";
            // 
            // labelPlayer1Name
            // 
            this.labelPlayer1Name.AutoSize = true;
            this.labelPlayer1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelPlayer1Name.Location = new System.Drawing.Point(26, 100);
            this.labelPlayer1Name.Name = "labelPlayer1Name";
            this.labelPlayer1Name.Size = new System.Drawing.Size(64, 17);
            this.labelPlayer1Name.TabIndex = 5;
            this.labelPlayer1Name.Text = "Player 1:";
            // 
            // checkboxPlayer2Type
            // 
            this.checkboxPlayer2Type.AutoSize = true;
            this.checkboxPlayer2Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkboxPlayer2Type.Location = new System.Drawing.Point(29, 130);
            this.checkboxPlayer2Type.Name = "checkboxPlayer2Type";
            this.checkboxPlayer2Type.Size = new System.Drawing.Size(83, 21);
            this.checkboxPlayer2Type.TabIndex = 6;
            this.checkboxPlayer2Type.Text = "Player 2:";
            this.checkboxPlayer2Type.UseVisualStyleBackColor = true;
            this.checkboxPlayer2Type.CheckedChanged += new System.EventHandler(this.player2Type_CheckedChanged);
            // 
            // textBoxPlayer2Name
            // 
            this.textBoxPlayer2Name.Enabled = false;
            this.textBoxPlayer2Name.Location = new System.Drawing.Point(115, 130);
            this.textBoxPlayer2Name.MaxLength = 20;
            this.textBoxPlayer2Name.Name = "textBoxPlayer2Name";
            this.textBoxPlayer2Name.Size = new System.Drawing.Size(100, 23);
            this.textBoxPlayer2Name.TabIndex = 7;
            this.textBoxPlayer2Name.Text = "[Computer]";
            // 
            // textBoxPlayer1Name
            // 
            this.textBoxPlayer1Name.Location = new System.Drawing.Point(115, 100);
            this.textBoxPlayer1Name.MaxLength = 20;
            this.textBoxPlayer1Name.Name = "textBoxPlayer1Name";
            this.textBoxPlayer1Name.Size = new System.Drawing.Size(100, 23);
            this.textBoxPlayer1Name.TabIndex = 8;
            // 
            // buttonSubmitSettings
            // 
            this.buttonSubmitSettings.Location = new System.Drawing.Point(140, 167);
            this.buttonSubmitSettings.Name = "buttonSubmitSettings";
            this.buttonSubmitSettings.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmitSettings.TabIndex = 9;
            this.buttonSubmitSettings.Text = "Done";
            this.buttonSubmitSettings.UseVisualStyleBackColor = true;
            this.buttonSubmitSettings.Click += new System.EventHandler(this.submitSettings_Click);
            // 
            // FormGameSettings
            // 
            this.ClientSize = new System.Drawing.Size(240, 208);
            this.Controls.Add(this.buttonSubmitSettings);
            this.Controls.Add(this.textBoxPlayer1Name);
            this.Controls.Add(this.textBoxPlayer2Name);
            this.Controls.Add(this.checkboxPlayer2Type);
            this.Controls.Add(this.labelPlayer1Name);
            this.Controls.Add(this.labelPlayers);
            this.Controls.Add(this.radioButtonBoardSizeTen);
            this.Controls.Add(this.radioButtonBoardSizeEight);
            this.Controls.Add(this.radioButtonBoardSizeSix);
            this.Controls.Add(this.labelBoardSize);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameSettings";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Damka Game Settings";
            this.TopMost = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void player2Type_CheckedChanged(object sender, System.EventArgs e)
        {
            textBoxPlayer2Name.Enabled = !textBoxPlayer2Name.Enabled;
            if (textBoxPlayer2Name.Enabled)
            {
                textBoxPlayer2Name.Text = "";
            }
            else
            {
                textBoxPlayer2Name.Text = "[Computer]";
            }
        }

        private void submitSettings_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}