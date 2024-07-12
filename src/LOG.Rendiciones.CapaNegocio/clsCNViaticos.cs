using LOG.Rendiciones.AccesoDatos;
using WCFLogistica.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.Funciones;
using GEN.CapaNegocio;

namespace LOG.Rendiciones.CapaNegocio
{
    public class clsCNViaticos
    {
        #region propiedades privadas
        private clsADViaticos adViaticos;
        #endregion

        #region constructores
        public clsCNViaticos()
        {
            this.adViaticos = new clsADViaticos();
        }
        #endregion

        #region métodos públicos
        public clsEntregaRendir registrarViatico(clsEntregaRendir objEntregaRendir, clsViatico objViatico, List<clsDetalleViatico> lstDetalleViatico)
        {
            try
            {
                /*Lista a DataTable */
                List<clsEntregaRendir> lstEntregaRendir = new List<clsEntregaRendir>();
                lstEntregaRendir.Add(objEntregaRendir);
                List<clsViatico> lstViatico = new List<clsViatico>();
                lstViatico.Add(objViatico);

                DataTable dtEntregaRendir = DataTableToList.CreateDataTable<clsEntregaRendir>(lstEntregaRendir);
                DataTable dtViatico = DataTableToList.CreateDataTable<clsViatico>(lstViatico);
                DataTable dtDetalleViatico = DataTableToList.CreateDataTable<clsDetalleViatico>(lstDetalleViatico);

                /*Convertir a XML*/
                DataSet dsEntregaRendir = new DataSet("dsEntrega");
                DataSet dsViatico = new DataSet("dsViatico");
                DataSet dsDetalleViatico = new DataSet("dsDetalleViatico");

                dtEntregaRendir.TableName = "dtEntrega";
                dtViatico.TableName = "dtViatico";
                dtDetalleViatico.TableName = "dtDetalleViatico";

                dsEntregaRendir.Tables.Add(dtEntregaRendir);
                dsViatico.Tables.Add(dtViatico);
                dsDetalleViatico.Tables.Add(dtDetalleViatico);

                string xmlEntregaRendir = clsCNFormatoXML.EncodingXML(dsEntregaRendir.GetXml());
                string xmlViatico = clsCNFormatoXML.EncodingXML(dsViatico.GetXml());
                string xmlDetalleViatico = clsCNFormatoXML.EncodingXML(dsDetalleViatico.GetXml());

                dsEntregaRendir.Tables.Clear();
                dsViatico.Tables.Clear();
                dsDetalleViatico.Tables.Clear();

                DataTable dtResEntregaRendir = this.adViaticos.registrarViatico(xmlEntregaRendir, xmlViatico, xmlDetalleViatico);
                return dtResEntregaRendir.Rows[0].ToObject<clsEntregaRendir>();
            }
            catch (Exception e)
            {
                clsEntregaRendir objResEntregaRendir = new clsEntregaRendir();
                objResEntregaRendir.cError = e.Message;
                return objResEntregaRendir;
            }
        }

        public clsViatico obtenerViatico(int idEntrega, int idViatico)
        {
            DataTable dtViatico = this.adViaticos.obtenerViatico(idEntrega, idViatico);
            return dtViatico.Rows[0].ToObject<clsViatico>();
        }

        public IList<clsDetalleViatico> obtenerDetallesViatico(int idViatico, int idDetalleViatico)
        {
            DataTable dtDetalleViatico = this.adViaticos.obtenerDetallesViatico(idViatico, idDetalleViatico);
            return dtDetalleViatico.SoftToList<clsDetalleViatico>();
        }
        #endregion
    }
}
