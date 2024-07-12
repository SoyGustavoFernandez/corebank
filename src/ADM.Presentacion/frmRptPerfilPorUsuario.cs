using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using EntityLayer;
using GEN.CapaNegocio;

namespace ADM.Presentacion
{
    public partial class frmRptPerfilPorUsuario : frmBase
    {
        #region Variables

        clsCNPerfilUsu perfilusu = new clsCNPerfilUsu();

        #endregion

        public frmRptPerfilPorUsuario()
        {
            InitializeComponent();
        }

        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            dtpIni.Value = new DateTime(clsVarGlobal.dFecSystem.Year, 1, 1);
            dtpFin.Value = clsVarGlobal.dFecSystem;
        }        

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (!(conBusCol1.txtCod.Text == ""))
            {
                int idUsuario = Convert.ToInt32(conBusCol1.idUsu);
                DateTime dFecIni = dtpIni.Value.Date;
                DateTime dFecFin = dtpFin.Value.Date;
                int nVigente = 0;

                if (rbtnVigentes.Checked)
                {
                    nVigente = 1;                    
                }
                else if (rbtnTodos.Checked)
                {
                    nVigente = 2; 
                }

                DataTable dtPerfilUsu = perfilusu.ReportePerfilesPorUsuario(idUsuario, dFecIni, dFecFin, nVigente);

                if (dtPerfilUsu.Rows.Count > 0)
                {
                    List<ReportDataSource> dtsList = new List<ReportDataSource>();
                    dtsList.Add(new ReportDataSource("dsPerfilUsuario", dtPerfilUsu));

                    List<ReportParameter> paramList = new List<ReportParameter>();
                    paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                    paramList.Add(new ReportParameter("idUsuario", idUsuario.ToString(), false));
                    paramList.Add(new ReportParameter("dFecLimIni", dFecIni.ToString("dd/MM/yyyy"), false));
                    paramList.Add(new ReportParameter("dFecLimFin", dFecFin.ToString("dd/MM/yyyy"), false));
                    paramList.Add(new ReportParameter("nVigente", nVigente.ToString(), false));
                    paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                    paramList.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));    

                    string reportPath = "rptPerfilesPorUsuario.rdlc";
                    new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
                }
                else
                {
                    MessageBox.Show("No existen datos", "Reporte de Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debe de seleccionar un usuario", "Reporte de Perfiles", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion
    }
}
