using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamsBestAF.Model;
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
            BindingContext = new ViewModels.DistanceThroughEarthViewModel();
            gc = new WilliamsBestAF.GreatCircle();
        }

        
        
        private void ClearTextButton_Clicked(object sender, EventArgs e)
        {
            LatDegrees1.Text = "";
            LongDegrees1.Text = "";
            LatDegrees2.Text = "";
            LongDegrees2.Text = "";
            LocationPicker1.SelectedIndex = 0;
            LocationPicker2.SelectedIndex = 0;
            ResultDistance.Text = "";
            ThroughGroundGreatCircleDifference.Text = "";
            
        }

        private void LocationPicker1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Picker = (Picker)sender;
            var location = (LocationInfo)Picker.SelectedItem;

            
            LatDegrees1.Text = location.Latitude.ToString();
            LongDegrees1.Text = location.Longitude.ToString();
        }

        private void LocationPicker2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Picker = (Picker)sender;
            var location = (LocationInfo)Picker.SelectedItem;

            LatDegrees2.Text = location.Latitude.ToString();
            LongDegrees2.Text = location.Longitude.ToString();
        }
    }
}