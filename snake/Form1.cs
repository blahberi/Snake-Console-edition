using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    public partial class Form1 : Form
    {

        private readonly Snake snake;
        private Direction? direction;

        public Form1()
        {
            InitializeComponent();

            this.direction = direction;
            this.snake = new Snake(new Point(3, 3));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateTimer.Enabled = true;
        }

        private void board_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.ScaleTransform(10, 10);
            Point? lastCorner = null;
            foreach (Point c in this.snake.SnakeCorners)
            {
                if (lastCorner.HasValue)
                {
                    e.Graphics.DrawLine(Pens.White, lastCorner.Value, c);
                }
                lastCorner = c;
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (this.direction != null)
            {
                snake.ChangeDirection(this.direction.Value);
                this.direction = null;
            }
            snake.Update();
            board.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    this.direction = Direction.Up;
                    break;
                case Keys.Down:
                    this.direction = Direction.Down;
                    break;
                case Keys.Left:
                    this.direction = Direction.Left;
                    break;
                case Keys.Right:
                    this.direction = Direction.Right;
                    break;
            }
        }
    }
}
