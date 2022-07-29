using WilliamsBestAF.Model;
using Xamarin.Forms;

namespace WilliamsBestAF.ViewModels
{
    public class PlottingPointsViewModel : BindableObject
    {
        private double latitude1;
        private double longitude1;
        private double latitude2;
        private double longitude2;
        private Model.CooridateSummary CooridateSummary { get; set; }

        public PlottingPointsViewModel()
        {
            CooridateSummary = (CooridateSummary)Application.Current.Properties["CooridateSummaryProperty"];
            Latitude1 = CooridateSummary.DepartureLatitude;
            Longitude1 = CooridateSummary.DepartureLongitude;
            Latitude2 = CooridateSummary.DestinationLatitude;
            Longitude2 = CooridateSummary.DestinationLongitude;
        }

        public double Latitude1
        { 
            get => latitude1;
            set
            {
                latitude1 = value;
                OnPropertyChanged();
            }
        }
        public double Longitude1
        { 
            get => longitude1;
            set
            {
                longitude1 = value;
                OnPropertyChanged();
            }
        }
        public double Latitude2
        { 
            get => latitude2; 
            set
            {
                latitude2 = value;
                OnPropertyChanged();
            }
                
        }
        public double Longitude2
        { 
            get => longitude2;
            set
            {
                longitude2 = value;
                OnPropertyChanged();
            }
        }
    }
}