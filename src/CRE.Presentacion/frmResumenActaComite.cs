using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace CRE.Presentacion
{
    public partial class frmResumenActaComite : frmBase
    {
        #region Variables Globales
        Transaccion transaccion = Transaccion.Nuevo;
        clsCNSolicitud Solicitud = new clsCNSolicitud();
        CRE.CapaNegocio.clsCNComite cncomite = new CapaNegocio.clsCNComite();
        DataTable Sol = new DataTable("dtSolicitud");
        decimal nMontoSolicitado = 0;
        int nCodPro = 1, nCodEst = 0, idCliente = 0;
        #endregion

        public frmResumenActaComite()
        {
            InitializeComponent();
            this.conBusCuentaCli1.cTipoBusqueda = "S";
            this.conBusCuentaCli1.cEstado = "[2]";
            cboTipoCredito.CargarProducto(nCodPro);
            cboModDesemb1.SelectedIndex = 0;
            cboPersonalCreditos.SelectedValue = 0;
            cboDestinoCredito.SelectedValue = 0;
            cboOperacionCre1.SelectedValue = 0;
        }

        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EntityLayer.EventoFormulario.INICIO);
        }

        private void tbcActaComite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcActaComite.SelectedIndex==1)
            {
                cargarDatosSolicitud(conBusCuentaCli1.nValBusqueda);
            }
            else
            {

            }
        }

        private void conBusCuentaCli1_MyClic(object sender, EventArgs e)
        {
            if (conBusCuentaCli1.nValBusqueda == 0)
            {
                MessageBox.Show("No se encontró número de solicitud", "Valida solicitud de cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                cargarParticipantes();
            }
        }

        private void conBusCuentaCli1_MyKey(object sender, KeyPressEventArgs e)
        {
            if (conBusCuentaCli1.nValBusqueda == 0)
            {
                MessageBox.Show("No se encontró número de solicitud", "Valida solicitud de cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                cargarParticipantes();
            }
        }

        private void cboTipoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoCredito.SelectedIndex > 0)
            {
                nCodPro = Convert.ToInt32(cboTipoCredito.SelectedValue);
                cboSubTipoCredito.CargarProducto(nCodPro);
            }
            else
            {
                cboTipoCredito.SelectedIndex = 0;
            }
        }

        private void cboSubTipoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubTipoCredito.SelectedIndex > 0)
            {
                nCodPro = Convert.ToInt32(cboSubTipoCredito.SelectedValue);
                cboProducto.CargarProducto(nCodPro);
            }
            else
            {
                cboSubTipoCredito.SelectedIndex = 0;
            }
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex > 0)
            {
                nCodPro = Convert.ToInt32(cboProducto.SelectedValue);
                cboSubProducto.CargarProducto(nCodPro);
            }
            else
            {
                cboProducto.SelectedIndex = 0;
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                DataSet dsDetComite = new DataSet("dsDetComite");
                dsDetComite.Tables.Add((DataTable)dtgParticipantes.DataSource);

                string xmlDetComite = dsDetComite.GetXml();
                if (transaccion == Transaccion.Nuevo)
                {
                    cncomite.InsertarActaComiteCredito(
                        conBusCuentaCli1.nValBusqueda, txtNumActa.Text.Trim(), clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia, txtAcuerdo.Text.Trim(), txtObservaciones.Text.Trim(),
                        txtComentario.Text.Trim(), clsVarGlobal.User.idUsuario, xmlDetComite);
                    MessageBox.Show("Los datos se registraron correctamente", "Registro de acta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (transaccion== Transaccion.Edita)
                {
                    cncomite.ActualizarComiteCredito(
                       conBusCuentaCli1.nValBusqueda, txtNumActa.Text.Trim(), clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia, txtAcuerdo.Text.Trim(), txtObservaciones.Text.Trim(),
                       txtComentario.Text.Trim(), clsVarGlobal.User.idUsuario, xmlDetComite);                    
                    MessageBox.Show("Los datos se actualizaron correctamente", "Registro de acta", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }                
                cargarParticipantes();
                HabilitarControles(false);
                
                btnImprimir1.Enabled = true;
                transaccion = Transaccion.Nuevo;
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiarControles();
            limpiarSolicitud();
            tbcActaComite.SelectedIndex = 0;
            btnImprimir1.Enabled = false;
            btnEditar1.Enabled = false;
            transaccion = Transaccion.Nuevo;
            HabilitarControles(true);
        }

        #endregion

        #region Metodos

        private bool validar()
        {
            bool lVal = false;

            if (conBusCuentaCli1.nValBusqueda == 0)
            {
                MessageBox.Show("Seleccione una solicitud de crédito por favor", "Validación Acta de Comité", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusCuentaCli1.btnBusCliente1.Focus();
                return lVal;
            }

            if (txtNumActa.Text == "")
            {
                MessageBox.Show("Debe de ingresar el número de acta por favor", "Validación Acta de Comité", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumActa.Focus();
                return lVal;
            }

            if (txtAcuerdo.Text == "")
            {
                MessageBox.Show("Debe de ingresar el acuerdo de comité por favor", "Validación Acta de Comité", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAcuerdo.Focus();
                return lVal;
            }

            if (txtComentario.Text == "")
            {
                MessageBox.Show("Debe de ingresar el comentario final de comité por favor", "Validación Acta de Comité", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtComentario.Focus();
                return lVal;
            }

            var nParticipan = ((DataTable)dtgParticipantes.DataSource).AsEnumerable().Where(x => Convert.ToBoolean(x["lExiste"]) == true).Count();
            if (nParticipan == 0)
            {
                MessageBox.Show("Debe de seleccionar participantes de comité por favor", "Validación Acta de Comité", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtgParticipantes.Focus();
                return lVal;
            }

            lVal = true;
            return lVal;
        }

        private void HabilitarControles(bool lEstado)
        {
            txtAcuerdo.Enabled = lEstado;
            txtObservaciones.Enabled = lEstado;
            txtComentario.Enabled = lEstado;
            txtNumActa.Enabled = lEstado;
        }

        private void formatoGrid()
        {
            foreach (DataGridViewColumn item in dtgParticipantes.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dtgParticipantes.Columns["idAgencia"].Visible = false;
            dtgParticipantes.Columns["idUsuario"].Visible = false;
            dtgParticipantes.Columns["idCargo"].Visible = false;

            dtgParticipantes.Columns["cNombre"].HeaderText = "Nombres";
            dtgParticipantes.Columns["cCargo"].HeaderText = "Cargo";
            dtgParticipantes.Columns["lExiste"].HeaderText = "Participa?";

            dtgParticipantes.Columns["cNombre"].Width = 200;
            dtgParticipantes.Columns["cCargo"].Width = 100;
            dtgParticipantes.Columns["lExiste"].Width = 60;
        }

        private void limpiarControles()
        {
            txtNumActa.Text = "";
            txtObservaciones.Text = "";
            txtComentario.Text = "";
            txtAcuerdo.Text = "";
            dtgParticipantes.DataSource = null;
            conBusCuentaCli1.limpiarControles();
            conBusCuentaCli1.btnBusCliente1.Enabled = true;
            conBusCuentaCli1.txtNroBusqueda.Enabled = true;
        }

        private void cargarParticipantes()
        {
            var dtParticipante = cncomite.ListarIntegComiteCredito(clsVarGlobal.nIdAgencia);

            if (dtParticipante.Rows.Count > 0)
            {
                dtParticipante.Columns["lExiste"].ReadOnly = false;
                dtgParticipantes.DataSource = dtParticipante;
                formatoGrid();
                txtNumActa.Focus();

                var dtDatosActa = cncomite.RetornaDatosActaComite(conBusCuentaCli1.nValBusqueda);
                if (dtDatosActa.Rows.Count > 0)
                {
                    foreach (DataRow item in dtParticipante.Rows)
                    {
                        foreach (DataRow item2 in dtDatosActa.Rows)
                        {
                            if (item["idUsuario"].ToString() == item2["idUsuario"].ToString())
                            {
                                item["lExiste"] = true;
                            }
                        }
                    }

                    txtAcuerdo.Text = dtDatosActa.Rows[0]["cAcuerdo"].ToString();
                    txtObservaciones.Text = dtDatosActa.Rows[0]["cObservaciones"].ToString();
                    txtComentario.Text = dtDatosActa.Rows[0]["cComentario"].ToString();
                    txtNumActa.Text = dtDatosActa.Rows[0]["cNumActa"].ToString();
                    HabilitarControles(false);
                    transaccion = Transaccion.Edita;
                    dtgParticipantes.Columns["lExiste"].ReadOnly = true;
                    btnEditar1.Enabled = true;
                    btnImprimir1.Enabled = true;
                }
                else
                {
                    HabilitarControles(true);
                    transaccion = Transaccion.Nuevo;
                    dtgParticipantes.ReadOnly = false;
                    foreach (DataGridViewColumn item in dtgParticipantes.Columns)
                    {
                        item.ReadOnly = true;
                    }
                    dtgParticipantes.Columns["lExiste"].ReadOnly = false;
                    btnEditar1.Enabled = false;
                    btnImprimir1.Enabled = false;
                }
            }
        }

        private void cargarDatosSolicitud(Int32 idSolicitud)
        {
            Sol = Solicitud.ConsultaSolicitud(idSolicitud);

            if (Sol.Rows.Count > 0)
            {
                dtpFechaSol.Value = (DateTime)Sol.Rows[0]["dFechaRegistro"];
                txtMonto.Text = Sol.Rows[0]["nCapitalSolicitado"].ToString();
                nMontoSolicitado = (Decimal)Sol.Rows[0]["nCapitalSolicitado"];
                cboMoneda.SelectedValue = Convert.ToInt32(Sol.Rows[0]["IdMoneda"]);
                nudCuotas.Value = Convert.ToInt32(Sol.Rows[0]["nCuotas"]);
                nudPlazo.Value = Convert.ToInt32(Sol.Rows[0]["nPlazoCuota"]);
                nudDiasGracia.Value = Convert.ToInt32(Sol.Rows[0]["ndiasgracia"]);
                dtFechaDesembolso.Value = Convert.ToDateTime(Sol.Rows[0]["dFechaDesembolsoSugerido"]);
                cboEstadoCredito.SelectedValue = Convert.ToInt32(Sol.Rows[0]["idEstado"]);
                cboPersonalCreditos.SelectedValue = Convert.ToInt32(Sol.Rows[0]["idUsuario"]);
                cboTipoCredito.SelectedValue = Convert.ToInt32(Sol.Rows[0]["nTipCre"]);
                cboSubTipoCredito.SelectedValue = Convert.ToInt32(Sol.Rows[0]["nSubTip"]);
                cboProducto.SelectedValue = Convert.ToInt32(Sol.Rows[0]["nProdu"]);
                cboSubProducto.SelectedValue = Convert.ToInt32(Sol.Rows[0]["nSubPro"]);
                cboDestinoCredito.SelectedValue = Convert.ToInt32(Sol.Rows[0]["idDestino"]);
                cboModDesemb1.SelectedValue = Convert.ToInt32(Sol.Rows[0]["idModalidadDes"]);
                txtTasaCom.Text = Convert.ToString(Sol.Rows[0]["nTasaCompensatoria"]);
                txtTasaMora.Text = Convert.ToString(Sol.Rows[0]["nTasaMoratoria"]);
                nCodEst = Convert.ToInt32(Sol.Rows[0]["idEstado"]);
                cboEstadoCredito.CargaEstadoActual(nCodEst);
                cboTipoPeriodo.SelectedValue = Convert.ToInt32(Sol.Rows[0]["idTipoPeriodo"]);
                cboOperacionCre1.SelectedValue = Convert.ToInt32(Sol.Rows[0]["idOperacion"]);
                idCliente = Convert.ToInt32(Sol.Rows[0]["idCli"]);
                txtMontoAmpliado.Text = Sol.Rows[0]["nMontoAmpliado"].ToString();
                txtSaldoCredito.Text = Sol.Rows[0]["nSaldoCreditos"].ToString();

                if (Convert.ToInt32(Sol.Rows[0]["idTipoPeriodo"]) == 1)
                {
                    this.lblBase19.Text = "Día de Pago:";
                    this.lblBase3.Text = "";
                    this.nudPlazo.Maximum = 31;
                }
                else
                {
                    this.lblBase19.Text = "Frecuencia:";
                    this.lblBase3.Text = "en días";
                    this.nudPlazo.Maximum = 365;
                }
                conBusCuentaCli1.btnBusCliente1.Enabled = false;
                conBusCuentaCli1.txtNroBusqueda.Enabled = false;
            }
            else
            {
                limpiarControles();
            }

        }

        private void limpiarSolicitud()
        {
            txtMonto.Text = "";
            cboMoneda.SelectedValue = 0;
            nudCuotas.Value = 0;
            nudPlazo.Value = 0;
            nudDiasGracia.Value = 0;
            dtFechaDesembolso.Value = clsVarGlobal.dFecSystem;
            cboOperacionCre1.SelectedValue = 1;
            cboEstadoCredito.SelectedValue = 0;
            cboPersonalCreditos.SelectedValue = 0;
            cboTipoCredito.SelectedValue = 0;
            cboSubTipoCredito.SelectedValue = 0;
            cboProducto.SelectedValue = 0;
            cboSubProducto.SelectedValue = 0;
            cboDestinoCredito.SelectedValue = 0;
            txtTasaCom.Text = "";
            txtTasaMora.Text = "";
            cboEstadoCredito.CargaEstadoActual(999);
            conBusCuentaCli1.txtEstado.Text = "";
            conBusCuentaCli1.txtNombreCli.Text = "";
            conBusCuentaCli1.txtNroBusqueda.Text = "";
            conBusCuentaCli1.txtCodCli.Text = "";
            conBusCuentaCli1.txtNroDoc.Text = "";
            cboModDesemb1.SelectedIndex = 0;
            chTasaEspecial.Checked = false;
            txtMontoAmpliado.Text = "";
            txtSaldoCredito.Text = "";
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            transaccion = Transaccion.Edita;
            dtgParticipantes.ReadOnly = false;
            foreach (DataGridViewColumn item in dtgParticipantes.Columns)
            {
                item.ReadOnly = true;
            }
            dtgParticipantes.Columns["lExiste"].ReadOnly = false;

            txtAcuerdo.Enabled = true;
            txtObservaciones.Enabled = true;
            txtComentario.Enabled = true;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            int idSolicitud = conBusCuentaCli1.nValBusqueda;

            if (idSolicitud == 0)
            {
                MessageBox.Show("Seleccione una solicitud de crédito por favor", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>(); 
            dtslist.Add(new ReportDataSource("dsActaComite", cncomite.RptActaComiteCredito(idSolicitud)));
            dtslist.Add(new ReportDataSource("dsDetalleComite", cncomite.RetornaDetalleComite(idSolicitud)));                       
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("idSolicitud", idSolicitud.ToString(), false));
            string reportpath = "rptActaComite.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        #endregion
    }
}
