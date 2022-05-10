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
    public partial class ClairautsFormula : ContentPage
    {
        WilliamsBestAF.GreatCircle gc;

        public ClairautsFormula()
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
            double latDeg3 = double.Parse(DLatitudeDeg1.Text);
            double latMin3 = double.Parse(DLatitudeMin1.Text);
            double lngDeg3 = double.Parse(DLongitudeDeg1.Text);
            double lngMin3 = double.Parse(DLongitudeMin1.Text);
            double lat1Degs = gc.DMS_Degrees(latDeg1, latMin1, 0);
            double lng1Degs = gc.DMS_Degrees(lngDeg1, lngMin1, 0);
            double lat2Degs = gc.DMS_Degrees(latDeg2, latMin2, 0);
            double lng2Degs = gc.DMS_Degrees(lngDeg2, lngMin2, 0);
            double lat3Degs = gc.DMS_Degrees(latDeg3, latMin3, 0);
            double lng3Degs = gc.DMS_Degrees(lngDeg3, lngMin3, 0);

            double lat1Radians = gc.Deg_Radians(lat1Degs);
            double lng1Radians = gc.Deg_Radians(lng1Degs);
            double lat2Radians = gc.Deg_Radians(lat2Degs);
            double lng2Radians = gc.Deg_Radians(lng2Degs);
            double tc = 0;
            double lat = 0;
            double tc1 = 0;
            double tc2 = 0;
            double latmx = Math.Acos(Math.Abs(Math.Sin(tc) * Math.Cos(lat)));
            bool EqualParts = Math.Sin(tc1) * Math.Cos(lat1Radians) == Math.Sin(tc2) * Math.Cos(lat2Radians);


            double distance = gc.GreatCircle_Calculation(lat1Degs, lng1Degs, lat3Degs, lng3Degs);
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
        }
    }
}