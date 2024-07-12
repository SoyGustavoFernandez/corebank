using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using CAJ.CapaNegocio;
using RPT.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmDetalleOperacionesDep : frmBase
    {
        public frmDetalleOperacionesDep()
        {
            InitializeComponent();
        }

        private void frmDetalleOperacionesDep_Load(object sender, EventArgs e)
        {
            dtpFecProceso.Value = clsVarGlobal.dFecSystem;

            //--Validar si ya Realizó su corte Fraccionario
            if (ValidarCorteFracc() == "ERROR")
            {
                this.Dispose();
                return;
            }

        }

        private string ValidarCorteFracc()
        {
            string cRpta = "OK";
            string msge = "";
            clsCNControlOpe ValCorFra = new clsCNControlOpe();
            string cCorFra = ValCorFra.ValidaCorteFracc(clsVarGlobal.dFecSystem, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()), clsVarGlobal.nIdAgencia, ref msge);
            if (msge == "OK")
            {
                if (cCorFra == "0")
                {
                    MessageBox.Show("Primero debe Realizar su Corte Fraccionario... por Favor..", "Validar Corte Fraccionario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cRpta = "ERROR";
                }
            }
            else
            {
                MessageBox.Show(msge, "Error al Validar Corte Fraccionario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cRpta = "ERROR";
            }
            return cRpta;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsDetOperacionesDep", new clsRPTCNDeposito().CNOperacionesDep(this.dtpFecProceso.Value, clsVarGlobal.User.idUsuario)));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("dFechaOpe", this.dtpFecProceso.Value.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("idUsuario", clsVarGlobal.User.idUsuario.ToString(), false));

            string reportpath = "rptDetalleOperacionesDEP.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
    }
}
