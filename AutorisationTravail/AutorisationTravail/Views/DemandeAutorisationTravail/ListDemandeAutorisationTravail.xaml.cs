using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Shared.Models.AutorisationTravail;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace AutorisationTravail.Views.DemandeAutorisationTravail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListDemandeAutorisationTravail : ContentPage
    {
        public List<ListATModel> DemandesATList;
        public ObservableCollection<ListATModel> demandeList = new ObservableCollection<ListATModel>();
        public ObservableCollection<ListATModel> DemandeList
        {
            get
            {
                return demandeList;
            }
            set
            {
                value = demandeList;
                OnPropertyChanged();
            }
        }

        public ListDemandeAutorisationTravail()
        {
            InitializeComponent();
            DemandesATList = new List<ListATModel>();
            DemandesATList.Add(new ListATModel
            {
                AutorisationID = 1,
                AutorisationNum = "0039884",
                AutorisationSite = "safi",
                AutorisationEntite = "Entity 01",
                AutorisationService = "chimie",
                AutorisationDemandeur = "ibrahim alaoui ",
                AutorisationDate = DateTime.Parse("03/06/2020"),
                AutorisationDateIntervention = DateTime.Parse("05/06/2020"),
                AutorisationHeureDebut = "15:00",
                AutorisationHeureFin = "17:30",
                AutorisationStatut = "Draft",
                AutorisationStatutBgColor = "#F5F5F5",
                AutorisationStatutTxtColor = "#AEB4BF"
            });

            DemandesATList.Add(new ListATModel
            {
                AutorisationID = 2,
                AutorisationNum = "0029821",
                AutorisationSite = "khouribga",
                AutorisationEntite = "Entity 02",
                AutorisationService = "chimie",
                AutorisationDemandeur = "samir benmakhlouf ",
                AutorisationDate = DateTime.Parse("06/06/2020"),
                AutorisationDateIntervention = DateTime.Parse("09/06/2020"),
                AutorisationHeureDebut = "14:00",
                AutorisationHeureFin = "18:00",
                AutorisationStatut = "Validée",
                AutorisationStatutBgColor = "#FFF1F7",
                AutorisationStatutTxtColor = "#CF464A"
            });

            DemandesATList.Add(new ListATModel
            {
                AutorisationID = 3,
                AutorisationNum = "0048821",
                AutorisationSite = "safi",
                AutorisationEntite = "Entity 03",
                AutorisationService = "chimie",
                AutorisationDemandeur = "ibrahim alaoui ",
                AutorisationDate = DateTime.Parse("07/06/2020"),
                AutorisationDateIntervention = DateTime.Parse("08/06/2020"),
                AutorisationHeureDebut = "10:00",
                AutorisationHeureFin = "16:00",
                AutorisationStatut = "Validée",
                AutorisationStatutBgColor = "#F1FFF2",
                AutorisationStatutTxtColor = "#2CD920"
            });

            DemandesATList.Add(new ListATModel
            {
                AutorisationID = 4,
                AutorisationNum = "0025121",
                AutorisationSite = "Jorf",
                AutorisationEntite = "Entity 04",
                AutorisationService = "chimie",
                AutorisationDemandeur = "karim naji ",
                AutorisationDate = DateTime.Parse("06/06/2020"),
                AutorisationDateIntervention = DateTime.Parse("08/06/2020"),
                AutorisationHeureDebut = "12:00",
                AutorisationHeureFin = "17:00",
                AutorisationStatut = "Refusée",
                AutorisationStatutBgColor = "#FFEDE6",
                AutorisationStatutTxtColor = "#F67D49"
            });

            DemandesATList.Add(new ListATModel
            {
                AutorisationID = 5,
                AutorisationNum = "0025100",
                AutorisationSite = "Jorf",
                AutorisationEntite = "Entity 05",
                AutorisationService = "mécanique",
                AutorisationDemandeur = "soufiane tazi",
                AutorisationDate = DateTime.Parse("10/06/2020"),
                AutorisationDateIntervention = DateTime.Parse("12/06/2020"),
                AutorisationHeureDebut = "09:00",
                AutorisationHeureFin = "11:00",
                AutorisationStatut = "En attente",
                AutorisationStatutBgColor = "#FFEDE6",
                AutorisationStatutTxtColor = "#F67D49"
            });

            DemandesATList.Add(new ListATModel
            {
                AutorisationID = 6,
                AutorisationNum = "0025421",
                AutorisationSite = "Jorf",
                AutorisationEntite = "Entity 06",
                AutorisationService = "mécanique",
                AutorisationDemandeur = "soufiane tazi",
                AutorisationDate = DateTime.Parse("03/06/2020"),
                AutorisationDateIntervention = DateTime.Parse("05/06/2020"),
                AutorisationHeureDebut = "09:00",
                AutorisationHeureFin = "11:00",
                AutorisationStatut = "En attente",
                AutorisationStatutBgColor = "#8cc1fa",
                AutorisationStatutTxtColor = "#2583e8"
            });


        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            App.Current.On<Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            foreach (ListATModel m in DemandesATList)
            {
                DemandeList.Add(m);
            }

            myListe.ItemsSource = DemandeList;
        }
        private void GetDemandeByStatus(string status)
        {

            ObservableCollection<ListATModel> filtredList = new ObservableCollection<ListATModel>();
            foreach (ListATModel demande in DemandesATList)
            {
                if (demande.AutorisationStatut.Equals(status))
                    filtredList.Add(demande);
            }
            demandeList.Clear();
            foreach (ListATModel m in filtredList)
            {
                DemandeList.Add(m);
            }


        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            App.Current.On<Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Pan);
        }

        private void Item_Tapped(object sender, EventArgs e)
        {
            var ItemContext = ((StackLayout)sender).BindingContext as ListATModel;

            if (ItemContext.DetailsColapse) ItemContext.DetailsColapse = false;
            else ItemContext.DetailsColapse = true;
        }
        private void myListe_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (myListe.SelectedItem != null)
            {
                myListe.SelectedItem = null;
            }
        }
        private async void BurgerMenu_Clicked(System.Object sender, System.EventArgs e)
        {

            await App.Current.MainPage.Navigation.PushAsync(new AddDemandeAutorisationTravail());
        }

        private async void NewDemandeATButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddDemandeAutorisationTravail());
        }
        private void SetTabbedBarButtonClicked(Label label, BoxView box)
        {
            label.TextColor = Color.FromHex("#7BCB09");
            box.BackgroundColor = Color.FromHex("#7BCB09");
        }
        void ResetTabbedBarButtons()
        {
            ValidatedDemandeLabel.TextColor = Color.Gray;
            ValidatedDemandeBox.BackgroundColor = Color.Transparent;

            PendingDemandeLabel.TextColor = Color.Gray;
            PendingDemandeBox.BackgroundColor = Color.Transparent;

            RefusedDemandeLabelle.TextColor = Color.Gray;
            RefusedDemandeBox.BackgroundColor = Color.Transparent;

            DraftDemandeLabel.TextColor = Color.Gray;
            DraftDemandeBox.BackgroundColor = Color.Transparent;
        }

        void Pending_Clicked(System.Object sender, System.EventArgs e)
        {
            ResetTabbedBarButtons();
            SetTabbedBarButtonClicked(PendingDemandeLabel, PendingDemandeBox);
            GetDemandeByStatus("En attente");
        }
        void Validated_Clicked(System.Object sender, System.EventArgs e)
        {
            ResetTabbedBarButtons();
            SetTabbedBarButtonClicked(ValidatedDemandeLabel, ValidatedDemandeBox);
            GetDemandeByStatus("Validée");
        }
        void Refused_Clicked(System.Object sender, System.EventArgs e)
        {
            ResetTabbedBarButtons();
            SetTabbedBarButtonClicked(RefusedDemandeLabelle, RefusedDemandeBox);
            GetDemandeByStatus("Refusée");
        }
        void Draft_Clicked(System.Object sender, System.EventArgs e)
        {
            ResetTabbedBarButtons();
            SetTabbedBarButtonClicked(DraftDemandeLabel, DraftDemandeBox);
            GetDemandeByStatus("Draft");

        }

        private async void Details_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new DemandeAutorisationDetails());
        }
    }
}
