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
    public partial class frmMantenParamEvalSobredeudaSolCre : frmBase
    {
        #region Varibles globales
        String cTituloMensaje = "Mantenimiento de parámetros de evaluación de sobreendeudamiento";
        clsCNSobreendeuda sobreendeuda = new clsCNSobreendeuda();
        String cTipoOperacion = "N";
        int idParametro = 0;
        #endregion
        public frmMantenParamEvalSobredeudaSolCre()
        {
            InitializeComponent();
        }

        #region Eventos
        private void frmMantenParamEvalSobredeudaSolCre_Load(object sender, EventArgs e)
        {
            cargarParametros();
            habilitarControles(false);
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            this.cTipoOperacion = "N";
            limpiarControles();
            habilitarControles(true);
        }
        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (this.dtgParametros.Rows.Count <= 0)
            {
                MessageBox.Show("No existen parametros para editar", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                DataTable dtInsercion = sobreendeuda.guardaParamSobredeudaSolCre(0, this.txtNombreP.Text, this.txtDescripcion.Text, this.txtSigno.Text, this.nudConstanteBase.Value, this.txtSimbolo.Text, this.chcVigencia.Checked, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
                MessageBox.Show(dtInsercion.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtInsercion.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }
            else if (this.cTipoOperacion == "A")
            {
                DataTable dtInsercion = sobreendeuda.guardaParamSobredeudaSolCre(this.idParametro, this.txtNombreP.Text, this.txtDescripcion.Text, this.txtSigno.Text, this.nudConstanteBase.Value, this.txtSimbolo.Text, this.chcVigencia.Checked, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
                MessageBox.Show(dtInsercion.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtInsercion.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }

            this.cTipoOperacion = "";
            limpiarControles();
            cargarParametros();
            habilitarControles(false);
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {

            this.cTipoOperacion = "";
            limpiarControles();
            verDetalle();
            habilitarControles(false);
        }

        private void dtgParametros_SelectionChanged(object sender, EventArgs e)
        {
            verDetalle();
        }

        #endregion

        #region Metodos
        private void cargarParametros()
        {
            DataTable dtParametros = sobreendeuda.listaParamSobredeudaSolCre(0);
            this.dtgParametros.DataSource = dtParametros;
            darFormatoDTGParametros();
        }
        private void darFormatoDTGParametros()
        {
            foreach (DataGridViewColumn item in this.dtgParametros.Columns)
            {
                item.Visible = false;
            }

            this.dtgParametros.Columns["idParametro"].Visible = true;
            this.dtgParametros.Columns["cParametro"].Visible = true;
            this.dtgParametros.Columns["cSigno"].Visible = true;
            this.dtgParametros.Columns["nConstanteBase"].Visible = true;
            this.dtgParametros.Columns["cSimbolo"].Visible = true;
            this.dtgParametros.Columns["lVigente"].Visible = true;            

            this.dtgParametros.Columns["idParametro"].FillWeight = 10;
            //this.dtgParametros.Columns["cParametro"].FillWeight = 20;
            this.dtgParametros.Columns["cSigno"].FillWeight = 20;
            this.dtgParametros.Columns["nConstanteBase"].FillWeight = 20;
            this.dtgParametros.Columns["cSimbolo"].FillWeight = 20;
            this.dtgParametros.Columns["lVigente"].FillWeight = 20;

            this.dtgParametros.Columns["idParametro"].HeaderText = "Id";
            this.dtgParametros.Columns["cParametro"].HeaderText = "Nombre parametro";
            this.dtgParametros.Columns["cSigno"].HeaderText = "Signo";
            this.dtgParametros.Columns["nConstanteBase"].HeaderText = "Constante";
            this.dtgParametros.Columns["cSimbolo"].HeaderText = "Simb.";
            this.dtgParametros.Columns["lVigente"].HeaderText = "Vigencia";
        }
        private Boolean validarDatos()
        {
            if (String.IsNullOrEmpty(this.txtNombreP.Text))
            {
                MessageBox.Show("Debe de ingresar un nombre para el parámetro", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNombreP.Focus();
                return true;
            }
            if (String.IsNullOrEmpty(this.txtDescripcion.Text))
            {
                MessageBox.Show("Debe de ingresar una descripción para resultado del parámetro", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtDescripcion.Focus();
                return true;
            }
            if (String.IsNullOrEmpty(this.txtSigno.Text))
            {
                MessageBox.Show("Debe de ingresar signo de comparación", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtSigno.Focus();
                return true;
            }
            if (String.IsNullOrEmpty(this.nudConstanteBase.Text))
            {
                MessageBox.Show("Debe de ingresar la constante base", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nudConstanteBase.Focus();
                return true;
            }
            return false;
        }
        private void verDetalle()
        {
            if (this.dtgParametros.SelectedRows.Count > 0)
            {
                this.idParametro = Convert.ToInt32(this.dtgParametros.SelectedRows[0].Cells["idParametro"].Value);
                this.txtNombreP.Text = Convert.ToString(this.dtgParametros.SelectedRows[0].Cells["cParametro"].Value);
                this.txtDescripcion.Text = Convert.ToString(this.dtgParametros.SelectedRows[0].Cells["cDescripcion"].Value);
                this.txtSigno.Text = Convert.ToString(this.dtgParametros.SelectedRows[0].Cells["cSigno"].Value);
                this.nudConstanteBase.Value = Convert.ToDecimal(this.dtgParametros.SelectedRows[0].Cells["nConstanteBase"].Value);
                this.txtSimbolo.Text = Convert.ToString(this.dtgParametros.SelectedRows[0].Cells["cSimbolo"].Value);
                this.chcVigencia.Checked = Convert.ToBoolean(this.dtgParametros.SelectedRows[0].Cells["lVigente"].Value);
            }    
        }

        private void habilitarControles(Boolean Val)
        {
            this.txtNombreP.Enabled = Val;
            this.txtDescripcion.Enabled = Val;
            this.txtSigno.Enabled = Val;
            this.nudConstanteBase.Enabled = Val;
            this.txtSimbolo.Enabled = Val;
            this.chcVigencia.Enabled = Val;

            this.btnNuevo1.Enabled = !Val;
            this.btnEditar1.Enabled = !Val;
            this.btnCancelar1.Enabled = Val;
            this.btnGrabar1.Enabled = Val;

            this.dtgParametros.Enabled = !Val;
        }
        private void limpiarControles()
        { 
            this.txtNombreP.Clear();
            this.txtDescripcion.Clear();
            this.txtSigno.Clear();
            this.nudConstanteBase.Value = 0.00m;
            this.txtSimbolo.Clear();
            this.chcVigencia.Checked = true;
        }
        #endregion        


    }
}

