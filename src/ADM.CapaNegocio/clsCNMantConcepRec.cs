using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ADM.AccesoDatos;

namespace ADM.CapaNegocio
{
    public class clsCNMantConcepRec
    {
        clsADMantConcepRec ListaConcepRec = new clsADMantConcepRec();
        public DataTable ListarConcep(int idTipRecibo)
        {
            return ListaConcepRec.ListarConcep(idTipRecibo);
        }
        public DataTable ListarConcepEjCorp(int idTipRecibo, string cIdConceptos)
        {
            return ListaConcepRec.ListarConcepEjCorp(idTipRecibo, cIdConceptos);
        }
        public int ActualizarConcepRec(int idConcepto, string TipoOpe, int idTipoRec, string cNombreRec,
                                                   string TipoMonto, decimal nMonto, int AfectaITF, int SoloPersonal,
                                                   int Vigente,bool lAfectaCaja, bool lRestringido)
        {
            DataTable dtResultado= ListaConcepRec.ActualizarConcepRec(idConcepto,  TipoOpe,  idTipoRec,  cNombreRec,
                                                    TipoMonto,  nMonto,  AfectaITF,  SoloPersonal,
                                                    Vigente, lAfectaCaja, lRestringido);
            int idConcpRec = 0;
            return idConcpRec = Convert.ToInt32(dtResultado.Rows[0][0]);
        }
        public DataTable ListarConceptoXPerfil(int idPerfil, int idTipoRec)
        {
            return ListaConcepRec.ListarConcepXPerfil(idPerfil, idTipoRec);
        }
        public DataTable GrabarConceptoXPerfil(int idTipRecibo ,   int idPerfil,string xmlConceptoAsignado)
        {
            return ListaConcepRec.GrabarConcepXPerfil(idTipRecibo ,   idPerfil,xmlConceptoAsignado);
        }


        public DataTable ListarConcepNoAsigandoPerfil(int idTipRecibo,int idPerfil)
        {
            return ListaConcepRec.ListarConcepNoAsigandoPerfil(idTipRecibo, idPerfil);
        }
    }
}
