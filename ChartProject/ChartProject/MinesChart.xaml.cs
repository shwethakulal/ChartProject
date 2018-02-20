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
        public ObservableCollection<CoalDateWiseModel> BauxiteData = new ObservableCollection<CoalDateWiseModel>();
        public MinesChart()
        {
            InitializeComponent();
            minescoalchart.PrimaryAxis = new DateTimeAxis()
            {
                IntervalType = DateTimeIntervalType.Days,
                Interval = 1,
                LabelRotationAngle=300,
                //Minimum = new DateTime(2018, 1, 18),
                //Maximum = new DateTime(2018, 1, 3)

            };
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
            var webApi = RestService.For<IWebAPI>("http://1.1.1.19:8090/");
            List<CoalDateWiseModel> coaldatewise = await webApi.GetCoalDateMines(year, month, day);
            List<CoalDateWiseModel> bauxitedatewise = await webApi.GetBauxiteDateMines(year, month, day);
            CoalData.Clear();
            foreach (CoalDateWiseModel coaldatewisedata in coaldatewise) {
                CoalData.Add(coaldatewisedata);
            }
            columnSeriesofcoal.ItemsSource = CoalData;
            lineSeriesofcoal.ItemsSource = CoalData;
            BauxiteData.Clear();
            foreach (CoalDateWiseModel bauxitedatewisedata in bauxitedatewise)
            {
                BauxiteData.Add(bauxitedatewisedata);
            }
            columnSeriesofbauxite.ItemsSource = BauxiteData;
            lineSeriesofbauxite.ItemsSource = BauxiteData;
        }


        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    var webApi = RestService.For<IWebAPI>("http://1.1.1.21:8090/");
        //    CoalBauxiteModel coalmines = await webApi.GetDespatchQtyCoalMines();

        //    //CoalData.Add(coalmines);


        //}
    }
}