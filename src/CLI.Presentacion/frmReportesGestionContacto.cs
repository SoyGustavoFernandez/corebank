using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using EntityLayer;
using RPT.CapaNegocio;
using CLI.Servicio;
using CLI.CapaNegocio;

namespace CLI.Presentacion
{
    //public partial class frmReportesGestionContacto : Form
    public partial class frmReportesGestionContacto : frmBase
    {
        DateTime dFechaDesde, dFechaHasta;
        clsCNCliente clsCliente = new clsCNCliente();
        DateTime dFechaHoy = DateTime.Now;
        public int idAgenciaGlobal = 0;
        public frmReportesGestionContacto()
        {
            InitializeComponent();
            datePicker1.Value = clsVarGlobal.dFecSystem;

            ActualizarEstablecimientos(cboAgencia1.SelectedIndex);
            cboEstablecimiento1.SelectedValue = 0;
            cboEstablecimiento1.Enabled = false;
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cboAgencia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencia1.SelectedIndex == 0)
            {
                ActualizarEstablecimientos(cboAgencia1.SelectedIndex);
                cboEstablecimiento1.SelectedValue = 0;
                cboEstablecimiento1.Enabled = false;
            }
            else 
            {
                int idAgencia = idAgenciaGlobal = Convert.ToInt32(this.cboAgencia1.SelectedValue);
                ActualizarEstablecimientos(idAgencia);
                cboAgencia1.SelectedValue = idAgencia;
                cboEstablecimiento1.SelectedValue = 0;
                cboEstablecimiento1.Enabled = true;
            }
        }
        private void ActualizarEstablecimientos(int idAgencia)
        {
            DataTable dtResultado = new DataTable("dtAgencia");
            dtResultado.Columns.Add("idAgencia", typeof(int));

            DataRow dr = dtResultado.NewRow();
            dr["idAgencia"] = idAgencia;
            dtResultado.Rows.Add(dr);

            DataTable dtRes = dtResultado;
            DataSet dsRes = new DataSet("dsAgencia");

            dsRes.Tables.Add(dtRes);
            string cXmlAgencias = dsRes.GetXml();

            DataTable dt = clsCliente.ListarEStablecimientoPorListaAgencia(cXmlAgencias);
            DataRow row = dt.NewRow();
            row["idEstablecimiento"] = 0;
            row["cNombreEstab"] = "**TODOS**";
            dt.Rows.Add(row);
            dt.DefaultView.Sort = "idEstablecimiento ASC";
            cboEstablecimiento1.DataSource = dt;
            cboEstablecimiento1.ValueMember = dt.Columns[0].ToString();
            cboEstablecimiento1.DisplayMember = dt.Columns[1].ToString();
            cboEstablecimiento1.ValueMember = dt.Columns["idEstablecimiento"].ToString();
            cboEstablecimiento1.DisplayMember = dt.Columns["cNombreEstab"].ToString();
            cboEstablecimiento1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            dFechaDesde = Convert.ToDateTime(this.datePicker1.Value);
            dFechaHasta = Convert.ToDateTime(this.datePicker2.Value);

            if (dFechaHasta <= dFechaHoy && dFechaDesde <= dFechaHoy)
            {
                if (dFechaDesde <= dFechaHasta)
                {
                    List<ReportDataSource> dtslist = new List<ReportDataSource>();
                    dtslist.Clear();
                    dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
                    dtslist.Add(new ReportDataSource("dsCambioDatosContactoCli", new clsRPTCNClientes().CNRptCambioDatosContactoCli(Convert.ToInt32(cboAgencia1.SelectedValue), Convert.ToInt32(cboEstablecimiento1.SelectedValue), dFechaDesde, dFechaHasta)));
                    List<ReportParameter> paramlist = new List<ReportParameter>();

                    paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                    paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                    paramlist.Add(new ReportParameter("idAgencia", cboAgencia1.SelectedIndex.ToString(), false));
                    paramlist.Add(new ReportParameter("idEstablecimiento", cboEstablecimiento1.SelectedIndex.ToString(), false));
                    paramlist.Add(new ReportParameter("dFechaDesde", dFechaDesde.ToString(), false));
                    paramlist.Add(new ReportParameter("dFechaHasta", dFechaHasta.ToString(), false));
                    paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

                    string reportpath = "rptCambioDatosContactoCli.rdlc";
                    new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                }
                else
                {
                    MessageBox.Show("La fecha Desde debe de ser menor o igual que la fecha Hasta.", "Gestión de contacto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.datePicker1.Focus();
                }
            }
            else
            {
                MessageBox.Show("Las fechas no pueden ser mayor a la de hoy.", "Gestión de contacto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.datePicker1.Focus();
            }

        }

        private void datePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dateTimePicker = (DateTimePicker)sender;
            DateTime dfechaActual = dateTimePicker.Value;
            datePicker2.MinDate = DateTimePicker.MinimumDateTime;
            datePicker2.MaxDate = DateTimePicker.MaximumDateTime;
            datePicker2.Value = dfechaActual;
            datePicker2.MinDate = dfechaActual.AddMonths(0);
            datePicker2.MaxDate = dfechaActual.AddMonths(1);
        }
    }
}
