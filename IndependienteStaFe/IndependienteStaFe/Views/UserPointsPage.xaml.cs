using IndependienteStaFe.Models;
using IndependienteStaFe.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IndependienteStaFe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPointsPage : ContentPage
    {
        public UserPointsPage()
        {
            InitializeComponent();
            Repository repository = new Repository();
            string token = App.Current.Properties["token"].ToString();

            userPuntos uPoints = repository.getGetUserPoints(token).Result;

            puntos.Text = uPoints.Points.ToString();

        }
    }
}