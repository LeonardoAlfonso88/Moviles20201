using System;
using AppGestionTiendas.Servicios.Propagacion;

namespace AppGestionTiendas.Models
{
    public class TelefonoModel : BaseModel
    {
        #region Properties
        private string tipo;
        private string numero;
        public UsuarioModel Usuario { get; set; }
        #endregion Properties

        #region Initialize
        public TelefonoModel() { }
        #endregion Initialize

        #region Getters & Setters
        public string Numero
        {
            get { return numero; }
            set
            {
                numero = value;
                OnPropertyChanged();
            }
        }
        public string Tipo
        {
            get { return tipo; }
            set
            {
                tipo = value;
                OnPropertyChanged();
            }
        }
        #endregion Getters & Setters
    }
}
