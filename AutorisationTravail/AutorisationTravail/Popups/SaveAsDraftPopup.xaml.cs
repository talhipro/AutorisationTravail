using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutorisationTravail.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SaveAsDraftPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public SaveAsDraftPopup()
        {
            InitializeComponent();
        }

        private async void SaveAsDraft_Tapped(System.Object sender, System.EventArgs e)
        {
        }

        private async void CancelDraft_Tapped(System.Object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
        private async void DeleteDraft_Tapped(System.Object sender, System.EventArgs e)
        {
            bool answer = await DisplayAlert("", "Voulez-vous vraiment annuler la demande?", "OUI", "NON");
        }
    }
}
