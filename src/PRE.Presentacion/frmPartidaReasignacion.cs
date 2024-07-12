using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using System.Globalization;

namespace PRE.Presentacion
{
    public partial class frmPartidaReasignacion : frmBase
    {
        #region Variables globales
        private clsCNPartidaModificacion cnpartidamodificacion = new clsCNPartidaModificacion();
        private clsCNPartidasPres cnpartidaspres = new clsCNPartidasPres();
        private DataTable dtPartidas;
        private Boolean lEsEjecucion = false;
        private string cTipoOperacion = "N";
        private int idPartidaReasig = 0;
        private int idPartidaOrigenG = 0;
        private int idPartidaDestinoG = 0;
        private int idTipoModificacion = 1;     // segun SI_FinTModificacionPartidas: 1 = reasignacion
        private String cTituloMensaje = "Partidas de reasignación";

        private int nEnero = 2;
        private List<string> cValoresPresOrigen = new List<string>();
        private List<string> cValoresPresDestino = new List<string>();
        private List<string> cValoresSaldoOrigen = new List<string>();
        private List<string> cValoresSaldoDestino = new List<string>();
        private decimal nDisponibleNeto;        

        #endregion
        #region Eventos
        public frmPartidaReasignacion()
        {
            InitializeComponent();
        }
        private void frmPartidaReasignacion_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            if (this.cboPeriodoPresupuestal1.Items.Count <= 0)
            {
                this.lEsEjecucion = false;
                habilitarControles(false);
                return;
            }
            int idPeriodoSelect = Convert.ToInt32(this.cboPeriodoPresupuestal1.SelectedValue);
            this.nudPorcentajeOrigen.Maximum = 100;
            this.nudPorcentajeOrigen.Minimum = 0;
            this.nudPorcentajeOrigen.DecimalPlaces = 2;            
            listarPartidasModif(idPeriodoSelect);
            formatearGridPartidasModif();
            verificarEstadoPeriodo(idPeriodoSelect);
            habilitarControles(false);                   
        }
        private void btnNuevo1_Click(object sender, EventArgs e)
        {            
            limpiarControles();
            cTipoOperacion = "N";
            habilitarControles(true);            
        }
       
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            habilitarControles(false);
            mostrarDetallesModif();
            cTipoOperacion = "";
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (verificarDetallesModif())
            {
                String cCodigo = this.txtCodigo.Text.ToString();
                String cJustific = this.txtJustificacion.Text.ToString();                
                int idPeriodo = (int)this.cboPeriodoPresupuestal1.SelectedValue;
                int idUsuReg = clsVarGlobal.User.idUsuario;
                DateTime dFechaReg = clsVarGlobal.dFecSystem;
                Decimal nMovimiento = Convert.ToDecimal(this.txtMovimientoDestino.Text);                                              
                if (cTipoOperacion == "N")
                {
                    String xmlValoresModificados = llenarCeldasModificadas();
                    insertarNuevaPartida(0, cJustific, idPeriodo, 1, Convert.ToInt32(this.conBusUsuSolicitante.idCliPer), idUsuReg, dFechaReg, idPartidaOrigenG, idPartidaDestinoG, xmlValoresModificados, nMovimiento, clsVarGlobal.nIdAgencia);
                }
                if (cTipoOperacion == "A")
                {
                    
                }
                listarPartidasModif(idPeriodo);
                habilitarControles(false);
            }
        }
        private void cboPeriodoPresupuestal1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idPeriodoSelect = Convert.ToInt32(this.cboPeriodoPresupuestal1.SelectedValue);                      
            verificarEstadoPeriodo(idPeriodoSelect);            
            habilitarControles(false);

            listarPartidasModif(idPeriodoSelect);
        }       
        private void dtgPartidasReasig_SelectionChanged(object sender, EventArgs e)
        {
            mostrarDetallesModif();
        }       
        private void btnBuscaPartidaOrigen_Click(object sender, EventArgs e)
        {
            buscarPartida(idPartidaOrigenG, this.txtCodNombrePartidaOrigen, this.nudPorcentajeOrigen, this.cboLimAplicaSaldoOrigen, this.dtgPartidaOrigen, this.cboNivelAprob);
        }
        private void btnBuscaPartidaDestino_Click(object sender, EventArgs e)
        {
            buscarPartida(idPartidaDestinoG, this.txtCodNombrePartidaDestino, null, null, this.dtgPartidaDestino, null);
        }
        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            int idSolicitud = Convert.ToInt32(this.dtgPartidasReasig.SelectedRows[0].Cells["idSolAproba"].Value);
            ejecutarReasignacion(idSolicitud, (int)this.cboPeriodoPresupuestal1.SelectedValue, this.idPartidaReasig, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
        }

        private void dtgPartidaOrigen_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int nColumnaActual = e.ColumnIndex;
            int nFilaActual = e.RowIndex;

            modificarCeldasOrigen(nColumnaActual);
        }
        private void dtgPartidaDestino_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int nColumnaActual = e.ColumnIndex;
            modificarCeldasDestino(nColumnaActual);
        }    
        private void dtgPartidaOrigen_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            Decimal d;
            if (Convert.ToInt32(e.ColumnIndex) >= nEnero && Convert.ToInt32(e.ColumnIndex) <= nEnero + 12)
            {
                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    MessageBox.Show("El campo no puede ser vacio, ingrese un número", cTituloMensaje);
                    e.Cancel = true;
                }
                else if (!Decimal.TryParse(e.FormattedValue.ToString(), out d))
                {
                    MessageBox.Show("Ingrese un número correcto", cTituloMensaje);
                    e.Cancel = true;
                }
            }
        }
        private void dtgPartidaDestino_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            Decimal d;
            if (Convert.ToInt32(e.ColumnIndex) >= nEnero && Convert.ToInt32(e.ColumnIndex) <= nEnero + 12)
            {
                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    MessageBox.Show("El campo no puede ser vacio, ingrese un número", cTituloMensaje);                    
                    e.Cancel = true;
                }
                else if (!Decimal.TryParse(e.FormattedValue.ToString(), out d))
                {
                    MessageBox.Show("Ingrese un número correcto", cTituloMensaje);                                      
                    e.Cancel = true;
                }
            }
        }
        private void dtgPartidaOrigen_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(TextboxNumeric_KeyPress);
            }
        }
        private void dtgPartidaDestino_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(TextboxNumeric_KeyPress);
            }
        }
        private void TextboxNumeric_KeyPress(object sender, KeyPressEventArgs e)
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
        private void frmPartidaReasignacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.dtgPartidaOrigen.CancelEdit();
            this.dtgPartidaOrigen.DataSource = null;
            this.dtgPartidaDestino.CancelEdit();
            this.dtgPartidaDestino.DataSource = null;
        }   
        #endregion
        #region Metodos
        private void listarPartidasModif(int nPeriodo)
        {
            dtPartidas = cnpartidamodificacion.ListarTodosPartidasModificacion(nPeriodo, idTipoModificacion);
            if (dtPartidas.Rows.Count <= 0)
            {
                habilitarControles(false);
                limpiarControles();
            }
            this.dtgPartidasReasig.DataSource = dtPartidas;
        }

        private void darFormatoDTValoresParaGuardar(DataTable dtValoresNuevosOrigen)
        {            
            dtValoresNuevosOrigen.Columns.Add("idPartida", typeof(int));
            dtValoresNuevosOrigen.Columns.Add("idMes", typeof(int));
            dtValoresNuevosOrigen.Columns.Add("nSaldoDisponible", typeof(Decimal));
            dtValoresNuevosOrigen.Columns.Add("nMovimiento", typeof(Decimal));
            dtValoresNuevosOrigen.Columns.Add("nPresupuestoNuevo", typeof(Decimal));
            dtValoresNuevosOrigen.Columns.Add("nPresupuestoDisponible", typeof(Decimal));
            dtValoresNuevosOrigen.Columns.Add("idVinculoPartida", typeof(int));        
        }
        private String llenarCeldasModificadas()
        {            
            DataTable dtValoresNuevosOrigen = new DataTable();
            darFormatoDTValoresParaGuardar(dtValoresNuevosOrigen);
            for (int i = nEnero; i < nEnero+12; i++)
            {                
                    DataRow drOrigen = dtValoresNuevosOrigen.NewRow();
                    drOrigen["idPartida"] = idPartidaOrigenG;                    
                    drOrigen["idMes"] = i - nEnero + 1;
                    drOrigen["nSaldoDisponible"] = cValoresPresOrigen[i];
                    drOrigen["nMovimiento"] = Convert.ToDecimal(dtgPartidaOrigen.Rows[0].Cells[i].Value) - Convert.ToDecimal(cValoresPresOrigen[i]);
                    drOrigen["nPresupuestoNuevo"] = Convert.ToDecimal(dtgPartidaOrigen.Rows[0].Cells[i].Value);
                    drOrigen["nPresupuestoDisponible"] = Convert.ToDecimal(dtgPartidaOrigen.Rows[1].Cells[i].Value);
                    drOrigen["idVinculoPartida"] = idPartidaDestinoG;
                    dtValoresNuevosOrigen.Rows.Add(drOrigen);
                    dtValoresNuevosOrigen.AcceptChanges();                   
             
                    DataRow drDestino = dtValoresNuevosOrigen.NewRow();
                    drDestino["idPartida"] = idPartidaDestinoG;
                    drDestino["idMes"] = i - nEnero + 1;
                    drDestino["nSaldoDisponible"] = cValoresPresDestino[i];
                    drDestino["nMovimiento"] = Convert.ToDecimal(dtgPartidaDestino.Rows[0].Cells[i].Value) - Convert.ToDecimal(cValoresPresDestino[i]);
                    drDestino["nPresupuestoNuevo"] = Convert.ToDecimal(dtgPartidaDestino.Rows[0].Cells[i].Value);
                    drDestino["nPresupuestoDisponible"] = Convert.ToDecimal(dtgPartidaDestino.Rows[1].Cells[i].Value);
                    drDestino["idVinculoPartida"] = idPartidaOrigenG;
                    dtValoresNuevosOrigen.Rows.Add(drDestino);
                    dtValoresNuevosOrigen.AcceptChanges();
                
            }
            DataSet dsValoresModificados = new DataSet("DSPartidasPresModificadas");
            dsValoresModificados.Tables.Add(dtValoresNuevosOrigen);
            string xmlValoresModificados = dsValoresModificados.GetXml();
            xmlValoresModificados = clsCNFormatoXML.EncodingXML(xmlValoresModificados);
            dsValoresModificados.Tables.Clear();
            return xmlValoresModificados;            
        }
        private void verificarEstadoPeriodo(int idPeriodoSelect)
        {
            int idEstadoPeriodo = Convert.ToInt32(this.cboPeriodoPresupuestal1.devolverValor(this.cboPeriodoPresupuestal1.SelectedIndex, "idEstado"));
            this.lblPlanificacion.Text = this.cboPeriodoPresupuestal1.devolverValor(this.cboPeriodoPresupuestal1.SelectedIndex, "cEstado");
            if (idEstadoPeriodo == 1)  
            {
                this.lblPlanificacion.ForeColor = Color.DarkGreen;
                lEsEjecucion = false;                
            }
            else if (idEstadoPeriodo == 2)   // 2 = ejecución 
            {
                this.lblPlanificacion.ForeColor = Color.RoyalBlue;
                lEsEjecucion = true;
            }
            else
            {
                this.lblPlanificacion.ForeColor = Color.Gray;
                lEsEjecucion = false;
            }
        }
        private void formatearGridPartidasModif()
        {
            foreach (DataGridViewColumn item in this.dtgPartidasReasig.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;                                  
            }            
            this.dtgPartidasReasig.Columns["cCodigoPartida"].Visible = true;            
            this.dtgPartidasReasig.Columns["nMonto"].Visible = true;
            this.dtgPartidasReasig.Columns["idCliSolicita"].Visible = true;
            this.dtgPartidasReasig.Columns["idSolAproba"].Visible = true; 
            this.dtgPartidasReasig.Columns["cEstadoSol"].Visible = true;
            this.dtgPartidasReasig.Columns["dFechaAprobacion"].Visible = true; 
            
            
            this.dtgPartidasReasig.Columns["nMonto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dtgPartidasReasig.Columns["cCodigoPartida"].HeaderText = "Código";            
            this.dtgPartidasReasig.Columns["nMonto"].HeaderText = "Movimiento";
            this.dtgPartidasReasig.Columns["idCliSolicita"].HeaderText = "Us. solicitante";
            this.dtgPartidasReasig.Columns["idSolAproba"].HeaderText = "Nº Solicitud";
            this.dtgPartidasReasig.Columns["cEstadoSol"].HeaderText = "Est. solicitud";
            this.dtgPartidasReasig.Columns["dFechaAprobacion"].HeaderText = "Fecha";
        }
        
        private void mostrarDetallesModif()
        {
            if (this.dtgPartidasReasig.SelectedRows.Count > 0)
            {
                this.idPartidaReasig = Convert.ToInt32(this.dtgPartidasReasig.SelectedRows[0].Cells["idPartidaModificacion"].Value);
                this.txtCodigo.Text = Convert.ToString(this.dtgPartidasReasig.SelectedRows[0].Cells["cCodigoPartida"].Value);
                this.txtJustificacion.Text = Convert.ToString(this.dtgPartidasReasig.SelectedRows[0].Cells["cFundamento"].Value);

                this.txtMovimientoOrigen.Text = String.Format("{0:#,0.00}", this.dtgPartidasReasig.SelectedRows[0].Cells["nMonto"].Value);
                this.txtMovimientoDestino.Text = String.Format("{0:#,0.00}", this.dtgPartidasReasig.SelectedRows[0].Cells["nMonto"].Value);
                this.conBusUsuSolicitante.txtCod.Text = Convert.ToString(this.dtgPartidasReasig.SelectedRows[0].Cells["idUsuario"].Value);
                this.conBusUsuSolicitante.BusPerByCod();

                idPartidaOrigenG = Convert.ToInt32(this.dtgPartidasReasig.SelectedRows[0].Cells["idPartidaOrigen"].Value);
                idPartidaDestinoG = Convert.ToInt32(this.dtgPartidasReasig.SelectedRows[0].Cells["idPartidaDestino"].Value);

                cValoresPresOrigen.Clear();
                cValoresPresDestino.Clear();
                cValoresSaldoOrigen.Clear();
                cValoresSaldoDestino.Clear();
                llenarPartidaActorasDeBD(idPartidaOrigenG, this.txtCodNombrePartidaOrigen , this.nudPorcentajeOrigen,this.cboLimAplicaSaldoOrigen, this.dtgPartidaOrigen, this.cboNivelAprob);
                llenarPartidaActorasDeBD(idPartidaDestinoG, this.txtCodNombrePartidaDestino, null, null, this.dtgPartidaDestino, this.cboNivelAprob);

                if (Convert.ToInt32(this.dtgPartidasReasig.SelectedRows[0].Cells["idEstadoSolicitud"].Value) == 2 )
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
                idPartidaReasig = 0;
                this.conBusUsuSolicitante.HabilitarControles(false);
                this.dtgPartidaOrigen.DataSource = null;
                this.dtgPartidaDestino.DataSource = null;
                this.grbProcesar.Visible = false;
            }
        }               
       
        private void llenarPartidaActorasDeBD(int idPartida, txtBase txtNombreP, nudBase nudPorcentaje, cboLimAplicaSaldo cboAplicSaldo, dtgBase dtgGrilla, cboNivelAprobPartidaPres cboNivelAprob)
        {
            int idPeriodo = Convert.ToInt32(this.cboPeriodoPresupuestal1.SelectedValue);
            frmBuscarPartidaPre buscarPartida = new frmBuscarPartidaPre();
            buscarPartida.idPeriodoSelec = idPeriodo;
            buscarPartida.idPartidaBuscada = idPartida;
            buscarPartida.buscarPorIdPartida();
            
            txtNombreP.Text = buscarPartida.cDescripcionBuscada;
            if (nudPorcentaje != null)
            {
                nudPorcentaje.Value = buscarPartida.nPorcentajeAsigBuscado;
                cboNivelAprob.SelectedValue = buscarPartida.idNivelAprobacion;
                cboAplicSaldo.SelectedValue = buscarPartida.idLimAplicBuscado;
            }
            DataTable dtModicacionPresupuesto = cnpartidamodificacion.ListaPresupuestoPartidaModificada(idPeriodo, idPartidaReasig, idPartida);
            formatearGridPartida(dtModicacionPresupuesto, dtgGrilla, idPeriodo, idPartida, cboAplicSaldo);
            pintarMesModificado(dtgGrilla);         
        }

        private void llenarGridPartida(int idPeriodo, int idPartida, DataGridView dtgUso, cboLimAplicaSaldo cboAplicSaldo)
        {
            DataTable dtPresupuesto = new DataTable();
            dtPresupuesto = cnpartidaspres.ListarValoresDeUnaPartida(idPeriodo, idPartida);
            formatearGridPartida(dtPresupuesto, dtgUso, idPeriodo, idPartida, cboAplicSaldo);
            obtenerLimiteAprobacion(dtgUso, cboAplicSaldo);
        }
        private void formatearGridPartida(DataTable dtPresupuesto, DataGridView dtgUso, int idPeriodo, int idPartida, cboLimAplicaSaldo cboAplicSaldo)
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
            dtgUso.Columns["cNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;            

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
        private void obtenerLimiteAprobacion(DataGridView dtgUso, cboLimAplicaSaldo cboAplicSaldo)
        {
            int nMesInicio = 1, nMesFin = 12;
            if (cboAplicSaldo == this.cboLimAplicaSaldoOrigen)
            {
                String cMesInicio = Convert.ToString(cboAplicSaldo.DevolverMesLimite(cboAplicSaldo.SelectedIndex, "cMesInicio"));
                String cMesFin = Convert.ToString(cboAplicSaldo.DevolverMesLimite(cboAplicSaldo.SelectedIndex, "cMesFin"));
                nMesInicio = retornarMesNum(cMesInicio);
                nMesFin = retornarMesNum(cMesFin);
            }
            else
            {
                nMesInicio = retornarMesNum("X");
                nMesFin = 12;
            }   
            
            copiarValoresIniciales(dtgUso, nMesInicio, nMesFin);

            habilitarCeldas(dtgUso, nMesInicio, nMesFin);            
            if (dtgUso == dtgPartidaOrigen)
                calcularDisponibleNeto(nMesInicio, nMesFin);
        }
        private void buscarPartida(int idPartida, txtBase txtNombreP, nudBase nudPorcentaje, cboLimAplicaSaldo cboAplicSaldo, dtgBase dtgGrilla, cboNivelAprobPartidaPres cboNivelAprobacion)
        {
            frmBuscarPartidaPre buscarPartida = new frmBuscarPartidaPre();
            int idPeriodo = Convert.ToInt32(this.cboPeriodoPresupuestal1.SelectedValue);
            buscarPartida.idPeriodoSelec = idPeriodo;
            buscarPartida.ShowDialog();
            if (buscarPartida.idPartidaBuscada == 0) return;

            idPartida = buscarPartida.idPartidaBuscada;
            
            if (nudPorcentaje != null)
            {
                idPartidaOrigenG = idPartida;
                foreach (DataGridViewRow Row in dtgPartidasReasig.Rows)
                {
                    int cValor = Convert.ToInt32(Row.Cells["idPartidaOrigen"].Value);
                    int idEstado = Convert.ToInt32(Row.Cells["idEstadoSolicitud"].Value);
                    if (cValor == idPartidaOrigenG && idEstado < 3) //segun SI_FinEstadoSolicitud: 3 = ejecutado
                    {
                        MessageBox.Show("La partida ya tiene un proceso de reasignación, no puede utilizarla", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }               
            }
            else
            {
                idPartidaDestinoG = idPartida;
            }

            if (idPartidaOrigenG == idPartidaDestinoG)
            {
                MessageBox.Show("Partida ya seleccionada, elija otra", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
            else
            {
                if (idPartida != 0)
                {
                    txtNombreP.Text = buscarPartida.cDescripcionBuscada;
                    if (nudPorcentaje != null)
                    {
                        cValoresSaldoOrigen.Clear();
                        cValoresPresOrigen.Clear();
                        nudPorcentaje.Value = buscarPartida.nPorcentajeAsigBuscado;
                        cboNivelAprobacion.SelectedValue = buscarPartida.idNivelAprobacion;
                        cboAplicSaldo.SelectedValue = buscarPartida.idLimAplicBuscado;
                        this.txtMovimientoOrigen.Text = string.Empty;
                    }
                    else
                    {
                        cValoresSaldoDestino.Clear();
                        cValoresPresDestino.Clear(); 
                        this.txtMovimientoDestino.Text = string.Empty;
                    }                                                                                    
                    llenarGridPartida(idPeriodo, idPartida, dtgGrilla, cboAplicSaldo);
                }           
            }
          
        }
        private void pintarMesModificado(DataGridView dtgGrilla)
        {   int row = 0;
            for (int j = nEnero; j < 12 + nEnero; j++)
            {                
                if (Convert.ToDecimal(dtgGrilla.Rows[row].Cells[j].Value) < 0)
                {
                    dtgGrilla.Rows[row].Cells[j].Value = (Convert.ToDecimal(dtgGrilla.Rows[row].Cells[j].Value) * -1)-1;
                    dtgGrilla.Rows[row].Cells[j].Style.BackColor = Color.PaleTurquoise;                   
                }
            }
        }
        private int retornarMesNum(string cMes)
        {
            int nMes;
            if (cMes == "X")
            {
                String cMesActual = Convert.ToString(clsVarGlobal.dFecSystem.ToString("MM"));
                nMes = Convert.ToInt32(cMesActual);
            }
            else
            {
                nMes = Convert.ToInt32(cMes);
            }
            return nMes;

        }
        private void habilitarCeldas(DataGridView dtgUso, int nMesInicio, int nMesFin)
        {
            if (nMesInicio != 0 && nMesFin != 0)
            {
                for (int j = nMesInicio - 1 + nEnero; j < nMesFin + nEnero; j++)
                {
                    dtgUso.Rows[0].Cells[j].ReadOnly = false;
                    if (dtgUso == dtgPartidaOrigen)
                    {
                        dtgUso.Rows[0].Cells[j].Style.BackColor = Color.FromArgb(255, 204, 204);
                    }
                    else
                    {
                        dtgUso.Rows[0].Cells[j].Style.BackColor = Color.FromArgb(204, 255, 204);
                    }
                    
                }
            }
        }
        private void copiarValoresIniciales(DataGridView dtgUso, int nMesInicio, int nMesFin)
        {
            if (nMesInicio != 0 && nMesFin != 0)
            {
                for (int j = 0; j < dtgUso.ColumnCount; j++)
                {
                    if (dtgUso == dtgPartidaOrigen)
                    {
                        cValoresPresOrigen.Add(Convert.ToString(dtgUso.Rows[0].Cells[j].Value));
                        cValoresSaldoOrigen.Add(Convert.ToString(dtgUso.Rows[1].Cells[j].Value));
                    }
                    else
                    {
                        cValoresPresDestino.Add(Convert.ToString(dtgUso.Rows[0].Cells[j].Value));
                        cValoresSaldoDestino.Add(Convert.ToString(dtgUso.Rows[1].Cells[j].Value));
                    }
                }
            }
        }
        private void calcularDisponibleNeto(int nMesInicio, int nMesFin)
        {
            if (nMesInicio != 0 && nMesFin != 0)
            {
                Decimal nSumaSaldo = 0;
                for (int j = nMesInicio - 1 + nEnero; j < nMesFin + nEnero; j++)
                {
                    nSumaSaldo += Convert.ToDecimal(dtgPartidaOrigen.Rows[1].Cells[j].Value);
                }
                nDisponibleNeto = nSumaSaldo * Convert.ToDecimal(nudPorcentajeOrigen.Value) / 100;
                txtDisponibleNeto.Text = String.Format("{0:#,0.00}", nDisponibleNeto);
            }
        }
        private void modificarCeldasOrigen(int nColumnaActual)
        {
            decimal nPreInicial = Convert.ToDecimal(cValoresPresOrigen[nColumnaActual]);
            decimal nPreModificado = Convert.ToDecimal(dtgPartidaOrigen.Rows[0].Cells[nColumnaActual].Value);
            decimal nSaldoInicial = Convert.ToDecimal(cValoresSaldoOrigen[nColumnaActual]);
            decimal nSaldoModificado = nSaldoInicial - (nPreInicial - nPreModificado);
            
            if (nPreModificado > nPreInicial)
            {
                MessageBox.Show("No puede aumentar presupuesto en partida origen", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgPartidaOrigen.Rows[0].Cells[nColumnaActual].Value = nPreInicial;
                dtgPartidaOrigen.Rows[1].Cells[nColumnaActual].Value = nSaldoInicial;
                calcularModificacionOrigen();
            }
            else if (nSaldoModificado < 0)
            {
                MessageBox.Show("El presupuesto modificado supera al saldo disponible en el mes", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgPartidaOrigen.Rows[0].Cells[nColumnaActual].Value = nPreInicial;
                dtgPartidaOrigen.Rows[1].Cells[nColumnaActual].Value = nSaldoInicial;
                calcularModificacionOrigen();
            }
            else
            {
                dtgPartidaOrigen.Rows[0].Cells[nColumnaActual].Value = nPreModificado;
                dtgPartidaOrigen.Rows[1].Cells[nColumnaActual].Value = nSaldoModificado;
                calcularModificacionOrigen();                
            }

        }
        private void calcularModificacionOrigen()
        {         
            decimal nSumaActualPres = 0;
            decimal nSumaActualSaldo = 0;
            for (int j = nEnero; j < nEnero + 12; j++)
            {
                nSumaActualPres += Convert.ToDecimal((Convert.ToDecimal(dtgPartidaOrigen.Rows[0].Cells[j].Value)).ToString("##,##0.00"));
                nSumaActualSaldo += Convert.ToDecimal((Convert.ToDecimal(dtgPartidaOrigen.Rows[1].Cells[j].Value)).ToString("##,##0.00"));
            }
            txtMovimientoOrigen.Text = ( Convert.ToDecimal(cValoresPresOrigen[nEnero + 12]) - nSumaActualPres).ToString("##,##0.00");
            dtgPartidaOrigen.Rows[0].Cells[nEnero + 12].Value = nSumaActualPres;
            dtgPartidaOrigen.Rows[1].Cells[nEnero + 12].Value = nSumaActualSaldo;
        }
        private void modificarCeldasDestino(int nColumnaActual)
        {
            decimal nPreInicial = Convert.ToDecimal(cValoresPresDestino[nColumnaActual]);
            decimal nPreModificado = Convert.ToDecimal(dtgPartidaDestino.Rows[0].Cells[nColumnaActual].Value);
            decimal nSaldoInicial = Convert.ToDecimal(cValoresSaldoDestino[nColumnaActual]);
            decimal nSaldoModificado = nSaldoInicial + (nPreModificado - nPreInicial);            
            if (nPreModificado > 999999999999)
            {
                MessageBox.Show("Limite de digitos exedido", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgPartidaDestino.Rows[0].Cells[nColumnaActual].Value = nPreInicial;
                dtgPartidaDestino.Rows[1].Cells[nColumnaActual].Value = nSaldoInicial;                
            }
            else if (nPreModificado < nPreInicial)
            {
                MessageBox.Show("No puede reducir el presupuesto en partida destino", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtgPartidaDestino.Rows[0].Cells[nColumnaActual].Value = nPreInicial;
                dtgPartidaDestino.Rows[1].Cells[nColumnaActual].Value = nSaldoInicial;                
            }            
            else
            {
                if (verificarMaxDigitos(dtgPartidaDestino))
                {
                    dtgPartidaDestino.Rows[0].Cells[nColumnaActual].Value = nPreModificado;
                    dtgPartidaDestino.Rows[1].Cells[nColumnaActual].Value = nSaldoModificado;                    
                }
                else 
                {
                    dtgPartidaDestino.Rows[0].Cells[nColumnaActual].Value = nPreInicial;
                    dtgPartidaDestino.Rows[1].Cells[nColumnaActual].Value = nSaldoInicial;                    
                }               
            }
            calcularModificacionDestino();

        }
        private void calcularModificacionDestino()
        {
            decimal nSumaActualPres = 0;
            decimal nSumaActualSaldo = 0;
            for (int j = nEnero; j < nEnero + 12; j++)
            {
                nSumaActualPres += Convert.ToDecimal((Convert.ToDecimal(dtgPartidaDestino.Rows[0].Cells[j].Value)).ToString("##,##0.00"));
                nSumaActualSaldo += Convert.ToDecimal((Convert.ToDecimal(dtgPartidaDestino.Rows[1].Cells[j].Value)).ToString("##,##0.00"));
            }           
            txtMovimientoDestino.Text = (nSumaActualPres - Convert.ToDecimal(cValoresPresDestino[nEnero + 12])).ToString("##,##0.00");
            dtgPartidaDestino.Rows[0].Cells[nEnero + 12].Value = nSumaActualPres;
            dtgPartidaDestino.Rows[1].Cells[nEnero + 12].Value = nSumaActualSaldo;            
        }
        private Boolean verificarMaxDigitos(DataGridView dtgLocal)
        {
            decimal nSumaActualPres = 0;
            decimal nSumaActualSaldo = 0;
            for (int j = nEnero; j < nEnero + 12; j++)
            {
                nSumaActualPres += Convert.ToDecimal((Convert.ToDecimal(dtgLocal.Rows[0].Cells[j].Value)).ToString("##,##0.00"));
                nSumaActualSaldo += Convert.ToDecimal((Convert.ToDecimal(dtgLocal.Rows[1].Cells[j].Value)).ToString("##,##0.00"));
            }
            if (nSumaActualPres > 999999999999.99m)
            {
                MessageBox.Show("Limite de digitos exedido Total", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                return false;
            }
            return true;
        }

        private void insertarNuevaPartida(int idPartida, String cFundamento, int idPeriodo, int idTipoModific, int idUsuSolicitante,
                                        int idUsu, DateTime dFecha, int idPartidaOrigen, int idPartidaDestino, String xmlModifPres, Decimal nMovimiento, int idAgencia)
        {            
            DataTable dtResultado = cnpartidamodificacion.InsertarPartida(idPartida, cFundamento, idPeriodo, idTipoModific, idUsuSolicitante,
                                                      idUsu, dFecha, idPartidaOrigen, idPartidaDestino, xmlModifPres, nMovimiento, idAgencia);            
            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ejecutarReasignacion(int idSolicitud, int idPeriodo, int idPartidaModificacion, int idUsuario, DateTime dFecha)
        {
            DataTable dtResultado = cnpartidamodificacion.ProcesarModificacionPresupuesto(idSolicitud, idPeriodo, idPartidaModificacion, idUsuario, dFecha);
            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            if ((int)dtResultado.Rows[0]["idError"] == 0)
            {
                listarPartidasModif((int) this.cboPeriodoPresupuestal1.SelectedValue);
            }
        }      

        private void habilitarControles(Boolean Val)
        {           
            
            this.txtJustificacion.Enabled = Val;
            this.conBusUsuSolicitante.HabilitarControles(Val);
            this.dtgPartidasReasig.Enabled = !Val;
            this.cboPeriodoPresupuestal1.Enabled = !Val;        
            if (!lEsEjecucion)
            {
                this.btnNuevo1.Enabled = false;          
                this.btnBuscaPartidaOrigen.Enabled = false;
                this.btnBuscaPartidaDestino.Enabled = false;
            }
            else
            {
                this.btnNuevo1.Enabled = !Val;           
                this.btnBuscaPartidaOrigen.Enabled = Val;
                this.btnBuscaPartidaDestino.Enabled = Val;
            }
            if (cTipoOperacion == "A")
            {
                this.dtgPartidaOrigen.ReadOnly = true;
                this.dtgPartidaDestino.ReadOnly = true;
                this.btnBuscaPartidaOrigen.Enabled = false;
                this.btnBuscaPartidaDestino.Enabled = false;
            }
            else 
            {
                this.dtgPartidaOrigen.ReadOnly = Val;
                this.dtgPartidaDestino.ReadOnly = Val;
            }
            this.btnCancelar1.Enabled = Val;
            this.btnGrabar1.Enabled = Val;                       
        }
        private void limpiarControles()
        {                       
            this.txtCodigo.Clear();
            this.txtJustificacion.Clear();
            this.cboLimAplicaSaldoOrigen.SelectedIndex = -1;            
            this.nudPorcentajeOrigen.Value = 0;
            this.txtDisponibleNeto.Clear();
            this.txtMovimientoOrigen.Clear();
            this.txtMovimientoDestino.Clear();
            this.conBusUsuSolicitante.LimpiarDatos();            
            this.txtCodNombrePartidaOrigen.Clear();
            this.txtCodNombrePartidaDestino.Clear();
            this.dtgPartidaOrigen.DataSource = null;
            this.dtgPartidaDestino.DataSource = null;
            idPartidaOrigenG = 0;
            idPartidaDestinoG = 0;
            this.grbProcesar.Visible = false;
        }        
        private Boolean verificarDetallesModif()
        {
            if (String.IsNullOrEmpty(this.txtJustificacion.Text.Trim()))
            {
                MessageBox.Show("Ingresar justificación de la partida", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtJustificacion.Focus();
                return false;    
            }
            if (String.IsNullOrEmpty(this.conBusUsuSolicitante.txtCod.Text))
            {
                MessageBox.Show("Seleccionar usuario solicitante", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.conBusUsuSolicitante.txtCod.Focus();
                return false;   
            }
            if (!String.IsNullOrEmpty(this.txtMovimientoOrigen.Text.Trim()) && !String.IsNullOrEmpty(this.txtMovimientoDestino.Text.Trim()))
            {
                if (Convert.ToDecimal( this.txtMovimientoOrigen.Text) != Convert.ToDecimal(this.txtMovimientoDestino.Text))
                {
                    MessageBox.Show("Los movimientos son inconsistentes", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;    
                }                                
            }
            else
            {
                MessageBox.Show("No se hicieron cambios presupuestales", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;   
            }
                
            return true;
        }

        
        
        #endregion       

        

       

       

      
    }
}


