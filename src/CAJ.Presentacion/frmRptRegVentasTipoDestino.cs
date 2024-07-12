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
    public partial class frmRptRegVentasTipoDestino : frmBase
    {
        /****************************************
        Tipos de Reportes:
        1 --> Reporte por tipo de Destino
        2 --> Reporte por Proveedor
        3 --> Reporte opr tipo comprobante
        *****************************************/
        private int idRep = 1;
        private int idTipoDestino = 0;

        public frmRptRegVentasTipoDestino()
        {
            InitializeComponent();
            CargarCboDestinos();
            dtpFecInicial.Value = clsVarGlobal.dFecSystem;
            dtpFecFinal.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string dFecIni = this.dtpFecInicial.Value.ToShortDateString();
            string dFecFin = this.dtpFecFinal.Value.ToShortDateString();
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue.ToString());

            if (cboDestino.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un destino.", "Reporte de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            idTipoDestino = Convert.ToInt32(cboDestino.SelectedValue);

            int idEstadoCpg =  Convert.ToInt32(cboEstadoComprobante1.SelectedValue);
            if (new clsCNCajaChica().RptRegVentas(dtpFecInicial.Value, dtpFecFinal.Value, idAgencia, idRep, idTipoDestino, idEstadoCpg).Rows.Count <= 0)
            {
                MessageBox.Show("No existen datos para mostrar.", "Reporte de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            List<ReportParameter> paramlist = new List<ReportParameter>();
            DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;
            String cNomAgen = clsVarGlobal.cNomAge;
            String cRutLogo = clsVarApl.dicVarGen["CRUTALOGO"];

            paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen.ToString(), false));
            paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString(), false));
            paramlist.Add(new ReportParameter("x_dFechaINI", dFecIni, false));
            paramlist.Add(new ReportParameter("x_dFechaFIN", dFecFin, false));
            paramlist.Add(new ReportParameter("x_cRutLogo", cRutLogo.ToString(), false));
            paramlist.Add(new ReportParameter("x_nIdAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("x_nidTipRep", idRep.ToString(), false));
            paramlist.Add(new ReportParameter("x_nidFiltro", idTipoDestino.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Add(new ReportDataSource("DsCpg", new clsCNCajaChica().RptRegVentas(dtpFecInicial.Value, dtpFecFinal.Value, idAgencia, idRep, idTipoDestino, idEstadoCpg)));

            string reportpath = "RptRegVentasTipoDest.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            this.btnImprimir.Enabled = true;
        }

        private void CargarCboDestinos()
        {
            clsCNCajaChica rptComprobante = new clsCNCajaChica();
            DataTable Destinos = rptComprobante.ListarDestinoComprPago(0);
            DataRow dr = Destinos.NewRow();
            dr["idDetinoComprPago"] = 0;
            dr["cDescripcion"] = "***TODOS***";
            Destinos.Rows.InsertAt(dr, 0);
            cboDestino.DataSource = Destinos;
            cboDestino.ValueMember = "idDetinoComprPago";
            cboDestino.DisplayMember = "cDescripcion";

        }

        private void frmRptRegVentasTipoDestino_Load(object sender, EventArgs e)
        {
            cboEstadoComprobante1.CargaEstado();
        }
    }
}
