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
using Shared;
using System.Threading;

namespace AutorisationTravail.Views.Permis
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPermis : ContentPage
    {
        public ObservableCollection<PermisListModel> PermisList { get; set; } = new ObservableCollection<PermisListModel>();

        public ListPermis()
        {
            InitializeComponent();

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) =>
            {
                // more info about animations:
                // https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/animation/simple

                // scale the frame to x1.2
                var scaleUpAnimationTask = FilterPermis.ScaleTo(1.02, 100);
                // set opacity to 0 (transparent)
                var fadeOutAnimationTask = FilterPermis.FadeTo(0.9, 100);

                // wait for the 2 animations to finish...
                await Task.WhenAll(scaleUpAnimationTask, fadeOutAnimationTask);

                // scale the frame back to original size
                var scaleDownAnimationTask = FilterPermis.ScaleTo(1, 100);
                // set opacity back to 1 (solid)
                var fadeInAnimationTask = FilterPermis.FadeTo(1, 100);

                // wait for the 2 animations to finish...
                await Task.WhenAll(scaleDownAnimationTask, fadeInAnimationTask);

                // Redirect to the correspond page...
                await PopupNavigation.Instance.PushAsync(new Popups.FilterPermisPopup());
            };
            FilterPermis.GestureRecognizers.Add(tapGestureRecognizer);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Popups.FilterPermisPopup, PermisFilterModel>(this, AppConstants.FILTER_PERMIS, async (sender, arg) =>
            {
                List<PermisListModel> FiltredATList = new List<PermisListModel>();

                FiltredATList = PermisList.Where(permis => (arg.Statuts.Contains(permis.PermisStatutValue) || arg.Statuts.Count == 0)
                                                       && (arg.Entities.Contains(permis.PermisEntite) || arg.Entities.Count == 0)
                                                       && (arg.Services.Contains(permis.PermisService) || arg.Services.Count == 0)
                                                       && (arg.Demandeurs.Contains(permis.PermisDemandeur) || arg.Demandeurs.Count == 0)
                                                       && (arg.Sites.Contains(permis.PermisSite) || arg.Sites.Count == 0)
                                                       && (arg.Types.Contains(permis.PermisType) || arg.Types.Count == 0)
                                       ).ToList();

                PermisList.Clear();

                foreach (var item in FiltredATList)
                {
                    PermisList.Add(item);
                }

                NoRecordsFrame.IsVisible = PermisList.Count() == 0 ? true : false;
                await PopupNavigation.Instance.PopAsync();
            });

            RefrechListPermis();
        }

        public void RefrechListPermis()
        {
            PermisList.Clear();
            PermisList.Add(new PermisListModel
            {
                PermisNumAT = "0039884",
                PermisDemandeur = "ibrahim alaoui",
                PermisType = "Permis de feu",
                PermisStatutValue = "En Cours De Preparation",
                PermisStatutBgColor = "#F5F5F5",
                PermisStatutTxtColor = "#AEB4BF",
                PermisDate = "05/07/2020",
                PermisEntite = "Entity 1",
                PermisService = "Service 1"
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
                PermisEntite = "Entity 2",
                PermisService = "Service 2"
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
                PermisEntite = "Entity 3",
                PermisService = "Service 3"
            });
            PermisList.Add(new PermisListModel
            {
                PermisNumAT = "0039884",
                PermisDemandeur = "ibrahim alaoui",
                PermisType = "Permis de Travail en Hauteur avec EPI",
                PermisStatutValue = "En Cours De Preparation",
                PermisStatutBgColor = "#F5F5F5",
                PermisStatutTxtColor = "#AEB4BF",
                PermisDate = "05/07/2020",
                PermisEntite = "Entity 4",
                PermisService = "Service 4"
            });
            PermisList.Add(new PermisListModel
            {
                PermisNumAT = "0039884",
                PermisDemandeur = "samir benmakhlouf",
                PermisType = "Permis de pénétration dans un espace confiné",
                PermisStatutValue = "Refusé",
                PermisStatutBgColor = "#FFF1F7",
                PermisStatutTxtColor = "#CF464A",
                PermisDate = "09/06/2020",
                PermisEntite = "Entity 3",
                PermisService = "Service 3"
            });

            PermisListView.ItemsSource = PermisList;
        }

        private void PermisListView_Refreshing(object sender, EventArgs e)
        {
            PermisListView.IsRefreshing = true;
            RefrechListPermis();
            PermisListView.IsRefreshing = false;

            NoRecordsFrame.IsVisible = PermisList.Count() == 0 ? true : false;
        }
        private void Reload_Tapped(object sender, EventArgs e)
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            var task = Task.Run(async() =>
            {
                for (int i = 1; i < 7; i++)
                {
                    if (ReloadImg.Rotation >= 360f) ReloadImg.Rotation = 0;
                    await ReloadImg.RotateTo(i * (360 / 6), 500, Easing.Linear);
                }
            },token);

            RefrechListPermis();

            tokenSource.Cancel();
            NoRecordsFrame.IsVisible = PermisList.Count() == 0 ? true : false;
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

        private async void BackBtn_Tapped(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

    }
}