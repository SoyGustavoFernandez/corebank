using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using SPL.CapaNegocio;
using System;
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
    public partial class frmMapeoRiesgos : frmBase
    {
        #region Varibles globales
        clsCNMapeoRiesgoYOpeInusual cnmapeoriesgoyopeinusual = new clsCNMapeoRiesgoYOpeInusual();
        String cTipoOperacion = "A";
        String cTituloMensajes = "Mantenimiento de productos";
        int idMapeoRiesgo = 0;
        int idItem = 0;       
        DataTable dtActividades;
        #endregion
        public frmMapeoRiesgos()
        {
            InitializeComponent();
        }
        #region Eventos
        private void frmMapeoRiesgos_Load(object sender, EventArgs e)
        {                     
            cargarCboProductos();
            cargarCboOperaciones(); 
            this.cboDep.SelectedIndexChanged -= new EventHandler(cboDep_SelectedIndexChanged);
            this.cboDep.CargarUbigeo(173);

            this.cboModulo1.SelectedIndexChanged -= new EventHandler(cboModulo1_SelectedIndexChanged);
            this.cboModulo1.ListarSoloModulos();

            this.cboTipoOperacion1.ListadoTipoOpe();
            cargarCboCalificRiesgo();
            cargarMapeo();
            habilitarControles(false);
        }
        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            habilitarControles(true);
            limpiarCampos();
            this.cTipoOperacion = "N";
            cargarListaActividades();
        }
        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (this.dtgMapeo.Rows.Count <= 0)
            {
                MessageBox.Show("No existen registros para editar", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            habilitarControles(true);
            this.cTipoOperacion = "A";
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            guardarMapeoRiesgo();            
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            this.cTipoOperacion = "A";
            cargarMapeo();
            habilitarControles(false);
        }
        private void cboTipoMapeoSPLAFT1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambiarOpcionesXTipoMapeo();
            cargarMapeo();
        }
        private void dtgActividades_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            calcularPuntajeActividades();
        }
        private void dtgActividades_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgActividades.IsCurrentCellDirty)
            {
                dtgActividades.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void dtgMapeo_SelectionChanged(object sender, EventArgs e)
        {
            verDetallesMapeo();            
        }
        private void cboDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cboDep.SelectedValue) == 0)
            {
                this.cboProvincia.Enabled = false;
            }
            else
            {
                if (this.cboDep.Enabled)
                {
                    this.cboProvincia.Enabled = true;
                }                       
            }
            this.cboProvincia.CargarUbigeo(Convert.ToInt32(this.cboDep.SelectedValue));
        }
        private void cboModulo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboTipoOperacion1.LisTipoOperacModulo(Convert.ToInt32(this.cboModulo1.SelectedValue));
        }
        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            if (this.dtgMapeo.SelectedRows.Count == 0)
            {
                MessageBox.Show("No se seleccionó ningún registro", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show("¿Está seguro de eliminar el registro?", cTituloMensajes, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DataTable dtInsercion = cnmapeoriesgoyopeinusual.eliminarRegMapeoRiesgo(Convert.ToInt32(this.dtgMapeo.SelectedRows[0].Cells["idMapeoRiesgo"].Value), clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
                MessageBox.Show(dtInsercion.Rows[0]["cMensaje"].ToString(), cTituloMensajes, MessageBoxButtons.OK, ((int)dtInsercion.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }
            cargarMapeo();
        }
        #endregion
        #region Metodos
        private void cargarMapeo()
        {
            DataTable dtMapeo = cnmapeoriesgoyopeinusual.listarMapeoRiesgo(Convert.ToInt32(this.cboTipoMapeoSPLAFT1.SelectedValue));
            dtMapeo.DefaultView.RowFilter = ("lVigente = 1");
            this.dtgMapeo.DataSource = dtMapeo;
            formatoDTGMapeo();
        }
        private void formatoDTGMapeo()
        {
            foreach (DataGridViewColumn item in this.dtgMapeo.Columns)
            {
                item.Visible = false;
            }
            this.dtgMapeo.Columns["cItem"].Visible = true;
            this.dtgMapeo.Columns["nPuntaje"].Visible = true;
            this.dtgMapeo.Columns["cCalificRiesgo"].Visible = true;

            this.dtgMapeo.Columns["nPuntaje"].Width = 50;
            this.dtgMapeo.Columns["cCalificRiesgo"].Width = 130;

            this.dtgMapeo.Columns["cItem"].HeaderText = "";
            this.dtgMapeo.Columns["nPuntaje"].HeaderText = "Puntaje";
            this.dtgMapeo.Columns["cCalificRiesgo"].HeaderText = "Riesgo";
        }
        private void cargarCboProductos()
        {
            DataTable dtProductosRiesgo = cnmapeoriesgoyopeinusual.listaProductosRiesgo(0, Convert.ToInt32(this.cboTipoMapeoSPLAFT1.SelectedValue));
            this.cboProductos.DataSource = dtProductosRiesgo;
            this.cboProductos.DisplayMember = "cProducto";
            this.cboProductos.ValueMember = "idProductoRiesgo"; 
        }
        private void cargarCboCalificRiesgo()
        {
            DataTable dtRiesgo = cnmapeoriesgoyopeinusual.listaCalificRiesgo(0);
            this.cboCalificRiesgo.DataSource = dtRiesgo;
            this.cboCalificRiesgo.DisplayMember = "cCalificRiesgo";
            this.cboCalificRiesgo.ValueMember = "idCalificRiesgo"; 
        }
        private void cargarCboOperaciones()
        {
            DataTable dtOpe = new clsCNUmbralSPL().ListarTipoOperaciones();
        }
        private void cargarListaActividades()
        {
            if (this.cTipoOperacion == "N")
            {                
                dtActividades = cnmapeoriesgoyopeinusual.listaActividadesXTipoMapeo(Convert.ToInt32(this.cboTipoMapeoSPLAFT1.SelectedValue));
                if (dtActividades.Rows.Count > 0)
                {
                    dtActividades.DefaultView.RowFilter = "lVigente = 1";
                    //dtActividades = dtActivid1;
                    for (int i = 0; i < dtActividades.Rows.Count-1; i++)
                    {
                        DataRow drActiv = dtActividades.Rows[i];
                        if (Convert.ToBoolean(drActiv["lVigente"]) == false)
                        {
                            drActiv.Delete();
                        }
                    }
                    dtActividades.AcceptChanges();
                    this.dtgActividades.DataSource = dtActividades;
                    formatoDTGActividades();
                }
                else
                {
                    MessageBox.Show("No existen Actividades para este Mapeo, configure la estructura", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    habilitarControles(false);
                }
            }
            else if (this.cTipoOperacion == "A")
            {
                dtActividades = cnmapeoriesgoyopeinusual.listaDetalleMapeo(this.idMapeoRiesgo);
                this.dtgActividades.DataSource = dtActividades;
                if (dtActividades.Rows.Count > 0)
                {
                    formatoDTGActividades();   
                }               
            }            
        }
        private void formatoDTGActividades()
        {
            this.dtgActividades.ReadOnly = false;
            foreach (DataGridViewColumn item in this.dtgActividades.Columns)
            {
                item.Visible = false;
                item.ReadOnly = true;
            }            
            this.dtActividades.Columns["lSeleccion"].ReadOnly = false;
            this.dtgActividades.Columns["lSeleccion"].ReadOnly = false;            

            this.dtgActividades.Columns["cActividadRiesgo"].Visible = true;
            this.dtgActividades.Columns["lSeleccion"].Visible = true;

            this.dtgActividades.Columns["lSeleccion"].Width = 50;

            this.dtgActividades.Columns["cActividadRiesgo"].HeaderText = "Actividad riesgo";
            this.dtgActividades.Columns["lSeleccion"].HeaderText = "";                      
        }
        private void habilitarControles(Boolean Val)
        {
            this.cboProductos.Enabled = Val;
            this.cboCalificRiesgo.Enabled = Val;
            this.dtgActividades.Enabled = Val;
            this.txtPuntaje.Enabled = Val;
            this.dtgMapeo.Enabled = !Val;
            this.cboTipoMapeoSPLAFT1.Enabled = !Val;
            this.cboDep.Enabled = Val;
            this.cboProvincia.Enabled = Val;
            this.cboModulo1.Enabled = Val;
            this.cboTipoOperacion1.Enabled = Val;

            this.btnNuevo1.Enabled = !Val;
            this.btnEditar1.Enabled = !Val;
            this.btnCancelar1.Enabled = Val;
            this.btnGrabar1.Enabled = Val;
            this.btnEliminar1.Enabled = !Val;
        }
        private void limpiarCampos()
        {
            this.txtPuntaje.Text = "0";
            this.dtgActividades.DataSource = null;
            this.cboCalificRiesgo.SelectedIndex = 0;
            this.cboDep.SelectedIndex = 0;                
            this.cboModulo1.SelectedIndex = 0;
            this.idItem = 0;
        }
        private void guardarMapeoRiesgo()
        {            
            int idItem = 0;
            int idTipoMapeo = Convert.ToInt32(this.cboTipoMapeoSPLAFT1.SelectedValue);
            String cTipoMapeoMensaje = String.Empty;
            if (idTipoMapeo < 3) //1 y 2 Productos
            {
                idItem = Convert.ToInt32(this.cboProductos.SelectedValue);
                cTipoMapeoMensaje = "el producto";
            }
            else if (Convert.ToInt32(this.cboTipoMapeoSPLAFT1.SelectedValue) == 3) // 3 zona
            {
                idItem = Convert.ToInt32(this.cboProvincia.SelectedValue);
                cTipoMapeoMensaje = "la provincia";
            }
            else if (Convert.ToInt32(this.cboTipoMapeoSPLAFT1.SelectedValue) == 4) // 4 operación
            {
                idItem = Convert.ToInt32(this.cboTipoOperacion1.SelectedValue);
                cTipoMapeoMensaje = "el tipo operación";
            }

            if (idItem == 0)
            {
                MessageBox.Show("Seleccione "+cTipoMapeoMensaje+"", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.grbDetalle.Focus();
                return;
            }
            Decimal nPuntaje = Convert.ToDecimal(this.txtPuntaje.Text);
            int idCalificRiesgo = Convert.ToInt32(this.cboCalificRiesgo.SelectedValue);

            // verifica que no exista ya el item en la lista
            foreach (DataGridViewRow item in this.dtgMapeo.Rows)
            {
                if (idItem != this.idItem)
                {
                    if (Convert.ToInt32(item.Cells["idItem"].Value) == idItem)
                    {
                        MessageBox.Show("El ítem ya se encuentra en la lista", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }                
            }

            DataSet DSDetalles = new DataSet("DSDetalleMapeo");
            DSDetalles.Tables.Add(dtActividades);
            String xmlDetalles = DSDetalles.GetXml();
            xmlDetalles = clsCNFormatoXML.EncodingXML(xmlDetalles);
            DSDetalles.Tables.Clear();

            if (this.cTipoOperacion == "N")
            {
                
                DataTable dtInsercion = cnmapeoriesgoyopeinusual.insertarRegMapeoRiesgo(0, idItem, idTipoMapeo, nPuntaje, idCalificRiesgo, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, xmlDetalles);
                MessageBox.Show(dtInsercion.Rows[0]["cMensaje"].ToString(), cTituloMensajes, MessageBoxButtons.OK, ((int)dtInsercion.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }
            else if (this.cTipoOperacion == "A")
            {
                DataTable dtInsercion = cnmapeoriesgoyopeinusual.insertarRegMapeoRiesgo(this.idMapeoRiesgo, idItem, idTipoMapeo, nPuntaje, idCalificRiesgo, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, xmlDetalles);
                MessageBox.Show(dtInsercion.Rows[0]["cMensaje"].ToString(), cTituloMensajes, MessageBoxButtons.OK, ((int)dtInsercion.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }
            this.cTipoOperacion = "A";

            limpiarCampos();
            habilitarControles(false);
            cargarMapeo();
        }
        private void cambiarOpcionesXTipoMapeo()
        {
            this.cTipoOperacion = "A";
            if (Convert.ToInt32(this.cboTipoMapeoSPLAFT1.SelectedValue) < 3) // 1 y 2 son productos
            {
                cargarCboProductos();
                this.panZona.Visible = false;
                this.panOperacion.Visible = false;
            }
            else if (Convert.ToInt32(this.cboTipoMapeoSPLAFT1.SelectedValue) == 3) // 3 zona
            {
                this.panOperacion.Visible = false;
                this.panZona.Visible = true;
                this.cboDep.SelectedIndexChanged += new EventHandler(cboDep_SelectedIndexChanged);
            }
            else if (Convert.ToInt32(this.cboTipoMapeoSPLAFT1.SelectedValue) == 4) // 4 operación
            {
                this.panZona.Visible = false;
                this.panOperacion.Visible = true;
                this.cboModulo1.SelectedIndexChanged += new EventHandler(cboModulo1_SelectedIndexChanged);
            }
            this.grbDetalle.Text = ((DataRowView)this.cboTipoMapeoSPLAFT1.SelectedItem)["cTipoMapeo"].ToString();
        }
        private void calcularPuntajeActividades()
        {
            int nCantidadChecks = 0;
            int nTotalItems = 0;
            foreach (DataGridViewRow item in this.dtgActividades.Rows)
            {
                if (Convert.ToBoolean(item.Cells["lSeleccion"].Value))
                {
                    nCantidadChecks++;
                }
                nTotalItems++;
            }            
            this.txtPuntaje.Text = Convert.ToDecimal(Convert.ToDecimal(nCantidadChecks) / Convert.ToDecimal(nTotalItems)).ToString();
        }
        private void verDetallesMapeo()
        {
            if (this.dtgMapeo.SelectedRows.Count > 0)
            {
                this.idMapeoRiesgo = Convert.ToInt32(this.dtgMapeo.SelectedRows[0].Cells["idMapeoRiesgo"].Value);
                if (Convert.ToInt32(this.cboTipoMapeoSPLAFT1.SelectedValue) < 3)
                {
                    this.cboProductos.SelectedValue = Convert.ToInt32(this.dtgMapeo.SelectedRows[0].Cells["idItem"].Value);
                    this.idItem = Convert.ToInt32(this.dtgMapeo.SelectedRows[0].Cells["idItem"].Value);
                }
                else if (Convert.ToInt32(this.cboTipoMapeoSPLAFT1.SelectedValue) == 3) // 3 zona
                {
                    this.cboDep.SelectedValue = Convert.ToInt32(this.dtgMapeo.SelectedRows[0].Cells["idPadreItem"].Value);
                    this.cboProvincia.SelectedValue = Convert.ToInt32(this.dtgMapeo.SelectedRows[0].Cells["idItem"].Value);
                    this.idItem = Convert.ToInt32(this.dtgMapeo.SelectedRows[0].Cells["idItem"].Value);
                }
                else if (Convert.ToInt32(this.cboTipoMapeoSPLAFT1.SelectedValue) == 4) // 4 operación
                {
                    this.cboModulo1.SelectedValue = Convert.ToInt32(this.dtgMapeo.SelectedRows[0].Cells["idPadreItem"].Value);
                    this.cboTipoOperacion1.SelectedValue = Convert.ToInt32(this.dtgMapeo.SelectedRows[0].Cells["idItem"].Value);
                    this.idItem = Convert.ToInt32(this.dtgMapeo.SelectedRows[0].Cells["idItem"].Value);
                }
                this.txtPuntaje.Text = Convert.ToString(this.dtgMapeo.SelectedRows[0].Cells["nPuntaje"].Value);
                this.cboCalificRiesgo.SelectedValue = Convert.ToInt32(this.dtgMapeo.SelectedRows[0].Cells["idCalificRiesgo"].Value);
                cargarListaActividades();
            }
            else
            {
                limpiarCampos();
            }
        }
        #endregion               

        private void txtPuntaje_TextChanged(object sender, EventArgs e)
        {
            //por probar
            if (this.btnGrabar1.Enabled)
            {
                Decimal nPorce = (( Convert.ToDecimal(this.txtPuntaje.Text) -0.01m)* (this.cboCalificRiesgo.Items.Count));
                int nPosicionCbo = Convert.ToInt32(Math.Truncate(nPorce));
                if (nPosicionCbo == (this.cboCalificRiesgo.Items.Count))
                {
                    this.cboCalificRiesgo.SelectedIndex = nPosicionCbo - 1;
                }
                else
                {
                    this.cboCalificRiesgo.SelectedIndex = nPosicionCbo;
                }
            }            
        }
    }
}
