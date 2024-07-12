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
using EntityLayer;
using CAJ.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace CAJ.Presentacion
{
    public partial class frmRptRegVentasSocios : frmBase
    {
        /****************************************
        Tipos de Reportes:
        1 --> Reporte por tipo de Destino
        2 --> Reporte por Proveedor
        3 --> Reporte opr tipo comprobante
        *****************************************/
        private int idRep = 3;
        private int idTipoCpg = 0;

        public frmRptRegVentasSocios()
        {
            InitializeComponent();
            FiltrarTipoCpg();
            dtpFecInicial.Value = clsVarGlobal.dFecSystem;
            dtpFecFinal.Value = clsVarGlobal.dFecSystem;           
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string dFecIni = this.dtpFecInicial.Value.ToShortDateString();
            string dFecFin = this.dtpFecFinal.Value.ToShortDateString();  
            
            if (cboTipoComprobantePago.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un tipo de comprobante.", "Reporte de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboAgencia.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una agencia.", "Reporte de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtpFecFinal.Value < dtpFecInicial.Value)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor a la fecha final.", "Reporte de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idTipoCpg = Convert.ToInt32(cboTipoComprobantePago.SelectedValue);
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue.ToString());

            int idEstadoCpg = Convert.ToInt32(cboEstadoComprobante1.SelectedValue);
            int idSiNoSocio = Convert.ToInt32(cboTipoCliente.SelectedValue);

            if (new clsCNCajaChica().CNRptRegVentasSocio(dtpFecInicial.Value, dtpFecFinal.Value, idAgencia, idRep, idTipoCpg, idEstadoCpg, idSiNoSocio).Rows.Count <= 0)
            {
                MessageBox.Show("No existen datos para mostrar.", "Reporte de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;
            String cNomAgen = clsVarGlobal.cNomAge;
            String cRutLogo = clsVarApl.dicVarGen["CRUTALOGO"];



            paramlist.Add(new ReportParameter("dFecIni", dFecIni, false));
            paramlist.Add(new ReportParameter("dFecFin", dFecFin, false));
            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("idTipRep", idRep.ToString(), false));
            paramlist.Add(new ReportParameter("idFiltro", idTipoCpg.ToString(), false));
            paramlist.Add(new ReportParameter("idEstadoCpg", idEstadoCpg.ToString(), false));
            paramlist.Add(new ReportParameter("lSiNoSocio", idSiNoSocio.ToString(), false));

            paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen.ToString(), false));
            paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString(), false));
            paramlist.Add(new ReportParameter("x_cRutLogo", cRutLogo.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Add(new ReportDataSource("dtRptRegVentasSocio", new clsCNCajaChica().CNRptRegVentasSocio(dtpFecInicial.Value, dtpFecFinal.Value, idAgencia, idRep, idTipoCpg, idEstadoCpg, idSiNoSocio)));

            string reportpath = "RptRegVentasSocio.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            this.btnImprimir.Enabled = true;
        }

        private void FiltrarTipoCpg()
        {
            DataView dv = new DataView((DataTable)cboTipoComprobantePago.DataSource);
            dv.RowFilter = "lPermRegVenta = 1";
            DataTable dt = dv.ToTable();
            DataRow dr = dt.NewRow();
            dr["idTipComPag"] = 0;
            dr["cDescripcion"] = "*** TODOS ***";
            dt.Rows.InsertAt(dr, 0);
            cboTipoComprobantePago.DataSource = dt;            
        }

        private void frmRptRegVentasSocios_Load(object sender, EventArgs e)
        {
            cboEstadoComprobante1.CargaEstado();
            ComboTipoCliente();
        }
        private void ComboTipoCliente()
        {
            DataTable dtTipCliente = new DataTable();
            dtTipCliente.Columns.Add("idTipClienteSocio", typeof(Int32));
            dtTipCliente.Columns.Add("cDescripcionClienteSocio", typeof(String));

            for (int i = 0; i < 3; i++)
            {
                 DataRow row = dtTipCliente.NewRow();
                 row["idTipClienteSocio"] = i;
                 if (i == 0)
                 {
                     row["cDescripcionClienteSocio"] = "*** TODOS ***";
                 }
                 else if (i == 1)
                 {
                     row["cDescripcionClienteSocio"] = "ES SOCIO";
                 }
                 else
                 {
                     row["cDescripcionClienteSocio"] = "NO SOCIO";   
                 }
                 dtTipCliente.Rows.Add(row);            
            }
           
            cboTipoCliente.DataSource = dtTipCliente;
            cboTipoCliente.ValueMember = dtTipCliente.Columns[0].ToString();
            cboTipoCliente.DisplayMember = dtTipCliente.Columns[1].ToString();

        
        }
    }
}
