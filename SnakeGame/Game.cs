using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SnakeGame
{
    public class Game
    {
        protected Snake snake;
        protected Apple apple;
        public Border border { get; protected set; }
        protected int scoreCount;

        private Direction? newDirection;

        private readonly Random r = new Random();

        public Game()
        {
            this.newDirection = null;
            this.snake = new Snake(new Point(3, 3));
            this.apple = new Apple(r.Next(0, 35), r.Next(0, 30));
            this.border = new Border();
            this.scoreCount = 0;
            this.Score = $"score: {this.scoreCount}";
        }

        public event Action<string> GameEnded;
        public event Action<Game> Clear;

        public string Score { get; private set; }

        virtual public void Draw(IPainter painter)
        {
            painter.DrawApple(apple);

            Corner lastCorner = null;
            foreach (Corner c in this.snake.SnakeCorners)
            {
                if (lastCorner != null)
                {
                    Point start = lastCorner.Position;
                    Point end = c.Position;

                    int size = Math.Abs(end.X - start.X) + Math.Abs(end.Y - start.Y);

                    painter.DrawStripe(lastCorner.Position, lastCorner.Direction, size);
                }
                lastCorner = c;
            }
        }

        public void UpdateDirection(Direction direction)
        {
            this.newDirection = direction;
        }

        virtual public void Update()
        {
            bool moveTail = true;
            // Check for collions
            if (this.apple.IsCollided(snake.Position))
            {

                moveTail = false;

                this.scoreCount++;
                this.Score = $"score: {this.scoreCount}";

                this.OnNewApple();
            }

            if (this.snake.IsCollided(snake.Position))
            {
                this.Die();
            }

            if (this.newDirection != null)
            {
                this.snake.ChangeDirection(this.newDirection.Value);
                this.newDirection = null;
            }

            if (this.border.IsCollided(snake.Position))
            {
                this.Die();
            }

            this.snake.Update(moveTail);
            
        }

        protected virtual void OnNewApple()
        {
            this.apple.Position.X = r.Next(0, 35);
            this.apple.Position.Y = r.Next(0, 30);
            while (true)
            {
                if (this.snake.IsCollided(this.apple.Position) ||
                    this.border.IsCollided(this.apple.Position))
                {
                    this.apple.Position.X = r.Next(0, 35);
                    this.apple.Position.Y = r.Next(0, 30);
                }
                else
                {
                    break;
                }
            }
        }

        private void Die()
        {
            if (this.GameEnded != null)
            {
                this.GameEnded($"GAME OVER :(\n\nYOUR SCORE IS: {this.scoreCount}");
            }
            if (this.Clear != null)
            {
                this.Clear(this);
            }

            this.snake = new Snake(new Point(3, 3));
            this.scoreCount = 0;
            this.Score = "score: 0";
        }
    }
}
