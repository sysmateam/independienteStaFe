using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using IndependienteStaFe.Models;

namespace IndependienteStaFe.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
        public partial class MainPage : MasterDetailPage
        {
       
            public MainPage()
            {
                InitializeComponent();
               navigationDrawerList.ItemsSource = GetMasterPageLists();

           
            }

        private void OnMenuSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageList)e.SelectedItem;

            if (item.Title == "Usuario")
            {
                Detail.Navigation.PushAsync(new UserInfoPage());
                IsPresented = false;
            }
            if (item.Title == "Puntos")
            {
                Detail.Navigation.PushAsync(new UserInfoPage());
                IsPresented = false;
            }
            if (item.Title == "Usuario")
            {
                Detail.Navigation.PushAsync(new ListvideosPage());
                IsPresented = false;
            }
            //   else
            // {
            //   Application.Current.Properties["MenuName"] = item.Title;
            // Detail = new NavigationPage(new HomeTabbedPage());
            //IsPresented = false;
            //}
        }
        List<MasterPageList> GetMasterPageLists()
        {
            return new List<MasterPageList>
            {
                new MasterPageList() { Title = "Usuario", Icon = "home.png" },
                new MasterPageList() { Title = "Puntos", Icon = "admin.png" },
                new MasterPageList() { Title = "Videos", Icon = "setting.png" }
            };
        }
    }

    //This class used for binding ListView. We can move it to other separate files as well   
    public class MasterPageList
    {
        public string Title { get; set; }
        public string Icon { get; set; }
    }

}