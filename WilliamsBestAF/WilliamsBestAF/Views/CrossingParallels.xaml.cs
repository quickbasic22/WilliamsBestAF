using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WilliamsBestAF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrossingParallels : ContentPage
    {
        WilliamsBestAF.GreatCircle gc;
        public CrossingParallels()
        {
            InitializeComponent();
            gc = new WilliamsBestAF.GreatCircle();
        }

        private void ComputeCourse_Clicked(object sender, EventArgs e)
        {

        }

        private void ClearAll_Clicked(object sender, EventArgs e)
        {

        }
    }
}