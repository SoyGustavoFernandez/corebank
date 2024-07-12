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
using GEN.PrintHelper;
using SPL.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace SPL.Presentacion
{
    public partial class frmRptCreditosCanceladosAnticipados : frmBase
    {
        #region Variable Globales
        clsCNCreditos cnCreditos;

        #endregion

        public frmRptCreditosCanceladosAnticipados()
        {
            InitializeComponent();
            dtpFechaFin.Value = clsVarGlobal.dFecSystem;
            dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
            cnCreditos = new clsCNCreditos();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            cboAgencias.AgenciasYTodos();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (cboAgencias.SelectedIndex < 0)
            {
                MessageBox.Show("Debe Seleccionar La Agencia", "Créditos Cancelado Anticipado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboMoneda.SelectedIndex < 0)
            {
                MessageBox.Show("Debe Seleccionar La Moneda", "Créditos Cancelado Anticipado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dtpFechaInicio.Value > dtpFechaFin.Value)
            {
                MessageBox.Show("La Fecha de Inicio No Puede Ser Menor Que La Fecha de Fin", "Créditos Cancelado Anticipado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if (txtMontoInicio.nDecValor> txtMontoFin.nDecValor)
            {
                MessageBox.Show("El Monto Inicio No puede Ser Mayor Que El Monto Fin", "Créditos Cancelado Anticipado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DateTime dFechaInicio = dtpFechaInicio.Value;
            DateTime dFechaFin = dtpFechaFin.Value;
            Decimal nMontoIni = txtMontoInicio.nDecValor;
            Decimal nMontoFin = txtMontoFin.nDecValor;
            int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
            int idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);

            DataTable dtRpt =  cnCreditos.CNCreditosCanceladosAnticipadamente(dFechaInicio, dFechaFin, nMontoIni, nMontoFin, idAgencia, idMoneda);

            if (dtRpt.Rows.Count == 0)
            {
                MessageBox.Show("No Hay datos para estos filtros ", "Créditos Cancelado Anticipado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            string reportpath = "rptCreditosCanceladosAnticipadamente.rdlc";
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string AgenEmision = clsVarApl.dicVarGen["cNomAge"];

            paramlist.Add(new ReportParameter("cNomAgen", AgenEmision, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaCancelInicio", dFechaInicio.ToShortDateString(), false));
            paramlist.Add(new ReportParameter("dFechaCancelFin", dFechaFin.ToShortDateString(), false));
            paramlist.Add(new ReportParameter("nMontoInicio", nMontoIni.ToString(), false));
            paramlist.Add(new ReportParameter("nMontoFin", nMontoFin.ToString(), false));

            paramlist.Add(new ReportParameter("cRutaLogo", Convert.ToString(clsVarApl.dicVarGen["CRUTALOGO"]), false));

            dtslist.Add(new ReportDataSource("dsCreditosCanceladosAnt", dtRpt));

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }
        #endregion

        #region Métodos
        #endregion

        
    }
}
