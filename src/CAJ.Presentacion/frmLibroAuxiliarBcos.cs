using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using System.Globalization;
using CAJ.CapaNegocio;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;
using EntityLayer;

namespace CAJ.Presentacion
{
    public partial class frmLibroAuxiliarBcos : frmBase
    {
        DataTable dtPeriodProc;
        DataTable dtInstituciones;

        public frmLibroAuxiliarBcos()
        {
            InitializeComponent();
            cboAnio.Enabled = true;
            cboMes.Enabled = false;
            cboInstitucion.Enabled = false;
            chcSelec.Enabled = false;
            chklbCuentas.Enabled = false;
            cboCuentas.Enabled = false;
        }        

        private void frmLibroAuxiliarBcos_Load(object sender, EventArgs e)
        {
            cboAnio.SelectedIndexChanged -= new EventHandler(cboAnio_SelectedIndexChanged);
            CargarPeriodos();
            cboAnio.SelectedIndexChanged += new EventHandler(cboAnio_SelectedIndexChanged);
        }

        private void CargarPeriodos()
        {
            dtPeriodProc = new clsCNMovimientoBanco().ListarPeriodosProcCierreBcos();
            DataView view = new DataView(dtPeriodProc);
            DataTable dtAnio = view.ToTable(true, "nAnio");
            cboAnio.DataSource = dtAnio;
            cboAnio.ValueMember = "nAnio";
            cboAnio.DisplayMember = "nAnio";
            cboAnio.SelectedIndex = -1;
        }

        private string obtenerNombreMesNumero(int numeroMes)
        {
            try
            {
                DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
                string nombreMes = formatoFecha.GetMonthName(numeroMes);
                return nombreMes;
            }
            catch
            {
                return "Desconocido";
            }
        }

        private void cboAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboAnio.SelectedIndex==-1)return;
            cboMes.SelectedIndexChanged -= new EventHandler(cboMes_SelectedIndexChanged);
            DataView view = new DataView(dtPeriodProc);
            view.RowFilter = "nAnio = " + cboAnio.SelectedValue.ToString();
            DataTable dtMes = view.ToTable(true, "nAnio", "nMes");
            DataColumn column = new DataColumn("nNomMes", typeof(string));
            dtMes.Columns.Add(column);
            foreach (DataRow row in dtMes.Rows)
            {
                TextInfo myTI = CultureInfo.CurrentCulture.TextInfo;
                row["nNomMes"] = myTI.ToTitleCase(obtenerNombreMesNumero(Convert.ToInt32(row["nMes"])));
            }
            cboMes.DataSource = dtMes;
            cboMes.ValueMember = "nMes";
            cboMes.DisplayMember = "nNomMes";
            cboMes.SelectedIndex = -1;
            cboMes.SelectedIndexChanged += new EventHandler(cboMes_SelectedIndexChanged);
            cboMes.Enabled = true;
        }

        private void CargarInstituciones()
        {
            DateTime dFecCierre = new DateTime(Convert.ToInt32(cboAnio.SelectedValue), Convert.ToInt32(cboMes.SelectedValue), 1).AddMonths(1).AddDays(-1);
            dtInstituciones = new clsCNMovimientoBanco().ListInstPeriodCierreBco(dFecCierre);
            DataView view = new DataView(dtInstituciones);
            DataTable dtInst = view.ToTable(true, "idEntidad", "cNombreCorto");
            cboInstitucion.DataSource = dtInst;
            cboInstitucion.ValueMember = "idEntidad";
            cboInstitucion.DisplayMember = "cNombreCorto";
            cboInstitucion.SelectedIndex = -1;
        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMes.SelectedIndex == -1) return;
            cboInstitucion.SelectedIndexChanged -= new EventHandler(cboInstitucion_SelectedIndexChanged);
            CargarInstituciones();
            cboInstitucion.SelectedIndexChanged += new EventHandler(cboInstitucion_SelectedIndexChanged);
            cboInstitucion.Enabled = true;
        }

        private void cboInstitucion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboInstitucion.SelectedIndex == -1) return;
            CargarCuentaInstituciones();
            chcSelec.Enabled = true;
            chklbCuentas.Enabled = true;
        }

        private void CargarCuentaInstituciones()
        {
            DataView view = new DataView(dtInstituciones);
            view.RowFilter = "idEntidad = " + cboInstitucion.SelectedValue.ToString();
            DataTable dtCuentas = view.ToTable(true, "idCuentaInstitucion", "cNumeroCuenta");
            
            this.chklbCuentas.DataSource = null;
            this.chklbCuentas.DataSource = dtCuentas;
            this.chklbCuentas.ValueMember = dtCuentas.Columns["idCuentaInstitucion"].ToString();
            this.chklbCuentas.DisplayMember = dtCuentas.Columns["cNumeroCuenta"].ToString();
        }

        private void chcSelec_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chcSelec.Checked)
            {
                for (int i = 0; i < this.chklbCuentas.Items.Count; i++)
                {
                    this.chklbCuentas.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < this.chklbCuentas.Items.Count; i++)
                {
                    this.chklbCuentas.SetItemChecked(i, false);
                }               
            }
            chklbCuentas_SelectedValueChanged(sender, e);
        }

        private void chklbCuentas_SelectedValueChanged(object sender, EventArgs e)
        {
            if (chklbCuentas.DataSource == null) return;
            if (chklbCuentas.CheckedItems.Count == 0)
            {
                dtgExtractoCta.DataSource = null;
                cboCuentas.DataSource = null;
                return;
            }
            DataTable dtCtasSeleccionadas = dtInstituciones.Clone();
            foreach (DataRowView item in chklbCuentas.CheckedItems)
            {
                DataRow row = dtCtasSeleccionadas.NewRow();
                row["idCuentaInstitucion"] = item["idCuentaInstitucion"].ToString();
                row["cNumeroCuenta"] = item["cNumeroCuenta"].ToString();
                dtCtasSeleccionadas.Rows.Add(row);
            }
            cboCuentas.SelectedIndexChanged -= new EventHandler(cboCuentas_SelectedIndexChanged);
            cboCuentas.DataSource = null;
            cboCuentas.DataSource = dtCtasSeleccionadas;
            cboCuentas.DisplayMember = "cNumeroCuenta";
            cboCuentas.ValueMember = "idCuentaInstitucion";
            cboCuentas.SelectedIndex = -1;
            cboCuentas.SelectedIndexChanged += new EventHandler(cboCuentas_SelectedIndexChanged);
            if (cboCuentas.Items.Count > 0)
            {
                cboCuentas.SelectedIndex = 0;
            }
        }

        private void cboCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCuentas.SelectedIndex == -1) return;
            DateTime dFechaIni = new DateTime(Convert.ToInt32(cboAnio.SelectedValue),Convert.ToInt32(cboMes.SelectedValue),1);
            DateTime dFechaFin = new DateTime(Convert.ToInt32(cboAnio.SelectedValue),Convert.ToInt32(cboMes.SelectedValue),1).AddMonths(1).AddDays(-1);
            //DataTable dtExtractoCta = new clsRPTCNCaja().CNExtractoBcos(Convert.ToInt32(cboCuentas.SelectedValue), dFechaIni, dFechaFin);
            DataTable dtExtractoCta = new clsRPTCNCaja().CNLibroAuxilarBcos(cboCuentas.SelectedValue.ToString(), dFechaIni, dFechaFin);
            dtgExtractoCta.DataSource = dtExtractoCta;
            FormatoGridView();
            cboCuentas.Enabled = true;
        }

        private void FormatoGridView()
        {
            #region Anterior
            dtgExtractoCta.Columns["dFechaRegistro"].Visible = false;
            dtgExtractoCta.Columns["dfechaOpe"].Visible = true;
            dtgExtractoCta.Columns["idTipoTransaccion"].Visible = false;
            dtgExtractoCta.Columns["cMotOper"].Visible = true;
            dtgExtractoCta.Columns["cTipDoc"].Visible = false;
            dtgExtractoCta.Columns["cNroDocumento"].Visible = false;
            dtgExtractoCta.Columns["nMontoOpera"].Visible = true;
            dtgExtractoCta.Columns["nSaldo"].Visible = true;
            dtgExtractoCta.Columns["cNombre"].Visible = false;

            dtgExtractoCta.Columns["cMoneda"].Visible = false;
            dtgExtractoCta.Columns["idEntidad"].Visible = false;
            dtgExtractoCta.Columns["idMoneda"].Visible = false;
            dtgExtractoCta.Columns["idCuentaInstitucion"].Visible = false;
            dtgExtractoCta.Columns["cNumeroCuenta"].Visible = false;
            dtgExtractoCta.Columns["nMontoEgreso"].Visible = false;
            dtgExtractoCta.Columns["nMontIngreso"].Visible = false;

            dtgExtractoCta.Columns["dfechaOpe"].HeaderText = "Fecha";
            dtgExtractoCta.Columns["cMotOper"].HeaderText = "Concepto";
            dtgExtractoCta.Columns["nMontoOpera"].HeaderText = "Monto";
            dtgExtractoCta.Columns["nSaldo"].HeaderText = "Saldo";

            dtgExtractoCta.Columns["dfechaOpe"].FillWeight = 50;
            dtgExtractoCta.Columns["cMotOper"].FillWeight = 150;
            dtgExtractoCta.Columns["nMontoOpera"].FillWeight = 50;
            dtgExtractoCta.Columns["nSaldo"].FillWeight = 50;
            #endregion
        

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (ValidarDatos()) return;

            string cIdCuentaInst = "";
            foreach (DataRowView item in chklbCuentas.CheckedItems)
            {
                cIdCuentaInst += (item.Row["idCuentaInstitucion"] + ",");               
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            DateTime dFechaIni = new DateTime(Convert.ToInt32(cboAnio.SelectedValue), Convert.ToInt32(cboMes.SelectedValue), 1);
            DateTime dFechaFin = new DateTime(Convert.ToInt32(cboAnio.SelectedValue), Convert.ToInt32(cboMes.SelectedValue), 1).AddMonths(1).AddDays(-1);
            DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;
            String cNomAgen = clsVarGlobal.cNomAge;
            String cRutLogo = clsVarApl.dicVarGen["CRUTALOGO"];

            paramlist.Add(new ReportParameter("idCtaBco", cIdCuentaInst.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaIni", dFechaIni.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaFin", dFechaFin.ToString(), false));
            paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString(), false));
            paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen.ToString(), false));
            paramlist.Add(new ReportParameter("x_RutLogo", cRutLogo.ToString(), false));          

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsBancos", new clsRPTCNCaja().CNLibroAuxilarBcos(cIdCuentaInst, dFechaIni, dFechaFin)));

            string reportpath = "rptLibroAuxiliarBcos.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private bool ValidarDatos()
        {
            if (cboAnio.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el año del periodo.", "Libro Auxiliar de Bancos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboAnio.Focus();
                return true;
            }
            if (cboMes.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el mes del periodo.", "Libro Auxiliar de Bancos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMes.Focus();
                return true;
            }
            if (cboInstitucion.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione alguna Entidad Financiera .", "Libro Auxiliar de Bancos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboInstitucion.Focus();
                return true;
            }
            if (chklbCuentas.CheckedItems.Count==0)
            {
                MessageBox.Show("Seleccione alguna cuenta de la lista.", "Libro Auxiliar de Bancos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboInstitucion.Focus();
                return true;
            }

            return false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cboAnio.SelectedIndex = -1;
            cboMes.SelectedIndex = -1;
            cboInstitucion.SelectedIndex = -1;
            cboCuentas.SelectedIndex = -1;
            chklbCuentas.DataSource = null;
            dtgExtractoCta.DataSource = null;
            chcSelec.Checked = false;
            
            cboAnio.Enabled = true;
            cboMes.Enabled = false;
            cboInstitucion.Enabled = false;
            chcSelec.Enabled = false;
            chklbCuentas.Enabled = false;
            cboCuentas.Enabled = false;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (cboAnio.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el año del periodo.", "Libro Auxiliar de Bancos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboAnio.Focus();
                return;
            }
            if (cboMes.SelectedIndex == -1)
            {
                MessageBox.Show("Elija el mes del periodo.", "Libro Auxiliar de Bancos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMes.Focus();
                return;
            }

            string cIdCuentaInst = "";
            foreach (DataRow item in dtInstituciones.Rows)
            {
                cIdCuentaInst += (item["idCuentaInstitucion"] + ",");
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            DateTime dFechaIni = new DateTime(Convert.ToInt32(cboAnio.SelectedValue), Convert.ToInt32(cboMes.SelectedValue), 1);
            DateTime dFechaFin = new DateTime(Convert.ToInt32(cboAnio.SelectedValue), Convert.ToInt32(cboMes.SelectedValue), 1).AddMonths(1).AddDays(-1);
            DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;
            String cNomAgen = clsVarGlobal.cNomAge;
            String cRutLogo = clsVarApl.dicVarGen["CRUTALOGO"];

            paramlist.Add(new ReportParameter("idCtaBco", cIdCuentaInst.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaIni", dFechaIni.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaFin", dFechaFin.ToString(), false));
            paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString(), false));
            paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen.ToString(), false));
            paramlist.Add(new ReportParameter("x_RutLogo", cRutLogo.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsBancos", new clsRPTCNCaja().CNLibroAuxilarBcos(cIdCuentaInst, dFechaIni, dFechaFin)));

            string reportpath = "rptLibroAuxiliarBcos.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
    }

}
