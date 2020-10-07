using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Models.DemandeAutorisation;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutorisationTravail.Views.DemandeAutorisationTravail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DemandeAutorisationDetails : ContentPage
    {
        public DemandeDetailsModel DemandeDetails { get; set; }
        public DemandeAutorisationDetails()
        {
            InitializeComponent();

            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DemandeDetails = new DemandeDetailsModel()
            {
                NumDemande = "0037483",
                Description = "Lorem ipsum doloaliquamr sit amet, consectetur adicing elit." +
                " Aliquam sollicitudinaliquam congue arcu," +
                " aliquam tristique aliquam ornare dolor commodo aliquam. Sed nec libero nisl.",
                CreateDate = "28/10/2020",
                CEEE = "Khalid bouajaadi",
                DateIntervention = "30/10/2020",
                EntiteExec = "Chimie",
                EntiteProp = "Safi",
                Entreprises = "CENTRELEC",
                HeureDebut = "07h00",
                HeureFin = "15h30",
                Lieu = "Le lieu de l'intervention",
                OTNum = "148/19",
                Services = "Services",
                Site = "Jorf Lasfar"
            };
        }



        private async void BackBtn_Tapped(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private void ButtonValider_Clicked(object sender, EventArgs e)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Popups.ValiderDemandeAT());
        }

        private void ButtonRefuser_Clicked(object sender, EventArgs e)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Popups.RefuserDemandeAT());
        }
    }
}