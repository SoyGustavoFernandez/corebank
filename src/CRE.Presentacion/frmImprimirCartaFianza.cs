using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmImprimirCartaFianza : frmBase
    {
        enum Modo { Imprimir, Bloqueado };
        clsCNCartaFianza cnCartaFianza = new clsCNCartaFianza();
        clsCodigoBarra codigoBarra = new clsCodigoBarra();
        int modoFormulario;
        int idSolicitud = 0;
        public frmImprimirCartaFianza()
        {
            InitializeComponent();
        }

        private void frmImprimirCartaFianza_Load(object sender, EventArgs e)
        {
            this.conBusCuentaCli1.cTipoBusqueda = "S";
            this.conBusCuentaCli1.cEstado = "[2]";
            this.conBusCuentaCli1.MyClic += conBusCuentaCli1_MyClic;
            this.conBusCuentaCli1.MyKey += conBusCuentaCli1_MyClic;
            controles((int)Modo.Bloqueado);
        }

        private void conBusCuentaCli1_MyClic(object sender, EventArgs e)
        {
            cargarDatos();
        }

        public void limpiarControles()
        {
            txtCartaFianza.Text = "";
            txtMontoAprobado.Text = "";
            txtPlazoAprobado.Text = "";
            cboMoneda1.SelectedIndex = -1;
            txtFechaInicioAprobado.Text = "";
            txtPlazoAprobado.Text = "";
            txtTasaAprobada.Text = "";
        }

        private bool estaEnDatos(string cadena, int valor)
        {
            string[] valores = cadena.Split(',');
            foreach (string item in valores)
            {
                if (Convert.ToInt32(item) == valor)
                {
                    return true;
                }
            }
            return false;
        }

        public void cargarDatos()
        {
            limpiarControles();

            idSolicitud = Convert.ToInt32(this.conBusCuentaCli1.nValBusqueda);

            if (idSolicitud != 0)
            {

                DataTable dtResultado = cnCartaFianza.obtenerCaracteristicasCartaFianza(idSolicitud);
                if (dtResultado.Rows.Count > 0)
                {
                    if (!estaEnDatos(Convert.ToString(clsVarApl.dicVarGen["nSubProductoCartaFianza"]), Convert.ToInt32(dtResultado.Rows[0]["idProducto"]))) //carta fianza
                    {
                        MessageBox.Show("La solicitud no corresponde a una carta fianza", "Caracteristicas Carta Fianza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        limpiarControles();
                        controles((int)Modo.Bloqueado);
                        return;
                    }
                    if (Convert.ToInt32(dtResultado.Rows[0]["idEstadoCartaFianza"]) != 5)
                    {
                        MessageBox.Show("La carta fianza no esta lista para ser impresa.", "Caracteristicas Carta Fianza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        limpiarControles();
                        controles((int)Modo.Bloqueado);
                        return;
                    }
                    txtCartaFianza.Text = dtResultado.Rows[0]["codCartaFianza"].ToString();
                    txtMontoAprobado.Text = dtResultado.Rows[0]["nMontoApro"].ToString();
                    txtPlazoAprobado.Text = dtResultado.Rows[0]["nPlazoApro"].ToString();
                    txtFechaInicioAprobado.Text = dtResultado.Rows[0]["dFechaApro"].ToString();
                    cboMoneda1.SelectedValue = dtResultado.Rows[0]["idMonedaApro"];
                    cboMoneda1.SelectedValue = dtResultado.Rows[0]["idMonedaApro"];
                    txtTasaAprobada.Text = dtResultado.Rows[0]["nTasaPropuesta"].ToString();
                    controles((int)Modo.Imprimir);
                }
                else
                {
                    controles((int)Modo.Bloqueado);
                }
            }
            else
            {
                controles((int)Modo.Bloqueado);
            }
        }

        private void btnCargarFile1_Click(object sender, EventArgs e)
        {
            frmBuscarCartasFianza frmBuscarCartasFianza = new frmBuscarCartasFianza();
            frmBuscarCartasFianza.cargarCartasFianza(5);
            frmBuscarCartasFianza.ShowDialog();
            if (frmBuscarCartasFianza.idSolicitud > 0 && frmBuscarCartasFianza.lAceptar)
            {
                this.conBusCuentaCli1.txtNroBusqueda.Text = frmBuscarCartasFianza.idSolicitud.ToString();
                this.conBusCuentaCli1.consultar();
            }
        }

        public void controles(int estado)
        {
            modoFormulario = estado;
            switch (estado)
            {
                case (int)Modo.Bloqueado:
                    this.txtMontoAprobado.Enabled = false;
                    this.txtPlazoAprobado.Enabled = false;
                    this.txtFechaInicioAprobado.Enabled = false;
                    this.cboMoneda1.Enabled = false;
                    this.conBusCuentaCli1.limpiarControles();
                    this.conBusCuentaCli1.txtNroBusqueda.Enabled = true;
                    this.conBusCuentaCli1.btnBusCliente1.Enabled = true;
                    this.conBusCuentaCli1.txtNroBusqueda.Focus();
                    limpiarControles();
                    this.btnImprimir1.Enabled = false;
                    break;
                case (int)Modo.Imprimir:
                    this.txtMontoAprobado.Enabled = false;
                    this.txtPlazoAprobado.Enabled = false;
                    this.txtFechaInicioAprobado.Enabled = false;
                    this.cboMoneda1.Enabled = false;
                    this.btnImprimir1.Enabled = true;
                    break;
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DataTable dtResultadoEmitir = new DataTable();
            dtResultadoEmitir = cnCartaFianza.emitirCartaFianza(idSolicitud,clsVarGlobal.PerfilUsu.idUsuario);
            if (dtResultadoEmitir.Rows.Count > 0 && Convert.ToInt32(dtResultadoEmitir.Rows[0][0]) == 0)
            {
                DataTable dtDatosCartaFianza = new DataTable();
                DataTable dtConsorcio = new DataTable();

                dtDatosCartaFianza = cnCartaFianza.obtenerCartaFianzaImprimir(idSolicitud);
                dtConsorcio = cnCartaFianza.obtenerConsorciados(idSolicitud);
                if (dtDatosCartaFianza.Rows.Count > 0)
                {

                    List<ReportDataSource> dtslist = new List<ReportDataSource>();
                    List<ReportParameter> paramlist = new List<ReportParameter>();
                    paramlist.Clear();
                    dtslist.Clear();

                    GEN.Funciones.clsNumLetras numLetras = new GEN.Funciones.clsNumLetras();

                    Decimal nMonto = Convert.ToDecimal (dtDatosCartaFianza.Rows[0]["monto"].ToString());
                    cboUbigeo ubigeo = new cboUbigeo();
                    paramlist.Add(new ReportParameter("cMontoEnPalabras", numLetras.ToCustomCardinal(nMonto).ToUpper(), false));
                    string cLugarFecha = ", " + clsVarGlobal.dFecSystem.ToString("D", new CultureInfo("es-ES")).ToUpperInvariant();
                    paramlist.Add(new ReportParameter("cLugarFecha", cLugarFecha, false));
                    dtDatosCartaFianza.Columns["cCodigoBarras"].ReadOnly = false;
                    dtDatosCartaFianza.Rows[0]["cCodigoBarras"] = codigoBarra.Convert((Convert.ToString(dtDatosCartaFianza.Rows[0]["codCartaFianza"]) + "______").Substring(0, 14), 250, 25);
                    dtslist.Add(new ReportDataSource("dsDatosCartaFianza", dtDatosCartaFianza));
                    string reportpath = "";

                    if (dtConsorcio.Rows.Count > 0)
                    {
                        dtslist.Add(new ReportDataSource("dsConsorcio", dtConsorcio));
                        reportpath = "rptCartaFianzaConsorcio.rdlc";
                    }
                    else
                    {
                        reportpath = "rptCartaFianzaPNPJ.rdlc";
                    }

                    new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                    controles((int)Modo.Bloqueado);
                }
                else
                {
                    MessageBox.Show("No se encuentra datos de la carta fianza", "Caracteristicas Carta Fianza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Error al emitir carta fianza: " + dtResultadoEmitir.Rows[0][1].ToString() , "Caracteristicas Carta Fianza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

    }
}
