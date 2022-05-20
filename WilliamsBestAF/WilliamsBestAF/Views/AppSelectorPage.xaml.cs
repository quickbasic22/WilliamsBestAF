using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WilliamsBestAF.ViewModels;

namespace WilliamsBestAF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppSelectorPage : ContentPage
    {
        public AppSelectorPage()
        {
            InitializeComponent();
            BindingContext = new AppSelectorPageViewModel();
        }
                      
       
    }
}