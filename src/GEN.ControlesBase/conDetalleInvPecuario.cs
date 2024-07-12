using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using CRE.CapaNegocio;
using GEN.Funciones;

namespace GEN.ControlesBase
{
    public partial class conDetalleInvPecuario : UserControl
    {
        private clsCNEvalAgrop objCapaNegocio;
        private List<clsInventarioPecuario> listInvPecuario;
        private BindingSource bsInventarioPecuario;
        private int idEvalCred;
        private int idEvalPecuaria;
        private int nMeses;
        private DateTime dFechaRegSolicitud;

        private DataGridViewRow rowVentaSeleccionado = null;
        private bool lEditandoInv = false;

        private DataTable dtTiposInventario;
        private DataTable dtEspecies;
        private DataTable dtRazas;
        private DataTable dtAnimales;
        private DataTable dtTiposCrianza;
        private DataTable dtSistemasCrianza;
        private DataTable dtProductosDerivados;
        private DataTable dtMonedas;
        private DataTable dtUnidadesMedida;


        public conDetalleInvPecuario()
        {
            InitializeComponent();
        }
        
        #region metodos

        public void inicializarControl()
        {
            this.objCapaNegocio = new clsCNEvalAgrop();
            this.listInvPecuario = new List<clsInventarioPecuario>();
            
            inicializarTablaInventario();
            FormatearDataGridView();

            this.btnNuevo.Enabled = true;
            this.btnAgregar.Enabled = false;
            this.btnQuitar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnEditar.Enabled = false;

            this.deshabilitarFormulario();
        }

        private void FormatearDataGridView()
        {
            this.dtgInventarioPecuario.Margin = new System.Windows.Forms.Padding(0);
            this.dtgInventarioPecuario.MultiSelect = false;
            this.dtgInventarioPecuario.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgInventarioPecuario.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgInventarioPecuario.RowHeadersVisible = false;
            this.dtgInventarioPecuario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgInventarioPecuario.ReadOnly = true;
        }

        private void inicializarTablaInventario()
        {
            this.bsInventarioPecuario = new BindingSource();
            this.bsInventarioPecuario.DataSource = this.listInvPecuario;
            this.dtgInventarioPecuario.DataSource = this.bsInventarioPecuario;

            this.bsInventarioPecuario.ResetBindings(false);
            this.dtgInventarioPecuario.Refresh();

            DataGridViewButtonColumn dgvbtnIngresos = new DataGridViewButtonColumn();
            dgvbtnIngresos.Name = "btnDetalles";
            dgvbtnIngresos.Text = "Detallar";
            dgvbtnIngresos.DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dgvbtnIngresos.UseColumnTextForButtonValue = true;
            this.dtgInventarioPecuario.Columns.Add(dgvbtnIngresos);

            DataGridViewButtonColumn dgvbtnValorizacion = new DataGridViewButtonColumn();
            dgvbtnValorizacion.Name = "btnValorizacion";
            dgvbtnValorizacion.Text = "Detallar";
            dgvbtnValorizacion.DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
            dgvbtnValorizacion.UseColumnTextForButtonValue = true;
            this.dtgInventarioPecuario.Columns.Add(dgvbtnValorizacion);

            foreach (DataGridViewColumn column in this.dtgInventarioPecuario.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgInventarioPecuario.Columns["cDescripcion"].DisplayIndex = 1;
            dtgInventarioPecuario.Columns["cEspecie"].DisplayIndex = 2;
            dtgInventarioPecuario.Columns["cRaza"].DisplayIndex = 3;
            dtgInventarioPecuario.Columns["cAnimal"].DisplayIndex = 4;
            dtgInventarioPecuario.Columns["cProductoDerivado"].DisplayIndex = 5;
            dtgInventarioPecuario.Columns["cUnidadMedida"].DisplayIndex = 6;
            dtgInventarioPecuario.Columns["cTipoCrianza"].DisplayIndex = 7;
            dtgInventarioPecuario.Columns["cSistemaCrianza"].DisplayIndex = 8;
            dtgInventarioPecuario.Columns["nMontoIngresos"].DisplayIndex = 9;
            dtgInventarioPecuario.Columns["nMontoEgresos"].DisplayIndex = 10;
            dtgInventarioPecuario.Columns["btnDetalles"].DisplayIndex = 11;
            dtgInventarioPecuario.Columns["nValorActual"].DisplayIndex = 12;
            dtgInventarioPecuario.Columns["btnValorizacion"].DisplayIndex = 13;

            dtgInventarioPecuario.Columns["cDescripcion"].Visible = true;
            dtgInventarioPecuario.Columns["cEspecie"].Visible = true;
            dtgInventarioPecuario.Columns["cRaza"].Visible = true;
            dtgInventarioPecuario.Columns["cAnimal"].Visible = true;
            dtgInventarioPecuario.Columns["cProductoDerivado"].Visible = true;
            dtgInventarioPecuario.Columns["cUnidadMedida"].Visible = true;
            dtgInventarioPecuario.Columns["cTipoCrianza"].Visible = true;
            dtgInventarioPecuario.Columns["cSistemaCrianza"].Visible = true;
            dtgInventarioPecuario.Columns["nMontoIngresos"].Visible = true;
            dtgInventarioPecuario.Columns["nMontoEgresos"].Visible = true;
            dtgInventarioPecuario.Columns["btnDetalles"].Visible = true;
            dtgInventarioPecuario.Columns["nValorActual"].Visible = true;
            dtgInventarioPecuario.Columns["btnValorizacion"].Visible = true;

            dtgInventarioPecuario.Columns["cDescripcion"].HeaderText = "Tipo Inventario";
            dtgInventarioPecuario.Columns["cEspecie"].HeaderText = "Especie";
            dtgInventarioPecuario.Columns["cRaza"].HeaderText = "Raza";
            dtgInventarioPecuario.Columns["cAnimal"].HeaderText = "Animal";
            dtgInventarioPecuario.Columns["cProductoDerivado"].HeaderText = "Producto Derivado";
            dtgInventarioPecuario.Columns["cUnidadMedida"].HeaderText = "Unidad Medida";
            dtgInventarioPecuario.Columns["cTipoCrianza"].HeaderText = "Tipo Crianza";
            dtgInventarioPecuario.Columns["cSistemaCrianza"].HeaderText = "Sistema Crianza";
            dtgInventarioPecuario.Columns["nMontoIngresos"].HeaderText = "Total ventas";
            dtgInventarioPecuario.Columns["nMontoEgresos"].HeaderText = "Total Costos";
            dtgInventarioPecuario.Columns["btnDetalles"].HeaderText = "Detallar";
            dtgInventarioPecuario.Columns["nValorActual"].HeaderText = "Valor Actual";
            dtgInventarioPecuario.Columns["btnValorizacion"].HeaderText = "Detallar";

            //dtgInventarioPecuario.Columns["cDescripcion"].FillWeight = 170; //30 20 
            //dtgInventarioPecuario.Columns["cUnidMedida"].FillWeight = 100;
            //dtgInventarioPecuario.Columns["nCantidad"].FillWeight = 80;
            //dtgInventarioPecuario.Columns["nPUnitVenta"].FillWeight = 100;
            //dtgInventarioPecuario.Columns["nPUnitCosto"].FillWeight = 100;
            //dtgInventarioPecuario.Columns["nTotalVentas"].FillWeight = 110;
            //dtgInventarioPecuario.Columns["nTotalCostos"].FillWeight = 110;
            //dtgInventarioPecuario.Columns["nUtilidadBruta"].FillWeight = 80;     //100
            //dtgInventarioPecuario.Columns["nMargenVentas"].FillWeight = 50;       //60
            dtgInventarioPecuario.Columns["btnDetalles"].FillWeight = 55;       //60
            dtgInventarioPecuario.Columns["btnValorizacion"].FillWeight = 55;       //60

            dtgInventarioPecuario.Columns["nMontoIngresos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgInventarioPecuario.Columns["nMontoEgresos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgInventarioPecuario.Columns["nValorActual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgInventarioPecuario.Columns["nMontoIngresos"].DefaultCellStyle.Format = "n2";
            dtgInventarioPecuario.Columns["nMontoEgresos"].DefaultCellStyle.Format = "n2";
            dtgInventarioPecuario.Columns["nValorActual"].DefaultCellStyle.Format = "n2";
        }

        public void AsignarDataTables(
            DataTable _dtTiposInventario,
            DataTable _dtEspecies,
            DataTable _dtRazas,
            DataTable _dtAnimales,
            DataTable _dtProductosDerivados,
            DataTable _dtTiposCrianza,
            DataTable _dtSistemasCrianza,
            DataTable _dtMonedas,
            DataTable _dtUnidadesMedida
        )
        {
            #region Global
            this.dtTiposInventario = _dtTiposInventario;
            this.dtEspecies = _dtEspecies;
            this.dtRazas = _dtRazas;
            this.dtAnimales = _dtAnimales;
            this.dtTiposCrianza = _dtTiposCrianza;
            this.dtSistemasCrianza = _dtSistemasCrianza;
            this.dtProductosDerivados = _dtProductosDerivados;
            this.dtMonedas = _dtMonedas;
            this.dtUnidadesMedida = _dtUnidadesMedida;


            this.cboTipoInventario.DisplayMember = "cDescripcion";
            this.cboTipoInventario.ValueMember = "nCodigo";
            this.cboTipoInventario.DataSource = this.dtTiposInventario.AsEnumerable().Where(item => Convert.ToInt32(item["nCodigo"]) == 10 || Convert.ToInt32(item["nCodigo"]) == 11).CopyToDataTable();

            this.cboEspecie.DisplayMember = "cEspecie";
            this.cboEspecie.ValueMember = "idEspecie";
            this.cboEspecie.DataSource = this.dtEspecies;

            this.cboTipoCrianza.DisplayMember = "cTipoCrianza";
            this.cboTipoCrianza.ValueMember = "idTipoCrianza";
            this.cboTipoCrianza.DataSource = this.dtTiposCrianza;

            this.cboSistemaCrianza.DisplayMember = "cSistemaCrianza";
            this.cboSistemaCrianza.ValueMember = "idSistemaCrianza";
            this.cboSistemaCrianza.DataSource = this.dtSistemasCrianza;

            this.cboMoneda.DisplayMember = "cMoneda";
            this.cboMoneda.ValueMember = "idMoneda";
            this.cboMoneda.DataSource = this.dtMonedas;

            this.cboUnidadMedida.DisplayMember = "cUnidadMedida";
            this.cboUnidadMedida.ValueMember = "idUnidadMedida";
            this.cboUnidadMedida.DataSource = this.dtUnidadesMedida;

            #endregion
            this.limpiarFormulario();
        }

        public void AsignarDatos(List<clsInventarioPecuario> _listVentasCostos, int _idEvalCred, int _nMeses, DateTime _dFechaRegSolicitud)
        {
            this.listInvPecuario.Clear();

            foreach (var item in _listVentasCostos)
            {
                this.listInvPecuario.Add(item);
            }

            this.bsInventarioPecuario.ResetBindings(false);

            this.idEvalCred = _idEvalCred;
            this.nMeses = _nMeses;
            this.dFechaRegSolicitud = _dFechaRegSolicitud;
        }

        private void RestablecerValorizacionActual(int idEvaluacionPecuaria)
        {
            this.objCapaNegocio.RestablecerValorizacionActual(idEvaluacionPecuaria);
        }
        #endregion

        private void limpiarFormulario()
        {
            this.cboTipoInventario.SelectedValue = -1;
            this.cboEspecie.SelectedValue = -1;
            this.cboRaza.SelectedValue = -1;
            this.cboAnimal.SelectedValue = -1;
            this.cboProductoDerivado.SelectedValue = -1;
            this.cboUnidadMedida.SelectedValue = -1;
            this.cboTipoCrianza.SelectedValue = -1;
            this.cboSistemaCrianza.SelectedValue = -1;
        }

        private void deshabilitarFormulario()
        {
            this.cboTipoInventario.Enabled = false;
            this.cboEspecie.Enabled = false;
            this.cboRaza.Enabled = false;
            this.cboAnimal.Enabled = false;
            this.cboProductoDerivado.Enabled = false;
            this.cboUnidadMedida.Enabled = false;
            this.cboTipoCrianza.Enabled = false;
            this.cboSistemaCrianza.Enabled = false;
        }

        private void habilitarFormulario()
        {
            this.cboTipoInventario.Enabled = true;
            this.cboEspecie.Enabled = true;
            this.cboRaza.Enabled = true;
            this.cboAnimal.Enabled = true;
            this.cboProductoDerivado.Enabled = true;
            this.cboUnidadMedida.Enabled = true;
            this.cboTipoCrianza.Enabled = true;
            this.cboSistemaCrianza.Enabled = true;
        }

        private bool validarFormulario()
        {
            if (this.cboTipoInventario.SelectedValue == null || Convert.ToInt32(this.cboTipoInventario.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar el tipo de inventario", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboTipoInventario.Focus();
                return false;
            }
            if (this.cboEspecie.SelectedValue == null || Convert.ToInt32(this.cboEspecie.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar la especie", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboEspecie.Focus();
                return false;
            }
            if (this.cboRaza.SelectedValue == null || Convert.ToInt32(this.cboRaza.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar la raza", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboRaza.Focus();
                return false;
            }
            if (this.cboAnimal.SelectedValue == null || Convert.ToInt32(this.cboAnimal.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar el animal", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboAnimal.Focus();
                return false;
            }
            if (this.cboTipoCrianza.SelectedValue == null || Convert.ToInt32(this.cboTipoCrianza.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar el tipo de crianza", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboTipoCrianza.Focus();
                return false;
            }
            if (this.cboSistemaCrianza.SelectedValue == null || Convert.ToInt32(this.cboSistemaCrianza.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar el sistema de crianza", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboSistemaCrianza.Focus();
                return false;
            }
            if (this.cboProductoDerivado.SelectedValue == null || Convert.ToInt32(this.cboProductoDerivado.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar el producto derivado", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboProductoDerivado.Focus();
                return false;
            }
            if (this.cboUnidadMedida.SelectedValue == null || Convert.ToInt32(this.cboUnidadMedida.SelectedValue) == -1)
            {
                MessageBox.Show("Debe seleccionar la unidad de medida", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboUnidadMedida.Focus();
                return false;
            }
            return true;
        }

        private void cboEspecie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cboEspecie.SelectedIndex) != -1)
            {
                DataTable dtAnimalesFiltrado = this.dtAnimales.AsEnumerable().Where(item => item.Field<int>("idEspecie") == Convert.ToInt32(cboEspecie.SelectedValue)).CopyToDataTable();
                DataTable dtRazasFiltrado = this.dtRazas.AsEnumerable().Where(item => item.Field<int>("idEspecie") == Convert.ToInt32(cboEspecie.SelectedValue)).CopyToDataTable();
                DataTable dtProdDerFiltrado = this.dtProductosDerivados.AsEnumerable().Where(item => item.Field<int>("idEspecie") == Convert.ToInt32(cboEspecie.SelectedValue)).CopyToDataTable();

                this.cboAnimal.DataSource = dtAnimalesFiltrado;
                this.cboAnimal.DisplayMember = "cAnimal";
                this.cboAnimal.ValueMember = "idAnimal";
                this.cboAnimal.SelectedValue = -1;

                this.cboRaza.DataSource = dtRazasFiltrado;
                this.cboRaza.DisplayMember = "cRaza";
                this.cboRaza.ValueMember = "idRaza";
                this.cboRaza.SelectedValue = -1;

                this.cboProductoDerivado.DataSource = dtProdDerFiltrado;
                this.cboProductoDerivado.DisplayMember = "cProductoDerivado";
                this.cboProductoDerivado.ValueMember = "idProductoDerivado";
                this.cboProductoDerivado.SelectedValue = -1;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.habilitarFormulario();
            this.btnNuevo.Enabled = false;
            this.btnAgregar.Enabled = true;
            this.btnQuitar.Enabled = false;
            this.btnCancelar.Enabled = true;
            this.btnEditar.Enabled = false;

            this.rowVentaSeleccionado = null;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!this.validarFormulario())
            {
                return;
            }
            
            int idTipoInventario = Convert.ToInt32(this.cboTipoInventario.SelectedValue);
            int idEspecie = Convert.ToInt32(this.cboEspecie.SelectedValue);
            int idRaza = Convert.ToInt32(this.cboRaza.SelectedValue);
            int idAnimal = Convert.ToInt32(this.cboAnimal.SelectedValue);
            int idProductoDerivado = Convert.ToInt32(this.cboProductoDerivado.SelectedValue);
            int idUnidadMedida = Convert.ToInt32(this.cboUnidadMedida.SelectedValue);
            int idTipoCrianza = Convert.ToInt32(this.cboTipoCrianza.SelectedValue);
            int idSistemaCrianza = Convert.ToInt32(this.cboSistemaCrianza.SelectedValue);
            int idMoneda = 1;

            DataTable ds = (new clsCNEvalPyme()).InsertarRegistroInvPecuario(
            this.idEvalCred,
            idTipoInventario,
            idEspecie,
            idRaza,
            idAnimal,
            idProductoDerivado,
            idTipoCrianza,
            idSistemaCrianza,
            idMoneda,
            idUnidadMedida);
            DataSet dsPec = (new clsCNEvalPyme()).RecuperarDetalleEstResultadosEvalPecuario(this.idEvalCred);
            var listInvPecuarioNuevo = DataTableToList.ConvertTo<clsInventarioPecuario>(dsPec.Tables[0]) as List<clsInventarioPecuario>;

            this.listInvPecuario.Clear();
            foreach (var item in listInvPecuarioNuevo)
            {
                this.listInvPecuario.Add(item);
            }

            this.bsInventarioPecuario.ResetBindings(false);
            this.limpiarFormulario();

            this.btnNuevo.Enabled = true;
            this.btnAgregar.Enabled = false;
            this.btnQuitar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnEditar.Enabled = false;

            this.deshabilitarFormulario();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.validarFormulario())
            {
                return;
            }

            /**/

            int idTipoInventario = Convert.ToInt32(this.cboTipoInventario.SelectedValue);
            int idEspecie = Convert.ToInt32(this.cboEspecie.SelectedValue);
            int idRaza = Convert.ToInt32(this.cboRaza.SelectedValue);
            int idAnimal = Convert.ToInt32(this.cboAnimal.SelectedValue);
            int idProductoDerivado = Convert.ToInt32(this.cboProductoDerivado.SelectedValue);
            int idUnidadMedida = Convert.ToInt32(this.cboUnidadMedida.SelectedValue);
            int idTipoCrianza = Convert.ToInt32(this.cboTipoCrianza.SelectedValue);
            int idSistemaCrianza = Convert.ToInt32(this.cboSistemaCrianza.SelectedValue);
            int idMoneda = 1;
            decimal nMontoIngresos = Convert.ToDecimal(this.rowVentaSeleccionado.Cells["nMontoIngresos"].Value);
            decimal nMontoEgresos = Convert.ToDecimal(this.rowVentaSeleccionado.Cells["nMontoEgresos"].Value);
            int idEvalPec = Convert.ToInt32(this.rowVentaSeleccionado.Cells["idEvaluacionPecuaria"].Value);
            int nValorActual = Convert.ToInt32(this.rowVentaSeleccionado.Cells["nValorActual"].Value);

            DataTable dt = this.objCapaNegocio.ActualizarEvaluacionPecuaria(idEvalPec,
                nMontoIngresos,
                nMontoEgresos,
                idTipoInventario,
                idEspecie,
                idRaza,
                idAnimal,
                idUnidadMedida,
                idProductoDerivado,
                idTipoCrianza,
                idSistemaCrianza,
                nValorActual
            );


            this.limpiarFormulario();
            this.deshabilitarFormulario();

            DataSet dsPec = (new clsCNEvalPyme()).RecuperarDetalleEstResultadosEvalPecuario(this.idEvalCred);
            var listInvPecuarioNuevo = DataTableToList.ConvertTo<clsInventarioPecuario>(dsPec.Tables[0]) as List<clsInventarioPecuario>;

            this.listInvPecuario.Clear();
            foreach (var item in listInvPecuarioNuevo)
            {
                this.listInvPecuario.Add(item);
            }

            this.bsInventarioPecuario.ResetBindings(false);

            this.btnNuevo.Enabled = true;
            this.btnAgregar.Enabled = false;
            this.btnQuitar.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnCancelar.Enabled = false;

            this.lEditandoInv = false;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("¿Está seguro que desea quitar el registo?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                //code for Yes
                DataTable ds = (new clsCNEvalPyme()).QuitarRegistroInvPecuario(this.idEvalPecuaria);

                DataSet dsPec = (new clsCNEvalPyme()).RecuperarDetalleEstResultadosEvalPecuario(this.idEvalCred);
                var listInvPecuarioNuevo = DataTableToList.ConvertTo<clsInventarioPecuario>(dsPec.Tables[0]) as List<clsInventarioPecuario>;
                
                this.listInvPecuario.Clear();
                foreach (var item in listInvPecuarioNuevo)
                {
                    this.listInvPecuario.Add(item);
                }

                this.bsInventarioPecuario.ResetBindings(false);

                this.btnNuevo.Enabled = true;
                this.btnAgregar.Enabled = false;
                this.btnQuitar.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
            else if (result == DialogResult.No)
            {
                //code for No
            }
            else if (result == DialogResult.Cancel)
            {
                //code for Cancel
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.deshabilitarFormulario();
            this.limpiarFormulario();
            this.dtgInventarioPecuario.ClearSelection();

            this.btnNuevo.Enabled = true;
            this.btnAgregar.Enabled = false;
            this.btnQuitar.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnCancelar.Enabled = false;

            this.lEditandoInv = false;
        }

        private void dtgInventarioPecuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == this.dtgInventarioPecuario.Columns["btnDetalles"].Index)
            {
                int idTipoInventario = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idTipoInventario"].Value);
                if (idTipoInventario == 10)
                {
                    MessageBox.Show("PLANTEL FIJO no permite llenado de ventas y costos", "Detalle de ventas y costos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.btnDetalles_Click(sender, e);
                return;
            }
            if (e.ColumnIndex == this.dtgInventarioPecuario.Columns["btnValorizacion"].Index)
            {
                this.btnValorizacion_Click(sender, e);
                return;
            }

            
            if (this.dtgInventarioPecuario.SelectedRows.Count == 0)
            {
                return;
            }

            if (this.lEditandoInv)
            {
                return;
            }

            this.rowVentaSeleccionado = this.dtgInventarioPecuario.SelectedRows[0];
            this.idEvalPecuaria = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idEvaluacionPecuaria"].Value);

            this.btnQuitar.Enabled = true;
        }

        private void dtgInventarioPecuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (this.dtgInventarioPecuario.SelectedRows.Count == 0)
            {
                return;
            }

            this.rowVentaSeleccionado = this.dtgInventarioPecuario.SelectedRows[0];
            this.idEvalPecuaria = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idEvaluacionPecuaria"].Value);

            int idTipoInventario = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idTipoInventario"].Value);
            int idEspecie = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idEspecie"].Value);
            int idRaza = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idRaza"].Value);
            int idAnimal = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idAnimal"].Value);
            int idTipoCrianza = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idTipoCrianza"].Value);
            int idSistemaCrianza = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idSistemaCrianza"].Value);
            int idUnidadMedida = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idUnidadMedida"].Value);
            int idProductoDerivado = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idProductoDerivado"].Value);
            int idMoneda = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idMoneda"].Value);


            this.cboTipoInventario.SelectedValue = idTipoInventario;
            this.cboEspecie.SelectedValue = idEspecie;
            this.cboRaza.SelectedValue = idRaza;
            this.cboAnimal.SelectedValue = idAnimal;
            this.cboTipoCrianza.SelectedValue = idTipoCrianza;
            this.cboSistemaCrianza.SelectedValue = idSistemaCrianza;
            this.cboUnidadMedida.SelectedValue = idUnidadMedida;
            this.cboProductoDerivado.SelectedValue = idProductoDerivado;
            // this.cboMoneda.SelectedValue = idMoneda;

            this.habilitarFormulario();
            this.cboTipoInventario.Enabled = false;

            this.lEditandoInv = true;
            this.btnNuevo.Enabled = false;
            this.btnAgregar.Enabled = false;
            this.btnQuitar.Enabled = false;
            this.btnEditar.Enabled = true;
            this.btnCancelar.Enabled = true;
        }

        private void btnDetalles_Click(object sender, DataGridViewCellEventArgs e)
        {
            int idEvalPec = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idEvaluacionPecuaria"].Value);

            this.lEditandoInv = false;
            this.deshabilitarFormulario();
            this.limpiarFormulario();
            this.btnNuevo.Enabled = true;
            this.btnAgregar.Enabled = false;
            this.btnQuitar.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnCancelar.Enabled = false;

            this.btnQuitar.Enabled = false;
            string cTipoInventario = Convert.ToString(this.dtgInventarioPecuario.SelectedRows[0].Cells["cDescripcion"].Value);
            string cEspecie = Convert.ToString(this.dtgInventarioPecuario.SelectedRows[0].Cells["cEspecie"].Value);
            string cRaza = Convert.ToString(this.dtgInventarioPecuario.SelectedRows[0].Cells["cRaza"].Value);
            string cAnimal = Convert.ToString(this.dtgInventarioPecuario.SelectedRows[0].Cells["cAnimal"].Value);
            string cProducto = Convert.ToString(this.dtgInventarioPecuario.SelectedRows[0].Cells["cProductoDerivado"].Value);
            string cUniMed = Convert.ToString(this.dtgInventarioPecuario.SelectedRows[0].Cells["cUnidadMedida"].Value);


            int idTipoInventario = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idTipoInventario"].Value);
            int idEspecie = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idEspecie"].Value);
            int idRaza = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idRaza"].Value);
            int idAnimal = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idAnimal"].Value);
            int idProductoDerivado = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idProductoDerivado"].Value);
            int idUnidadMedida = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idUnidadMedida"].Value);
            int idTipoCrianza = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idTipoCrianza"].Value);
            int idSistemaCrianza = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idSistemaCrianza"].Value);
            int idMoneda = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idMoneda"].Value);
            decimal nValorActual = Convert.ToDecimal(this.dtgInventarioPecuario.SelectedRows[0].Cells["nValorActual"].Value);
        

            frmDetalleActividadPecuaria frmExpEval = new frmDetalleActividadPecuaria();
            frmExpEval.EstablecerDetalleInventario(idEvalPec, this.nMeses, this.dFechaRegSolicitud, cTipoInventario, cEspecie, cRaza, cAnimal, cProducto, cUniMed, idTipoCrianza);
            frmExpEval.ShowDialog();
            /**/
            List<clsActividadPecuaria> lstMovimientosPecuario = new List<clsActividadPecuaria>();
            decimal nTotalVentas = 0;
            decimal nTotalCostos = 0;

            foreach (var item in frmExpEval.lstVentasPecuario)
            {
                lstMovimientosPecuario.Add(item);

                int nMesInicio = ((item.dMesInicio.Year - this.dFechaRegSolicitud.Year) * 12) + item.dMesInicio.Month - this.dFechaRegSolicitud.Month;
                int nLimite = this.nMeses > 12 ? 12 : this.nMeses;

                while (nMesInicio <= nLimite)
                {
                    nTotalVentas = nTotalVentas + item.nMontoTotal;
                    nMesInicio = nMesInicio + item.idPeriodoCred;
                }
            }

            foreach (var item in frmExpEval.lstCostosPecuario)
            {
                lstMovimientosPecuario.Add(item);

                int nMesInicio = ((item.dMesInicio.Year - this.dFechaRegSolicitud.Year) * 12) + item.dMesInicio.Month - this.dFechaRegSolicitud.Month;
                int nLimite = this.nMeses > 12 ? 12 : this.nMeses;

                while (nMesInicio <= nLimite)
                {
                    nTotalCostos = nTotalCostos + item.nMontoTotal;
                    nMesInicio = nMesInicio + item.idPeriodoCred;
                }
            }

            if (frmExpEval.lEditado == true)
            {
                this.objCapaNegocio.RestablecerValorizacionActual(idEvalPec);
                DataTable dt = this.objCapaNegocio.ActualizarEvaluacionPecuaria(idEvalPec,
                    nTotalVentas,
                    nTotalCostos,
                    idTipoInventario,
                    idEspecie,
                    idRaza,
                    idAnimal,
                    idUnidadMedida,
                    idProductoDerivado,
                    idTipoCrianza,
                    idSistemaCrianza,
                    0
                );
            }
            else
            {
                DataTable dt = this.objCapaNegocio.ActualizarEvaluacionPecuaria(idEvalPec,
                    nTotalVentas,
                    nTotalCostos,
                    idTipoInventario,
                    idEspecie,
                    idRaza,
                    idAnimal,
                    idUnidadMedida,
                    idProductoDerivado,
                    idTipoCrianza,
                    idSistemaCrianza,
                    nValorActual
                );
            }
            /**/

            // refrescar datos
            DataSet dsPec = (new clsCNEvalPyme()).RecuperarDetalleEstResultadosEvalPecuario(this.idEvalCred);
            var listInvPecuarioActual = DataTableToList.ConvertTo<clsInventarioPecuario>(dsPec.Tables[0]) as List<clsInventarioPecuario>;
            this.listInvPecuario.Clear();
            foreach (var item in listInvPecuarioActual)
            {
                this.listInvPecuario.Add(item);
            }
            
            this.bsInventarioPecuario.ResetBindings(false);
        }

        private void btnValorizacion_Click(object sender, DataGridViewCellEventArgs e)
        {
            int idEvalPec = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idEvaluacionPecuaria"].Value);
            int idTipoInventario = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idTipoInventario"].Value);
            int idEspecie = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idEspecie"].Value);
            int idRaza = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idRaza"].Value);
            int idAnimal = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idAnimal"].Value);
            int idProductoDerivado = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idProductoDerivado"].Value);
            int idUnidadMedida = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idUnidadMedida"].Value);
            int idTipoCrianza = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idTipoCrianza"].Value);
            int idSistemaCrianza = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idSistemaCrianza"].Value);
            int idMoneda = Convert.ToInt32(this.dtgInventarioPecuario.SelectedRows[0].Cells["idMoneda"].Value);
            decimal nTotalVentas = Convert.ToDecimal(this.dtgInventarioPecuario.SelectedRows[0].Cells["nMontoIngresos"].Value);
            decimal nTotalCostos = Convert.ToDecimal(this.dtgInventarioPecuario.SelectedRows[0].Cells["nMontoEgresos"].Value);
            decimal nValorActual = 0;

            frmValorizacionInventario frmValor = new frmValorizacionInventario(idEvalPec, idTipoInventario);
            frmValor.ShowDialog();
            nValorActual = frmValor.nValorActual;

            DataTable dt = this.objCapaNegocio.ActualizarEvaluacionPecuaria(idEvalPec,
                nTotalVentas,
                nTotalCostos,
                idTipoInventario,
                idEspecie,
                idRaza,
                idAnimal,
                idUnidadMedida,
                idProductoDerivado,
                idTipoCrianza,
                idSistemaCrianza,
                nValorActual
            );
            /**/

            // refrescar datos
            DataSet dsPec = (new clsCNEvalPyme()).RecuperarDetalleEstResultadosEvalPecuario(this.idEvalCred);
            var listInvPecuarioActual = DataTableToList.ConvertTo<clsInventarioPecuario>(dsPec.Tables[0]) as List<clsInventarioPecuario>;
            this.listInvPecuario.Clear();
            foreach (var item in listInvPecuarioActual)
            {
                this.listInvPecuario.Add(item);
            }

            this.bsInventarioPecuario.ResetBindings(false);
        }

        private void conDetalleInvPecuario_Load(object sender, EventArgs e)
        {
            // this.inicializarControl();
        }

    }
}
