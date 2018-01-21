using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChartProject
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
           
		}


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //Item additem = new Item
            //{
            //    daily = 5619,
            //    mtd = 2900,
            //    ytd = 67676,
            //    name = "truck"
            //};
            //await App.Database.SaveItemAsync(additem);
            List<Item> items = await App.Database.GetItemsAsync();
            if (items.Count > 0)
            {
                Item item = items[0];
                Label nameLable = new Label { Text=item.name};
                itemGrid.Children.Add(nameLable,0,1);
                Label dailyLable = new Label { Text = item.daily.ToString() };       
                itemGrid.Children.Add(dailyLable, 1, 1);
                Label mtdLable = new Label { Text = item.mtd.ToString() };
                itemGrid.Children.Add(mtdLable, 2, 1);
                Label ytdLable = new Label { Text = item.ytd.ToString() };
                itemGrid.Children.Add(ytdLable, 3, 1);
            }


        }

    }
}
