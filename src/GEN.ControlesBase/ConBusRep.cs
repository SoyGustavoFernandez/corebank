using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;

namespace GEN.ControlesBase
{
    public partial class ConBusRep : UserControl
    {
        clsCNBusReports CNBusReports = new clsCNBusReports();
        List<clsReporte> lisRep = new List<clsReporte>();

        public ConBusRep()
        {
            InitializeComponent();
        }

        private void ConBusRep_Load(object sender, EventArgs e)
        {
            lisRep= CNBusReports.LisReports("CLI");
            dtgReports.DataSource = lisRep;
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            BusRepByName();
        }

        private void BusRepByName()
        {
            dtgReports.DataSource= CNBusReports.LisRepByName(txtReporte.Text);
        }

        private void txtReporte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BusRepByName();
            }
        }

        private void btnConsultar1_Click(object sender, EventArgs e)
        {
            List<ReportParameter> paramlist = new List<ReportParameter>();
            //paramlist.Add(new ReportParameter("nIDEmpresa", VariableGlobal.nIDEmpresa.ToString(), false));
            string reportpath = (string)dtgReports.CurrentRow.Cells["R_Ruta"].Value;
            new frmReporte(paramlist, reportpath).ShowDialog();
        }
    }
}
