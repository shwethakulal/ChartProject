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
    public partial class BauxiteMinePage : ContentPage
    {
        public ObservableCollection<CoalDateWiseModel> BauxiteLineData = new ObservableCollection<CoalDateWiseModel>();
        public ObservableCollection<CoalDateWiseModel> BauxiteData = new ObservableCollection<CoalDateWiseModel>();
        double percentageachieved;
        public BauxiteMinePage()
        {
            InitializeComponent();
            minesbauxitechart.PrimaryAxis = new DateTimeAxis()
            {
                IntervalType = DateTimeIntervalType.Days,
                Interval = 1,
                LabelRotationAngle = 300,
                //Minimum = new DateTime(2018, 1, 18),
                //Maximum = new DateTime(2018, 1, 3)

            };
        }
        private async void datepicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime currentDate = e.NewDate;
            int day = currentDate.Day;
            int month = currentDate.Month;
            int year = currentDate.Year;
          

            var webApi = RestService.For<IWebAPI>("http://192.168.1.102:8090/");
            List<CoalDateWiseModel> bauxitedatewise = await webApi.GetBauxiteDateMines(year, month, day);
            BauxiteData.Clear();
            BauxiteLineData.Clear();
            foreach (CoalDateWiseModel bauxitedatewisedata in bauxitedatewise)
            {
                CoalDateWiseModel bauxiteDateWiseModel = new CoalDateWiseModel
                {
                    dailyDespatch = 2243,
                    date = bauxitedatewisedata.date
                };
                BauxiteData.Add(bauxitedatewisedata);
                BauxiteLineData.Add(bauxiteDateWiseModel);
            }
            columnSeriesofbauxite.ItemsSource = BauxiteData;
            lineSeriesofbauxite.ItemsSource = BauxiteLineData;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var webApi = RestService.For<IWebAPI>("http://192.168.1.102:8090/");

            CoalBauxiteModel allBauxiteMines = await webApi.GetAllBauxiteMines();
            CoalBauxiteModel dispatchQtyBauxite = await webApi.GetDespatchQtyBauxiteMines();

            //For Bauxite Grid
            Label nameBauxiteLable = new Label { Text = allBauxiteMines.name, HorizontalTextAlignment = TextAlignment.Center, BackgroundColor = Color.LightBlue };
            bauxiteGrid.Children.Add(nameBauxiteLable, 0, 1);

            Label dailyBauxiteLable = new Label { Text = allBauxiteMines.daily.ToString(), HorizontalTextAlignment = TextAlignment.Center, BackgroundColor = Color.LightBlue };
            bauxiteGrid.Children.Add(dailyBauxiteLable, 1, 1);

            Label mtdBauxiteLable = new Label { Text = allBauxiteMines.mtd.ToString(), HorizontalTextAlignment = TextAlignment.Center, BackgroundColor = Color.LightBlue };
            bauxiteGrid.Children.Add(mtdBauxiteLable, 2, 1);

            Label ytdBauxiteLable = new Label { Text = allBauxiteMines.ytd.ToString(), HorizontalTextAlignment = TextAlignment.Center, BackgroundColor = Color.LightBlue };
            bauxiteGrid.Children.Add(ytdBauxiteLable, 3, 1);

            //For dispatchQty bauxite values
            Label nameBauxiteDispatchLable = new Label { Text = dispatchQtyBauxite.name, HorizontalTextAlignment = TextAlignment.Center, BackgroundColor = Color.LightBlue };
            bauxiteGrid.Children.Add(nameBauxiteDispatchLable, 0, 2);

            Label dailyBauxiteDispatchLable = new Label { Text = dispatchQtyBauxite.daily.ToString(), HorizontalTextAlignment = TextAlignment.Center, BackgroundColor = Color.LightBlue };
            percentageachieved = (dispatchQtyBauxite.daily / allBauxiteMines.daily) * 100;
            if (percentageachieved > 105)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "green_up_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(dailyBauxiteDispatchLable);
                bauxiteGrid.Children.Add(layout, 1, 2);
            }
            else if (percentageachieved <= 105 && percentageachieved >= 100)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "yellow_up_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(dailyBauxiteDispatchLable);
                bauxiteGrid.Children.Add(layout, 1, 2);
            }
            else if (percentageachieved <= 100 && percentageachieved >= 95)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "yellow_down_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(dailyBauxiteDispatchLable);
                bauxiteGrid.Children.Add(layout, 1, 2);
            }
            else if (percentageachieved < 95)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "red_down_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(dailyBauxiteDispatchLable);
                bauxiteGrid.Children.Add(layout, 1, 2);
            }


            Label mtdBauxiteDispatchLable = new Label { Text = dispatchQtyBauxite.mtd.ToString(), HorizontalTextAlignment = TextAlignment.Center, BackgroundColor = Color.LightBlue };
            percentageachieved = (dispatchQtyBauxite.mtd / allBauxiteMines.mtd) * 100;
            if (percentageachieved > 105)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "green_up_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(mtdBauxiteDispatchLable);
                bauxiteGrid.Children.Add(layout, 2, 2);
            }
            else if (percentageachieved <= 105 && percentageachieved >= 100)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "yellow_up_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(mtdBauxiteDispatchLable);
                bauxiteGrid.Children.Add(layout, 2, 2);
            }
            else if (percentageachieved <= 100 && percentageachieved >= 95)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "yellow_down_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(mtdBauxiteDispatchLable);
                bauxiteGrid.Children.Add(layout, 2, 2);
            }
            else if (percentageachieved < 95)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "red_down_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(mtdBauxiteDispatchLable);
                bauxiteGrid.Children.Add(layout, 2, 2);
            }


            Label ytdBauxiteDispatchLable = new Label { Text = dispatchQtyBauxite.ytd.ToString(), HorizontalTextAlignment = TextAlignment.Center, BackgroundColor = Color.LightBlue };
            percentageachieved = (dispatchQtyBauxite.ytd / allBauxiteMines.ytd) * 100;
            if (percentageachieved > 105)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "green_up_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(ytdBauxiteDispatchLable);
                bauxiteGrid.Children.Add(layout, 3, 2);
            }
            else if (percentageachieved <= 105 && percentageachieved >= 100)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "yellow_up_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(ytdBauxiteDispatchLable);
                bauxiteGrid.Children.Add(layout, 3, 2);
            }
            else if (percentageachieved <= 100 && percentageachieved >= 95)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "yellow_down_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(ytdBauxiteDispatchLable);
                bauxiteGrid.Children.Add(layout, 3, 2);
            }
            else if (percentageachieved < 95)
            {
                var layout = new StackLayout() { Orientation = StackOrientation.Horizontal, BackgroundColor = Color.LightBlue };
                var image = new Image { Source = "red_down_arrow.jpg" };
                layout.Children.Add(image);
                layout.Children.Add(ytdBauxiteDispatchLable);
                bauxiteGrid.Children.Add(layout, 3, 2);
            }


        }
    }
}

