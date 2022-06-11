using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using WilliamsBestAF.Model;
using WilliamsBestAF.Views;
using Xamarin.Forms;

namespace WilliamsBestAF.ViewModels
{

    public class CooridatesPageViewModel : BindableObject
    {
        public CooridateSummary Summarize { get; set; }
        private GreatCircle gc = new GreatCircle();
        private double latitude1degree = 33;
        private double latitude1minute = 57;
        private double latitude1second = 0;
        private double longitude1degree = 118;
        private double longitude1minute = 24;
        private double longitude1second = 0;
        private double latitude2degree = 40;
        private double latitude2minute = 38;
        private double latitude2second = 0;
        private double longitude2degree = 73;
        private double longitude2minute = 47;
        private double longitude2second = 0;
        public double Latitude1Radians = 0.0;
        public double Longitude1Radians = 0.0;
        public double Latitude2Radians = 0.0;
        public double Longitude2Radians = 0.0;
        public string departurelocation = "";
        public string destinationlocation = "";
        public Command ConvertDegreesToRadiansCommand { get; set; }

        public ObservableCollection<LocationInfo> LocationInformation { get; set; }

        public CooridatesPageViewModel()
        {
            Summarize = (CooridateSummary)Application.Current.Properties["CooridateSummaryProperty"];
            ConvertDegreesToRadiansCommand = new Command(ConvertDegToRadCommand);
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
                new LocationInfo() { Id = 14, Name = "Bolivar Ohio", Latitude = 40.65014, Longitude = -81.45259},
                new LocationInfo() { Id = 15, Name = "Eustis AntiPodal", Latitude = -28.881541, Longitude = 98.296258}
            };

                        
        }
        public string DepartureLocation
        {
            get
            {
                return departurelocation;
            }
            set
            {
                departurelocation = value;
                OnPropertyChanged();
            }
        }
        public double Latitude1Degree
        {
            get
            {
                return latitude1degree;
            }
            set
            {
                latitude1degree = value;
                OnPropertyChanged();
            }
        }
        public double Latitude1Minute
        {
            get
            {
                return latitude1minute;
            }
            set
            {
                latitude1minute = value;
                OnPropertyChanged();
            }
        }
        public double Latitude1Second
        {
            get
            {
                return latitude1second;
            }
            set
            {
                latitude1second = value;
                OnPropertyChanged();
            }
        }
        public double Longitude1Degree
        {
            get
            {
                return longitude1degree;
            }
            set
            {
                longitude1degree = value;
                OnPropertyChanged();
            }
        }
        public double Longitude1Minute
        {
            get
            {
                return longitude1minute;
            }
            set
            {
                longitude1minute = value;
                OnPropertyChanged();
            }
        }
        public double Longitude1Second
        {
            get
            {
                return longitude1second;
            }
            set
            {
                longitude1second = value;
                OnPropertyChanged();
            }
        }
        public string DestinationLocation
        {
            get
            {
                return destinationlocation;
            }
            set
            {
                destinationlocation = value;
                OnPropertyChanged();
            }
        }
        public double Latitude2Degree
        {
            get
            {
                return latitude2degree;
            }
            set
            {
                latitude2degree = value;
                OnPropertyChanged();
            }
        }
        public double Latitude2Minute
        {
            get
            {
                return latitude2minute;
            }
            set
            {
                latitude2minute = value;
                OnPropertyChanged();
            }
        }
        public double Latitude2Second
        {
            get
            {
                return latitude2second;
            }
            set
            {
                latitude2second = value;
                OnPropertyChanged();
            }
        }
        public double Longitude2Degree
        {
            get
            {
                return longitude2degree;
            }
            set
            {
                longitude2degree = value;
                OnPropertyChanged();
            }
        }
        public double Longitude2Minute
        {
            get
            {
                return longitude2minute;
            }
            set
            {
                longitude2minute = value;
                OnPropertyChanged();
            }
        }
        public double Longitude2Second
        {
            get
            {
                return longitude2second;
            }
            set
            {
                longitude2second = value;
                OnPropertyChanged();
            }
        }
       

        private async void ConvertDegToRadCommand(object obj)
        {
            Convert_Degrees_Radians();
           // await Shell.Current.GoToAsync($"{nameof(GreatCircleDistance)}?{nameof(GreatCircleDistanceViewModel.Latitude1)}={Latitude1Radians}&{nameof(GreatCircleDistanceViewModel.Longitude1)}={Longitude1Radians}&{nameof(GreatCircleDistanceViewModel.Latitude2)}={Latitude2Radians}&{nameof(GreatCircleDistanceViewModel.Longitude2)}={Longitude2Radians}");
            await Shell.Current.GoToAsync($"{nameof(PlottingPoints)}?{nameof(PlottingPointsViewModel.Latitude1)}={Latitude1Radians}&{nameof(PlottingPointsViewModel.Longitude1)}={Longitude1Radians}&{nameof(PlottingPointsViewModel.Latitude2)}={Latitude2Radians}&{nameof(PlottingPointsViewModel.Longitude2)}={Longitude2Radians}");
        }

        private void Calculate()
        {
            double distance = gc.GreatCircle_Calculation(Latitude1Radians, Longitude1Radians, Latitude2Radians, Longitude2Radians);
            double distanceNM = gc.RadiansToNauticalMiles(distance);
            double distanceMiles = gc.NauticalMilesToMiles(distanceNM);

            Summarize.DepartureName = DepartureLocation;
            Summarize.DepartureLatitude = Latitude1Radians;
            Summarize.DepartureLongitude = Longitude1Radians;

            Summarize.DestinationName = DestinationLocation;
            Summarize.DestinationLatitude = Latitude2Radians;
            Summarize.DestinationLongitude = Longitude2Radians;

            Summarize.GreatCircleDistance = distanceMiles;
            double courseRadians = gc.CourseBetweenPoints(distance, Latitude1Radians, Longitude1Radians, Latitude2Radians, Longitude2Radians);
            Summarize.TripCourse = Math.Round(gc.RadiansToDegrees(courseRadians), 0);

            double throughGround = gc.GetDistantThroughEarth(Latitude1Radians, Longitude1Radians, Latitude2Radians, Longitude2Radians);
            Summarize.ThroughGroundDistance = throughGround;
            double greatCircleMinusThroughGround = distanceMiles - throughGround;
            Summarize.GreatCircleThroughGroundDifference = greatCircleMinusThroughGround;
        }

        public void Convert_Degrees_Radians()
        {
           double Latitude1Deg = gc.DMS_Degrees(Latitude1Degree, Latitude1Minute, Latitude1Second);
           double Longitude1Deg = gc.DMS_Degrees(Longitude1Degree, Longitude1Minute, Longitude1Second);
           double Latitude2Deg = gc.DMS_Degrees(Latitude2Degree, Latitude2Minute, Latitude2Second);
           double Longitude2Deg = gc.DMS_Degrees(Longitude2Degree, Longitude2Minute, Longitude2Second);
            Latitude1Radians = gc.DegreesToRadians(Latitude1Deg);
            Longitude1Radians = gc.DegreesToRadians(Longitude1Deg);
            Latitude2Radians = gc.DegreesToRadians(Latitude2Deg);
            Longitude2Radians = gc.DegreesToRadians(Longitude2Deg);
            Calculate();
        }

    }
}
