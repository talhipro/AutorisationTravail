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
    public partial class ValiderDemandeAT : Rg.Plugins.Popup.Pages.PopupPage
    {
        public ValiderDemandeAT()
        {
            InitializeComponent();
        }

        private void Non_Clicked(object sender, EventArgs e)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }

        private void Oui_Clicked(object sender, EventArgs e)
        {
            // Code to validate this demande.
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new DemandeValiderSucces());
        }
    }
}