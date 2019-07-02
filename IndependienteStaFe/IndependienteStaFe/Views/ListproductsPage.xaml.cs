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
    public partial class ListproductsPage : ContentPage
    {
        public ListproductsPage()
        {
            InitializeComponent();

            Repository repo = new Repository();
            var productos=repo.getProductos();
            Lista.ItemsSource = productos.data.ToString();
        }
    }
}