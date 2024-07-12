using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using RCP.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using CRE.Presentacion;
using SPL.CapaNegocio;
using CLI.CapaNegocio;

namespace RCP.Presentacion
{
    public partial class frmHistorialRecupera : frmBase
    {

        #region Variables

        clsCNEventoRecupera eventorecupera = new clsCNEventoRecupera();
        clsCNPep cnpep = new clsCNPep();
        clsCNSolicitudRecuperacion cnsolicitudrecupera = new clsCNSolicitudRecuperacion();
        clsCNCliente cnCliente = new clsCNCliente();
        DataTable dtCreditos = new DataTable();
        DataTable dtEventos = new DataTable();
        int idCreditoSeleccionado = 0;
        #endregion

        public frmHistorialRecupera()
        {
            InitializeComponent();
        }

        public frmHistorialRecupera(int idCliente)
        {
            InitializeComponent();
            conBusCli1.txtCodCli.Text = idCliente.ToString();
            conBusCli1.CargardatosCli(idCliente);
            cargar();
            btnCancelar1.Visible = false;
        }

        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);

            habiliatarBotones(false);
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnRegEvento_Click(object sender, EventArgs e)
        {
            if (conBusCli1.idCli>0)
            {
                frmRegistroVisita frmRegContacto = new frmRegistroVisita(conBusCli1.idCli);
                frmRegContacto.ShowDialog();
                cargarEventos();
            }
        }

        private void btnDatCli_Click(object sender, EventArgs e)
        {
            if (conBusCli1.idCli > 0)
            {
                if (conBusCli1.nidTipoPersona == 1)
                {
                    string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
                    String AgenEmision = clsVarApl.dicVarGen["cNomAge"];

                    List<ReportParameter> paramlist = new List<ReportParameter>();
                    List<ReportDataSource> dtslist = new List<ReportDataSource>();

                    paramlist.Add(new ReportParameter("x_cNombEmpresa", cNomEmp, false));
                    paramlist.Add(new ReportParameter("x_AgenEmision", AgenEmision, false));
                    paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));


                    dtslist.Add(new ReportDataSource("DataSet1", new clsRPTCNClientes().CNRetornoCliente(conBusCli1.idCli)));
                    dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));

                    dtslist.Add(new ReportDataSource("dsDatosPepCliente", cnpep.DatosPepCliente(conBusCli1.idCli)));

                    string reportpath = "rptFichaCli.rdlc";
                    new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                }
                else
                    MessageBox.Show("El Reporte sólo es para personas Naturales", "Impresión de Reportes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnDirRecupera_Click(object sender, EventArgs e)
        {
            if (conBusCli1.idCli > 0)
            {
                frmDireccionRecupera frmdireccion = new frmDireccionRecupera(conBusCli1.idCli);
                frmdireccion.ShowDialog();
            }
        }

        private void btnPosCli_Click(object sender, EventArgs e)
        {
            if (conBusCli1.idCli > 0)
            {
                FrmPosicionCli frmposicioncli = new FrmPosicionCli(conBusCli1.idCli);
                frmposicioncli.ShowDialog();
            }
        }

        private void btnCartas_Click(object sender, EventArgs e)
        {
            if (conBusCli1.idCli>0)
            {
                frmCartasNotifica frmcartanotifica = new frmCartasNotifica(conBusCli1.idCli);
                frmcartanotifica.ShowDialog();
                conBusCli1_ClicBuscar(sender, e);
                if (dtgEventos.Rows.Count > 0)
                {
                    habiliatarBotones(true);
                }
                else
                {
                    habiliatarBotones(true);
                    btnImprimir1.Enabled = false;
                }
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (dtgEventos.RowCount > 0)
            {
                int idCuenta = Convert.ToInt32(dtgCreditos.Rows[idCreditoSeleccionado].Cells["idCuenta"].Value);

                var eventos = cnsolicitudrecupera.EventosTransRecupera(idCuenta);

                if (eventos.Rows.Count > 0)
                {
                    List<ReportDataSource> dtsList = new List<ReportDataSource>();
                    dtsList.Add(new ReportDataSource("dsEventosTrans", eventos));

                    List<ReportParameter> paramList = new List<ReportParameter>();
                    paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                    paramList.Add(new ReportParameter("idCuenta", idCuenta.ToString(), false));
                    paramList.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
                    paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));


                    string reportPath = "rptContactoCliente.rdlc";
                    new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
                }
                else
                {
                    MessageBox.Show("No existen datos", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            conBusCli1.Enabled = true;
            conBusCli1.limpiarControles();
            dtgEventos.DataSource = null;
            dtgCreditos.DataSource = null;
            habiliatarBotones(false);
            conBusCli1.txtCodCli.Enabled = true;
            conBusCli1.txtCodCli.Focus();
            lblBaseNegativa.Text = "";
        }

        private void cargarEventos()
        {
            dtEventos = eventorecupera.ListarEventoRecuperaPorCuenta(Convert.ToInt32(dtgCreditos.Rows[idCreditoSeleccionado].Cells["idCuenta"].Value));
            dtgEventos.DataSource = dtEventos;

            formatoGridEventosTodos();
            if (dtgEventos.Rows.Count > 0)
            {
                habiliatarBotones(true);

                List<String> lstActividad = new List<string>();
                List<String> lstAccion = new List<string>();
                lstActividad.Add("TODOS");
                lstAccion.Add("TODOS");
                DateTime dtFechaMin = clsVarGlobal.dFecSystem;
                foreach (DataRow row in dtEventos.Rows)
                {
                    if (!lstActividad.Exists(x => x == row["cEvento"].ToString()))
                    {
                        lstActividad.Add(row["cEvento"].ToString());
                    }

                    if (dtFechaMin > Convert.ToDateTime(row["dFecha"]))
                    {
                        dtFechaMin = Convert.ToDateTime(row["dFecha"]);
                    }
                }
                cboActividad.DataSource = lstActividad;
                //cboAccion.DataSource = lstAccion;
                dtpFechaInicio.Value = dtFechaMin;
                dtpFechaFin.Value = clsVarGlobal.dFecSystem;
            }
            else
            {
                habiliatarBotones(true);
                btnImprimir1.Enabled = false;
            }
        }

        private void dtgCreditos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idCreditoSeleccionado = e.RowIndex;
                cargarEventos();
            }
        }

        private void btnPosIntegral_Click(object sender, EventArgs e)
        {
            if (conBusCli1.idCli == 0)
            {
                MessageBox.Show("Seleccione el cliente para la busqueda.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cDocumentoID = conBusCli1.txtNroDoc.Text;
            string cNombre = conBusCli1.txtNombre.Text;
            int idCli = conBusCli1.idCli;
            new frmPosicionInterv().MostrarReporte(cDocumentoID, cNombre, idCli);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            filtrar();
        }

        private void btnFiltrar1_Click(object sender, EventArgs e)
        {
            filtrar();
        }

        #endregion

        #region Metodos

        private void habiliatarBotones(bool lEstado)
        {
            btnCartas.Enabled = lEstado;
            btnDatCli.Enabled = lEstado;
            btnDirRecupera.Enabled = lEstado;
            btnImprimir1.Enabled = lEstado;
            btnPosCli.Enabled = lEstado;
            btnRegEvento.Enabled = lEstado;
            grbFiltros.Enabled = lEstado;
        }

        private void formatoGridCreditos()
        {
            foreach (DataGridViewColumn columna in dtgCreditos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                columna.Visible = false;
            }
            dtgCreditos.Columns["idCuenta"].Visible = true;
            dtgCreditos.Columns["cSimbolo"].Visible = true;
            dtgCreditos.Columns["nCapitalDesembolso"].Visible = true;
            dtgCreditos.Columns["dFechaDesembolso"].Visible = true;
            dtgCreditos.Columns["nSaldoCapital"].Visible = true;
            dtgCreditos.Columns["nAtraso"].Visible = true;
            dtgCreditos.Columns["cAsesor"].Visible = true;
            dtgCreditos.Columns["cEstado"].Visible = true;

            dtgCreditos.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgCreditos.Columns["cSimbolo"].HeaderText = "Moneda";
            dtgCreditos.Columns["nCapitalDesembolso"].HeaderText = "Monto Desembolsado";
            dtgCreditos.Columns["dFechaDesembolso"].HeaderText = "Fecha Desembolso";
            dtgCreditos.Columns["nSaldoCapital"].HeaderText = "Saldo Capital";
            dtgCreditos.Columns["nAtraso"].HeaderText = "Atraso";
            dtgCreditos.Columns["cAsesor"].HeaderText = "Asesor";
            dtgCreditos.Columns["cEstado"].HeaderText = "Estado";
        }

        private void formatoGridEventosTodos()
        {
            foreach (DataGridViewColumn columna in dtgEventos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.Automatic;
                columna.Visible = false;
            }

            dtgEventos.Columns["cEvento"].Visible = true;
            dtgEventos.Columns["dFecha"].Visible = true;
            dtgEventos.Columns["cWinUser"].Visible = true;

            dtgEventos.Columns["cEvento"].HeaderText = "Evento";
            dtgEventos.Columns["dFecha"].HeaderText = "Fec. Reg.";
            dtgEventos.Columns["cWinUser"].HeaderText = "Acción";

            dtgEventos.Columns["cEvento"].Width = 80;
            dtgEventos.Columns["dFecha"].Width = 65;
            dtgEventos.Columns["cWinUser"].Width = 200;
        }

        private void formatoGridEventosInfPase()
        {
            foreach (DataGridViewColumn columna in dtgEventos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.Automatic;
                columna.Visible = false;
            }

            dtgEventos.Columns["cEvento"].Visible = true;
            dtgEventos.Columns["dFecha"].Visible = true;
            dtgEventos.Columns["cWinUser"].Visible = true;
            dtgEventos.Columns["lAsignacionAutomatica"].Visible = true;
            dtgEventos.Columns["cMotivo"].Visible = true;
            dtgEventos.Columns["cOpinion"].Visible = true;
            dtgEventos.Columns["cObservacion"].Visible = true;

            dtgEventos.Columns["cEvento"].HeaderText = "Evento";
            dtgEventos.Columns["dFecha"].HeaderText = "Fec. Reg.";
            dtgEventos.Columns["cWinUser"].HeaderText = "Usuario";
            dtgEventos.Columns["lAsignacionAutomatica"].HeaderText = "Asig. Auto.";
            dtgEventos.Columns["cMotivo"].HeaderText = "Motivo";
            dtgEventos.Columns["cOpinion"].HeaderText = "Opinión";
            dtgEventos.Columns["cObservacion"].HeaderText = "Observación";

            dtgEventos.Columns["cEvento"].Width = 80;
            dtgEventos.Columns["dFecha"].Width = 65;
            dtgEventos.Columns["cWinUser"].Width = 80;
            dtgEventos.Columns["lAsignacionAutomatica"].Width = 50;
            dtgEventos.Columns["cMotivo"].Width = 100;
            dtgEventos.Columns["cOpinion"].Width = 100;
            dtgEventos.Columns["cObservacion"].Width = 100;
        }

        private void formatoGridEventosCondonacion()
        {
            foreach (DataGridViewColumn columna in dtgEventos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.Automatic;
                columna.Visible = false;
            }

            dtgEventos.Columns["cEvento"].Visible = true;
            dtgEventos.Columns["dFecha"].Visible = true;
            dtgEventos.Columns["cWinUser"].Visible = true;
            dtgEventos.Columns["nMonto"].Visible = true;
            dtgEventos.Columns["cMotivo"].Visible = true;
            dtgEventos.Columns["cSustento"].Visible = true;
            dtgEventos.Columns["cNombreCondonacion"].Visible = true;

            dtgEventos.Columns["cEvento"].HeaderText = "Evento";
            dtgEventos.Columns["dFecha"].HeaderText = "Fec. Reg.";
            dtgEventos.Columns["cWinUser"].HeaderText = "Usuario";
            dtgEventos.Columns["nMonto"].HeaderText = "Monto";
            dtgEventos.Columns["cMotivo"].HeaderText = "Motivo";
            dtgEventos.Columns["cSustento"].HeaderText = "Sustento";
            dtgEventos.Columns["cNombreCondonacion"].HeaderText = "Observación";

            dtgEventos.Columns["cEvento"].Width = 80;
            dtgEventos.Columns["dFecha"].Width = 65;
            dtgEventos.Columns["cWinUser"].Width = 80;
            dtgEventos.Columns["nMonto"].Width = 70;
            dtgEventos.Columns["cMotivo"].Width = 100;
            dtgEventos.Columns["cSustento"].Width = 100;
            dtgEventos.Columns["cNombreCondonacion"].Width = 100;
        }

        private void formatoGridEventosGestion()
        {
            foreach (DataGridViewColumn columna in dtgEventos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.Automatic;
                columna.Visible = false;
            }

            dtgEventos.Columns["cEvento"].Visible = true;
            dtgEventos.Columns["dFecha"].Visible = true;
            dtgEventos.Columns["cWinUser"].Visible = true;
            dtgEventos.Columns["cAccion"].Visible = true;
            dtgEventos.Columns["cMotivo"].Visible = true;
            dtgEventos.Columns["cResultado"].Visible = true;
            dtgEventos.Columns["cContacto"].Visible = true;
            dtgEventos.Columns["cObservacion"].Visible = true;

            dtgEventos.Columns["cEvento"].HeaderText = "Evento";
            dtgEventos.Columns["dFecha"].HeaderText = "Fec. Reg.";
            dtgEventos.Columns["cWinUser"].HeaderText = "Usuario";
            dtgEventos.Columns["cAccion"].HeaderText = "Acción";
            dtgEventos.Columns["cMotivo"].HeaderText = "Motivo";
            dtgEventos.Columns["cResultado"].HeaderText = "Resultado";
            dtgEventos.Columns["cContacto"].HeaderText = "Contacto";
            dtgEventos.Columns["cObservacion"].HeaderText = "Observación";

            dtgEventos.Columns["cEvento"].Width = 80;
            dtgEventos.Columns["dFecha"].Width = 65;
            dtgEventos.Columns["cWinUser"].Width = 80;
            dtgEventos.Columns["cAccion"].Width = 50;
            dtgEventos.Columns["cMotivo"].Width = 100;
            dtgEventos.Columns["cResultado"].Width = 100;
            dtgEventos.Columns["cContacto"].Width = 100;
            dtgEventos.Columns["cObservacion"].Width = 100;
        }

        private void formatoGridEventosCamOrdenPre()
        {
            foreach (DataGridViewColumn columna in dtgEventos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.Automatic;
                columna.Visible = false;
            }

            dtgEventos.Columns["cEvento"].Visible = true;
            dtgEventos.Columns["dFecha"].Visible = true;
            dtgEventos.Columns["cWinUser"].Visible = true;
            dtgEventos.Columns["nCapital"].Visible = true;
            dtgEventos.Columns["nInteres"].Visible = true;
            dtgEventos.Columns["nIntComp"].Visible = true;
            dtgEventos.Columns["nMora"].Visible = true;
            dtgEventos.Columns["nMonto"].Visible = true;

            dtgEventos.Columns["cEvento"].HeaderText = "Evento";
            dtgEventos.Columns["dFecha"].HeaderText = "Fec. Reg.";
            dtgEventos.Columns["cWinUser"].HeaderText = "Usuario";
            dtgEventos.Columns["nCapital"].HeaderText = "Capital";
            dtgEventos.Columns["nInteres"].HeaderText = "Interes";
            dtgEventos.Columns["nIntComp"].HeaderText = "Int. Comp.";
            dtgEventos.Columns["nMora"].HeaderText = "Mora";
            dtgEventos.Columns["nMonto"].HeaderText = "Total";

            dtgEventos.Columns["cEvento"].Width = 80;
            dtgEventos.Columns["dFecha"].Width = 65;
            dtgEventos.Columns["cWinUser"].Width = 80;
            dtgEventos.Columns["nCapital"].Width = 70;
            dtgEventos.Columns["nInteres"].Width = 70;
            dtgEventos.Columns["nIntComp"].Width = 70;
            dtgEventos.Columns["nMora"].Width = 70;
            dtgEventos.Columns["nMonto"].Width = 70;
        }

        private void formatoGridEventosCastigo()
        {
            foreach (DataGridViewColumn columna in dtgEventos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.Automatic;
                columna.Visible = false;
            }

            dtgEventos.Columns["cEvento"].Visible = true;
            dtgEventos.Columns["dFecha"].Visible = true;
            dtgEventos.Columns["cWinUser"].Visible = true;
            dtgEventos.Columns["cTramo"].Visible = true;
            dtgEventos.Columns["cRecuperador"].Visible = true;
            dtgEventos.Columns["nCapital"].Visible = true;
            dtgEventos.Columns["nInteres"].Visible = true;
            dtgEventos.Columns["nIntComp"].Visible = true;
            dtgEventos.Columns["nMora"].Visible = true;
            dtgEventos.Columns["nOtros"].Visible = true;

            dtgEventos.Columns["cEvento"].HeaderText = "Evento";
            dtgEventos.Columns["dFecha"].HeaderText = "Fec. Reg.";
            dtgEventos.Columns["cWinUser"].HeaderText = "Usuario";
            dtgEventos.Columns["cTramo"].HeaderText = "Tramo";
            dtgEventos.Columns["cRecuperador"].HeaderText = "Recuperador";
            dtgEventos.Columns["nCapital"].HeaderText = "Capital";
            dtgEventos.Columns["nInteres"].HeaderText = "Interes";
            dtgEventos.Columns["nIntComp"].HeaderText = "Int. Comp.";
            dtgEventos.Columns["nMora"].HeaderText = "Mora";
            dtgEventos.Columns["nOtros"].HeaderText = "Otros";

            dtgEventos.Columns["cEvento"].Width = 80;
            dtgEventos.Columns["dFecha"].Width = 65;
            dtgEventos.Columns["cWinUser"].Width = 80;
            dtgEventos.Columns["cTramo"].Width = 100;
            dtgEventos.Columns["cRecuperador"].Width = 100;
            dtgEventos.Columns["nCapital"].Width = 70;
            dtgEventos.Columns["nInteres"].Width = 70;
            dtgEventos.Columns["nIntComp"].Width = 70;
            dtgEventos.Columns["nMora"].Width = 70;
            dtgEventos.Columns["nOtros"].Width = 70;
        }

        private void formatoGridEventosPaseJudicial()
        {
            foreach (DataGridViewColumn columna in dtgEventos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.Automatic;
                columna.Visible = false;
            }

            dtgEventos.Columns["cEvento"].Visible = true;
            dtgEventos.Columns["dFecha"].Visible = true;
            dtgEventos.Columns["cWinUser"].Visible = true;
            dtgEventos.Columns["cJustificacion"].Visible = true;
            dtgEventos.Columns["nCapital"].Visible = true;
            dtgEventos.Columns["nInteres"].Visible = true;
            dtgEventos.Columns["nIntComp"].Visible = true;
            dtgEventos.Columns["nMora"].Visible = true;
            dtgEventos.Columns["nDiasAtraso"].Visible = true;

            dtgEventos.Columns["cEvento"].HeaderText = "Evento";
            dtgEventos.Columns["dFecha"].HeaderText = "Fec. Reg.";
            dtgEventos.Columns["cWinUser"].HeaderText = "Usuario";
            dtgEventos.Columns["cJustificacion"].HeaderText = "Tramo";
            dtgEventos.Columns["nCapital"].HeaderText = "Capital";
            dtgEventos.Columns["nInteres"].HeaderText = "Interes";
            dtgEventos.Columns["nIntComp"].HeaderText = "Int. Comp.";
            dtgEventos.Columns["nMora"].HeaderText = "Mora";
            dtgEventos.Columns["nDiasAtraso"].HeaderText = "Atraso";

            dtgEventos.Columns["cEvento"].Width = 80;
            dtgEventos.Columns["dFecha"].Width = 65;
            dtgEventos.Columns["cWinUser"].Width = 80;
            dtgEventos.Columns["cJustificacion"].Width = 100;
            dtgEventos.Columns["nCapital"].Width = 70;
            dtgEventos.Columns["nInteres"].Width = 70;
            dtgEventos.Columns["nIntComp"].Width = 70;
            dtgEventos.Columns["nMora"].Width = 70;
            dtgEventos.Columns["nDiasAtraso"].Width = 70;
        }

        private void formatoGridEventosDesembolso()
        {
            foreach (DataGridViewColumn columna in dtgEventos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.Automatic;
                columna.Visible = false;
            }

            dtgEventos.Columns["cEvento"].Visible = true;
            dtgEventos.Columns["dFecha"].Visible = true;
            dtgEventos.Columns["cWinUser"].Visible = true;
            dtgEventos.Columns["nMonto"].Visible = true;
            dtgEventos.Columns["nCuotas"].Visible = true;
            dtgEventos.Columns["dFechaCulminacion"].Visible = true;
            dtgEventos.Columns["nTEA"].Visible = true;

            dtgEventos.Columns["cEvento"].HeaderText = "Evento";
            dtgEventos.Columns["dFecha"].HeaderText = "Fec. Reg.";
            dtgEventos.Columns["cWinUser"].HeaderText = "Usuario";
            dtgEventos.Columns["nMonto"].HeaderText = "Monto";
            dtgEventos.Columns["nCuotas"].HeaderText = "Cuotas";
            dtgEventos.Columns["dFechaCulminacion"].HeaderText = "Culminación";
            dtgEventos.Columns["nTEA"].HeaderText = "TEA (%).";

            dtgEventos.Columns["cEvento"].Width = 80;
            dtgEventos.Columns["dFecha"].Width = 65;
            dtgEventos.Columns["cWinUser"].Width = 80;
            dtgEventos.Columns["nMonto"].Width = 70;
            dtgEventos.Columns["nCuotas"].Width = 50;
            dtgEventos.Columns["dFechaCulminacion"].Width = 65;
            dtgEventos.Columns["nTEA"].Width = 70;
        }

        private void formatoGridEventosProcJudicial()
        {
            foreach (DataGridViewColumn columna in dtgEventos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.Automatic;
                columna.Visible = false;
            }

            dtgEventos.Columns["cEvento"].Visible = true;
            dtgEventos.Columns["dFecha"].Visible = true;
            dtgEventos.Columns["cWinUser"].Visible = true;
            dtgEventos.Columns["cNroExpediente"].Visible = true;

            dtgEventos.Columns["cEvento"].HeaderText = "Evento";
            dtgEventos.Columns["dFecha"].HeaderText = "Fec. Reg.";
            dtgEventos.Columns["cWinUser"].HeaderText = "Usuario";
            dtgEventos.Columns["cNroExpediente"].HeaderText = "Nro. Expediente";

            dtgEventos.Columns["cEvento"].Width = 80;
            dtgEventos.Columns["dFecha"].Width = 65;
            dtgEventos.Columns["cWinUser"].Width = 80;
            dtgEventos.Columns["cNroExpediente"].Width = 100;

        }

        private void formatoGridEventosActoProcesal()
        {
            foreach (DataGridViewColumn columna in dtgEventos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.Automatic;
                columna.Visible = false;
            }

            dtgEventos.Columns["cEvento"].Visible = true;
            dtgEventos.Columns["dFecha"].Visible = true;
            dtgEventos.Columns["cWinUser"].Visible = true;
            dtgEventos.Columns["cNroExpediente"].Visible = true;
            dtgEventos.Columns["cJustificacion"].Visible = true;
            dtgEventos.Columns["cObservacion"].Visible = true;

            dtgEventos.Columns["cEvento"].HeaderText = "Evento";
            dtgEventos.Columns["dFecha"].HeaderText = "Fec. Reg.";
            dtgEventos.Columns["cWinUser"].HeaderText = "Usuario";
            dtgEventos.Columns["cNroExpediente"].HeaderText = "Nro. Expediente";
            dtgEventos.Columns["cJustificacion"].HeaderText = "Tipo Acto Procesal";
            dtgEventos.Columns["cObservacion"].HeaderText = "Observación";

            dtgEventos.Columns["cEvento"].Width = 80;
            dtgEventos.Columns["dFecha"].Width = 65;
            dtgEventos.Columns["cWinUser"].Width = 80;
            dtgEventos.Columns["cNroExpediente"].Width = 100;
            dtgEventos.Columns["cJustificacion"].Width = 100;
            dtgEventos.Columns["cObservacion"].Width = 100;

        }

        private void formatoGridEventosCongelarTasa()
        {
            foreach (DataGridViewColumn columna in dtgEventos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.Automatic;
                columna.Visible = false;
            }

            dtgEventos.Columns["cEvento"].Visible = true;
            dtgEventos.Columns["dFecha"].Visible = true;
            dtgEventos.Columns["cWinUser"].Visible = true;
            dtgEventos.Columns["nTEA"].Visible = true;
            dtgEventos.Columns["nTasaCompensatoria"].Visible = true;
            dtgEventos.Columns["nTasaMora"].Visible = true;
            dtgEventos.Columns["nTCEA"].Visible = true;

            dtgEventos.Columns["cEvento"].HeaderText = "Evento";
            dtgEventos.Columns["dFecha"].HeaderText = "Fec. Reg.";
            dtgEventos.Columns["cWinUser"].HeaderText = "Usuario";
            dtgEventos.Columns["nTEA"].HeaderText = "TEA (%)";
            dtgEventos.Columns["nTasaCompensatoria"].HeaderText = "Tasa Comp (%)";
            dtgEventos.Columns["nTasaMora"].HeaderText = "Tasa Mora (%)";
            dtgEventos.Columns["nTCEA"].HeaderText = "TCEA (%)";

            dtgEventos.Columns["cEvento"].Width = 80;
            dtgEventos.Columns["dFecha"].Width = 65;
            dtgEventos.Columns["cWinUser"].Width = 80;
            dtgEventos.Columns["nTEA"].Width = 80;
            dtgEventos.Columns["nTasaCompensatoria"].Width = 80;
            dtgEventos.Columns["nTasaMora"].Width = 80;
            dtgEventos.Columns["nTCEA"].Width = 80;

        }


        private void filtrar()
        {
            DataTable dtFiltradoActividad = dtEventos.Clone();
            DataTable dtFiltradoFechas = dtEventos.Clone();
            DataTable dtCopiaOrinal = dtEventos.Copy();
            DataRow[] rows = dtCopiaOrinal.Select("cEvento = '" + cboActividad.Text + "' OR 'TODOS' = '" + cboActividad.Text + "'");
            foreach (DataRow row in rows)
            {
                dtFiltradoActividad.ImportRow(row);
            }

            var lisrows = (from item in dtFiltradoActividad.AsEnumerable()
                           where Convert.ToDateTime(item["dFecha"]) >= dtpFechaInicio.Value.Date && Convert.ToDateTime(item["dFecha"]) <= dtpFechaFin.Value.Date
                           select item).ToList();

            foreach (DataRow row in lisrows)
            {
                dtFiltradoFechas.ImportRow(row);
            }
            dtgEventos.DataSource = dtFiltradoFechas;

            switch (cboActividad.Text)
            {
                case "INFORME DE PASE":
                    formatoGridEventosInfPase();
                    break;
                case "CONDONACIÓN":
                    formatoGridEventosCondonacion();
                    break;
                case "GESTIÓN":
                case "EVENTO":
                    formatoGridEventosGestion();
                    break;
                case "CAMBIO DE ORDER DE PRELACIÓN":
                    formatoGridEventosCamOrdenPre();
                    break;
                case "CASTIGO":
                    formatoGridEventosCastigo();
                    break;
                case "PASE A JUDICIAL":
                    formatoGridEventosPaseJudicial();
                    break;
                case "PROC. JUDICIAL":
                    formatoGridEventosProcJudicial();
                    break;
                case "DESEMBOLSO":
                    formatoGridEventosDesembolso();
                    break;
                case "ACTO PROCESAL":
                    formatoGridEventosActoProcesal();
                    break;
                case "CONGELAR TASA":
                    formatoGridEventosCongelarTasa();
                    break;
                default:
                    formatoGridEventosTodos();
                    break;
            }
        }

        public void cargar(int idCliente)
        {
            conBusCli1.txtCodCli.Text = idCliente.ToString();
            conBusCli1.CargardatosCli(idCliente);
            cargar();
        }

        private void cargar()
        {
            if (conBusCli1.idCli > 0)
            {
                dtgEventos.DataSource = null;
                dtgCreditos.DataSource = null;
                habiliatarBotones(false);

                dtCreditos = cnCliente.ListaCreditos(conBusCli1.idCli);
                if (dtCreditos.Rows.Count >= 0)
                {
                    dtgCreditos.DataSource = dtCreditos;
                    formatoGridCreditos();
                    habiliatarBotones(true);
                }

                DataTable dtClienteBasesNegativas = cnCliente.CNBuscarClienteBaseNegativas(conBusCli1.idCli);
                if (dtClienteBasesNegativas.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtClienteBasesNegativas.Rows[0]["idBaseNegativaClientes"]) != 0 || Convert.ToInt32(dtClienteBasesNegativas.Rows[0]["idBaseBaseNegativaSocios"]) != 0 || Convert.ToInt32(dtClienteBasesNegativas.Rows[0]["idBaseNegativa"]) != 0)
                    {
                        lblBaseNegativa.Text = "Alerta: Cliente en base negativa";
                    }
                    else
                    {
                        lblBaseNegativa.Text = "";
                    }
                }

            }
            else
            {
                habiliatarBotones(false);
            }
        }
        #endregion

    }
}
