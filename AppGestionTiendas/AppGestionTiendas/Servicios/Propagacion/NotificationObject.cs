using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppGestionTiendas.Servicios.Propagacion
{
    public class NotificationObject : INotifyPropertyChanged
    {
        public NotificationObject()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
    }
}
