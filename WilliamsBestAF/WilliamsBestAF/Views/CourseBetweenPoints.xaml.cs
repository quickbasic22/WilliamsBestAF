using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WilliamsBestAF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseBetweenPoints : ContentPage
    {
        WilliamsBestAF.GreatCircle gc;
        public CourseBetweenPoints()
        {
            InitializeComponent();
            gc = new WilliamsBestAF.GreatCircle();
        }

        private void ComputeCourse_Clicked(object sender, EventArgs e)
        {
            double latDeg1 = 0.0;
            double latMin1 = 0.0;
            double lngDeg1 = 0.0;
            double lngMin1 = 0.0;
            double latDeg2 = 0.0;
            double latMin2 = 0.0;
            double lngDeg2 = 0.0;
            double lngMin2 = 0.0;

            try
            {
                latDeg1 = double.Parse(LatitudeDeg1.Text);
                latMin1 = double.Parse(LatitudeMin1.Text);
                lngDeg1 = double.Parse(LongitudeDeg1.Text);
                lngMin1 = double.Parse(LongitudeMin1.Text);
                latDeg2 = double.Parse(LatitudeDeg2.Text);
                latMin2 = double.Parse(LatitudeMin2.Text);
                lngDeg2 = double.Parse(LongitudeDeg2.Text);
                lngMin2 = double.Parse(LongitudeMin2.Text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
           
            double lat1Degs = gc.DMS_Degrees(latDeg1, latMin1, 0);
            double lng1Degs = gc.DMS_Degrees(lngDeg1, lngMin1, 0);
            double lat2Degs = gc.DMS_Degrees(latDeg2, latMin2, 0);
            double lng2Degs = gc.DMS_Degrees(lngDeg2, lngMin2, 0);
            double lat1Radians = gc.Deg_Radians(lat1Degs);
            double lng1Radians = gc.Deg_Radians(lng1Degs);
            double lat2Radians = gc.Deg_Radians(lat2Degs);
            double lng2Radians = gc.Deg_Radians(lng2Degs);


            double tc1 = 0;
            double distance = gc.GreatCircle_Calculation(lat1Degs, lng1Degs, lat2Degs, lng2Degs);

            if (Math.Cos(lat1Radians) < 0.00010)
                if (lat1Radians > 0)
                    tc1 = Math.PI;
                else
                    tc1 = 2 * Math.PI;
            else if (Math.Sin(lng2Radians - lng1Radians) < 0)
            {
                tc1 = Math.Acos((Math.Sin(lat2Radians) - Math.Sin(lat1Radians) * Math.Cos(distance)) / (Math.Sin(distance) * Math.Cos(lat1Radians)));
            }
            else
                tc1 = 2 * Math.PI - Math.Acos((Math.Sin(lat2Radians) - Math.Sin(lat1Radians) * Math.Cos(distance)) / (Math.Sin(distance) * Math.Cos(lat1Radians)));
            double CourseDegrees = Math.Round(gc.RadiansToDegrees(tc1), 0);

            Results.Text = CourseDegrees.ToString() + " " + "Degrees Initial heading";
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

        }

        private void ReverseComputeCourse_Clicked(object sender, EventArgs e)
        {

            var latdeg1 = LatitudeDeg1.Text;
            var latmin1 = LatitudeMin1.Text;
            var longdeg1 = LongitudeDeg1.Text;
            var longmin1 = LongitudeMin1.Text;

            var latdeg2 = LatitudeDeg2.Text;
            var latmin2 = LatitudeMin2.Text;
            var longdeg2 = LongitudeDeg2.Text;
            var longmin2 = LongitudeMin2.Text;

            LatitudeDeg2.Text = latdeg1;
            LatitudeMin2.Text = latmin1;
            LongitudeDeg2.Text = longdeg1;
            LongitudeMin2.Text = longmin1;

            LatitudeDeg1.Text = latdeg2;
            LatitudeMin1.Text = latmin2;
            LongitudeDeg1.Text = longdeg2;
            LongitudeMin1.Text = longmin2;
            ComputeCourse_Clicked(this, null);
        }

        private void CheckedDD_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (CheckedDD.IsChecked)
            {

                LatitudeMin1.IsVisible = false;
                LatitudeSec1.IsVisible = false;
                LatitudeMin1.Text = "0";
                LatitudeSec1.Text = "0";

                LongitudeMin1.IsVisible = false;
                LongitudeSec1.IsVisible = false;
                LongitudeMin1.Text = "0";
                LongitudeSec1.Text = "0";

                LatitudeMin2.IsVisible = false;
                LatitudeSec2.IsVisible = false;
                LatitudeMin2.Text = "0";
                LatitudeSec2.Text = "0";

                LongitudeMin2.IsVisible = false;
                LongitudeSec2.IsVisible = false;
                LongitudeMin2.Text = "0";
                LongitudeSec2.Text = "0";


            }
            else
            {

                LatitudeMin1.IsVisible = true;
                LatitudeSec1.IsVisible = true;

                LongitudeMin1.IsVisible = true;
                LongitudeSec1.IsVisible = true;

                LatitudeMin2.IsVisible = true;
                LatitudeSec2.IsVisible = true;

                LongitudeMin2.IsVisible = true;
                LongitudeSec2.IsVisible = true;
            }
        }
    }
}