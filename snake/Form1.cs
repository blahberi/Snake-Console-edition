﻿using SnakeForWindows;
using SnakeGame;
using System;
using System.Windows.Forms;
namespace snake
{
    public partial class Form1 : Form
    {
        private readonly Game game;
        private WindowsBorder windowsBorder;

        public Form1()
        {
            InitializeComponent();
            this.game = new Game();
            this.game.GameEnded += this.Die;
            this.windowsBorder = new WindowsBorder();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateTimer.Enabled = true;
        }

        private void board_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.ScaleTransform(20, 20);

            IPainter painter = new WindowsPainter(e.Graphics);
            this.game.Draw(painter);
            this.windowsBorder.DrawBorder(this.game.border, e.Graphics);
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            this.game.Update();
            score.Text = this.game.Score;
            board.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    this.game.UpdateDirection(Direction.Up);
                    break;
                case Keys.Down:
                    this.game.UpdateDirection(Direction.Down);
                    break;
                case Keys.Left:
                    this.game.UpdateDirection(Direction.Left);
                    break;
                case Keys.Right:
                    this.game.UpdateDirection(Direction.Right);
                    break;
            }
        }

        private void Die(string msg)
        {
            updateTimer.Enabled = false;
            MessageBox.Show(msg);
            updateTimer.Enabled = true;
        }

        private void score_Click(object sender, EventArgs e)
        {

        }
    }
}
