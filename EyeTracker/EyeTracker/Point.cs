﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeTracker
{
    class Point
    {
        private int x;
        private int y;
        public int X { get { return this.x; } }
        public int Y { get { return this.y; } }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
