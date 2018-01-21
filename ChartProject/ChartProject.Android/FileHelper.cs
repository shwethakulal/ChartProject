﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;

using Android.Runtime;
using Android.Views;
using Android.Widget;
using ChartProject.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace ChartProject.Droid
{
    public class FileHelper : IFileHelper
    {

        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}