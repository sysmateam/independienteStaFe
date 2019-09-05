using Acr.UserDialogs;
using IndependienteStaFe.Models;
using IndependienteStaFe.Services;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IndependienteStaFe.Views
{
    [DesignTimeVisible(false)]
    public partial class UserInfoPage : ContentPage
    {
        IUserDialogs Dialogs = UserDialogs.Instance;
        public UserInfoPage()
        {
            InitializeComponent();

            fechaNacimiento.MaximumDate = DateTime.Parse(DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "-" + (DateTime.Now.Year - 18).ToString());

            Repository repo = new Repository();
            string token = App.Current.Properties["token"].ToString();
            userInfo user = repo.postUserInfo(token).Result;


            nombre.Text = user.data.Name;
            apellido.Text = user.data.LastName;
            ciudad.Text = user.data.City;
            telefono.Text = user.data.CellNumber;
        }


        public async void OnUpdateUser(object sender, EventArgs e)
        {
            if (nombre.Text != null && telefono.Text != null)
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
                    UserUpdate userUpdate = new UserUpdate();
                    userCreate update = repository.PostUpdateUser(userUpdate).Result;
                    Dialogs.ShowLoading(update.Message.ToString()); ;
                    await Task.Delay(2000);
                    Dialogs.HideLoading();

                    InicioPage myHomePage = new InicioPage();
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