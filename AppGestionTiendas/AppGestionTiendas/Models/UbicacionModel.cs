using System;
using AppGestionTiendas.Servicios.Propagacion;

namespace AppGestionTiendas.Models
{
    public class UbicacionModel : BaseModel
    {
        #region Properties
        private string lugar;
        public ProductoModel Producto { get; set; }
        #endregion Properties

        #region Initialize
        public UbicacionModel() { }
        #endregion Initialize

        #region Getters & Setters
        public string Lugar
        {
            get { return lugar; }
            set
            {
                lugar = value;
                OnPropertyChanged();
            }
        }
        #endregion Getters & Setters
    }
}
