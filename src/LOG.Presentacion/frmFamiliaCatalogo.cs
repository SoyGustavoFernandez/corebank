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
using LOG.CapaNegocio;

namespace LOG.Presentacion
{
    public partial class frmFamiliaCatalogo : frmBase
    {
        #region Variable
        private string cTituloMsjes = "Mantenimeinto de Familia";
        private clsCNNotaSalida clsNotaSalida = new clsCNNotaSalida();
        private clsNotaSalida objNotaSalida;
        public int nTipBusqueda = 0;
        clsCNCatalogo clsCatalogo = new clsCNCatalogo();
        #endregion
        public frmFamiliaCatalogo()
        {
            InitializeComponent();
        }

        private void FormatoGridView(bool lSoloLectura = false)
        {
            dtgDetalleNS.ReadOnly = false;
            foreach (DataGridViewColumn column in dtgDetalleNS.Columns)
            {
                column.ReadOnly = true;
                column.Visible = false;
            }

            dtgDetalleNS.Columns["idCatalogo"].Visible = true;
            dtgDetalleNS.Columns["cUnidMedida"].Visible = true;
            dtgDetalleNS.Columns["cProducto"].Visible = true;

            dtgDetalleNS.Columns["idCatalogo"].HeaderText = "Código";
            dtgDetalleNS.Columns["cUnidMedida"].HeaderText = "Uni. Medida";
            dtgDetalleNS.Columns["cProducto"].HeaderText = "Producto";

            dtgDetalleNS.Columns["idCatalogo"].DisplayIndex = 0;
            dtgDetalleNS.Columns["cProducto"].DisplayIndex = 1;
            dtgDetalleNS.Columns["cUnidMedida"].DisplayIndex = 2;

            dtgDetalleNS.Columns["idCatalogo"].FillWeight = 20;
            dtgDetalleNS.Columns["cUnidMedida"].FillWeight = 20;
            dtgDetalleNS.Columns["cProducto"].FillWeight = 80;

        }

        private void btnMiniAgregar1_Click(object sender, EventArgs e)
        {
            objNotaSalida = new clsNotaSalida(0);

            frmBusquedaCatalogo frmCatalogo = new frmBusquedaCatalogo();
            frmCatalogo.idAlmacen = 0;
            frmCatalogo.pidTipoPedido = 0;
            frmCatalogo.nTipBusqueda = 1;
            frmCatalogo.ShowDialog();

            List<clsCatalogo> LstCatalogoSeleccionado = frmCatalogo.LstCatalogoSeleccionado;

            if (LstCatalogoSeleccionado.Count == 0)
            {
                MessageBox.Show("No se seleccionó ningun producto.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (clsCatalogo objCatalogo in LstCatalogoSeleccionado)
            {
                clsDetNotaSalida objDetNotSalida = new clsDetNotaSalida(0);
                objDetNotSalida.objCatalogo = objCatalogo;
                objDetNotSalida.idUniMedida = objCatalogo.idUnidadAlmacenaje;
                objDetNotSalida.cUnidMedida = objCatalogo.cUnidAlmacenaje;

                objNotaSalida.LstDetNotSalida.Add(objDetNotSalida);

                dtgDetalleNS.DataSource = objNotaSalida.LstDetNotSalida.Where(x => x.lVigente == true).ToList();
            }

            FormatoGridView();
        }

        private void cboTipoBien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoBien.SelectedIndex >= 0)
            {
                this.cboSubTipoBien.ListarGrupo(0, Convert.ToInt32(this.cboTipoBien.SelectedValue));
                cboSubTipoBien.SelectedValue = 0;
                cboGrupoBien.SelectedValue = 0;
                cboSubGrupo.SelectedValue = 0;
            }
        }

        private void cboSubTipoBien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboSubTipoBien.SelectedIndex > 0)
            {
                this.cboGrupoBien.ListarGrupo(Convert.ToInt32(this.cboSubTipoBien.SelectedValue), Convert.ToInt32(this.cboTipoBien.SelectedValue));
                cboGrupoBien.SelectedValue = 0;
                cboSubGrupo.SelectedValue = 0;
            }
        }

        private void cboGrupoBien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboGrupoBien.SelectedIndex > 0)
            {
                this.cboSubGrupo.ListarGrupo(Convert.ToInt32(this.cboGrupoBien.SelectedValue), Convert.ToInt32(this.cboTipoBien.SelectedValue));
                cboSubGrupo.SelectedValue = 0;
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (dtgDetalleNS.Rows.Count == 0)
            {
                MessageBox.Show("No se seleccionó ningun producto.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboSubGrupo.SelectedIndex <= 0)
            {
                MessageBox.Show("No se ha seleccionado el Sub Grupo / Familia.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtRes = clsCatalogo.CNCambiarFamiliaBienes(Convert.ToInt32(cboSubGrupo.SelectedValue), objNotaSalida);

            if (Convert.ToInt32(dtRes.Rows[0]["idRes"]) == 1)
            {
                MessageBox.Show(dtRes.Rows[0]["cmensaje"].ToString(), cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show(dtRes.Rows[0]["cmensaje"].ToString(), cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
