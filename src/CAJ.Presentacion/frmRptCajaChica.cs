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
using CAJ.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmRptCajaChica : frmBase
    {
        int nidResp;
        DataTable dtListadoCajaChica;

        public frmRptCajaChica()
        {
            InitializeComponent();
        }        

        private void cboAgencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCajChica.SelectedIndexChanged -= new EventHandler(cboCajChica_SelectedIndexChanged);
            ListaCajChica(Convert.ToInt32(this.cboAgencias.SelectedValue.ToString()));
            cboCajChica.SelectedIndex = -1;
            cboCajChica.SelectedIndexChanged += new EventHandler(cboCajChica_SelectedIndexChanged);
        }

        private void cboCajChica_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void FormatoGrid()
        {
            this.dtgListaNroCajChicas.Columns["nNroCajChi"].Visible = true;
            this.dtgListaNroCajChicas.Columns["idRecHab"].Visible = true;
            this.dtgListaNroCajChicas.Columns["cNombreAge"].Visible = true;
            this.dtgListaNroCajChicas.Columns["cMoneda"].Visible = true;
            this.dtgListaNroCajChicas.Columns["nMonMaxCaj"].Visible = true;
            this.dtgListaNroCajChicas.Columns["nMonMaxCpg"].Visible = true;
            this.dtgListaNroCajChicas.Columns["nSaldo"].Visible = true;
            this.dtgListaNroCajChicas.Columns["nSaldoAcum"].Visible = true;
            this.dtgListaNroCajChicas.Columns["cEstado"].Visible = true;
            this.dtgListaNroCajChicas.Columns["dFechaIni"].Visible = true;

            this.dtgListaNroCajChicas.Columns["nNroCajChi"].HeaderText = "Nro Caja";
            this.dtgListaNroCajChicas.Columns["idRecHab"].HeaderText = "Nro Rec";
            this.dtgListaNroCajChicas.Columns["cNombreAge"].HeaderText = "Agencia";
            this.dtgListaNroCajChicas.Columns["cMoneda"].HeaderText = "Moneda";
            this.dtgListaNroCajChicas.Columns["nMonMaxCaj"].HeaderText = "Monto Caja";
            this.dtgListaNroCajChicas.Columns["nMonMaxCpg"].HeaderText = "Monto Max CPG";
            this.dtgListaNroCajChicas.Columns["nSaldo"].HeaderText = "Saldo Caja";
            this.dtgListaNroCajChicas.Columns["nSaldoAcum"].HeaderText = "Gasto Caja";
            this.dtgListaNroCajChicas.Columns["cEstado"].HeaderText = "Estado";
            this.dtgListaNroCajChicas.Columns["dFechaIni"].HeaderText = "Fecha Ini.";

            this.dtgListaNroCajChicas.Columns["nNroCajChi"].Width = 50;
            this.dtgListaNroCajChicas.Columns["idRecHab"].Width = 50;
            this.dtgListaNroCajChicas.Columns["cNombreAge"].Width = 120;
            this.dtgListaNroCajChicas.Columns["cMoneda"].Width = 100;
            this.dtgListaNroCajChicas.Columns["nMonMaxCaj"].Width = 80;
            this.dtgListaNroCajChicas.Columns["nMonMaxCpg"].Width = 90;
            this.dtgListaNroCajChicas.Columns["nSaldo"].Width = 80;
            this.dtgListaNroCajChicas.Columns["nSaldoAcum"].Width = 90;
            this.dtgListaNroCajChicas.Columns["cEstado"].Width = 70;
            this.dtgListaNroCajChicas.Columns["dFechaIni"].Width = 80;

            this.dtgListaNroCajChicas.Focus();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string Msje = ValidarDatos().Trim();
            if (!string.IsNullOrEmpty(Msje))
            {
                MessageBox.Show(Msje, "Reporte Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            int idResp = nidResp;
            int idCajChica = Convert.ToInt32(cboCajChica.SelectedValue.ToString());
            int nNroCajChica = Convert.ToInt32(dtgListaNroCajChicas.CurrentRow.Cells["nNroCajChi"].Value);
            DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;
            String cNomAgen = clsVarGlobal.cNomAge;
            String cRutLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            int EstadoCpg = Convert.ToInt32(cboEstadoComprobante1.SelectedValue);

            paramlist.Add(new ReportParameter("idResp", idResp.ToString(), false));
            paramlist.Add(new ReportParameter("idCajChica", idCajChica.ToString(), false));
            paramlist.Add(new ReportParameter("nNroCajChica", nNroCajChica.ToString(), false));
            paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString(), false));
            paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen.ToString(), false));
            paramlist.Add(new ReportParameter("x_RutLogo", cRutLogo.ToString(), false));
            paramlist.Add(new ReportParameter("EstadoCpg", EstadoCpg.ToString(), false));
            
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsDetCajChica", new clsRPTCNCaja().CNDetCajChica(idResp, idCajChica, nNroCajChica, EstadoCpg)));
            dtslist.Add(new ReportDataSource("dsDatosCajaChica", new clsRPTCNCaja().CNDatosCajChica(idCajChica, nNroCajChica)));

            string reportpath = "RptCajaChica.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private string ValidarDatos()
        {
            string Msje = "";
            //==================================================================
            //--Validar Datos del Reporte
            //==================================================================
            if (string.IsNullOrEmpty(cboCajChica.Text))
            {
                Msje += "Debe un nombre de caja chica";
                cboCajChica.Focus();
                cboCajChica.Select();
            }
            if (dtgListaNroCajChicas.RowCount==0)
            {
                Msje += "No se encontraron cajas chicas habilitadas.";
            }
            return Msje;
        }

        private void ListaCajChica(int idAge)
        {
            clsCNCajaChica Lista = new clsCNCajaChica();
            dtListadoCajaChica = Lista.ListadoCajaChica(idAge);

            cboCajChica.DataSource = dtListadoCajaChica;
            cboCajChica.ValueMember = "idCajChica";
            cboCajChica.DisplayMember = "cNomCajChi";
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            if (cboCajChica.SelectedValue != null)
            {
                dtgListaNroCajChicas.DataSource = null;
                clsCNCajaChica Lista = new clsCNCajaChica();
                DataTable tb = Lista.ListarNroCajChica(Convert.ToInt32(cboCajChica.SelectedValue), dtFecInicio.Value, dtFecFinal.Value);
                dtgListaNroCajChicas.DataSource = tb;
                nidResp = Convert.ToInt32(dtListadoCajaChica.Rows[cboCajChica.SelectedIndex]["idResCajChi"].ToString());
                FormatoGrid();
            }
            else
            {
                MessageBox.Show("Debe seleccionar nombre de caja chica", "Reporte caja chica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
