using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;

namespace CRE.Presentacion
{
    public partial class frmTasador : frmBase
    {
        #region Variables
        private Transaccion cEvento;
        #endregion

        public frmTasador()
        {
            InitializeComponent();
            cboTasador.cargarTodos();
            conBusUbig.cargar();
            conBusUbig.cboPais.SelectedValue = 173;
        }

        #region Eventos
        private void Form_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            cargartasador();

            btnNuevo.Enabled = true;
            btnEditar.Enabled = cboTasador.Items.Count > 0;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;

            cboTasador.Focus();
            cboTasador.Select();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cEvento = Transaccion.Nuevo;
            btnEditar.Enabled = false;
            btnNuevo.Enabled = false;
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = true;
            limpiarcontroles();
            rbtActivo.Checked = true;
            habilitarcontroles(true);

            txtDocumento.Focus();
            txtDocumento.Select();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (cboTasador.Items.Count==0)
            {
                MessageBox.Show("No existen registros por editar.", "Validación de registros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cEvento = Transaccion.Edita;
            btnEditar.Enabled = false;
            btnNuevo.Enabled = false;
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = true;
            habilitarcontroles(true);

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
            cboTasador.SelectedIndex = cboTasador.Items.Count > 0 ? 0 : -1;
            cargartasador();
            habilitarcontroles(false);

            cboTasador.Focus();
            cboTasador.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if(!validar()) return;

            clsTasador objtasador = new clsTasador();

            objtasador.idTasador = cboTasador.SelectedValue != null ?  Convert.ToInt32(cboTasador.SelectedValue):0;
            objtasador.cDocumento = txtDocumento.Text.Trim();
            objtasador.cPaterno = txtPaterno.Text.Trim();
            objtasador.cMaterno = txtMaterno.Text.Trim();
            objtasador.cNombres = txtNombres.Text.Trim();
            objtasador.cTasador = String.Format("{0} {1} {2}", objtasador.cPaterno, objtasador.cMaterno, objtasador.cNombres);
            objtasador.cResolSBS = txtResolSBS.Text.Trim();
            objtasador.dFecResolucion = dtpFecResolucion.Value.Date;
            objtasador.dFinResolucion = dtpFinResolucion.Value.Date;
            objtasador.cDireccion = txtDireccion.Text.Trim();
            objtasador.cDirEstudio = txtDirEstudio.Text.Trim();
            objtasador.idUbigeo = Convert.ToInt32(conBusUbig.cboDistrito.SelectedValue);
            objtasador.cTelefFijo = txtTelefFijo.Text.Trim();
            objtasador.cTelefCel = txtTelefCel.Text.Trim();
            objtasador.cEspecialidad = txtEspecialidad.Text.Trim();
            
            objtasador.dFechaReg = clsVarGlobal.dFecSystem.Date;
            objtasador.lVigente = rbtActivo.Checked;

            clsDBResp objDbResp = null;

            objDbResp = new clsCNTasador().CNGuardarTasador(objtasador);

            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, "Mantenimiento de tasador", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnEditar.Enabled = true;
                btnNuevo.Enabled = true;
                btnCancelar.Enabled = false;
                btnGrabar.Enabled = false;
                cboTasador.cargarTodos();
                cargartasador();
                habilitarcontroles(false);

                cboTasador.Focus();
                cboTasador.Select();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, "Mantenimiento de tasador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cboTasador_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargartasador();     
        }

        #endregion

        #region Metodos
        private void limpiarcontroles()
        {
            cboTasador.SelectedIndexChanged -= cboTasador_SelectedIndexChanged;
            cboTasador.SelectedIndex = -1;
            cboTasador.SelectedIndexChanged += cboTasador_SelectedIndexChanged;

            txtDocumento.Text = String.Empty;
            txtPaterno.Text = String.Empty;
            txtMaterno.Text=String.Empty;
            txtNombres.Text = String.Empty;
            txtResolSBS.Text=String.Empty;
            dtpFecResolucion.Value = clsVarGlobal.dFecSystem.Date;
            dtpFinResolucion.Value = clsVarGlobal.dFecSystem.Date;
            txtDireccion.Text = String.Empty;
            txtDirEstudio.Text=String.Empty;
            conBusUbig.nIdNodo = 0;
            conBusUbig.cargar();
            conBusUbig.cboPais.SelectedValue = 173;

            txtTelefFijo.Text = String.Empty;
            txtTelefCel.Text = String.Empty;
            txtEspecialidad.Text=String.Empty;

            rbtnInactivo.Checked = false;
            rbtActivo.Checked = false;
        }

        private void habilitarcontroles(bool estado)
        {
            txtDocumento.Enabled = estado;
            txtPaterno.Enabled = estado;
            txtMaterno.Enabled = estado;
            txtNombres.Enabled = estado;
            txtResolSBS.Enabled = estado;
            dtpFecResolucion.Enabled = estado;
            dtpFinResolucion.Enabled = estado;
            txtDireccion.Enabled = estado;
            txtDirEstudio.Enabled = estado;
            conBusUbig.Enabled = estado;
            txtTelefFijo.Enabled = estado;
            txtTelefCel.Enabled = estado;
            txtEspecialidad.Enabled = estado;

            rbtActivo.Enabled = estado;
            rbtnInactivo.Enabled = estado;
            cboTasador.Enabled = !estado;
        }

        private void cargartasador()
        {
            if (cboTasador.Items.Count>0)
            {
                clsTasador tasador = (clsTasador)cboTasador.SelectedItem;

                txtDocumento.Text = tasador.cDocumento;
                txtPaterno.Text = tasador.cPaterno;
                txtMaterno.Text = tasador.cMaterno;
                txtNombres.Text = tasador.cNombres;
                txtResolSBS.Text = tasador.cResolSBS;
                dtpFecResolucion.Value = tasador.dFecResolucion.Date;
                dtpFinResolucion.Value = tasador.dFinResolucion.Date;
                txtDireccion.Text = tasador.cDireccion;
                txtDirEstudio.Text = tasador.cDirEstudio;
                conBusUbig.cargarUbigeo(Convert.ToInt32(tasador.idUbigeo));
                txtTelefFijo.Text = tasador.cTelefFijo;
                txtTelefCel.Text = tasador.cTelefCel;
                txtEspecialidad.Text = tasador.cEspecialidad;
                rbtActivo.Checked = tasador.lVigente;
                rbtnInactivo.Checked = !tasador.lVigente;
            }

        }

        private bool validar()
        {
            if (String.IsNullOrEmpty(txtDocumento.Text.Trim()))
            {
                MessageBox.Show("Ingrese el documento de identidad.", "Validación de campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtPaterno.Text.Trim()))
            {
                MessageBox.Show("Ingrese el apellido paterno.", "Validación de campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPaterno.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtMaterno.Text.Trim()))
            {
                MessageBox.Show("Ingrese el apellido materno.", "Validación de campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaterno.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtResolSBS.Text.Trim()))
            {
                MessageBox.Show("Ingrese la resolución SBS.", "Validación de campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtResolSBS.Focus();
                return false;
            }

            if (dtpFinResolucion.Value.Date<dtpFecResolucion.Value.Date)
            {
                MessageBox.Show("La fecha final de la resolución no puede ser anterior a la fecha de inicio.", "Validación de campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFinResolucion.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtDireccion.Text.Trim()))
            {
                MessageBox.Show("Ingrese la dirección.", "Validación de campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
                return false;
            }

            if (conBusUbig.cboDistrito.SelectedIndex<=0)
            {
                MessageBox.Show("seleccione el ubigeo de la dirección.", "Validación de campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return false;
            }

            //if (String.IsNullOrEmpty(txtTelefFijo.Text.Trim()))
            //{
            //    MessageBox.Show("Ingrese el teléfono fijo.", "Validación de campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtTelefFijo.Focus();
            //    return false;
            //}

            if (String.IsNullOrEmpty(txtTelefCel.Text.Trim()))
            {
                MessageBox.Show("Ingrese el teléfono celular.", "Validación de campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefCel.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtEspecialidad.Text.Trim()))
            {
                MessageBox.Show("Ingrese la especialidad.", "Validación de campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEspecialidad.Focus();
                return false;
            }

            if (!rbtActivo.Checked && !rbtnInactivo.Checked)
            {
                MessageBox.Show("seleccione una estado para el registro.", "Validación de campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rbtActivo.Focus();
                return false;
            }

            return true; 
        }

        #endregion

    }
}
