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
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using EntityLayer;

namespace LOG.Presentacion
{
    public partial class frmRptStockBienesAgencia : frmBase

    {
        public frmRptStockBienesAgencia()
        {
            InitializeComponent();
        }

        private void frmRptStockBienesAgencia_Load(object sender, EventArgs e)
        {
            CargarCboGrupo(0, 0);
            cboAgencia.AgenciasYTodos();
            cboAlmacen.CargarAlmacenYTodos(1);
            dtpFecha.Value = clsVarGlobal.dFecSystem;
            dtpFecha.Enabled = false;

            if (clsVarGlobal.nIdAgencia == 1)
            {
                cboAgencia.Enabled = true;
            }
            else
            {
                cboAgencia.SelectedValue = clsVarGlobal.nIdAgencia;
                cboAgencia.Enabled = false;
            }
        }

        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencia.SelectedIndex > 0)
            {
                cboAlmacen.CargarAlmacenYTodos((int)cboAgencia.SelectedValue);
            }
            else if (cboAgencia.SelectedIndex  == 0)
            {
                cboAlmacen.CargarAlmacenYTodos((int)cboAgencia.SelectedValue);
                cboAlmacen.SelectedValue = 0;
                cboGrupos.SelectedValue = 0;
                cboSubGrupos.SelectedValue = 0;
                cboRubros.SelectedValue = 0;
            }
        }

        private void CargarCboGrupo(int idGrupoActivo, int idTipoBien)
        {
            clsRPTCNLogistica objLogistica = new clsRPTCNLogistica();
            DataTable dtListaGrupos;
            dtListaGrupos = objLogistica.CNCargarGrupoSubGrupoRubro(idGrupoActivo, idTipoBien);

            DataRow row = dtListaGrupos.NewRow();
            row["idGrupoActivo"] = 0;
            row["cNombreGrupo"] = "TODOS";
            dtListaGrupos.Rows.Add(row);
            cboGrupos.ValueMember = "idGrupoActivo";
            cboGrupos.DisplayMember = "cNombreGrupo";
            cboGrupos.DataSource = dtListaGrupos;

            if (cboGrupos.SelectedIndex == 0)
            {
                cboSubGrupos.SelectedIndex = 0;
                cboRubros.SelectedIndex = 0;
            }
            
        }

        private void CargarCboSubGrupo(int idGrupo, int idTipoBien)
        {
            clsRPTCNLogistica objLogistica = new clsRPTCNLogistica();
            DataTable dtListaSubGrupos;
            dtListaSubGrupos = objLogistica.CNCargarGrupoSubGrupoRubro(idGrupo, idTipoBien);
            if (dtListaSubGrupos.Rows.Count > 0)
            {
                DataRow row = dtListaSubGrupos.NewRow();
                row["idGrupoActivo"] = 0;
                row["cNombreGrupo"] = "TODOS";
                dtListaSubGrupos.Rows.Add(row);
                cboSubGrupos.ValueMember = "idGrupoActivo";
                cboSubGrupos.DisplayMember = "cNombreGrupo";
                cboSubGrupos.DataSource = dtListaSubGrupos;
            }
            else
            {
                return;
            }

        }

        private void CargarCboRubros(int idSubGrupo, int idTipoBien)
        {
            clsRPTCNLogistica objLogistica = new clsRPTCNLogistica();
            DataTable dtListaRubros;
            dtListaRubros = objLogistica.CNCargarGrupoSubGrupoRubro(idSubGrupo, idTipoBien);
            if (dtListaRubros.Rows.Count > 0)
            {
                DataRow row = dtListaRubros.NewRow();
                row["idGrupoActivo"] = 0;
                row["cNombreGrupo"] = "TODOS";
                dtListaRubros.Rows.Add(row);
                cboRubros.ValueMember = "idGrupoActivo";
                cboRubros.DisplayMember = "cNombreGrupo";
                cboRubros.DataSource = dtListaRubros;
            }
            else
            {
                return;
            }


        }

        private void cboGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboGrupos.SelectedIndex >=0)
            {
                CargarCboSubGrupo((int)cboGrupos.SelectedValue, 0);
            }            
        }

        private void cboSubGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboSubGrupos.SelectedIndex >= 0)
            {
                CargarCboRubros((int)cboSubGrupos.SelectedValue, 0);
            }
        }

        private void chcHistorico_CheckedChanged(object sender, EventArgs e)
        {
            dtpFecha.Enabled = chcHistorico.Checked;

            if (!chcHistorico.Checked)
            {
                dtpFecha.Value = clsVarGlobal.dFecSystem;
            }
            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            clsRPTCNLogistica objLogistica = new clsRPTCNLogistica();
            DataTable dtStockBienesAgencia;

            DateTime dFecha = dtpFecha.Value;
            int idAlmacen = (int)cboAlmacen.SelectedValue;
            string cAlmacen = cboAlmacen.Text;
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);
            int idRubro = (int)cboRubros.SelectedValue;
            string cGrupo = cboGrupos.Text;
            string cSubGrupo = cboSubGrupos.Text;
            string cRubro = cboRubros.Text;

            if (chcHistorico.Checked)
            {
                dtStockBienesAgencia = objLogistica.CNHistoricoStockBienPorAgencia(dFecha, idAgencia, idRubro);
            }
            else
            {
                dtStockBienesAgencia = objLogistica.CNStockBienPorAgencia(idAgencia, idRubro);
            }

            if (dtStockBienesAgencia.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();

                dtsList.Add(new ReportDataSource("StockBienAgencia", dtStockBienesAgencia));

                List<ReportParameter> paramList = new List<ReportParameter>();

                paramList.Add(new ReportParameter("dFecha", dFecha.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("idAgencia", cboAgencia.SelectedValue.ToString(), false));
                //paramList.Add(new ReportParameter("idAlmacen", idAlmacen.ToString(), false));
                paramList.Add(new ReportParameter("idRubro", idRubro.ToString(), false));
                paramList.Add(new ReportParameter("cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramList.Add(new ReportParameter("cNomAgencia", clsVarApl.dicVarGen["cNomAge"], false));

                string reportPath = "rptStockBienPorAgencia.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos", "Reporte de Saldos por Almacen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
    }
}
