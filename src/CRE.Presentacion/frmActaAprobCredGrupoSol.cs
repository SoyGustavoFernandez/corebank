using CRE.CapaNegocio;
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
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class frmActaAprobCredGrupoSol : frmBase
    {
        private clsCNAprobacionCredito objCNAprobacionCredito = new clsCNAprobacionCredito();

        public frmActaAprobCredGrupoSol()
        {
            InitializeComponent();
            txtIdGrupoSolidario.Text = "0";
            txtIdGrupoSolidario.Enabled = false;
            dtpFechaIni.Value = clsVarGlobal.dFecSystem.AddDays(-1);
            dtpFechaFin.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImpActaCredito_Click(object sender, EventArgs e)
        {
            if (dtgSolCredGrupAprob.DataSource == null)
            {
                MessageBox.Show("No se ha hecho ninguna busqueda.", "Acta de apribación del Grupo Solidario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtgSolCredGrupAprob.RowCount == 0)
            {
                MessageBox.Show("No hay ningun registro en el datagrid.", "Acta de apribación del Grupo Solidario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtgSolCredGrupAprob.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay ningun registro seleccionado en el datagrid.", "Acta de apribación del Grupo Solidario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idSolGrupoSolidario = Convert.ToInt32(dtgSolCredGrupAprob.SelectedRows[0].Cells["idSolicitudCredGrupoSol"].Value);
            int idGrupoSolidario = Convert.ToInt32(dtgSolCredGrupAprob.SelectedRows[0].Cells["idGrupoSolidario"].Value);


            DataTable dtData = objCNAprobacionCredito.ActaCreditoGrupoSol(idGrupoSolidario, idSolGrupoSolidario);
            DataTable dtData2 = objCNAprobacionCredito.ActaCreditoGrupoSol2(idGrupoSolidario, idSolGrupoSolidario);
            DataTable dtData3 = objCNAprobacionCredito.ActaCreditoGrupoSol3(idGrupoSolidario, idSolGrupoSolidario);
            DataTable dtData4 = objCNAprobacionCredito.ActaCreditoGrupoSol4(idGrupoSolidario, idSolGrupoSolidario);
            DataTable dtNivelesAprob = objCNAprobacionCredito.LisNivelAprobaSolCredGrupoSol(idSolGrupoSolidario);
            string cNomAgen = clsVarGlobal.cNomAge.ToString();

            if (dtData.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();

                dtsList.Add(new ReportDataSource("dsSoli1", dtData));
                dtsList.Add(new ReportDataSource("dsSoli2", dtData2));
                dtsList.Add(new ReportDataSource("dsSoli3", dtData3));
                dtsList.Add(new ReportDataSource("dsExcepciones", dtData4));
                dtsList.Add(new ReportDataSource("dsNivelAproGrupoSol", dtNivelesAprob));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("idGrupo", idGrupoSolidario.ToString(), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));

                string reportPath = "rptActaCrediSolidario.rdlc";  
                new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();


            }
            else
            {
                MessageBox.Show("No existen datos para esta Evaluación. ", "Acta de apribación del Grupo Solidario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMiniBusqueda1_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;

            DataTable dtRes = objCNAprobacionCredito.CNListaCredAprobadosGrupSolXFechaYGrupo(dtpFechaIni.Value, dtpFechaFin.Value, Convert.ToInt32(txtIdGrupoSolidario.Text));
            dtgSolCredGrupAprob.DataSource = dtRes;
            formatoGrid();

        }

        private bool validar()
        {
            if (dtpFechaIni.Value > dtpFechaFin.Value)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final.", "Acta de apribación del Grupo Solidario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void chcGrupoSolidario_CheckedChanged(object sender, EventArgs e)
        {
            if (chcGrupoSolidario.Checked)
            {
                txtIdGrupoSolidario.Enabled = true;
            }
            else
            {
                txtIdGrupoSolidario.Enabled = false;
            }
            txtIdGrupoSolidario.Text = "0";
        }

        private void formatoGrid()
        { 
            foreach (DataGridViewColumn item in dtgSolCredGrupAprob.Columns)
	        {
		        item.Visible = false;
	        }

            dtgSolCredGrupAprob.Columns["idSolicitudCredGrupoSol"].Visible = true;
            dtgSolCredGrupAprob.Columns["dFechaDecisFinal"].Visible = true;
            dtgSolCredGrupAprob.Columns["cNombreGrupo"].Visible = true;
            dtgSolCredGrupAprob.Columns["cEstado"].Visible = true;
            dtgSolCredGrupAprob.Columns["cMoneda"].Visible = true;
            dtgSolCredGrupAprob.Columns["nMontoSolicitado"].Visible = true;
            dtgSolCredGrupAprob.Columns["cProducto"].Visible = true;
            dtgSolCredGrupAprob.Columns["cNombreAsesor"].Visible = true;

            dtgSolCredGrupAprob.Columns["idSolicitudCredGrupoSol"].HeaderText = "Nro Solicitud";
            dtgSolCredGrupAprob.Columns["dFechaDecisFinal"].HeaderText = "Fecha Aprobación";
            dtgSolCredGrupAprob.Columns["cNombreGrupo"].HeaderText = "Nombre Grupo";
            dtgSolCredGrupAprob.Columns["cEstado"].HeaderText = "Estado";
            dtgSolCredGrupAprob.Columns["cMoneda"].HeaderText = "Moneda";
            dtgSolCredGrupAprob.Columns["nMontoSolicitado"].HeaderText = "Monto Grupal";
            dtgSolCredGrupAprob.Columns["cProducto"].HeaderText = "Producto";
            dtgSolCredGrupAprob.Columns["cNombreAsesor"].HeaderText = "Nombre Asesor";
        }
    }
}
