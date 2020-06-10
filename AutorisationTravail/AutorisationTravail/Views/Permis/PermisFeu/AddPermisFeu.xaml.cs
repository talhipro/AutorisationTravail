using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutorisationTravail.Views.Permis
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPermisFeu : ContentPage
    {
        public AddPermisFeu()
        {
            InitializeComponent();
        }

        private async void RisqueOui_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if(e.Value)
            await Application.Current.MainPage.DisplayAlert("Info!", "Après l'enregistrement du permis une notification sera envoyée à l'Hse Site pour avoir la validation du ce Permis!", "Ok");
        }
    }
}