using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;
using System.Windows.Forms;
using CLI.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNBuscarCli
    {
        clsBuscarCli objListarCli = new clsBuscarCli();
        clsADCliente objADCliente = new clsADCliente(); // solo para usar calculadora de edad

        // Crear metodo para recibid datos en un datatable
        public DataTable ListarClientes(string cCriBus,string cDniNom, int idAgencia = 0)
        {
            return objListarCli.BuscarCliente(cCriBus,cDniNom, idAgencia);
        }
        public DataTable ListarClientesBN(int nModo, string cCriBus, string cDniNom)
        {
            return objListarCli.BuscarClienteBN(nModo, cCriBus, cDniNom);
        }
        public DataTable ListarclixIdCli(Int32 idCli)
        {
            return objListarCli.DatoClientexIdCli(idCli);
        }
        public DataTable DatosClientexNumSol(int idSol)
        {
            return objListarCli.DatosClientexNumSol(idSol);
        }
        public DataTable ValidaPersonaPep(int idTipoDoc,string nNumDoc, int idCli)
        {
            return objListarCli.DatosPersonaPep(idTipoDoc, nNumDoc, idCli);
        }
        //--================================================================================
        //--Guardar Solicitudes de Aprobacion SPLAFT
        //--================================================================================
        public DataTable GuardarSolicitudAprobacSPLAFT(int idAgencia, int idCliente, int idMoneda,
                                                 Decimal nMontoOpe, DateTime dFecSolici, int idUsuRegist)
        {
            return objListarCli.GuardarSolicitudAprobacSPLAFT(idAgencia, idCliente, idMoneda,
                                                              nMontoOpe, dFecSolici, idUsuRegist);
        }
        //--================================================================================
        //--validar estado de la solicitud de SPLAFT
        //--================================================================================
        public DataTable ValidarSolicitudSplaft(int idCliente)
        {
            return objListarCli.buscarSolicitudSplaft(idCliente);
        }

        /// <summary>
        /// Consulta si el cliente no está al día con sus Aportes y Seguro Mortuorio
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public string AlertarSocioNoEstaAlDiaAportes(int idCliente, DateTime dFecSystem)
        {
            DataSet dsSituacion = objListarCli.AlertarSocioNoEstaAlDiaAportes(idCliente, dFecSystem);

            DataTable dtAportes         = dsSituacion.Tables[0];
            DataTable dtFondoMortuorio  = dsSituacion.Tables[1];

            string cMensajeAportes = "";
            string cMensajeFondoMortuorio = "";

            if (dtAportes.Rows.Count>0)
            {
                cMensajeAportes = "- El socio no está al día con sus APORTES."+ Environment.NewLine;
            }
            if (dtFondoMortuorio.Rows.Count > 0)
            {
                cMensajeFondoMortuorio = "- El socio no está al día con su FONDO DE SEGURO.";
            }

            return cMensajeAportes + cMensajeFondoMortuorio;
        }


        public DataTable MarcarComoRegistroPEPPendiente(int idCli, string cDocumento, string ApellidoPat, string ApellidoMat, string cNombres, DateTime dFechaNac, int idTipoDoc, string cCargo)
        {
            return objListarCli.MarcarComoRegistroPEPPendiente(idCli, cDocumento, ApellidoPat, ApellidoMat, cNombres, dFechaNac, idTipoDoc, cCargo);
        }

        //--================================================================================
        //--Valida si Cliente esta en Base Negativa
        //--================================================================================
        public bool ValidaCliBaseNegativa(string cNroDocumento, int idModulo, bool lBaseNegativa)
        {
            if (!lBaseNegativa)
            {
                return false;
            }
            DataTable dtBasNeg = objListarCli.ValidaCliBaseNegativa(cNroDocumento, idModulo);
            if (dtBasNeg.Rows.Count>0)
            {
                MessageBox.Show("Cliente se encuentra en la Base Negativa por el siguiente motivo: \n" + dtBasNeg.Rows[0]["cMotivo"].ToString(), "Validar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        public DataTable GetDatosGenCli(int idCli)
        {
            return objListarCli.GetDatosGenCli(idCli);
        }
        public DataTable CNClienteNuevoRecurrente(int idCli)
        {
            return objListarCli.ADClienteNuevoRecurrente(idCli);
        }

        public DataTable ListarClientesPosInt(int idTipoDocumento, string cDniNom)
        {
            return objListarCli.BuscarClientePosInt(idTipoDocumento, cDniNom);
        }

        public DataTable determinarTipoCliente(int idCli)
        {
            return objListarCli.determinarTipoCliente(idCli);
        }

        public DataTable CNClienteNuevoRecurrenteNuevoCalculo(int idCli)
        {
            return objListarCli.ADClienteNuevoRecurrenteNuevoCalculo(idCli);
        }

        public DataTable CNClienteRecurrenteCredParalelos( string  cXml)
        {
            return objListarCli.ADClienteRecurrenteCredParalelos(cXml);
        }

        public DataTable CNValidarClienteCreditoTasaCamp(int idCli, int idProducto, int idOperacion)
        {
            return objListarCli.ADValidarClienteCreditoTasaCamp(idCli, idProducto, idOperacion);
        }


        public DataTable CNComprobarProductCamp(int idProducto)
        {
            return objListarCli.ADComprobarProductCamp(idProducto);
        }

        public int CNCalcularEdad(int idCliente, DateTime dFechaActual)
        {
            return objADCliente.ADCalcularEdad(idCliente, dFechaActual);
        }
        public DataTable CNListarClientesQori()
        {
            return objListarCli.ADListarClientesQori();
        }
        public DataTable CNRecalculoCondiciones()
        {
            return objListarCli.ADRecalculoCondiciones();
        }
        public DataTable CNInsertaClientes(string xmlCargaCli,int idUsuReg)
        {
            return objListarCli.ADInsertaClientes(xmlCargaCli, idUsuReg);
        }
        public DataTable CNListarAsesorQori()
        {
            return objListarCli.ADListarAsesorQori();
        }
        public DataTable CNListarCreditoQori()
        {
            return objListarCli.ADListarCreditoQori();
        }
        public DataTable CNCambiarClasificacionInterna(int idCli, int idClasifInterna)
        {
            return objListarCli.ADCambiarClasificacionInterna(idCli,idClasifInterna);
        }
        public DataTable CNCambiarClasificacionInternaxOferta(int idCli, int idClasifInterna, int idUsuarioReg, int idOferta)
        {
            return objListarCli.ADCambiarClasificacionInternaxOferta(idCli, idClasifInterna, idUsuarioReg, idOferta);
        }
        public DataTable CNVerificaClasificacionInternaxOferta(int idCli)
        {
            return objListarCli.ADVerificaClasificacionInternaxOferta(idCli);
        }

        public DataTable CNBuscarClienteXDocumentoID(string cDocumentoID, int idTipoDocumento)
        {
            return objListarCli.ADBuscarClienteXDocumentoID(cDocumentoID, idTipoDocumento);
        }
        // Crear metodo para recibir datos en un datatable
        public DataTable ListarClientesAutUsoDatos(string cCriBus, string cDniNom, int idAgencia = 0)
        {
            return objListarCli.BuscarClienteAutUsoDatos(cCriBus, cDniNom, idAgencia);
        }
        public DataTable ListarClixIdCliAutUsoDatos(Int32 idCli)
        {
            return objListarCli.DatoClientexIdCliAutUsoDatos(idCli);
        }

    }
}
