using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace CRE.AccesoDatos
{
    public class clsADIntervCre
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable obtenerIntervinienteSolicitud(int idSolicitud, int idModulo, bool lNuevo, bool lNoParticipa)
        {
            return objEjeSp.EjecSP("CRE_ObtenerIntervinienteSolicitud_SP", idSolicitud, idModulo, lNuevo, lNoParticipa);
        }
        public DataTable ADObtenerIntervinienteActaSolicitud(int idSolicitud, int idModulo)
        {
            return objEjeSp.EjecSP("CRE_ObtenerIntervinienteActaSolicitud_SP", idSolicitud, idModulo);
        }
        public DataTable ADdtIntervCre(int nNumSolicitud, int idModulo)
        {
            return objEjeSp.EjecSP("CRE_LisIntervxCre", nNumSolicitud, idModulo);
        }

        public DataTable GuardarIntervCre(int nNumSolicitud, string cCodUsuReg, DateTime pdFecReg,
                   string xmlInterv)
        {
            return objEjeSp.EjecSP("Cre_GuardarIntervCre_Sp", nNumSolicitud, cCodUsuReg, pdFecReg, xmlInterv);
        }
        
        #region Reporte Posicion Integral

        public DataTable ADdtLisSalRCC(string nIdDocumento, int idTipoDocumento)
        {
            return objEjeSp.EjecSP("CRE_LisSaldosRCDSBS_SP", nIdDocumento, idTipoDocumento);
        }

        public DataTable ADdtLisCalifiRCDSBS(string nIdDocumento, int idTipoDocumento)
        {
            return objEjeSp.EjecSP("CRE_LisCalifiRCDSBS_SP", nIdDocumento, idTipoDocumento);
        }
        public DataTable ADdtLisSaldosRCDSBS(string nCodSbs, int nUltiNMeses = 0, int nDirOrIndi = 0)
        {
            return objEjeSp.EjecSP("CRE_ClienteSaldosRCDSBS_SP", nCodSbs, nUltiNMeses, nDirOrIndi);
        }
        public DataTable ADdtListClienCalifSBS(string nIdDocumento, int idTipoDocumento, int nUltiNMeses) 
        {
            return objEjeSp.EjecSP("CRE_ClienteCalifRCDSBS_SP", nIdDocumento, idTipoDocumento, nUltiNMeses); 
        }
      
        public DataTable ADdtListClienCalifSBS_Fecha(int idTipoDocumento,string nIdDocumento, string cFecha)
        {
            return objEjeSp.EjecSP("CRE_ClienteCalifRCDSBS_Fecha_SP", idTipoDocumento,nIdDocumento, cFecha);
        }

        public DataTable ADdtLisCrexCliInt(string nIdDocumento, int idTipoDocumento)
        {
            return objEjeSp.EjecSP("CRE_LisCrexCliPosInt_SP", nIdDocumento, idTipoDocumento); //cambiar Sp
        }

        public DataTable ADdtLisGarxCli(string nIdDocumento, int idTipoDocumento)
        {
            return objEjeSp.EjecSP("CRE_LisGarxCli_SP", nIdDocumento, idTipoDocumento);
        }

        public DataTable ADdtLisCreGarxCli(string nIdDocumento, int idTipoDocumento)
        {
            return objEjeSp.EjecSP("CRE_LisCreGarxCli_SP", nIdDocumento, idTipoDocumento);
        }

        public DataTable ADdtLisGarOtrUtixCli(string nIdDocumento, int idTipoDocumento)
        {
            return objEjeSp.EjecSP("CRE_LisGarOtrUtixCli_SP", nIdDocumento, idTipoDocumento);
        }

        public DataTable ADdtLisCtaAhoxCli(string nIdDocumento, int idTipoDocumento)
        {
            return objEjeSp.EjecSP("CRE_LisCtaAhoxCli_SP", nIdDocumento, idTipoDocumento);
        }

        public DataTable ADdtLisCliCreMismaDire(string nIdDocumento, int idTipoDocumento)
        {
            return objEjeSp.EjecSP("CRE_LisCliCreMismaDire_SP", nIdDocumento, idTipoDocumento);
        }

        public DataTable ADdtLisVinculadosaCli(string nIdDocumento, int idTipoDocumento)
        {
            return objEjeSp.EjecSP("CRE_LisVinculadosaCli_SP", nIdDocumento, idTipoDocumento);
        }

        public DataTable ADdtVerificarRelacionCliente(string nIdDocumento, int idTipDoc)
        {
            return objEjeSp.EjecSP("CRE_VerificarRelacionCliente_SP", nIdDocumento, idTipDoc);
        }

        public DataTable ADdtLisCliMismaGar(string nIdDocumento, int idTipoDocumento)
        {
            return objEjeSp.EjecSP("CRE_LisCliMismaGar_SP", nIdDocumento, idTipoDocumento);
        }

        public DataTable ADdtLisCliRelaGrupoEcono(string nIdDocumento, int idTipoDocumento)
        {
            return objEjeSp.EjecSP("CRE_LisCliRelaGrupoEcono_SP", nIdDocumento, idTipoDocumento);
        }

        public DataTable ADdtLstRastreoInt(string cDocumentoID, int idTipoDocumento)
        {
            return objEjeSp.EjecSP("GEN_BusRastreoPosInt_sp", cDocumentoID, idTipoDocumento);
        }

        public DataTable ADdtLisSolCreCli(string cDocumentoID, int idTipoDocumento)
        {
            return objEjeSp.EjecSP("CRE_LstSolicitudesCli_sp", cDocumentoID, idTipoDocumento);
        }

        public DataTable ADdtLisDatBaseNegativa(string cDocumentoID, int idTipoDocumento)
        {
            return objEjeSp.EjecSP("CRE_LisBaseNegativaPosInterv_Sp", cDocumentoID, idTipoDocumento);
        }

        public DataTable ADdtLisDatPEP(string cDocumentoID, int idTipoDocumento)
        {
            return objEjeSp.EjecSP("CRE_LisPEPPosInterv_Sp", cDocumentoID, idTipoDocumento);
        }

        public DataTable ValidaExistePersonaSBSPosInt(int idTipoDocumento, string cDocumento)
        {
            return objEjeSp.EjecSP("CRE_ValidaExistePersonaSBSPosInt_SP", idTipoDocumento, cDocumento);
        }

        public DataTable ADValidaExistePersonaCampania(int idTipoDocumento, string cDocumento)
        {
            return objEjeSp.EjecSP("CRE_ValidaExistePersonaCampania_SP", idTipoDocumento, cDocumento);
        }

        public DataTable ADLisCarFiaCli(int idCli)
        {
            return objEjeSp.EjecSP("CRE_ListaCartasFianzaCliente_SP", idCli);
        }

        public DataTable ADLisCreCliFiSol(int idCli)
        {
            return objEjeSp.EjecSP("CRE_LisCreCliFiSol_SP", idCli);
        }

        public DataTable ADBaseNegativa(string cDocumentoID, int idTipoDocumento)
        {
            return objEjeSp.EjecSP("CRE_LisBaseNegativa_SP", cDocumentoID, idTipoDocumento);
        }

        public DataTable ADLibBaseNegativa(string cDocumentoID, int idTipoDocumento)
        {
            return objEjeSp.EjecSP("CRE_LisLibBaseNegativa_SP", cDocumentoID, idTipoDocumento);
        }

        #endregion
        
        public DataTable ValidaExistePersonaSBS(string cDocumento)
        {
            return objEjeSp.EjecSP("CRE_ValidaExistePersonaSBS_SP", cDocumento);
        }

        public DataTable validaPermisoQuitarConyugue(int idPerfil)
        {
            return objEjeSp.EjecSP("CRE_ValidaPermisoQuitarConyugue_SP", idPerfil);
        }

        public DataTable ADdtLstRastreo(int idCli, int idCuenta, int idModulo, int idMenu, int idUsuReg,
                                        string cDocumentoID)
        {
            return objEjeSp.EjecSP("GEN_BusRastreo_sp", idCli, idCuenta, idModulo, idMenu, idUsuReg, cDocumentoID);
        }

        public DataTable ADdtLisCrexCli(string nIdDocumento)
        {
            return objEjeSp.EjecSP("CRE_LisCrexCli_SP", nIdDocumento);
        }
        public DataTable ADdtIntervSoli(int nNumSolicitud, int idModulo, bool lNoParticipa)
        {
            return objEjeSp.EjecSP("CRE_ListIntervxSolicitud_SP", nNumSolicitud, idModulo, lNoParticipa);
        }

        public DataTable ADEdadAniosDias(DateTime dFechaNacimiento)
        {
            return objEjeSp.EjecSP("CRE_CalEdadAniosDias_SP", dFechaNacimiento, "1900/01/01");
        }

        public DataTable ADClasifiInterna(int idCli, int nMeses)
        {
            /**
             * 
             * El tercer parametro es la configuracion de periodo
             * 1 => traer en 24 meses si os
             *      mostrara campos vacios en los meses sin
             *      clasificacion
             * 0 => traer solo en los meses en donde hay registros
             *      si faltan registros no los muestra
             *      
             */
            return objEjeSp.EjecSP("CRE_ClasifiInternaCRAC_LASA_SP", idCli, nMeses, 0);
        }

        public DataTable ADCliPosiblesParientes(int idCli, string cPaterno = "", string cMaterno = "")
        {
            return objEjeSp.EjecSP("CRE_CliPosiblesParientes_SP", idCli, cPaterno, cMaterno);
        }

        public DataTable ADLisCreCli_2(int idCli)
        {
            return objEjeSp.EjecSP("CRE_LisCrexCli_2_SP", idCli);
        }

        public DataTable ADLisSolCli(string cDocumentoId, int idTipDoc)
        {
            return objEjeSp.EjecSP("CRE_LstSolicitudesCli_sp", cDocumentoId, idTipDoc);
        }

        public DataTable ADAvaladosRCCSBS(string cDocumentoID, int idTipoDocumento)
        {
            return objEjeSp.EjecSP("CRE_LisAvaladosRCCSBS_SP", cDocumentoID, idTipoDocumento);
        }

        public DataTable ADCrePreAprov(int idCli)
        {
            return objEjeSp.EjecSP("CRE_LisCredPreApro_SP", idCli);
        }
        
        public DataTable ADDirNumTelPar(int idCli, int idCliCony = -1)
        {
            return objEjeSp.EjecSP("CRE_LisDirNumTelPar_SP", idCli, idCliCony);
        }


        #region PosInterv2
        public DataTable dtCalifEntityRccSbs(int idTipoDocumento, string cDocumentoID)
        {
            return objEjeSp.EjecSP("CRE_PI2_CalifEntityRccSbs_SP", idTipoDocumento, cDocumentoID);
        }
        public DataTable dtsaldosSbsTitCony(int idTipoDocumento, string cDocumentoID)
        {
            return objEjeSp.EjecSP("CRE_PI2_saldosSbsTitCony_SP", idTipoDocumento, cDocumentoID);
        }
        public DataTable dtsaldosEntidadFinanciera(int idTipoDocumento, string cDocumentoID,string cFecha)
        {
            return objEjeSp.EjecSP("CRE_DEVUELVESALDOENTIDADFINANCIERA_SP", idTipoDocumento, cDocumentoID, cFecha);
        }
        public DataTable dtLisAvaladosRCCSBS(int idTipoDocumento, string cDocumentoID)
        {
            return objEjeSp.EjecSP("CRE_PI2_LisAvaladosRCCSBS_SP", idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisCreCliFiSol(int idTipoDocumento, string cDocumentoID)
        {
            return objEjeSp.EjecSP("CRE_PI2_LisCreCliFiSol_SP", idTipoDocumento, cDocumentoID);
        }
        public DataTable dtListaCartasFianzaCliente(int idTipoDocumento, string cDocumentoID)
        {
            return objEjeSp.EjecSP("CRE_PI2_ListaCartasFianzaCliente_SP", idTipoDocumento, cDocumentoID);
        }
        public DataTable dtClasifiInternaCaja(int idTipoDocumento, string cDocumentoID, int nMeses = 24)
        {
            return objEjeSp.EjecSP("CRE_PI2_ClasifiInternaCaja_SP", idTipoDocumento, cDocumentoID, nMeses);
        }
        public DataTable dtLisPEPPosInterv(int idTipoDocumento, string cDocumentoID)
        {
            return objEjeSp.EjecSP("CRE_PI2_LisPEPPosInterv_SP", idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisBaseNegativa(int idTipoDocumento, string cDocumentoID)
        {
            return objEjeSp.EjecSP("CRE_PI2_LisBaseNegativa_SP", idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisLibBaseNegativa(int idTipoDocumento, string cDocumentoID)
        {
            return objEjeSp.EjecSP("CRE_PI2_LisLibBaseNegativa_SP", idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLstSolicitudesCli(int idTipoDocumento, string cDocumentoID)
        {
            return objEjeSp.EjecSP("CRE_PI2_LstSolicitudesCli_sp", idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisCrexCli(int idTipoDocumento, string cDocumentoID)
        {
            return objEjeSp.EjecSP("CRE_PI2_LisCrexCli_SP", idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisCredPreApro(int idTipoDocumento, string cDocumentoID)
        {
            return objEjeSp.EjecSP("CRE_PI2_LisCredPreApro_SP", idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisGarOtrUtixCli(int idTipoDocumento, string cDocumentoID)
        {
            return objEjeSp.EjecSP("CRE_PI2_LisGarOtrUtixCli_SP", idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisGarxCli(int idTipoDocumento, string cDocumentoID)
        {
            return objEjeSp.EjecSP("CRE_PI2_LisGarxCli_SP", idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisCtaAhoxCli(int idTipoDocumento, string cDocumentoID)
        {
            return objEjeSp.EjecSP("CRE_PI2_LisCtaAhoxCli_SP", idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisCliCreMismaDire(int idTipoDocumento, string cDocumentoID)
        {
            return objEjeSp.EjecSP("CRE_PI2_LisCliCreMismaDire_SP", idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisCliRelaGrupoEcono(int idTipoDocumento, string cDocumentoID)
        {
            return objEjeSp.EjecSP("CRE_PI2_LisCliRelaGrupoEcono_SP", idTipoDocumento, cDocumentoID);
        }
        public DataTable dtCliPosiblesParientes(int idTipoDocumento, string cDocumentoID)
        {
            return objEjeSp.EjecSP("CRE_PI2_CliPosiblesParientes_SP", idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisCliMismaGar(int idTipoDocumento, string cDocumentoID)
        {
            return objEjeSp.EjecSP("CRE_PI2_LisCliMismaGar_SP", idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisDirNumTelPar(int idTipoDocumento, string cDocumentoID)
        {
            return objEjeSp.EjecSP("CRE_PI2_LisDirNumTelPar_SP", idTipoDocumento, cDocumentoID);
        }
        public DataTable ADdtLstRastreoIntyPos(string cDocumentoID)
        {
            return objEjeSp.EjecSP("GEN_BusRastreoPosIntyPosCon_sp", cDocumentoID);
        }
        public DataTable ADdtLstRastreoPosicionconsolidada(string cDocumentoID)
        {
            return objEjeSp.EjecSP("GEN_BusRastreoPosicionConsolidada_SP", cDocumentoID);
        }
        public DataTable ADdevuelveDatosUsuario(int idUsuario)
        {
            return objEjeSp.EjecSP("GEN_DevuelveDatosUsuario_SP", idUsuario);
        }
        #endregion PosInterv2
    }
}
