using System;
using System.Collections.Generic;
using Xamarin.Forms;
using WilliamsBestAF.Views;
using System.Diagnostics;

namespace WilliamsBestAF
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PlottingPoints), typeof(PlottingPoints));
            Routing.RegisterRoute(nameof(CooridatesPage), typeof(CooridatesPage));
            Routing.RegisterRoute(nameof(GreatCircleDistance), typeof(GreatCircleDistance));
            Routing.RegisterRoute(nameof(CourseBetweenPoints), typeof(CourseBetweenPoints));
            Routing.RegisterRoute(nameof(AppSelectorPage), typeof(AppSelectorPage));
            Routing.RegisterRoute(nameof(DistanceThroughEarth), typeof(DistanceThroughEarth));
            Routing.RegisterRoute(nameof(LatitudeOfPointOnGC), typeof(LatitudeOfPointOnGC));
            Routing.RegisterRoute(nameof(LatitudeLongitudeGivenRadialAndDistance), typeof(LatitudeLongitudeGivenRadialAndDistance));
            Routing.RegisterRoute(nameof(IntersectingRadials), typeof(IntersectingRadials));
            Routing.RegisterRoute(nameof(ClairautsFormula), typeof(ClairautsFormula));
            Routing.RegisterRoute(nameof(CrossingParallels), typeof(CrossingParallels));
            Routing.RegisterRoute(nameof(IntermediatePointsOnAGreatCircle), typeof(IntermediatePointsOnAGreatCircle));
            Routing.RegisterRoute(nameof(CrossTrackError), typeof(CrossTrackError));


        }

    }
}
