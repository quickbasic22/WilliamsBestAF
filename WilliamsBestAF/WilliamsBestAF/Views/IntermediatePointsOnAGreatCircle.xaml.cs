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
    public partial class IntermediatePointsOnAGreatCircle : ContentPage
    {
        WilliamsBestAF.GreatCircle gc;
        public IntermediatePointsOnAGreatCircle()
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
            double f = double.Parse(FactionOfDistance.Text);
            double lat1Degs = gc.DMS_Degrees(latDeg1, latMin1, 0);
            double lng1Degs = gc.DMS_Degrees(lngDeg1, lngMin1, 0);
            double lat2Degs = gc.DMS_Degrees(latDeg2, latMin2, 0);
            double lng2Degs = gc.DMS_Degrees(lngDeg2, lngMin2, 0);

            double lat1Radians = gc.Deg_Radians(lat1Degs);
            double lng1Radians = gc.Deg_Radians(lng1Degs);
            double lat2Radians = gc.Deg_Radians(lat2Degs);
            double lng2Radians = gc.Deg_Radians(lng2Degs);
            double d = gc.GreatCircle_Calculation(lat1Radians, lng1Radians, lat2Radians, lng2Radians);

            double A = Math.Sin((1 - f) * d) / Math.Sin(d);
            double B = Math.Sin(f * d) / Math.Sin(d);
            double x = A * Math.Cos(lat1Radians) * Math.Cos(lng1Radians) + B * Math.Cos(lat2Radians) * Math.Cos(lng2Radians);
            double y = A * Math.Cos(lat1Radians) * Math.Sin(lng1Radians) + B * Math.Cos(lat2Radians) * Math.Sin(lng2Radians);
            double z = A * Math.Sin(lat1Radians) + B * Math.Sin(lat2Radians);
            double lat = Math.Atan2(z, Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)));
            double lon = Math.Atan2(y, x);
            double latDD = gc.RadiansToDegrees(lat);
            double lonDD = gc.RadiansToDegrees(lon);
            string latDMS = gc.Deg_DMS(latDD);
            string lonDMS = gc.Deg_DMS(lonDD);

            Results.Text = latDMS + " " + "Latitude" + " " + lonDMS + " " + "Longitude";  
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
            FactionOfDistance.Text = "";
            Location1.Text = "";
            Location2.Text = "";

        }
    }
}