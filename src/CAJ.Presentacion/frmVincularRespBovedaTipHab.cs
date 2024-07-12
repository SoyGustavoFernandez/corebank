using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAJ.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;

namespace CAJ.Presentacion
{
    public partial class frmVincularRespBovedaTipHab : frmBase
    {
        clsCNControlOpe cnVinctipHabRespo = new clsCNControlOpe();
        DataTable dtListaVinculo;
        int nOpcion = 0;
        private int pidVinTipHabRes = 0;
        public frmVincularRespBovedaTipHab()
        {
            InitializeComponent();
        }

        private void frmVincularRespBovedaTipoHabilitacion_Load(object sender, EventArgs e)
        {
            listarTipoHabilitacion();

            cboAgencias.SelectedIndex = -1;
            cboTipResponsableCaja1.SelectedIndex = -1;
            cboTiposHabilitacion.SelectedIndex = -1;
            chclBilletaje.Checked = false;

            cboTiposHabilitacion.Enabled = false;
            cboTipResponsableCaja1.Enabled = false;
            chclBilletaje.Enabled = false;
        }

        private void listarTipoHabilitacion()
        {
            DataTable dtTipoHabilitacion;
            int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
            dtTipoHabilitacion = cnVinctipHabRespo.listarTodosTiposHabilitacion(idAgencia);
            cboTiposHabilitacion.DataSource = dtTipoHabilitacion;
            cboTiposHabilitacion.ValueMember = "idTipHab";
            cboTiposHabilitacion.DisplayMember = "cDescripcion";
        }
        private void cargarDatosRelacion()
        {

            int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
            dtListaVinculo = cnVinctipHabRespo.listaRelacionTipoHabilitacionXResponsable(idAgencia);
            dtgVinculoTipHabTipResBov.DataSource = dtListaVinculo;

            dtgVinculoTipHabTipResBov.Columns["idTipHabPorTipRes"].Visible = false;
            dtgVinculoTipHabTipResBov.Columns["idAgencia"].Visible = false;
            dtgVinculoTipHabTipResBov.Columns["idTipResCaj"].Visible = false;
            dtgVinculoTipHabTipResBov.Columns["idTipHab"].Visible = false;
            dtgVinculoTipHabTipResBov.Columns["tipoResponsable"].HeaderText = "TIPO RESPONSABLE";
            dtgVinculoTipHabTipResBov.Columns["tipoHabilitacion"].HeaderText = "TIPO HABILITACION";
            dtgVinculoTipHabTipResBov.Columns["lNecBilletaje"].HeaderText = "SOLICITA BILLETAJE";
            dtgVinculoTipHabTipResBov.Columns["tipoResponsable"].Width = 180;
            dtgVinculoTipHabTipResBov.Columns["tipoHabilitacion"].Width = 150;
        }

        private void cboAgencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencias.SelectedIndex > -1)
            {
                DataRow row = ((DataTable)cboAgencias.DataSource).Rows[cboAgencias.SelectedIndex];
                string IdTipEsq = row["idTipEsquemaCaja"].ToString();
                if (IdTipEsq.Equals(""))
                {
                    btnNuevo1.Enabled = false;
                    btnEditar1.Enabled = false;
                    btnCancelar.Enabled = false;
                    MessageBox.Show("La agencia no tiene asignado el esquema de trabajo", "Mantenimiento de Responsables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (Convert.ToInt32(IdTipEsq) <= 0)
                {
                    btnNuevo1.Enabled = false;
                    btnEditar1.Enabled = false;
                    btnCancelar.Enabled = false;
                    MessageBox.Show("La agencia no tiene asignado el esquema de trabajo", "Mantenimiento de Responsables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                }
                else
                {
                    btnNuevo1.Enabled = true;
                    btnEditar1.Enabled = true;

                }

                cargarDatosRelacion();
                int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
                cboTipResponsableCaja1.cargarTipoResponsableCajaAdm(idAgencia);
                listarTipoHabilitacion();
            }
        }
        private bool lExisteTipHabPorResponsable()
        {
            bool lValor = false;
            foreach (DataRow rows in dtListaVinculo.Rows)
            {
                if (Convert.ToInt32(rows["idTipResCaj"].ToString()) == Convert.ToInt32(cboTipResponsableCaja1.SelectedValue) &&
                    Convert.ToInt32(rows["idTipHab"].ToString()) == Convert.ToInt32(cboTiposHabilitacion.SelectedValue)
                    )
                {
                    MessageBox.Show("Ya existe tipo de habilitación '" + cboTiposHabilitacion.Text + "' para el " + cboTipResponsableCaja1.Text, "Vinculo tipo de habilitación con tipo responsable de bóveda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lValor = true;
                    break;
                }
            }
            return lValor;
        }
        private void dtgVinculoTipHabTipResBov_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int Fila = e.RowIndex;
            cargarDatos(Fila);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            #region validacion
            if (this.cboAgencias.SelectedIndex < 0)
            {
                MessageBox.Show("Debe Seleccionar la Agencia", "Vinculo tipo de habilitación con tipo responsable de bóveda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgencias.Focus();
                this.cboAgencias.Select();
                return;
            }
            if (this.cboTipResponsableCaja1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el tipo de responsable.", "Vinculo tipo de habilitación con tipo responsable de bóveda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboTipResponsableCaja1.Focus();
                this.cboTipResponsableCaja1.Select();
                return;
            }
            if (this.cboTiposHabilitacion.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el tipo de habilitación ", "Vinculo tipo de habilitación con tipo responsable de bóveda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboTiposHabilitacion.Focus();
                this.cboTiposHabilitacion.Select();
                return;
            }

            #endregion
            //==================================================================
            //--Guardar Datos opcion nuevo
            //==================================================================
            if (nOpcion == 1)
            {
                if (lExisteTipHabPorResponsable())
                {
                    return;
                }
                int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
                int idTipoResponsable = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);
                int idTipoHabilitacion = Convert.ToInt32(cboTiposHabilitacion.SelectedValue);
                bool lNecBilletaje = chclBilletaje.Checked;
                DataTable dtResp;
                dtResp = cnVinctipHabRespo.GrabarVincTipHabTipResponsable(idAgencia, clsVarGlobal.nIdAgencia, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, idTipoResponsable, idTipoHabilitacion, lNecBilletaje);
                if (Convert.ToInt32(dtResp.Rows[0]["nResp"]) > 0)
                {
                    MessageBox.Show("Los datos se guardaron correctamente", "Vinculo tipo de habilitación con tipo responsable de bóveda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatosRelacion();
                    this.cboAgencias.Enabled = true;
                    this.cboTiposHabilitacion.Enabled = false;
                    this.cboTipResponsableCaja1.Enabled = false;
                    this.chclBilletaje.Enabled = false;
                    this.dtgVinculoTipHabTipResBov.Enabled = true;
                    btnNuevo1.Enabled = true;
                    btnEditar1.Enabled = true;
                    btnEliminar1.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnCancelar.Enabled = false;
                    nOpcion = 0;
                }
                else
                {
                    MessageBox.Show(dtResp.Rows[0]["mResp"].ToString(), "Vinculo tipo de habilitación con tipo responsable de bóveda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            //==================================================================
            //--Guardar Datos opcion editar
            //==================================================================
            if (nOpcion == 2)
            {

                bool lNecBilletaje = chclBilletaje.Checked;
                DataTable dtResp;
                dtResp = cnVinctipHabRespo.EditarVincTipHabTipResponsable(pidVinTipHabRes, clsVarGlobal.nIdAgencia, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, lNecBilletaje, true);
                if (Convert.ToInt32(dtResp.Rows[0]["nResp"]) > 0)
                {
                    MessageBox.Show("Los datos se guardaron correctamente", "Vinculo tipo de habilitación con tipo responsable de bóveda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatosRelacion();
                    this.cboAgencias.Enabled = true;
                    this.chclBilletaje.Enabled = false;
                    this.dtgVinculoTipHabTipResBov.Enabled = true; btnNuevo1.Enabled = true;
                    btnEditar1.Enabled = true;
                    btnEliminar1.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnCancelar.Enabled = false;
                    nOpcion = 0;
                }
                else
                {
                    MessageBox.Show(dtResp.Rows[0]["mResp"].ToString(), "Vinculo tipo de habilitación con tipo responsable de bóveda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void cargarDatos(int fila)
        {
            pidVinTipHabRes = Convert.ToInt32(dtListaVinculo.Rows[fila]["idTipHabPorTipRes"].ToString());
            int idTipResCaj = 0;
            int idTipHab = 0;
            idTipResCaj = Convert.ToInt32(dtListaVinculo.Rows[fila]["idTipResCaj"].ToString());
            idTipHab = Convert.ToInt32(dtListaVinculo.Rows[fila]["idTipHab"].ToString());

            if (dtgVinculoTipHabTipResBov.SelectedRows.Count > 0)
            {
                if (cboTipResponsableCaja1.DataSource != null)
                {
                    cboTipResponsableCaja1.SelectedValue = idTipResCaj;
                }
                if (cboTiposHabilitacion.DataSource != null)
                {
                    cboTiposHabilitacion.SelectedValue = idTipHab;
                }

            }
            chclBilletaje.Checked = Convert.ToBoolean(dtListaVinculo.Rows[fila]["lNecBilletaje"].ToString());
        }
        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            if (this.cboAgencias.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar la agencia", "Vincular tipos de habilitaciones por responsables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgencias.Focus();
                this.cboAgencias.Select();
                return;
            }
            nOpcion = 1;
            cboTipResponsableCaja1.SelectedIndex = -1;
            cboTiposHabilitacion.SelectedIndex = -1;
            chclBilletaje.Checked = false;

            dtgVinculoTipHabTipResBov.Enabled = false;
            cboAgencias.Enabled = false;
            cboTiposHabilitacion.Enabled = true;
            cboTipResponsableCaja1.Enabled = true;
            chclBilletaje.Enabled = true;
            btnNuevo1.Enabled = false;
            btnEditar1.Enabled = false;
            btnEliminar1.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (dtgVinculoTipHabTipResBov.RowCount > 0)
            {
                nOpcion = 2;
                dtgVinculoTipHabTipResBov.Enabled = false;
                cboAgencias.Enabled = false;
                chclBilletaje.Enabled = true;
                btnNuevo1.Enabled = false;
                btnEditar1.Enabled = false;
                btnEliminar1.Enabled = false;
                btnGrabar.Enabled = true;
                btnCancelar.Enabled = true;
            }
            else
            {
                MessageBox.Show("No existe registro para editar", "Vinculo tipo de habilitación con tipo responsable de bóveda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            nOpcion = 0;
            cboTiposHabilitacion.Enabled = false;
            cboTipResponsableCaja1.Enabled = false;
            chclBilletaje.Enabled = false;

            dtgVinculoTipHabTipResBov.Enabled = true;
            cboAgencias.Enabled = true;
            chclBilletaje.Enabled = false;
            btnNuevo1.Enabled = true;
            btnEditar1.Enabled = true;
            btnEliminar1.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
            if (dtgVinculoTipHabTipResBov.SelectedRows.Count > 0)
            {
                int FilaIndice;
                FilaIndice = dtgVinculoTipHabTipResBov.SelectedCells[1].RowIndex;
                cargarDatos(FilaIndice);
            }
        }

        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            if (this.cboAgencias.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar la agencia", "Vincular tipos de habilitaciones por responsables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgencias.Focus();
                this.cboAgencias.Select();
                return;
            }
            if (dtgVinculoTipHabTipResBov.RowCount <= 0)
            {
                MessageBox.Show("No existe registro para eliminar", "Vinculo tipo de habilitación con tipo responsable de bóveda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("¿Esta seguro de eliminar el registro?", "Vinculo tipo de habilitación con tipo responsable de bóveda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                bool lNecBilletaje = chclBilletaje.Checked;
                DataTable dtResp;
                dtResp = cnVinctipHabRespo.EditarVincTipHabTipResponsable(pidVinTipHabRes, clsVarGlobal.nIdAgencia, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, lNecBilletaje, false);
                if (Convert.ToInt32(dtResp.Rows[0]["nResp"]) > 0)
                {
                    MessageBox.Show("Los datos se eliminaron correctamente", "Vinculo tipo de habilitación con tipo responsable de bóveda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatosRelacion();
                }
                else
                {
                    MessageBox.Show("Error al eliminar los datos del vinculo", "Vinculo tipo de habilitación con tipo responsable de bóveda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //private void dtgVinculoTipHabTipResBov_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}
    }
}
