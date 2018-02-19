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
        public ObservableCollection<CoalBauxiteModel> CoalData = new ObservableCollection<CoalBauxiteModel>();
        public MinesChart()
        {
            InitializeComponent();

            //mineschart.PrimaryAxis = new DateTimeAxis()
            //{
            //    IntervalType = DateTimeIntervalType.Days,
            //    Interval = 1,
            //    Minimum = new DateTime(2018, 1, 18),
            //    Maximum = new DateTime(2018, 1, 14)

            //};
            columnSeries.ItemsSource = CoalData;

        }
        private async void datepicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime currentDate = e.NewDate;
            int day = currentDate.Day;
            int month = currentDate.Month;
            int year = currentDate.Year;
            var webApi = RestService.For<IWebAPI>("http://1.1.1.19:8090/");
            CoalBauxiteModel CoalDateMines = await webApi.GetCurrentDateMines(year, month, day);
            CoalData.Clear();
            CoalData.Add(CoalDateMines);
            columnSeries.ItemsSource = CoalData;
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