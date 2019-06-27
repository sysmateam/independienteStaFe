using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IndependienteStaFe.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
