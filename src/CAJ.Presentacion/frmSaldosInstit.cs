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
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace CAJ.Presentacion
{
    public partial class frmSaldosInstit : frmBase
    {
        public frmSaldosInstit()
        {
            InitializeComponent();
        }
        string cNombreAge;
        private int pIdAgencia;
        private void frmSaldosInstit_Load(object sender, EventArgs e)
        {
            this.dtpFechaSis.Value = clsVarGlobal.dFecSystem;
        }

        private void FormatoGrid()
        {
            this.dtgSaldoIntit.Columns["idAgencia"].Visible = false;          
            this.dtgSaldoIntit.Columns["idUsuario"].Visible = false;          
            this.dtgSaldoIntit.Columns["cNombreAge"].Width = 150;
            this.dtgSaldoIntit.Columns["cNombreAge"].HeaderText = "AGENCIAS";
            this.dtgSaldoIntit.Columns["nMontoCieSol"].Width = 100;
            this.dtgSaldoIntit.Columns["nMontoCieSol"].HeaderText = "SALDO CIERRE S/.";
            this.dtgSaldoIntit.Columns["nMontoCieDol"].Width = 100;
            this.dtgSaldoIntit.Columns["nMontoCieDol"].HeaderText = "SALDO CIERRE $";
            this.dtgSaldoIntit.Columns["cEstado"].Width = 80;
            this.dtgSaldoIntit.Columns["cEstado"].HeaderText = "ESTADO";
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            string msg = "";
            DateTime dfecpro = Convert.ToDateTime(this.dtpFechaSis.Value.ToShortDateString());
            clsCNControlOpe VerEstCie = new clsCNControlOpe();
            DataTable tbEstCie = VerEstCie.ListadosaldosInstit(dfecpro, ref msg);
            if (msg == "OK")
            {
                this.dtgSaldoIntit.DataSource = tbEstCie;
                FormatoGrid();
                this.dtgSaldoIntit.Columns["cNombreAge"].Width = 150;
            }
            else
            {
                MessageBox.Show(msg, "Verificar Saldos de Agencias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimirLibro_Click(object sender, EventArgs e)
        {
            DateTime dFecha = this.dtpFechaSis.Value;
            //int idAge = pIdAgencia;
            List<ReportDataSource> dtslist = new List<ReportDataSource>();


            dtslist.Add(new ReportDataSource("dsBilLibroCajBov", new clsRPTCNCaja().CNRptListaLibroCajBov(pIdAgencia, dFecha)));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToShortDateString(), false));
            paramlist.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("dFecCorFra", dFecha.ToShortDateString(), false));
            paramlist.Add(new ReportParameter("idAgencia", pIdAgencia.ToString(), false));

           

            paramlist.Add(new ReportParameter("nOpcion", "2", false));
            paramlist.Add(new ReportParameter("cAgenciaProceso", cNombreAge, false));

            string reportpath = "RptBillLibrCajBov.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void dtgSaldoIntit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            activaboton();
        }

        private void dtgSaldoIntit_SelectionChanged(object sender, EventArgs e)
        {
            activaboton();
        }
        
        private void activaboton()
        {
            if (dtgSaldoIntit.Rows.Count > 0)
            {  
                string fila = dtgSaldoIntit.CurrentRow.Cells["cEstado"].Value.ToString();
                 cNombreAge = dtgSaldoIntit.CurrentRow.Cells["cNombreAge"].Value.ToString();
                 pIdAgencia = Convert.ToInt32(dtgSaldoIntit.CurrentRow.Cells["idAgencia"].Value);

                if (fila.Equals("OK"))
                {
                    btnImprimirLibro.Enabled = true;
                }
                else
                {
                    btnImprimirLibro.Enabled = false;
                }
            }
        }
    }
}
