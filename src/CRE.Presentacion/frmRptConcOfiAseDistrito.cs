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
using Microsoft.Reporting.WinForms;
using GEN.CapaNegocio;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmRptConcOfiAseDistrito : frmBase
    {
        #region Variables Globales

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = clsVarGlobal.dFecSystem.AddDays(-1).Date;
            cboAgencias.AgenciasYTodos();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            DateTime dFecha = dtpFecha.Value.Date;
            int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            decimal nIndMoraTotApor = clsVarApl.dicVarGen["nIndMoraTotApor"];

            decimal nTipoCambio = 0;

            DataTable dtTiposCambios = new clsCNGenAdmOpe().RetornaTiposCambio(dFecha);
            nTipoCambio = Convert.ToDecimal(dtTiposCambios.Rows[0]["nTipCamFij"]);

            DataTable dtData = new clsRPTCNCredito().CNrptConcOficinaAsesorDistrito(dFecha,idAgencia);

            if (dtData.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte Conc. C. Oficina, Asesor y Distrito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString()));
            paramlist.Add(new ReportParameter("nTipoCambio", nTipoCambio.ToString(), false));
            paramlist.Add(new ReportParameter("dFecha", dFecha.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("nIndMoraMin", nIndMoraTotApor.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsData", dtData));

            string reportpath = "rptConcOfiAseDistrito.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }

        #endregion

        #region Metodos

        public frmRptConcOfiAseDistrito()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            if (dtpFecha.Value >= clsVarGlobal.dFecSystem.Date)
            {
                MessageBox.Show("Seleccione una fecha válida para procesar el reporte.", "Validación de datos",
                                                                                            MessageBoxButtons.OK,
                                                                                            MessageBoxIcon.Warning);
                return false;
            }
            if (cboAgencias.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la agencia para el reporte.", "Validación de datos",
                                                                            MessageBoxButtons.OK,
                                                                            MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion

    }
}
