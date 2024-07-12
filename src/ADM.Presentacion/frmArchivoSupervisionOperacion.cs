using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using EntityLayer;
using CAJ.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using System.Drawing.Imaging;

namespace ADM.Presentacion
{
    public partial class frmArchivoSupervisionOperacion : frmBase
    {
        #region Variables
        int imgPosicion;
        DataTable dtImagenes;
        private clsCNVisitaSupervisionOperacion clsVisita = new clsCNVisitaSupervisionOperacion();
        public int idVisita;
        public int idPregunta;
        public bool lEdicion;
        #endregion

        public frmArchivoSupervisionOperacion()
        {
            InitializeComponent();
        }

        #region Metodos
        private void formatearDTG()
        {
            dtgArchivos.Columns["cArchivo"].HeaderText = "Archivo";
            dtgArchivos.Columns["lSelected"].HeaderText = "";
            dtgArchivos.Columns["idArchivo"].Visible = false;
            dtgArchivos.Columns["lSelected"].Visible = false;
            dtgArchivos.Columns["cArchivo"].SortMode = DataGridViewColumnSortMode.NotSortable;

            DataGridViewButtonColumn btnRemove = new DataGridViewButtonColumn();
            {
                btnRemove.Name = "btnDeleteFile";
                btnRemove.HeaderText = "Quitar";
                btnRemove.Text = "-";
                btnRemove.UseColumnTextForButtonValue = true;
                btnRemove.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnRemove.FlatStyle = FlatStyle.Standard;
                btnRemove.CellTemplate.Style.BackColor = Color.Honeydew;
                btnRemove.Visible = lEdicion;
                dtgArchivos.Columns.Add(btnRemove);
            }
        }

        private void ponerImagen(int idArchivo)
        {
            try
            {
                DataTable img = clsVisita.obtenerArchivoVisita(idArchivo);
                byte[] picture = Compresion.DescompressedByte((byte[])img.Rows[0]["bBinary"]);

                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox1.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(picture));
                lblNombreArchivo.Text = img.Rows[0]["cArchivo"].ToString();
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
                if (Convert.ToInt32(dtgArchivos.Rows[i].Cells["idArchivo"].Value) == idArchivo)
                {
                    dtgArchivos.Rows[i].Selected = true;
                    dtgArchivos.Focus();
                    dtgArchivos.Rows[i].Cells["lSelected"].Value = 1;
                    imgPosicion = i;
                }
                else
                    dtgArchivos.Rows[i].Cells["lSelected"].Value = 0;
            }
        }

        private void cambiarPosicion(int val)
        {
            if (dtImagenes.Rows.Count > 0)
            {
                imgPosicion = imgPosicion + val;
                if (imgPosicion < 0)
                    imgPosicion = dtImagenes.Rows.Count - 1;
                if (imgPosicion >= dtImagenes.Rows.Count)
                    imgPosicion = 0;

                marcarDtg(Convert.ToInt32(dtImagenes.Rows[imgPosicion]["idArchivo"]));
            }
        }

        private void listarArchivosVisitaxPregunta()
        {
            dtImagenes = clsVisita.listarArchivosVisita(idVisita, idPregunta);
            dtImagenes.Columns.Add("lSelected", typeof(bool));
            dtgArchivos.DataSource = dtImagenes;
            if (dtImagenes.Rows.Count > 0)
            {
                dtgArchivos.Rows[0].Selected = true;
                dtgArchivos.Focus();
                dtgArchivos.Rows[0].Cells["lSelected"].Value = 1;
            }
            else
            {
                pictureBox1.Image = null;
                lblNombreArchivo.Text = "";
            }
        }

        #endregion

        #region Eventos
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
                int idArchivo = Convert.ToInt32(dtgArchivos.Rows[dtgArchivos.SelectedCells[0].RowIndex].Cells["idArchivo"].Value);
                ponerImagen(idArchivo);
            }
        }

        private void frmArchivoSupervisionOperacion_Load(object sender, EventArgs e)
        {
            panel1.AutoScroll = true;
            listarArchivosVisitaxPregunta();
            formatearDTG();
            btnExaminar.Visible = lEdicion;
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter =
            "Images (*.BMP;*.JPG;*.PNG;*.JPEG;)|*.BMP;*.JPG;*.PNG;*.JPEG;|" + "All cFiles (*.*)|*.*";

            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "Carga de Archivos - Supervisión de Operaciones";

            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                int nCargados = 0;
                string cErrorCarga = "";
                string cRepetidos = "";
                foreach (String cFile in openFileDialog1.FileNames)
                {
                    try
                    {
                        MemoryStream stream = new MemoryStream();
                        Bitmap bitmap = new Bitmap(cFile);
                        bitmap.Save(stream, ImageFormat.Jpeg);
                        stream.Position = 0;
                        byte[] bBinaryFile = Compresion.CompressedByte(stream.GetBuffer());

                        DataTable dtRes = clsVisita.guardarArchivoSupervision(idVisita, idPregunta, Path.GetFileName(cFile), bBinaryFile, clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.PerfilUsu.idPerfil);
                        if (Convert.ToInt32(dtRes.Rows[0]["idRespuesta"]) == 1)
                        {
                            nCargados++;
                        }
                        else if (Convert.ToInt32(dtRes.Rows[0]["idRespuesta"]) == 2)
                        {
                            if (cRepetidos != "")
                                cRepetidos += "\n";
                            cRepetidos += "_ " + cFile;
                        }
                        else
                        {
                            if (cErrorCarga != "")
                                cErrorCarga += "\n";
                            cErrorCarga += "_ " + cFile;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: El Archivo (" + cFile + ") No pudo cargarse por que no existe o no tiene permisos o está dañado.", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                if (openFileDialog1.SafeFileNames.Count() == nCargados)
                {
                    MessageBox.Show("Se ha cargado los archivos correctamente", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string cMesg = "Error, no se cargaron los arhivos:\n";
                    if (cErrorCarga != "")
                    {
                        cMesg += "Error al cargar:\n" + cErrorCarga;
                    }

                    if (cRepetidos != "")
                    {
                        cMesg += "Archivos ya Existentes:\n" + cRepetidos;
                    }

                    MessageBox.Show(cMesg, "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                listarArchivosVisitaxPregunta();
            }
        }

        private void dtgArchivos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgArchivos.Rows.Count > 0)
            {
                int deleteFile = dtgArchivos.Columns["btnDeleteFile"].Index;
                if (dtgArchivos.CurrentCell.ColumnIndex.Equals(deleteFile))
                {
                    if (MessageBox.Show("Seguro que desea quitar este archivo?", "Carga de Archivos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DataTable dtRes = clsVisita.quitarArchivoSupervision(Convert.ToInt32(dtgArchivos.Rows[dtgArchivos.CurrentCell.RowIndex].Cells["idArchivo"].Value));
                        if (Convert.ToInt32(dtRes.Rows[0]["idRespuesta"]) == 1)
                        {
                            MessageBox.Show("Se ha quitado el archivo existosamente.", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            listarArchivosVisitaxPregunta();
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error, inténtelo de nuevo.", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
        }

        #endregion
    }
}
