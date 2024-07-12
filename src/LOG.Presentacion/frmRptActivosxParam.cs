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
using Microsoft.Reporting.WinForms;
using EntityLayer;
using RPT.CapaNegocio;
using LOG.CapaNegocio;

namespace LOG.Presentacion
{
    public partial class frmRptActivosxParam : frmBase
    {
        public frmRptActivosxParam()
        {
            InitializeComponent();
        }
        private void CargarEstados()
        {
            if ((cboArea1.SelectedIndex > -1 ) && ( cboAgencias1.SelectedIndex > -1))
            {
                int idArea;
                idArea = Convert.ToInt32(cboArea1.SelectedValue);

                clsCNPersonal LisColab = new clsCNPersonal();
                DataTable dtEstados = LisColab.CNListaPersonalxArea(Convert.ToInt32(cboAgencias1.SelectedValue), idArea);
                this.chklbEstados.DataSource = dtEstados;
                this.chklbEstados.ValueMember = dtEstados.Columns["idUsuario"].ToString();
                this.chklbEstados.DisplayMember = dtEstados.Columns["cNombre"].ToString();  
            }
                      
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

        private void frmRptActivosxParam_Load(object sender, EventArgs e)
        {
            cboAgencias1.SelectedValue = 0;
            cboArea1.SelectedValue = 0;
            cboArea1.CargarArea(Convert.ToInt32(cboAgencias1.SelectedValue));            
            CargarEstados();
        }

        private void cboAgencias1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboArea1.CargarArea(Convert.ToInt32(cboAgencias1.SelectedValue));
            CargarEstados();
        }

        private void cboArea1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            CargarEstados();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string Msje = ValidarDatos().Trim();
            if (!string.IsNullOrEmpty(Msje))
            {
                MessageBox.Show(Msje, "Activos por Personal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            String idUsuarioResp = "";
            foreach (DataRowView item in this.chklbEstados.CheckedItems)
            {
                idUsuarioResp += (item.Row["idUsuario"] + ",");
            }



            DataTable dtActivoColab = new clsCNActivos().CNListaActivosColab(idUsuarioResp, Convert.ToInt32(cboAgencias1.SelectedValue));
            if (dtActivoColab.Rows.Count<=0)
            {
                MessageBox.Show("No se encontraton registros con los parametros especificados para el reporte.", "Reporte de Recibos por Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

            List<ReportParameter> paramlist = new List<ReportParameter>();

            //int idCtaBco = nIdCuentaInst;
            //DateTime dFechaIni = this.dtpFecIni.Value.Date;
            //DateTime dFechaFin = this.dtpFecFin.Value.Date;


            //paramlist.Add(new ReportParameter("idUsuResp", idUsuarioResp, false));
            paramlist.Add(new ReportParameter("idAgencia", cboAgencias1.SelectedValue.ToString() , false));
            paramlist.Add(new ReportParameter("cNombreVariable", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsActivoColab", dtActivoColab ));
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));

            string reportpath = "rptDetalleActivos.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }
        private string ValidarDatos()
        {
            string Msje = "";
            //==================================================================
            //--Validar Datos del Reporte
            //==================================================================            
            if (this.chklbEstados.CheckedItems.Count == 0)
            {
                Msje += "Seleccione al menos un Estado.\n";
                this.chklbEstados.Focus();
                this.chklbEstados.Select();
            }
            return Msje;
        }

        
    }
}
