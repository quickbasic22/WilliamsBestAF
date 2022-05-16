using System;
using System.Collections.Generic;
using System.Text;

namespace WilliamsBestAF.Model
{
    public class LocationInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public override string ToString()
        {
            return this.Name + " " + Latitude + " " + Longitude;
        }

    }
}
