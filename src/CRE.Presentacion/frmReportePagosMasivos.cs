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
using Microsoft.Reporting.WinForms;
using CRE.CapaNegocio;
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class frmReportePagosMasivos : frmBase
    {
        #region Atributos
        #endregion

        public frmReportePagosMasivos()
        {
            InitializeComponent();
            LimpiarFormulario(); 
        }

        public frmReportePagosMasivos(int idPagoMasivo)
        {
            InitializeComponent();
            ImprimirPagoMasivo(idPagoMasivo);
            
        }

        #region Metodos Privados
        public void LimpiarFormulario() 
        {
            dtpInicio.Value = clsVarGlobal.dFecSystem;
            dtpFin.Value    = clsVarGlobal.dFecSystem;
            if(dtgPagosMasivos.DataSource != null)
            {
                ((DataTable)dtgPagosMasivos.DataSource).Clear();
                dtgPagosMasivos.Update();
            }
            
        }
        public void ImprimirPagoMasivo(int idPagoMasivo)
        {
            clsCNCredito objCredito = new clsCNCredito();

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DataTable dtResp = objCredito.CNReportePagoMasivo(idPagoMasivo);

            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("idPagoMasivo", "0", false));

            dtslist.Add(new ReportDataSource("dsPagoMasivo", dtResp));

            string reportpath = "rptPagoMasivo.rdlc";
            frmReporteLocal frmreporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmreporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            frmreporte.ShowDialog();
        }

        private void FormatoGrid()
        {
            foreach (DataGridViewColumn item in dtgPagosMasivos.Columns)
            {
                item.Visible = false;
            }

            dtgPagosMasivos.Columns["idPagoMasivo"].HeaderText = "ID.";
            dtgPagosMasivos.Columns["idPagoMasivo"].Visible = true;
            dtgPagosMasivos.Columns["idPagoMasivo"].Width = 15;

            dtgPagosMasivos.Columns["dFechaReg"].HeaderText = "Fecha";
            dtgPagosMasivos.Columns["dFechaReg"].Visible = true;

            dtgPagosMasivos.Columns["cTipoPagoMasivo"].HeaderText = "T. Pago Masivo";
            dtgPagosMasivos.Columns["cTipoPagoMasivo"].Visible = true;

            dtgPagosMasivos.Columns["cNombreOrden"].HeaderText = "Ordenante";
            dtgPagosMasivos.Columns["cNombreOrden"].Visible = true;

            dtgPagosMasivos.Columns["cNombreEjecuta"].HeaderText = "Ejecutante";
            dtgPagosMasivos.Columns["cNombreEjecuta"].Visible = true;
        }

        #endregion

        #region Eventos
        
        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            DateTime dFechaIni,
                     dFechaFin;
            clsCNCredito objCredito = new clsCNCredito();

            dFechaIni = dtpInicio.Value;
            dFechaFin = dtpFin.Value;

            if (dFechaIni > dFechaFin)
            {
                MessageBox.Show("La Fecha Inicio no puede ser mayor que la Fecha Fin", "Reporte Pagos Masivos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable dtResp = objCredito.CNListaPagoMasivo(dFechaIni, dFechaFin);
            dtgPagosMasivos.DataSource = dtResp;
            FormatoGrid();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (dtgPagosMasivos.DataSource == null)
            {
                MessageBox.Show("No se tiene pagos masivos seleccionados", "Reporte Pagos Masivos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtgPagosMasivos.SelectedRows.Count == 0)
            {
                MessageBox.Show("No se tiene pagos masivos seleccionados", "Reporte Pagos Masivos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int idPagoMasivo = Convert.ToInt32(dtgPagosMasivos.SelectedRows[0].Cells["idPagoMasivo"].Value);

            ImprimirPagoMasivo(idPagoMasivo);
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
        #endregion
    }
}
