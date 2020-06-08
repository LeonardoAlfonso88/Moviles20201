using AppGestionTiendas.Servicios.Navigation;
using AppGestionTiendas.Servicios.Propagacion;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionTiendas.ViewModels
{
    public class ViewModelBase : NotificationObject
    {

        #region Properties
        public NavigationService NavigationService { get; set; }
        #endregion

        #region Getters & Setters

        #endregion Getters & Setters

        public ViewModelBase()
        {
            NavigationService = App.NavigationService;
        }

        public virtual async Task ConstructorAsync(object parameters)
        {
            await Task.FromResult(true);
        }
    }
}
