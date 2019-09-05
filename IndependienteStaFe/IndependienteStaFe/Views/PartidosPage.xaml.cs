using IndependienteStaFe.Services;
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IndependienteStaFe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PartidosPage : ContentPage
    {
        Repository repo = new Repository();
        public PartidosPage()
        {
            InitializeComponent();
            var par = repo.getPartidos("3").Result;
            var date = DateTime.Parse(par.data[0].DateGame, new CultureInfo("es-ES"));
            var dayweek = date.DayOfWeek;

            partido.Text = par.data[0].DateGame;
            team1.Source = par.data[0].LocalShield;
            team2.Source = par.data[0].VisitorShield;
        }
    }
}