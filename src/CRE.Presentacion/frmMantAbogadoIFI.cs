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
    public partial class frmMantAbogadoIFI : frmBase
    {
        #region Variables Globales

        Transaccion cEvento = Transaccion.Nuevo;
        clsCNProcJud procesojudicial = new clsCNProcJud();

        #endregion

        public frmMantAbogadoIFI()
        {
            InitializeComponent();
            cboAbogado.cargarTodos();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            cargarAbogado();
            btnNuevo.Enabled = true;
            btnEditar.Enabled = cboAbogado.Items.Count > 0;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
            chcEstudioJuridico.Enabled = false;

            cboAbogado.Focus();
            cboAbogado.Select();
        }

        private bool validar()
        {
            bool lVal = false;

            if (String.IsNullOrEmpty(txtDocumento.Text.Trim()))
            {
                if (chcEstudioJuridico.Checked)
                {
                    MessageBox.Show("Debe ingresar el RUC del estudio juridico.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
                }
                else
                {
                    MessageBox.Show("Debe ingresar el documento de identidad del abogado.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
                }
                txtDocumento.Focus();
                return lVal;
            }

            if (txtApePaterno.Enabled && String.IsNullOrEmpty(txtApePaterno.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el apellido paterno del abogado.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApePaterno.Focus();
                return lVal;
            }

            if (txtApeMaterno.Enabled && String.IsNullOrEmpty(txtApeMaterno.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el apellido materno del abogado.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApeMaterno.Focus();
                return lVal;
            }

            if (String.IsNullOrEmpty(txtNombres.Text.Trim()))
            {
                if (chcEstudioJuridico.Checked)
                {
                    MessageBox.Show("Debe ingresar la razon social del estudio juridico.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Debe ingresar los nombres del abogado.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                txtNombres.Focus();
                return lVal;
            }

            if (txtApeMaterno.Enabled && String.IsNullOrEmpty(txtDomicilio.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar la dirección del domicilio del abogado.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDomicilio.Focus();
                return lVal;
            }

            if (chcExterno.Checked)
            {
                if (String.IsNullOrEmpty(txtDirEstudio.Text.Trim()))
                {
                    MessageBox.Show("Debe ingresar la dirección del estudio del abogado.", "Validación de registro",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDomicilio.Focus();
                    return lVal;
                }
            }

            if (chcEstudioJuridico.Checked && String.IsNullOrEmpty(txtDirEstudio.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar la dirección del estudio juridico.", "Validación de registro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDomicilio.Focus();
                return lVal;
            }
            


            //if (String.IsNullOrEmpty(txtTelefFijo.Text.Trim()))
            //{
            //    MessageBox.Show("Debe ingresar el telefono fijo del abogado.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtTelefFijo.Focus();
            //    return lVal;
            //}

            if (!chcExterno.Checked)
            {
                if (String.IsNullOrEmpty(txtTelefCel1.Text.Trim()))
                {
                    MessageBox.Show("Debe ingresar el teléfono celular institucional.", "Validación de registro", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtTelefCel1.Focus();
                    return lVal;
                }
            }

            if (chcEstudioJuridico.Checked && String.IsNullOrEmpty(txtTelefCel1.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el teléfono celular estudio juridico.", "Validación de registro", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtTelefCel1.Focus();
                return lVal;
            }

            if (txtTelefCel2.Enabled && String.IsNullOrEmpty(txtTelefCel2.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el teléfono celular personal.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefCel2.Focus();
                return lVal;
            }

            if (txtEmail.Enabled && String.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el correo electrónico del abogado.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return lVal;
            }

            if (txtNumColegio.Enabled && String.IsNullOrEmpty(txtNumColegio.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el número de colegiatura del abogado.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumColegio.Focus();
                return lVal;
            }

            if (txtRepresentanteLegal.Enabled && String.IsNullOrEmpty(txtRepresentanteLegal.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el representante legal del estudio.", "Validación de registro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRepresentanteLegal.Focus();
                return lVal;
            }
            if (txtAbogadoResponsable.Enabled && String.IsNullOrEmpty(txtAbogadoResponsable.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar la abogado responsable de estudio juridico", "Validación de registro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAbogadoResponsable.Focus();
                return lVal;
            }

            if (cboAbogado.Items.Count > 0 && cEvento== Transaccion.Nuevo)
            {
                var dtRegistros = (DataTable)cboAbogado.DataSource;

                int nExiste = dtRegistros.AsEnumerable().Count(x => x["cDocIdent"].ToString() == txtDocumento.Text.Trim());

                if (nExiste > 0)
                {
                    MessageBox.Show("Ya existe un registro con el número de documento ingresado.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDocumento.Focus();
                    return lVal;
                }
            }

            if (!rbtActivo.Checked && !rbtnInactivo.Checked)
            {
                MessageBox.Show("Debe seleccionar un estado para el registro.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rbtActivo.Focus();
                return lVal;
            }

            lVal = true;
            return lVal;
        }

        private void cargarAbogado()
        {
            if (this.cboAbogado.Items.Count > 0)
            {
                var abogado = (DataRowView)cboAbogado.SelectedItem;

                txtDocumento.Text = abogado["cDocIdent"].ToString();
                txtApePaterno.Text = abogado["cApePaterno"].ToString();
                txtApeMaterno.Text = abogado["cApeMaterno"].ToString();
                txtNombres.Text = abogado["cNombres"].ToString();
                txtDomicilio.Text = abogado["cDirDomicilio"].ToString();
                txtDirEstudio.Text = abogado["cDirEstudio"].ToString();
                txtTelefFijo.Text = abogado["cTelfFijo"].ToString();
                txtTelefCel1.Text = abogado["cTelfCel1"].ToString();
                txtTelefCel2.Text = abogado["cTelfCel2"].ToString();
                txtEmail.Text = abogado["cEmail"].ToString();
                txtNumColegio.Text = abogado["cNumColeg"].ToString();
                txtRepresentanteLegal.Text = abogado["cRepresentanteLegal"].ToString();
                txtAbogadoResponsable.Text = abogado["cAbogadoACargo"].ToString();                
                chcExterno.Checked = Convert.ToBoolean(abogado["lExterno"]);
                chcEstudioJuridico.Checked = Convert.ToBoolean(abogado["lEstudioJuridico"]);
                if(chcEstudioJuridico.Checked)
                    txtNombres.Text = abogado["cRazonSocial"].ToString();

                if (Convert.ToBoolean(abogado["lVigente"]) == false)
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
            cboAbogado.SelectedIndexChanged -= cboAbogado_SelectedIndexChanged;
            cboAbogado.SelectedIndex = -1;
            cboAbogado.SelectedIndexChanged += cboAbogado_SelectedIndexChanged;

            txtDocumento.Text = String.Empty;
            txtApePaterno.Text = String.Empty;
            txtApeMaterno.Text = String.Empty;
            txtNombres.Text = String.Empty;
            txtNumColegio.Text = String.Empty;
            txtDomicilio.Text = String.Empty;
            txtDirEstudio.Text = String.Empty;
            txtTelefFijo.Text = String.Empty;
            txtTelefCel1.Text = String.Empty;
            txtTelefCel2.Text = String.Empty;
            txtEmail.Text = String.Empty;
            chcExterno.Checked = false;
            rbtnInactivo.Checked = false;
            rbtActivo.Checked = false;
            chcEstudioJuridico.Enabled = false;
            chcEstudioJuridico.Checked = false;
        }

        private void habilitarControles(bool estado)
        {
            txtDocumento.Enabled = estado;
            txtApePaterno.Enabled = estado;
            txtApeMaterno.Enabled = estado;
            txtNombres.Enabled = estado;
            txtNumColegio.Enabled = estado;
            txtDomicilio.Enabled = estado;
            txtDirEstudio.Enabled = estado;
            txtTelefFijo.Enabled = estado;
            txtTelefCel1.Enabled = estado;
            txtTelefCel2.Enabled = estado;
            txtEmail.Enabled = estado;
            rbtActivo.Enabled = estado;
            chcExterno.Enabled = estado;
            rbtnInactivo.Enabled = estado;
            cboAbogado.Enabled = !estado;
            chcEstudioJuridico.Enabled = estado;
            txtAbogadoResponsable.Enabled = estado;
            txtRepresentanteLegal.Enabled = estado;
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
            chcEstudioJuridico.Enabled = true;
            txtAbogadoResponsable.Enabled = false;
            txtRepresentanteLegal.Enabled = false;

            txtDocumento.Focus();
            txtDocumento.Select();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.cboAbogado.Items.Count == 0)
            {
                MessageBox.Show("No existen registros por editar", "Validación de registros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cEvento = Transaccion.Edita;
            btnEditar.Enabled = false;
            btnNuevo.Enabled = false;
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = true;
            chcEstudioJuridico.Enabled = true;
            habilitarControles(true);

            activarControlObjetos(this, EventoFormulario.EDITAR);

            if (chcEstudioJuridico.Checked)
            {
                lblNombre.Text = "Razon Social:";
                lblDocumento.Text = "R.U.C.:";
                txtDocumento.MaxLength = 11;
                txtApeMaterno.Enabled = false;
                txtApePaterno.Enabled = false;
                txtDomicilio.Enabled = false;
                txtNumColegio.Enabled = false;
                txtTelefCel2.Enabled = false;
                txtEmail.Enabled = false;
                txtRepresentanteLegal.Enabled = true;
                txtAbogadoResponsable.Enabled = true;
            }
            else
            {
                lblNombre.Text = "Nombres:";
                lblDocumento.Text = "D.N.I.:";
                txtDocumento.MaxLength = 8;
                txtApeMaterno.Enabled = true;
                txtApePaterno.Enabled = true;
                txtDomicilio.Enabled = true;
                txtNumColegio.Enabled = true;
                txtTelefCel2.Enabled = true;
                txtEmail.Enabled = true;
                txtRepresentanteLegal.Enabled = false;
                txtAbogadoResponsable.Enabled = false;
            }

            txtDocumento.Focus();
            txtDocumento.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
            btnNuevo.Enabled = true;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
            chcEstudioJuridico.Enabled = false;
            cboAbogado.SelectedIndex = cboAbogado.Items.Count > 0 ? 0 : -1;
            cargarAbogado();
            habilitarControles(false);

            cboAbogado.Focus();
            cboAbogado.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;

            int idAbogado = cboAbogado.SelectedValue != null ? Convert.ToInt32(this.cboAbogado.SelectedValue):0;
            string cDocIdent = txtDocumento.Text.Trim();
            string cApePaterno = txtApePaterno.Text.Trim();
            string cApeMaterno = txtApeMaterno.Text.Trim();
            string cNombres = txtNombres.Text.Trim();
            string cNumColeg = txtNumColegio.Text.Trim();
            bool lVigente = rbtActivo.Checked;
            string cDirDomicilio = txtDomicilio.Text.Trim();
            string cDirEstudio = txtDirEstudio.Text.Trim();
            string cTelfFijo = txtTelefFijo.Text.Trim();
            string cTelfCel1 = txtTelefCel1.Text.Trim();
            string cTelfCel2 = txtTelefCel2.Text.Trim();
            string cEmail = txtEmail.Text.Trim();
            string cRepresentanteLegal = txtRepresentanteLegal.Text.Trim();
            string cAbogadoResponsable = txtAbogadoResponsable.Text.Trim();
            bool lExterno = chcExterno.Checked;
            bool lEstudioJuridico = chcEstudioJuridico.Checked;

            clsDBResp objDbResp = null;

            if (cEvento == Transaccion.Nuevo)
            {
                objDbResp = procesojudicial.InsertarAbogadoIFI(cDocIdent, cApePaterno, cApeMaterno, cNombres, cNumColeg,
                                                    cDirDomicilio, cDirEstudio, cTelfFijo, cTelfCel1, cTelfCel2,
                                                    cEmail, lExterno, lVigente, lEstudioJuridico, cRepresentanteLegal, cAbogadoResponsable);

            
            }
            else
            {
                objDbResp = procesojudicial.ActualizarAbogadoIFI(idAbogado, cDocIdent, cApePaterno, cApeMaterno, cNombres, cNumColeg,
                                                    cDirDomicilio, cDirEstudio, cTelfFijo, cTelfCel1, cTelfCel2,
                                                    cEmail, lExterno, lVigente, lEstudioJuridico, cRepresentanteLegal, cAbogadoResponsable);
                
            }

            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, "Registro de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnEditar.Enabled = true;
                btnNuevo.Enabled = true;
                btnCancelar.Enabled = false;
                btnGrabar.Enabled = false;
                cboAbogado.cargarTodos();
                cargarAbogado();
                habilitarControles(false);

                cboAbogado.Focus();
                cboAbogado.Select();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, "Registro de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
        }

        private void cboAbogado_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarAbogado();
        }

        private void chcEstudioJuridico_CheckedChanged(object sender, EventArgs e)
        {
            if (chcEstudioJuridico.Enabled)
            {
                if (chcEstudioJuridico.Checked)
                {
                    lblNombre.Text = "Razon Social:";
                    lblDocumento.Text = "R.U.C.:";
                    txtDocumento.MaxLength = 11;
                    txtApeMaterno.Enabled = false;
                    txtApePaterno.Enabled = false;
                    txtDomicilio.Enabled = false;
                    txtNumColegio.Enabled = false;
                    txtTelefCel2.Enabled = false;
                    txtEmail.Enabled = false;
                    txtRepresentanteLegal.Enabled = true;
                    txtAbogadoResponsable.Enabled = true;
                }
                else
                {
                    lblNombre.Text = "Nombres:";
                    lblDocumento.Text = "D.N.I.:";
                    txtDocumento.MaxLength = 8;
                    txtApeMaterno.Enabled = true;
                    txtApePaterno.Enabled = true;
                    txtDomicilio.Enabled = true;
                    txtNumColegio.Enabled = true;
                    txtTelefCel2.Enabled = true;
                    txtEmail.Enabled = true;
                    txtRepresentanteLegal.Enabled = false;
                    txtAbogadoResponsable.Enabled = false;
                }
            }
            else
            {
                if (chcEstudioJuridico.Checked)
                {
                    lblNombre.Text = "Razon Social:";
                    lblDocumento.Text = "R.U.C.:";
                }
                else
                {
                    lblNombre.Text = "Nombres:";
                    lblDocumento.Text = "D.N.I.:";
                }
                
            }
        }

        private void txtApePaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarSoloLetras((txtBase)sender, e);
        }

        private void validarSoloLetras(txtBase txt, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 8 || e.KeyChar == 32 || e.KeyChar == 209 || e.KeyChar == 241)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtApeMaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarSoloLetras((txtBase)sender, e);
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarSoloLetras((txtBase)sender, e);
        }
    }
}
