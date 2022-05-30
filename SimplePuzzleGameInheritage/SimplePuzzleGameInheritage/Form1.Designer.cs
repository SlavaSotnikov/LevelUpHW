using System;
using System.Drawing;

namespace SimplePuzzleGameInheritage
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
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(544, 313);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.ResumeLayout(false);

        }

        private void InitializeDynamicComponents()
        {
            _buttons = new MyButton[4, 4];

            int amountOfButtons = 0;

            int tabInd = 1;

            for (int i = 0; i < _buttons.GetLength(0); i++)
            {
                for (int j = 0; j < _buttons.GetLength(1); j++)
                {
                    int x = i * SIZE + GAP;
                    int y = j * SIZE + GAP;

                    _buttons[i, j] = new MyButton()
                    {
                        I = i,
                        J = j,
                        Location = new Point(x, y),
                        Name = string.Format("button{0}", tabInd),
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
                    ++tabInd;
                }
            }
        }

        #endregion
    }
}

