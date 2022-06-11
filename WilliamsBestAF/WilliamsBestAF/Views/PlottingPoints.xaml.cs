using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamsBestAF.Model;
using WilliamsBestAF.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WilliamsBestAF.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlottingPoints : ContentPage
	{
		GreatCircle gc = new GreatCircle();
		CooridateSummary Summary = (CooridateSummary)Application.Current.Properties["CooridateSummaryProperty"];
		//CooridateSummary[] PlottedPoints;
		public ObservableCollection<CooridateSummary> Items { get; set; }
		//public Command LoadItemsCommand { get; }

		public PlottingPoints()
		{
			InitializeComponent();
			//PlottedPoints = new CooridateSummary[100];
			//LoadItemsCommand = new Command(() => ExecuteLoadItemsCommand());
		    Items = new ObservableCollection<CooridateSummary>();
			getCooridates(0.10);
			MyListView.BindingContext = Items;
			Title = "Plotted Points on Great Circle";
			MyListView.BackgroundColor = Color.Crimson;
		}
		
		private void getCooridates(double distancePercent)
		{
			double course = Summary.TripCourse;
			double lat1 = Summary.DepartureLatitude;
			double lng1 = Summary.DepartureLongitude;
			double lat2 = Summary.DestinationLatitude;
			double lng2 = Summary.DestinationLongitude;
			double tripdistance = Summary.GreatCircleDistance;
			double numberOfPoints = Math.Round(1 / distancePercent, 0);
			double increment = 0;
			int counter;

			for (counter = 0;counter < numberOfPoints;counter++)
			{
				increment += 0.10;
				double[] data = gc.IntermediatePointsOnAGreatCircle(increment, lat1, lng1, lat2, lng2);

				CooridateSummary sum = new CooridateSummary();
				var calclat1 = gc.DegreesToRadians(data[0]);
				var calclng1 = gc.DegreesToRadians(data[1]);
				sum.DepartureLatitude = calclat1;
				sum.DepartureLongitude = calclng1;
				sum.DestinationLatitude = lat1;
				sum.DestinationLongitude = lng1;
				Items.Add(sum);
				
				
				//PlottedPoints[counter] = new CooridateSummary();
				//PlottedPoints[counter].DepartureLatitude = data[0];
				//PlottedPoints[counter].DepartureLongitude = data[1];
				//PlottedPoints[counter].DestinationLatitude = lat2;
				//PlottedPoints[counter].DestinationLongitude = lng2;
			}
			
		}

	 //  private void ExecuteLoadItemsCommand()
		//{
		//	IsBusy = true;

		//	try
		//	{ 
		//		Items.Clear();
		//		var items = PlottedPoints.ToList();
		//		foreach (var item in items)
		//		{
		//			Items.Add(item);
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		Debug.WriteLine(ex);
		//	}
		//	finally
		//	{
		//		IsBusy = false;
		//	}
		//}
	}
}