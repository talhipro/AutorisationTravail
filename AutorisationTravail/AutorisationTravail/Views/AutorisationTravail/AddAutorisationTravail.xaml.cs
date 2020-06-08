using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutorisationTravail.Views.AutorisationTravail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAutorisationTravail : ContentPage
    {
        public AddAutorisationTravail()
        {
            InitializeComponent();
        }

        private async void AddRisques_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Popups.AddRisquesPopup());
        }

        private async void AddMesures_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Popups.AddMesuresPopup());
        }

        private async void AddMoyensAcces_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Popups.AddMoyensAccesPopup());
        }

        private async void AddEPI_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Popups.AddEPIPopup());
        }

        private async void AddPermis_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Popups.AddPermisPopup());
        }
    }
}