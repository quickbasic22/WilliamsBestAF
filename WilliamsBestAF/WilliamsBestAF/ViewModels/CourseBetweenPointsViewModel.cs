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
    public class CourseBetweenPointsViewModel : BindableObject
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
        private double Lat1Deg;
        private double Lat2Deg;
        private double Lng1Deg;
        private double Lng2Deg;
        private double Lat1Rad;
        private double Lat2Rad;
        private double Lng1Rad;
        private double Lng2Rad;
        public Command<object> CalculateCommand { get; set; }

        public ObservableCollection<LocationInfo> LocationInformation { get; set; }

        public CourseBetweenPointsViewModel()
        {
            CalculateCommand = new Command<object>(Calculate);

            LocationInformation = new ObservableCollection<LocationInfo>()
            {
                new LocationInfo() { Id = 0, Name = "Select A Location", Latitude = 0, Longitude = 0 },
                new LocationInfo() { Id = 1, Name = "Eustis, Florida", Latitude = ConvertDegreesToRadians(28.881541), Longitude = ConvertDegreesToRadians(-81.703742)},
                new LocationInfo() { Id = 2, Name = "Los Angeles", Latitude = ConvertDegreesToRadians(34.05349), Longitude = ConvertDegreesToRadians(-118.24532)},
                new LocationInfo() { Id = 3, Name = "Miami", Latitude = ConvertDegreesToRadians(25.775084), Longitude = ConvertDegreesToRadians(-80.1947)},
                new LocationInfo() { Id = 4, Name = "New York City", Latitude = ConvertDegreesToRadians(40.71455), Longitude = ConvertDegreesToRadians(-74.00712)},
                new LocationInfo() { Id = 5, Name = "London England", Latitude = ConvertDegreesToRadians(51.500153), Longitude = ConvertDegreesToRadians(-0.1262362)},
                new LocationInfo() { Id = 6, Name = "Frankfurt Germany", Latitude = ConvertDegreesToRadians(50.11208), Longitude = ConvertDegreesToRadians(8.68341)},
                new LocationInfo() { Id = 7, Name = "Chicago", Latitude = ConvertDegreesToRadians(41.88425), Longitude = ConvertDegreesToRadians(-87.63245)},
                new LocationInfo() { Id = 8, Name = "Singapore", Latitude = ConvertDegreesToRadians(1.29016), Longitude = ConvertDegreesToRadians(103.852)},
                new LocationInfo() { Id = 9, Name = "Brazil", Latitude = ConvertDegreesToRadians(-10.8104515), Longitude = ConvertDegreesToRadians(-52.973118)},
                new LocationInfo() { Id = 10, Name = "Galápagos Islands", Latitude = ConvertDegreesToRadians(-0.43609226), Longitude = ConvertDegreesToRadians(-90.59137)},
                new LocationInfo() { Id = 11, Name = "Hilo Hawaii", Latitude = ConvertDegreesToRadians(19.724876), Longitude = ConvertDegreesToRadians(155.08868)},
                new LocationInfo() { Id = 12, Name = "Dubai", Latitude = ConvertDegreesToRadians(25.20498), Longitude = ConvertDegreesToRadians(55.271057)},
                new LocationInfo() { Id = 13, Name = "Juneau Alaska", Latitude = ConvertDegreesToRadians(58.300323), Longitude = ConvertDegreesToRadians(-134.41763)},
                new LocationInfo() { Id = 14, Name = "Bolivar Ohio", Latitude = ConvertDegreesToRadians(40.65014), Longitude = ConvertDegreesToRadians(-81.45259)},
                new LocationInfo() { Id = 15, Name = "Eustis AntiPodal", Latitude = ConvertDegreesToRadians(-28.881541), Longitude = ConvertDegreesToRadians(98.296258)}
            };


        }

        private void Calculate(object obj)
        {
           

            Lat1Deg = latitude1degree + (latitude1minute / 60) + (latitude1second / 3600);
            Lng1Deg = longitude1degree + (longitude1minute / 60) + (longitude1second / 3600);
            Lat2Deg = latitude2degree + (latitude2minute / 60) + (latitude2second / 3600);
            Lng2Deg = longitude2degree + (longitude2minute / 60) + (longitude2second / 3600);
            Lat1Rad = gc.DegreesToRadians(Lat1Deg);
            Lng1Rad = gc.DegreesToRadians(Lng1Deg);
            Lat2Rad = gc.DegreesToRadians(Lat2Deg);
            Lng2Rad = gc.DegreesToRadians(Lng2Deg);
            var distanceRadians = gc.GreatCircle_Calculation(Lat1Rad, Lng1Rad, Lat2Rad, Lng2Rad);
            var courseRadians = gc.CourseBetweenPoints(distanceRadians, Lat1Rad, Lng1Rad, Lat2Rad, Lng2Rad);
            var courseDegrees = gc.RadiansToMiles(courseRadians);
            Distance = courseDegrees.ToString();

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

        private double ConvertDegreesToRadians(double radians)
        {
            return gc.DegreesToRadians(radians);
        }
    }
}
