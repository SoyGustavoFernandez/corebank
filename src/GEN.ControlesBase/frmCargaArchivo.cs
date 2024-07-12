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
using GEN.BotonesBase;
using EntityLayer;
using GEN.Funciones;
using System.Diagnostics;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GEN.ControlesBase
{
    public partial class frmCargaArchivo : frmBase
    {
        #region Variables
        public int idSolicitud;
        public int idCuenta;
        bool readOnly;
        private int idCargo = clsVarGlobal.User.idCargo;
        private CRE.CapaNegocio.clsCNAdministracionFiles clsFiles = new CRE.CapaNegocio.clsCNAdministracionFiles();
        private CRE.CapaNegocio.clsCNCargaArchivo objCNCargaArchivo = new CRE.CapaNegocio.clsCNCargaArchivo();
        private List<string> fileVistos = new List<string>();
        private DataTable dtGrupoArchivo;
        private int idPagareCredito = 0;
        private int idEstadoSolicitud = 0;
        private int idTipoPersona = 1;
        private bool lPeticionSustento = false;
        private bool lChecklist = false;
        private bool lChecklistMenu = false;
        private int idDescTipoDoc_ = 0;
        private int idTipoSolicitudObs;
        private bool lGruposSolidario = false;
        private List<clsSustentoArchivoPagare> lstSustentoVinculacionArchivo = new List<clsSustentoArchivoPagare>();
        private List<int> lstTipoArchivoEscaneadoSustento = new List<int>();

        private bool lSuperaExposicion = false;

        public String politPriv;
        public int idCli;
        public bool lTasa = false;
        public bool lTasaPost = false;
        public bool lverTasaPost = false;
        public string cTipoArchivo;

        #endregion

        #region Metodos
        public frmCargaArchivo()
        {
            InitializeComponent();
        }

        public frmCargaArchivo(int idSolicitud_, bool lectura)
        {
            InitializeComponent();
            readOnly = lectura;

            idSolicitud = idSolicitud_;

            DataTable dtEstadoSolicitud = clsFiles.obtenerDatosSolicitud(idSolicitud);
            if (dtEstadoSolicitud.Rows.Count > 0)
            {
                idEstadoSolicitud = Convert.ToInt32(dtEstadoSolicitud.Rows[0]["idEstado"]);
                idPagareCredito = Convert.ToInt32(dtEstadoSolicitud.Rows[0]["idPagareCredito"]);
                idTipoPersona = Convert.ToInt32(dtEstadoSolicitud.Rows[0]["IdTipoPersona"]);
                lSuperaExposicion = Convert.ToBoolean(dtEstadoSolicitud.Rows[0]["lSuperaMontoExposicion"]);
            }

            lstTipoArchivoEscaneadoSustento = objCNCargaArchivo.CNObtenerListaSustentoTipoArchivo();

        }
        public frmCargaArchivo(int idcliente, bool lectura, String PoliticaPrivacidad)
        {
            InitializeComponent();
            readOnly = lectura;

            politPriv = PoliticaPrivacidad;
            this.idCli = idcliente;

            /*idSolicitud = idSolicitud_;

            DataTable dtEstadoSolicitud = clsFiles.obtenerDatosSolicitud(idSolicitud);
            if (dtEstadoSolicitud.Rows.Count > 0)
            {
                idEstadoSolicitud = Convert.ToInt32(dtEstadoSolicitud.Rows[0]["idEstado"]);
                idPagareCredito = Convert.ToInt32(dtEstadoSolicitud.Rows[0]["idPagareCredito"]);
                idTipoPersona = Convert.ToInt32(dtEstadoSolicitud.Rows[0]["IdTipoPersona"]);
                lSuperaExposicion = Convert.ToBoolean(dtEstadoSolicitud.Rows[0]["lSuperaMontoExposicion"]);
            }
            */
            //lstTipoArchivoEscaneadoSustento = objCNCargaArchivo.CNObtenerListaSustentoTipoArchivo();
            lstTipoArchivoEscaneadoSustento.Add(20);

        }

        public frmCargaArchivo(int idSolicitud_, bool lectura, bool lChecklist_ = false, bool lGruposSolidario_ = false, bool lChecklistMenu_ = false)
        {
            InitializeComponent();
            readOnly = lectura;
            idSolicitud = idSolicitud_;
            lChecklist = lChecklist_;
            lGruposSolidario = lGruposSolidario_;
            lChecklistMenu = lChecklistMenu_;

            DataTable dtEstadoSolicitud = clsFiles.obtenerDatosSolicitud(idSolicitud);
            if (dtEstadoSolicitud.Rows.Count > 0)
            {
                idEstadoSolicitud = Convert.ToInt32(dtEstadoSolicitud.Rows[0]["idEstado"]);
                idPagareCredito = Convert.ToInt32(dtEstadoSolicitud.Rows[0]["idPagareCredito"]);
                idTipoPersona = Convert.ToInt32(dtEstadoSolicitud.Rows[0]["IdTipoPersona"]);
                lSuperaExposicion = Convert.ToBoolean(dtEstadoSolicitud.Rows[0]["lSuperaMontoExposicion"]);
            }

            lstTipoArchivoEscaneadoSustento = objCNCargaArchivo.CNObtenerListaSustentoTipoArchivo();
        }

        private DataTable filtarGrupoArchivo()
        {
            DataTable dtgGrupoFiltrado = new DataTable();


            dtgGrupoFiltrado.Columns.Add("idDescTipoDoc", typeof(int));
            dtgGrupoFiltrado.Columns.Add("cDescTipoDoc", typeof(string));

            foreach (DataRow dtRow in dtGrupoArchivo.Rows)
            {
                DataRow[] dtr = dtgGrupoFiltrado.Select("idDescTipoDoc=" + dtRow["idDescTipoDoc"]);

                if (dtr.Length == 0)
                {
                    DataRow row = dtgGrupoFiltrado.NewRow();
                    row["idDescTipoDoc"] = dtRow["idDescTipoDoc"];
                    row["cDescTipoDoc"] = dtRow["cDescTipoDoc"];
                    dtgGrupoFiltrado.Rows.Add(row);
                }
            }
            return dtgGrupoFiltrado;
        }

        //private void filtrarArchivos(int idDescTipoDoc)
        //{
        //    foreach (DataGridViewRow row in dtgFiles.Rows)
        //    {
        //        dtgFiles.CurrentCell = null;
        //        row.Visible = false;
        //    }

        //    if (idDescTipoDoc != 0)
        //    {
        //        foreach (DataGridViewRow row in dtgFiles.Rows)
        //        {
        //            if (Convert.ToInt32(row.Cells["idDescTipoDoc"].Value) == idDescTipoDoc)
        //            {
        //                row.Visible = true;
        //            }
        //        }
        //    }
        //}

        private void formatearDTG(bool lInicio)
        {
            foreach (DataGridViewColumn column in dtgFiles.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (dtgFiles.IsCurrentCellDirty)
            {
                dtgFiles.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            dtgFiles.Columns["cDescTipoDoc"].HeaderText = "Grupo de Archivos/Expedientes";
            dtgFiles.Columns["cTipoArchivo"].HeaderText = "Archivo/Expediente";
            dtgFiles.Columns["cArchivo"].HeaderText = "Nombre del Archivo";
            dtgFiles.Columns["lObligatorio"].HeaderText = "Obligatorio";

            dtgFiles.Columns["cDescTipoDoc"].FillWeight = 45;
            dtgFiles.Columns["cTipoArchivo"].FillWeight = 45;
            dtgFiles.Columns["cArchivo"].FillWeight = 45;
            dtgFiles.Columns["lObligatorio"].FillWeight = 11;

            dtgFiles.Columns["cDescTipoDoc"].Visible = true;
            dtgFiles.Columns["cTipoArchivo"].Visible = true;
            dtgFiles.Columns["cArchivo"].Visible = true;
            dtgFiles.Columns["lObligatorio"].Visible = true;

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
                dtgFiles.Columns.Add(btnAdd);
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
                dtgFiles.Columns.Add(btnRemove);
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
                dtgFiles.Columns.Add(btnView);
            }
            dtgFiles.Columns["cDescTipoDoc"].DisplayIndex = 0;

            dtgFiles.Columns["cTipoArchivo"].DisplayIndex = 1;
            dtgFiles.Columns["cArchivo"].DisplayIndex = 2;
            dtgFiles.Columns["lObligatorio"].DisplayIndex = 6;
            dtgFiles.Columns["btnAddFile"].DisplayIndex = 7;
            dtgFiles.Columns["btnDeleteFile"].DisplayIndex = 8;
            dtgFiles.Columns["btnViewFile"].DisplayIndex = 9;

            if (lChecklist == true)
            {
                dtgFiles.Columns["lVistoBueno"].HeaderText = "Visto Bueno";
                dtgFiles.Columns["lObservado"].HeaderText = "Observado";
                dtgFiles.Columns["lAbsuelto"].HeaderText = "Absuelto";

                dtgFiles.Columns["lVistoBueno"].FillWeight = 14;
                dtgFiles.Columns["lObservado"].FillWeight = 14;
                dtgFiles.Columns["lAbsuelto"].FillWeight = 11;

                this.dtgFiles.Columns["lVistoBueno"].Visible = true;
                this.dtgFiles.Columns["lObservado"].Visible = true;
                this.dtgFiles.Columns["lAbsuelto"].Visible = true;
                this.dtgFiles.Columns["lObligatorio"].Visible = false;
                this.dtgFiles.Columns["btnAddFile"].Visible = false;
                this.dtgFiles.Columns["btnDeleteFile"].Visible = false;

                if (VerificarPerfilAbsuelveChecklist()) // Asesor
                {
                    this.dtgFiles.Columns["btnAddFile"].Visible = true;
                    this.dtgFiles.Columns["btnDeleteFile"].Visible = true;
                    btnGrabar2.Visible = true;
                }

                dtgFiles.Columns["lvistobueno"].DisplayIndex = 3;
                dtgFiles.Columns["lObservado"].DisplayIndex = 4;
                dtgFiles.Columns["lAbsuelto"].DisplayIndex = 5;

                if (!lChecklistMenu)
                {
                    this.dtgFiles.Columns["lAbsuelto"].Visible = false;
                }
            }
            if (lverTasaPost == true)
            {
                this.dtgFiles.Columns["btnAddFile"].Visible = false;
                this.dtgFiles.Columns["btnDeleteFile"].Visible = false;
            }
        }
        private bool verificarEnvios()
        {
            for (int i = 0; i < dtgFiles.Rows.Count; i++)
            {
                if (dtgFiles.Rows[i].Cells["bArchivoBinary"].Value.ToString() != "" && !Convert.ToBoolean(dtgFiles.Rows[i].Cells["lInsertado"].Value))
                    return false;
            }

            return true;
        }
        #endregion

        #region Eventos
        private void cboGrupoArchivo_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (this.cboGrupoArchivo.SelectedValue.ToString() != "")
            //{
            //   // filtrarArchivos(Convert.ToInt32(this.cboGrupoArchivo.SelectedValue.ToString()));
            //}
        }

        private void dtgFiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panelFile.Visible = false;
            int addFile = dtgFiles.Columns["btnAddFile"].Index;
            int deleteFile = dtgFiles.Columns["btnDeleteFile"].Index;
            int viewFile = dtgFiles.Columns["btnViewFile"].Index;
            int vistobueno = 0;
            int observado = 0;
            int absuelto = 0;
            if (lChecklist == true)
            {
                vistobueno = dtgFiles.Columns["lvistobueno"].Index;
                observado = dtgFiles.Columns["lobservado"].Index;
                absuelto = dtgFiles.Columns["labsuelto"].Index;
            }
            if (dtgFiles.CurrentCell == null)
                return;

            int idAccionVinculacion = 0;
            bool lInsertado = Convert.ToBoolean(dtgFiles.CurrentRow.Cells["lInsertado"].Value);
            string cArchivoNombre = Convert.ToString(dtgFiles.CurrentRow.Cells["cArchivo"].Value);

            cTipoArchivo = Convert.ToString(dtgFiles.CurrentRow.Cells["cTipoArchivo"].Value);

            if (lGruposSolidario)
            {
                idTipoSolicitudObs = 2; //Grupo
            }
            else
            {
                idTipoSolicitudObs = 1; //Individual
            }

            if (dtgFiles.CurrentCell.ColumnIndex.Equals(addFile))
            {
                if (!lInsertado || (lInsertado && !String.IsNullOrWhiteSpace(cArchivoNombre)))
                {
                    idAccionVinculacion = 3;
                }
                else
                {
                    idAccionVinculacion = 1;
                }
            }
            else if (dtgFiles.CurrentCell.ColumnIndex.Equals(deleteFile))
            {
                idAccionVinculacion = 2;
            }

            if (!validarSustentoCargaArchivo(idAccionVinculacion))
                return;

            if (dtgFiles.CurrentCell.ColumnIndex.Equals(addFile))
            {
                if (lChecklist == true)
                {
                    if (Convert.ToInt32(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lVistobueno"].Value) == 1)
                    {
                        MessageBox.Show("No puede cambiar ni quitar el archivo de este documento porque ya dieron Visto Bueno con la opción Checklist.", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        agregarArchivo();
                    }
                }
                else
                {
                    agregarArchivo();
                }

            }
            else if (dtgFiles.CurrentCell.ColumnIndex.Equals(deleteFile))
            {
                if (lChecklist == true)
                {
                    if (Convert.ToInt32(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lVistobueno"].Value) == 1)
                    {
                        MessageBox.Show("No puede cambiar ni quitar el archivo de este documento porque ya dieron Visto Bueno con la opción Checklist.", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        borrarAchivo();
                    }
                }
                else
                {
                    borrarAchivo();
                }
            }

            else if (dtgFiles.CurrentCell.ColumnIndex.Equals(viewFile))
            {
                if (dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cArchivo"].Value.ToString() != "")
                {
                    byte[] bits;
                    if (dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cExtension"].Value.ToString() == "")
                    {
                        DataTable res = clsFiles.CNObtenerArchivoEscaneado(idSolicitud, Convert.ToInt32(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["idTipoArchivo"].Value));

                        dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cExtension"].Value = res.Rows[0]["cExtension"].ToString();
                        dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["bArchivoBinary"].Value = (byte[])res.Rows[0]["bArchivoBinary"];
                    }
                    bits = Compresion.DescompressedByte((byte[])dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["bArchivoBinary"].Value);

                    string sFile = dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cArchivo"].Value.ToString() +
                                    "-" + clsVarGlobal.User.idUsuario.ToString() +
                                    dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cExtension"].Value.ToString()
                                    ;
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
                    panelFile.Visible = true;

                    int i = 0;
                    for (i = 0; i < fileVistos.Count(); i++)
                    {
                        if (fileVistos[i] == ruta.ToString())
                            break;
                    }
                    if (fileVistos.Count() == i)
                        fileVistos.Add(ruta.ToString());
                }
                else
                {
                    panelFile.Visible = false;
                    MessageBox.Show("No se cargó ningun Archivo", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            if (lChecklist == true)
            {
                if (dtgFiles.CurrentCell.ColumnIndex.Equals(vistobueno))
                {
                    if (VerificarPerfilVBObservaChecklist()) // RSC || COORDINADOR DE OPERACIONES
                    {
                        if (Convert.ToInt32(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lVistobueno"].Value) == 0)
                        {
                            if (Convert.ToInt32(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lObservado"].Value) == 1)
                            {
                                MessageBox.Show("Para cambiar a Visto Bueno, el documento con observación tiene que estar absuelto por el asesor.", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }

                            else
                            {
                                if (Convert.ToInt32(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lObligatorio"].Value) == 1)
                                {
                                    if (dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cArchivo"].Value != DBNull.Value)
                                    {
                                        vistoBueno();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Para dar Visto Bueno primero debe registrar un archivo.", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                                else
                                {
                                    vistoBueno();
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Ya dieron Visto Bueno a este documento.", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }
                    else
                    {
                        MessageBox.Show("El perfil actual no tiene permiso para dar Visto Bueno. Comuníquese con el Representante de Servicio al Cliente.", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }

                else if (dtgFiles.CurrentCell.ColumnIndex.Equals(observado))
                {
                    if (VerificarPerfilVBObservaChecklist()) // RSC || COORDINADOR DE OPERACIONES
                    {
                        bool lAbsuelto = Convert.ToBoolean(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lAbsuelto"].Value is DBNull ? 0 : dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lAbsuelto"].Value);
                        frmRegistroDocumentoObs frmRegistroDocumentosObs = new frmRegistroDocumentoObs(clsVarGlobal.User.idUsuario,
                                                                                                        idSolicitud,
                                                                                                        idTipoSolicitudObs,
                                                                                                        Convert.ToInt32(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["idTipoArchivo"].Value),
                                                                                                        clsVarGlobal.User.idEstablecimiento,
                                                                                                        lAbsuelto
                                                                                                        );
                        frmRegistroDocumentosObs.ShowDialog();
                        //idDescTipoDoc_ = Convert.ToInt32(cboGrupoArchivo.SelectedValue);
                        cargardatos(false);
                    }
                    else
                    {
                        if (dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lVistobueno"].Value == DBNull.Value || Convert.ToInt32(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lVistobueno"].Value) == 0)
                        {
                            bool lAbsuelto = Convert.ToBoolean(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lAbsuelto"].Value is DBNull ? 0 : dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lAbsuelto"].Value);
                            frmRegistroDocumentoObs frmRegistroDocumentosObs = new frmRegistroDocumentoObs(clsVarGlobal.User.idUsuario,
                                                                                                            idSolicitud,
                                                                                                            idTipoSolicitudObs,
                                                                                                            Convert.ToInt32(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["idTipoArchivo"].Value),
                                                                                                            clsVarGlobal.User.idEstablecimiento,
                                                                                                            lAbsuelto
                                                                                                            );
                            frmRegistroDocumentosObs.ShowDialog();
                            //idDescTipoDoc_ = Convert.ToInt32(cboGrupoArchivo.SelectedValue);
                            cargardatos(false);
                        }
                        else
                        {
                            MessageBox.Show("Ya dieron Visto Bueno a este documento.", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }

                else if (dtgFiles.CurrentCell.ColumnIndex.Equals(absuelto))
                {
                    if (VerificarPerfilVBObservaChecklist()) // RSC || COORDINADOR DE OPERACIONES
                    {

                        bool lAbsuelto = Convert.ToBoolean(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lAbsuelto"].Value is DBNull ? 0 : dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lAbsuelto"].Value);

                        if (lAbsuelto)
                        {
                            frmRegistroDocumentoObs frmRegistroDocumentosObs = new frmRegistroDocumentoObs(clsVarGlobal.User.idUsuario,
                                                                                                                idSolicitud,
                                                                                                                idTipoSolicitudObs,
                                                                                                                Convert.ToInt32(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["idTipoArchivo"].Value),
                                                                                                                clsVarGlobal.User.idEstablecimiento,
                                                                                                                lAbsuelto
                                                                                                                );
                            frmRegistroDocumentosObs.ShowDialog();
                            //idDescTipoDoc_ = Convert.ToInt32(cboGrupoArchivo.SelectedValue);
                            cargardatos(false);
                        }
                        else
                        {
                            if (dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lVistobueno"].Value == DBNull.Value || Convert.ToInt32(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lVistobueno"].Value) == 0)
                            {
                                if (dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lObservado"].Value == DBNull.Value || Convert.ToInt32(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lObservado"].Value) == 0)
                                {
                                    MessageBox.Show("El documento seleccionado aún no ha sido revisado.", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    MessageBox.Show("El Asesor de Negocios aún no ha completado con el Descargo para absolver la observación.", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }

                            }
                            else
                            {
                                MessageBox.Show("Ya dieron Visto Bueno a este documento.", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                    else
                    {
                        if (dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lVistobueno"].Value == DBNull.Value || Convert.ToInt32(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lVistobueno"].Value) == 0)
                        {
                            bool lAbsuelto = Convert.ToBoolean(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lAbsuelto"].Value is DBNull ? 0 : dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lAbsuelto"].Value);
                            frmRegistroDocumentoObs frmRegistroDocumentosObs = new frmRegistroDocumentoObs(clsVarGlobal.User.idUsuario,
                                                                                                                idSolicitud,
                                                                                                                idTipoSolicitudObs,
                                                                                                                Convert.ToInt32(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["idTipoArchivo"].Value),
                                                                                                                clsVarGlobal.User.idEstablecimiento,
                                                                                                                lAbsuelto
                                                                                                                );
                            frmRegistroDocumentosObs.ShowDialog();
                            //idDescTipoDoc_ = Convert.ToInt32(cboGrupoArchivo.SelectedValue);
                            cargardatos(false);
                        }
                        else
                        {
                            MessageBox.Show("Ya dieron Visto Bueno a este documento.", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }

            }

        }

        private void btnGrabar2_Click(object sender, EventArgs e)
        {
            bool lCambios = false;
            for (int i = 0; i < dtgFiles.Rows.Count; i++)
            {
                if (!Convert.ToBoolean(dtgFiles.Rows[i].Cells["lInsertado"].Value))
                {
                    lCambios = true;
                }
            }

            //if (cboGrupoArchivo.SelectedIndex == -1)
            //{
            //    MessageBox.Show("No se ha seleccionado un Grupo de Archivos/Expedientes", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            if (!lCambios)
            {
                MessageBox.Show("No se encontraron cambios para ser Guardados", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            for (int i = 0; i < dtgFiles.Rows.Count; i++)
            {
                if (!Convert.ToBoolean(dtgFiles.Rows[i].Cells["lInsertado"].Value))
                {
                    DataTable res = new DataTable();

                    if (politPriv == "Política Privacidad")
                    {
                        res = clsFiles.cargarArchivoPolPriv(
                        idSolicitud,
                        Convert.ToInt32(dtgFiles.Rows[i].Cells["idDescTipoDoc"].Value),
                        Convert.ToInt32(dtgFiles.Rows[i].Cells["idTipoArchivo"].Value),
                        dtgFiles.Rows[i].Cells["cArchivo"].Value.ToString(),
                        (byte[])dtgFiles.Rows[i].Cells["bArchivoBinary"].Value,
                        dtgFiles.Rows[i].Cells["cExtension"].Value.ToString(),
                        clsVarGlobal.User.idUsuario,
                        idCli);
                    }
                    else
                    {
                        res = clsFiles.cargarArchivo(
                        idSolicitud,
                        Convert.ToInt32(dtgFiles.Rows[i].Cells["idDescTipoDoc"].Value),
                        Convert.ToInt32(dtgFiles.Rows[i].Cells["idTipoArchivo"].Value),
                        dtgFiles.Rows[i].Cells["cArchivo"].Value.ToString(),
                        (byte[])dtgFiles.Rows[i].Cells["bArchivoBinary"].Value,
                        dtgFiles.Rows[i].Cells["cExtension"].Value.ToString(),
                        clsVarGlobal.User.idUsuario);
                    }
                    if (res.Rows.Count > 0)
                        dtgFiles.Rows[i].Cells["lInsertado"].Value = res.Rows[0]["idEstado"];
                    else dtgFiles.Rows[i].Cells["lInsertado"].Value = 0;

                    int idTipoArchivoEscaneado = Convert.ToInt32(dtgFiles.Rows[i].Cells["idTipoArchivo"].Value);
                    if (res.Rows.Count > 0 && lstTipoArchivoEscaneadoSustento.Contains(idTipoArchivoEscaneado))
                    {
                        clsSustentoArchivoPagare objSustentoArchivoPagare = lstSustentoVinculacionArchivo.Find(item => item.idSolicitud == idSolicitud && item.idTipoArchivo == idTipoArchivoEscaneado);
                        objSustentoArchivoPagare = (objSustentoArchivoPagare == null) ? new clsSustentoArchivoPagare() : objSustentoArchivoPagare;
                        string xmlSustentoVinculacionArchivo = objSustentoArchivoPagare.GetXml();

                        DataTable dtResultado = objCNCargaArchivo.CNRegistrarSustentoVinculacionArchivo(xmlSustentoVinculacionArchivo, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);

                        if (dtResultado.Rows.Count > 0)
                        {
                            if (Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) == 0)
                            {
                                MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un al registrar el sustento del archivo cargado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }
            }
            if (verificarEnvios())
            {

                MessageBox.Show("Se registró correctamente los archivos", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Ocurrió un error al subir uno de los archivos, intente de nuevo..", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void frmCargaArchivo_Load(object sender, EventArgs e)
        {
            cargardatos(true);
        }

        private void cargardatos(bool lInicio)
        {
            if (!lInicio)
            {
                dtgFiles.Columns.Clear();
            }
            panelFile.Visible = false;
            txtSolicitud.Text = idSolicitud.ToString();

            //cboGrupoArchivo.SelectedValueChanged -= cboGrupoArchivo_SelectedValueChanged;

            int idUsuarioReg = 0;
            if (!readOnly)
            {
                idUsuarioReg = clsVarGlobal.User.idUsuario;
            }
            DataSet dtRes;
            if (lChecklist)
            {
                btnGrabar2.Visible = false;
                if (lGruposSolidario)
                {
                    //grbBase1.Visible = false;
                    this.lblBase2.Visible = false;
                    this.rbtJuridica.Visible = false;
                    this.rbtNatural.Visible = false;
                }
                dtRes = clsFiles.ObtenerTipoGrupoArchivoCheckList(idSolicitud, lGruposSolidario);
            }
            else
            {
                if (lTasa == false)
                {
                    if (politPriv == "Política Privacidad")
                    { dtRes = clsFiles.getTipoGrupoArchivoCli(idCli); }
                    else { dtRes = clsFiles.getTipoGrupoArchivo(idSolicitud, idUsuarioReg); }
                }
                else 
                {
                    if (lTasaPost == true)
                    {
                        dtRes = clsFiles.CNObtenerTipoGrupoArchivoTasaPost(idSolicitud);
                    }
                    else 
                    {
                        dtRes = clsFiles.CNObtenerTipoGrupoArchivoTasa(idSolicitud);
                    }
                }
            }

            if (dtRes.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron archivos configurados para ser cargados", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (Convert.ToInt32(dtRes.Tables[0].Rows[0]["idEstado"]) == 0 && !readOnly)
            {
                MessageBox.Show(dtRes.Tables[0].Rows[0]["cMsg"].ToString(), "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnGrabar2.Enabled = false;
                //cboGrupoArchivo.Enabled = false;
            }
            else
            {
                DataTable dtGrupoArchivoRes = dtRes.Tables[0];
                foreach (DataColumn column in dtGrupoArchivoRes.Columns)
                {
                    column.ReadOnly = false;
                }
                dtGrupoArchivo = dtGrupoArchivoRes;

                if (dtGrupoArchivo.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtGrupoArchivo.Rows[0]["idTipoPersona"].ToString()) == 1)
                    {
                        rbtNatural.Checked = true;
                        rbtJuridica.Checked = false;
                    }
                    else
                    {
                        rbtNatural.Checked = false;
                        rbtJuridica.Checked = true;
                    }

                    DataTable dtGrupoTmp = filtarGrupoArchivo();
                    if (dtGrupoTmp.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontró una configración para su PERFIL", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        //this.cboGrupoArchivo.DataSource = dtGrupoTmp;
                        //this.cboGrupoArchivo.DisplayMember = "cDescTipoDoc";
                        //this.cboGrupoArchivo.ValueMember = "idDescTipoDoc";
                        //this.cboGrupoArchivo.SelectedIndex = -1;
                        //cboGrupoArchivo.SelectedValueChanged += cboGrupoArchivo_SelectedValueChanged;

                        dtgFiles.DataSource = dtGrupoArchivoRes;
                        formatearDTG(lInicio);
                      //  filtrarArchivos(0);

                        //if (cboGrupoArchivo.Items.Count > 0)
                        //{
                        //    if (lChecklist)
                        //    {
                        //        if (!lInicio)
                        //        {
                        //            cboGrupoArchivo.SelectedValue = idDescTipoDoc_;
                        //        }
                        //        else
                        //        {
                        //            cboGrupoArchivo.SelectedIndex = 0;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        cboGrupoArchivo.SelectedIndex = 0;
                        //    }
                        //}
                    }
                }
            }

        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void frmCargaArchivo_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool lValida = false;
            if (dtgFiles.DataSource == null)
            {
                e.Cancel = lValida;
                return;
            }

            if (((DataTable)dtgFiles.DataSource).Rows.Count > 0)
            {
                e.Cancel = lValida;
                return;
            }

            if (((DataTable)dtgFiles.DataSource).AsEnumerable().Any(item => Convert.ToInt32(Convert.ToInt32(item["idTipoArchivo"])) == 20))
            {
                bool lArchivoCargado = ((DataTable)dtgFiles.DataSource).AsEnumerable().Any(item => (Convert.ToInt32(item["idTipoArchivo"]) == 20 && !String.IsNullOrWhiteSpace(Convert.ToString(item["cArchivo"]))));
                bool lArchivoGrabado = ((DataTable)dtgFiles.DataSource).AsEnumerable().Any(item => (Convert.ToInt32(item["idTipoArchivo"]) == 20 && Convert.ToBoolean(item["lInsertado"])));

                if ((!lArchivoCargado && lArchivoGrabado) && lSuperaExposicion)
                {
                    switch (idEstadoSolicitud)
                    {
                        case 0:
                        case 1:
                        case 13:
                            DialogResult drResultado;
                            drResultado = MessageBox.Show("Aun no ha cargado el Pagaré de Crédito.\n ¿Está seguro de continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            lValida = (drResultado == DialogResult.No) ? true : false;
                            break;
                        default:
                            break;
                    }
                }
            }

            e.Cancel = lValida;
        }

        private void cboGrupoArchivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboGrupoArchivo.SelectedIndex != -1)
            //{

            //}
        }

        private bool validarSustentoCargaArchivo(int idAccionVinculacion)
        {
            clsSustentoArchivoPagare objSustentoArchivo = new clsSustentoArchivoPagare();
            int idDescTipoDoc = 0;
            int idTipoArchivoEscaneado = 0;
            bool lPrimerSustento = true;


            idDescTipoDoc = Convert.ToInt32(dtgFiles.CurrentRow.Cells["idDescTipoDoc"].Value);
            idTipoArchivoEscaneado = Convert.ToInt32(dtgFiles.CurrentRow.Cells["idTipoArchivo"].Value);

            if (idAccionVinculacion.In(1, 2, 3) && lstTipoArchivoEscaneadoSustento.Contains(idTipoArchivoEscaneado))
            {
                DataTable dtSustentoVinculacion = objCNCargaArchivo.CNVerificarSustentoVinculacionArchivo(idSolicitud, idTipoArchivoEscaneado);
                DataTable dtDatosPagare = objCNCargaArchivo.CNVerificarCargaArchivoSolicitud(idSolicitud, idTipoArchivoEscaneado, idDescTipoDoc);
                DataTable dtVinculacionPagare = objCNCargaArchivo.CNVerificarVinculacionPagare(idSolicitud);
                lPrimerSustento = (dtSustentoVinculacion.Rows.Count > 0) ? false : true;

                bool lPagareCredito = (Convert.ToInt32(dtVinculacionPagare.Rows[0]["idPagareCredito"]) != 0) ? true : false;
                bool lArchivos = (Convert.ToInt32(dtVinculacionPagare.Rows[0]["idArchivos"]) != 0) ? true : false;
                bool lSustentoVinculacionArchivo = (Convert.ToInt32(dtVinculacionPagare.Rows[0]["idSustentoArchivoPagare"]) != 0) ? true : false;
                int idEstadoVinculacionArchivo = Convert.ToInt32(dtVinculacionPagare.Rows[0]["idEstadoVinculacionArchivo"]);

                if (idAccionVinculacion.In(2, 3) && lPagareCredito && idEstadoSolicitud == 2 && idEstadoVinculacionArchivo == 2)
                {
                    MessageBox.Show("Es necesario registrar el número de pagaré con este archivo, ", "Vinculación de Pagaré de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                if (dtDatosPagare.Rows.Count > 0 && !lPrimerSustento)
                {
                    frmSustentoVinculacionArchivo frmSustentoVinculacion = new frmSustentoVinculacionArchivo(idSolicitud, lSuperaExposicion, idEstadoSolicitud, _idTipoArchivo: idTipoArchivoEscaneado, _idArchivo: 0, _idAccionVinculacion: idAccionVinculacion, _idPagareCredito: idPagareCredito, _idSolicitudGrupoSolidario: 0);
                    frmSustentoVinculacion.ShowDialog();

                    objSustentoArchivo = frmSustentoVinculacion.objSustentoVinculacionArchivo;

                    if (!String.IsNullOrWhiteSpace(objSustentoArchivo.cComentario))
                    {
                        if (objSustentoArchivo.idAccionVinculacionArchivo == 3)
                            lstSustentoVinculacionArchivo.Clear();
                        lstSustentoVinculacionArchivo.Add(objSustentoArchivo);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (lPrimerSustento && idAccionVinculacion == 1)
                    {
                        objSustentoArchivo.idSustentoArchivoPagare = 0;
                        objSustentoArchivo.idSolicitud = idSolicitud;
                        objSustentoArchivo.idSolicitudGrupoSolidario = 0;
                        objSustentoArchivo.lSuperaMontoExposicion = lSuperaExposicion;
                        objSustentoArchivo.idArchivo = 0;
                        objSustentoArchivo.idTipoArchivo = idTipoArchivoEscaneado;
                        objSustentoArchivo.idPagareCredito = idPagareCredito;
                        objSustentoArchivo.idMotivoVinculacionArchivo = 1;
                        objSustentoArchivo.cComentario = "REGISTRO INICIAL DEL SUSTENTO DEL ARCHIVO";
                        objSustentoArchivo.idAccionVinculacionArchivo = idAccionVinculacion;
                        objSustentoArchivo.idEstadoSolicitud = idEstadoSolicitud;
                        objSustentoArchivo.idEstado = 1;
                        objSustentoArchivo.idUsuario = clsVarGlobal.User.idUsuario;
                        objSustentoArchivo.dFechaRegistro = clsVarGlobal.dFecSystem;
                        objSustentoArchivo.lVigente = true;
                    }
                    if (!String.IsNullOrWhiteSpace(objSustentoArchivo.cComentario))
                    {
                        lstSustentoVinculacionArchivo.Add(objSustentoArchivo);
                    }
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private void agregarArchivo()
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Abrir archivo";
            fDialog.InitialDirectory = clsVarGlobal.cRutPathApp;
            fDialog.Multiselect = false;
            fDialog.Filter = "PDF Documents|*.pdf| Archivos JPG|*.jpg| Archivos JPEG|*.jpeg";

            if (fDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo fi = new FileInfo(fDialog.FileName);
                long fileSize = fi.Length;
                int maxSize = clsVarApl.dicVarGen["cMaxFile"];
                if (fileSize > maxSize)
                {
                    int bytesCar = (Convert.ToInt32(fileSize) / 1048576);
                    int bytesMax = (Convert.ToInt32(maxSize) / 1048576);
                    MessageBox.Show("El archivo que intentas subir excede el límite de tamaño permitido (5MB). Por favor, selecciona un archivo más pequeño y vuelve a intentarlo.", "Adjuntar Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    string cArchivo = fDialog.FileName;
                    FileInfo fInfo = new FileInfo(cArchivo);
                    long numBytes = fInfo.Length;
                    FileStream fStream = new FileStream(cArchivo, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fStream);

                    if (fInfo.Extension == ".jpg" || fInfo.Extension == ".jpeg")
                    {
                        string cRutaArchivo = "";
                        int indice = cArchivo.IndexOf(".j");
                        if (indice != -1)
                        {
                            cRutaArchivo = cArchivo.Substring(0, indice);
                        }

                        string cArchivoPdf = cRutaArchivo + ".pdf";
                        using (FileStream fs = new FileStream(cArchivoPdf, FileMode.Create))
                        {
                            Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                            doc.Open();

                            // Cargar la imagen JPG
                            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(fStream);
                            jpg.ScaleToFit(doc.PageSize.Width, doc.PageSize.Height);
                            doc.Add(jpg);
                            doc.Close();
                        }

                        byte[] bytesPdf = new byte[0]; ;
                        if (File.Exists(cArchivoPdf))
                        {
                            using (FileStream pdfFileStream = new FileStream(cArchivoPdf, FileMode.Open, FileAccess.Read))
                            {
                                bytesPdf = new byte[pdfFileStream.Length];
                                pdfFileStream.Read(bytesPdf, 0, (int)pdfFileStream.Length);
                            }
                        }

                        string nameFile = cArchivoPdf;
                        string cDocumentoSesion = fInfo.Name;
                        string cExtension = ".pdf";

                        dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cArchivo"].Value = cDocumentoSesion;
                        dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cExtension"].Value = cExtension;
                        dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["bArchivoBinary"].Value = Compresion.CompressedByte(bytesPdf);
                        dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lInsertado"].Value = 0;

                        if (File.Exists(cArchivoPdf)) 
                        {
                            File.Delete(cArchivoPdf);
                        }

                    }
                    else
                    {
                        string nameFile = cArchivo;
                        string cDocumentoSesion = fInfo.Name;
                        byte[] vDocumentoSesion = br.ReadBytes((int)numBytes);
                        string cExtension = fInfo.Extension;
                        fStream.Flush();
                        fStream.Close();
                        br.Close();

                        dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cArchivo"].Value = cDocumentoSesion;
                        dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cExtension"].Value = cExtension;
                        dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["bArchivoBinary"].Value = Compresion.CompressedByte(vDocumentoSesion);
                        dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lInsertado"].Value = 0;
                    }


                }
            }
        }

        private void borrarAchivo()
        {
            dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cArchivo"].Value = "";
            dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cExtension"].Value = "";
            dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["bArchivoBinary"].Value = new byte[0];
            dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lInsertado"].Value = 0;
        }

        private void vistoBueno()
        {
            if (Convert.ToInt32(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lAbsuelto"].Value) == 1)
            {
                bool lAbsuelto = Convert.ToBoolean(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lAbsuelto"].Value is DBNull ? 0 : dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lAbsuelto"].Value);
                frmRegistroDocumentoObs frmRegistroDocumentosObs = new frmRegistroDocumentoObs(clsVarGlobal.User.idUsuario,
                                                                                idSolicitud,
                                                                                idTipoSolicitudObs,
                                                                                Convert.ToInt32(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["idTipoArchivo"].Value),
                                                                                clsVarGlobal.User.idEstablecimiento,
                                                                                lAbsuelto
                                                                                );
                frmRegistroDocumentosObs.ShowDialog();
                //idDescTipoDoc_ = Convert.ToInt32(cboGrupoArchivo.SelectedValue);
                cargardatos(false);
            }
            else
            {
                int idEstadoCreditoObs = 1; //Visto Bueno
                int idRegistroSolCredObs = 0;
                DialogResult dialogResult = MessageBox.Show("Declaro que he revisado este documento siendo conforme, por lo cual doy Visto Bueno bajo mi responsabilidad.", "Checklist de documentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    DataTable dtRes = clsFiles.guardarRegistroSolCredObs(
                                                                    clsVarGlobal.User.idUsuario,
                                                                    idSolicitud,
                                                                    idTipoSolicitudObs,
                                                                    Convert.ToInt32(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["idTipoArchivo"].Value),
                                                                    idEstadoCreditoObs,
                                                                    idRegistroSolCredObs,
                                                                    "",
                                                                    0);
                    //idDescTipoDoc_ = Convert.ToInt32(cboGrupoArchivo.SelectedValue);
                    cargardatos(false);
                }
            }
        }

        private bool VerificarPerfilVBObservaChecklist()
        {
            bool lPerfil = false;
            DataTable dtPerfil = clsFiles.ListarPerfilVBObservaChecklist();
            foreach (DataRow item in dtPerfil.Rows)
            {
                if (Convert.ToInt32(item["idPerfil"]) == clsVarGlobal.PerfilUsu.idPerfil)
                {
                    lPerfil = true;
                    break;
                }
            }
            return lPerfil;
        }

        private bool VerificarPerfilAbsuelveChecklist()
        {
            bool lPerfil = false;
            DataTable dtPerfil = clsFiles.ListarPerfilAbsuelveChecklist();
            foreach (DataRow item in dtPerfil.Rows)
            {
                if (Convert.ToInt32(item["idPerfil"]) == clsVarGlobal.PerfilUsu.idPerfil)
                {
                    lPerfil = true;
                    break;
                }
            }
            return lPerfil;
        }

        private void panelBotones_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
