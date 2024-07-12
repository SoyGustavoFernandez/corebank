using CNT.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNT.Presentacion
{
    public partial class frmCertificadoITF : frmBase
    {
        public frmCertificadoITF()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            int idcli = conBusCli1.idCli;
            if (idcli==0)
            {
                MessageBox.Show("Debe seleccionar un cliente", "ITF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime dFecIni = dtpFecIni.Value;
            DateTime dFecFin = dtpFecFin.Value;
            Decimal nEjercicio = ndEjeGra.Value;
            DateTime dFecPro = clsVarGlobal.dFecSystem;

            DataTable dtTrx = new clsCNITF().DatoTRX(idcli, dFecIni, dFecFin);
            DataTable dtVariable = new clsCNITF().DatoVariableITF();
            if (dtTrx.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dsITF", dtTrx));
                dtslist.Add(new ReportDataSource("dtsVariables", dtVariable));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_nIdCli", idcli.ToString(), false));
                paramlist.Add(new ReportParameter("x_dFecIni", dFecIni.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_dFecFin", dFecFin.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cEjercicio", nEjercicio.ToString(), false));
                paramlist.Add(new ReportParameter("x_dFecProceso", dFecPro.ToString("dd/MM/yyyy"), false));

                string reportpath = "RptCerITF.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para el cliente seleccionado", "ITF", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void ndEjeGra_Validated(object sender, EventArgs e)
        {
        }

        private void frmCertificadoITF_Load(object sender, EventArgs e)
        {
            ndEjeGra.Value = clsVarGlobal.dFecSystem.Year;
            decimal nEjercicio = ndEjeGra.Value;
            dtpFecIni.Value = Convert.ToDateTime(Convert.ToString(nEjercicio)+"/01/01");
            dtpFecFin.Value = Convert.ToDateTime(Convert.ToString(nEjercicio + 1) + "/01/01").AddDays(-1);
        }

        private void ndEjeGra_ValueChanged(object sender, EventArgs e)
        {
            decimal nEjercicio = ndEjeGra.Value;
            dtpFecIni.Value = Convert.ToDateTime(Convert.ToString(nEjercicio) + "/01/01");
            dtpFecFin.Value = Convert.ToDateTime(Convert.ToString(nEjercicio + 1) + "/01/01").AddDays(-1);
        }
    }
}
