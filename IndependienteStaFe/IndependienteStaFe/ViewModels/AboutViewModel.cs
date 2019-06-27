using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace IndependienteStaFe.ViewModels
{
    public class AboutViewModel 
    {
        public AboutViewModel()
        {
            

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}