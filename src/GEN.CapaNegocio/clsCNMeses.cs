using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNMeses
    {
        clsADMeses adMeses = new clsADMeses();
        public DataTable listarMeses()
        {
            var dt = adMeses.listarMesesXML();
            DataTable dtMeses = dt.Clone();
            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtMeses, LoadOption.OverwriteChanges);
            return dtMeses;

        }

        /// <summary>
        /// Retorna la fecha como cadena para forma de documentos como oficio, cartas y otros
        /// Ejm: 28 de JULIO DE 2014
        /// </summary>
        /// <returns></returns>
        public string retornarFechaDescMes()
        {
            var dtMes = listarMeses().AsEnumerable().Where(x => (int)x["idMeses"] == clsVarGlobal.dFecSystem.Month).ToList();
            return clsVarGlobal.dFecSystem.Day.ToString() + " DE " + dtMes[0]["cMes"].ToString() + " DE " + clsVarGlobal.dFecSystem.Year.ToString();
                    
        }
    }
}
