using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADGuardaPersonal
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        //===============================================================
        //Método para Guardar Datos del Personal
        //===============================================================
        public DataTable GuardaPersonal(int nIdCli, int nidAgencia, int nIdCargo,
                                        int idTipContrato, int idTipoRegimen, int idRegimen,int idEsqComAFP, string cRegPensiones,
                                        DateTime dInicioPensiones, string cCtaSalario,string cCtaCTS, string cAutogenerado,
                                        int idGrupSanguineo, int nidArea, int nidEstablecimiento, int idTipoContratoTiempo, int lDiscapacidad,
                                        int lDepSalarioPropio, int lDepCTSPropio, int idCodInstSalario, int idCodInstCTS,
                                        string xmlRelLab, string xmlFamiliares, int idCategoria, string cWinUser, DateTime dFechaReg, int idUsuReg, string  cEmailInst, string cTelCelPer)
        {
            return objEjeSp.EjecSP("Gen_GuardarPersonal_Sp", nIdCli, nidAgencia,  nIdCargo,
                                                             idTipContrato, idTipoRegimen, idRegimen, idEsqComAFP, cRegPensiones,
                                              dInicioPensiones, cCtaSalario,cCtaCTS, cAutogenerado,
                                              idGrupSanguineo, nidArea, nidEstablecimiento, idTipoContratoTiempo, lDiscapacidad,
                                              lDepSalarioPropio, lDepCTSPropio, idCodInstSalario, idCodInstCTS,
                                              xmlRelLab, xmlFamiliares, idCategoria, cWinUser, dFechaReg, idUsuReg, cEmailInst, cTelCelPer);
        }
        //===============================================================
        //Método para Actualizar Datos del Personal
        //===============================================================
        public void ActualizaPersonal(int nIdUsuario, int nidAgencia, int nIdCargo,
                                      int idTipContrato, int idTipoRegimen, int idRegimen,int idEsqComAFP, string cRegPensiones,
                                      DateTime dInicioPensiones, string cCtaSalario,string cCtaCTS, string cAutogenerado,
                                      int idGrupSanguineo, int nidArea, int nidEstablecimiento, int idTipoContratoTiempo, int lDiscapacidad,
                                      int lDepSalarioPropio, int lDepCTSPropio, int idCodInstSalario, int idCodInstCTS,
                                      string xmlRelLab, string xmlFamiliares, int idCategoria, DateTime dFechaReg, int idUsuReg, string  cEmailInst, string cTelCelPer)
        {
            objEjeSp.EjecSP("Gen_ActualizarPersonal_Sp", nIdUsuario, nidAgencia,  nIdCargo,
                                                         idTipContrato, idTipoRegimen, idRegimen,idEsqComAFP, cRegPensiones,
                                              dInicioPensiones, cCtaSalario,cCtaCTS, cAutogenerado,
                                              idGrupSanguineo, nidArea, nidEstablecimiento, idTipoContratoTiempo, lDiscapacidad,
                                              lDepSalarioPropio, lDepCTSPropio, idCodInstSalario, idCodInstCTS,
                                              xmlRelLab, xmlFamiliares, idCategoria, dFechaReg, idUsuReg, cEmailInst, cTelCelPer);
        }
        public DataTable ListarCtasPersonal(int nIdCli)
        {
            return objEjeSp.EjecSP("CLI_ListarCtasPersonal_sp", nIdCli);
        }
        public DataTable ListarCtasCTS(int nIdCli)
        {
            return objEjeSp.EjecSP("CLI_ListarCtasPersonalCTS_sp", nIdCli);
        }
        //===============================================================
        //Método para registrar contratos del Personal
        //===============================================================
        public DataTable RegistrarContratosPersonal(int idRelacionLab, int idTipoContrato, DateTime dFechaInicio, DateTime dFechaVencimiento, int idArea, int IdAgencia, int idEstado, int idCargo, int idModalidadCont, int idTipoPagoRem)
        {
            return objEjeSp.EjecSP("GRH_GrabarContratos_sp", idRelacionLab, idTipoContrato, dFechaInicio, dFechaVencimiento, idArea, IdAgencia, idEstado, idCargo, idModalidadCont, idTipoPagoRem);
        }
        //===============================================================
        //Método para Actualizar contratos del Personal
        //===============================================================
        public DataTable ActualizaContratosPersonal(int idContrato, int idRelacionLab, int idTipoContrato, DateTime dFechaInicio, DateTime dFechaCese, DateTime dFechaVencimiento, int idArea, int IdAgencia, int idEstado, bool lVigente, int idCargo, int idModalidadCont, int idTipoPagoRem)
        {
            return objEjeSp.EjecSP("GRH_ActualizarContratos_sp", idContrato, idRelacionLab, idTipoContrato, dFechaInicio, dFechaCese, dFechaVencimiento, idArea, IdAgencia, idEstado, lVigente, idCargo, idModalidadCont, idTipoPagoRem);
        }

        public DataTable ADRetornarUsuarioParaSistema(int idCli)
        {
            return objEjeSp.EjecSP("GTH_RetornarUsuarioParaSistema_SP", idCli);
        }
    }
}
