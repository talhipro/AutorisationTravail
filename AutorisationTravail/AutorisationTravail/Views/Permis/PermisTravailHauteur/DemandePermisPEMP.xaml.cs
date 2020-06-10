using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutorisationTravail.Views.Permis.PermisTravailHauteur
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DemandePermisPEMP : ContentPage
    {
        public DemandePermisPEMP()
        {
            InitializeComponent();
        }

        private async void SendDemande_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddPermisPEMP());
        }
    }
}