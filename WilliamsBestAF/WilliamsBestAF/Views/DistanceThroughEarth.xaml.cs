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

        
        private void LocationPicker_SelectedIndexChanged(object sender, EventArgs e)
        {

            var picker = sender as Picker;
            var picker1 = (Picker)picker.FindByName("LocationPicker1");
            var picker2 = (Picker)picker.FindByName("LocationPicker2");
            
            if (picker1.SelectedItem is LocationInfo)
            {
                var location = (Model.LocationInfo)picker1.SelectedItem;

               
                    LatDegrees1.Text = location.Latitude.ToString();
                    LongDegrees1.Text = location.Longitude.ToString();

               
                Debug.WriteLine(location.Name);
                Debug.WriteLine(LocationPicker1.SelectedIndex);
            }
            else
            {
                var location = (Model.LocationInfo)picker2.SelectedItem;

                
                    LatDegrees2.Text = location.Latitude.ToString();
                    LongDegrees2.Text = location.Longitude.ToString();
                
                Debug.WriteLine(location.Name);
                Debug.WriteLine(LocationPicker2.SelectedIndex);
            }

            
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

    }
}