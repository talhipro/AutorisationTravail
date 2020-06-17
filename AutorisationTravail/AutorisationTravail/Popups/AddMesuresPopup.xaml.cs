using Rg.Plugins.Popup.Services;
using Shared.Models;
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
    public partial class AddMesuresPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public List<AtCheckedItem> MesuresList { get; set; } = new List<AtCheckedItem>();
        public AddMesuresPopup()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MesuresList.Add(new AtCheckedItem
            {
                Name = "Vidange de l'équipement et ses circuits",
                IsSelected = true
            });
            MesuresList.Add(new AtCheckedItem
            {
                Name = "Consignation des Énergies",
                IsSelected = false
            });
            MesuresList.Add(new AtCheckedItem
            {
                Name = "Eclairage",
                IsSelected = true
            });
            MesuresList.Add(new AtCheckedItem
            {
                Name = "Dépressuration",
                IsSelected = false
            });
            MesuresList.Add(new AtCheckedItem
            {
                Name = "Ventilation",
                IsSelected = false
            });
            MesuresList.Add(new AtCheckedItem
            {
                Name = "Nettoyage",
                IsSelected = true
            });
            MesuresList.Add(new AtCheckedItem
            {
                Name = "Balisage",
                IsSelected = true
            });

            myListe.ItemsSource = MesuresList;
        }

        private void myListe_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (myListe.SelectedItem != null)
            {
                myListe.SelectedItem = null;

                var Item = e.SelectedItem as AtCheckedItem;

                Item.IsSelected = !Item.IsSelected;
            }
        }

        private async void AddItems_Clicked(object sender, EventArgs e)
        {
            var SelectedItemsList = MesuresList.Where(item => item.IsSelected);

            await Application.Current.MainPage.DisplayAlert("Confirmation!", $"Vous avez choisi {SelectedItemsList.Count()} Mesure(s)", "Ok");
        }

        private async void ClosePopup_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        protected override bool OnBackgroundClicked()
        {
            return false;
        }
    }
}