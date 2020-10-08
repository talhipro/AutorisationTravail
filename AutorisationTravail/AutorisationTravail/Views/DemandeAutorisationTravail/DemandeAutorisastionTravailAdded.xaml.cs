using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AutorisationTravail.Views.DemandeAutorisationTravail
{
    public partial class DemandeAutorisastionTravailAdded : ContentPage
    {
        public DemandeAutorisastionTravailAdded()
        {
            InitializeComponent();
        }

        private async void BackToDemandeATButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopToRootAsync();
        }
    }
}
