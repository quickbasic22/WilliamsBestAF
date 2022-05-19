using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WilliamsBestAF.ViewModels;

namespace WilliamsBestAF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppSelectorPage : ContentPage
    {
        public AppSelectorPage()
        {
            InitializeComponent();
        }

        private async void ClairautsFormula_Clicked(object sender, EventArgs e)
        {
           await Shell.Current.GoToAsync("\\ClairautsFormula", true);
        }

        private async void CooridatesPage_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("\\CooridatesPage", true);
        }

        private async void CourseBetweenPoints_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("\\CourseBetweenPoints", true);
        }

        private async void CrossingParallels_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("\\CrossingParallels", true);
        }

        private async void CrossTrackError_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("\\CrossTrackError", true);
        }

        private async void DistanceThroughEarth_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("\\DistanceThroughEarth", true);
        }

        private async void GreatCircleCooridates_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("\\GreatCircleCooridates", true);
        }

        private async void GreatCircleDistance_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("\\GreatCircleDistance", true);
        }

        private async void IntermediatePointsOnAGreatCircle_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("\\IntermediatePointsOnAGreatCircle", true);
        }

        private async void IntersectingRadials_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("\\IntersectingRadials", true);
        }

        private async void LatitudeLongitudeGivenRadialAndDistance_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("\\LatitudeLongitudeGivenRadialAndDistance", true);
        }

        private async void LatitudeOfPointOnGC_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("\\LatitudeOfPointOnGC", true);
        }
    }
}