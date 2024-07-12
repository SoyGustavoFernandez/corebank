using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;

namespace CRE.Presentacion
{
    public partial class frmPaqueteSeguro : frmBase
    {
        clsCNPaqueteSeguro PaqueteSeguro = new clsCNPaqueteSeguro();
        clsMantenimientoPaqueteSeguro objPaqueteSeguro = new clsMantenimientoPaqueteSeguro();
        clsMantenimientoPaqueteSeguro _clsMantenimientoPaqueteSeguro = new clsMantenimientoPaqueteSeguro();
        List<clsMantenimientoPaqueteSeguro> clsMantenimientoPaqueteSeguro = new List<clsMantenimientoPaqueteSeguro>();
        public int idPaqSegSeguro, nfilaseleccionada;

        public frmPaqueteSeguro()
        {
            InitializeComponent();
        }
        private void frmPaqueteSeguro_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            cboDetalleGasto1.listarDetalleGastoEnSolicitud();
            cboDetalleGasto1.SelectedIndex = 0;
            cboDetalleGasto1.SelectedIndexChanged += cboDetalleGasto1_SelectedIndexChanged;
            btnMiniEditar1.Enabled = false;
            btnMiniAgregar1.Enabled = true;
            cboEstadoVigencia1.Cargar();
            cboEstadoVigencia1.SelectedValue = -1;
            dtpFechaIncio.Format = DateTimePickerFormat.Custom;            
            dtpFechaIncio.CustomFormat = "dd/MM/yyyy";
            dtpFechaIncio.Value = DateTime.Now.AddDays(-120);
            dtpFechaFin.Format = DateTimePickerFormat.Custom;
            dtpFechaFin.CustomFormat = "dd/MM/yyyy";
            dtpFechaFin.Value = DateTime.Now;
        }
        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
             try
            {
                _clsMantenimientoPaqueteSeguro.idDetalleGasto = Convert.ToInt32(cboDetalleGasto1.SelectedValue.ToString());
            }
            catch (Exception)
            {
                _clsMantenimientoPaqueteSeguro.idDetalleGasto = 0;
            }
            try
            {
                if (Convert.ToInt32(cboEstadoVigencia1.SelectedValue) ==-1)
                {                    
                    _clsMantenimientoPaqueteSeguro.nFiltro = 0;
                }
                else
                {   _clsMantenimientoPaqueteSeguro.cEstado = Convert.ToBoolean(cboEstadoVigencia1.SelectedValue);
                    _clsMantenimientoPaqueteSeguro.nFiltro = 1;
                }                  
            }
            catch (Exception)
            {
                _clsMantenimientoPaqueteSeguro.cEstado = true;
            }
            _clsMantenimientoPaqueteSeguro.dFechaRegistro = Convert.ToDateTime(dtpFechaIncio.Text);
            _clsMantenimientoPaqueteSeguro.dFechaFinRegistro = Convert.ToDateTime(dtpFechaFin.Text);
            _clsMantenimientoPaqueteSeguro.cNombreCompleto = txtPlanPaqueteSeguro.Text;

            llenarGridPaqueteSeguro();
            btnMiniEditar1.Enabled = true;
        }
        private void cboDetalleGasto1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void llenarGridPaqueteSeguro()
        {
            try
            {
                clsMantenimientoPaqueteSeguro.Clear();
                clsMantenimientoPaqueteSeguro.AddRange(PaqueteSeguro.CNListarPaqueteSeguro(_clsMantenimientoPaqueteSeguro).ToList<clsMantenimientoPaqueteSeguro>());
                int order = 1;
                foreach (clsMantenimientoPaqueteSeguro item in clsMantenimientoPaqueteSeguro)
                {
                    item.orden = order;
                    order++;
                }
                dtgListaPaqueteSeguro.DataSource = clsMantenimientoPaqueteSeguro;
                BindingSource BindingSourcePaqueteSeguro = new BindingSource();
                BindingSourcePaqueteSeguro.DataSource = clsMantenimientoPaqueteSeguro;
                dtgListaPaqueteSeguro.DataSource = BindingSourcePaqueteSeguro;
                dtgListaPaqueteSeguro.ScrollBars = ScrollBars.Both;
                dtgListaPaqueteSeguro.AutoResizeColumns();
                dtgListaPaqueteSeguro.ClearSelection();
                styleGridPaqueteSeguro();
                dtgListaPaqueteSeguro.Refresh();
            }
            catch (Exception)
            {
                return;
            }
        }
        public void styleGridPaqueteSeguro()
        {
            foreach (DataGridViewColumn columna in dtgListaPaqueteSeguro.Columns)
            {
                columna.Visible = false;
            }
            dtgListaPaqueteSeguro.Columns["orden"].Visible = true;
            dtgListaPaqueteSeguro.Columns["cNombreCompleto"].Visible = true;
            dtgListaPaqueteSeguro.Columns["nPrecio"].Visible = true;
            dtgListaPaqueteSeguro.Columns["cEstado"].Visible = true;
            dtgListaPaqueteSeguro.Columns["orden"].DisplayIndex = 0;
            dtgListaPaqueteSeguro.Columns["cNombreCompleto"].DisplayIndex = 1;
            dtgListaPaqueteSeguro.Columns["nPrecio"].DisplayIndex = 2;
            dtgListaPaqueteSeguro.Columns["cEstado"].DisplayIndex = 3;
            dtgListaPaqueteSeguro.Columns["orden"].HeaderText = "Orden";
            dtgListaPaqueteSeguro.Columns["cNombreCompleto"].HeaderText = "Nombre";
            dtgListaPaqueteSeguro.Columns["nPrecio"].HeaderText = "Precio";
            dtgListaPaqueteSeguro.Columns["cEstado"].HeaderText = "Estado";
            dtgListaPaqueteSeguro.Columns["orden"].Width = 40;
            dtgListaPaqueteSeguro.Columns["cNombreCompleto"].Width = 350;
            dtgListaPaqueteSeguro.Columns["nPrecio"].Width = 50;
            dtgListaPaqueteSeguro.Columns["cEstado"].Width = 50;
        }
        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            objPaqueteSeguro = new clsMantenimientoPaqueteSeguro();
            frmMantenimientoPaqueteSeguros frmMantenimientoPaqueteSeguros = new frmMantenimientoPaqueteSeguros();
            objPaqueteSeguro.idDetalleGasto = Convert.ToInt32(cboDetalleGasto1.SelectedValue);
            frmMantenimientoPaqueteSeguros.asignarDatos(objPaqueteSeguro);
            frmMantenimientoPaqueteSeguros.ShowDialog();
            llenarGridPaqueteSeguro();
        }
        private void btnMiniEditar1_Click(object sender, EventArgs e)
        {
            if (dtgListaPaqueteSeguro.CurrentRow == null)
            {
                MessageBox.Show("No se ha seleccionado un registro para editar", "Planes de Seguro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                objPaqueteSeguro = new clsMantenimientoPaqueteSeguro();
                nfilaseleccionada = Convert.ToInt32(dtgListaPaqueteSeguro.CurrentCell.RowIndex);
                var celdaSeleccionada = dtgListaPaqueteSeguro.Rows[nfilaseleccionada].Cells["idPaqueteSeguro"];
                var detalleSeguro = dtgListaPaqueteSeguro.Rows[nfilaseleccionada].Cells["idDetalleGasto"];
                objPaqueteSeguro.idPaqueteSeguro = Convert.ToInt32(celdaSeleccionada.Value);
                objPaqueteSeguro.idDetalleGasto = Convert.ToInt32(detalleSeguro.Value);
                frmMantenimientoPaqueteSeguros frmMantenimientoPaqueteSeguros = new frmMantenimientoPaqueteSeguros();                
                frmMantenimientoPaqueteSeguros.asignarDatos(objPaqueteSeguro);
                frmMantenimientoPaqueteSeguros.ShowDialog();
                llenarGridPaqueteSeguro();
            }
        }
    }
}