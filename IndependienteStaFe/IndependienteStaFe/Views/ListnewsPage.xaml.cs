using Android.Arch.Lifecycle;
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
        }

        protected override async void OnAppearing()
        {
            var vm = BindingContext as ViewModels.NewsViewModel;
            var content = await vm._Client.GetStringAsync(vm.urlnews);
            var Post = JsonConvert.DeserializeObject<NewsHead>(content);
            
            vm._post = new ObservableCollection<NewsDetail>(Post.NewsDetail);
            Lista.ItemsSource = vm._post;
            base.OnAppearing();
        }
    }
}