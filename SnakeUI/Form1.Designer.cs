﻿namespace snake
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
            this.board = new System.Windows.Forms.Panel();
            this.score = new System.Windows.Forms.Label();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.board.SuspendLayout();
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.BackColor = System.Drawing.Color.Black;
            this.board.Controls.Add(this.score);
            this.board.Location = new System.Drawing.Point(0, 0);
            this.board.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(735, 735);
            this.board.TabIndex = 0;
            this.board.Paint += new System.Windows.Forms.PaintEventHandler(this.board_Paint);
            // 
            // score
            // 
            this.score.BackColor = System.Drawing.Color.Transparent;
            this.score.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.score.ForeColor = System.Drawing.Color.White;
            this.score.Location = new System.Drawing.Point(50, 50);
            this.score.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(192, 38);
            this.score.TabIndex = 0;
            this.score.Text = "score: 0";
            this.score.Click += new System.EventHandler(this.score_Click);
            // 
            // updateTimer
            // 
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 735);
            this.Controls.Add(this.board);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "snake";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.board.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel board;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Label score;
    }
}

