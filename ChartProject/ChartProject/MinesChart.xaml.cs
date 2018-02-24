using Refit;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChartProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MinesChart : ContentPage
    {
        public ObservableCollection<CoalDateWiseModel> CoalData = new ObservableCollection<CoalDateWiseModel>();
        public ObservableCollection<CoalDateWiseModel> CoalLineData = new ObservableCollection<CoalDateWiseModel>();
        private double width = 0;
        private double height = 0;
        double percentageachieved;
        public MinesChart()
        {
            InitializeComponent();
            minescoalchart.PrimaryAxis = new DateTimeAxis()
            {
                IntervalType = DateTimeIntervalType.Days,
                Interval = 1,
                LabelRotationAngle = 300,
                // Minimum = new DateTime(2018, 1, 18),
                //Maximum = new DateTime(2018, 1, 3)
                //AutoScrollingDelta = 3,
                //AutoScrollingDeltaType = DateTimeDeltaType.Days
            };

        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;
                if (width > height)
                {
                    outerStack.Orientation = StackOrientation.Horizontal;
                }
                else
                {
                    outerStack.Orientation = StackOrientation.Vertical;
                }
            }
        }
        private async void datepicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime currentDate = e.NewDate;
            int day = currentDate.Day;
            int month = currentDate.Month;
            int year = currentDate.Year;
            //double dailydespatch = 0;

            var webApi = RestService.For<IWebAPI>("http://192.168.1.102:8090/");
            List<CoalDateWiseModel> coaldatewise = await webApi.GetCoalDateMines(year, month, day);

            CoalData.Clear();
            CoalLineData.Clear();
            foreach (CoalDateWiseModel coaldatewisedata in coaldatewise)
            {
                CoalDateWiseModel coalDateWiseModel = new CoalDateWiseModel
                {
                    dailyDespatch = 7386,
                    date = coaldatewisedata.date
                };
                CoalData.Add(coaldatewisedata);
                CoalLineData.Add(coalDateWiseModel);
            }
            columnSeriesofcoal.ItemsSource = CoalData;
            lineSeriesofcoal.ItemsSource = CoalLineData;

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var webApi = RestService.For<IWebAPI>("http://192.168.1.102:8090/");
            CoalBauxiteModel allCoalMines = await webApi.GetAllCoalMines();

            CoalBauxiteModel dispatchQtyCoal = await webApi.GetDespatchQtyCoalMines();


            //For Coal Grid
            Label nameCoalLable = new Label { Text = allCoalMines.name, HorizontalTextAlignment = TextAlignment.Center, BackgroundColor = Color.LightBlue };
            coalGrid.Children.Add(nameCoalLable, 0, 1);

            Label dailyCoalLable = new Label { Text = allCoalMines.daily.ToString(), HorizontalTextAlignment = TextAlignment.Center, BackgroundColor = Color.LightBlue };
            coalGrid.Children.Add(dailyCoalLable, 1, 1);

            Label mtdCoalLable = new Label { Text = allCoalMines.mtd.ToString(), HorizontalTextAlignment = TextAlignment.Center, BackgroundColor = Color.LightBlue };
            coalGrid.Children.Add(mtdCoalLable, 2, 1);

            Label ytdCoalLable = new Label { Text = allCoalMines.ytd.ToString(), HorizontalTextAlignment = TextAlignment.Center, BackgroundColor = Color.LightBlue };
            coalGrid.Children.Add(ytdCoalLable, 3, 1);

            //For dispatchQty coal values
            Label nameCoalDispatchLable = new Label { Text = dispatchQtyCoal.name, HorizontalTextAlignment = TextAlignment.Center, BackgroundColor = Color.LightBlue };
            coalGrid.Children.Add(nameCoalDispatchLable, 0, 2);

            Label dailyCoalDispatchLable = new Label { Text = dispatchQtyCoal.daily.ToString(), HorizontalTextAlignment = TextAlignment.Center, BackgroundColor = Color.LightBlue };
            percentageachieved = (dispatchQtyCoal.daily / allCoalMines.daily) * 100;
            if (percentageachieved > 105)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "green_up_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(dailyCoalDispatchLable);
                coalGrid.Children.Add(layout, 1, 2);
            }
            else if (percentageachieved <= 105 && percentageachieved >= 100)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "yellow_up_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(dailyCoalDispatchLable);
                coalGrid.Children.Add(layout, 1, 2);
            }
            else if (percentageachieved <= 100 && percentageachieved >= 95)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "yellow_down_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(dailyCoalDispatchLable);
                coalGrid.Children.Add(layout, 1, 2);
            }
            else if (percentageachieved < 95)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "red_down_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(dailyCoalDispatchLable);
                coalGrid.Children.Add(layout, 1, 2);
            }

            Label mtdCoalDispatchLable = new Label { Text = dispatchQtyCoal.mtd.ToString(), HorizontalTextAlignment = TextAlignment.Center, BackgroundColor = Color.LightBlue };
            percentageachieved = (dispatchQtyCoal.mtd / allCoalMines.mtd) * 100;
            if (percentageachieved > 105)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "green_up_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(mtdCoalDispatchLable);
                coalGrid.Children.Add(layout, 2, 2);
            }
            else if (percentageachieved <= 105 && percentageachieved >= 100)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "yellow_up_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(mtdCoalDispatchLable);
                coalGrid.Children.Add(layout, 2, 2);
            }
            else if (percentageachieved <= 100 && percentageachieved >= 95)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "yellow_down_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(mtdCoalDispatchLable);
                coalGrid.Children.Add(layout, 2, 2);
            }
            else if (percentageachieved < 95)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "red_down_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(mtdCoalDispatchLable);
                coalGrid.Children.Add(layout, 2, 2);
            }

            Label ytdCoalDispatchLable = new Label { Text = dispatchQtyCoal.ytd.ToString(), HorizontalTextAlignment = TextAlignment.Center, BackgroundColor = Color.LightBlue };
            percentageachieved = (dispatchQtyCoal.ytd / allCoalMines.ytd) * 100;
            if (percentageachieved > 105)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "green_up_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(ytdCoalDispatchLable);
                coalGrid.Children.Add(layout, 3, 2);
            }
            else if (percentageachieved <= 105 && percentageachieved >= 100)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "yellow_up_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(ytdCoalDispatchLable);
                coalGrid.Children.Add(layout, 3, 2);
            }
            else if (percentageachieved <= 100 && percentageachieved >= 95)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "yellow_down_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(ytdCoalDispatchLable);
                coalGrid.Children.Add(layout, 3, 2);
            }
            else if (percentageachieved < 95)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "red_down_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(ytdCoalDispatchLable);
                coalGrid.Children.Add(layout, 3, 2);
            }
        }
    }
}
