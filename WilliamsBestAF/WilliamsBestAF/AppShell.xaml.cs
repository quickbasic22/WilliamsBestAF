using System;
using System.Collections.Generic;
using Xamarin.Forms;
using WilliamsBestAF.Views;

namespace WilliamsBestAF
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CourseBetweenPoints), typeof(CourseBetweenPoints));

        }

    }
}
