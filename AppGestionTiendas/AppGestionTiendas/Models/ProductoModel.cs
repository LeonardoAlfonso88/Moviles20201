using System;
using System.Collections.Generic;
using AppGestionTiendas.Servicios.Propagacion;

namespace AppGestionTiendas.Models
{
    public class ProductoModel : BaseModel
    {
        #region Properties
        private double precio;
        private string nombre;
        private string tamano;
        private string fechaVencimiento;
        private UbicacionModel ubicacion;
        private EstadoProductoModel estado;
        public QRModel QR { get; set; }
        private PedidoModel pedido;
        #endregion Properties

        #region Initialize
        public ProductoModel(UbicacionModel ubicacion, EstadoProductoModel estado, QRModel QR)
        {
            this.ubicacion = ubicacion;
            this.estado = estado;
            this.QR = QR;
        }
        #endregion Initialize

        #region Getters & Setters
        public double Precio
        {
            get { return precio; }
            set
            {
                precio = value;
                OnPropertyChanged();
            }
        }
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged();
            }
        }
        public string Tamano
        {
            get { return tamano; }
            set
            {
                tamano = value;
                OnPropertyChanged();
            }
        }
        public string FechaVencimiento
        {
            get { return fechaVencimiento; }
            set
            {
                fechaVencimiento = value;
                OnPropertyChanged();
            }
        }
        public PedidoModel Pedido
        {
            get { return pedido; }
            set
            {
                pedido = value;
                OnPropertyChanged();
            }
        }
        #endregion Getters & Setters
    }
}
