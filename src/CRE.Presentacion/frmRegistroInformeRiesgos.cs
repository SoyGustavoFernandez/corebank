using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using System.IO;
using EntityLayer;
using System.Linq;

namespace CRE.Presentacion
{
    public partial class frmRegistroInformeRiesgos : frmBase
    {

        #region Variables

        OpenFileDialog dialog = new OpenFileDialog();

        clsCNSolicitud SolCre = new clsCNSolicitud();//Par recuperar los datos de la solicitud de crédito, ejm datos del clientes, etc.

        DataTable dtDocumentos = new DataTable();//Contendrá los datos de los documentos que se adjuntarán al Informe(No se muestra al cliente)
        DataTable dtAuxDocs = new DataTable();//Tabla para mostrar los documentos que se van adjuntando(Se muestra al usuario - gridview)

        DataTable dtInfRiesgos = new DataTable();

        frmListSolInformeRiesgos frmListSolInfRiesgos;
        clsCNInformeRiesgos InformeRiesgos = new clsCNInformeRiesgos();

        short nInsertActualiza = 1;//Si es  1: insertará un nuevo informe
        //      2: Actualizará un informe
        int nIdInformeRiesgos = 0; //Identificador del INFORME DE RIESGOS
        int nidSolCre;                  //Identificador de la SOLICITUD DE CRÉDITO
        int nidsolInformeRiesgos = 0;   //Identificador de la SOLICITUD DE INFORME DE RIESGO
        private string cDirectorioRiesgos = "riesgos";

        private int idEvalCred = 0;
        private int idSolicitud = 0;
        private int idTipEvalCred = 0;
        #endregion

        #region Eventos

        private void frmRegistroInformeRiesgos_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            {
                buttons.Name = "boton";
                buttons.Text = "Ver";
                buttons.UseColumnTextForButtonValue = true;
                buttons.FlatStyle = FlatStyle.Standard;
                buttons.CellTemplate.Style.BackColor = Color.Honeydew;
            }
            dtgDocumentos.Columns.Add(buttons);
            DarFormatoGridDocumentos();
            if (nIdInformeRiesgos > 0)
            {
                txtCodigoInformeRiesgo.Text = nIdInformeRiesgos.ToString();
                MostrarInformeRiesgos();

                btnEditar1.Enabled = false;
                btnCancelar1.Enabled = false;
            }
        }

        private void btnAgrDoc_Click(object sender, EventArgs e)//'BOTON AGREGAR Y QUITAR DOCUMENTOS' debebn ser visibles sólo para el perfil que va leer los inf. de riesgos
        {
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //Recuperar el nombre del archivo a Subir
                string[] cAuxNombreArchivo = dialog.FileName.Split('\\');
                string cNombreArchivo = cAuxNombreArchivo[cAuxNombreArchivo.Length - 1];

                if (NombreArchivoEsRepetido(cNombreArchivo))
                {
                    MessageBox.Show("El nombre del archivo ya existe", "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Data que se guardará
                DataRow drDocumento = dtDocumentos.NewRow();
                drDocumento["idDocInfRiesgo"] = 0;
                drDocumento["cNombreArchivo"] = cNombreArchivo;
                dtDocumentos.Rows.Add(drDocumento);

                //Para mostrarlos en pantalla
                DataRow drAuxDoc = dtAuxDocs.NewRow();
                drAuxDoc["idDocInfRiesgo"] = 0;
                drAuxDoc["cNombreArchivo"] = cNombreArchivo;
                drAuxDoc["cDireccionArchivo"] = dialog.FileName;
                drAuxDoc["lVigente"] = true;
                dtAuxDocs.Rows.Add(drAuxDoc);

                CargarIconoArchivosAGrid();
                btnQuitDoc.Enabled = true;

                dtgDocumentos.CurrentCell = null;
                for (int i = 0; i < dtAuxDocs.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dtAuxDocs.Rows[i]["lVigente"]) == false)
                    {
                        dtgDocumentos.Rows[i].Visible = false;
                    }
                }

            }
        }

        private void btnQuitDoc_Click(object sender, EventArgs e)//'BOTON AGREGAR Y QUITAR DOCUMENTOS' debebn ser visibles sólo para el perfil que va leer los inf. de riesgos
        {
            if (dtgDocumentos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar el documento a eliminar", "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nfilaseleccionada = Convert.ToInt32(this.dtgDocumentos.SelectedRows[0].Index);

            if (nInsertActualiza == 1)//El botón Guardar Insertará un nuevo informe
            {
                dtAuxDocs.Rows.RemoveAt(nfilaseleccionada);
                dtDocumentos.Rows.RemoveAt(nfilaseleccionada);
            }
            else//El botón Guardar editará un informe
            {
                if (Convert.ToInt32(dtAuxDocs.Rows[nfilaseleccionada]["idDocInfRiesgo"]) == 0)//Recién se ha insertado en aplicativo, pero no se insertado en Base de datos
                {
                    //Quitar fila de dtTable (el que se va enviar a Base de Datos)
                    for (int i = 0; i < dtDocumentos.Rows.Count; i++)
                    {
                        if (dtDocumentos.Rows[i]["cNombreArchivo"].ToString().Trim().ToUpper().Equals(dtAuxDocs.Rows[nfilaseleccionada]["cNombreArchivo"].ToString().Trim().ToUpper()))
                        {
                            //Quitar fila de dtTable (el que se va enviar a Base de Datos)
                            dtDocumentos.Rows.RemoveAt(i);
                            break;
                        }
                    }
                    //Quitar fila de dtTable (el que se va mostrar en pantalla)
                    dtAuxDocs.Rows.RemoveAt(nfilaseleccionada);
                }
                else
                {
                    dtAuxDocs.Rows[nfilaseleccionada]["lvigente"] = 0;
                    dtgDocumentos.CurrentCell = null;
                    dtgDocumentos.Rows[nfilaseleccionada].Visible = false;
                }
            }

            if (dtAuxDocs.Rows.Count == 0)
            {
                btnQuitDoc.Enabled = false;
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            txtCodigoInformeRiesgo.Text = "";
            LimpiarCampos();
            btnListaSolPendientes.Enabled = true;
            grbInforme.Enabled = true;
            nInsertActualiza = 1;//Reinicia al modo de insertado
            nIdInformeRiesgos = 0;
            nidSolCre = 0;
            nidsolInformeRiesgos = 0;

            dtgDocumentos.ReadOnly = true;
            DarFormatoGridDocumentos();
            txtCodigoInformeRiesgo.Focus();
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            DataTable dtSolOpiRecu = SolCre.verificarSolOpiRecu(idSolicitud);
            if (dtSolOpiRecu.Rows.Count > 0)
            {
                MessageBox.Show("La solicitud tiene pendiente la opinión de recuperaciones.", "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool lCamposValidos = ValidarCampos();

            if (lCamposValidos == false)
            {
                return;
            }

            if (nInsertActualiza == 1)//Insertará un nuevo informe
            {
                //Codificar el(los) archivo(s) a bytes que se van almacenar en Base de Datos
                for (int i = 0; i < dtAuxDocs.Rows.Count; i++)
                {
                    DataTable dtRespuestaIdInfRiesgo = InformeRiesgos.InsertInformeRiesgo(frmListSolInfRiesgos.nidSolCre, frmListSolInfRiesgos.nidSolInfRiesgo, txtOpinion.Text, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, nIdInformeRiesgos, (Object)CodificarArchivoABytes(dtAuxDocs.Rows[i]["cDireccionArchivo"].ToString()), dtAuxDocs.Rows[i]["cNombreArchivo"].ToString(), rbtnFavorable.Checked);
                    nIdInformeRiesgos = Convert.ToInt32(dtRespuestaIdInfRiesgo.Rows[0][0]);
                }
                MessageBox.Show("Se ha registrado correctamente INFORME N° " + nIdInformeRiesgos.ToString(), "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else//Actualizará un informe
            {
                //Codificar el(los) archivo(s) a bytes que se van almacenar en Base de Datos
                for (int i = 0; i < dtAuxDocs.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dtAuxDocs.Rows[i]["idDocInfRiesgo"]) == 0)//nuevos documentos que se están adjuntando
                    {
                        DataTable dtRespuesta = InformeRiesgos.InsertInformeRiesgo(nidSolCre, nidsolInformeRiesgos, txtOpinion.Text, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, nIdInformeRiesgos, (Object)CodificarArchivoABytes(dtAuxDocs.Rows[i]["cDireccionArchivo"].ToString()), dtAuxDocs.Rows[i]["cNombreArchivo"].ToString(), rbtnFavorable.Checked);
                    }
                    else //documentos adjuntos que se cambiará su estado vigente
                    {
                        if (Convert.ToBoolean(dtAuxDocs.Rows[i]["lvigente"]) == false)
                        {
                            DataTable dtRespuesta = InformeRiesgos.ActualizaInformeRiesgo(nIdInformeRiesgos, txtOpinion.Text, Convert.ToInt32(dtAuxDocs.Rows[i]["idDocInfRiesgo"]), clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, false, false, rbtnFavorable.Checked);
                        }
                        else
                        {
                            DataTable dtRespuesta = InformeRiesgos.ActualizaInformeRiesgo(nIdInformeRiesgos, txtOpinion.Text, Convert.ToInt32(dtAuxDocs.Rows[i]["idDocInfRiesgo"]), clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, true, Convert.ToBoolean(dtAuxDocs.Rows[i]["lLeido"]), rbtnFavorable.Checked);
                        }
                    }
                }

                MessageBox.Show("Informe Actualizado correctamente", "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nIdInformeRiesgos = Convert.ToInt32(txtCodigoInformeRiesgo.Text);

                dtInfRiesgos = InformeRiesgos.BuscarInformeRiesgo(nIdInformeRiesgos, null, null, null, string.Empty, 2);

                if (dtInfRiesgos.Rows.Count == 0)
                {
                    MessageBox.Show("No existe el Informe de Riesgos N° " + txtCodigoInformeRiesgo.Text, "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MostrarInformeRiesgos();
            }

            //Congelar vista
            txtOpinion.Enabled = false;
            rbtnFavorable.Enabled = false;
            rbtnDesfavorable.Enabled = false;
            //dtgDocumentos.Enabled = false;

            btnAgrDoc.Enabled = false;
            btnQuitDoc.Enabled = false;

            btnGrabar1.Enabled = false;

            //Cambia color grid
            //dtgDocumentos.ForeColor = Color.Gray;
        }

        private void btnBusqueda2_Click(object sender, EventArgs e)
        {
            frmBuscarInfRiegos frmBuscaInf = new frmBuscarInfRiegos();
            frmBuscaInf.ShowDialog();
            if (frmBuscaInf.nidSolInfRiesgo != 0)
            {
                dtInfRiesgos = frmBuscaInf.dtResultado;
                nIdInformeRiesgos = Convert.ToInt32(dtInfRiesgos.Rows[0]["idInfRiesgos"]);
                txtCodigoInformeRiesgo.Text = nIdInformeRiesgos.ToString();
                MostrarInformeRiesgos();
            }
            else
            {
                LimpiarCampos();
                DarFormatoGridDocumentos();
            }
        }

        private void btnEditar1_Click(object sender, EventArgs e)//Debe ser visible éste botón sólo para el perfil que adiciona/quita archivos adjuntado al informe de riesgos
        {
            DataTable dtSolOpiRecu =  SolCre.verificarSolOpiRecu(idSolicitud);
            if (dtSolOpiRecu.Rows.Count > 0)
            {
                MessageBox.Show("La solicitud tiene pendiente la opinión de recuperaciones.", "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            nInsertActualiza = 2;

            dtgDocumentos.ForeColor = Color.Black;

            grbInforme.Enabled = false;
            txtOpinion.Enabled = true;
            rbtnFavorable.Enabled = true;
            rbtnDesfavorable.Enabled = true;
            btnAgrDoc.Enabled = true;
            btnEditar1.Enabled = false;
            btnGrabar1.Enabled = true;
            if (dtAuxDocs.Rows.Count > 0)
            {
                btnQuitDoc.Enabled = true;
            }

            /*//Dar permisos de lectura al grid de documentos
            dtgDocumentos.ReadOnly = false;
            for (int i = 0; i < dtgDocumentos.ColumnCount; i++)
            {
                if (dtgDocumentos.Columns[i].Name.Equals("lLeido") == false)
                {
                    dtgDocumentos.Columns[i].ReadOnly = true;
                }
            }
            */
            txtOpinion.Focus();

        }

        private void btnLeer1_Click(object sender, EventArgs e)
        {

            nInsertActualiza = 2;

            dtgDocumentos.ForeColor = Color.Black;

            grbInforme.Enabled = false;
            txtOpinion.Enabled = false;
            btnAgrDoc.Enabled = true;
            //btnLeer1.Enabled = false;
            btnGrabar1.Enabled = true;
            if (dtAuxDocs.Rows.Count > 0)
            {
                btnQuitDoc.Enabled = true;
            }

            //Permitir ver la opcion leido
            dtgDocumentos.Columns["lLeido"].Visible = true;
            dtgDocumentos.Columns["lLeido"].HeaderText = "Leido";
            dtgDocumentos.Columns["lLeido"].Width = 50;

            //Dar permisos de lectura al grid de documentos
            dtgDocumentos.ReadOnly = false;
            for (int i = 0; i < dtgDocumentos.ColumnCount; i++)
            {
                if (dtgDocumentos.Columns[i].Name.Equals("lLeido") == false)
                {
                    dtgDocumentos.Columns[i].ReadOnly = true;
                }
            }

            txtOpinion.Focus();
        }

        private void btnListaSolPendientes_Click(object sender, EventArgs e)
        {
            frmListSolInfRiesgos = new frmListSolInformeRiesgos();
            frmListSolInfRiesgos.ShowDialog();

            if (frmListSolInfRiesgos.nidSolInfRiesgo != 0 && frmListSolInfRiesgos.nidSolCre != 0)
            {
                LimpiarCampos();
                //Re usar la función de búsqueda de 'solicitud de crédito'
                DataTable dtSolCre = SolCre.ConsultaSolicitud(frmListSolInfRiesgos.nidSolCre);
                if (dtSolCre.Rows.Count == 0)
                {
                    MessageBox.Show("Error al recuperar datos de la solicitud de crédito", "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.idEvalCred = Convert.ToInt32(dtSolCre.Rows[0]["idEvalCred"]);
                    this.idSolicitud = Convert.ToInt32(dtSolCre.Rows[0]["idSolicitud"]);
                    this.idTipEvalCred = Convert.ToInt32(dtSolCre.Rows[0]["idTipEvalCred"]);

                    txtCodInst.Text = Convert.ToString(dtSolCre.Rows[0]["cCodCliente"]).Substring(0, 3);
                    txtCodAge.Text = Convert.ToString(dtSolCre.Rows[0]["cCodCliente"]).Substring(3, 3);
                    txtCodCliente.Text = Convert.ToString(dtSolCre.Rows[0]["cCodCliente"]).Substring(6);

                    txtNombre.Text = Convert.ToString(dtSolCre.Rows[0]["cNombre"]);
                    txtNroDocIde.Text = Convert.ToString(dtSolCre.Rows[0]["cDocumentoID"]);

                    //Datos de la solicitud del crédito
                    txtCodSolCre.Text = frmListSolInfRiesgos.nidSolCre.ToString();
                    txtMotivoSolInfRiesgo.Text = frmListSolInfRiesgos.cMotivoSolInformeRiesgo;

                    this.txtMontoPropuesto.Text = (Convert.ToDecimal(frmListSolInfRiesgos.cCapitalPropuesto)).ToString("N2");
                    this.txtAsesor.Text = frmListSolInfRiesgos.cNombreAsesor;
                    this.txtOficina.Text = frmListSolInfRiesgos.cNomCorto;
                }

                txtCodigoInformeRiesgo.Text = "";
                grbInforme.Enabled = false;

                //Habilitar Controles para insertar un nuevo informe
                txtOpinion.Enabled = true;
                rbtnFavorable.Enabled = true;
                rbtnDesfavorable.Enabled = true;
                btnAgrDoc.Enabled = true;
                btnGrabar1.Enabled = true;
                btnImprimir1.Enabled = true;
                DarFormatoGridDocumentos();
                txtOpinion.Focus();
            }
        }

        private void dtgDocumentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtAuxDocs.Rows.Count > 0 && nIdInformeRiesgos != 0)
            {
                //Verificar que se estée haciendo click en el boton "Registrar Informe riesgo"
                if (dtgDocumentos.CurrentCell.OwningColumn.Name.Equals("boton"))
                {
                    int nfilaseleccionada = Convert.ToInt32(this.dtgDocumentos.CurrentRow.Index);
                    int nIdDocInfRiesgo = Convert.ToInt32(dtDocumentos.Rows[nfilaseleccionada]["idDocInfRiesgo"]);
                    if (nIdDocInfRiesgo == 0)
                    {
                        MessageBox.Show("El archivo todavía no se ha guardado", "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    string[] cExtensionArchivo = dtAuxDocs.Rows[nfilaseleccionada]["cNombreArchivo"].ToString().Split('.');
                    string cExtencion = cExtensionArchivo[cExtensionArchivo.Length - 1].ToUpper();

                    if (Convert.ToInt32(dtAuxDocs.Rows[nfilaseleccionada]["idDocInfRiesgo"]) == nIdDocInfRiesgo)
                    {
                        string cDirectorio = String.Format("{0}\\{1}", clsVarGlobal.cRutPathApp, cDirectorioRiesgos);
                        string cNombreArchivo = dtAuxDocs.Rows[nfilaseleccionada]["cNombreArchivo"].ToString();
                        if (!Directory.Exists(cDirectorio))
                        {
                            Directory.CreateDirectory(cDirectorio);
                        }

                        string ruta = String.Format("{0}\\{1}", cDirectorio, cNombreArchivo);
                        FileInfo fileInfo = new FileInfo(ruta);
                        File.WriteAllBytes(ruta, (byte[])(this.dtDocumentos.Rows[nfilaseleccionada]["bArchivo"]));
                        frmVisualisarDocRiesgos frmVerDoc = new frmVisualisarDocRiesgos(cDirectorio, fileInfo.Name, fileInfo.Extension);
                        frmVerDoc.ShowDialog();
                    }
                }
            }
        }

        private void txtCodigoInformeRiesgo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtCodigoInformeRiesgo.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Debe ingresar un Número de Informe de Riesgo", "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigoInformeRiesgo.Focus();
                    return;
                }

                nIdInformeRiesgos = Convert.ToInt32(txtCodigoInformeRiesgo.Text);

                dtInfRiesgos = InformeRiesgos.BuscarInformeRiesgo(nIdInformeRiesgos, null, null, null, string.Empty, 2);

                if (dtInfRiesgos.Rows.Count == 0)
                {
                    MessageBox.Show("No existe el Informe de Riesgos N° " + txtCodigoInformeRiesgo.Text, "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MostrarInformeRiesgos();
            }
        }

        private void frmRegistroInformeRiesgos_FormClosed(object sender, FormClosedEventArgs e)
        {
            eliminar();
        }

        #endregion

        #region Métodos

        public frmRegistroInformeRiesgos()
        {
            InitializeComponent();

            //GRID  de documentos, aquí el usuario añadirá documentos en su informe de riesgos
            dtDocumentos.Columns.Add("idDocInfRiesgo", typeof(int));
            dtDocumentos.Columns.Add("cNombreArchivo", typeof(string));
            dtDocumentos.Columns.Add("bArchivo", typeof(object));
            dtDocumentos.Columns.Add("lLeido", typeof(bool));


            dtAuxDocs.Columns.Add("idDocInfRiesgo", typeof(int));
            dtAuxDocs.Columns.Add("IconoArchivo", typeof(Image));
            dtAuxDocs.Columns.Add("cNombreArchivo", typeof(string));
            dtAuxDocs.Columns.Add("cDireccionArchivo", typeof(string));
            dtAuxDocs.Columns.Add("lvigente", typeof(bool));
            dtAuxDocs.Columns.Add("lLeido", typeof(bool));

            dtgDocumentos.DataSource = dtAuxDocs;
            dtgDocumentos.Columns["cNombreArchivo"].HeaderText = "Nombre del Archivo";

            MostrarAlerta();//Si existen solicitudes de Informes de riesgo pendientes de atención se mostrará la cantidad de ellas

            dialog.Filter = "Documentos Word(*.doc, *.docx)|*.docx;*.doc|Imagenes(*.png, *jpg)|*.png;*.jpg|PDF(*.pdf)|*.pdf";
        }

        public frmRegistroInformeRiesgos(int idInfRiesgos)
            : this()
        {
            nIdInformeRiesgos = idInfRiesgos;
            dtInfRiesgos = InformeRiesgos.BuscarInformeRiesgo(nIdInformeRiesgos, null, null, null, string.Empty, 2);

            if (dtInfRiesgos.Rows.Count == 0)
            {
                MessageBox.Show("No existe el Informe de Riesgos N° " + txtCodigoInformeRiesgo.Text, "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Dispose();
                return;
            }
        }

        private bool NombreArchivoEsRepetido(string cNombreArchivoASubir)
        {
            bool lRespuesta = false;
            for (int i = 0; i < dtAuxDocs.Rows.Count; i++)
            {
                if (dtAuxDocs.Rows[i]["cNombreArchivo"].ToString().ToUpper().Equals(cNombreArchivoASubir.ToUpper()))
                {
                    lRespuesta = true;
                    break;
                }
            }

            return lRespuesta;
        }

        private void LimpiarCampos()
        {
            dtgDocumentos.DataSource = null;
            dtgDocumentos.Enabled = true;
            dtgDocumentos.ForeColor = Color.Black;

            this.idEvalCred = 0;
            this.idSolicitud = 0;
            this.idTipEvalCred = 0;

            txtOpinion.Text = "";
            txtOpinion.Enabled = false;

            //Datos del cliente
            txtCodInst.Text = "";
            txtCodAge.Text = "";
            txtCodCliente.Text = "";

            txtNombre.Text = "";
            txtNroDocIde.Text = "";

            //Datos de la solicitud de crédito
            txtCodSolCre.Text = "";
            txtMotivoSolInfRiesgo.Text = "";

            rbtnFavorable.Checked = false;
            rbtnDesfavorable.Checked = false;
            rbtnFavorable.Enabled = false;
            rbtnDesfavorable.Enabled = false;

            //Botones Agregar/Quitar
            btnAgrDoc.Enabled = false;
            btnQuitDoc.Enabled = false;
            btnEditar1.Enabled = false;
            btnGrabar1.Enabled = false;
            btnImprimir1.Enabled = false;

            //Grupo Informe
            grbInforme.Enabled = true;

            //DataTable que se mostrará(Gridview)
            dtAuxDocs.Clear();

            //DataTable para enviar datos a Base de Datos
            dtDocumentos.Clear();

            dtgDocumentos.DataSource = dtAuxDocs;

            txtCodigoInformeRiesgo.Focus();

            this.txtMontoPropuesto.Clear();
            this.txtAsesor.Clear();
            this.txtOficina.Clear();
        }

        private bool ValidarCampos()
        {
            bool lCamposValidos = false;
            if (txtOpinion.Text.Trim().Equals(""))
            {
                MessageBox.Show("El informe de Riesgos debe tener un comentario y/o opinión", "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOpinion.Focus();
                return lCamposValidos;
            }

            if (txtNombre.Text.Trim().Equals(""))
            {
                MessageBox.Show("El informe de Riesgos debe tener los datos del cliente", "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lCamposValidos;
            }

            if (dtgDocumentos.RowCount == 0)
            {
                MessageBox.Show("El informe de Riesgos debe tener documentos adjuntados", "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lCamposValidos;
            }

            if (!rbtnFavorable.Checked && !rbtnDesfavorable.Checked)
            {
                MessageBox.Show("Seleccione si la opinión es favorable o desfavorable.", "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lCamposValidos;
            }

            lCamposValidos = true;

            return lCamposValidos;
        }

        public byte[] CodificarArchivoABytes(string cNombreArchivo)
        {
            return System.IO.File.ReadAllBytes(cNombreArchivo);
        }

        private void MostrarAlerta()
        {
            //Mostrar la alerta de pendientes sólo para los perfiles que 'no visualizan' el formulario de  APROBACIÓN DE SOLICITUDES
            clslisMenu listamenumodulo = new clslisMenu();
            var lista = new clsCNMenu().listarMenuPorPerfil(clsVarGlobal.PerfilUsu.idPerfil);
            listamenumodulo.Clear();
            listamenumodulo.AddRange(lista.ToList());

            foreach (clsMenu item in listamenumodulo)
            {
                if (item.cFormMenu.Equals("frmCambioEstadoSol") && item.lActivo == false)
                {
                    //Mostrar la Cantidad de Solicitudes de Informe de riesgo pendientes
                    int nCantAlertasSolInformeRiesgos = InformeRiesgos.ListarSolicitudesInformeRiesgo(0).Rows.Count;
                    if (nCantAlertasSolInformeRiesgos > 0)
                    {
                        //MessageBox.Show("Usted tiene " + nCantAlertasSolInformeRiesgos.ToString() + " nueva(s) solicitud(es) de informe de riesgos en espera de atención...", "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //
                    break;
                }
            }
        }

        private void MostrarInformeRiesgos()
        {
            LimpiarCampos();
            FormatoGridLectura();

            this.idEvalCred = Convert.ToInt32(dtInfRiesgos.Rows[0]["idEvalCred"]);
            this.idSolicitud = Convert.ToInt32(dtInfRiesgos.Rows[0]["idSolicitud"]);
            this.idTipEvalCred = Convert.ToInt32(dtInfRiesgos.Rows[0]["idTipEvalCred"]);

            //Datos del cliente
            txtCodInst.Text = Convert.ToString(dtInfRiesgos.Rows[0]["cCodCliente"]).Substring(0, 3);
            txtCodAge.Text = Convert.ToString(dtInfRiesgos.Rows[0]["cCodCliente"]).Substring(3, 3);
            txtCodCliente.Text = Convert.ToString(dtInfRiesgos.Rows[0]["cCodCliente"]).Substring(6);

            txtNombre.Text = Convert.ToString(dtInfRiesgos.Rows[0]["cNombre"]);
            txtNroDocIde.Text = Convert.ToString(dtInfRiesgos.Rows[0]["cDocumentoID"]);

            rbtnFavorable.Checked = Convert.ToBoolean(dtInfRiesgos.Rows[0]["lFavorable"]);
            rbtnDesfavorable.Checked = !Convert.ToBoolean(dtInfRiesgos.Rows[0]["lFavorable"]);

            //Datos del informe
            dtpFechaInfRiesgo.Value = Convert.ToDateTime(dtInfRiesgos.Rows[0]["dFechaRegistroInforme"]);
            txtOpinion.Text = Convert.ToString(dtInfRiesgos.Rows[0]["cOpinion"]);

            //Datos de la solicitud
            txtCodSolCre.Text = Convert.ToString(dtInfRiesgos.Rows[0]["idSolCre"]);
            txtMotivoSolInfRiesgo.Text = Convert.ToString(dtInfRiesgos.Rows[0]["cMotivo"]);

            nidSolCre = Convert.ToInt32(dtInfRiesgos.Rows[0]["idSolCre"]);
            nidsolInformeRiesgos = Convert.ToInt32(dtInfRiesgos.Rows[0]["idSolInfRiesgo"]);

            this.txtMontoPropuesto.Text = (Convert.ToDecimal(dtInfRiesgos.Rows[0]["nCapitalPropuesto"])).ToString("N2");
            this.txtAsesor.Text = Convert.ToString(dtInfRiesgos.Rows[0]["cNombreAsesor"]);
            this.txtOficina.Text = Convert.ToString(dtInfRiesgos.Rows[0]["cNomCorto"]);


            //Listado de documentos para mostrarlos en pantalla
            DataTable dtInfRiesgosDocumento = InformeRiesgos.BuscarDocInformeRiesgo(nIdInformeRiesgos);
            for (int i = 0; i < dtInfRiesgosDocumento.Rows.Count; i++)
            {
                //Verificar que el informe tenga documentos aduntados
                if (String.IsNullOrEmpty(dtInfRiesgosDocumento.Rows[i]["idDocInfRiesgo"].ToString()) == false)
                {
                    DataRow drAuxDoc = dtAuxDocs.NewRow();
                    drAuxDoc["cNombreArchivo"] = dtInfRiesgosDocumento.Rows[i]["cNombreArchivo"];
                    drAuxDoc["idDocInfRiesgo"] = dtInfRiesgosDocumento.Rows[i]["idDocInfRiesgo"];
                    drAuxDoc["lLeido"] = dtInfRiesgosDocumento.Rows[i]["lLeido"];
                    dtAuxDocs.Rows.Add(drAuxDoc);

                    //Cargando la tabla que contendrá los archivos recuperados de la búsqueda
                    DataRow drDoc = this.dtDocumentos.NewRow();
                    drDoc["idDocInfRiesgo"] = dtInfRiesgosDocumento.Rows[i]["idDocInfRiesgo"];
                    drDoc["cNombreArchivo"] = dtInfRiesgosDocumento.Rows[i]["cNombreArchivo"];
                    drDoc["bArchivo"] = dtInfRiesgosDocumento.Rows[i]["bArchivo"];
                    drDoc["lLeido"] = dtInfRiesgosDocumento.Rows[i]["lLeido"];
                    dtDocumentos.Rows.Add(drDoc);
                }
            }

            dtgDocumentos.DataSource = dtAuxDocs;

            //Setear los campos como no vigentes
            for (int i = 0; i < dtAuxDocs.Rows.Count; i++)
            {
                dtAuxDocs.Rows[i]["lvigente"] = 1;
            }

            CargarIconoArchivosAGrid();

            btnEditar1.Enabled = true;
            //btnLeer1.Enabled = true;
            btnGrabar1.Enabled = false;
            grbInforme.Enabled = false;
            btnImprimir1.Enabled = true;
            btnListaSolPendientes.Enabled = false;

            dtgDocumentos.ForeColor = Color.Gray;

            if (Convert.ToBoolean(dtInfRiesgos.Rows[0]["lEjecutado"]) == true)
            {
                MessageBox.Show("La solicitud de Crédito N° " + dtInfRiesgos.Rows[0]["idSolCre"].ToString() + " ha cambiado de Estado. Sólo puede leer el Informe", "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnEditar1.Enabled = false;
                //btnLeer1.Enabled = false;
            }

            if (dtAuxDocs.Rows.Count > 0)
            {
                //Hacer que el sistema selecciona la primera fila : seleccionaremos  la celda de columna=1 fila=0 (visible en el dataGridView)
                dtgDocumentos.CurrentCell = dtgDocumentos[2, 0];
                //Hacer que en la pantalla se muestre seleccionado la primera columna
                dtgDocumentos.Rows[0].Selected = true;
            }
        }

        private void CargarIconoArchivosAGrid()
        {
            //Asignar el icono del archivo de acuerdo al
            for (int i = 0; i < dtAuxDocs.Rows.Count; i++)
            {
                string[] cExtensionArchivo = dtAuxDocs.Rows[i]["cNombreArchivo"].ToString().Split('.');

                switch (cExtensionArchivo[cExtensionArchivo.Length - 1].ToUpper())
                {
                    case "JPG":
                        dtgDocumentos.Rows[i].Cells["IconoArchivo"].Value = Properties.Resources.ImgPng;
                        break;
                    case "PNG":
                        dtgDocumentos.Rows[i].Cells["IconoArchivo"].Value = Properties.Resources.ImgPng;
                        break;
                    case "DOC":
                        dtgDocumentos.Rows[i].Cells["IconoArchivo"].Value = Properties.Resources.ImgWord;
                        break;
                    case "DOCX":
                        dtgDocumentos.Rows[i].Cells["IconoArchivo"].Value = Properties.Resources.ImgWord;
                        break;
                    case "XLS":
                        dtgDocumentos.Rows[i].Cells["IconoArchivo"].Value = Properties.Resources.ImgExcel;
                        break;
                    case "XLSX":
                        dtgDocumentos.Rows[i].Cells["IconoArchivo"].Value = Properties.Resources.ImgExcel;
                        break;
                    case "PDF":
                        dtgDocumentos.Rows[i].Cells["IconoArchivo"].Value = Properties.Resources.ImgPdf;
                        break;
                }
            }
        }

        private void DarFormatoGridDocumentos()
        {
            foreach (DataGridViewColumn column in dtgDocumentos.Columns)
            {
                column.Visible = false;
            }

            dtgDocumentos.Columns["IconoArchivo"].Visible = true;
            dtgDocumentos.Columns["cNombreArchivo"].Visible = true;

            dtgDocumentos.Columns["IconoArchivo"].HeaderText = "";
            dtgDocumentos.Columns["cNombreArchivo"].HeaderText = "Nombre del Archivo";

            dtgDocumentos.Columns["IconoArchivo"].Width = 30;


            //Inmovilizar la clasificación del Grid
            dtgDocumentos.Columns["cNombreArchivo"].SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        private void FormatoGridLectura()
        {
            foreach (DataGridViewColumn column in dtgDocumentos.Columns)
            {
                column.Visible = false;
            }

            dtgDocumentos.Columns["IconoArchivo"].Visible = true;
            dtgDocumentos.Columns["cNombreArchivo"].Visible = true;
            dtgDocumentos.Columns["boton"].Visible = true;

            dtgDocumentos.Columns["IconoArchivo"].HeaderText = "";
            dtgDocumentos.Columns["cNombreArchivo"].HeaderText = "Nombre del Archivo";
            dtgDocumentos.Columns["boton"].HeaderText = "";

            dtgDocumentos.Columns["IconoArchivo"].Width = 50;


            dtgDocumentos.Columns["boton"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Inmovilizar la clasificación del Grid
            dtgDocumentos.Columns["cNombreArchivo"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void eliminar()
        {
            string[] files = System.IO.Directory.GetFiles(clsVarGlobal.cRutPathApp + "\\", "*.PDF");

            foreach (string file in files)
            {
                File.Delete(file);
            }
        }

        #endregion

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (this.idEvalCred == 0 || this.idTipEvalCred == 0)
            {
                MessageBox.Show("La solicitud de Crédito N° " + this.idSolicitud + " no tiene evaluación",
                   "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            frmExpEval frmExpEval = new frmExpEval(this.idEvalCred, this.idSolicitud, this.idTipEvalCred);
            frmExpEval.ShowDialog();
        }

    }
}
