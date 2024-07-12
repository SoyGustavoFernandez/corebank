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
    public partial class frmRptHabilitaciones : frmBase
    {
        public string cValCarCol="S";

        #region Eventos del Formularios

        public frmRptHabilitaciones()
        {
            InitializeComponent();
        }

        private void frmRptHabilitaciones_Load(object sender, EventArgs e)
        {
            DatosUsuario();
            if (this.cboAgencias.SelectedIndex >= 0)
            {
                this.cboAgencias.SelectedValue = 1;
                this.cboAgencias.Select();
                this.cboAgencias_SelectedIndexChanged(sender, e);
            }
            //=====================================================
            //----Validar cargo del Colaborador
            //=====================================================
            clsCNControlOpe ValCargo = new clsCNControlOpe();
            string ValCargoPer = ValCargo.ValidacargoPer(clsVarGlobal.User.idUsuario);
            //if (ValCargoPer=="0")
            //{
            //    cValCarCol = "N";
            //    this.cboAgencias.Enabled = false;
            //    this.cboColaborador.Enabled = false;
            //    this.cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
            //    this.cboColaborador.SelectedValue = clsVarGlobal.User.idUsuario;                
            //}
        }
        
        private void ListarColAgencia(int idAge)
        {
            clsCNControlOpe LisColAge = new clsCNControlOpe();
            DateTime dFecIni =dtpFecIni.Value;
            DateTime dFecFin =dtpFecFin.Value;

            DataTable tbColAge = LisColAge.CNListarColabAgenciasIniOpe(idAge,dFecIni ,dFecFin );
            this.cboColaborador.DataSource = tbColAge;
            this.cboColaborador.ValueMember = tbColAge.Columns["idUsuario"].ToString();
            this.cboColaborador.DisplayMember = tbColAge.Columns["cNombre"].ToString();
            if (tbColAge.Rows.Count > 0)
            {
                this.cboColaborador.Enabled = true;
            }
            else
            {
                this.cboColaborador.Enabled = false;
            }
        }

        private void cboAgencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nItem;
            nItem = Convert.ToInt32(this.cboAgencias.SelectedValue.ToString());
            ListarColAgencia(nItem);
            if (cValCarCol == "N")
            {
                this.cboColaborador.Enabled = false;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //==================================================================
            //--Validar Datos del Reporte
            //==================================================================
            if (string.IsNullOrEmpty(this.cboAgencias.SelectedValue.ToString().Trim()))
            {
                MessageBox.Show("Debe Seleccionar una Agencia", "Reporte de Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgencias.Focus();
                this.cboAgencias.Select();
                return;
            }
            if (this.cboColaborador.SelectedIndex < 0)
            {
                MessageBox.Show("Debe Seleccionar el Colaborador", "Reporte de Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboColaborador.Focus();
                this.cboColaborador.Select();
                return;
            }
            if (string.IsNullOrEmpty(this.cboColaborador.SelectedValue.ToString().Trim()))
            {
                MessageBox.Show("Debe Seleccionar el Colaborador", "Reporte de Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboColaborador.Focus();
                this.cboColaborador.Select();
                return;
            }
            if (this.dtpFecIni.Value>this.dtpFecFin.Value)
            {
                MessageBox.Show("La Fecha Final no Puede ser Menor que la Fecha Inicial", "Reporte de Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpFecIni.Focus();
                return;
            }
                string dFecIni = this.dtpFecIni.Value.ToShortDateString();
                string dFecFin = this.dtpFecFin.Value.ToShortDateString();
                string idUsu = this.cboColaborador.SelectedValue.ToString();
                string idAge = this.cboAgencias.SelectedValue.ToString();
                DateTime dFechaSis = clsVarGlobal.dFecSystem;
                string cVarVal = clsVarApl.dicVarGen["CRUTALOGO"];
                DataTable dtHabilitaciones = new clsRPTCNCaja().CNRptHabilitaciones(Convert.ToDateTime(dFecIni), Convert.ToDateTime(dFecFin), Convert.ToInt32(idUsu),Convert.ToInt32(idAge));
            
            if (dtHabilitaciones.Rows.Count<=0)
	        {
                MessageBox.Show("No existen registros de habilitaciones", "Reporte de Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
	        }
            else
	        {              
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("dFecIni", dFecIni, false));
                paramlist.Add(new ReportParameter("dFecFin", dFecFin, false));
                paramlist.Add(new ReportParameter("idUsuario", idUsu, false));
                paramlist.Add(new ReportParameter("idAge", idAge, false));
                paramlist.Add(new ReportParameter("cNombreVariable", cVarVal, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString("dd/MM/yyyy"), false));          

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsHabilitacion", dtHabilitaciones));

                string reportpath = "RptHabilitaciones.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

                this.btnImprimir.Enabled = true;
	        }
           
        }

        #endregion

        /// <summary>
        /// Carga y asigna datos del Usuario
        /// </summary>
        private void DatosUsuario()
        {
            dtpFechaSis.Value = clsVarGlobal.dFecSystem;
            this.dtpFecIni.Value = clsVarGlobal.dFecSystem;
            this.dtpFecFin.Value = clsVarGlobal.dFecSystem;

            txtCodUsu.Text = clsVarGlobal.User.idUsuario.ToString();
            txtUsuario.Text = clsVarGlobal.User.cWinUser;
            int nidCli = Convert.ToInt32(clsVarGlobal.User.idCli);
            clsCNRetDatosCliente RetDatCli = new clsCNRetDatosCliente();
            DataTable DatosCli = RetDatCli.ListarDatosCli(nidCli, "D");
            if (DatosCli.Rows.Count > 0)
            {
                txtNomUsu.Text = DatosCli.Rows[0]["cNombre"].ToString();
            }
            else
            {
                txtNomUsu.Text = "";
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            //==================================================================
            //--Validar Datos del Reporte
            //==================================================================
            if (string.IsNullOrEmpty(this.cboAgencias.SelectedValue.ToString().Trim()))
            {
                MessageBox.Show("Debe Seleccionar una Agencia", "Reporte de Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgencias.Focus();
                this.cboAgencias.Select();
                return;
            }
            if (this.cboColaborador.SelectedIndex < 0)
            {
                MessageBox.Show("Debe Seleccionar el Colaborador", "Reporte de Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboColaborador.Focus();
                this.cboColaborador.Select();
                return;
            }
            if (string.IsNullOrEmpty(this.cboColaborador.SelectedValue.ToString().Trim()))
            {
                MessageBox.Show("Debe Seleccionar el Colaborador", "Reporte de Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboColaborador.Focus();
                this.cboColaborador.Select();
                return;
            }
            if (this.dtpFecIni.Value > this.dtpFecFin.Value)
            {
                MessageBox.Show("La Fecha Final no Puede ser Menor que la Fecha Inicial", "Reporte de Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpFecIni.Focus();
                return;
            }
            string dFecIni = this.dtpFecIni.Value.ToShortDateString();
            string dFecFin = this.dtpFecFin.Value.ToShortDateString();
            string idUsu = this.cboColaborador.SelectedValue.ToString();
            string idAge = this.cboAgencias.SelectedValue.ToString();
            DateTime dFechaSis = clsVarGlobal.dFecSystem;
            string cVarVal = clsVarApl.dicVarGen["CRUTALOGO"];
            DataTable dtHabilitacionesBill = new clsRPTCNCaja().CNRptHabilitacionesBill(Convert.ToDateTime(dFecIni), Convert.ToDateTime(dFecFin), Convert.ToInt32(idUsu), Convert.ToInt32(idAge));

            if (dtHabilitacionesBill.Rows.Count <= 0)
            {
                MessageBox.Show("No existen registros de habilitaciones", "Reporte de Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("dFecIni", dFecIni, false));
                paramlist.Add(new ReportParameter("dFecFin", dFecFin, false));
                paramlist.Add(new ReportParameter("idUsuario", idUsu, false));
                paramlist.Add(new ReportParameter("idAge", idAge, false));
                paramlist.Add(new ReportParameter("cNombreVariable", cVarVal, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString("dd/MM/yyyy"), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsBillHabilitacion", dtHabilitacionesBill));

                string reportpath = "RptHabilitacionesBill.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

                this.btnImprimir.Enabled = true;
            }
        }

        private void dtpFecFin_ValueChanged(object sender, EventArgs e)
        {
            int nItem;
            nItem = Convert.ToInt32(this.cboAgencias.SelectedValue.ToString());
            ListarColAgencia(nItem);
        
        }

        private void dtpFecIni_ValueChanged(object sender, EventArgs e)
        {
            int nItem;
            nItem = Convert.ToInt32(this.cboAgencias.SelectedValue.ToString());
            ListarColAgencia(nItem);
        }
    }
}
