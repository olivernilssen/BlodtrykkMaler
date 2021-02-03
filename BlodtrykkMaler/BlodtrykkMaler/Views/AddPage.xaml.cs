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

        /// <summary>
        /// Save button, saves entered values into database if both are filled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var measurements = (Measurement)BindingContext;

            //Check to make sure the input fields are both populated
            if (string.IsNullOrWhiteSpace(DiastolicEntry.Text) || string.IsNullOrWhiteSpace(SystolicEntry.Text))
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Info", "Du må fylle inn begge feltene", "Ok");
                });
            }
            else
            {
                int Id = await App.Database.SaveMeasurmentAsync(new Measurement
                {
                    Systolic = int.Parse(SystolicEntry.Text),
                    Diastolic = int.Parse(DiastolicEntry.Text),
                    Date = DateTime.Now.Date,
                    DateString = DateTime.Now.ToString("dd/MM/yy")
                }); ;

                // If the database didn't manage to add a use, we will get an error
                if (Id < 0)
                {
                    throw new Exception("The Measurment wasn't saved correctly");
                }
                else
                {
                    //Bind the details of the new Measurement and go to the Detailspage with more info about this measurement
                    var newMeasurment = await App.Database.GetMeasurementAsync(Id);
                    var detailPage = new DetailPage
                    {
                        BindingContext = newMeasurment
                    };

                    await Navigation.PushModalAsync(detailPage);

                    SystolicEntry.Text = DiastolicEntry.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// Clear button, clears the input text fields for the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnClearButtonClicked(object sender, EventArgs e)
        {
            SystolicEntry.Text = DiastolicEntry.Text = string.Empty;
        }
    }
}