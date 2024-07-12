using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmListadoClientes : frmBase
    {
        public frmListadoClientes()
        {
            InitializeComponent();
            this.cboProducto1.CargarProducto(16);
        }

        private void frmListadoClientes_Load(object sender, EventArgs e)
        {
            this.cboProducto1.SelectedIndex = 1;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dtsDetClientes", new clsRPTCNDeposito().CNClientes(clsVarGlobal.User.idUsuario,(int)this.cboProducto1.SelectedValue)));
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));

            string reportpath = "rptDetalleClientesDEP.rdlc";
            new frmReporteLocal(dtslist, reportpath).ShowDialog();
        }
    }
}
