using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF.CoreBank.Validaciones.Interface;
using EntityLayer;

namespace WCF.CoreBank.Validaciones
{
    public class clsValidarSolicitud : IConfigValidacion
    {
        public void setObjeto<T>(T obj) 
        {
 
        }

        public Dictionary<string, reglaValidacion[]> configuracion()
        {
            reglaValidacion regla = new reglaValidacion();
            Dictionary<string, reglaValidacion[]> dConfiguracion = new Dictionary<string, reglaValidacion[]>
            {
                {
                    "cDocumentoID", 
                    new reglaValidacion[]
                    {  
                        new reglaValidacion {type = "aaaaa", value="bbbbbb", msgError="cccccccc"},
                        new reglaValidacion {type = "aaaaa", value="bbbbbb", msgError="cccccccc"},
                        new reglaValidacion {type = "aaaaa", value="bbbbbb", msgError="cccccccc"},
                    }
                }
            };

            return dConfiguracion;
        }
    }
}