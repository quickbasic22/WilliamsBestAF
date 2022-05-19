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
    public partial class LatitudeLongitudeGivenRadialAndDistance : ContentPage
    {
        WilliamsBestAF.GreatCircle gc;
        public LatitudeLongitudeGivenRadialAndDistance()
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
            double distancetxt = double.Parse(Distance.Text);
            double distance = gc.NauticalMilesToRadians(distancetxt);
            double truecoursetxt = double.Parse(TrueCourse.Text);
            double lat1Degs = gc.DMS_Degrees(latDeg1, latMin1, 0);
            double lng1Degs = gc.DMS_Degrees(lngDeg1, lngMin1, 0);
            double lat2Degs = gc.DMS_Degrees(latDeg2, latMin2, 0);
            double lng2Degs = gc.DMS_Degrees(lngDeg2, lngMin2, 0);
            double lat1Radians = gc.Deg_Radians(lat1Degs);
            double lng1Radians = gc.Deg_Radians(lng1Degs);
            double lat2Radians = gc.Deg_Radians(lat2Degs);
            double lng2Radians = gc.Deg_Radians(lng2Degs);
            double truecourse = gc.Deg_Radians(truecoursetxt);
            double lat;
            double lng;
            double lat2;
            double lng2;
            double dlon;
            
            // distances 1/4 around globe

            lat = Math.Asin(Math.Sin(lat1Radians) * Math.Cos(distance) + Math.Cos(lat1Radians) * Math.Sin(distance) * Math.Cos(truecourse));

            if (Math.Cos(lat) == 0)
                lng = lng1Radians;
            else
                lng = (lng1Radians - Math.Asin(Math.Sin(truecourse) * Math.Sin(distance) / Math.Cos(lat)) + Math.PI % (2 * Math.PI)) - Math.PI;

            // distances greater use this
            lat2 = Math.Asin(Math.Sin(lat1Radians) * Math.Cos(distance) + Math.Cos(lat1Radians) * Math.Sin(distance) * Math.Cos(truecourse));
            dlon = Math.Atan2(Math.Sin(truecourse) * Math.Sin(distance) * Math.Cos(lat1Radians), Math.Cos(distance) - Math.Sin(lat1Radians) * Math.Sin(lat));
            lng2 = (lng1Radians - dlon + Math.PI % 2 * Math.PI) - Math.PI;
            double latAnswerDeg = gc.RadiansToDegrees(lat);
            double lngAnswerDeg = gc.RadiansToDegrees(lng);

            string latitudeDeg = gc.Deg_DMS(latAnswerDeg);
            string longitudeDeg = gc.Deg_DMS(lngAnswerDeg);
            Results.Text = latitudeDeg + " " + "Latitude";
            Results2.Text = longitudeDeg + " " + "Longitude";
            
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
            Results2.Text = "";
            Distance.Text = "";
            TrueCourse.Text = "";
        }
    }
}