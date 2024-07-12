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
using GEN.LibreriaOffice;
using GEN.CapaNegocio;
using CAJ.CapaNegocio;
using Microsoft.Reporting.WinForms;
using EntityLayer;
using RPT.CapaNegocio;
using GRH.CapaNegocio;

namespace CLI.Presentacion
{
    public partial class frmRptCliJurRepLeg : frmBase
    {
        public frmRptCliJurRepLeg()
        {
            InitializeComponent();
            ListadoAgencias();
            dtpRegDesde.Value = clsVarGlobal.dFecSystem;
            dtpRegHasta.Value = clsVarGlobal.dFecSystem;
        }

        private void ListadoAgencias()
        {
            clsCNControlOpe ListadoAgencia = new clsCNControlOpe();
            DataTable dt = ListadoAgencia.ListarAgencias();
            DataRow dr = dt.NewRow();
            dr["idAgencia"] = "0";
            dr["cNombreAge"] = "***TODOS***";
            dt.Rows.Add(dr);
            this.cboAgencias.DataSource = dt;
            this.cboAgencias.ValueMember = dt.Columns["idAgencia"].ToString();
            this.cboAgencias.DisplayMember = dt.Columns["cNombreAge"].ToString();
            this.cboAgencias.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void frmRptCliJurRepLeg_Load(object sender, EventArgs e)
        {

        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (cboAgencias.SelectedIndex == -1) 
            {
                MessageBox.Show("Debe seleccionar la Agencia", "Reporte Personas Juridicas Representantes Legales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgencias.Focus();
                return;
            }

            DateTime dFechaDesde = this.dtpRegDesde.Value;
            DateTime dFechaHasta = this.dtpRegHasta.Value;

            if (dFechaDesde > dFechaHasta)
            {
                MessageBox.Show("La Fecha Desde es más reciente que la Fecha Hasta", "Error Selección de Fechas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarGlobal.cNomAge;
            string cUsuWin = clsVarGlobal.User.cWinUser;

            Int32 idAge = Convert.ToInt32(this.cboAgencias.SelectedValue);
            
            clsRPTCNClientes rptClientes = new clsRPTCNClientes();
            DataTable dtPersonasJuridicasRepLeg = rptClientes.CNRetornoPersonaJuridicaRepresentantes(idAge, dFechaDesde, dFechaHasta); 
            if (dtPersonasJuridicasRepLeg.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("cNomEmp", cNomEmp, false));
                paramlist.Add(new ReportParameter("cNombreAge", cNomAgen, false));
                paramlist.Add(new ReportParameter("cUsuWin", cUsuWin, false));
                paramlist.Add(new ReportParameter("cRutaLogo", EntityLayer.clsVarApl.dicVarGen["CRUTALOGO"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();

                dtslist.Add(new ReportDataSource("listaCliJurRepLeg", dtPersonasJuridicasRepLeg));

                string reportpath = "rptPerJurRepreLeg.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Hay Personas Jurídicas en la agencia seleccionada", "No se Encontraron Personas Jurídicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgencias.Focus();
                return;
            }
            
        }
    }
}
