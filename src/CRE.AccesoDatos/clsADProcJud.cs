using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using GEN.AccesoDatos;

namespace CRE.AccesoDatos
{
    public class clsADProcJud
    {       
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        clsADTablaXml cnadtabla = new clsADTablaXml();

        public DataTable RegProcJud(string xmlProcJudicial)
        {
            return objEjeSp.EjecSP("Cre_RegProcJudicial_Sp", xmlProcJudicial);
        }

        public DataTable RegActProc(string xmlActProc,string cDetActProc,int idEncargAud)
        {
            return objEjeSp.EjecSP("Cre_RegActProc_Sp", xmlActProc, cDetActProc, idEncargAud);
        }

        public DataTable VincProcJudCtaCred(string xmlCtaProcJud)
        {
            return objEjeSp.EjecSP("Cre_VincProcJudCtaCre_Sp", xmlCtaProcJud);
        }

        public DataTable ReasignarProcJud(string xmlReasigProcJud)
        {
            return objEjeSp.EjecSP("Cre_ReasigProcJud_Sp", xmlReasigProcJud);
        }

        public clsDBResp CastigCreditos(string xmlCredCast,DateTime dFechaSistema, int idUsuarioSistema ,
	                                    int nIdAgencia)
        {
            DataTable dtResult = objEjeSp.EjecSP("Cre_CastigCred_Sp", xmlCredCast, dFechaSistema, idUsuarioSistema,
                                    nIdAgencia);
            return new clsDBResp(dtResult);
        }

        public DataTable BusProcJud(int idProcJud)
        {
            return objEjeSp.EjecSP("Cre_BusProcJudicial_Sp", idProcJud);
        }

        public DataTable BusLstProcJud(int idCli)
        {
            return objEjeSp.EjecSP("Cre_BusProcJudicialCli_Sp", idCli);
        }

        public DataTable BusCtasCliente(int idCli)
        {
            return objEjeSp.EjecSP("Cre_BusCtaCliVincProcJud_Sp", idCli);
        }

        public DataTable BusActProc(int idProcJud)
        {
            return objEjeSp.EjecSP("Cre_BusActProc_Sp", idProcJud);
        }

        public DataTable BusLstProcJudAsigAbog(int idAbog)
        {
            return objEjeSp.EjecSP("Cre_BusProcJudAsigAbog_Sp", idAbog);
        }

        public DataTable BusLstCtaCast(int idAgencia, int nAtrasoMin, int nAtrasoMax)
        {
            return objEjeSp.EjecSP("Cre_BusCtasCasti_Sp", idAgencia, nAtrasoMin, nAtrasoMax);
        }

        public DataTable ListarEstProcJud()
        {
            return objEjeSp.EjecSP("Cre_ListarEstProcJud_Sp");
        }
        public DataTable ListarEstProcJudXML()
        {
            return cnadtabla.retonarTablaXml("SI_FinEstProcJud");
        }

        public DataTable ListarJuzgados()
        {
            return objEjeSp.EjecSP("Cre_ListarJuzgados_Sp");
        }
        public DataTable ListarJuzgadosXML()
        {
            return cnadtabla.retonarTablaXml("SI_FinJuzgado");
        }

        public DataTable ListarJuez()
        {
            return objEjeSp.EjecSP("Cre_ListaJuez_Sp");
        }

        public DataTable ListarSecretario()
        {
            return objEjeSp.EjecSP("Cre_ListaSecretarios_Sp");
        }

        public DataTable ListarAbogado()
        {
            return objEjeSp.EjecSP("Cre_ListaAbogados_Sp");
        }

        public DataTable ListarSubProcesosJudiciales()
        {
            return objEjeSp.EjecSP("Cre_ListSubProcJudiciales_Sp");
        }

        public DataTable ListarTipoProcJud()
        {
            return objEjeSp.EjecSP("Cre_ListaTipoProcJud_Sp");
        }

        public DataTable ListarTipMedJud()
        {
            return objEjeSp.EjecSP("Cre_ListaTipoMedJud_Sp");
        }

        public DataTable ListarAbogadoXml()
        {
            return cnadtabla.retonarTablaXml("SI_FinAbogadoIFI");
        }

        #region Mantenimiento de abogados

        public clsDBResp InsertarAbogadoIFI(string cDocIdent, string cApePaterno, string cApeMaterno, string cNombres, 
                                            string cNumColeg,string cDirDomicilio,string cDirEstudio, string cTelfFijo, 
                                            string cTelfCel1, string cTelfCel2, string cEmail,bool lExterno, bool lVigente,
                                            bool lEstudioJuridico, string cRepresentanteLegal, string cAbogadoResponsable)
        {
            DataTable dtResult =  objEjeSp.EjecSP("CRE_InsertarAbogadoIFI_SP",cDocIdent, cApePaterno, cApeMaterno, cNombres, cNumColeg,
                                                                cDirDomicilio, cDirEstudio, cTelfFijo, cTelfCel1, cTelfCel2,
                                                                cEmail, lExterno,lVigente, lEstudioJuridico, cRepresentanteLegal, cAbogadoResponsable);
            clsDBResp objDbResp = new clsDBResp(dtResult);
            return objDbResp;
        }

        public clsDBResp ActualizarAbogadoIFI(int idAbogado, string cDocIdent, string cApePaterno, string cApeMaterno, string cNombres,
                                            string cNumColeg, string cDirDomicilio, string cDirEstudio, string cTelfFijo, 
                                            string cTelfCel1, string cTelfCel2, string cEmail, bool lExterno, bool lVigente,
                                            bool lEstudioJuridico, string cRepresentanteLegal, string cAbogadoResponsable)
        {
            DataTable dtResult = objEjeSp.EjecSP("CRE_ActualizarAbogadoIFI_SP", idAbogado, cDocIdent, cApePaterno, cApeMaterno, cNombres, cNumColeg,
                                                                    cDirDomicilio, cDirEstudio, cTelfFijo, cTelfCel1, cTelfCel2,
                                                                    cEmail, lExterno, lVigente, lEstudioJuridico, cRepresentanteLegal, cAbogadoResponsable);
            clsDBResp objDbResp = new clsDBResp(dtResult);
            return objDbResp;
        }

        #endregion

        #region Mantenimiento de Estados de Proceso judicial

        public clsDBResp InsertarEstProcJud(string cEstProcJud, int? idSubProcJudicial, bool lVigente, int idTipProcJud)
        {
            DataTable dtResult = objEjeSp.EjecSP("CRE_InsertarEstProcJud_SP", cEstProcJud,
                idSubProcJudicial == null ? DBNull.Value : (object)idSubProcJudicial, lVigente, idTipProcJud);
            clsDBResp objDbResp = new clsDBResp(dtResult);
            return objDbResp;
        }

        public clsDBResp ActualizarEstProcJud(int idEstProcJud, string cEstProcJud, int? idSubProcJudicial, bool lVigente)
        {
            DataTable dtResult = objEjeSp.EjecSP("CRE_ActualizarEstProcJud_SP", idEstProcJud, cEstProcJud,
                idSubProcJudicial == null ? DBNull.Value : (object)idSubProcJudicial, lVigente);
            clsDBResp objDbResp = new clsDBResp(dtResult);
            return objDbResp;
        }

        #endregion
        
        #region Mantenimiento de Juez

        public clsDBResp InsertarJuez(string cDocIdent, string cApePaterno, string cApeMaterno, string cNombres, int idJuzgado,
                                string cTelefono, bool lVigente)
        {
            DataTable dtResult = objEjeSp.EjecSP("CRE_InsertarJuez_SP", cDocIdent, cApePaterno, cApeMaterno, cNombres, idJuzgado,
                                                cTelefono ,lVigente);
            clsDBResp objDbResp = new clsDBResp(dtResult);
            return objDbResp;
        }

        public clsDBResp ActualizarJuez(int idJuez, string cDocIdent, string cApePaterno, string cApeMaterno, string cNombres, int idJuzgado,
                                string cTelefono, bool lVigente)
        {
            DataTable dtResult = objEjeSp.EjecSP("CRE_ActualizarJuez_SP", idJuez, cDocIdent, cApePaterno, cApeMaterno, cNombres, idJuzgado,
                                                    cTelefono, lVigente);
            clsDBResp objDbResp = new clsDBResp(dtResult);
            return objDbResp;
        }

        #endregion

        #region Mantenimiento de Juzgado

        public clsDBResp InsertarJuzgado(string cCodJuzgado, string cJuzgado, int idUbigeo, string cDireccion, bool lVigente)
        {
            DataTable dtResult = objEjeSp.EjecSP("CRE_InsertarJuzgado_SP", cCodJuzgado, cJuzgado, idUbigeo, cDireccion, lVigente);
            clsDBResp objDbResp = new clsDBResp(dtResult);
            return objDbResp;
        }

        public clsDBResp ActualizarJuzgado(int idJuzgado, string cCodJuzgado, string cJuzgado, int idUbigeo, string cDireccion, bool lVigente)
        {
            DataTable dtResult = objEjeSp.EjecSP("CRE_ActualizarJuzgado_SP", idJuzgado, cCodJuzgado, cJuzgado, idUbigeo, cDireccion, lVigente);
            clsDBResp objDbResp = new clsDBResp(dtResult);
            return objDbResp;
        }

        #endregion

        #region Mantenimiento de Secretario

        public clsDBResp InsertarSecretario(string cDocIdent, string cApePaterno, string cApeMaterno, string cNombres, int idJuzgado,
                                        string cTelefFijo1,string cTelefFijo2,string cTelefCel1,string cTelefCel2, bool lVigente)
        {
            DataTable dtResult = objEjeSp.EjecSP("CRE_InsertarSecretario_SP", cDocIdent, cApePaterno, cApeMaterno, cNombres, idJuzgado, 
                                        cTelefFijo1, cTelefFijo2, cTelefCel1, cTelefCel2,lVigente);
            clsDBResp objDbResp = new clsDBResp(dtResult);
            return objDbResp;
        }

        public clsDBResp ActualizarSecretario(int idSecretario, string cDocIdent, string cApePaterno, string cApeMaterno, string cNombres, int idJuzgado,
                                            string cTelefFijo1, string cTelefFijo2, string cTelefCel1, string cTelefCel2, bool lVigente)
        {
            DataTable dtResult = objEjeSp.EjecSP("CRE_ActualizarSecretario_SP", idSecretario, cDocIdent, cApePaterno, cApeMaterno, cNombres, idJuzgado,
                                                cTelefFijo1, cTelefFijo2, cTelefCel1, cTelefCel2, lVigente);
            clsDBResp objDbResp = new clsDBResp(dtResult);
            return objDbResp;
        }

        #endregion

        #region Mantenimiento de Tipo Med Judicial

        public DataTable InsertarTipoMedJud(string cTipoMedJud, bool lVigente)
        {
            return objEjeSp.EjecSP("CRE_InsertarTipoMedJud_SP", cTipoMedJud, lVigente);
        }

        public DataTable ActualizarTipoMedJud(int idTipoMedJud, string cTipoMedJud, bool lVigente)
        {
            return objEjeSp.EjecSP("CRE_ActualizarTipoMedJud_SP", idTipoMedJud, cTipoMedJud, lVigente);
        }

        #endregion

        #region Mantenimiento de Tipo Proceso Judicial

        public DataTable InsertarTipoProcJud(string cTipoProcJud, bool lVigente)
        {
            return objEjeSp.EjecSP("CRE_InsertarTipoProcJud_SP", cTipoProcJud, lVigente);
        }

        public DataTable ActualizarTipoProcJud(int idTipoProcJud, string cTipoProcJud, bool lVigente)
        {
            return objEjeSp.EjecSP("CRE_ActualizarTipoProcJud_SP", idTipoProcJud, cTipoProcJud, lVigente);
        }

        #endregion 
    
        
    
        public DataTable ListarEstPorTipoProc(int idTipoProcJud)
        {
            return objEjeSp.EjecSP("CRE_ListarEstProcPorTipoProc_SP", idTipoProcJud);
        }

        public DataTable ListarEstPorTipoProcMant(int idTipoProcJud)
        {
            return objEjeSp.EjecSP("CRE_ListarEstProcPorTipoProcTodos_SP", idTipoProcJud);
        }

        public DataTable BusCtasCredRelacionadas(int idProcJudicial)
        {
            return objEjeSp.EjecSP("CRE_ListarCtasCredCRelacionadas_SP", idProcJudicial);
        }
    }
}
