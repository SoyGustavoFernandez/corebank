using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
    public partial class FrmRptListadoPer : frmBase
    {
        int permiso=0;
        int permiso2=0;
        public FrmRptListadoPer()
        {
            InitializeComponent();
        }

        private void FrmRptListadoPer_Load(object sender, EventArgs e)
        {
            ListadoAgencias();
            cboAgencias.SelectedIndex = -1;
            EstadoPersonal();
            permiso = 1;
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
       
        private void EstadoPersonal()
        {
            clsCNEstPersonal ListaEstPersonal = new clsCNEstPersonal();
            DataTable dtListaEstPersonal = ListaEstPersonal.ListaEstPersonal();
            DataRow dr = dtListaEstPersonal.NewRow();
            dr[0] = "0";
            dr[1] = "***TODOS***";
            dtListaEstPersonal.Rows.Add(dr);
            this.cboEstPer.DataSource = dtListaEstPersonal;
            this.cboEstPer.ValueMember = dtListaEstPersonal.Columns[0].ToString();
            this.cboEstPer.DisplayMember = dtListaEstPersonal.Columns[1].ToString();

            cboEstPer.SelectedIndex = -1;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (cboAgencias.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar la Agencia", "Registro de Colaboradores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgencias.Focus();
                return;
            }
            if (cboArea1.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el Área", "Registro de Colaboradores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboArea1.Focus();
                return ;
            }
            if (cboCargoPersonal.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el Cargo", "Registro de Colaboradores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCargoPersonal.Focus();
                return;
            }
            if (cboEstPer.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el Estado de los colaboradores", "Registro de Colaboradores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboEstPer.Focus();
                return;
            }

            int idAge = Convert.ToInt32(this.cboAgencias.SelectedValue);
            int idArea =  Convert.ToInt32(this.cboArea1.SelectedValue);
            int idCargo =  Convert.ToInt32(this.cboCargoPersonal.SelectedValue);
            int idEst =  Convert.ToInt32(this.cboEstPer.SelectedValue);

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];


            DataTable dtRpt = new clsRPTCNRecurHum().CNListaColaboradores(idAge,idArea, idCargo, idEst);
            if (dtRpt.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();


                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                                
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsLisPersonal", dtRpt));
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));


                string reportpath = "RptListadoPersonal.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();                
            }
            else
            {
                MessageBox.Show("No Existen Datos para el Reporte", "Reporte de Colaboradores", MessageBoxButtons.OK, MessageBoxIcon.Information);               
                return;
            }
        }

        private void cboAgencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (permiso == 1 && cboAgencias.Text.Trim() != "")
            {
                clsCNArea objArea = new clsCNArea();
                DataTable dtArea = objArea.CNListadoArea(Convert.ToInt32(cboAgencias.SelectedValue));
                DataRow dr = dtArea.NewRow();
                dr[0] = "0";
                dr[1] = "***TODOS***";
                dtArea.Rows.Add(dr);
                this.cboArea1.DataSource = dtArea;
                this.cboArea1.ValueMember = dtArea.Columns[0].ToString();
                this.cboArea1.DisplayMember = dtArea.Columns[1].ToString();
               
                permiso2 = 1;
                
                if (Convert.ToInt32(cboAgencias.SelectedValue) == 0)
                {
                    this.cboArea1.SelectedIndex = -1;
                    this.cboArea1.SelectedValue = 0;
                    this.cboArea1.Enabled = false;
                }
                else
                {
                    this.cboArea1.SelectedIndex = -1;
                    this.cboArea1.Enabled = true;
                }
            }
        }

        private void cboArea1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (permiso2 == 1 && cboArea1.Text.Trim().ToString() != "")
            {
                clsCNListaCargoPersonal objCargoPersonal = new clsCNListaCargoPersonal();
                DataTable dtCargoPersonal = objCargoPersonal.ListacargoPersonal(Convert.ToInt32(cboArea1.SelectedValue));
                DataRow dr = dtCargoPersonal.NewRow();
                dr[0] = "0";
                dr[1] = "***TODOS***";
                dtCargoPersonal.Rows.Add(dr);
                this.cboCargoPersonal.DataSource = dtCargoPersonal;
                this.cboCargoPersonal.ValueMember = dtCargoPersonal.Columns[0].ToString();
                this.cboCargoPersonal.DisplayMember = dtCargoPersonal.Columns[1].ToString();
                
                if (Convert.ToInt32(cboArea1.SelectedValue) == 0)
                {
                    this.cboCargoPersonal.SelectedValue = 0;
                    this.cboCargoPersonal.Enabled = false;
                }
                else
                {
                    this.cboCargoPersonal.SelectedIndex = -1;
                    this.cboCargoPersonal.Enabled = true;
                }
                
            }
        }       
    }
}
