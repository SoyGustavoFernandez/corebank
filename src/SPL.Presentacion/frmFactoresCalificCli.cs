using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using SPL.CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace SPL.Presentacion
{
    public partial class frmFactoresCalificCli : frmBase
    {

        #region Variables globales

        private clsCNScoring cnScoring;
        private clsCNMapeoRiesgoYOpeInusual cnmapeoriesgoyopeinusual;
        private DataTable dtFactores;
        private const string cTituloMensajes = "Factores de calificación de clientes";
        private string cTipoOperacion = "N";
        private string cFactor = String.Empty;
        private string cColumna = String.Empty; //nombre de columna en tabla clientes
        private int idFactor = 0;
        private decimal nIdFactEnTabla = 0;
        private int idPadre = 0;
        private bool lPuntuado = false;
        private int idFactorHijo = 0;
        private bool lPuntuadoHijo = false;
        private bool lSubControlesCargados = false;

        #endregion

        public frmFactoresCalificCli()
        {
            InitializeComponent();

            cnScoring = new clsCNScoring();
            cnmapeoriesgoyopeinusual = new clsCNMapeoRiesgoYOpeInusual();
        }

        #region Eventos

        private void frmFactoresCalificCli_Load(object sender, EventArgs e)
        {
            cboTipoFactor.SelectedIndexChanged -= new EventHandler(cboTipoFactor_SelectedIndexChanged);
            cboGrupoFactores.SelectedIndexChanged -= new EventHandler(cboGrupoFactores_SelectedIndexChanged);
            cboModulo.SelectedIndexChanged -= new EventHandler(cboModulo_SelectedIndexChanged);
            CargarCbos();
            cboTipoEval.CargarPorGrupo(0);
            //CargarTiposEval();
            CargarCboGruposFactores();
            cboTipoFactor.SelectedIndexChanged += new EventHandler(cboTipoFactor_SelectedIndexChanged);
            cboGrupoFactores.SelectedIndexChanged += new EventHandler(cboGrupoFactores_SelectedIndexChanged);
            cboTipoEval.SelectedIndexChanged += new EventHandler(cboTipoEval_SelectedIndexChanged);

            OcultarTodosPanelFact();
            chcSeleccionarFact.Checked = false;
            HabilitarControles(false);
            CargarFactores();
        }

        private void cboTipoFactor_SelectedIndexChanged(object sender, EventArgs e)
        {
            OcultarTodosPanelFact();
            MuestraControlFactor();
        }

        private void chcSeleccionarFact_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarSeleccionFactor();
        }

        private void chcSeleccionarFact_EnabledChanged(object sender, EventArgs e)
        {
            HabilitarSeleccionFactor();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (!lSubControlesCargados)
            {
                CargarSubControles();
                lSubControlesCargados = true;
                cboModulo.SelectedIndexChanged += new EventHandler(cboModulo_SelectedIndexChanged);
            }
            LimpiarCampos();
            HabilitarControles(true);
            HabilitarDeAcuerdoAnivel();
            //this.chcPuntaje.Checked = false;
            cTipoOperacion = "N";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!lSubControlesCargados)
            {
                CargarSubControles();
                lSubControlesCargados = true;
                cboModulo.SelectedIndexChanged += new EventHandler(cboModulo_SelectedIndexChanged);
            }
            cTipoOperacion = "A";
            HabilitarControles(true);
            txtCodigo.Enabled = false;
            cboNivel.Enabled = false;
            chcSeleccionarFact.Enabled = false;
            txtDescripcion.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            CargarFactores();
            HabilitarControles(false);
            cTipoOperacion = String.Empty;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            GuardarFactor();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgFactores.Rows.Count == 0)
            {
                MessageBox.Show("No existen factores para eliminar", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dtgFactores.SelectedRows.Count < 1)
            {
                MessageBox.Show("No se selecciono ningun factor", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //mensaje de confirmación
            if (MessageBox.Show("¿Está seguro de eliminar el factor de calificación?", cTituloMensajes, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DataTable dtEliminar = cnScoring.EliminaFactorCalific(idFactor, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
                MessageBox.Show(dtEliminar.Rows[0]["cMensaje"].ToString(), cTituloMensajes, MessageBoxButtons.OK, ((int)dtEliminar.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));

                if (idPadre == 0)
                {
                    cboGrupoFactores.SelectedIndexChanged -= new EventHandler(cboGrupoFactores_SelectedIndexChanged);
                    CargarCboGruposFactores();
                    cboGrupoFactores.SelectedIndexChanged += new EventHandler(cboGrupoFactores_SelectedIndexChanged);
                }
                CargarFactores();
            }
        }

        private void dtgFactores_SelectionChanged(object sender, EventArgs e)
        {
            VerDetallesFactor();
        }

        private void cboTipoEval_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCboGruposFactores();
            if (cboGrupoFactores.Items.Count == 0)
            {
                CargarFactores();
            }
        }

        private void cboGrupoFactores_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarFactores();
        }

        private void cboNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (idPadre == 0 && Convert.ToInt32(cboNivel.SelectedValue) == 1)
            {
                cboCamposDTCli.Enabled = false;
            }
            else
            {
                cboCamposDTCli.Enabled = true;
            }
        }

        private void cboModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModulo.Items.Count > 0)
            {
                DataTable dtProductosRiesgo = new clsCNMapeoRiesgoYOpeInusual().listaProductosRiesgo(0, Convert.ToInt32(cboModulo.SelectedValue));
                cboProductos.DisplayMember = "cProducto";
                cboProductos.ValueMember = "idProductoRiesgo";
                cboProductos.DataSource = dtProductosRiesgo;
            }
        }

        private void cboTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboTipClasif.CargarClasificacion(Convert.ToInt32(cboTipoPersona1.SelectedValue));
            cboSegmentoSocio.ListarSegmento(Convert.ToInt32(cboTipoPersona1.SelectedValue));
        }

        private void chcXRangos_CheckedChanged(object sender, EventArgs e)
        {
            txtDescripcion.Visible = !chcXRangos.Checked;
            lblRangMin.Visible = chcXRangos.Checked;
            nudRangoMin.Visible = chcXRangos.Checked;
            lblRangMax.Visible = chcXRangos.Checked;
            nudRangoMax.Visible = chcXRangos.Checked;
        }

        #endregion

        #region Metodos

        private void CargarFactores()
        {
            int idTipoEval = Convert.ToInt32(cboTipoEval.SelectedValue);
            int idGrupoFactores = Convert.ToInt32(cboGrupoFactores.SelectedValue);
            dtFactores = cnScoring.ListaFactoresCalificacion(idTipoEval, 0, idGrupoFactores);
            dtgFactores.DataSource = dtFactores;
            FormatoDTGFactores();
            //VerificarPonderados();
        }

        private void FormatoDTGFactores()
        {
            foreach (DataGridViewColumn item in this.dtgFactores.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //this.dtgFactores.Columns["idFactor"].Visible = true;
            //this.dtgFactores.Columns["idFactorPadre"].Visible = true;
            this.dtgFactores.Columns["cDescripcion"].Visible = true;
            this.dtgFactores.Columns["nPonderado"].Visible = true;
            //this.dtgFactores.Columns["cCodEvenRiesgo"].Visible = true;
            this.dtgFactores.Columns["nPuntaje"].Visible = true;
            //this.dtgFactores.Columns["cFactores"].Visible = true;
            this.dtgFactores.Columns["cDescripcion"].HeaderText = "Factor de calificación";
            this.dtgFactores.Columns["nPonderado"].HeaderText = "Ponderado";
            this.dtgFactores.Columns["cCodEvenRiesgo"].HeaderText = "Cod Even Riesgo";

            this.dtgFactores.Columns["nPonderado"].DefaultCellStyle.Format = "P";

            this.dtgFactores.Columns["cDescripcion"].Width = 280;
        }

        private void VerDetallesFactor()
        {
            if (dtgFactores.SelectedRows.Count > 0 )
            {
                idFactor = Convert.ToInt32(dtgFactores.SelectedRows[0].Cells["idFactor"].Value);
                idPadre = Convert.ToInt32(dtgFactores.SelectedRows[0].Cells["idFactorPadre"].Value);
                nudPonderado.Value = Convert.ToDecimal(dtgFactores.SelectedRows[0].Cells["nPonderado"].Value)*100;
                txtCodigo.Text = Convert.ToString(dtgFactores.SelectedRows[0].Cells["cCodigo"].Value);
                txtDescripcion.Text = Convert.ToString(dtgFactores.SelectedRows[0].Cells["cFactores"].Value);
                cboCamposDTCli.SelectedValue = Convert.ToString(dtgFactores.SelectedRows[0].Cells["cColumna"].Value);
                cColumna = Convert.ToString(dtgFactores.SelectedRows[0].Cells["cColumna"].Value);
                lPuntuado = Convert.ToBoolean(dtgFactores.SelectedRows[0].Cells["lPreferId"].Value);
                nudPuntaje.Value = Convert.ToDecimal(dtgFactores.SelectedRows[0].Cells["nPuntaje"].Value);
                nudRangoMin.Value = Convert.ToDecimal(dtgFactores.SelectedRows[0].Cells["nIdFactEnTabla"].Value);
                if (!String.IsNullOrEmpty(dtgFactores.SelectedRows[0].Cells["nValorMaximo"].Value.ToString()))
                {
                    chcXRangos.Checked = true;
                    nudRangoMax.Value = Convert.ToDecimal(this.dtgFactores.SelectedRows[0].Cells["nValorMaximo"].Value);
                }
                else
                {
                    this.chcXRangos.Checked = false;
                }

                int i = this.dtgFactores.SelectedRows[0].Index+1;
                this.idFactorHijo = 0;
                this.lPuntuadoHijo = false;
                if (i < this.dtgFactores.Rows.Count)
                {
                    if (Convert.ToInt32(this.dtFactores.Rows[i]["idFactorPadre"]) == idFactor)
                    {
                        this.idFactorHijo = Convert.ToInt32(this.dtFactores.Rows[i]["idFactor"]);
                        this.lPuntuadoHijo = Convert.ToBoolean(this.dtFactores.Rows[i]["lPreferId"]);
                    }
                }

                //if (Convert.ToInt32(this.dtgFactores.SelectedRows[0].Cells["nIdFactEnTabla"].Value) == 0)
                //{
                //    this.chcSeleccionarFact.Checked = false;
                //}
                //else
                //{
                //    this.chcSeleccionarFact.Checked = true;
                //}
                this.chcSeleccionarFact.Checked = Convert.ToBoolean(this.dtgFactores.SelectedRows[0].Cells["nIdFactEnTabla"].Value);
            }
        }

        private void GuardarFactor()
        {

            int idNivel = Convert.ToInt32(this.cboNivel.SelectedValue);
            Decimal nValorMaximo = 0;
            //
            if (this.chcSeleccionarFact.Checked)
            {
                CapturaIdFactor();
            }
            else
            {
                this.nIdFactEnTabla = 0;
                if (this.chcXRangos.Checked)
                {
                    this.txtDescripcion.Text = String.Concat(this.nudRangoMin.Value, " - ", this.nudRangoMax.Value);
                    this.nIdFactEnTabla = this.nudRangoMin.Value;
                    nValorMaximo = this.nudRangoMax.Value;
                }
                cFactor = this.txtDescripcion.Text;
            }
            if (!ValidaDatos()) //Valida los datos
            {
                return;
            }
            Decimal nPonderado = this.nudPonderado.Value / 100;
            this.cColumna = Convert.ToString(this.cboCamposDTCli.SelectedValue);
            Boolean lConId = this.chcSeleccionarFact.Checked;
            if (cTipoOperacion == "N" && idNivel == 1)
            {
                if (this.chcXRangos.Checked)
                {
                    if (ValidaRangos(idPadre))
                    {
                        return;
                    }
                }
                DataTable dtInsercion = cnScoring.InsertarFactorCalificacion(Convert.ToInt32(this.cboTipoEval.SelectedValue), 0, idPadre, String.Empty, this.cFactor, Convert.ToDecimal(this.nIdFactEnTabla), nValorMaximo, this.txtCodigo.Text, nPonderado, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, this.cColumna, lConId, this.nudPuntaje.Value, true, this.chcXRangos.Checked);
                MessageBox.Show(dtInsercion.Rows[0]["cMensaje"].ToString(), cTituloMensajes, MessageBoxButtons.OK, ((int)dtInsercion.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
                if (idPadre == 0 )
                {
                    CargarCboGruposFactores();
                }
                else
                {
                    CargarFactores();
                }
            }
            else if (cTipoOperacion == "N" && idNivel == 2)
            {
                if (this.chcXRangos.Checked)
                {
                    if (ValidaRangos(idFactor))
                    {
                        return;
                    }
                }
                DataTable dtInsercion = cnScoring.InsertarFactorCalificacion(Convert.ToInt32(this.cboTipoEval.SelectedValue), 0, idFactor, String.Empty, this.cFactor, this.nIdFactEnTabla, nValorMaximo, this.txtCodigo.Text, nPonderado, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, this.cColumna, lConId, this.nudPuntaje.Value, true, this.chcXRangos.Checked);
                MessageBox.Show(dtInsercion.Rows[0]["cMensaje"].ToString(), cTituloMensajes, MessageBoxButtons.OK, ((int)dtInsercion.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
                CargarFactores();
            }
            else if (cTipoOperacion == "A")
            {
                DataTable dtInsercion = cnScoring.InsertarFactorCalificacion(Convert.ToInt32(this.cboTipoEval.SelectedValue), idFactor, idPadre, String.Empty, this.cFactor, this.nIdFactEnTabla, nValorMaximo, this.txtCodigo.Text, nPonderado, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, this.cColumna, lConId, this.nudPuntaje.Value, true, this.chcXRangos.Checked);
                MessageBox.Show(dtInsercion.Rows[0]["cMensaje"].ToString(), cTituloMensajes, MessageBoxButtons.OK, ((int)dtInsercion.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
                CargarFactores();
            }
            LimpiarCampos();
            HabilitarControles(false);
        }

        private void VerificarPonderados()
        {
            int idFactor = 0;
            bool lHayInconsistencia = false;
            decimal nSumaPonderado = 0;
            decimal nPonderado = 0;
            bool lHayHijos = false;
            for (int i = 0; i < dtFactores.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtFactores.Rows[i]["lUltimo"]) == 0)
                {
                    idFactor = Convert.ToInt32(dtFactores.Rows[i]["idFactor"]);
                    nPonderado = Convert.ToDecimal(dtFactores.Rows[i]["nPonderado"]);
                    nSumaPonderado = 0;
                    lHayHijos = false;
                    for (int k = 0; k < dtFactores.Rows.Count; k++)
                    {
                        if (idFactor == Convert.ToInt32(dtFactores.Rows[k]["idFactorPadre"]))
                        {
                            if (Convert.ToInt32(dtFactores.Rows[k]["lUltimo"]) == 0)
                            {
                                lHayHijos = true;
                            }
                            nSumaPonderado += Convert.ToDecimal(dtFactores.Rows[k]["nPonderado"]);
                        }
                    }
                    if (lHayHijos)
                    {
                        if (nPonderado != nSumaPonderado)
                        {
                            dtgFactores.Rows[i].DefaultCellStyle.BackColor = Color.MistyRose;
                            lHayInconsistencia = true;
                        }
                    }
                }
            }
            if (lHayInconsistencia)
            {
                MessageBox.Show("Existe inconsistencia en los ponderados", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CargarTiposEval()
        {
            //carga tipos de evaluacion
            //DataTable dtTiposEval = cnScoring.listaTiposEvaluacion(0);
            //dtTiposEval.DefaultView.RowFilter = ("lVigente = 1");
            //this.cboTipoEval.DataSource = dtTiposEval;
            //this.cboTipoEval.DisplayMember = "cEvaluacion";
            //this.cboTipoEval.ValueMember = "idEvaluacion";
        }

        private void CargarCboGruposFactores()
        {
            //carga grupos de factores de calificacion
            int idTipoEvaluacion = Convert.ToInt32(cboTipoEval.SelectedValue);
            cboGrupoFactores.CargarTodos(idTipoEvaluacion);
        }

        private void CargarCbos()
        {
            //carga tipos de comandos
            DataTable dtTipos = new DataTable();
            dtTipos.Columns.Add("idTipo", typeof(int));
            dtTipos.Columns.Add("cTipo", typeof(String));

            DataRow drTipo3 = dtTipos.NewRow();
            drTipo3["idTipo"] = 1;
            drTipo3["cTipo"] = "Actividad Económica";
            dtTipos.Rows.Add(drTipo3);
            DataRow drTipo19 = dtTipos.NewRow();
            drTipo19["idTipo"] = 19;
            drTipo19["cTipo"] = "Agencias";
            dtTipos.Rows.Add(drTipo19);
            DataRow drTipo22 = dtTipos.NewRow();
            drTipo22["idTipo"] = 22;
            drTipo22["cTipo"] = "Calificación crediticia";
            dtTipos.Rows.Add(drTipo22);
            DataRow drTipo6 = dtTipos.NewRow();
            drTipo6["idTipo"] = 2;
            drTipo6["cTipo"] = "Canales de distrib.";
            dtTipos.Rows.Add(drTipo6);
            DataRow drTipo12 = dtTipos.NewRow();
            drTipo12["idTipo"] = 12;
            drTipo12["cTipo"] = "Género";
            dtTipos.Rows.Add(drTipo12);
            DataRow drTipo24 = dtTipos.NewRow();
            drTipo24["idTipo"] = 24;
            drTipo24["cTipo"] = "Magnitud Empresarial";
            dtTipos.Rows.Add(drTipo24);
            DataRow drTipo5 = dtTipos.NewRow();
            drTipo5["idTipo"] = 3;
            drTipo5["cTipo"] = "Moneda";
            dtTipos.Rows.Add(drTipo5);
            DataRow drTipo11 = dtTipos.NewRow();
            drTipo11["idTipo"] = 11;
            drTipo11["cTipo"] = "Nacionalidad";
            dtTipos.Rows.Add(drTipo11);
            DataRow drTipo13 = dtTipos.NewRow();
            drTipo13["idTipo"] = 13;
            drTipo13["cTipo"] = "Naturaleza cliente";
            dtTipos.Rows.Add(drTipo13);
            DataRow drTipo14 = dtTipos.NewRow();
            drTipo14["idTipo"] = 14;
            drTipo14["cTipo"] = "Nivel de Instrucción";
            dtTipos.Rows.Add(drTipo14);
            DataRow drTipo10 = dtTipos.NewRow();
            drTipo10["idTipo"] = 10;
            drTipo10["cTipo"] = "Perfil de cliente";
            dtTipos.Rows.Add(drTipo10);
            DataRow drTipo4 = dtTipos.NewRow();
            drTipo4["idTipo"] = 4;
            drTipo4["cTipo"] = "Productos";
            dtTipos.Rows.Add(drTipo4);
            DataRow drTipo2 = dtTipos.NewRow();
            drTipo2["idTipo"] = 5;
            drTipo2["cTipo"] = "Profesiones u ocupaciones";
            dtTipos.Rows.Add(drTipo2);
            DataRow drTipo9 = dtTipos.NewRow();
            drTipo9["idTipo"] = 9;
            drTipo9["cTipo"] = "Regímenes";
            dtTipos.Rows.Add(drTipo9);
            DataRow drTipo16 = dtTipos.NewRow();
            drTipo16["idTipo"] = 16;
            drTipo16["cTipo"] = "Sector";
            dtTipos.Rows.Add(drTipo16);
            DataRow drTipo21 = dtTipos.NewRow();
            drTipo21["idTipo"] = 21;
            drTipo21["cTipo"] = "Segmento socioeco.";
            dtTipos.Rows.Add(drTipo21);
            DataRow drTipo7 = dtTipos.NewRow();
            drTipo7["idTipo"] = 6;
            drTipo7["cTipo"] = "Si o No";
            dtTipos.Rows.Add(drTipo7);
            DataRow drTipo18 = dtTipos.NewRow();
            drTipo18["idTipo"] = 18;
            drTipo18["cTipo"] = "Tipo construcción";
            dtTipos.Rows.Add(drTipo18);
            DataRow drTipo23 = dtTipos.NewRow();
            drTipo23["idTipo"] = 23;
            drTipo23["cTipo"] = "Tipo Doc. Adicional";
            dtTipos.Rows.Add(drTipo23);
            DataRow drTipo8 = dtTipos.NewRow();
            drTipo8["idTipo"] = 7;
            drTipo8["cTipo"] = "Tipo persona";
            dtTipos.Rows.Add(drTipo8);
            DataRow drTipo15 = dtTipos.NewRow();
            drTipo15["idTipo"] = 15;
            drTipo15["cTipo"] = "Tipo residencia";
            dtTipos.Rows.Add(drTipo15);
            DataRow drTipo20 = dtTipos.NewRow();
            drTipo20["idTipo"] = 20;
            drTipo20["cTipo"] = "Tipo rol hogar";
            dtTipos.Rows.Add(drTipo20);
            DataRow drTipo17 = dtTipos.NewRow();
            drTipo17["idTipo"] = 17;
            drTipo17["cTipo"] = "Tipo vivienda";
            dtTipos.Rows.Add(drTipo17);
            DataRow drTipo1 = dtTipos.NewRow();
            drTipo1["idTipo"] = 8;
            drTipo1["cTipo"] = "Ubigeo";
            dtTipos.Rows.Add(drTipo1);

            cboTipoFactor.DataSource = dtTipos;
            cboTipoFactor.DisplayMember = "cTipo";
            cboTipoFactor.ValueMember = "idTipo";

            //DT con campos de detalle de cliente, para asociarlos
            var lstClientes = new List<int>();
            lstClientes.Add(0);
            DataTable dtDatosCli = cnScoring.ListaDatosCliEvaluacion(lstClientes);
            DataTable dtCampos = new DataTable();
            dtCampos.Columns.Add("Campo", typeof(String));
            DataRow drFila0 = dtCampos.NewRow();
            drFila0["Campo"] = "";
            dtCampos.Rows.Add(drFila0);

            foreach (DataColumn item in dtDatosCli.Columns)
            {
                DataRow drFila = dtCampos.NewRow();
                drFila["Campo"] = item.ColumnName;
                dtCampos.Rows.Add(drFila);
            }

            cboCamposDTCli.DataSource = dtCampos;
            cboCamposDTCli.DisplayMember = "Campo";
            cboCamposDTCli.ValueMember = "Campo";
        }

        private void CargarSubControles()
        {
            //carga lista de profesiones
            clsCNProfesion listaProf = new clsCNProfesion();
            DataTable tbProf = listaProf.ListarProfesion();
            cboProfesion.DataSource = tbProf;
            cboProfesion.ValueMember = tbProf.Columns[0].ToString();
            cboProfesion.DisplayMember = tbProf.Columns[1].ToString();

            //carga modulos ahorros y creditos
            DataTable dtModulo = new DataTable();
            dtModulo.Columns.Add("idModulo", typeof(int));
            dtModulo.Columns.Add("cModulo", typeof(String));
            DataRow drModulo = dtModulo.NewRow();
            drModulo["idModulo"] = 1;
            drModulo["cModulo"] = "CRÉDITOS";
            dtModulo.Rows.Add(drModulo);
            DataRow drModulo2 = dtModulo.NewRow();
            drModulo2["idModulo"] = 2;
            drModulo2["cModulo"] = "AHORROS";
            dtModulo.Rows.Add(drModulo2);
            cboModulo.DataSource = dtModulo;
            cboModulo.DisplayMember = "cModulo";
            cboModulo.ValueMember = "idModulo";
            cboModulo.SelectedIndex = -1;

            //carga con de ubigeo
            conBusUbig1.cargar();

            //carga combo de si o no
            DataTable dtSiNo = new DataTable();
            dtSiNo.Columns.Add("id", typeof(int));
            dtSiNo.Columns.Add("cDes", typeof(String));
            DataRow drSiNo1 = dtSiNo.NewRow();
            drSiNo1["id"] = 1;
            drSiNo1["cDes"] = "SI";
            dtSiNo.Rows.Add(drSiNo1);
            DataRow drSiNo2 = dtSiNo.NewRow();
            drSiNo2["id"] = 0;
            drSiNo2["cDes"] = "NO";
            dtSiNo.Rows.Add(drSiNo2);
            cboSiNo.DataSource = dtSiNo;
            cboSiNo.DisplayMember = "cDes";
            cboSiNo.ValueMember = "id";

            //COMBO de regimenes
            DataTable dtRegimenes = cnScoring.ListaRegimenes(0);
            dtRegimenes.DefaultView.RowFilter = ("lVigente = 1");
            cboRegimen.DataSource = dtRegimenes;
            cboRegimen.DisplayMember = "cRegimen";
            cboRegimen.ValueMember = "idRegimen";

            //combo perfiles
            DataTable dtPerfiles = cnmapeoriesgoyopeinusual.listaPerfilCli(0);
            dtPerfiles.DefaultView.RowFilter = "lVigente = 1";
            cboPerfiles.DataSource = dtPerfiles;
            cboPerfiles.DisplayMember = "cPerfilCliOpeInusual";
            cboPerfiles.ValueMember = "idPerfilCliOpeInusual";

            //combo nacionao o extranjero
            DataTable dtNacionalExtranj = new DataTable();
            dtNacionalExtranj.Columns.Add("id", typeof(int));
            dtNacionalExtranj.Columns.Add("cDes", typeof(String));
            DataRow drNoE2 = dtNacionalExtranj.NewRow();
            drNoE2["id"] = 0;
            drNoE2["cDes"] = "PERUANA";
            dtNacionalExtranj.Rows.Add(drNoE2);
            DataRow drNoE1 = dtNacionalExtranj.NewRow();
            drNoE1["id"] = 1;
            drNoE1["cDes"] = "EXTRANJERA";
            dtNacionalExtranj.Rows.Add(drNoE1);
            cboNacionalExtranj.DataSource = dtNacionalExtranj;
            cboNacionalExtranj.DisplayMember = "cDes";
            cboNacionalExtranj.ValueMember = "id";

            //combo magnitud empresarial

            //combo naturaleza
            cboTipClasif.CargarClasificacion(1);

            // Carga Datos deNivel de Instruccion
            clsCNNivInstruccion listaNivInst = new clsCNNivInstruccion();
            DataTable tbNivInst = listaNivInst.ListarNivInstruccion();
            cboNivInstruc.DataSource = tbNivInst;
            cboNivInstruc.ValueMember = tbNivInst.Columns[0].ToString();
            cboNivInstruc.DisplayMember = tbNivInst.Columns[1].ToString();

            //combo calificacion
        }

        private void MuestraControlFactor()
        {
            if (Convert.ToInt32(cboTipoFactor.SelectedValue) == 1) // Actividad Económica
            {
                conActividad1.Visible = true;
            }
            else if (Convert.ToInt32(cboTipoFactor.SelectedValue) == 2) // Canales
            {
                cboCanal1.Visible = true;
                lblCanal.Visible = true;
            }
            else if (Convert.ToInt32(cboTipoFactor.SelectedValue) == 3) // Moneda
            {
                cboMoneda.Visible = true;
                lblMoneda.Visible = true;
            }
            else if (Convert.ToInt32(cboTipoFactor.SelectedValue) == 4) // Productos
            {
                lblProductos.Visible = true;
                cboProductos.Visible = true;
                lblComentProd.Visible = true;
                lblModulo.Visible = true;
                cboModulo.Visible = true;
            }
            else if (Convert.ToInt32(cboTipoFactor.SelectedValue) == 5) // Profesiones
            {
                cboProfesion.Visible = true;
                lblProfesion.Visible = true;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 6) // Si o No
            {
                cboSiNo.Visible = true;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 7) // Tipo de persona
            {
                lblTipoPersona.Visible = true;
                cboTipoPersona1.Visible = true;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 8) // Ubigeo
            {
                conBusUbig1.Visible = true;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 9) // Regimenes
            {
                lblRegimen.Visible = true;
                cboRegimen.Visible = true;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 10) // Perfiles de cliente
            {
                this.lblPerfiles.Visible = true;
                this.cboPerfiles.Visible = true;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 11) // _Nacional o internacional
            {
                this.lblNacionalExtranj.Visible = true;
                this.cboNacionalExtranj.Visible = true;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 12) // Género (Sexo)
            {
                this.lblSexo.Visible = true;
                this.cboSexo1.Visible = true;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 13) // Naturaleza
            {
                this.lblTipoPersona.Visible = true;
                this.cboTipoPersona1.Visible = true;
                this.lblTipoClasif.Visible = true;
                this.cboTipClasif.Visible = true;
                this.cboTipoPersona1.SelectedIndexChanged += new EventHandler(cboTipoPersona_SelectedIndexChanged);
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 14) // Nivel de instruccion
            {
                this.lblNivInstruc.Visible = true;
                this.cboNivInstruc.Visible = true;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 15) // Tipo de residencia
            {
                this.lblTipoResidencia.Visible = true;
                this.cboTipoResidencia1.Visible = true;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 16) // Sector
            {
                this.lblSector.Visible = true;
                this.cboSector.Visible = true;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 17) // Tipo de vivienda
            {
                this.lblTipVivienda.Visible = true;
                this.cboTipVivienda.Visible = true;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 18) // Tipo de construcción
            {
                this.lblTipoConst.Visible = true;
                this.cboTipoConst.Visible = true;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 19) // Agencias
            {
                this.lblAgencia.Visible = true;
                this.cboAgencia.Visible = true;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 20) // Tipo rol en hogar
            {
                this.lblTipoRolHogar.Visible = true;
                this.cboTipoRolHogar.Visible = true;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 21) // Segmento socio
            {
                this.lblTipoPersona.Visible = true;
                this.cboTipoPersona1.Visible = true;
                this.lblSegmentoSocio.Visible = true;
                this.cboSegmentoSocio.Visible = true;
                this.cboTipoPersona1.SelectedIndexChanged += new EventHandler(cboTipoPersona_SelectedIndexChanged);
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 22) // Calificacion crediticia
            {
                this.lblCalificCred.Visible = true;
                this.cboCalificCred.Visible = true;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 23) // Tipo doc. adicional
            {
                this.lblTipoDocAdi.Visible = true;
                this.cboTipDocAdi.Visible = true;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 24) // Magnitud empresarial
            {
                this.lblMagnitudEmp.Visible = true;
                this.cboMagnitudEmp.Visible = true;
            }
        }

        private void CapturaIdFactor()
        {
            clsCNUbigeo cnUbigeo = new clsCNUbigeo();
            if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 1) // Actividad Económica
            {
                this.cFactor = Convert.ToString(((DataRowView)this.conActividad1.cboCIIU.SelectedItem)[this.conActividad1.cboCIIU.DisplayMember]);
                this.nIdFactEnTabla = Convert.ToInt32(this.conActividad1.cboCIIU.SelectedValue);
                //this.cColumna = this.conActividad1.cboCIIU.ValueMember;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 2) // Canales
            {
                this.cFactor = Convert.ToString(((DataRowView)this.cboCanal1.SelectedItem)[this.cboCanal1.DisplayMember]);
                this.nIdFactEnTabla = Convert.ToInt32(this.cboCanal1.SelectedValue);
               // this.cColumna = this.cboCanal1.ValueMember;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 3) // Moneda
            {
                this.cFactor = Convert.ToString(((DataRowView)this.cboMoneda.SelectedItem)[this.cboMoneda.DisplayMember]);
                this.nIdFactEnTabla = Convert.ToInt32(this.cboMoneda.SelectedValue);
                //this.cColumna = this.cboMoneda1.ValueMember;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 4) // Productos
            {
                this.cFactor = Convert.ToString(((DataRowView)this.cboProductos.SelectedItem)[this.cboProductos.DisplayMember]);
                this.nIdFactEnTabla = Convert.ToInt32(this.cboProductos.SelectedValue);
               // this.cColumna = this.cboProductos.ValueMember;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 5) // Profesiones
            {
                this.cFactor = Convert.ToString(((DataRowView)this.cboProfesion.SelectedItem)[this.cboProfesion.DisplayMember]);
                this.nIdFactEnTabla = Convert.ToInt32(this.cboProfesion.SelectedValue);
                this.cColumna = this.cboProfesion.ValueMember;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 6) // Si o No
            {
                this.cFactor = Convert.ToString(((DataRowView)this.cboSiNo.SelectedItem)[this.cboSiNo.DisplayMember]);
                this.nIdFactEnTabla = Convert.ToInt32(this.cboSiNo.SelectedValue);
               // this.cColumna = String.Empty;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 7) // Tipo de persona
            {
                this.cFactor = Convert.ToString(((DataRowView)this.cboTipoPersona1.SelectedItem)[this.cboTipoPersona1.DisplayMember]);
                this.nIdFactEnTabla = Convert.ToInt32(this.cboTipoPersona1.SelectedValue);
               // this.cColumna = this.cboTipoPersona1.ValueMember;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 8) // ubigeo
            {
                if (Convert.ToInt32(this.conBusUbig1.cboPais.SelectedValue) != 173 )
                {
                    this.cFactor = Convert.ToString(((DataRowView)this.conBusUbig1.cboPais.SelectedItem)[this.conBusUbig1.cboPais.DisplayMember]);
                    this.nIdFactEnTabla = Convert.ToInt32(this.conBusUbig1.cboPais.SelectedValue);
                }
                else
                {
                    DataTable dtUbigeo = cnUbigeo.ListarNombresUbig(Convert.ToInt32(this.conBusUbig1.nIdNodo), Convert.ToInt32(this.conBusUbig1.nIdNodo), Convert.ToInt32(this.conBusUbig1.nIdNodo), Convert.ToInt32(this.conBusUbig1.nIdNodo));
                    this.cFactor = Convert.ToString(dtUbigeo.Rows[0]["cDescipcion"].ToString());
                    this.nIdFactEnTabla = Convert.ToInt32(this.conBusUbig1.nIdNodo);
                }
                //this.cColumna = this.conBusUbig1.cboDepartamento.ValueMember;
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 9) // Regimenes
            {
                this.cFactor = Convert.ToString(((DataRowView)this.cboRegimen.SelectedItem)[this.cboRegimen.DisplayMember]);
                this.nIdFactEnTabla = Convert.ToInt32(this.cboRegimen.SelectedValue);
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 10) // Perfiles de cliente
            {
                this.cFactor = Convert.ToString(((DataRowView)this.cboPerfiles.SelectedItem)[this.cboPerfiles.DisplayMember]);
                this.nIdFactEnTabla = Convert.ToInt32(this.cboPerfiles.SelectedValue);
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 11) // Nacional o internacional
            {
                this.cFactor = Convert.ToString(((DataRowView)this.cboNacionalExtranj.SelectedItem)[this.cboNacionalExtranj.DisplayMember]);
                this.nIdFactEnTabla = Convert.ToInt32(this.cboNacionalExtranj.SelectedValue);
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 12) // Género (Sexo)
            {
                this.cFactor = Convert.ToString(((DataRowView)this.cboSexo1.SelectedItem)[this.cboSexo1.DisplayMember]);
                this.nIdFactEnTabla = Convert.ToInt32(this.cboSexo1.SelectedValue);
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 13) // Naturaleza
            {
                this.cFactor = Convert.ToString(((DataRowView)this.cboTipClasif.SelectedItem)[this.cboTipClasif.DisplayMember]);
                this.nIdFactEnTabla = Convert.ToInt32(this.cboTipClasif.SelectedValue);
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 14) // Nivel de instruccion
            {
                this.cFactor = Convert.ToString(((DataRowView)this.cboNivInstruc.SelectedItem)[this.cboNivInstruc.DisplayMember]);
                this.nIdFactEnTabla = Convert.ToInt32(this.cboNivInstruc.SelectedValue);
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 15) // Tipo de residencia
            {
                this.cFactor = Convert.ToString(((DataRowView)this.cboTipoResidencia1.SelectedItem)[this.cboTipoResidencia1.DisplayMember]);
                this.nIdFactEnTabla = Convert.ToInt32(this.cboTipoResidencia1.SelectedValue);
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 16) // Sector
            {
                this.cFactor = Convert.ToString(((DataRowView)this.cboSector.SelectedItem)[this.cboSector.DisplayMember]);
                this.nIdFactEnTabla = Convert.ToInt32(this.cboSector.SelectedValue);
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 17) // Tipo de vivienda
            {
                this.cFactor = Convert.ToString(((DataRowView)this.cboTipVivienda.SelectedItem)[this.cboTipVivienda.DisplayMember]);
                this.nIdFactEnTabla = Convert.ToInt32(this.cboTipVivienda.SelectedValue);
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 18) // Tipo de construcción
            {
                this.cFactor = Convert.ToString(((DataRowView)this.cboTipoConst.SelectedItem)[this.cboTipoConst.DisplayMember]);
                this.nIdFactEnTabla = Convert.ToInt32(this.cboTipoConst.SelectedValue);
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 19) // Agencias
            {
                this.cFactor = Convert.ToString(((DataRowView)this.cboAgencia.SelectedItem)[this.cboAgencia.DisplayMember]);
                this.nIdFactEnTabla = Convert.ToInt32(this.cboAgencia.SelectedValue);
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 20) // Tipo rol en hogar
            {
                this.cFactor = Convert.ToString(((DataRowView)this.cboTipoRolHogar.SelectedItem)[this.cboTipoRolHogar.DisplayMember]);
                this.nIdFactEnTabla = Convert.ToInt32(this.cboTipoRolHogar.SelectedValue);
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 21) // Segmento socio
            {
                this.cFactor = Convert.ToString(((DataRowView)this.cboSegmentoSocio.SelectedItem)[this.cboSegmentoSocio.DisplayMember]);
                this.nIdFactEnTabla = Convert.ToInt32(this.cboSegmentoSocio.SelectedValue);
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 22) // calificacion crediticia
            {
                this.cFactor = Convert.ToString(((DataRowView)this.cboCalificCred.SelectedItem)[this.cboCalificCred.DisplayMember]);
                this.nIdFactEnTabla = Convert.ToInt32(this.cboCalificCred.SelectedValue);
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 23) // Tipo doc. adicional
            {
                this.cFactor = Convert.ToString(((DataRowView)this.cboTipDocAdi.SelectedItem)[this.cboTipDocAdi.DisplayMember]);
                this.nIdFactEnTabla = Convert.ToInt32(this.cboTipDocAdi.SelectedValue);
            }
            else if (Convert.ToInt32(this.cboTipoFactor.SelectedValue) == 24) // Magnitud empresarial
            {
                this.cFactor = Convert.ToString(((DataRowView)this.cboMagnitudEmp.SelectedItem)[this.cboMagnitudEmp.DisplayMember]);
                this.nIdFactEnTabla = Convert.ToInt32(this.cboMagnitudEmp.SelectedValue);
            }
        }

        private void OcultarTodosPanelFact()
        {
            conBusUbig1.Visible = false;
            cboProfesion.Visible = false;
            lblProfesion.Visible = false;
            conActividad1.Visible = false;
            lblProductos.Visible = false;
            cboProductos.Visible = false;
            lblComentProd.Visible = false;
            lblModulo.Visible = false;
            cboModulo.Visible = false;
            cboMoneda.Visible = false;
            lblMoneda.Visible = false;
            cboCanal1.Visible = false;
            lblCanal.Visible = false;
            lblSiNo.Visible = false;
            cboSiNo.Visible = false;
            lblTipoPersona.Visible = false;
            cboTipoPersona1.Visible = false;
            lblRegimen.Visible = false;
            cboRegimen.Visible = false;
            lblPerfiles.Visible = false;
            cboPerfiles.Visible = false;
            lblNacionalExtranj.Visible = false;
            cboNacionalExtranj.Visible = false;
            lblMagnitudEmpresarial.Visible = false;
            cboMagnitudEmpresarial.Visible = false;
            lblSexo.Visible = false;
            cboSexo1.Visible = false;
            lblTipoClasif.Visible = false;
            cboTipClasif.Visible = false;
            cboTipoPersona1.SelectedIndexChanged -= new EventHandler(cboTipoPersona_SelectedIndexChanged);
            lblNivInstruc.Visible = false;
            cboNivInstruc.Visible = false;
            lblTipoResidencia.Visible = false;
            cboTipoResidencia1.Visible = false;
            lblSector.Visible = false;
            cboSector.Visible = false;
            lblTipVivienda.Visible = false;
            cboTipVivienda.Visible = false;
            lblTipoConst.Visible = false;
            cboTipoConst.Visible = false;
            lblAgencia.Visible = false;
            cboAgencia.Visible = false;
            lblTipoRolHogar.Visible = false;
            cboTipoRolHogar.Visible = false;
            lblSegmentoSocio.Visible = false;
            cboSegmentoSocio.Visible = false;
            lblCondDomNat.Visible = false;
            cboCondDomNat.Visible = false;
            lblCalificCred.Visible = false;
            cboCalificCred.Visible = false;
            lblTipoDocAdi.Visible = false;
            cboTipDocAdi.Visible = false;
            lblMagnitudEmp.Visible = false;
            cboMagnitudEmp.Visible = false;
        }

        private void HabilitarControles(bool Val)
        {
            btnNuevo.Enabled = !Val;
            btnEditar.Enabled = !Val;
            btnGrabar.Enabled = Val;
            btnCancelar.Enabled = Val;
            btnEliminar.Enabled = !Val;

            cboNivel.Enabled = Val;
            cboCamposDTCli.Enabled = Val;
            nudPonderado.Enabled = Val;
            txtCodigo.Enabled = Val;
            txtDescripcion.Enabled = Val;
            chcSeleccionarFact.Enabled = Val;
            nudPuntaje.Enabled = Val;
            chcXRangos.Enabled = Val;
            nudRangoMin.Enabled = Val;
            nudRangoMax.Enabled = Val;

            if (cTipoOperacion == "A")
            {
                txtDescripcion.Enabled = false;
                chcSeleccionarFact.Enabled = false;
                cboTipoFactor.Enabled = false;
                chcXRangos.Enabled = false;
                nudRangoMin.Enabled = false;
                nudRangoMax.Enabled = false;
            }

            dtgFactores.Enabled = !Val;

            cboTipoEval.Enabled = !Val;
            cboGrupoFactores.Enabled = !Val;
        }

        private void LimpiarCampos()
        {
            cboNivel.SelectedIndex = 0;
            nudPonderado.Value = 0.00m;
            txtCodigo.Clear();
            txtDescripcion.Clear();
            chcSeleccionarFact.Checked = false;
            nudPuntaje.Value = 0.00m;
            nudRangoMin.Value = 0.00m;
            nudRangoMax.Value = 0.00m;
        }

        private void HabilitarSeleccionFactor()
        {
            if (!chcSeleccionarFact.Enabled)
            {
                return;
            }
            if (chcSeleccionarFact.Checked)
            {
                cboTipoFactor.Enabled = true;
                grbFactores.Enabled = true;
                txtDescripcion.Enabled = false;
                chcXRangos.Checked = false;
                chcXRangos.Enabled = false;
                if (cTipoOperacion == "N")
                {
                    this.txtDescripcion.Clear();
                }
            }
            else
            {
                cboTipoFactor.SelectedIndex = -1;
                cboTipoFactor.Enabled = false;
                grbFactores.Enabled = false;
                txtDescripcion.Enabled = true;
                chcXRangos.Enabled = true;
            }
        }

        private void HabilitarDeAcuerdoAnivel()
        {
            if (Convert.ToInt32(cboNivel.SelectedValue) == 1)
            {
                cboCamposDTCli.Enabled = true;
                txtCodigo.Enabled = false;

                if (idPadre == 0)
                {
                    txtCodigo.Enabled = true;
                    cboCamposDTCli.Enabled = false;
                }
            }
            else
            {
                txtCodigo.Enabled = false;
                txtCodigo.Clear();

                cboCamposDTCli.Enabled = true;

                if (idPadre == 0)
                {
                    cboCamposDTCli.Enabled = true;
                }
            }
        }

        private bool ValidaDatos()
        {
            if (chcXRangos.Checked)
            {
                if (nudRangoMin.Value > nudRangoMax.Value)
                {
                    MessageBox.Show("Rango máximo debe ser mayor a mínimo", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nudRangoMax.Focus();
                    return false;
                }
            }
            if (!chcSeleccionarFact.Checked && String.IsNullOrEmpty(this.txtDescripcion.Text))
            {
                MessageBox.Show("Ingrese un nombre de factor de calificación", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescripcion.Focus();
                return false;
            }
            int idNivel = Convert.ToInt32(cboNivel.SelectedValue);
            if (idPadre != 0)
            {
                if (cboCamposDTCli.SelectedIndex < 0) //Validamos que se seleccione un campo
                {
                    MessageBox.Show("Seleccione un atributo", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboCamposDTCli.Focus();
                    return false;
                }
            }
            else
            {
                if (idNivel == 1)
                {
                    if (String.IsNullOrEmpty(txtCodigo.Text))
                    {
                        MessageBox.Show("Ingrese un codigo único para el nuevo grupo", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCodigo.Focus();
                        return false;
                    }
                }
                else if (idNivel == 2)
                {
                    if (cboCamposDTCli.SelectedIndex < 0) //Validamos que se seleccione un campo
                    {
                        MessageBox.Show("Seleccione un atributo", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.cboCamposDTCli.Focus();
                        return false;
                    }
                }
            }
            return true;
        }

        private bool ValidaRangos(int idPadre)
        {
            bool nEstado = false;
            foreach (DataGridViewRow item in dtgFactores.Rows)
            {
                if (Convert.ToInt32(item.Cells["idFactorPadre"].Value) == idPadre)
                {
                    nEstado = true;
                    if ((Convert.ToDecimal(item.Cells["nIdFactEnTabla"].Value) <= nudRangoMin.Value && nudRangoMin.Value <= Convert.ToDecimal(item.Cells["nValorMaximo"].Value))
                    || (Convert.ToDecimal(item.Cells["nIdFactEnTabla"].Value) <= nudRangoMax.Value && nudRangoMax.Value <= Convert.ToDecimal(item.Cells["nValorMaximo"].Value)))
                    {
                        MessageBox.Show("Rangos se superponen a rangos existentes", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        nudRangoMax.Focus();
                        return true;
                    }
                }

                if (nEstado && String.IsNullOrEmpty(item.Cells["nValorMaximo"].Value.ToString()))
                {
                    break;
                }
            }
            return false;
        }

        #endregion

    }
}
