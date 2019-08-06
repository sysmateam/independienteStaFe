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
    public partial class ListvideosPage : ContentPage
    {
        public ListvideosPage()
        {
            InitializeComponent();
            Repository repo = new Repository();
            var videos = repo.getVideos();

            imagen.Source = videos.data[0].Image;
            videod.Text = videos.data[0].Name;

            Lista.ItemsSource = videos.data;
           
        }
    }
}