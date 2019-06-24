﻿using IndependienteStaFe.ViewModels;
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
        public LoginPage()
        {
            var vm = new LoginViewModel();
            this.BindingContext = vm;
            vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again", "OK");
            InitializeComponent();

            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                vm.SubmitCommand.Execute(null);
            };
        }

        public void Button_Clicked(object sender, EventArgs e)
        {
            var navPage = new NavigationPage(new LoginPage());
            Application.Current.MainPage = navPage;

             navPage.PushAsync(new MainPage());
   
           
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