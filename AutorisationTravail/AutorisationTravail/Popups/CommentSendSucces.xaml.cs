﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutorisationTravail.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommentSendSucces : Rg.Plugins.Popup.Pages.PopupPage
    {
        public CommentSendSucces()
        {
            InitializeComponent();
        }

        private async void DemandesAT_Clicked(object sender, EventArgs e)
        {
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}