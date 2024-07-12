using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using GEN.AccesoDatos;
namespace GRH.AccesoDatos
{
    public class clsADConceptoRemunerativo
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        clsADTablaXml cnadtabla = new clsADTablaXml();

        public DataTable ADListarConceptoTipoPlanilla(int idTipoPlanilla)
        {
            return objEjeSp.EjecSP("GRH_ListarConceptoTipoPlanilla_SP", idTipoPlanilla);
        }

        public DataTable ADRegistrarConceptoPlanilla(int idTipoPlanilla, string xmlConceptoPlanilla)
        {
            return objEjeSp.EjecSP("GRH_RegistrarConceptoPlanilla_SP", idTipoPlanilla, xmlConceptoPlanilla);
        }

        public DataTable ADListarConceptoPersona(int idUsuario)
        {
            return objEjeSp.EjecSP("GRH_ListarConceptoPersona_SP", idUsuario);
        }

        public DataTable ADRegistrarConceptoPersona(int idUsuario, string xmlConceptoPersona)
        {
            return objEjeSp.EjecSP("GRH_RegistrarConceptoPersona_SP", idUsuario, xmlConceptoPersona);
        }

        public DataTable ListarTipoConcRemXML()
        {
            return cnadtabla.retonarTablaXml("SI_FinTipoConceptoRemunerativo");
        }

        public DataTable ADListaTipoPagoRemun(int idTipoPagoRem)
        {
            return objEjeSp.EjecSP("GRH_ListarTipoPagoRemunerativoPadre_SP", idTipoPagoRem);
        }

        public DataTable ADListaModalidadContrato()
        {
            return objEjeSp.EjecSP("GEN_ListarModalidadContrato_SP");
        }
    }
}
