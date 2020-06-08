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
    public partial class AddPermisPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public AddPermisPopup()
        {
            InitializeComponent();
        }

        private async void ClosePopup_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
                ListPermisHauteur.IsVisible = true;
            else
                ListPermisHauteur.IsVisible = false;
        }
    }
}