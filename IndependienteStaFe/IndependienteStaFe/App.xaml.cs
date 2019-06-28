﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using IndependienteStaFe.Services;
using IndependienteStaFe.Views;

namespace IndependienteStaFe
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<Repository>();
            // MainPage = new MainPage();
             MainPage = new LoginPage();

            

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
