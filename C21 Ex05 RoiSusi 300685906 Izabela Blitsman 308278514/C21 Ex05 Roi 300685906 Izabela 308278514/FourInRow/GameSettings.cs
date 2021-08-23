using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FourInRow
{
    class GameSettings : Form
    {
        TextBox m_TextboxPlayer1Name = new TextBox();
        TextBox m_TextboxPlayer2Name = new TextBox();

        Label m_LabelPlayers = new Label();
        Label m_LabelPlayer1 = new Label();
        Label m_LabelPlayer2 = new Label();
        Label m_LabelBoardSize = new Label();
        Label m_LabelRows = new Label();
        Label m_LabelCols = new Label();

        CheckBox m_CheckboxPlayer2 = new CheckBox();

        NumericUpDown m_NumericUpDownRows = new NumericUpDown();
        NumericUpDown m_NumericUpDownCols = new NumericUpDown();

        Button m_ButtonStart = new Button();

        public GameSettings()
        {
            this.Text = "Game Settings";
            this.Size = new Size(250, 280);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            InitControls();
        }

        /// <summary>
        /// Layouting the controls (textboxes, lables, buttons) on the form
        /// </summary>
        private void InitControls()
        {
            m_LabelPlayers.Text = "Players:";
            m_LabelPlayers.Location = new Point(10, 20);
            this.Controls.Add(m_LabelPlayers);

            m_LabelPlayer1.Text = "Player 1:";
            m_LabelPlayer1.Location = new Point(20, 50);
            this.Controls.Add(m_LabelPlayer1);

            int textBoxPlayer1Top = m_LabelPlayer1.Top + m_LabelPlayer1.Height / 2;
            textBoxPlayer1Top -= m_TextboxPlayer1Name.Height / 2;

            m_TextboxPlayer1Name.Location = new Point(m_LabelPlayer1.Right + 8, textBoxPlayer1Top);
            this.Controls.Add(m_TextboxPlayer1Name);
            
            m_CheckboxPlayer2.AutoSize = true;
            m_CheckboxPlayer2.Location = new Point(20, 80);
            this.Controls.Add(m_CheckboxPlayer2);

            m_LabelPlayer2.Text = "Player 2:";
            m_LabelPlayer2.AutoSize = true;
            m_LabelPlayer2.Location = new Point(m_CheckboxPlayer2.Right + 1, 80);
            this.Controls.Add(m_LabelPlayer2);

            int textBoxPlayer2Top = m_LabelPlayer2.Top + m_LabelPlayer2.Height / 2;
            textBoxPlayer2Top -= m_LabelPlayer2.Height / 2;

            m_TextboxPlayer2Name.Text = "[Computer]";
            m_TextboxPlayer2Name.Enabled = false;
            m_TextboxPlayer2Name.Location = new Point(m_TextboxPlayer1Name.Left, textBoxPlayer2Top);
            this.Controls.Add(m_TextboxPlayer2Name);

            m_LabelBoardSize.Text = "Board Size:";
            m_LabelBoardSize.Location = new Point(20, 150);
            this.Controls.Add(m_LabelBoardSize);

            m_LabelRows.Text = "Rows:";
            m_LabelRows.AutoSize = true;
            m_LabelRows.Location = new Point(30, 180);
            this.Controls.Add(m_LabelRows);

            m_NumericUpDownRows.Minimum = 4;
            m_NumericUpDownRows.Maximum = 10;
            m_NumericUpDownRows.AutoSize = true;
            m_NumericUpDownRows.Location = new Point(m_LabelRows.Right + 1, 180);
            m_NumericUpDownRows.Width = 10;
            this.Controls.Add(m_NumericUpDownRows);

            m_LabelCols.Text = "Cols:";
            m_LabelCols.AutoSize = true;
            m_LabelCols.Location = new Point(m_NumericUpDownRows.Right + 32, m_LabelRows.Top);
            this.Controls.Add(m_LabelCols);

            m_NumericUpDownCols.Minimum = 4;
            m_NumericUpDownCols.Maximum = 10;
            m_NumericUpDownCols.AutoSize = true;
            m_NumericUpDownCols.Location = new Point(m_LabelCols.Right + 1, 180);
            m_NumericUpDownCols.Width = 10;
            this.Controls.Add(m_NumericUpDownCols);

            m_ButtonStart.Text = "Start!";
            m_ButtonStart.Location = new Point(20, 210);
            m_ButtonStart.Width = m_NumericUpDownCols.Right + 8;
            this.Controls.Add(m_ButtonStart);

            m_ButtonStart.Click += new EventHandler(m_ButtonStart_Click);
            m_CheckboxPlayer2.Click += new EventHandler(m_CheckboxPlayer2_Click);
        }

        private void m_ButtonStart_Click(object sender, EventArgs e)
        {
            //TODO: call to the game ui
        }

        private void m_CheckboxPlayer2_Click(object sender, EventArgs e)
        {
            m_TextboxPlayer2Name.Enabled = true;
            m_TextboxPlayer2Name.Text = string.Empty;
        }

        public string Player1Name
        {
            get { return m_TextboxPlayer1Name.Text; }
            set { m_TextboxPlayer1Name.Text = value; }
        }

        public string Player2Name
        {
            get { return m_TextboxPlayer2Name.Text; }
            set { m_TextboxPlayer2Name.Text = value; }
        }
    }
}
