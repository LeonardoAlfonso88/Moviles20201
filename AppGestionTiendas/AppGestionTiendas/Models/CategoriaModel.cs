using System;
using Newtonsoft.Json;

namespace AppGestionTiendas.Models
{
    public class CategoriaModel : BaseModel
    {
        #region Properties

        [JsonProperty("idCategoria")]
        public long IdCategoria { get; set; }

        [JsonProperty("categoria")]
        public string Categoria { get; set; }

        [JsonIgnore]
        public QRModel QR { get; set; }
        #endregion Properties

        #region Initialize
        public CategoriaModel() { }
        #endregion Initialize

        #region Getters & Setters

        #endregion Getters & Setters
    }
}
