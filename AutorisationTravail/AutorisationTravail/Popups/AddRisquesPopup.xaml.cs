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
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public partial class AddRisquesPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public List<AtCheckedItem> RisquesList { get; set; } = new List<AtCheckedItem>();

        public AddRisquesPopup()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            RisquesList = new List<AtCheckedItem>
            {
                new AtCheckedItem
                {
                    Name = "Travail en hauteur",
                    IsSelected = true
                },
                new AtCheckedItem
                {
                    Name = "Proximité aux réseaux enterrés",
                    IsSelected = false
                },
                new AtCheckedItem
                {
                    Name = "Produits inflammatables",
                    IsSelected = true
                },
                new AtCheckedItem
                {
                    Name = "Manutention mécanique",
                    IsSelected = false
                },
                new AtCheckedItem
                {
                    Name = "Outillage",
                    IsSelected = false
                },
                new AtCheckedItem
                {
                    Name = "Bruit (>80 dB)",
                    IsSelected = true
                },
                new AtCheckedItem
            {
                Name = "Circulation personnes",
                IsSelected = true
            }
            };


            myListe.ItemsSource = RisquesList;
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

        private void AddItems_Clicked(object sender, EventArgs e)
        {
            var SelectedItemsList = RisquesList.Where(item => item.IsSelected);

            Application.Current.MainPage.DisplayAlert("Confirmation!", $"Vous avez choisi {SelectedItemsList.Count()} Risque(s)", "Ok");
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