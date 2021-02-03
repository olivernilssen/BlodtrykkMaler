
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

        /// <summary>
        /// When the view/page appears, load the Measurments from database
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetMeasurementsByDateAsync();

        }

        /// <summary>
        /// On list item tapped. Push modal with a new detail screen specific for this measurement
        /// </summary>
        private async void OnListItemTapped(object sender, ItemTappedEventArgs e)
        {
            //Only do this is there are details inside the item tapped
            if (e.Item != null)
            {
                var detailPage = new DetailPage();
                detailPage.BindingContext = e.Item as Measurement;
                listView.SelectedItem = null;
                await Navigation.PushModalAsync(detailPage);
            }
        }
    }
}