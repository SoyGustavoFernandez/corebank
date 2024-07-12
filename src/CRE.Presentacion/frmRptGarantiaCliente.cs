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
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmRptGarantiaCliente : frmBase
    {
        #region Variable Globales

        clsCNGarantia cngarantia = new clsCNGarantia();

        #endregion

        public frmRptGarantiaCliente()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            cboEstadosGarantia1.cargarTodos();
            cboEstadosGarantia1.SelectedIndex = -1;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                DataTable dtGarantias = cngarantia.CNrptGarantiasCliente(conBusCli1.idCli, (int)this.cboEstadosGarantia1.SelectedValue);

                if (dtGarantias.Rows.Count > 0)
                {
                    List<ReportParameter> paramList = new List<ReportParameter>();
                    List<ReportDataSource> dtsList = new List<ReportDataSource>();

                    dtsList.Add(new ReportDataSource("dsGarantiasCliente", dtGarantias));

                    paramList.Add(new ReportParameter("idCli", conBusCli1.idCli.ToString(), false));
                    paramList.Add(new ReportParameter("idEstado", this.cboEstadosGarantia1.SelectedValue.ToString(), false));
                    paramList.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
                    paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                    paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                    string reportPath = "rptGarantiasCliente.rdlc";
                    new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
                }
                else
                {
                    MessageBox.Show("No existe datos para los parámetros seleccionados", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        #endregion

        #region Métodos

        private bool validar()
        {
            bool lValida = false;

            if (conBusCli1.idCli == 0)
            {
                MessageBox.Show("Por favor seleccione un cliente", "Validación cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusCli1.btnBusCliente.Focus();
                return lValida;
            }

            if (cboEstadosGarantia1.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor seleccione estado de la garantía", "Validación garantía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboEstadosGarantia1.Focus();
                return lValida;
            }

            lValida = true;
            return lValida;
        }


        #endregion

        
    }
}
