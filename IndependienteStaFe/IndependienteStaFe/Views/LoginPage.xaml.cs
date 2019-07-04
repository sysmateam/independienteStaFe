using Acr.UserDialogs;
using IndependienteStaFe.Models;
using IndependienteStaFe.Services;
using IndependienteStaFe.ViewModels;
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
    public partial class LoginPage : ContentPage
    {
        Repository repo = new Repository();
        public LoginPage()
        {
            var vm = new LoginViewModel();
            this.BindingContext = vm;

            


            InitializeComponent();

            usuario.Completed += (object sender, EventArgs e) =>
            {
                password.Focus();
            };

            password.Completed += (object sender, EventArgs e) =>
            {
                vm.SubmitCommand.Execute(null);
            };
        }

        public async void Button_Clicked(object sender, EventArgs e)
        {
            IUserDialogs Dialogs = UserDialogs.Instance;

            

            if(usuario.Text!="" && password.Text != "")
            {
               Login login = repo.ConnectUser(usuario.Text, password.Text).Result;

                if(login.Status=="ok")
                {
                    App.Current.Properties["token"] = login.Jwt;

                    Dialogs.ShowLoading("Ingresando...");
                    await Task.Delay(2000);
                    Dialogs.HideLoading();

                    MainPage myHomePage = new MainPage();
                    NavigationPage.SetHasNavigationBar(myHomePage, false);
                    await Navigation.PushModalAsync(myHomePage);
                }

            }
         
           




        }
        public void ClickedSignin(object sender, EventArgs e)
        {
            var navPage = new NavigationPage(new LoginPage());
            Application.Current.MainPage = navPage;

            navPage.PushAsync(new RegisterPage());


        }

        public void ClickedRecuperarClave(object sender, EventArgs e)
        {
            var navPage = new NavigationPage(new LoginPage());
            Application.Current.MainPage = navPage;

            navPage.PushAsync(new RecuperarClavePage());


        }

    }
}