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
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using GEN.CapaNegocio;

namespace ADM.Presentacion
{
    public partial class frmMantenimientoZonas : frmBase
    {
        #region Variable Globales

        clsCNRegionZona cnregionzona = new clsCNRegionZona();
        Transaccion operacion = Transaccion.Selecciona;

        #endregion

        public frmMantenimientoZonas()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            cargarRegionZona();
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                if (operacion == Transaccion.Nuevo)
                {
                    var dtresul = cnregionzona.CNInsertarZona(txtDescripcion.Text.Trim(), rbtActivo.Checked);
                    MessageBox.Show(dtresul.Rows[0]["cMensaje"].ToString(), "Registro de Región-Zona", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (operacion == Transaccion.Edita)
                {
                    var dtresul = cnregionzona.CNActualizarZona((int)lstRegiones.SelectedValue, txtDescripcion.Text.Trim(), rbtActivo.Checked);
                    MessageBox.Show(dtresul.Rows[0]["cMensaje"].ToString(), "Registro de Región-Zona", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                operacion = Transaccion.Selecciona;
                btnEditar1.Enabled = true;
                btnNuevo1.Enabled = true;
                btnCancelar1.Enabled = false;
                btnGrabar1.Enabled = false;
                this.cargarRegionZona();
                habilitarcontroles(false);
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            operacion = Transaccion.Selecciona;
            btnEditar1.Enabled = true;
            btnNuevo1.Enabled = true;
            btnCancelar1.Enabled = false;
            btnGrabar1.Enabled = false;
            cargarRegionZona();
            habilitarcontroles(false);
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (this.lstRegiones.Items.Count == 0)
            {
                MessageBox.Show("No existe registros por editar", "Validación de registros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            operacion = Transaccion.Edita;
            btnEditar1.Enabled = false;
            btnNuevo1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
            habilitarcontroles(true);
            activarControlObjetos(this, EventoFormulario.EDITAR);
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            operacion = Transaccion.Nuevo;
            btnEditar1.Enabled = false;
            btnNuevo1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
            limpiarcontroles();
            habilitarcontroles(true);
            lstRegiones.ClearSelected();
        }

        private void lstRegiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarRegionZonaItem();
        }

        #endregion

        #region Métodos

        private bool validar()
        {
            bool lValida = false;

            if (txtDescripcion.Text.Trim()=="")
            {
                MessageBox.Show("Ingrese la descripción de la Región por favor", "Validación de descripción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return lValida;
            }

            if (!rbtActivo.Checked && !rbtnInactivo.Checked)
            {
                MessageBox.Show("Seleccione el estado para el registro", "validación de estado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rbtActivo.Focus();
                return lValida;
            }

            lValida = true;
            return lValida;
        }
        
        private void limpiarcontroles()
        {
            txtDescripcion.Text = "";
            rbtnInactivo.Checked = false;
            rbtActivo.Checked = false;
        }

        private void habilitarcontroles(bool estado)
        {
            txtDescripcion.Enabled = estado;
            rbtActivo.Enabled = estado;
            rbtnInactivo.Enabled = estado;
            this.lstRegiones.Enabled = !estado;
        }

        private void cargarRegionZona()
        {
            var dtRegionZona = cnregionzona.CNListarZona();

            if (dtRegionZona.Rows.Count > 0)
            {
                lstRegiones.ValueMember = "idZona";
                lstRegiones.DisplayMember = "cDesZona";
                lstRegiones.DataSource = dtRegionZona;                
            }
        }

        private void cargarRegionZonaItem()
        {
            if (lstRegiones.SelectedItems.Count > 0)
            {
                var drRegion = (DataRowView)lstRegiones.SelectedItem;
                txtDescripcion.Text = drRegion["cDesZona"].ToString();
                rbtActivo.Checked = (bool)drRegion["lVigente"];
                rbtnInactivo.Checked = !rbtActivo.Checked;
            }
        }

        #endregion
        
    }
}
