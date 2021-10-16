using System;
using System.Drawing;

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
            this.lblMoves = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.test1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
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
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click_1);
            // 
            // lblMoves
            // 
            this.lblMoves.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblMoves.AutoSize = true;
            this.lblMoves.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMoves.Location = new System.Drawing.Point(335, 122);
            this.lblMoves.Name = "lblMoves";
            this.lblMoves.Size = new System.Drawing.Size(127, 15);
            this.lblMoves.TabIndex = 1;
            this.lblMoves.Text = "Number of movements:   ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.test1ToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            // 
            // test1ToolStripMenuItem
            // 
            this.test1ToolStripMenuItem.Name = "test1ToolStripMenuItem";
            this.test1ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.test1ToolStripMenuItem.Text = "Test1";
            this.test1ToolStripMenuItem.Click += new System.EventHandler(this.test1ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(484, 316);
            this.Controls.Add(this.lblMoves);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Puzzle Game";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
                        TabStop = false,
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
                _buttons[i, j].BackColor = Color.OldLace;
            }
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem test1ToolStripMenuItem;
    }
}

