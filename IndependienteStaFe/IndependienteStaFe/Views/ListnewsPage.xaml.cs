using Android.Arch.Lifecycle;
using IndependienteStaFe.Services;
using IndependienteStaFe.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static IndependienteStaFe.Models.News;

namespace IndependienteStaFe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListnewsPage : ContentPage
    {
       
      
        public ListnewsPage()
        {
           
         
            InitializeComponent();

            Repository repo= new Repository();

            var news =repo.getNews();

            Lista.ItemsSource = news.data;
        }

       
    }
}