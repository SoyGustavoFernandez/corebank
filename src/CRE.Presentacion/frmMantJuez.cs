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
    public partial class frmMantJuez : frmBase
    {
        #region Variables Globales

        Transaccion cEvento = Transaccion.Nuevo;
        clsCNProcJud procesojudicial = new clsCNProcJud();

        #endregion


        public frmMantJuez()
        {
            InitializeComponent();
            cboJuez.cargarTodos();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            cargarJuez();

            btnNuevo.Enabled = true;
            btnEditar.Enabled = cboJuez.Items.Count > 0;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;

            cboJuez.Focus();
            cboJuez.Select();
        }

        private bool validar()
        {
            bool lVal = false;

            //if (String.IsNullOrEmpty(txtDocumento.Text.Trim()))
            //{
            //    MessageBox.Show("Debe ingresar el documento de identidad.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtDocumento.Focus();
            //    return lVal;
            //}

            if (String.IsNullOrEmpty(txtApePaterno.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el apellido paterno.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApePaterno.Focus();
                return lVal;
            }

            if (String.IsNullOrEmpty(txtApeMaterno.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el apellido materno.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApeMaterno.Focus();
                return lVal;
            }

            if (String.IsNullOrEmpty(txtNombres.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar los nombres.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombres.Focus();
                return lVal;
            }

            //if (String.IsNullOrEmpty(txtTelefono.Text.Trim()))
            //{
            //    MessageBox.Show("Debe ingresar el teléfono del juez.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtTelefono.Focus();
            //    return lVal;
            //}

            if (cboJuzgado.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el juzgado al que pertenece el juez.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboJuzgado.Focus();
                return lVal;
            }

            //if (this.cboJuez.Items.Count > 0 && cEvento == Transaccion.Nuevo)
            //{
            //    var dtRegistros = (DataTable)cboJuez.DataSource;

            //    int nExiste = dtRegistros.AsEnumerable().Where(x => x["cDocIdent"].ToString() == txtDocumento.Text.Trim()).Count();

            //    if (nExiste > 0)
            //    {
            //        MessageBox.Show("Ya existe un registro con el número de documento ingresado.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        txtDocumento.Focus();
            //        return lVal;
            //    }
            //}

            if (!rbtActivo.Checked && !rbtnInactivo.Checked)
            {
                MessageBox.Show("Seleccione un estado para el registrado.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rbtActivo.Focus();
                return lVal;
            }

            lVal = true;
            return lVal;
        }

        private void cargarJuez()
        {
            if (this.cboJuez.Items.Count > 0)
            {
                var juez = (DataRowView)cboJuez.SelectedItem;

                txtDocumento.Text = juez["cDocIdent"].ToString();
                txtApePaterno.Text = juez["cApePaterno"].ToString();
                txtApeMaterno.Text = juez["cApeMaterno"].ToString();
                txtNombres.Text = juez["cNombres"].ToString();
                txtTelefono.Text = juez["cTelefono"].ToString();
                this.cboJuzgado.SelectedValue = Convert.ToInt32(juez["idJuzgado"]);
                if (Convert.ToBoolean(juez["lVigente"]) == false)
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

        private void limpiarControles()
        {
            cboJuez.SelectedIndexChanged -= cboJuez_SelectedIndexChanged;
            cboJuez.SelectedIndex = -1;
            cboJuez.SelectedIndexChanged += cboJuez_SelectedIndexChanged;

            txtDocumento.Text = String.Empty;
            txtApePaterno.Text = String.Empty;
            txtApeMaterno.Text = String.Empty;
            txtNombres.Text = String.Empty;
            txtTelefono.Text= String.Empty;
            rbtnInactivo.Checked = false;
            rbtActivo.Checked = false;
        }

        private void habilitarControles(bool estado)
        {
            txtDocumento.Enabled = estado;
            txtApePaterno.Enabled = estado;
            txtApeMaterno.Enabled = estado;
            txtNombres.Enabled = estado;
            txtTelefono.Enabled = estado;
            rbtActivo.Enabled = estado;
            rbtnInactivo.Enabled = estado;
            cboJuzgado.Enabled=estado;
            cboJuez.Enabled = !estado;
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

            txtDocumento.Focus();
            txtDocumento.Select();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.cboJuez.Items.Count == 0)
            {
                MessageBox.Show("No existen registros por editar", "Validación de registros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cEvento = Transaccion.Edita;
            btnEditar.Enabled = false;
            btnNuevo.Enabled = false;
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = true;
            habilitarControles(true);

            activarControlObjetos(this, EventoFormulario.EDITAR);

            txtDocumento.Focus();
            txtDocumento.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
            btnNuevo.Enabled = true;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
            cboJuez.SelectedIndex = cboJuez.Items.Count > 0 ? 0 : -1;
            cargarJuez();
            habilitarControles(false);

            cboJuez.Focus();
            cboJuez.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;

            clsDBResp objDbResp = null;

            int idJuez = cboJuez.SelectedValue != null ? Convert.ToInt32(cboJuez.SelectedValue) : 0; 
            string cDocIdent = txtDocumento.Text.Trim();
            string cApePaterno = txtApePaterno.Text.Trim();
            string cApeMaterno = txtApeMaterno.Text.Trim();
            string cNombres = txtNombres.Text.Trim();
            int idJuzgado = Convert.ToInt32(cboJuzgado.SelectedValue);
            string cTelefono = txtTelefono.Text.Trim();
            bool lVigente = rbtActivo.Checked;

            if (cEvento == Transaccion.Nuevo)
            {
                objDbResp = procesojudicial.InsertarJuez(cDocIdent, cApePaterno, cApeMaterno, cNombres, idJuzgado, cTelefono, lVigente);
            }
            else
            {
                objDbResp = procesojudicial.ActualizarJuez(idJuez, cDocIdent, cApePaterno, cApeMaterno, cNombres, idJuzgado, cTelefono, lVigente);
            }

            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, "Mantenimiento de juez", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                btnEditar.Enabled = true;
                btnNuevo.Enabled = true;
                btnCancelar.Enabled = false;
                btnGrabar.Enabled = false;
                this.cboJuez.cargarTodos();
                cargarJuez();
                habilitarControles(false);

                cboJuez.Focus();
                cboJuez.Select();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, "Mantenimiento de juez", MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
            } 
        }

        private void cboJuez_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarJuez();
        }
    }
}
