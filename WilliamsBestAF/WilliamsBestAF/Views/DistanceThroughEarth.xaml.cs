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
    public partial class DistanceThroughEarth : ContentPage
    {
        WilliamsBestAF.GreatCircle gc;
        public DistanceThroughEarth()
        {
            InitializeComponent();
            BindingContext = new ViewModels.AppSelectorPageViewModel();
            gc = new WilliamsBestAF.GreatCircle();
        }

        private void Calculate_Clicked(object sender, EventArgs e)
        {
            
            
        }

        private void LocationPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            var location = (Model.LocationInfo)picker.SelectedItem;

            if (LatDegrees1.Text == "")
            {
                LatDegrees1.Text = location.Latitude.ToString();
                LongDegrees1.Text = location.Longitude.ToString();
                Location1.Text = location.Name;
            }
            else
            {
                LatDegrees2.Text = location.Latitude.ToString();
                LongDegrees2.Text = location.Longitude.ToString();
                Location2.Text = location.Name;
            }

            Debug.WriteLine(location.Name);
            Debug.WriteLine(LocationPicker.SelectedIndex);
        }

        private void ClearTextButton_Clicked(object sender, EventArgs e)
        {
            LatDegrees1.Text = "";
            LongDegrees1.Text = "";
            LatDegrees2.Text = "";
            LongDegrees2.Text = "";
            Location1.Text = "";
            Location2.Text = "";
            LocationPicker.Title = "Pick a location";
            ResultDistance.Text = "";
            ThroughGroundGreatCircleDifference.Text = "";
        }

    }
}