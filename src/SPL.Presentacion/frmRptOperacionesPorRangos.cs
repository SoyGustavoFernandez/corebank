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
using SPL.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace SPL.Presentacion
{
    public partial class frmRptOperacionesPorRangos : frmBase
    {
        clsCNOperacionesMultiples cnOpeMult = new clsCNOperacionesMultiples();
        DateTime dFechaInicio;
        DateTime dFechaFin;
        int idCli = 0;
        string cTitulo = "Reporte de operaciones por rangos mayor a $.7000";

        public frmRptOperacionesPorRangos()
        {
            InitializeComponent();
            limpiar();
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            if (dtpdFechaInicio.Value > dtpdFechaFin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if(txtnMontoDolares.nDecValor<7000)
            {
                MessageBox.Show("El monto debe ser mayor a $.7000", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            dFechaInicio = dtpdFechaInicio.Value;
            dFechaFin = dtpdFechaFin.Value;
            DataTable dtOpeRangos = cnOpeMult.CNRptOperacionPorRango(dFechaInicio, dFechaFin, txtnMontoDolares.nDecValor);
            if (dtOpeRangos.Rows.Count == 0)
            {
                MessageBox.Show("No hay resultados para estos filtros", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            dtgClientesRango.DataSource = dtOpeRangos;
            activarFiltros(false);

            formatoGridClientes();
        }

        private void activarFiltros(Boolean lBol)
        {
            dtpdFechaInicio.Enabled = lBol;
            dtpdFechaFin.Enabled = lBol;
            txtnMontoDolares.Enabled = lBol;
            btnBusqueda1.Enabled = lBol;
            btnImprimir1.Enabled = !lBol;
            btnImprimir2.Enabled = !lBol;
        }

        private void limpiar()
        {
            dtpdFechaInicio.Value = clsVarGlobal.dFecSystem;
            dtpdFechaFin.Value = clsVarGlobal.dFecSystem;
            txtnMontoDolares.Text = Convert.ToDecimal(7000).ToString();
            txtnTotal.Text = Convert.ToDecimal(0).ToString();
            if (dtgClientesRango.DataSource != null)
                ((DataTable)dtgClientesRango.DataSource).Clear();

            if (dtgDetalleOperaciones.DataSource != null)
                ((DataTable)dtgDetalleOperaciones.DataSource).Clear();

        }
        private void formatoGridClientes()
        {
            foreach (DataGridViewColumn item in dtgClientesRango.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dtgClientesRango.Columns["cCodCliente"].HeaderText = "Código Cliente";
            dtgClientesRango.Columns["cNombre"].HeaderText = "Nombre Cliente";
            dtgClientesRango.Columns["nMontoDolares"].HeaderText = "Monto en Dolares";
            dtgClientesRango.Columns["dFechaInicio"].HeaderText = "Fecha Inicio";
            dtgClientesRango.Columns["dFechaFin"].HeaderText = "Fecha Fin";
            
            dtgClientesRango.Columns["nTipoCambioSplaft"].Visible = false;
            dtgClientesRango.Columns["idCli"].Visible = false;
            dtgClientesRango.Columns["nMontoDolares"].DefaultCellStyle.Format = "N2";
        }
        private void formatoGridDetalle()
        {
            foreach (DataGridViewColumn item in dtgDetalleOperaciones.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dtgDetalleOperaciones.Columns["IdKardex"].HeaderText = "Nro. Operación";
            dtgDetalleOperaciones.Columns["nMontoDolares"].Visible = false;

            dtgDetalleOperaciones.Columns["cCodCliente"].HeaderText = "Código Cliente";
            dtgDetalleOperaciones.Columns["cMotivoOperacion"].HeaderText = "Operación";
            dtgDetalleOperaciones.Columns["cTipoOperacion"].HeaderText = "Tipo Operación";
            dtgDetalleOperaciones.Columns["nMontoOriginal"].HeaderText = "Monto";
            dtgDetalleOperaciones.Columns["cMoneda"].HeaderText = "Moneda";
            dtgDetalleOperaciones.Columns["cNombreAgencia"].HeaderText = "Agencia";
            dtgDetalleOperaciones.Columns["cWinUser"].HeaderText = "Usuario";
            dtgDetalleOperaciones.Columns["cModulo"].HeaderText = "Modulo";

            dtgDetalleOperaciones.Columns["nMontoOriginal"].DefaultCellStyle.Format = "N2";
        }
        private void btnDetalle1_Click(object sender, EventArgs e)
        {
            if (dtgClientesRango.RowCount == 0)
            {
                MessageBox.Show("No se ha encontrado un cliente seleccionado", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            idCli = Convert.ToInt32(dtgClientesRango.SelectedRows[0].Cells["idCli"].Value);
            DataTable dtDetalle = cnOpeMult.CNDetalleOperacionesRangos(dFechaInicio, dFechaFin, txtnMontoDolares.nDecValor, idCli);

            dtgDetalleOperaciones.DataSource = dtDetalle;
            formatoGridDetalle();
            txtnTotal.Text = "0";
            sumarTotal();
        }

        private void sumarTotal()
        {
            DataTable dtCount = ((DataTable)dtgDetalleOperaciones.DataSource);
            decimal nTotal = 0;
            foreach (DataRow item in dtCount.Rows)
	        {
                nTotal += Convert.ToDecimal(item["nMontoDolares"]);
	        }
            txtnTotal.Text = nTotal.ToString("N2");
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (dtgDetalleOperaciones.RowCount == 0)
            {
                MessageBox.Show("No se encontró detalle de operaciones", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (idCli == 0)
            {
                MessageBox.Show("No se ha seleccionado a un cliente", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataTable dtCli = ((DataTable)dtgClientesRango.DataSource);
            DataTable dtTemp = dtCli.Clone();
            foreach (DataRow item in dtCli.Rows)
            {
                if (Convert.ToInt32(item["idCli"]) == idCli)
                {
                    dtTemp.ImportRow(item);
                }
            }
            string reportpath = "rptOperacionesRangoMayores7000.rdlc";

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string AgenEmision = clsVarApl.dicVarGen["cNomAge"];

            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            paramlist.Add(new ReportParameter("cNomAgen", AgenEmision, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaInicio", dFechaInicio.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFechaFin", dFechaFin.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("nMontoDolares", txtnMontoDolares.Text, false));
            paramlist.Add(new ReportParameter("cRutaLogo", Convert.ToString(clsVarApl.dicVarGen["CRUTALOGO"]), false));

            dtslist.Add(new ReportDataSource("dsDetalleOperaRango", ((DataTable)dtgDetalleOperaciones.DataSource)));
            dtslist.Add(new ReportDataSource("dsOperacionCli", dtTemp));


            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void btnImprimir2_Click(object sender, EventArgs e)
        {
            if (dtgClientesRango.RowCount == 0)
            {
                MessageBox.Show("No se encontró clientes que pasaron el rango", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dtCli = ((DataTable)dtgClientesRango.DataSource);
            DataTable dtTemp = dtCli.Clone();
            foreach (DataRow item in dtCli.Rows)
            {
                if (Convert.ToInt32(item["idCli"]) == idCli)
                {
                    dtTemp.ImportRow(item);
                }
            }
            string reportpath = "rptOperacionesRangoClientes.rdlc";

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string AgenEmision = clsVarApl.dicVarGen["cNomAge"];

            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            paramlist.Add(new ReportParameter("cNomAgen", AgenEmision, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaInicio", dFechaInicio.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFechaFin", dFechaFin.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("nMontoDolares", txtnMontoDolares.Text, false));
            paramlist.Add(new ReportParameter("cRutaLogo", Convert.ToString(clsVarApl.dicVarGen["CRUTALOGO"]), false));

            dtslist.Add(new ReportDataSource("dsOperacionRango", ((DataTable)dtgClientesRango.DataSource)));


            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiar();
            activarFiltros(true);
        }

        private void dtgClientesRango_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgClientesRango.RowCount == 0)
            {
                MessageBox.Show("No se ha encontrado un cliente seleccionado", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dtgClientesRango.SelectedRows.Count == 0)
            {
                return;
            }

            idCli = Convert.ToInt32(dtgClientesRango.SelectedRows[0].Cells["idCli"].Value);
            DataTable dtDetalle = cnOpeMult.CNDetalleOperacionesRangos(dFechaInicio, dFechaFin, txtnMontoDolares.nDecValor, idCli);

            if (dtDetalle.Rows.Count == 0)
            {
                MessageBox.Show("No se ha encontraron datos de operaciones multiples para el cliente", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ((DataTable)dtgDetalleOperaciones.DataSource).Clear();
                return;
            }

            dtgDetalleOperaciones.DataSource = dtDetalle;
            formatoGridDetalle();
            txtnTotal.Text = "0";
            sumarTotal();
        }
    }
}
