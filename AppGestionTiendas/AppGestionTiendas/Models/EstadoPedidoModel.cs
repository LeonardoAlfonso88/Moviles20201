using System;
using AppGestionTiendas.Servicios.Propagacion;

namespace AppGestionTiendas.Models
{
    public class EstadoPedidoModel : BaseModel
    {
        #region Properties
        private string estado;
        public PedidoModel Pedido { get; set; }
        #endregion Properties

        #region Initialize
        public EstadoPedidoModel() { }
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
