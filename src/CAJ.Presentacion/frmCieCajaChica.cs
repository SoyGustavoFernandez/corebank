using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmCieCajaChica : frmBase
    {
        clsCNCajaChica Lista = new clsCNCajaChica();
        DataTable dtDatosCajChica;
        public frmCieCajaChica()
        {
            InitializeComponent();
        }

        private void frmCieCajaChica_Load(object sender, EventArgs e)
        {
            this.cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
            this.dtpCierre.Value = clsVarGlobal.dFecSystem;
            if (ValidarRespCajChica())
            {
                MessageBox.Show("Usted no es responsable de Caja Chica", "Cierre de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
                return;
            }
            if (ValidarCajaChicaActivo())
            {
                MessageBox.Show("Falta Iniciar Fondo Fijo", "Cierre de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
                return;
            }
            if (ValidarHabilitacionCajChica()==4)
            {
                MessageBox.Show("Falta realizar la Habilitacion de Fondo Fijo", "Cierre de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
                return;
            }
            if (ValidarCierreCajChic())
            {
                MessageBox.Show("Caja Chica Cerrada.", "Cierre de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
                return;
            }
            CargarCajChica();
            CargarDatCierreCajChica();
        }
        private bool ValidarCierreCajChic()
        {
            bool lRpta = false;
            if (Convert.ToInt32(dtDatosCajChica.Rows[0]["idEstCajChi"].ToString()) == 3)
            {
                lRpta = true;
            }

            return lRpta;
        }
        private bool ValidarRespCajChica()
        {
            bool valRespCajChi = false;
            dtDatosCajChica = Lista.BuscarCajChicResp(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);
            if (dtDatosCajChica.Rows.Count <= 0)
            {
                valRespCajChi = true;
            }
            return valRespCajChi;
        }
        private bool ValidarCajaChicaActivo()
        {
            bool lRpta = false;
            if (Convert.ToInt32(dtDatosCajChica.Rows[0]["idEstCajChi"].ToString()) == 1)
            {
                lRpta = true;
            }
            return lRpta;
        }
        private int ValidarHabilitacionCajChica()
        {
           // dtDatosCajChica = Lista.BuscarHabCajChic(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);
            return Convert.ToInt32(dtDatosCajChica.Rows[0]["idEstCajChi"].ToString());
        }

        private void CargarCajChica()
        {
            
            DataTable tb = Lista.ListaCajaChica(clsVarGlobal.nIdAgencia, clsVarGlobal.User.idUsuario,2);
            this.cboCajChica.DataSource = tb;
            this.cboCajChica.ValueMember = tb.Columns["idCajChica"].ToString();
            this.cboCajChica.DisplayMember = tb.Columns["cNomCajChi"].ToString();
        }
        private void CargarDatCierreCajChica()
        {
            this.btnImprimir.Enabled = false;
            if (this.cboCajChica.Items.Count > 0)
            {
                int idCaj = Convert.ToInt32(this.cboCajChica.SelectedValue.ToString());
                clsCNCajaChica Lista = new clsCNCajaChica();
                DataTable tb = Lista.DatosCierreCajChica(idCaj, 0, 1);
                if (tb.Rows.Count > 0)
                {
                    this.txtNroFonFij.Text = tb.Rows[0]["nNroCajChi"].ToString();
                    this.txtNomResCaj.Text = tb.Rows[0]["cNombre"].ToString();
                    this.txtIDResCaj.Text = tb.Rows[0]["idResCajChi"].ToString();
                    this.cboMoneda.SelectedValue = tb.Rows[0]["idMoneda"];
                    this.txtMontoFij.Text = tb.Rows[0]["nMonMaxCaj"].ToString();
                    this.txtSalCaja.Text = tb.Rows[0]["nSaldoAnt"].ToString();
                    this.dtpFecInicio.Value = Convert.ToDateTime(tb.Rows[0]["dFechaIni"].ToString());
                    this.txtMonCierre.Text = tb.Rows[0]["nTotalHab"].ToString();
                
                    //================================================================================
                    //--Lllenar Comprobantes de Caja Chica
                    //================================================================================
                    int idNroCaj = Convert.ToInt32(this.txtNroFonFij.Text);
                    clsCNCajaChica ListaCpg = new clsCNCajaChica();
                    DataTable tbCpg = ListaCpg.DatosCierreCajChica(idCaj, idNroCaj, 2);
                    this.dtgLisCpgCajChi.DataSource = tbCpg;
                    if (tbCpg.Rows.Count > 0)
                    {
                        this.txtNroCpg.Text = tbCpg.Rows[0]["nTotalCpg"].ToString();
                        this.btnProcesar.Enabled = true;
                        this.btnImprimir.Enabled = true;
                    }
                    else
                    {
                        this.txtNroCpg.Text = "0";
                        this.btnProcesar.Enabled = false;
                    }
                }
            }
        }

        private void cboCajChica_SelectedIndexChanged(object sender, EventArgs e)
        {
           // CargarDatCierreCajChica();
        }

        private void cboCajChica_Click(object sender, EventArgs e)
        {
            CargarDatCierreCajChica();
        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            var Msg = MessageBox.Show("¿Estas Seguro de Realizar el Cierre de caja Chica?...", "Cierre de Caja Chica", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Msg == DialogResult.No)
            {
                return;
            }
            //===============================================================================
            //--Asignar Datos a las Variables
            //===============================================================================
            int idCaj = Convert.ToInt32(this.cboCajChica.SelectedValue.ToString());
            int nNroCaj = Convert.ToInt32(this.txtNroFonFij.Text);
            DateTime dFecReg = this.dtpCierre.Value;
            int nNroCpg = Convert.ToInt32(this.txtNroCpg.Text);
            
            //===============================================================================
            //--Registro de Habilitación de Caja Chica
            //===============================================================================
            clsCNCajaChica dtCajChi = new clsCNCajaChica();
            DataTable tbdtCajChi = dtCajChi.RegistrarCierreCajChica(idCaj, nNroCaj, dFecReg, clsVarGlobal.User.idUsuario, nNroCpg);
            if (Convert.ToInt32(tbdtCajChi.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(tbdtCajChi.Rows[0]["cMensage"].ToString(), "Cierre de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnProcesar.Enabled = false;
            }
            else
            {
                MessageBox.Show(tbdtCajChi.Rows[0]["cMensage"].ToString(), "Cierre de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            List<ReportParameter> paramlist = new List<ReportParameter>();
            int idResp = Convert.ToInt32(txtIDResCaj.Text);
            int idCajChica = Convert.ToInt32(cboCajChica.SelectedValue.ToString());
            int nNroCajChica = Convert.ToInt32(txtNroFonFij.Text);
            DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;
            String cNomAgen = clsVarGlobal.cNomAge;
            String cRutLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            int EstadoCpg =  2;

            paramlist.Add(new ReportParameter("idResp", idResp.ToString(), false));
            paramlist.Add(new ReportParameter("idCajChica", idCajChica.ToString(), false));
            paramlist.Add(new ReportParameter("nNroCajChica", nNroCajChica.ToString(), false));
            paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString(), false));
            paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen.ToString(), false));
            paramlist.Add(new ReportParameter("x_RutLogo", cRutLogo.ToString(), false));
            paramlist.Add(new ReportParameter("EstadoCpg", EstadoCpg.ToString(), false));


            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsDetCajChica", new clsRPTCNCaja().CNDetCajChica(idResp, idCajChica, nNroCajChica, EstadoCpg)));
            dtslist.Add(new ReportDataSource("dsDatosCajaChica", new clsRPTCNCaja().CNDatosCajChica(idCajChica, nNroCajChica)));

            string reportpath = "RptCajaChica.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

    }
}
