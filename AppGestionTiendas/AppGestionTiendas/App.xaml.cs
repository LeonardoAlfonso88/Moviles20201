using AppGestionTiendas.Servicios.Navigation;
using AppGestionTiendas.Views;
using Plugin.FirebasePushNotification;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGestionTiendas
{
    public partial class App : Application
    {
        #region Properties
        static NavigationService navigationService;
        #endregion

        #region Getters & Setters
        public static NavigationService NavigationService
        {
            get
            {
                if (navigationService == null)
                {
                    navigationService = new NavigationService();
                }
                return navigationService;
            }
        }
        #endregion Getters & Setters



        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginView());
        }

        protected override void OnStart()
        {
            CrossFirebasePushNotification.Current.Subscribe("general");
            CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine($"TOKEN : {p.Token}");
            };
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
