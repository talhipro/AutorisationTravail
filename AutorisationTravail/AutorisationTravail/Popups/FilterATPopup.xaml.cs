using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Shared.Models;
using Shared.Models.AutorisationTravail;
using Shared;

namespace AutorisationTravail.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterATPopup : PopupPage
    {
        public List<AtCheckedItem> Statuts { get; set; } = new List<AtCheckedItem>();
        public List<AtCheckedItem> Entities { get; set; } = new List<AtCheckedItem>();
        public List<AtCheckedItem> Services { get; set; } = new List<AtCheckedItem>();
        public List<AtCheckedItem> Demandeurs { get; set; } = new List<AtCheckedItem>();
        public AtFilterModel FilterElements { get; set; } = new AtFilterModel();

        #region Search Textes
        public string StatutSearch { get; set; } = string.Empty;
        public string EntitySearch { get; set; } = string.Empty;
        public string ServiceSearch { get; set; } = string.Empty;
        public string DemandeurSearch { get; set; } = string.Empty;
        #endregion

        public FilterATPopup()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            for (int i = 0; i < 10; i++)
            {
                Entities.Add(
                    new AtCheckedItem
                    {
                        Name = string.Concat("Entity ", (i + 1)),
                        IsSelected = false
                    });
                Services.Add(
                    new AtCheckedItem
                    {
                        Name = string.Concat("Service ", (i + 1)),
                        IsSelected = false
                    });
                Demandeurs.Add(
                    new AtCheckedItem
                    {
                        Name = string.Concat("Demandeur ", (i + 1)),
                        IsSelected = false
                    });
            }

            Statuts = new List<AtCheckedItem>
            {
                new AtCheckedItem
                {
                    Name = "Draft",
                    IsSelected = false
                },
                new AtCheckedItem
                {
                    Name = "Attente permis",
                    IsSelected = false
                },
                new AtCheckedItem
                {
                    Name = "En exécution",
                    IsSelected = false
                },
                new AtCheckedItem
                {
                    Name = "Attente Validation",
                    IsSelected = false
                },
                new AtCheckedItem
                {
                    Name = "Attente réception",
                    IsSelected = false
                },
                new AtCheckedItem
                {
                    Name = "Réceptionné",
                    IsSelected = false
                }
            };
            StatutList.ItemsSource = Statuts;

            EntiteList.ItemsSource = Entities;
            ServiceList.ItemsSource = Services;
            DemandeurList.ItemsSource = Demandeurs;
        }

        #region Scroll between filters
        private void Statut_Tapped(object sender, EventArgs e)
        {
            #region Change Colors
            ServiceFrame.BackgroundColor = Color.FromHex("#EAF8FF");
            ServiceIcon.TintColor = Color.FromHex("#54C7FC");
            EntiteFrame.BackgroundColor = Color.FromHex("#EAF8FF");
            EntiteIcon.TintColor = Color.FromHex("#54C7FC");
            DemandeurFrame.BackgroundColor = Color.FromHex("#EAF8FF");
            DemandeurIcon.TintColor = Color.FromHex("#54C7FC");

            StatutFrame.BackgroundColor = Color.FromHex("#54C7FC");
            StatutIcon.TintColor = Color.White;
            #endregion

            #region Change Visibility
            StatutListContainer.IsVisible = true;
            EntiteListContainer.IsVisible = false;
            ServiceListContainer.IsVisible = false;
            DemandeurListContainer.IsVisible = false;
            #endregion

            SearchInFilterEntry.Text = StatutSearch;
        }

        private void Entite_Tapped(object sender, EventArgs e)
        {
            #region Change Colors
            StatutFrame.BackgroundColor = Color.FromHex("#EAF8FF");
            StatutIcon.TintColor = Color.FromHex("#54C7FC");
            ServiceFrame.BackgroundColor = Color.FromHex("#EAF8FF");
            ServiceIcon.TintColor = Color.FromHex("#54C7FC");
            DemandeurFrame.BackgroundColor = Color.FromHex("#EAF8FF");
            DemandeurIcon.TintColor = Color.FromHex("#54C7FC");

            EntiteFrame.BackgroundColor = Color.FromHex("#54C7FC");
            EntiteIcon.TintColor = Color.White;
            #endregion

            #region Change Visibility
            EntiteListContainer.IsVisible = true;
            StatutListContainer.IsVisible = false;
            ServiceListContainer.IsVisible = false;
            DemandeurListContainer.IsVisible = false;
            #endregion

            SearchInFilterEntry.Text = EntitySearch;
        }

        private void Service_Tapped(object sender, EventArgs e)
        {
            #region Change Colors
            StatutFrame.BackgroundColor = Color.FromHex("#EAF8FF");
            StatutIcon.TintColor = Color.FromHex("#54C7FC");
            EntiteFrame.BackgroundColor = Color.FromHex("#EAF8FF");
            EntiteIcon.TintColor = Color.FromHex("#54C7FC");
            DemandeurFrame.BackgroundColor = Color.FromHex("#EAF8FF");
            DemandeurIcon.TintColor = Color.FromHex("#54C7FC");

            ServiceFrame.BackgroundColor = Color.FromHex("#54C7FC");
            ServiceIcon.TintColor = Color.White;
            #endregion

            #region Change Visibility
            ServiceListContainer.IsVisible = true;
            StatutListContainer.IsVisible = false;
            EntiteListContainer.IsVisible = false;
            DemandeurListContainer.IsVisible = false;
            #endregion

            SearchInFilterEntry.Text = ServiceSearch;
        }

        private void Demandeur_Tapped(object sender, EventArgs e)
        {
            #region Change Colors
            StatutFrame.BackgroundColor = Color.FromHex("#EAF8FF");
            StatutIcon.TintColor = Color.FromHex("#54C7FC");
            EntiteFrame.BackgroundColor = Color.FromHex("#EAF8FF");
            EntiteIcon.TintColor = Color.FromHex("#54C7FC");
            ServiceFrame.BackgroundColor = Color.FromHex("#EAF8FF");
            ServiceIcon.TintColor = Color.FromHex("#54C7FC");

            DemandeurFrame.BackgroundColor = Color.FromHex("#54C7FC");
            DemandeurIcon.TintColor = Color.White;
            #endregion

            #region Change Visibility
            DemandeurListContainer.IsVisible = true;
            StatutListContainer.IsVisible = false;
            EntiteListContainer.IsVisible = false;
            ServiceListContainer.IsVisible = false;
            #endregion

            SearchInFilterEntry.Text = DemandeurSearch;
        }
        #endregion

        #region Selecting Items
        private void StatutList_ItemSelected(object sender, EventArgs e)
        {
            var SelectedItem = ((StackLayout)sender).BindingContext as AtCheckedItem;
            SelectedItem.IsSelected = !SelectedItem.IsSelected;

            StatutBox.IsVisible = Statuts.Where(item => item.IsSelected).ToList().Count != 0 ? true : false;
        }

        private void EntiteList_ItemSelected(object sender, EventArgs e)
        {
            var SelectedItem = ((StackLayout)sender).BindingContext as AtCheckedItem;
            SelectedItem.IsSelected = !SelectedItem.IsSelected;

            EntityBox.IsVisible = Entities.Where(item => item.IsSelected).ToList().Count != 0 ? true : false;
        }

        private void ServiceList_ItemSelected(object sender, EventArgs e)
        {
            var SelectedItem = ((StackLayout)sender).BindingContext as AtCheckedItem;
            SelectedItem.IsSelected = !SelectedItem.IsSelected;

            ServiceBox.IsVisible = Services.Where(item => item.IsSelected).ToList().Count != 0 ? true : false;
        }

        private void DemandeurList_ItemSelected(object sender, EventArgs e)
        {
            var SelectedItem = ((StackLayout)sender).BindingContext as AtCheckedItem;
            SelectedItem.IsSelected = !SelectedItem.IsSelected;

            DemandeurBox.IsVisible = Demandeurs.Where(item => item.IsSelected).ToList().Count != 0 ? true : false;
        }
        #endregion

        #region Search In Filters
        private void FilterSerach_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (StatutListContainer.IsVisible)
            {
                StatutList.ItemsSource = Statuts.Where(statut => statut.Name.ToLower().Contains(e.NewTextValue.ToLower()));
                StatutSearch = e.NewTextValue;
            }
            if (EntiteListContainer.IsVisible)
            {
                EntiteList.ItemsSource = Entities.Where(statut => statut.Name.ToLower().Contains(e.NewTextValue.ToLower()));
                EntitySearch = e.NewTextValue;
            }
            if (ServiceListContainer.IsVisible)
            {
                ServiceList.ItemsSource = Services.Where(statut => statut.Name.ToLower().Contains(e.NewTextValue.ToLower()));
                ServiceSearch = e.NewTextValue;
            }
            if (DemandeurListContainer.IsVisible)
            {
                DemandeurList.ItemsSource = Demandeurs.Where(statut => statut.Name.ToLower().Contains(e.NewTextValue.ToLower()));
                DemandeurSearch = e.NewTextValue;
            }
        }
        #endregion

        private void ApplyFilter_Clicked(object sender, EventArgs e)
        {
            FilterElements.Statuts = Statuts.Where(item => item.IsSelected).Select(item => item.Name).ToList();
            FilterElements.Entities = Entities.Where(item => item.IsSelected).Select(item => item.Name).ToList();
            FilterElements.Services = Services.Where(item => item.IsSelected).Select(item => item.Name).ToList();
            FilterElements.Demandeurs = Demandeurs.Where(item => item.IsSelected).Select(item => item.Name).ToList();

            MessagingCenter.Instance.Send(sender: this, AppConstants.FILTER_AT, FilterElements);
        }

        private async void SwipeDown_Swiped(object sender, SwipedEventArgs e)
        {
            var frame = ((Frame)sender);
            if (frame.Margin.Top != 0)
            {
                await PopupNavigation.Instance.PopAsync();
            }
            else
            {
                frame.Margin = new Thickness(frame.Margin.Left, 200, frame.Margin.Right, frame.Margin.Bottom);
                UpArrowImg.Source = "ArrowUp.png";
            }
        }

        private void SwipeUp_Swiped(object sender, SwipedEventArgs e)
        {
            var frame = ((Frame)sender);
            if (frame.Margin.Top != 0)
            {
                frame.Margin = new Thickness(frame.Margin.Left, 0, frame.Margin.Right, frame.Margin.Bottom);
                UpArrowImg.Source = "ArrowDown.png";
            }
        }

        private async void ClosePopup_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

    }
}