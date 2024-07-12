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
using LOG.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;
namespace GEN.ControlesBase
{
    public partial class frmBusquedaCatalogo : frmBase
    {
        #region Variables

        public int nTipBusqueda = 0;

        DataTable dtCatalogo = new DataTable();
        DataTable dt;
        List<clsCatalogo> LstCatalogo;
        public List<clsCatalogo> LstCatalogoSeleccionado = new List<clsCatalogo>();
        
        public clsCatalogo objCatalogo;
        public int idAlmacen = 0;
        public string idGrupo = "";
        public string cDescCatalogo="";
        public string cCatalogo="";
        public int idUnidad=0;
        public string cUnidad="";
        public decimal nStock;
        public int pidTipoPedido=0;
        public int idMoneda = 0;

        #endregion

        #region Eventos

        private void frmBusquedaCatalogo_Load(object sender, EventArgs e)
        {
            IniForm();
        }

        private void cboTipoBien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoBien.SelectedIndex >= 0)
            {
                this.cboSubTipoBien.ListarGrupo(0, Convert.ToInt32(this.cboTipoBien.SelectedValue));
                cboSubTipoBien.SelectedValue = 0;
                cboGrupoBien.SelectedValue = 0;
                cboSubGrupo.SelectedValue = 0;
                txtBuscar.Text = "";
                BuscarCatalogo();
            }
        }

        private void cboSubTipoBien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboSubTipoBien.SelectedIndex > 0)
            {
                this.cboGrupoBien.ListarGrupo(Convert.ToInt32(this.cboSubTipoBien.SelectedValue), Convert.ToInt32(this.cboTipoBien.SelectedValue));
                cboGrupoBien.SelectedValue = 0;
                cboSubGrupo.SelectedValue = 0;
                txtBuscar.Text = "";
                BuscarCatalogo();
            }
        }

        private void cboGrupoBien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboGrupoBien.SelectedIndex > 0)
            {
                this.cboSubGrupo.ListarGrupo(Convert.ToInt32(this.cboGrupoBien.SelectedValue), Convert.ToInt32(this.cboTipoBien.SelectedValue));
                cboSubGrupo.SelectedValue = 0;
                txtBuscar.Text = "";
                BuscarCatalogo();
                this.txtBuscar.Enabled = true;
            }
        }

        private void cboSubGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            if (this.cboSubGrupo.SelectedIndex > 0)
            {
                BuscarCatalogo();
                this.txtBuscar.Enabled = true;
            }
            else
            {
                btnAceptar.Enabled = false;
                cboUnidadMedida.Enabled = false;
                this.dtgDetalleCatalogo.DataSource = "";
            }
        }

        private void dtgDetalleCatalogo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgDetalleCatalogo.SelectedRows[0].Cells["lSelect"].Value = !Convert.ToBoolean(dtgDetalleCatalogo.SelectedRows[0].Cells["lSelect"].Value);
        }

        private void dtgDetalleCatalogo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtgDetalleCatalogo.SelectedRows[0].Cells["lSelect"].Value = !Convert.ToBoolean(dtgDetalleCatalogo.SelectedRows[0].Cells["lSelect"].Value);
            }
        }  

        private void txtCatalogo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BuscarCatalogo();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.dtCatalogo.Clear();
            cDescCatalogo = "";
            cCatalogo = "";
            idGrupo = "";
            idUnidad = 0;
            cUnidad = "";
        }

        #endregion

        #region Metodos

        public frmBusquedaCatalogo()
        {
            InitializeComponent();
        }

        private void Aceptar()
        {
            if (dtgDetalleCatalogo.SelectedRows.Count > 0)
            {
                if (nTipBusqueda == 1)
                {
                    foreach(DataGridViewRow row in dtgDetalleCatalogo.Rows){
                        if (Convert.ToBoolean(row.Cells["lSelect"].Value))
                        {
                            LstCatalogoSeleccionado.Add((clsCatalogo)row.DataBoundItem);
                        }
                    }
                    
                }
                else
                {
                    int fila = dtgDetalleCatalogo.SelectedCells[0].RowIndex;

                    idGrupo = this.dtgDetalleCatalogo.Rows[fila].Cells["idGrupoActivo"].Value.ToString();
                    cDescCatalogo = this.dtgDetalleCatalogo.Rows[fila].Cells["cNombreGrupo"].Value.ToString();
                    cCatalogo = this.dtgDetalleCatalogo.Rows[fila].Cells["cNombreGrupo"].Value.ToString();
                    idUnidad = Convert.ToInt32(cboUnidadMedida.SelectedValue);
                    cUnidad = cboUnidadMedida.Text;
                }
                this.Dispose();
            }
            else
            {
                MessageBox.Show("No existe Ningún Item para añadir ", "Añadir Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void BuscarCatalogo()
        {
            string cFiltro = this.txtBuscar.Text;
            if (nTipBusqueda == 1)
            {
                int idTipoBien = Convert.ToInt32(cboTipoBien.SelectedValue);
                int idSubTipo = Convert.ToInt32(cboSubTipoBien.SelectedValue);
                int idGrupo = Convert.ToInt32(cboGrupoBien.SelectedValue);
                int idSubGrupo = Convert.ToInt32(cboSubGrupo.SelectedValue);

                LstCatalogo = new clsCNCatalogo().CNBuscarCatalogoxGrupo(cFiltro,idAlmacen, idTipoBien, idSubTipo, idGrupo, idSubGrupo, idMoneda);
                if (LstCatalogo.Count > 0)
                {
                    this.dtgDetalleCatalogo.DataSource = LstCatalogo;
                    Formatogrid();
                    btnAceptar.Enabled = true;
                }
            }
            else
            {
                clsCNGrupoCatalogo objGrupo = new clsCNGrupoCatalogo();
                dt = objGrupo.CNListaGrupoCatalogo(Convert.ToInt32(cboGrupoBien.SelectedValue), Convert.ToInt32(cboTipoBien.SelectedValue));

                if (dt.Rows.Count > 0)
                {
                    dtgDetalleCatalogo.DataSource = dt;
                    Formatogrid();
                    btnAceptar.Enabled = true;
                    cboUnidadMedida.Enabled = true;
                }
                else
                {
                    btnAceptar.Enabled = false;
                    cboUnidadMedida.Enabled = false;
                }
            }
        }

        private void Formatogrid()
        {
            if (nTipBusqueda == 1)
            {
                foreach (DataGridViewColumn column in dtgDetalleCatalogo.Columns)
                {
                    column.Visible = false;
                }

                dtgDetalleCatalogo.Columns["idCatalogo"].Visible = true;
                dtgDetalleCatalogo.Columns["cUnidAlmacenaje"].Visible = true;
                dtgDetalleCatalogo.Columns["cNombreGrupo"].Visible = true;
                dtgDetalleCatalogo.Columns["cProducto"].Visible = true;
                dtgDetalleCatalogo.Columns["lSelect"].Visible = true;

                dtgDetalleCatalogo.Columns["idCatalogo"].HeaderText = "Cód";
                dtgDetalleCatalogo.Columns["cUnidAlmacenaje"].HeaderText = "Und";
                dtgDetalleCatalogo.Columns["cNombreGrupo"].HeaderText = "Descripción";
                dtgDetalleCatalogo.Columns["cProducto"].HeaderText = "Bien/Servicio";
                dtgDetalleCatalogo.Columns["lSelect"].HeaderText = "";

                dtgDetalleCatalogo.Columns["idCatalogo"].FillWeight = 5;
                dtgDetalleCatalogo.Columns["cUnidAlmacenaje"].FillWeight = 5;
                dtgDetalleCatalogo.Columns["cNombreGrupo"].FillWeight = 23;
                dtgDetalleCatalogo.Columns["cProducto"].FillWeight = 63;
                dtgDetalleCatalogo.Columns["lSelect"].FillWeight = 4;

                dtgDetalleCatalogo.Columns["idCatalogo"].DisplayIndex = 1;
                dtgDetalleCatalogo.Columns["cUnidAlmacenaje"].DisplayIndex = 2;
                dtgDetalleCatalogo.Columns["cNombreGrupo"].DisplayIndex = 3;
                dtgDetalleCatalogo.Columns["cProducto"].DisplayIndex = 4;
                dtgDetalleCatalogo.Columns["lSelect"].DisplayIndex = 0;
            }
            else
            {
                dtgDetalleCatalogo.Columns["idGrupoActivo"].Visible = true;
                dtgDetalleCatalogo.Columns["cNombreGrupo"].Visible = true;

                dtgDetalleCatalogo.Columns["idGrupoActivo"].HeaderText = "Código";
                dtgDetalleCatalogo.Columns["cNombreGrupo"].HeaderText = "Descripción";

                dtgDetalleCatalogo.Columns["idGrupoActivo"].Width = 50;
                dtgDetalleCatalogo.Columns["cNombreGrupo"].Width = 200;
            }

        }

        private void IniForm()
        {
            cboTipoBien.SelectedIndex = -1;
            cboTipoBien.cargarTipoBien(pidTipoPedido);

            cboSubTipoBien.SelectedIndex = -1;
            cboGrupoBien.SelectedIndex = -1;
            cboUnidadMedida.Enabled = false;
            btnAceptar.Enabled = true;
            if (nTipBusqueda == 1)
            {
                cboSubGrupo.Enabled = true;
                txtBuscar.Enabled = true;
            }
            else
            {
                cboSubGrupo.Enabled = false;
                txtBuscar.Enabled = false;
            }
        }

        #endregion

        private void dtgDetalleCatalogo_SelectionChanged(object sender, EventArgs e)
        {
            if (nTipBusqueda == 1)
            {
                if (dtgDetalleCatalogo.SelectedRows.Count > 0)
                {
                    cboUnidadMedida.SelectedValue = Convert.ToInt16(dtgDetalleCatalogo.SelectedRows[0].Cells["idUnidadAlmacenaje"].Value);
                }
            }
        }

    }
}
