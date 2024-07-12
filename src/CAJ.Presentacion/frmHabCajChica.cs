using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmHabCajChica : frmBase
    {
        private int x_nTipOpe = 0;

        public frmHabCajChica()
        {
            InitializeComponent();
        }

        private void frmHabCajChica_Load(object sender, EventArgs e)
        {
            x_nTipOpe = 5;
            CargarCajChica(0);
            this.cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
            cboAgencias_SelectedIndexChanged(sender,e);
			this.dtpFecHab.Value = clsVarGlobal.dFecSystem;
        }

        private void CargarCajChica(int idAge)
        {
            clsCNCajaChica Lista = new clsCNCajaChica();
            DataTable tb = Lista.ListaCajaChica(idAge,clsVarGlobal.User.idUsuario,1);
            this.cboCajChica.DataSource = tb;
            this.cboCajChica.ValueMember = tb.Columns["idCajChica"].ToString();
            this.cboCajChica.DisplayMember = tb.Columns["cNomCajChi"].ToString();
        }

        private void DatosCajChica(int idCaj)
        {
            LimpiarControles();
            clsCNCajaChica Lista = new clsCNCajaChica();
            DataTable tb = Lista.DatosCajaChica(idCaj,1);
            if (tb.Rows.Count > 0)
            {
                this.txtNomResCaj.Text = tb.Rows[0]["cNombre"].ToString();
                this.txtIDResCaj.Text = tb.Rows[0]["idResCajChi"].ToString();
                this.cboMoneda.SelectedValue = tb.Rows[0]["idMoneda"];
                this.txtMonFonFij.Text = tb.Rows[0]["nMonMaxCaj"].ToString();
                this.txtSalAnt.Text = tb.Rows[0]["nSalAnt"].ToString();
                this.txtMonHab.Text = tb.Rows[0]["nTotHab"].ToString();
                this.txtNroCajChi.Text = tb.Rows[0]["nNroCajChi"].ToString();
                this.btnGrabar.Enabled = true;
                this.btnNuevo.Enabled = false;
                this.lblMensaje.Visible = false;
                this.txtSustento.Enabled = true;
                this.txtSustento.Focus();
            }
            else
            {
                this.btnGrabar.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.txtSustento.Enabled = false;
                this.lblMensaje.Visible = true;
            }
        }

        private void LimpiarControles()
        {
            this.txtNomResCaj.Clear();
            this.txtIDResCaj.Clear();
            this.cboMoneda.SelectedValue = 1;
            this.txtMonFonFij.Text = "0.00";
            this.txtSalAnt.Text = "0.00";
            this.txtMonHab.Text = "0.00";
            this.txtNroCajChi.Text = "0.00";
            this.txtNroRecibo.Clear();
            this.txtSustento.Clear();
			this.dtpFecHab.Value = clsVarGlobal.dFecSystem;
        }

        private void cboAgencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCajChica(Convert.ToInt32(this.cboAgencias.SelectedValue.ToString()));
        }

        private void cboCajChica_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cboCajChica.SelectedIndex.ToString()) >= 0)
            {
                DatosCajChica(Convert.ToInt32(this.cboCajChica.SelectedValue.ToString()));
            }
            else
            {
                LimpiarControles();
            }
        }

        private string ValidarDatos()
        {
            //=======================================================================
            //--Validar Datos de la Agencia
            //=======================================================================
            if (string.IsNullOrEmpty(this.cboAgencias.SelectedValue.ToString()))
            {
                MessageBox.Show("Debe Seleccionar La Agencia", "Habilitación de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgencias.Select();
                this.cboAgencias.Focus();
                return "ERROR";
            }

            if (this.cboAgencias.SelectedIndex < 0)
            {
                MessageBox.Show("Debe Seleccionar La Agencia", "Habilitación de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgencias.Select();
                this.cboAgencias.Focus();
                return "ERROR";
            }

            //=======================================================================
            //--Validar Datos del Responsable
            //=======================================================================
            if (string.IsNullOrEmpty(this.txtNomResCaj.Text.Trim()))
            {
                MessageBox.Show("No Existe Responsable de Caja Chica", "Habilitación de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNomResCaj.Select();
                this.txtNomResCaj.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(this.txtIDResCaj.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Responsable de Caja Chica", "Registro de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtIDResCaj.Select();
                this.txtIDResCaj.Focus();
                return "ERROR";
            }

           
            if (string.IsNullOrEmpty(this.cboMoneda.SelectedValue.ToString()))
            {
                MessageBox.Show("No existe Moneda para la Habilitación..REVISAR...", "Habilitación de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboMoneda.Select();
                this.cboMoneda.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(this.txtMonHab.Text.Trim()))
            {
                MessageBox.Show("El Monto de Habilitación no es Válido", "Habilitación de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtMonHab.Select();
                this.txtMonHab.Focus();
                return "ERROR";
            }

            if (Convert.ToDecimal (this.txtMonHab.Text) <= 0)
            {
                MessageBox.Show("El Monto de Habilitación no es Válido", "Habilitación de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtMonHab.Select();
                this.txtMonHab.Focus();
                return "ERROR";
            }
            if (string.IsNullOrEmpty(this.txtSustento.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Sustento de la Habilitación", "Habilitación de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtSustento.Select();
                this.txtSustento.Focus();
                return "ERROR";
            }

            //if (Convert.ToInt32(this.txtIDResCaj.Text.Trim()) != clsVarGlobal.User.idUsuario)
            //{
            //    MessageBox.Show("Usted no es Responsable de esta Caja Chica para la Habilitación", "Habilitación de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    this.txtIDResCaj.Select();
            //    this.txtIDResCaj.Focus();
            //    return "ERROR";
            //}
                     
            return "OK";
        }

        private bool ValidaSiInicioOperaciones()
        {
            clsCNControlOpe ValidaOpe = new clsCNControlOpe();
            string cEstCie = ValidaOpe.ValidaIniOpe(dtpFecHab.Value, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);
            // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada  
            switch (cEstCie) // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada  
            {
                case "F":
                    MessageBox.Show("El Usuario no puede Habilitar su Fondo Fijo, NO Inicio sus Operaciones", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                case "A":
                    break;
                case "C":
                    MessageBox.Show("El Usuario no puede Habilitar su Fondo Fijo, El Usuario ya Cerro sus Operaciones", "Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                default:
                    MessageBox.Show(cEstCie, "Error al Validar Estado de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
            }
            return true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidaSiInicioOperaciones())
            {
                return;
            }
            if (ValidarDatos() == "ERROR")
            {
                return;
            }

            //===============================================================================
            //--Asignar Datos a las Variables
            //===============================================================================
            int idAge = Convert.ToInt32(this.cboAgencias.SelectedValue.ToString());
            int idCaj = Convert.ToInt32(this.cboCajChica.SelectedValue.ToString());
            int idRes = Convert.ToInt32(this.txtIDResCaj.Text);
            int idMon = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());
            Decimal nMontoHab = Convert.ToDecimal(this.txtMonHab.Text);
            Decimal nSalAnt = Convert.ToDecimal(this.txtSalAnt.Text);
            string cSust = this.txtSustento.Text.Trim();
			DateTime dFechaHab = dtpFecHab.Value;
            bool lModificaSaldoLinea = true;
            int idTipoTransac = 2; //egreso
            int IdUsuario = clsVarGlobal.User.idUsuario;

            //===============================================================================
            //--Valida Saldo de caja
            //===============================================================================
            if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, idMon, 2, nMontoHab))
            {
                return;
            }

            //===============================================================================
            //--Registro de Habilitación de Caja Chica
            //===============================================================================
            clsCNCajaChica dtCajChi = new clsCNCajaChica();
            DataTable tbdtCajChi = dtCajChi.RegistraHabCajaChica(idCaj, idRes, idMon, nMontoHab, 0, nMontoHab, nSalAnt, cSust, dFechaHab, clsVarGlobal.User.idUsuario, idAge,
                lModificaSaldoLinea, idTipoTransac);

            if (Convert.ToInt32(tbdtCajChi.Rows[0]["idRpta"].ToString()) == 0)
            {

                txtNroRecibo.Text = tbdtCajChi.Rows[0]["idRecibo"].ToString();

                // RQ-412 Integracion de Saldos en Linea
                new Semaforo().ValidarSaldoSemaforo();
                
                MessageBox.Show("La Habilitación se Registro Correctamente, NRO RECIBO: " + tbdtCajChi.Rows[0]["idRecibo"].ToString(), "Registro de Habilitación de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Information); 
               
                //int nIdKardex = Convert.ToInt32(tbdtCajChi.Rows[0]["idKardex"]);

                this.btnNuevo.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.cboCajChica.Enabled = false;
                this.txtSustento.ReadOnly = true;

                //---============================================================================================
                //--Imprimir Voucher
                //---============================================================================================

                string msge = "";
                int idRec = Convert.ToInt32(tbdtCajChi.Rows[0]["idRecibo"]);
                int nIdKardex = Convert.ToInt32(tbdtCajChi.Rows[0]["idKardex"]);

                //clsCNControlOpe DtRecibo = new clsCNControlOpe();
                //DataTable tbRec = DtRecibo.BuscarRecibo(idRec, ref msge);
                ImpresionVoucher(nIdKardex, 3, x_nTipOpe, 1, nMontoHab, 0, 0, 1);
                //EmitirVoucher(tbRec, idRec, nIdKardex);

            }
            else
            {
                MessageBox.Show(tbdtCajChi.Rows[0]["cMensage"].ToString(), "Registro de Habilitación de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }   
        }

        private void EmitirVoucher(DataTable dtDatosCobro, int idRec, int nIdKardex)
        {
            string cVarVal = clsVarApl.dicVarGen["CRUTALOGO"];
            string cRUC = clsVarApl.dicVarGen["cRUC"];
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("idRec", idRec.ToString(), false));
            paramlist.Add(new ReportParameter("cNombreVariable", cVarVal, false));
            paramlist.Add(new ReportParameter("idKardex", nIdKardex.ToString(), false));
            paramlist.Add(new ReportParameter("cRUC", cRUC.ToString(), false));
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsCobro", dtDatosCobro));
            string reportpath = "RptVoucherHabCajaCh.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (cboCajChica.SelectedIndex == -1)
            {
                LimpiarControles();               
                this.btnGrabar.Enabled = false;
            }
            else
            {
                this.btnGrabar.Enabled = true;
            }
            this.cboCajChica.Enabled = true;
            this.btnNuevo.Enabled = false;         
            this.txtSustento.Enabled = true;
            this.txtSustento.ReadOnly = false;
            this.cboCajChica.Focus();
        }
    }
}
