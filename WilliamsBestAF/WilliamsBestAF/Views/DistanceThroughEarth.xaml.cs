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
    public partial class DistanceThroughEarth : ContentPage
    {
        WilliamsBestAF.GreatCircle gc;
        public DistanceThroughEarth()
        {
            InitializeComponent();
            BindingContext = new ViewModels.DistanceThroughEarthViewModel();
            gc = new WilliamsBestAF.GreatCircle();
        }

        private void Calculate_Clicked(object sender, EventArgs e)
        {
            double lat = double.Parse(LatDegrees1.Text);
            double lng = double.Parse(LongDegrees1.Text);
            double lat2 = double.Parse(LatDegrees2.Text);
            double lng2 = double.Parse(LongDegrees2.Text);
            double distancethroughearth = gc.GetDistantThroughEarth(lat, lng, lat2, lng2);
            ResultDistance.Text = distancethroughearth.ToString();
            double gcdistance = gc.GreatCircle_Calculation(lat, lng, lat2, lng2);
            GreatCircleDistance.Text = gcdistance.ToString();
            double GCThroughEarthDifference = gcdistance - distancethroughearth;
            ThroughGroundGreatCircleDifference.Text = GCThroughEarthDifference.ToString();
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
        }

        private void ClearTextButton_Clicked(object sender, EventArgs e)
        {
            LatDegrees1.Text = "";
            LongDegrees1.Text = "";
            LatDegrees2.Text = "";
            LongDegrees2.Text = "";
            Location1.Text = "";
            Location2.Text = "";
        }
    }
}