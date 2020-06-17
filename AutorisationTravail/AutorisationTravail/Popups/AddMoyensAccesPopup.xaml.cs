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
    public partial class AddMoyensAccesPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public List<AtCheckedItem> MoyensAccesList { get; set; } = new List<AtCheckedItem>();
        public AddMoyensAccesPopup()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MoyensAccesList.Add(new AtCheckedItem
            {
                Name = "Escabeau",
                IsSelected = true
            });
            MoyensAccesList.Add(new AtCheckedItem
            {
                Name = "Nacelle, PEMP",
                IsSelected = false
            });
            MoyensAccesList.Add(new AtCheckedItem
            {
                Name = "Echafaudage",
                IsSelected = true
            });
            MoyensAccesList.Add(new AtCheckedItem
            {
                Name = "Passerelle",
                IsSelected = false
            });

            myListe.ItemsSource = MoyensAccesList;
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
            var SelectedItemsList = MoyensAccesList.Where(item => item.IsSelected);

            await Application.Current.MainPage.DisplayAlert("Confirmation!", $"Vous avez choisi {SelectedItemsList.Count()} Moyens(s) d'acess", "Ok");
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