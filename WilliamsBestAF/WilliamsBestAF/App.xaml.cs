using System;
using System.Diagnostics;
using WilliamsBestAF.Model;
using WilliamsBestAF.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace WilliamsBestAF
{
    public partial class App : Application
    {
        public static string DepartureName { get; set; }
        public static double DepartureLatitude { get; set; }
        public static double DepartureLongitude { get; set; }

        public static string DestinationName { get; set; }
        public static double DestinationLatitude { get; set; }
        public static double DestinationLongitude { get; set; }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            AppActions.OnAppAction += new EventHandler<AppActionEventArgs>(AppActions_OnAppAction);
            Application.Current.Properties.Add("DepartureName", DepartureName);
            Application.Current.Properties.Add("DepartureLatitude", DepartureLatitude);
            Application.Current.Properties.Add("DepartureLongitude", DepartureLongitude);

            Application.Current.Properties.Add("DestinationName", DepartureName);
            Application.Current.Properties.Add("DestinationLatitude", DepartureLatitude);
            Application.Current.Properties.Add("DestinationLongitude", DepartureLongitude);


        }

        private void AppActions_OnAppAction(object sender, AppActionEventArgs e)
        {
            if (Application.Current != this && Application.Current is App app)
            {
                AppActions.OnAppAction -= app.AppActions_OnAppAction;
                return;
            }
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                if (e.AppAction.Id == "AppSelectorPage")
                    await Shell.Current.GoToAsync(nameof(AppSelectorPage));
                else if (e.AppAction.Id == "CourseBetweenPoints")
                    await Shell.Current.GoToAsync(nameof(CourseBetweenPoints));
                else if (e.AppAction.Id == "DistanceThroughEarth")
                    await Shell.Current.GoToAsync(nameof(DistanceThroughEarth));
            });
        }

        protected async override void OnStart()
        {
            try
            {
                await AppActions.SetAsync(
                    new AppAction("AppSelectorPage", "App Selector Page", icon: "icon_about"),
                new AppAction("CourseBetweenPoints", "Course Between Points", icon: "icon_feed"),
                    new AppAction("DistanceThroughEarth", "Distance Through Earth", icon: "icon_feed")
                    );
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }


        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
            base.OnResume();

        }
    }
}
