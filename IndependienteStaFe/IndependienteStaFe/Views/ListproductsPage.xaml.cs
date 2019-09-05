using Acr.UserDialogs;
using IndependienteStaFe.Models;
using IndependienteStaFe.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IndependienteStaFe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListproductsPage : ContentPage
    {
        IUserDialogs Dialogs = UserDialogs.Instance;
        Repository repo = new Repository();
        string token = "";

        public ListproductsPage()
        {
            InitializeComponent();

            Repository repo = new Repository();
            if (App.Current.Properties.ContainsKey("token"))
            {
                token = App.Current.Properties["token"].ToString();
            }


            var productos = repo.getProductos(token).Result;
            Lista.ItemsSource = productos.data;

            // clear selected item
            Lista.SelectedItem = null;


        }

        public Command ItemTappedCommand
        {
            get
            {
                return new Command(() =>
                {
                    Product.Data pro = new Product.Data();
                    var obj = pro;
                    string param = obj.ProductId.ToString();
                    ProductInfo product = repo.getProductosInfo(token, param).Result;


                    ProductoDetailPage myHomePage = new ProductoDetailPage(product);
                    NavigationPage.SetHasNavigationBar(myHomePage, false);
                    Navigation.PushModalAsync(myHomePage);
                });
            }
        }

        private void EvetClicked(object s, SelectedItemChangedEventArgs e)
        {

            //string param = obj.ProductId.ToString();
            var obj = (Product.Data)e.SelectedItem;
            string param = obj.ProductId.ToString();

            ProductInfo product = repo.getProductosInfo(token, param).Result;


            ProductoDetailPage myHomePage = new ProductoDetailPage(product);
            NavigationPage.SetHasNavigationBar(myHomePage, false);
            Navigation.PushModalAsync(myHomePage);











        }
    }
}