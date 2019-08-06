﻿using Acr.UserDialogs;
using Android.Arch.Lifecycle;
using IndependienteStaFe.Helpers;
using IndependienteStaFe.Models;
using IndependienteStaFe.Services;
using IndependienteStaFe.ViewModels;
using Newtonsoft.Json;
using System;
using Xamarin.Essentials;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static IndependienteStaFe.Models.News;

namespace IndependienteStaFe.Views
{
    [DesignTimeVisible(false)]
    public partial class ListnewsPage : ContentPage
    {
        public ICommand command { get; private set; }
        public partial class CustomerNavigationPage : NavigationPage
        {

            public CustomerNavigationPage() : base(new ListnewsPage()) { BarBackgroundColor = Color.FromHex("FFFF"); }

        }

        IUserDialogs Dialogs = UserDialogs.Instance;
        Repository repo = new Repository();
        DateTime endTime = new DateTime();
        string token = "";
        string limit = "";
        public ListnewsPage()
        {
           
         
            InitializeComponent();
            var current = Connectivity.NetworkAccess;
            var profiles = Connectivity.ConnectionProfiles;
            
            News news= new News();
            if (current == NetworkAccess.Internet)
            {
                news=repo.getNews(token,limit).Result;
                imagen.Source = news.data[0].Image;
                noticiad.Text = news.data[0].Name;
                Lista.ItemsSource = news.data;
            }
            else
            {
                Lista.ItemsSource = news.data;
            }

          
          






      /*      if (Settings.IsLoggedIn == false)
            {
                this.ToolbarItems.Add(new ToolbarItem
                {

                    Text = "Registrarme",
                    Order = ToolbarItemOrder.Primary,
                    Command = new Command(async () =>
                    {
                        Dialogs.ShowLoading("Espere por favor...");
                        await Task.Delay(1000);
                        Dialogs.HideLoading();

                        RegisterPage myHomePage = new RegisterPage();
                        NavigationPage.SetHasNavigationBar(myHomePage, true);
                        await Navigation.PushModalAsync(myHomePage);

                    })


                });
                this.ToolbarItems.Add(new ToolbarItem
                {

                    Text = "INICIO",
                    Order = ToolbarItemOrder.Secondary,
                    Command = new Command(async () =>
                    {
                        Dialogs.ShowLoading("Espere por favor...");
                        await Task.Delay(2000);
                        Dialogs.HideLoading();

                        LoginPage myHomePage = new LoginPage();
                        NavigationPage.SetHasNavigationBar(myHomePage, true);
                        await Navigation.PushModalAsync(myHomePage);

                    })


                });

            }
            else
            {
                this.ToolbarItems.Add(new ToolbarItem
                {

                    Text = "Perfil",
                    IconImageSource= "usuario.png",
                    Order = ToolbarItemOrder.Primary,
                    Command = new Command(async () =>
                    {
                        Dialogs.ShowLoading("Espere por favor...");
                        await Task.Delay(2000);
                        Dialogs.HideLoading();

                        UserInfoPage myHomePage = new UserInfoPage();
                        NavigationPage.SetHasNavigationBar(myHomePage, true);
                        await Navigation.PushModalAsync(myHomePage);

                    })


                });

                this.ToolbarItems.Add(new ToolbarItem
                {

                    Text = "LogOut",
                    IconImageSource = "logout.png",
                    Order = ToolbarItemOrder.Secondary,
                    Command = new Command(async () =>
                    {
                        string token = App.Current.Properties["token"].ToString();
                        userLogOut user = repo.LogOut(token).Result;
                        Settings.IsLoggedIn = false;
                        Dialogs.ShowLoading(user.Message.ToString()); ;
                        await Task.Delay(2000);
                        Dialogs.HideLoading();


                    })


                });
            }*/
            
        }
    
        public async void User_Clicked(object sender, EventArgs e)
        {
            
            string token = App.Current.Properties["token"].ToString();
            userLogOut user= repo.LogOut(token).Result;
            Dialogs.ShowLoading(user.Message.ToString()); ;
            await Task.Delay(2000);
            Dialogs.HideLoading();

            Application.Current.MainPage = new LoginPage();

        }

        private  void EvetClicked(object s, SelectedItemChangedEventArgs e)
        {
          
                var obj = (News.Data)e.SelectedItem;
                string param = obj.NewsId.ToString();
                NewsDetail newsdetail= repo.getNewsDetail(param).Result;
                

                NewsDetailPage myHomePage = new NewsDetailPage(newsdetail);
                NavigationPage.SetHasNavigationBar(myHomePage, false);
                Navigation.PushModalAsync(myHomePage);

        }

        
    }
}