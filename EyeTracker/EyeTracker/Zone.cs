using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeTracker
{
    class Zone
    {
        private int x;
        private int y;
        private int width;
        private int height;
        private string name;
        public int X { get { return this.x; } }
        public int Y { get { return this.y; } }
        public int Width { get { return this.width; } }
        public int Height { get { return this.height; } }
        public string Name { get { return this.name; } }

        public Zone(string name, int x, int y, int width, int height)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public Zone(string name, Point point, int width, int height)
        {
            this.name = name;
            this.x = point.X;
            this.y = point.Y;
            this.width = width;
            this.height = height;
        }
    }
}
