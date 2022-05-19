using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace WilliamsBestAF.ViewModels
{
    [QueryProperty(nameof(lat1), nameof(lat1))]
    [QueryProperty(nameof(lng1), nameof(lng1))]
    [QueryProperty(nameof(lat2), nameof(lat2))]
    [QueryProperty(nameof(lng2), nameof(lng2))]
    public class AppSelectorPageViewModel : INotifyPropertyChanged
    {
        private double flat1;
        private double flng1;
        private double flat2;
        private double flng2;

        public double lat1
        {
            get
            {
                return flat1;
            }
            set
            {
                flat1 = value;
                OnPropertyChanged();
            }
        }
        public double lng1
        {
            get
            {
                return flng1;
            }
            set
            {
                flng1 = value;
                OnPropertyChanged();
            }
        }
        public double lat2 
        {
            get
            {
                return flat2;
            }
            set
            {
                flat2 = value;
                OnPropertyChanged();
            }
        }
        public double lng2 
        {
            get
            {
                return flng2;
            }
            set
            {
                flng2 = value;
                OnPropertyChanged();
            }
        }

        
        #region INotifyPropertyChanged
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
