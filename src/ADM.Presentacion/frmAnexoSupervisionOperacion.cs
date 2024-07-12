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
using GEN.ControlesBase;
using EntityLayer;
using System.IO;
using GEN.Funciones;
using System.Diagnostics;

namespace ADM.Presentacion
{
    public partial class frmAnexoSupervisionOperacion : frmBase
    {
        #region Variables
        public int idVisita;
        private clsCNVisitaSupervisionOperacion clsVisita = new clsCNVisitaSupervisionOperacion();
        bool readOnly = false;
        private string ruta;
        #endregion

        #region Metodos
        public frmAnexoSupervisionOperacion()
        {
            InitializeComponent();
        }

        private void getAnexoVisita()
        {
            DataTable dtAnexo = clsVisita.getAnexoVisita(idVisita);
            dtgAnexo.DataSource = dtAnexo;

            DataTable dtDatosVisita = clsVisita.getDatosVisita(idVisita);
            if (Convert.ToInt32(dtDatosVisita.Rows[0]["idEstado"]) == 2 || Convert.ToInt32(dtDatosVisita.Rows[0]["idUsuario"]) != clsVarGlobal.User.idUsuario || Convert.ToInt32(dtDatosVisita.Rows[0]["nConformidad"]) > 0)
            {
                readOnly = true;
                grbBase1.Visible = false;
            }
            else
            {
                readOnly = false;
                grbBase1.Visible = true;
            }

            if (dtAnexo.Rows.Count > 0)
            {
                grbBase1.Visible = false;
            }
        }

        private void formatDtg()
        {
            foreach (DataGridViewColumn item in dtgAnexo.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgAnexo.Columns["cNombreArchivo"].Visible = true;
            dtgAnexo.Columns["cNombreArchivo"].HeaderText = "Nombre de Archivo";

            dtgAnexo.Columns["cNombreArchivo"].DisplayIndex = 1;


            if (!readOnly)
            {
                DataGridViewButtonColumn btnAdd = new DataGridViewButtonColumn();
                {
                    btnAdd.Name = "btnAddFile";
                    btnAdd.HeaderText = "Subir";
                    btnAdd.Text = "+";
                    btnAdd.UseColumnTextForButtonValue = true;
                    btnAdd.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    btnAdd.FlatStyle = FlatStyle.Standard;
                    btnAdd.CellTemplate.Style.BackColor = Color.Honeydew;
                    btnAdd.Visible = !readOnly;
                    dtgAnexo.Columns.Add(btnAdd);
                    dtgAnexo.Columns["btnAddFile"].DisplayIndex = 2;
                }

                DataGridViewButtonColumn btnRemove = new DataGridViewButtonColumn();
                {
                    btnRemove.Name = "btnDeleteFile";
                    btnRemove.HeaderText = "Quitar";
                    btnRemove.Text = "-";
                    btnRemove.UseColumnTextForButtonValue = true;
                    btnRemove.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    btnRemove.FlatStyle = FlatStyle.Standard;
                    btnRemove.CellTemplate.Style.BackColor = Color.Honeydew;
                    btnRemove.Visible = !readOnly;
                    dtgAnexo.Columns.Add(btnRemove);
                }
            }

            DataGridViewButtonColumn btnView = new DataGridViewButtonColumn();
            {
                btnView.Name = "btnViewFile";
                btnView.HeaderText = "Ver";
                btnView.Text = "Ver";
                btnView.UseColumnTextForButtonValue = true;
                btnView.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnView.FlatStyle = FlatStyle.Standard;
                btnView.CellTemplate.Style.BackColor = Color.Honeydew;
                btnView.DefaultCellStyle.BackColor = Color.LightGray;
                dtgAnexo.Columns.Add(btnView);
            }

        }

        private void agregarAnexo()
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Excel Files (.xlsx)|*.xlsx|(.xls)|*.xls";
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string[] cAuxNombreArchivo = dialog.FileName.Split('\\');
                    string cNombreArchivo = cAuxNombreArchivo[cAuxNombreArchivo.Length - 1];
                    string cDireccion = dialog.FileName;

                    DataTable dtRes = clsVisita.guardarAnexoVisita(idVisita, cNombreArchivo, Compresion.CompressedByte(System.IO.File.ReadAllBytes(cDireccion)));

                    if (Convert.ToInt32(dtRes.Rows[0]["idRes"]) == 1)
                    {
                        MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Anexos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getAnexoVisita();
                    }
                    else
                    {
                        MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Anexos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Anexos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion



        #region Eventos

        private void dtgAnexo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int addFile = -1;
            int deleteFile = -1;
            int viewFile = -1;

            if (!readOnly)
            {
                addFile = dtgAnexo.Columns["btnAddFile"].Index;
                deleteFile = dtgAnexo.Columns["btnDeleteFile"].Index;
            }

            viewFile = dtgAnexo.Columns["btnViewFile"].Index;

            if (dtgAnexo.CurrentCell == null)
                return;

            if (dtgAnexo.CurrentCell.ColumnIndex.Equals(addFile))
            {
                agregarAnexo();
            }
            else if (dtgAnexo.CurrentCell.ColumnIndex.Equals(deleteFile))
            {
                if (dtgAnexo.Rows[dtgAnexo.CurrentCell.RowIndex].Cells["cNombreArchivo"].Value.ToString() != "")
                {
                    DataTable dtRes = clsVisita.guardarAnexoVisita(idVisita, "", new byte[0]);

                    if (Convert.ToInt32(dtRes.Rows[0]["idRes"]) == 1)
                    {
                        MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Anexos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getAnexoVisita();
                    }
                    else
                    {
                        MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Anexos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("No se cargó ningun Anexo", "Anexos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (dtgAnexo.CurrentCell.ColumnIndex.Equals(viewFile))
            {
                if (dtgAnexo.Rows[dtgAnexo.CurrentCell.RowIndex].Cells["cNombreArchivo"].Value.ToString() != "")
                {
                    try
                    {
                        dtgAnexo.Enabled = false;
                        string cDirectorio = String.Format("{0}\\{1}", clsVarGlobal.cRutPathApp, "documentosTmp");
                        string cNombreArchivo = clsVarGlobal.User.idUsuario + " " + idVisita + " " + dtgAnexo.Rows[dtgAnexo.CurrentCell.RowIndex].Cells["cNombreArchivo"].Value.ToString();
                        if (!Directory.Exists(cDirectorio))
                        {
                            Directory.CreateDirectory(cDirectorio);
                        }

                        ruta = String.Format("{0}\\{1}", cDirectorio, cNombreArchivo);
                        FileInfo fileInfo = new FileInfo(ruta);
                        File.WriteAllBytes(ruta, Compresion.DescompressedByte((byte[])dtgAnexo.Rows[dtgAnexo.CurrentCell.RowIndex].Cells["bArchivo"].Value));

                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.CreateNoWindow = true;
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.FileName = ruta;


                        Process correctionProcess = Process.Start(startInfo);
                        correctionProcess.EnableRaisingEvents = true;
                        correctionProcess.Exited += new EventHandler(processExited);
                        correctionProcess.WaitForExit();
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message, "Anexos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("No se cargó ningun Anexo", "Anexo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        internal void processExited(object sender, System.EventArgs e)
        {
            System.IO.File.Delete(ruta);
            dtgAnexo.Enabled = true;
        }

        private void btnAnexo_Click(object sender, EventArgs e)
        {
            agregarAnexo();
        }

        private void frmAnexoSupervisionOperacion_Load(object sender, EventArgs e)
        {
            getAnexoVisita();
            formatDtg();
        }
        #endregion
    }
}
