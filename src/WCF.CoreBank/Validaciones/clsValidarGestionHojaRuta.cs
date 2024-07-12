using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF.CoreBank.Validaciones.Interface;
using EntityLayer;

namespace WCF.CoreBank.Validaciones
{
    public class clsValidarGestionHojaRuta : IConfigValidacion
    {
        public void setObjeto<T>(T obj)
        {

        }

        public Dictionary<string, reglaValidacion[]> configuracion()
        {
            Dictionary<string, reglaValidacion[]> dConfiguracion = new Dictionary<string, reglaValidacion[]>
            {
                {
                    "idDetalleHojaRuta", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="numerico"}
                    }
                },
                {
                    "idResultado", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="numerico"}
                    }
                },
                {
                    "idMotivoMora", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="numerico"}
                    }
                },
                {
                    "idTipoCliente", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="numerico"}
                    }
                },
                {
                    "lRecuperable", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="booleano"}
                    }
                },
                {
                    "cObservacion", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="longitudMax", value="500"}
                    }
                },
                {
                    "dFechaPromesa", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="fecha"}
                    }
                },
                {
                    "nMontoPromesa", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="decimal", value="2"}
                    }
                },
                {
                    "cObservacionPromesa", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="longitudMax", value="250"}
                    }
                },
                {
                    "lVisitar", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="booleano"}
                    }
                },
                {
                    "dFechaVisita", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="fecha"}
                    }
                },
                {
                    "cObservacionVisita", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="longitudMax", value="250"}
                    }
                },
                {
                    "cLatitud", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="decimal"}
                    }
                },
                {
                    "cLongitud", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="decimal"}
                    }
                },
                {
                    "dFechaRegistraCliente", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="fecha"}
                    }
                },
                {
                    "lDomVerificado", 
                    new reglaValidacion[]
                    {
                       new reglaValidacion {type="booleano"}
                    }
                },
                {
                    "lNotificacionEntregada", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="booleano"}
                    }
                }
            };
            return dConfiguracion;
        }
    }
}