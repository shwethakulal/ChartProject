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
    public partial class AddItemPage : ContentPage
    {

        public AddItemPage()
        {
            InitializeComponent();


        }

        public async void AddNewItem(object sender, EventArgs e)
        {
            Item additem = new Item();
            additem.name = txtName.Text;
            additem.daily = Int32.Parse(txtDaily.Text);
            additem.mtd = Int32.Parse(txtMtd.Text);
            additem.ytd = Int32.Parse(txtYtd.Text);
            await App.Database.SaveItemAsync(additem);
            txtName.Text = "";
            txtDaily.Text = "";
            txtMtd.Text = "";
            txtYtd.Text = "";
            lblName.IsVisible = true;
        }
        public async void ViewItems(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new MainPage()));
        }
    }
}