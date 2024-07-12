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
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmMantJuzgado : frmBase
    {
        #region Variables Globales

        Transaccion cEvento = Transaccion.Nuevo;
        clsCNProcJud procesojudicial = new clsCNProcJud();

        #endregion

        public frmMantJuzgado()
        {
            InitializeComponent();
            cboJuzgado.cargarTodos();
            conBusUbig.cargar();        
            conBusUbig.cboPais.SelectedValue = 173;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            cargarJuzgado();

            btnNuevo.Enabled = true;
            btnEditar.Enabled = cboJuzgado.Items.Count > 0;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;

            cboJuzgado.Focus();
            cboJuzgado.Select();
        }

        private void cargarJuzgado()
        {
            if (this.cboJuzgado.Items.Count > 0)
            {
                var juzgado = (DataRowView)cboJuzgado.SelectedItem;
                txtCodJuzgado.Text = juzgado["cCodJuzgado"].ToString();
                txtDescripcion.Text = juzgado["cJuzgado"].ToString();
                txtDireccion.Text = juzgado["cDireccion"].ToString();

                conBusUbig.cargarUbigeo(Convert.ToInt32(juzgado["idUbigeo"]));
                if (Convert.ToBoolean(juzgado["lVigente"]) == false)
                {
                    rbtnInactivo.Checked = true;
                    rbtActivo.Checked = false;
                }
                else
                {
                    rbtnInactivo.Checked = false;
                    rbtActivo.Checked = true;
                }
            }
        }


        private bool validar()
        {
            bool lVal = false;

            if (String.IsNullOrEmpty(txtCodJuzgado.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el código del juzgado.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodJuzgado.Focus();
                return lVal;
            }

            if (String.IsNullOrEmpty(txtDescripcion.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el nombre del juzgado.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return lVal;
            }

            if (String.IsNullOrEmpty(txtDireccion.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar la dirección del juzgado.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
                return lVal;
            }

            if (!rbtActivo.Checked && !rbtnInactivo.Checked)
            {
                MessageBox.Show("Debe seleccionar un estado para el registro.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rbtActivo.Focus();
                return lVal;
            }

            if (this.cboJuzgado.Items.Count > 0 && cEvento== Transaccion.Nuevo)
            {
                var dtRegistros = (DataTable)cboJuzgado.DataSource;

                int nExiste = dtRegistros.AsEnumerable().Where(x => x["cJuzgado"].ToString() == this.txtDescripcion.Text.Trim()).Count();

                if (nExiste > 0)
                {
                    MessageBox.Show("Ya existe un registro con la descripción ingresada.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDescripcion.Focus();
                    return lVal;
                }
            }

            if (conBusUbig.cboDistrito.SelectedIndex <= 0)
            {
                MessageBox.Show("Debe seleccionar un ubigeo para el juzgado", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusUbig.Focus();
                return lVal;
            }

            lVal = true;
            return lVal;
        }

        private void limpiarControles()
        {
            cboJuzgado.SelectedIndexChanged -= cboJuzgado_SelectedIndexChanged;
            cboJuzgado.SelectedIndex = -1;
            cboJuzgado.SelectedIndexChanged += cboJuzgado_SelectedIndexChanged;

            txtCodJuzgado.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            txtDireccion.Text=String.Empty;
            rbtnInactivo.Checked = false;
            rbtActivo.Checked = false;

            conBusUbig.nIdNodo = 0;
            conBusUbig.cargar();
            conBusUbig.cboPais.SelectedValue = 173;
        }

        private void habilitarControles(bool estado)
        {
            conBusUbig.Enabled = estado;
            txtCodJuzgado.Enabled = estado;
            txtDescripcion.Enabled = estado;
            txtDireccion.Enabled = estado;
            rbtActivo.Enabled = estado;
            rbtnInactivo.Enabled = estado;
            cboJuzgado.Enabled = !estado;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cEvento = Transaccion.Nuevo;
            btnEditar.Enabled = false;
            btnNuevo.Enabled = false;
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = true;
            limpiarControles();
            rbtActivo.Checked = true;
            habilitarControles(true);

            txtCodJuzgado.Focus();
            txtCodJuzgado.Select();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.cboJuzgado.Items.Count == 0)
            {
                MessageBox.Show("No existen registros por editar.", "Validación de registros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cEvento = Transaccion.Edita;
            btnEditar.Enabled = false;
            btnNuevo.Enabled = false;
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = true;
            habilitarControles(true);
            txtCodJuzgado.Enabled = false;

            activarControlObjetos(this, EventoFormulario.EDITAR);

            txtDescripcion.Focus();
            txtDescripcion.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
            btnNuevo.Enabled = true;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
            cboJuzgado.SelectedIndex = cboJuzgado.Items.Count > 0 ? 0 : -1;
            cargarJuzgado();
            habilitarControles(false);

            cboJuzgado.Focus();
            cboJuzgado.Select();
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;

            int idJuzgado = cboJuzgado.SelectedValue != null ? Convert.ToInt32(this.cboJuzgado.SelectedValue):0;
            string cCodJuzgado = txtCodJuzgado.Text.Trim();
            string cJuzgado = txtDescripcion.Text.Trim();
            int idUbigeo = Convert.ToInt32(conBusUbig.cboDistrito.SelectedValue);
            string cDireccion = txtDireccion.Text.Trim();
            bool lVigente = rbtActivo.Checked;

            clsDBResp objDbResp = null;
            if (cEvento == Transaccion.Nuevo)
            {
                objDbResp = procesojudicial.InsertarJuzgado(cCodJuzgado, cJuzgado, idUbigeo, cDireccion, lVigente);
            }
            else
            {
                objDbResp = procesojudicial.ActualizarJuzgado(idJuzgado, cCodJuzgado, cJuzgado, idUbigeo, cDireccion, lVigente);
            }

            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, "Registro de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnEditar.Enabled = true;
                btnNuevo.Enabled = true;
                btnCancelar.Enabled = false;
                btnGrabar.Enabled = false;
                cboJuzgado.cargarTodos();
                cargarJuzgado();
                habilitarControles(false);

                cboJuzgado.Focus();
                cboJuzgado.Select();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, "Registro de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cboJuzgado_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarJuzgado();
        }

        private void lblBase3_Click(object sender, EventArgs e)
        {

        }
    }
}
