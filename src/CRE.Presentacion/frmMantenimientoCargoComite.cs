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
using CRE.CapaNegocio;
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class frmMantenimientoCargoComite : frmBase
    {

        #region Variables Globales
        clsCNComite cncomite = new clsCNComite();

        #endregion

        public frmMantenimientoCargoComite()
        {
            InitializeComponent();
            cboArea1.CargarTodasArea();
            cboArea1.SelectedValue = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            cboCargoPersonalcs1.CargarCargo(Convert.ToInt32(cboArea1.SelectedValue));
            cargarCargosAgencia();
        }

        private bool validar()
        {
            bool lVal = false;

            if (cboCargoPersonalcs1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe de seleccionar un cargo de personal", "Validación de cargo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }

            if (lstCargosAgencia.Items.Count > 0)
            {
                int idCargo = Convert.ToInt32(cboCargoPersonalcs1.SelectedValue);
                int nExiste = ((DataTable)lstCargosAgencia.DataSource).AsEnumerable().Where(x => Convert.ToInt32(x["idCargo"]) == idCargo).Count();

                if (nExiste > 0)
                {
                    MessageBox.Show("Ya se agregó el cargo para la agencia seleccionada", "Validación de cargo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return lVal;
                }
            }
            

            lVal = true;
            return lVal;
        }

        private void cargarCargosAgencia()
        {
            lstCargosAgencia.DataSource = null;
            var dtCargos = cncomite.ListarCargoComiteid(Convert.ToInt32(cboAgencias1.SelectedValue));
            if (dtCargos.Rows.Count > 0)
            {
                lstCargosAgencia.DataSource = dtCargos;
                lstCargosAgencia.ValueMember = dtCargos.Columns[0].ColumnName;
                lstCargosAgencia.DisplayMember = dtCargos.Columns[1].ColumnName;
            }            
        }

        private void cboArea1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboArea1.SelectedIndex > -1)
            {
                if (cboArea1.SelectedValue is DataRowView)
                {
                    return;
                }
                cboCargoPersonalcs1.CargarCargo(Convert.ToInt32(cboArea1.SelectedValue));
            }
        }

        private void cboAgencias1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCargosAgencia();
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            cboArea1.Enabled = true;
            cboCargoPersonalcs1.Enabled = true;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
            btnNuevo1.Enabled = false;
            btnEliminar1.Enabled = false;
            cboAgencias1.Enabled = false;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            cboArea1.Enabled = false;
            cboCargoPersonalcs1.Enabled = false;
            btnCancelar1.Enabled = false;
            btnGrabar1.Enabled = false;
            btnNuevo1.Enabled = true;
            cboAgencias1.Enabled = true;
            btnEliminar1.Enabled = true;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                cncomite.InsertarCargoComite(Convert.ToInt32(cboAgencias1.SelectedValue), Convert.ToInt32(cboCargoPersonalcs1.SelectedValue),
                                                true, clsVarGlobal.User.idUsuario);
                MessageBox.Show("Los datos se guardaron corectamente", "Registro de cargo comité", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cargarCargosAgencia();
                cboArea1.Enabled = false;
                cboCargoPersonalcs1.Enabled = false;
                btnCancelar1.Enabled = false;
                btnGrabar1.Enabled = false;
                btnNuevo1.Enabled = true;
                cboAgencias1.Enabled = true;
            }
        }

        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            if (lstCargosAgencia.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("¿Esta seguró de eliminar el cargo de la agencia seleccionada?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    cncomite.EliminarCargoComite(Convert.ToInt32(cboAgencias1.SelectedValue), Convert.ToInt32(lstCargosAgencia.SelectedValue));
                    MessageBox.Show("Los datos se guardaron corectamente", "Registro de cargo comité", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cargarCargosAgencia();
                    cboArea1.Enabled = false;
                    cboCargoPersonalcs1.Enabled = false;
                    btnCancelar1.Enabled = false;
                    btnGrabar1.Enabled = false;
                    btnNuevo1.Enabled = true;
                    cboAgencias1.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Seleccione un item de la lista para eliminar", "Registro de cargo comité", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
