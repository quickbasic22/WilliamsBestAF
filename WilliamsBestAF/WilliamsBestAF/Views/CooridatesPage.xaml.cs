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
        private CooridateSummary GetSummary { get; set; }

        public CooridatesPage()
        {
                InitializeComponent();
                gc = new GreatCircle();
           GetSummary = (CooridateSummary)Application.Current.Properties["CooridateSummaryProperty"];
            BindingContext = _viewModel = new CooridatesPageViewModel();

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
            LocationPicker1.SelectedIndex = 0;
            LocationPicker2.SelectedIndex = 0;
            
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