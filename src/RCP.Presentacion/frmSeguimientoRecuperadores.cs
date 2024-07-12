using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RCP.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCP.Presentacion
{
    public partial class frmSeguimientoRecuperadores : frmBase
    {
        clsCNReportes cnReportes = new clsCNReportes();

        public frmSeguimientoRecuperadores()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (dtpInicio.Value > dtpFin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha final", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dtCreditos;
            string cTitulo = "";
            switch (cboFiltro.SelectedIndex)
            { 
                case 0:
                    dtCreditos = cnReportes.SeguimientoRecuperadoresTodos(Convert.ToDateTime(dtpInicio.Value), Convert.ToDateTime(dtpFin.Value));
                    cTitulo = "SEGUIMIENTO GENERADO POR RECUPERACIONES";
                    break;
                case 1:
                    dtCreditos = cnReportes.SeguimientoRecuperadoresHojaRuta(Convert.ToDateTime(dtpInicio.Value), Convert.ToDateTime(dtpFin.Value));
                    cTitulo = "SEGUIMIENTO GENERADO POR RECUPERACIONES - HOJA DE RUTA";                    
                    break;
                case 2:
                    dtCreditos = cnReportes.SeguimientoRecuperadoresConCli(Convert.ToDateTime(dtpInicio.Value), Convert.ToDateTime(dtpFin.Value));
                    cTitulo = "SEGUIMIENTO GENERADO POR RECUPERACIONES - CONTACTO AL CLIENTE";                    
                    break;
                default:
                    dtCreditos = cnReportes.SeguimientoRecuperadoresTodos(Convert.ToDateTime(dtpInicio.Value), Convert.ToDateTime(dtpFin.Value));
                    cTitulo = "SEGUIMIENTO GENERADO POR RECUPERACIONES";
                    break;
            }

            List<ReportDataSource> dtsList = new List<ReportDataSource>();
            dtsList.Add(new ReportDataSource("dsCreditos", dtCreditos));

            List<ReportParameter> paramList = new List<ReportParameter>();
            paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramList.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramList.Add(new ReportParameter("cTitulo", cTitulo, false));
            paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

            string reportPath = "rptSegRecHojRutaContCli.rdlc";
            new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();         
        }

        private void frmSeguimientoRecuperadores_Load(object sender, EventArgs e)
        {
            cboFiltro.SelectedIndex = 0;
            dtpInicio.Value = dtpFin.Value = clsVarGlobal.dFecSystem;
        }
    }
}
