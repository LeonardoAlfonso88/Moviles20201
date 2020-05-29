using System;
using AppGestionTiendas.Servicios.Propagacion;

namespace AppGestionTiendas.Models
{
    public class DireccionModel : BaseModel
    {
        #region Properties
        private string direccion;
        private string complementos;
        private string comentarios;
        private bool esFavorita;
        public UsuarioModel Usuario { get; set; }
        #endregion Properties

        #region Initialize
        public DireccionModel() { }
        #endregion Initialize

        #region Getters & Setters
        public string Direccion
        {
            get { return direccion; }
            set
            {
                direccion = value;
                OnPropertyChanged();
            }
        }
        public string Complementos
        {
            get { return complementos; }
            set
            {
                complementos = value;
                OnPropertyChanged();
            }
        }
        public string Comentarios
        {
            get { return comentarios; }
            set
            {
                comentarios = value;
                OnPropertyChanged();
            }
        }
        public bool EsFavorita
        {
            get { return esFavorita; }
            set
            {
                esFavorita = value;
                OnPropertyChanged();
            }
        }
        #endregion Getters & Setters
    }
}
