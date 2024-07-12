using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.Funciones;
using CRE.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;

namespace CRE.Presentacion
{
    public partial class FrmCancelConSaldo : frmBase
    {
        #region Variables

        private const int idTipoOperacion = 7;
        clsCNCredito Credito = new clsCNCredito();
        public string cTipoBusqueda, nEstadoCredito;
        public DataTable tbDatosCuenta, tbDatosSolicitud;
        bool lCancela = false;
        clsCNGarantia cngarantia = new clsCNGarantia();
        clsCNCondonacion cnCondonacion = new clsCNCondonacion();
        frmReporteLocal rptCondonacionEjec;

        int idSolicitudAproba = 0;

        #endregion

        #region Eventos

        private void FrmCancelConSaldo_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);

            cTipoBusqueda = "C";
            nEstadoCredito = "[5]";

            this.conBusCuentaCli.cTipoBusqueda = cTipoBusqueda;
            this.conBusCuentaCli.cEstado = nEstadoCredito;

            this.conBusCuentaCli.MyClic += new EventHandler(conBusCuentaCli1_MyClic);
            this.conBusCuentaCli.MyKey += new KeyPressEventHandler(conBusCuentaCli1_MyKey);

            cboMot.CargarMotivos(2);
            cboMotivoOperacion.ListarMotivoOperacion(idTipoOperacion, clsVarGlobal.PerfilUsu.idPerfil);
            cboMotivoOperacion.SelectedIndex = -1;
        }

        private void conBusCuentaCli1_MyKey(object sender, KeyPressEventArgs e)
        {
            LoadData();
        }

        private void conBusCuentaCli1_MyClic(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FrmCancelConSaldo_FormClosed(object sender, FormClosedEventArgs e)
        {
            LiberarCuenta();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            this.registrarRastreo(Convert.ToInt32(conBusCuentaCli.nIdCliente), Convert.ToInt32(conBusCuentaCli.nIdCuenta), "Inicio - Condonación de Deuda", btnGrabar);

            if (conBusCuentaCli.nValBusqueda == 0)
            {
                MessageBox.Show("Debe asignar una cuenta valida", "Condonación de Deuda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboMot.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un motivo", "Condonación de Deuda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Convert.ToDecimal (txtTotal.Text) < 0.0m)
            {
                MessageBox.Show("El Monto a Pagar debe ser mayor a 0", "Condonación de Deuda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToInt32(tbDatosSolicitud.Rows[0]["idEstadoSol"]) != 3)
            {
                MessageBox.Show("Para Proceder a la Condonación de la Cuenta, la Solicitud debe estar en ESTADO: APROBADO", "Condonación de Deuda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }

            if (cboMotivoOperacion.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccion el motivo de la operación.", "Condonación de Deuda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (lCancela)
            {
                DataTable dtResultado = new clsCNCredito().CancConDeuda(conBusCuentaCli.nValBusqueda, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem.ToString(),
                                   Convert.ToInt32(cboMot.SelectedValue), clsVarGlobal.User.idUsuario, txtMot.Text,
                                   Convert.ToDecimal(txtTotal.Text), Convert.ToInt32(tbDatosCuenta.Rows[0]["idProducto"]),
                                   Convert.ToInt32(cboMotivoOperacion.SelectedValue)
                                   , idSolicitudAproba);
                MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Condonación de Deuda", MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));                

                var dtGarantia = cngarantia.CNValidaCuentaGarantia(conBusCuentaCli.nValBusqueda);
                if (dtGarantia.Rows.Count > 0)
                {
                    MessageBox.Show("El crédito se canceló, cliente debe de realizar el trámite \n para liberar su garantía, coordinar con su asesor", "Validar garantía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                DataTable dtResultado2 = new clsCNCredito().CNPerdonaDeuda(conBusCuentaCli.nValBusqueda, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem.ToString(),
                                   Convert.ToInt32(cboMot.SelectedValue), clsVarGlobal.User.idUsuario, txtMot.Text,
                                   Convert.ToDecimal(txtCap.Text), Convert.ToDecimal(txtInt.Text), Convert.ToDecimal(txtIntComp.Text),
                                   Convert.ToDecimal(txtOtro.Text), Convert.ToDecimal(txtMora.Text), Convert.ToInt32(cboMotivoOperacion.SelectedValue)
                                   , this.idSolicitudAproba);

                MessageBox.Show(dtResultado2.Rows[0]["cMensaje"].ToString(), "Condonación de Deuda", MessageBoxButtons.OK, ((int)dtResultado2.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));                
            }            
            LiberarCuenta();
            imprimirNotaAbono();            
            while (MessageBox.Show("¿Desea reimprimir el reporte?", "Condonación de Deuda",
                                                                        MessageBoxButtons.YesNo,
                                                                        MessageBoxIcon.Question) == DialogResult.Yes)
            {
                imprimirNotaAbono();
            }

            CleanData();
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
            this.cboMotivoOperacion.Enabled = false;
            this.registrarRastreo(Convert.ToInt32(conBusCuentaCli.nIdCliente), Convert.ToInt32(conBusCuentaCli.nIdCuenta), "Fin - Condonación de Deuda", btnGrabar);
            
        }

        private void btnSolAprobadas_Click(object sender, EventArgs e)
        {
            frmListSolCancAprob frmLiSolApr = new frmListSolCancAprob();
            frmLiSolApr.ShowDialog();
            if (frmLiSolApr.NroCuenta != 0)
            {
                this.conBusCuentaCli.nValBusqueda = frmLiSolApr.NroCuenta;

                this.conBusCuentaCli.txtCodIns.Text = frmLiSolApr.cNroCuenta.Substring(0, 3);
                this.conBusCuentaCli.txtCodAge.Text = frmLiSolApr.cNroCuenta.Substring(3, 3);
                this.conBusCuentaCli.txtCodMod.Text = frmLiSolApr.cNroCuenta.Substring(6, 2);
                this.conBusCuentaCli.txtCodMon.Text = frmLiSolApr.cNroCuenta.Substring(8, 1);
                this.conBusCuentaCli.txtNroBusqueda.Text = frmLiSolApr.cNroCuenta.Substring(9);

                this.conBusCuentaCli.txtCodCli.Text = frmLiSolApr.cCodCliente.ToString();
                this.conBusCuentaCli.txtNroDoc.Text = frmLiSolApr.cDocumentoDNI.ToString();
                this.conBusCuentaCli.txtNombreCli.Text = frmLiSolApr.cNomCliente.ToString();

                this.conBusCuentaCli.txtNroBusqueda.Enabled = false;
                this.conBusCuentaCli.btnBusCliente1.Enabled = false;
                LoadData();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LiberarCuenta();
            CleanData();
            this.cboMotivoOperacion.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
            this.idSolicitudAproba = 0;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            LiberarCuenta();
        }

        #endregion

        #region Métodos

        public FrmCancelConSaldo()
        {
            InitializeComponent();
        }

        public void LiberarCuenta()
        {
            this.conBusCuentaCli.LiberarCuenta();
            this.conBusCuentaCli.btnBusCliente1.Enabled = true;
            this.conBusCuentaCli.txtNroBusqueda.Enabled = true;
            this.conBusCuentaCli.txtNroBusqueda.Focus();
            this.conBusCuentaCli.nValBusqueda = 0;
        }

        private void LoadData()
        {

            tbDatosSolicitud = cnCondonacion.CNBuscaSolAprobaCondonacionAprobados(Convert.ToInt32(conBusCuentaCli.txtCodCli.Text.Substring(conBusCuentaCli.txtCodCli.Text.Length - 7, 7)), Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text));

            if (tbDatosSolicitud.Rows.Count > 0)
            {
                this.idSolicitudAproba = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idSolAproba"]);
                tbDatosCuenta = Credito.CNObtieneDetalleCondonacion(idSolicitudAproba);

                if (tbDatosCuenta.Rows.Count > 0)
                {

                    txtCap.Text = tbDatosCuenta.Rows[0]["NSALCAP"].ToString();
                    txtInt.Text = tbDatosCuenta.Rows[0]["NSALINT"].ToString();
                    txtIntComp.Text = tbDatosCuenta.Rows[0]["nSalIntComp"].ToString();
                    txtOtro.Text = tbDatosCuenta.Rows[0]["NSALOTR"].ToString();
                    txtMora.Text = tbDatosCuenta.Rows[0]["NSALMOR"].ToString();
                    txtTotal.Text = tbDatosCuenta.Rows[0]["NSALTOT"].ToString();

                    txtUruReg.Text = tbDatosSolicitud.Rows[0]["cNombre"].ToString();
                    txtAgenReg.Text = tbDatosSolicitud.Rows[0]["cNombreAge"].ToString();
                    dtFecSolicitud.Value = Convert.ToDateTime(tbDatosSolicitud.Rows[0]["dFecSolici"]);
                    lblEstSolicitud.Text = tbDatosSolicitud.Rows[0]["cEstadoSol"].ToString().ToUpper();
                    if (Convert.ToInt32(tbDatosSolicitud.Rows[0]["idEstadoSol"]) == 3)
                    {
                        lblFecAprob.Text = Convert.ToDateTime(tbDatosSolicitud.Rows[0]["dFecAprSol"]).ToShortDateString();
                    }
                    cboMot.SelectedValue = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idMotivo"]);
                    txtMot.Text = Convert.ToString(tbDatosSolicitud.Rows[0]["cSustento"]);

                    if (Convert.ToDecimal(tbDatosCuenta.Rows[0]["nDeuda"]) == Convert.ToDecimal(tbDatosCuenta.Rows[0]["NSALTOT"]))
                    {
                        lblMensaje.Text = "CRÉDITO SE CANCELARA";
                        lCancela = true;
                    }
                    else
                    {
                        lblMensaje.Text = "";
                        lCancela = false;
                    }

                    btnGrabar.Enabled = true;
                    btnCancelar.Enabled = true;
                    cboMotivoOperacion.Enabled = true;                             
                }
                if (tbDatosSolicitud.Rows.Count == 0)
                {
                    MessageBox.Show("No existe solicitud de Condonación para esta Cuenta y el Monto de Deuda actual", "Condonación de Deuda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    btnGrabar.Enabled = false;
                    btnCancelar.Enabled = false;                 
                    cboMotivoOperacion.Enabled = false;
                    if (!String.IsNullOrEmpty(this.conBusCuentaCli.txtCodCli.Text))
                    {
                        LiberarCuenta();
                    } 
                    CleanData();
                }
            }
            else
            {
                MessageBox.Show("No existe solicitud de condonación para esta cuenta", "Condonación de Deuda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.cboMotivoOperacion.Enabled = false;
                if (!String.IsNullOrEmpty(this.conBusCuentaCli.txtCodCli.Text))
                {
                    LiberarCuenta();
                }                
                CleanData();
            }
        }

        public void CleanData()
        {
            cboMot.SelectedIndex = -1;
            txtCap.Text = string.Empty;
            txtInt.Text = string.Empty;
            txtIntComp.Text = string.Empty;
            txtOtro.Text = string.Empty;
            txtMora.Text = string.Empty;
            txtTotal.Text = string.Empty;
            txtMot.Text = string.Empty;
            txtUruReg.Text = string.Empty;
            txtAgenReg.Text = string.Empty;
            lblEstSolicitud.Text = string.Empty;
            lblFecAprob.Text = string.Empty;
            dtFecSolicitud.Value = DateTime.Now;
            cboMotivoOperacion.SelectedIndex = -1;

            this.conBusCuentaCli.txtCodAge.Text = string.Empty;
            this.conBusCuentaCli.txtCodIns.Text = string.Empty;
            this.conBusCuentaCli.txtCodMod.Text = string.Empty;
            this.conBusCuentaCli.txtCodMon.Text = string.Empty;
            this.conBusCuentaCli.txtNroBusqueda.Text = string.Empty;

            this.conBusCuentaCli.txtCodCli.Text = string.Empty;
            this.conBusCuentaCli.txtNroDoc.Text = string.Empty;
            this.conBusCuentaCli.txtNombreCli.Text = string.Empty;
            conBusCuentaCli.nValBusqueda = 0;
        }
        private void imprimirNotaAbono()
        {
            int idCuenta = Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text);
            int idSolicitud = Convert.ToInt32(tbDatosSolicitud.Rows[0]["idSolAproba"]);
            DataTable dtDatosReporte = cnCondonacion.listaDatosRptNotaAbono(idCuenta, idSolicitud);
            String cLugarFecha = dtDatosReporte.Rows[0]["cLugar"].ToString() + ", " + clsVarGlobal.dFecSystem.ToString("dd 'de' MMMM 'de' yyyy");
            String cNombreCli = this.conBusCuentaCli.txtNombreCli.Text;
            String cDocumentoID = this.conBusCuentaCli.txtNroDoc.Text;
            String cNroCuenta = this.conBusCuentaCli.txtCodIns.Text + "-" + this.conBusCuentaCli.txtCodAge.Text + "-" + this.conBusCuentaCli.txtCodMod.Text + "-" + this.conBusCuentaCli.txtCodMon.Text + "-" + this.conBusCuentaCli.txtNroBusqueda.Text;
            String cUsuSolicitant = this.txtUruReg.Text;
            clsNumLetras numeroletras = new clsNumLetras();
            numeroletras.SeparadorDecimalSalida = "con ";
            numeroletras.MascaraSalidaDecimal = "/100 " + dtDatosReporte.Rows[0]["cMoneda"].ToString();
            String cMontoLetras = numeroletras.ToCustomCardinal(Convert.ToString(dtDatosReporte.Rows[0]["SaldoTotal"]));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cLugarFecha", cLugarFecha, false));
            paramlist.Add(new ReportParameter("cNombreCli", cNombreCli, false));
            paramlist.Add(new ReportParameter("cDocumentoID", cDocumentoID, false));
            paramlist.Add(new ReportParameter("idCuenta", idCuenta.ToString(), false));
            paramlist.Add(new ReportParameter("cNroCuenta", cNroCuenta, false));
            paramlist.Add(new ReportParameter("idSolicitud", idSolicitud.ToString(), false));
            paramlist.Add(new ReportParameter("cUsuSolicitant", cUsuSolicitant, false));
            paramlist.Add(new ReportParameter("cMontoLetras", cMontoLetras, false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("DSdeudaAnterior", dtDatosReporte));

            string reportpath = "rptNotaAbono.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
        #endregion

    }
}
