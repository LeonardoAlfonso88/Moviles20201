using System;
using AppGestionTiendas.Servicios.Propagacion;

namespace AppGestionTiendas.Models
{
    public class EstadoProductoModel : BaseModel
    {
        #region Properties
        private string estado;
        public ProductoModel Producto { get; set; }
        #endregion Properties

        #region Initialize
        public EstadoProductoModel() { }
        #endregion Initialize

        #region Getters & Setters
        public string Estado
        {
            get { return estado; }
            set
            {
                estado = value;
                OnPropertyChanged();
            }
        }
        #endregion Getters & Setters
    }
}
