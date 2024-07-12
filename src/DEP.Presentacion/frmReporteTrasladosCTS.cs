using EntityLayer;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEP.Presentacion
{
    public partial class frmReporteTrasladosCTS : frmBase
    {
        public frmReporteTrasladosCTS()
        {
            InitializeComponent();
        }

        private void frmReporteTrasladosCTS_Load(object sender, EventArgs e)
        {
            cboEstadoSolic1.EstadosYTodos();
            cboAgencias1.AgenciasYTodos();
            dtFecInicio.Value = clsVarGlobal.dFecSystem;
            dtFecFin.Value = clsVarGlobal.dFecSystem;
            cboAgencias1.SelectedIndex = -1;
            cboEstadoSolic1.SelectedIndex = -1;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            //VALIDACIONES
            if (Convert.ToDateTime(dtFecFin.Value.ToShortDateString()) < Convert.ToDateTime(dtFecInicio.Value.ToShortDateString()))
            {
                MessageBox.Show("Periodo Incorrecto: La fecha de Inicio es posterior a la Final", "Extracto de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboEstadoSolic1.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el Estado del Traslado de CTS", "Traslado de Depósitos de CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboAgencias1.SelectedIndex == 0 || cboAgencias1.Text == "")
            {
                MessageBox.Show("Seleccione la Agencia", "Traslado de Depósitos de CTS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DateTime dFecInicio = dtFecInicio.Value;
            DateTime dFecFin = dtFecFin.Value;            
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            string cAgencia = cboAgencias1.Text;
            string cEstado = cboEstadoSolic1.Text;
            string idAgencia = "";
            string idEstado = "";

            //Obtener idAgencia//
            if (Convert.ToString(cboAgencias1.SelectedValue) == "0")
            {
                int i = 1;
                foreach (DataRowView item in cboAgencias1.Items)
                {
                    if (i < cboAgencias1.Items.Count && i > 1)
                        idAgencia += item[0] + ",";
                    i++;
                }
                idAgencia = idAgencia.Remove((idAgencia.Length - 1), 1);
            }

            else if (Convert.ToString(cboAgencias1.SelectedValue) != "0")
                idAgencia = Convert.ToString(cboAgencias1.SelectedValue);


            //Obtener idEstado//
            if (Convert.ToString(cboEstadoSolic1.SelectedValue) == "0")
            {
                idEstado = "[";
                int i = 1;
                foreach (DataRowView item in cboEstadoSolic1.Items)
                {
                    if (i < cboEstadoSolic1.Items.Count)
                        idEstado += item[0] + ",";
                    i++;
                }
                idEstado = idEstado.Remove((idEstado.Length - 1), 1) + "]";
            }

            else if (Convert.ToString(cboEstadoSolic1.SelectedValue) != "0")
                idEstado = Convert.ToString(cboEstadoSolic1.SelectedValue);



            DataTable dtDatosExtorno = new clsRPTCNDeposito().CNDatosTrasladosCTS(dFecInicio, dFecFin, idAgencia, idEstado);


            if (dtDatosExtorno.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte para este intervalo de Fechas", "Extracto de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_dFechaINI", dFecInicio.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_dFechaFIN", dFecFin.ToString("dd/MM/yyyy"), false));

                
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_cAgencia", cAgencia, false));
                paramlist.Add(new ReportParameter("x_cEstado", cEstado, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                


                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsTrasladosCTS", dtDatosExtorno));
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));

                string reportpath = "rptTrasladosCTS.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            dtFecInicio.Value = clsVarGlobal.dFecSystem;
            dtFecFin.Value = clsVarGlobal.dFecSystem;
            cboAgencias1.SelectedIndex = -1;
            cboEstadoSolic1.SelectedIndex = -1;
        }
    }
}
