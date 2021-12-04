using System.Drawing;
using System.Windows.Forms;

namespace WFArcadeGame
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
            this.components = new System.ComponentModel.Container();
            this.GameMainTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // GameMainTimer
            // 
            this.GameMainTimer.Interval = 25;
            this.GameMainTimer.Tick += new System.EventHandler(this.RunGame);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Name = "Form1";
            this.Text = "Arcade Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Add Picture Boxes to List.
        /// </summary>
        private void InitializeDynamicComponents()
        {
            _images = new PictureBox[_game.AmountOfObjects];

            for (int i = 0; i < _images.Length; i++)
            {
                _images[i] = new PictureBox()
                {
                    Visible = true,
                    Size = new Size(HALFIMAGE_SIZE, HALFIMAGE_SIZE),
                    SizeMode = PictureBoxSizeMode.Zoom,
                };

                Controls.Add(_images[i]);
            }
        }

        #endregion

        private Timer GameMainTimer;
    }
}

