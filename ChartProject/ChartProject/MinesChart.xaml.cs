using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
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
		public MinesChart ()
		{
			InitializeComponent ();
            mineschart.PrimaryAxis = new DateTimeAxis()
            {
                IntervalType = DateTimeIntervalType.Days,
                Interval = 1,


                Minimum = new DateTime(2018, 1, 18),
                Maximum = new DateTime(2018, 1, 4)

            };
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var webApi = RestService.For<IWebAPI>("http://1.1.1.21:8090/");
            List<Employee> employees = await webApi.GetAllEmployees();
            employeeData.Clear();
            foreach (Employee emp in employees)
            {
                employeeData.Add(emp);
            }


        }
    }
}