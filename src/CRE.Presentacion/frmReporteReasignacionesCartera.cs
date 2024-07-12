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
//using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmReporteReasignacionesCartera : frmBase
    {
        public frmReporteReasignacionesCartera()
        {
            InitializeComponent();
            cboAgencias.AgenciasYTodos();
            dtpFecProcIni.Value = clsVarGlobal.dFecSystem;
            dtpFecProcFin.Value = clsVarGlobal.dFecSystem;
        }

        private void ListarColAgencia(int idAge)
        {
            clsCNControlOpe LisColAge = new clsCNControlOpe();
            
            DataTable tbColAge = LisColAge.ListarAsesoresAgencias(idAge);
            DataRow dr = tbColAge.NewRow();
            dr["idUsuario"] = "0";
            dr["cNombre"] = "***SELECCIONE***";
            tbColAge.Rows.InsertAt(dr, 0);
            this.cboColaborador.DataSource = tbColAge;
            this.cboColaborador.ValueMember = tbColAge.Columns["idUsuario"].ToString();
            this.cboColaborador.DisplayMember = tbColAge.Columns["cNombre"].ToString();
            if (tbColAge.Rows.Count > 0)
            {
                this.cboColaborador.Enabled = true;
            }
            else
            {
                this.cboColaborador.Enabled = false;
            }
        }

        private void cboAgencias_SelectIndexChanged(object sender, EventArgs e)
        {
            int nItem;
            nItem = Convert.ToInt32(this.cboAgencias.SelectedValue.ToString());
            ListarColAgencia(nItem);
        }

        private string ValidarDatos()
        {
            //==================================================================
            //--Validar Datos del Reporte
            //==================================================================
            if (string.IsNullOrEmpty(this.cboAgencias.SelectedValue.ToString().Trim()))
            {
                MessageBox.Show("Debe Seleccionar una Agencia", "Reporte de Reasignación de Cartera", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgencias.Focus();
                this.cboAgencias.Select();
                return "ERROR";
            }
            if (this.cboColaborador.SelectedIndex < 1)
            {
                MessageBox.Show("Debe Seleccionar el Colaborador", "Reporte de Reasignación de Cartera", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboColaborador.Focus();
                this.cboColaborador.Select();
                return "ERROR";
            }
            if (string.IsNullOrEmpty(this.cboColaborador.SelectedValue.ToString().Trim()))
            {
                MessageBox.Show("Debe Seleccionar el Colaborador", "Reporte de Reasignación de Cartera", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboColaborador.Focus();
                this.cboColaborador.Select();
                return "ERROR";
            }
            if (this.dtpFecProcIni.Value > this.dtpFecProcFin.Value)
            {
                MessageBox.Show("La Fecha Final no Puede ser Menor que la Fecha Inicial", "Reporte de Reasignación de Cartera", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpFecProcIni.Focus();
                return "ERROR";
            }
            return "OK";
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (ValidarDatos() == "ERROR")
            {
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            
            DateTime dFecIni = this.dtpFecProcIni.Value.Date;
            DateTime dFecFin = this.dtpFecProcFin.Value.Date;
            
            string idUsu = this.cboColaborador.SelectedValue.ToString();
            string idAge = this.cboAgencias.SelectedValue.ToString();

            DataTable Datos = new clsRPTCNCredito().CNGenReasignacionesCarteraCred(idAge, idUsu, dFecIni, dFecFin);
            
            if (Datos.Rows.Count <= 0)
            {
                MessageBox.Show("No se encontraton registros con los \n parametros especificados para el reporte.", "Reporte de Reasignaciones de Cartera", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            paramlist.Clear();
            
            paramlist.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("UserID",clsVarGlobal.User.idUsuario.ToString(),false));
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            
            dtslist.Add(new ReportDataSource("dsListaReasignacionesCartera", Datos));
            string reportpath = "rptReasignacionesCartera.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            this.btnImprimir.Enabled = true;
        }
    }
}

