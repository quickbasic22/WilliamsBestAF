using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamsBestAF.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WilliamsBestAF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GreatCircleDistance : ContentPage
    {
        WilliamsBestAF.GreatCircle gc;
        public GreatCircleDistance()
        {
            InitializeComponent();
            gc = new WilliamsBestAF.GreatCircle();
            BindingContext = new GreatCircleDistanceViewModel();
            
        }

        
    }
}