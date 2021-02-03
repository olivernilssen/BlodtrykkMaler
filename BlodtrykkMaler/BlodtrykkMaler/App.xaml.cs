using BlodtrykkMaler.Database;
using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlodtrykkMaler
{
    public partial class App : Application
    {
        static MeasurmentsDb database;
        public static MeasurmentsDb Database
        {
            //initialize the databse when we start our application
            get
            {
                if (database == null)
                {
                    database = new MeasurmentsDb(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "measurments.db3"));
                }

                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
    }
}
