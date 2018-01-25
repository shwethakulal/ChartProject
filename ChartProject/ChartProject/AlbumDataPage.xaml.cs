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
    public partial class AlbumDataPage : ContentPage
    {
        public AlbumDataPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            albumGrid.RowDefinitions = new RowDefinitionCollection();
            var albumApi = RestService.For<IAlbumAPI>("http://jsonplaceholder.typicode.com");
            try
            {              
                List<Album> userId = await albumApi.GetAllAlbums();
                for (int i = 0; i < userId.Count; i++)
                {
                    Album album = userId[i];
                    albumGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50,GridUnitType.Absolute) });
                    Label userid = new Label { Text = album.userId.ToString() };
                    albumGrid.Children.Add(userid, 0, i + 1);
                    Label id = new Label { Text = album.id.ToString() };
                    albumGrid.Children.Add(id, 1, i + 1);
                    Label title = new Label { Text = album.title };
                    albumGrid.Children.Add(title, 2, i + 1);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}