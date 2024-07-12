using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmMantCategoriaOfi : frmBase
    {
        public frmMantCategoriaOfi()
        {
            InitializeComponent();
        }
        #region Variables globales
        clsCNCategoriaOficina cnCategoriaOficina = new clsCNCategoriaOficina();
        int idCategoriaOfi = 0;
        int idPeriodo;
        #endregion
        #region Eventos
        private void frmMantCategoriaOfi_Load(object sender, EventArgs e)
        {
            cargarInicio();
        }
        private void cboPeriodoCateOfi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCategorias();
        }
        private void cboCategoriaOficina1_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccionarCategoria();
        }
        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            registrarNuevaCategoria();
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            cancelarRegistro();
        }
        private void btnEditar1_Click(object sender, EventArgs e)
        {
            editarRegistro();

        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            grabarRegistro();

        }
        #endregion
        #region Metodos
        private void seleccionarCategoria()
        {
            if (cboCategoriaOficina.SelectedIndex >= 0)
            {
                DataTable dtCategoriaOficina = (DataTable)cboCategoriaOficina.DataSource;
                txtDescripcion.Text = dtCategoriaOficina.Rows[cboCategoriaOficina.SelectedIndex]["cDescripcion"].ToString();
                chbVigente.Checked = Convert.ToBoolean(dtCategoriaOficina.Rows[cboCategoriaOficina.SelectedIndex]["lVigente"]);
            }
        }
        private void registrarNuevaCategoria()
        {
            habilitarControles(4, true);
        }
        private void cancelarRegistro()
        {
            cargarInicio();
        }
        private void editarRegistro()
        {
            idCategoriaOfi = Convert.ToInt32(cboCategoriaOficina.SelectedValue);
            habilitarControles(5,true);
        }
        private void grabarRegistro()
        {
            if (validar())
            {
                if (idCategoriaOfi == 0)
                {
                    DataTable dtResultado = cnCategoriaOficina.InsertarCategoriaOficina(txtDescripcion.Text.Trim(), idPeriodo, chbVigente.Checked, clsVarGlobal.User.idUsuario);
                    if (Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                    {
                        MessageBox.Show("Categoría de oficina registrada correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar Categoría de oficina.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    DataTable dtResultado = cnCategoriaOficina.ActualizarCategoriaOficina(idCategoriaOfi, txtDescripcion.Text.Trim(), idPeriodo, chbVigente.Checked, clsVarGlobal.User.idUsuario);
                    if (Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                    {
                        MessageBox.Show("Categoría de oficina editada correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al editar Categoría de oficina.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                cargarInicio();
                habilitarControles(6, true);
            }
        }
        private bool validar()
        {
            if (txtDescripcion.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe ingresar la descripción", "Validación de campo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescripcion.Focus();
                return false;
            }
            return true;
        }
        private void cargarInicio()
        {
            habilitarControles(1, false);
            this.cboPeriodoCateOfi.cargarDatos(false);
            idPeriodo = Convert.ToInt16(cboPeriodoCateOfi.SelectedValue);
            cboCategoriaOficina.cargarDatos(false, idPeriodo);////

            seleccionarCategoria();
        }
        private void cargarCategorias()
        {
            idPeriodo = Convert.ToInt16(cboPeriodoCateOfi.SelectedValue);
            this.txtDescripcion.Clear();
            this.chbVigente.Checked = false;
            cboCategoriaOficina.cargarDatos(false, idPeriodo);
            
            DataTable dt = cnCategoriaOficina.obtenerPeriodoCateOfi(false, idPeriodo);
            this.lblValor.Text = Convert.ToString(dt.Rows[0]["cEstado"]);
            if (Convert.ToInt16(dt.Rows[0]["idEstadoCateOfi"]) != 2)
            {
                habilitarControles(2, false);
            }
            else
            {
                habilitarControles(2,true);
            }

            if (cboCategoriaOficina.SelectedItem == null || Convert.ToInt16(dt.Rows[0]["idEstadoCateOfi"]) != 2)
            {
                habilitarControles(3, false);
            }
            else
            {
                habilitarControles(3, true);
            }

            seleccionarCategoria();
        }
        private void habilitarControles(int nValor, Boolean lValor)
        {
            switch (nValor)
            {
                case 1:
                    this.cboPeriodoCateOfi.Enabled = !lValor;
                    this.cboCategoriaOficina.Enabled = !lValor;
                    this.txtDescripcion.Enabled = lValor;
                    this.chbVigente.Enabled = lValor;
                    this.btnNuevo.Enabled = lValor;
                    this.btnEditar.Enabled = lValor;
                    this.btnGrabar.Enabled = lValor;
                    this.btnCancelar.Enabled = lValor;
                    break;
                case 2:
                    this.btnNuevo.Enabled = lValor;
                    break;
                case 3:
                    this.btnEditar.Enabled = lValor;
                    break;
                case 4:
                    this.idCategoriaOfi = 0;
                    this.cboCategoriaOficina.Enabled = !lValor;
                    this.cboCategoriaOficina.SelectedIndex = -1;
                    this.txtDescripcion.Clear();
                    this.txtDescripcion.Enabled = lValor;
                    this.chbVigente.Checked = !lValor;
                    this.chbVigente.Enabled = lValor;
                    this.btnNuevo.Enabled = !lValor;
                    this.btnEditar.Enabled = !lValor;
                    this.btnCancelar.Enabled = lValor;
                    this.btnGrabar.Enabled = lValor;
                    this.cboPeriodoCateOfi.Enabled = !lValor;
                    this.chbVigente.Checked = true;
                    break;
                case 5:
                    this.cboPeriodoCateOfi.Enabled = !lValor;
                    this.cboCategoriaOficina.Enabled = lValor;
                    this.txtDescripcion.Enabled = lValor;
                    this.chbVigente.Enabled = lValor;
                    this.btnNuevo.Enabled = !lValor;
                    this.btnEditar.Enabled = !lValor;
                    this.btnCancelar.Enabled = lValor;
                    this.btnGrabar.Enabled = lValor;
                    this.cboCategoriaOficina.Enabled = !lValor;
                    break;
                case 6:
                    this.cboCategoriaOficina.Enabled = lValor;
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
