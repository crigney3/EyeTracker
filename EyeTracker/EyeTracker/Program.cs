using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tobii.Interaction;

namespace EyeTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            
            bool quit = false;
            int count = 0;
            Tracking tracker = new Tracking();
            //tracker.Calibrate();
            tracker.gazePointDataStream.GazePoint((gazePointX, gazePointY, _) => tracker.ZoneTracker(gazePointX, gazePointY));

            Console.ReadLine();
               
           

            
            
            

        }
    }
}
