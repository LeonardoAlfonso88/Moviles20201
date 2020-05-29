using System;
namespace AppGestionTiendas.Models
{
    public class PerfilModel : BaseModel
    {
        #region Properties
        public string NombrePerfil { get; set; }
        public UsuarioModel Usuario { get; set; }
        #endregion Properties

        #region Initialize
        public PerfilModel() { }
        #endregion Initialize

        #region Getters & Setters

        #endregion Getters & Setters
    }
}
