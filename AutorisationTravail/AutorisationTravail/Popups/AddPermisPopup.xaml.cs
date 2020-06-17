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
    public partial class AddPermisPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public List<AtCheckedItem> PermisList { get; set; } = new List<AtCheckedItem>();
        public AddPermisPopup()
        {
            InitializeComponent();
        }

        //<x:String>Permis pour espace confiné</x:String>
        //<x:String></x:String>
        //<x:String></x:String>
        //<x:String></x:String>

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PermisList.Add(new AtCheckedItem
            {
                Name = "Permis pour espace confiné",
                IsSelected = true
            });
            PermisList.Add(new AtCheckedItem
            {
                Name = "Permis de feu",
                IsSelected = false
            });
            PermisList.Add(new AtCheckedItem
            {
                Name = "Permis de fouille",
                IsSelected = true
            });
            PermisList.Add(new AtCheckedItem
            {
                Name = "Permis de Consignation",
                IsSelected = false
            });

            myListe.ItemsSource = PermisList;
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
            var SelectedItemsList = PermisList.Where(item => item.IsSelected);

            await Application.Current.MainPage.DisplayAlert("Confirmation!", $"Vous avez choisi {SelectedItemsList.Count()} Permis", "Ok");
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

        //private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        //{
        //    if (e.Value)
        //        ListPermisHauteur.IsVisible = true;
        //    else
        //        ListPermisHauteur.IsVisible = false;
        //}
    }
}