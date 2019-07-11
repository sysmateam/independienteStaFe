using Acr.UserDialogs;
using Android.Arch.Lifecycle;
using IndependienteStaFe.Models;
using IndependienteStaFe.Services;
using IndependienteStaFe.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static IndependienteStaFe.Models.News;

namespace IndependienteStaFe.Views
{
    [DesignTimeVisible(false)]
    public partial class ListnewsPage : ContentPage
    {
        IUserDialogs Dialogs = UserDialogs.Instance;
        Repository repo = new Repository();

        public ListnewsPage()
        {
           
         
            InitializeComponent();

            Repository repo= new Repository();

            var news =repo.getNews();

            Lista.ItemsSource = news.data;
        }



        public async void Logout_Clicked(object sender, EventArgs e)
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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            
        }

    }
}