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
        public Dictionary<string, Zone> zoneList;
        Host host = new Host();
        public GazePointDataStream gazePointDataStream;

        /// <summary>
        /// Initialize the tracker with a new GazePointStream, which must be initialized for the tracker to collect data
        /// </summary>
        public Tracking()
        {
            this.gazePointDataStream = this.host.Streams.CreateGazePointDataStream();
            this.zoneList = new Dictionary<string, Zone>();
        }

        public void ZoneTracker(double x, double y)
        {
            foreach(KeyValuePair<string, Zone> zone in this.zoneList)
            {
                if ((x >= zone.Value.X && x <= zone.Value.Width) && (y >= zone.Value.Y && y <= zone.Value.Height))
                {
                    Console.WriteLine($"Eyes looking at Zone {zone.Value.Name}");
                    return;
                }
            }
        }

        public void UncalibratedZoneTracker(double x, double y)
        {
            Console.WriteLine("Eyes currently looking at Point {" + x + ", " + y + "}");
        }

        public void NewZone(string name, int x, int y, int width, int height)
        {
            if (!zoneList.ContainsKey(name))
            {
                Zone newZone = new Zone(name, x, y, width, height);
                zoneList.Add(name, newZone);
                Console.WriteLine($"New Zone {name} added at {x}, {y} with a width {width} and a height of {height}");
            }
            
            
        }

        public void Calibrate()
        {
            zoneList.Clear();
            Console.WriteLine("Please look at the center of your screen.");
            System.Threading.Thread.Sleep(5000);
            this.gazePointDataStream.GazePoint((gazePointX, gazePointY, _) => NewZone("center", (int)gazePointX - 200, (int)gazePointY - 200, 400, 400));
            Console.WriteLine();

            Console.WriteLine("Please look at the top of your screen.");
            System.Threading.Thread.Sleep(5000);
            this.gazePointDataStream.GazePoint((gazePointX, gazePointY, _) => NewZone("top", (int)gazePointX - 200, (int)gazePointY - 200, 400, 200));
            Console.WriteLine();

            Console.WriteLine("Please look at the left of your screen.");
            System.Threading.Thread.Sleep(5000);
            this.gazePointDataStream.GazePoint((gazePointX, gazePointY, _) => NewZone("left", (int)gazePointX - 200, (int)gazePointY - 200, 200, 400));
            Console.WriteLine();

            Console.WriteLine("Please look at the bottom of your screen.");
            System.Threading.Thread.Sleep(5000);
            this.gazePointDataStream.GazePoint((gazePointX, gazePointY, _) => NewZone("bottom", (int)gazePointX - 200, (int)gazePointY - 200, 400, 200));
            Console.WriteLine();

            Console.WriteLine("Please look at the right of your screen.");
            System.Threading.Thread.Sleep(5000);
            this.gazePointDataStream.GazePoint((gazePointX, gazePointY, _) => NewZone("right", (int)gazePointX - 200, (int)gazePointY - 200, 200, 400));
            Console.WriteLine();

            Console.WriteLine("Calibration for screens completed.");
            Console.WriteLine();
        }

        public void CarCalibrate()
        {
            zoneList.Clear();
            Console.WriteLine("Please look at the center of the steering wheel.");
            System.Threading.Thread.Sleep(1500);
            this.gazePointDataStream.GazePoint((gazePointX, gazePointY, _) => NewZone("Wheel", (int)gazePointX - 300, (int)gazePointY - 300, 600, 600));
            Console.WriteLine();

            Console.WriteLine("Please look at the center of the windshield.");
            System.Threading.Thread.Sleep(1500);
            this.gazePointDataStream.GazePoint((gazePointX, gazePointY, _) => NewZone("Windshield", (int)gazePointX - 400, (int)gazePointY - 800, 800, 1600));

            Console.WriteLine();

            Console.WriteLine("Calibration for Car completed.");
            Console.WriteLine();
        }
    }
}
