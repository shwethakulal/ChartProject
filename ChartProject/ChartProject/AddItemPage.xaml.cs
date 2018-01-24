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
            if (txtName.Text != null && txtDaily.Text != null && txtMtd.Text != null && txtYtd.Text != null)
            {
                Item additem = new Item();
                additem.name = txtName.Text;
                additem.daily = Int64.Parse(txtDaily.Text);
                additem.mtd = Int64.Parse(txtMtd.Text);
                additem.ytd = Int64.Parse(txtYtd.Text);
                await App.Database.SaveItemAsync(additem);
                txtName.Text = "";
                txtDaily.Text = "";
                txtMtd.Text = "";
                txtYtd.Text = "";
                lblName.IsVisible = true;
            }
            else
            {
                await DisplayAlert("Alert", "Please fill all the fields", "ok");
            }
        }
        public async void ViewItems(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new MainPage()));
        }
        public async void ViewAlbumData(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new AlbumDataPage()));
        }
    }
}