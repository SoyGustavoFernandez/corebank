using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace ADM.AccesoDatos
{
    public class clsADMantConcepRec
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListarConcep(int idTipRecibo)
        {
            return objEjeSp.EjecSP("ADM_ListarConcepRecib_sp", idTipRecibo);
        }

        public DataTable ListarConcepEjCorp(int idTipRecibo, string cIdConceptos)
        {
            return objEjeSp.EjecSP("ADM_ListarConcepReciboGrupoEjecutivo_sp", idTipRecibo, cIdConceptos);
        }

       
        public DataTable ActualizarConcepRec(int idConcepto, string TipoOpe, int idTipoRec, string cNombreRec,
                                                   string TipoMonto, decimal nMonto, int AfectaITF, int SoloPersonal,
                                                   int Vigente, bool lAfectaCaja, bool lRestringido)
        {
            return objEjeSp.EjecSP("ADM_ActualConcepRecib_sp", idConcepto, TipoOpe, idTipoRec, cNombreRec,
                                                    TipoMonto, nMonto, AfectaITF, SoloPersonal,
                                                    Vigente, lAfectaCaja, lRestringido);
        }
        public DataTable ListarConcepXPerfil(int idPerfil, int idTipoRec)
        {
            return objEjeSp.EjecSP("ADM_ListarConcepRecibXPerfil_sp", idPerfil, idTipoRec);
        }
        public DataTable GrabarConcepXPerfil(int idTipRecibo ,   int idPerfil,string xmlConceptoAsignado)
        {
            return objEjeSp.EjecSP("ADM_GrabarConRecPerfil_Sp",idTipRecibo ,   idPerfil, xmlConceptoAsignado);
        }

        public DataTable ListarConcepNoAsigandoPerfil(int idTipRecibo, int idPerfil)
        {
            return objEjeSp.EjecSP("ADM_ListarConcepNoAsigandoPerfil_Sp", idTipRecibo, idPerfil);
        }
    }
}
