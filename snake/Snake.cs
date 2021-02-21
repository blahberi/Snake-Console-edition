using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class Snake
    {
        public int direction;
        /*
          0 - up
          1 - down
          2 - left
          3 - right
        */
        public int[] head;
        public int[] tail;
        public Corner[] corners;
        public Snake()
        {
            this.direction = direction;
            this.head = head;
            this.tail = tail;
            this.corners = corners;
        }

        public void Update()
        {

        }
    }
}
