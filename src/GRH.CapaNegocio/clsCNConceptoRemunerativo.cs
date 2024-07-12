using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNConceptoRemunerativo
    {
        clsADConceptoRemunerativo objConceptoRemunerativo = new clsADConceptoRemunerativo();

        public DataTable CNListarConceptoTipoPlanilla(int idTipoPlanilla)
        {
            return objConceptoRemunerativo.ADListarConceptoTipoPlanilla(idTipoPlanilla);
        }

        public DataTable CNRegistrarConceptoPlanilla(int idTipoPlanilla, string xmlConceptoPlanilla)
        {
            return objConceptoRemunerativo.ADRegistrarConceptoPlanilla(idTipoPlanilla, xmlConceptoPlanilla);
        }

        public DataTable CNListarConceptoPersona(int idUsuario)
        {
            return objConceptoRemunerativo.ADListarConceptoPersona(idUsuario);
        }

        public DataTable CNRegistrarConceptoPersona(int idUsuario, string xmlConceptoPersona)
        {
            return objConceptoRemunerativo.ADRegistrarConceptoPersona(idUsuario, xmlConceptoPersona);
        }
        public DataTable ListarTipoConcRem()
        {
            var dt = objConceptoRemunerativo.ListarTipoConcRemXML();
            DataTable dtConcepto = dt.Clone();
            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtConcepto, LoadOption.OverwriteChanges);
            return dtConcepto;
        }

        public DataTable CNListaTipoPagoRemun(int idTipoPagoRem)
        {
            return objConceptoRemunerativo.ADListaTipoPagoRemun(idTipoPagoRem);
        }

        public DataTable CNListaModalidadContrato()
        {
            return objConceptoRemunerativo.ADListaModalidadContrato();
        }
    }
}
