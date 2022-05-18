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
    public partial class GreatCircleCooridates : ContentPage
    {
        GreatCircle GreatCircle = new GreatCircle();
        public GreatCircleCooridates()
        {
            InitializeComponent();
            GreatCircle = new GreatCircle();
        }

        public void Get_Cooridates()
        {
            
        }
    }
}