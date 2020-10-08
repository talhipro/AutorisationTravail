using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutorisationTravail.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuMaster : ContentPage
    {
        public ListView ListView;

        public MenuMaster()
        {
            InitializeComponent();

            BindingContext = new MenuMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MenuMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MenuMenuItem> MenuItems { get; set; }

            public MenuMasterViewModel()
            {
                MenuItems = new ObservableCollection<MenuMenuItem>(new[]
                {
                    new MenuMenuItem { Id = 0, Title = "Demande AT" , TargetType = typeof(DemandeAutorisationTravail.ListDemandeAutorisationTravail),TopMarging = 50,Icon = "menu_icon.png"},
                    new MenuMenuItem { Id = 1, Title = "AT en cours" ,TargetType = typeof(AutorisationTravail.ListAutorisationTravail),TopMarging = 50,Icon = "menu_icon.png"},
                    new MenuMenuItem { Id = 2, Title = "List des Permis", TargetType = typeof(Permis.ListPermis),Icon = "menu_icon.png"},
                    new MenuMenuItem { Id = 3, Title = "Notification" ,Icon = "menu_icon.png"},
                    new MenuMenuItem { Id = 4},
                    new MenuMenuItem { Id = 5},
                    new MenuMenuItem { Id = 6, Title = "Se Déconnecter",TopMarging = 50 ,Icon = "menu_icon.png"},
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        private async void CloseBtn_Tapped(object sender, EventArgs e)
        {
            //await Application.Current.MainPage.Navigation.PopToRootAsync();
        }
    }
}
