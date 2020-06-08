using AppGestionTiendas.Servicios.Propagacion;
using AppGestionTiendas.Views;
using Plugin.GoogleClient;
using Plugin.GoogleClient.Shared;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppGestionTiendas.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        //Atributos
        private string nombre {get;set;}
        private IGoogleClientManager googleClientManager;

        private int contarLogin;

        //Commands
        public ICommand InicioSesion { get; set; }
        public ICommand InicioSesionNormal { get; set; }


        //Getters y Setters
        public string NombrePersona
        {
            get { return nombre; }
            set 
            {
                nombre = value;
                OnPropertyChanged();
            }
        }
        public int ContarLogin
        {
            get { return contarLogin; }
            set
            {
                contarLogin = value;
                OnPropertyChanged();
            }
        }

        public LoginViewModel()
        {
            InicioSesion = new Command(() => InicioSesionCommand(),() => true);
            InicioSesionNormal = new Command(async () => await IniciarSesionNavegacion(), () => true);
            ContarLogin = 0;
            googleClientManager = CrossGoogleClient.Current;
        }

        private async void InicioSesionCommand()
        {
            googleClientManager.OnLogin += OnLoginCompleted;
            try
            {
                await googleClientManager.LoginAsync();
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", e.ToString(), "OK");
            }
        }

        private async Task IniciarSesionNavegacion()
        {
            await NavigationService.PushPage(new CategoryView());
        }

        private void OnLoginCompleted(object sender, GoogleClientResultEventArgs<GoogleUser> e)
        {
            if(e != null)
            {
                GoogleUser user = e.Data;
                NombrePersona = user.Name;
            }
        }
    }
}
