using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADTipAutUsoDatos
    {
        clsGENEjeSP genobjEjeSp = new clsGENEjeSP();
        public DataTable ADListaTipAutUsoDatos()
        {
            return genobjEjeSp.EjecSP("GEN_ListaTipAutUsoDatos_sp");
        }
        public DataTable ADEstadoAutUsoDatos()
        {
            return genobjEjeSp.EjecSP("GEN_EstadoAutUsoDatos_sp");
        }
        public DataTable ADMotivoAutUsoDatos(bool esRemoto=false)
        {
            return genobjEjeSp.EjecSP("GEN_MotivoAutUsoDatos_sp", esRemoto);
        }
        public DataTable ADObtenerIntervinienteBiometrico(int idCliente)
        {
            return genobjEjeSp.EjecSP("TDP_ObtenerIntervinienteBiometrico_SP", idCliente);
        }
        public DataTable ADObtenerMotivoDesistimientoAutUsoDato()
        {
            return genobjEjeSp.EjecSP("TDP_ObtenerMotivoDesistimiento_SP");
        }
        public DataTable ADListaCanalRegistro()
        {
            return genobjEjeSp.EjecSP("TDP_ObtenerCanalesRegistro_SP");
        }
        public DataTable listarReporteAutoUsoTratamientoDatos(params object[] parametros)
        {
            return this.genobjEjeSp.EjecSP("TDP_ListaRptAutTraDatos_SP", parametros);
        }

    }
}
