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
using GEN.CapaNegocio;
using GEN.Funciones;
using GEN.BotonesBase;
using RPT.CapaNegocio;
using CRE.CapaNegocio;
using ADM.CapaNegocio;
using System.Diagnostics;
using Microsoft.Reporting.WinForms;
using EntityLayer;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmReporteDocumentosCreditosObs : frmBase
    {
        private clsCNAgencia cnagencia = new clsCNAgencia();
        private CRE.CapaNegocio.clsCNAdministracionFiles clsFiles = new CRE.CapaNegocio.clsCNAdministracionFiles();
        DataTable dtAgencia = new DataTable();
        bool lTodosRegion = true;
        bool lTodosOficina = true;
        bool lTodosEstablecimiento = true;
        public frmReporteDocumentosCreditosObs()
        {
            InitializeComponent();
            
        }

        private void frmReporteDocumentosCreditosObs_Load(object sender, EventArgs e)
        {
            cargarRegion();
        }

        public void cargarRegion()
        {
            DataTable dtRegion = clsFiles.ListarZonaVigentes();
            chbRegion.DataSource = dtRegion;
            chbRegion.ValueMember = dtRegion.Columns["idZona"].ToString();
            chbRegion.DisplayMember = dtRegion.Columns["cDesZona"].ToString();
            ObtenerEstado();
            
        }

        private void chbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            lTodosRegion = false;
            chbTodosRegion.Checked = false;            
            chbTodosOficina.Checked = false;
            chbTodosEstablecimiento.Checked = false;
            chbRegion.ClearSelected();
            ActualizarAgencias();
            lTodosRegion = true;
        }               
        
        private void chbOficina_SelectedIndexChanged(object sender, EventArgs e)
        {
            lTodosOficina = false;
            chbTodosOficina.Checked = false;
            chbTodosEstablecimiento.Checked = false;
            chbOficina.ClearSelected();
            ActualizarEstablecimientos();
            lTodosOficina = true;
        }

        private void chbEstablecimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            lTodosEstablecimiento = false;            
            
            chbTodosEstablecimiento.Checked = false;
            chbEstablecimiento.ClearSelected();
            ActualizarEstablecimientos();
            lTodosEstablecimiento = true;
        }

        private void ActualizarAgencias() 
        {
            DataTable dtRes = SelecccionarRegion();
            DataSet dsRes = new DataSet("dsRegion");

            dsRes.Tables.Add(dtRes);
            string cXmlRegion = dsRes.GetXml();

            DataTable dtAgencia = clsFiles.ListarAgenciaPorListaRegion(cXmlRegion);
            chbOficina.DataSource = dtAgencia;
            chbOficina.ValueMember = dtAgencia.Columns["idAgencia"].ToString();
            chbOficina.DisplayMember = dtAgencia.Columns["cNombreAge"].ToString();
        }

        private void ActualizarEstablecimientos()
        {
            DataTable dtRes = SeleccionarAgencias();
            DataSet dsRes = new DataSet("dsAgencia");

            dsRes.Tables.Add(dtRes);
            string cXmlAgencias = dsRes.GetXml();

            DataTable dtEstablecimiento = clsFiles.ListarEStablecimientoPorListaAgencia(cXmlAgencias);
            chbEstablecimiento.DataSource = dtEstablecimiento;
            chbEstablecimiento.ValueMember = dtEstablecimiento.Columns["idEstablecimiento"].ToString();
            chbEstablecimiento.DisplayMember = dtEstablecimiento.Columns["cNombreEstab"].ToString();
        }

        public DataTable SelecccionarRegion()
        {
            DataTable dtResultado = new DataTable("dtRegion");
            dtResultado.Columns.Add("idZona", typeof(int));

            foreach (DataRowView item in chbRegion.CheckedItems)
            {
                DataRow dr = dtResultado.NewRow();
                dr["idZona"] = item["idZona"];
                dtResultado.Rows.Add(dr);
            }

            return dtResultado;
        }

        public DataTable SeleccionarAgencias()
        {
            DataTable dtResultado = new DataTable("dtAgencia");
            dtResultado.Columns.Add("idAgencia", typeof(int));

            foreach (DataRowView item in chbOficina.CheckedItems)
            {
                DataRow dr = dtResultado.NewRow();
                dr["idAgencia"] = item["idAgencia"];
                dtResultado.Rows.Add(dr);
            }

            return dtResultado;
        }

        public DataTable SeleccionarEstablecimientos()
        {
            DataTable dtResultado = new DataTable("dtEstablecimiento");
            dtResultado.Columns.Add("idEstablecimiento", typeof(int));

            foreach (DataRowView item in chbEstablecimiento.CheckedItems)
            {
                DataRow dr = dtResultado.NewRow();
                dr["idEstablecimiento"] = item["idEstablecimiento"];
                dtResultado.Rows.Add(dr);
            }

            return dtResultado;
        }
        private void ObtenerEstado()
        {
            DataTable dtEstado = clsFiles.EstadoCreditoObs();
            cboEstado.DataSource = dtEstado;
            cboEstado.ValueMember = dtEstado.Columns["idEstadoCreditoObs"].ToString();
            cboEstado.DisplayMember = dtEstado.Columns["cEstadoCreditoObs"].ToString();
        }

        private void chcTodosRegion_CheckedChanged(object sender, EventArgs e)
        {
            if (lTodosRegion)
            {
                if (chbTodosRegion.Checked)
                {
                    for (int i = 0; i < chbRegion.Items.Count; i++)
                        chbRegion.SetItemChecked(i, true);
                    ActualizarAgencias();
                    ActualizarEstablecimientos();
                }
                else
                {
                    for (int i = 0; i < chbRegion.Items.Count; i++)
                        chbRegion.SetItemChecked(i, false);
                    ActualizarAgencias();
                    ActualizarEstablecimientos();
                    chbTodosOficina.Checked = false;
                    chbTodosEstablecimiento.Checked = false;
                }
            }
         
        }

        private void chcTodosOficina_CheckedChanged(object sender, EventArgs e)
        {
            if (lTodosOficina)
            {
                bool lrpta = false;
                for (int i = 0; i < chbRegion.Items.Count; i++)
                    if (chbRegion.GetItemCheckState(i) == CheckState.Checked)
                    {
                        lrpta = true;
                    }

                if (lrpta)
                {
                    if (chbTodosOficina.Checked)
                    {
                        for (int i = 0; i < chbOficina.Items.Count; i++)
                            chbOficina.SetItemChecked(i, true);
                        ActualizarEstablecimientos();
                    }
                    else
                    {
                        for (int i = 0; i < chbOficina.Items.Count; i++)
                            chbOficina.SetItemChecked(i, false);
                        ActualizarEstablecimientos();
                        chbTodosEstablecimiento.Checked = false;
                    }
                }
                else
                {
                    chbTodosOficina.Checked = false;
                }
            }

        }

        private void chcTodosEstablecimiento_CheckedChanged(object sender, EventArgs e)
        {
            if (lTodosEstablecimiento)
            {
                bool lrpta = false;
                for (int i = 0; i < chbOficina.Items.Count; i++)
                {
                    if (chbOficina.GetItemCheckState(i) == CheckState.Checked)
                    {
                        lrpta = true;
                    }
                }
                if (lrpta)
                {
                    if (chbTodosEstablecimiento.Checked)
                    {
                        for (int i = 0; i < chbEstablecimiento.Items.Count; i++)
                            chbEstablecimiento.SetItemChecked(i, true);
                    }
                    else
                    {
                        for (int i = 0; i < chbEstablecimiento.Items.Count; i++)
                            chbEstablecimiento.SetItemChecked(i, false);
                    }
                }
                else
                {
                    chbTodosEstablecimiento.Checked = false;
                }
            }
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFecHorInicio = Convert.ToDateTime(dtpFechaInicio.Value.ToString("yyyy-MM-dd"));
            DateTime dFecHorFinal = Convert.ToDateTime(dtpFechaFinal.Value.ToString("yyyy-MM-dd"));
            if (Convert.ToDateTime(dtpFechaInicio.Value.ToString("yyyy-MM-dd")) > Convert.ToDateTime(dtpFechaFinal.Value.ToString("yyyy-MM-dd")))
            {
                MessageBox.Show("La fecha final, no puede ser menor que la fecha inicial", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            bool lrpta = false;
            for (int i = 0; i < chbEstablecimiento.Items.Count; i++)
            {
                if (chbEstablecimiento.GetItemCheckState(i) == CheckState.Checked)
                {
                    lrpta = true;
                }
            }
            if (!lrpta)
            {
                MessageBox.Show("Falta completar datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            bool lHistorial = chbHistorial.Checked;
            DataTable dtResEstablecimientos = SeleccionarEstablecimientos();
            DataSet dsResEstablecimientos = new DataSet("dsEstablecimiento");
            dsResEstablecimientos.Tables.Add(dtResEstablecimientos);
            string cXmlEstablecimientos = dsResEstablecimientos.GetXml();   
            
            string reportpath = "rptSolicitudesCreditosObservados.rdlc";

            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            paramlist.Add(new ReportParameter("cEstablecimiento", cXmlEstablecimientos, false));
            paramlist.Add(new ReportParameter("idEstadoCreditoObs", Convert.ToString(cboEstado.SelectedValue), false));
            paramlist.Add(new ReportParameter("dFechaInicio", dFecHorInicio.ToString("yyyy-MM-dd HH:mm:ss"), false));
            paramlist.Add(new ReportParameter("dFechaFin", dFecHorFinal.ToString("yyyy-MM-dd HH:mm:ss"), false));
            paramlist.Add(new ReportParameter("lHistorial", Convert.ToString(lHistorial), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

           dtslist.Add(new ReportDataSource("dsSolicitudes", clsFiles.CNRptSolicitudesCreditosObservados(cXmlEstablecimientos, Convert.ToInt32(cboEstado.SelectedValue), dFecHorInicio, dFecHorFinal, lHistorial)));
          
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            
        }          
 
    }
}
