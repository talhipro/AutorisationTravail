using Rg.Plugins.Popup.Services;
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
    public partial class MenuPermis : Rg.Plugins.Popup.Pages.PopupPage
    {
        public MenuPermis()
        {
            InitializeComponent();
        }

        private async void PermisFeu_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Views.Permis.AddPermisFeu());
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }

        private async void PermisPEMP_Clicked(object sender, EventArgs e)
        {
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
            await Application.Current.MainPage.Navigation.PushAsync(new Views.Permis.PermisTravailHauteur.DemandePermisPEMP());
        }

        private async void PermisPenetration_Clicked(object sender, EventArgs e)
        {
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
            await Application.Current.MainPage.Navigation.PushAsync(new Views.Permis.PermisPenetrationEspaceConfine.DemandePermisPenetrationEspaceConfine());
        }

        private async void ClosePopup_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}