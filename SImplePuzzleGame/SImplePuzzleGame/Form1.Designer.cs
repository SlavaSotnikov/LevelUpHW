using System.Drawing;
using System.Windows.Forms;

namespace SimplePuzzleGame
{
    partial class Form1
    {
        private Button[,] _buttons;
        public new int Size { get { return 75; } }

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
            _buttons = new Button[4, 4];

            for (int i = 0; i < _buttons.GetLength(0); i++)
            {
                for (int j = 0; j < _buttons.GetLength(1); j++)
                {
                    _buttons[i, j] = new Button();
                }
            }

            _buttons[3, 3] = null;
            this.SuspendLayout();
            // 
            // button1
            // 
            _buttons[0, 0].Location = new System.Drawing.Point(10, 10);
            _buttons[0, 0].Name = "button1";
            _buttons[0, 0].Size = new System.Drawing.Size(75, 75);
            _buttons[0, 0].TabIndex = 0;
            _buttons[0, 0].Text = "1";
            _buttons[0, 0].UseVisualStyleBackColor = true;
            _buttons[0, 0].BackColor = System.Drawing.Color.PeachPuff;
            _buttons[0, 0].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _buttons[0, 0].Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            _buttons[0, 1].Location = new System.Drawing.Point(85, 10);
            _buttons[0, 1].Name = "button2";
            _buttons[0, 1].Size = new System.Drawing.Size(75, 75);
            _buttons[0, 1].TabIndex = 1;
            _buttons[0, 1].Text = "2";
            _buttons[0, 1].UseVisualStyleBackColor = true;
            _buttons[0, 1].BackColor = System.Drawing.Color.PeachPuff;
            _buttons[0, 1].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _buttons[0, 1].Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            _buttons[0, 2].Location = new System.Drawing.Point(160, 10);
            _buttons[0, 2].Name = "button3";
            _buttons[0, 2].Size = new System.Drawing.Size(75, 75);
            _buttons[0, 2].TabIndex = 2;
            _buttons[0, 2].Text = "3";
            _buttons[0, 2].UseVisualStyleBackColor = true;
            _buttons[0, 2].BackColor = System.Drawing.Color.PeachPuff;
            _buttons[0, 2].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _buttons[0, 2].Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            _buttons[0, 3].Location = new System.Drawing.Point(235, 10);
            _buttons[0, 3].Name = "button4";
            _buttons[0, 3].Size = new System.Drawing.Size(75, 75);
            _buttons[0, 3].TabIndex = 3;
            _buttons[0, 3].Text = "4";
            _buttons[0, 3].UseVisualStyleBackColor = true;
            _buttons[0, 3].BackColor = System.Drawing.Color.PeachPuff;
            _buttons[0, 3].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _buttons[0, 3].Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            _buttons[1, 0].Location = new System.Drawing.Point(10, 85);
            _buttons[1, 0].Name = "button5";
            _buttons[1, 0].Size = new System.Drawing.Size(75, 75);
            _buttons[1, 0].TabIndex = 4;
            _buttons[1, 0].Text = "5";
            _buttons[1, 0].UseVisualStyleBackColor = true;
            _buttons[1, 0].BackColor = System.Drawing.Color.PeachPuff;
            _buttons[1, 0].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _buttons[1, 0].Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            _buttons[1, 1].Location = new System.Drawing.Point(85, 85);
            _buttons[1, 1].Name = "button6";
            _buttons[1, 1].Size = new System.Drawing.Size(75, 75);
            _buttons[1, 1].TabIndex = 5;
            _buttons[1, 1].Text = "6";
            _buttons[1, 1].UseVisualStyleBackColor = true;
            _buttons[1, 1].BackColor = System.Drawing.Color.PeachPuff;
            _buttons[1, 1].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _buttons[1, 1].Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            _buttons[1, 2].Location = new System.Drawing.Point(160, 85);
            _buttons[1, 2].Name = "button7";
            _buttons[1, 2].Size = new System.Drawing.Size(75, 75);
            _buttons[1, 2].TabIndex = 6;
            _buttons[1, 2].Text = "7";
            _buttons[1, 2].UseVisualStyleBackColor = true;
            _buttons[1, 2].BackColor = System.Drawing.Color.PeachPuff;
            _buttons[1, 2].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _buttons[1, 2].Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            _buttons[1, 3].Location = new System.Drawing.Point(235, 85);
            _buttons[1, 3].Name = "button8";
            _buttons[1, 3].Size = new System.Drawing.Size(75, 75);
            _buttons[1, 3].TabIndex = 7;
            _buttons[1, 3].Text = "8";
            _buttons[1, 3].UseVisualStyleBackColor = true;
            _buttons[1, 3].BackColor = System.Drawing.Color.PeachPuff;
            _buttons[1, 3].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _buttons[1, 3].Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            _buttons[2, 0].Location = new System.Drawing.Point(10, 160);
            _buttons[2, 0].Name = "button9";
            _buttons[2, 0].Size = new System.Drawing.Size(75, 75);
            _buttons[2, 0].TabIndex = 8;
            _buttons[2, 0].Text = "9";
            _buttons[2, 0].UseVisualStyleBackColor = true;
            _buttons[2, 0].BackColor = System.Drawing.Color.PeachPuff;
            _buttons[2, 0].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _buttons[2, 0].Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            _buttons[2, 1].Location = new System.Drawing.Point(85, 160);
            _buttons[2, 1].Name = "button10";
            _buttons[2, 1].Size = new System.Drawing.Size(75, 75);
            _buttons[2, 1].TabIndex = 9;
            _buttons[2, 1].Text = "10";
            _buttons[2, 1].UseVisualStyleBackColor = true;
            _buttons[2, 1].BackColor = System.Drawing.Color.PeachPuff;
            _buttons[2, 1].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _buttons[2, 1].Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            _buttons[2, 2].Location = new System.Drawing.Point(160, 160);
            _buttons[2, 2].Name = "button11";
            _buttons[2, 2].Size = new System.Drawing.Size(75, 75);
            _buttons[2, 2].TabIndex = 10;
            _buttons[2, 2].Text = "11";
            _buttons[2, 2].UseVisualStyleBackColor = true;
            _buttons[2, 2].BackColor = System.Drawing.Color.PeachPuff;
            _buttons[2, 2].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _buttons[2, 2].Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            _buttons[2, 3].Location = new System.Drawing.Point(235, 160);
            _buttons[2, 3].Name = "button12";
            _buttons[2, 3].Size = new System.Drawing.Size(75, 75);
            _buttons[2, 3].TabIndex = 11;
            _buttons[2, 3].Text = "12";
            _buttons[2, 3].UseVisualStyleBackColor = true;
            _buttons[2, 3].BackColor = System.Drawing.Color.PeachPuff;
            _buttons[2, 3].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _buttons[2, 3].Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            _buttons[3, 0].Location = new System.Drawing.Point(10, 235);
            _buttons[3, 0].Name = "button13";
            _buttons[3, 0].Size = new System.Drawing.Size(75, 75);
            _buttons[3, 0].TabIndex = 12;
            _buttons[3, 0].Text = "13";
            _buttons[3, 0].UseVisualStyleBackColor = true;
            _buttons[3, 0].BackColor = System.Drawing.Color.PeachPuff;
            _buttons[3, 0].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _buttons[3, 0].Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            _buttons[3, 1].Location = new System.Drawing.Point(85, 235);
            _buttons[3, 1].Name = "button14";
            _buttons[3, 1].Size = new System.Drawing.Size(75, 75);
            _buttons[3, 1].TabIndex = 13;
            _buttons[3, 1].Text = "14";
            _buttons[3, 1].UseVisualStyleBackColor = true;
            _buttons[3, 1].BackColor = System.Drawing.Color.PeachPuff;
            _buttons[3, 1].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _buttons[3, 1].Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            _buttons[3, 2].Location = new System.Drawing.Point(160, 235);
            _buttons[3, 2].Name = "button15";
            _buttons[3, 2].Size = new System.Drawing.Size(75, 75);
            _buttons[3, 2].TabIndex = 14;
            _buttons[3, 2].Text = "15";
            _buttons[3, 2].UseVisualStyleBackColor = true;
            _buttons[3, 2].BackColor = System.Drawing.Color.PeachPuff;
            _buttons[3, 2].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _buttons[3, 2].Click += new System.EventHandler(this.button15_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 320);
            this.Controls.Add(_buttons[3, 2]);
            this.Controls.Add(_buttons[3, 1]);
            this.Controls.Add(_buttons[3, 0]);
            this.Controls.Add(_buttons[2, 3]);
            this.Controls.Add(_buttons[2, 2]);
            this.Controls.Add(_buttons[2, 1]);
            this.Controls.Add(_buttons[2, 0]);
            this.Controls.Add(_buttons[1, 3]);
            this.Controls.Add(_buttons[1, 2]);
            this.Controls.Add(_buttons[1, 1]);
            this.Controls.Add(_buttons[1, 0]);
            this.Controls.Add(_buttons[0, 3]);
            this.Controls.Add(_buttons[0, 2]);
            this.Controls.Add(_buttons[0, 1]);
            this.Controls.Add(_buttons[0, 0]);
            this.Name = "Form1";
            this.Text = "Simple Puzzle Game";
            this.BackColor = System.Drawing.Color.OldLace;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion
    }
}

