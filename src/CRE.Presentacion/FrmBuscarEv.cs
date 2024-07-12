using CRE.CapaNegocio;
//using CRW.Helper;
using EntityLayer;
//using CRW.ControlBase;
using GEN.ControlesBase;
//using CRE.CapaNegocio;
//using EntityLayer;

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
    public partial class FrmBuscarEv : frmBase
    {
        public int idCli;
        public int idEvalCred;
        public int idSolicitud;
        public int idOperacion;
        public decimal nMontoProp;
        public string cNroDocumento;
        public string cNombreCliente;
        private string cTipoEvaluacion = "";

        private clsCNEvaluacion objCapaNegocio;

        public FrmBuscarEv()
        {
            InitializeComponent();
        }

        public FrmBuscarEv(string cTipoEvalCre, string cTituloForm = "FrmBuscarEv")
        {
            InitializeComponent();

            FormatearDataGridView();

            this.conBusCli.BorderStyle = BorderStyle.None;

            this.idCli = 0;
            this.idEvalCred = 0;
            this.idSolicitud = 0;
            this.idOperacion = 0;
            this.nMontoProp = 0;
            this.cNroDocumento = "";
            this.cNombreCliente = "";

            this.objCapaNegocio = new clsCNEvaluacion();
            this.Text = cTituloForm;
            cTipoEvaluacion = cTipoEvalCre;
        }

        #region Metodos
        private void FormatearDataGridView()
        {
            this.dtgEvalCred.Margin = new System.Windows.Forms.Padding(0);
            this.dtgEvalCred.MultiSelect = false;
            this.dtgEvalCred.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgEvalCred.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgEvalCred.RowHeadersVisible = false;
            this.dtgEvalCred.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void FormatColumnsDtg()
        {
            foreach (DataGridViewColumn column in this.dtgEvalCred.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgEvalCred.Columns["idSolicitud"].DisplayIndex = 0;
            dtgEvalCred.Columns["idEvalCred"].DisplayIndex = 1;
            dtgEvalCred.Columns["cProducto"].DisplayIndex = 2;
            //dtgEvalCred.Columns["cOperacion"].DisplayIndex = 4;
            //dtgEvalCred.Columns["cModalidadCredito"].DisplayIndex = 4;
            dtgEvalCred.Columns["cMoneda"].DisplayIndex = 3;
            dtgEvalCred.Columns["nCapitalPropuesto"].DisplayIndex = 4;
            dtgEvalCred.Columns["cEstado"].DisplayIndex = 6;
            dtgEvalCred.Columns["cTipEvalCred"].DisplayIndex = 5;

            dtgEvalCred.Columns["idSolicitud"].Visible = true;
            dtgEvalCred.Columns["idEvalCred"].Visible = true;
            dtgEvalCred.Columns["cProducto"].Visible = true;
            //dtgEvalCred.Columns["cOperacion"].Visible = true;
            //dtgEvalCred.Columns["cModalidadCredito"].Visible = true;
            dtgEvalCred.Columns["cMoneda"].Visible = true;
            dtgEvalCred.Columns["nCapitalPropuesto"].Visible = true;
            dtgEvalCred.Columns["cEstado"].Visible = true;
            dtgEvalCred.Columns["cTipEvalCred"].Visible = true;

            dtgEvalCred.Columns["idSolicitud"].HeaderText = "Solicitud";
            dtgEvalCred.Columns["idEvalCred"].HeaderText = "Evaluación";
            dtgEvalCred.Columns["cProducto"].HeaderText = "Producto";
            //dtgEvalCred.Columns["cOperacion"].HeaderText = "Código";
            //dtgEvalCred.Columns["cModalidadCredito"].HeaderText = "Código";
            dtgEvalCred.Columns["cMoneda"].HeaderText = "Mda.";
            dtgEvalCred.Columns["nCapitalPropuesto"].HeaderText = "Monto Prop.";
            dtgEvalCred.Columns["cEstado"].HeaderText = "Estado";
            dtgEvalCred.Columns["cTipEvalCred"].HeaderText = "Tipo Eval.";

            dtgEvalCred.Columns["idSolicitud"].FillWeight = 60;
            dtgEvalCred.Columns["idEvalCred"].FillWeight = 60;
            dtgEvalCred.Columns["cProducto"].FillWeight = 150;
            //dtgEvalCred.Columns["cOperacion"].FillWeight = 100;
            //dtgEvalCred.Columns["cModalidadCredito"].FillWeight = 100;
            dtgEvalCred.Columns["cMoneda"].FillWeight = 30;
            dtgEvalCred.Columns["nCapitalPropuesto"].FillWeight = 80;
            dtgEvalCred.Columns["cEstado"].FillWeight = 100;
            dtgEvalCred.Columns["cTipEvalCred"].FillWeight = 130;

            //dtgEvalCred.Columns["idSolicitud"].DefaultCellStyle.Format = "D8";
            //dtgEvalCred.Columns["idEvalCred"].DefaultCellStyle.Format = "D8";
            dtgEvalCred.Columns["nCapitalPropuesto"].DefaultCellStyle.Format = "n2";
        }
        #endregion

        #region Eventos
        private void FrmBuscarEvPyme_Load(object sender, EventArgs e)
        {
            conBusCli.Select();
        }

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            this.idCli = this.conBusCli.idCli;

            if (this.idCli != 0)
            {
                this.cNroDocumento = this.conBusCli.txtNroDoc.Text;
                this.cNombreCliente = this.conBusCli.txtNombre.Text;

                DataTable dt = this.objCapaNegocio.ListarEvaluacionPorCliente(this.idCli, clsVarGlobal.User.idUsuario, this.cTipoEvaluacion);
                
                this.dtgEvalCred.DataSource = dt;
                this.FormatColumnsDtg();
                this.dtgEvalCred.Focus();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtgEvalCred.SelectedRows.Count == 0) return;

            if (dtgEvalCred.CurrentRow != null)
            {
                this.idEvalCred = Convert.ToInt32(dtgEvalCred.CurrentRow.Cells["idEvalCred"].Value);
                this.idSolicitud = Convert.ToInt32(dtgEvalCred.CurrentRow.Cells["idSolicitud"].Value);
                this.idOperacion = Convert.ToInt32(dtgEvalCred.CurrentRow.Cells["idOperacion"].Value);
                this.nMontoProp = Convert.ToInt32(dtgEvalCred.CurrentRow.Cells["nCapitalPropuesto"].Value);
                this.Close();

                #region ValidarPDS
                DataTable dtControlDPS = new clsCNCargaArchivo().controlDpsCargados(this.idSolicitud);
                if (Convert.ToInt32(dtControlDPS.Rows[0]["idEstado"]) == 0)
                {
                    MessageBox.Show(dtControlDPS.Rows[0]["cEstado"].ToString(), "Alerta de Control de DPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                #endregion
            }
        }

        private void dtgEvalCred_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgEvalCred.SelectedRows.Count == 0) return;

            if (dtgEvalCred.CurrentRow != null)
            {
                this.idEvalCred = Convert.ToInt32(dtgEvalCred.CurrentRow.Cells["idEvalCred"].Value);
                #region ValidarPDS
                DataTable dtControlDPS = new clsCNCargaArchivo().controlDpsCargados(Convert.ToInt32(dtgEvalCred.CurrentRow.Cells["idSolicitud"].Value));
                if (Convert.ToInt32(dtControlDPS.Rows[0]["idEstado"]) == 0)
                {
                    MessageBox.Show(dtControlDPS.Rows[0]["cEstado"].ToString(), "Alerta de Control de DPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                #endregion
                this.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void dtgEvalCred_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnAceptar.PerformClick();
                e.Handled = true;
            }
        }
        #endregion

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.dtgEvalCred.DataSource = null;
            this.conBusCli.limpiarControles();
            this.conBusCli.txtCodCli.Enabled = true;
            this.conBusCli.txtCodCli.Focus();
        }
    }
}
