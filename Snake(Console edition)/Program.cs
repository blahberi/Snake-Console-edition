using System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Snake_Console_edition_
{
    class Program
    {

        private static void DrawScreen()
        {
            //Console.Clear();
            Console.SetCursorPosition(_left, _top);
            Console.Write('*');
        }
    }
}
