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
            get
            {
                if (database == null)
                {
                    database = new MeasurmentsDb(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "measurments.db3"));
                }

                Debug.WriteLine("testing testing");
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
