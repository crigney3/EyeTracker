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
            /*
             *Setup HTTP libraries 
             */
            Console.WriteLine("Welcome to the Eye Tracker test console. To calibrate for screens, type 'c'.");
            Console.WriteLine("To calibrate for any car, type 'car'.");

            //The instantiated tracker object handles everything below the surface.
            Tracking tracker = new Tracking();

            

            string input = Console.ReadLine();

            if (input == "c")
            {
                //Calibrate the tracker using the screen calibration method
                tracker.Calibrate();
            }
            else if(input == "car")
            {
                tracker.CarCalibrate();
            }
            else
            {
                //Run the tracker in uncalibrated mode
                tracker.gazePointDataStream.GazePoint((gazePointX, gazePointY, _) => tracker.UncalibratedZoneTracker(gazePointX, gazePointY));
            }

            tracker.gazePointDataStream.GazePoint((gazePointX, gazePointY, _) => tracker.ZoneTracker(gazePointX, gazePointY));

            //Without this line, the tracker doesn't collect input. 
            Console.ReadLine();
            
            

        }
    }
}
