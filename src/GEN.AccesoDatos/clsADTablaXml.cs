using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace GEN.AccesoDatos
{
    public class clsADTablaXml
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP(); 
       
        public clslisTablasXml listarTablasActualizar()
        {
            clslisTablasXml lista = new clslisTablasXml();

            var dt = objEjeSp.EjecSP("GEN_ListarTablaAct_sp");
            if (dt.Rows.Count>0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    lista.Add(new clsTablasXml()
                    {
                        idTabla = (int)item["idTabla"],
                        cTabla = item["cTabla"].ToString(),
                        idEstado = (int)item["idEstado"],
                        lVigente = (bool)item["lVigente"]
                    });
                }
            }


            return lista;
        }

        public DataTable listarTablasVigente()
        {            
            return objEjeSp.EjecSP("GEN_ListarTablaAct_sp");           
        }

        public DataSet retonarDatosTabla(string cTabla) 
        {
            return objEjeSp.DSEjecSP("GEN_RetDatTablaXml_sp", cTabla);
        }

        /// <summary>
        /// Retorna la tabla que se solicita tal como se encuentra en la base de datos
        /// </summary>
        /// <param name="cTabla">Nombre de la tabla</param>
        /// <returns>Datos de la tabla</returns>
        public DataTable retonarTablaXml(string cTabla)
        {
            string crutaxml = clsVarGlobal.cRutPathApp + @"\xml\" + cTabla + @".xml";

            DataSet ds = new DataSet();
            ds.ReadXml(crutaxml);

            return ds.Tables[0];
        }
    }
}
