using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmMantGrupoMeta : frmBase
    {
        #region Variable Globales
        DataTable dtGrupoMeta;
        clsCNMeta cnMeta = new clsCNMeta();
        Transaccion transaccion = Transaccion.Selecciona;
        string cTituloMsg = "Mantenimiento grupo meta";
        #endregion

        public frmMantGrupoMeta()
        {
            InitializeComponent();
            cargarDatos();
            activarForm(false);
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
        }

        private void cboTipoIncentivo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoIncentivo1.SelectedIndex < 0)
            {
                return;
            }

            cboTipoMeta2.cargarDatos(Convert.ToInt32(cboTipoIncentivo1.SelectedValue));
        }

        private void dtgGrupoMeta_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgGrupoMeta.RowCount == 0)
            {
                return;
            }

            int nIndice = e.RowIndex;

            cboGrupoAsesor1.SelectedValue = Convert.ToInt32(dtGrupoMeta.Rows[nIndice]["idGrupoAsesor"]);
            cboCategoriaAsesor1.SelectedValue = Convert.ToInt32(dtGrupoMeta.Rows[nIndice]["idCategoria"]);
            cboTipoIncentivo1.SelectedValue = Convert.ToInt32(dtGrupoMeta.Rows[nIndice]["idTipoIncentivo"]);
            cboTipoMeta2.SelectedValue = Convert.ToInt32(dtGrupoMeta.Rows[nIndice]["idTipoMeta"]);
            txtValorMeta.Text = dtGrupoMeta.Rows[nIndice]["nValorMeta"].ToString();
            chcVigente.Checked = Convert.ToBoolean(dtGrupoMeta.Rows[nIndice]["lVigente"]);
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            transaccion = Transaccion.Nuevo;
            activarForm(true);
            limpiar();
            chcVigente.Checked = true;
            chcVigente.Enabled = false;
            controlBotones(transaccion);
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            transaccion = Transaccion.Selecciona;
            activarForm(false);
            limpiar();
            controlBotones(transaccion);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }

            int idCategoria = Convert.ToInt32(cboCategoriaAsesor1.SelectedValue);
            int idTipoMeta = Convert.ToInt32(cboTipoMeta2.SelectedValue);
            int idGrupoAsesor = Convert.ToInt32(cboGrupoAsesor1.SelectedValue);
            decimal nValor = txtValorMeta.nDecValor;
            Boolean lVigente = chcVigente.Checked;

            DataTable dtResultado = cnMeta.CNGrupoMetas(idCategoria, idGrupoAsesor, idTipoMeta);

            if (dtResultado.Rows.Count > 0 && transaccion == Transaccion.Nuevo)
            {
                MessageBox.Show("Ya existe un registro con esas características", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dtResult = cnMeta.CNInsertarGrupoMeta(idCategoria, idGrupoAsesor, idTipoMeta, nValor, lVigente);

            
            if (Convert.ToInt32(dtResult.Rows[0]["nResultado"]) == 0)
            {
                MessageBox.Show(dtResult.Rows[0]["cMensaje"].ToString(), cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show(dtResult.Rows[0]["cMensaje"].ToString(), cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarDatos();
                activarForm(false);
                transaccion = Transaccion.Selecciona;
                controlBotones(transaccion);
            }


        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            transaccion = Transaccion.Edita;
            activarForm(false);
            txtValorMeta.Enabled = true;
            chcVigente.Enabled = true;
            dtgGrupoMeta.Enabled = false;
            controlBotones(transaccion);
        }

        #endregion

        #region Métodos

        private bool validar()
        {
            bool lValida = false;
            if (cboGrupoAsesor1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el grupo asesor.", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboGrupoAsesor1.Focus();
                return lValida;
            }

            if (cboCategoriaAsesor1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar la categoria asesor", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCategoriaAsesor1.Focus();
                return lValida;
            }

            if (cboTipoIncentivo1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el tipo de incentivo", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoIncentivo1.Focus();
                return lValida;
            }

            if (cboTipoMeta2.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el tipo de meta", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoMeta2.Focus();
                return lValida;
            }

            if (String.IsNullOrEmpty(txtValorMeta.Text.Trim()))
            {
                MessageBox.Show("Ingrese el valor meta", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtValorMeta.Focus();
                return lValida;
            }

            lValida = true;
            return lValida;
        }

        private void cargarDatos()
        {
            dtGrupoMeta = cnMeta.CNGrupoMetas(0, 0, 0);
            dtgGrupoMeta.DataSource = dtGrupoMeta;
            formatoGrid();
        }

        private void activarForm(Boolean lBol)
        {
            cboTipoIncentivo1.Enabled = lBol;
            cboTipoMeta2.Enabled = lBol;
            txtValorMeta.Enabled = lBol;
            chcVigente.Enabled = lBol;
            cboGrupoAsesor1.Enabled = lBol;
            cboCategoriaAsesor1.Enabled = lBol;
            dtgGrupoMeta.Enabled = !lBol;
        }

        private void formatoGrid()
        {
            foreach (DataGridViewColumn item in dtgGrupoMeta.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.ReadOnly = true;
            }
            dtgGrupoMeta.Columns["cCategoriaAsesor"].Width = 160;
            dtgGrupoMeta.Columns["cTipoMeta"].Width = 180;
            dtgGrupoMeta.Columns["cGrupoAsesor"].Width = 180;
            dtgGrupoMeta.Columns["nValorMeta"].Width = 180;
            dtgGrupoMeta.Columns["cDescripcion"].Width = 180;
            dtgGrupoMeta.Columns["lVigente"].Width = 20;

            dtgGrupoMeta.Columns["cCategoriaAsesor"].Visible = true;
            dtgGrupoMeta.Columns["cTipoMeta"].Visible = true;
            dtgGrupoMeta.Columns["cGrupoAsesor"].Visible = true;
            dtgGrupoMeta.Columns["nValorMeta"].Visible = true;
            dtgGrupoMeta.Columns["cDescripcion"].Visible = true;
            dtgGrupoMeta.Columns["lVigente"].Visible = true;

            dtgGrupoMeta.Columns["cCategoriaAsesor"].HeaderText = "Categoría Asesor";
            dtgGrupoMeta.Columns["cTipoMeta"].HeaderText = "Tipo Meta";
            dtgGrupoMeta.Columns["cGrupoAsesor"].HeaderText = "Grupo Asesor";
            dtgGrupoMeta.Columns["nValorMeta"].HeaderText = "Valor";
            dtgGrupoMeta.Columns["cDescripcion"].HeaderText = "Tipo Incentivo";
            dtgGrupoMeta.Columns["lVigente"].HeaderText = "Activo";

            dtgGrupoMeta.Columns["nValorMeta"].DefaultCellStyle.Format = "N2";
        }

        private void limpiar()
        {
            cboTipoIncentivo1.SelectedIndex = -1;
            cboTipoMeta2.SelectedIndex = -1;
            txtValorMeta.Clear();
            chcVigente.Checked = false;
            cboGrupoAsesor1.SelectedIndex = -1;
            cboCategoriaAsesor1.SelectedIndex = -1;
        }

        private void controlBotones(Transaccion tran)
        {
            switch (tran)
            { 
                case Transaccion.Selecciona:
                    btnNuevo1.Enabled = true;
                    btnEditar1.Enabled = true;
                    btnCancelar1.Enabled = false;
                    btnGrabar1.Enabled = false;
                    break;
                case Transaccion.Nuevo:
                case Transaccion.Edita:
                    btnNuevo1.Enabled = false;
                    btnEditar1.Enabled = false;
                    btnCancelar1.Enabled = true;
                    btnGrabar1.Enabled = true;
                    break;
            }
        }
        #endregion        
    }
}
