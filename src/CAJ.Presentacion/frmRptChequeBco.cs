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
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using EntityLayer;

namespace CAJ.Presentacion
{
    public partial class frmRptChequeBco : frmBase
    {
        int nIdCuentaInst;

        public frmRptChequeBco()
        {
            InitializeComponent();
        }

        private void frmRptChequeBco_Load(object sender, EventArgs e)
        {
            CargarEstados();
            this.dtpFecIni.Value = clsVarGlobal.dFecSystem.Date;
            this.dtpFecFin.Value = clsVarGlobal.dFecSystem.Date;
            chcSelec.Checked = true;
        }

        private void CargarEstados()
        {
            clsCNCajaChica LisConcep = new clsCNCajaChica();
            DataTable dtEstados = LisConcep.ListarEstCheque();
            this.chklbEstados.DataSource = dtEstados;
            this.chklbEstados.ValueMember = dtEstados.Columns["idEstadoCheque"].ToString();
            this.chklbEstados.DisplayMember = dtEstados.Columns["cDescripcion"].ToString();
        }

        private void chcSelec_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chcSelec.Checked)
            {
                for (int i = 0; i < this.chklbEstados.Items.Count; i++)
                {
                    this.chklbEstados.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < this.chklbEstados.Items.Count; i++)
                {
                    this.chklbEstados.SetItemChecked(i, false);
                }
            }
        }

        private void btnBuscarCuenta_Click(object sender, EventArgs e)
        {
            frmBusquedaCuentaInst frmBuscar = new frmBusquedaCuentaInst();
            frmBuscar.ShowDialog();
            if (frmBuscar.pcNumeroCuenta == null) return;
            nIdCuentaInst = frmBuscar.pidCuentaInstitucion;
            this.cboEntidad.CargarEntidades(frmBuscar.pidTipoEntidad);
            this.cboEntidad.SelectedValue = frmBuscar.pidEntidad;
            this.txtNroCuenta.Text = frmBuscar.pcNumeroCuenta;
            this.cboMoneda.SelectedValue = frmBuscar.pidMoneda;
        }

        private string ValidarDatos()
        {
            string Msje = "";
            //==================================================================
            //--Validar Datos del Reporte
            //==================================================================
            if (string.IsNullOrEmpty(this.txtNroCuenta.Text.Trim()))
            {
                Msje += "Debe Seleccionar una Cuenta.\n";
                this.btnBuscarCuenta.Focus();
                this.btnBuscarCuenta.Select();
            }
            if (this.dtpFecIni.Value.Date > this.dtpFecFin.Value.Date)
            {
                Msje += "La fecha final no puede ser menor a la fecha inicial.\n";
                this.dtpFecIni.Focus();
                this.dtpFecIni.Select();
            }
            if (this.chklbEstados.CheckedItems.Count==0)
            {
                Msje += "Seleccione al menos un Estado.\n";
                this.chklbEstados.Focus();
                this.chklbEstados.Select();
            }
            return Msje;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string Msje = ValidarDatos().Trim();
            if (!string.IsNullOrEmpty(Msje))
            {
                MessageBox.Show(Msje, "Reporte Extracto Bancos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            String idEstado = "";
            foreach (DataRowView item in this.chklbEstados.CheckedItems)
            {
                idEstado += (item.Row["idEstadoCheque"] + ",");
            }
            List<ReportParameter> paramlist = new List<ReportParameter>();

            int idCtaBco = nIdCuentaInst;
            DateTime dFechaIni = this.dtpFecIni.Value.Date;
            DateTime dFechaFin = this.dtpFecFin.Value.Date;


            paramlist.Add(new ReportParameter("idCtaBco", idCtaBco.ToString(), false));
            paramlist.Add(new ReportParameter("idEstado", idEstado, false));
            paramlist.Add(new ReportParameter("dFechaIni", dFechaIni.ToShortDateString(), false));
            paramlist.Add(new ReportParameter("dFechaFin", dFechaFin.ToShortDateString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsDetCheques", new clsRPTCNCaja().CNDetChequeBco(idCtaBco,idEstado,dFechaIni,dFechaFin)));
            dtslist.Add(new ReportDataSource("dsDatosBco", new clsRPTCNCaja().CNDatosBco(idCtaBco)));

            string reportpath = "RptChequeBco.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
    }
}
