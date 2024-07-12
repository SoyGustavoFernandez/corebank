using EntityLayer;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DEP.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmExtractoCuentas : frmBase
    {
        clsCNEnvExtCtas clsEnvExtCtas = new clsCNEnvExtCtas();
        string cHtmlPlantilla;
        string cNota;

        public frmExtractoCuentas()
        {
            InitializeComponent();
            inicializaPlantillaEnvCtaAhorros();
        }

        private void frmExtractoCuentas_Load(object sender, EventArgs e)
        {
            conBusCtaAho.nTipOpe = 18;
            conBusCtaAho.lBloqueaBusquedaNombre = this.lBloqueaBusquedaNombre;
            conBusCtaAho.pnIdMon = 0;
            conBusCtaAho.idcuenta = 0;
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            conBusCtaAho.txtCodAge.Focus();
            dtFecFin.Value = clsVarGlobal.dFecSystem;
            dtFecInicio.Value = clsVarGlobal.dFecSystem;
        }

        private void inicializaPlantillaEnvCtaAhorros()
        {
            DataTable dtHtmlPlanExtCtasCor = clsEnvExtCtas.CNObtenerHtmlPlanExtCtaCorreo();
            if (dtHtmlPlanExtCtasCor.Rows.Count > 0)
            {
                this.cHtmlPlantilla = Convert.ToString(dtHtmlPlanExtCtasCor.Rows[0]["cHtmlPlan"]);
                this.cNota = Convert.ToString(dtHtmlPlanExtCtasCor.Rows[0]["cNota"]);
            }
            else
            {
                MessageBox.Show("No se encuentra la plantilla html para el envío de correo", "Envío de extractos de cuentas por Correo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            //VALIDACIONES
            if (Convert.ToDateTime(dtFecFin.Value.ToShortDateString()) < Convert.ToDateTime(dtFecInicio.Value.ToShortDateString()))
            {
                MessageBox.Show("Periodo Incorrecto: La fecha de Inicio es posterior a la Final", "Validación de extracto de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(conBusCtaAho.txtNroCta.Text))
            {
                MessageBox.Show("Debe Seleccionar primero la Cuenta y/o Cliente", "Validación de extracto de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(conBusCtaAho.txtNombre.Text))
            {
                MessageBox.Show("No Existe cliente para la búsqueda", "Validación de extracto de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Convert.ToInt32(conBusCtaAho.txtNroCta.Text.Trim()) == 0)
            {
                MessageBox.Show("El valor de búsqueda no puede ser igual a cero(0)", "Validación de extracto de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DateTime dFecInicio = dtFecInicio.Value;
            DateTime dFecFin = dtFecFin.Value;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];            
            
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("x_dFechaINI", dFecInicio.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_dFechaFIN", dFecFin.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
            paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("x_cMensaje", this.cNota, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            int idUsuario = clsVarGlobal.User.idUsuario;
            string cPathRoot = clsVarGlobal.cRutPathApp;
            string cPathAnioMes = this.dtFecFin.Value.ToString("yyyyMMdd");
            string cNroCuenta = conBusCtaAho.txtCodIns.Text + conBusCtaAho.txtCodAge.Text + conBusCtaAho.txtCodMod.Text + conBusCtaAho.txtCodMon.Text + conBusCtaAho.txtNroCta.Text;
            string cRuta = Path.Combine(cPathRoot, cPathAnioMes);
            string cDireccion = Path.Combine(cRuta, cNroCuenta + "." + enuFormatoReporte.Pdf);            

            DataTable dtDatosCta = new clsRPTCNDeposito().CNDatosExtractoCta(Convert.ToInt32(conBusCtaAho.idcuenta));
            if (dtDatosCta.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Validación de extracto de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string cCorreo = Convert.ToString(dtDatosCta.Rows[0]["cDireccionEnvioEstCta"]);
            string cNombresCliente = Convert.ToString(dtDatosCta.Rows[0]["cNombre"]);

            DataTable dtExtracto = new clsRPTCNDeposito().CNRptMovimientosExtCtaCorreo(Convert.ToInt32(conBusCtaAho.idcuenta), dFecInicio, dFecFin);
            if (dtExtracto.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Validación de extracto de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dtResImpExtCta = new clsRPTCNDeposito().CNRegistroImpresionesExtCta(Convert.ToInt32(conBusCtaAho.idcuenta), clsVarGlobal.dFecSystem, clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.nIdAgencia);
            if (Convert.ToInt32(dtResImpExtCta.Rows[0]["nResp"]) == 1)
            {
                txtNroImpresion.Text = (Convert.ToInt32(txtNroImpresion.Text) + 1).ToString();
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsGenExtracCta", dtDatosCta));
            dtslist.Add(new ReportDataSource("dsExtractoCuenta", dtExtracto));

            string reportpath = "rptExtCtaCorreo.rdlc";

            DataTable dtExtCtasGenEnv = null;
            try
            {
                new frmReporteLocal(dtslist, reportpath, paramlist, enuFormatoReporte.Pdf, cRuta, cNroCuenta);
                dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(2, 1, Convert.ToInt32(conBusCtaAho.idcuenta), idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 1, "OK");
            }
            catch (Exception ex)
            {
                dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(2, 1, Convert.ToInt32(conBusCtaAho.idcuenta), idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 0, ex.ToString());
            }

            /* ---- Envio --- */
            List<string> cDestinoCorreo = new List<string>();            
            cDestinoCorreo.Add(cCorreo); //Cambiar correo para pruebas

            List<string> cAdjunto = new List<string>();            

            if (File.Exists(cDireccion))
            {
                cAdjunto.Add(cDireccion);
            }
            else
            {
                MessageBox.Show("No se encuentra el extracto de cuenta generado", "Validación de extracto de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }        

            string cAsunto = "Extracto de Cuenta (CRAC LOS ANDES)";
            string cMensaje = this.cHtmlPlantilla;
            cMensaje = cMensaje.Replace("$varCliente", cNombresCliente);                       
            
            dtExtCtasGenEnv = null;
            clsCNServicioCorreo objServicioCorreo = new clsCNServicioCorreo();

            try
            {
                if (objServicioCorreo.enviarMensaje(cDestinoCorreo, cAsunto, cMensaje, cAdjunto))
                {
                    dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(2, 2, Convert.ToInt32(conBusCtaAho.idcuenta), idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 1, "OK");
                }
                else
                {
                    dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(2, 2, Convert.ToInt32(conBusCtaAho.idcuenta), idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 0, "ERROR");
                }
            }
            catch (Exception ex)
            {
                dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(2, 2, Convert.ToInt32(conBusCtaAho.idcuenta), idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 0, ex.ToString());
                MessageBox.Show("Error al enviar extracto de cuenta (" + ex.ToString() + ")", "Validación de extracto de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Se generó y envió correctamente el extracto de cuenta", "Validación de extracto de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void btnImprimir1_Click(object sender, System.EventArgs e)
        {
            //VALIDACIONES
            if (Convert.ToDateTime(dtFecFin.Value.ToShortDateString()) < Convert.ToDateTime(dtFecInicio.Value.ToShortDateString()))
            {
                MessageBox.Show("Periodo Incorrecto: La fecha de Inicio es posterior a la Final", "Validación de extracto de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(conBusCtaAho.txtNroCta.Text))
            {
                MessageBox.Show("Debe Seleccionar primero la Cuenta y/o Cliente", "Validación de extracto de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(conBusCtaAho.txtNombre.Text))
            {
                MessageBox.Show("No Existe cliente para la búsqueda", "Validación de extracto de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Convert.ToInt32(conBusCtaAho.txtNroCta.Text.Trim()) == 0)
            {
                MessageBox.Show("El valor de búsqueda no puede ser igual a cero(0)", "Validación de extracto de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DateTime dFecInicio = dtFecInicio.Value;
            DateTime dFecFin = dtFecFin.Value;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            DataTable dtDatosCta = new clsRPTCNDeposito().CNDatosExtractoCta(Convert.ToInt32(conBusCtaAho.idcuenta));
            
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("x_dFechaINI", dFecInicio.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_dFechaFIN", dFecFin.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
            paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("idCuenta", conBusCtaAho.idcuenta.ToString(), false));
            paramlist.Add(new ReportParameter("dFecProc", clsVarGlobal.dFecSystem.ToShortDateString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            frmReporteLocal rptExtracto;

            bool lPreVisualizar = false;
            string cPerfiles = clsVarApl.dicVarGen["idPerfilVisualizaExtractoCuenta"];
            string[] idPerfil = cPerfiles.Split(',');
            int index = Array.IndexOf(idPerfil, clsVarGlobal.PerfilUsu.idPerfil.ToString());
            if(index != -1){
                lPreVisualizar = true;
            }

            string cPrinterName = "";
            PrintDialog printDialog = new PrintDialog();
            if (!lPreVisualizar)
            {
                if (printDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                if (rbtFDetallado.Checked)
                {
                    printDialog.PrinterSettings.DefaultPageSettings.Landscape = true;
                    printDialog.PrinterSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1169);
                }
                cPrinterName = " a impresora " + printDialog.PrinterSettings.PrinterName;
            }

            if (rbtFDetallado.Checked)
            {
                DataTable dtExtractoDetalle = new clsRPTCNDeposito().CNExtractoCta(Convert.ToInt32(conBusCtaAho.idcuenta), dFecInicio, dFecFin);
                if (dtExtractoDetalle.Rows.Count == 0)
                {
                    MessageBox.Show("No existen datos para el reporte", "Validación de extracto de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataTable dtResImpExtCta = new clsRPTCNDeposito().CNRegistroImpresionesExtCta(Convert.ToInt32(conBusCtaAho.idcuenta), clsVarGlobal.dFecSystem, clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.nIdAgencia);
                if (Convert.ToInt32(dtResImpExtCta.Rows[0]["nResp"]) == 1)
                {
                    txtNroImpresion.Text = (Convert.ToInt32(txtNroImpresion.Text) + 1).ToString();
                }

                
                //=================  Registro Inicio Rastreo ===================================
                this.registrarRastreo(Convert.ToInt32(this.conBusCtaAho.txtCodCli.Text), Convert.ToInt32(conBusCtaAho.idcuenta), "Impresión de Extracto de Cuenta - Detallado del " + dFecInicio.ToString("yyyy/MM/dd") + " al " + dFecFin.ToString("yyyy/MM/dd") + cPrinterName, btnImprimir);
                //==============================================================================

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsDatosGenCta", dtDatosCta));
                dtslist.Add(new ReportDataSource("dsExtractoCta", dtExtractoDetalle));

                string reportpath = "rptExtractoCtaDetallado.rdlc";

                if(lPreVisualizar){
                    rptExtracto = new frmReporteLocal(dtslist, reportpath, paramlist);
                }else{
                    rptExtracto = new frmReporteLocal(dtslist, reportpath, paramlist, true, true);
                    rptExtracto.printDoc.PrinterSettings = printDialog.PrinterSettings;
                }
                
                rptExtracto.ShowDialog();
            }
            else if (rbtFResumen.Checked)
            {
                DataTable dtExtracto = new clsRPTCNDeposito().CNExtractoCta(Convert.ToInt32(conBusCtaAho.idcuenta), dFecInicio, dFecFin);
                if (dtExtracto.Rows.Count == 0)
                {
                    MessageBox.Show("No existen datos para el reporte", "Validación de extracto de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataTable dtResImpExtCta = new clsRPTCNDeposito().CNRegistroImpresionesExtCta(Convert.ToInt32(conBusCtaAho.idcuenta), clsVarGlobal.dFecSystem, clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.nIdAgencia);
                if (Convert.ToInt32(dtResImpExtCta.Rows[0]["nResp"]) == 1)
                {
                    txtNroImpresion.Text = (Convert.ToInt32(txtNroImpresion.Text) + 1).ToString();
                }

                //=================  Registro Inicio Rastreo ===================================
                this.registrarRastreo(Convert.ToInt32(this.conBusCtaAho.txtCodCli.Text), Convert.ToInt32(conBusCtaAho.idcuenta), "Impresión de Extracto de Cuenta - Resumen del " + dFecInicio.ToString("yyyy/MM/dd") + " al " + dFecFin.ToString("yyyy/MM/dd") + " a impresora " + cPrinterName, btnImprimir);
                //==============================================================================

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsDatosGenCta", dtDatosCta));
                dtslist.Add(new ReportDataSource("dsExtractoCta", dtExtracto));

                string reportpath = "rptExtractoCtaSimple.rdlc";

                if(lPreVisualizar){
                    rptExtracto = new frmReporteLocal(dtslist, reportpath, paramlist);
                }else{
                    rptExtracto = new frmReporteLocal(dtslist, reportpath, paramlist, true);;
                    rptExtracto.printDoc.PrinterSettings = printDialog.PrinterSettings;
                }
                rptExtracto.ShowDialog();
            }
            else if (rbtFCorreo.Checked)
            {                
                int idUsuario = clsVarGlobal.User.idUsuario;
                string cPathRoot = clsVarGlobal.cRutPathApp;
                string cPathAnioMes = this.dtFecFin.Value.ToString("yyyyMMdd");
                string cNroCuenta = conBusCtaAho.txtCodIns.Text + conBusCtaAho.txtCodAge.Text + conBusCtaAho.txtCodMod.Text + conBusCtaAho.txtCodMon.Text + conBusCtaAho.txtNroCta.Text;
                string cRuta = Path.Combine(cPathRoot, cPathAnioMes);
                string cDireccion = Path.Combine(cRuta, cNroCuenta + "." + enuFormatoReporte.Pdf);

                DataTable dtExtracto = new clsRPTCNDeposito().CNRptMovimientosExtCtaCorreo(Convert.ToInt32(conBusCtaAho.idcuenta), dFecInicio, dFecFin);
                if (dtExtracto.Rows.Count == 0)
                {
                    MessageBox.Show("No existen datos para el reporte", "Validación de extracto de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataTable dtResImpExtCta = new clsRPTCNDeposito().CNRegistroImpresionesExtCta(Convert.ToInt32(conBusCtaAho.idcuenta), clsVarGlobal.dFecSystem, clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.nIdAgencia);
                if (Convert.ToInt32(dtResImpExtCta.Rows[0]["nResp"]) == 1)
                {
                    txtNroImpresion.Text = (Convert.ToInt32(txtNroImpresion.Text) + 1).ToString();
                }

                //=================  Registro Inicio Rastreo ===================================
                this.registrarRastreo(Convert.ToInt32(this.conBusCtaAho.txtCodCli.Text), Convert.ToInt32(conBusCtaAho.idcuenta), "Impresión de Extracto de Cuenta - Correo del " + dFecInicio.ToString("yyyy/MM/dd") + " al " + dFecFin.ToString("yyyy/MM/dd"), btnImprimir);
                //==============================================================================

                paramlist.Add(new ReportParameter("x_cMensaje", this.cNota, false));                

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsGenExtracCta", dtDatosCta));
                dtslist.Add(new ReportDataSource("dsExtractoCuenta", dtExtracto));

                string reportpath = "rptExtCtaCorreo.rdlc";

                DataTable dtExtCtasGenEnv = null;
                try
                {
                    if (lPreVisualizar)
                    {
                        rptExtracto = new frmReporteLocal(dtslist, reportpath, paramlist);
                    }
                    else
                    {
                        rptExtracto = new frmReporteLocal(dtslist, reportpath, paramlist, true) ;
                        rptExtracto.printDoc.PrinterSettings = printDialog.PrinterSettings;
                    }
                    rptExtracto.ShowDialog();

                    dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(2, 1, Convert.ToInt32(conBusCtaAho.idcuenta), idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 1, "OK");
                }
                catch (Exception ex)
                {
                    dtExtCtasGenEnv = clsEnvExtCtas.CNInsExtCtasGenEnv(2, 1, Convert.ToInt32(conBusCtaAho.idcuenta), idUsuario, cDireccion, Convert.ToInt32(cPathAnioMes), 0, ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Seleccione un Formato de Extracto de Cuenta antes de continuar", "Validación de extracto de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiar();            
            rbtFResumen.Checked = false;
            rbtFDetallado.Checked = false;
            rbtFCorreo.Checked = false;
            rbtFCorreo.Enabled = true;
            btnEnviar.Enabled = false;
            btnImprimir.Enabled = false;
            conBusCtaAho.LimpiarControles();
            conBusCtaAho.idcuenta = 0;
            conBusCtaAho.HabDeshabilitarCtrl(true);
            conBusCtaAho.btnBusCliente.Enabled = true;
            conBusCtaAho.txtCodAge.Enabled = true;
            txtNroImpresion.Text = "0";
        }

        private void limpiar()
        {
            conBusCtaAho.LimpiarControles();
            dtFecInicio.Value = clsVarGlobal.dFecSystem;
            dtFecFin.Value = clsVarGlobal.dFecSystem;

        }

        private void conBusCtaAho_ClicBusCta(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(conBusCtaAho.txtCodCli.Text))
            {
                conBusCtaAho.HabDeshabilitarCtrl(false);
                conBusCtaAho.btnBusCliente.Enabled = false;
                btnImprimir.Enabled = true;
                DataTable dtNroImprExtCta = new clsRPTCNDeposito().CNObtieneNroImpExtractoCta(Convert.ToInt32(conBusCtaAho.idcuenta));
                txtNroImpresion.Text = dtNroImprExtCta.Rows[0]["nNroImpresionExtCta"].ToString();

                DataTable dtCorreoExtCta = new clsRPTCNDeposito().CNObtieneDirecCorreoExtractoCta(Convert.ToInt32(conBusCtaAho.idcuenta));
                if (!string.IsNullOrEmpty(Convert.ToString(dtCorreoExtCta.Rows[0]["idTipoEnvioEstCta"])) && Convert.ToInt32(dtCorreoExtCta.Rows[0]["idTipoEnvioEstCta"]) == 2)
                {
                    this.rbtFCorreo.Enabled = true;
                    this.btnEnviar.Enabled = true;                    
                }
                else
                {
                    this.rbtFCorreo.Enabled = false;
                    this.btnEnviar.Enabled = false;                    
                }
            }
            else
            {
                btnImprimir.Enabled = false;
            }
            if (!string.IsNullOrEmpty(conBusCtaAho.txtNroCta.Text) && Convert.ToInt32(conBusCtaAho.idcuenta) > 0)
            {
                RevisionDocumentosCTSPendientes();
            }
        }

        //--================================================================
        //--Revisión de documentos pendientes CTS
        //--================================================================
        private void RevisionDocumentosCTSPendientes()
        {
            int idCuenta = this.conBusCtaAho.idcuenta;
            DataTable dtListaRegDocCTS = new clsCNRegDocumentoCTS().CNListarRegDocumentosCTSByCuenta(idCuenta);

            if (dtListaRegDocCTS.Rows.Count != 0)
            {
                string cMsg = "La cuenta tiene los siguientes documentos por regularizar: \n\n";
                bool bMsg = false;

                foreach (DataRow item in dtListaRegDocCTS.Rows)
                {
                    if (Convert.ToBoolean(item["bEnviado"]) == false)
                    {
                        cMsg += "\t- " + item["cDenominacion"] + " [No enviado]\n";
                        bMsg = true;
                    }

                    if (Convert.ToBoolean(item["bFirmado"]) == false)
                    {
                        cMsg += "\t- " + item["cDenominacion"] + " [No firmado]\n";
                        bMsg = true;
                    }
                }

                if (bMsg)
                {
                    MessageBox.Show(cMsg, "Revisión de documentos pendientes CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void rbtBase_CheckedChanged(object sender, EventArgs e)
        {
            rbtBase rbtSelected = sender as rbtBase;
            if (!string.IsNullOrEmpty(conBusCtaAho.txtNroCta.Text) && rbtSelected.Name == rbtFCorreo.Name)
            {
                this.btnEnviar.Enabled = true;
            }
            else
            {
                this.btnEnviar.Enabled = false;
            }
        }

        private void conBusCtaAho_ChangeDocumentoID(object sender, EventArgs e)
        {
            if (this.conBusCtaAho.txtNroDoc.Text.Length < 6)
            {
                return;
            }

            int idRes = Convert.ToInt32(clsVarApl.dicVarGen["lAlertaOfertaCredito"]);
            bool lAlerta = Convert.ToBoolean(idRes);
            if (lAlerta)
            {
                frmAlertaOfertaCredito objAlertaOferta = new frmAlertaOfertaCredito(this.conBusCtaAho.txtNroDoc.Text);
            }
        }        
    }
}
