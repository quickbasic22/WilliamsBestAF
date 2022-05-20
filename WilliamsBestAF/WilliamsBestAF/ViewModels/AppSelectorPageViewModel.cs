using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using WilliamsBestAF.Model;
using Xamarin.Forms;

namespace WilliamsBestAF.ViewModels
{
    [QueryProperty(nameof(Latitude1), nameof(Latitude1))]
    [QueryProperty(nameof(Longitude1), nameof(Longitude1))]
    [QueryProperty(nameof(Latitude2), nameof(Latitude2))]
    [QueryProperty(nameof(Longitude2), nameof(Longitude2))]
    public class AppSelectorPageViewModel : BindableObject
    {
        private double latitude1;
        private double longitude1;
        private double latitude2;
        private double longitude2;
        public Command ClairautsFormulaCommand { get; set; }
        public Command CooridatesPageCommand { get; set; }
        public Command CourseBetweenPointsCommand { get; set; }
        public Command CrossingParallelsCommand { get; set; }
        public Command CrossTrackErrorCommand { get; set; }
        public Command DistanceThroughEarthCommand { get; set; }
        public Command GreatCircleCooridatesCommand { get; set; }
        public Command GreatCircleDistanceCommand { get; set; }
        public Command IntermediatePointsOnAGreatCircleCommand { get; set; }
        public Command IntersectingRadialsCommand { get; set; }
        public Command LatitudeLongitudeGivenRadialAndDistanceCommand { get; set; }
        public Command LatitudeOfPointOnGCCommand { get; set; }
        public ObservableCollection<LocationInfo> LocationInformation { get; set; }

        public AppSelectorPageViewModel()
        {
            ClairautsFormulaCommand = new Command(async () => await Shell.Current.GoToAsync("\\ClairautsFormula", true));
            CooridatesPageCommand = new Command(async () => await Shell.Current.GoToAsync("CooridatesPage"));
            CourseBetweenPointsCommand = new Command(async () => await Shell.Current.GoToAsync("\\CourseBetweenPoints", true));
            CrossingParallelsCommand = new Command(async () => await Shell.Current.GoToAsync("\\CrossingParallels", true));
            CrossTrackErrorCommand = new Command(async () => await Shell.Current.GoToAsync("\\CrossTrackError", true));
            DistanceThroughEarthCommand = new Command(async () => await Shell.Current.GoToAsync("\\DistanceThroughEarth", true));
            GreatCircleCooridatesCommand = new Command(async () => await Shell.Current.GoToAsync("\\GreatCircleCooridates", true));
            GreatCircleDistanceCommand = new Command(async () => await Shell.Current.GoToAsync("\\GreatCircleDistance", true));
            IntermediatePointsOnAGreatCircleCommand = new Command(async () => await Shell.Current.GoToAsync("\\IntermediatePointsOnAGreatCircle", true));
            IntersectingRadialsCommand = new Command(async () => await Shell.Current.GoToAsync("\\IntersectingRadials", true));
            LatitudeLongitudeGivenRadialAndDistanceCommand = new Command(async () => await Shell.Current.GoToAsync("\\LatitudeLongitudeGivenRadialAndDistance", true));
            LatitudeOfPointOnGCCommand = new Command(async () => await Shell.Current.GoToAsync("\\LatitudeOfPointOnGC", true));
            LocationInformation = new ObservableCollection<LocationInfo>()
            {
                new LocationInfo() { Id = 0, Name = "Select A Location", Latitude = 0, Longitude = 0 },
                new LocationInfo() { Id = 1, Name = "Eustis, Florida", Latitude = 28.881541, Longitude = -81.703742},
                new LocationInfo() { Id = 2, Name = "Los Angeles", Latitude = 34.05349, Longitude = -118.24532},
                new LocationInfo() { Id = 3, Name = "Miami", Latitude = 25.775084, Longitude = -80.1947},
                new LocationInfo() { Id = 4, Name = "New York City", Latitude = 40.71455, Longitude = -74.00712},
                new LocationInfo() { Id = 5, Name = "London England", Latitude = 51.500153, Longitude = -0.1262362},
                new LocationInfo() { Id = 6, Name = "Frankfurt Germany", Latitude = 50.11208, Longitude = 8.68341},
                new LocationInfo() { Id = 7, Name = "Chicago", Latitude = 41.88425, Longitude = -87.63245},
                new LocationInfo() { Id = 8, Name = "Singapore", Latitude = 1.29016, Longitude = 103.852},
                new LocationInfo() { Id = 9, Name = "Brazil", Latitude = -10.8104515, Longitude = -52.973118},
                new LocationInfo() { Id = 10, Name = "Galápagos Islands", Latitude = -0.43609226, Longitude = -90.59137},
                new LocationInfo() { Id = 11, Name = "Hilo Hawaii", Latitude = 19.724876, Longitude = 155.08868},
                new LocationInfo() { Id = 12, Name = "Dubai", Latitude = 25.20498, Longitude = 55.271057},
                new LocationInfo() { Id = 13, Name = "Juneau Alaska", Latitude = 58.300323, Longitude = -134.41763},
                new LocationInfo() { Id = 14, Name = "Bolivar Ohio", Latitude = 40.65014, Longitude = -81.45259}
            };
        }


             

        public double Latitude1
        {
            get
            {
                return latitude1;
            }
            set
            {
                latitude1 = value;
                OnPropertyChanged();
            }
        }
        public double Longitude1
        {
            get
            {
                return longitude1;
            }
            set
            {
                longitude1 = value;
                OnPropertyChanged();
            }
        }
        public double Latitude2 
        {
            get
            {
                return latitude2;
            }
            set
            {
                latitude2 = value;
                OnPropertyChanged();
            }
        }
        public double Longitude2 
        {
            get
            {
                return longitude2;
            }
            set
            {
                longitude2 = value;
                OnPropertyChanged();
            }
        }
    }
}
