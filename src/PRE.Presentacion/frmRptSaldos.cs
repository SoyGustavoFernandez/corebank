using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using PRE.CapaNegocio;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRE.Presentacion
{
    public partial class frmRptSaldos : frmBase
    {
        #region Variables Globales
        private DataTable dtPartidas;
        private clsCNPartidasPres cnpartidaspres = new clsCNPartidasPres();
        private Boolean lEsPlanificacion = false;
        private String cTituloMensaje = "Reporte saldo mensual";        
        #endregion

        public frmRptSaldos()
        {
            InitializeComponent();
        }
        #region Eventos
        private void frmRptSaldoMensual_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            if (this.cboPeriodoPresupuestal1.Items.Count <= 0)
            {               
                habilitarControles(false);
                return;
            }            
            int idPeriodoSelect = Convert.ToInt32(this.cboPeriodoPresupuestal1.SelectedValue);
            this.cboEstructuraPresupuesto1.soloEstructuras();
            formatoYdatosTipoReporte();
            listarPartidas(idPeriodoSelect, this.cboEstructuraPresupuesto1.SelectedValue.ToString());            
            verificarEstadoPeriodo();
            habilitarControles(true);
            //limpiarSeleccionGrilla();
        }       
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (!validarDatosAImprimir())
            {
                return;
            }
            int idPeriodo = Convert.ToInt32(this.cboPeriodoPresupuestal1.SelectedValue);
            String cEstructura = this.cboEstructuraPresupuesto1.SelectedValue.ToString();
            String cPeriodo = Convert.ToString(((DataRowView)this.cboPeriodoPresupuestal1.SelectedItem)["cPeriodos"]);
            int idMesDesde = Convert.ToInt32(this.cboMesDesde.SelectedValue);
            int idMesHasta = Convert.ToInt32(this.cboMesHasta.SelectedValue);
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("idPeriodo", this.cboPeriodoPresupuestal1.SelectedValue.ToString(), false));
            paramlist.Add(new ReportParameter("cAnioPres", Convert.ToString(((DataRowView)this.cboPeriodoPresupuestal1.SelectedItem)["cPeriodos"]), false));
            
            paramlist.Add(new ReportParameter("idMesFin", this.cboMesHasta.SelectedValue.ToString(), false));
            paramlist.Add(new ReportParameter("cEstructura", cEstructura, false));

            clsRPTCNPresupuestos rptcnpresupuestos = new clsRPTCNPresupuestos();
            
            if (Convert.ToInt32(this.cboTipoReporte.SelectedValue) == 1) //saldo mensual
            {
                paramlist.Add(new ReportParameter("idMesInicio", this.cboMesDesde.SelectedValue.ToString(), false));
                DataTable dtDatos = rptcnpresupuestos.listarSaldosMensuales(idPeriodo, cEstructura, idMesDesde, idMesHasta);
                if (dtDatos.Rows.Count == 0)
                {
                    MessageBox.Show("No existen datos para esos filtros", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Add(new ReportDataSource("dsSaldosMensuales", dtDatos));
                string reportpath = "rptSaldoMensualPresupuesto.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else if (Convert.ToInt32(this.cboTipoReporte.SelectedValue) == 2) //saldo acumulado
            {
                DataTable dtDatos = rptcnpresupuestos.listarSaldosAcumulado(idPeriodo, cEstructura, idMesHasta);
                if (dtDatos.Rows.Count == 0)
                {
                    MessageBox.Show("No existen datos para esos filtros", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Add(new ReportDataSource("dsSaldosMensuales", dtDatos));
                string reportpath = "rptSaldoAcumuladoPresupuesto.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }            
        }
        private void cboPeriodoPresupuestal1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idPeriodoSelect = Convert.ToInt32(this.cboPeriodoPresupuestal1.SelectedValue);            
            listarPartidas(idPeriodoSelect, this.cboEstructuraPresupuesto1.SelectedValue.ToString());            
            verificarEstadoPeriodo();
            habilitarControles(true);                      
        }
        private void cboEstructuraPresupuesto1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listarPartidas(Convert.ToInt32(this.cboPeriodoPresupuestal1.SelectedValue), this.cboEstructuraPresupuesto1.SelectedValue.ToString());           
            verificarEstadoPeriodo();
            habilitarControles(true);
        }
       
        #endregion

        #region Métodos
        private void listarPartidas(int idPeriodoPlanific, String cEstructura)
        {
            dtPartidas = cnpartidaspres.ListarPartidasXEstructura(idPeriodoPlanific, cEstructura);
            //this.dtgPartidasPres.DataSource = dtPartidas;
            //if (this.dtgPartidasPres.RowCount <= 0)
            //{
            //    habilitarControles(false);
            //}
            //formatoDTGPartidas();
        }       

        private void verificarEstadoPeriodo()
        {
            int idEstadoPeriodo = Convert.ToInt32(this.cboPeriodoPresupuestal1.devolverValor(this.cboPeriodoPresupuestal1.SelectedIndex, "idEstado"));
            this.lblPlanificacion.Text = this.cboPeriodoPresupuestal1.devolverValor(this.cboPeriodoPresupuestal1.SelectedIndex, "cEstado");
            if (idEstadoPeriodo == 1)   // 1 = planificacion
            {
                this.lblPlanificacion.ForeColor = Color.DarkGreen;
                lEsPlanificacion = true;
            }
            else if (idEstadoPeriodo == 2)
            {
                this.lblPlanificacion.ForeColor = Color.RoyalBlue;
                lEsPlanificacion = false;
            }
            else
            {
                this.lblPlanificacion.ForeColor = Color.Gray;
                lEsPlanificacion = false;
            }
        }
        private void habilitarControles(Boolean Val)
        {
            if (lEsPlanificacion)
            {
                this.btnImprimir1.Enabled = false;
            }
            else
            {
                this.btnImprimir1.Enabled = Val;
            }
        }                        
        private Boolean validarDatosAImprimir()
        {            
            if ((int)this.cboMesDesde.SelectedValue > (int)this.cboMesHasta.SelectedValue)
            {
                MessageBox.Show("El mes de inicio no puede ser mayor que el mes final", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;    
        }
        private void formatoYdatosTipoReporte()
        {
            this.cboTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            DataTable dtTipoReporte = new DataTable();
            dtTipoReporte.Columns.Add("idTipoReporte", typeof(int));
            dtTipoReporte.Columns.Add("cTipoRepote", typeof(String));
            DataRow drEstructura = dtTipoReporte.NewRow();
            drEstructura["idTipoReporte"] = 1;
            drEstructura["cTipoRepote"] = "Saldos mensuales";
            dtTipoReporte.Rows.Add(drEstructura);
            DataRow drEstructura2 = dtTipoReporte.NewRow();
            drEstructura2["idTipoReporte"] = 2;
            drEstructura2["cTipoRepote"] = "Saldo acumulado";
            dtTipoReporte.Rows.Add(drEstructura2);           
            
            this.cboTipoReporte.DisplayMember = "cTipoRepote";
            this.cboTipoReporte.ValueMember = "idTipoReporte";
            this.cboTipoReporte.DataSource = dtTipoReporte;
            
        }
        #endregion                          

        private void cboTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cboTipoReporte.SelectedValue) == 2)
            {
                this.cboMesDesde.SelectedValue = 1;
                this.cboMesDesde.Enabled = false;
            }
            else
            {
                this.cboMesDesde.Enabled = true;
            }
        }
       
    }
}
