using DEP.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.Funciones;



namespace DEP.Presentacion
{
    public partial class frmSolicitudCartaCTSTransferencias : frmBase
    {
        clsCNSolicCTS solicitud = new clsCNSolicCTS();
        clsFunUtiles FunTruncar = new clsFunUtiles();

        DataTable dtDatosCuenta;
        DataTable tbDatosSolicitud;

        int idSolCTS = 0;
        
        public frmSolicitudCartaCTSTransferencias()
        {
            InitializeComponent();
        }

        private void inicializarComboTipoComprobanteCTS()
        {
            clsCNSolicCTS solicitud = new clsCNSolicCTS();
            DataTable dtListaTipComprobantePagoCTS = solicitud.CNListarTipComprobantePagoCTS();

            if (dtListaTipComprobantePagoCTS.Rows.Count > 0)
            {
                cboTipoComp.ValueMember = "idTipoComPagoCTS";
                cboTipoComp.DisplayMember = "cDescripcion";
                cboTipoComp.DataSource = dtListaTipComprobantePagoCTS;
            }

            cboTipoComp.SelectedIndex = -1;
        }

        private void frmCartaCTSTransferencias_Load(object sender, EventArgs e)
        {
            conBusCtaAho.idEstCuenta = 2; //Cuentas Canceladas
            conBusCtaAho.nTipOpe = 21; //Cuentas CTS            
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];            

            inicializarComboTipoComprobanteCTS();
            dtFechaOp.Value = clsVarGlobal.dFecSystem;

            LimpiarDatosCartaCTS();
            btnEnviar.Enabled = false;
            btnImprimir.Enabled = false;
        }

        private void conBusCtaAho_ClicBusCta(object sender, EventArgs e)
        {
            LimpiarDatosCartaCTS();
            
            if (conBusCtaAho.idcuenta == 0)
            {
                return;
            }

            //Buscar datos de la cuenta
            if (!BuscarDatCuenta())
            {
                return;
            } 

            //Buscar datos de la solicitud
            BuscarDatosCartaCTS();
        }

        private bool BuscarDatCuenta()
        {
            dtDatosCuenta = solicitud.CNDatosCuentaCTSCancelado(conBusCtaAho.idcuenta);

            if (dtDatosCuenta.Rows.Count > 0)
            {
                if (dtDatosCuenta.Rows[0]["idTipoComPagoCTS"].ToString() == "")
                {
                    MessageBox.Show("Tipo de Cancelación no valida para Transferencia de CTS. Verificar", "Validar datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false; 
                }
                else
                {
                    cboMonOrigen.SelectedValue = Convert.ToInt32(dtDatosCuenta.Rows[0]["idMoneda"].ToString());
                    cboTipoEntidadOri.SelectedValue = clsVarApl.dicVarGen["idTipoInstFin"];
                    cboEntidadOri.SelectedValue = clsVarApl.dicVarGen["idInstFin"];
                    cboMonDestino.SelectedValue = Convert.ToInt32(dtDatosCuenta.Rows[0]["idMoneda"].ToString());
                    txtMonto.Text = dtDatosCuenta.Rows[0]["nMontoCancelacion"].ToString();

                    txtcCodEmpleador.Text = dtDatosCuenta.Rows[0]["cCodCliente"].ToString();
                    txtcEmpleador.Text = dtDatosCuenta.Rows[0]["cNombre"].ToString();
                    txtcRUCEmpleador.Text = dtDatosCuenta.Rows[0]["cDocumentoID"].ToString();
                }
            }
            else
            {
                MessageBox.Show("No se encontró información de la cuenta. Verificar", "Validar datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void BuscarDatosCartaCTS()
        {
            //Validaciones
            if (conBusCtaAho.txtCodCli.Text.Trim() == "")
            {
                conBusCtaAho.btnBusCliente.Focus();
                return;
            }

            clsCNSolicCTS BuscarDatosSol = new clsCNSolicCTS();
            tbDatosSolicitud = BuscarDatosSol.DatosSolici(Convert.ToInt32(conBusCtaAho.txtCodCli.Text.Trim()),2);

            if (tbDatosSolicitud.Rows.Count == 0)
            {
                idSolCTS = 0;

                lblEstado.Text = "SIN SOLICITUD";
                lblUsuarioSol.Visible = false;
                lblFecha.Visible = false;

                HabilitarControles(true);
                HabilitarDatosCartaCTS(false);

                btnEditarDet.Enabled = false;
                btnCancelarDet.Enabled = false;
                btnGrabarDet.Enabled = false;

                btnEnviar.Enabled = true;
                btnImprimir.Enabled = false;
            }
            else
            {
                lblEstado.Visible = true;
                lblUsuarioSol.Visible = true;
                lblFecha.Visible = true;

                HabilitarControles(false);
                HabilitarDatosCartaCTS(false);
                conBusCtaAho.HabDeshabilitarCtrl(false);
                conBusCtaAho.btnBusCliente.Enabled = false;

                btnEnviar.Enabled = false;
                btnImprimir.Enabled = false;

                lblEstado.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cEstadoSol"]);
                lblFecha.Text = Convert.ToString(Convert.ToDateTime(tbDatosSolicitud.Rows[0]["dFechaSolic"]).ToShortDateString());
                lblUsuarioSol.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["UsuSolicitud"]);

                cboMonDestino.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idMonedaDest"]);
                cboTipoEntidadDes.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["TipoEntidadDes"]);
                cboEntidadDes.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idEntidadDes"]);

                DatosCartaCTS();

                if (Convert.ToInt32(tbDatosSolicitud.Rows[0]["idEstSol"]) == 4) // RECHAZADO
                {
                    chcNuevaSolicitud.Visible = true;
                }
                else
                {
                    chcNuevaSolicitud.Visible = false;
                }
            }
        }

        private void DatosCartaCTS()
        {
            clsCNSolicCTS BuscarDatosSol = new clsCNSolicCTS();

            idSolCTS = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idSolCTS"]);
            DataTable dtDatosSolCarta = BuscarDatosSol.CNDatosSoliciCTSCarta(idSolCTS);

            btnEditarDet.Enabled = false;
            btnCancelarDet.Enabled = false;
            btnGrabarDet.Enabled = false;

            btnImprimir.Enabled = false;

            if (Convert.ToInt32(tbDatosSolicitud.Rows[0]["idEstSol"]) == 2 || // APROBADO
                Convert.ToInt32(tbDatosSolicitud.Rows[0]["idEstSol"]) == 3) // EJECUTADO
            {
                if (Convert.ToInt32(tbDatosSolicitud.Rows[0]["idEstSol"]) == 2) // APROBADO
                {
                    btnEditarDet.Enabled = true;
                }

                if (dtDatosSolCarta.Rows.Count > 0)
                {
                    txtViaEntidad.Text = Convert.ToString(dtDatosSolCarta.Rows[0]["cViaEntidad"]);
                    cboTipoComp.SelectedValue = Convert.ToInt32(dtDatosSolCarta.Rows[0]["idTipoComPagoCTS"]);
                    dtFechaOp.Value = Convert.ToDateTime(dtDatosSolCarta.Rows[0]["dFechaOpe"]);
                    txtNroOpOCheque.Text = Convert.ToString(dtDatosSolCarta.Rows[0]["cNroOpeOCheque"]);
                    txtNroCta.Text = Convert.ToString(dtDatosSolCarta.Rows[0]["cNroCta"]);
                    txtImporte.Text = Convert.ToDecimal(dtDatosSolCarta.Rows[0]["nImporte"]).ToString("##,##0.00");

                    btnImprimir.Enabled = true;
                }
                else
                {
                    txtViaEntidad.Text = Convert.ToString(dtDatosCuenta.Rows[0]["cViaEntidad"]);
                    cboTipoComp.SelectedValue = Convert.ToInt32(dtDatosCuenta.Rows[0]["idTipoComPagoCTS"]);
                    dtFechaOp.Value = Convert.ToDateTime(dtDatosCuenta.Rows[0]["dFechaOpe"]);
                    txtNroOpOCheque.Text = Convert.ToString(dtDatosCuenta.Rows[0]["cNroOpeOCheque"]);
                    txtNroCta.Text = Convert.ToString(dtDatosCuenta.Rows[0]["cNroCta"]);
                    txtImporte.Text = Convert.ToDecimal(dtDatosCuenta.Rows[0]["nImporte"]).ToString("##,##0.00");
                }
            }
        }

        private void cboTipoEntidadOri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoEntidadOri.SelectedIndex != -1)
            {
                cboEntidadOri.CargarEntidades((int)cboTipoEntidadOri.SelectedValue);
            }
        }

        private void cboTipoEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoEntidadDes.SelectedIndex != -1)
            {
                cboEntidadDes.CargarEntidades((int)cboTipoEntidadDes.SelectedValue);
            }
        }

        private void chcNuevaSolicitud_CheckedChanged(object sender, EventArgs e)
        {
            if (chcNuevaSolicitud.Checked == true && chcNuevaSolicitud.Visible == true)
            {
                LimpiarDatosCartaCTS();
                lblEstado.Text = "NUEVA SOLICITUD";
                lblUsuarioSol.Visible = false;
                lblUsuario.Visible = false;
                lblFecha.Visible = false;
                lblFecSol.Visible = false;
                HabilitarControles(true);
                btnImprimir.Enabled = false;
                btnEnviar.Enabled = true;
            }
            else if (chcNuevaSolicitud.Checked == false && chcNuevaSolicitud.Visible == true)
            {
                HabilitarControles(false);
                lblUsuarioSol.Visible = true;
                lblUsuario.Visible = true;
                lblFecha.Visible = true;
                lblFecSol.Visible = true;
                lblEstado.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cEstadoSol"]);
                lblUsuarioSol.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["UsuSolicitud"]);
                lblFecha.Text = Convert.ToString(Convert.ToDateTime(tbDatosSolicitud.Rows[0]["dFechaSolic"]).ToShortDateString());

                btnEnviar.Enabled = false;
                btnImprimir.Enabled = false;
            }
        }

        private void btnEditarDet_Click(object sender, EventArgs e)
        {
            HabilitarDatosCartaCTS(true);

            btnEditarDet.Enabled = false;
            btnCancelarDet.Enabled = true;
            btnGrabarDet.Enabled = true;
        }

        private void btnCancelarDet_Click(object sender, EventArgs e)
        {
            HabilitarDatosCartaCTS(false);

            btnEditarDet.Enabled = true;
            btnCancelarDet.Enabled = false;
            btnGrabarDet.Enabled = false;

            DatosCartaCTS();
        }

        private void btnGrabarDet_Click(object sender, EventArgs e)
        {
            btnEditarDet.Enabled = true;
            btnCancelarDet.Enabled = false;
            btnGrabarDet.Enabled = false;

            if (idSolCTS != 0)
            {
                clsCNSolicCTS objDatosSolCarta = new clsCNSolicCTS();
                objDatosSolCarta.CNRegSoliciCTSCarta(idSolCTS, Convert.ToDecimal(txtMonto.Text), txtViaEntidad.Text, Convert.ToInt32(cboTipoComp.SelectedValue), dtFechaOp.Value, txtNroOpOCheque.Text, txtNroCta.Text, Convert.ToDecimal(txtImporte.Text), clsVarGlobal.User.idUsuario);
            }

            HabilitarDatosCartaCTS(false);
            DatosCartaCTS();
        }    

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            conBusCtaAho.LimpiarControles();
            conBusCtaAho.txtCodCli.Focus();
                        
            chcNuevaSolicitud.Visible = false;
            chcNuevaSolicitud.Checked = false;
            btnEnviar.Enabled = false;
            btnImprimir.Enabled = false;

            LimpiarDatosCartaCTS();
            HabilitarControles(false);
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (conBusCtaAho.txtCodCli.Text.Trim() == "")
            {
                MessageBox.Show("Debe asignar un Cliente Válido", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToInt32(conBusCtaAho.txtCodCli.Text.Trim()) == clsVarGlobal.User.idCli)
            {
                MessageBox.Show("No se puede enviar una solicitud donde el involucrado sea Ud. mismo, ello lo deberá realizar otro Personal", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboMonDestino.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el Tipo de Moneda Destino", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboTipoEntidadDes.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el Tipo de Entidad Financiera", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboEntidadDes.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar la Entidad Financiera", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int idCuenta = conBusCtaAho.idcuenta;
            int idMonedaOri = Convert.ToInt32(cboMonOrigen.SelectedValue);
            int idMonedaDest = Convert.ToInt32(cboMonDestino.SelectedValue);
            int idAgencia = clsVarGlobal.nIdAgencia;
            int idCli = Convert.ToInt32(conBusCtaAho.txtCodCli.Text);
            int idEmpleador = 0; // Revisar
                        
            clsCNSolicCTS solicitud = new clsCNSolicCTS();
            solicitud.EnviarSolicitud(idCuenta, idCli, Convert.ToInt32(cboTipoEntidadDes.SelectedValue),
                                    Convert.ToInt32(cboEntidadDes.SelectedValue), idMonedaOri, idAgencia, 0,
                                    idMonedaDest, idEmpleador,
                                    clsVarGlobal.User.idUsuario, Convert.ToDateTime(clsVarGlobal.dFecSystem), 2);
            
            MessageBox.Show("Su solicitud fue enviada correctamente", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (chcNuevaSolicitud.Checked == true && chcNuevaSolicitud.Visible == true)
            {
                solicitud.AnularSol(Convert.ToInt32(tbDatosSolicitud.Rows[0]["idSolCTS"]));
            }
            BuscarDatosCartaCTS();
            btnEnviar.Enabled = false;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //Procedimiento para imprimir una Carta
            clsCNSolicCTS solicitud = new clsCNSolicCTS();
            DataTable dtRptSolicTraslCartaCTS = solicitud.CNRptSolicTraslCartaCTS(idSolCTS, clsVarGlobal.nIdAgencia);

            if (dtRptSolicTraslCartaCTS.Rows.Count > 0)
            {
                if (Convert.ToInt32(tbDatosSolicitud.Rows[0]["idEstSol"]) == 2) // Aprobado
                {
                    if (MessageBox.Show(this, "Una vez emitido la carta, no podra modificar ninguno de sus datos, ¿desea continuar?", "INFORMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    {
                        return;
                    }
                }
                   
                string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
                string cDia = clsVarGlobal.dFecSystem.Day.ToString();
                string cMes = clsVarGlobal.dFecSystem.ToString("MMMM");
                string cAño = clsVarGlobal.dFecSystem.Year.ToString();

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_cDia", cDia, false));
                paramlist.Add(new ReportParameter("x_cMes", cMes, false));
                paramlist.Add(new ReportParameter("x_cAnio", cAño, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString(), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsRptSolicTraslCartaCTS", dtRptSolicTraslCartaCTS));

                string reportpath = "rptCartaTrasferenciaCTS.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

                BuscarDatosCartaCTS();
            }
            else
            {
                MessageBox.Show("No se encontraron datos para el reporte", "Solicitud de Traslado de CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void HabilitarControles(Boolean var)
        {
            conBusCtaAho.HabDeshabilitarCtrl(!var);
            conBusCtaAho.btnBusCliente.Enabled = !var;
            cboMonDestino.Enabled = false;
            cboTipoEntidadDes.Enabled = var;
            cboEntidadDes.Enabled = var;            
        }

        private void HabilitarDatosCartaCTS(Boolean lHabilitar)
        {
            txtViaEntidad.Enabled = lHabilitar;
            cboTipoComp.Enabled = false;
            dtFechaOp.Enabled = lHabilitar;
            txtNroOpOCheque.Enabled = lHabilitar;
            txtNroCta.Enabled = lHabilitar;
            txtImporte.Enabled = false;

            if (cboTipoComp.SelectedIndex != -1)
            {
                if((int)cboTipoComp.SelectedValue != 2 && lHabilitar)
                {
                    txtViaEntidad.Enabled = false;
                    dtFechaOp.Enabled = false;
                    txtNroCta.Enabled = false;
                }
            }
        }

        private void LimpiarDatosCartaCTS()
        {
            lblEstado.Text = "";
            lblFecha.Text = "";
            lblUsuarioSol.Text = "";

            cboMonOrigen.SelectedIndex = -1;
            cboTipoEntidadOri.SelectedIndex = -1;
            cboEntidadOri.SelectedIndex = -1;
            txtMonto.Text = "";

            cboMonDestino.SelectedIndex = -1;
            cboTipoEntidadDes.SelectedIndex = -1;
            cboEntidadDes.SelectedIndex = -1;

            LimpiarDatosCartaCts();
        }

        private void LimpiarDatosCartaCts()
        {
            txtViaEntidad.Text = "";
            cboTipoComp.SelectedIndex = -1;
            dtFechaOp.Value = clsVarGlobal.dFecSystem;
            txtNroOpOCheque.Text = "";
            txtNroCta.Text = "";
            txtImporte.Text = "";        
        }

        
    }
}
