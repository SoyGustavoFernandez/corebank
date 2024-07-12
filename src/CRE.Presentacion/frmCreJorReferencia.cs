#region Referencias
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
using System.Text.RegularExpressions;
#endregion

namespace CRE.Presentacion
{
    public partial class frmCreJorReferencia : frmBase
    {
        #region Variables
        public clsCreJorScoreJornalero oScoreJornalero = new clsCreJorScoreJornalero();
        private clsCreJorReferencia oReferencia = new clsCreJorReferencia();
        private clsCNCreditoJornalero cncrejor = new clsCNCreditoJornalero();
        #endregion
        #region Constructor
        public frmCreJorReferencia()
        {
            InitializeComponent();
            this.editar(false);
            this.cboVinculo.DataSource = this.cncrejor.listaTipoVinculos().Tables[0];
            this.cboVinculo.DisplayMember = "cDescripcion";
            this.cboVinculo.ValueMember = "idTipVinculoEval";

            this.cboTipoVinculo.DataSource = this.cncrejor.listaTipoVinculos().Tables[1];
            this.cboTipoVinculo.DisplayMember = "cTipoReferencia";
            this.cboTipoVinculo.ValueMember = "idTipoReferencia";
        }
        #endregion
        #region Metodos
        private void editar(bool lEstado)
        {
            this.btnEditar1.Enabled = !lEstado;
            this.btnGrabar1.Enabled = lEstado;
            this.txtNombre.Enabled = lEstado;
            this.txtDireccion.Enabled = lEstado;
            this.txtTelefCel1.Enabled = lEstado;
            this.cboVinculo.Enabled = lEstado;
            this.btnNuevo1.Enabled = !lEstado;
            this.btnMiniAgregar1.Enabled = lEstado;
            this.cboTipoVinculo.Enabled = lEstado;
        }
        private void cargarReferenciaEnVista()
        {
            this.txtNombre.Text = this.oReferencia.cNombre;
            this.txtDireccion.Text = this.oReferencia.cDireccion;
            this.txtTelefCel1.Text = this.oReferencia.cTelefono;
            this.cboVinculo.SelectedValue = this.oReferencia.idTipVinculoEval != 0 ? this.oReferencia.idTipVinculoEval : this.cboVinculo.SelectedValue;
            this.cboTipoVinculo.SelectedValue = this.oReferencia.idTipoReferencia != 0 ? this.oReferencia.idTipoReferencia : this.cboTipoVinculo.SelectedValue;
            this.cboVinculo.SelectedValue = this.oReferencia.idTipVinculoEval != 0 ? this.oReferencia.idTipVinculoEval : this.cboVinculo.SelectedValue;
        }
        private void cargarReferenciaFromDtg()
        {
            if (this.dtgReferencias.SelectedRows.Count > 0)
            { 
                DataRow drFila = ((DataRowView)this.dtgReferencias.SelectedRows[0].DataBoundItem).Row;
                this.oReferencia.idReferencia = drFila.Table.Columns.Contains("idReferencia") ? Convert.ToInt32(drFila["idReferencia"]) : 0;
                this.oReferencia.idScoreJornalero = drFila.Table.Columns.Contains("idScoreJornalero") ? Convert.ToInt32(drFila["idScoreJornalero"]) : 0;
                this.oReferencia.cNombre = drFila.Table.Columns.Contains("cNombre") ? Convert.ToString(drFila["cNombre"]) : "";
                this.oReferencia.cDireccion = drFila.Table.Columns.Contains("cDireccion") ? Convert.ToString(drFila["cDireccion"]) : "";
                this.oReferencia.cTelefono = drFila.Table.Columns.Contains("cTelefono") ? Convert.ToString(drFila["cTelefono"]) : "";
                this.oReferencia.idTipVinculoEval = drFila.Table.Columns.Contains("idTipVinculoEval") ? Convert.ToInt32(drFila["idTipVinculoEval"]) : 0;
                this.oReferencia.idTipoReferencia = drFila.Table.Columns.Contains("idTipoReferencia") ? Convert.ToInt32(drFila["idTipoReferencia"]) : 0;
                this.oReferencia.lVigente = drFila.Table.Columns.Contains("lVigente") ? Convert.ToBoolean(drFila["lVigente"]) : true;
                this.oReferencia.indexRow = this.dtgReferencias.SelectedRows[0].Index;

                this.cargarReferenciaEnVista();
                this.editar(false);
            }
        }
        private void cargarReferencias()
        {
            this.dtgReferencias.DataSource = this.oScoreJornalero.dtReferencias;

            /** Configurar dtgReferencias **/
            foreach (DataGridViewColumn oCol in this.dtgReferencias.Columns) 
            { 
                oCol.Visible = false;
                oCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewRow oRow in this.dtgReferencias.Rows)
            {
                bool lVigencia = Convert.ToBoolean(oRow.Cells["lVigente"].Value);
                foreach (DataGridViewCell oCell in oRow.Cells)
                {
                    oCell.Style.BackColor = lVigencia ? Color.White : Color.Red;
                }
                oRow.Visible = lVigencia;
            }
            if (this.dtgReferencias.Columns.Contains("cNombre"))
            {
                this.dtgReferencias.Columns["cNombre"].HeaderText = "Nombre";
                this.dtgReferencias.Columns["cNombre"].Visible = true;
            }
            if (this.dtgReferencias.Columns.Contains("cDireccion"))
            {
                this.dtgReferencias.Columns["cDireccion"].HeaderText = "Dirección";
                this.dtgReferencias.Columns["cDireccion"].Visible = true;
            }
            if (this.dtgReferencias.Columns.Contains("cTelefono"))
            {
                this.dtgReferencias.Columns["cTelefono"].HeaderText = "Teléfono";
                this.dtgReferencias.Columns["cTelefono"].Visible = true;
            }
            if (this.dtgReferencias.Columns.Contains("cTipoReferencia"))
            {
                this.dtgReferencias.Columns["cTipoReferencia"].HeaderText = "Referencia";
                this.dtgReferencias.Columns["cTipoReferencia"].Visible = true;
            }
            
        }
        private void nuevo(bool lEstado = true)
        {
            this.oReferencia = new clsCreJorReferencia();
            this.cargarReferenciaEnVista();
            this.editar(lEstado);
        }
        private void borrarReferencia()
        {
            if (this.dtgReferencias.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Esta seguro(a) de eliminar esta referencia?",
                                "Confirmación",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                ) == DialogResult.Yes)
                {
                    CurrencyManager oCurrencyManager = (CurrencyManager)BindingContext[this.dtgReferencias.DataSource];
                    oCurrencyManager.SuspendBinding();
                    this.dtgReferencias.SelectedRows[0].Cells["lVigente"].Value = false;
                    this.dtgReferencias.SelectedRows[0].Visible = false;
                    this.cargarReferencias();
                    oCurrencyManager.ResumeBinding();
                    this.nuevo(false);
                }
            }
        }
        #endregion
        #region Eventos
        private bool validar()
        {
            if(this.txtDireccion.Text.Trim() == "" || this.txtNombre.Text.Trim() == "" || this.txtTelefCel1.Text.Trim() == "")
            {
                return false;
            }
            return true;
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (!this.validar())
            {
                MessageBox.Show("Llenar espacios en blanco", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.oReferencia.cNombre = this.txtNombre.Text;
            this.oReferencia.cDireccion = this.txtDireccion.Text;
            this.oReferencia.cTelefono = this.txtTelefCel1.Text;
            this.oReferencia.idTipVinculoEval = Convert.ToInt32(this.cboVinculo.SelectedValue);
            this.oReferencia.idTipoReferencia = Convert.ToInt32(this.cboTipoVinculo.SelectedValue);

            if (this.oReferencia.indexRow >= 0)
            {
                this.oScoreJornalero.dtReferencias.Rows[this.oReferencia.indexRow]["idReferencia"] = this.oReferencia.idReferencia;
                this.oScoreJornalero.dtReferencias.Rows[this.oReferencia.indexRow]["idScoreJornalero"] = this.oReferencia.idScoreJornalero;
                this.oScoreJornalero.dtReferencias.Rows[this.oReferencia.indexRow]["cNombre"] = this.oReferencia.cNombre;
                this.oScoreJornalero.dtReferencias.Rows[this.oReferencia.indexRow]["cDireccion"] = this.oReferencia.cDireccion;
                this.oScoreJornalero.dtReferencias.Rows[this.oReferencia.indexRow]["cTelefono"] = this.oReferencia.cTelefono;
                this.oScoreJornalero.dtReferencias.Rows[this.oReferencia.indexRow]["idTipVinculoEval"] = this.oReferencia.idTipVinculoEval;
                this.oScoreJornalero.dtReferencias.Rows[this.oReferencia.indexRow]["cTipVinculoEval"] = this.cboVinculo.Text;
                this.oScoreJornalero.dtReferencias.Rows[this.oReferencia.indexRow]["idTipoReferencia"] = this.oReferencia.idTipoReferencia;
                this.oScoreJornalero.dtReferencias.Rows[this.oReferencia.indexRow]["cTipoReferencia"] = this.cboTipoVinculo.Text;
                this.oScoreJornalero.dtReferencias.Rows[this.oReferencia.indexRow]["lVigente"] = this.oReferencia.lVigente;
            }
            else
            {
                this.oScoreJornalero.dtReferencias.Rows.Add(
                    this.oReferencia.idReferencia,
                    this.oReferencia.idScoreJornalero,
                    this.oReferencia.cNombre,
                    this.oReferencia.cDireccion,
                    this.oReferencia.cTelefono,
                    this.oReferencia.idTipVinculoEval,
                    this.cboVinculo.Text,
                    this.oReferencia.idTipoReferencia,
                    this.cboTipoVinculo.Text,
                    this.oReferencia.lVigente
                    );
            }

            this.cargarReferencias();
            this.nuevo(false);
        }
        private void btnCerrar1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void frmCreJorReferencia_Shown(object sender, EventArgs e)
        {
            this.cargarReferencias();
        }
        private void btnEditar1_Click(object sender, EventArgs e)
        {
            this.editar(true);
        }
        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            this.nuevo();
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.nuevo(false);
        }
        private void dtgReferencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                this.borrarReferencia();
            }
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Char.IsControl(e.KeyChar))
            {
                return;
            }

            var regex = new Regex(@"[^a-zA-ZñÑáéíóúÁÉÍÓÚ0-9\s]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }
        private void btnMiniQuitar1_Click(object sender, EventArgs e)
        {
            this.borrarReferencia();
        }
        private void dtgReferencias_SelectionChanged(object sender, EventArgs e)
        {
            this.cargarReferenciaFromDtg();
        }
        private void dtgReferencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.cargarReferenciaFromDtg();
        }
        #endregion

        
    }
}
