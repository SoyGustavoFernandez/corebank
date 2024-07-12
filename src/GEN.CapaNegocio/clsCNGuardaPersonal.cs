using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNGuardaPersonal
    {
        clsADGuardaPersonal objGuardaPersonal = new clsADGuardaPersonal();
        //=========================================================================
        //--Metodo que Envia los Datos para Guardar
        //=========================================================================
        public DataTable GuardaPersonal(int nIdCli, int nidAgencia, int nIdCargo,
                                       int idTipContrato,int idTipoRegimen,int idRegimen,int idEsqComAFP,string cRegPensiones,
                                        DateTime dInicioPensiones, string cCtaSalario,string cCtaCTS, string cAutogenerado,
                                        int idGrupSanguineo, int nidArea, int nidEstablecimiento,int idTipoContratoTiempo,int lDiscapacidad,
                                        int lDepSalarioPropio, int lDepCTSPropio, int idCodInstSalario, int idCodInstCTS,
                                        string xmlRelLab, string xmlFamiliares, int idCategoria, string cWinUser, DateTime dFechaReg, int idUsuReg, string  cEmailInst, string cTelCelPer)
        {
            return objGuardaPersonal.GuardaPersonal(nIdCli, nidAgencia,  nIdCargo,
                                                     idTipContrato, idTipoRegimen, idRegimen, idEsqComAFP, cRegPensiones,
                                              dInicioPensiones, cCtaSalario,cCtaCTS, cAutogenerado,
                                              idGrupSanguineo, nidArea, nidEstablecimiento, idTipoContratoTiempo, lDiscapacidad, 
                                              lDepSalarioPropio, lDepCTSPropio, idCodInstSalario, idCodInstCTS,
                                              xmlRelLab, xmlFamiliares, idCategoria, cWinUser, dFechaReg, idUsuReg, cEmailInst, cTelCelPer);
        }
        //=========================================================================
        //--Metodo que Envia los Datos para Actualizar
        //=========================================================================
        public void ActualizaPersonal(int nIdUsuario,  int nidAgencia, int nIdCargo, 
                                        int idTipContrato, int idTipoRegimen, int idRegimen, int idEsqComAFP, string cRegPensiones,
                                        DateTime dInicioPensiones, string cCtaSalario, string cCtaCTS, string cAutogenerado,
                                        int idGrupSanguineo, int nidArea, int nidEstablecimiento, int idTipoContratoTiempo, int lDiscapacidad,
                                        int lDepSalarioPropio, int lDepCTSPropio, int idCodInstSalario, int idCodInstCTS,
                                        string xmlRelLab, string xmlFamiliares, int idCategoria, DateTime dFechaReg, int idUsuReg, string  cEmailInst, string cTelCelPer)
        {
            objGuardaPersonal.ActualizaPersonal(nIdUsuario, nidAgencia,  nIdCargo,
                                                idTipContrato, idTipoRegimen, idRegimen,idEsqComAFP, cRegPensiones,
                                              dInicioPensiones, cCtaSalario, cCtaCTS, cAutogenerado,
                                              idGrupSanguineo, nidArea, nidEstablecimiento, idTipoContratoTiempo, lDiscapacidad,
                                              lDepSalarioPropio, lDepCTSPropio, idCodInstSalario, idCodInstCTS,
                                              xmlRelLab, xmlFamiliares, idCategoria, dFechaReg, idUsuReg, cEmailInst, cTelCelPer);
        }
        public DataTable ListarCtasPersonal(int nIdCli)
        {
            return objGuardaPersonal.ListarCtasPersonal(nIdCli);
        }
        public DataTable ListarCtasCTS(int nIdCli)
        {
            return objGuardaPersonal.ListarCtasCTS(nIdCli);
        }

        //=========================================================================
        //--Metodo que actualiza los contratos del personal
        //=========================================================================
        public DataTable RegistraContratoPersonal(int idRelacionLab, int idTipoContrato, DateTime dFechaInicio, DateTime dFechaVencimiento, int idArea, int IdAgencia, int idEstado, int idCargo, int idModalidadCont, int idTipoPagoRem)
        {
            return objGuardaPersonal.RegistrarContratosPersonal(idRelacionLab, idTipoContrato, dFechaInicio, dFechaVencimiento, idArea, IdAgencia, idEstado, idCargo, idModalidadCont, idTipoPagoRem);
        }
        //=========================================================================
        //--Metodo que actualiza los contratos del personal
        //=========================================================================
        public DataTable ActualizaContratoPersonal(int idContrato, int idRelacionLab, int idTipoContrato, DateTime dFechaInicio, DateTime dFechaCese, DateTime dFechaVencimiento, int idArea, int IdAgencia, int idEstado, bool lVigente, int idCargo, int idModalidadCont, int idTipoPagoRem)
        {
            return objGuardaPersonal.ActualizaContratosPersonal(idContrato, idRelacionLab, idTipoContrato, dFechaInicio, dFechaCese, dFechaVencimiento, idArea, IdAgencia, idEstado, lVigente, idCargo, idModalidadCont, idTipoPagoRem);
        }

        public DataTable CNRetornarUsuarioParaSistema(int idCli)
        {
            return objGuardaPersonal.ADRetornarUsuarioParaSistema(idCli);
        }
    }
}
