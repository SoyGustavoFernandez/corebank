using EntityLayer;
using GEN.ControlesBase;
using RSG.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSG.Presentacion
{
    public partial class frmMantenCalificativoSobredeuda : frmBase
    {
        #region Varibles globales
        String cTituloMensaje = "Mantenimiento de calificación de sobreendeudamiento";
        clsCNSobreendeuda sobreendeuda = new clsCNSobreendeuda();
        String cTipoOperacion = "N";
        int idCalificacion = 0;
        #endregion

        public frmMantenCalificativoSobredeuda()
        {
            InitializeComponent();            
        }

        #region Eventos
        private void frmMantenCalificativoSobredeuda_Load(object sender, EventArgs e)
        {
            cargarCalificativos();
            habilitarControles(false);
        }
        private void dtgCalificacion_SelectionChanged(object sender, EventArgs e)
        {
            verDetalle();
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            this.cTipoOperacion = "N";
            limpiarControles();
            habilitarControles(true);
        }
        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (this.dtgCalificacion.Rows.Count <= 0)
            {
                MessageBox.Show("No existen calificativos para editar", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.cTipoOperacion = "A";
            habilitarControles(true);
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                return;
            }

            if (this.cTipoOperacion == "N")
            {
                DataTable dtInsercion = sobreendeuda.guardaCalificativoSobredeuda(-1, this.txtNombre.Text, this.chcAlerta.Checked, this.chcVigencia.Checked, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
                MessageBox.Show(dtInsercion.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtInsercion.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }
            else if (this.cTipoOperacion == "A")
            {
                DataTable dtInsercion = sobreendeuda.guardaCalificativoSobredeuda(this.idCalificacion, this.txtNombre.Text, this.chcAlerta.Checked, this.chcVigencia.Checked, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
                MessageBox.Show(dtInsercion.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtInsercion.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }

            this.cTipoOperacion = "";
            limpiarControles();
            cargarCalificativos();
            habilitarControles(false);
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {

            this.cTipoOperacion = "";
            limpiarControles();
            verDetalle();
            habilitarControles(false);
        }
        #endregion

        #region Metodos
        private void cargarCalificativos()
        {
            DataTable dtCalificativo = sobreendeuda.listaCalificSobredeudaCli(0);
            this.dtgCalificacion.DataSource = dtCalificativo;
            darFormatodtgCalificacion();
        }
        private void darFormatodtgCalificacion()
        {
            foreach (DataGridViewColumn item in this.dtgCalificacion.Columns)
            {
                item.Visible = false;
            }

            this.dtgCalificacion.Columns["idCalificacion"].Visible = true;
            this.dtgCalificacion.Columns["cCalificacion"].Visible = true;
            this.dtgCalificacion.Columns["lAlerta"].Visible = true;
            this.dtgCalificacion.Columns["lVigente"].Visible = true;

            this.dtgCalificacion.Columns["idCalificacion"].FillWeight = 10;
            //this.dtgCalificacion.Columns["cCalificacion"].Width = 20;            
            this.dtgCalificacion.Columns["lAlerta"].FillWeight = 20;
            this.dtgCalificacion.Columns["lVigente"].FillWeight = 20;

            this.dtgCalificacion.Columns["idCalificacion"].HeaderText = "Id";
            this.dtgCalificacion.Columns["cCalificacion"].HeaderText = "Nombre calificación";
            this.dtgCalificacion.Columns["lAlerta"].HeaderText = "Alerta";            
            this.dtgCalificacion.Columns["lVigente"].HeaderText = "Vigencia";
        }
        private Boolean validarDatos()
        {
            if (String.IsNullOrEmpty(this.txtNombre.Text))
            {
                MessageBox.Show("Debe de ingresar un nombre", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNombre.Focus();
                return true;
            }          
            return false;
        }
        private void verDetalle()
        {
            if (this.dtgCalificacion.SelectedRows.Count > 0)
            {
                this.idCalificacion = Convert.ToInt32(this.dtgCalificacion.SelectedRows[0].Cells["idCalificacion"].Value);
                this.txtNombre.Text = Convert.ToString(this.dtgCalificacion.SelectedRows[0].Cells["cCalificacion"].Value);
                this.chcAlerta.Checked = Convert.ToBoolean(this.dtgCalificacion.SelectedRows[0].Cells["lAlerta"].Value);
                this.chcVigencia.Checked = Convert.ToBoolean(this.dtgCalificacion.SelectedRows[0].Cells["lVigente"].Value);
            }
        }

        private void habilitarControles(Boolean Val)
        {
            this.txtNombre.Enabled = Val;
            this.chcAlerta.Enabled = Val;
            this.chcVigencia.Enabled = Val;

            this.btnNuevo1.Enabled = !Val;
            this.btnEditar1.Enabled = !Val;
            this.btnCancelar1.Enabled = Val;
            this.btnGrabar1.Enabled = Val;

            this.dtgCalificacion.Enabled = !Val;
        }
        private void limpiarControles()
        {
            this.txtNombre.Clear();
            this.chcAlerta.Checked = true;
            this.chcVigencia.Checked = true;
        }
        #endregion
        
       
    }
}
