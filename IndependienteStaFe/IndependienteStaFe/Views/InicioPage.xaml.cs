using Acr.UserDialogs;
using IndependienteStaFe.Controls;
using IndependienteStaFe.Models;
using IndependienteStaFe.Services;
using IndependienteStaFe.ViewModels;
using IndependienteStaFe.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IndependienteStaFe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioPage : ContentPage
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
        Game partido = new Game();
        string cTimer;
        private int counter = 60;
        System.Timers.Timer timer;
        public InicioPage()
        {
            InitializeComponent();
            BindingContext = new CountdownViewModel();
            var current = Connectivity.NetworkAccess;
            var profiles = Connectivity.ConnectionProfiles;
            News news = new News();
            CountDownTimer countDownTimer = new CountDownTimer();
            if (current == NetworkAccess.Internet)
            {
                string limit = "3";
                if (App.Current.Properties.ContainsKey("token"))
                {
                    token = App.Current.Properties["token"].ToString();
                }
                news = repo.getNews(token,limit).Result;
                imagen.Source = news.data[0].Image;
                noticiad.Text = news.data[0].Name.ToString();
                Lista.ItemsSource = news.data;

                partido = repo.getPartidos("3").Result;

                
                countdown.Text = StartCountDownTimer();


            }
            else
            {
                Lista.ItemsSource = news.data;
            }

        }

        public async void Button_Clicked(object sender, EventArgs e)
        {
            Dialogs.ShowLoading("Espere por favor...");
            await Task.Delay(2000);
            Dialogs.HideLoading();

            LoginPage myHomePage = new LoginPage();
            NavigationPage.SetHasNavigationBar(myHomePage, true);
            await Navigation.PushModalAsync(myHomePage);
        }

        public async void Noticias_Clicked(object sender, EventArgs e)
        {
            Dialogs.ShowLoading("Espere por favor...");
            await Task.Delay(2000);
            Dialogs.HideLoading();

            ListnewsPage myHomePage = new ListnewsPage();
            NavigationPage.SetHasNavigationBar(myHomePage, true);
            await Navigation.PushModalAsync(myHomePage);
        }
        
        public async void Register_Clicked(object sender, EventArgs e)
        {
            Dialogs.ShowLoading("Espere por favor...");
            await Task.Delay(1000);
            Dialogs.HideLoading();

            RegisterPage myHomePage = new RegisterPage();
            NavigationPage.SetHasNavigationBar(myHomePage, true);
            await Navigation.PushModalAsync(myHomePage);
        }
        public async void Membership_Clicked(object sender, EventArgs e)
        {
            Dialogs.ShowLoading("Espere por favor...");
            await Task.Delay(1000);
            Dialogs.HideLoading();

            MembemshipPage myHomePage = new MembemshipPage();
            NavigationPage.SetHasNavigationBar(myHomePage, true);
            await Navigation.PushModalAsync(myHomePage);
        }
        private void EvetClicked(object s, SelectedItemChangedEventArgs e)
        {

            var obj = (News.Data)e.SelectedItem;
            string param = obj.NewsId.ToString();
            NewsDetail newsdetail = repo.getNewsDetail(param).Result;


            NewsDetailPage myHomePage = new NewsDetailPage(newsdetail);
            NavigationPage.SetHasNavigationBar(myHomePage, false);
            Navigation.PushModalAsync(myHomePage);

        }


        public string  StartCountDownTimer()
        {
            endTime = Convert.ToDateTime(partido.data[0].DateGame);
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            
            timer.Enabled = true;
            TimeSpan ts = endTime - DateTime.Now;
            cTimer = ts.ToString("d' Días 'h' Horas 'm' Minutos 's' Segundos'");
            timer.Start();
            if ((ts.TotalMilliseconds < 0) || (ts.TotalMilliseconds < 1000))
            {
                timer.Stop();
            }
            return cTimer;
        }
       
       

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var vm = BindingContext as BaseViewModel;
            await vm?.LoadAsync();
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            var vm = BindingContext as BaseViewModel;
            await vm?.UnloadAsync();
        }
    }
}