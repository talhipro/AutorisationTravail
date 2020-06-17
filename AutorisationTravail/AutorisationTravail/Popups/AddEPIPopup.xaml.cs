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
    public partial class AddEPIPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public List<AtCheckedItem> EpiList { get; set; } = new List<AtCheckedItem>();
        public AddEPIPopup()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            EpiList.Add(new AtCheckedItem
            {
                Name = "Casque soudure",
                IsSelected = true
            });
            EpiList.Add(new AtCheckedItem
            {
                Name = "Masque à gaz",
                IsSelected = false
            });
            EpiList.Add(new AtCheckedItem
            {
                Name = "Masque à poussiéres",
                IsSelected = true
            });
            EpiList.Add(new AtCheckedItem
            {
                Name = "Cagoule",
                IsSelected = false
            });
            EpiList.Add(new AtCheckedItem
            {
                Name = "ARI",
                IsSelected = false
            });
            EpiList.Add(new AtCheckedItem
            {
                Name = "Stop bruit",
                IsSelected = true
            });
            EpiList.Add(new AtCheckedItem
            {
                Name = "Bottes de sécurité",
                IsSelected = true
            });
            EpiList.Add(new AtCheckedItem
            {
                Name = "Guêtres",
                IsSelected = true
            });
            EpiList.Add(new AtCheckedItem
            {
                Name = "Ecran facial",
                IsSelected = true
            });

            myListe.ItemsSource = EpiList;
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
            var SelectedItemsList = EpiList.Where(item => item.IsSelected);

            await Application.Current.MainPage.DisplayAlert("Confirmation!", $"Vous avez choisi {SelectedItemsList.Count()} EPI(s)", "Ok");
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