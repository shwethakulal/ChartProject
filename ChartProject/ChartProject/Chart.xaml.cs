using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChartProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Chart : ContentPage
    {
        
        public ObservableCollection<Employee> employeeData = new ObservableCollection<Employee>();
        public Chart()
        {
            InitializeComponent();
            columnSeries.ItemsSource = employeeData;
            lineSeries.ItemsSource = employeeData;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var webApi = RestService.For<IWebAPI>("http://192.168.1.100:8090/");
            List<Employee> employees = await webApi.GetAllEmployees();
            employeeData.Clear();
            foreach (Employee emp in employees)
            {
                employeeData.Add(emp);
            }


        }
    }
}