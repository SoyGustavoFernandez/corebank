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
    public partial class frmMantEstProcJud : frmBase
    {
        #region Variables Globales

        Transaccion cEvento = Transaccion.Nuevo;
        clsCNProcJud procesojudicial = new clsCNProcJud();

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            cargarEstadoProcJud();
            btnNuevo.Enabled = true;
            btnEditar.Enabled = cboEstProcJud.Items.Count > 0;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;

            cboTipoProcJud1.SelectedIndex = -1;

            cboEstProcJud.Focus();
            cboEstProcJud.Select();
            cboEstProcJud.cargarPorTipoProcMant(0);
            txtDescripcion.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cEvento = Transaccion.Nuevo;
            btnEditar.Enabled = false;
            btnNuevo.Enabled = false;
            cboTipoProcJud1.Enabled = false;
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = true;
            limpiarControles();
            rbtActivo.Checked = true;
            habilitarControles(true);

            txtDescripcion.Focus();
            txtDescripcion.Select();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (cboEstProcJud.Items.Count == 0)
            {
                MessageBox.Show("No existen registros por editar.", "Validación de registros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cEvento = Transaccion.Edita;
            btnEditar.Enabled = false;
            btnNuevo.Enabled = false;
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = true;
            cboTipoProcJud1.Enabled = false;
            habilitarControles(true);

            activarControlObjetos(this, EventoFormulario.EDITAR);

            txtDescripcion.Focus();
            txtDescripcion.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
            btnNuevo.Enabled = true;
            cboTipoProcJud1.Enabled = true;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
            cboEstProcJud.SelectedIndex = cboEstProcJud.Items.Count > 0 ? 0 : -1;
            cargarEstadoProcJud();
            habilitarControles(false);
            cboEstProcJud.Focus();
            cboEstProcJud.Select();
            cboEstProcJud.cargarPorTipoProcMant(0);
            txtDescripcion.Clear();
            cboEstProcJud.cargarPorTipoProcMant(Convert.ToInt32(cboTipoProcJud1.SelectedValue));
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;

            int idEstProcJud = cboEstProcJud.SelectedValue != null ? Convert.ToInt32(cboEstProcJud.SelectedValue) : 0;
            string cEstProcJud = txtDescripcion.Text.Trim();
            int? idSubProcJudicial = null;//Convert.ToInt32(cboSubProcJudicial.SelectedValue);
            bool lVigente = rbtActivo.Checked;

            clsDBResp objDbResp = null;
            if (cEvento == Transaccion.Nuevo)
            {
                objDbResp = procesojudicial.InsertarEstProcJud(cEstProcJud,idSubProcJudicial,lVigente, Convert.ToInt32(cboTipoProcJud1.SelectedValue));
            }
            else
            {
                objDbResp = procesojudicial.ActualizarEstProcJud(idEstProcJud, cEstProcJud, idSubProcJudicial, lVigente);
            }

            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, "Registro de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnEditar.Enabled = true;
                btnNuevo.Enabled = true;
                cboTipoProcJud1.Enabled = true;
                btnCancelar.Enabled = false;
                btnGrabar.Enabled = false;
                cboEstProcJud.cargarTodos();
                cargarEstadoProcJud();
                habilitarControles(false);
                cboEstProcJud.Focus();
                cboEstProcJud.Select();
                cboEstProcJud.cargarPorTipoProcMant(0);
                txtDescripcion.Clear();
                cboEstProcJud.cargarPorTipoProcMant(Convert.ToInt32(cboTipoProcJud1.SelectedValue));
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, "Registro de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void cboEstProcJud_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarEstadoProcJud();
        }

        #endregion

        #region Métodos

        public frmMantEstProcJud()
        {
            InitializeComponent();
            cboEstProcJud.cargarTodos();
        }

        private void cargarEstadoProcJud()
        {
            if (this.cboEstProcJud.Items.Count > 0)
            {
                var estado = (DataRowView)cboEstProcJud.SelectedItem;
                txtDescripcion.Text = estado["cEstProcJud"].ToString();
                cboSubProcJudicial.SelectedValue = estado["idSubProcJudicial"] != DBNull.Value ? Convert.ToInt32(estado["idSubProcJudicial"]) : 0;
                rbtnInactivo.Checked = !Convert.ToBoolean(estado["lVigente"]);
                rbtActivo.Checked = Convert.ToBoolean(estado["lVigente"]);
            }
            else
            {
                limpiarControles();
                habilitarControles(false);
            }
        }

        private bool validar()
        {
            bool lVal = false;
            if (String.IsNullOrEmpty(txtDescripcion.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar la descripción del estado.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return lVal;
            }

            //if (cboSubProcJudicial.SelectedIndex < 0)
            //{
            //    MessageBox.Show("Seleccione el subproceso del estado.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cboSubProcJudicial.Focus();
            //    return lVal;
            //}

            if (!rbtActivo.Checked && !rbtnInactivo.Checked)
            {
                MessageBox.Show("Debe seleccionar un estado para el registro.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rbtActivo.Focus();
                return lVal;
            }

            //if (cboEstProcJud.Items.Count > 0 && cEvento == Transaccion.Nuevo)
            //{
            //    var dtRegistros = (DataTable)cboEstProcJud.DataSource;

            //    int nExiste = dtRegistros.AsEnumerable().Count(x => x["cEstProcJud"].ToString() == this.txtDescripcion.Text.Trim());

            //    if (nExiste > 0)
            //    {
            //        MessageBox.Show("Ya existe un registro con la descripción ingresada.", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        txtDescripcion.Focus();
            //        return lVal;
            //    }
            //}

            lVal = true;
            return lVal;
        }

        private void limpiarControles()
        {
            cboEstProcJud.SelectedIndexChanged -= cboEstProcJud_SelectedIndexChanged;
            cboEstProcJud.SelectedIndex = -1;
            cboEstProcJud.SelectedIndexChanged += cboEstProcJud_SelectedIndexChanged;
            txtDescripcion.Text = "";
            cboSubProcJudicial.SelectedIndex = -1;
            rbtnInactivo.Checked = false;
            rbtActivo.Checked = false;
        }

        private void habilitarControles(bool estado)
        {
            txtDescripcion.Enabled = estado;
            cboSubProcJudicial.Enabled = estado;
            rbtActivo.Enabled = estado;
            rbtnInactivo.Enabled = estado;
            this.cboEstProcJud.Enabled = !estado;
        }

        #endregion

        private void cboTipoProcJud1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoProcJud1.SelectedIndex >= 0)
            {
                txtDescripcion.Text = "";
                cboEstProcJud.cargarPorTipoProcMant(Convert.ToInt32(cboTipoProcJud1.SelectedValue));                
            }
        }
        
    }
}
