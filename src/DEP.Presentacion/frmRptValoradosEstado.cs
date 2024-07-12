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
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmRptValoradosEstado : frmBase
    {
        public frmRptValoradosEstado()
        {
            InitializeComponent();
        }
        private void frmRptValorados_Load(object sender, EventArgs e)
        {
            cboAgencias.AgenciasYTodos();
            //cboAgencias.SelectedIndex = -1;
            //DataTable dtTipValo = (DataTable)cboTipoValorado.DataSource;
            ////cboTipoValorado.DataSource = null;

            ////DataRow row = dtTipValo.NewRow();
            ////row["idTipoValorado"] = 0;
            ////row["cValorado"] = "TODOS";
            ////dtTipValo.Rows.Add(row);

            //cboTipoValorado.DataSource = dtTipValo;
            //cboTipoValorado.ValueMember = "idTipoValorado";
            //cboTipoValorado.DisplayMember = "cValorado";
            cboEstValorado1.ListaEstadosOP();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            if (cboAgencias.SelectedIndex == -1 || cboAgencias.Text == "")
            {
                MessageBox.Show("Seleccione la Agencia", "Reporte de valorados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int idAgencia = 0, idTipoValorado=0,idEstadoValorado=0;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
            idTipoValorado = Convert.ToInt32(cboTipoValorado.SelectedValue);
            idEstadoValorado = Convert.ToInt32(cboEstValorado1.SelectedValue);
            DataTable dtRpt = new clsRPTCNDeposito().CNRptListaTalonarioPorEstado(idAgencia, 0, idTipoValorado, idEstadoValorado);

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            //paramlist.Add(new ReportParameter("idAgeDestino", cboAgencias.Text.ToString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", cRutaLogo, false));
            paramlist.Add(new ReportParameter("cNombreAge", cNomAgen, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToShortDateString(), false));

            paramlist.Add(new ReportParameter("idEstaVal", idEstadoValorado.ToString(), false));
            paramlist.Add(new ReportParameter("idAgeDestino", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("idAgeMod", "0", false));
            paramlist.Add(new ReportParameter("idTipoValorado", idTipoValorado.ToString(), false));



            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsListaValoradoTalonario", dtRpt));
              string reportpath = "";
              if (Convert.ToInt32(cboTipoValorado.SelectedValue) == 1)
              {
                  reportpath = "rptValoradoTalonariosOP.rdlc";
              }
              else
              {
                  reportpath = "rptValoradoTalonariosCert.rdlc";
              }

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }


    }
}
