using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEP.Presentacion
{
    public partial class frmReporteExtornosCuenta : frmBase
    {
        #region Atributos
        int idCta = 0;
        #endregion

        #region Metodos
        public frmReporteExtornosCuenta()
        {
            InitializeComponent();
        }        
        #endregion

        #region Eventos
        private void frmReporteExtornosCuenta_Load(object sender, EventArgs e)
        {
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            conBusCtaAho.nTipOpe = 12;
            this.dtFechaHasta.Value = clsVarGlobal.dFecSystem.Date;
            this.dtFechaDesde.Value = clsVarGlobal.dFecSystem.Date;
        }

        private void conBusCtaAho_ClicBusCta(object sender, EventArgs e)
        {
            idCta = 0;
            if (conBusCtaAho.idcuenta != null && conBusCtaAho.idcuenta > 0)
            {
                idCta = conBusCtaAho.idcuenta;                
                conBusCtaAho.HabDeshabilitarCtrl(false);
            }
        }
        
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //VALIDACIONES
            if (this.idCta == 0)
            {
                MessageBox.Show("Seleccione una cuenta de ahorros", "Extracto de Extornos de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToDateTime(this.dtFechaHasta.Value.ToShortDateString()) < Convert.ToDateTime(this.dtFechaDesde.Value.ToShortDateString()))
            {
                MessageBox.Show("Periodo Incorrecto: La fecha de Inicio es posterior a la Final", "Extracto de Extornos de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }            

            int idCta = this.idCta;            
            DateTime dFecInicio = this.dtFechaDesde.Value;
            DateTime dFecFin = this.dtFechaHasta.Value;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            DataTable dtDatosExtorno = new clsRPTCNDeposito().ADDatosExtornosCta(dFecInicio, dFecFin, idCta);

            if (dtDatosExtorno.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Extracto de Extornos de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_dFechaINI", dFecInicio.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_dFechaFIN", dFecFin.ToString("dd/MM/yyyy"), false));                
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString(), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsDatosExtorno", dtDatosExtorno));

                string reportpath = "rptListaExtornosCta.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            idCta = 0;
            dtFechaDesde.Value = clsVarGlobal.dFecSystem.Date;
            dtFechaHasta.Value = clsVarGlobal.dFecSystem.Date;

            conBusCtaAho.LimpiarControles();
            conBusCtaAho.HabDeshabilitarCtrl(true);
        }
        #endregion
    }
}