using SnakeGame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Snake_Console_edition_
{
    class ConsoleSnakeGame : Game
    {
        public override void Draw(IPainter painter, int pixelSize=0) //pixelSize has no meaning, it has to be there because its an overide for a class that is also used by the ui version
        {
            base.Draw(painter, pixelSize);
        }

        protected override void OnNewApple()
        {
            Erase(this.apple.Position);
            base.OnNewApple();
        }
        public override void Update()
        {
            Erase(this.snake.Tail.Position);
            base.Update();
        }

        private static void Erase(Point position)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(" ");
        }
    }
}
