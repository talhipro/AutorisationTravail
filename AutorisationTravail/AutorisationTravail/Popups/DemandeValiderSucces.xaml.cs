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
    public partial class DemandeValiderSucces : Rg.Plugins.Popup.Pages.PopupPage
    {
        public DemandeValiderSucces()
        {
            InitializeComponent();
        }

        private async void DemandesAT_Clicked(object sender, EventArgs e)
        {
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
            await App.Current.MainPage.Navigation.PushAsync(new Views.DemandeAutorisationTravail.ListDemandeAutorisationTravail());
        }
    }
}