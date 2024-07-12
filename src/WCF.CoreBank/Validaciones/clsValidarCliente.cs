using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF.CoreBank.Validaciones.Interface;
using EntityLayer;

namespace WCF.CoreBank.Validaciones
{
    public class clsValidarCliente : IConfigValidacion
    {
        public void setObjeto<T>(T obj)
        {

        }

        public Dictionary<string, reglaValidacion[]> configuracion()
        {
            Dictionary<string, reglaValidacion[]> dConfiguracion = new Dictionary<string, reglaValidacion[]>
            {
                {
                    "idUsuario", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="numerico"}
                    }
                },
                {
                    "idTipoDocumento", 
                    new reglaValidacion[]
                    {
                        new reglaValidacion {type="numerico"}
                    }
                },
                {
                    "cDocumentoID", new reglaValidacion[]
                    {  
                        new reglaValidacion {type="longitudDocumento"},
                        new reglaValidacion {type="numerico"}
                    }
                },
                {
                    "nIdActivEco", new reglaValidacion[]
                    {
                        new reglaValidacion {type="numerico"}
                    }
                },
                {
                    "IdTipoPersona", new reglaValidacion[]
                    {
                        new reglaValidacion {type="numerico", value="", msgError="El campo idActividad no es dato numérico"}
                    }
                },
                {
                    "cApellidoPaterno", new reglaValidacion[]{
                        new reglaValidacion {type="lRequerido", value="false", msgError=""},
                        new reglaValidacion {type="longitudMax", value="50", msgError="Supera los 50 carácteres permitidos"},
                        new reglaValidacion {type="alfabetico", value="", msgError="Debe contener solo caracteres del alfabeto"}
                    }
                },
                {
                    "cApellidoMaterno", new reglaValidacion[]{
                        new reglaValidacion {type="lRequerido", value="false", msgError=""},
                        new reglaValidacion {type="longitudMax", value="40", msgError="Supera los 40 carácteres permitidos"},
                        new reglaValidacion {type="alfabetico", value="", msgError="Debe contener solo caracteres del alfabeto"}
                    }
                },
                {
                    "cNombre", new reglaValidacion[]{
                        new reglaValidacion {type="lRequerido", value="false", msgError=""},
                        new reglaValidacion {type="longitudMax", value="200", msgError="Supera los 200 carácteres permitidos"},
                        new reglaValidacion {type="alfabetico", value="", msgError="Debe contener solo caracteres del alfabeto"}
                    }
                },
                {
                    "cRazonSocial", new reglaValidacion[]{
                        new reglaValidacion {type="lRequerido", value="false", msgError=""},
                        new reglaValidacion {type="longitudMax", value="100", msgError="Supera los 100 carácteres permitidos"}
                    }
                },
                {
                    "idDireccion", 
                    new reglaValidacion[]{}
                },
                {
                    "cCorreoCli", new reglaValidacion[]{
                        new reglaValidacion {type="longitudMax", value="100", msgError="Supera los 100 carácteres permitidos"},
                        new reglaValidacion {type="email", value="", msgError="E-mail no válido"}
                    }
                },
                {
                    "nNumeroTelefono", 
                    new reglaValidacion[]{}
                }
            };
            return dConfiguracion;
        }
    }
}