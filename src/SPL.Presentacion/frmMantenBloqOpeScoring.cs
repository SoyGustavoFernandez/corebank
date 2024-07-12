using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using SPL.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPL.Presentacion
{
    public partial class frmMantenBloqOpeScoring : frmBase
    {
        #region Variables globales
        String cTituloMensaje = "Mantenimiento de calificativos";
        String cTipoOperacion = "N";
        int idGrupoBloq = 0;
        clsCNScoring cnScoring = new clsCNScoring();

        DataTable dtDetalleBloq;
        #endregion

        public frmMantenBloqOpeScoring()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmVerifDatosActualCli_Load(object sender, EventArgs e)
        {
            this.cboModulo.ListarSoloModulos();
            limpiarControles();
            limpiarMiniControles();
            habilitarControles(false);

            cargarGrupoBloq();
            this.cboAgencias.SelectedIndex = 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cTipoOperacion = "N";
            limpiarControles();
            habilitarControles(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cTipoOperacion = "A";
            habilitarControles(true);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!validarGrupo())
            {
                return;
            }
            String cDetalle = this.txtNombre.Text;
            DateTime dVigInicio = this.dtpVigDesde.Value;
            DateTime dVigFin = this.dtpVigHasta.Value;
            Boolean lBloqueo = this.chcVigencia.Checked;

            DataSet DSDetalle = new DataSet("DSDetalleBloq");
            DSDetalle.Tables.Add(this.dtDetalleBloq);
            String xmlDetalleBloq = DSDetalle.GetXml();
            xmlDetalleBloq = clsCNFormatoXML.EncodingXML(xmlDetalleBloq);
            DSDetalle.Tables.Clear();

            if (this.cTipoOperacion == "N")
            {
                DataTable dtGuardar = cnScoring.GuardaConfiBloqueOpe(0, cDetalle, dVigInicio, dVigFin, lBloqueo, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, xmlDetalleBloq);
                MessageBox.Show(dtGuardar.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtGuardar.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }
            else if (this.cTipoOperacion == "A")
            {
                DataTable dtGuardar = cnScoring.GuardaConfiBloqueOpe(this.idGrupoBloq, cDetalle, dVigInicio, dVigFin, lBloqueo, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, xmlDetalleBloq);
                MessageBox.Show(dtGuardar.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtGuardar.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }
            limpiarControles();
            cargarGrupoBloq();
            habilitarControles(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cargarGrupoBloq();
            habilitarControles(false);
        }

        private void btnMiniNuevo_Click(object sender, EventArgs e)
        {
            habilitarMiniControl(true);
        }

        private void btnMiniAgregar_Click(object sender, EventArgs e)
        {
            if (!validaDetalleBloq())
            {
                return;
            }
            DataRow drRegla = this.dtDetalleBloq.NewRow();
            drRegla["idDetalleBloq"] = 0;
            drRegla["idBloqueo"] = this.idGrupoBloq;
            drRegla["idAgencia"] = this.cboAgencias.SelectedValue;
            drRegla["idOperacion"] = this.cboTipoOperacion.SelectedValue;
            drRegla["cTipoOperacion"] = ((System.Data.DataRowView)this.cboTipoOperacion.SelectedItem)[this.cboTipoOperacion.DisplayMember.ToString()].ToString();
            drRegla["idDiaSemana"] = this.cboDiasSemana.SelectedValue;
            drRegla["cDia"] = ((System.Data.DataRowView)this.cboDiasSemana.SelectedItem)[this.cboDiasSemana.DisplayMember.ToString()].ToString();
            drRegla["lBloqueo"] = this.chcBloqueo.Checked;
            this.dtDetalleBloq.Rows.Add(drRegla);

            limpiarMiniControles();
            habilitarMiniControl(false);
        }

        private void btnMiniQuitar_Click(object sender, EventArgs e)
        {
            if (this.dtgDetalleBloq.Rows.Count <= 0)
            {
                MessageBox.Show("No existen reglas para quitar", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (this.dtgDetalleBloq.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar la regla que desea eliminar", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    int id = this.dtgDetalleBloq.SelectedRows[0].Index;
                    this.dtgDetalleBloq.Rows.RemoveAt(id);
                }
            }
        }

        private void btnMiniCancelEst_Click(object sender, EventArgs e)
        {
            limpiarMiniControles();
            habilitarMiniControl(false);
        }

        private void dtgGrupoBloqueo_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgGrupoBloqueo.SelectedRows.Count > 0)
            {
                this.idGrupoBloq = Convert.ToInt32(this.dtgGrupoBloqueo.SelectedRows[0].Cells["idBloqueo"].Value);
                this.txtNombre.Text = Convert.ToString(this.dtgGrupoBloqueo.SelectedRows[0].Cells["cDescripcion"].Value);
                this.dtpVigDesde.Value = Convert.ToDateTime(this.dtgGrupoBloqueo.SelectedRows[0].Cells["dFechaDesde"].Value);
                this.dtpVigHasta.Value = Convert.ToDateTime(this.dtgGrupoBloqueo.SelectedRows[0].Cells["dFechaHasta"].Value);
                this.chcVigencia.Checked = Convert.ToBoolean(this.dtgGrupoBloqueo.SelectedRows[0].Cells["lVigente"].Value);

            }
            cargarDetalleBloq(this.idGrupoBloq);
        }

        private void cboModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboTipoOperacion.LisTipoOperacModulo(Convert.ToInt32(this.cboModulo.SelectedValue));
        }

        private void cboAgencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idGrupo = Convert.ToInt32(this.cboAgencias.SelectedValue);
            //foreach (DataGridViewRow item in this.dtgCalificacion.Rows)
            for (int i = 0; i < this.dtgDetalleBloq.Rows.Count; i++)
            {
                if (Convert.ToInt32(this.dtgDetalleBloq.Rows[i].Cells["idAgencia"].Value) == idGrupo)
                {
                    this.dtgDetalleBloq.CurrentCell = null;
                    this.dtgDetalleBloq.Rows[i].Visible = true;
                }
                else
                {
                    this.dtgDetalleBloq.CurrentCell = null;
                    this.dtgDetalleBloq.Rows[i].Visible = false;
                }
            }
        }

        #endregion

        #region Metodos

        private void cargarGrupoBloq()
        {
            DataTable dtGrupos = cnScoring.ListarGrupBloqOpe(0);
            this.dtgGrupoBloqueo.DataSource = dtGrupos;
            if (dtGrupos.Rows.Count == 0)
            {
                cargarDetalleBloq(this.idGrupoBloq);
            }
            this.cboAgencias.SelectedIndex = -1;
            this.cboAgencias.SelectedIndex = 0;
            darFormatoDTGGrupoBloq();
        }

        private void darFormatoDTGGrupoBloq()
        {
            foreach (DataGridViewColumn columna in this.dtgGrupoBloqueo.Columns)
            {
                columna.Visible = false;
            }
            this.dtgGrupoBloqueo.Columns["idBloqueo"].Visible = true;
            this.dtgGrupoBloqueo.Columns["cDescripcion"].Visible = true;
            this.dtgGrupoBloqueo.Columns["dFechaDesde"].Visible = true;
            this.dtgGrupoBloqueo.Columns["dFechaHasta"].Visible = true;
            this.dtgGrupoBloqueo.Columns["lVigente"].Visible = true;

            this.dtgGrupoBloqueo.Columns["idBloqueo"].FillWeight = 10;
            this.dtgGrupoBloqueo.Columns["cDescripcion"].FillWeight = 40;
            this.dtgGrupoBloqueo.Columns["dFechaDesde"].FillWeight = 20;
            this.dtgGrupoBloqueo.Columns["dFechaHasta"].FillWeight = 20;
            this.dtgGrupoBloqueo.Columns["lVigente"].FillWeight = 10;

            this.dtgGrupoBloqueo.Columns["idBloqueo"].HeaderText = "N°";
            this.dtgGrupoBloqueo.Columns["cDescripcion"].HeaderText = "Nombre";
            this.dtgGrupoBloqueo.Columns["dFechaDesde"].HeaderText = "Fecha desde";
            this.dtgGrupoBloqueo.Columns["dFechaHasta"].HeaderText = "Fecha hasta";
            this.dtgGrupoBloqueo.Columns["lVigente"].HeaderText = "Vigencia";
        }

        private void cargarDetalleBloq(int idGrupobloq)
        {
            dtDetalleBloq = cnScoring.ListarDetalleBloOpe(idGrupobloq);
            this.dtgDetalleBloq.DataSource = dtDetalleBloq;
            darFormatoDTGDetalleBloq();
        }

        private void darFormatoDTGDetalleBloq()
        {
            foreach (DataGridViewColumn columna in this.dtgDetalleBloq.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                columna.Visible = false;
            }
            this.dtgDetalleBloq.Columns["cTipoOperacion"].Visible = true;
            this.dtgDetalleBloq.Columns["cDia"].Visible = true;
            this.dtgDetalleBloq.Columns["lBloqueo"].Visible = true;

            this.dtgDetalleBloq.Columns["cTipoOperacion"].FillWeight = 60;
            this.dtgDetalleBloq.Columns["cDia"].FillWeight = 30;
            this.dtgDetalleBloq.Columns["lBloqueo"].FillWeight = 10;

            this.dtgDetalleBloq.Columns["cTipoOperacion"].HeaderText = "Tipo operación";
            this.dtgDetalleBloq.Columns["cDia"].HeaderText = "Día de semana";
            this.dtgDetalleBloq.Columns["lBloqueo"].HeaderText = "Detiene Ope.";
        }

        private void habilitarControles(bool Val)
        {
            this.dtgGrupoBloqueo.Enabled = !Val;

            this.txtNombre.Enabled = Val;
            this.chcVigencia.Enabled = Val;
            this.dtpVigDesde.Enabled = Val;
            this.dtpVigHasta.Enabled = Val;

            this.btnNuevo.Enabled = !Val;
            this.btnEditar.Enabled = !Val;
            this.btnCancelar.Enabled = Val;
            this.btnGrabar.Enabled = Val;
            habilitarMiniControl(!Val);
            if (!btnCancelar.Enabled)
            {
                this.btnMiniAgregar.Enabled = false;
                this.btnMiniCancelEst.Enabled = false;
                this.grbMiniCombos.Enabled = false;
                this.cboAgencias.Enabled = true;
            }
        }

        private void habilitarMiniControl(bool Val)
        {
            this.btnMiniNuevo.Enabled = !Val;
            this.btnMiniQuitar.Enabled = !Val;
            this.btnMiniAgregar.Enabled = Val;
            this.btnMiniCancelEst.Enabled = Val;

            this.cboAgencias.Enabled = !Val;
            this.grbMiniCombos.Enabled = Val;
            //this.cboModulo.Enabled = Val;
            //this.cboTipoOperacion.Enabled = Val;
            //this.cboDiasSemana.Enabled = Val;
            //if (!this.conBuscaProducto.Enabled)
            //{
            //    this.conBuscaProducto.limpiar();
            //}


        }

        private void limpiarControles()
        {
            this.txtNombre.Clear();
            this.dtpVigDesde.Value = clsVarGlobal.dFecSystem;
            this.dtpVigHasta.Value = clsVarGlobal.dFecSystem;
            this.cboAgencias.SelectedItem = 0;
            this.cboModulo.SelectedIndex = -1;
            this.cboDiasSemana.SelectedIndex = -1;
            cargarDetalleBloq(0);
        }

        private void limpiarMiniControles()
        {
            this.cboModulo.SelectedIndex = - 1;
            this.cboDiasSemana.SelectedIndex = -1;
            this.chcBloqueo.Checked = false;
        }

        private bool validarGrupo()
        {
            if (String.IsNullOrEmpty(this.txtNombre.Text))
            {
                MessageBox.Show("Ingrese un nombre para grupo de bloqueo", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNombre.Focus();
                return false;
            }
            if (this.dtpVigDesde.Value > this.dtpVigHasta.Value)
            {
                MessageBox.Show("La fecha de vigencia final no puede ser menor que la fecha de inicio", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpVigHasta.Focus();
                return false;
            }
            if (this.dtgDetalleBloq.Rows.Count < 1)
            {
                MessageBox.Show("Ingrese al menos un detalle de bloqueo", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnMiniNuevo.Focus();
                return false;
            }
            return true;
        }

        private bool validaDetalleBloq()
        {
            if (this.cboTipoOperacion.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione operación", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboTipoOperacion.Focus();
                return false;
            }
            if (this.cboDiasSemana.SelectedIndex == -1)
            {
                    MessageBox.Show("Seleccione día de semana", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.cboDiasSemana.Focus();
                    return false;
            }
            foreach (DataGridViewRow item in this.dtgDetalleBloq.Rows)
            {
                if (this.cboAgencias.SelectedValue.ToString() == item.Cells["idAgencia"].Value.ToString() &&
                    this.cboTipoOperacion.SelectedValue.ToString() == item.Cells["idOperacion"].Value.ToString() && this.cboDiasSemana.SelectedValue.ToString() == item.Cells["idDiaSemana"].Value.ToString())
                {
                    MessageBox.Show("Ya existe una configuración para operación: " + item.Cells["cTipoOperacion"].Value.ToString() + " en día: " + item.Cells["cDia"].Value.ToString(), cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.cboDiasSemana.Focus();
                    return false;
                }
            }
            return true;
        }

        #endregion

    }
}
