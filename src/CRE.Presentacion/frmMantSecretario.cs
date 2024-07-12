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
    public partial class frmMantSecretario : frmBase
    {
        #region Variables Globales

        Transaccion cEvento = Transaccion.Nuevo;
        clsCNProcJud procesojudicial = new clsCNProcJud();

        #endregion

        public frmMantSecretario()
        {
            InitializeComponent();
            cboSecretario.cargarTodos();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            cargarSecretario();

            btnNuevo.Enabled = true;
            btnEditar.Enabled = cboSecretario.Items.Count > 0;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;

            cboSecretario.Focus();
            cboSecretario.Select();
        }

        private bool validar()
        {
            bool lVal = false;

            if (String.IsNullOrEmpty(txtDocumento.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el documento de identidad.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return lVal;
            }

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

            //if (String.IsNullOrEmpty(txtTelefFijo1.Text.Trim()) && String.IsNullOrEmpty(txtTelefFijo2.Text.Trim()))
            //{
            //    MessageBox.Show("Ingrese por lo menos un telefono fijo.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtTelefFijo1.Focus();
            //    return lVal;
            //}

            //if (String.IsNullOrEmpty(txtTelefCel1.Text.Trim()) && String.IsNullOrEmpty(txtTelefCel2.Text.Trim()))
            //{
            //    MessageBox.Show("Ingrese por lo menos un telefono celular.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtTelefCel1.Focus();
            //    return lVal;
            //}

            if (cboJuzgado.SelectedIndex<0)
            {
                MessageBox.Show("Seleccione el juzgado.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboJuzgado.Focus();
                return lVal;
            }

            //if (this.cboSecretario.Items.Count > 0 && cEvento == Transaccion.Nuevo)
            //{
            //    var dtRegistros = (DataTable)cboSecretario.DataSource;

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
                MessageBox.Show("Debe seleccionar un estado para el registro.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rbtActivo.Focus();
                return lVal;
            }

            lVal = true;
            return lVal;
        }

        private void cargarSecretario()
        {
            if (this.cboSecretario.Items.Count > 0)
            {
                var secretario = (DataRowView)cboSecretario.SelectedItem;

                txtDocumento.Text = secretario["cDocIdent"].ToString();
                txtApePaterno.Text = secretario["cApePaterno"].ToString();
                txtApeMaterno.Text = secretario["cApeMaterno"].ToString();
                txtNombres.Text = secretario["cNombres"].ToString();
                txtTelefFijo1.Text = secretario["cTelefFijo1"].ToString();
                txtTelefFijo2.Text = secretario["cTelefFijo2"].ToString();
                txtTelefCel1.Text = secretario["cTelefCel1"].ToString();
                txtTelefCel2.Text = secretario["cTelefCel2"].ToString();
                this.cboJuzgado.SelectedValue = Convert.ToInt32(secretario["idJuzgado"]);
                if (Convert.ToBoolean(secretario["lVigente"]) == false)
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
            cboSecretario.SelectedIndexChanged -= cboSecretario_SelectedIndexChanged;
            cboSecretario.SelectedIndex = -1;
            cboSecretario.SelectedIndexChanged += cboSecretario_SelectedIndexChanged;

            txtDocumento.Text = String.Empty;
            txtApePaterno.Text = String.Empty;
            txtApeMaterno.Text = String.Empty;
            txtNombres.Text = String.Empty;
            txtTelefFijo1.Text =String.Empty;
            txtTelefFijo2.Text = String.Empty;
            txtTelefCel1.Text=String.Empty;
            txtTelefCel2.Text = String.Empty;
            rbtnInactivo.Checked = false;
            rbtActivo.Checked = false;
        }

        private void habilitarControles(bool estado)
        {
            txtDocumento.Enabled = estado;
            txtApePaterno.Enabled = estado;
            txtApeMaterno.Enabled = estado;
            txtNombres.Enabled = estado;
            txtTelefFijo1.Enabled = estado;
            txtTelefFijo2.Enabled = estado;
            txtTelefCel1.Enabled = estado;
            txtTelefCel2.Enabled = estado;
            rbtActivo.Enabled = estado;
            rbtnInactivo.Enabled = estado;
            cboJuzgado.Enabled = estado;
            cboSecretario.Enabled = !estado;
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
            if (this.cboSecretario.Items.Count == 0)
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
            cboSecretario.SelectedIndex = cboSecretario.Items.Count > 0 ? 0 : -1;
            cargarSecretario();
            habilitarControles(false);

            cboSecretario.Focus();
            cboSecretario.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;

            int idSecretario = cboJuzgado.SelectedValue != null ? Convert.ToInt32(cboJuzgado.SelectedValue) : 0;
            string cDocIdent = txtDocumento.Text.Trim();
            string cApePaterno = txtApePaterno.Text.Trim();
            string cApeMaterno = txtApeMaterno.Text.Trim();
            string cNombres = txtNombres.Text.Trim();
            int idJuzgado = Convert.ToInt32(cboJuzgado.SelectedValue);
            string cTelefFijo1 = txtTelefFijo1.Text.Trim();
            string cTelefFijo2 =txtTelefFijo2.Text.Trim();
            string cTelefCel1 =txtTelefCel1.Text.Trim();
            string cTelefCel2 =txtTelefCel2.Text.Trim();
            bool lVigente =  rbtActivo.Checked;

            clsDBResp objDbResp = null;

            if (cEvento == Transaccion.Nuevo)
            {

                objDbResp = procesojudicial.InsertarSecretario(cDocIdent, cApePaterno, cApeMaterno, cNombres, idJuzgado,
                                                cTelefFijo1, cTelefFijo2, cTelefCel1, cTelefCel2, lVigente);

            }
            else
            {
                objDbResp = procesojudicial.ActualizarSecretario(idSecretario, cDocIdent, cApePaterno, cApeMaterno, cNombres, idJuzgado,
                                                cTelefFijo1, cTelefFijo2, cTelefCel1, cTelefCel2, lVigente);
            }

            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, "Registro de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnEditar.Enabled = true;
                btnNuevo.Enabled = true;
                btnCancelar.Enabled = false;
                btnGrabar.Enabled = false;
                cboSecretario.cargarTodos();
                cargarSecretario();
                habilitarControles(false);

                cboSecretario.Focus();
                cboSecretario.Select();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, "Registro de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
        }

        private void cboSecretario_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarSecretario();
        }

    }
}
