using Acr.UserDialogs;
using IndependienteStaFe.Helpers;
using IndependienteStaFe.Models;
using IndependienteStaFe.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IndependienteStaFe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : CarouselPage
    {
        IUserDialogs Dialogs = UserDialogs.Instance;
        public RegisterPage()
        {
            InitializeComponent();

            Repository repo = new Repository();

            var termconds = "";// repo.getTermConds();
            var poldatos = repo.getPolDatos();

            Ciudades listciudades = repo.getCiudades();

            fechaNacimiento.MaximumDate = DateTime.Parse(DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "-" + (DateTime.Now.Year - 18).ToString());

            foreach (var item in listciudades.data)
            {

                ciudad.Items.Add(item.Name);
                ciudad.Items.IndexOf(item.id.ToString());

            }

            lbltermconds.Source = new HtmlWebViewSource
            {
                // Html = termconds.data[0].Name.ToString() + "<br/>" + termconds.data[0].Content
                Html = ""
            };

            lblpoldatos.Source = new HtmlWebViewSource
            {
                Html = poldatos.data[0].Name.ToString() + "<br/>" + poldatos.data[0].Content
            };


        }
        public async void OnClickedFinalizar(object sender, EventArgs args)
        {
            if (nombre.Text != null && password.Text != null && correo.Text != null && password.Text != null && telefono.Text != null && password.Text.Equals(passwordconf.Text))
            {
                MD5HashX2 pwtohash = new MD5HashX2();

                User usuario = new User();
                usuario.name = nombre.Text;
                usuario.Lastname = apellido.Text;
                usuario.Id = userid.Text;
                usuario.Emal = correo.Text;
                usuario.Password = pwtohash.MD5Hash(password.Text);
                usuario.City = ciudad.SelectedIndex.ToString();
                usuario.Address = address.Text;
                usuario.Cellnumber = telefono.Text;
                usuario.Gender = lstViewGeneros.SelectedIndex.ToString();
                usuario.Birdhdate = fechaNacimiento.Date;
                usuario.Datapolicy = true;
                usuario.Termsandconditions = true;


                Repository repository = new Repository();

                try
                {

                    userCreate user = repository.postUserCreate(usuario).Result;
                    Dialogs.ShowLoading(user.Message.ToString()); ;
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

        private void FechaNacimiento_DateSelected(object sender, DateChangedEventArgs e)
        {

        }
    }
}