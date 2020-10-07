using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Shared.Models.AutorisationTravail;
using System.Windows.Input;
using Shared;
using System.Threading;

namespace AutorisationTravail.Views.AutorisationTravail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListAutorisationTravail : ContentPage
    {
        public ObservableCollection<ListATModel> ATList { get; set; } = new ObservableCollection<ListATModel>();

        public ListAutorisationTravail()
        {
            InitializeComponent();

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) =>
            {
                // more info about animations:
                // https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/animation/simple

                // scale the frame to x1.2
                var scaleUpAnimationTask = FilterAT.ScaleTo(1.02, 100);
                // set opacity to 0 (transparent)
                var fadeOutAnimationTask = FilterAT.FadeTo(0.9, 100);

                // wait for the 2 animations to finish...
                await Task.WhenAll(scaleUpAnimationTask, fadeOutAnimationTask);

                // scale the frame back to original size
                var scaleDownAnimationTask = FilterAT.ScaleTo(1, 100);
                // set opacity back to 1 (solid)
                var fadeInAnimationTask = FilterAT.FadeTo(1, 100);

                // wait for the 2 animations to finish...
                await Task.WhenAll(scaleDownAnimationTask, fadeInAnimationTask);

                // Redirect to the correspond page...
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Popups.FilterATPopup());
            };
            FilterAT.GestureRecognizers.Add(tapGestureRecognizer);
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Popups.FilterATPopup, AtFilterModel>(this, AppConstants.FILTER_AT, async (sender, arg) =>
            {
                /*var msg = string.Concat(
                    $"Vous avez choisi:\n",
                    $"\t\t{arg.Statuts.Count()} Statu(s)\n",
                    $"\t\t{arg.Entities.Count()} Entite(s)\n",
                    $"\t\t{arg.Services.Count()} Service(s)\n",
                    $"\t\t{arg.Demandeurs.Count()} Demandeur(s)");

                await DisplayAlert("Message received", msg, "OK");*/
                List<ListATModel> FiltredATList = new List<ListATModel>();

                FiltredATList = ATList.Where(AT => (arg.Statuts.Contains(AT.AutorisationStatut) || arg.Statuts.Count == 0)
                                                       && (arg.Entities.Contains(AT.AutorisationEntite) || arg.Entities.Count == 0)
                                                       && (arg.Services.Contains(AT.AutorisationService) || arg.Services.Count == 0)
                                                       && (arg.Demandeurs.Contains(AT.AutorisationDemandeur) || arg.Demandeurs.Count == 0)
                                       ).ToList();

                ATList.Clear();

                foreach (var item in FiltredATList)
                {
                    ATList.Add(item);
                }

                ResultType.Text = "Éléments filtrés";
                NoRecordsFrame.IsVisible = ATList.Count() == 0 ? true : false;
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
            });

            RefrechListAT();
        }
        private void AtListView_Refreshing(object sender, EventArgs e)
        {
            AtListView.IsRefreshing = true;
            RefrechListAT();
            AtListView.IsRefreshing = false;

            NoRecordsFrame.IsVisible = ATList.Count() == 0 ? true : false;
        }

        public void RefrechListAT()
        {
            ATList.Clear();
            ATList.Add(new ListATModel
            {
                AutorisationID = 1,
                AutorisationNum = "0039884",
                AutorisationSite = "safi",
                AutorisationEntite = "Entity 1",
                AutorisationService = "Service 1",
                AutorisationDemandeur = "ibrahim alaoui ",
                AutorisationDate = DateTime.Parse("03/06/2020"),
                AutorisationDateIntervention = DateTime.Parse("05/06/2020"),
                AutorisationHeureDebut = "15:00",
                AutorisationHeureFin = "17:30",
                AutorisationStatut = "Draft",
                AutorisationStatutBgColor = "#F5F5F5",
                AutorisationStatutTxtColor = "#AEB4BF"
            });
            ATList.Add(new ListATModel
            {
                AutorisationID = 2,
                AutorisationNum = "0029821",
                AutorisationSite = "khouribga",
                AutorisationEntite = "Entity 2",
                AutorisationService = "Service 2",
                AutorisationDemandeur = "samir benmakhlouf ",
                AutorisationDate = DateTime.Parse("06/06/2020"),
                AutorisationDateIntervention = DateTime.Parse("09/06/2020"),
                AutorisationHeureDebut = "14:00",
                AutorisationHeureFin = "18:00",
                AutorisationStatut = "Attente permis",
                AutorisationStatutBgColor = "#FFF1F7",
                AutorisationStatutTxtColor = "#CF464A"
            });
            ATList.Add(new ListATModel
            {
                AutorisationID = 3,
                AutorisationNum = "0048821",
                AutorisationSite = "safi",
                AutorisationEntite = "Entity 3",
                AutorisationService = "Service 3",
                AutorisationDemandeur = "ibrahim alaoui ",
                AutorisationDate = DateTime.Parse("07/06/2020"),
                AutorisationDateIntervention = DateTime.Parse("08/06/2020"),
                AutorisationHeureDebut = "10:00",
                AutorisationHeureFin = "16:00",
                AutorisationStatut = "En exécution",
                AutorisationStatutBgColor = "#F1FFF2",
                AutorisationStatutTxtColor = "#2CD920"
            });
            ATList.Add(new ListATModel
            {
                AutorisationID = 4,
                AutorisationNum = "0025121",
                AutorisationSite = "Jorf",
                AutorisationEntite = "Entity 4",
                AutorisationService = "Service 4",
                AutorisationDemandeur = "karim naji ",
                AutorisationDate = DateTime.Parse("06/06/2020"),
                AutorisationDateIntervention = DateTime.Parse("08/06/2020"),
                AutorisationHeureDebut = "12:00",
                AutorisationHeureFin = "17:00",
                AutorisationStatut = "Attente Validation",
                AutorisationStatutBgColor = "#FFEDE6",
                AutorisationStatutTxtColor = "#F67D49"
            });
            ATList.Add(new ListATModel
            {
                AutorisationID = 5,
                AutorisationNum = "0025100",
                AutorisationSite = "Jorf",
                AutorisationEntite = "Entity 5",
                AutorisationService = "Service 4",
                AutorisationDemandeur = "soufiane tazi",
                AutorisationDate = DateTime.Parse("10/06/2020"),
                AutorisationDateIntervention = DateTime.Parse("12/06/2020"),
                AutorisationHeureDebut = "09:00",
                AutorisationHeureFin = "11:00",
                AutorisationStatut = "Attente réception",
                AutorisationStatutBgColor = "#FFEDE6",
                AutorisationStatutTxtColor = "#F67D49"
            });
            ATList.Add(new ListATModel
            {
                AutorisationID = 6,
                AutorisationNum = "0025421",
                AutorisationSite = "Jorf",
                AutorisationEntite = "Entity 6",
                AutorisationService = "Service 5",
                AutorisationDemandeur = "soufiane tazi",
                AutorisationDate = DateTime.Parse("03/06/2020"),
                AutorisationDateIntervention = DateTime.Parse("05/06/2020"),
                AutorisationHeureDebut = "09:00",
                AutorisationHeureFin = "11:00",
                AutorisationStatut = "Réceptionné",
                AutorisationStatutBgColor = "#8cc1fa",
                AutorisationStatutTxtColor = "#2583e8"
            });
            ATList.Add(new ListATModel
            {
                AutorisationID = 7,
                AutorisationNum = "0029821",
                AutorisationSite = "khouribga",
                AutorisationEntite = "Entity 4",
                AutorisationService = "Service 6",
                AutorisationDemandeur = "samir benmakhlouf ",
                AutorisationDate = DateTime.Parse("07/07/2020"),
                AutorisationDateIntervention = DateTime.Parse("10/07/2020"),
                AutorisationHeureDebut = "14:30",
                AutorisationHeureFin = "18:30",
                AutorisationStatut = "Attente permis",
                AutorisationStatutBgColor = "#FFF1F7",
                AutorisationStatutTxtColor = "#CF464A"
            });
            ATList.Add(new ListATModel
            {
                AutorisationID = 8,
                AutorisationNum = "0029821",
                AutorisationSite = "khouribga",
                AutorisationEntite = "Entity 2",
                AutorisationService = "Service 7",
                AutorisationDemandeur = "samir benmakhlouf ",
                AutorisationDate = DateTime.Parse("07/07/2020"),
                AutorisationDateIntervention = DateTime.Parse("10/07/2020"),
                AutorisationHeureDebut = "14:30",
                AutorisationHeureFin = "18:30",
                AutorisationStatut = "En exécution",
                AutorisationStatutBgColor = "#F1FFF2",
                AutorisationStatutTxtColor = "#2CD920"
            });

            AtListView.ItemsSource = ATList;
        }

        private void Recherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            //FilterItem(search.Text);
        }


        private async void SearchBtn_Tapped(object sender, EventArgs e)
        {
            //Task<bool> moveAnimationTask;
            Task<bool> scaleAnimationTask;
            if (SearchSection.HeightRequest != 0)
            {
                //moveAnimationTask = SearchSection.TranslateTo(0, -600, 200);
                scaleAnimationTask = SearchSection.FadeTo(0, 100);
                SearchSection.HeightRequest = 0;
            }
            else
            {
                //moveAnimationTask = SearchSection.TranslateTo(0, 0, 200);
                scaleAnimationTask = SearchSection.FadeTo(1, 100);
                SearchSection.HeightRequest = -1;
            }

            // wait for the 2 animations to finish...
            await Task.WhenAll(/*moveAnimationTask, */scaleAnimationTask);
        }

        private void Item_Tapped(object sender, EventArgs e)
        {
            var ItemContext = ((StackLayout)sender).BindingContext as ListATModel;

            if (ItemContext.DetailsColapse) ItemContext.DetailsColapse = false;
            else ItemContext.DetailsColapse = true;
        }

        private async void BackBtn_Tapped(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private void ResultType_Tapped(object sender, EventArgs e)
        {
            if (ResultType.Text != "Toutes les autorisation")
            {
                ResultTypeAll.IsVisible = !ResultTypeAll.IsVisible;
                if (ResultTypeAll.IsVisible)
                {
                    SmallFillArrowDown.RotateTo(180, 0);
                }
                else
                {
                    SmallFillArrowDown.RotateTo(0, 0);
                }
            }
        }

        private void ResultTypeAll_Tapped(object sender, EventArgs e)
        {
            RefrechListAT();
            ResultType.Text = "Toutes les autorisation";
            ResultTypeAll.IsVisible = false;
            NoRecordsFrame.IsVisible = false;
            SmallFillArrowDown.RotateTo(0, 0);
        }

        private void Reload_Tapped(object sender, EventArgs e)
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            var task = Task.Run(async () =>
            {
                for (int i = 1; i < 7; i++)
                {
                    if (ReloadImg.Rotation >= 360f) ReloadImg.Rotation = 0;
                    await ReloadImg.RotateTo(i * (360 / 6), 500, Easing.Linear);
                }
            }, token);

            RefrechListAT();

            tokenSource.Cancel();
            NoRecordsFrame.IsVisible = ATList.Count() == 0 ? true : false;
            ResultTypeAll.IsVisible = false;
            ResultType.Text = "Toutes les autorisation";
        }
    }
}