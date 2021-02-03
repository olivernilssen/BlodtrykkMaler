
using SkiaSharp;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using BlodtrykkMaler.Models;
using System.Linq;

namespace BlodtrykkMaler.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GraphPage : ContentPage
    {
        
        public GraphPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When the page appears we want to get the database entries and render them to a chart
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var Measurments = App.Database.GetMeasurementsAsync().Result;

            //Two lists with one bloodpressure value each
            var diastolicEntires = new List<ChartEntry>();
            var systolicEntires = new List<ChartEntry>();

            //Populate the entries
            foreach (Measurement item in Measurments)
            {
                systolicEntires.Add(
                    new ChartEntry(item.Systolic)
                    {
                        Color = SKColor.Parse("#f8961e")
                    }
                );

                diastolicEntires.Add(
                    new ChartEntry(item.Diastolic)
                    {
                        Color = SKColor.Parse("#43aa8b")
                    }
                );
            }

            //Diastolic linechart properties
            DiastolicChart.Chart = new LineChart() {
                Entries = diastolicEntires,
                LineMode = LineMode.Spline,
                LineSize = 10,
                PointMode = PointMode.Circle,
                PointSize = 40,
                MinValue = 40,
                MaxValue = 170,
                BackgroundColor = SKColor.Empty
            };

            //Systolic linechart properties
            SystolicChart.Chart = new LineChart()
            {
                Entries = systolicEntires,
                LineMode = LineMode.Spline,
                LineSize = 10,
                PointMode = PointMode.Circle,
                PointSize = 40,
                MinValue = 40,
                MaxValue = 170,
                BackgroundColor = SKColor.Empty
            };
        }
    }
}