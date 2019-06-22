using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using static IndependienteStaFe.Models.News;

namespace IndependienteStaFe.ViewModels
{

    public class NewsViewModel : INotifyPropertyChanged
    {
        public string urlnews = "https://crmpuntos.oliviadirect.co/services/content/list-news.php";
        public HttpClient _Client = new HttpClient();
        public ObservableCollection<NewsDetail> _post;

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
