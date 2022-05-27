using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamsBestAF.Model;
using WilliamsBestAF.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WilliamsBestAF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CooridatesPage : ContentPage
    {
        GreatCircle gc;
        CooridatesPageViewModel _viewModel;
        private CooridateSummary GetSummary;

        public CooridatesPage()
        {
                InitializeComponent();
                gc = new GreatCircle();
            BindingContext = _viewModel = new CooridatesPageViewModel();
           GetSummary = (CooridateSummary)Application.Current.Properties["CooridateSummaryProperty"];
        }
       
        private async void Calculate_Clicked(object sender, EventArgs e)
        {
            double latDeg1 = 0.0;
            double latMin1 = 0.0;
            double latSec1 = 0.0;
            double lngDeg1 = 0.0;
            double lngMin1 = 0.0;
            double lngSec1 = 0.0;

            double latDeg2 = 0.0;
            double latMin2 = 0.0;
            double latSec2 = 0.0;
            double lngDeg2 = 0.0;
            double lngMin2 = 0.0;
            double lngSec2 = 0.0;

            try
            {
                latDeg1 = double.Parse(LatitudeDeg1?.Text);
                latMin1 = double.Parse(LatitudeMin1?.Text);
                latSec1 = double.Parse(LatitudeSec1?.Text);
                lngDeg1 = double.Parse(LongitudeDeg1?.Text);
                lngMin1 = double.Parse(LongitudeMin1?.Text);
                lngSec1 = double.Parse(LongitudeSec1?.Text);

                latDeg2 = double.Parse(LatitudeDeg2?.Text);
                latMin2 = double.Parse(LatitudeMin2?.Text);
                latSec2 = double.Parse(LatitudeSec2?.Text);
                lngDeg2 = double.Parse(LongitudeDeg2?.Text);
                lngMin2 = double.Parse(LongitudeMin2?.Text);
                lngSec2 = double.Parse(LongitudeSec2?.Text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            
            double lat1Degs = gc.DMS_Degrees(latDeg1, latMin1, latSec1);
            double lng1Degs = gc.DMS_Degrees(lngDeg1, lngMin1, lngSec1);
            double lat2Degs = gc.DMS_Degrees(latDeg2, latMin2, latSec2);
            double lng2Degs = gc.DMS_Degrees(lngDeg2, lngMin2, lngSec2);

            double lat1Radians = gc.Deg_Radians(lat1Degs);
            double lng1Radians = gc.Deg_Radians(lng1Degs);
            double lat2Radians = gc.Deg_Radians(lat2Degs);
            double lng2Radians = gc.Deg_Radians(lng2Degs);
            double distance = gc.GreatCircle_Calculation(lat1Radians, lng1Radians, lat2Radians, lng2Radians);
            double distanceNM = gc.RadiansToNauticalMiles(distance);
            double distanceMiles = gc.NauticalMilesToMiles(distanceNM);

            GetSummary.DepartureName = LocationPicker1.Title;
            GetSummary.DepartureLatitude = lat1Radians;
            GetSummary.DepartureLongitude = lng1Radians;

            GetSummary.DestinationName = LocationPicker2.Title;
            GetSummary.DestinationLatitude = lat2Radians;
            GetSummary.DestinationLongitude = lng2Radians;

            GetSummary.GreatCircleDistance = distanceMiles;
            double courseRadians = gc.CourseBetweenPoints(distance, lat1Radians, lng1Radians, lat2Radians, lng2Radians);
            GetSummary.TripCourse = Math.Round(gc.RadiansToDegrees(courseRadians), 0);

            double throughGround = gc.GetDistantThroughEarth(lat1Radians, lng1Radians, lat2Radians, lng2Radians);
            GetSummary.ThroughGroundDistance = throughGround;
            double greatCircleMinusThroughGround = distanceMiles - throughGround;
            GetSummary.GreatCircleThroughGroundDifference = greatCircleMinusThroughGround;

            _viewModel.Latitude1 = lat1Radians;
            _viewModel.Longitude1 = lng1Radians;
            _viewModel.Latitude2 = lat2Radians;
            _viewModel.Longitude2 = lng2Radians;

            Results.Text = distanceMiles.ToString() + " " + "Miles";
             await Shell.Current.GoToAsync($"{nameof(GreatCircleDistance)}?{nameof(GreatCircleDistanceViewModel.Latitude1)}={lat1Radians}&{nameof(GreatCircleDistanceViewModel.Longitude1)}={lng1Radians}&{nameof(GreatCircleDistanceViewModel.Latitude2)}={lat2Radians}&{nameof(GreatCircleDistanceViewModel.Longitude2)}={lng2Radians}");
             //   await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}")

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
                
        private void ClearAll_Clicked(object sender, EventArgs e)
        {
            LatitudeDeg1.Text = "";
            LatitudeMin1.Text = "";
            LatitudeSec1.Text = "";
            LongitudeDeg1.Text = "";
            LongitudeMin1.Text = "";
            LongitudeSec1.Text = "";
            LatitudeDeg2.Text = "";
            LatitudeMin2.Text = "";
            LatitudeSec2.Text = "";
            LongitudeDeg2.Text = "";
            LongitudeMin2.Text = "";
            LongitudeSec2.Text = "";

            Results.Text = "";
            

        }

        private void LocationPicker1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Picker = (Picker)sender;
            var location = (LocationInfo)Picker.SelectedItem;
           
            
                LatitudeDeg1.Text = location.Latitude.ToString();
                LongitudeDeg1.Text = location.Longitude.ToString();
            
           
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
            Calculate_Clicked(this, null);
        }

        private void LocationPicker2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Picker = (Picker)sender;
            var location = (LocationInfo)Picker.SelectedItem;

            
                LatitudeDeg2.Text = location.Latitude.ToString();
                LongitudeDeg2.Text = location.Longitude.ToString();
            
        }
    }
}