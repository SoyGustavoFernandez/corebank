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
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmIndGeoColocaciones : frmBase
    {
        public frmIndGeoColocaciones()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {

            string cDpto = cboDpto.SelectedValue.ToString();
            string cProv = cboProv.SelectedValue.ToString();
            DateTime dFecSis = dtpFecha.Value.Date;

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_CodDpto", cDpto, false));
            paramlist.Add(new ReportParameter("x_CodPro", cProv, false));
            paramlist.Add(new ReportParameter("x_dFecha", dFecSis.ToString("dd/MM/yyyy"), false));

            string reportpath = "/RPT/RptIndicadoresMapa";
            new frmReporte(paramlist, reportpath).ShowDialog();
        }

        private void frmIndGeoColocaciones_Load(object sender, EventArgs e)
        {
            DataTable dtDpto = new clsRPTCNAgencia().CNDepartamento();
            this.cboDpto.DataSource = dtDpto;
            this.cboDpto.ValueMember = dtDpto.Columns["cCodDpto"].ToString();
            this.cboDpto.DisplayMember = dtDpto.Columns["cNomDpto"].ToString();

            DataTable dtProv = new clsRPTCNAgencia().CNProvincia(this.cboDpto.SelectedValue.ToString());
            this.cboProv.DataSource = dtProv;
            this.cboProv.ValueMember = dtProv.Columns["cCodPro"].ToString();
            this.cboProv.DisplayMember = dtProv.Columns["cNomPro"].ToString();
            this.dtpFecha.Value = clsVarGlobal.dFecSystem;
        }

        private void cboDpto_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtProv = new clsRPTCNAgencia().CNProvincia(this.cboDpto.SelectedValue.ToString());
            this.cboProv.DataSource = dtProv;
            this.cboProv.ValueMember = dtProv.Columns["cCodPro"].ToString();
            this.cboProv.DisplayMember = dtProv.Columns["cNomPro"].ToString();
        }
    }
}
