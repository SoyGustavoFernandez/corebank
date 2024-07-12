using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRE.AccesoDatos;
using System.Data;

namespace CRE.CapaNegocio
{
    public class clsCNIntervCre
    {
        public clsADIntervCre CNIntervCre = new clsADIntervCre();
        public DataTable obtenerIntervinienteSolicitud(int idSolicitud, int idModulo, bool lNuevo, bool lNoParticipa)
        {
            return CNIntervCre.obtenerIntervinienteSolicitud(idSolicitud, idModulo, lNuevo, lNoParticipa);
        }
        public DataTable CNObtenerIntervinienteActaSolicitud(int idSolicitud, int idModulo)
        {
            return CNIntervCre.ADObtenerIntervinienteActaSolicitud(idSolicitud, idModulo);
        }
        public DataTable CNdtIntervCre(int nNumSolicitud, int idModulo)
        {
            return CNIntervCre.ADdtIntervCre(nNumSolicitud, idModulo);
        }
        public DataTable GuardarIntervCre(int nNumSolicitud, string cCodUsuReg, DateTime pdFecReg,
                string xmlInterv)
        {
            return CNIntervCre.GuardarIntervCre(nNumSolicitud, cCodUsuReg, pdFecReg, xmlInterv);
        }
        
        #region Reporte Posicion Integral

        public DataTable CNdtLisSalRCC(string nIdDocumento, int idTipoDocumento)
        {
            return CNIntervCre.ADdtLisSalRCC(nIdDocumento, idTipoDocumento); 
        }
        public DataTable CNdtLisCalifiRCDSBS(string nIdDocumento, int idTipoDocumento)
        {
            return CNIntervCre.ADdtLisCalifiRCDSBS(nIdDocumento, idTipoDocumento);
        }

        public DataTable CNdtListClienCalifSBS(string nIdDocumento, int idTipoDocumento, int ultiNMeses) 
        {
            return CNIntervCre.ADdtListClienCalifSBS(nIdDocumento, idTipoDocumento, ultiNMeses);
        }

        public DataTable ADdtListClienCalifSBS_Fecha(int idTipoDocumento, string nIdDocumento, string cFecha)
        {
            return CNIntervCre.ADdtListClienCalifSBS_Fecha(idTipoDocumento, nIdDocumento, cFecha);
        }

        public DataTable CNdtLisSaldosRCDSBS(string nCodSbs, int nUltiNMeses = 0, int nDirOrIndi = 0)
        {
            return CNIntervCre.ADdtLisSaldosRCDSBS(nCodSbs, nUltiNMeses, nDirOrIndi);
        }
        public DataTable CNdtLisCrexCliInt(string nIdDocumento, int idTipoDocumento)
        {
            return CNIntervCre.ADdtLisCrexCliInt(nIdDocumento, idTipoDocumento);
        }

        public DataTable CNdtLisGarxCli(string nIdDocumento, int idTipoDocumento)
        {
            return CNIntervCre.ADdtLisGarxCli(nIdDocumento, idTipoDocumento);
        }

        public DataTable CNdtLisCreGarxCli(string nIdDocumento, int idTipoDocumento)
        {
            return CNIntervCre.ADdtLisCreGarxCli(nIdDocumento, idTipoDocumento);
        }

        public DataTable CNdtLisGarOtrUtixCli(string nIdDocumento, int idTipoDocumento)
        {
            return CNIntervCre.ADdtLisGarOtrUtixCli(nIdDocumento, idTipoDocumento);
        }

        public DataTable CNdtLisCtaAhoxCli(string nIdDocumento, int idTipoDocumento)
        {
            return CNIntervCre.ADdtLisCtaAhoxCli(nIdDocumento, idTipoDocumento);
        }

        public DataTable CNdtLisCliCreMismaDire(string nIdDocumento, int idTipoDocumento)
        {
            return CNIntervCre.ADdtLisCliCreMismaDire(nIdDocumento, idTipoDocumento);
        }

        public DataTable CNdtLisVinculadosaCli(string nIdDocumento, int idTipoDocumento)
        {
            return CNIntervCre.ADdtLisVinculadosaCli(nIdDocumento, idTipoDocumento);
        }

        public DataTable CNdtVerificarRelacionCliente(string nIdDocumento, int idTipDoc)
        {
            return CNIntervCre.ADdtVerificarRelacionCliente(nIdDocumento, idTipDoc);
        }

        public DataTable CNdtLisCliMismaGar(string nIdDocumento, int idTipoDocumento)
        {
            return CNIntervCre.ADdtLisCliMismaGar(nIdDocumento, idTipoDocumento);
        }

        public DataTable CNdtLisCliRelaGrupoEcono(string nIdDocumento, int idTipoDocumento)
        {
            return CNIntervCre.ADdtLisCliRelaGrupoEcono(nIdDocumento, idTipoDocumento);
        }

        public DataTable CNdtLstRastreoInt(string cDocumentoID = "0", int idTipoDocumento = 0)
        {
            return CNIntervCre.ADdtLstRastreoInt(cDocumentoID, idTipoDocumento);
        }
        public DataTable CNdtLstRastreoIntyPost(string cDocumentoID = "0")
        {
            return CNIntervCre.ADdtLstRastreoIntyPos(cDocumentoID);
        }
        public DataTable CNdtLstRastreoPosicionConsolidada(string cDocumentoID = "0")
        {
            return CNIntervCre.ADdtLstRastreoPosicionconsolidada(cDocumentoID);
        }

        
        public DataTable CNADdevuelveDatosUsuario(int idUsuario)
        {
            return CNIntervCre.ADdevuelveDatosUsuario(idUsuario);
        }
        
        public DataTable CNdtLisSolCreCli(string cDocumentoID, int idTipoDocumento)
        {
            return CNIntervCre.ADdtLisSolCreCli(cDocumentoID, idTipoDocumento);
        }

        public DataTable CNdtLisDatBaseNegativa(string cDocumentoID, int idTipoDocumento)
        {
            return CNIntervCre.ADdtLisDatBaseNegativa(cDocumentoID, idTipoDocumento);
        }

        public DataTable CNdtLisDatPEP(string cDocumentoID, int idTipoDocumento)
        {
            return CNIntervCre.ADdtLisDatPEP(cDocumentoID, idTipoDocumento);
        }

        public DataTable ValidaExistePersonaSBSPosInt(int idTipoDocumento, string cDocumento)
        {
            return CNIntervCre.ValidaExistePersonaSBSPosInt(idTipoDocumento, cDocumento);
        }

        public DataTable CNValidaExistePersonaCampania(int idTipoDocumento, string cDocumento)
        {
            return CNIntervCre.ADValidaExistePersonaCampania(idTipoDocumento, cDocumento);
        }

        public DataTable CNLisCarFiaCli(int idCli)
        {
            return CNIntervCre.ADLisCarFiaCli(idCli);
        }

        public DataTable CNLisCreCliFiSol(int idCli)
        {
            return CNIntervCre.ADLisCreCliFiSol(idCli);
        }

        public DataTable CNBaseNegativa(string cDocumentoID, int idTipoDocumento)
        {
            return CNIntervCre.ADBaseNegativa(cDocumentoID, idTipoDocumento);
        }

        public DataTable CNLibBaseNegativa(string cDocumentoID, int idTipoDocumento)
        {
            return CNIntervCre.ADLibBaseNegativa(cDocumentoID, idTipoDocumento);
        }

        #endregion

        public DataTable ValidaExistePersonaSBS(string cDocumento)
        {
            return CNIntervCre.ValidaExistePersonaSBS(cDocumento);
        }

        public DataTable validaPermisoQuitarConyugue(int idPerfil)
        {
            return CNIntervCre.validaPermisoQuitarConyugue(idPerfil);    
        }

        public DataTable CNdtLstRastreo(int idCli = 0, int idCuenta = 0, int idModulo = 0, int idMenu = 0, int idUsuReg = 0,
                                       string cDocumentoID = "0")
        {
            return CNIntervCre.ADdtLstRastreo(idCli, idCuenta, idModulo, idMenu, idUsuReg, cDocumentoID);
        }

        public DataTable CNdtLisCrexCli(string nIdDocumento)
        {
            return CNIntervCre.ADdtLisCrexCli(nIdDocumento);
        }
        public DataTable CNdtIntervSoli(int nNumSolicitud, int idModulo, bool lNoParticipa = true)
        {
            return CNIntervCre.ADdtIntervSoli(nNumSolicitud, idModulo, lNoParticipa);
        }

        public DataTable CNEdadAniosDias(DateTime dFechaNacimiento)
        {
            return CNIntervCre.ADEdadAniosDias(dFechaNacimiento);
        }

        public DataTable CNClasifiInterna(int idCli, int nMeses)
        {
            return CNIntervCre.ADClasifiInterna(idCli, nMeses);
        }

        public DataTable CNCliPosiblesParientes(int idCli, string cPaterno = "", string cMaterno = "")
        {
            return CNIntervCre.ADCliPosiblesParientes(idCli, cPaterno, cMaterno);
        }

        public DataTable CNlisCreCli_2(int idCli) 
        {
            return CNIntervCre.ADLisCreCli_2(idCli);
        }

        public DataTable CNLisSolCli(string cDocumentoId, int idTipDoc)
        {
            return CNIntervCre.ADLisSolCli(cDocumentoId, idTipDoc);
        }

        public DataTable CNAvaladosRCCSBS(string cDocumentoID, int idTipoDocumento)
        {
            return CNIntervCre.ADAvaladosRCCSBS(cDocumentoID, idTipoDocumento);
        }

        public DataTable CNCrePreApro(int idCli)
        {
            return CNIntervCre.ADCrePreAprov(idCli);
        }

        public DataTable CNDirNumTelPar(int idCli, int idCliCony = -1)
        {
            return CNIntervCre.ADDirNumTelPar(idCli, idCliCony);
        }

        #region PosInterv2
        public DataTable dtCalifEntityRccSbs(int idTipoDocumento, string cDocumentoID)
        {
            return this.CNIntervCre.dtCalifEntityRccSbs(idTipoDocumento, cDocumentoID);
        }
        public DataTable dtsaldosSbsTitCony(int idTipoDocumento, string cDocumentoID)
        {
            return this.CNIntervCre.dtsaldosSbsTitCony(idTipoDocumento, cDocumentoID);
        }
        public DataTable dtsaldosEntidadFinanciera(int idTipoDocumento, string cDocumentoID,string cFecha)
        {
            return this.CNIntervCre.dtsaldosEntidadFinanciera(idTipoDocumento, cDocumentoID, cFecha);
        }
        
        public DataTable dtLisAvaladosRCCSBS(int idTipoDocumento, string cDocumentoID)
        {
            return this.CNIntervCre.dtLisAvaladosRCCSBS(idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisCreCliFiSol(int idTipoDocumento, string cDocumentoID)
        {
            return this.CNIntervCre.dtLisCreCliFiSol(idTipoDocumento, cDocumentoID);
        }
        public DataTable dtListaCartasFianzaCliente(int idTipoDocumento, string cDocumentoID)
        {
            return this.CNIntervCre.dtListaCartasFianzaCliente(idTipoDocumento, cDocumentoID);
        }
        public DataTable dtClasifiInternaCaja(int idTipoDocumento, string cDocumentoID)
        {
            return this.CNIntervCre.dtClasifiInternaCaja(idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisPEPPosInterv(int idTipoDocumento, string cDocumentoID)
        {
            return this.CNIntervCre.dtLisPEPPosInterv(idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisBaseNegativa(int idTipoDocumento, string cDocumentoID)
        {
            return this.CNIntervCre.dtLisBaseNegativa(idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisLibBaseNegativa(int idTipoDocumento, string cDocumentoID)
        {
            return this.CNIntervCre.dtLisLibBaseNegativa(idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLstSolicitudesCli(int idTipoDocumento, string cDocumentoID)
        {
            return this.CNIntervCre.dtLstSolicitudesCli(idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisCrexCli(int idTipoDocumento, string cDocumentoID)
        {
            return this.CNIntervCre.dtLisCrexCli(idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisCredPreApro(int idTipoDocumento, string cDocumentoID)
        {
            return this.CNIntervCre.dtLisCredPreApro(idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisGarOtrUtixCli(int idTipoDocumento, string cDocumentoID)
        {
            return this.CNIntervCre.dtLisGarOtrUtixCli(idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisGarxCli(int idTipoDocumento, string cDocumentoID)
        {
            return this.CNIntervCre.dtLisGarxCli(idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisCtaAhoxCli(int idTipoDocumento, string cDocumentoID)
        {
            return this.CNIntervCre.dtLisCtaAhoxCli(idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisCliCreMismaDire(int idTipoDocumento, string cDocumentoID)
        {
            return this.CNIntervCre.dtLisCliCreMismaDire(idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisCliRelaGrupoEcono(int idTipoDocumento, string cDocumentoID)
        {
            return this.CNIntervCre.dtLisCliRelaGrupoEcono(idTipoDocumento, cDocumentoID);
        }
        public DataTable dtCliPosiblesParientes(int idTipoDocumento, string cDocumentoID)
        {
            return this.CNIntervCre.dtCliPosiblesParientes(idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisCliMismaGar(int idTipoDocumento, string cDocumentoID)
        {
            return this.CNIntervCre.dtLisCliMismaGar(idTipoDocumento, cDocumentoID);
        }
        public DataTable dtLisDirNumTelPar(int idTipoDocumento, string cDocumentoID)
        {
            return this.CNIntervCre.dtLisDirNumTelPar(idTipoDocumento, cDocumentoID);
        }
        #endregion PosInterv2
    }
}
