using System;
using System.Collections.Generic;
using System.Text;
using WilliamsBestAF;

namespace WilliamsBestAF.Model
{
    public class Cooridates
    {
        GreatCircle gc = new GreatCircle();
        string LocationName { get; set; }
        double LatitudeRadians { get; set; }
        double LongitudeRadians { get; set; }
        double LatitudeDegrees { get; set; }
        double LatitudeDeg { get; set; }
        double LatitudeMin { get; set; }
        double LatitudeSec { get; set; }
        double LongitudeDegrees { get; set; }
        double LongitudeDeg { get; set; }
        double LongitudeMin { get; set; }
        double LongitudeSec { get; set; }

        public Cooridates()
        {

        }
        public Cooridates(string locationname, double latitudedegrees, double longitudedegrees)
        {
            this.LocationName = locationname;
            this.LatitudeDegrees = latitudedegrees;
            this.LongitudeDegrees = longitudedegrees;
            this.LatitudeDeg = latitudedegrees;
            this.LatitudeMin = 0;
            this.LatitudeSec = 0;
            this.LongitudeDeg = longitudedegrees;
            this.LongitudeMin = 0;
            this.LongitudeSec = 0;
            LatitudeRadians = gc.DegreesToRadians(latitudedegrees);
            LongitudeRadians = gc.DegreesToRadians(longitudedegrees);
            var latdms = gc.Deg_DMS(LatitudeDegrees);
            var longdms = gc.Deg_DMS(LongitudeDegrees);
            string[] latd = latdms.Split(' ', '.');
            LatitudeDeg = Convert.ToDouble(latd[0]);
            LatitudeMin = Convert.ToDouble(latd[1]);
            LatitudeSec = Convert.ToDouble(latd[2]);
        }
       
        public Cooridates(string locationname, double LatDeg, double LatMin, double LatSec, double LongDeg, double LongMin,double LongSec)
        {
            LocationName = locationname;
            LatitudeDeg = LatDeg;
            LatitudeMin = LatMin;
            LatitudeSec = LatSec;
            LongitudeDeg = LongDeg;
            LongitudeMin = LongMin;
            LongitudeSec = LongSec;
            LatitudeDegrees = gc.DMS_Degrees(LatDeg, LatMin, LatSec);
            LongitudeDegrees = gc.DMS_Degrees(LongDeg, LongMin, LongSec);
            LatitudeRadians = gc.DegreesToRadians(LatitudeDegrees);
            LongitudeRadians = gc.DegreesToRadians(LongitudeDegrees);

        }
        public Cooridates(double LatRad, double LongRad, string locationname)
        {
            this.LocationName = locationname;
            this.LatitudeRadians = LatRad;
            this.LongitudeRadians = LongRad;
            LatitudeDegrees = gc.RadiansToDegrees(LatitudeRadians);
            LongitudeDegrees = gc.RadiansToDegrees(LongitudeRadians);
            var latdms = gc.Deg_DMS(LatitudeDegrees);
            var longdms = gc.Deg_DMS(LongitudeDegrees);
            string[] latd = latdms.Split(' ', '.');
            LatitudeDeg = Convert.ToDouble(latd[0]);
            LatitudeMin = Convert.ToDouble(latd[1]);
            LatitudeSec = Convert.ToDouble(latd[2]);
        }
    }
}
