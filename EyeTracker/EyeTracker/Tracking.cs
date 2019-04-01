using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tobii.Interaction;

namespace EyeTracker
{
    class Tracking
    {
        public List<Zone> zoneList;
        public double xLoc;
        public double yLoc;
        public bool zoneReturn;
        Host host = new Host();
        public GazePointDataStream gazePointDataStream;

        public Tracking()
        {
            this.gazePointDataStream = this.host.Streams.CreateGazePointDataStream();
            this.zoneReturn = false;
            this.zoneList = new List<Zone>();
        }

        /*
        public double EyeX()
        {
            var gazePointDataStream = host.Streams.CreateGazePointDataStream();
            double x = 0;
            gazePointDataStream.GazePoint((gazePointX, gazePointY, _) => x = gazePointX);
            this.xLoc = x;
            return x;
        }

        public double EyeY()
        {
            
            var gazePointDataStream = host.Streams.CreateGazePointDataStream();
            double y = 0;
            gazePointDataStream.GazePoint((gazePointX, gazePointY, _) => y = gazePointY);
            this.yLoc = y;
            return y;
        }
        */

        public bool InZone(Zone zone)
        {

            this.gazePointDataStream.GazePoint((gazePointX, gazePointY, _) => ZoneTracker(gazePointX, gazePointY));
            return this.zoneReturn;
        }

        public void ZoneTracker(double x, double y)
        {
            foreach(Zone zone in this.zoneList)
            {
                if ((x >= zone.X && x <= zone.Width) && (y >= zone.Y && y <= zone.Height))
                {
                    Console.WriteLine($"Eyes looking at Zone {zone.Name}");
                    this.zoneReturn = true;
                }
            }
            
        }

        public void NewZone(string name, int x, int y, int width, int height)
        {
            Zone newZone = new Zone(name, x, y, width, height);
            zoneList.Add(newZone);
        }

        public void Calibrate()
        {
            Console.WriteLine("Please look at the center of your screen.");
            for(int i = 0; i < 100; i++)
            {
                //Wait
            }
            var gazePointDataStream = host.Streams.CreateGazePointDataStream();
            //gazePointDataStream.GazePoint((gazePointX, gazePointY, _) => NewZone("center", (int)gazePointX - 200, (int)gazePointY - 200, 400, 400));
            Console.WriteLine();

            Console.WriteLine("Please look at the top of your screen.");
            for (int i = 0; i < 100; i++)
            {
                //Wait
            }
            //gazePointDataStream.GazePoint((gazePointX, gazePointY, _) => NewZone("top", (int)gazePointX - 200, (int)gazePointY - 200, 400, 400));
            Console.WriteLine();

        }
    }
}
