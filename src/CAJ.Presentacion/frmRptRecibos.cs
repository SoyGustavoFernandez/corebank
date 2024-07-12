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
    public partial class frmRptRecibos : frmBase
    {
        public string cValCarCol = "S";
        public frmRptRecibos()
        {
            InitializeComponent();
        }

        private void frmRptRecibos_Load(object sender, EventArgs e)
        {
            DatosUsuario();
            if (this.cboAgencias.SelectedIndex >= 0)
            {
                this.cboAgencias.SelectedValue = 1;
                this.cboAgencias.Select();
                this.cboAgencias_SelectedIndexChanged(sender,e);
            }
            //=====================================================
            //----Validar cargo del Colaborador
            //=====================================================
            clsCNControlOpe ValCargo = new clsCNControlOpe();
            string ValCargoPer = ValCargo.ValidacargoPer(clsVarGlobal.User.idUsuario);
            if (ValCargoPer == "0")
            {
                cValCarCol = "N";
                this.cboAgencias.Enabled = false;
                this.cboColaborador.Enabled = false;
                this.cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
                this.cboColaborador.SelectedValue = clsVarGlobal.User.idUsuario;                
            }
            this.dtpFechaRpt.Value = clsVarGlobal.dFecSystem;
        }

        private void DatosUsuario()
        {
            dtpFechaSis.Value = clsVarGlobal.dFecSystem;
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

        private void ListarColAgencia(int idAge)
        {
            clsCNControlOpe LisColAge = new clsCNControlOpe();
            DataTable tbColAge = LisColAge.ListarColabAgencias(idAge);
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
            if (cValCarCol == "N")
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
                MessageBox.Show("Debe Seleccionar una Agencia", "Reporte de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgencias.Focus();
                this.cboAgencias.Select();
                return;
            }
            if (this.cboColaborador.SelectedIndex==-1)
            {
                MessageBox.Show("Debe Seleccionar el Colaborador", "Reporte de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboColaborador.Focus();
                this.cboColaborador.Select();
                return;
            }
            if (string.IsNullOrEmpty(this.cboColaborador.SelectedValue.ToString().Trim()))
            {
                MessageBox.Show("Debe Seleccionar el Colaborador", "Reporte de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboColaborador.Focus();
                this.cboColaborador.Select();
                return;
            }          

            string dFecha = this.dtpFechaRpt.Value.ToShortDateString();
            string idUsu = this.cboColaborador.SelectedValue.ToString();
            string idAge = this.cboAgencias.SelectedValue.ToString();
            DateTime dFechaSis = clsVarGlobal.dFecSystem;
            string cVarVal = clsVarApl.dicVarGen["CRUTALOGO"];

            DataTable dtRecibos = new clsRPTCNCaja().CNRptRecibos(Convert.ToDateTime(dFecha), Convert.ToInt32(idUsu), Convert.ToInt32(idAge));
            if (dtRecibos.Rows.Count<=0)
            {
                MessageBox.Show("No se encontraton registros con los parametros especificados para el reporte.", "Reporte de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("dFecOpe", dFecha, false));
                paramlist.Add(new ReportParameter("idUsu", idUsu, false));
                paramlist.Add(new ReportParameter("idAge", idAge, false));
                paramlist.Add(new ReportParameter("cNombreVariable", cVarVal, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString("dd/MM/yyyy"), false));
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dsRecibos", dtRecibos));
                string reportpath = "RptRecibos.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                this.btnImprimir.Enabled = true;
            }          
        }

    }
}
