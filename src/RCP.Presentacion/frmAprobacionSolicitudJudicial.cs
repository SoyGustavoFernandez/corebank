using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.Presentacion;
using EntityLayer;
using GEN.ControlesBase;
using RCP.CapaNegocio;

namespace RCP.Presentacion
{
    public partial class frmAprobacionSolicitudJudicial : frmBase
    {

        #region Variables

        DataTable dtSolPendientes;
        clsCNSolicitudRecuperacion solicitud = new clsCNSolicitudRecuperacion();

        DataTable dtDocumentos = new DataTable();//Contendrá los datos de los documentos que se adjuntarán al Informe(No se muestra al cliente)
        DataTable dtAuxDocs = new DataTable();//Tabla para mostrar los documentos que se van adjuntando(Se muestra al usuario - gridview)

        int nIdInformeRiesgos = 0; //Identificador del INFORME DE RIESGOS
        int nidSolCre;                  //Identificador de la SOLICITUD DE CRÉDITO
        int nidsolInformeRiesgos = 0;   //Identificador de la SOLICITUD DE INFORME DE RIESGO
        private string cDirecSolJudicial = "SolicitudJudicial";

        #endregion
        public frmAprobacionSolicitudJudicial()
        {
            InitializeComponent();


            dtDocumentos.Columns.Add("idSolicitudJudicialDoc", typeof(int));
            dtDocumentos.Columns.Add("cNombreArchivo", typeof(string));
            dtDocumentos.Columns.Add("bArchivo", typeof(object));
            dtDocumentos.Columns.Add("lLeido", typeof(bool));


            dtAuxDocs.Columns.Add("idSolicitudJudicialDoc", typeof(int));
            dtAuxDocs.Columns.Add("IconoArchivo", typeof(Image));
            dtAuxDocs.Columns.Add("cNombreArchivo", typeof(string));
            dtAuxDocs.Columns.Add("cDireccionArchivo", typeof(string));
            dtAuxDocs.Columns.Add("lvigente", typeof(bool));
            dtAuxDocs.Columns.Add("lLeido", typeof(bool));

            dtgDocumentos.DataSource = dtAuxDocs;
            dtgDocumentos.Columns["cNombreArchivo"].HeaderText = "Nombre del Archivo";
            
        }

        private void frmAprobacionSolicitudJudicial_Load(object sender, EventArgs e)
        {

            cboPersonalCargo1.cargarPersonal("nCargosRecuperadores", clsVarGlobal.nIdAgencia);
            cargarPendientesAprobaJudicial();

            cboUsuRecuperadores1.cargarGestoresLegalesYTodos();
            
            //
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

            //
            
            
            
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


        private void cargarPendientesAprobaJudicial()
        {
            dtSolPendientes = solicitud.ListarSoliRecuperaPendiAprobJudicial();

            /*if (dtSolPendientes.Rows.Count > 0)
            {
                dtgSolicitudes.DataSource = dtSolPendientes;
                formatoGridCreditos();
            }*/
            dtgSolicitudes.DataSource = dtSolPendientes;
            formatoGridCreditos();
            LimpiarCampos();
            //formatoGridCreditos();
            //CargarDatosPase();

        }

        private void formatoGridCreditos()
        {
            dtgSolicitudes.ReadOnly = false;
            foreach (DataGridViewColumn columna in dtgSolicitudes.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                columna.Visible = false;
                columna.ReadOnly = true;
            }

            dtgSolicitudes.Columns["lAprobado"].Visible = true;
            dtgSolicitudes.Columns["idCuenta"].Visible = true;
            dtgSolicitudes.Columns["dFechaReg"].Visible = true;
            dtgSolicitudes.Columns["idCli"].Visible = true;
            dtgSolicitudes.Columns["cNombre"].Visible = true;
            dtgSolicitudes.Columns["cWinUser"].Visible = true;
            dtgSolicitudes.Columns["nAtraso"].Visible = true;
            dtgSolicitudes.Columns["nSaldo"].Visible = true;

            dtgSolicitudes.Columns["lAprobado"].HeaderText = "Aprob.";
            dtgSolicitudes.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgSolicitudes.Columns["dFechaReg"].HeaderText = "Fecha Reg.";
            dtgSolicitudes.Columns["idCli"].HeaderText = "Cod. Cliente";
            dtgSolicitudes.Columns["cNombre"].HeaderText = "Nombres";
            dtgSolicitudes.Columns["cWinUser"].HeaderText = "Usu. Reg.";
            dtgSolicitudes.Columns["nAtraso"].HeaderText = "Atraso";
            dtgSolicitudes.Columns["nSaldo"].HeaderText = "Saldo";

            dtgSolicitudes.Columns["lAprobado"].Width = 40;
            dtgSolicitudes.Columns["idCuenta"].Width = 50;
            dtgSolicitudes.Columns["dFechaReg"].Width = 80;
            dtgSolicitudes.Columns["idCli"].Width = 70;
            dtgSolicitudes.Columns["cNombre"].Width = 250;
            dtgSolicitudes.Columns["cWinUser"].Width = 90;
            dtgSolicitudes.Columns["nAtraso"].Width = 40;
            dtgSolicitudes.Columns["nSaldo"].Width = 100;

            dtgSolicitudes.Columns["idCuenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgSolicitudes.Columns["idCli"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgSolicitudes.Columns["nAtraso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgSolicitudes.Columns["nSaldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgSolicitudes.Columns["nSaldo"].DefaultCellStyle.Format = "N2";
        }
        private void LimpiarCampos()
        {
            dtgDocumentos.DataSource = null;
            dtgDocumentos.Enabled = true;
            dtgDocumentos.ForeColor = Color.Black;

            txtOpinion.Text = "";

            txtCuenta.Text = "";
            txtCodCliente.Text = "";
            txtNomCliente.Text = "";

            LimpiarDocs();
            //DataTable que se mostrará(Gridview)
            //dtAuxDocs.Clear();
            //DataTable para enviar datos a Base de Datos
            //dtDocumentos.Clear();
            //dtgDocumentos.DataSource = dtAuxDocs;           
        }

        private void LimpiarDocs()
        {
            int nFilas = dtDocumentos.Rows.Count;
            for (int i = 0; i < nFilas; i++)
            {
                dtAuxDocs.Rows.RemoveAt(0);
                dtDocumentos.Rows.RemoveAt(0);
            }
            dtgDocumentos.DataSource = dtAuxDocs;
            //dtgDocumentos.DataSource = dtDocumentos;
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
        private void CargarDatosPase()
        {


            if (dtgSolicitudes.Rows.Count > 0)
            {

                txtOpinion.Text = dtgSolicitudes.SelectedRows[0].Cells["cOpinion"].Value.ToString();
                txtCuenta.Text = dtgSolicitudes.SelectedRows[0].Cells["idCuenta"].Value.ToString();
                txtCodCliente.Text = dtgSolicitudes.SelectedRows[0].Cells["idCli"].Value.ToString();
                txtNomCliente.Text = dtgSolicitudes.SelectedRows[0].Cells["cNombre"].Value.ToString();

                DataTable dtSolJudicialDocumento_ = solicitud.BuscarDocSolicitudJudicial(Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idSolicitudJudicial"].Value));

                for (int i = 0; i < dtSolJudicialDocumento_.Rows.Count; i++)
                {
                    //Verificar que el informe tenga documentos aduntados
                    if (String.IsNullOrEmpty(dtSolJudicialDocumento_.Rows[i]["idSolicitudJudicialDoc"].ToString()) == false)
                    {
                        DataRow drAuxDoc = dtAuxDocs.NewRow();

                        drAuxDoc["cNombreArchivo"] = dtSolJudicialDocumento_.Rows[i]["cNombreArchivo"];
                        drAuxDoc["idSolicitudJudicialDoc"] = dtSolJudicialDocumento_.Rows[i]["idSolicitudJudicialDoc"];
                        drAuxDoc["lLeido"] = dtSolJudicialDocumento_.Rows[i]["lLeido"];

                        dtAuxDocs.Rows.Add(drAuxDoc);

                        //Cargando la tabla que contendrá los archivos recuperados de la búsqueda
                        DataRow drDoc = this.dtDocumentos.NewRow();
                        drDoc["idSolicitudJudicialDoc"] = dtSolJudicialDocumento_.Rows[i]["idSolicitudJudicialDoc"];
                        drDoc["cNombreArchivo"] = dtSolJudicialDocumento_.Rows[i]["cNombreArchivo"];
                        drDoc["bArchivo"] = dtSolJudicialDocumento_.Rows[i]["bArchivo"];
                        drDoc["lLeido"] = dtSolJudicialDocumento_.Rows[i]["lLeido"];
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

                dtgDocumentos.ForeColor = Color.Gray;

                if (dtAuxDocs.Rows.Count > 0)
                {
                    //Hacer que el sistema selecciona la primera fila : seleccionaremos  la celda de columna=1 fila=0 (visible en el dataGridView)
                    dtgDocumentos.CurrentCell = dtgDocumentos[2, 0];
                    //Hacer que en la pantalla se muestre seleccionado la primera columna
                    dtgDocumentos.Rows[0].Selected = true;
                }
            }
        }
        private void dtgSolicitudes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            LimpiarCampos();
            FormatoGridLectura();
            CargarDatosPase();
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
        

        private void dtgDocumentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dtAuxDocs.Rows.Count > 0 )
            {
   
                if (dtgDocumentos.CurrentCell.OwningColumn.Name.Equals("boton"))
                {
                    int nfilaseleccionada = Convert.ToInt32(this.dtgDocumentos.CurrentRow.Index);
                    int nIdDocInfRiesgo = Convert.ToInt32(dtDocumentos.Rows[nfilaseleccionada]["idSolicitudJudicialDoc"]);
                    if (nIdDocInfRiesgo == 0)
                    {
                        MessageBox.Show("El archivo todavía no se ha guardado", "Solicitud Judicial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    string[] cExtensionArchivo = dtAuxDocs.Rows[nfilaseleccionada]["cNombreArchivo"].ToString().Split('.');
                    string cExtencion = cExtensionArchivo[cExtensionArchivo.Length - 1].ToUpper();

                    if (Convert.ToInt32(dtAuxDocs.Rows[nfilaseleccionada]["idSolicitudJudicialDoc"]) == nIdDocInfRiesgo)
                    {
                        string cDirectorio = String.Format("{0}\\{1}", clsVarGlobal.cRutPathApp, cDirecSolJudicial);
                        string cNombreArchivo = dtAuxDocs.Rows[nfilaseleccionada]["cNombreArchivo"].ToString();
                        if (!Directory.Exists(cDirectorio))
                        {
                            Directory.CreateDirectory(cDirectorio);
                        }

                        string ruta = String.Format("{0}\\{1}", cDirectorio, cNombreArchivo);
                        FileInfo fileInfo = new FileInfo(ruta);
                        File.WriteAllBytes(ruta, (byte[])(this.dtDocumentos.Rows[nfilaseleccionada]["bArchivo"]));
                        frmVisualizarDocRecuperaciones frmVerDoc = new frmVisualizarDocRecuperaciones(cDirectorio, fileInfo.Name, fileInfo.Extension);
                        
                        frmVerDoc.ShowDialog();
                    }
                }
            }
        }

        private bool validar()
        {
            bool lVal = false;

            if (txtCuenta.Text == null || txtCuenta.Text == "")
            //if (dtgSolicitudes.CurrentRow == null)
            {
                MessageBox.Show("Por favor seleccione la cuenta de crédito", "Validación de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }

            if (cboUsuRecuperadores1.Text == "")
            {
                MessageBox.Show("Debe seleccionar al Gestor Legal", "Validación de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }

            lVal = true;
            return lVal;
        }
        private void btnAprobar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                
                DataTable dtResultadoAprob
                = solicitud.AprobarSolicitudJudicial(Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idSolicitudJudicial"].Value),
                                                        Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idCuenta"].Value),
                                                        Convert.ToInt32(cboUsuRecuperadores1.SelectedValue), clsVarGlobal.User.idUsuario,
                                                        Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idEstadoSolJudicial"].Value), 1);

                if (dtResultadoAprob.Rows.Count > 0 && Convert.ToInt32(dtResultadoAprob.Rows[0][0]) == 0)
                {
                    MessageBox.Show("La Aprobación de pase a Judicial se realizo correctamente.", "Aprobacion de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                cargarPendientesAprobaJudicial();
                LimpiarCampos();
                FormatoGridLectura();
                CargarDatosPase();
            }
            
        }
        private bool validarDenegacion()
        {
            bool lVal = false;

            if (txtCuenta.Text == null || txtCuenta.Text == "")
            {
                MessageBox.Show("Por favor seleccione la cuenta de crédito", "Validación de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }

            lVal = true;
            return lVal;
        }
        private void btnDenegar1_Click(object sender, EventArgs e)
        {
            if (validarDenegacion())
            {

                DataTable dtResultadoAprob
                = solicitud.AprobarSolicitudJudicial(Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idSolicitudJudicial"].Value),
                                                        Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idCuenta"].Value),
                                                        Convert.ToInt32(cboUsuRecuperadores1.SelectedValue), clsVarGlobal.User.idUsuario,
                                                        Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idEstadoSolJudicial"].Value), 2);

                if (dtResultadoAprob.Rows.Count > 0 && Convert.ToInt32(dtResultadoAprob.Rows[0][0]) == 0)
                {
                    MessageBox.Show("Se ha denegado la solicitud.", "Aprobacion de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarPendientesAprobaJudicial();
                    LimpiarCampos();
                    FormatoGridLectura();
                    CargarDatosPase();
                }
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            FormatoGridLectura();
        }

    }
}
 