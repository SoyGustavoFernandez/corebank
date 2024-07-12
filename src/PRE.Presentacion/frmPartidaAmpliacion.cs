using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using PRE.CapaNegocio;
using EntityLayer;

namespace PRE.Presentacion
{
    public partial class frmPartidaAmpliacion : frmBase
    {
        #region Variables Globales

        private clsCNPartidaModificacion cnpartidamodificacion = new clsCNPartidaModificacion();
        private clsCNPartidasPres cnpartidaspres = new clsCNPartidasPres();

        private List<string> cValoresPres = new List<string>();
        private List<string> cValoresSaldo = new List<string>();

        private int idTipoModificacion = 2;
        private int idPeriodoSelec;
        private int idModificacion = 0;
        private int idPartidaG = 0;
        private int nEnero = 2;

        private bool lEsEjecucion = false;

        private string cTituloMensate = "Partidas de Ampliación";
        #endregion
        #region Eventos
        public frmPartidaAmpliacion()
        {
            InitializeComponent();
        }
        private void frmAmpliacionPartida_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            if (verificarEstadoPeriodo())
            {
                mostrarMesActual();
                verificarEstadoPeriodo();
                habilitarControles(false);
                listarPartidasModif();
                formatearGridPartidasModif();
            }
            else
            {
                bloquearTodo();
            }

        }
        private void frmPartidaAmpliacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtgPartidaPres.CancelEdit();
            dtgPartidaPres.DataSource = null;
        }
        private void cboPeriodoPresupuestal_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificarEstadoPeriodo();
            habilitarControles(false);
            limpiarControles();
            listarPartidasModif();
        }

        private void dtgPartidasAmpl_SelectionChanged(object sender, EventArgs e)
        {
            limpiarControles();
            habilitarControles(false);
            mostrarDetallesModif();
        }
        private void dtgPartidaPres_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (Convert.ToInt32(e.ColumnIndex) >= nEnero && Convert.ToInt32(e.ColumnIndex) < nEnero + 12)
            {
                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    MessageBox.Show("El campo no puede ser vacio", cTituloMensate, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtgPartidaPres.CancelEdit();
                    return;
                }
                else if (verificarDecimal(e.FormattedValue.ToString()))
                {
                    MessageBox.Show("No es un número correcto", cTituloMensate, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtgPartidaPres.CancelEdit();
                }
            }
        }
        private void dtgPartidaPres_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int nColumnaActual = e.ColumnIndex;
            editarCeldas(nColumnaActual);
        }
        private void dtgPartidaPres_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(Numeric_KeyPress);
            }
        }
        private void Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || Convert.ToInt32(e.KeyChar).In(8, 13, 46))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnBuscaPartida_Click(object sender, EventArgs e)
        {
            buscarPartida();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarControles();
            habilitarControles(true);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarControles();
            habilitarControles(false);
            mostrarDetallesModif();
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (verificarDetallesModif())
            {
                DataTable dtValoresNuevos = new DataTable();
                darFormatoDTValoresParaGuardar(dtValoresNuevos);
                String cCodigo = txtCodigo.Text.ToString();
                String cJustific = txtFundamento.Text.ToString();
                int idUsuReg = clsVarGlobal.User.idUsuario;
                DateTime dFechaReg = clsVarGlobal.dFecSystem;
                Decimal nMovimiento = Convert.ToDecimal(txtMovimiento.Text);
                String xmlValoresModificados = llenarCeldasModificadas(dtValoresNuevos);
                insertarNuevaPartida(0, cJustific, idPeriodoSelec, idTipoModificacion, Convert.ToInt32(conBusUsuSolicitante.idCliPer), idUsuReg, dFechaReg, idPartidaG, 0, xmlValoresModificados, nMovimiento, clsVarGlobal.nIdAgencia);
                listarPartidasModif();
                habilitarControles(false);
            }
        }
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            int idSolicitud = Convert.ToInt32(this.dtgPartidasAmpl.SelectedRows[0].Cells["idSolAproba"].Value);
            ejecutarAmpliacion(idSolicitud, (int)this.cboPeriodoPresupuestal.SelectedValue, idModificacion, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
        }
        #endregion
        #region Metodos
        private bool verificarEstadoPeriodo()
        {
            if (cboPeriodoPresupuestal.SelectedItem == null)
            {
                return false;
            }
            else
            {
                idPeriodoSelec = Convert.ToInt32(this.cboPeriodoPresupuestal.SelectedValue);

                DataTable dtPeriodoSelect = new clsCNPeriodos().PeriodosPresupuesto(idPeriodoSelec);
                this.lblEstado.Text = Convert.ToString(dtPeriodoSelect.Rows[0]["cEstado"]);
                int nEstado = Convert.ToInt32(dtPeriodoSelect.Rows[0]["idEstado"]);


                if (nEstado == 2)
                {
                    this.lblEstado.ForeColor = Color.RoyalBlue;
                    lEsEjecucion = true;
                }
                else if (nEstado == 1)
                {
                    this.lblEstado.ForeColor = Color.DarkGreen;
                    lEsEjecucion = false;
                }
                else
                {
                    this.lblEstado.ForeColor = Color.Gray;
                    lEsEjecucion = false;
                }

                return true;
            }

        }
        private void mostrarMesActual()
        {
            DateTime dNombreMes = clsVarGlobal.dFecSystem;
            string cNombreMes = dNombreMes.ToString("MMMM");
            TextInfo textInfo = new CultureInfo("es-PE", false).TextInfo;
            cNombreMes = textInfo.ToTitleCase(cNombreMes);
            lblNombreMes.Text = cNombreMes;
        }
        private void habilitarControles(Boolean lVal)
        {
            if (lEsEjecucion)
            {
                btnNuevo.Enabled = !lVal;
                btnBuscaPartida.Enabled = lVal;
                conBusUsuSolicitante.txtCod.Enabled = lVal;
                conBusUsuSolicitante.btnConsultar.Enabled = lVal;
                txtFundamento.Enabled = lVal;
                txtNombrePartida.Enabled = lVal;
            }
            else
            {
                btnNuevo.Enabled = lVal;
                btnBuscaPartida.Enabled = lVal;
                conBusUsuSolicitante.txtCod.Enabled = lVal;
                conBusUsuSolicitante.btnConsultar.Enabled = lVal;
                txtFundamento.Enabled = lVal;
                txtNombrePartida.Enabled = lVal;
            }
            btnCancelar.Enabled = lVal;
            btnGrabar.Enabled = lVal;
        }
        private void limpiarControles()
        {
            txtCodigo.Clear();
            txtFundamento.Clear();
            txtNombrePartida.Clear();
            cboLimAplicaSaldo.SelectedValue = -1;
            cboNivelAprobacion.SelectedValue = -1;
            dtgPartidaPres.DataSource = null;
            conBusUsuSolicitante.txtCargo.Clear();
            conBusUsuSolicitante.txtCod.Clear();
            conBusUsuSolicitante.txtNom.Clear();
            txtMovimiento.Clear();
        }

        private void listarPartidasModif()
        {
            DataTable dtPartidas = new DataTable();
            dtPartidas = cnpartidamodificacion.ListarTodosPartidasModificacion(idPeriodoSelec, idTipoModificacion);
            if (dtPartidas.Rows.Count <= 0)
            {
                habilitarControles(false);
                limpiarControles();
            }
            dtgPartidasAmpl.DataSource = dtPartidas;
        }
        private void mostrarDetallesModif()
        {
            if (dtgPartidasAmpl.SelectedRows.Count > 0)
            {
                idModificacion = Convert.ToInt32(dtgPartidasAmpl.SelectedRows[0].Cells["idPartidaModificacion"].Value);
                txtCodigo.Text = Convert.ToString(dtgPartidasAmpl.SelectedRows[0].Cells["cCodigoPartida"].Value);
                txtFundamento.Text = Convert.ToString(dtgPartidasAmpl.SelectedRows[0].Cells["cFundamento"].Value);

                txtMovimiento.Text = String.Format("{0:#,0.00}", dtgPartidasAmpl.SelectedRows[0].Cells["nMonto"].Value);
                conBusUsuSolicitante.txtCod.Text = Convert.ToString(dtgPartidasAmpl.SelectedRows[0].Cells["idUsuario"].Value);
                conBusUsuSolicitante.BusPerByCod();

                idPartidaG = Convert.ToInt32(dtgPartidasAmpl.SelectedRows[0].Cells["idPartidaOrigen"].Value);
                cValoresPres.Clear();
                cValoresSaldo.Clear();
                llenarPartidaActorasDeBD(idPartidaG, this.txtNombrePartida, null, this.cboLimAplicaSaldo, this.dtgPartidaPres);
                if (Convert.ToInt32(this.dtgPartidasAmpl.SelectedRows[0].Cells["idEstadoSolicitud"].Value) == 2)
                {
                    this.grbProcesar.Visible = true;
                }
                else
                {
                    this.grbProcesar.Visible = false;
                }
            }
            else
            {
                idModificacion = 0;
                dtgPartidaPres.DataSource = null;
            }
        }
        private void formatearGridPartidasModif()
        {
            foreach (DataGridViewColumn item in this.dtgPartidasAmpl.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;

            }
            this.dtgPartidasAmpl.Columns["cCodigoPartida"].Visible = true;
            this.dtgPartidasAmpl.Columns["nMonto"].Visible = true;
            this.dtgPartidasAmpl.Columns["idCliSolicita"].Visible = true;
            this.dtgPartidasAmpl.Columns["idSolAproba"].Visible = true;
            this.dtgPartidasAmpl.Columns["cEstadoSol"].Visible = true;
            this.dtgPartidasAmpl.Columns["dFechaAprobacion"].Visible = true;

            this.dtgPartidasAmpl.Columns["nMonto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dtgPartidasAmpl.Columns["cCodigoPartida"].HeaderText = "Código";
            this.dtgPartidasAmpl.Columns["nMonto"].HeaderText = "Movimiento";
            this.dtgPartidasAmpl.Columns["idCliSolicita"].HeaderText = "Us. solicitante";
            this.dtgPartidasAmpl.Columns["idSolAproba"].HeaderText = "Nº Solicitud";
            this.dtgPartidasAmpl.Columns["cEstadoSol"].HeaderText = "Est. solicitud";
            this.dtgPartidasAmpl.Columns["dFechaAprobacion"].HeaderText = "Fecha";

        }
        private void llenarPartidaActorasDeBD(int idPartida, txtBase txtNombreP, nudBase nudPorcentaje, cboLimAplicaSaldo cboAplicSaldo, dtgBase dtgGrilla)
        {
            int idPeriodo = Convert.ToInt32(this.cboPeriodoPresupuestal.SelectedValue);
            frmBuscarPartidaPre frmbuscarpartidapre = new frmBuscarPartidaPre();
            frmbuscarpartidapre.idPeriodoSelec = idPeriodo;
            frmbuscarpartidapre.idPartidaBuscada = idPartida;
            frmbuscarpartidapre.buscarPorIdPartida();

            cboAplicSaldo.SelectedValue = frmbuscarpartidapre.idLimAplicBuscado;
            cboNivelAprobacion.SelectedValue = frmbuscarpartidapre.idNivelAprobacion;
            txtNombreP.Text = frmbuscarpartidapre.cDescripcionBuscada;
            if (nudPorcentaje != null)
            {
                nudPorcentaje.Value = frmbuscarpartidapre.nPorcentajeAsigBuscado;
            }
            DataTable dtModicacionPresupuesto = cnpartidamodificacion.ListaPresupuestoPartidaModificada(idPeriodo, idModificacion, idPartida);
            formatearGridPartida(dtModicacionPresupuesto, dtgGrilla);
            pintarMesModificado(dtgGrilla);
        }
        private void llenarGridPartida(int idPartida, DataGridView dtgUso)
        {
            DataTable dtPresupuesto = new DataTable();
            dtPresupuesto = cnpartidaspres.ListarValoresDeUnaPartida(idPeriodoSelec, idPartida);
            formatearGridPartida(dtPresupuesto, dtgUso);
        }

        private void buscarPartida()
        {
            frmBuscarPartidaPre frmbuscarpartidapre = new frmBuscarPartidaPre();
            frmbuscarpartidapre.idPeriodoSelec = idPeriodoSelec;
            frmbuscarpartidapre.ShowDialog();
            if (frmbuscarpartidapre.idPartidaBuscada == 0)
            {
                return;
            }
            else
            {
                idPartidaG = frmbuscarpartidapre.idPartidaBuscada;
                string cDescripcion = frmbuscarpartidapre.cDescripcionBuscada;
                decimal nPresupuestoApertura = frmbuscarpartidapre.nPresAperBuscado;
                int idLimAplicacion = frmbuscarpartidapre.idLimAplicBuscado;
                int idNivelAprob = frmbuscarpartidapre.idNivelAprobacion;
                decimal nPorcentajeAsignacion = frmbuscarpartidapre.nPorcentajeAsigBuscado;
                txtNombrePartida.Text = cDescripcion;
                cValoresPres.Clear();
                cValoresSaldo.Clear();
                cboLimAplicaSaldo.SelectedValue = idLimAplicacion;
                cboNivelAprobacion.SelectedValue = idNivelAprob;
                txtMovimiento.Text = string.Empty;
                llenarGridPartida(idPartidaG, dtgPartidaPres);
                obtenerLimiteAprobacion();
            }
        }
        private void obtenerLimiteAprobacion()
        {
            int nMesInicio = Convert.ToInt32(clsVarGlobal.dFecSystem.ToString("MM"));
            copiarValoresIniciales();
            habilitarCeldas(nMesInicio);
        }
        private void copiarValoresIniciales()
        {
            for (int j = 0; j < dtgPartidaPres.ColumnCount; j++)
            {
                cValoresPres.Add(Convert.ToString(dtgPartidaPres.Rows[0].Cells[j].Value));
                cValoresSaldo.Add(Convert.ToString(dtgPartidaPres.Rows[1].Cells[j].Value));
            }
        }
        private void formatearGridPartida(DataTable dtPresupuesto, DataGridView dtgUso)
        {
            dtgUso.DataSource = dtPresupuesto;

            dtPresupuesto.Columns["cNombre"].ReadOnly = false;
            dtPresupuesto.Columns["Enero"].ReadOnly = false;
            dtPresupuesto.Columns["Febrero"].ReadOnly = false;
            dtPresupuesto.Columns["Marzo"].ReadOnly = false;
            dtPresupuesto.Columns["Abril"].ReadOnly = false;
            dtPresupuesto.Columns["Mayo"].ReadOnly = false;
            dtPresupuesto.Columns["Junio"].ReadOnly = false;
            dtPresupuesto.Columns["Julio"].ReadOnly = false;
            dtPresupuesto.Columns["Agosto"].ReadOnly = false;
            dtPresupuesto.Columns["Setiembre"].ReadOnly = false;
            dtPresupuesto.Columns["Octubre"].ReadOnly = false;
            dtPresupuesto.Columns["Noviembre"].ReadOnly = false;
            dtPresupuesto.Columns["Diciembre"].ReadOnly = false;
            dtPresupuesto.Columns["nSumaTotal"].ReadOnly = false;

            foreach (DataGridViewColumn item in dtgUso.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            dtgUso.ReadOnly = false;

            dtgUso.Columns["cNombre"].Visible = true;
            dtgUso.Columns["Enero"].Visible = true;
            dtgUso.Columns["Febrero"].Visible = true;
            dtgUso.Columns["Marzo"].Visible = true;
            dtgUso.Columns["Abril"].Visible = true;
            dtgUso.Columns["Mayo"].Visible = true;
            dtgUso.Columns["Junio"].Visible = true;
            dtgUso.Columns["Julio"].Visible = true;
            dtgUso.Columns["Agosto"].Visible = true;
            dtgUso.Columns["Setiembre"].Visible = true;
            dtgUso.Columns["Octubre"].Visible = true;
            dtgUso.Columns["Noviembre"].Visible = true;
            dtgUso.Columns["Diciembre"].Visible = true;
            dtgUso.Columns["nSumaTotal"].Visible = true;

            dtgUso.Columns["cNombre"].HeaderText = "Descripción";
            dtgUso.Columns["nSumaTotal"].HeaderText = "Total";

            dtgUso.Columns["Enero"].DefaultCellStyle.Format = "N2";
            dtgUso.Columns["Febrero"].DefaultCellStyle.Format = "N2";
            dtgUso.Columns["Marzo"].DefaultCellStyle.Format = "N2";
            dtgUso.Columns["Abril"].DefaultCellStyle.Format = "N2";
            dtgUso.Columns["Mayo"].DefaultCellStyle.Format = "N2";
            dtgUso.Columns["Junio"].DefaultCellStyle.Format = "N2";
            dtgUso.Columns["Julio"].DefaultCellStyle.Format = "N2";
            dtgUso.Columns["Agosto"].DefaultCellStyle.Format = "N2";
            dtgUso.Columns["Setiembre"].DefaultCellStyle.Format = "N2";
            dtgUso.Columns["Octubre"].DefaultCellStyle.Format = "N2";
            dtgUso.Columns["Noviembre"].DefaultCellStyle.Format = "N2";
            dtgUso.Columns["Diciembre"].DefaultCellStyle.Format = "N2";
            dtgUso.Columns["nSumaTotal"].DefaultCellStyle.Format = "N2";
        }
        private void habilitarCeldas(int nMesInicio)
        {
            for (int j = nMesInicio - 1 + nEnero; j < nEnero + 12; j++)
            {
                dtgPartidaPres.Rows[0].Cells[j].ReadOnly = false;
                dtgPartidaPres.Rows[0].Cells[j].Style.BackColor = Color.PaleGreen;
            }
        }
        private void editarCeldas(int nColumnaActual)
        {
            decimal nPreInicial = Convert.ToDecimal(cValoresPres[nColumnaActual]);
            decimal nSaldoInicial = Convert.ToDecimal(cValoresSaldo[nColumnaActual]);
            decimal nPreModificado = Convert.ToDecimal(dtgPartidaPres.Rows[0].Cells[nColumnaActual].Value);
            decimal nSaldoModificado = nSaldoInicial + (nPreModificado - nPreInicial);

            //if (nPreModificado < nPreInicial)
            if(nPreModificado < 0)
            {
                //MessageBox.Show("No puede ser menor al presupuesto del mes, que es " + cValoresPres[nColumnaActual], cTituloMensate, MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("No puede ser negativo", cTituloMensate, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtgPartidaPres.Rows[0].Cells[nColumnaActual].Value = nPreInicial;
                dtgPartidaPres.Rows[1].Cells[nColumnaActual].Value = nSaldoInicial;
                calcularModificacion();
            }
            else
            {
                dtgPartidaPres.Rows[1].Cells[nColumnaActual].Value = nSaldoModificado;
                calcularModificacion();
            }

        }
        private void calcularModificacion()
        {
            decimal nSumaActualPres = 0;
            decimal nSumaActualSaldo = 0;
            for (int j = nEnero; j < nEnero + 12; j++)
            {
                nSumaActualPres += Convert.ToDecimal(String.Format("{0:#,0.00}", dtgPartidaPres.Rows[0].Cells[j].Value));
                nSumaActualSaldo += Convert.ToDecimal(String.Format("{0:#,0.00}", dtgPartidaPres.Rows[1].Cells[j].Value));
            }
            txtMovimiento.Text = String.Format("{0:#,0.00}", nSumaActualPres - Convert.ToDecimal(cValoresPres[nEnero + 12]));
            dtgPartidaPres.Rows[0].Cells[nEnero + 12].Value = nSumaActualPres;
            dtgPartidaPres.Rows[1].Cells[nEnero + 12].Value = nSumaActualSaldo;
        }
        private void darFormatoDTValoresParaGuardar(DataTable dtValoresNuevos)
        {
            dtValoresNuevos.Columns.Add("idPartida", typeof(int));
            dtValoresNuevos.Columns.Add("idMes", typeof(int));
            dtValoresNuevos.Columns.Add("nSaldoDisponible", typeof(Decimal));
            dtValoresNuevos.Columns.Add("nMovimiento", typeof(Decimal));
            dtValoresNuevos.Columns.Add("nPresupuestoNuevo", typeof(Decimal));
            dtValoresNuevos.Columns.Add("nPresupuestoDisponible", typeof(Decimal));
            dtValoresNuevos.Columns.Add("idVinculoPartida", typeof(int));
        }
        private string llenarCeldasModificadas(DataTable dtValoresNuevos)
        {
            for (int i = nEnero; i < nEnero + 12; i++)
            {
                DataRow drDestino = dtValoresNuevos.NewRow();
                drDestino["idPartida"] = idPartidaG;
                drDestino["idMes"] = i - nEnero + 1;
                drDestino["nSaldoDisponible"] = cValoresPres[i];
                drDestino["nMovimiento"] = Convert.ToDecimal(dtgPartidaPres.Rows[0].Cells[i].Value) - Convert.ToDecimal(cValoresPres[i]);
                drDestino["nPresupuestoNuevo"] = Convert.ToDecimal(dtgPartidaPres.Rows[0].Cells[i].Value);
                drDestino["nPresupuestoDisponible"] = Convert.ToDecimal(dtgPartidaPres.Rows[1].Cells[i].Value);
                drDestino["idVinculoPartida"] = 0; // ojo
                dtValoresNuevos.Rows.Add(drDestino);
                dtValoresNuevos.AcceptChanges();
            }
            DataSet dsValoresModificados = new DataSet("DSPartidasPresModificadas");
            dsValoresModificados.Tables.Add(dtValoresNuevos);
            string xmlValoresModificados = dsValoresModificados.GetXml();
            xmlValoresModificados = clsCNFormatoXML.EncodingXML(xmlValoresModificados);
            dsValoresModificados.Tables.Clear();
            return xmlValoresModificados;
        }
        private void insertarNuevaPartida(int idPartida, String cFundamento, int idPeriodo, int idTipoModific, int idUsuSolicitante, int idUsu, DateTime dFecha,
                                            int idPartidaOrigen, int idPartidaDestino, String xmlModifPres, Decimal nMovimiento, int idAgencia)
        {
            DataTable dtResultado = cnpartidamodificacion.InsertarPartida(idPartida, cFundamento, idPeriodo, idTipoModific, idUsuSolicitante, idUsu, dFecha, idPartidaOrigen, idPartidaDestino, xmlModifPres, nMovimiento, idAgencia);
            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMensate, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ejecutarAmpliacion(int idSolicitud, int idPeriodo, int idPartidaModificacion, int idUsuario, DateTime dFecha)
        {
            DataTable dtResultado = cnpartidamodificacion.ProcesarModificacionPresupuesto(idSolicitud, idPeriodo, idPartidaModificacion, idUsuario, dFecha);
            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMensate, MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            if ((int)dtResultado.Rows[0]["idError"] == 0)
            {
                listarPartidasModif();
            }
        }
        private bool verificarDetallesModif()
        {
            if (String.IsNullOrEmpty(txtFundamento.Text.Trim()))
            {
                MessageBox.Show("Ingrese la Justificación de la partida", cTituloMensate, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (String.IsNullOrEmpty(conBusUsuSolicitante.txtCod.Text.Trim()))
            {
                MessageBox.Show("Ingrese el usuario solicitante", cTituloMensate, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (String.IsNullOrEmpty(txtNombrePartida.Text.Trim()))
            {
                MessageBox.Show("Seleccione una partida", cTituloMensate, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (String.IsNullOrEmpty(txtMovimiento.Text.Trim()))
            {
                MessageBox.Show("El valor del movimiento es incorrecto",cTituloMensate, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //if (Convert.ToDecimal(txtMovimiento.Text) <= 0)
            //{
            //    MessageBox.Show("El valor del movimiento es incorrecto",cTituloMensate, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            return true;
        }
        private void pintarMesModificado(DataGridView dtgGrilla)
        {
            int row = 0;
            for (int j = nEnero; j < 12 + nEnero; j++)
            {
                if (Convert.ToDecimal(dtgGrilla.Rows[row].Cells[j].Value) < 0)
                {
                    dtgGrilla.Rows[row].Cells[j].Value = (Convert.ToDecimal(dtgGrilla.Rows[row].Cells[j].Value) * -1)-1;
                    if (dtgGrilla == dtgPartidaPres)
                    {
                        dtgGrilla.Rows[row].Cells[j].Style.BackColor = Color.PaleTurquoise;
                    }
                }
            }
        }
        private bool verificarDecimal(string nValue)
        {
            decimal d;
            if (decimal.TryParse(nValue, out d))
            {
                return false;
            }

            else
            {
                return true;
            }

        }
        private void bloquearTodo()
        {
            grbBase2.Enabled = false;
            conBusUsuSolicitante.Enabled = false;
            btnBuscaPartida.Enabled = false;
            btnNuevo.Enabled = false;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
        }
        #endregion
    }
}