using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    public partial class Form1 : Form
    {

        private Snake snake;
        private Direction? newDirection;
        private Apple apple;

        private Random r = new Random();
        public Form1()
        {
            InitializeComponent();

            this.newDirection = null;
            this.snake = new Snake(new Point(3, 3));
            this.apple = new Apple(r.Next(0, 35), r.Next(0, 30));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateTimer.Enabled = true;
        }

        private void board_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.ScaleTransform(20, 20);

            e.Graphics.SmoothingMode = SmoothingMode.None;
            e.Graphics.FillRectangle(Brushes.Red, apple.Position.X, apple.Position.Y, 1, 1);
            

            Point? lastCorner = null;
            foreach (Point c in this.snake.SnakeCorners)
            {
                if (lastCorner.HasValue)
                {
                    Point start = lastCorner.Value;
                    Point end = c;

                    Rectangle r = new Rectangle(Math.Min(start.X, end.X),
                       Math.Min(start.Y, end.Y),
                       Math.Abs(start.X - end.X)+1,
                       Math.Abs(start.Y - end.Y)+1);

                    e.Graphics.SmoothingMode = SmoothingMode.None;
                    
                    e.Graphics.FillRectangle(Brushes.White, r);
                }
                lastCorner = c;
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            bool moveTail = true;
            // Check for collions
            if (apple.IsCollided(snake.Position))
            {
                moveTail = false;
                apple.Position.X = r.Next(0, 35);
                apple.Position.Y = r.Next(0, 30);
            }

            if (snake.IsCollided(snake.Position))
            {
                Die();
            }

            if (this.newDirection != null)
            {
                snake.ChangeDirection(this.newDirection.Value);
                this.newDirection = null;
            }



            snake.Update(moveTail);

            board.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    this.newDirection = Direction.Up;
                    break;
                case Keys.Down:
                    this.newDirection = Direction.Down;
                    break;
                case Keys.Left:
                    this.newDirection = Direction.Left;
                    break;
                case Keys.Right:
                    this.newDirection = Direction.Right;
                    break;
            }
        }
        
        private void Die()
        {
            updateTimer.Enabled = false;
            MessageBox.Show("GAME OVER :(");
            snake = new Snake(new Point(3, 3));
            updateTimer.Enabled = true;
        }
    }
}
