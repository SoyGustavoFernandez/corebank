using EntityLayer;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmCargarArchivosFechaValor : frmBase
    {
        #region Variables Globales

        private List<clsArchivoCargadoFechaValor> lstArchivosCargados;
        public event EventHandler<List<clsArchivoCargadoFechaValor>> ArchivosActualizados;
        private readonly string cTituloForm = "Archivos de Sustento";
        private string cFormularioLlamada = string.Empty;
        private readonly string[] lsExtensionesValidas = { ".pdf", ".txt", ".png", ".jpg", ".docx", ".xlsx", ".xls", ".msg" };

        #endregion

        #region Constructor

        public frmCargarArchivosFechaValor()
        {
            InitializeComponent();
        }

        public frmCargarArchivosFechaValor(List<clsArchivoCargadoFechaValor> _lstArchivosCargados, string _formName)
        {
            InitializeComponent();
            InitializeForm(_lstArchivosCargados, _formName);
        }

        #endregion

        #region Métodos Privados

        private void InitializeForm(List<clsArchivoCargadoFechaValor> archivosCargados, string formName)
        {
            lstArchivosCargados = archivosCargados;
            bindingSourceArchivosCargados.DataSource = lstArchivosCargados;
            dtgArchivosCargados.DataSource = bindingSourceArchivosCargados;
            dtgArchivosCargados.ClearSelection();
            cFormularioLlamada = formName;
            FormatearDTGArchivosCargados();
        }

        private void FormatearDTGArchivosCargados()
        {
            OcultarColumnas();
            ConfigurarEstiloColumnas();

            if (cFormularioLlamada == "frmPagoFechaValor")
                AgregarColumnaEliminar();

            AgregarColumnaVer();
            OrdenarColumnas();
        }

        private void OcultarColumnas()
        {
            foreach (DataGridViewColumn col in dtgArchivosCargados.Columns)
            {
                col.Visible = false;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgArchivosCargados.IsCurrentCellDirty)
            {
                dtgArchivosCargados.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void ConfigurarEstiloColumnas()
        {
            dtgArchivosCargados.Margin = new Padding(0);
            dtgArchivosCargados.MultiSelect = false;
            dtgArchivosCargados.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgArchivosCargados.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgArchivosCargados.RowHeadersVisible = false;

            dtgArchivosCargados.Columns["cNombreArchivo"].HeaderText = "Nombre Archivo";
            dtgArchivosCargados.Columns["cNombreArchivo"].FillWeight = 100;
            dtgArchivosCargados.Columns["cNombreArchivo"].Visible = true;

            dtgArchivosCargados.Columns["cPathCompleto"].HeaderText = "Ruta Completa";
            dtgArchivosCargados.Columns["cPathCompleto"].FillWeight = 100;
            dtgArchivosCargados.Columns["cPathCompleto"].Visible = false;
        }

        private void AgregarColumnaEliminar()
        {
            var btnDelete = new DataGridViewButtonColumn
            {
                Name = "btnDeleteFile",
                HeaderText = "Quitar",
                Text = "-",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                FlatStyle = FlatStyle.Standard,
                CellTemplate = { Style = { BackColor = Color.Honeydew } },
                DefaultCellStyle = { BackColor = Color.LightGray }
            };

            dtgArchivosCargados.Columns.Add(btnDelete);
        }

        private void AgregarColumnaVer()
        {
            var btnView = new DataGridViewButtonColumn
            {
                Name = "btnViewFile",
                HeaderText = "Ver",
                Text = "Ver",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                FlatStyle = FlatStyle.Standard,
                CellTemplate = { Style = { BackColor = Color.Honeydew } },
                DefaultCellStyle = { BackColor = Color.LightGray }
            };

            dtgArchivosCargados.Columns.Add(btnView);
        }

        private void OrdenarColumnas()
        {
            dtgArchivosCargados.Columns["cNombreArchivo"].DisplayIndex = 0;
            if (cFormularioLlamada == "frmPagoFechaValor")
                dtgArchivosCargados.Columns["btnDeleteFile"].DisplayIndex = 1;
            dtgArchivosCargados.Columns["btnViewFile"].DisplayIndex = 2;
        }

        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EscribirArchivoTemporal(byte[] fileBytes, string filePath)
        {
            File.WriteAllBytes(filePath, fileBytes);
        }

        private void NavegarWebBrowser(string path)
        {
            webBrowser.Navigate(path);
            PanelContenedorVisualizador.Visible = true;
        }

        private void AbrirArchivo(int rowIndex)
        {
            try
            {
                var cellFileName = dtgArchivosCargados.Rows[rowIndex].Cells["cNombreArchivo"].Value;
                var cellFilePath = dtgArchivosCargados.Rows[rowIndex].Cells["cPathCompleto"].Value;
                var cBinary = dtgArchivosCargados.Rows[rowIndex].Cells["cByteArchivo"].Value;

                string fileName = cellFileName.ToString();
                string filePath = cellFilePath == null ? string.Empty : cellFilePath.ToString();
                string extension = Path.GetExtension(fileName);

                if (!ValidarExtension(extension))
                {
                    throw new NotSupportedException("El tipo de archivo no es compatible.");
                }

                if (cFormularioLlamada == "frmPagoFechaValor")
                {
                    byte[] fileBytes = LeerBytesArchivo(filePath);
                    EscribirArchivoTemporal(fileBytes, filePath);
                    NavegarWebBrowser(filePath);
                }
                else
                {
                    if (cBinary != null)
                    {
                        byte[] binaryData = (byte[])cBinary;
                        string tempPath = Path.Combine(Path.GetTempPath(), fileName);
                        File.WriteAllBytes(tempPath, binaryData);
                        NavegarWebBrowser(tempPath);
                    }
                    else
                    {
                        throw new IOException("Error al leer el contenido del archivo.");
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al abrir el archivo: {ex.Message}");
            }
        }

        private void EliminarArchivo(int rowIndex)
        {
            dtgArchivosCargados.Rows.RemoveAt(rowIndex);
            webBrowser.Navigate("about:blank");
            PanelContenedorVisualizador.Visible = false;
            ArchivosActualizados?.Invoke(this, lstArchivosCargados);
        }

        private bool ValidarExtension(string extension)
        {
            return lsExtensionesValidas.Contains(extension.ToLower());
        }

        private byte[] LeerBytesArchivo(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("El archivo seleccionado no existe.");
            }

            return File.ReadAllBytes(filePath);
        }

        #endregion

        #region Métodos Públicos

        #endregion

        #region Eventos

        private void dtgArchivosCargados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dtgArchivosCargados.CurrentCell == null)
                return;

            int viewFile = dtgArchivosCargados.Columns["btnViewFile"].Index;
            int viewDelete = cFormularioLlamada == "frmPagoFechaValor" ? dtgArchivosCargados.Columns["btnDeleteFile"].Index : -1;

            if (e.ColumnIndex == viewFile)
            {
                AbrirArchivo(e.RowIndex);
            }
            else if (e.ColumnIndex == viewDelete)
            {
                EliminarArchivo(e.RowIndex);
            }
        }

        #endregion
    }
}