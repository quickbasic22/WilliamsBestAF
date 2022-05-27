using System;
using System.Collections.Generic;
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
    public class GreatCircleDistanceViewModel : BindableObject
    {
        private double latitude1;
        private double longitude1;
        private double latitude2;
        private double longitude2;
        private double greatcircledistance;
        private CooridateSummary Summary;
        private double throughtearthdistance;
        private double greatcircleminusthroughearthdistance;

        public GreatCircleDistanceViewModel()
        {
            Summary = (CooridateSummary)Application.Current.Properties["CooridateSummaryProperty"];
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

        public double GreatCircleDistance
        {
            get
            {
                return greatcircledistance = Summary.GreatCircleDistance;
            }
            set
            {
                greatcircledistance = value;
                OnPropertyChanged();
            }
        }

        public double ThroughEarthDistance
        {
            get
            {
                return throughtearthdistance = Summary.ThroughGroundDistance;
            }
            set
            {
                throughtearthdistance = value;
                OnPropertyChanged();
            }
        }

        public double GreatCircleMinusThroughEarthDistance
        {
            get
            {
                return greatcircleminusthroughearthdistance = Summary.GreatCircleThroughGroundDifference;
            }
            set
            {
                greatcircleminusthroughearthdistance = value;
                OnPropertyChanged();
            }
        }
    }
}
