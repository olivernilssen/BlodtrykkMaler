
using BlodtrykkMaler.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlodtrykkMaler.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetMeasurementsAsync();

        }

        private void Stared_Clicked(object sender, System.EventArgs e)
        {
            // to come
        }
        private async void Delete_Clicked(object sender, System.EventArgs e)
        {
            var item = (Measurement)BindingContext;

            if (item == null)
            {
                await DisplayAlert("Error", "Målingen ble ikke slettet, kontakt admin", "ok");
            }
            else
            {
                int result = await App.Database.DeleteMeasurementAsync(item.Id);
                await DisplayAlert("Error", message: "Målingen" + item.Id + " ble slettet", "ok");
                listView.ItemsSource = await App.Database.GetMeasurementsAsync();
            }

        }

        private void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                BindingContext = e.SelectedItem as Measurement;
            }
        }

    }
}