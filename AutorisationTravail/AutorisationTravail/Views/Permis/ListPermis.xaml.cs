using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Models.Permis;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace AutorisationTravail.Views.Permis
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPermis : ContentPage
    {
        private ObservableCollection<PermisListModel> permisList = new ObservableCollection<PermisListModel>();
        public ObservableCollection<PermisListModel> PermisList
        {
            get
            {
                return permisList;
            }
            set
            {
                value = permisList;
                OnPropertyChanged();
            }
        }
        public ListPermis()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            App.Current.On<Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);

            PermisList.Add(new PermisListModel
            {
                NumAT = "0039884",
                Demandeur = "ibrahim alaoui",
                Type = "Permis de feu",
                StatutValue = "En cours de preparation",
                StatutColor = "#dbdbdb",
                CreatedDate = "05/07/2020"
            });
            PermisList.Add(new PermisListModel
            {
                NumAT = "0039884",
                Demandeur = "samir benmakhlouf",
                Type = "Permis de fouille",
                StatutValue = "Attente Validation",
                StatutColor = "Accent",
                CreatedDate = "09/06/2020"
            });
            PermisList.Add(new PermisListModel
            {
                NumAT = "0039884",
                Demandeur = "samir benmakhlouf",
                Type = "Permis de pénétration dans un espace confiné",
                StatutValue = "Validé",
                StatutColor = "LightGreen",
                CreatedDate = "09/06/2020"
            });
            PermisList.Add(new PermisListModel
            {
                NumAT = "0039884",
                Demandeur = "ibrahim alaoui",
                Type = "Permis de Travail en Hauteur avec EPI",
                StatutValue = "En cours de preparation",
                StatutColor = "#dbdbdb",
                CreatedDate = "05/07/2020"
            });

            myListe.ItemsSource = PermisList;
        }

        private void myListe_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (myListe.SelectedItem != null)
            {
                myListe.SelectedItem = null;
            }
        }

        private async void NewPermis_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync( new Popups.MenuPermis());
        }
    }
}