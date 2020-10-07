using Rg.Plugins.Popup.Services;
using Shared.Models;
using Shared.Models.AutorisationTravail;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutorisationTravail.Views.AutorisationTravail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public partial class AddAutorisationTravail : ContentPage
    {
        public ATModel AutorisationTravail { get; set; } = new ATModel();
        public List<SiteModel> SiteList { get; set; } = new List<SiteModel>();
        public List<EntiteModel> EntiteList { get; set; } = new List<EntiteModel>();

        //public SiteModel AtSite { get; set; } = new SiteModel() { Id = "01", SiteName = "Site 01" };

    public AddAutorisationTravail()
        {
            InitializeComponent();
            BindingContext = this;

            #region Init Steps Props
            Step1ExpandableLayout.HeightRequest = 0;
            Step2ExpandableLayout.HeightRequest = 0;
            Step3ExpandableLayout.HeightRequest = 0;
            #endregion
        }

        protected async override void OnAppearing()
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

            await ExpandLayout(Step1ExpandableLayout, Step1IconText, Step1IconFrame, Step1IsChecked, Step1IsExpanded);
            Step1IsExpanded = true;
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

        #region Steps Code
        private bool IsExpanding;

        private bool Step1IsExpanded = false;
        private bool Step2IsExpanded = false;
        private bool Step3IsExpanded = false;

        private bool Step1IsChecked = false;
        private bool Step2IsChecked = false;
        private bool Step3IsChecked = false;

        private async void Step1_Clicked(object sender, EventArgs e)
        {
            if (!IsExpanding)
            {
                IsExpanding = true;
                //var height =  Step1ExpandableContent.Height;
                if (Step1IsExpanded)
                {
                    await CollapseLayout(Step1ExpandableLayout, Step1IconText, Step1IconFrame, Step1IsChecked, Step1IsExpanded);
                }
                else
                {
                    await CollapseLayout(Step3ExpandableLayout, Step3IconText, Step3IconFrame, Step3IsChecked, Step3IsExpanded);
                    await CollapseLayout(Step2ExpandableLayout, Step2IconText, Step2IconFrame, Step2IsChecked, Step2IsExpanded);
                    await ExpandLayout(Step1ExpandableLayout, Step1IconText, Step1IconFrame, Step1IsChecked, Step1IsExpanded);
                    Step3IsExpanded = false;
                    Step2IsExpanded = false;
                }
                Step1IsExpanded = !Step1IsExpanded;
                IsExpanding = false;
            }
        }
        private async void Step2_Clicked(object sender, EventArgs e)
        {
            if (!IsExpanding)
            {
                IsExpanding = true;
                //var height =  Step1ExpandableContent.Height;
                if (Step2IsExpanded)
                {
                    await CollapseLayout(Step2ExpandableLayout, Step2IconText, Step2IconFrame, Step2IsChecked, Step2IsExpanded);

                }
                else
                {
                    await CollapseLayout(Step3ExpandableLayout, Step3IconText, Step3IconFrame, Step3IsChecked, Step3IsExpanded);
                    await CollapseLayout(Step1ExpandableLayout, Step1IconText, Step1IconFrame, Step1IsChecked, Step1IsExpanded);
                    await ExpandLayout(Step2ExpandableLayout, Step2IconText, Step2IconFrame, Step2IsChecked, Step2IsExpanded);
                    Step3IsExpanded = false;
                    Step1IsExpanded = false;
                }
                Step2IsExpanded = !Step2IsExpanded;
                IsExpanding = false;
            }
        }
        private async void Step3_Clicked(object sender, EventArgs e)
        {
            if (!IsExpanding)
            {
                IsExpanding = true;
                //var height =  Step1ExpandableContent.Height;
                if (Step3IsExpanded)
                {
                    await CollapseLayout(Step3ExpandableLayout, Step3IconText, Step3IconFrame, Step3IsChecked, Step3IsExpanded);
                }
                else
                {
                    await CollapseLayout(Step1ExpandableLayout, Step1IconText, Step1IconFrame, Step1IsChecked, Step1IsExpanded);
                    await CollapseLayout(Step2ExpandableLayout, Step2IconText, Step2IconFrame, Step2IsChecked, Step2IsExpanded);
                    await ExpandLayout(Step3ExpandableLayout, Step3IconText, Step3IconFrame, Step3IsChecked, Step3IsExpanded);
                    Step1IsExpanded = false;
                    Step2IsExpanded = false;
                }
                Step3IsExpanded = !Step3IsExpanded;
                IsExpanding = false;
            }
        }

        private async void Suivant_Step1_Clicked(object sender, EventArgs e)
        {
            Step1IsChecked = true;
            Step1IconText.Text = "✓";
            Step1IconText.TextColor = Color.White;
            Step1IconFrame.BackgroundColor = Color.DarkGreen;

            await CollapseLayout(Step1ExpandableLayout);
            await ExpandLayout(Step2ExpandableLayout, Step2IconText, Step2IconFrame, Step2IsChecked, Step2IsExpanded);
            Step2IsExpanded = true;
            Step1IsExpanded = false;
        }

        private async void Suivant_Step2_Clicked(object sender, EventArgs e)
        {
            Step2IsChecked = true;
            Step2IconText.Text = "✓";
            Step2IconText.TextColor = Color.White;
            Step2IconFrame.BackgroundColor = Color.DarkGreen;

            await CollapseLayout(Step2ExpandableLayout);
            await ExpandLayout(Step3ExpandableLayout, Step3IconText, Step3IconFrame, Step3IsChecked, Step3IsExpanded);
            Step3IsExpanded = true;
            Step2IsExpanded = false;
        }

        private void Suivant_Step3_Clicked(object sender, EventArgs e)
        {
            Step3IsChecked = true;
            Step3IconText.Text = "✓";
            Step3IconText.TextColor = Color.White;
            Step3IconFrame.BackgroundColor = Color.DarkGreen;
        }

        private async Task CollapseLayout(StackLayout layout)
        {
            var animation = new Animation(v => layout.HeightRequest = v, -1, 0);
            animation.Commit(layout, "ExpandSize", 16, 100);
            await layout.FadeTo(0, 200);

        }
        private async Task ExpandLayout(StackLayout layout)
        {
            var animation = new Animation(v => layout.HeightRequest = v, 0, -1);
            animation.Commit(layout, "ExpandSize", 16, 100);
            await layout.FadeTo(1, 200);
        }

        private async Task ExpandLayout(StackLayout layout, Label label, Frame frame, bool IsChecked, bool IsExpanded)
        {
            if (!IsExpanded)
            {
                await ExpandLayout(layout);
                if (!IsChecked)
                {
                    label.TextColor = Color.DarkGreen;
                    frame.BackgroundColor = Color.FromHex("#c4dfb4");
                }
            }
        }

        private async Task CollapseLayout(StackLayout layout, Label label, Frame frame, bool IsChecked, bool IsExpanded)
        {
            if (IsExpanded)
            {
                await CollapseLayout(layout);
                if (!IsChecked)
                {
                    label.TextColor = Color.White;
                    frame.BackgroundColor = Color.LightGray;
                }
            }
        }
        #endregion

    }
}