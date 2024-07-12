using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using LOG.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace LOG.Presentacion
{
    public partial class frmIngresosAlmacen : frmBase
    {
        #region Variables Globales

        private clsCNAlmacen cnAlmacen;
        private clsCNNotaEntrada objCNNotaEntrada;
        private clsRPTCNLogistica cnrptlogistica;

        private readonly DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;

        #endregion

        #region Constructores

        public frmIngresosAlmacen()
        {
            InitializeComponent();

            cnAlmacen = new clsCNAlmacen();
            objCNNotaEntrada = new clsCNNotaEntrada();
            cnrptlogistica = new clsRPTCNLogistica();
        }

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            dtpFecIni.Value = new DateTime(dFechaSis.Year, dFechaSis.Month, 1);
            dtpFecFin.Value = dFechaSis;
            cboAgencia.SelectedValue = clsVarGlobal.User.idAgeCol;
            txtUsuario.Text = clsVarGlobal.User.cWinUser;
            //cboAlmacenes.SelectedValue = clsVarGlobal.User.idAgeCol;
            cboAlmacenes.SelectedIndex = -1;
            ListarNotasEntrada();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            LimpiarGrids();
            ListarNotasEntrada();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmIngresoBienesAlmacen frmentrada = new frmIngresoBienesAlmacen();
            frmentrada.ShowDialog();
            ListarNotasEntrada();
        }

        private void dtgNotaEntrada_SelectionChanged(object sender, EventArgs e)
        {
            ListarDetalleNotaEntrada();
        }

        private void btnActa_Click(object sender, EventArgs e)
        {
            if (dtgNotaEntrada.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Seleccione una nota de entrada", "Reporte Nota Entrada ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];

            int idNotaEntrada = Convert.ToInt32(dtgNotaEntrada.SelectedRows[0].Cells["idNotaEntrada"].Value);

            DataTable dtNotaEntrada = cnrptlogistica.CNReporteNotaEntrada(idNotaEntrada);
            if (dtNotaEntrada.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte Nota Entrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("cRutaLogo", cRutaLogo, false));
                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("idNotaEntrada", idNotaEntrada.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();

                dtslist.Add(new ReportDataSource("dsNotaEntradaAlmacen", dtNotaEntrada));

                string reportpath = "rptNotaEntradaAlmacen.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        #endregion

        #region Metodos

        private void ListarNotasEntrada()
        {
            var lstNotaEntrada = objCNNotaEntrada.ListaNotasEntradaAgencia(Convert.ToInt32(cboAgencia.SelectedValue),
                                                                            dtpFecIni.Value, dtpFecFin.Value);

            dtgNotaEntrada.SelectionChanged -= dtgNotaEntrada_SelectionChanged;

            dtgNotaEntrada.DataSource = lstNotaEntrada.ToList();
            FormatoNotaEntrada();
            dtgNotaEntrada.ClearSelection();

            dtgNotaEntrada.SelectionChanged += dtgNotaEntrada_SelectionChanged;

            if (dtgNotaEntrada.RowCount > 0)
                dtgNotaEntrada.Rows[0].Selected = true;
        }

        private void ListarDetalleNotaEntrada()
        {
            if (dtgNotaEntrada.SelectedRows.Count > 0)
            {
                var objNotaEntrada = (clsNotaEntrada)dtgNotaEntrada.SelectedRows[0].DataBoundItem;
                var lstDetalleNotaEntrada = objCNNotaEntrada.ListDetalleNotaEntrada(objNotaEntrada.idNotaEntrada);
                dtgDetNotaEntrada.DataSource = lstDetalleNotaEntrada.ToList();
                FormatoDetalleNotaEntrada();
                MapeaNotaEntradaControles(objNotaEntrada);
            }
        }

        private void FormatoNotaEntrada()
        {
            foreach (DataGridViewColumn item in dtgNotaEntrada.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgNotaEntrada.Columns["nNroDocumento"].Visible = true;
            dtgNotaEntrada.Columns["dFechaReg"].Visible = true;
            dtgNotaEntrada.Columns["cMotivo"].Visible = true;

            dtgNotaEntrada.Columns["nNroDocumento"].HeaderText = "Documento";
            dtgNotaEntrada.Columns["dFechaReg"].HeaderText = "Fecha";
            dtgNotaEntrada.Columns["cMotivo"].HeaderText = "Motivo";

            dtgNotaEntrada.Columns["nNroDocumento"].Width = 90;
            dtgNotaEntrada.Columns["dFechaReg"].Width = 70;
            dtgNotaEntrada.Columns["cMotivo"].Width = 120;
        }

        private void FormatoDetalleNotaEntrada()
        {
            foreach (DataGridViewColumn item in dtgDetNotaEntrada.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgDetNotaEntrada.Columns["nNum"].Visible = true;
            dtgDetNotaEntrada.Columns["cProducto"].Visible = true;
            dtgDetNotaEntrada.Columns["nCantidad"].Visible = true;
            dtgDetNotaEntrada.Columns["cUnidad"].Visible = true;
            dtgDetNotaEntrada.Columns["nPrecioUnitario"].Visible = true;
            dtgDetNotaEntrada.Columns["nSubTotal"].Visible = true;
            dtgDetNotaEntrada.Columns["nTotal"].Visible = true;


            dtgDetNotaEntrada.Columns["nNum"].HeaderText = "Item";
            dtgDetNotaEntrada.Columns["cProducto"].HeaderText = "Descripción";
            dtgDetNotaEntrada.Columns["nCantidad"].HeaderText = "Cantidad";
            dtgDetNotaEntrada.Columns["cUnidad"].HeaderText = "Unidad";
            dtgDetNotaEntrada.Columns["nPrecioUnitario"].HeaderText = "P.U.";
            dtgDetNotaEntrada.Columns["nSubTotal"].HeaderText = "Sub Total";
            dtgDetNotaEntrada.Columns["nTotal"].HeaderText = "Total";

            dtgDetNotaEntrada.Columns["nNum"].DisplayIndex = 0;
            dtgDetNotaEntrada.Columns["cProducto"].DisplayIndex = 1;
            dtgDetNotaEntrada.Columns["nCantidad"].DisplayIndex = 2;
            dtgDetNotaEntrada.Columns["cUnidad"].DisplayIndex = 3;
            dtgDetNotaEntrada.Columns["nPrecioUnitario"].DisplayIndex = 4;
            dtgDetNotaEntrada.Columns["nSubTotal"].DisplayIndex = 5;
            dtgDetNotaEntrada.Columns["nTotal"].DisplayIndex = 6;

            dtgDetNotaEntrada.Columns["nNum"].FillWeight = 8;
            dtgDetNotaEntrada.Columns["cProducto"].FillWeight = 40;
            dtgDetNotaEntrada.Columns["nCantidad"].FillWeight = 12;
            dtgDetNotaEntrada.Columns["cUnidad"].FillWeight = 12;
            dtgDetNotaEntrada.Columns["nPrecioUnitario"].FillWeight = 14;
            dtgDetNotaEntrada.Columns["nSubTotal"].FillWeight = 14;
            dtgDetNotaEntrada.Columns["nTotal"].FillWeight = 14;

            dtgDetNotaEntrada.Columns["nCantidad"].DefaultCellStyle.Format = "#,0.00";
            dtgDetNotaEntrada.Columns["nPrecioUnitario"].DefaultCellStyle.Format = "#,0.00";
            dtgDetNotaEntrada.Columns["nSubTotal"].DefaultCellStyle.Format = "#,0.00";
            dtgDetNotaEntrada.Columns["nTotal"].DefaultCellStyle.Format = "#,0.00";
        }

        private void LimpiarGrids()
        {
            dtgNotaEntrada.DataSource = null;
            dtgDetNotaEntrada.DataSource = null;
            txtProveedor.Text = string.Empty;
            txtTotalNotaEntrada.Text = string.Empty;
        }

        private void MapeaNotaEntradaControles(clsNotaEntrada objNotaEntrada)
        {
            cboAlmacenes.SelectedValue = objNotaEntrada.idAlmacen;
            txtProveedor.Text = objNotaEntrada.cProveedor;
            txtTotalNotaEntrada.Text = string.Format("{0:0.00}", objNotaEntrada.nTotal);
        }

        #endregion

    }
}
