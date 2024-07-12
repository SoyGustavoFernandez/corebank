using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPT.Presentacion
{
    public partial class frmAnexo16BSupuesto : frmBase
    {
        DataTable dtAnexo16B;
        clsRPTCNReporte cnDatoGenericos = new clsRPTCNReporte();
        public frmAnexo16BSupuesto()
        {
            InitializeComponent();
            dtpFecha.Value = clsVarGlobal.dFecSystem;
        }

        private void btnGenerar1_Click(object sender, EventArgs e)
        {
            DateTime dFecha = dtpFecha.Value;
            DataSet dsAnexo16BSup = new clsRPTCNCredito().CNDatosContingenciaAnexo16B(dFecha);

            DataTable dtAnexo16BSup = dsAnexo16BSup.Tables[0];

            if (dtAnexo16BSup.Rows.Count > 0)
            {
                if (MessageBox.Show("Existen datos generados ¿Esta seguro de sobreescribirlos?", "Anexo 16B Supuestos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    ProcesaSupuesto(dFecha);
                }
            }
            else
            {
                ProcesaSupuesto(dFecha);
            }

        }
        private void ProcesaSupuesto(DateTime dFecha)
        {
            DataSet dsAnexo16B = new clsRPTCNCredito().CNAnexo16B(dFecha);
            dtAnexo16B = dsAnexo16B.Tables[0];
            dtgAnexo16B.DataSource = dtAnexo16B;
            // SOLES
            foreach (DataGridViewRow row in dtgAnexo16B.Rows)
            {
                int nFila = Convert.ToInt32(row.Cells[11].Value);
                switch (nFila)
                {
                    case 2:
                        row.DefaultCellStyle.BackColor = Color.AliceBlue;
                        break;

                    case 4:
                        row.DefaultCellStyle.BackColor = Color.SkyBlue;
                        break;
                }
            }

            foreach (DataGridViewRow row in dtgAnexo16B.Rows)
            {
                foreach (DataGridViewColumn col in dtgAnexo16B.Columns)
                {
                    if (Convert.ToInt32(col.Index) > 0)
                    {
                        if (Convert.ToDecimal(dtgAnexo16B[col.Index, row.Index].Value) < 0)
                        {
                            dtgAnexo16B[col.Index, row.Index].Style.ForeColor = Color.Red;
                        }
                    }
                }

            }
            // Dólares
            DataTable dtAnexo16BME = dsAnexo16B.Tables[1];
            dtgME.DataSource = dtAnexo16BME;
            foreach (DataGridViewRow row2 in dtgME.Rows)
            {
                int nFila = Convert.ToInt32(row2.Cells[11].Value);
                switch (nFila)
                {
                    case 2:
                        row2.DefaultCellStyle.BackColor = Color.AliceBlue;
                        break;

                    case 4:
                        row2.DefaultCellStyle.BackColor = Color.SkyBlue;
                        break;
                }
            }

            foreach (DataGridViewRow row1 in dtgME.Rows)
            {
                foreach (DataGridViewColumn col1 in dtgME.Columns)
                {
                    if (Convert.ToInt32(col1.Index) > 0)
                    {
                        if (Convert.ToDecimal(dtgME[col1.Index, row1.Index].Value) < 0)
                        {
                            dtgME[col1.Index, row1.Index].Style.ForeColor = Color.Red;
                        }
                    }
                }
            }
        }
        
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFecha = dtpFecha.Value;

            DataSet dsAnexo16BRep = new clsRPTCNCredito().CNDatosContingenciaAnexo16B(dFecha);
            DataTable dtAnexo16BRep = dsAnexo16BRep.Tables[2];

            if (dtAnexo16BRep.Rows.Count == 0)
            {
                MessageBox.Show("No existe datos para el reporte", "Anexo 16B Supuestos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("x_dFecha", dFecha.Date.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dtsAnexo16BSup", dtAnexo16BRep));

            string reportpath = "RptAnexo16BSupuestos.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
 
        }
    }
}
