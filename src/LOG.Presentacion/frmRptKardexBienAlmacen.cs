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
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.LibreriaOffice;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using LOG.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;


namespace LOG.Presentacion
{
    public partial class frmRptKardexBienAlmacen : frmBase
    {
        private int nTipBusqueda = 0;
        public frmRptKardexBienAlmacen()
        {
            InitializeComponent();
        }

        private void frmRptKardexBienAlmacen_Load(object sender, EventArgs e)
        {
            dtpFechaIni.Value = clsVarGlobal.dFecSystem;
            dtpFechaFin.Value = clsVarGlobal.dFecSystem;
            cboTipoBien.cargarTipoBien(0, true);
            cboTipoBien.SelectedValue = 0;

            if (clsVarGlobal.nIdAgencia == 1)
            {
                cboAgencia.Enabled = true;
            }
            else
            {
                cboAgencia.SelectedValue = clsVarGlobal.nIdAgencia;
                cboAgencia.Enabled = false;
            }
        }

        private void cboTipoBien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoBien.SelectedIndex > 0)
            {
                this.cboSubTipoBien.ListarGrupo(0, Convert.ToInt32(this.cboTipoBien.SelectedValue), true);
            }
            else
            {
                this.cboSubTipoBien.SelectedValue = 0;
                this.cboGrupoBien.SelectedValue = 0;
                this.cboSubGrupo.SelectedValue = 0;
            }
        }

        private void cboSubTipoBien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboSubTipoBien.SelectedIndex > 0)
            {
                this.cboGrupoBien.ListarGrupo(Convert.ToInt32(this.cboSubTipoBien.SelectedValue), Convert.ToInt32(this.cboTipoBien.SelectedValue), true);
            }
            else
            {
                this.cboGrupoBien.SelectedValue = 0;
                this.cboSubGrupo.SelectedValue = 0;
            }
        }

        private void cboGrupoBien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboGrupoBien.SelectedIndex > 0)
            {
                this.cboSubGrupo.ListarGrupo(Convert.ToInt32(this.cboGrupoBien.SelectedValue), Convert.ToInt32(this.cboTipoBien.SelectedValue), true);
            }
            else
            {
                this.cboSubGrupo.SelectedValue = 0;
            }
        }

        private void cboAgencia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencia.SelectedIndex >= 0)
            {
                cboAlmacen.CargarAlmacen((int)cboAgencia.SelectedValue);
            }
        }

        public void CargarAlmacen(int idAgencia)
        {
            DataTable dtAlmacen = new clsCNAlmacen().CNListarAlmacenAgencia(idAgencia);
            cboAlmacen.DataSource = dtAlmacen;
            cboAlmacen.ValueMember = dtAlmacen.Columns[0].ToString();
            cboAlmacen.DisplayMember = dtAlmacen.Columns[1].ToString();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            clsRPTCNLogistica objLogistica = new clsRPTCNLogistica();
            DataTable dtKardexBienAlmacen;

            DateTime dFecha = clsVarGlobal.dFecSystem;
            DateTime dFechaIni = dtpFechaIni.Value;
            DateTime dFechaFin = dtpFechaFin.Value;
            int idAlmacen = (int)cboAlmacen.SelectedValue;
            string cAlmacen = cboAlmacen.Text;

            int idCatalogo = 0;
            if (dtgDetalleCatalogo.Rows.Count > 0 && dtgDetalleCatalogo.SelectedRows.Count > 0)
            {
                int rowIndex = dtgDetalleCatalogo.CurrentCell.RowIndex;
                idCatalogo = Convert.ToInt32(dtgDetalleCatalogo.Rows[rowIndex].Cells["idCatalogo"].Value);
            }

            int idTipoBien = 0, idGrupo = 0, idSubGrupo = 0, idRubro = 0;
            if (cboSubTipoBien.SelectedIndex > 0)
            {
                idGrupo = (int)cboSubTipoBien.SelectedValue;
            }

            if (cboGrupoBien.SelectedIndex > 0)
            {
                idSubGrupo = (int)cboGrupoBien.SelectedValue;
            }

            if (cboSubGrupo.SelectedIndex > 0)
            {
                idRubro = (int)cboSubGrupo.SelectedValue;
            }

            dtKardexBienAlmacen = objLogistica.CNKardexBienPorAlmacen(dFechaIni, dFechaFin, idAlmacen, (int)cboTipoBien.SelectedValue, idGrupo, idSubGrupo, idRubro, idCatalogo);

            if (dtKardexBienAlmacen.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();

                dtsList.Add(new ReportDataSource("dsKardexBienAlmacen", dtKardexBienAlmacen));

                List<ReportParameter> paramList = new List<ReportParameter>();

                paramList.Add(new ReportParameter("cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                paramList.Add(new ReportParameter("cNomAgencia", clsVarApl.dicVarGen["cNomAge"], false));
                paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                paramList.Add(new ReportParameter("dFechaInicio", dFechaIni.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("dFechaFin", dFechaFin.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("idAlmacen", idAlmacen.ToString(), false));
                paramList.Add(new ReportParameter("cAlmacen", cAlmacen, false));
                paramList.Add(new ReportParameter("idRubro", "0", false));

                string reportPath = "rptKardexBienPorAlmacen.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos", "Reporte de Saldos por Almacen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool Validar()
        {
            if (cboAgencia.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la agencia.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboAlmacen.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el almacén.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dtpFechaFin.Value.Date < dtpFechaIni.Value.Date)
            {
                MessageBox.Show("La fecha final no puede ser anterior a la fecha inicial.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void BuscarCatalogo()
        {
            List<clsCatalogo> LstCatalogo;
            string cFiltro = this.txtBuscar.Text;

            LstCatalogo = new clsCNCatalogo().CNBuscarCatalogoxGrupo(cFiltro, Convert.ToInt32(cboAlmacen.SelectedValue), 0, 0, 0, Convert.ToInt32(cboSubGrupo.SelectedValue), 0);
                if (LstCatalogo.Count > 0)
                {
                    this.dtgDetalleCatalogo.DataSource = LstCatalogo;
                    Formatogrid();
                    dtgDetalleCatalogo.ClearSelection();
                }
        }

        private void Formatogrid()
        {
            
                foreach (DataGridViewColumn column in dtgDetalleCatalogo.Columns)
                {
                    column.Visible = false;
                }

                dtgDetalleCatalogo.Columns["idCatalogo"].Visible = true;
                dtgDetalleCatalogo.Columns["cNombreGrupo"].Visible = true;
                dtgDetalleCatalogo.Columns["cProducto"].Visible = true;

                dtgDetalleCatalogo.Columns["idCatalogo"].HeaderText = "Código";
                dtgDetalleCatalogo.Columns["cNombreGrupo"].HeaderText = "Descripción";
                dtgDetalleCatalogo.Columns["cProducto"].HeaderText = "Bien/Servicio";

                dtgDetalleCatalogo.Columns["idCatalogo"].Width = 50;
                dtgDetalleCatalogo.Columns["cNombreGrupo"].Width = 200;
                dtgDetalleCatalogo.Columns["cProducto"].Width = 200;
            }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BuscarCatalogo();
            }
        }

        private void cboSubGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)(cboSubGrupo.SelectedValue) > 0)
            {
                BuscarCatalogo();
                this.txtBuscar.Enabled = true;
            }
            else
            {
                this.dtgDetalleCatalogo.DataSource = null;
            }
        }

    }
}
