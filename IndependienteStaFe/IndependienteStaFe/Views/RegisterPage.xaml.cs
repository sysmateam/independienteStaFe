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
    public partial class RegisterPage : CarouselPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        

       public void OnClickedFinalizar(object sender, EventArgs e)
        {
            var navPage = new NavigationPage(new RegisterPage());
            Application.Current.MainPage = navPage;

            navPage.PushAsync(new MainPage());


        }
    }
}