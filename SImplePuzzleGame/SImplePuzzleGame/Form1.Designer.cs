using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimplePuzzleGame
{
    partial class Form1
    {
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
            this.btnNewGame = new System.Windows.Forms.Button();
            this.lblAmOfMoves = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(358, 156);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(75, 23);
            this.btnNewGame.TabIndex = 0;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.BtnNewGame_Click);
            // 
            // lblAmOfMoves
            // 
            this.lblAmOfMoves.AutoSize = true;
            this.lblAmOfMoves.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAmOfMoves.Location = new System.Drawing.Point(335, 122);
            this.lblAmOfMoves.Name = "lblAmOfMoves";
            this.lblAmOfMoves.Size = new System.Drawing.Size(121, 15);
            this.lblAmOfMoves.TabIndex = 1;
            this.lblAmOfMoves.Text = "Number of movements: ";
            this.lblAmOfMoves.Click += new System.EventHandler(this.Label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(484, 316);
            this.Controls.Add(this.lblAmOfMoves);
            this.Controls.Add(this.btnNewGame);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Puzzle Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InitializeDynamicComponents()
        {
            _buttons = new MyButton[FIELD_SIZE, FIELD_SIZE];

            int amountOfButtons = 0;

            int tabInd = 1;

            for (int j = 0; j < FIELD_SIZE; j++)
            {
                for (int i = 0; i < FIELD_SIZE; i++)
                {
                    int x = i * SIZE + GAP;
                    int y = j * SIZE + GAP;

                    _buttons[i, j] = new MyButton(i, j)
                    {
                        I = i,
                        J = j,
                        Location = new Point(x, y),
                        Name = string.Format("button{0}", tabInd),
                        Size = new Size(SIZE, SIZE),
                        TabIndex = tabInd,
                        Text = string.Format("{0}", _game.GetNumber(i, j)),
                        UseVisualStyleBackColor = true,
                        BackColor = Color.PeachPuff,
                        Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                    };

                    InitializeEmpty(j, i);

                    _buttons[i, j].Click += new EventHandler(this.Button_Click);

                    this.Controls.Add(_buttons[i, j]);
                    ++amountOfButtons;
                    ++tabInd;
                }
            }
        }

        private void InitializeEmpty(int j, int i)
        {
            if (_buttons[i, j].Text == "16")
            {
                _buttons[i, j].Text = string.Empty;
                _buttons[i, j].BackColor = Color.AliceBlue;
            }
        }

        //public void ShowButt()
        //{
        //    for (int x = 0; x < FIELD_SIZE; x++)
        //    {
        //        for (int y = 0; y < FIELD_SIZE; y++)
        //        {
        //            ShowButton(_game.GetNumber(x, y), x, y);
        //        }
        //    }
        //}

        //private void ShowButton(int num, int x, int y)
        //{
        //    MyButton myButton = _buttons[x, y];
        //    myButton.Text = num.ToString();
        //    myButton.Visible = num > 0;
        //}

        #endregion

        private Button btnNewGame;
        private Label lblAmOfMoves;
    }
}

