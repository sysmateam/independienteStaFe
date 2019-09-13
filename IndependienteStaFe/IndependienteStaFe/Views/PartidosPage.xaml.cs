using IndependienteStaFe.Services;
using System;
using System.Globalization;
using System.Threading.Tasks;
using Xamarin.Forms;
using Acr.UserDialogs;
using Xamarin.Forms.Xaml;

namespace IndependienteStaFe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PartidosPage : ContentPage
    {
        Repository repo = new Repository();
        IUserDialogs Dialogs = UserDialogs.Instance;
        public PartidosPage()
        {
            InitializeComponent();
            var par = repo.getPartidos("3").Result;
            var date = DateTime.Parse(par.data[0].DateGame, new CultureInfo("es-ES"));
            var dayweek = date.DayOfWeek;

            partido.Text = par.data[0].DateGame;
            team1.Source = par.data[0].LocalShield;
            team2.Source = par.data[0].VisitorShield;
            Name1.Text = par.data[0].LocalTeamName;
            Name2.Text = par.data[0].VisitorTeamName;
            Lista.ItemsSource = par.data;

            
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




        public async void Home_Clicked(object sender, EventArgs e)
        {
            Dialogs.ShowLoading("Espere por favor...");
            await Task.Delay(2000);
            Dialogs.HideLoading();

            InicioPage myHomePage = new InicioPage();
            NavigationPage.SetHasNavigationBar(myHomePage, true);
            await Navigation.PushModalAsync(myHomePage);
        }
    }
   
}