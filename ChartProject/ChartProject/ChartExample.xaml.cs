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
    public partial class ChartExample : ContentPage
    {
        public ObservableCollection<CoalDateWiseModel> CoalData = new ObservableCollection<CoalDateWiseModel>();
        public ObservableCollection<CoalDateWiseModel> CoalLineData = new ObservableCollection<CoalDateWiseModel>();
        private double width = 0;
        private double height = 0;

        public ChartExample()
        {
            InitializeComponent();
            minescoalchart.PrimaryAxis = new DateTimeAxis()
            {
                IntervalType = DateTimeIntervalType.Days,
                Interval = 1,
                LabelRotationAngle = 300,
                //Minimum = new DateTime(2018, 1, 18),
                //Maximum = new DateTime(2018, 1, 3),
                AutoScrollingDelta = 3,
                AutoScrollingDeltaType = DateTimeDeltaType.Days
               
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

            var webApi = RestService.For<IWebAPI>("http://192.168.43.25:8090/");
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
    }
}