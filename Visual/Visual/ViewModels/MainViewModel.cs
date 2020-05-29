using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Visual.Models;
using Visual.Servicios.Propagacion;
using Visual.Views;
using Xamarin.Forms;

namespace Visual.ViewModels
{
    public class MainViewModel : NotificationObject
    {
        #region Propierties
        public List<TestModel> Nombres { get; set; }
        public bool ImagenVisible { get; set; }

        private TestModel testActual;


        #region Commands
        public ICommand IrFormularioCommand { get; set; }
        public ICommand RecibirUsuarioSeleccionadoCommand { get; set; }
        #endregion Commands

        #endregion Propierties


        #region Getters/Setters
        public TestModel TestActual
        {
            get
            {
                return testActual;
            }
            set
            {
                testActual = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Initialize
        public MainViewModel()
        {
            Nombres = new List<TestModel>()
            {
                new TestModel("Leonardo", "32", "leo@gmail.com", "50000"),
                new TestModel("Laura", "20", "laura@gmail.com", "10000000"),
                new TestModel("Cristian", "21","cristian@gmail.com", "200000000")
            };

            TestActual = new TestModel("Si Usuario", "0", "", "");
            ImagenVisible = true;
            IrFormularioCommand = new Command(async() => await IrFormulario(), () => true);
            RecibirUsuarioSeleccionadoCommand = new Command<TestModel>(async (item) => await RecibirUsuarioSeleccionado(item), (item) => true);
        }


        #endregion Initialize


        #region Métodos
        public async Task IrFormulario()
        {
            var navigationPage = Application.Current.MainPage;           
            NavigationPage wrapper = new NavigationPage(new MainPage());
            await ((NavigationPage)navigationPage).PushAsync(wrapper);
        }

        public async Task RecibirUsuarioSeleccionado(TestModel item)
        {
            TestActual = item;
            MessageViewPop popUp = new MessageViewPop();
            ((MessageViewModel)popUp.BindingContext).Message = "El usuario seleccionado es " + TestActual.Nombre;
            await PopupNavigation.Instance.PushAsync(popUp);
        }
        #endregion Métodos
    }
}


