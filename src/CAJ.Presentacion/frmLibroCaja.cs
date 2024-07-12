using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using CAJ.CapaNegocio;
using CLI.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;

namespace CAJ.Presentacion
{
    public partial class frmLibroCaja : frmBase
    {
        //================================================
        //--Declarar variables Publicas
        //================================================
        public DataTable tbIngSol;
        public DataTable tbEgrSol;
        public DataTable tbIngDol;
        public DataTable tbEgrDol;

        public frmLibroCaja()
        {
            InitializeComponent();
        }

        private void frmCierreOperaciones_Load(object sender, EventArgs e)
        {
            DatosUsuario();
            this.dtpProceso.Value = clsVarGlobal.dFecSystem;
            
        }

       
       
        private void DatosUsuario()
        {
            txtCodUsu.Text = clsVarGlobal.User.idUsuario.ToString();
            int nidCli = Convert.ToInt32(clsVarGlobal.User.idCli);
            clsCNRetDatosCliente RetDatCli = new clsCNRetDatosCliente();
            DataTable DatosCli = RetDatCli.ListarDatosCli(nidCli, "D");
            if (DatosCli.Rows.Count > 0)
            {
                txtNomUsu.Text = DatosCli.Rows[0]["cNombre"].ToString();
            }
            else
            {
                txtNomUsu.Text = "";
            }
        }

        private void SalIniOpe()
        {
            clsCNControlOpe idResBob = new clsCNControlOpe();
            int nResBov = idResBob.RetornaResBoveda(clsVarGlobal.nIdAgencia);
            
            string msge = "";
            int idUsu = Convert.ToInt32(this.txtCodUsu.Text);
            clsCNControlOpe saldoIniOpe = new clsCNControlOpe();
            //=====================================================================
            //---Ingresos en Soles
            //=====================================================================
            DataTable tbSalIniOpe = saldoIniOpe.SaldoinicialOpe(Convert.ToDateTime(this.dtpProceso.Value.ToShortDateString()), 
                                                                 nResBov, clsVarGlobal.nIdAgencia, 1,ref msge);
            if (msge == "OK")
            {
                if (tbSalIniOpe.Rows.Count > 0)
                {
                    this.txtSalIniSol.Text = tbSalIniOpe.Rows[0]["nSalIniSol"].ToString();
                    this.txtSalIniDol.Text = tbSalIniOpe.Rows[0]["nSalIniDol"].ToString();
                }
            }
            else
            {
                MessageBox.Show(msge, "Error al Extraer El Saldo Inicial...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void SaldoFinal()
        {
            //====================
            //--SALDO FINA SOLES
            //====================
            this.txtSalFinSol.Text = Convert.ToString(Math.Round((Convert.ToDecimal(this.txtSalIniSol.Text) + Convert.ToDecimal(this.txtMonIngSol.Text) - Convert.ToDecimal (this.txtMonEgrSol.Text)),2));
            //====================
            //--SALDO FINA DOLARES
            //====================
            this.txtSalFinDol.Text = Convert.ToString(Math.Round((Convert.ToDecimal(this.txtSalIniDol.Text) + Convert.ToDecimal(this.txtMonIngDol.Text) - Convert.ToDecimal (this.txtMonEgrDol.Text)),2));
        }

        private void CuadreOpe()
        {
            string msge = "";
            int idUsu = clsVarGlobal.User.idUsuario; 
            clsCNControlOpe CuadreOpe = new clsCNControlOpe();
            //=====================================================================
            //---Ingresos en Soles
            //=====================================================================
            int idTipResCaja =0;//no se usa para esta opcion

            tbIngSol = CuadreOpe.ConsultaCuadreOpe(Convert.ToDateTime(this.dtpProceso.Value.ToShortDateString()), idUsu, 1, clsVarGlobal.nIdAgencia, 1, 2, ref msge,idTipResCaja);
            if (msge == "OK")
            {
                this.dtgIngSoles.DataSource = tbIngSol;
                if (tbIngSol.Rows.Count>0)
                {
                    this.txtMonIngSol.Text = tbIngSol.Rows[0]["nTotal"].ToString();
                    this.btnImprimir.Enabled = true;
                }                
            }
            else
            {
                MessageBox.Show(msge, "Error al Extraer Datos de las Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //=====================================================================
            //---Egresos en Soles
            //=====================================================================
            tbEgrSol = CuadreOpe.ConsultaCuadreOpe(Convert.ToDateTime(this.dtpProceso.Value.ToShortDateString()), idUsu, 1, clsVarGlobal.nIdAgencia, 2, 2, ref msge, idTipResCaja);
            if (msge == "OK")
            {
                this.dtgEgrSoles.DataSource = tbEgrSol;
                if (tbEgrSol.Rows.Count > 0)
                {
                    this.txtMonEgrSol.Text = tbEgrSol.Rows[0]["nTotal"].ToString();
                    this.btnImprimir.Enabled = true;
                } 
            }
            else
            {
                MessageBox.Show(msge, "Error al Extraer Datos de las Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          

            //=====================================================================
            //---Ingresos en Dolares
            //=====================================================================
            tbIngDol = CuadreOpe.ConsultaCuadreOpe(Convert.ToDateTime(this.dtpProceso.Value.ToShortDateString()), idUsu, 2, clsVarGlobal.nIdAgencia, 1, 2, ref msge, idTipResCaja);
            if (msge == "OK")
            {
                this.dtgIngDolares.DataSource = tbIngDol;
                if (tbIngDol.Rows.Count > 0)
                {
                    this.txtMonIngDol.Text = tbIngDol.Rows[0]["nTotal"].ToString();
                    this.btnImprimir.Enabled = true;
                }  
            }
            else
            {
                MessageBox.Show(msge, "Error al Extraer Datos de las Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //=====================================================================
            //---Egresos en Dolares
            //=====================================================================
            tbEgrDol = CuadreOpe.ConsultaCuadreOpe(Convert.ToDateTime(this.dtpProceso.Value.ToShortDateString()), idUsu, 2, clsVarGlobal.nIdAgencia, 2, 2, ref msge, idTipResCaja);
            if (msge == "OK")
            {
                this.dtgEgrDolares.DataSource = tbEgrDol;
                if (tbEgrDol.Rows.Count > 0)
                {
                    this.txtMonEgrDol.Text = tbEgrDol.Rows[0]["nTotal"].ToString();
                    this.btnImprimir.Enabled = true;
                } 
            }
            else
            {
                MessageBox.Show(msge, "Error al Extraer Datos de las Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            DateTime dFecha = Convert.ToDateTime(this.dtpProceso.Value.ToShortDateString());
            int idMon = 1;
            int idAge = clsVarGlobal.nIdAgencia;
            paramlist.Add(new ReportParameter("dFecReg", dFecha.ToString(), false));
            paramlist.Add(new ReportParameter("idMon", idMon.ToString(), false));
            paramlist.Add(new ReportParameter("idAge", idAge.ToString(), false));

            dtslist.Add(new ReportDataSource("RptLibroCaja", new clsCNCajaChica().RptLibroCaja(dFecha, idMon, idAge)));
            string reportpath = "RptLibroCaja.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            this.btnImprimir.Enabled = true;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            //--Reiniciar valores
            this.txtSalIniSol.Text = "0.00";
            this.txtMonIngSol.Text = "0.00";
            this.txtMonEgrSol.Text = "0.00";
            this.txtSalFinSol.Text = "0.00";
            this.txtSalIniDol.Text = "0.00";
            this.txtMonIngDol.Text = "0.00";
            this.txtMonEgrDol.Text = "0.00";
            this.txtSalFinDol.Text = "0.00";
            //--Procesar Libro Caja
            this.btnImprimir.Enabled = false;
            
            //Actualizar Cierre
            CuadreOpe();
            SalIniOpe();
            SaldoFinal();
        } 
    }
}
