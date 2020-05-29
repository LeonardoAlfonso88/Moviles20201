using AppGestionTiendas.Servicios.Propagacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppGestionTiendas.Models
{
    public class BaseModel : NotificationObject
    {
        #region Properties
        [JsonIgnore]
        public long ID { get; set; }
        #endregion Properties
    }
}
