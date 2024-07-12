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
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace DEP.Presentacion
{
    public partial class frmRptSaldosxRangosAhorros : frmBase
    {
        #region Variables Globales

        private const string cTituloMsjes = "Reporte de plazos fijos por rangos";

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            cboPlazos.CargarPLazos(2);
            cboEstadoCtaDeposito.EstadoCtaYTodos();
            DataTable dtPlazo = (DataTable)cboPlazos.DataSource;
            DataRow dr = dtPlazo.NewRow();
            dr[0] = "0";
            dr[1] = "TODOS";
            dtPlazo.Rows.InsertAt(dr,0);
            cboMoneda.MonedasYTodos();
            cboMoneda.SelectedIndex = -1;
            cboAgencia.SelectedIndex = -1;
            cboEstadoCtaDeposito.SelectedIndex = -1;
            cboPlazos.SelectedIndex = -1;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            int idAgencia = Convert.ToInt16(cboAgencia.SelectedValue);
            int idMoneda = Convert.ToInt16(cboMoneda.SelectedValue);
            int idEstado = Convert.ToInt16(cboEstadoCtaDeposito.SelectedValue);
            int idPlazo = Convert.ToInt32(cboPlazos.SelectedValue);
            string cAgencia = cboAgencia.Text;
            DateTime dFecSis = clsVarGlobal.dFecSystem;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            DataTable dtData = new clsRPTCNDeposito().CNRptCuentasPlazosFijosxRangos(idAgencia, idMoneda, idEstado, idPlazo);

            if (dtData.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_cAgencia", cAgencia, false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", dFecSis.ToString("dd/MM/yyyy"), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsData", dtData));
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));

                string reportpath = "RptCtasPlazosFijosRangos.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existen Datos para el Reporte", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        #endregion

        #region Metodos

        //Colocar los metodos declarados en el formulario

        public frmRptSaldosxRangosAhorros()
        {
            InitializeComponent();
        }


        private bool Validar()
        {
            if (cboMoneda.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la moneda.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboAgencia.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la agencia.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboEstadoCtaDeposito.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el estado.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboPlazos.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el plazo.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion

        

    }
}
