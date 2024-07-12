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

namespace ADM.Presentacion
{
    public partial class frmMantenimientoUsuarioZona : frmBase
    {
        clsCNUsuario cnUsuario = new clsCNUsuario();
        DataTable dtZonas;

        public frmMantenimientoUsuarioZona()
        {
            InitializeComponent();
        }

        private void frmMantenimientoUsuarioZona_Load(object sender, EventArgs e)
        {
            cboZona1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            grbDatos.Enabled = false;
            conBusCol1.Enabled = true;
            btnCancelar1.Enabled = false;
            limpiar();
        }

        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                DataTable dtResultado = cnUsuario.agregarZona(idUsuario: Convert.ToInt32(conBusCol1.idUsu), idZona: Convert.ToInt32(cboZona1.SelectedValue), idUsuReg: clsVarGlobal.User.idUsuario);
                if (Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                {
                    MessageBox.Show("Se agregó la zona correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargar();
                }
                else
                {
                    MessageBox.Show("Error al agregar zona, intentelo de nuevo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private bool validar()
        {
            if (cboZona1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una zona a agregar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboZona1.Focus();
                return false;
            }
            int idZona = Convert.ToInt32(cboZona1.SelectedValue);
            var varZonas = (from zonas in dtZonas.AsEnumerable()
                            where Convert.ToInt32(zonas["idZona"]) == idZona
                            select zonas).ToList();
            if (varZonas.Count > 0)
            {
                MessageBox.Show("No puede agregar una zona que ya este en la lista de zonas asignadas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboZona1.Focus();
                return false;
            }
            return true;
        }

        private void conBusCol1_BuscarUsuario(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            if (!String.IsNullOrEmpty(conBusCol1.idUsu))
            {
                dtZonas = cnUsuario.ObtenerZonasUsuario(Convert.ToInt32(conBusCol1.idUsu));
                dtgZonas.DataSource = dtZonas;
                formatearGrill();
                dtgZonas.ClearSelection();
                grbDatos.Enabled = true;
                conBusCol1.Enabled = false;
                btnCancelar1.Enabled = true;
            }
        }

        private void formatearGrill()
        {
            foreach (DataGridViewColumn columna in dtgZonas.Columns)
            {
                columna.Visible = false;
            }

            dtgZonas.Columns["cDesZona"].Visible = true;

            dtgZonas.Columns["cDesZona"].HeaderText = "Zona";

            dtgZonas.Columns["cDesZona"].Width = 300;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            grbDatos.Enabled = false;
            conBusCol1.Enabled = true;
            btnCancelar1.Enabled = false;
            limpiar();
        }

        private void limpiar()
        {
            conBusCol1.LimpiarDatos();
            conBusCol1.Enabled = true;
            conBusCol1.txtCod.Focus();
            cboZona1.SelectedIndex = -1;
            dtgZonas.DataSource = null;
        }

        private void btnMiniQuitar1_Click(object sender, EventArgs e)
        {
            if (dtgZonas.CurrentRow != null)
            {
                DataTable dtResultado = cnUsuario.quitarZona(idZonaUsuario: Convert.ToInt32(dtgZonas.CurrentRow.Cells["idZonaUsuario"].Value), idUsuReg: clsVarGlobal.User.idUsuario);
                if (Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                {
                    MessageBox.Show("Se quitó la zona correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargar();
                }
                else
                {
                    MessageBox.Show("Error al quitar zona, intentelo de nuevo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar la zona a eliminar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
