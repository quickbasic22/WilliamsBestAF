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
    public partial class CrossingParallels : ContentPage
    {
        WilliamsBestAF.GreatCircle gc;
        public CrossingParallels()
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
            double latDeg3 = double.Parse(LatitudeDeg3.Text);
            double latMin3 = double.Parse(LatitudeMin3.Text);
            double lngDeg3 = double.Parse(LongitudeDeg3.Text);
            double lngMin3 = double.Parse(LongitudeMin3.Text);
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
            double lat3Radians = gc.Deg_Radians(lat3Degs);
            double lng3Radians = gc.Deg_Radians(lng3Degs);
            string stringResult = "";
            double dlon = 0;
            double lon3_1 = 0;
            double lon3_2 = 0;
            double distance = gc.GreatCircle_Calculation(lat1Degs, lng1Degs, lat2Degs, lng2Degs);

            double l12 = lng1Radians - lng2Radians;
            double A = Math.Sin(lat1Radians) * Math.Cos(lat2Radians) * Math.Cos(lat3Radians) * Math.Sin(l12);
            double B = Math.Sin(lat1Radians) * Math.Cos(lat2Radians) * Math.Cos(lat3Radians) * Math.Cos(l12) - Math.Cos(lat1Radians) * Math.Sin(lat2Radians) * Math.Cos(lat3Radians);
            double C = Math.Cos(lat1Radians) * Math.Cos(lat2Radians) * Math.Sin(lat3Radians) * Math.Sin(l12);
            double lon = Math.Atan2(B, A);      // (atan2(y, x) convention)
            if (Math.Abs(C) > Math.Sqrt(Math.Pow(A, 2) + Math.Pow(B, 2)))
            {
               stringResult = "no crossing";
            }
                
            else
            {
                dlon = Math.Acos(C / Math.Sqrt(Math.Pow(A, 2) + Math.Pow(B, 2)));
                lon3_1 = (lng1Radians + dlon + lon + Math.PI % 2 * Math.PI) - Math.PI;
                lon3_2 = (lng1Radians - dlon + lon + Math.PI % 2 * Math.PI) - Math.PI;
            }

            string strResult = !String.IsNullOrEmpty(stringResult) ? stringResult : string.Empty;



            Results.Text = dlon.ToString() + " " + lon3_1.ToString() + " " + lon3_2.ToString() + "" + strResult;
             
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
            LatitudeDeg3.Text = "";
            LatitudeMin3.Text = "";
            LongitudeDeg3.Text = "";
            LongitudeMin3.Text = "";
            Results.Text = "";
            Location1.Text = "";
            Location2.Text = "";
            Location3.Text = "";
        }
    }
}