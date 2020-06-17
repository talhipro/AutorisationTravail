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
                PermisNumAT = "0039884",
                PermisDemandeur = "ibrahim alaoui",
                PermisType = "Permis de feu",
                PermisStatutValue = "En cours de preparation",
                PermisStatutBgColor = "#F5F5F5",
                PermisStatutTxtColor = "#AEB4BF",
                PermisDate = "05/07/2020",
                PermisEntite = "Entité 01",
                PermisService = "Service 01"
            });
            PermisList.Add(new PermisListModel
            {
                PermisNumAT = "0039884",
                PermisDemandeur = "samir benmakhlouf",
                PermisType = "Permis de fouille",
                PermisStatutValue = "Attente Validation",
                PermisStatutBgColor = "#FFEDE6",
                PermisStatutTxtColor = "#F67D49",
                PermisDate = "09/06/2020",
                PermisEntite = "Entité 02",
                PermisService = "Service 02"
            });
            PermisList.Add(new PermisListModel
            {
                PermisNumAT = "0039884",
                PermisDemandeur = "samir benmakhlouf",
                PermisType = "Permis de pénétration dans un espace confiné",
                PermisStatutValue = "Validé",
                PermisStatutBgColor = "#F1FFF2",
                PermisStatutTxtColor = "#2CD920",
                PermisDate = "09/06/2020",
                PermisEntite = "Entité 03",
                PermisService = "Service 03"
            });
            PermisList.Add(new PermisListModel
            {
                PermisNumAT = "0039884",
                PermisDemandeur = "ibrahim alaoui",
                PermisType = "Permis de Travail en Hauteur avec EPI",
                PermisStatutValue = "En cours de preparation",
                PermisStatutBgColor = "#F5F5F5",
                PermisStatutTxtColor = "#AEB4BF",
                PermisDate = "05/07/2020",
                PermisEntite = "Entité 04",
                PermisService = "Service 04"
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
        private void Item_Tapped(object sender, EventArgs e)
        {
            var ItemContext = ((StackLayout)sender).BindingContext as PermisListModel;

            if (ItemContext.DetailsColapse) ItemContext.DetailsColapse = false;
            else ItemContext.DetailsColapse = true;
        }
    }
}