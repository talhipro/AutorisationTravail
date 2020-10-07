using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutorisationTravail.Views.Permis.PermisPenetrationEspaceConfine
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DemandePermisPenetrationEspaceConfine : ContentPage
    {
        public DemandePermisPenetrationEspaceConfine()
        {
            InitializeComponent();
        }

        private async void PickFileAptitude_Clicked(object sender, EventArgs e)
        {
            try
            {
                FileData fileData = await CrossFilePicker.Current.PickFile();
                if (fileData == null)
                    return; // user canceled file picking

                string fileName = fileData.FileName;
                string contents = System.Text.Encoding.UTF8.GetString(fileData.DataArray);

                System.Console.WriteLine("File name chosen: " + fileName);
                System.Console.WriteLine("File data: " + contents);

                AptitudeFileName.Text = fileName;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception choosing file: " + ex.ToString());
            }
        }

        private async void BackBtn_Tapped(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}