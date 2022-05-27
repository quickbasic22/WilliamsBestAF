using System;
using System.Collections.Generic;
using System.Text;

namespace WilliamsBestAF.Model
{
    public class CooridateSummary
    {
        public string DepartureName { get; set; } = "Departure Location";
        public double DepartureLatitude { get; set; } = 0.0;
        public double DepartureLongitude { get; set; } = 0.0;

        public string DestinationName { get; set; } = "Destination Location";
        public double DestinationLatitude { get; set; } = 0.0;
        public double DestinationLongitude { get; set; } = 0.0;

        public double TripCourse { get; set; } = 0.0;
        public double GreatCircleDistance { get; set; } = 0.0;
        public double ThroughGroundDistance { get; set; } = 0.0;

        public double GreatCircleThroughGroundDifference { get; set; } = 0.0;
    }
}
