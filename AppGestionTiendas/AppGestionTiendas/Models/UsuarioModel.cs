using System;
using System.Collections.Generic;
using AppGestionTiendas.Servicios.Propagacion;

namespace AppGestionTiendas.Models
{
    public class UsuarioModel : BaseModel
    {
        #region Properties
        public string Email { get; set; }
        private string nombre;
        private List<DireccionModel> direcciones;
        private List<TelefonoModel> telefonos;
        private PerfilModel perfil;
        private List<PedidoModel> pedidos;
        #endregion Properties

        #region Initialize
        public UsuarioModel(PerfilModel perfil)
        {
            this.perfil = perfil;
        }
        #endregion Initialize

        #region Getters & Setters
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged();
            }
        }
        /* Relación de 0 a muchos con direciones */
        public List<DireccionModel> Direcciones
        {
            get { return direcciones; }
            set
            {
                direcciones = value;
                OnPropertyChanged();
            }
        }
        public List<TelefonoModel> Telefonos
        {
            get { return telefonos; }
            set
            {
                telefonos = value;
                OnPropertyChanged();
            }
        }
        /* Relación de 1 a 1 con Perfil*/
        public PerfilModel Perfil
        {
            get { return perfil; }
            set
            {
                perfil = value;
                OnPropertyChanged();
            }
        }
        public List<PedidoModel> Pedidos
        {
            get { return pedidos; }
            set
            {
                pedidos = value;
                OnPropertyChanged();
            }
        }
        #endregion Getters & Setters
    }
}
