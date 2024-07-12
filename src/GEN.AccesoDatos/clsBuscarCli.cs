using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsBuscarCli
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        //Crear Método para ejecutar SP
        public DataTable BuscarCliente(string cCriBus, string cDatosCli, int idAgencia)
        {
            return objEjeSp.EjecSP("Gen_BuscarCli_sp", cCriBus, cDatosCli, idAgencia);
        }
        public DataTable BuscarClienteBN(int nModo, string cCriBus, string cDatosCli)
        {
            //objEjeSp.CargaParametroSP("", 1);
            return objEjeSp.EjecSP("Gen_BuscarCliBN_sp", nModo, cCriBus, cDatosCli);
        }
        public DataTable DatoClientexIdCli(Int32 IdCli)
        {
            return objEjeSp.EjecSP("CLI_DatoClientexIdCli_Sp", IdCli);
        }
        public DataTable DatosClientexNumSol(int idSol)
        {
            return objEjeSp.EjecSP("Gen_RetornaIdCliByNumSol_Sp", idSol);
        }
        public DataTable DatosPersonaPep(int idTipoDoc, string  nNumDoc, int idCli)
        {
            return objEjeSp.EjecSP("GEN_BuscarPersonaPep", idTipoDoc, nNumDoc, idCli);
        }
        //--================================================================================
        //--Guardar Solicitudes de Aprobacion SPLAFT
        //--================================================================================
        public DataTable GuardarSolicitudAprobacSPLAFT(int idAgencia, int idCliente, int idMoneda,
                                                 Decimal nMontoOpe, DateTime dFecSolici,int idUsuRegist)
        {
            return new clsGENEjeSP().EjecSP("SPL_RegSolAprobacion_Sp", idAgencia, idCliente, idMoneda, 
                                                                      nMontoOpe, dFecSolici, idUsuRegist);

        }
        //--================================================================================
        //--validar estado de la solicitud de splaft
        //--================================================================================
        public DataTable buscarSolicitudSplaft(int idCli)
        {
            return new clsGENEjeSP().EjecSP("SPL_BuscarSolAprobada_Sp", idCli);
        }

        public DataSet AlertarSocioNoEstaAlDiaAportes(int idCliente, DateTime dFecSystem)
        {
            return objEjeSp.DSEjecSP("CLI_SituacionSocioAportesFondoMortuorio_Sp", idCliente, dFecSystem);
        }

        public DataTable MarcarComoRegistroPEPPendiente(int idCli, string cDocumento, string ApellidoPat, string ApellidoMat, string cNombres, DateTime dFechaNac, int idTipoDoc, string cCargo)
        {
            return objEjeSp.EjecSP("CLI_MarcarComoRegistroPEPPendiente_Sp", idCli, cDocumento, ApellidoPat, ApellidoMat, cNombres, dFechaNac, idTipoDoc, cCargo);
        }

        //--================================================================================
        //--Valida si Cliente esta en Base Negativa
        //--================================================================================
        public DataTable ValidaCliBaseNegativa(string cNroDocumento, int idModulo)
        {
            return new clsGENEjeSP().EjecSP("CLI_ValidarCliBaseNegativa_Sp", cNroDocumento, idModulo);
        }

        public DataTable GetDatosGenCli(int idCli)
        {
            return new clsGENEjeSP().EjecSP("GEN_GetDatosGenCli_Sp", idCli);
        }
        public DataTable ADClienteNuevoRecurrente(int idCli)
        {
            return objEjeSp.EjecSP("CRE_ClienteNuevoRecurrente_SP", idCli);
        }

        public DataTable BuscarClientePosInt(int idTipoDocumento, string cDniNom)
        {
            return objEjeSp.EjecSP("Gen_BuscarCliPosInt_sp", idTipoDocumento, cDniNom);
        }

        public DataTable determinarTipoCliente(int idCli)
        {
            return objEjeSp.EjecSP("CRE_DeterminarTipoCliente_SP", idCli);
        }

        public DataTable ADClienteNuevoRecurrenteNuevoCalculo(int idCli)
        {
            return objEjeSp.EjecSP("CRE_ClienteNuevoRecurrenteNuevoCalculo_SP", idCli);
        }

        public DataTable ADClienteRecurrenteCredParalelos(string cXml)
        {
            return objEjeSp.EjecSP("CRE_ClienteRecurrenteCredParalelos_SP", cXml);
        }

        public DataTable ADValidarClienteCreditoTasaCamp(int idCli, int idProducto, int idOperacion)
        {
            return objEjeSp.EjecSP("CRE_ValidarClienteCreditoTasaCamp_SP", idCli, idProducto, idOperacion);
        }

        public DataTable ADComprobarProductCamp(int idProducto)
        {
            return objEjeSp.EjecSP("CRE_ComprobarProductoCamp_SP", idProducto);
        }

        public DataTable ADListarClientesQori()
        {
            return objEjeSp.EjecSP("CRE_ListaClientesQori_SP");
        }
        public DataTable ADRecalculoCondiciones()
        {
            return objEjeSp.EjecSP("CRE_RecalculoQori_SP");
        }
        public DataTable ADInsertaClientes(string xmlCargaCli,int idUsuReg)
        {
            return objEjeSp.EjecSP("CRE_InsertarClientesQori_SP", xmlCargaCli,idUsuReg);
        }
        public DataTable ADListarAsesorQori()
        {
            return objEjeSp.EjecSP("CRE_MostrarAsesorQori_SP");
        }
        public DataTable ADListarCreditoQori()
        {
            return objEjeSp.EjecSP("CRE_MostrarCreditosQori_SP");
        }
        public DataTable ADCambiarClasificacionInterna(int idCli, int idClasifInterna)
        {
            return objEjeSp.EjecSP("CRE_CambiaClasifInterna_SP",idCli,idClasifInterna);
        }

        public DataTable ADCambiarClasificacionInternaxOferta(int idCli, int idClasifInterna, int idUsuarioReg, int idOferta)
        {
            return objEjeSp.EjecSP("CRE_CambiaClasifInternaxOferta_SP", idCli, idClasifInterna, idUsuarioReg, idOferta);
        }
        public DataTable ADVerificaClasificacionInternaxOferta(int idCli)
        {
            return objEjeSp.EjecSP("CRE_VerificaClasifInternaxOferta_SP", idCli);
        }
        public DataTable ADBuscarClienteXDocumentoID(string cDocumentoID, int idTipoDocumento)
        {
            return objEjeSp.EjecSP("GEN_BuscarClienteXDocumentoID_SP", cDocumentoID, idTipoDocumento);
        }
        //Crear Método para ejecutar SP
        public DataTable BuscarClienteAutUsoDatos(string cCriBus, string cDatosCli, int idAgencia)
        {
            return objEjeSp.EjecSP("TDP_BuscarCliAutUsoDat_SP", cCriBus, cDatosCli, idAgencia);
        }

        public DataTable DatoClientexIdCliAutUsoDatos(Int32 IdCli)
        {
            return objEjeSp.EjecSP("TDP_BuscarCliAutUsoDatxIdCli_SP", IdCli);
        }

    }
}
