using System;
using Newtonsoft.Json;

namespace AppGestionTiendas.Models
{
    public class CategoriaModel : BaseModel
    {
        #region Properties

        [JsonProperty("idCategoria")]
        public long idCategoria;

        [JsonProperty("categoria")]
        private string categoria;

        [JsonIgnore]
        public QRModel QR { get; set; }
        #endregion Properties

        #region Initialize
        public CategoriaModel() { }
        #endregion Initialize

        #region Getters & Setters
        public long IdCategoria
        {
            get { return idCategoria; }
            set
            {
                idCategoria = value;
                OnPropertyChanged();
            }
        }
        public string Categoria
        {
            get { return categoria; }
            set
            {
                categoria = value;
                OnPropertyChanged();
            }
        }
        #endregion Getters & Setters
    }
}
