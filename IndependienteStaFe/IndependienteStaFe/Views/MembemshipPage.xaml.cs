using Acr.UserDialogs;
using IndependienteStaFe.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IndependienteStaFe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MembemshipPage : ContentPage
    {
        IUserDialogs Dialogs = UserDialogs.Instance;
        public MembemshipPage()
        {
            InitializeComponent();

            Repository repo = new Repository();
            var membresias = repo.getMembresia();

            Lista.ItemsSource = membresias.data.ToString();
        }

        public async void UpdateMembreship_Clicked(object sender, EventArgs e)
        {
           


            Dialogs.ShowLoading("Cambia tu membresía..."); ;
            await Task.Delay(2000);
            Dialogs.HideLoading();

            UpdateMembershipPage myHomePage = new UpdateMembershipPage();


            NavigationPage.SetHasNavigationBar(myHomePage, false);



            await Navigation.PushModalAsync(myHomePage);


        }
    }
}