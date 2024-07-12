using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF.CoreBank.Validaciones.Interface;
using EntityLayer;

namespace WCF.CoreBank.Validaciones
{
    public class clsValidarDireccion : IConfigValidacion
    {
        public void setObjeto<T>(T obj)
        {

        }

        public Dictionary<string, reglaValidacion[]> configuracion()
        {
            Dictionary<string, reglaValidacion[]> dConfiguracion = new Dictionary<string, reglaValidacion[]>
            {
                {
                    "idDireccion", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="numerico"}
                    }
                },
                {
                    "idCli", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="numerico"}
                    }
                },
                {
                    "idUbigeo", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="numerico"}
                    }
                },
                {
                    "cDireccion", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="longitudMax", value="2"}
                    }
                },
                {
                    "nLat", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="decimal"}
                    }
                },
                {
                    "nLong", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="decimal"}
                    }
                }
            };
            return dConfiguracion;
        }
    }
}