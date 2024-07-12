using CRE.CapaNegocio;
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

namespace CRE.Presentacion
{
    public partial class frmImpCreditosCongelados : frmBase
    {
        clsCNCredito cnCredito = new clsCNCredito();
        public frmImpCreditosCongelados()
        {
            InitializeComponent();
        }

        private void frmImpCreditosCongelados_Load(object sender, EventArgs e)
        {
            dtpInicio.Value = clsVarGlobal.dFecSystem;
            dtpFin.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                DataTable dtCreditosCongelados = cnCredito.listarCreditosCongelados(Convert.ToDateTime(dtpInicio.Value), Convert.ToDateTime(dtpFin.Value), chcConPagos.Checked);
                if (dtCreditosCongelados.Rows.Count > 0)
                {
                    List<ReportDataSource> dtslist = new List<ReportDataSource>();
                    List<ReportParameter> paramlist = new List<ReportParameter>();
                    paramlist.Clear();
                    paramlist.Add(new ReportParameter("dFecIni", dtpInicio.Value.ToString("dd/MM/yyyy"), false));
                    paramlist.Add(new ReportParameter("dFecFin", dtpFin.Value.ToString("dd/MM/yyyy"), false));
                    paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                    paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                    paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

                    dtslist.Clear();
                    dtslist.Add(new ReportDataSource("dsCreditosCongelados", dtCreditosCongelados));

                    string reportpath = "rptCreditosTasaCongelada.rdlc";
                    new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se tiene datos para mostrar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private bool validar()
        {
            if (dtpInicio.Value > dtpFin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha fin", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpInicio.Focus();
                return false;
            }
            return true;
        }
    }
}
