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
    public partial class mPage : ContentPage
    {
        public mPage()
        {
            InitializeComponent();



            listView.ItemSelected += async (sender, e) =>
            {
               
                    var navPage = new NavigationPage(new RecuperarClavePage());
                    Application.Current.MainPage = navPage;

                await navPage.PushAsync(new UserInfoPage());
               
            };
        }
    }
}