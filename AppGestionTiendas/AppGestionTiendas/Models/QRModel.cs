using System;
namespace AppGestionTiendas.Models
{
    public class QRModel : BaseModel
    {
        #region Properties
        public string Mensaje { get; set; }
        public string Referencia { get; set; }
        public CategoriaModel Categoria { get; set; }
        public ProductoModel Producto { get; set; }
        #endregion Properties

        #region Initialize
        public QRModel(CategoriaModel Categoria)
        {
            this.Categoria = Categoria;
        }
        #endregion Initialize

        #region Getters & Setters

        #endregion Getters & Setters

    }
}
