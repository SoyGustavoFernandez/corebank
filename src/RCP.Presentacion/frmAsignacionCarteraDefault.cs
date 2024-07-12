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
using Microsoft.Reporting.WinForms;
using RCP.CapaNegocio;

namespace RCP.Presentacion
{
    public partial class frmAsignacionCarteraDefault : frmBase
    {
        clsCNCarteraRecupera cnCarteraRecupera = new clsCNCarteraRecupera();
        string cPeriodo = "";
        DataTable dtCreditos = new DataTable();

        public frmAsignacionCarteraDefault()
        {
            InitializeComponent();
        }

        private void cargar()
        {
            dtCreditos = cnCarteraRecupera.resumenAsigSinGestor();
            if (dtCreditos.Rows.Count > 0)
            {
                dtgCreditosNoAsignados.DataSource = dtCreditos;
                formatoGridCreditos();
                lblTotal.Text = "Total: " + dtgCreditosNoAsignados.Rows.Count.ToString();
                btnGrabar1.Enabled = true;
                btnImprimir1.Enabled = true;
            }
            else
            {
                dtgCreditosNoAsignados.DataSource = null;
                btnGrabar1.Enabled = false;
                btnImprimir1.Enabled = false;
            }
        }

        private void frmAsignacionCarteraDefault_Load(object sender, EventArgs e)
        {
            cPeriodo = clsVarGlobal.dFecSystem.Month.ToString("00") + clsVarGlobal.dFecSystem.Year.ToString("0000");
            txtPeriodo.Text = clsVarGlobal.dFecSystem.Month.ToString("00") + " - " + clsVarGlobal.dFecSystem.Year.ToString("0000");
            cargar();
        }

        private void formatoGridCreditos()
        {
            foreach (DataGridViewColumn column in this.dtgCreditosNoAsignados.Columns)
            {
                column.Visible = false;                
            }

            dtgCreditosNoAsignados.Columns["cTramo"].Visible = true;
            dtgCreditosNoAsignados.Columns["cEstadoContable"].Visible = true;
            dtgCreditosNoAsignados.Columns["nAtraso"].Visible = true;
            dtgCreditosNoAsignados.Columns["cNombre"].Visible = true;
            dtgCreditosNoAsignados.Columns["dFechaDesembolso"].Visible = true;
            dtgCreditosNoAsignados.Columns["cMoneda"].Visible = true;
            dtgCreditosNoAsignados.Columns["nCapitalDesembolso"].Visible = true;
            dtgCreditosNoAsignados.Columns["nSaldoCapital"].Visible = true;

            dtgCreditosNoAsignados.Columns["cTramo"].HeaderText = "Tramo";
            dtgCreditosNoAsignados.Columns["cEstadoContable"].HeaderText = "Estado contable";
            dtgCreditosNoAsignados.Columns["nAtraso"].HeaderText = "Atraso";
            dtgCreditosNoAsignados.Columns["cNombre"].HeaderText = "Nombre del cliente";
            dtgCreditosNoAsignados.Columns["dFechaDesembolso"].HeaderText = "Fec. Desembolso";
            dtgCreditosNoAsignados.Columns["cMoneda"].HeaderText = "Moneda";
            dtgCreditosNoAsignados.Columns["nCapitalDesembolso"].HeaderText = "Desembolso";
            dtgCreditosNoAsignados.Columns["nSaldoCapital"].HeaderText = "Saldo Capital";

            dtgCreditosNoAsignados.Columns["cTramo"].Width = 70;
            dtgCreditosNoAsignados.Columns["cEstadoContable"].Width = 70;
            dtgCreditosNoAsignados.Columns["nAtraso"].Width = 50;
            dtgCreditosNoAsignados.Columns["cNombre"].Width = 150;
            dtgCreditosNoAsignados.Columns["dFechaDesembolso"].Width = 50;
            dtgCreditosNoAsignados.Columns["cMoneda"].Width = 50;
            dtgCreditosNoAsignados.Columns["nCapitalDesembolso"].Width = 70;
            dtgCreditosNoAsignados.Columns["nSaldoCapital"].Width = 70;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (dtCreditos.Rows.Count > 0)
            {
                String cTitulo = "Crédito no asignados al periodo " + txtPeriodo.Text;
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsCreditos", dtCreditos));

                List<ReportParameter> paramList = new List<ReportParameter>();
                paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramList.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramList.Add(new ReportParameter("cTitulo", cTitulo, false));
                paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

                string reportPath = "rptAsignacionFutCarteraRecuperaciones.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
            }
            else
            {
                MessageBox.Show("El reporte no tiene datos que mostrar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            DialogResult result =
                            MessageBox.Show(
                                "Se asignará " + dtCreditos.Rows.Count + " Créditos sin gestor asignado. ¿Desea continuar?", "Validación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }

            DataSet dsCreditos = new DataSet();
            dsCreditos.Tables.Add(dtCreditos);
            string xmlCodigos = dsCreditos.GetXml();

            DataTable dtResultado = cnCarteraRecupera.AsignarCarteraSinGestor(xmlCodigos,
                                                                            clsVarGlobal.dFecSystem.Month.ToString("00") + clsVarGlobal.dFecSystem.Year.ToString("0000"),
                                                                            clsVarGlobal.PerfilUsu.idUsuario,
                                                                            clsVarGlobal.dFecSystem
                                                                            );

            if (dtResultado.Rows.Count > 0 && Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
            {
                MessageBox.Show(dtResultado.Rows[0][1].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargar();                
            }
        }
    }
}
