using Acr.UserDialogs;
using IndependienteStaFe.Models;
using IndependienteStaFe.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IndependienteStaFe.Views
{
    [DesignTimeVisible(false)]
    public partial class UserInfoPage : ContentPage
    {
        public UserInfoPage()
        {
            InitializeComponent();

            Repository repo = new Repository();
            User user= repo.getGetUser();

            nombre.Text = user.name;
            apellido.Text = user.Lastname;
            ciudad.Text = user.City;
            telefono.Text = user.Cellnumber;
        }


       public async void OnUpdateUser(object sender, EventArgs e)
        {
            if (nombre.Text != null    && telefono.Text != null)
            {
              

                User usuario = new User();
                usuario.name = nombre.Text;
                usuario.Lastname = apellido.Text;
               
                usuario.City = ciudad.Text;
                usuario.Cellnumber = telefono.Text;
                usuario.Gender = lstViewGeneros.SelectedIndex.ToString();
                usuario.Birdhdate = fechaNacimiento.Date;
                usuario.Datapolicy = true;
                usuario.Termsandconditions = true;


                Repository repository = new Repository();

                try
                {

                    repository.PostUpdateUser(usuario);
                    MainPage myHomePage = new MainPage();


                    NavigationPage.SetHasNavigationBar(myHomePage, false);

                    await Navigation.PushModalAsync(myHomePage);
                }

                catch (Exception ex)
                {
                    await DisplayAlert("Registrarse Error", ex.Message, "Gracias");

                }

            }





        }
    }
}