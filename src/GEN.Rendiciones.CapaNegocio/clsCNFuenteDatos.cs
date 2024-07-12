using EntityLayer;
using GEN.Rendiciones.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.Funciones;
using Rendiciones.EntityLayer;

namespace GEN.Rendiciones.CapaNegocio
{
    public class clsCNFuenteDatos
    {
        clsADFuenteDatos objADFuenteDatos;

        public clsCNFuenteDatos()
        {
            this.objADFuenteDatos = new clsADFuenteDatos();
        }

        public clsVarGen obtenerVariable(string cVariable)
        {
            DataTable dt = this.objADFuenteDatos.obtenerVariable(cVariable);
            return dt.Rows[0].ToObject<clsVarGen>();
        }

        public IList<clsProveedor> buscarProveedor(int idCriterio, string cCriterio)
        {
            DataTable dt = this.objADFuenteDatos.buscarProveedor(idCriterio, cCriterio);
            return dt.SoftToList<clsProveedor>();
        }

        public IList<clsConceptoRecibo> obtenerConceptosRecibo(int idTipRec, int idPerfil)
        {
            DataTable dt = this.objADFuenteDatos.obtenerConceptosRecibo(idTipRec, idPerfil);
            return dt.SoftToList<clsConceptoRecibo>();
        }   
    }
}
