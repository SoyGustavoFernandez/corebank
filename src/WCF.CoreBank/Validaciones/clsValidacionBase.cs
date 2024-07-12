using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityLayer;
using System.Reflection;
using WCF.CoreBank.Validaciones.Interface;
using System.Data;
using System.Text.RegularExpressions;

namespace WCF.CoreBank.Validaciones
{
    public class clsValidacionBase
    {
        public clsMsjError objError;
        public IObjetoValidado objValidadoTmp;

        public clsValidacionBase()
        {
            objError = new clsMsjError();
        }

        public clsMsjError validacion<T>(IObjetoValidado objValidado_, IConfigValidacion objConfig)
        {
            //objError.clearList();
            objValidadoTmp = objValidado_;
            var objCliente = objValidado_.getObjeto();


            Dictionary<string, reglaValidacion[]> config = objConfig.configuracion();
            foreach (KeyValuePair<string, reglaValidacion[]> item in config)
            {
                bool lRequerido = true;
                string valorObjeto = getValorObjeto(objCliente, item.Key);

                foreach (reglaValidacion regla in item.Value)
                {
                    if (regla.type == "lRequerido")
                        lRequerido = Convert.ToBoolean(regla.value);
                    else if(valorObjeto == item.Key+": Campo no encontrado")
                        objError.AddError(valorObjeto);
                    else if (lRequerido || valorObjeto.Length > 0)
                        ValidarItem(regla, valorObjeto, item.Key);
                }
            }

            return objError;
        }

        private void ValidarItem(reglaValidacion cRegla, string cValor, string key)
        {
            switch (cRegla.type)
            {
                case "longitud":
                    longitud(cRegla,cValor, key);
                    break;
                case "longitudMax":
                    longitudMax(cRegla, cValor, key);
                    break;
                case "longitudMin":
                    longitudMin(cRegla, cValor, key);
                    break;
                case "longitudMinMax":
                    longitudMinMax(cRegla, cValor, key);
                    break;
                case "numerico":
                    numerico(cRegla, cValor, key);
                    break;
                case "decimal":
                    esDecimal(cRegla, cValor, key);
                    break;
                case "alfabetico":
                    alfabetico(cRegla, cValor, key);
                    break;
                case "booleano":
                    booleano(cRegla, cValor, key);
                    break;
                case "fecha":
                    fecha(cRegla, cValor, key);
                    break;
                case "email":
                    email(cRegla, cValor, key);
                    break;
                case "exeExpresion":
                    exeExpresion(cRegla, cValor, key);
                    break;
                case "longitudDocumento":
                    longitudDocumento(cRegla, cValor, obtenerValor("idTipoDocumento"), key);
                    break;
                default:
                    noFuncion(cRegla, key);
                    break;
                    
            }
        }
        /***************************************************************************************************/
        private void longitudDocumento(reglaValidacion cRegla, string cValor, string idTipoDocumento, string key)
        {
            try
            {
                if(idTipoDocumento == "")
                    objError.AddError("idTipoDocumento: campo no encontrado");
                int docLength = 0;
                string documento = "";
                if (idTipoDocumento == "1") { docLength = 8; documento="DNI";}
                else if (idTipoDocumento == "2") { docLength = 11; documento = "Carné de extranjería"; }
                else if (idTipoDocumento == "3") { docLength = 11; documento = "Pasaporte"; }
                else if (idTipoDocumento == "4") { docLength = 12; documento = "RUC"; }

                if(docLength == 0)
                    objError.AddError("No se encontro un tamaño para este idTipoDocumento");
                else if (cValor.Length != docLength)
                    objError.AddError((cRegla.msgError == "" || cRegla.msgError == null) ? (cRegla.msgError.Replace("%tipoDoc%", documento)).Replace("%value%", docLength.ToString()) : cRegla.msgError);
            }
            catch (Exception ex)
            {
                objError.AddError("longitudDocumento("+key+"): " + ex.Message);
            }
        }

        public void longitud(reglaValidacion cRegla, string cValor, string key)
        {
            try
            {
                Regex expresion = new Regex("^[0-9]+$");
                if (!expresion.IsMatch(cRegla.value))
                    objError.AddError("El campo Value con respecto a " + key + " no es válido");
                if (Convert.ToInt32(cRegla.value) != cValor.Length)
                    objError.AddError((cRegla.msgError == "" || cRegla.msgError == null) ? "El campo " + key + "debe tener " + cRegla.value + " dígitos." : cRegla.msgError);
            }
            catch (Exception ex)
            {
                objError.AddError("longitud("+key+"): " + ex.Message);
            }
        }

        private void longitudMax(reglaValidacion cRegla, string cvalor, string key)
        {
            try
            {
                Regex expresion = new Regex("^[0-9]+$");
                if (!expresion.IsMatch(cRegla.value))
                    objError.AddError("El campo Value con respecto a "+key+" no es válido");
                else if (cvalor.Length > Convert.ToInt32(cRegla.value))
                    objError.AddError((cRegla.msgError == "" || cRegla.msgError == null) ? "El campo " + key + "debe tener como máximo " + cRegla.value + " dígitos." : cRegla.msgError);
            }
            catch (Exception ex)
            {
                objError.AddError("longitud("+key+"): " + ex.Message);
            }
        }

        private void longitudMin(reglaValidacion cRegla, string cvalor, string key)
        {
            try
            {
                Regex expresion = new Regex("^[0-9]+$");
                if (!expresion.IsMatch(cRegla.value))
                    objError.AddError("El campo Value con respecto a " + key + " no es válido");
                else if (cvalor.Length < Convert.ToInt32(cRegla.value))
                    objError.AddError((cRegla.msgError == "" || cRegla.msgError == null) ? "El campo " + key + "debe tener como mínimo" + cRegla.value + " dígitos." : cRegla.msgError);
            }
            catch (Exception ex)
            {
                objError.AddError("longitudMin("+key+"): " + ex.Message);
            }
        }

        private void longitudMinMax(reglaValidacion cRegla, string cvalor, string key)
        {
            try
            {
                string[] val = cRegla.value.Split(',');
                if (cvalor.Length > Convert.ToInt32(val[0]) && cvalor.Length < Convert.ToInt32(val[1]))
                    objError.AddError((cRegla.msgError == "" || cRegla.msgError == null) ? "El campo " + key + "debe tener entre " + val[0] + " y " + val[1] + " dígitos." : cRegla.msgError);
            }
            catch (Exception ex)
            {
                objError.AddError("longitudMinMax("+key+"): " + ex.Message);
            }
        }

        private void numerico(reglaValidacion cRegla, string cValor, string key)
        {
            try
            {
                Regex expresion = new Regex("^[0-9]+$");
                if (!expresion.IsMatch(cValor))
                    objError.AddError((cRegla.msgError == "" || cRegla.msgError == null) ? "El campo " + key + " no es un dato numérico." : cRegla.msgError);
            }
            catch (Exception ex)
            {
                objError.AddError("numero("+key+"): " + ex.Message);
            }
        }

        private void esDecimal(reglaValidacion cRegla, string cValor, string key)
        {
            try
            {
                Regex expresion = new Regex("^[0-9]([.,][0-9]{1,3})?$");
                decimal dec;
                //if (!expresion.IsMatch(cValor))
                if (!decimal.TryParse(cValor, out dec))
                    objError.AddError((cRegla.msgError == "" || cRegla.msgError == null) ? "El campo " + key + " no es un dato de tipo decimal." : cRegla.msgError);
            }
            catch (Exception ex)
            {
                objError.AddError("numero("+key+"): " + ex.Message);
            }
        }

        private void alfabetico(reglaValidacion cRegla, string cValor, string key)
        {
            try
            {
                Regex expresion = new Regex(@"^[a-zA-Z]+$");
                if (!expresion.IsMatch(cValor))
                    objError.AddError((cRegla.msgError == "" || cRegla.msgError == null) ? "El campo " + key + " no es un dato de tipo alfabético." : cRegla.msgError);
            }
            catch (Exception ex)
            {
                objError.AddError("alfabetico("+key+"): " + ex.Message);
            }
        }

        private void booleano(reglaValidacion cRegla, string cValor, string key)
        {
            try
            {
                Regex expresion = new Regex("^(True|False|TRUE|FALSE|1|0)$");
                if (!expresion.IsMatch(cValor))
                    objError.AddError((cRegla.msgError == "" || cRegla.msgError == null) ? "El campo " + key + " no es un dato de tipo booleano." : cRegla.msgError);
            }
            catch (Exception ex)
            {
                objError.AddError("booleano(" + key + "): " + ex.Message);
            }
        }

        private void fecha(reglaValidacion cRegla, string cValor, string key)
        {
            try
            {
                DateTime dateValue;
                if (!DateTime.TryParse(cValor, out dateValue))
                    objError.AddError((cRegla.msgError == "" || cRegla.msgError == null) ? "El campo " + key + " no es un dato de tipo fecha." : cRegla.msgError);
            }
            catch (Exception ex)
            {
                objError.AddError("fecha(" + key + "): " + ex.Message);
            }
        }

        private void email(reglaValidacion cRegla, string cValor, string key)
        {
            try
            {
                Regex expresion = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                if (!expresion.IsMatch(cValor))
                    objError.AddError((cRegla.msgError == "" || cRegla.msgError == null) ? "El campo " + key + " no es un dato de tipo E-mail." : cRegla.msgError);
            }
            catch (Exception ex)
            {
                objError.AddError("email("+key+"): " + ex.Message);
            }
        }

        public void exeExpresion(reglaValidacion cRegla, string cValor, string key)
        {
            try
            {
                string cValidar = cRegla.value.Replace("%value%", cValor);
                DataTable dtComputable = new DataTable();
                if (!Convert.ToBoolean(dtComputable.Compute(cValidar.Trim(), "")))
                    objError.AddError(cRegla.msgError);
            }
            catch (Exception ex)
            {
                objError.AddError("exeExpresion("+key+"): " + ex.Message);
            }
        }

        private void noFuncion(reglaValidacion cRegla, string key)
        {
            try
            {
                objError.AddError("No se encontró la regla: " + cRegla.type);
            }
            catch (Exception ex)
            {
                objError.AddError("noFuncion("+key+"): " + ex.Message);
            }
        }

        /***************************************************************************************************/
        private string getValorObjeto(object objCliente, string key)
        {
            foreach (var prop in objCliente.GetType().GetProperties())
            {
                if (prop.Name == key)
                    return prop.GetValue(objCliente, null).ToString();
            }
            return key+": Campo no encontrado";
        }

        private string obtenerValor(string key)
        {
            try
            {
                string valor = "";
                foreach (var prop in objValidadoTmp.getObjeto().GetType().GetProperties())
                {
                    if (prop.Name == key)
                        valor = prop.GetValue(objValidadoTmp.getObjeto(), null).ToString();
                }

                return valor;
            }
            catch (Exception ex)
            {
                objError.AddError("obtenerValor(" + key + "): " + ex.Message);
                return "";
            }
        }
    }
}