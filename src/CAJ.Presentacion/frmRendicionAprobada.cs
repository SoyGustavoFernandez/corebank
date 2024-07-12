using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CAJ.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;

namespace CAJ.Presentacion
{
    public partial class frmRendicionAprobada : frmBase
    {
        #region Variables
        private int idEntregaRendicion = 0;
        private decimal nMonto;
        private int idMoneda;
        private string cSustento;
        private int idConceptoDevolucion;
        private clsCNCuentasPorPagar cnCuentasPorPagar = new clsCNCuentasPorPagar();
        #endregion

        #region Metodos
        
        public frmRendicionAprobada()
        {
            InitializeComponent();
        }

        private void personalizarTamanio()
        {
            int nHeigthRow = 22;
            if(dtgComprobantesPago.Rows.Count > 0)
                nHeigthRow = dtgComprobantesPago.Rows[0].Height;
            

            int nRows = dtgComprobantesPago.Rows.Count >= 10 ? 10: (dtgComprobantesPago.Rows.Count<=3?3: dtgComprobantesPago.Rows.Count);
            int nHeigth = nHeigthRow * nRows + dtgComprobantesPago.ColumnHeadersHeight;

            dtgComprobantesPago.Height = nHeigth + 3;
            grbCpg.Height = nHeigth + 25;
        }

        private void abrirFormularioRendicion(int idUsuario){
            frmEntregasRendirAprobados frmRendicionaprob = new frmEntregasRendirAprobados();
            frmRendicionaprob.cTipoEntrega = "Rendicion";
            frmRendicionaprob.idUsuario = idUsuario;
            frmRendicionaprob.cCargo = this.conBusCol1.txtCargo.Text;
            frmRendicionaprob.cNombre = this.conBusCol1.txtNom.Text;

            frmRendicionaprob.ShowDialog();
            idEntregaRendicion = frmRendicionaprob.idEntrega;
            nMonto = frmRendicionaprob.nMonto;
            idMoneda = frmRendicionaprob.idMoneda;
            cSustento = frmRendicionaprob.cMotivo;
            idConceptoDevolucion = frmRendicionaprob.idConceptoDevolucion;

            if (idEntregaRendicion != 0)
            {
                obtenerDetalleRendicion(idEntregaRendicion);
            }
        }

        private void obtenerDetalleRendicion(int idEntrega)
        {
            txtSolicitud.Text = idEntrega.ToString();
            this.conBusCol1.Enabled = false;
            /*Valida usuario que inició registro*/
            DataTable dtUsuario = cnCuentasPorPagar.obtenerUsuarioInicioRendicion(idEntrega);
            int idUsuarioRendicion = clsVarGlobal.PerfilUsu.idUsuario;

            if(dtUsuario.Rows.Count > 0){
                idUsuarioRendicion = Convert.ToInt32(dtUsuario.Rows[0]["idUsuario"]);
            }

            if (clsVarGlobal.PerfilUsu.idUsuario == idUsuarioRendicion)
            {
                /*Obtener Comprobantes de Pago vinculados*/
                DataTable dtDetRendicion = new DataTable();
                dtDetRendicion = cnCuentasPorPagar.obtenerComprobantesRendicion(idEntrega);

                dtDetRendicion.Columns.Add("nTotalTmp", typeof(Decimal));

                foreach (DataColumn col in dtDetRendicion.Columns)
                    col.ReadOnly = false;

                foreach (DataRow row in dtDetRendicion.Rows)
                {
                    row["nTotalTmp"] = Convert.ToDecimal(row["nTotal"]) - (Convert.ToDecimal(row["nTotalDetraccion"]) + Convert.ToDecimal(row["nTotCuartaCateg"]));
                }
                    

                this.dtgComprobantesPago.DataSource = null;
                this.dtgComprobantesPago.Rows.Clear();
                this.dtgComprobantesPago.Columns.Clear();
                this.dtgComprobantesPago.Refresh();
                dtgComprobantesPago.DataSource = dtDetRendicion;
                formatearDtgComprobantes();

                personalizarTamanio();

                /*Obtener Recibos vinculados*/
                DataTable dtRecibos = new DataTable();
                dtRecibos = cnCuentasPorPagar.obtenerRecibosRendicion(idEntrega);
                foreach (DataColumn col in dtRecibos.Columns)
                    col.ReadOnly = false;

                this.dtgRecibos.DataSource = null;
                this.dtgRecibos.Rows.Clear();
                this.dtgRecibos.Columns.Clear();
                this.dtgRecibos.Refresh();
                dtgRecibos.DataSource = dtRecibos;
                formatearDtgRecibos();

                cargarResumenDetalle(dtDetRendicion, dtRecibos);
                btnFinalizar1.Enabled = true;
            }
            else
            {
                btnFinalizar1.Enabled = false;
                MessageBox.Show("El usuario "+(dtUsuario.Rows.Count>0?dtUsuario.Rows[0]["cNombre"]:"")+" ya inició la rendición, solo dicho usuario puede finalizar la rendición.", "Validación de Rendición", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cargarResumenDetalle(DataTable dtDetRendicion, DataTable dtRecibos)
        {
            /*Datos por DTG*/
            decimal nTotalCpg = 0;
            foreach (DataRow row in dtDetRendicion.Rows)
            {
                nTotalCpg += Convert.ToDecimal(row["nTotal"]);
            }

            decimal nTotalRec = 0;
            foreach (DataRow row in dtRecibos.Rows)
            {
                nTotalRec += Convert.ToDecimal(row["nMonto"]);
            }


            /*Construye Detalle de la Rendición*/
            DataTable dtDetalle = new DataTable();
            dtDetalle.Columns.Add("cTipo", typeof(string));
            dtDetalle.Columns.Add("cSimbolo", typeof(string));
            dtDetalle.Columns.Add("nTotal", typeof(decimal));

            dtDetalle.Rows.Add("Importe Habilitado", idMoneda == 1 ? "S/" : "$", nMonto);
            dtDetalle.Rows.Add("Importe Rendido", idMoneda == 1 ? "S/" : "$", nTotalCpg + nTotalRec);
            if (nMonto != nTotalCpg + nTotalRec)
            {
                dtDetalle.Rows.Add(
                    nMonto > nTotalCpg + nTotalRec ? "Importe por Devolver" : "Importe por Reembolsar"
                    , idMoneda == 1 ? "S/" : "$"
                    , Math.Abs(nMonto - (nTotalCpg + nTotalRec)));
            }

            dtgDetalle.DataSource = dtDetalle;

            /*Construye Resumen de la Rendición*/
            DataTable dtResumen = new DataTable();
            dtResumen.Columns.Add("cTipo", typeof(string));
            dtResumen.Columns.Add("nCantidad", typeof(string));
            dtResumen.Columns.Add("cSimbolo", typeof(string));
            dtResumen.Columns.Add("nTotal", typeof(decimal));

            dtResumen.Rows.Add("Comprobantes", dtDetRendicion.Rows.Count.ToString(), idMoneda == 1 ? "S/" : "$", nTotalCpg);
            dtResumen.Rows.Add("Recibos", dtRecibos.Rows.Count.ToString(), idMoneda == 1 ? "S/" : "$", nTotalRec);
            dtResumen.Rows.Add("Total", "", idMoneda == 1 ? "S/" : "$", nTotalCpg + nTotalRec);

            dtgResumen.DataSource = dtResumen;

            formatearResumenDetalleDtg();
        }

        private void formatearDtgComprobantes()
        {
            foreach (DataGridViewColumn column in dtgComprobantesPago.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgComprobantesPago.Columns["nRow"].Visible = true;
            dtgComprobantesPago.Columns["cProveedor"].Visible = true;
            dtgComprobantesPago.Columns["cTipoComprobante"].Visible = true;
            dtgComprobantesPago.Columns["cNumero"].Visible = true;
            dtgComprobantesPago.Columns["cSerie"].Visible = true;
            dtgComprobantesPago.Columns["cSimbolo"].Visible = true;
            dtgComprobantesPago.Columns["nTotalTmp"].Visible = true;
            dtgComprobantesPago.Columns["cEstadoComprobante"].Visible = true;

            dtgComprobantesPago.Columns["nRow"].HeaderText = "#";
            dtgComprobantesPago.Columns["cProveedor"].HeaderText = "Proveedor";
            dtgComprobantesPago.Columns["cTipoComprobante"].HeaderText = "Comprobante";
            dtgComprobantesPago.Columns["cNumero"].HeaderText = "Número";
            dtgComprobantesPago.Columns["cSerie"].HeaderText = "Serie";
            dtgComprobantesPago.Columns["cSimbolo"].HeaderText = "";
            dtgComprobantesPago.Columns["nTotal"].HeaderText = "Monto";
            dtgComprobantesPago.Columns["cEstadoComprobante"].HeaderText = "Estado";

            dtgComprobantesPago.Columns["cNumero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgComprobantesPago.Columns["cSerie"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgComprobantesPago.Columns["cSimbolo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgComprobantesPago.Columns["nTotalTmp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgComprobantesPago.Columns["cEstadoComprobante"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgComprobantesPago.Columns["nTotal"].DefaultCellStyle.Format = "N2";

            dtgComprobantesPago.Columns["nRow"].FillWeight = 4;
            dtgComprobantesPago.Columns["cProveedor"].FillWeight = 42;
            dtgComprobantesPago.Columns["cTipoComprobante"].FillWeight = 26;
            dtgComprobantesPago.Columns["cNumero"].FillWeight = 7;
            dtgComprobantesPago.Columns["cSerie"].FillWeight = 7;
            dtgComprobantesPago.Columns["cSimbolo"].FillWeight = 4;
            dtgComprobantesPago.Columns["nTotalTmp"].FillWeight = 10;
            dtgComprobantesPago.Columns["cEstadoComprobante"].FillWeight = 10;

            dtgComprobantesPago.Columns["nRow"].DisplayIndex = 0;
            dtgComprobantesPago.Columns["cProveedor"].DisplayIndex = 1;
            dtgComprobantesPago.Columns["cTipoComprobante"].DisplayIndex = 2;
            dtgComprobantesPago.Columns["cNumero"].DisplayIndex = 3;
            dtgComprobantesPago.Columns["cSerie"].DisplayIndex = 4;
            dtgComprobantesPago.Columns["cSimbolo"].DisplayIndex = 5;
            dtgComprobantesPago.Columns["nTotalTmp"].DisplayIndex = 6;
            dtgComprobantesPago.Columns["cEstadoComprobante"].DisplayIndex = 7;

            DataGridViewButtonColumn btnAdd = new DataGridViewButtonColumn();
            {
                btnAdd.Name = "btnCargarComprobante";
                btnAdd.HeaderText = "Pagar";
                btnAdd.Text = "Pagar";
                btnAdd.UseColumnTextForButtonValue = true;
                btnAdd.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnAdd.FlatStyle = FlatStyle.Standard;
                btnAdd.CellTemplate.Style.BackColor = Color.Honeydew;
                btnAdd.Visible = true;
                btnAdd.DisplayIndex = 8;
                dtgComprobantesPago.Columns.Add(btnAdd);
            }
        }

        private void formatearDtgRecibos()
        {
            foreach (DataGridViewColumn column in dtgRecibos.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgRecibos.Columns["cConcepto"].Visible = true;
            dtgRecibos.Columns["cSimbolo"].Visible = true;
            dtgRecibos.Columns["nMonto"].Visible = true;
            dtgRecibos.Columns["cEstado"].Visible = true;

            dtgRecibos.Columns["cConcepto"].HeaderText = "Concepto";
            dtgRecibos.Columns["cSimbolo"].HeaderText = "";
            dtgRecibos.Columns["nMonto"].HeaderText = "Monto";
            dtgRecibos.Columns["cEstado"].HeaderText = "Estado";


            dtgRecibos.Columns["nMonto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgRecibos.Columns["nMonto"].DefaultCellStyle.Format = "N2";

            dtgRecibos.Columns["cConcepto"].FillWeight = 79;
            dtgRecibos.Columns["cSimbolo"].FillWeight = 4;
            dtgRecibos.Columns["nMonto"].FillWeight = 9;
            dtgRecibos.Columns["cEstado"].FillWeight = 8;

            dtgRecibos.Columns["cConcepto"].DisplayIndex = 0;
            dtgRecibos.Columns["cSimbolo"].DisplayIndex = 1;
            dtgRecibos.Columns["nMonto"].DisplayIndex = 2;
            dtgRecibos.Columns["cEstado"].DisplayIndex = 3;

            DataGridViewButtonColumn btnAdd = new DataGridViewButtonColumn();
            {
                btnAdd.Name = "btnEmitirRecibo";
                btnAdd.HeaderText = "Emitir";
                btnAdd.Text = "Emitir";
                btnAdd.UseColumnTextForButtonValue = true;
                btnAdd.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnAdd.FlatStyle = FlatStyle.Standard;
                btnAdd.CellTemplate.Style.BackColor = Color.Honeydew;
                btnAdd.Visible = true;
                btnAdd.DisplayIndex = 4;
                dtgRecibos.Columns.Add(btnAdd);
            }
        }

        private void formatearResumenDetalleDtg()
        {
            /*Formato de DTG de Detalle*/
            dtgDetalle.Columns["cTipo"].HeaderText = "Detalle";
            dtgDetalle.Columns["cSimbolo"].HeaderText = "";
            dtgDetalle.Columns["nTotal"].HeaderText = "Total";
            
            dtgDetalle.Columns["cTipo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgDetalle.Columns["nTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            dtgDetalle.Columns["nTotal"].DefaultCellStyle.Format = "N2";
            
            dtgDetalle.Columns["cTipo"].FillWeight = 62;
            dtgDetalle.Columns["cSimbolo"].FillWeight = 10;
            dtgDetalle.Columns["nTotal"].FillWeight = 33;
            
            dtgDetalle.Enabled = false;
            dtgDetalle.ClearSelection();

            /*Formato de DTG de Resumen*/
            dtgResumen.Columns["cTipo"].HeaderText = "Tipo";
            dtgResumen.Columns["nCantidad"].HeaderText = "#";
            dtgResumen.Columns["cSimbolo"].HeaderText = "";
            dtgResumen.Columns["nTotal"].HeaderText = "Total";
            
            dtgResumen.Columns["cTipo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgResumen.Columns["nTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            dtgResumen.Columns["nTotal"].DefaultCellStyle.Format = "N2";
            
            dtgResumen.Columns["cTipo"].FillWeight = 43;
            dtgResumen.Columns["nCantidad"].FillWeight = 12;
            dtgResumen.Columns["cSimbolo"].FillWeight = 13;
            dtgResumen.Columns["nTotal"].FillWeight = 32;
            
            dtgResumen.Enabled = false;
            dtgResumen.ClearSelection();
        }

        private int copiarComprobantePagoTmp()
        {
            /*
             * Registrar comprobante y detalle en temporal
             * Jalar los datos de la temporal pero para mandar reemplzar el idComrpobante y el idDetalle para que se actualice en la tabla original de si_fincomprobante
             * Para eso se debe guardar los id reales en la temporal
             */
            DataTable dtComprPago = cnCuentasPorPagar.obtenerComprobanteTemporal(Convert.ToInt32(dtgComprobantesPago.CurrentRow.Cells["idComprobantePagoTmp"].Value));
            foreach (DataColumn col in dtComprPago.Columns)
                col.ReadOnly = false;
            foreach (DataRow row in dtComprPago.Rows)
            {
                row["idComprobantePago"] = row["idComprobantePagoCoreBank"];
                row["idAgencia"] = clsVarGlobal.nIdAgencia;
                row["dFechaOpe"] = clsVarGlobal.dFecSystem;
                row["dFechaProvision"] = clsVarGlobal.dFecSystem;
                row["idUsuarioRegistro"] = clsVarGlobal.PerfilUsu.idUsuario;
            }

            DataTable dtDetComprPago = cnCuentasPorPagar.obtenerDetalleComprobanteTemporal(Convert.ToInt32(dtgComprobantesPago.CurrentRow.Cells["idComprobantePagoTmp"].Value));
            foreach (DataColumn col in dtDetComprPago.Columns)
                col.ReadOnly = false;
            foreach (DataRow row in dtDetComprPago.Rows)
            {
                row["idComprobantepago"] = row["idComprobantePagoCoreBank"];
                row["idDetalleComprobante"] = row["idDetalleComprobanteCoreBank"];
            }

            if (dtComprPago.Rows.Count > 0)
            {
                DataSet dsComprPago = new DataSet("dsComprPago");
                DataSet dsDetComprPago = new DataSet("dsDetComprPago");
                DataSet dsDescComprPago = new DataSet("dsDescComprPago");


                dtComprPago.TableName = "dtComprPago";
                dtDetComprPago.TableName = "dtDetComprPago";

                dsComprPago.Tables.Add(dtComprPago);
                dsDetComprPago.Tables.Add(dtDetComprPago);

                string xmlComprPago = clsCNFormatoXML.EncodingXML(dsComprPago.GetXml());
                string xmlDetComprPago = clsCNFormatoXML.EncodingXML(dsDetComprPago.GetXml());

                dsComprPago.Tables.Clear();
                dsDetComprPago.Tables.Clear();
                dsDescComprPago.Tables.Clear();

                DataTable dtResult = cnCuentasPorPagar.copiarComprobanteRendicion(xmlComprPago, xmlDetComprPago, idEntregaRendicion, Convert.ToInt32(dtgComprobantesPago.CurrentRow.Cells["idComprobantePagoTmp"].Value));

                if (dtResult.Rows[0]["idMsje"].ToString() == "0")
                {
                    return Convert.ToInt32(dtResult.Rows[0]["idComprobantePago"]);
                }
                else
                {
                    MessageBox.Show(dtResult.Rows[0]["cMsje"].ToString(), "Copiar Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return 0;
                }
            }

            return 0;
        }
        #endregion

        #region Ventos
        private void frmRendicionAprobada_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
        }

        private void dtgComprobantesPago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgComprobantesPago.Columns["btnCargarComprobante"].Index && e.RowIndex >= 0)
            {
                if (Convert.ToInt32(dtgComprobantesPago.CurrentRow.Cells["idComprobantePago"].Value) == 0 || Convert.ToBoolean(dtgComprobantesPago.CurrentRow.Cells["lModificado"].Value))
                {
                    dtgComprobantesPago.CurrentRow.Cells["idComprobantePago"].Value = copiarComprobantePagoTmp();
                    dtgComprobantesPago.CurrentRow.Cells["lModificado"].Value = 0;
                }

                if (Convert.ToInt32(dtgComprobantesPago.CurrentRow.Cells["idComprobantePago"].Value) != 0)
                {
                    frmRegistroPagoComprobante frmregpagocpg = new frmRegistroPagoComprobante(Convert.ToInt32(dtgComprobantesPago.CurrentRow.Cells["idComprobantePago"].Value));
                    frmregpagocpg.objFrmSemaforo = this.objFrmSemaforo;
                    frmregpagocpg.ShowDialog();

                    if (frmregpagocpg.lComprobantePagado)
                    {
                        dtgComprobantesPago.CurrentRow.Cells["cEstadoComprobante"].Value = "PAGADO";
                    }
                }
                
            }
        }

        private void dtgRecibos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgRecibos.Columns["btnEmitirRecibo"].Index && e.RowIndex >= 0)
            {
                if (Convert.ToInt32(dtgRecibos.CurrentRow.Cells["idRecibo"].Value) == 0)
                {
                    //Generar recibo
                    frmEmisionRecibos frmRecibos = new frmEmisionRecibos(
                        Convert.ToInt32(this.conBusCol1.txtCod.Text),
                        Convert.ToInt32(dtgRecibos.CurrentRow.Cells["idTipRecibo"].Value),
                        Convert.ToInt32(dtgRecibos.CurrentRow.Cells["idConcepto"].Value),
                        Convert.ToInt32(dtgRecibos.CurrentRow.Cells["idMoneda"].Value),
                        Convert.ToDecimal(dtgRecibos.CurrentRow.Cells["nMonto"].Value),
                        Convert.ToString(dtgRecibos.CurrentRow.Cells["cSustento"].Value),
                        idEntregaRendicion);
                    frmRecibos.objFrmSemaforo = this.objFrmSemaforo;
                    frmRecibos.ShowDialog();

                    if (frmRecibos.cCodigoRecibo != "")
                    {
                        DataTable dtRes = cnCuentasPorPagar.vincularReciboRendicion(idEntregaRendicion, Convert.ToInt32(dtgRecibos.CurrentRow.Cells["idConcepto"].Value), Convert.ToInt32(frmRecibos.cCodigoRecibo));
                        dtgRecibos.CurrentRow.Cells["idRecibo"].Value = frmRecibos.cCodigoRecibo;
                        dtgRecibos.CurrentRow.Cells["cEstado"].Value = "EMITIDO";
                    }
                }
                else
                {
                    frmEmisionRecibos frmRecibos = new frmEmisionRecibos();
                    frmRecibos.idReciboBuscar = (Convert.ToInt32(dtgRecibos.CurrentRow.Cells["idRecibo"].Value));
                    frmRecibos.ShowDialog();
                }
            }

        }

        private void conBusCol1_BuscarUsuario(object sender, EventArgs e)
        {
            if (this.conBusCol1.txtCod.Text == "")
            {
                MessageBox.Show("No se ha seleccionado un colaborador", "Rendiciones Aprobadas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            abrirFormularioRendicion(Convert.ToInt32(this.conBusCol1.txtCod.Text));
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            idEntregaRendicion = 0;
            this.conBusCol1.LimpiarDatos();
            this.conBusCol1.Enabled = true;
            this.conBusCol1.txtCod.Enabled = true;
            this.conBusCol1.btnConsultar.Enabled = true;
            this.conBusCol1.txtCod.Focus();

            this.dtgComprobantesPago.DataSource = null;
            this.dtgComprobantesPago.Rows.Clear();
            this.dtgComprobantesPago.Columns.Clear();
            this.dtgComprobantesPago.Refresh();

            this.dtgRecibos.DataSource = null;
            this.dtgRecibos.Rows.Clear();
            this.dtgRecibos.Columns.Clear();
            this.dtgRecibos.Refresh();

            this.dtgResumen.DataSource = null;
            this.dtgResumen.Rows.Clear();
            this.dtgResumen.Columns.Clear();
            this.dtgResumen.Refresh();

            this.dtgDetalle.DataSource = null;
            this.dtgDetalle.Rows.Clear();
            this.dtgDetalle.Columns.Clear();
            this.dtgDetalle.Refresh();

            this.txtSolicitud.Text = "";
        }

        private void btnFinalizar1_Click(object sender, EventArgs e)
        {
            if (idEntregaRendicion == 0)
            {
                MessageBox.Show("No se tiene seleccioando una Rendición", "Finalizar Rendición", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dtValidacion = cnCuentasPorPagar.validarFinalizacionRendicion(idEntregaRendicion);
            if (!Convert.ToBoolean(dtValidacion.Rows[0]["lCompleto"]))
            {
                MessageBox.Show(dtValidacion.Rows[0]["cMsjIncompleto"].ToString(), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if(MessageBox.Show("Una vez finalizado la rendición, el proceso es irreversible \n\n¿Está seguro de Finalizar la Rendición?", "Finalizar Rendición", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmEmisionRecibos frmRecibos = new frmEmisionRecibos(Convert.ToInt32(this.conBusCol1.txtCod.Text), 1, idConceptoDevolucion, idMoneda, nMonto, "(SOL: " + idEntregaRendicion + ") " + cSustento, idEntregaRendicion);
                frmRecibos.objFrmSemaforo = this.objFrmSemaforo;
                frmRecibos.ShowDialog();

                if (frmRecibos.cCodigoRecibo != "")
                {
                    this.btnFinalizar1.Enabled = false;

                    /*Cambiar estado a Rendido*/
                    DataTable dtRendido = cnCuentasPorPagar.cambiarEstadoSolicitudRendicion(idEntregaRendicion, clsVarGlobal.PerfilUsu.idUsuario);

                    if (Convert.ToInt32(dtRendido.Rows[0]["idRespuesta"]) == 1)
                    {
                        MessageBox.Show(dtRendido.Rows[0]["cRespuesta"].ToString(), "Rendición de Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(dtRendido.Rows[0]["cRespuesta"].ToString(), "Rendición de Entrega", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.btnFinalizar1.Enabled = true;
                    }
                }   
            }            
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        #endregion
    }

}
