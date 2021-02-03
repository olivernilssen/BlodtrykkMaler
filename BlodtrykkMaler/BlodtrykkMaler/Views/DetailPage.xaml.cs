using BlodtrykkMaler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlodtrykkMaler.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Dismiss the current popped navigation page and go back to the previous one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        async void OnDismissButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Delete button to delete this specific entry from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void onDeleteButtonClickedAsync(object sender, EventArgs e)
        {
            var item = (Measurement)BindingContext;

            //Send error message to user if the content page can't find measurment
            if (item == null)
            {
                await DisplayAlert("Error", "Målingen ble ikke slettet, kontakt admin", "ok");
            }
            else
            {
                int result = await App.Database.DeleteMeasurementAsync(item.Id);

                //Inform the user if the entry was deleted from database
                if (result == 0)
                {
                    await DisplayAlert("Error", "Målingen ble ikke slettet, kontakt admin", "ok");
                }
                else
                {
                    await DisplayAlert("Error", message: "Målinge " + item.Id + " ble slettet", "ok");
                    await Navigation.PopModalAsync();
                }
            }
        }

    }
}