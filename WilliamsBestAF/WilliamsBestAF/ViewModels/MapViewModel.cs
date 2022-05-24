using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace WilliamsBestAF.ViewModels
{
    [QueryProperty(nameof(CoorLat), nameof(CoorLat))]
    [QueryProperty(nameof(CoorLong), nameof(CoorLong))]
    public class MapViewModel : BindableObject
    {
        private double coorlat;
        private double coorlong;
        public double CoorLat
        { 
            get => coorlat;
            set
            {
                coorlat = value;
                OnPropertyChanged();
            }   
        }
        public double CoorLong
        {
            get => coorlong;
            set
            {
                coorlong = value;
                OnPropertyChanged();
            }
        }

       
    }
}
