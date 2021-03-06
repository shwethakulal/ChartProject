﻿using System;
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
            
            List<Item> items = await App.Database.GetItemsAsync();
            for(int i=0;i<items.Count;i++)
            {
                Item item = items[i];
                Label nameLable = new Label { Text = item.name };
                itemGrid.Children.Add(nameLable, 0, i+1);
                Label dailyLable = new Label { Text = item.daily.ToString() };
                if (i == 1)
                {
                    var layout = new StackLayout() { Orientation=StackOrientation.Horizontal};
                    var image = new Image { Source = "green_arrow.jpg" };
                    layout.Children.Add(image);
                    layout.Children.Add(dailyLable);
                    itemGrid.Children.Add(layout, 1, i + 1);
                }
                else
                {

                    itemGrid.Children.Add(dailyLable, 1, i + 1);
                }
                Label mtdLable = new Label { Text = item.mtd.ToString() };
                if (i == 1)
                {
                    var layout = new StackLayout() { Orientation = StackOrientation.Horizontal };
                    var image = new Image { Source = "red_arrow.jpg" };
                    layout.Children.Add(image);
                    layout.Children.Add(mtdLable);
                    itemGrid.Children.Add(layout, 2, i + 1);
                }
                else
                {
                    itemGrid.Children.Add(mtdLable, 2, i + 1);
                }                              
                Label ytdLable = new Label { Text = item.ytd.ToString() };
                if (i == 1)
                {
                    var layout = new StackLayout() { Orientation = StackOrientation.Horizontal };
                    var image = new Image { Source = "yellow_arrow.jpg" };
                    layout.Children.Add(image);
                    layout.Children.Add(ytdLable);
                    itemGrid.Children.Add(layout, 3, i + 1);
                }
                else
                {
                    itemGrid.Children.Add(ytdLable, 3, i + 1);
                }
            }

        }

    }
}
