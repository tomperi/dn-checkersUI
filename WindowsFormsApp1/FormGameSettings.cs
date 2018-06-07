using System;
using System.Drawing;
using System.Windows.Forms;

namespace checkersGUI
{
    public class FormGameSettings : Form
    {
        private readonly Font r_DefaultFont = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 177);
        private readonly Font r_DefaultTitleFont = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, 177);

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
        
        public FormGameSettings()
        {
            initializeComponent();
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
                return checkboxPlayer2Type.Checked ? 
                                         textBoxPlayer2Name.Text : "Computer";
            }
        }

        public Player.ePlayerType Player2Type
        {
            get
            {
                return checkboxPlayer2Type.Checked ? 
                           Player.ePlayerType.Human : Player.ePlayerType.Computer;
            }
        }

        private void initializeComponent()
        {
            // Init Components
            labelBoardSize = new Label();
            radioButtonBoardSizeSix = new RadioButton();
            radioButtonBoardSizeEight = new RadioButton();
            radioButtonBoardSizeTen = new RadioButton();
            labelPlayers = new Label();
            labelPlayer1Name = new Label();
            checkboxPlayer2Type = new CheckBox();
            textBoxPlayer2Name = new TextBox();
            textBoxPlayer1Name = new TextBox();
            buttonSubmitSettings = new Button();
            SuspendLayout();

            // labelBoardSize
            labelBoardSize.AutoSize = true;
            labelBoardSize.Font = r_DefaultTitleFont;
            labelBoardSize.Location = new Point(13, 13);
            labelBoardSize.Name = "labelBoardSize";
            labelBoardSize.Size = new Size(96, 18);
            labelBoardSize.TabIndex = 0;
            labelBoardSize.Text = "Board Size:";

            // radioButtonBoardSizeSix
            radioButtonBoardSizeSix.AutoSize = true;
            radioButtonBoardSizeSix.Font = r_DefaultFont;
            radioButtonBoardSizeSix.Location = new Point(27, 39);
            radioButtonBoardSizeSix.Name = "radioButtonBoardSizeSix";
            radioButtonBoardSizeSix.Size = new Size(56, 21);
            radioButtonBoardSizeSix.TabIndex = 1;
            radioButtonBoardSizeSix.TabStop = true;
            radioButtonBoardSizeSix.Text = "6 x 6";
            radioButtonBoardSizeSix.TextAlign = ContentAlignment.MiddleCenter;
            radioButtonBoardSizeSix.UseVisualStyleBackColor = true;

            // radioButtonBoardSizeEight
            radioButtonBoardSizeEight.AutoSize = true;
            radioButtonBoardSizeEight.Font = r_DefaultFont;
            radioButtonBoardSizeEight.Location = new Point(94, 39);
            radioButtonBoardSizeEight.Name = "radioButtonBoardSizeEight";
            radioButtonBoardSizeEight.Size = new Size(56, 21);
            radioButtonBoardSizeEight.TabIndex = 2;
            radioButtonBoardSizeEight.TabStop = true;
            radioButtonBoardSizeEight.Text = "8 x 8";
            radioButtonBoardSizeEight.UseVisualStyleBackColor = true;

            // radioButtonBoardSizeTen
            radioButtonBoardSizeTen.AutoSize = true;
            radioButtonBoardSizeTen.Font = r_DefaultFont;
            radioButtonBoardSizeTen.Location = new Point(158, 39);
            radioButtonBoardSizeTen.Name = "radioButtonBoardSizeTen";
            radioButtonBoardSizeTen.Size = new Size(72, 21);
            radioButtonBoardSizeTen.TabIndex = 3;
            radioButtonBoardSizeTen.TabStop = true;
            radioButtonBoardSizeTen.Text = "10 x 10";
            radioButtonBoardSizeTen.UseVisualStyleBackColor = true;

            // labelPlayers
            labelPlayers.AutoSize = true;
            labelPlayers.Font = r_DefaultTitleFont;
            labelPlayers.Location = new Point(16, 72);
            labelPlayers.Name = "labelPlayers";
            labelPlayers.Size = new Size(69, 18);
            labelPlayers.TabIndex = 4;
            labelPlayers.Text = "Players:";

            // labelPlayer1Name
            labelPlayer1Name.AutoSize = true;
            labelPlayer1Name.Font = r_DefaultFont;
            labelPlayer1Name.Location = new Point(26, 100);
            labelPlayer1Name.Name = "labelPlayer1Name";
            labelPlayer1Name.Size = new Size(64, 17);
            labelPlayer1Name.TabIndex = 5;
            labelPlayer1Name.Text = "Player 1:";

            // checkboxPlayer2Type
            checkboxPlayer2Type.AutoSize = true;
            checkboxPlayer2Type.Font = r_DefaultFont;
            checkboxPlayer2Type.Location = new Point(29, 130);
            checkboxPlayer2Type.Name = "checkboxPlayer2Type";
            checkboxPlayer2Type.Size = new Size(83, 21);
            checkboxPlayer2Type.TabIndex = 6;
            checkboxPlayer2Type.Text = "Player 2:";
            checkboxPlayer2Type.UseVisualStyleBackColor = true;
            checkboxPlayer2Type.CheckedChanged += player2Type_CheckedChanged;

            // textBoxPlayer2Name
            textBoxPlayer2Name.Enabled = false;
            textBoxPlayer2Name.Location = new Point(115, 130);
            textBoxPlayer2Name.MaxLength = MainGame.k_MaxNameSize;
            textBoxPlayer2Name.Name = "textBoxPlayer2Name";
            textBoxPlayer2Name.Size = new Size(100, 23);
            textBoxPlayer2Name.TabIndex = 7;
            textBoxPlayer2Name.Text = "[Computer]";

            // textBoxPlayer1Name
            textBoxPlayer1Name.Location = new Point(115, 100);
            textBoxPlayer1Name.MaxLength = MainGame.k_MaxNameSize;
            textBoxPlayer1Name.Name = "textBoxPlayer1Name";
            textBoxPlayer1Name.Size = new Size(100, 23);
            textBoxPlayer1Name.TabIndex = 8;

            // buttonSubmitSettings
            buttonSubmitSettings.Location = new Point(140, 167);
            buttonSubmitSettings.Name = "buttonSubmitSettings";
            buttonSubmitSettings.Size = new Size(75, 23);
            buttonSubmitSettings.TabIndex = 9;
            buttonSubmitSettings.Text = "Done";
            buttonSubmitSettings.UseVisualStyleBackColor = true;
            buttonSubmitSettings.Click += submitSettings_Click;

            // FormGameSettings
            // Add all Components
            Controls.Add(buttonSubmitSettings);
            Controls.Add(textBoxPlayer1Name);
            Controls.Add(textBoxPlayer2Name);
            Controls.Add(checkboxPlayer2Type);
            Controls.Add(labelPlayer1Name);
            Controls.Add(labelPlayers);
            Controls.Add(radioButtonBoardSizeTen);
            Controls.Add(radioButtonBoardSizeEight);
            Controls.Add(radioButtonBoardSizeSix);
            Controls.Add(labelBoardSize);

            // FormGameSettings Properties
            Font = r_DefaultFont;
            ClientSize = new Size(240, 208);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormGameSettings";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Damka Game Settings";
            TopMost = true;
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        private void player2Type_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPlayer2Name.Enabled = !textBoxPlayer2Name.Enabled;
            textBoxPlayer2Name.Text = textBoxPlayer2Name.Enabled ? string.Empty : "[Computer]";
        }

        private void submitSettings_Click(object sender, EventArgs e)
        {
            // Check if one of the textboxes is empty
            if (textBoxPlayer1Name.Text == string.Empty || 
                textBoxPlayer2Name.Text == string.Empty)
            {
                MessageBox.Show("Both player names must be filled!", "Error", MessageBoxButtons.OK);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}