using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WilliamsBestAF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LatitudeLongitudeGiveRadialAndDistance : ContentPage
    {
        WilliamsBestAF.GreatCircle gc;
        public LatitudeLongitudeGiveRadialAndDistance()
        {
            InitializeComponent();
            gc = new WilliamsBestAF.GreatCircle();
        }

        private void ComputeCourse_Clicked(object sender, EventArgs e)
        {
            double latDeg1 = double.Parse(LatitudeDeg1.Text);
            double latMin1 = double.Parse(LatitudeMin1.Text);
            double lngDeg1 = double.Parse(LongitudeDeg1.Text);
            double lngMin1 = double.Parse(LongitudeMin1.Text);
            double latDeg2 = double.Parse(LatitudeDeg2.Text);
            double latMin2 = double.Parse(LatitudeMin2.Text);
            double lngDeg2 = double.Parse(LongitudeDeg2.Text);
            double lngMin2 = double.Parse(LongitudeMin2.Text);
            double distance = double.Parse(Distance.Text);
            double truecourse = double.Parse(TrueCourse.Text);
            double lat1Degs = gc.DMS_Degrees(latDeg1, latMin1, 0);
            double lng1Degs = gc.DMS_Degrees(lngDeg1, lngMin1, 0);
            double lat2Degs = gc.DMS_Degrees(latDeg2, latMin2, 0);
            double lng2Degs = gc.DMS_Degrees(lngDeg2, lngMin2, 0);
            double lat1Radians = gc.Deg_Radians(lat1Degs);
            double lng1Radians = gc.Deg_Radians(lng1Degs);
            double lat2Radians = gc.Deg_Radians(lat2Degs);
            double lng2Radians = gc.Deg_Radians(lng2Degs);
            double lat;
            double lng;
            double dlon;
            
            // distances 1/4 around globe

            lat = Math.Asin(Math.Sin(lat1Radians) * Math.Cos(distance) + Math.Cos(lat1Radians) * Math.Sin(distance) * Math.Cos(truecourse));

            if (Math.Cos(lat) == 0)
                lng = lng1Radians;
            else
                lng = (lng1Radians - Math.Asin(Math.Sin(truecourse) * Math.Sin(distance) / Math.Cos(lat1Radians)) + Math.PI % 2 * Math.PI) - Math.PI;

            // distances greater use this
            lat = Math.Asin(Math.Sin(lat1Radians) * Math.Cos(distance) + Math.Cos(lat1Radians) * Math.Sin(distance) * Math.Cos(truecourse));
            dlon = Math.Atan2(Math.Sin(truecourse) * Math.Sin(distance) * Math.Cos(lat1Radians), Math.Cos(distance) - Math.Sin(lat1Radians) * Math.Sin(lat1Radians));
            lng = (lng1Radians - dlon + Math.PI % 2 * Math.PI) - Math.PI;

            Results.Text = lat.ToString() + " " + "Latitude";
            Results2.Text = lng.ToString() + " " + "Longitude";
            
        }

        private void ClearAll_Clicked(object sender, EventArgs e)
        {
            LatitudeDeg1.Text = "";
            LatitudeMin1.Text = "";
            LongitudeDeg1.Text = "";
            LongitudeMin1.Text = "";
            LatitudeDeg2.Text = "";
            LatitudeMin2.Text = "";
            LongitudeDeg2.Text = "";
            LongitudeMin2.Text = "";
            Results.Text = "";
            Distance.Text = "";
            TrueCourse.Text = "";
        }
    }
}