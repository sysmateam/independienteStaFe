using IndependienteStaFe.Helpers;
using IndependienteStaFe.Models;
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


        public async void OnClickedFinalizar(object sender, EventArgs args)
        {
            if (nombre.Text != null && password.Text != null && correo.Text != null && password.Text != null && telefono.Text != null)
            {
                MD5HashX2 pwtohash = new MD5HashX2();
               
                User usuario = new User();
                usuario.name = nombre.Text;
                usuario.Lastname = apellido.Text;
                usuario.Id = userid.Text;
                usuario.Emal = correo.Text;
                usuario.Password = pwtohash.MD5Hash(password.Text);
                usuario.City = ciudad.Text;
                usuario.Address = address.Text;
                usuario.Cellnumber = telefono.Text;
                usuario.Gender = lstViewGeneros.SelectedIndex.ToString();
                usuario.Birdhdate = fechaNacimiento.Date;
                usuario.Datapolicy = true;
                usuario.Termsandconditions = true;
                

                Repository repository = new Repository();

                try
                {

                    repository.PostUser(usuario);
                    MainPage myHomePage = new MainPage();


                    NavigationPage.SetHasNavigationBar(myHomePage, false);

                    await Navigation.PushModalAsync(myHomePage);
                }

                catch (Exception ex)
                {
                    await DisplayAlert("Registrarse Error", ex.Message, "Gracias");

                }

            }


            else
            {
                await DisplayAlert("Registrarse", "Verifique la Información", "Gracias");
            }

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