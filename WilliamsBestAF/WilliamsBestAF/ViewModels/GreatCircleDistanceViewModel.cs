using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using WilliamsBestAF.Model;
using Xamarin.Forms;

namespace WilliamsBestAF.ViewModels
{
    public class GreatCircleDistanceViewModel : BindableObject
    {
        private GreatCircle gc = new GreatCircle();
        private double latitude1degree;
        private double latitude1minute;
        private double latitude1second;
        private double longitude1degree;
        private double longitude1minute;
        private double longitude1second;
        private double latitude2degree;
        private double latitude2minute;
        private double latitude2second;
        private double longitude2degree;
        private double longitude2minute;
        private double longitude2second;
        public double Latitude1Radians;
        public double Longitude1Radians;
        public double Latitude2Radians;
        public double Longitude2Radians;
        private string distance;

        private double Lat1Rad;
        private double Lat2Rad;
        private double Lng1Rad;
        private double Lng2Rad;
        public Command<object> CalculateCommand { get; set; }

        public ObservableCollection<LocationInfo> LocationInformation { get; set; }

        public GreatCircleDistanceViewModel()
        {
            CalculateCommand = new Command<object>(Calculate);

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

        private void Calculate(object obj)
        {
            var Lat1Deg = latitude1degree;
            var Lat1Min = latitude1minute;
            var Lat1Sec = latitude1second;
            var Lng1Deg = longitude1degree;
            var Lng1Min = longitude1minute;
            var Lng1Sec = longitude1second;
            var Lat2Deg = latitude2degree;
            var Lat2Min = latitude2minute;
            var Lat2Sec = latitude2second;
            var Lng2Deg = longitude2degree;
            var Lng2Min = longitude2minute;
            var Lng2Sec = longitude2second;
            Lat1Deg = gc.DMS_Degrees(Lat1Deg, Lat1Min, Lat1Sec);
            Lng1Deg = gc.DMS_Degrees(Lng1Deg, Lng1Min, Lng1Sec);
            Lat2Deg = gc.DMS_Degrees(Lat2Deg, Lat2Min, Lat2Sec);
            Lng2Deg = gc.DMS_Degrees(Lng2Deg, Lng2Min, Lng2Sec);
            Lat1Rad = gc.DegreesToRadians(Lat1Deg);
            Lng1Rad = gc.DegreesToRadians(Lng1Deg);
            Lat2Rad = gc.DegreesToRadians(Lat2Deg);
            Lng2Rad = gc.DegreesToRadians(Lng2Deg);


            var distanceRadians = gc.GreatCircle_Calculation(Lat1Rad, Lng1Rad, Lat2Rad, Lng2Rad);
            var distanceMiles = gc.RadiansToMiles(distanceRadians);
            Distance = distanceMiles.ToString();

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

        public string Distance
        {
            get => distance;
            set
            {
                distance = value;
                OnPropertyChanged();
            }

        }


    }
}
