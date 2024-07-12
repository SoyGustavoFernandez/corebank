using GEN.CapaNegocio;
using GEN.ControlesBase;
using SPL.CapaNegocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPL.Presentacion
{
    public partial class frmMantenimientoProductos : frmBase
    {
        #region Varibles globales
        clsCNMapeoRiesgoYOpeInusual cnmapeoriesgoyopeinusual = new clsCNMapeoRiesgoYOpeInusual();
        clsCNProducto cnproductoAsociado = new clsCNProducto();
        String cTipoOperacion = "N";
        int idProductoRiesgo = 0;
        String cIdsProdAsoc = String.Empty;
        String cTituloMensajes = "Mantenimiento de productos";
        DataTable dtProdAsociado;
        #endregion
        public frmMantenimientoProductos()
        {
            InitializeComponent();
        }
        #region Eventos
        private void frmMantenimientoProductos_Load(object sender, EventArgs e)
        {
            this.cboTipoProd.SelectedIndexChanged -= new EventHandler(cboTipoProd_SelectedIndexChanged);
            cargaCboTipoProd();
            this.cboTipoProd.SelectedIndexChanged += new EventHandler(cboTipoProd_SelectedIndexChanged);
            cargarProductos(Convert.ToInt32( this.cboTipoProd.SelectedValue));            
            habilitarControles(false);
        }
        private void cboTipoProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarProductos(Convert.ToInt32(this.cboTipoProd.SelectedValue));
            this.conBuscaProducto.cargarProductosOtroModulo(Convert.ToInt32(((DataRowView)this.cboTipoProd.SelectedItem)["idProductoMod"].ToString()));
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            habilitarControles(true);
            limpiarCampos();
            this.cTipoOperacion = "N";
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (this.dtgProducto.Rows.Count <= 0)
            {
                MessageBox.Show("No existen productos para editar", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            habilitarControles(true);
            this.cTipoOperacion = "A";
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (!validarDatos())
            {
                return;
            }
            guardarProducto();
            limpiarCampos();
            this.conBuscaProducto.limpiar();
            habilitarControles(false);
            cargarProductos(Convert.ToInt32(this.cboTipoProd.SelectedValue));
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            cargarProductos(Convert.ToInt32(this.cboTipoProd.SelectedValue));
            habilitarControles(false);
            this.conBuscaProducto.limpiar();
        }
        private void btnMiniNuevo1_Click(object sender, EventArgs e)
        {
            habilitarControlProdAsoci(true);
        }
        private void btnMiniQuitar1_Click(object sender, EventArgs e)
        {
            quitarProdInterno();
        }
        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            int idProducto = this.conBuscaProducto.idSubproducto();
            if (!verificaNoRepitenProdAsoc(idProducto))
            {
                return;
            }
            agregarProdInterno(idProducto);
            habilitarControlProdAsoci(false);
        }
        private void btnMiniCancelEst1_Click(object sender, EventArgs e)
        {
            habilitarControlProdAsoci(false);
        }

        private void dtgProducto_SelectionChanged(object sender, EventArgs e)
        {
            verDetallesProducto();
        }

        #endregion
        #region Metodos
        private void cargarProductos(int idTipoProd)
        {
            DataTable dtProductos = cnmapeoriesgoyopeinusual.listaProductosRiesgoTodos(idTipoProd);
            this.dtgProducto.DataSource = dtProductos;
            darFormatoDTGProductos();
            if (dtProductos.Rows.Count==0)
            {
                cargarProductosAsociados("0");
                this.idProductoRiesgo = 0;
            }
        }
        private void darFormatoDTGProductos()
        {
            foreach (DataGridViewColumn item in this.dtgProducto.Columns)
            {
                item.Visible = false;
            }
            this.dtgProducto.Columns["cProducto"].Visible = true;
            this.dtgProducto.Columns["cIdsProductosAsoc"].Visible = true;
            this.dtgProducto.Columns["lVigente"].Visible = true;

            this.dtgProducto.Columns["cProducto"].HeaderText = "Nombre";
            this.dtgProducto.Columns["cIdsProductosAsoc"].HeaderText = "IDs Productos Int.";
            this.dtgProducto.Columns["lVigente"].HeaderText = "Vigencia";
        }
        private void cargaCboTipoProd()
        {
            DataTable dtTipoProd = cnmapeoriesgoyopeinusual.listaTiposProducRiesgo();

            this.cboTipoProd.DataSource = dtTipoProd;
            this.cboTipoProd.DisplayMember = "cTipoProd";
            this.cboTipoProd.ValueMember = "idModulo"; 
        }
        private void habilitarControles(Boolean Val)
        {            
            this.txtNombreProducto.Enabled = Val;
            this.chcVigencia.Enabled = Val;
            this.cboTipoProd.Enabled = !Val;
            this.dtgProducto.Enabled = !Val;
                       
            this.btnNuevo1.Enabled = !Val;
            this.btnEditar1.Enabled = !Val;                                   
            this.btnCancelar1.Enabled = Val;
            this.btnGrabar1.Enabled = Val;
            habilitarControlProdAsoci(!Val);
            if (!btnCancelar1.Enabled)
            {
                this.btnMiniAgregar1.Enabled = false;
                this.btnMiniCancelEst1.Enabled = false;
                this.conBuscaProducto.Enabled = false;
            }                                           
        }
        private void habilitarControlProdAsoci(Boolean Val)
        {
            this.conBuscaProducto.Enabled = Val;
            if (!this.conBuscaProducto.Enabled)
            {
                this.conBuscaProducto.limpiar();
            }         

            this.btnMiniNuevo1.Enabled = !Val;
            this.btnMiniQuitar1.Enabled = !Val;
            this.btnMiniAgregar1.Enabled = Val;
            this.btnMiniCancelEst1.Enabled = Val;
        }
        private void verDetallesProducto()
        {
            if (this.dtgProducto.SelectedRows.Count > 0)
            {
                this.idProductoRiesgo = Convert.ToInt32(this.dtgProducto.SelectedRows[0].Cells["idProductoRiesgo"].Value);
                this.txtNombreProducto.Text = Convert.ToString(this.dtgProducto.SelectedRows[0].Cells["cProducto"].Value);
                this.chcVigencia.Checked = Convert.ToBoolean(this.dtgProducto.SelectedRows[0].Cells["lVigente"].Value);
                this.cIdsProdAsoc = Convert.ToString(this.dtgProducto.SelectedRows[0].Cells["cIdsProductosAsoc"].Value);                
            }
            else
            {
                limpiarCampos();
            }
            cargarProductosAsociados(cIdsProdAsoc);
        }
        private void cargarProductosAsociados(String cIdsProdAsociados)
        {
            dtProdAsociado = cnproductoAsociado.ListarProductoModNivel(Convert.ToInt32(this.cboTipoProd.SelectedValue), 4, cIdsProdAsociados);
            this.dtgProductosAsociados.DataSource = dtProdAsociado;
            darFormatoDTGProductosAsociados();
        }
        private void darFormatoDTGProductosAsociados()
        {
            foreach (DataGridViewColumn item in this.dtgProductosAsociados.Columns)
            {                
                item.Visible = false;
                item.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", (float)(7.5));
            }
            this.dtgProductosAsociados.Columns["IdProducto"].Visible = true;
            this.dtgProductosAsociados.Columns["cProducto"].Visible = true;
            this.dtgProductosAsociados.Columns["IdProducto"].Width = 40; 

            this.dtgProductosAsociados.Columns["IdProducto"].HeaderText = "Id"; 
            this.dtgProductosAsociados.Columns["cProducto"].HeaderText = "Producto"; 
        }
        private Boolean validarDatos()
        {
            if (String.IsNullOrEmpty(this.txtNombreProducto.Text.Trim()))
            {
                MessageBox.Show("Ingrese nombre de producto", this.cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtNombreProducto.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(this.cIdsProdAsoc))
            {
                MessageBox.Show("Debe seleccionar al menos un producto interno", this.cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.btnMiniNuevo1.Focus();
                return false;
            }
            return true;
        }
        private void limpiarCampos()
        {
            this.txtNombreProducto.Clear();
            this.dtProdAsociado.Rows.Clear(); 
            this.chcVigencia.Checked = true;
            this.cIdsProdAsoc = String.Empty;
        }
        private void agregaProdAsociadosCSV(String cIdProd)
        {
            if (String.IsNullOrEmpty(this.cIdsProdAsoc))
            {
                this.cIdsProdAsoc = cIdProd;
            }
            else
            {
                this.cIdsProdAsoc += ","+cIdProd;
            }
        }
        private String quitarProdAsociadoCSV(String idProd)
        {
            String[] separador = new string[] { "," };
            String[] ids = this.cIdsProdAsoc.Split(separador, StringSplitOptions.RemoveEmptyEntries);
            ArrayList cIDSs = new ArrayList(ids);
            cIDSs.Remove(idProd);

            return String.Join(",", cIDSs.ToArray());
        }
        private Boolean verificaNoRepitenProdAsoc(int idProdAsoc)
        {
            if (idProdAsoc == 0)
            {
                MessageBox.Show("Debe seleccionar un producto interno", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            foreach (DataGridViewRow item in this.dtgProductosAsociados.Rows)
            {
                if (Convert.ToInt32(item.Cells["IdProducto"].Value) == idProdAsoc)
                {
                    MessageBox.Show("Producto interno ya se encuentra en la lista", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }
        private void guardarProducto()
        {
            if (this.cTipoOperacion == "N")
            {
                DataTable dtInsercion = cnmapeoriesgoyopeinusual.insertarProductosRiesgo(0, this.txtNombreProducto.Text, Convert.ToInt32(this.cboTipoProd.SelectedValue), this.cIdsProdAsoc, this.chcVigencia.Checked);
                MessageBox.Show(dtInsercion.Rows[0]["cMensaje"].ToString(), cTituloMensajes, MessageBoxButtons.OK, ((int)dtInsercion.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }
            else if (this.cTipoOperacion == "A")
            {
                DataTable dtInsercion = cnmapeoriesgoyopeinusual.insertarProductosRiesgo(this.idProductoRiesgo, this.txtNombreProducto.Text, Convert.ToInt32(this.cboTipoProd.SelectedValue), this.cIdsProdAsoc, this.chcVigencia.Checked);
                MessageBox.Show(dtInsercion.Rows[0]["cMensaje"].ToString(), cTituloMensajes, MessageBoxButtons.OK, ((int)dtInsercion.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }
        }
        private void quitarProdInterno()
        {
            if (this.dtgProductosAsociados.Rows.Count <= 0)
            {
                MessageBox.Show("No existen productos asociados para quitar", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.dtgProductosAsociados.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Seleccione algún producto asociado para quitar", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                int id = this.dtgProductosAsociados.SelectedRows[0].Index;
                String cIdProd = Convert.ToString(this.dtgProductosAsociados.SelectedRows[0].Cells["IdProducto"].Value);
                this.cIdsProdAsoc = quitarProdAsociadoCSV(cIdProd);
                this.dtProdAsociado.Rows.RemoveAt(id);
            }
        }
        private void agregarProdInterno(int idPro)
        {
            int idProducto = idPro;
            agregaProdAsociadosCSV(idProducto.ToString());
            DataRow drProdAsoc = this.dtProdAsociado.NewRow();
            drProdAsoc["IdProducto"] = idProducto;
            drProdAsoc["cProducto"] = this.conBuscaProducto.cboTipoCredito.Text + " / " + this.conBuscaProducto.cboSubTipoCredito.Text + " / " + this.conBuscaProducto.cboProducto.Text + " / " + this.conBuscaProducto.cboSubProducto.Text;
            this.dtProdAsociado.Rows.Add(drProdAsoc);
        }
        #endregion
    }
}
