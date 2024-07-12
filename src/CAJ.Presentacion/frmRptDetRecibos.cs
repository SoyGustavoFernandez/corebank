using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmRptDetRecibos : frmBase
    {
        public frmRptDetRecibos()
        {
            InitializeComponent();
            cboAgencias.AgenciasYTodos();
            cboMoneda.MonedasYTodos();
        }

        private void frmRptDetRecibos_Load(object sender, EventArgs e)
        {
            if (this.cboAgencias.SelectedIndex >= 0)
            {
                this.cboAgencias.SelectedValue = 1;
                this.cboAgencias.Select();
                this.cboAgencias_SelectedIndexChanged(sender, e);
            }
            
            //======================================================
            //--Cargar Datos
            //======================================================
            CargarTiporecibos();
            if (this.cboTipRec.SelectedIndex<0)
            {
                CargarConceptos(0);
            }
            else
            {
                CargarConceptos(Convert.ToInt32(cboTipRec.SelectedValue.ToString().Trim()));
            }
            dtpFecIni.Value = clsVarGlobal.dFecSystem.Date;
            dtpFecFin.Value = clsVarGlobal.dFecSystem.Date;
            //CargarSubItemCon(0);
        }

        private void CargarTiporecibos()
        {
            clsCNControlOpe LisTiprec = new clsCNControlOpe();
            DataTable tbTipRec = LisTiprec.ListarTipRec();
            DataRow dr = tbTipRec.NewRow();
            dr["idTipRecibo"] = "0";
            dr["cDescripcion"] = "***TODOS***";
            tbTipRec.Rows.InsertAt(dr, 0);
            cboTipRec.DataSource = tbTipRec;
            cboTipRec.ValueMember = tbTipRec.Columns["idTipRecibo"].ToString();
            cboTipRec.DisplayMember = tbTipRec.Columns["cDescripcion"].ToString();
            cboTipRec.SelectedValue = 1;
        }

        private void CargarConceptos(int nTipRec)
        {
            clsCNControlOpe LisConcep = new clsCNControlOpe();
            DataTable tbConcep = LisConcep.ListaConceptos(nTipRec,"");
            if (tbConcep.Rows.Count>0)
            {
                DataRow dr = tbConcep.NewRow();
                dr["idConcepto"] = "0";
                dr["cConcepto"] = "***TODOS***";
                dr["cTipMonto"] = "V";
                dr["nAfectoITF"] = 0;
                dr["nMontoCon"] = 0.00;
                tbConcep.Rows.InsertAt(dr, 0);
            }
            
            cboConcepto.DataSource = tbConcep;
            cboConcepto.ValueMember = tbConcep.Columns["idConcepto"].ToString();
            cboConcepto.DisplayMember = tbConcep.Columns["cConcepto"].ToString();
        }


        private void ListarColAgencia(int idAge)
        {
            clsCNControlOpe LisColAge = new clsCNControlOpe();
            DataTable tbColAge = LisColAge.ListarColabAgencias(idAge);            
            DataRow dr = tbColAge.NewRow();
            dr["idUsuario"] = "0";
            dr["cNombre"] = "***TODOS***";
            tbColAge.Rows.InsertAt(dr,0);
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

        private void cboAgencias_SelectedIndexChanged(object sender, EventArgs e)
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
                MessageBox.Show("Debe Seleccionar una Agencia", "Reporte de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgencias.Focus();
                this.cboAgencias.Select();
                return "ERROR";
            }
            if (this.cboColaborador.SelectedIndex < 0)
            {
                MessageBox.Show("Debe Seleccionar el Colaborador", "Reporte de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboColaborador.Focus();
                this.cboColaborador.Select();
                return "ERROR";
            }
            if (string.IsNullOrEmpty(this.cboColaborador.SelectedValue.ToString().Trim()))
            {
                MessageBox.Show("Debe Seleccionar el Colaborador", "Reporte de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboColaborador.Focus();
                this.cboColaborador.Select();
                return "ERROR";
            }
            if (this.cboTipRec.SelectedIndex < 0)
            {
                MessageBox.Show("Debe Seleccionar el Tipo de Recibo", "Reporte de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboTipRec.Focus();
                this.cboTipRec.Select();
                return "ERROR";
            }
            if (this.cboMoneda.SelectedIndex < 0)
            {
                MessageBox.Show("Debe Seleccionar la Moneda", "Reporte de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboMoneda.Focus();
                this.cboMoneda.Select();
                return "ERROR";
            }
            if (this.cboConcepto.SelectedIndex < 0)
            {
                MessageBox.Show("Debe Seleccionar el Concepto", "Reporte de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboConcepto.Focus();
                this.cboConcepto.Select();
                return "ERROR";
            }
            
            if (this.dtpFecIni.Value > this.dtpFecFin.Value)
            {
                MessageBox.Show("La Fecha Final no Puede ser Menor que la Fecha Inicial", "Reporte de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpFecIni.Focus();
                return "ERROR";
            }
            return "OK";
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (ValidarDatos()=="ERROR")
            {
                return;
            }
            List<ReportParameter> paramlist = new List<ReportParameter>();
            DateTime dFecIni = this.dtpFecIni.Value.Date;
            DateTime dFecFin = this.dtpFecFin.Value.Date;
            string idUsu = this.cboColaborador.SelectedValue.ToString();
            string idAge = this.cboAgencias.SelectedValue.ToString();
            string idMon = this.cboMoneda.SelectedValue.ToString();
            string idConcep = this.cboConcepto.SelectedValue.ToString();
            string dFechaSis = clsVarGlobal.dFecSystem.Date.ToString();
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];

            if (new clsRPTCNCaja().CNConRecibos(idAge, idUsu, dFecIni, dFecFin, idMon, idConcep).Rows.Count <= 0)
            {
                MessageBox.Show("No se encontraton registros con los \n parametros especificados para el reporte.", "Reporte de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            paramlist.Clear();
            paramlist.Add(new ReportParameter("idAge", idAge, false));
            paramlist.Add(new ReportParameter("idUsu", idUsu, false));
            paramlist.Add(new ReportParameter("dFecIni", dFecIni.Date.ToString(), false));
            paramlist.Add(new ReportParameter("dFecFin", dFecFin.Date.ToString(), false));
            paramlist.Add(new ReportParameter("idMon", idMon, false));
            paramlist.Add(new ReportParameter("idConcep", idConcep, false));
            paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis, false));
            paramlist.Add(new ReportParameter("cNombreVariable", cRutaLogo, false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Add(new ReportDataSource("dsConRecibos", new clsRPTCNCaja().CNConRecibos(idAge, idUsu, dFecIni, dFecFin, idMon, idConcep)));

            string reportpath = "RptConRecibos.rdlc";
            new frmReporteLocal(dtslist, reportpath,paramlist).ShowDialog();
            this.btnImprimir.Enabled = true;
        }

        private void cboTipRec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipRec.SelectedValue.ToString() == "1")
            {
                CargarConceptos(1);
            }
            else
            {
                CargarConceptos(2);
            }
        }


    }
}
