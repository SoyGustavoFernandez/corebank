using EntityLayer;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class frmVisita : frmBase
    {
        #region Variables
        clsCNVisitas clsCNVisita = new clsCNVisitas();
        int idVisita;
        int idSolicitud;
        int imgPosicion;
        DataTable imagenes;
        #endregion

        public frmVisita(int idVisita_, int idSolicitud_)
        {
            InitializeComponent();
            idVisita = idVisita_;
            idSolicitud = idSolicitud_;
        }

        private void frmVisita_Load(object sender, EventArgs e)
        {
            //DataTable imagen = getAllImages();
            imagenes = clsCNVisita.CNListarArchivosVisita(idVisita, idSolicitud);
            imagenes.Columns.Add("lSelected", typeof(bool));
            dtgArchivos.DataSource = imagenes;
            formatearDTG();
            if (imagenes.Rows.Count > 0)
            {
                dtgArchivos.Rows[0].Selected = true;
                dtgArchivos.Focus();
                dtgArchivos.Rows[0].Cells["lSelected"].Value = 1;
            }
            else
            {
                MessageBox.Show("no se tiene archivos vinculados..", "Archivos de Visita", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
            }
        }

        private void formatearDTG()
        {
            dtgArchivos.Columns["cNombreArchivo"].HeaderText = "Archivo";
            dtgArchivos.Columns["lSelected"].HeaderText = "";
            dtgArchivos.Columns["idArchivos"].Visible = false;
            dtgArchivos.Columns["lSelected"].Width = 20;
            dtgArchivos.Columns["cNombreArchivo"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void ponerImagen(int idArchivo)
        {
            try
            {
                DataTable img = clsCNVisita.CNObtenerArchivoVisita(idArchivo);
                byte[] picture = Convert.FromBase64String(img.Rows[0]["cArchivo"].ToString());
                pictureBox1.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(picture));
                lblNombreArchivo.Text = img.Rows[0]["cNombreArchivo"].ToString();
                marcarDtg(idArchivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void marcarDtg(int idArchivo)
        {
            for (int i = 0; i < dtgArchivos.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtgArchivos.Rows[i].Cells["idArchivos"].Value) == idArchivo)
                {
                    dtgArchivos.Rows[i].Selected = true;
                    dtgArchivos.Focus();
                    dtgArchivos.Rows[i].Cells["lSelected"].Value = 1;
                    imgPosicion = i;
                }else
                    dtgArchivos.Rows[i].Cells["lSelected"].Value = 0;
            }
        }

        private void cambiarPosicion(int val)
        {
            if (imagenes.Rows.Count > 0)
            {
                imgPosicion = imgPosicion + val;
                if (imgPosicion < 0)
                    imgPosicion = imagenes.Rows.Count - 1;
                if (imgPosicion >= imagenes.Rows.Count)
                    imgPosicion = 0;

                marcarDtg(Convert.ToInt32(imagenes.Rows[imgPosicion]["idArchivos"]));
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            cambiarPosicion(-1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            cambiarPosicion(1);
        }

        private void dtgArchivos_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgArchivos.SelectedCells.Count > 0)
            {
                int idArchivo = Convert.ToInt32(dtgArchivos.Rows[dtgArchivos.SelectedCells[0].RowIndex].Cells["idArchivos"].Value);
                ponerImagen(idArchivo);
            }
        }
    }
}
