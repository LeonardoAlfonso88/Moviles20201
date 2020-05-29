using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Visual.Views;
using Xamarin.Forms;

namespace Visual.ViewModels
{
    public class MainPageViewModel
    {
        #region Properties

        public ICommand BackCommand { get; set; }
        public ICommand InfoCommand { get; set; }
        
        #endregion

        #region Getters y Setters

        #endregion Getters y Setters

        public MainPageViewModel()
        {
            BackCommand = new Command(async () => await Back(), () => true);
            InfoCommand = new Command(async () => await Info(), () => true);
        }

        public async Task Back()
        {
            var navigationPage = (NavigationPage)Application.Current.MainPage;
            await navigationPage.PopAsync();
        }

        public async Task Info()
        {
            MessageViewPop popUp = new MessageViewPop();
            ((MessageViewModel)popUp.BindingContext).Message = "Barcelona es el mejor equipo del mundo";
            await PopupNavigation.Instance.PushAsync(popUp);
        }
    }
}
