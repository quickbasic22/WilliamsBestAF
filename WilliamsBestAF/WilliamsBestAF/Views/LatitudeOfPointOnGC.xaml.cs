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
    public partial class LatitudeOfPointOnGC : ContentPage
    {
        WilliamsBestAF.GreatCircle gc;
        public LatitudeOfPointOnGC()
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
            double lngDeg3 = double.Parse(IntermediateLngDeg.Text);
            double lngMin3 = double.Parse(IntermediateLngMin.Text);
            double lat1Degs = gc.DMS_Degrees(latDeg1, latMin1, 0);
            double lng1Degs = gc.DMS_Degrees(lngDeg1, lngMin1, 0);
            double lat2Degs = gc.DMS_Degrees(latDeg2, latMin2, 0);
            double lng2Degs = gc.DMS_Degrees(lngDeg2, lngMin2, 0);
            double lng3Degs = gc.DMS_Degrees(lngDeg3, lngMin3, 0);
            double lat1Radians = gc.Deg_Radians(lat1Degs);
            double lng1Radians = gc.Deg_Radians(lng1Degs);
            double lat2Radians = gc.Deg_Radians(lat2Degs);
            double lng2Radians = gc.Deg_Radians(lng2Degs);
            double lng3Radians = gc.Deg_Radians(lng3Degs);
            double lat = 0;

            if (Math.Sin(lng1Radians - lng2Radians) != 0)
            {
                lat = Math.Atan((Math.Sin(lat1Radians) * Math.Cos(lat2Radians) * Math.Sin(lng3Radians - lng2Radians) - Math.Sin(lat2Radians) * Math.Cos(lat1Radians) * Math.Sin(lng3Radians - lng1Radians)) / (Math.Cos(lat1Radians) * Math.Cos(lat2Radians) * Math.Sin(lng1Radians - lng2Radians)));
            }
            else
                lat = 0;

            double resultInDegrees = gc.RadiansToDegrees(lat);
            string resultDegreesMin = gc.Deg_DMS(resultInDegrees);

            Results.Text = resultDegreesMin.ToString() + " " + "Latitude";    
            Results2.Text = lngDeg3.ToString() + " " + lngMin3.ToString() + " 0" + " Longitude";

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
            IntermediateLngDeg.Text = "";
            IntermediateLngMin.Text = "";
        }
    }
}