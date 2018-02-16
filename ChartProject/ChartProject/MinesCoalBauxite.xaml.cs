using Refit;
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
	public partial class MinesCoalBauxite : ContentPage
	{
		public MinesCoalBauxite ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var webApi = RestService.For<IWebAPI>("http://1.1.1.21:8090/");
            CoalBauxiteModel allCoalMines = await webApi.GetAllCoalMines();
            CoalBauxiteModel allBauxiteMines = await webApi.GetAllBauxiteMines();
            CoalBauxiteModel dispatchQtyCoal = await webApi.GetDespatchQtyCoalMines();
            CoalBauxiteModel dispatchQtyBauxite = await webApi.GetDespatchQtyBauxiteMines();

            //For Coal Grid
            Label nameCoalLable = new Label { Text = allCoalMines.name };
            coalGrid.Children.Add(nameCoalLable, 0, 1);

            Label dailyCoalLable = new Label { Text = allCoalMines.daily.ToString() };
            coalGrid.Children.Add(dailyCoalLable, 1,1);
                
            Label mtdCoalLable = new Label { Text = allCoalMines.mtd.ToString() };
            coalGrid.Children.Add(mtdCoalLable, 2,1);              
               
            Label ytdCoalLable = new Label { Text = allCoalMines.ytd.ToString() };
            coalGrid.Children.Add(ytdCoalLable, 3,1);

            //For dispatchQty coal values
            Label nameCoalDispatchLable = new Label { Text = dispatchQtyCoal.name };
            coalGrid.Children.Add(nameCoalDispatchLable, 0, 2);

            Label dailyCoalDispatchLable = new Label { Text = dispatchQtyCoal.daily.ToString() };
            coalGrid.Children.Add(dailyCoalDispatchLable, 1, 2);

            Label mtdCoalDispatchLable = new Label { Text = dispatchQtyCoal.mtd.ToString() };
            coalGrid.Children.Add(mtdCoalDispatchLable, 2, 2);

            Label ytdCoalDispatchLable = new Label { Text = dispatchQtyCoal.ytd.ToString() };
            coalGrid.Children.Add(ytdCoalDispatchLable, 3, 2);

            //For Bauxite Grid
            Label nameBauxiteLable = new Label { Text = allBauxiteMines.name };
            bauxiteGrid.Children.Add(nameBauxiteLable, 0, 1);

            Label dailyBauxiteLable = new Label { Text = allBauxiteMines.daily.ToString() };
            bauxiteGrid.Children.Add(dailyBauxiteLable, 1, 1);

            Label mtdBauxiteLable = new Label { Text = allBauxiteMines.mtd.ToString() };
            bauxiteGrid.Children.Add(mtdBauxiteLable, 2, 1);

            Label ytdBauxiteLable = new Label { Text = allBauxiteMines.ytd.ToString() };
            bauxiteGrid.Children.Add(ytdBauxiteLable, 3, 1);

            //For dispatchQty bauxite values
            Label nameBauxiteDispatchLable = new Label { Text = dispatchQtyBauxite.name };
            bauxiteGrid.Children.Add(nameBauxiteDispatchLable, 0, 2);

            Label dailyBauxiteDispatchLable = new Label { Text = dispatchQtyBauxite.daily.ToString() };
            bauxiteGrid.Children.Add(dailyBauxiteDispatchLable, 1, 2);

            Label mtdBauxiteDispatchLable = new Label { Text = dispatchQtyBauxite.mtd.ToString() };
            bauxiteGrid.Children.Add(mtdBauxiteDispatchLable, 2, 2);

            Label ytdBauxiteDispatchLable = new Label { Text = dispatchQtyBauxite.ytd.ToString() };
            bauxiteGrid.Children.Add(ytdBauxiteDispatchLable, 3, 2);

        }

        }
    }
