using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SimplePuzzleGameInheritage
{
    partial class Form1
    {
        private static Random rnd = new Random();

        private MyButton[,] _buttons;
        private const int SIZE = 75;
        private const int GAP = 10;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _buttons = new MyButton[4, 4];
            int amountOfButtons = 0;

            int tabInd = 0;

            int i = 0;
            int j = 0;

            while (amountOfButtons < _buttons.Length - 1)
            {
                do
                {
                    i = rnd.Next(0, 4);
                    j = rnd.Next(0, 4);

                } while (_buttons[i, j] != null);

                int x = i * SIZE + GAP;
                int y = j * SIZE + GAP;

                _buttons[i, j] = new MyButton()
                {
                    I = i,
                    J = j,
                    Location = new Point(x, y),
                    Name = string.Format("button{0}", ++tabInd),
                    Size = new Size(SIZE, SIZE),
                    TabIndex = tabInd,
                    Text = string.Format("{0}", tabInd),
                    UseVisualStyleBackColor = true,
                    BackColor = Color.PeachPuff,
                    Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                };

                _buttons[i, j].Click += new EventHandler(this.Button_Click);

                this.Controls.Add(_buttons[i, j]);
                ++amountOfButtons;
            }

            this.components = new Container();
            this.timer1 = new Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new EventHandler(this.Timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(320, 320);
            this.Name = "Form1";
            this.Text = "Simple Puzzle Game";
            this.BackColor = Color.OldLace;
            this.MaximizeBox = false;
            this.Opacity = 0D;
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.Load += new EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Timer timer1;
    }
}

