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
    public partial class frmReImpresionCartaFianza : frmBase
    {
        clsCNCartaFianza cnCartaFianza = new clsCNCartaFianza();
        clsCodigoBarra codigoBarra = new clsCodigoBarra();
        int idCartaFianza = 0;
        int idSolAproba = 0;
        int idSolicitud = 0;
        
        public frmReImpresionCartaFianza()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DataTable dtResultado = cnCartaFianza.reimpresionCartaFianza(idCartaFianza, idSolAproba, clsVarGlobal.PerfilUsu.idUsuario);
            if (dtResultado.Rows.Count > 0 && Convert.ToInt32(dtResultado.Rows[0][0]) != 0)
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
                    dtDatosCartaFianza.Rows[0]["cCodigoBarras"] = codigoBarra.Convert(Convert.ToString(dtDatosCartaFianza.Rows[0]["codCartaFianza"]), 250, 25);
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
                    btnImprimir1.Enabled = false;
                    limpiar();

                }
                else
                {
                    MessageBox.Show("No se encuentra datos de la carta fianza", "Caracteristicas Carta Fianza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Error al aprobar el acta de aprobación de carta fianza: " + dtResultado.Rows[0][0].ToString(), "Impresión acta carta fianza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnListaAprob1_Click(object sender, EventArgs e)
        {
            frmListaCartaFianzaAprob frmListaCartaFianzaAprob = new frmListaCartaFianzaAprob(2);
            frmListaCartaFianzaAprob.ShowDialog();
            limpiar();
            if (frmListaCartaFianzaAprob.idCartaFianzaSeleccionada != 0 && frmListaCartaFianzaAprob.lAceptar)
            {
                idCartaFianza = frmListaCartaFianzaAprob.idCartaFianzaSeleccionada;
                idSolAproba = frmListaCartaFianzaAprob.idSolAproba;
                idSolicitud = frmListaCartaFianzaAprob.idSolicitudCF;
                cargarDatos(idCartaFianza);
                btnImprimir1.Enabled = true;
            }
            else
            {
                btnImprimir1.Enabled = false;
            }
        }

        private void limpiar()
        {
            txtCodCartaFianza.Clear();
            txtDocumento.Clear();
            txtFechaInicioAprobado.Clear();
            txtMontoAprobado.Clear();
            txtNombreCliente.Clear();
            txtPlazoAprobado.Clear();

        }

        public void cargarDatos(int idCartaFianza)
        {
            DataTable dtCartaFianza = cnCartaFianza.obtenerCartaFianza(idCartaFianza);
            if (dtCartaFianza.Rows.Count > 0)
            {
                txtCodCartaFianza.Text = Convert.ToInt32(dtCartaFianza.Rows[0]["idAgencia"]).ToString("00") + " - " + idCartaFianza.ToString("000000");
                txtDocumento.Text = dtCartaFianza.Rows[0]["cNomCorto"] + " " + dtCartaFianza.Rows[0]["cDocumentoID"];
                txtNombreCliente.Text = dtCartaFianza.Rows[0]["cNombre"].ToString();
                txtMontoAprobado.Text = dtCartaFianza.Rows[0]["cSimbolo"] + " " + dtCartaFianza.Rows[0]["nMonto"];
                txtPlazoAprobado.Text = dtCartaFianza.Rows[0]["nPlazo"] + " día(s)";
                txtFechaInicioAprobado.Text = dtCartaFianza.Rows[0]["dFechaVigencia"].ToString();
            }

        }
    }
}
