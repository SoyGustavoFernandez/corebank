using CRE.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace CRE.CapaNegocio
{
    public class clsCNProcJud
    {
        clsADProcJud objProcJud = new clsADProcJud();

        public DataTable RegProcJud(string xmlProcJudicial)
        {
            return objProcJud.RegProcJud(xmlProcJudicial);
        }

        public DataTable RegActProc(string xmlActProc,string cDetActProc,int idEncargAud)
        {
            return objProcJud.RegActProc(xmlActProc, cDetActProc, idEncargAud);
        }

        public DataTable VincProcJudCtaCred(string xmlCtaProcJud)
        {
            return objProcJud.VincProcJudCtaCred(xmlCtaProcJud);
        }

        public DataTable ReasignarProcJud(string xmlReasigProcJud)
        {
            return objProcJud.ReasignarProcJud(xmlReasigProcJud);
        }

        public clsDBResp CastigCreditos(string xmlCredCast,DateTime dFechaSistema,int idUsuarioSistema,
	                                    int nIdAgencia)
        {
            return objProcJud.CastigCreditos(xmlCredCast,dFechaSistema,idUsuarioSistema,nIdAgencia);
        }

        public DataTable BusProcJud(int idProcJud)
        {
            return objProcJud.BusProcJud(idProcJud);
        }

        public DataTable BusLstProcJud(int idCli)
        {
            return objProcJud.BusLstProcJud(idCli);
        }

        public DataTable BusCtasCliente(int idCli)
        {
            return objProcJud.BusCtasCliente(idCli);
        }

        public DataTable BusActProc(int idProcJud)
        {
            return objProcJud.BusActProc(idProcJud);
        }

        public DataTable BusLstProcJudAsigAbog(int idAbog)
        {
            return objProcJud.BusLstProcJudAsigAbog(idAbog);
        }

        public DataTable BusLstCtaCast(int idAgencia,int nAtrasoMin,int nAtrasoMax)
        {
            return objProcJud.BusLstCtaCast(idAgencia,nAtrasoMin,nAtrasoMax);
        }

        public DataTable ListarEstProcJud()
        {          
            return objProcJud.ListarEstProcJud();

            //var dt = objProcJud.ListarEstProcJudXML();
            //DataTable dtEstProcJud = dt.Clone();
            //(from item in dt.AsEnumerable()
            // where (bool)item["lVigente"] == true
            // select item).CopyToDataTable(dtEstProcJud, LoadOption.OverwriteChanges);
            //return dtEstProcJud;
        }

        public DataTable ListarJuzgados()
        {           
            return objProcJud.ListarJuzgados();         

            //var dt = objProcJud.ListarJuzgadosXML();
            //DataTable dtJuzgado = dt.Clone();
            //(from item in dt.AsEnumerable()
            // where (bool)item["lVigente"] == true
            // select item).CopyToDataTable(dtJuzgado, LoadOption.OverwriteChanges);
            //return dtJuzgado;
        }

        public DataTable ListarJuez()
        {
            return objProcJud.ListarJuez();
        }

        public DataTable ListarSecretario()
        {
            return objProcJud.ListarSecretario();
        }       

        public DataTable ListarTipoProcJud()
        {
            return objProcJud.ListarTipoProcJud();
        }

        public DataTable ListarTipMedJud()
        {
            return objProcJud.ListarTipMedJud();
        }

        public DataTable ListarAbogado()
        {

            return objProcJud.ListarAbogado();           
        }

        public DataTable ListarSubProcesosJudiciales()
        {
            return objProcJud.ListarSubProcesosJudiciales();
        }


        #region Mantenimiento de abogados

        public clsDBResp InsertarAbogadoIFI(string cDocIdent, string cApePaterno, string cApeMaterno, string cNombres,
                                            string cNumColeg, string cDirDomicilio, string cDirEstudio, string cTelfFijo, 
                                            string cTelfCel1, string cTelfCel2, string cEmail,bool lExterno, bool lVigente,
                                            bool lEstudioJuridico, string cRepresentanteLegal, string cAbogadoResponsable)
        {
            return objProcJud.InsertarAbogadoIFI(cDocIdent, cApePaterno, cApeMaterno, cNombres, cNumColeg,
                                                cDirDomicilio, cDirEstudio, cTelfFijo, cTelfCel1, cTelfCel2,
                                                cEmail, lExterno, lVigente, lEstudioJuridico, cRepresentanteLegal, cAbogadoResponsable);
        }

        public clsDBResp ActualizarAbogadoIFI(int idAbogado, string cDocIdent, string cApePaterno, string cApeMaterno, string cNombres,
                                            string cNumColeg, string cDirDomicilio, string cDirEstudio, string cTelfFijo, 
                                            string cTelfCel1, string cTelfCel2, string cEmail,bool lExterno, bool lVigente,
                                            bool lEstudioJuridico, string cRepresentanteLegal, string cAbogadoResponsable)
        {
            return objProcJud.ActualizarAbogadoIFI(idAbogado, cDocIdent, cApePaterno, cApeMaterno, cNombres, cNumColeg, 
                                                    cDirDomicilio, cDirEstudio, cTelfFijo, cTelfCel1, cTelfCel2,
                                                    cEmail, lExterno, lVigente, lEstudioJuridico, cRepresentanteLegal, cAbogadoResponsable);
        }

        #endregion

        #region Mantenimiento de Estados de Proceso judicial

        public clsDBResp InsertarEstProcJud(string cEstProcJud, int? idSubProcJudicial, bool lVigente, int idTipProcJud)
        {
            return objProcJud.InsertarEstProcJud(cEstProcJud, idSubProcJudicial, lVigente, idTipProcJud);
        }

        public clsDBResp ActualizarEstProcJud(int idEstProcJud, string cEstProcJud, int? idSubProcJudicial, bool lVigente)
        {
            return objProcJud.ActualizarEstProcJud(idEstProcJud, cEstProcJud, idSubProcJudicial, lVigente);
        }

        #endregion

        #region Mantenimiento de Juez

        public clsDBResp InsertarJuez(string cDocIdent, string cApePaterno, string cApeMaterno, string cNombres, int idJuzgado, 
                                       string cTelefono, bool lVigente)
        {
            return objProcJud.InsertarJuez(cDocIdent, cApePaterno, cApeMaterno, cNombres, idJuzgado, cTelefono, lVigente);
        }

        public clsDBResp ActualizarJuez(int idJuez, string cDocIdent, string cApePaterno, string cApeMaterno, string cNombres, int idJuzgado,
                                        string cTelefono, bool lVigente)
        {
            return objProcJud.ActualizarJuez(idJuez, cDocIdent, cApePaterno, cApeMaterno, cNombres, idJuzgado, cTelefono, lVigente);
        }

        #endregion

        #region Mantenimiento de Juzgado

        public clsDBResp InsertarJuzgado(string cCodJuzgado, string cJuzgado, int idUbigeo, string cDireccion, bool lVigente)
        {
            return objProcJud.InsertarJuzgado(cCodJuzgado, cJuzgado, idUbigeo, cDireccion, lVigente);
        }

        public clsDBResp ActualizarJuzgado(int idJuzgado, string cCodJuzgado, string cJuzgado, int idUbigeo, string cDireccion, bool lVigente)
        {
            return objProcJud.ActualizarJuzgado(idJuzgado,cCodJuzgado, cJuzgado, idUbigeo, cDireccion, lVigente);
        }

        #endregion

        #region Mantenimiento de Secretario

        public clsDBResp InsertarSecretario(string cDocIdent, string cApePaterno, string cApeMaterno, string cNombres, int idJuzgado,
                                            string cTelefFijo1, string cTelefFijo2, string cTelefCel1, string cTelefCel2, bool lVigente)
        {
            return objProcJud.InsertarSecretario(cDocIdent, cApePaterno, cApeMaterno, cNombres, idJuzgado,
                                                cTelefFijo1, cTelefFijo2, cTelefCel1, cTelefCel2, lVigente);
        }

        public clsDBResp ActualizarSecretario(int idSecretario, string cDocIdent, string cApePaterno, string cApeMaterno, string cNombres, int idJuzgado,
                                            string cTelefFijo1, string cTelefFijo2, string cTelefCel1, string cTelefCel2, bool lVigente)
        {
            return objProcJud.ActualizarSecretario(idSecretario, cDocIdent, cApePaterno, cApeMaterno, cNombres, idJuzgado,
                                                cTelefFijo1, cTelefFijo2, cTelefCel1, cTelefCel2, lVigente);
        }

        #endregion

        #region Mantenimiento de Tipo Med Judicial

        public DataTable InsertarTipoMedJud(string cTipoMedJud, bool lVigente)
        {
            return objProcJud.InsertarTipoMedJud(cTipoMedJud, lVigente);
        }

        public DataTable ActualizarTipoMedJud(int idTipoMedJud, string cTipoMedJud, bool lVigente)
        {
            return objProcJud.ActualizarTipoMedJud(idTipoMedJud, cTipoMedJud, lVigente);
        }

        #endregion

        #region Mantenimiento de Tipo Proceso Judicial

        public DataTable InsertarTipoProcJud(string cTipoProcJud, bool lVigente)
        {
            return objProcJud.InsertarTipoProcJud(cTipoProcJud, lVigente);
        }

        public DataTable ActualizarTipoProcJud(int idTipoProcJud, string cTipoProcJud, bool lVigente)
        {
            return objProcJud.ActualizarTipoProcJud(idTipoProcJud, cTipoProcJud, lVigente);
        }

        #endregion


        public DataTable ListarEstPorTipoProc(int idTipoProcJud)
        {
            return objProcJud.ListarEstPorTipoProc(idTipoProcJud);
        }

        public DataTable ListarEstPorTipoProcMant(int idTipoProcJud)
        {
            return objProcJud.ListarEstPorTipoProcMant(idTipoProcJud);
        }

        public DataTable BusCtasCredRelacionadas(int idProcJudicial)
        {
            return objProcJud.BusCtasCredRelacionadas(idProcJudicial);
        }
    }
}
