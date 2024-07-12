using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
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

namespace CRE.Presentacion
{
    public partial class frmSeleccionarDocEvalAnterior : frmBase
    {
        #region Variables Globales
        clsCNSeleccionarDocEvalAnterior objCNCargaArchivo = new clsCNSeleccionarDocEvalAnterior();
        public int idSolicitudAnterior = 0;
        public int idSolicitud = 0;
        public int idUsuario = clsVarGlobal.User.idUsuario;
        public int idPerfil = clsVarGlobal.PerfilUsu.idPerfil;
        public int idAgencia = clsVarGlobal.nIdAgencia;
        public bool lCerrar = false;
        public DataTable dtResultado, dtTipoArchivosConfig, dtResultadosFiltrados;
        public int idTipEvalConfig = 0;
        public int nMensaje = 0;
        public List<Tuple<int, string>> listTiposEvaluacion;
        public int nItem = 0;
        #endregion

        public frmSeleccionarDocEvalAnterior()
        {
            InitializeComponent();
        }

        public frmSeleccionarDocEvalAnterior(int _idSolicitudAnterior, int _idSolicitud, List<Tuple<int, string>> _listTiposEvaluacion)
        {
            InitializeComponent();

            idSolicitudAnterior = _idSolicitudAnterior;
            idSolicitud = _idSolicitud;
            listTiposEvaluacion = _listTiposEvaluacion;
        }

        #region Eventos
        private void frmSeleccionarDocEvalAnterior_Load(object sender, EventArgs e)
        {
            nItem = 0;
            OptenerDocEvalAnterior();
        }

        private void frmSeleccionarDocEvalAnterior_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.lCerrar)
            {
                e.Cancel = true;
                return;
            }
        }

        private void btnCancelar1_Click_1(object sender, EventArgs e)
        {
            if(nMensaje == 1)
            {
                this.Close();
                this.Dispose();
            }
            else
            {
                DialogResult cRespuesta = MessageBox.Show("¿Está seguro de que no desea vincular ningún documento a la solicitud?", "Advertencia de validación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (cRespuesta == DialogResult.Yes)
                {
                    this.Close();
                    this.Dispose();
                }
            }
        }

        private void dtgDocumentosEvalAnterior_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void dtgDocumentosEvalAnterior_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int viewFile = dtgDocumentosEvalAnterior.Columns["btnViewFile"].Index;

            if (e.RowIndex == -1)
                return;
            
            try
            {
                if (dtgDocumentosEvalAnterior.CurrentCell.ColumnIndex.Equals(viewFile))
                {
                    int idFormato = (String.IsNullOrEmpty(dtgDocumentosEvalAnterior.Rows[dtgDocumentosEvalAnterior.CurrentCell.RowIndex].Cells["idFormato"].Value.ToString())) ? 1 : Convert.ToInt32(dtgDocumentosEvalAnterior.Rows[dtgDocumentosEvalAnterior.CurrentCell.RowIndex].Cells["idFormato"].Value);

                    if (idFormato == 1 && (dtgDocumentosEvalAnterior.Rows[dtgDocumentosEvalAnterior.CurrentCell.RowIndex].Cells["cExtencion"].Value.ToString() == ".jpg" || dtgDocumentosEvalAnterior.Rows[dtgDocumentosEvalAnterior.CurrentCell.RowIndex].Cells["cExtencion"].Value.ToString() == ".png"))
                    {
                        panelImg.Visible = true;
                        panelPdf.Visible = false;
                        byte[] picture = Convert.FromBase64String(dtgDocumentosEvalAnterior.Rows[dtgDocumentosEvalAnterior.CurrentCell.RowIndex].Cells["cArchivo"].Value.ToString());
                        pictureBox1.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(picture));
                    }
                    else
                    {
                        panelPdf.Visible = true;
                        panelImg.Visible = false;
                        byte[] bits;
                        byte[] bArchivoBinary;

                        if (String.IsNullOrEmpty(dtgDocumentosEvalAnterior.Rows[dtgDocumentosEvalAnterior.CurrentCell.RowIndex].Cells["bArchivoBinary"].Value.ToString()))
                        {
                            if (String.IsNullOrEmpty(dtgDocumentosEvalAnterior.Rows[dtgDocumentosEvalAnterior.CurrentCell.RowIndex].Cells["cArchivo"].Value.ToString()))
                            {
                                MessageBox.Show("Documento invalido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            else
                            {
                                string str = dtgDocumentosEvalAnterior.Rows[dtgDocumentosEvalAnterior.CurrentCell.RowIndex].Cells["cArchivo"].Value.ToString();
                                bits = Convert.FromBase64String(str);
                            }
                        }
                        else
                        {
                            bArchivoBinary = (byte[])dtgDocumentosEvalAnterior.Rows[dtgDocumentosEvalAnterior.CurrentCell.RowIndex].Cells["bArchivoBinary"].Value;
                            bits = Compresion.DescompressedByte(bArchivoBinary);
                        }

                        string sFile = dtgDocumentosEvalAnterior.Rows[dtgDocumentosEvalAnterior.CurrentCell.RowIndex].Cells["cNombreArchivo"].Value.ToString() + "-" + clsVarGlobal.User.idUsuario.ToString();

                        string ruta = Directory.GetCurrentDirectory() + "\\documentosTmp";

                        if (!Directory.Exists(ruta))
                        {
                            DirectoryInfo di = Directory.CreateDirectory(ruta);
                        }

                        FileStream fs = new FileStream("documentosTmp\\" + sFile, FileMode.Create);
                        fs.Write(bits, 0, Convert.ToInt32(bits.Length));
                        fs.Close();

                        ruta = ruta + "\\" + sFile;
                        contPdf.src = ruta;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAceptar1_Click_1(object sender, EventArgs e)
        {
            if (ValidarSeleccionCheckBoxDatos())
            {
                string xmlArchivos = ConvertirDatosDataGridViewAXml();
                DataTable dtRespuesta = objCNCargaArchivo.CNVicularDocumentos(idSolicitud, idSolicitudAnterior, idUsuario, idPerfil, idAgencia, idTipEvalConfig, xmlArchivos);

                MessageBox.Show(dtRespuesta.Rows[0]["cMensaje"].ToString(), "Respuesta", MessageBoxButtons.OK, ((int)dtRespuesta.Rows[0]["idError"] == 0 ? MessageBoxIcon.Exclamation : MessageBoxIcon.Information));

                lCerrar = true;
                this.Close();
            }
        }

        private void dtgDocumentosEvalAnterior_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgDocumentosEvalAnterior.Columns["dgTipoArchivo"].Index)
            {
                ActualizaDatosTipoArchivo(e.RowIndex, e.ColumnIndex);
            }
        }

        private void ActualizaDatosTipoArchivo(int rowIndex, int columnIndex)
        {
            this.dtgDocumentosEvalAnterior.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDocumentosEvalAnterior_CellValueChanged);

            if (columnIndex == dtgDocumentosEvalAnterior.Columns["dgTipoArchivo"].Index)
            {
                DataGridViewComboBoxCell comboBoxCell = dtgDocumentosEvalAnterior.Rows[rowIndex].Cells["dgTipoArchivo"] as DataGridViewComboBoxCell;

                if (comboBoxCell != null && comboBoxCell.Value != null)
                {
                    string cValorSeleccionado = comboBoxCell.Value.ToString();
                    string cNombreArchivo = comboBoxCell.FormattedValue.ToString();

                    for (int i = 0; i < dtgDocumentosEvalAnterior.Rows.Count; i++)
                    {
                        if (i != rowIndex)
                        {
                            DataGridViewComboBoxCell otherComboBoxCell = dtgDocumentosEvalAnterior.Rows[i].Cells["dgTipoArchivo"] as DataGridViewComboBoxCell;
                            if (otherComboBoxCell != null && otherComboBoxCell.Value != null)
                            {
                                string valorCelda = otherComboBoxCell.Value.ToString();
                                if (cValorSeleccionado == valorCelda)
                                {
                                    MessageBox.Show("El archivo \"" + cNombreArchivo + "\" ya ha sido seleccionado.", "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    comboBoxCell.Value = null;
                                    dtgDocumentosEvalAnterior.Rows[rowIndex].Cells["dgTipoArchivo"].Value = null;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            this.dtgDocumentosEvalAnterior.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDocumentosEvalAnterior_CellValueChanged);
        }

        private void cboTipoEvaluacion_SelectedValueChanged(object sender, EventArgs e)
        {
            nItem = cboTipoEvaluacion.SelectedIndex;
            if (nItem != -1)
            {
                OptenerDocEvalAnterior();
                RestablecerPanel();
            }
        }
        #endregion

        #region Metodos
        private void OptenerDocEvalAnterior()
        {
            clsCNAdministracionFiles clsFiles = new clsCNAdministracionFiles();
            DataSet dtTipoArchivos;
            idTipEvalConfig = listTiposEvaluacion[nItem].Item1;

            dtResultado = objCNCargaArchivo.CNOptenerDocEvalAnterior(idSolicitudAnterior, idSolicitud, idTipEvalConfig);
            AsignarTipoEvalucion();

            if (dtResultado.Rows.Count > 0)
            {
                this.dtgDocumentosEvalAnterior.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDocumentosEvalAnterior_CellValueChanged);

                dtgDocumentosEvalAnterior.DataSource = dtResultado;
                dtTipoArchivos = clsFiles.getTipoGrupoArchivo(idSolicitud, idUsuario);
                dtTipoArchivosConfig = dtTipoArchivos.Tables[0];

                AgregarColumnasDataGridViewDocumentosEvalAnterior();
                ArmardtgDocumentosEvalAnterior();
                ConfigurarComboBoxDataSource();
                LimpiarMensaje();

                this.dtgDocumentosEvalAnterior.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDocumentosEvalAnterior_CellValueChanged);
            }
            else {
                LimpiarDatosDataGridView();
            }
        }

        private void ArmardtgDocumentosEvalAnterior()
        {
            dtgDocumentosEvalAnterior.AutoGenerateColumns = false;

            foreach (DataGridViewColumn columna in dtgDocumentosEvalAnterior.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                columna.Visible = false;
            }

            dtgDocumentosEvalAnterior.Columns["nNumeroFila"].Visible = true;
            dtgDocumentosEvalAnterior.Columns["idSolicitud"].Visible = true;
            dtgDocumentosEvalAnterior.Columns["cNombreArchivo"].Visible = true;
            dtgDocumentosEvalAnterior.Columns["dgTipoArchivo"].Visible = true;
            dtgDocumentosEvalAnterior.Columns["btnViewFile"].Visible = true;
            dtgDocumentosEvalAnterior.Columns["lSeleccion"].Visible = true;

            dtgDocumentosEvalAnterior.Columns["nNumeroFila"].HeaderText = "N°";
            dtgDocumentosEvalAnterior.Columns["idSolicitud"].HeaderText = "Solicitud";
            dtgDocumentosEvalAnterior.Columns["cNombreArchivo"].HeaderText = "Nombre del documento";
            dtgDocumentosEvalAnterior.Columns["dgTipoArchivo"].HeaderText = "Tipo de archivo";
            dtgDocumentosEvalAnterior.Columns["btnViewFile"].HeaderText = "Ver";
            dtgDocumentosEvalAnterior.Columns["lSeleccion"].HeaderText = "Seleccionar";

            dtgDocumentosEvalAnterior.Columns["nNumeroFila"].Width = 30;
            dtgDocumentosEvalAnterior.Columns["idSolicitud"].Width = 60;
            dtgDocumentosEvalAnterior.Columns["cNombreArchivo"].Width = 250;
            dtgDocumentosEvalAnterior.Columns["dgTipoArchivo"].Width = 250;
            dtgDocumentosEvalAnterior.Columns["btnViewFile"].Width = 50;
            dtgDocumentosEvalAnterior.Columns["lSeleccion"].Width = 80;

            dtgDocumentosEvalAnterior.Columns["nNumeroFila"].ReadOnly = true;
            dtgDocumentosEvalAnterior.Columns["idSolicitud"].ReadOnly = true;
            dtgDocumentosEvalAnterior.Columns["cNombreArchivo"].ReadOnly = true;
            dtgDocumentosEvalAnterior.Columns["dgTipoArchivo"].ReadOnly = false;
            dtgDocumentosEvalAnterior.Columns["btnViewFile"].ReadOnly = false;
            dtgDocumentosEvalAnterior.Columns["lSeleccion"].ReadOnly = false;
        }

        private void AgregarColumnasDataGridViewDocumentosEvalAnterior()
        {
            DataGridViewTextBoxColumn numeroFilaColumna = new DataGridViewTextBoxColumn();
            {
                numeroFilaColumna.Name = "nNumeroFila";
                numeroFilaColumna.SortMode = DataGridViewColumnSortMode.NotSortable;
                dtgDocumentosEvalAnterior.Columns.Insert(0, numeroFilaColumna);
            };
            ColumanNumeroFila();

            DataGridViewComboBoxColumn dgTipoArchivo = new DataGridViewComboBoxColumn();
            {
                dgTipoArchivo.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                dgTipoArchivo.Name = "dgTipoArchivo";
                dgTipoArchivo.DataPropertyName = "idArchivoForeing";
                dgTipoArchivo.DataSource = dtTipoArchivosConfig;
                dgTipoArchivo.DisplayMember = "cTipoArchivo";
                dgTipoArchivo.ValueMember = "idTipoArchivo";
                dtgDocumentosEvalAnterior.Columns.Add(dgTipoArchivo);
            };

            DataGridViewButtonColumn btnView = new DataGridViewButtonColumn();
            {
                btnView.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnView.FlatStyle = FlatStyle.Standard;
                btnView.CellTemplate.Style.BackColor = Color.Honeydew;
                btnView.DefaultCellStyle.BackColor = Color.LightGray;
                btnView.Name = "btnViewFile";
                btnView.Text = "Ver";
                btnView.UseColumnTextForButtonValue = true;
                dtgDocumentosEvalAnterior.Columns.Add(btnView);
            };

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            {
                checkBoxColumn.Name = "lSeleccion";
                checkBoxColumn.HeaderText = "Seleccionar";
                checkBoxColumn.TrueValue = true;
                checkBoxColumn.FalseValue = false;
                dtgDocumentosEvalAnterior.Columns.Add(checkBoxColumn);
            };
            MarcarCheckSiVisitaObligatorio();
        }

        private void ConfigurarComboBoxDataSource()
        {
            dtResultadosFiltrados = dtResultado.AsEnumerable()
                .GroupBy(row => row.Field<int?>("idArchivoForeing"))
                .Where(group => group.First().Field<string>("cTipoArchivo") == "Predeterminado")
                .Select(group => new
                {
                    idArchivoForeing = group.Key ?? 0,
                    cTipoArchivo = group.First().Field<string>("cTipoArchivo"),
                    idArchivos = group.First().Field<int>("idArchivos")
                })
                .ToDataTable();
        }

        private void ColumanNumeroFila()
        {
            for (int i = 0; i < dtgDocumentosEvalAnterior.Rows.Count; i++)
            {
                dtgDocumentosEvalAnterior["nNumeroFila", i].Value = (i + 1).ToString();
            }
        }

        private bool ValidarSeleccionCheckBoxDatos()
        {
            bool lHaySeleccion = false;
            bool lHayError = false;

            foreach (DataGridViewRow fila in dtgDocumentosEvalAnterior.Rows)
            {
                bool lSeleccionado = Convert.ToBoolean(fila.Cells["lSeleccion"].Value);
                string cNombreArchivo = Convert.ToString(fila.Cells["cNombreArchivo"].Value);
                int idArchivoForeing = String.IsNullOrEmpty(fila.Cells["idArchivoForeing"].Value.ToString()) ? 0 : Convert.ToInt32(fila.Cells["idArchivoForeing"].Value);

                if (lSeleccionado)
                {
                    lHaySeleccion = true;

                    bool lResultado = dtTipoArchivosConfig.AsEnumerable().Any(item => item.Field<int>("idTipoArchivo") == idArchivoForeing);

                    if (!lResultado && idArchivoForeing != 0)
                    {
                        MessageBox.Show(string.Format("Debe seleccionar un tipo de archivo para {0}.", cNombreArchivo), "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        lHayError = true;
                        break;
                    }

                    foreach (DataRow resultadoRow in dtResultadosFiltrados.Rows)
                    {
                        int idArchivoForeingResultado = Convert.ToInt32(resultadoRow["idArchivoForeing"]);
                        object value = fila.Cells["dgTipoArchivo"].Value;

                        if (idArchivoForeingResultado == idArchivoForeing)
                        {
                            MessageBox.Show(string.Format("Debe seleccionar un tipo de archivo para {0}.", cNombreArchivo), "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            lHayError = true;
                            break;
                        }
                    }
                }
            }

            if (!lHaySeleccion)
            {
                MessageBox.Show("Asegúrese de seleccionar los documentos necesarios para la solicitud.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lHayError = true;
            }

            return !lHayError;
        }

        private int ContarFilasConCampoNumero()
        {
            int nContador = 0;

            foreach (DataGridViewRow fila in dtgDocumentosEvalAnterior.Rows)
            {
                if (fila.Cells["N°"].Value != null && !string.IsNullOrWhiteSpace(fila.Cells["N°"].Value.ToString()))
                {
                    nContador++;
                }
            }

            return nContador;
        }

        private string ConvertirDatosDataGridViewAXml()
        {
            DataTable dtDatos = new DataTable();
            dtDatos.Columns.Add("idArchivos", typeof(int));
            dtDatos.Columns.Add("idVisita", typeof(int));
            dtDatos.Columns.Add("idDetalleVisita", typeof(int));
            dtDatos.Columns.Add("idArchivoForeing", typeof(int));
         
            foreach (DataGridViewRow fila in dtgDocumentosEvalAnterior.Rows)
            {
                if (fila.Cells["lSeleccion"].Value != null && (bool)fila.Cells["lSeleccion"].Value)
                {
                    DataRow row = dtDatos.NewRow();

                    int idArchivos = Convert.ToInt32(fila.Cells["idArchivos"].Value);
                    int idVisita = (String.IsNullOrEmpty((fila.Cells["idVisita"].Value.ToString())) ? 0 : Convert.ToInt32(fila.Cells["idVisita"].Value));
                    int idDetalleVisita = (String.IsNullOrEmpty((fila.Cells["idDetalleVisita"].Value.ToString())) ? 0 : Convert.ToInt32(fila.Cells["idDetalleVisita"].Value));
                    int idArchivoForeing = (String.IsNullOrEmpty((fila.Cells["idArchivoForeing"].Value.ToString())) ? 0 : Convert.ToInt32(fila.Cells["idArchivoForeing"].Value));

                    row["idArchivos"] = idArchivos;
                    row["idVisita"] = idVisita;
                    row["idDetalleVisita"] = idDetalleVisita;
                    row["idArchivoForeing"] = idArchivoForeing;
                    
                    dtDatos.Rows.Add(row);
                }
            }
            DataSet dsDatos = new DataSet("dsDatos");
            dsDatos.Tables.Add(dtDatos);
            string xmlDatos = dsDatos.GetXml();
            xmlDatos = clsCNFormatoXML.EncodingXML(xmlDatos);

            return xmlDatos;
        }

        private void MarcarCheckSiVisitaObligatorio()
        {
            foreach (DataGridViewRow row in dtgDocumentosEvalAnterior.Rows)
            {
                object visitaValue = row.Cells["idVisita"].Value;
                object dgTipoArchivo = row.Cells["dgTipoArchivo"].Value;

                if (visitaValue != DBNull.Value && visitaValue != null)
                {
                    DataGridViewCheckBoxCell chkCell = (DataGridViewCheckBoxCell)row.Cells["lSeleccion"];
                    DataGridViewComboBoxCell comboBoxCell = (DataGridViewComboBoxCell)row.Cells["dgTipoArchivo"];
                    if (chkCell != null && comboBoxCell != null)
                    {
                        chkCell.Value = true;
                        chkCell.ReadOnly = true;
                        comboBoxCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        comboBoxCell.ReadOnly = true;

                        row.ReadOnly = true;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            cell.ReadOnly = true;
                        }
                    }
                }
            }
        }

        private void AsignarTipoEvalucion()
        {
            cboTipoEvaluacion.DisplayMember = "Item2";
            cboTipoEvaluacion.ValueMember = "Item1";

            cboTipoEvaluacion.DataSource = listTiposEvaluacion;
        }

        private void LimpiarMensaje()
        {
            lblAlerta.Visible = false;
            btnAceptar1.Enabled = true;
        }

        private void LimpiarDatosDataGridView()
        {
            dtgDocumentosEvalAnterior.DataSource = null;
            dtgDocumentosEvalAnterior.Rows.Clear();
            
            lblAlerta.Visible = true;
            btnAceptar1.Enabled = false;
            nMensaje = 1;
        }

        private void RestablecerPanel() 
        {
            pictureBox1.Image = null;
            contPdf.src = "";
            panelPdf.Visible = false;
            panelImg.Visible = false;
        }
        #endregion
    }
}
