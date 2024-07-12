using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Servicio;
using GEN.CapaNegocio;
using System.IO;
using GEN.Funciones;
using System.Diagnostics;
using ADM.CapaNegocio;
using EntityLayer.SentinelData;
using CRE.CapaNegocio;
using System.Globalization;
using Microsoft.Reporting.WinForms;

namespace CRE.Presentacion
{
    public partial class frmExpedienteLinea : frmBase
    {
        #region Variables
        clsCNIntervCre cninterviniente = new clsCNIntervCre();
        private clsExpedienteLinea clsExpediente = new clsExpedienteLinea();
        private clsLsMenuExpediente lstMenuExpediente = new clsLsMenuExpediente();
        private int idCli = 0, idSolicitud = 0, idCliGrupoSol = 0;
        private string cTipoSolicitud = "individual";
        private int idSolicitudSeleccionado = 0;
        private DataTable dtDatosArchivos;
        private clsLsMenuExpediente lstMenuExp = new clsLsMenuExpediente();
        string cTipoPersona = string.Empty;
        DataTable dtClasificacionCliente = new DataTable();
        ClsCNClienteExclusivo objCE = new ClsCNClienteExclusivo();
        Response objRespuesta;
        List<TitularConyuge> objLisTituConyuge;
        clsApiCentralRsgExterno objCentraRsgExterno = new clsApiCentralRsgExterno();
        GEN.CapaNegocio.clsCNValidaReglasDinamicas ValidaReglasDinamicas = new GEN.CapaNegocio.clsCNValidaReglasDinamicas();
        DataTable dtBasicoSunatTitular;
        DataColumn columnBasicoSunatTitular;
        DataRow rowBasicoSunatTitular;

        Response objRespuestaTitular;
        Response objRespuestaConyuge;

        DataTable dtBasicoSunatConyuge;
        DataColumn columnBasicoSunatConyuge;
        DataRow rowBasicoSunatConyuge;
        DataSet dsContenedorDatoSentinel;

        DataTable dtBSunatDireccionTitular;
        DataColumn columnBSunatDireccionTitular;
        DataRow rowBSunatDireccionTitular;

        DataTable dtBSunatDireccionConyuge;
        DataColumn columnBSunatDireccionConyuge;
        DataRow rowBSunatDireccionConyuge;

        DataTable dtRlegalTitular;
        DataColumn columnRlegalTitular;
        DataRow rowRlegalTitular;

        DataTable dtRlegalConyuge;
        DataColumn columnRlegalConyuge;
        DataRow rowRlegalConyuge;

        DataTable dtlCredNoUtilizadaT;
        DataColumn columnlCredNoUtilizadaT;
        DataRow rowlCredNoUtilizadaT;

        DataTable dtlCredNoUtilizadaC;
        DataColumn columnlCredNoUtilizadaC;
        DataRow rowlCredNoUtilizadaC;

        DataTable dtDeudaTitular;
        DataColumn columnDeudaTitular;
        DataRow rowDeudaTitular;

        DataTable dtDeudaConyuge;
        DataColumn columnDeudaConyuge;
        DataRow rowDeudaConyuge;

        DataTable dtAvalistaTitular;
        DataColumn columnAvalistaTitular;
        DataRow rowAvalistaTitular;

        DataTable dtAvalistaConyuge;
        DataColumn columnAvalistaConyuge;
        DataRow rowAvalistaConyuge;

        DataTable dtAvalado;
        DataColumn columnAvaladoTitular;
        DataRow rowAvaladoTitular;

        DataTable dtAvaladoConyuge;
        DataColumn columnAvaladoConyuge;
        DataRow rowAvaladoConyuge;
        DataTable dtDeudaSentinelDirectaTitular;
        DataTable dtDeudaSentinelDirectaConyuge;

        DataTable dtMicrTitular;
        DataColumn columnMicrTitular;
        DataRow rowMicrTitular;

        DataTable dtMicrConyuge;
        DataColumn columnMicrConyuge;
        DataRow rowMicrConyuge;

        DataTable dtHistorialSentinelTitular;
        DataRow rowHistorialSentinelTitular;
        DataColumn columnHistorialSentinelTitular;

        DataTable dtHistorialSentinelConyuge;
        DataRow rowHistorialSentinelConyuge;
        DataColumn columnHistorialSentinelConyuge;

        DataTable dtClasTitularConyuge;
        DataColumn columnClasTitularConyuge;
        DataRow rowClasTitularConyuge;
        string cSemaforoTitular = string.Empty;
        string cSemaforoConyuge = string.Empty;
        #endregion

        #region Métodos
        public frmExpedienteLinea()
        {
            InitializeComponent();
            pnlTipoReprogramacion.Visible = false;
        }

        public frmExpedienteLinea(int idSolicitud_, int idCliGrupoSol_, string cTipoSolicitud_)
        {
            InitializeComponent();
            cTipoSolicitud = cTipoSolicitud_;
            idSolicitud = idSolicitud_;
            idSolicitudSeleccionado = idSolicitud_;
            idCliGrupoSol = idCliGrupoSol_;
            pnlTipoReprogramacion.Visible = false;
        }

        private void getMenuExpediente(int idSolicitud, string cTipoSolicitud)
        {
            if (conBusCli1.nidTipoPersona == 1)
            {
                cTipoPersona = "N";
            }
            if (conBusCli1.nidTipoPersona == 2 || conBusCli1.nidTipoPersona == 3)
            {
                cTipoPersona = "J";
            }

            DataSet dtMenuExpDatosSolicitud = clsExpediente.getMenuExpediente(idSolicitud, cTipoSolicitud);

            DataTable dtDatosMenu = dtMenuExpDatosSolicitud.Tables[0];

            lstMenuExp.Clear();
            foreach (DataRow item in dtDatosMenu.Rows)
            {
                lstMenuExp.Add(new clsMenuExpediente()
                {
                    idMenu = Convert.ToInt32(item["idMenu"]),
                    cMenu = item["cMenu"].ToString(),
                    idPadre = Convert.ToInt32(item["idPadre"]),
                    idDescTipoDoc = Convert.ToInt32(item["idDescTipoDoc"]),
                    nOrden = Convert.ToInt32(item["nOrden"]),
                    idCategoriaArchivo = Convert.ToInt32(item["idcategoriaArchivo"]),
                    idArchivo = Convert.ToInt32(item["idArchivo"]),
                    cExtension = item["cExtension"].ToString(),
                    idSecundario = Convert.ToInt32(item["idSecundario"])
                });
            }

            this.treeMenuExpediente.Nodes.Clear();
            this.treeMenuExpediente.BeginUpdate();
            agregarNodosMenu();
            expandNodes();
            this.treeMenuExpediente.EndUpdate();
            pnlTipoReprogramacion.Visible = false;

            /*Datos de la Solicitud*/
            DataTable dtDatosSol = dtMenuExpDatosSolicitud.Tables[1];
            if (dtDatosSol.Rows.Count > 0)
            {
                txtSolicitud.Text = dtDatosSol.Rows[0]["idSolicitud"].ToString();
                txtFechaSolicitud.Text = dtDatosSol.Rows[0]["dFechaRegistro"].ToString();
                txtOperacion.Text = dtDatosSol.Rows[0]["cOperacion"].ToString();
                txtProducto.Text = dtDatosSol.Rows[0]["Producto"].ToString();
                txtAsesor.Text = dtDatosSol.Rows[0]["cNombre"].ToString();
                txtTipoCliente.Text = dtDatosSol.Rows[0]["cTipoCli"].ToString();
                lblTipoReprogramacion.Text = dtDatosSol.Rows[0]["cTipoPlanPago"].ToString();
                if (lblTipoReprogramacion.Text != "-" && dtDatosSol.Rows[0]["cOperacion"].ToString() != "RETENCION CON CAMBIO DE TASA")
                {
                    pnlTipoReprogramacion.Visible = true;
                }
            }
            if (pnlReportLocal.Controls.Count > 0)
            {
                pnlReportLocal.Controls.RemoveAt(0);
            }
            pnlImagen.Visible = false;
            pnlPdf.Visible = false;
            pnlIniReportLocal.Visible = true;
        }
        private void getMenuExpedientePolPriv(DataTable dtDatosPoliticaPrivacidadCliente)
        {
            DataTable dtDatosMenu = dtDatosPoliticaPrivacidadCliente;

            lstMenuExp.Clear();
            foreach (DataRow item in dtDatosMenu.Rows)
            {
                lstMenuExp.Add(new clsMenuExpediente()
                {
                    idMenu = Convert.ToInt32(item["idMenu"]),
                    cMenu = item["cDescMenu"].ToString(),
                    idPadre = Convert.ToInt32(item["idPadre"]),
                    idDescTipoDoc = Convert.ToInt32(item["idDescTipoDoc"]),
                    nOrden = Convert.ToInt32(item["nOrden"]),
                    idCategoriaArchivo = Convert.ToInt32(item["idcategoriaArchivo"]),
                    idArchivo = Convert.ToInt32(item["idArchivos"]),
                    cExtension = item["cExtension"].ToString(),
                    idSecundario = Convert.ToInt32(item["idSecundario"])
                });
            }

            this.treeMenuExpediente.Nodes.Clear();
            this.treeMenuExpediente.BeginUpdate();
            agregarNodosMenu();
            expandNodes();
            this.treeMenuExpediente.EndUpdate();
            pnlTipoReprogramacion.Visible = false;

            pnlImagen.Visible = false;
            pnlPdf.Visible = false;
            pnlIniReportLocal.Visible = true;
        }

        private void expandNodes()
        {
            for (int i = 0; i < treeMenuExpediente.Nodes.Count; i++)
            {
                treeMenuExpediente.Nodes[i].Expand();
            }
        }

        private void agregarNodosMenu()
        {
            TreeNode padre;
            TreeNode hijo;
            try
            {
                foreach (var item in lstMenuExp)
                {
                    hijo = new TreeNode();
                    hijo.Tag = item;
                    hijo.ToolTipText = item.idMenu.ToString();
                    hijo.Name = item.idArchivo.ToString();
                    hijo.SelectedImageKey = item.idDescTipoDoc.ToString();
                    hijo.ImageKey = item.idCategoriaArchivo.ToString();
                    hijo.Text = item.cMenu.ToString();
                    hijo.ToolTipText = item.cExtension.ToString();
                    hijo.StateImageKey = item.idSecundario.ToString();

                    padre = buscarPadre(item.idPadre.ToString(), treeMenuExpediente.Nodes);

                    clsMenuExpediente objctactbhijo = (clsMenuExpediente)hijo.Tag;

                    if (padre == null){
                        hijo.NodeFont = new Font("Arial", 9, FontStyle.Bold);
                        this.treeMenuExpediente.Nodes.Add(hijo);
                    }
                    else
                    {
                        clsMenuExpediente objctactb = (clsMenuExpediente)padre.Tag;
                        padre.Nodes.Add(hijo);
                    }
                    padre = null;

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private TreeNode buscarPadre(String NodoBusqueda, TreeNodeCollection nodos)
        {
            TreeNode nodoPadre = null;
            var encontrado = false;
            int ncontador = 0;

            while (encontrado == false && ncontador < nodos.Count)
            {
                if (((clsMenuExpediente)nodos[ncontador].Tag).idMenu == Convert.ToInt32(NodoBusqueda))
                {
                    encontrado = true;
                    nodoPadre = nodos[ncontador];
                }
                else
                {
                    if (nodos[ncontador].Nodes.Count > 0)
                    {
                        nodoPadre = buscarPadre(NodoBusqueda, nodos[ncontador].Nodes);
                        if (nodoPadre != null)
                        {
                            encontrado = true;
                        }
                    }
                }
                ncontador++;
            }
            return nodoPadre;
        }

        private void abrirFormCuentas()
        {
            idCli = conBusCli1.idCli;
            clsCNRetornsCuentaSolCliente RetornaCuentaSolCliente = new clsCNRetornsCuentaSolCliente();
            DataTable dtDatosCuentaSolCliente = RetornaCuentaSolCliente.RetornaCuentaSolCliente(idCli, "T", "[]");

            if (dtDatosCuentaSolCliente.Rows.Count == 0)
            {
                MessageBox.Show("Cliente seleccionado no tiene cuentas en estado vigente", "Validación de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cancelarBusqueda();
                return;
            }
            else
            {
                GEN.ControlesBase.FrmBuscaCuentaCliente frmBusCuenCli = new GEN.ControlesBase.FrmBuscaCuentaCliente();
                frmBusCuenCli.CargarDatos(idCli, "T", "[]");
                frmBusCuenCli.ShowDialog();

                if (Convert.ToInt32(frmBusCuenCli.idSolicitud) != 0) {
                    limpiarDatosSolicitud();
                    idSolicitud = Convert.ToInt32(frmBusCuenCli.idSolicitud);
                }
                
                if (idSolicitud != 0)
                {
                    getMenuExpediente(idSolicitud, cTipoSolicitud);
                    btnMasCuentas.Visible = true;
                    idSolicitudSeleccionado = idSolicitud;
                    this.conBusGrupoSol1.LimpiarControl();
                    this.aplicarAuthObjetoForm();
                }
                else
                {
                    cancelarBusqueda();
                }
            }
        }
        private void buscarPoliticaPrivacidad()
        {
            idCli = conBusCli2.idCli;
            clsCNRetornsCuentaSolCliente RetornaCuentaSolCliente = new clsCNRetornsCuentaSolCliente();

            DataTable dtDatosPoliticaPrivacidadCliente = new DataTable();
            dtDatosPoliticaPrivacidadCliente = RetornaCuentaSolCliente.CNRetornaPoliticaPrivacidadCliente(idCli);

            if (dtDatosPoliticaPrivacidadCliente.Rows.Count == 0)
            {
                MessageBox.Show("Cliente seleccionado no tiene cargado la Política de Privacidad", "Validación de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cancelarBusqueda();
                return;
            }
            else
            {
                getMenuExpedientePolPriv(dtDatosPoliticaPrivacidadCliente);

                }
            }
        private void limpiarDatosSolicitud()
        {
            txtSolicitud.Text = "";
            txtFechaSolicitud.Text = "";
            txtOperacion.Text = "";
            txtProducto.Text = "";
            txtAsesor.Text = "";
            txtTipoCliente.Text = "";
            lblTipoReprogramacion.Text = "-";
        }

        private void cancelarBusqueda()
        {
            pnlTipoReprogramacion.Visible = false;
            conBusCli1.limpiarControles();
            conBusCli2.limpiarControles();
            btnMasCuentas.Visible = false;
            idCli = 0;
            treeMenuExpediente.Nodes.Clear();
            if (pnlReportLocal.Controls.Count > 0)
                pnlReportLocal.Controls.RemoveAt(0);

            pictureImg.Image = null;

            limpiarDatosSolicitud();

            pnlImagen.Visible = false;
            pnlPdf.Visible = false;
            pnlIniReportLocal.Visible = true;

            this.conBusGrupoSol1.LimpiarControl();
        }

        private void abrirFrmSolicitudGrupoSol()
        {
            int idGrupoSol = Convert.ToInt32(conBusGrupoSol1.txtIdGrupoSolidario.Text.ToString());
            frmBuscaSolicitudGrupoSol frmBuscaSol = new frmBuscaSolicitudGrupoSol(idGrupoSol);
            frmBuscaSol.ShowDialog();

            int idSolicitudGrupoSolidario = frmBuscaSol.getSolicitudGrupoSolidario();
            if (idSolicitudGrupoSolidario != 0)
            {
                limpiarDatosSolicitud();
                idSolicitudSeleccionado = idSolicitudGrupoSolidario;
                txtSolicitud.Text = idSolicitudSeleccionado.ToString();
                getMenuExpediente(idSolicitudSeleccionado, cTipoSolicitud);
                btnMasCuentas.Visible = true;
                this.conBusCli1.limpiarControles();
            }
            else
            {
                cancelarBusqueda();
            }

            
        }
        private void aplicarAuthObjetoForm()
        {
            this.btnCargarFile.Visible = false;

            if(this.idSolicitud > 0)
            {
                clsCNAuthObjetoForm objCNAuthObjetoForm = new clsCNAuthObjetoForm();
                DataTable dtAuthObjetoForm = objCNAuthObjetoForm.listarAuthObjetoForm(this.idSolicitud);
                DataRow rowObjetoForm = null;
                try
                {
                    rowObjetoForm = dtAuthObjetoForm.AsEnumerable().First(x => x.Field<string>("cObjeto").Equals("btnCargarFile") && x.Field<bool>("lVisible"));
                }
                catch
                {
                    rowObjetoForm = null;
                };


                if (rowObjetoForm != null && rowObjetoForm != null)
                {
                    this.btnCargarFile.Visible = true;
                }
                else
                {
                    this.btnCargarFile.Visible = false;
                }
            }
        }
        #endregion

        #region Eventos
        private void frmExpedienteLinea_Load(object sender, EventArgs e)
        {
            conBusCli1.limpiarControles();
            btnMasCuentas.Visible = false;
            cancelarBusqueda();
            this.conBusGrupoSol1.txtIdGrupoSolidario.Enabled = true;
            this.conBusGrupoSol1.txtNombreGrupo.Enabled = true;

            dtDatosArchivos = new DataTable();
            dtDatosArchivos.Columns.Add("idArchivo", typeof(System.Int32));
            dtDatosArchivos.Columns.Add("idSolicitud", typeof(System.Int32));
            dtDatosArchivos.Columns.Add("idCategoriaArchivo", typeof(System.Int32));
            dtDatosArchivos.Columns.Add("cTipoSolicitud", typeof(System.String));
            dtDatosArchivos.Columns.Add("sFile", typeof(System.String));
            dtDatosArchivos.Columns.Add("byteFile", typeof(System.Byte[]));
            dtDatosArchivos.Columns.Add("idSecundario", typeof(System.Int32));

            if (idSolicitudSeleccionado != 0)
            {
                if (cTipoSolicitud == "individual")
                {
                    conBusCli1.CargardatosCli(idCliGrupoSol);
                    tabControl1.SelectedIndex = 0;
                }
                else
                {
                    this.conBusGrupoSol1.ObtenerSolCredGrupoSolidario(idCliGrupoSol);
                    tabControl1.SelectedIndex = 1;
                }
                getMenuExpediente(idSolicitudSeleccionado, cTipoSolicitud);
                btnMasCuentas.Visible = true;
            }

            InicializarTablaSentinel();

            this.aplicarAuthObjetoForm();  
        }
        public void CreaTablaBasicoSunatTitular()
        {

            dtBasicoSunatTitular = new DataTable("dtBasicoSunatTitular");
            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "TDoc";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "NDoc";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "RelTDoc";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "RelNDOC";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "RazSoc";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "NomCom";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "TipCon";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "IniAct";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "ActEco";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "FchInsRRPP";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "AgeRet";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "ApePat";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "ApeMat";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "Nom";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "Sex";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "EstCon";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "EstDom";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "EstDomic";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "CondDomic";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

        }
        public void CreaTablaBasicoSunatConyuge()
        {

            dtBasicoSunatConyuge = new DataTable("dtBasicoSunatConyuge");
            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "TDoc";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "NDoc";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "RelTDoc";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "RelNDOC";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "RazSoc";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "NomCom";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "TipCon";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "IniAct";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "ActEco";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "FchInsRRPP";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "AgeRet";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "ApePat";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "ApeMat";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "Nom";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "Sex";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "EstCon";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "EstDom";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "EstDomic";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "CondDomic";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

        }
        public void CreaTablaBSunatDireccionTitular()
        {

            dtBSunatDireccionTitular = new DataTable("dtBSunatDireccionTitular");
            columnBSunatDireccionTitular = new DataColumn();
            columnBSunatDireccionTitular.DataType = System.Type.GetType("System.String");
            columnBSunatDireccionTitular.ColumnName = "Direccion";
            dtBSunatDireccionTitular.Columns.Add(columnBSunatDireccionTitular);

            columnBSunatDireccionTitular = new DataColumn();
            columnBSunatDireccionTitular.DataType = System.Type.GetType("System.String");
            columnBSunatDireccionTitular.ColumnName = "Fuente";
            dtBSunatDireccionTitular.Columns.Add(columnBSunatDireccionTitular);

        }
        public void CreaTablaBSunatDireccionConyuge()
        {

            dtBSunatDireccionConyuge = new DataTable("dtBSunatDireccionConyuge");
            columnBSunatDireccionConyuge = new DataColumn();
            columnBSunatDireccionConyuge.DataType = System.Type.GetType("System.String");
            columnBSunatDireccionConyuge.ColumnName = "Direccion";
            dtBSunatDireccionConyuge.Columns.Add(columnBSunatDireccionConyuge);

            columnBSunatDireccionConyuge = new DataColumn();
            columnBSunatDireccionConyuge.DataType = System.Type.GetType("System.String");
            columnBSunatDireccionConyuge.ColumnName = "Fuente";
            dtBSunatDireccionConyuge.Columns.Add(columnBSunatDireccionConyuge);

        }
        public void CreaTablaRLegalTitular()
        {
            dtRlegalTitular = new DataTable("dtRlegalTitular");
            columnRlegalTitular = new DataColumn();
            columnRlegalTitular.DataType = System.Type.GetType("System.String");
            columnRlegalTitular.ColumnName = "TDOC";
            dtRlegalTitular.Columns.Add(columnRlegalTitular);

            columnRlegalTitular = new DataColumn();
            columnRlegalTitular.DataType = System.Type.GetType("System.String");
            columnRlegalTitular.ColumnName = "NDOC";
            dtRlegalTitular.Columns.Add(columnRlegalTitular);

            columnRlegalTitular = new DataColumn();
            columnRlegalTitular.DataType = System.Type.GetType("System.String");
            columnRlegalTitular.ColumnName = "Nombre";
            dtRlegalTitular.Columns.Add(columnRlegalTitular);

            columnRlegalTitular = new DataColumn();
            columnRlegalTitular.DataType = System.Type.GetType("System.String");
            columnRlegalTitular.ColumnName = "FecIniCar";
            dtRlegalTitular.Columns.Add(columnRlegalTitular);

            columnRlegalTitular = new DataColumn();
            columnRlegalTitular.DataType = System.Type.GetType("System.String");
            columnRlegalTitular.ColumnName = "Cargo";
            dtRlegalTitular.Columns.Add(columnRlegalTitular);
        }
        public void CreaTablaRLegalConyuge()
        {
            dtRlegalConyuge = new DataTable("dtRlegalConyuge");
            columnRlegalConyuge = new DataColumn();
            columnRlegalConyuge.DataType = System.Type.GetType("System.String");
            columnRlegalConyuge.ColumnName = "TDOC";
            dtRlegalConyuge.Columns.Add(columnRlegalConyuge);

            columnRlegalConyuge = new DataColumn();
            columnRlegalConyuge.DataType = System.Type.GetType("System.String");
            columnRlegalConyuge.ColumnName = "NDOC";
            dtRlegalConyuge.Columns.Add(columnRlegalConyuge);

            columnRlegalConyuge = new DataColumn();
            columnRlegalConyuge.DataType = System.Type.GetType("System.String");
            columnRlegalConyuge.ColumnName = "Nombre";
            dtRlegalConyuge.Columns.Add(columnRlegalConyuge);

            columnRlegalConyuge = new DataColumn();
            columnRlegalConyuge.DataType = System.Type.GetType("System.String");
            columnRlegalConyuge.ColumnName = "FecIniCar";
            dtRlegalConyuge.Columns.Add(columnRlegalConyuge);

            columnRlegalConyuge = new DataColumn();
            columnRlegalConyuge.DataType = System.Type.GetType("System.String");
            columnRlegalConyuge.ColumnName = "Cargo";
            dtRlegalConyuge.Columns.Add(columnRlegalConyuge);
        }
        public void CreaTablalCredNoUtilTitular()
        {

            dtlCredNoUtilizadaT = new DataTable("dtlCredNoUtilizadaT");
            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "Condicion";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);

            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "Inst";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);

            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "LinApr";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);

            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "LinNoUti";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);

            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "LinUti";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);

            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "TipCred";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);
        }
        public void CreaTablalCredNoUtilConyuge()
        {

            dtlCredNoUtilizadaC = new DataTable("dtlCredNoUtilizadaC");
            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "Condicion";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);

            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "Inst";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);

            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "LinApr";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);

            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "LinNoUti";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);

            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "LinUti";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);

            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "TipCred";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);
        }
        public void CreaTablaDeudaTitular()
        {
            dtDeudaTitular = new DataTable("dtDeudaTitular");

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "Condicion";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.Int32");
            columnDeudaTitular.ColumnName = "idFue";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "MaxDiaVen";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "NomFue";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "VenTot";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "NomEnt";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "MontDeu";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);


            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "DiaVen";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "NumDoc";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

        }
        public void CreaTablaDeudaConyuge()
        {
            dtDeudaConyuge = new DataTable("dtDeudaConyuge");

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "Condicion";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.Int32");
            columnDeudaConyuge.ColumnName = "idFue";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "MaxDiaVen";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "NomFue";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "VenTot";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "NomEnt";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "MontDeu";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);


            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "DiaVen";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "NumDoc";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);
        }
        public void CreaTablaAvalistaTitular()
        {
            dtAvalistaTitular = new DataTable("dtAvalistaTitular");

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "Condicion";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "NDoc";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "RazSoc";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "Sem12Mes";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "SemAct";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "SemPre";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "NDocAcre";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "RazSocAcre";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "Cal";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "SalDeu";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "TipEnt";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "FecRep";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

        }
        public void CreaTablaAvalistaConyuge()
        {
            dtAvalistaConyuge = new DataTable("dtAvalistaConyuge");

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "Condicion";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "NDoc";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "RazSoc";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "Sem12Mes";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "SemAct";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "SemPre";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "NDocAcre";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "RazSocAcre";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "Cal";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "SalDeu";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "TipEnt";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "FecRep";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);


        }
        public void CreaTablaAvaladoTitular()
        {
            ///Crea Tabla Avalado Titular
            dtAvalado = new DataTable("dtAvalado");

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "Condicion";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "ndoc";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "tDoc";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "razSoc";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "semAct";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "Sem12Mes";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "tDocAcre";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "nDocAcre";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "razSocAcre";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "cal";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "tipEnt";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "salDeu";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "fecRep";
            dtAvalado.Columns.Add(columnAvaladoTitular);


        }
        public void CreaTablaAvaladoConyuge()
        {
            dtAvaladoConyuge = new DataTable("dtAvaladoConyuge");

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "Condicion";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "ndoc";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "tDoc";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "razSoc";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "semAct";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "Sem12Mes";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "tDocAcre";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "nDocAcre";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "razSocAcre";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "cal";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "tipEnt";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "salDeu";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "fecRep";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

        }
        public void CreaTablaMicrofinanzasTitular()
        {
            dtMicrTitular = new DataTable("dtMicrTitular");

            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "Condicion";
            dtMicrTitular.Columns.Add(columnMicrTitular);

            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "NomEnt";
            dtMicrTitular.Columns.Add(columnMicrTitular);

            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "Cal";
            dtMicrTitular.Columns.Add(columnMicrTitular);


            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "SalDeu";
            dtMicrTitular.Columns.Add(columnMicrTitular);


            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.Int32");
            columnMicrTitular.ColumnName = "DiaVen";
            dtMicrTitular.Columns.Add(columnMicrTitular);


            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "FchPro";
            dtMicrTitular.Columns.Add(columnMicrTitular);


            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "FchRep";
            dtMicrTitular.Columns.Add(columnMicrTitular);
            
            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "FchProNumero";
            dtMicrTitular.Columns.Add(columnMicrTitular);

            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "DeudaTotal";
            dtMicrTitular.Columns.Add(columnMicrTitular);

        }
        public void CreaTablaMicrofinanzasConyuge()
        {
            dtMicrConyuge = new DataTable("dtMicrConyuge");

            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "Condicion";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);

            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "NomEnt";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);


            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "Cal";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);


            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "SalDeu";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);


            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.Int32");
            columnMicrConyuge.ColumnName = "DiaVen";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);


            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "FchPro";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);


            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "FchRep";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);
            
            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "FchProNumero";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);

            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "DeudaTotal";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);
        }
        public void CreaTablaHistorialSentinelTitular()
        {
            dtHistorialSentinelTitular = new DataTable("dtHistorialSentinelTitular");

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "FechPro";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "SemaActual";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.Int32");
            columnHistorialSentinelTitular.ColumnName = "NroEntidad";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);


            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "DeudaTotal";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);


            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "Calificacion";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);
            
            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajeNOR";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajeCPP";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajeDEF";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajeDUD";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajePER";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajeSCAL";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "FchProNumero";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);
            
        }
        public void CreaTablaHistorialSentinelConyuge()
        {
            dtHistorialSentinelConyuge = new DataTable("dtHistorialSentinelConyuge");

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "FechPro";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "SemaActual";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.Int32");
            columnHistorialSentinelConyuge.ColumnName = "NroEntidad";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "DeudaTotal";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "Calificacion";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);
            
            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajeNOR";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajeCPP";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajeDEF";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajeDUD";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajePER";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajeSCAL";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "FchProNumero";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);
            
        }
        public void CreaTablaClasificacionCliente()
        {

            dtClasTitularConyuge = new DataTable("dtClasTitularConyuge");
            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cCondicion";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.Int32");
            columnClasTitularConyuge.ColumnName = "idTipoDocumento";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "ctipoDocumento";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cnombre";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cNumDocumento";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.Int32");
            columnClasTitularConyuge.ColumnName = "idCli";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cCalificacion";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cEstadoCivil";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cEdad";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cRelNDoc";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cTipoCliente";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool lFlag = true;
            if (this.tabControl1.SelectedIndex == 0)
            {
                cTipoSolicitud = "individual";
                if (this.conBusCli1.txtCodCli.Text == "")
                    lFlag = false;
                btnMostrarVoucher.Visible = true;
                lblMostrarVoucher.Visible = true;
            }
            else
            {
                cTipoSolicitud = "grupal";
                if (this.conBusGrupoSol1.txtIdGrupoSolidario.Text == "")
                    lFlag = false;
                btnMostrarVoucher.Visible = false;
                lblMostrarVoucher.Visible = false;
            }

            btnMasCuentas.Visible = lFlag;
        }

        private int posicionArchivoTmp(int idArchivo, int idSolicitud, int idCategoriaArchivo, string cTipoSolicitud, int idSecundario)
        {
            int pos = -1;
            bool lEncontrado = false;
            if (dtDatosArchivos != null)
            {
                foreach (DataRow dr in dtDatosArchivos.Rows)
                {
                    pos++;
                    if (Convert.ToInt32(dr["idArchivo"]) == idArchivo && Convert.ToInt32(dr["idSolicitud"]) == idSolicitud
                        && Convert.ToInt32(dr["idCategoriaArchivo"]) == idCategoriaArchivo && Convert.ToString(dr["cTipoSolicitud"]) == cTipoSolicitud
                        && Convert.ToInt32(dr["idSecundario"]) == idSecundario)
                    {
                        lEncontrado = true;
                        break;
                    }
                }

                if (lEncontrado)
                {
                    return pos;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        private void mostrarPDF( byte[] bits, string sFile)
        {
            pnlImagen.Visible = false;
            pnlIniReportLocal.Visible = false;
            pnlPdf.Visible = true;

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

        private void treeMenuExpediente_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node.Text.Contains("Solicitud y Aprobación de Tasa Negociable"))
                {
                    pnlImagen.Visible = false;
                    pnlPdf.Visible = false;
                    pnlIniReportLocal.Visible = true;
                    pnlReportLocal.Controls.Clear();

                    bool lRetencion = false;
                    if (txtOperacion.Text.Contains("RETENCION"))
                    {
                        lRetencion = true;
                    }

                    int idSolicitud = idSolicitudSeleccionado;
                    clsCNSolicitud cnsolicitud = new clsCNSolicitud();
                    var datocre = cnsolicitud.CNObtenerRepoTasaNegociable(idSolicitud, lRetencion);

                    int idUsuario = 0, idAgencia = 0, idZonaUsuario = 0, idTipoSolTasaDesembolso = 0;
                    if (datocre.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(datocre.Rows[0]["idEstado"]) == 4)
                        {
                            MessageBox.Show("Solicitud de Tasa fue DENEGADO.", "Solicitud Tasa Negociada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        idUsuario = Convert.ToInt32(datocre.Rows[0]["idUsuReg"]);
                        idAgencia = Convert.ToInt32(datocre.Rows[0]["idAgencia"]);
                        DataTable dtZonaUsuario = cnsolicitud.CNObtenerZonaUsuario(idUsuario);
                        if (dtZonaUsuario.Rows.Count > 0)
                        {
                            idZonaUsuario = Convert.ToInt32(dtZonaUsuario.Rows[0]["idZona"]);
                        }
                        idTipoSolTasaDesembolso = Convert.ToInt32(datocre.Rows[0]["idTipoSolTasaDesembolso"]);
                    }
                    else
                    {
                        MessageBox.Show("No existen datos", "Solicitud Tasa Negociada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var datosinterv = cnsolicitud.CNMostrarTasaPromedioPonderada(clsVarGlobal.dFecSystem, idAgencia, idZonaUsuario, idUsuario);
                    var eventos = cnsolicitud.CNObtenerRastreoTasaNegociableRepo(idSolicitud, idTipoSolTasaDesembolso); //1: Pre Desembolso 2:Post desembolso

                    if (datocre.Rows.Count > 0)
                    {
                        List<ReportDataSource> dtsList = new List<ReportDataSource>();
                        dtsList.Add(new ReportDataSource("dsDatoCreTrans", datocre));
                        dtsList.Add(new ReportDataSource("dsDato_b", datosinterv));
                        dtsList.Add(new ReportDataSource("dsDato_c", eventos));

                        List<ReportParameter> paramList = new List<ReportParameter>();
                        paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                        paramList.Add(new ReportParameter("idCuenta", idSolicitud.ToString(), false));
                        paramList.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
                        paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                        if (idTipoSolTasaDesembolso == 1)
                        {
                            paramList.Add(new ReportParameter("cTituloRepo", "ACTA DE RESOLUCIÓN DE TEA NEGOCIABLE", false));
                        }
                        else if (idTipoSolTasaDesembolso == 2)
                        {
                            paramList.Add(new ReportParameter("cTituloRepo", "ACTA DE SOLICITUD Y APROBACIÓN DE TASA NEGOCIABLE", false));
                        }

                        string reportPath = "rptReporteSolicitudTasaNegociada.rdlc";
                        frmReporteLocal frmReporteExpediente = new frmReporteLocal(dtsList, reportPath, paramList);
                        frmReporteExpediente.TopLevel = false;
                        frmReporteExpediente.lEsExpedienteVirtual2 = true;
                        Cursor.Current = Cursors.Default;
                        frmReporteExpediente.TopLevel = false;
                        frmReporteExpediente.Dock = DockStyle.Fill;
                        frmReporteExpediente.rpvReporteLocal.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
                        frmReporteExpediente.AutoSizeMode = AutoSizeMode.GrowOnly;
                        frmReporteExpediente.ControlBox = false;
                        frmReporteExpediente.ShowIcon = false;
                        frmReporteExpediente.AutoSize = true;
                        frmReporteExpediente.BringToFront();
                        pnlReportLocal.Controls.Add(frmReporteExpediente);
                        pnlReportLocal.Tag = frmReporteExpediente;
                        frmReporteExpediente.Show();
                    }
                    else
                    {
                        MessageBox.Show("No existen datos", "Solicitud Tasa Negociada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    return;
                }

                if (Convert.ToInt32(e.Node.ImageKey) != 0)
                {
                    frmReporteLocal frmReporteExpediente;
                    if (pnlReportLocal.Controls.Count > 0)
                    {
                        pnlReportLocal.Controls.RemoveAt(0);
                    }
                    pnlReportLocal.Controls.Clear();
                    if (Convert.ToInt32(e.Node.Name) != 0)
                    {
                        byte[] bits = new byte[0];
                        DataSet dtsExpediente = new DataSet();
                        DataTable dsDatoExpediente = new DataTable();
                        int pos = posicionArchivoTmp(Convert.ToInt32(e.Node.Name), idSolicitudSeleccionado, Convert.ToInt32(e.Node.ImageKey), cTipoSolicitud, Convert.ToInt32(e.Node.StateImageKey));
                        if (pos >= 0)
                        {
                            mostrarPDF((byte[])dtDatosArchivos.Rows[pos]["byteFile"], (string)dtDatosArchivos.Rows[pos]["sFile"]);
                        }
                        else
                        {
                            dtsExpediente = clsExpediente.obtenerExpediente(Convert.ToInt32(e.Node.Name), idSolicitudSeleccionado, Convert.ToInt32(e.Node.ImageKey), cTipoSolicitud, e.Node.ToolTipText, Convert.ToInt32(e.Node.StateImageKey));
                            dsDatoExpediente = dtsExpediente.Tables[0];


                            /*  Construir Archivos Cargados en PDF */
                            if ((dsDatoExpediente.Rows[0]["cFormato"].ToString() == "binary" || dsDatoExpediente.Rows[0]["cFormato"].ToString() == "base64") && dsDatoExpediente.Rows[0]["cExtension"].ToString() == ".pdf")
                            {
                                if (dsDatoExpediente.Rows[0]["cFormato"].ToString() == "base64")
                                {
                                    string str = dsDatoExpediente.Rows[0]["vBase64"].ToString();
                                    bits = Convert.FromBase64String(str);
                                }
                                else if (dsDatoExpediente.Rows[0]["cFormato"].ToString() == "binary")
                                {
                                    if (Convert.ToBoolean(dsDatoExpediente.Rows[0]["lComprimido"]))
                                    {
                                        bits = Compresion.DescompressedByte((byte[])dsDatoExpediente.Rows[0]["bArchivoBinary"]);
                                    }
                                    else
                                    {
                                        bits = (byte[])dsDatoExpediente.Rows[0]["bArchivoBinary"];
                                    }
                                }

                                string sFile = dsDatoExpediente.Rows[0]["cArchivo"].ToString() + "-" + clsVarGlobal.User.idUsuario.ToString() + dsDatoExpediente.Rows[0]["cExtension"].ToString();

                                DataRow dr = dtDatosArchivos.NewRow();
                                dr["idArchivo"] = Convert.ToInt32(e.Node.Name);
                                dr["idSolicitud"] = idSolicitudSeleccionado;
                                dr["idCategoriaArchivo"] = Convert.ToInt32(e.Node.ImageKey);
                                dr["cTipoSolicitud"] = cTipoSolicitud;
                                dr["sFile"] = sFile;
                                dr["byteFile"] = bits;
                                dr["idSecundario"] = Convert.ToInt32(e.Node.StateImageKey);
                                dtDatosArchivos.Rows.Add(dr);
                                mostrarPDF(bits, sFile);
                            }
                            /*  Construir RDLC  */
                            else if (dsDatoExpediente.Rows[0]["cFormato"].ToString() == "xml" && dsDatoExpediente.Rows[0]["cExtension"].ToString() == ".rdlc")
                            {
                                pnlImagen.Visible = false;
                                pnlIniReportLocal.Visible = true;
                                pnlPdf.Visible = false;

                                if (txtOperacion.Text.Contains("RETENCION"))
                                {
                                    DataRow newRow = dtsExpediente.Tables[2].NewRow();
                                    newRow["idExpediente"] = 25;
                                    newRow["cParametro"] = "cTitulo";
                                    newRow["cClave"] = "cTipoEval";
                                    dtsExpediente.Tables[2].Rows.Add(newRow);
                                }

                                frmReporteExpediente = clsExpediente.getReportLocal(
                                    /*dsDatoExpediente =>*/dtsExpediente.Tables[0],
                                    /*dsDataSets =>*/dtsExpediente.Tables[1],
                                    /*dsParameters =>*/dtsExpediente.Tables[2],
                                    /*dsClaves =>*/dtsExpediente.Tables[3]);
                                pnlReportLocal.Controls.Add(frmReporteExpediente);
                                pnlReportLocal.Tag = frmReporteExpediente;
                                frmReporteExpediente.Show();
                            }
                            /*  Construir Visita - Imagen  */
                            else if (dsDatoExpediente.Rows[0]["cFormato"].ToString() == "base64" && dsDatoExpediente.Rows[0]["cExtension"].ToString() == ".jpg")
                            {
                                StringEncryptorDecryptor stringEncriptor = new StringEncryptorDecryptor();
                                string idVisita = stringEncriptor.encryptString(Convert.ToString(e.Node.Name), true);

                                try
                                {
                                    Process browser = new Process();
                                    browser.StartInfo.Arguments = "--incognito --app=" + clsVarApl.dicVarGen["cUrlDetVisita"].ToString() + idVisita + "";
                                    browser.StartInfo.FileName = "chrome.exe";
                                    browser.Start();

                                }
                                catch (Exception exp)
                                {
                                    MessageBox.Show("No se encontró Navegador Chrome, favor de instalar..", "Detalle de Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Formato de archivo incompatible, no se puede mostrar el archivo.", "Mostrar Expediente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                    else if (e.Node.Parent.Text == "Posición consolidada Cliente" && (e.Node.Text == "(R) TITULAR (" + conBusCli1.txtNroDoc.Text + ") " || e.Node.ToolTipText == ".rdlc"))
                    {
                        InicializarTablaSentinel();
                        DataTable dResultado = new DataTable();
                        dResultado = ValidaReglasDinamicas.ValidarReglasCondiciones(ArmarTablaParametros(), "frmPosConCliente", cTipoPersona);
                        SentinelConsulta(cTipoPersona, Convert.ToInt32(e.Node.StateImageKey));
                        pnlImagen.Visible = false;
                        pnlIniReportLocal.Visible = true;
                        pnlPdf.Visible = false;

                        frmReporteExpediente = clsExpediente.getReportLocalExpedienteNormalJC(Convert.ToInt32(e.Node.SelectedImageKey), idSolicitudSeleccionado, cTipoSolicitud, Convert.ToInt32(e.Node.StateImageKey), GeneraResumenCondiciones(dResultado), dsContenedorDatoSentinel);
                        pnlReportLocal.Controls.Add(frmReporteExpediente);
                        pnlReportLocal.Tag = frmReporteExpediente;
                        frmReporteExpediente.Show();


                    }
                    else
                    {
                        pnlImagen.Visible = false;
                        pnlIniReportLocal.Visible = true;
                        pnlPdf.Visible = false;

                        frmReporteExpediente = clsExpediente.getReportLocalExpedienteNormal(Convert.ToInt32(e.Node.SelectedImageKey), idSolicitudSeleccionado, cTipoSolicitud, Convert.ToInt32(e.Node.StateImageKey));
                        pnlReportLocal.Controls.Add(frmReporteExpediente);
                        pnlReportLocal.Tag = frmReporteExpediente;
                        frmReporteExpediente.Show();
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("" + exc.Message + " - " + exc.InnerException, "Mostrar Expediente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            abrirFormCuentas();

        }

        public void SentinelConsulta(string TipoPErsona, int idCliente)
        {
            dsContenedorDatoSentinel = new DataSet();
   
            if (this.conBusCli1.txtCodCli.Text != string.Empty)
            {
                DataTable dRastreo = new DataTable();

                dRastreo = cninterviniente.CNdtLstRastreoPosicionConsolidada(conBusCli1.txtNroDoc.Text);
                dRastreo.TableName = "dtRastreo";

                dsContenedorDatoSentinel.Tables.Add(dRastreo.Copy());
                GEN.CapaNegocio.clsCNBuscarCli listarCli = new GEN.CapaNegocio.clsCNBuscarCli();
                DataTable tablaCli = listarCli.ListarclixIdCli(idCliente);

                int idTipoDocumento = Convert.ToInt32(tablaCli.Rows[0]["idTipoDocumento"]);
                string cDocumentoID  = Convert.ToString(tablaCli.Rows[0]["cDocumentoID"]);
                int idTipoPersona = Convert.ToInt32(tablaCli.Rows[0]["IdTipoPersona"]);
                TipoPErsona = (idTipoPersona.In(2,3)) ? "J" : "N" ;
                objLisTituConyuge = new List<TitularConyuge>();
                //Clasificacion Cliente
                dtClasificacionCliente = objCE.CNObtenerClasificacionTitularConyuge(cDocumentoID, idTipoDocumento);
                for (int i = 0; i < dtClasificacionCliente.Rows.Count; i++)
                {
                    TitularConyuge modelTituConyuge = new TitularConyuge();
                    modelTituConyuge.cCondicion = dtClasificacionCliente.Rows[i]["cCondicion"].ToString();
                    modelTituConyuge.ctipoDocumento = dtClasificacionCliente.Rows[i]["ctipoDocumento"].ToString();
                    modelTituConyuge.cnombre = dtClasificacionCliente.Rows[i]["cnombre"].ToString();
                    modelTituConyuge.cNumDocumento = dtClasificacionCliente.Rows[i]["cNumDocumento"].ToString();
                    modelTituConyuge.idCli = Convert.ToInt32(dtClasificacionCliente.Rows[i]["idCli"].ToString());
                    modelTituConyuge.cCalificacion = dtClasificacionCliente.Rows[i]["cCalificacion"].ToString();
                    modelTituConyuge.cEstadoCivil = dtClasificacionCliente.Rows[i]["cEstadoCivil"].ToString();
                    modelTituConyuge.cEdad = dtClasificacionCliente.Rows[i]["cEdad"].ToString();
                    modelTituConyuge.cTipoCliente = dtClasificacionCliente.Rows[i]["cTipoCliente"].ToString();
                    modelTituConyuge.idTipoDocumento = Convert.ToInt32(dtClasificacionCliente.Rows[i]["idTipoDocumento"].ToString());

                 
                    if (TipoPErsona == "N")
                    {
                        objRespuesta = objCentraRsgExterno.ConsultaClienteExterno(clsVarGlobal.User.idUsuario, dtClasificacionCliente.Rows[i]["cNumDocumento"].ToString(), "D");
                        if (objRespuesta.Data.Count > 0)
                        {
                            DatosBasicoSunat(objRespuesta.Data[0].InfBas, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            modelTituConyuge.cRelNDoc = (objRespuesta.Data[0].InfBas == null) ? String.Empty : objRespuesta.Data[0].InfBas.RelNDoc;
                            DatosBasicoSunatDireccion(objRespuesta.Data[0].InfGen.Direcc, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosBasicoSunatRLegal(objRespuesta.Data[0].InfGen.EsRepLegDe, objRespuesta.Data[0].InfGen.RepLeg, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosBasicoLineaCredito(objRespuesta.Data[0].ConRap.UtiLinCre, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosDeudaProtesto(objRespuesta.Data[0].ConRap.DetVen, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosAvalista(objRespuesta.Data[0].AvalCod.AvalDe, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosAvalado(objRespuesta.Data[0].AvalCod.QuiAval, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosDeudaDirecta(objRespuesta.Data[0].ConRap.DetSBSMicr, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                        }

                        if (dtClasificacionCliente.Rows[i]["cCondicion"].ToString() == "Titular")
                        {
                            objRespuestaTitular = objRespuesta;
                        }
                        else
                        {
                            objRespuestaConyuge = objRespuesta;
                        }
                    }

                    if (TipoPErsona == "J")
                    {
                        objRespuesta = objCentraRsgExterno.ConsultaClienteExterno(clsVarGlobal.User.idUsuario, dtClasificacionCliente.Rows[i]["cNumDocumento"].ToString(), "R");
                        if (objRespuesta.Data.Count > 0)
                        {
                            DatosBasicoSunat(objRespuesta.Data[0].InfBas, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosBasicoSunatDireccion(objRespuesta.Data[0].InfGen.Direcc, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosBasicoSunatRLegal(objRespuesta.Data[0].InfGen.EsRepLegDe, objRespuesta.Data[0].InfGen.RepLeg, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosBasicoLineaCredito(objRespuesta.Data[0].ConRap.UtiLinCre, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosDeudaProtesto(objRespuesta.Data[0].ConRap.DetVen, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosAvalista(objRespuesta.Data[0].AvalCod.AvalDe, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosAvalado(objRespuesta.Data[0].AvalCod.QuiAval, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosDeudaDirecta(objRespuesta.Data[0].ConRap.DetSBSMicr, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                        }

                        if (dtClasificacionCliente.Rows[i]["cCondicion"].ToString() == "Titular")
                        {
                            objRespuestaTitular = objRespuesta;
                    }
                    }
                    if (objRespuesta.Data.Count == 0)
                    {
                        MessageBox.Show("Existe caida del Servicio Sentinel, Comunicarse con el departamento de sistemas", "Sentinel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        modelTituConyuge.PuntajeScore = "";
                        modelTituConyuge.nRiesgo = "";
                        modelTituConyuge.CapacidadPago = "";
                        modelTituConyuge.cRelNDoc = "";
                        objLisTituConyuge.Add(modelTituConyuge);

                        dtClasTitularConyuge.Clear();
                        for (int j = 0; j < objLisTituConyuge.Count; j++)
                        {
                            DataRow rowClasTitularConyuge = dtClasTitularConyuge.NewRow();

                            rowClasTitularConyuge["cCondicion"] = objLisTituConyuge[j].cCondicion;
                            rowClasTitularConyuge["idTipoDocumento"] = Convert.ToInt32(objLisTituConyuge[j].idTipoDocumento);
                            rowClasTitularConyuge["ctipoDocumento"] = objLisTituConyuge[j].ctipoDocumento;
                            rowClasTitularConyuge["cnombre"] = objLisTituConyuge[j].cnombre;
                            rowClasTitularConyuge["cNumDocumento"] = objLisTituConyuge[j].cNumDocumento;
                            rowClasTitularConyuge["idCli"] = Convert.ToInt32(objLisTituConyuge[j].idCli);
                            rowClasTitularConyuge["cCalificacion"] = objLisTituConyuge[j].cCalificacion;
                            rowClasTitularConyuge["cEstadoCivil"] = objLisTituConyuge[j].cEstadoCivil;
                            rowClasTitularConyuge["cEdad"] = objLisTituConyuge[j].cEdad;
                            rowClasTitularConyuge["cRelNDoc"] = objLisTituConyuge[j].cRelNDoc;
                            rowClasTitularConyuge["cTipoCliente"] = objLisTituConyuge[j].cTipoCliente;

                            dtClasTitularConyuge.Rows.Add(rowClasTitularConyuge);
                        }

                        dsContenedorDatoSentinel.Tables.Add(dtBasicoSunatTitular.Copy());
                        dsContenedorDatoSentinel.Tables.Add(dtBasicoSunatConyuge.Copy());
                        dsContenedorDatoSentinel.Tables.Add(dtBSunatDireccionTitular.Copy());
                        dsContenedorDatoSentinel.Tables.Add(dtBSunatDireccionConyuge.Copy());
                        dsContenedorDatoSentinel.Tables.Add(dtRlegalTitular.Copy());
                        dsContenedorDatoSentinel.Tables.Add(dtRlegalConyuge.Copy());
                        dsContenedorDatoSentinel.Tables.Add(dtClasTitularConyuge.Copy());
                        dsContenedorDatoSentinel.Tables.Add(dtMicrTitular.Copy());
                        dsContenedorDatoSentinel.Tables.Add(dtMicrConyuge.Copy());
                        DataTable dtCombinedDeudaSentinelVacio = new DataTable("dtDeudaSentinelDirectaTitular");
                        if (dtDeudaSentinelDirectaTitular != null)
                        {
                            dtCombinedDeudaSentinelVacio = dtDeudaSentinelDirectaTitular.Copy();
                        }

                        if (dtDeudaSentinelDirectaConyuge != null)
                        {
                            dtCombinedDeudaSentinelVacio.Merge(dtDeudaSentinelDirectaConyuge);
                        }

                        dsContenedorDatoSentinel.Tables.Add(dtCombinedDeudaSentinelVacio.Copy());

                        DataTable dtCombinedLineaCreditoSentinelVacio = new DataTable("dtlCredNoUtilizadaT");
                        if (dtlCredNoUtilizadaT != null)
                        {
                            dtCombinedLineaCreditoSentinelVacio = dtlCredNoUtilizadaT.Copy();
                        }
                        if (dtlCredNoUtilizadaC != null)
                        {
                            dtCombinedLineaCreditoSentinelVacio.Merge(dtlCredNoUtilizadaC);
                        }

                        dsContenedorDatoSentinel.Tables.Add(dtCombinedLineaCreditoSentinelVacio.Copy());

                        DataTable dtCombinedVencidoSentinelVacio = new DataTable("dtDeudaTitular");
                        if (dtDeudaTitular != null)
                        {
                            dtCombinedVencidoSentinelVacio = dtDeudaTitular.Copy();
                        }
                        if (dtDeudaConyuge != null)
                        {
                            dtCombinedVencidoSentinelVacio.Merge(dtDeudaConyuge);
                        }
                        dsContenedorDatoSentinel.Tables.Add(dtCombinedVencidoSentinelVacio.Copy());

                        DataTable dtCombinedAvalistaSentinelVacio = new DataTable("dtAvalistaTitular");
                        if (dtAvalistaTitular != null)
                        {
                            dtCombinedAvalistaSentinelVacio = dtAvalistaTitular.Copy();
                        }
                        if (dtAvalistaConyuge != null)
                        {
                            dtCombinedAvalistaSentinelVacio.Merge(dtAvalistaConyuge);
                        }
                        dsContenedorDatoSentinel.Tables.Add(dtCombinedAvalistaSentinelVacio.Copy());

                        DataTable dtCombinedAvaladoSentinelVacio = new DataTable("dtAvalado");
                        if (dtAvalado != null)
                        {
                            dtCombinedAvaladoSentinelVacio = dtAvalado.Copy();
                        }
                        if (dtAvaladoConyuge != null)
                        {
                            dtCombinedAvaladoSentinelVacio.Merge(dtAvaladoConyuge);
                        }
                        dsContenedorDatoSentinel.Tables.Add(dtCombinedAvaladoSentinelVacio.Copy());
                        dsContenedorDatoSentinel.Tables.Add(dtHistorialSentinelTitular.Copy());
                        dsContenedorDatoSentinel.Tables.Add(dtHistorialSentinelConyuge.Copy());
                        return;
                    }
                    objLisTituConyuge.Add(modelTituConyuge);
                }
                dtClasTitularConyuge.Clear();
                for (int i = 0; i < objLisTituConyuge.Count; i++)
                {
                    DataRow rowClasTitularConyuge = dtClasTitularConyuge.NewRow();

                    rowClasTitularConyuge["cCondicion"] = objLisTituConyuge[i].cCondicion;
                    rowClasTitularConyuge["idTipoDocumento"] = Convert.ToInt32(objLisTituConyuge[i].idTipoDocumento);
                    rowClasTitularConyuge["ctipoDocumento"] = objLisTituConyuge[i].ctipoDocumento;
                    rowClasTitularConyuge["cnombre"] = objLisTituConyuge[i].cnombre;
                    rowClasTitularConyuge["cNumDocumento"] = objLisTituConyuge[i].cNumDocumento;
                    rowClasTitularConyuge["idCli"] = Convert.ToInt32(objLisTituConyuge[i].idCli);
                    rowClasTitularConyuge["cCalificacion"] = objLisTituConyuge[i].cCalificacion;
                    rowClasTitularConyuge["cEstadoCivil"] = objLisTituConyuge[i].cEstadoCivil;
                    rowClasTitularConyuge["cEdad"] = objLisTituConyuge[i].cEdad;
                    rowClasTitularConyuge["cRelNDoc"] = objLisTituConyuge[i].cRelNDoc;
                    rowClasTitularConyuge["cTipoCliente"] = objLisTituConyuge[i].cTipoCliente;
                  
                           
                    dtClasTitularConyuge.Rows.Add(rowClasTitularConyuge);
                }

                dsContenedorDatoSentinel.Tables.Add(dtBasicoSunatTitular.Copy());
                dsContenedorDatoSentinel.Tables.Add(dtBasicoSunatConyuge.Copy());
                dsContenedorDatoSentinel.Tables.Add(dtBSunatDireccionTitular.Copy());
                dsContenedorDatoSentinel.Tables.Add(dtBSunatDireccionConyuge.Copy());
                dsContenedorDatoSentinel.Tables.Add(dtRlegalTitular.Copy());
                dsContenedorDatoSentinel.Tables.Add(dtRlegalConyuge.Copy());
                dsContenedorDatoSentinel.Tables.Add(dtClasTitularConyuge.Copy());

                DataTable dtCombinedDeudaSentinel = new DataTable("dtDeudaSentinelDirectaTitular");
                if (dtDeudaSentinelDirectaTitular != null)
                {
                    dtCombinedDeudaSentinel = dtDeudaSentinelDirectaTitular.Copy();
                }

                if (dtDeudaSentinelDirectaConyuge != null)
                {
                    dtCombinedDeudaSentinel.Merge(dtDeudaSentinelDirectaConyuge);
                }

                dsContenedorDatoSentinel.Tables.Add(dtCombinedDeudaSentinel.Copy());

                DataTable dtCombinedLineaCreditoSentinel = new DataTable("dtlCredNoUtilizadaT");
                if (dtlCredNoUtilizadaT != null)
                {
                    dtCombinedLineaCreditoSentinel = dtlCredNoUtilizadaT.Copy();
                }
                if (dtlCredNoUtilizadaC != null)
                {
                    dtCombinedLineaCreditoSentinel.Merge(dtlCredNoUtilizadaC);
                }

                dsContenedorDatoSentinel.Tables.Add(dtCombinedLineaCreditoSentinel.Copy());

                DataTable dtCombinedVencidoSentinel = new DataTable("dtDeudaTitular");
                if (dtDeudaTitular != null)
                {
                    dtCombinedVencidoSentinel = dtDeudaTitular.Copy();
                }
                if (dtDeudaConyuge != null)
                {
                    dtCombinedVencidoSentinel.Merge(dtDeudaConyuge);
                }
                dsContenedorDatoSentinel.Tables.Add(dtCombinedVencidoSentinel.Copy());

                DataTable dtCombinedAvalistaSentinel = new DataTable("dtAvalistaTitular");
                if (dtAvalistaTitular != null)
                {
                    dtCombinedAvalistaSentinel = dtAvalistaTitular.Copy();
                }
                if (dtAvalistaConyuge != null)
                {
                    dtCombinedAvalistaSentinel.Merge(dtAvalistaConyuge);
                }
                dsContenedorDatoSentinel.Tables.Add(dtCombinedAvalistaSentinel.Copy());

                DataTable dtCombinedAvaladoSentinel = new DataTable("dtAvalado");
                if (dtAvalado != null)
                {
                    dtCombinedAvaladoSentinel = dtAvalado.Copy();
                }
                if (dtAvaladoConyuge != null)
                {
                    dtCombinedAvaladoSentinel.Merge(dtAvaladoConyuge);
                }
                dsContenedorDatoSentinel.Tables.Add(dtCombinedAvaladoSentinel.Copy());

                HistoricoSentinel_Titular();
                HistoricoSentinel_Conyuge();

                dsContenedorDatoSentinel.Tables.Add(dtHistorialSentinelTitular.Copy());
                dsContenedorDatoSentinel.Tables.Add(dtHistorialSentinelConyuge.Copy());

                if (objRespuestaTitular.Data != null)
                {
                    foreach (DataSenConBasSBSMicr objDeuda in objRespuestaTitular.Data[0].ConRap.DetSBSMicr)
                    {
                        DateTime dtFechaProc = new DateTime(objDeuda.ano, objDeuda.mes, 1);
                        rowMicrTitular = dtMicrTitular.NewRow();
                        rowMicrTitular["Condicion"] = "Titular";
                        rowMicrTitular["NomEnt"] = "DEUDA TOTAL";
                        rowMicrTitular["Cal"] = "SCAL";
                        rowMicrTitular["SalDeu"] = objDeuda.Detalle.Sum(x => Convert.ToDecimal(x.SalDeu));
                        rowMicrTitular["DiaVen"] = (objDeuda.Detalle.Count > 0) ? objDeuda.Detalle.Max(x => Convert.ToInt32(x.DiaVen)) : 0;
                        rowMicrTitular["FchPro"] = fechaformateada(objDeuda.ano + "-" + objDeuda.mes);
                        rowMicrTitular["FchRep"] = objDeuda.Detalle.Max(x => Convert.ToString(x.FchRep)); ;
                        rowMicrTitular["FchProNumero"] = dtFechaProc.ToString("yyyy-MM");
                        rowMicrTitular["DeudaTotal"] = objDeuda.Detalle.Sum(x => Convert.ToDecimal(x.SalDeu));
                        dtMicrTitular.Rows.Add(rowMicrTitular);
                    }
                }

                if (objRespuestaConyuge != null)
                {
                    foreach (DataSenConBasSBSMicr objDeuda in objRespuestaConyuge.Data[0].ConRap.DetSBSMicr)
                    {
                        DateTime dtFechaProc = new DateTime(objDeuda.ano, objDeuda.mes, 1);
                        rowMicrConyuge = dtMicrConyuge.NewRow();
                        rowMicrConyuge["Condicion"] = "Conyuge";
                        rowMicrConyuge["NomEnt"] = "DEUDA TOTAL";
                        rowMicrConyuge["Cal"] = "SCAL";
                        rowMicrConyuge["SalDeu"] = objDeuda.Detalle.Sum(x => Convert.ToDecimal(x.SalDeu));
                        rowMicrConyuge["DiaVen"] = (objDeuda.Detalle.Count > 0) ? objDeuda.Detalle.Max(x => Convert.ToInt32(x.DiaVen)) : 0;
                        rowMicrConyuge["FchPro"] = fechaformateada(objDeuda.ano + "-" + objDeuda.mes);
                        rowMicrConyuge["FchRep"] = objDeuda.Detalle.Max(x => Convert.ToString(x.FchRep)); ;
                        rowMicrConyuge["FchProNumero"] = dtFechaProc.ToString("yyyy-MM");
                        rowMicrConyuge["DeudaTotal"] = objDeuda.Detalle.Sum(x => Convert.ToDecimal(x.SalDeu));
                        dtMicrConyuge.Rows.Add(rowMicrConyuge);
                    }
            }

                dsContenedorDatoSentinel.Tables.Add(dtMicrTitular.Copy());
                dsContenedorDatoSentinel.Tables.Add(dtMicrConyuge.Copy());

            }

        }

        public void DatosBasicoSunat(DataSenInfBasica dataBasicoSunat,string CondicionTitularConyuge)
        {
            List<DataSenInfBasica> ListaSunatInfoSentinelTitular = new List<DataSenInfBasica>();
            if (dataBasicoSunat != null)
            {
                if (Convert.ToInt32(conBusCli1.nidTipoDocumento) == 1) //PERSONA NATURAL
                {
                    switch (CondicionTitularConyuge)
                    {
                        case "Titular":
                            dtBasicoSunatTitular.Clear();
                            DataRow rowBasicoSunatTitular = dtBasicoSunatTitular.NewRow();
                         
                            rowBasicoSunatTitular["TDoc"] = dataBasicoSunat.TDoc;
                            rowBasicoSunatTitular["NDoc"] = dataBasicoSunat.NDoc;
                            rowBasicoSunatTitular["RelTDOC"] = dataBasicoSunat.RelTDoc;
                            rowBasicoSunatTitular["RelNDoc"] = dataBasicoSunat.RelNDoc;
                            rowBasicoSunatTitular["RazSoc"] = dataBasicoSunat.RazSoc;
                            rowBasicoSunatTitular["NomCom"] = dataBasicoSunat.NomCom;
                            rowBasicoSunatTitular["TipCon"] = dataBasicoSunat.TipCon;
                            rowBasicoSunatTitular["IniAct"] = dataBasicoSunat.IniAct;
                            rowBasicoSunatTitular["ActEco"] = dataBasicoSunat.ActEco;
                            rowBasicoSunatTitular["FchInsRRPP"] = dataBasicoSunat.FchInsRRPP;
                            rowBasicoSunatTitular["AgeRet"] = dataBasicoSunat.AgeRet;
                            rowBasicoSunatTitular["ApePat"] = dataBasicoSunat.ApePat;
                            rowBasicoSunatTitular["ApeMat"] = dataBasicoSunat.ApeMat;
                            rowBasicoSunatTitular["Nom"] = dataBasicoSunat.Nom;
                            rowBasicoSunatTitular["Sex"] = dataBasicoSunat.Sex;
                            rowBasicoSunatTitular["EstCon"] = dataBasicoSunat.EstCon;
                            rowBasicoSunatTitular["EstDom"] = dataBasicoSunat.EstCon;
                            rowBasicoSunatTitular["EstDomic"] = dataBasicoSunat.EstCon;
                            rowBasicoSunatTitular["CondDomic"] = dataBasicoSunat.EstCon;
                            dtBasicoSunatTitular.Rows.Add(rowBasicoSunatTitular);
                            break;
                        case "Conyuge":
                            dtBasicoSunatConyuge.Clear();
                            DataRow rowBasicoSunatConyuge = dtBasicoSunatConyuge.NewRow();

                            rowBasicoSunatConyuge["TDoc"] = dataBasicoSunat.TDoc;
                            rowBasicoSunatConyuge["NDoc"] = dataBasicoSunat.NDoc;
                            rowBasicoSunatConyuge["RelTDOC"] = dataBasicoSunat.RelTDoc;
                            rowBasicoSunatConyuge["RelNDoc"] = dataBasicoSunat.RelNDoc;
                            rowBasicoSunatConyuge["RazSoc"] = dataBasicoSunat.RazSoc;
                            rowBasicoSunatConyuge["NomCom"] = dataBasicoSunat.NomCom;
                            rowBasicoSunatConyuge["TipCon"] = dataBasicoSunat.TipCon;
                            rowBasicoSunatConyuge["IniAct"] = dataBasicoSunat.IniAct;
                            rowBasicoSunatConyuge["ActEco"] = dataBasicoSunat.ActEco;
                            rowBasicoSunatConyuge["FchInsRRPP"] = dataBasicoSunat.FchInsRRPP;
                            rowBasicoSunatConyuge["AgeRet"] = dataBasicoSunat.AgeRet;
                            rowBasicoSunatConyuge["ApePat"] = dataBasicoSunat.ApePat;
                            rowBasicoSunatConyuge["ApeMat"] = dataBasicoSunat.ApeMat;
                            rowBasicoSunatConyuge["Nom"] = dataBasicoSunat.Nom;
                            rowBasicoSunatConyuge["Sex"] = dataBasicoSunat.Sex;
                            rowBasicoSunatConyuge["EstCon"] = dataBasicoSunat.EstCon;
                            rowBasicoSunatConyuge["EstDom"] = dataBasicoSunat.EstCon;
                            rowBasicoSunatConyuge["EstDomic"] = dataBasicoSunat.EstCon;
                            rowBasicoSunatConyuge["CondDomic"] = dataBasicoSunat.EstCon;
                            dtBasicoSunatConyuge.Rows.Add(rowBasicoSunatConyuge);
                            break;

                    }
                }
                if (Convert.ToInt32(conBusCli1.nidTipoDocumento) == 4)//PERSONA JURIDICA
                {
                    dtBasicoSunatTitular.Clear();
                    DataRow rowBasicoSunatTitular = dtBasicoSunatTitular.NewRow();

                    rowBasicoSunatTitular["TDoc"] = dataBasicoSunat.TDoc;
                    rowBasicoSunatTitular["NDoc"] = dataBasicoSunat.NDoc;
                    rowBasicoSunatTitular["RelTDOC"] = dataBasicoSunat.RelTDoc;
                    rowBasicoSunatTitular["RelNDoc"] = dataBasicoSunat.RelNDoc;
                    rowBasicoSunatTitular["RazSoc"] = dataBasicoSunat.RazSoc;
                    rowBasicoSunatTitular["NomCom"] = dataBasicoSunat.NomCom;
                    rowBasicoSunatTitular["TipCon"] = dataBasicoSunat.TipCon;
                    rowBasicoSunatTitular["IniAct"] = dataBasicoSunat.IniAct;
                    rowBasicoSunatTitular["ActEco"] = dataBasicoSunat.ActEco;
                    rowBasicoSunatTitular["FchInsRRPP"] = dataBasicoSunat.FchInsRRPP;
                    rowBasicoSunatTitular["AgeRet"] = dataBasicoSunat.AgeRet;
                    rowBasicoSunatTitular["ApePat"] = dataBasicoSunat.ApePat;
                    rowBasicoSunatTitular["ApeMat"] = dataBasicoSunat.ApeMat;
                    rowBasicoSunatTitular["Nom"] = dataBasicoSunat.Nom;
                    rowBasicoSunatTitular["Sex"] = dataBasicoSunat.Sex;
                    rowBasicoSunatTitular["EstCon"] = dataBasicoSunat.EstCon;
                    rowBasicoSunatTitular["EstDom"] = dataBasicoSunat.EstCon;
                    rowBasicoSunatTitular["EstDomic"] = dataBasicoSunat.EstCon;
                    rowBasicoSunatTitular["CondDomic"] = dataBasicoSunat.EstCon;
                    dtBasicoSunatTitular.Rows.Add(rowBasicoSunatTitular);

                }

            }
        }
        public void DatosBasicoSunatDireccion(List<DataSenInfGenDirecc> dataBasicaDireccion, string CondicionTitularConyuge)
        {
            if (dataBasicaDireccion.Count > 0)
            {
                if (Convert.ToInt32(conBusCli1.nidTipoDocumento) == 1) //PERSONA NATURAL
                {
                    switch (CondicionTitularConyuge)
                    {
                        case "Titular":
                            dtBSunatDireccionTitular.Clear();
                            for (int iDireccSunatT = 0; iDireccSunatT < dataBasicaDireccion.Count; iDireccSunatT++)
                            {
                                DataRow rowBSunatDireccionTitular = dtBSunatDireccionTitular.NewRow();
                                rowBSunatDireccionTitular["Direccion"] = dataBasicaDireccion[iDireccSunatT].Direccion;
                                rowBSunatDireccionTitular["Fuente"] = dataBasicaDireccion[iDireccSunatT].Fuente;
                                dtBSunatDireccionTitular.Rows.Add(rowBSunatDireccionTitular);
                            }


                            break;
                        case "Conyuge":
                            dtBSunatDireccionConyuge.Clear();
                            for (int iDireccSunatC = 0; iDireccSunatC < dataBasicaDireccion.Count; iDireccSunatC++)
                            {
                                DataRow rowBSunatDireccionConyuge = dtBSunatDireccionConyuge.NewRow();
                                rowBSunatDireccionConyuge["Direccion"] = dataBasicaDireccion[iDireccSunatC].Direccion;
                                rowBSunatDireccionConyuge["Fuente"] = dataBasicaDireccion[iDireccSunatC].Fuente;
                                dtBSunatDireccionConyuge.Rows.Add(rowBSunatDireccionConyuge);
                            }

                            break;
                    }
                }
                if (Convert.ToInt32(conBusCli1.nidTipoDocumento) == 4)//PERSONA JURIDICA
                {
                    dtBSunatDireccionTitular.Clear();
                    for (int iDireccSunatT = 0; iDireccSunatT < dataBasicaDireccion.Count; iDireccSunatT++)
                    {
                        DataRow rowBSunatDireccionTitular = dtBSunatDireccionTitular.NewRow();
                        rowBSunatDireccionTitular["Direccion"] = dataBasicaDireccion[iDireccSunatT].Direccion;
                        rowBSunatDireccionTitular["Fuente"] = dataBasicaDireccion[iDireccSunatT].Fuente;
                        dtBSunatDireccionTitular.Rows.Add(rowBSunatDireccionTitular);
                    }

                }


            }
        }
        public void DatosBasicoSunatRLegal(List<DataSenInfGenEsRepLeg> EsRepLegDe ,List<DataSenInfGenRepLeg> ListRepLeg, string CondicionTitularConyuge)
        {
            if (EsRepLegDe.Count > 0)
            {
                if (Convert.ToInt32(conBusCli1.nidTipoDocumento) == 1) //PERSONA NATURAL
                {
                    switch (CondicionTitularConyuge)
                    {
                        case "Titular":
                            dtRlegalTitular.Clear();
                            for (int iRlegalTitular = 0; iRlegalTitular < EsRepLegDe.Count; iRlegalTitular++)
                            {
                                DataRow rowRlegalTitular = dtRlegalTitular.NewRow();

                                rowRlegalTitular["TDOC"] = EsRepLegDe[iRlegalTitular].TDOC;
                                rowRlegalTitular["NDOC"] = EsRepLegDe[iRlegalTitular].NDOC.ToString();
                                rowRlegalTitular["Nombre"] = EsRepLegDe[iRlegalTitular].RazSoc.ToString();
                                rowRlegalTitular["FecIniCar"] = EsRepLegDe[iRlegalTitular].FecIniCar.ToString();
                                rowRlegalTitular["Cargo"] = EsRepLegDe[iRlegalTitular].Cargo.ToString();
                                dtRlegalTitular.Rows.Add(rowRlegalTitular);
                            }

                            break;
                        case "Conyuge":
                            dtRlegalConyuge.Clear();
                            for (int iRlegalConyuge = 0; iRlegalConyuge < EsRepLegDe.Count; iRlegalConyuge++)
                            {
                                DataRow rowRlegalConyuge = dtRlegalConyuge.NewRow();

                                rowRlegalConyuge["TDOC"] = EsRepLegDe[iRlegalConyuge].TDOC;
                                rowRlegalConyuge["NDOC"] = EsRepLegDe[iRlegalConyuge].NDOC.ToString();
                                rowRlegalConyuge["Nombre"] = EsRepLegDe[iRlegalConyuge].RazSoc.ToString();
                                rowRlegalConyuge["FecIniCar"] = EsRepLegDe[iRlegalConyuge].FecIniCar.ToString();
                                rowRlegalConyuge["Cargo"] = EsRepLegDe[iRlegalConyuge].Cargo.ToString();
                                dtRlegalConyuge.Rows.Add(rowRlegalConyuge);
                            }
                            break;
                    }
                }
            }
            if (ListRepLeg.Count>0)
            {
                if (Convert.ToInt32(conBusCli1.nidTipoDocumento) == 4)//PERSONA JURIDICA
                {
                    dtRlegalTitular.Clear();
                    for (int iRlegalTitular = 0; iRlegalTitular < ListRepLeg.Count; iRlegalTitular++)
                    {
                        DataRow rowRlegalTitular = dtRlegalTitular.NewRow();

                        rowRlegalTitular["TDOC"] = ListRepLeg[iRlegalTitular].TDOC;
                        rowRlegalTitular["NDOC"] = ListRepLeg[iRlegalTitular].NDOC.ToString();
                        rowRlegalTitular["Nombre"] = ListRepLeg[iRlegalTitular].Nombre.ToString();
                        rowRlegalTitular["FecIniCar"] = ListRepLeg[iRlegalTitular].FecIniCar.ToString();
                        rowRlegalTitular["Cargo"] = ListRepLeg[iRlegalTitular].Cargo.ToString();
                        dtRlegalTitular.Rows.Add(rowRlegalTitular);
                    }


                }
            }

           
        }
        public void DatosBasicoLineaCredito(List<DataSenConBasUtiLinCre> UtiLinCre, string CondicionTitularConyuge)
        {
            if (UtiLinCre.Count > 0)
            {

                switch (CondicionTitularConyuge)
                {
                    case "Titular":
                        dtlCredNoUtilizadaT.Clear();
                        for (int iLCredNoUtili = 0; iLCredNoUtili < UtiLinCre.Count; iLCredNoUtili++)
                        {
                            DataRow rowlCredNoUtilizadaT = dtlCredNoUtilizadaT.NewRow();
                            rowlCredNoUtilizadaT["Condicion"] = "Titular";
                            rowlCredNoUtilizadaT["Inst"] = UtiLinCre[iLCredNoUtili].Inst;
                            rowlCredNoUtilizadaT["LinApr"] = UtiLinCre[iLCredNoUtili].LinApr.ToString();
                            rowlCredNoUtilizadaT["LinNoUti"] = UtiLinCre[iLCredNoUtili].LinNoUti.ToString();
                            rowlCredNoUtilizadaT["LinUti"] = UtiLinCre[iLCredNoUtili].LinUti.ToString();
                            rowlCredNoUtilizadaT["TipCred"] = UtiLinCre[iLCredNoUtili].TipCred.ToString();
                            dtlCredNoUtilizadaT.Rows.Add(rowlCredNoUtilizadaT);
                        }

                        break;
                    case "Conyuge":
                        dtlCredNoUtilizadaC.Clear();
                        for (int iLCredNoUtiliConyuge = 0; iLCredNoUtiliConyuge < UtiLinCre.Count; iLCredNoUtiliConyuge++)
                        {
                            DataRow rowlCredNoUtilizadaC = dtlCredNoUtilizadaC.NewRow();
                            rowlCredNoUtilizadaC["Condicion"] = "Cónyuge";
                            rowlCredNoUtilizadaC["Inst"] = UtiLinCre[iLCredNoUtiliConyuge].Inst;
                            rowlCredNoUtilizadaC["LinApr"] = UtiLinCre[iLCredNoUtiliConyuge].LinApr.ToString();
                            rowlCredNoUtilizadaC["LinNoUti"] = UtiLinCre[iLCredNoUtiliConyuge].LinNoUti.ToString();
                            rowlCredNoUtilizadaC["LinUti"] = UtiLinCre[iLCredNoUtiliConyuge].LinUti.ToString();
                            rowlCredNoUtilizadaC["TipCred"] = UtiLinCre[iLCredNoUtiliConyuge].TipCred.ToString();
                            dtlCredNoUtilizadaC.Rows.Add(rowlCredNoUtilizadaC);
                        }

                        break;
                }
            }

        }
        public void DatosDeudaProtesto(List<DataSenConBasVen> ListProtestoDeuLaboralSentinel, string CondicionTitularConyuge)
        {
            if (ListProtestoDeuLaboralSentinel != null)
                {
                    if (ListProtestoDeuLaboralSentinel.Count > 0)
                    {
                        switch (CondicionTitularConyuge)
                        {
                            case "Titular":
                                dtDeudaTitular.Clear();

                                for (int iDeudaTitular = 0; iDeudaTitular < ListProtestoDeuLaboralSentinel.Count; iDeudaTitular++)
                                {
                                    for (int iVenciDeudaTitular = 0; iVenciDeudaTitular <  ListProtestoDeuLaboralSentinel[iDeudaTitular].DetalleVencidos.Count; iVenciDeudaTitular++)
                                    {
                                        DataRow rowDeudaTitular = dtDeudaTitular.NewRow();
                                        rowDeudaTitular["Condicion"]    = "Titular";
                                        rowDeudaTitular["idFue"]        = ListProtestoDeuLaboralSentinel[iDeudaTitular].IdFue;
                                        rowDeudaTitular["MaxDiaVen"]    = ListProtestoDeuLaboralSentinel[iDeudaTitular].MaxDiaVen.ToString();
                                        rowDeudaTitular["NomFue"]       = ListProtestoDeuLaboralSentinel[iDeudaTitular].NomFue.ToString();
                                        rowDeudaTitular["VenTot"]       = ListProtestoDeuLaboralSentinel[iDeudaTitular].VenTot.ToString();
                                        rowDeudaTitular["NomEnt"]       = ListProtestoDeuLaboralSentinel[iDeudaTitular].DetalleVencidos[iVenciDeudaTitular].NomEnt.ToString();
                                        rowDeudaTitular["MontDeu"]      = ListProtestoDeuLaboralSentinel[iDeudaTitular].DetalleVencidos[iVenciDeudaTitular].MontDeu.ToString();
                                        rowDeudaTitular["DiaVen"]       = ListProtestoDeuLaboralSentinel[iDeudaTitular].DetalleVencidos[iVenciDeudaTitular].DiaVen.ToString();
                                        rowDeudaTitular["NumDoc"]       = ListProtestoDeuLaboralSentinel[iDeudaTitular].DetalleVencidos[iVenciDeudaTitular].NumDoc.ToString();
                          
                                        dtDeudaTitular.Rows.Add(rowDeudaTitular);
                                    }
                                }

                                break;
                            case "Conyuge":
                                dtDeudaConyuge.Clear();
                       
                                for (int iDeudaConyuge = 0; iDeudaConyuge < ListProtestoDeuLaboralSentinel.Count; iDeudaConyuge++)
                                {
                                    for (int iVenciDeudaConyuge = 0; iVenciDeudaConyuge < ListProtestoDeuLaboralSentinel[iDeudaConyuge].DetalleVencidos.Count; iVenciDeudaConyuge++)
                                    {
                                        DataRow rowDeudaConyuge = dtDeudaConyuge.NewRow();
                                        rowDeudaConyuge["Condicion"] = "Cónyuge";
                                        rowDeudaConyuge["idFue"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].IdFue;
                                        rowDeudaConyuge["MaxDiaVen"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].MaxDiaVen.ToString();
                                        rowDeudaConyuge["NomFue"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].NomFue.ToString();
                                        rowDeudaConyuge["VenTot"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].VenTot.ToString();
                                       
                                        rowDeudaConyuge["NomEnt"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].DetalleVencidos[iVenciDeudaConyuge].NomEnt.ToString();
                                        rowDeudaConyuge["MontDeu"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].DetalleVencidos[iVenciDeudaConyuge].MontDeu.ToString();
                                        rowDeudaConyuge["DiaVen"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].DetalleVencidos[iVenciDeudaConyuge].DiaVen.ToString();
                                        rowDeudaConyuge["NumDoc"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].DetalleVencidos[iVenciDeudaConyuge].NumDoc.ToString();
                                        dtDeudaConyuge.Rows.Add(rowDeudaConyuge);

                                    }
                              
                                }

                         
                                break;
                        }
                    }
                }
        }
        public void DatosAvalista(List<DataSenAvalDe> LisAvalista, string CondicionTitularConyuge)
        {
            if (LisAvalista != null)
            {
                if (LisAvalista.Count > 0)
                {
                    switch (CondicionTitularConyuge)
                    {

                        case "Titular":
                            dtAvalistaTitular.Clear();

                            for (int iAvalista = 0; iAvalista < LisAvalista.Count; iAvalista++)
                            {
                                for (int iAcredorAvalista = 0; iAcredorAvalista < LisAvalista[iAvalista].Acreedor.Count; iAcredorAvalista++)
                                {
                                    DataRow rowAvalistaTitular = dtAvalistaTitular.NewRow();
                                    rowAvalistaTitular["Condicion"] = "Titular";
                                    rowAvalistaTitular["NDoc"] = LisAvalista[iAvalista].NDoc.ToString();
                                    rowAvalistaTitular["RazSoc"] = LisAvalista[iAvalista].RazSoc.ToString();
                                    rowAvalistaTitular["Sem12Mes"] = LisAvalista[iAvalista].Sem12Mes.ToString();
                                    rowAvalistaTitular["SemAct"] = LisAvalista[iAvalista].SemAct.ToString();
                                    rowAvalistaTitular["SemPre"] = LisAvalista[iAvalista].SemPre.ToString();
                                    rowAvalistaTitular["NDocAcre"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].NDoc.ToString();
                                    rowAvalistaTitular["RazSocAcre"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].RazSoc.ToString();
                                    rowAvalistaTitular["Cal"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].Cal.ToString();
                                    rowAvalistaTitular["SalDeu"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].SalDeu.ToString();
                                    rowAvalistaTitular["TipEnt"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].TipEnt.ToString();
                                    rowAvalistaTitular["FecRep"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].FecRep.ToString();

                                    dtAvalistaTitular.Rows.Add(rowAvalistaTitular);

                                }
                            }


                            break;
                        case "Conyuge":
                            dtAvalistaConyuge.Clear();

                            for (int iAvalistaConyuge = 0; iAvalistaConyuge < LisAvalista.Count; iAvalistaConyuge++)
                            {
                                for (int iAcredorAvalistaConyuge = 0; iAcredorAvalistaConyuge < LisAvalista[iAvalistaConyuge].Acreedor.Count; iAcredorAvalistaConyuge++)
                                {
                                    DataRow rowAvalistaConyuge = dtAvalistaConyuge.NewRow();
                                    rowAvalistaConyuge["Condicion"] = "Cónyuge";
                                    rowAvalistaConyuge["NDoc"] = LisAvalista[iAvalistaConyuge].NDoc.ToString();
                                    rowAvalistaConyuge["RazSoc"] = LisAvalista[iAvalistaConyuge].RazSoc.ToString();
                                    rowAvalistaConyuge["Sem12Mes"] = LisAvalista[iAvalistaConyuge].Sem12Mes.ToString();
                                    rowAvalistaConyuge["SemAct"] = LisAvalista[iAvalistaConyuge].SemAct.ToString();
                                    rowAvalistaConyuge["SemPre"] = LisAvalista[iAvalistaConyuge].SemPre.ToString();

                                    rowAvalistaConyuge["NDocAcre"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].NDoc.ToString();
                                    rowAvalistaConyuge["RazSocAcre"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].RazSoc.ToString();
                                    rowAvalistaConyuge["Cal"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].Cal.ToString();
                                    rowAvalistaConyuge["SalDeu"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].SalDeu.ToString();
                                    rowAvalistaConyuge["TipEnt"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].TipEnt.ToString();
                                    rowAvalistaConyuge["FecRep"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].FecRep.ToString();
                                    dtAvalistaConyuge.Rows.Add(rowAvalistaConyuge);

                                }

                            }

                            break;
                    }
                }
            }
        }
        public void DatosAvalado(List<DataSenAvalPor> Listavalado, string CondicionTitularConyuge)
        {
            if (Listavalado != null)
            {
                if (Listavalado.Count > 0)
                {
                    switch (CondicionTitularConyuge)
                    {
                        case "Titular":
                       
                                dtAvalado.Clear();

                            for (int iAvalado = 0; iAvalado < Listavalado.Count; iAvalado++)
                            {
                                for (int iAcreedorTitular = 0; iAcreedorTitular < Listavalado[iAvalado].Acreedor.Count; iAcreedorTitular++)
                                {
                                    rowAvaladoTitular = dtAvalado.NewRow();
                                    rowAvaladoTitular["Condicion"] = "Titular";
                                    rowAvaladoTitular["ndoc"] = Listavalado[iAvalado].NDoc.ToString();
                                    rowAvaladoTitular["tDoc"] = Listavalado[iAvalado].TDoc.ToString();
                                    rowAvaladoTitular["razSoc"] = Listavalado[iAvalado].RazSoc.ToString();
                                    rowAvaladoTitular["semAct"] = Listavalado[iAvalado].SemAct.ToString();
                                    rowAvaladoTitular["Sem12Mes"] = Listavalado[iAvalado].Sem12Mes.ToString();
                                    rowAvaladoTitular["tDocAcre"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].TDoc.ToString();
                                    rowAvaladoTitular["nDocAcre"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].NDoc.ToString();
                                    rowAvaladoTitular["razSocAcre"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].RazSoc.ToString();
                                    rowAvaladoTitular["cal"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].Cal.ToString();
                                    rowAvaladoTitular["tipEnt"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].TipEnt.ToString();
                                    rowAvaladoTitular["salDeu"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].SalDeu.ToString();
                                    rowAvaladoTitular["fecRep"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].FecRep.ToString();

                                    dtAvalado.Rows.Add(rowAvaladoTitular);
                                }

                            }

                            break;
                        case "Conyuge":
          
                                dtAvaladoConyuge.Clear();

                            for (int iAvaladoConyuge = 0; iAvaladoConyuge < Listavalado.Count; iAvaladoConyuge++)
                            {

                                for (int iAcreedorConyuge = 0; iAcreedorConyuge < Listavalado[iAvaladoConyuge].Acreedor.Count; iAcreedorConyuge++)
                                {
                                    rowAvaladoConyuge = dtAvaladoConyuge.NewRow();
                                    rowAvaladoConyuge["Condicion"] = "Cónyuge";
                                    rowAvaladoConyuge["ndoc"] = Listavalado[iAvaladoConyuge].NDoc.ToString();
                                    rowAvaladoConyuge["tDoc"] = Listavalado[iAvaladoConyuge].TDoc.ToString();
                                    rowAvaladoConyuge["razSoc"] = Listavalado[iAvaladoConyuge].RazSoc.ToString();
                                    rowAvaladoConyuge["semAct"] = Listavalado[iAvaladoConyuge].SemAct.ToString();
                                    rowAvaladoConyuge["Sem12Mes"] = Listavalado[iAvaladoConyuge].Sem12Mes.ToString();

                                    rowAvaladoConyuge["tDocAcre"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].TDoc.ToString();
                                    rowAvaladoConyuge["nDocAcre"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].NDoc.ToString();
                                    rowAvaladoConyuge["razSocAcre"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].RazSoc.ToString();
                                    rowAvaladoConyuge["cal"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].Cal.ToString();
                                    rowAvaladoConyuge["tipEnt"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].TipEnt.ToString();
                                    rowAvaladoConyuge["salDeu"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].SalDeu.ToString();
                                    rowAvaladoConyuge["fecRep"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].FecRep.ToString();
                                    dtAvaladoConyuge.Rows.Add(rowAvaladoConyuge);


                                }

                            }

                            break;
                    }
                }
            }
        }
        public void DatosDeudaDirecta(List<DataSenConBasSBSMicr> DetSBSMicr, string CondicionTitularConyuge)
        {
            if (objRespuesta.Data[0].ConRap.DetSBSMicr.Count > 0)
            {
                DetSBSMicr = objRespuesta.Data[0].ConRap.DetSBSMicr;

                switch (CondicionTitularConyuge)
                {
                    case "Titular":
                        dtMicrTitular.Clear();
                        dtDeudaSentinelDirectaTitular = new DataTable("dtDeudaSentinelDirectaTitular");
                        for (int iSBSMicro = 0; iSBSMicro < DetSBSMicr.Count; iSBSMicro++)
                        {
                            DateTime dtFechaProc = new DateTime(objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].ano, objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].mes, 1);
                            for (int iDetalle = 0; iDetalle < DetSBSMicr[iSBSMicro].Detalle.Count; iDetalle++)
                            {
                                rowMicrTitular = dtMicrTitular.NewRow();

                                rowMicrTitular["Condicion"] = "Titular";
                                rowMicrTitular["NomEnt"] = DetSBSMicr[iSBSMicro].Detalle[iDetalle].NomEnt;
                                rowMicrTitular["Cal"] = DetSBSMicr[iSBSMicro].Detalle[iDetalle].Cal;
                                rowMicrTitular["SalDeu"] = DetSBSMicr[iSBSMicro].Detalle[iDetalle].SalDeu;
                                rowMicrTitular["DiaVen"] = DetSBSMicr[iSBSMicro].Detalle[iDetalle].DiaVen;
                                rowMicrTitular["FchPro"] = fechaformateada(DetSBSMicr[iSBSMicro].Detalle[iDetalle].FchPro);
                                rowMicrTitular["FchRep"] = DetSBSMicr[iSBSMicro].Detalle[iDetalle].FchRep;
                                rowMicrTitular["FchProNumero"] = dtFechaProc.ToString("yyyy-MM");
                                rowMicrTitular["DeudaTotal"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle.Sum(x => Convert.ToDecimal(x.SalDeu)); 
 
                                dtMicrTitular.Rows.Add(rowMicrTitular);
                            }
                            if (DetSBSMicr[iSBSMicro].Detalle.Count == 0)
                            {
                                rowMicrTitular = dtMicrTitular.NewRow();
                                rowMicrTitular["Condicion"] = "Titular";
                                rowMicrTitular["NomEnt"] = "";
                                rowMicrTitular["Cal"] = "SCAL";
                                rowMicrTitular["SalDeu"] = 0;
                                rowMicrTitular["DiaVen"] = 0;
                                rowMicrTitular["FchPro"] = fechaformateada(objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].ano + "-" + objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].mes);
                                rowMicrTitular["FchRep"] = "";
                                rowMicrTitular["FchProNumero"] = dtFechaProc.ToString("yyyy-MM"); 
                                rowMicrTitular["DeudaTotal"] = 0; 

                                dtMicrTitular.Rows.Add(rowMicrTitular);
                            }

                        }
                        cSemaforoTitular = objRespuesta.Data[0].ConRap.Resumen_ConRap.Semaforos;
                        var dtExisteDataMesAnioSBSMicr = dtMicrTitular.AsEnumerable().Where(r => r.Field<string>("FchPro") == Convert.ToString(fechaformateada(clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd")))).Any();

                        if (dtExisteDataMesAnioSBSMicr)
                        {
                            dtDeudaSentinelDirectaTitular = dtMicrTitular.AsEnumerable().Where(r => r.Field<string>("FchPro") == Convert.ToString(fechaformateada(clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd")))).CopyToDataTable();
                            dtDeudaSentinelDirectaTitular.TableName = "dtDeudaSentinelDirectaTitular";
                        }
            
                        break;
                    case "Conyuge":
                        dtMicrConyuge.Clear();
                        dtDeudaSentinelDirectaConyuge = new DataTable("dtDeudaSentinelDirectaConyuge");
                        for (int iSBSMicro = 0; iSBSMicro < objRespuesta.Data[0].ConRap.DetSBSMicr.Count; iSBSMicro++)
                        {
                            DateTime dtFechaProc = new DateTime(objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].ano, objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].mes, 1);
                            for (int iDetalle = 0; iDetalle < objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle.Count; iDetalle++)
                            {
                                rowMicrConyuge = dtMicrConyuge.NewRow();
                                rowMicrConyuge["Condicion"] = "Cónyuge";
                                rowMicrConyuge["NomEnt"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].NomEnt;
                                rowMicrConyuge["Cal"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].Cal;
                                rowMicrConyuge["SalDeu"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].SalDeu;
                                rowMicrConyuge["DiaVen"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].DiaVen;
                                rowMicrConyuge["FchPro"] = fechaformateada(objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].FchPro);
                                rowMicrConyuge["FchRep"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].FchRep;
                                rowMicrConyuge["FchProNumero"] = dtFechaProc.ToString("yyyy-MM"); 
                                rowMicrConyuge["DeudaTotal"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle.Sum(x => Convert.ToDecimal(x.SalDeu)); 

                                dtMicrConyuge.Rows.Add(rowMicrConyuge);
                            }

                            if (objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle.Count == 0)
                            {
                                rowMicrConyuge = dtMicrConyuge.NewRow();
                                rowMicrConyuge["Condicion"] = "Cónyuge";
                                rowMicrConyuge["NomEnt"] = "";
                                rowMicrConyuge["Cal"] = "SCAL";
                                rowMicrConyuge["SalDeu"] = 0;
                                rowMicrConyuge["DiaVen"] = 0;
                                rowMicrConyuge["FchPro"] = fechaformateada(objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].ano + "-" + objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].mes);
                                rowMicrConyuge["FchRep"] = "";
                                rowMicrConyuge["FchProNumero"] = dtFechaProc.ToString("yyyy-MM"); 
                                rowMicrConyuge["DeudaTotal"] = 0; 

                                dtMicrConyuge.Rows.Add(rowMicrConyuge);
                            }

                        }
                        cSemaforoConyuge = objRespuesta.Data[0].ConRap.Resumen_ConRap.Semaforos;
                        var dtExisteDataMesAnioSBSMicrConyuge = dtMicrConyuge.AsEnumerable().Where(r => r.Field<string>("FchPro") == Convert.ToString(fechaformateada(clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd")))).Any();
                        if (dtExisteDataMesAnioSBSMicrConyuge)
                        {
                            dtDeudaSentinelDirectaConyuge = dtMicrConyuge.AsEnumerable().Where(r => r.Field<string>("FchPro") == Convert.ToString(fechaformateada(clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd")))).CopyToDataTable();
                            dtDeudaSentinelDirectaConyuge.TableName = "dtDeudaSentinelDirectaConyuge";
            
                        }

                        break;
                }
            }
        }
        public void HistoricoSentinel_Titular()
        {
            if (dtMicrTitular.Rows.Count > 0)
            {
                dtHistorialSentinelTitular.Clear();
                var dataTitular = dtMicrTitular.AsEnumerable().GroupBy(X => X["FchPro"]).Select(X => X.CopyToDataTable());
                var SemaforoActual = InvertirCadena(cSemaforoTitular);

                decimal DeutaTotal;
                int nNumeroEntidad;
                string cCalificacion;
                string cfechaPRo;
                List<ListOrdenSemaforo> DataSemaforoTitular = LLenaListaSemaforo(SemaforoActual);

                for (int iDataTitular = 0; iDataTitular < dataTitular.Count(); iDataTitular++)
                {
                    var DataTitularAgrupada = dataTitular.ElementAt(iDataTitular);
                    DeutaTotal = 0;
                    nNumeroEntidad = 0;
                    cCalificacion = String.Empty;
                    cfechaPRo = string.Empty;
                    decimal nValorDeudaNOR = Decimal.Zero;
                    decimal nValorDeudaCPP = Decimal.Zero;
                    decimal nValorDeudaDEF = Decimal.Zero;
                    decimal nValorDeudaDUD = Decimal.Zero;
                    decimal nValorDeudaPER = Decimal.Zero;
                    decimal nValorDeudaSCAL = Decimal.Zero;
                    string cFechProNumero = String.Empty;

                    for (int y = 0; y < DataTitularAgrupada.Rows.Count; y++)
                    {
                        DeutaTotal += Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]);
                        nNumeroEntidad += 1;
                        cCalificacion = DataTitularAgrupada.Rows[y]["Cal"].ToString();
                        cfechaPRo = DataTitularAgrupada.Rows[y]["FchPro"].ToString();

                        nValorDeudaNOR += (cCalificacion == "NOR") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaCPP += (cCalificacion == "CPP") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaDEF += (cCalificacion == "DEF") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaDUD += (cCalificacion == "DUD") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaPER += (cCalificacion == "PER") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaSCAL += (cCalificacion == "SCAL") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;

                        cFechProNumero = Convert.ToString(DataTitularAgrupada.Rows[y]["FchProNumero"]);
                    }

                    rowHistorialSentinelTitular = dtHistorialSentinelTitular.NewRow();

                    rowHistorialSentinelTitular["FechPro"] = cfechaPRo;
                    rowHistorialSentinelTitular["SemaActual"] = DataSemaforoTitular.Where(S => S.codigo == iDataTitular).Select(S => S.Semaforo).ToList()[0];
                    rowHistorialSentinelTitular["NroEntidad"] = nNumeroEntidad;
                    rowHistorialSentinelTitular["DeudaTotal"] = DeutaTotal;
                    rowHistorialSentinelTitular["Calificacion"] = cCalificacion;

                    rowHistorialSentinelTitular["PorcentajeNOR"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaNOR * 100 / DeutaTotal), 0);
                    rowHistorialSentinelTitular["PorcentajeCPP"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaCPP * 100 / DeutaTotal), 0);
                    rowHistorialSentinelTitular["PorcentajeDEF"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaDEF * 100 / DeutaTotal), 0);
                    rowHistorialSentinelTitular["PorcentajeDUD"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaDUD * 100 / DeutaTotal), 0);
                    rowHistorialSentinelTitular["PorcentajePER"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaPER * 100 / DeutaTotal), 0);
                    rowHistorialSentinelTitular["PorcentajeSCAL"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaSCAL * 100 / DeutaTotal), 0);

                    rowHistorialSentinelTitular["FchProNumero"] = cFechProNumero;

                    dtHistorialSentinelTitular.Rows.Add(rowHistorialSentinelTitular);
                }
            }

        }
        public void HistoricoSentinel_Conyuge()
        {
            if (dtMicrConyuge.Rows.Count > 0)
            {
                dtHistorialSentinelConyuge.Clear();
                var dataConyuge = dtMicrConyuge.AsEnumerable().GroupBy(X => X["FchPro"]).Select(X => X.CopyToDataTable());
                var SemaforoActual = InvertirCadena(cSemaforoConyuge);

                decimal DeutaTotal;
                int nNumeroEntidad;
                string cCalificacion;
                string cfechaPRo;
                List<ListOrdenSemaforo> DataSemaforoTitular = LLenaListaSemaforo(SemaforoActual);

                for (int iDataConyuge = 0; iDataConyuge < dataConyuge.Count(); iDataConyuge++)
                {
                    var DataTitularAgrupada = dataConyuge.ElementAt(iDataConyuge);
                    DeutaTotal = 0;
                    nNumeroEntidad = 0;
                    cCalificacion = String.Empty;
                    cfechaPRo = string.Empty;
                    decimal nValorDeudaNOR = Decimal.Zero;
                    decimal nValorDeudaCPP = Decimal.Zero;
                    decimal nValorDeudaDEF = Decimal.Zero;
                    decimal nValorDeudaDUD = Decimal.Zero;
                    decimal nValorDeudaPER = Decimal.Zero;
                    decimal nValorDeudaSCAL = Decimal.Zero;
                    string cFechProNumero = String.Empty;

                    for (int y = 0; y < DataTitularAgrupada.Rows.Count; y++)
                    {
                        DeutaTotal += Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]);
                        nNumeroEntidad += 1;
                        cCalificacion = DataTitularAgrupada.Rows[y]["Cal"].ToString();
                        cfechaPRo = DataTitularAgrupada.Rows[y]["FchPro"].ToString();

                        nValorDeudaNOR += (cCalificacion == "NOR") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaCPP += (cCalificacion == "CPP") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaDEF += (cCalificacion == "DEF") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaDUD += (cCalificacion == "DUD") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaPER += (cCalificacion == "PER") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaSCAL += (cCalificacion == "SCAL") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        cFechProNumero = Convert.ToString(DataTitularAgrupada.Rows[y]["FchProNumero"]);
                    }

                    rowHistorialSentinelConyuge = dtHistorialSentinelConyuge.NewRow();

                    rowHistorialSentinelConyuge["FechPro"] = cfechaPRo;
                    rowHistorialSentinelConyuge["SemaActual"] = DataSemaforoTitular.Where(S => S.codigo == iDataConyuge).Select(S => S.Semaforo).ToList()[0];
                    rowHistorialSentinelConyuge["NroEntidad"] = nNumeroEntidad;
                    rowHistorialSentinelConyuge["DeudaTotal"] = DeutaTotal;
                    rowHistorialSentinelConyuge["Calificacion"] = cCalificacion;

                    rowHistorialSentinelConyuge["PorcentajeNOR"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaNOR * 100 / DeutaTotal), 0);
                    rowHistorialSentinelConyuge["PorcentajeCPP"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaCPP * 100 / DeutaTotal), 0);
                    rowHistorialSentinelConyuge["PorcentajeDEF"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaDEF * 100 / DeutaTotal), 0);
                    rowHistorialSentinelConyuge["PorcentajeDUD"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaDUD * 100 / DeutaTotal), 0);
                    rowHistorialSentinelConyuge["PorcentajePER"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaPER * 100 / DeutaTotal), 0);
                    rowHistorialSentinelConyuge["PorcentajeSCAL"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaSCAL * 100 / DeutaTotal), 0);

                    rowHistorialSentinelConyuge["FchProNumero"] = cFechProNumero;

                    dtHistorialSentinelConyuge.Rows.Add(rowHistorialSentinelConyuge);
                }
            }

        }
        public static string InvertirCadena(string cadena)
        {
            // Convertir a arreglo
            char[] cadenaComoCaracteres = cadena.ToCharArray();
            // Invertir el arreglo usando métodos incorporados
            Array.Reverse(cadenaComoCaracteres);
            // Convertir de nuevo el arreglo a cadena
            return new string(cadenaComoCaracteres);
        }
        public List<ListOrdenSemaforo> LLenaListaSemaforo(string cadena)
        {

            List<ListOrdenSemaforo> lista = new List<ListOrdenSemaforo>();
            for (int i = 0; i < cadena.Length; i++)
            {
                ListOrdenSemaforo objmodel = new ListOrdenSemaforo();
                objmodel.codigo = i;
                objmodel.Semaforo = cadena[i].ToString();
                //char c = dato[i];
                lista.Add(objmodel);

            }

            return lista;
        }

 private DataTable ArmarTablaParametros()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";

            drfila[1] = conBusCli1.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nidTipoPersona";
            drfila[1] = conBusCli1.nidTipoPersona.ToString();
            dtTablaParametros.Rows.Add(drfila);


            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cDocumentoID";
            drfila[1] = "'" + conBusCli1.txtNroDoc.Text + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoDocumento";
            drfila[1] = "'" + conBusCli1.nidTipoDocumento + "'";
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }
        public DataTable GeneraResumenCondiciones(DataTable dt)
        {
            DataTable dtRespuesta = new DataTable();
            dtRespuesta.Columns.Add("Mensaje", typeof(string));
            dtRespuesta.Columns.Add("Resultado", typeof(string));

            DataTable dtRespuestaDetCumple = dtRespuesta.Clone();
            DataTable dtRespuestaDetNoCumple = dtRespuesta.Clone();

            DataTable dtGeneral = dtRespuesta.Clone();
            dtGeneral = dt.AsEnumerable()
                                .Where(b => Convert.ToString(b.Field<string>("cTipoCondicion")) == "GENERAL")
                                .GroupBy(x => x.Field<string>("Mensaje"))
                                .Select(y => dtRespuesta.Rows.Add(Convert.ToString(y.First().Field<string>("Mensaje")), Convert.ToString(y.First().Field<string>("Resultado")))).CopyToDataTable();

            DataTable dtProducto = dtRespuesta.Clone();
            dtProducto = dt.AsEnumerable().Where(x => Convert.ToString(x.Field<string>("cTipoCondicion")) == "PRODUCTO").CopyToDataTable();

            IEnumerable<IGrouping<string, string>> lstCumple = dtProducto.AsEnumerable().Where(b => Convert.ToString(b.Field<string>("Resultado")) == "CUMPLE").GroupBy(grp => grp.Field<string>("Mensaje"), grp => grp.Field<string>("Oculto"));
            IEnumerable<IGrouping<string, string>> lstNoCumple = dtProducto.AsEnumerable().Where(b => Convert.ToString(b.Field<string>("Resultado")) == "NO CUMPLE").GroupBy(grp => grp.Field<string>("Mensaje"), grp => grp.Field<string>("Oculto"));

            foreach (IGrouping<string, string> oNoCumple in lstNoCumple)
            {
                string cNoCumpleDet = (dtProducto.AsEnumerable().Any(x => Convert.ToString(x.Field<string>("Resultado")) == "NO CUMPLE" && Convert.ToString(x.Field<string>("Mensaje")) == oNoCumple.Key)) ? "NO CUMPLE:" : "";
                cNoCumpleDet = cNoCumpleDet + " " + String.Join(", ", oNoCumple);
                dtRespuestaDetNoCumple.Rows.Add(oNoCumple.Key, cNoCumpleDet);
            }

            foreach (IGrouping<string, string> oCumple in lstCumple)
            {
                string cCumpleDet = (dtProducto.AsEnumerable().Any(x => Convert.ToString(x.Field<string>("Resultado")) == "CUMPLE" && Convert.ToString(x.Field<string>("Mensaje")) == oCumple.Key)) ? "CUMPLE" : "";
                dtRespuestaDetCumple.Rows.Add(oCumple.Key, cCumpleDet);
            }

            dtRespuestaDetCumple.Merge(dtRespuestaDetNoCumple, true, MissingSchemaAction.AddWithKey);

            dtRespuestaDetCumple.AsEnumerable()
                .GroupBy(grp => grp.Field<string>("Mensaje"))
                .Select(x => new { Mensaje = x.Key, Resultado = String.Join(" - ", x.Select(i => i.Field<string>("Resultado"))) }).ToList()
                .ForEach(x => { dtRespuesta.Rows.Add(x.Mensaje, x.Resultado); });

            return dtRespuesta;
        }
        private void conBusCli2_ClicBuscar(object sender, EventArgs e)
        {
            //abrirFormCuentas();
            buscarPoliticaPrivacidad();
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            cancelarBusqueda();
        }

        private void btnMasCuentas_Click(object sender, EventArgs e)
        {
            if (cTipoSolicitud == "individual"){
                abrirFormCuentas();
            }
            else
            {
                abrirFrmSolicitudGrupoSol();
            }
        }

        private void conBusGrupoSol1_ClicBuscar(object sender, EventArgs e)
        {
            if (!this.conBusGrupoSol1.lResultado)
            {
                MessageBox.Show("No se encontró ningún resultado.", "Documentación en Línea", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                abrirFrmSolicitudGrupoSol();
            }
            
        }

        private void btnMostrarVoucher_Click(object sender, EventArgs e)
        {
            if (idSolicitudSeleccionado != 0 && this.conBusCli1.txtNroDoc.Text != "")
            {
                frmCargarVoucherTramite frmCargarVoucher = new frmCargarVoucherTramite(idSolicitudSeleccionado);
                frmCargarVoucher.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione una Solicitud de Crédito.", "Documentación en Línea", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmExpedienteLinea_FormClosing(object sender, FormClosingEventArgs e)
        {
            string ruta = Directory.GetCurrentDirectory() + "\\documentosTmp";
            foreach(DataRow dr in dtDatosArchivos.Rows)
            {
                if (System.IO.File.Exists(ruta + "\\" + dr["sFile"]))
                {
                    try
                    {
                        System.IO.File.Delete(ruta + "\\" + dr["sFile"]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                }
            }
        }
        #endregion   

        private void btnCargarFile_Click(object sender, EventArgs e)
        {

            if (this.idSolicitud > 0)
            {
                frmCargaArchivo frmCargaArchivo = new frmCargaArchivo(this.idSolicitud, false);
                frmCargaArchivo.ShowDialog();

                if (this.idSolicitud != 0)
                {
                    getMenuExpediente(this.idSolicitud, this.cTipoSolicitud);
                    btnMasCuentas.Visible = true;
                    idSolicitudSeleccionado = idSolicitud;
                    this.conBusGrupoSol1.LimpiarControl();
                }
                else
                {
                    cancelarBusqueda();
                }
            }            
            else
            {
                MessageBox.Show("No se encontró una Solicitud.", "CARGA DE ARCHIVOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public string fechaformateada(string fecha)
        {
            string[] valores = fecha.Split('-');
            string Mes = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(valores[1]));
            string Anio = valores[0];
            string Resultado = Mes.Replace(".", "").Replace("Set", "Sep") + " " + Anio;
            return Resultado;
        }

        public void InicializarTablaSentinel()
        {
            CreaTablaClasificacionCliente();
            CreaTablaBasicoSunatTitular();
            CreaTablaBasicoSunatConyuge();
            CreaTablaBSunatDireccionTitular();
            CreaTablaBSunatDireccionConyuge();
            CreaTablaRLegalTitular();
            CreaTablaRLegalConyuge();
            CreaTablalCredNoUtilTitular();
            CreaTablalCredNoUtilConyuge();
            CreaTablaDeudaTitular();
            CreaTablaDeudaConyuge();
            CreaTablaAvalistaTitular();
            CreaTablaAvalistaConyuge();
            CreaTablaAvaladoTitular();
            CreaTablaAvaladoConyuge();
            CreaTablaMicrofinanzasTitular();
            CreaTablaMicrofinanzasConyuge();
            CreaTablaHistorialSentinelTitular();
            CreaTablaHistorialSentinelConyuge();
        }
    }
}
