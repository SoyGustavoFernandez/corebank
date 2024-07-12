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
using GEN.Funciones;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmDevolucionCajChica : frmBase
    {
        private int x_nTipOpe = 0;

        public frmDevolucionCajChica()
        {
            InitializeComponent();
        }

        private void frmHabCajChica_Load(object sender, EventArgs e)
        {
            x_nTipOpe = 5;

            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            if (this.ValidarInicioOpeSoloCaja() != "A")
            {
                this.Dispose();
                return;
            }

            conBusCol.txtCod.Enabled = false;
            conBusCol.btnConsultar.Enabled = false;
            CargarCajChica(0);
            this.cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
            cboAgencias_SelectedIndexChanged(sender,e);
        }
    
        private void CargarCajChica(int idAge)
        {
            clsCNCajaChica Lista = new clsCNCajaChica();
            DataTable tb = Lista.ListaCajaChica(idAge,clsVarGlobal.User.idUsuario,2);  //--Caja Chica en estado Activo
            this.cboCajChica.DataSource = tb;
            this.cboCajChica.ValueMember = tb.Columns["idCajChica"].ToString();
            this.cboCajChica.DisplayMember = tb.Columns["cNomCajChi"].ToString();
        }

        private void DatosCajChica(int idCaj)
        {
            LimpiarControles();
            clsCNCajaChica Lista = new clsCNCajaChica();
            DataTable tb = Lista.DatosCajaChica(idCaj,2);
            if (tb.Rows.Count > 0)
            {
                if (Convert.ToDecimal (tb.Rows[0]["nSalAnt"].ToString())==0)
                {
                    MessageBox.Show("No Hay Monto a Devolver en la caja Chica", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimpiarControles();
                    return;
                }
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
                conBusCol.txtCod.Enabled = false;
                conBusCol.btnConsultar.Enabled = true;
                this.txtSustento.Enabled = true;
                this.txtSustento.Focus();
            }
            else
            {
                conBusCol.txtCod.Enabled = false;
                conBusCol.btnConsultar.Enabled = false;
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

            if (Convert.ToDecimal (txtSalAnt.Text)==0)
            {
                MessageBox.Show("El Monto de la Devolución,No puede Ser Cero", "Habilitación de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            if (Convert.ToDecimal (this.txtMonHab.Text) < 0)
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
            if (string.IsNullOrEmpty(this.conBusCol.txtNom.Text.Trim()))
            {
                MessageBox.Show("Debe Seleccionar el Colaborador Destinatario", "Devolución de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.conBusCol.btnConsultar.Focus();
                return "ERROR";   
            }
            
            if (Convert.ToInt16(conBusCol.idAgencia) != Convert.ToInt16(cboAgencias.SelectedValue))
            {
                MessageBox.Show("Debe de seleccionar a un responsable de ventanilla de la misma agencia", "Devolución de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.conBusCol.btnConsultar.Focus();
                return "ERROR";
            }
         
                     
            return "OK";
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
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
            int idOpe = Convert.ToInt32(this.conBusCol.txtCod.Text);
            //int idOpe = clsVarGlobal.User.idUsuario;
            int idMon = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());
            //Decimal nMontoHab = Convert.ToDecimal (this.txtMonHab.Text);
            //Decimal nSalAnt = Convert.ToDecimal (this.txtSalAnt.Text);
            Decimal nMontoHab = Convert.ToDecimal (this.txtSalAnt.Text); //--Saldo Disponible a Devolver
            Decimal nSalAnt = Convert.ToDecimal (this.txtMonHab.Text);  //--Monto Gastado
            string cSust = this.txtSustento.Text.Trim();

            if (ValidaSaldoLinea(idRes, idAge, idMon, 1, nMontoHab))
            {
                return;
            }

            //===============================================================================
            //--Registro de Habilitación de Caja Chica
            //===============================================================================
            string msg = "";
            bool lModificaSaldoLinea = true;
            int idTipoTransac = 1; //INGRESO

            clsCNImpresion Imprimir = new clsCNImpresion();
            clsCNCajaChica dtCajChi = new clsCNCajaChica();
            DataTable tbdtCajChi = dtCajChi.RegistraDevCajaChica(idCaj, idRes, idMon, nMontoHab, 0, nMontoHab, nSalAnt, cSust, clsVarGlobal.dFecSystem, idOpe, idAge, lModificaSaldoLinea, idTipoTransac);
            if (Convert.ToInt32(tbdtCajChi.Rows[0]["idRpta"].ToString()) == 0)
            {
                txtNroRecibo.Text = tbdtCajChi.Rows[0]["idRecibo"].ToString();

                new Semaforo().ValidarSaldoSemaforo();
                // RQ-412 Integracion de Saldos en Linea

                MessageBox.Show("La Devolución se Registro Correctamente, NRO RECIBO: " + tbdtCajChi.Rows[0]["idRecibo"].ToString(), "Registro de Devolucion de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Information);              
                
                this.btnNuevo.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.cboCajChica.Enabled = false;
                this.txtSustento.ReadOnly = true;

                //---============================================================================================
                //--Imprimir Voucher
                //---============================================================================================
				//PARA LA IMPRESONA TERMICA
				//int nIdKardex = Convert.ToInt32(tbdtCajChi.Rows[0]["idKardex"]);             
				//clsCNImpresion Imprimir = new clsCNImpresion();
                //DataTable dtDatosOperacion = Imprimir.CNDatosOperacion(nIdKardex, clsVarGlobal.idModulo);
                //if (dtDatosOperacion.Rows.Count > 0)
                //{

                //    string cCadena = Convert.ToString(Imprimir.CNImpresionVoucher(clsVarGlobal.idModulo, x_nTipOpe, dtDatosOperacion, 1));
                //    if (string.IsNullOrEmpty(cCadena))
                //    {

                //        MessageBox.Show("Ocurrió un problema al intentar imprimir", "Registro de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    }
                //    else
                //    {



                //        List<ReportDataSource> dtslist = new List<ReportDataSource>();
                //        List<ReportParameter> paramlist = new List<ReportParameter>();
                //        paramlist.Add(new ReportParameter("cTexto", cCadena, false));
                //        paramlist.Add(new ReportParameter("cNombreVariable", clsVarApl.dicVarGen["CRUTALOGO"], false));
                //        string reportpath = "rptVoucher.rdlc";
                //        new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();
                //    }
                //}

                ///////////////////////Emitir voucher////////////////////////////////
                string msge = "";
                int idRec = Convert.ToInt32(tbdtCajChi.Rows[0]["idRecibo"]);
                int nIdKardex = Convert.ToInt32(tbdtCajChi.Rows[0]["idKardex"]);

                ImpresionVoucher(nIdKardex, 3, x_nTipOpe, 1, nMontoHab, 0, 0, 1);
                //clsCNControlOpe DtRecibo = new clsCNControlOpe();
                //DataTable tbRec = DtRecibo.BuscarRecibo(idRec, ref msge);
                //EmitirVoucher(tbRec, idRec, nIdKardex);
                /////////////////////////////////////////////////////////////////////                             
               
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
            string reportpath = "RptVoucherDevCajaCh.rdlc";
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
