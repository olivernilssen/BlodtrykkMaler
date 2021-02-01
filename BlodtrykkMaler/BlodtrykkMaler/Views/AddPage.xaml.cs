using BlodtrykkMaler.Models;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlodtrykkMaler.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var measurements = (Measurement)BindingContext;

            if (string.IsNullOrWhiteSpace(DiastolicEntry.Text) || string.IsNullOrWhiteSpace(SystolicEntry.Text))
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    Debug.WriteLine("No input in entry fields");
                    await DisplayAlert("Info", "Du må fylle inn begge feltene", "Ok");
                });
            }
            else
            {
                await App.Database.SaveMeasurmentAsync(new Measurement
                {
                    Systolic = int.Parse(SystolicEntry.Text),
                    Diastolic = int.Parse(DiastolicEntry.Text),
                    Date = DateTime.Now.Date,
                    DateString = DateTime.Now.ToString("MM/dd/yy")
                }); ;

                SystolicEntry.Text = DiastolicEntry.Text = string.Empty;
            }
        }

        void OnClearButtonClicked(object sender, EventArgs e)
        {
            SystolicEntry.Text = DiastolicEntry.Text = string.Empty;
        }
    }
}