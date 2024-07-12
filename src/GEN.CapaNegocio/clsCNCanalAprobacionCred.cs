using GEN.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace GEN.CapaNegocio
{
    public class clsCNCanalAprobacionCred
    {
        private clsADCanalAprobacionCred objADCanalAprobacionCred = new clsADCanalAprobacionCred();

        // Este metodo se coloca para mantener la compatibilidad con el tipo de evaluacion principal de canales A y B
        public DataTable ListarCanalesAprobacionCred()
        {
            DataSet dsCanalesAprobacionCred = new DataSet("CanalesAprobacionCred");
            DataTable dtCanalAprobacionCred =  new DataTable("CanalAprobacionCred");
            dtCanalAprobacionCred.Columns.Add("idCanalAproCred");

            DataRow drCanal = dtCanalAprobacionCred.NewRow();

            drCanal["idCanalAproCred"] = "1";
            dtCanalAprobacionCred.Rows.Add(drCanal);

            drCanal = dtCanalAprobacionCred.NewRow();
            drCanal["idCanalAproCred"] = "2";
            dtCanalAprobacionCred.Rows.Add(drCanal);
            

            dsCanalesAprobacionCred.Tables.Add(dtCanalAprobacionCred);

            string xmlCanalesAprobacionCred = dsCanalesAprobacionCred.GetXml();

            return objADCanalAprobacionCred.ListarCanalesAprobacionCred(xmlCanalesAprobacionCred);
        }

        public DataTable ListarCanalesAprobacionCred(DataTable dtCanalAprobacionCred)
        {
            DataSet dsCanalesAprobacionCred = new DataSet("CanalesAprobacionCred");

            dtCanalAprobacionCred.TableName = "CanalAprobacionCred";

            dsCanalesAprobacionCred.Tables.Add(dtCanalAprobacionCred);
            string xmlCanalesAprobacionCred = dsCanalesAprobacionCred.GetXml();

            return objADCanalAprobacionCred.ListarCanalesAprobacionCred(xmlCanalesAprobacionCred);
        }

        public List<clsCanalAprobacionCred> listarCanalAprobacionCred(string cIdsCanalAproCred = "0")
        {
            return objADCanalAprobacionCred.listarCanalAprobacionCred(cIdsCanalAproCred);
        }
    }
}
