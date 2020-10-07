using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutorisationTravail
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.Home.HomeView());
            //MainPage = new NavigationPage(new Views.DemandeAutorisationTravail.DemandeAutorisationDetails());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
