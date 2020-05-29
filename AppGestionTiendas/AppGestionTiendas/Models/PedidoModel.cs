using System;
using System.Collections.Generic;
using AppGestionTiendas.Servicios.Propagacion;

namespace AppGestionTiendas.Models
{
    public class PedidoModel : BaseModel
    {
        #region Properties
        private double valorTotal;
        private EstadoPedidoModel estado;
        public UsuarioModel Usuario { get; set; }
        private List<ProductoModel> productos;
        #endregion Properties

        #region Initialize
        public PedidoModel(EstadoPedidoModel estado)
        {
            this.estado = estado;
        }
        #endregion Initialize

        #region Getters & Setters
        public double ValorTotal
        {
            get { return valorTotal; }
            set
            {
                valorTotal = value;
                OnPropertyChanged();
            }
        }
        public EstadoPedidoModel Estado
        {
            get { return estado; }
            set
            {
                estado = value;
                OnPropertyChanged();
            }
        }
        public List<ProductoModel> Productos
        {
            get { return productos; }
            set
            {
                productos = value;
                OnPropertyChanged();
            }
        }
        #endregion Getters & Setters

    }
}
