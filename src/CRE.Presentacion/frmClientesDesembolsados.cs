using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using EntityLayer;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmClientesDesembolsados : frmBase
    {
        Boolean lEstado = true;
        int idCargo = clsVarGlobal.User.idCargo;
        int idAgencia = clsVarGlobal.nIdAgencia;

        public frmClientesDesembolsados()
        {
            InitializeComponent();
            cboTipoCliente.SelectedValue = 1;
            dtpFecIni.Value = clsVarGlobal.dFecSystem;
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Validar();
            if (!lEstado)
            {
                return;
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            idAgencia = (int)cboAgencia1.SelectedValue;
            if (idAgencia==0)
            {
                MessageBox.Show("Seleccione una oficina","Detalle Desembolsos",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            int idTipCli = (int)cboTipoCliente.SelectedValue;
            DateTime dFecIni = dtpFecIni.Value;
            DateTime dFecFin = dtpFecFin.Value;
            dtslist.Add(new ReportDataSource("dsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsLisDesembolso", new clsRPTCNCredito().CNDesembolso(idAgencia,idTipCli,dFecIni,dFecFin)));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            string cTipoCliente = "";
                if ( idTipCli == 1)
                {
                    cTipoCliente = "NUEVOS";
                }else if ( idTipCli == 2)
                {
                    cTipoCliente = "REPRESTAMO";
                }else
                {
                    cTipoCliente = "NUEVOS Y REPRESTAMO";
                }

            paramlist.Clear();
            paramlist.Add(new ReportParameter("dFecIni", dtpFecIni.Value.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFecFin", dtpFecFin.Value.ToString("dd/MM/yyyy"), false));
			paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cTipoCliente", cTipoCliente, false));

            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("IdTipoCliente", idTipCli.ToString(), false));

            paramlist.Add(new ReportParameter("cNombreVariable", "CRUTALOGO", false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));

            string reportpath = "rptClientesDesembolsados.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
        void Validar()
        {
            if (dtpFecIni.Value>dtpFecFin.Value)
            {
                MessageBox.Show("La Fecha Final debe ser mayor o igual a la Fecha inicial", "Detalle Desembolsos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lEstado = false;
            }
            else
            {
                lEstado = true;
            }
        
        }

        private void btnBlanco1_Click(object sender, EventArgs e)
        {
            Validar();
            if (!lEstado)
            {
                return;
            }
            idAgencia = (int)cboAgencia1.SelectedValue;
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            int idTipCli = (int)cboTipoCliente.SelectedValue;
            DateTime dFecIni = dtpFecIni.Value;
            DateTime dFecFin = dtpFecFin.Value;
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsDesembolso", new clsRPTCNCredito().CNTotalDesembolso(dFecIni, dFecFin, idAgencia)));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("dFecIni", dFecIni.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFecFin", dFecFin.ToString("dd/MM/yyyy"), false));
			paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
			

            string reportpath = "rptDesembolso.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void btnImpResumen_Click(object sender, EventArgs e)
        {
            Validar();
            if (!lEstado)
            {
                return;
            }
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            int idTipCli = (int)cboTipoCliente.SelectedValue;
            DateTime dFecIni = dtpFecIni.Value;
            DateTime dFecFin = dtpFecFin.Value;
            idAgencia = (int)cboAgencia1.SelectedValue;

            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            string reportpath = "";
            if (idAgencia==0)
            {
                reportpath = "rptDesembolsoResumen.rdlc";
                dtslist.Add(new ReportDataSource("dtsDesembolso", new clsRPTCNCredito().CNConsolidadoDesembolso(dFecIni, dFecFin)));
            }
            else
            {
                reportpath = "rptDesembolsoResumenAge.rdlc";
                dtslist.Add(new ReportDataSource("dtsDesembolso", new clsRPTCNCredito().CNConsolidadoDesembolso(dFecIni, dFecFin, idAgencia)));
                dtslist.Add(new ReportDataSource("dtsAgencia", new clsRPTCNAgencia().CNDatoAgencia(idAgencia)));
            }

            paramlist.Add(new ReportParameter("dFecIni", dFecIni.ToString(), false));
            paramlist.Add(new ReportParameter("dFecFin", dFecFin.ToString(), false));
			paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void frmClientesDesembolsados_Load(object sender, EventArgs e)
        {
            //if (idCargo == 1 || idCargo == 2 || idCargo == 3)
            //{
            //    cboAgencia1.SelectedValue = idAgencia;
            //    cboAgencia1.Enabled = false;
            //}
            //else
            //{
            //    cboAgencia1.Enabled = true;
            //    cboAgencia1.SelectedValue = 0;
            //}
        } 
    }
}
