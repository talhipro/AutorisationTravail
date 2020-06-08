using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Shared.Models;


using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace AutorisationTravail.Views.AutorisationTravail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListAutorisationTravail : ContentPage
    {
        public ListAutorisationTravail()
        {
            InitializeComponent();
        }

        private ObservableCollection<ListATModel> demandeList = new ObservableCollection<ListATModel>();
        public ObservableCollection<ListATModel> DemandeList { get { return demandeList; } set { value = demandeList; OnPropertyChanged(); } }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            App.Current.On<Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);

            DemandeList.Add(new ListATModel { AutorisationID = 1, AutorisationNum = "0039884", AutorisationSite = "safi", AutorisationEntite = "Entity 01", AutorisationService = "chimie", AutorisationDemandeur = "ibrahim alaoui ", AutorisationDate = DateTime.Parse("03/06/2020"),  AutorisationDateIntervention = DateTime.Parse("05/06/2020"), AutorisationHeureDebut = "15:00", AutorisationHeureFin = "17:30", AutorisationStatut = "Draft", AutorisationStatutColor = "#d92027" });

            DemandeList.Add(new ListATModel { AutorisationID = 2, AutorisationNum = "0029821", AutorisationSite = "khouribga", AutorisationEntite = "Entity 02", AutorisationService = "chimie", AutorisationDemandeur = "samir benmakhlouf ", AutorisationDate = DateTime.Parse("06/06/2020"), AutorisationDateIntervention = DateTime.Parse("09/06/2020"), AutorisationHeureDebut = "14:00", AutorisationHeureFin = "18:00", AutorisationStatut = "Attente permis", AutorisationStatutColor = "#40bad5" });

            DemandeList.Add(new ListATModel { AutorisationID = 3, AutorisationNum = "0048821", AutorisationSite = "safi", AutorisationEntite = "Entity 03", AutorisationService = "chimie", AutorisationDemandeur = "ibrahim alaoui ", AutorisationDate = DateTime.Parse("07/06/2020"), AutorisationDateIntervention = DateTime.Parse("08/06/2020"), AutorisationHeureDebut = "10:00", AutorisationHeureFin = "16:00", AutorisationStatut = "En exécution", AutorisationStatutColor = "#f9d89c" });

            DemandeList.Add(new ListATModel { AutorisationID = 4, AutorisationNum = "0025121", AutorisationSite = "Jorf", AutorisationEntite = "Entity 04", AutorisationService = "chimie", AutorisationDemandeur = "karim naji ", AutorisationDate = DateTime.Parse("06/06/2020"), AutorisationDateIntervention = DateTime.Parse("08/06/2020"), AutorisationHeureDebut = "12:00", AutorisationHeureFin = "17:00", AutorisationStatut = "Attente Validation", AutorisationStatutColor = "#feceab" });

            DemandeList.Add(new ListATModel { AutorisationID = 5, AutorisationNum = "0025100", AutorisationSite = "Jorf", AutorisationEntite = "Entity 05", AutorisationService = "mécanique", AutorisationDemandeur = "soufiane tazi", AutorisationDate = DateTime.Parse("10/06/2020"), AutorisationDateIntervention = DateTime.Parse("06/15/2020"), AutorisationHeureDebut = "09:00", AutorisationHeureFin = "11:00", AutorisationStatut = "Attente réception", AutorisationStatutColor = "#0a97b0" });

            DemandeList.Add(new ListATModel { AutorisationID = 6, AutorisationNum = "0025421", AutorisationSite = "Jorf", AutorisationEntite = "Entity 06", AutorisationService = "mécanique", AutorisationDemandeur = "soufiane tazi", AutorisationDate = DateTime.Parse("03/06/2020"), AutorisationDateIntervention = DateTime.Parse("05/06/2020"), AutorisationHeureDebut = "09:00", AutorisationHeureFin = "11:00", AutorisationStatut = "Réceptionné", AutorisationStatutColor = "#99b898" });

            myListe.ItemsSource = DemandeList;


        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            App.Current.On<Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Pan);
        }

        private void Recherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterItem(search.Text);
        }

        private void FilterItem(string filter)
        {
        }

        private void myListe_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (myListe.SelectedItem != null)
            {
                myListe.SelectedItem = null;
            }
        }
    }
}