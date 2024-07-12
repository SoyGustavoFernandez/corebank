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
using CRE.CapaNegocio;
using GEN.CapaNegocio;
using GEN.Funciones;
using GEN.BotonesBase;
using EntityLayer;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;


namespace CRE.Presentacion
{
    public partial class frmReporteSolicitud : frmBase
    {

        #region Variables Globales
        
        int idPersonalCreditoGlobal=0;
        DateTime dFechaDesde, dFechaHasta;
        int idProductoGlobal=0;
        int idGlobal=0;
        clsRPTCNSolicitud cnrptsolicitud = new clsRPTCNSolicitud();
        DateTime dFechaHoy = clsVarGlobal.dFecSystem;
        string cTituloMsjes = "Reporte de Solicitudes";
        int idAgenciaCbo = 0;
        int idZonaGlobal=0, idAgenciaGlobal=0;
        #endregion 
       
        #region Eventos

        private void frmReporteSolicitud_Load(object sender, EventArgs e)
        {
            this.datePicker1.Value = dFechaHoy;
            this.datePicker2.Value = dFechaHoy;
            this.btnImprimir1.Enabled = false;
            this.checkBox2.Enabled = false;
            idGlobal = 0;
            BorrarDatos();

        }
        
        public frmReporteSolicitud()
        {
                InitializeComponent();
                this.checkBox2.Enabled = false;
        }


        private void btnCancelar1_Click(object sender, EventArgs e)
        {
                BorrarDatos();
        }

        private void cboZona1_SelectedIndexChanged(object sender, EventArgs e)
        {
                int nIdZona = Convert.ToInt32(this.cboZona1.SelectedValue);
                idZonaGlobal = nIdZona;
                this.cboAgencias1.FiltrarPorZonaTodos(nIdZona);
               
                cboAgencias1.SelectedValue = idAgenciaCbo;  
        }

        private void cboAgencias1_SelectedIndexChanged(object sender, EventArgs e)
        { 
                int nIdAgencia = Convert.ToInt32(this.cboAgencias1.SelectedValue);
                idAgenciaGlobal = nIdAgencia;
                this.cboPersonalCreditos1.ListarPersonal(nIdAgencia,true);       
        }

        private void cboPersonalCreditos1_SelectedIndexChanged(object sender, EventArgs e)
        {
                int idPersonalCreditos = Convert.ToInt32(this.cboPersonalCreditos1.SelectedValue);
                idPersonalCreditoGlobal = idPersonalCreditos;
                this.btnImprimir1.Enabled = true;
                idGlobal = 1;
                this.checkBox2.Enabled = true;

                
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (idGlobal == 1)
            {
                Reporte();
            }     
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                this.cboZona1.Enabled = false;
                this.cboAgencias1.Enabled = false;
                this.cboPersonalCreditos1.Enabled = false;
                this.cboPersonalCreditos1.SelectedValue = 0;
                this.btnImprimir1.Enabled = true;
                this.cboZona1.SelectedValue = 0;
                this.cboAgencias1.SelectedValue = 0;
                this.conProducto1.cboSubProducto.SelectedValue = 0;
                this.checkBox1.Enabled = true;
                idGlobal = 1;
                idProductoGlobal = 0;

                this.checkBox2.Enabled = true;
                this.btnImprimir1.Enabled = true;
            }
            else
            {
                this.cboZona1.Enabled = true;
                this.cboAgencias1.Enabled = true;
                this.cboPersonalCreditos1.Enabled = true;
                this.btnImprimir1.Enabled = false;
                this.checkBox1.Enabled = true;
                idGlobal = 0;
                idProductoGlobal = 0;
               
                this.checkBox2.Enabled = false;
     
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                this.conProducto1.Enabled = false;
                this.checkBox2.Enabled = true;
                this.btnImprimir1.Enabled = true;
                this.conProducto1.cboSubProducto.SelectedValue = 0;
                idGlobal = 1;
   
            }
            else
            {
                this.conProducto1.Enabled = true;
                this.checkBox2.Enabled = true;
                this.btnImprimir1.Enabled = true;
                idGlobal = 1;
            }
        }

        #endregion 
      
        #region Metodos


        private void Reporte()
        {
                int nIdAsesor = Convert.ToInt32(idPersonalCreditoGlobal);
                string cIdAsesor = Convert.ToString(nIdAsesor);

                int nIdProducto = Convert.ToInt32(this.conProducto1.cboSubProducto.SelectedValue); //1067;
                idProductoGlobal = nIdProducto;
                dFechaDesde = Convert.ToDateTime(this.datePicker1.Value);
                dFechaHasta = Convert.ToDateTime(this.datePicker2.Value);
                string dhoyy = Convert.ToString(dFechaHoy);
                string cNomAgen = clsVarGlobal.cNomAge.ToString();

             
                    if (dFechaHasta <= dFechaHoy && dFechaDesde<=dFechaHoy)
                    {
                        if (dFechaDesde <= dFechaHasta)
                        {

                            DataTable dtData = cnrptsolicitud.CNRptSolicitud(idZonaGlobal,idAgenciaGlobal,nIdAsesor, nIdProducto, dFechaDesde, dFechaHasta);
                            if (dtData.Rows.Count > 0)
                            {
                                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                                dtsList.Add(new ReportDataSource("dsSolicitud", dtData));

                                List<ReportParameter> paramlist = new List<ReportParameter>();

                                paramlist.Add(new ReportParameter("nIdAsesor", nIdAsesor.ToString(), false));
                                paramlist.Add(new ReportParameter("nIdProducto", nIdProducto.ToString(), false));
                                paramlist.Add(new ReportParameter("dFechaDesde", dFechaDesde.ToString(), false));
                                paramlist.Add(new ReportParameter("dFechaHasta", dFechaHasta.ToString(), false));
                                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                                paramlist.Add(new ReportParameter("dhoyy", dhoyy, false));

                                string reportPath = "rptSolicitud.rdlc";
                                new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No existen datos para este intervalo de fechas.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("La fecha Desde debe de ser menor o igual que la fecha Hasta", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.datePicker1.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Las fechas no puede ser mayor a la de hoy", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.datePicker1.Focus();
                    }
                
                nIdProducto = 0;   
        }

        private void BorrarDatos()
        {
            InitializeComponent();
            cboZona1.SelectedValue = -1;
            cboAgencias1.SelectedValue = -1;
            cboPersonalCreditos1.SelectedValue = -1;
            this.datePicker1.Value = dFechaHoy;
            this.datePicker2.Value = dFechaHoy;
            this.btnImprimir1.Enabled = false;
            idGlobal = 0;
            idProductoGlobal = 0;
            this.checkBox2.Enabled = false;
         }


        #endregion

    }
}



