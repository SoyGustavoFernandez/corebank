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
using GEN.PrintHelper;
using LOG.CapaNegocio;

namespace LOG.Presentacion
{
    public partial class frmListaActivosxAlmacen : frmBase
    {
        #region Variables Globales
        clsCNAlmacen cnAlmacen = new clsCNAlmacen();
        DataTable dtActAlmacen = new DataTable();
        int idAlmacenAct;
        public int idCatalog;
        public string cNombreGrup, cNombreSubGrup, cNombreRubr, cProduct, cNomCort;
        public decimal nCantStock;
        public int idUnidadAlm;

        #endregion        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //public frmListaActivosxAlmacen()
        //{
        //    InitializeComponent();
        //}

        public frmListaActivosxAlmacen(int idAlmacen)
        {
            InitializeComponent();
            idAlmacenAct = idAlmacen;
            dtActAlmacen = cnAlmacen.CNListaActAlmacen("%", idAlmacenAct);
            dtgActivosxAlmacen.DataSource = dtActAlmacen;           
        }       

        private void dtgTransferencias_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Int32 nFilaActual = Convert.ToInt32(this.dtgActivosxAlmacen.SelectedCells[0].RowIndex);
            txtStock.Text = dtgActivosxAlmacen.Rows[nFilaActual].Cells["nCantidadStock"].Value.ToString();
            txtDescripBien.Text = dtgActivosxAlmacen.Rows[nFilaActual].Cells["cProducto"].Value.ToString();
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            if (txtReferencia.Text =="")
            {
                dtgActivosxAlmacen.ClearSelection();

                dtActAlmacen = cnAlmacen.CNListaActAlmacen("%", idAlmacenAct);
                dtgActivosxAlmacen.DataSource = dtActAlmacen;                
            }
            else
            {            
            dtgActivosxAlmacen.ClearSelection();

            dtActAlmacen = cnAlmacen.CNListaActAlmacen(txtReferencia.Text, idAlmacenAct);
            dtgActivosxAlmacen.DataSource = dtActAlmacen;            
            }
        }

        private void txtReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtReferencia.Text == "")
                {
                    dtgActivosxAlmacen.ClearSelection();

                    dtActAlmacen = cnAlmacen.CNListaActAlmacen("%", idAlmacenAct);
                    dtgActivosxAlmacen.DataSource = dtActAlmacen;                    
                }
                else
                {
                    dtgActivosxAlmacen.ClearSelection();

                    dtActAlmacen = cnAlmacen.CNListaActAlmacen(txtReferencia.Text, idAlmacenAct);
                    dtgActivosxAlmacen.DataSource = dtActAlmacen;                    
                }
            }           
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            Int32 nFilaActual = Convert.ToInt32(this.dtgActivosxAlmacen.SelectedCells[0].RowIndex);            
            idCatalog= Convert.ToInt32(dtgActivosxAlmacen.Rows[nFilaActual].Cells["idCatalogo"].Value);
            cNombreGrup = dtgActivosxAlmacen.Rows[nFilaActual].Cells["cNombreGrupo"].Value.ToString();
            cNombreSubGrup = dtgActivosxAlmacen.Rows[nFilaActual].Cells["cNombreSubGrupo"].Value.ToString();
            cNombreRubr = dtgActivosxAlmacen.Rows[nFilaActual].Cells["cNombreRubro"].Value.ToString();
            cProduct = dtgActivosxAlmacen.Rows[nFilaActual].Cells["cProducto"].Value.ToString();
            cNomCort = dtgActivosxAlmacen.Rows[nFilaActual].Cells["cNomCorto"].Value.ToString();
            nCantStock = Convert.ToDecimal(dtgActivosxAlmacen.Rows[nFilaActual].Cells["nCantidadStock"].Value);
            idUnidadAlm = Convert.ToInt32(dtgActivosxAlmacen.Rows[nFilaActual].Cells["idUnidadAlmacenaje"].Value);
            this.Dispose();
        }
        
    }
}
