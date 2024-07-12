using CRE.CapaNegocio;
using EntityLayer;
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
    public partial class frmImprimirOpiRecuperaciones : frmBase
    {
        clsCNSolicitudAmortiza cnsolicitudamortiza = new clsCNSolicitudAmortiza();

        public frmImprimirOpiRecuperaciones()
        {
            InitializeComponent();
            conBusCuentaCli1.cTipoBusqueda = "S";
            conBusCuentaCli1.cEstado = "[1,2,13]";
        }

        private void frmImprimirOpiRecuperaciones_Load(object sender, EventArgs e)
        {
            limpiar();
        }

        private void cargar()
        {
            btnImprimir1.Enabled = false;
            btnCancelar1.Enabled = false;
            if (conBusCuentaCli1.txtNroBusqueda.Text.Trim().Length > 0)
            {
                int idSolicitud = Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text);
                if (idSolicitud != 0)
                {
                    DataTable dtSolicitud = cnsolicitudamortiza.ObtenerDetSoliRefinancia(idSolicitud);
                    if (dtSolicitud.Rows.Count > 0)
                    {
                        txtMonto.Text = dtSolicitud.Rows[0]["nCapitalSolicitado"].ToString();
                        cboMoneda.SelectedValue = Convert.ToInt32(dtSolicitud.Rows[0]["IdMoneda"]);
                        txtOperacion.Text = dtSolicitud.Rows[0]["cOperacion"].ToString();
                        btnImprimir1.Enabled = (Convert.ToInt32(dtSolicitud.Rows[0]["idEstado"]) == 3);
                        btnCancelar1.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("La solicitud no tiene opinión de recuperaciones.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                    }
                }
                else
                {
                    limpiar();
                }
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            int idSolicitud = Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text);
            if (idSolicitud != 0)
            {
                string reportpath = "rptOpinionRefinanciacion.rdlc";

                List<ReportDataSource> lisData = new List<ReportDataSource>();
                List<ReportParameter> lisParametros = new List<ReportParameter>();

                lisParametros.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                lisParametros.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                lisParametros.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                //lisParametros.Add(new ReportParameter("idSolicitud", idSolicitud.ToString(), false));

                lisData.Add(new ReportDataSource("dsOpinion", cnsolicitudamortiza.CNrptOpinionRefinanciacion(idSolicitud)));
                new frmReporteLocal(lisData, reportpath, lisParametros).ShowDialog();
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            btnCancelar1.Enabled = false;
            btnImprimir1.Enabled = false;
            conBusCuentaCli1.Enabled = true;
            conBusCuentaCli1.txtNroBusqueda.Enabled = true;
            limpiar();

        }

        private void limpiar()
        {
            conBusCuentaCli1.limpiarControles();
            conBusCuentaCli1.txtNroBusqueda.Focus();
            conBusCuentaCli1.Enabled = true;

            txtOperacion.Clear();
            cboMoneda.SelectedIndex = -1;
            txtMonto.Clear();

        }

        private void conBusCuentaCli1_MyClic_1(object sender, EventArgs e)
        {
            cargar();
        }

        private void conBusCuentaCli1_MyKey(object sender, KeyPressEventArgs e)
        {
            cargar();
        }
    }
}
