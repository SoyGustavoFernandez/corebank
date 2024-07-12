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
using GEN.LibreriaOffice;
using GEN.CapaNegocio;
using CAJ.CapaNegocio;
using Microsoft.Reporting.WinForms;
using EntityLayer;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmReporteMoraTramoAsesor :  frmBase
    {
        string cTituloMensajes = "Reporte mora";
        public frmReporteMoraTramoAsesor()
        {
            InitializeComponent();
            ListadoAgencias();
            dtpFechaProceso.Value = clsVarGlobal.dFecSystem.AddDays(-1).Date;
        }

        private void ListadoAgencias()
        {
            clsCNControlOpe ListadoAgencia = new clsCNControlOpe();
            DataTable dt = ListadoAgencia.ListarAgencias();

            this.cboAgencias.DataSource = dt;
            this.cboAgencias.ValueMember = dt.Columns["idAgencia"].ToString();
            this.cboAgencias.DisplayMember = dt.Columns["cNombreAge"].ToString();
        }

        private void frmReporteMoraTramoAsesor_Load(object sender, EventArgs e)
        {

        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (cboAgencias.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar la agencia", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgencias.Focus();
                return;
            }

            if (dtpFechaProceso.Value >= clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha menor que la fecha del sistema", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgencias.Focus();
                return;
            }

            DateTime dFecha = this.dtpFechaProceso.Value;

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarGlobal.cNomAge;
            string cUsuWin = clsVarGlobal.User.cWinUser;

            Int32 idAge = Convert.ToInt32(this.cboAgencias.SelectedValue);

            clsRPTCNCredito rptCredito = new clsRPTCNCredito();
            DataTable dtReporteMoraTramo = rptCredito.CNRptMoraTramoAsesor(idAge, dFecha);
            if (dtReporteMoraTramo.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("cUsuWin", cUsuWin, false));
                paramlist.Add(new ReportParameter("cRutaLogo", EntityLayer.clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("dFecha", dFecha.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaSis", dFecha.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNombreAgenciaSelecionada", this.cboAgencias.Text, false));
                List<ReportDataSource> dtslist = new List<ReportDataSource>();

                dtslist.Add(new ReportDataSource("rptMoraTramoAsesor", dtReporteMoraTramo));

                string reportpath = "rptMoraTramoAsesor.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay créditos en mora para la agencia y fecha seleccionada", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgencias.Focus();
                return;
            }
            
        }
    }
}
