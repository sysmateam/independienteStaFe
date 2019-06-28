using Acr.UserDialogs;
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
    public partial class RecuperarClavePage : ContentPage
    {
        IUserDialogs Dialogs = UserDialogs.Instance;
        public RecuperarClavePage()
        {
            InitializeComponent();
        }

        public async void OnRecuperarClave(object sender, EventArgs e)
        {
            

            Dialogs.ShowLoading("Procesando...");
            await Task.Delay(2000);
            Dialogs.HideLoading();


            MainPage myHomePage = new MainPage();


            NavigationPage.SetHasNavigationBar(myHomePage, false);



            await Navigation.PushModalAsync(myHomePage);


        }

        public async void OnCancelar(object sender, EventArgs e)
        {
            Dialogs.ShowLoading("Cancelando...");
            await Task.Delay(1000);
            Dialogs.HideLoading();

            MainPage myHomePage = new MainPage();


            NavigationPage.SetHasNavigationBar(myHomePage, false);



            await Navigation.PushModalAsync(myHomePage);


        }
        

    }
}