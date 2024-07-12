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
using Microsoft.Reporting.WinForms;
using EntityLayer;
using SPL.CapaNegocio;

namespace SPL.Presentacion
{
    public partial class frmRptRegistroOperacionesMultiples : frmBase
    {
        clsCNOperacionesMultiples cnOpeMult = new clsCNOperacionesMultiples();
        public frmRptRegistroOperacionesMultiples()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFechaInicio = conFechaAñoMesInicio.RetornaFecha();
            DateTime dFechaFin;
            int idMes = 0;
            idMes = conFechaAñoMesFin.idMes;
            if (conFechaAñoMesFin.idMes==12)
            {
                idMes = 0;
                dFechaFin = new DateTime(conFechaAñoMesFin.anio+1, idMes + 1, 1).AddDays(-1);
            }
            else
            {
                dFechaFin = new DateTime(conFechaAñoMesFin.anio, idMes + 1, 1).AddDays(-1);
            }
            

            if (dFechaInicio>dFechaFin)
            {
                MessageBox.Show("El Inicio no puede ser mayor que la fecha de fin", "Reporte del Registro de Operaciones Múltiples", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cboAgencias1.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una agencia", "Reporte del Registro de Operaciones Múltiples", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string reportpath = "rptRegistrodeOperacionesMultiples .rdlc";
            DataTable dtResultado = cnOpeMult.CNRptRegOperacionesMultiples(dFechaInicio, dFechaFin, Convert.ToInt32(cboAgencias1.SelectedValue));
            
            if(dtResultado.Rows.Count == 0)
            {
                MessageBox.Show("No hay resultados para esos filtros", "Reporte del Registro de Operaciones Múltiples", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string AgenEmision = clsVarApl.dicVarGen["cNomAge"];

            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            paramlist.Add(new ReportParameter("cNomAgen", AgenEmision, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaInicio", dFechaInicio.ToShortDateString().ToString(), false));
            paramlist.Add(new ReportParameter("dFechaFin", dFechaFin.ToShortDateString().ToString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", Convert.ToString(clsVarApl.dicVarGen["CRUTALOGO"]), false));

            dtslist.Add(new ReportDataSource("dsOperacionesMultiples", dtResultado));


            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
    }
}
