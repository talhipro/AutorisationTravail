using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutorisationTravail.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) =>
            {
                // more info about animations:
                // https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/animation/simple

                // scale the frame to x1.2
                var scaleUpAnimationTask = DemandeAT.ScaleTo(1.02, 100);
                // set opacity to 0 (transparent)
                var fadeOutAnimationTask = DemandeAT.FadeTo(0.9, 100);

                // wait for the 2 animations to finish...
                await Task.WhenAll(scaleUpAnimationTask, fadeOutAnimationTask);

                // scale the frame back to original size
                var scaleDownAnimationTask = DemandeAT.ScaleTo(1, 100);
                // set opacity back to 1 (solid)
                var fadeInAnimationTask = DemandeAT.FadeTo(1, 100);

                // wait for the 2 animations to finish...
                await Task.WhenAll(scaleDownAnimationTask, fadeInAnimationTask);

                // Redirect to the correspond page...
                await Application.Current.MainPage.Navigation.PushAsync(new DemandeAutorisationTravail.DemandeAutorisationDetails());
            };
            DemandeAT.GestureRecognizers.Add(tapGestureRecognizer);

            var tapGestureRecognizer1 = new TapGestureRecognizer();
            tapGestureRecognizer1.Tapped += async (s, e) =>
            {
                // more info about animations:
                // https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/animation/simple

                // scale the frame to x1.2
                var scaleUpAnimationTask = CreateAT.ScaleTo(1.02, 100);
                // set opacity to 0 (transparent)
                var fadeOutAnimationTask = CreateAT.FadeTo(0.9, 100);

                // wait for the 2 animations to finish...
                await Task.WhenAll(scaleUpAnimationTask, fadeOutAnimationTask);

                // scale the frame back to original size
                var scaleDownAnimationTask = CreateAT.ScaleTo(1, 100);
                // set opacity back to 1 (solid)
                var fadeInAnimationTask = CreateAT.FadeTo(1, 100);

                // wait for the 2 animations to finish...
                await Task.WhenAll(scaleDownAnimationTask, fadeInAnimationTask);

                // Redirect to the correspond page...
                await Application.Current.MainPage.Navigation.PushAsync(new AutorisationTravail.AddAutorisationTravail());
            };
            CreateAT.GestureRecognizers.Add(tapGestureRecognizer1);

            var tapGestureRecognizer2 = new TapGestureRecognizer();
            tapGestureRecognizer2.Tapped += async (s, e) =>
            {
                // more info about animations:
                // https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/animation/simple

                // scale the frame to x1.2
                var scaleUpAnimationTask = ListAT.ScaleTo(1.02, 100);
                // set opacity to 0 (transparent)
                var fadeOutAnimationTask = ListAT.FadeTo(0.9, 100);

                // wait for the 2 animations to finish...
                await Task.WhenAll(scaleUpAnimationTask, fadeOutAnimationTask);

                // scale the frame back to original size
                var scaleDownAnimationTask = ListAT.ScaleTo(1, 100);
                // set opacity back to 1 (solid)
                var fadeInAnimationTask = ListAT.FadeTo(1, 100);

                // wait for the 2 animations to finish...
                await Task.WhenAll(scaleDownAnimationTask, fadeInAnimationTask);
                // Redirect to the correspond page...
                await Application.Current.MainPage.Navigation.PushAsync(new AutorisationTravail.ListAutorisationTravail());
            };
            ListAT.GestureRecognizers.Add(tapGestureRecognizer2);

            var tapGestureRecognizer3 = new TapGestureRecognizer();
            tapGestureRecognizer3.Tapped += async (s, e) =>
            {
                // more info about animations:
                // https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/animation/simple

                // scale the frame to x1.2
                var scaleUpAnimationTask = ListPermis.ScaleTo(1.02, 100);
                // set opacity to 0 (transparent)
                var fadeOutAnimationTask = ListPermis.FadeTo(0.9, 100);

                // wait for the 2 animations to finish...
                await Task.WhenAll(scaleUpAnimationTask, fadeOutAnimationTask);

                // scale the frame back to original size
                var scaleDownAnimationTask = ListPermis.ScaleTo(1, 100);
                // set opacity back to 1 (solid)
                var fadeInAnimationTask = ListPermis.FadeTo(1, 100);

                // wait for the 2 animations to finish...
                await Task.WhenAll(scaleDownAnimationTask, fadeInAnimationTask);

                // Redirect to the correspond page...
                await Application.Current.MainPage.Navigation.PushAsync(new Permis.ListPermis());
            };
            ListPermis.GestureRecognizers.Add(tapGestureRecognizer3);
        }
    }
}