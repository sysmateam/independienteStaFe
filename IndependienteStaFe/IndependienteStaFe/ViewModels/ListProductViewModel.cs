using Android.Content.Res;
using IndependienteStaFe.Models;
using IndependienteStaFe.Services;
using IndependienteStaFe.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IndependienteStaFe.ViewModels
{
    public class ListProductViewModel: BindableObject
    {
        Repository repo = new Repository();
        string token = "";
        Product productselected = new Product();
        public Command ItemTappedCommand
        {
            get
            {
                return new Command((data) =>
                {

                });
            }
        }
    }
}
