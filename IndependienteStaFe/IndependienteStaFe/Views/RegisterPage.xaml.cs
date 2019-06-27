using IndependienteStaFe.Services;
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

            Repository repo = new Repository();

            var termconds = repo.getTermConds();
            var poldatos = repo.getPolDatos();

            lbltermconds.Text = termconds.data[0].Name.ToString()+'\n' + termconds.data[0].Content.ToString();

            lblpoldatos.Text = poldatos.data[0].Name.ToString() + '\n' + poldatos.data[0].Content.ToString();
        }

        

       public async void OnClickedFinalizar(object sender, EventArgs e)
        {
            MainPage myHomePage = new MainPage();


            NavigationPage.SetHasNavigationBar(myHomePage, false);

            await Navigation.PushModalAsync(myHomePage);


        }

        public void OnClickedNext1(object sender, EventArgs e)
        {
            CurrentPage = page2;

        }

        public void OnClickedNext2(object sender, EventArgs e)
        {
            CurrentPage = page3;

        }

        public void OnClickedNext3(object sender, EventArgs e)
        {
            CurrentPage = page4;

        }
        public void OnClickedBack(object sender, EventArgs e)
        {
            CurrentPage = page1;

        }

        public void OnClickedBack1(object sender, EventArgs e)
        {
            CurrentPage = page2;

        }
    }
}