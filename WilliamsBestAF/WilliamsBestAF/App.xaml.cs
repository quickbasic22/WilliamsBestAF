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
        private CooridateSummary cooridatesummary;

        public CooridateSummary CooridateSummary
        {
            get => cooridatesummary;
            set
            {
                cooridatesummary = value;
            }
        }
        

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            AppActions.OnAppAction += new EventHandler<AppActionEventArgs>(AppActions_OnAppAction);
           CooridateSummary = new CooridateSummary();
            Application.Current.Properties.Add("CooridateSummaryProperty", CooridateSummary);
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
