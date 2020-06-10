using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutorisationTravail.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void Demande_Tapped(object sender, EventArgs e)
        {

        }
        private async void AddAT_Tapped(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AutorisationTravail.AddAutorisationTravail());
        }
        private async void ListAT_Tapped(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AutorisationTravail.ListAutorisationTravail());
        }
        private async void ListPermis_Tapped(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Permis.ListPermis());
        }
    }
}