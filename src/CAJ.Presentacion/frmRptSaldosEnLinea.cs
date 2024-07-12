using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmRptSaldosEnLinea : frmBase
    {
        public DataSet dsListaAgencias;

        public frmRptSaldosEnLinea()
        {
            InitializeComponent();
            DatosUsuario();
            iniCboLimPor();
            this.cboZona1.cargarZona(true, false);
            this.dsListaAgencias = (new clsCNControlLimitesBoveda()).listaAgenciasEOBs();
        }

        void iniCboLimPor()
        { 
            var dtLimites = new DataTable();
            dtLimites.Columns.Add("nLimPor", typeof(Decimal));
            dtLimites.Columns.Add("cLim");

            dtLimites.Rows.Add(-1, "NO APLICA");
            dtLimites.Rows.Add(80, "80%");
            dtLimites.Rows.Add(90, "90%");
            dtLimites.Rows.Add(100, "100%");

            this.cboLimPor.DataSource = dtLimites;
            this.cboLimPor.DisplayMember = "cLim";
            this.cboLimPor.ValueMember = "nLimPor";
        }

        private void grbBase1_Enter(object sender, EventArgs e)
        {

        }
        private void DatosUsuario()
        {
            dtpFechaDesde.Value = clsVarGlobal.dFecSystem;
            this.dtpFechaHasta.Value = clsVarGlobal.dFecSystem;
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
            DateTime dFecha = this.dtpFechaDesde.Value;            
            int idAge = Convert.ToInt32(cboAgencia.SelectedValue);
            Int32 idZona = Convert.ToInt32(cboZona1.SelectedValue);
            
            List<ReportParameter> paramlist = new List<ReportParameter>();

            string dFechaSistema = clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy");
            string cAgenOpe = clsVarGlobal.cNomAge;
            Decimal nLimPor = Convert.ToDecimal(this.cboLimPor.SelectedValue);

            paramlist.Add(new ReportParameter("cAgenOpe", cAgenOpe, false));
            paramlist.Add(new ReportParameter("dFechaSistema", dFechaSistema, false));
            paramlist.Add(new ReportParameter("cNombreVariable", "CRUTALOGO", false));
            paramlist.Add(new ReportParameter("cNombreImgLimite", "cRutaImgLimite", false));
            paramlist.Add(new ReportParameter("cZona", this.cboZona1.Text, false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("DSSaldoEnLinea", new clsRPTCNCaja().CNSaldoEnLinea(this.dtpFechaDesde.Value, this.dtpFechaHasta.Value, idAge, nLimPor, idZona)));
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsRutaLimites", new clsRPTCNAgencia().CNRutaImgLimite()));

            string reportpath = "rptSaldoEnLinea.rdlc";
            new frmReporteLocal(dtslist, reportpath,paramlist).ShowDialog();

            this.btnImprimir.Enabled = true;
        }

        private void cboZona1_SelectedValueChanged(object sender, EventArgs e)
        {
            this.cboAgencia.SelectedValue = 0;
            if (this.cboZona1.SelectedValue != null && this.cboZona1.SelectedValue != DBNull.Value && this.dsListaAgencias.Tables.Count > 0)
            {
                if (Convert.ToInt32(this.cboZona1.SelectedValue) == 0)
                {
                    this.cboAgencia.DataSource = this.dsListaAgencias.Tables[0];
                }
                else
                {
                    var dtAgencias = this.dsListaAgencias.Tables[0].Select("idZona = " + this.cboZona1.SelectedValue.ToString()).CopyToDataTable();
                    dtAgencias.ImportRow(this.dsListaAgencias.Tables[0].Rows[0]);
                    dtAgencias = dtAgencias.AsEnumerable().OrderBy(x => x.Field<Int32>("idAgencia")).CopyToDataTable();
                    this.cboAgencia.DataSource = dtAgencias;
                }
            }
        }
    }
}
