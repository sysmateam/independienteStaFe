using IndependienteStaFe.Helpers;
using IndependienteStaFe.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IndependienteStaFe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            if (Settings.IsLoggedIn == false)
            {
               // products.ContentTemplate = new DataTemplate { LoginPage };
            }

        }
    }
}