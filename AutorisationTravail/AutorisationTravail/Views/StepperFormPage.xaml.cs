using System;
using Rg.Plugins.Popup.Services;
using Shared.Models;
using Shared.Models.AutorisationTravail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutorisationTravail.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StepperFormPage : ContentPage
    {
        public ATModel AutorisationTravail { get; set; } = new ATModel();
        public List<SiteModel> SiteList { get; set; } = new List<SiteModel>();
        public List<EntiteModel> EntiteList { get; set; } = new List<EntiteModel>();
        public StepperFormPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


            EntiteList = new List<EntiteModel>
            {
                new EntiteModel() {Id = "01", EntiteName = "Entite 01"},
                new EntiteModel() {Id = "02", EntiteName = "Entite 02"},
                new EntiteModel() {Id = "03", EntiteName = "Entite 03"},
                new EntiteModel() {Id = "04", EntiteName = "Entite 04"},
                new EntiteModel() {Id = "05", EntiteName = "Entite 05"}
            };

            SiteList = new List<SiteModel>
            {
                new SiteModel() {Id = "01", SiteName = "Site 01"},
                new SiteModel() {Id = "02", SiteName = "Site 02"},
                new SiteModel() {Id = "03", SiteName = "Site 03"},
                new SiteModel() {Id = "04", SiteName = "Site 04"},
                new SiteModel() {Id = "05", SiteName = "Site 05"}
            };

            AutorisationTravail.AtMoyensAcces = new List<AtCheckedItem>()
            {
                new AtCheckedItem(),
                new AtCheckedItem(),
                new AtCheckedItem()
            };

            AutorisationTravail.AtRisques = new List<AtCheckedItem>()
            {
                new AtCheckedItem(),
                new AtCheckedItem(),
                new AtCheckedItem(),
                new AtCheckedItem()
            };

            AutorisationTravail.AtEpiSpecifiques = new List<AtCheckedItem>()
            {
                new AtCheckedItem(),
                new AtCheckedItem(),
                new AtCheckedItem(),
                new AtCheckedItem(),
                new AtCheckedItem(),
                new AtCheckedItem()
            };
        }

        private async void AddRisques_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Popups.AddRisquesPopup());
        }

        private async void AddMesures_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Popups.AddMesuresPopup());
        }

        private async void AddMoyensAcces_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Popups.AddMoyensAccesPopup());
        }

        private async void AddEPI_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Popups.AddEPIPopup());
        }

        private async void AddPermis_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Popups.AddPermisPopup());
        }

        private void Submit_Clicked(object sender, EventArgs e)
        {

        }

        private async void BackBtn_Tapped(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }


        #region Steps Clicks

        private bool _IsExpanded;
        private bool _IsExpanding;
        private async void Etape1Title_Clicked(object sender, EventArgs e)
        {
            //Etape1.IsVisible = !Etape1.IsVisible;
            if (!_IsExpanding)
            {
                _IsExpanding = true;

                if (_IsExpanded)
                {
                    var animation = new Animation(v => Etape1.HeightRequest = v, Etape1.Height, 0);
                    animation.Commit(this, "ExpandSize", 16, 250);
                    await Etape1.FadeTo(0, 250, Easing.BounceIn);
                }
                else
                {
                    var animation = new Animation(v => Etape1.HeightRequest = v, 0, Etape1.HeightRequest);
                    animation.Commit(this, "ExpandSize", 16, 250);
                    await Etape1.FadeTo(1, 250, Easing.BounceIn);
                }


                _IsExpanded = !_IsExpanded;
                _IsExpanding = false;
            }
        }
        #endregion
    }
}