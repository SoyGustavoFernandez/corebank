using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.Funciones;
using GEN.WCFLogistica.AccesoDatos;
using WCFLogistica.EntityLayer;

namespace GEN.WCFLogistica.CapaNegocio
{
    public class clsCNFuenteDatos
    {
        clsADFuenteDatos adFuenteDatos;

        public clsCNFuenteDatos()
        {
            this.adFuenteDatos = new clsADFuenteDatos();
        }

        public clsVarGen obtenerVariable(string cVariable)
        {
            DataTable dtVarGen = this.adFuenteDatos.obtenerVariable(cVariable);
            return dtVarGen.Rows[0].ToObject<clsVarGen>();
        }

        public IList<clsProveedor> buscarProveedor(int idCriterio, string cCriterio)
        {
            DataTable dtProveedor = this.adFuenteDatos.buscarProveedor(idCriterio, cCriterio);
            return dtProveedor.SoftToList<clsProveedor>();
        }

        public IList<clsConceptoRecibo> obtenerConceptosRecibo(int idTipRec, int idPerfil)
        {
            DataTable dtConceptoRecibo = this.adFuenteDatos.obtenerConceptosRecibo(idTipRec, idPerfil);
            return dtConceptoRecibo.SoftToList<clsConceptoRecibo>();
        }

        public IList<clsConfigTipoComprobante> obtenerConfigTipoComprobante(int idTipoComprobante = 0)
        {
            DataTable dtConfigTipoComprobante = this.adFuenteDatos.obtenerConfigTipoComprobante(idTipoComprobante);
            return dtConfigTipoComprobante.SoftToList<clsConfigTipoComprobante>();
        } 
    }
}
