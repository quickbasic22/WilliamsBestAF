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
    public partial class CooridatesPage : ContentPage
    {
        public CooridatesPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.GreatCircleViewModel();
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

        }
    }
}