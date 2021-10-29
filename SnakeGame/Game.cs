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

        private List<Direction> newDirections;

        private readonly Random r = new Random();

        public Game()
        {
            this.newDirections = new List<Direction>();
            this.snake = new Snake(new Point(3, 3));
            this.apple = new Apple(r.Next(0, 34), r.Next(0, 29));
            this.border = new Border();
            this.scoreCount = 0;
            this.Score = $"score: {this.scoreCount}";
        }

        public event Action<string> GameEnded;
        public event Action<Game> Clear;

        public string Score { get; private set; }

        virtual public void Draw(IPainter painter, int pixelSize)
        {
            painter.DrawApple(apple, pixelSize);

            Corner lastCorner = null;
            foreach (Corner c in this.snake.SnakeCorners)
            {
                if (lastCorner != null)
                {
                    Point start = lastCorner.Position;
                    Point end = c.Position;

                    int size = Math.Abs(end.X - start.X) + Math.Abs(end.Y - start.Y);

                    painter.DrawStripe(lastCorner.Position, lastCorner.Direction, size, pixelSize);
                }
                lastCorner = c;
            }
        }

        public void UpdateDirection(Direction direction)
        {
            this.newDirections.Add(direction);
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

            if (this.newDirections.Count != 0)
            {
                this.snake.ChangeDirection(this.newDirections[0]);
                this.newDirections.RemoveAt(0);
            }

            if (this.border.IsCollided(snake.Position))
            {
                this.Die();
            }

            this.snake.Update(moveTail);
            
        }

        protected virtual void OnNewApple()
        {
            this.apple.Position.X = r.Next(0, 34);
            this.apple.Position.Y = r.Next(0, 29);
            while (true)
            {
                if (this.snake.IsCollided(this.apple.Position) ||
                    this.border.IsCollided(this.apple.Position))
                {
                    this.apple.Position.X = r.Next(0, 34);
                    this.apple.Position.Y = r.Next(0, 29);
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
