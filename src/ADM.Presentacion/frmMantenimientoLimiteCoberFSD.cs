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
using ADM.CapaNegocio;
using EntityLayer;


namespace ADM.Presentacion
{
    public partial class frmMantenimientoLimiteCoberFSD : frmBase
    {
        

        public frmMantenimientoLimiteCoberFSD()
        {
            InitializeComponent();
        }

        private void frmMantenimientoLimiteCoberFSD_Load(object sender, EventArgs e)
        {
            dtLimCoberFSD.Rows.Clear();
            dtLimCoberFSD = cnLimCoberFSD.ListarLimiteCoberFSD(0);
            if (dtLimCoberFSD.Rows.Count > 0)
            {
                dtgLimiteCoberFSD.DataSource = dtLimCoberFSD;
                MostrarGrid();
            }

            DateTime dFecNueIni;
            DateTime dFecNueFin;
            dFecNueIni = Convert.ToDateTime(clsVarGlobal.dFecSystem.Date);
            dFecNueFin = dFecNueIni.AddDays(1);
            dtFechaInicioFSD.Value = dFecNueIni;
            dtFechaFinFSD.Value = dFecNueFin;

            grbAsignarFSD.Enabled = false;
            btnCancelar1.Enabled = false;
            btnGrabar1.Enabled = false;
        }

        #region Variables

        clsCNMantLimiteCoberFSD cnLimCoberFSD = new clsCNMantLimiteCoberFSD();
        DataTable dtLimCoberFSD = new DataTable();
        Transaccion operacion = Transaccion.Selecciona;

        #endregion

        #region Eventos
        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            dtLimCoberFSD = cnLimCoberFSD.BuscarLimiteCoberFSD(dtBuscarFechaInicioFSD.Value, dtBuscarFechaFinFSD.Value);
            if (dtLimCoberFSD.Rows.Count > 0)
            {
                dtgLimiteCoberFSD.DataSource = dtLimCoberFSD;
                MostrarGrid();
            }
            else
                MessageBox.Show("No se encontraron Datos", "Busqueda de Cobertura de Limite FSD", MessageBoxButtons.OK, MessageBoxIcon.Error);

            grbBuscarFSD.Enabled = true;
            grbAsignarFSD.Enabled = false;
            dtgLimiteCoberFSD.Enabled = true;
            btnNuevo1.Enabled = true;
            btnGrabar1.Enabled = false;
            btnEditar1.Enabled = true;
            btnCancelar1.Enabled = false;
        }
        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            operacion = Transaccion.Nuevo;
            dtLimCoberFSD = cnLimCoberFSD.ObtenerUltimaFecha();
            if (dtLimCoberFSD.Rows.Count > 0)
            {
                DateTime dUltimaFecha = Convert.ToDateTime(dtLimCoberFSD.Rows[0][0]);
                dtFechaInicioFSD.Value = dUltimaFecha.AddDays(1).Date;
                dtFechaFinFSD.Value = dtFechaInicioFSD.Value.AddDays(1).Date;
            }

            dtLimCoberFSD.Rows.Clear();

            dtFechaInicioFSD.Focus();
            grbBuscarFSD.Enabled = false;
            grbAsignarFSD.Enabled = true;
            dtFechaInicioFSD.Enabled = true;
            dtFechaFinFSD.Enabled = true;
            dtgLimiteCoberFSD.Enabled = true;
            btnNuevo1.Enabled = false;
            btnGrabar1.Enabled = true;
            btnEditar1.Enabled = false;
            btnCancelar1.Enabled = true;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            int lvigencia = chcVigencia.Checked ? 1 : 0;

            if (operacion == Transaccion.Nuevo)
            {
                dtLimCoberFSD = cnLimCoberFSD.ObtenerUltimaFecha();
                DateTime dUltimaFecha = Convert.ToDateTime(dtLimCoberFSD.Rows[0][0]);
                if (dtFechaInicioFSD.Value >= dUltimaFecha && dtFechaFinFSD.Value > dtFechaInicioFSD.Value)
                {
                    cnLimCoberFSD.insertarLimiteCoberFSD(dtFechaInicioFSD.Value, dtFechaFinFSD.Value, txtMontoMaxFSD.nDecValor, lvigencia);
                    MessageBox.Show("Se registro correctamente el Limite de Cobertura FSD", "Registro Limite de Cobertura FSD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Rango de Fecha no permitida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMontoMaxFSD.Text = " ";
                    chcVigencia.Checked=false;

            }

            if (operacion == Transaccion.Edita)
            {
                cnLimCoberFSD.actualizarLimiteCoberFSD(Convert.ToInt32(dtgLimiteCoberFSD.CurrentRow.Cells["idLimiteFSD"].Value), dtFechaInicioFSD.Value, dtFechaFinFSD.Value, txtMontoMaxFSD.nDecValor, lvigencia);
                MessageBox.Show("Se actualizó correctamente el Limite de Cobertura FSD", "Actualiza Limite de Cobertura FSD", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dtLimCoberFSD.Rows.Clear();
            dtLimCoberFSD = cnLimCoberFSD.ListarLimiteCoberFSD(0);
            if (dtLimCoberFSD.Rows.Count > 0)
            {
                dtgLimiteCoberFSD.DataSource = dtLimCoberFSD;
                MostrarGrid();
            }

            grbBuscarFSD.Enabled = true;
            grbAsignarFSD.Enabled = false;
            dtgLimiteCoberFSD.Enabled = true;
            btnNuevo1.Enabled = true;
            btnGrabar1.Enabled = false;
            btnEditar1.Enabled = true;
            btnCancelar1.Enabled = false;
            txtMontoMaxFSD.Text = " ";

        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            operacion = Transaccion.Edita;
            var filaSeleccionada = dtgLimiteCoberFSD.SelectedRows[0];
            DateTime dFechaSistema = Convert.ToDateTime(clsVarGlobal.dFecSystem.Date);
            DateTime dFechaInicial = Convert.ToDateTime(filaSeleccionada.Cells["dFechaInicial"].Value);
            DateTime dFechaFinal = Convert.ToDateTime(filaSeleccionada.Cells["dFechaFinal"].Value);
            //Si la fecha es mayor a la del sistemas se puede editar
            if (dFechaSistema < dFechaFinal)
            {
                dtFechaInicioFSD.Value = Convert.ToDateTime(filaSeleccionada.Cells["dFechaInicial"].Value);
                dtFechaFinFSD.Value = Convert.ToDateTime(filaSeleccionada.Cells["dFechaFinal"].Value);
                txtMontoMaxFSD.Text = filaSeleccionada.Cells["nMaxCoberFSD"].Value.ToString();

                if (Convert.ToInt32(filaSeleccionada.Cells["lVigente"].Value) == 1)
                {
                    chcVigencia.Checked = true;
                }
                else
                    chcVigencia.Checked = false;

                grbBuscarFSD.Enabled = false;
                grbAsignarFSD.Enabled = true;
                dtFechaInicioFSD.Enabled = true;
                dtFechaFinFSD.Enabled = true;
                txtMontoMaxFSD.Enabled = true;
                dtgLimiteCoberFSD.Enabled = false;
                btnNuevo1.Enabled = false;
                btnGrabar1.Enabled = true;
                btnEditar1.Enabled = false;
                btnCancelar1.Enabled = true;
            }

            //Si la fecha es menor a la del sistemas NO se puede editar
            else if (dFechaSistema > dFechaInicial && dFechaFinal < dFechaSistema)
            {
                MessageBox.Show("No se Puede editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grbAsignarFSD.Enabled = false;
                grbBuscarFSD.Enabled = true;
                dtgLimiteCoberFSD.Enabled = true;
                btnNuevo1.Enabled = true;
                btnGrabar1.Enabled = false;
                btnEditar1.Enabled = true;
                btnCancelar1.Enabled = false;
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            txtMontoMaxFSD.Text = " ";
            grbBuscarFSD.Enabled = true;
            grbAsignarFSD.Enabled = false;
            dtgLimiteCoberFSD.Enabled = true;
            btnNuevo1.Enabled = true;
            btnGrabar1.Enabled = false;
            btnEditar1.Enabled = true;
            btnCancelar1.Enabled = false;
        }

        #endregion

        #region Metodos
        private void MostrarGrid()
        {
            foreach (DataGridViewColumn item in dtgLimiteCoberFSD.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgLimiteCoberFSD.Columns["idLimiteFSD"].Visible = false;

            dtgLimiteCoberFSD.Columns["dFechaInicial"].HeaderText = "Fecha Inicial";
            dtgLimiteCoberFSD.Columns["dFechaFinal"].HeaderText = "Fecha Final";
            dtgLimiteCoberFSD.Columns["nMaxCoberFSD"].HeaderText = "Monto Maximo";
            dtgLimiteCoberFSD.Columns["lVigente"].HeaderText = "Vigente";

            dtgLimiteCoberFSD.Columns["dFechaInicial"].DisplayIndex = 1;
            dtgLimiteCoberFSD.Columns["dFechaFinal"].DisplayIndex = 2;
            dtgLimiteCoberFSD.Columns["nMaxCoberFSD"].DisplayIndex = 3;
            dtgLimiteCoberFSD.Columns["lVigente"].DisplayIndex = 4;

            dtgLimiteCoberFSD.Columns["dFechaInicial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgLimiteCoberFSD.Columns["dFechaFinal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgLimiteCoberFSD.Columns["nMaxCoberFSD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgLimiteCoberFSD.Columns["lVigente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgLimiteCoberFSD.Columns["dFechaInicial"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgLimiteCoberFSD.Columns["dFechaFinal"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgLimiteCoberFSD.Columns["nMaxCoberFSD"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgLimiteCoberFSD.Columns["lVigente"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        #endregion

    }
}
