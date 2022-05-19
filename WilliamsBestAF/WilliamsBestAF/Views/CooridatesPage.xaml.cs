using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamsBestAF.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WilliamsBestAF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CooridatesPage : ContentPage
    {
        GreatCircle gc;
        public CooridatesPage()
        {
            InitializeComponent();
            gc = new GreatCircle();
        }

       
        private void LocationPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var location = (Model.LocationInfo)picker.SelectedItem;

            if (LatitudeDeg1.Text == "")
            {
                LatitudeDeg1.Text = location.Latitude.ToString();
                LongitudeDeg1 .Text = location.Longitude.ToString();
                Location1.Text = location.Name;
            }
            else
            {
                LatitudeDeg2.Text = location.Latitude.ToString();
                LongitudeDeg2.Text = location.Longitude.ToString();
                Location2.Text = location.Name;
            }

            Debug.WriteLine(location.Name);
            Debug.WriteLine(LocationPicker.SelectedIndex);
        }

        private void Calculate_Clicked(object sender, EventArgs e)
        {
            string location1 = Location1.Text;
            double latDeg1 = double.Parse(LatitudeDeg1.Text);
            double latMin1 = double.Parse(LatitudeMin1.Text);
            double latSec1 = double.Parse(LatitudeSec1.Text);
            double lngDeg1 = double.Parse(LongitudeDeg1.Text);
            double lngMin1 = double.Parse(LongitudeMin1.Text);
            double lngSec1 = double.Parse(LongitudeSec1.Text);
            string location2 = Location2.Text;
            double latDeg2 = double.Parse(LatitudeDeg2.Text);
            double latMin2 = double.Parse(LatitudeMin2.Text);
            double latSec2 = double.Parse(LatitudeSec2.Text);
            double lngDeg2 = double.Parse(LongitudeDeg2.Text);
            double lngMin2 = double.Parse(LongitudeMin2.Text);
            double lngSec2 = double.Parse(LongitudeSec2.Text);
            double lat1Degs = gc.DMS_Degrees(latDeg1, latMin1, latSec1);
            double lng1Degs = gc.DMS_Degrees(lngDeg1, lngMin1, lngSec1);
            double lat2Degs = gc.DMS_Degrees(latDeg2, latMin2, latSec2);
            double lng2Degs = gc.DMS_Degrees(lngDeg2, lngMin2, lngSec2);

            double lat1Radians = gc.Deg_Radians(lat1Degs);
            double lng1Radians = gc.Deg_Radians(lng1Degs);
            double lat2Radians = gc.Deg_Radians(lat2Degs);
            double lng2Radians = gc.Deg_Radians(lng2Degs);
            double distance = gc.GreatCircle_Calculation(lat1Degs, lng1Degs, lat2Degs, lng2Degs);


            Shell.Current.GoToAsync($"{nameof(AppSelectorPage)}?{nameof(ViewModels.AppSelectorPageViewModel.lat1)}={lat1Radians}&{nameof(ViewModels.AppSelectorPageViewModel.lng1)}={lng1Radians})&{nameof(ViewModels.AppSelectorPageViewModel.lat2)}={lat2Radians}&{nameof(ViewModels.AppSelectorPageViewModel.lng2)}={lng2Radians}");
             //   await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");

        }

        private void CheckedDD_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (CheckedDD.IsChecked)
            {

                LatitudeMin1.IsVisible = false;
                LatitudeSec1.IsVisible = false;
                
                LongitudeMin1.IsVisible = false;
                LongitudeSec1.IsVisible = false;
                
                LatitudeMin2.IsVisible = false;
                LatitudeSec2.IsVisible = false;
               
                LongitudeMin2.IsVisible = false;
                LongitudeSec2.IsVisible = false;

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
            Location1.Text = "";
            LatitudeDeg1.Text = "";
            LatitudeMin1.Text = "";
            LatitudeSec1.Text = "";
            Location2.Text = "";
            LatitudeDeg2.Text = "";
            LatitudeMin2.Text = "";
            LatitudeSec2.Text = "";

            Results.Text = "";

        }
    }
}