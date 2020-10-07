using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutorisationTravail.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RefuserDemandeAT : Rg.Plugins.Popup.Pages.PopupPage
    {
        public RefuserDemandeAT()
        {
            InitializeComponent();
        }

        private void Annuler_Clicked(object sender, EventArgs e)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }

        private async void Envoyer_Clicked(object sender, EventArgs e)
        {
            //Code to send Comment

            var Confirmation =  await Application.Current.MainPage.DisplayAlert("", "Voulez‑vous vraiment envoyer votre commentaire ? ", "OUI", "NON");

            if(Confirmation)
            {
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new CommentSendSucces());
            }
        }
    }
}