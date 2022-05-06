using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Math;

namespace WilliamsBestAF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IntersectingRadials : ContentPage
    {
        WilliamsBestAF.GreatCircle gc;
        public IntersectingRadials()
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
            double lat1Degs = gc.DMS_Degrees(latDeg1, latMin1, 0);
            double lng1Degs = gc.DMS_Degrees(lngDeg1, lngMin1, 0);
            double lat2Degs = gc.DMS_Degrees(latDeg2, latMin2, 0);
            double lng2Degs = gc.DMS_Degrees(lngDeg2, lngMin2, 0);
            double lat1Radians = gc.Deg_Radians(lat1Degs);
            double lng1Radians = gc.Deg_Radians(lng1Degs);
            double lat2Radians = gc.Deg_Radians(lat2Degs);
            double lng2Radians = gc.Deg_Radians(lng2Degs);
            double lat3;
            double l12;
            double A;
            double B;
            double C;
            double lon;
            double dlon;
            double lon3_1;
            double lon3_2;

            double distance = gc.GreatCircle_Calculation(lat1Degs, lng1Degs, lat2Degs, lng2Degs);

            lat3 = 36 * PI / 180;
            l12 = lng1Radians - lng2Radians;
            A = Sin(lat1Radians) * Cos(lat2Radians) * Cos(lat3) * Sin(l12);
            B = Sin(lat1Radians) * Cos(lat2Radians) * Cos(lat3) * Cos(l12) - Cos(lat1Radians) * Sin(lat2Radians) * Cos(lat3);
            C = Cos(lat1Radians) * Cos(lat2Radians) * Sin(lat3) * Sin(l12);
            lon = Atan2(B, A);

            var answer = Abs(C) > Sqrt(Pow(A, 2) + Pow(B, 2)) ? Abs(C) : Sqrt(Pow(A, 2) + Pow(B, 2));
            dlon = Acos(C / Sqrt(Pow(A, 2) + Pow(B, 2)));
            lon3_1 = (lng1Radians + dlon + lon + PI % 2 * PI) - PI;
            lon3_2 = (lng1Radians - dlon + lon + PI % 2 * PI) - PI;
            // lon3_1 lies between lon1 and lon2, but lon3_2 does not, so the 36 degree parallel is crossed once between LAX and JFK at lon3_1

            double answerInDegrees = gc.RadiansToDegrees(lon3_1);

            Results.Text = answerInDegrees.ToString() + " " + "degrees longitude";
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