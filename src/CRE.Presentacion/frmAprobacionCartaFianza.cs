using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmAprobacionCartaFianza : frmBase
    {
        clsCNCartaFianza cnCartaFianza = new clsCNCartaFianza();
        clsCNSolicitud cnSolicitud = new clsCNSolicitud();
        int idCartaFianza = 0;
        int idSolAproba = 0;
        int idSolicitud = 0;
        int idEstadoCartaFianza = 0;
        public frmAprobacionCartaFianza()
        {
            InitializeComponent();
        }

        private void btnListaAprob1_Click(object sender, EventArgs e)
        {
            frmListaCartaFianzaAprob frmListaCartaFianzaAprob = new frmListaCartaFianzaAprob(1);
            frmListaCartaFianzaAprob.ShowDialog();

            if (frmListaCartaFianzaAprob.idCartaFianzaSeleccionada != 0 && frmListaCartaFianzaAprob.lAceptar==true)
            {
                idCartaFianza = frmListaCartaFianzaAprob.idCartaFianzaSeleccionada;
                idSolAproba = frmListaCartaFianzaAprob.idSolAproba;
                idSolicitud = frmListaCartaFianzaAprob.idSolicitudCF;
                conBusCuentaCli1.asignarCuenta(idSolicitud);
                cargarDatos(idCartaFianza);
                btnImprimir1.Enabled = true;
            }
            else
            {
                limpiar();
            }
        }

        private void limpiar()
        {
            txtCartaFianza.Text         = "";
            txtSolicitud.Text           = "";
            txtMontoAprobado.Text       = "";
            txtPlazoAprobado.Text       = "";
            txtFechaInicioAprobado.Text = "";
            conBusCuentaCli1.LiberarCuenta();
            conBusCuentaCli1.limpiarControles();
            btnImprimir1.Enabled = false;
        }
        public void cargarDatos(int idCartaFianza)
        {
            DataTable dtCartaFianza = cnCartaFianza.obtenerCartaFianza(idCartaFianza);
            if (dtCartaFianza.Rows.Count > 0)
            {
                idEstadoCartaFianza = Convert.ToInt32(dtCartaFianza.Rows[0]["idEstadoCartaFianza"]);
                txtCartaFianza.Text = dtCartaFianza.Rows[0]["codCartaFianza"].ToString();
                txtSolicitud.Text = dtCartaFianza.Rows[0]["idSolicitud"].ToString();
                txtMontoAprobado.Text = dtCartaFianza.Rows[0]["cSimbolo"] + " " + dtCartaFianza.Rows[0]["nMonto"];
                txtPlazoAprobado.Text = dtCartaFianza.Rows[0]["nPlazo"] + " día(s)";
                txtFechaInicioAprobado.Text = Convert.ToDateTime(dtCartaFianza.Rows[0]["dFechaVigencia"]).ToShortDateString();
            }

        }
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (this.idCartaFianza != 0)
            {
                if (idEstadoCartaFianza == 3)
                {
                    DataTable dtResultado = cnCartaFianza.aprobarCartaFianza(idCartaFianza, idSolicitud, idSolAproba, clsVarGlobal.PerfilUsu.idUsuario);
                    if (dtResultado.Rows.Count > 0 && Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                    {
                        List<ReportDataSource> dtslist = new List<ReportDataSource>();
                        List<ReportParameter> paramlist = new List<ReportParameter>();
                        paramlist.Clear();
                        dtslist.Clear();
                        DataTable dtSolicitud = cnSolicitud.ConsultaSolicitud(idSolicitud);
                        DataTable dtIntervinientes = cnCartaFianza.listarIntervinientes(idSolicitud);
                        DataTable dtDatosREAC = cnCartaFianza.obtenerDatosClienteREAC(idSolicitud, Convert.ToInt32(dtSolicitud.Rows[0]["idCli"]), Convert.ToInt32(dtSolicitud.Rows[0]["idProducto"]));
                        DataTable dtGarantias = cnCartaFianza.listarDetalleGarantias(idSolicitud);
                        DataTable dtAprobadores = cnCartaFianza.listarAprobadores(idSolAproba);
                        DataTable dtComisiones = cnCartaFianza.listarDetalleComisiones(idSolicitud);

                        dtslist.Add(new ReportDataSource("dsIntervinientes", dtIntervinientes));
                        dtslist.Add(new ReportDataSource("dsCartaFianza", dtDatosREAC));
                        dtslist.Add(new ReportDataSource("dsAprobadores", dtAprobadores));
                        dtslist.Add(new ReportDataSource("dsGarantias", dtGarantias));
                        dtslist.Add(new ReportDataSource("dsComisiones", dtComisiones));

                        string reportpath = "rptActaAprobacionCartaFianza.rdlc";
                        new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show(@"Error al aprobar el acta de aprobación de carta fianza: " + dtResultado.Rows[0][0].ToString(),
                            @"Impresión acta carta fianza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    List<ReportDataSource> dtslist = new List<ReportDataSource>();
                    List<ReportParameter> paramlist = new List<ReportParameter>();
                    paramlist.Clear();
                    dtslist.Clear();
                    DataTable dtSolicitud = cnSolicitud.ConsultaSolicitud(idSolicitud);
                    DataTable dtIntervinientes = cnCartaFianza.listarIntervinientes(idSolicitud);
                    DataTable dtDatosREAC = cnCartaFianza.obtenerDatosClienteREAC(idSolicitud, Convert.ToInt32(dtSolicitud.Rows[0]["idCli"]), Convert.ToInt32(dtSolicitud.Rows[0]["idProducto"]));
                    DataTable dtGarantias = cnCartaFianza.listarDetalleGarantias(idSolicitud);
                    DataTable dtAprobadores = cnCartaFianza.listarAprobadores(idSolAproba);
                    DataTable dtComisiones = cnCartaFianza.listarDetalleComisiones(idSolicitud);

                    dtslist.Add(new ReportDataSource("dsIntervinientes", dtIntervinientes));
                    dtslist.Add(new ReportDataSource("dsCartaFianza", dtDatosREAC));
                    dtslist.Add(new ReportDataSource("dsAprobadores", dtAprobadores));
                    dtslist.Add(new ReportDataSource("dsGarantias", dtGarantias));
                    dtslist.Add(new ReportDataSource("dsComisiones", dtComisiones));

                    string reportpath = "rptActaAprobacionCartaFianza.rdlc";
                    new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                }
            }
            else
            {
                MessageBox.Show(@"Debe elegir una carta fianza aprobada",@"Impresión acta carta fianza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmAprobacionCartaFianza_Load(object sender, EventArgs e)
        {
            this.conBusCuentaCli1.cTipoBusqueda = "S";
            this.conBusCuentaCli1.cEstado = "[1,13,2,5]";
            this.conBusCuentaCli1.MyClic += conBusCuentaCli1_MyClic;
            this.conBusCuentaCli1.MyKey += conBusCuentaCli1_MyClic;
            this.conBusCuentaCli1.lblNroBuscar.Text = "Nro Solicitud: ";
            btnImprimir1.Enabled = false;
        }

        private void conBusCuentaCli1_MyClic(object sender, EventArgs e)
        {
            if(conBusCuentaCli1.txtNroBusqueda.Text.Trim().Length > 0)
            {
                idSolicitud = Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text);
                DataTable dtDatosCarta = cnCartaFianza.ObtenerDatosBasicos(idSolicitud);
                if (dtDatosCarta.Rows.Count > 0)
                {
                    idCartaFianza = Convert.ToInt32(dtDatosCarta.Rows[0]["idCartaFianza"]);
                    idSolAproba = Convert.ToInt32(dtDatosCarta.Rows[0]["idSolAproba"]);
                    cargarDatos(idCartaFianza);
                }
                else
                {
                    conBusCuentaCli1.limpiarControles();
                    limpiar();
                    conBusCuentaCli1.txtNroBusqueda.Enabled = true;
                    conBusCuentaCli1.txtNroBusqueda.Focus();
                    conBusCuentaCli1.btnBusCliente1.Enabled = true;
                    MessageBox.Show("No se encontro carta fianza con el número de solicitud ingresado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }
    }
}
