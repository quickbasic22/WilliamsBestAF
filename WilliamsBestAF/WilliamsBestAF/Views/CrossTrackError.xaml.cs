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
    public partial class CrossTrackError : ContentPage
    {
        WilliamsBestAF.GreatCircle gc;
        public CrossTrackError()
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
            double XTD = 0;
            // string[] dist_ADString = await gc.Get_Cooridates(this, null);

            //string thisLatString = dist_ADString[0];
            //string thisLngString = dist_ADString[1];

            //double thisLat = double.Parse(thisLatString);
            //double thisLng = double.Parse(thisLngString);
                       
            double dist_AD = gc.GreatCircle_Calculation(lat1Degs, lng1Degs, lat3Degs, lng3Degs);
            double dist_AB = gc.GreatCircle_Calculation(lat1Degs, lng1Degs, lat2Degs, lng2Degs);
            double crs_AD = gc.CourseBetweenPoints(dist_AD, lat1Degs, lng1Degs, lat3Degs, lng3Degs);
            double crs_AB = gc.CourseBetweenPoints(dist_AB, lat1Degs, lng1Degs, lat2Degs, lng2Degs);
            

            XTD = Math.Asin(Math.Sin(dist_AD) * Math.Sin(crs_AD - crs_AB));
            // positive XTD means right of course, negative means left
            // If the point A is the N. or S. Pole replace crs_AD-crs_AB with lon_D-lon_B or lon_B-lon_D respectively

            // The "along track distance", ATD, the distance from A along the course towards B to the point abeam D is given by:
            double ATD = Math.Acos(Math.Cos(dist_AD) / Math.Cos(XTD));

            // For very short distances:
            double ATD2 = Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(Math.Pow(dist_AD, 2)), 2) - Math.Pow(Math.Sin(XTD), 2) / Math.Cos(XTD)));
            string directionFromCourse = "";
            if (ATD > 0)
            {
                directionFromCourse = "Nautical Miles right of course";
            }
            else if (ATD < 0)
            {
                directionFromCourse = "Nautical Miles left of course";
            }
            else
            {
                directionFromCourse = "On Course";
            }

            double NauticalMileResult = gc.RadiansToNauticalMiles(XTD);
            double AlongTrackDistance = gc.RadiansToNauticalMiles(ATD);
            ResultsAlongCourse.Text = AlongTrackDistance.ToString() + " " + "Nautical Miles Along course";
            Results.Text = NauticalMileResult.ToString() + " " + directionFromCourse;
            
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
            ResultsAlongCourse.Text = "";
            DLatitudeDeg1.Text = "";
            DLatitudeMin1.Text = "";
            DLongitudeDeg1.Text = "";
            DLongitudeMin1.Text = "";
            Location1.Text = "";
            Location2.Text = "";
            Location3.Text = "";

        }
    }
}