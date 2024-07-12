using EntityLayer;
using GEN.CapaNegocio;
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

namespace RCP.Presentacion
{
    public partial class frmMantTramos : frmBase
    {
        clsCNTramo cnTramo = new clsCNTramo();
        DataTable dtTramos= new DataTable();
        int idTramo = 0;
        int idAccionSeleccionada = 0;//1 = nuevo, 2 = modificar
        public frmMantTramos()
        {
            InitializeComponent();
        }

        private void frmMantTramos_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cboTramo_SelectedIndexChanged(object sender, EventArgs e)
        {
            obtenerDatos();
        }

        private void limpiarCampos()
        {
            cboTramo.SelectedIndex = -1;
            cboTipoTramo.SelectedIndex = -1;
            txtNombreTramo.Clear();
            txtDescripcionTramo.Clear();
            txtAtrasoMinimo.Clear();
            txtAtrasoMaximo.Clear();
            chcVigente.Checked = false;
        }

        private void obtenerDatos()
        {
            if (cboTramo.SelectedIndex >= 0 && dtTramos.Rows.Count > 0)
            {
                idTramo = Convert.ToInt32(dtTramos.Rows[cboTramo.SelectedIndex]["idTramo"]);
                txtNombreTramo.Text = dtTramos.Rows[cboTramo.SelectedIndex]["cNombre"].ToString();
                txtDescripcionTramo.Text = dtTramos.Rows[cboTramo.SelectedIndex]["cDescripcion"].ToString();
                txtAtrasoMinimo.Text = dtTramos.Rows[cboTramo.SelectedIndex]["nDiasMinimo"].ToString();
                txtAtrasoMaximo.Text = dtTramos.Rows[cboTramo.SelectedIndex]["nDiasMaximo"].ToString();
                chcVigente.Checked = Convert.ToBoolean(dtTramos.Rows[cboTramo.SelectedIndex]["lVigente"]);
                cboTipoTramo.SelectedValue = dtTramos.Rows[cboTramo.SelectedIndex]["idTramoGestion"];
            }            
        }

        private void cargar()
        {
            cboTramo.ListarTodos();
            dtTramos = (DataTable)cboTramo.DataSource;
            cboTramo.SelectedIndex = -1;
            bloquearControles(1);
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            bloquearControles(2);
            idAccionSeleccionada = 1;
        }

        private void bloquearControles(int idAccion)
        {
            switch (idAccion)
            {
                case 1://only read
                    cboTramo.Enabled = true;
                    txtNombreTramo.Enabled = false;
                    txtDescripcionTramo.Enabled = false;
                    txtAtrasoMinimo.Enabled = false;
                    txtAtrasoMaximo.Enabled = false;
                    chcVigente.Enabled = false;
                    cboTipoTramo.Enabled = false;

                    btnNuevo1.Enabled = true;
                    btnEditar1.Enabled = true;
                    btnGrabar1.Enabled = false;
                    btnCancelar1.Enabled = false;
                    break;
                case 2://nuevo
                    cboTramo.Enabled = false;
                    txtNombreTramo.Enabled = true;
                    txtDescripcionTramo.Enabled = true;
                    txtAtrasoMinimo.Enabled = true;
                    txtAtrasoMaximo.Enabled = true;
                    chcVigente.Enabled = true;
                    cboTipoTramo.Enabled = true;

                    btnNuevo1.Enabled = false;
                    btnEditar1.Enabled = false;
                    btnGrabar1.Enabled = true;
                    btnCancelar1.Enabled = true;
                    break;
                case 3://modificar
                    cboTramo.Enabled = false;
                    txtNombreTramo.Enabled = true;
                    txtDescripcionTramo.Enabled = true;
                    txtAtrasoMinimo.Enabled = true;
                    txtAtrasoMaximo.Enabled = true;
                    chcVigente.Enabled = true;
                    cboTipoTramo.Enabled = true;

                    btnNuevo1.Enabled = false;
                    btnEditar1.Enabled = false;
                    btnGrabar1.Enabled = true;
                    btnCancelar1.Enabled = true;
                    break;                
            }
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (cboTramo.SelectedIndex >= 0)
            {
                bloquearControles(3);
                idAccionSeleccionada = 2;
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            if (idAccionSeleccionada == 1)
            {
                limpiarCampos();
            }
            else if (idAccionSeleccionada == 2)
            {
                obtenerDatos();
            }
            bloquearControles(1);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if(validar())
            if (idAccionSeleccionada == 1)
            {
                DataTable dtResultado = cnTramo.registrarTramo(txtNombreTramo.Text, txtDescripcionTramo.Text, Convert.ToInt32(txtAtrasoMinimo.Text), Convert.ToInt32(txtAtrasoMaximo.Text), clsVarGlobal.User.cWinUser, chcVigente.Checked, Convert.ToInt32(cboTipoTramo.SelectedValue));
                if (Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                {
                    MessageBox.Show("Tramo agregado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bloquearControles(1);
                    cargar();
                    cboTramo.SelectedIndex = cboTramo.Items.Count - 1;
                }
                else
                {
                    MessageBox.Show("Error al agregar tramo: " + dtResultado.Rows[0][1], this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (idAccionSeleccionada == 2)
            {
                DataTable dtResultado = cnTramo.actualizarTramo(idTramo ,txtNombreTramo.Text, txtDescripcionTramo.Text, Convert.ToInt32(txtAtrasoMinimo.Text), Convert.ToInt32(txtAtrasoMaximo.Text), clsVarGlobal.User.cWinUser, chcVigente.Checked, Convert.ToInt32(cboTipoTramo.SelectedValue));
                if (Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                {
                    MessageBox.Show("Tramo actualizado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bloquearControles(1);
                    int idTemp = cboTramo.SelectedIndex;
                    cargar();
                    cboTramo.SelectedIndex = idTemp;
                }
                else
                {
                    MessageBox.Show("Error al actualizar tramo: " + dtResultado.Rows[0][1], this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool validar()
        {
            if (txtNombreTramo.Text.Length <= 0)
            {
                MessageBox.Show("Debe ingresar nombre del tramo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombreTramo.Focus();
                return false;
            }
            if (txtDescripcionTramo.Text.Length <= 0)
            {
                MessageBox.Show("Debe ingresar descripcion del tramo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescripcionTramo.Focus();
                return false;
            }
            if (cboTipoTramo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar tipo de tramo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboTipoTramo.Focus();
                return false;
            }
            if (txtAtrasoMinimo.Text.Length <= 0)
            {
                MessageBox.Show("Debe ingresar atraso minimo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAtrasoMinimo.Focus();
                return false;
            }
            if (txtAtrasoMaximo.Text.Length <= 0)
            {
                MessageBox.Show("Debe ingresar atraso maximo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAtrasoMaximo.Focus();
                return false;
            }
            if (Convert.ToInt32(txtAtrasoMinimo.Text) > Convert.ToInt32(txtAtrasoMaximo.Text))
            {
                MessageBox.Show("El atraso minimo no puede ser mayor al maximo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAtrasoMinimo.Focus();
                return false;
            }
            return true;
        }
    }
}
