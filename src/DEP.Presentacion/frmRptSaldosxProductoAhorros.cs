using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmRptSaldosxProductoAhorros : frmBase
    {
        #region Variables Globales
        //Declarar variables globales

        private const string cTituloMsjes = "Reporte de saldos por producto.";
        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = clsVarGlobal.dFecSystem;
            cboAgencia.SelectedIndex = -1;
            chcHistorico.Checked = false;
            dtpFecha.Enabled = false;
        }

        #endregion

        #region Metodos

        public frmRptSaldosxProductoAhorros()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            if (cboAgencia.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la agencia", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if(!Validar()) return;

            int idAgencia = Convert.ToInt16(cboAgencia.SelectedValue);
            string cAgencia = cboAgencia.Text;
            DateTime dFecSis = clsVarGlobal.dFecSystem;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            DateTime dFecha = dtpFecha.Value;

            DataTable dtData = null;

            if (!chcHistorico.Checked)
            {
                dtData = new clsRPTCNDeposito().CNRptSaldosOnlineProductoAhorros(idAgencia);                
            }
            else
            {
                dtData = new clsRPTCNDeposito().CNRptSaldosProductoHistAhorros(dFecha, idAgencia);
            }

            if (dtData.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cAgencia", cAgencia, false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", dFecSis.ToString("dd/MM/yyyy"), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsData", dtData));
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));

                string reportpath = string.Empty;

                if (!chcHistorico.Checked)
                {
                    reportpath = "RptSaldosOnlineProductoAhorros.rdlc";
                }
                else
                {
                    reportpath = "RptSaldosProductoHistAhorros.rdlc";
                }

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existen Datos para el Reporte", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void chcHistorico_CheckedChanged(object sender, EventArgs e)
        {
            dtpFecha.Enabled = chcHistorico.Checked;
            dtpFecha.Value = clsVarGlobal.dFecSystem;
        }

    }
}
