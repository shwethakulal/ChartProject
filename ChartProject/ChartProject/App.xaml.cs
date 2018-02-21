using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ChartProject
{
	public partial class App : Application
	{
        static ItemDatabase database;
        public App ()
		{
			InitializeComponent();
         
            MainPage = new NavigationPage(new ChartProject.MinesChart());

        }

        public static ItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("ChartSQLite.db3"));
                }
                return database;
            }
        }
        protected override void OnStart ()
		{
          
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
