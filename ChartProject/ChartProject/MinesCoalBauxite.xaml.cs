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
            var webApi = RestService.For<IWebAPI>("http://1.1.1.16:8090/");
            CoalBauxiteModel allMines = await webApi.GetAllMines();                       

               Label nameLable = new Label { Text = allMines.name };
               minesGrid.Children.Add(nameLable, 0, 1);

                Label dailyLable = new Label { Text = allMines.daily.ToString() };
                minesGrid.Children.Add(dailyLable,1,1);
                
                Label mtdLable = new Label { Text = allMines.mtd.ToString() };
                minesGrid.Children.Add(mtdLable,2,1);              
               
                Label ytdLable = new Label { Text = allMines.ytd.ToString() };
                minesGrid.Children.Add(ytdLable,3,1);
                
            }

        }
    }
