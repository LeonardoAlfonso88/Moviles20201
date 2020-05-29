using System;
using System.Collections.Generic;

namespace AppGestionTiendas.Configuracion
{
    public class ConfiguracionRest
    {
        #region Properties
        private readonly string NameSpaceRest;
        public Dictionary<string, string> VerbosConfiguracion { get; set; }
        #endregion Properties

        #region Inicialize
        public ConfiguracionRest()
        {
            NameSpaceRest = "AppGestionTiendas.Servicios.ApiRest.";
            InicializarVerbosConfiguracion();

        }
        #endregion Métodos

        #region Métodos
        private void InicializarVerbosConfiguracion()
        {
            VerbosConfiguracion = new Dictionary<string, string>();
            VerbosConfiguracion.Add("GET", string.Concat(NameSpaceRest, "RequestParametros`1"));
            VerbosConfiguracion.Add("DELETE", string.Concat(NameSpaceRest, "RequestParametros`1"));
            VerbosConfiguracion.Add("POST", string.Concat(NameSpaceRest, "RequestBody`1"));
            VerbosConfiguracion.Add("PUT", string.Concat(NameSpaceRest, "RequestBody`1"));
        }

        #endregion Métodos  
    }
}
