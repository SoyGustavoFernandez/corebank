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
using RPT.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmConsultaCieOpe : frmBase
    {
        //================================================
        //--Declarar variables Publicas
        //================================================
        public DataTable tbIngSol;
        public DataTable tbEgrSol;
        public DataTable tbIngDol;
        public DataTable tbEgrDol;
        int pnCantidad = 0;//el valor 2 indica que el usuario es responsable de bóveda y caja pulmón

        public frmConsultaCieOpe()
        {
            InitializeComponent();
        }

        private void frmCierreOperaciones_Load(object sender, EventArgs e)
        {
            DatosUsuario();
            if (string.IsNullOrEmpty(this.txtCodUsu.Text.Trim()))
            {
                MessageBox.Show("No Existe Usuario", "Validar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnProcesar.Enabled = false;
            }

            this.dtpProceso.Value = clsVarGlobal.dFecSystem;
            cboTipResponsableCaja1.cargarTipoResponsableCajaOpe(clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem);

            //int nValResBov = ValidaRespBoveda();
            ////para ventanilla solo permite ver sus operaciones
            //if (nValResBov == 1 && pnCantidad==1)
            //{
            //    cboColaborador.Enabled = false;
            //    cboTipResponsableCaja1.Enabled = false;
            //}
            //else
            //{
            //    cboColaborador.Enabled = true;
            //    cboTipResponsableCaja1.Enabled = true;
            //}
            //cboTipResponsableCaja1.SelectedIndex  =-1;

        }

        private void ActualizarCierre()
        {
            CuadreOpe();
            FormatoGrid();
            SalIniOpe();
            SaldoFinal();
            //--Saldo de Corte Fraccionario
            SaldoCorteFraccionario();
        }

        private void DatosUsuario()
        {
            dtpFechaSis.Value = clsVarGlobal.dFecSystem;
            txtCodUsu.Text = clsVarGlobal.User.idUsuario.ToString();
            txtUsuario.Text = clsVarGlobal.User.cWinUser;
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

        private void ListarColAgencia(string cTipRes, int idAge)
        {
            //clsCNControlOpe LisColAge = new clsCNControlOpe();
            //DataTable tbColAge = LisColAge.ListarColabAgencias(idAge);
            //this.cboColaborador.DataSource = tbColAge;
            //this.cboColaborador.ValueMember = tbColAge.Columns["idUsuario"].ToString();
            //this.cboColaborador.DisplayMember = tbColAge.Columns["cNombre"].ToString();
            //if (tbColAge.Rows.Count > 0)
            //{
            //    this.cboColaborador.Enabled = true;
            //}
            //else
            //{
            //    this.cboColaborador.Enabled = false;
            //}
            string msg = "";
            DateTime dtFecConsulta = dtpProceso.Value;
            clsCNControlOpe LisColAge = new clsCNControlOpe();

            DataTable tbColAge = LisColAge.LisRespHab(5, clsVarGlobal.nIdAgencia, cTipRes, clsVarGlobal.User.idUsuario, ref msg, dtFecConsulta);

            this.cboColaborador.DataSource = tbColAge;
            this.cboColaborador.ValueMember = tbColAge.Columns["idUsuario"].ToString();
            this.cboColaborador.DisplayMember = tbColAge.Columns["cNombre"].ToString();
        }

        private void FormatoGrid()
        {
            //--Formato Grid Ingreso Soles
            this.dtgIngSoles.Columns["idTipoOperacion"].Visible = false;
            this.dtgIngSoles.Columns["nTotal"].Visible = false;
            this.dtgIngSoles.Columns["cTipoOperacion"].Width = 250;
            this.dtgIngSoles.Columns["cTipoOperacion"].HeaderText = "Tipo Operación";
            this.dtgIngSoles.Columns["nMontoOperacion"].Width = 120;
            this.dtgIngSoles.Columns["nMontoOperacion"].HeaderText = "Total Operación";
            this.dtgIngSoles.Columns["nCantidad"].HeaderText = "Cant.";
            this.dtgIngSoles.Columns["nCantidad"].Width = 40;
            this.dtgIngSoles.Columns["nMontoOperacion"].DefaultCellStyle.Format = "N2";
            //--Formato Grid Egreso Soles
            this.dtgEgrSoles.Columns["idTipoOperacion"].Visible = false;
            this.dtgEgrSoles.Columns["nTotal"].Visible = false;
            this.dtgEgrSoles.Columns["cTipoOperacion"].Width = 250;
            this.dtgEgrSoles.Columns["cTipoOperacion"].HeaderText = "Tipo Operación";
            this.dtgEgrSoles.Columns["nMontoOperacion"].Width = 120;
            this.dtgEgrSoles.Columns["nMontoOperacion"].HeaderText = "Total Operación";
            this.dtgEgrSoles.Columns["nCantidad"].HeaderText = "Cant.";
            this.dtgEgrSoles.Columns["nCantidad"].Width = 40;
            this.dtgEgrSoles.Columns["nMontoOperacion"].DefaultCellStyle.Format = "N2";
        }

        private void FormatoGridDol()
        {
            //--Formato Grid Ingreso Dólares
            this.dtgIngDolares.Columns["idTipoOperacion"].Visible = false;
            this.dtgIngDolares.Columns["nTotal"].Visible = false;
            this.dtgIngDolares.Columns["cTipoOperacion"].Width = 250;
            this.dtgIngDolares.Columns["cTipoOperacion"].HeaderText = "Tipo Operación";
            this.dtgIngDolares.Columns["nMontoOperacion"].Width = 120;
            this.dtgIngDolares.Columns["nMontoOperacion"].HeaderText = "Total Operación";
            this.dtgIngDolares.Columns["nCantidad"].HeaderText = "Cant.";
            this.dtgIngDolares.Columns["nCantidad"].Width = 40;
            this.dtgIngDolares.Columns["nMontoOperacion"].DefaultCellStyle.Format="N2";
            //--Formato Grid Egreso Dólares
            this.dtgEgrDolares.Columns["idTipoOperacion"].Visible = false;
            this.dtgEgrDolares.Columns["nTotal"].Visible = false;
            this.dtgEgrDolares.Columns["cTipoOperacion"].Width = 250;
            this.dtgEgrDolares.Columns["cTipoOperacion"].HeaderText = "Tipo Operación";
            this.dtgEgrDolares.Columns["nMontoOperacion"].Width = 120;
            this.dtgEgrDolares.Columns["nMontoOperacion"].HeaderText = "Total Operación";
            this.dtgEgrDolares.Columns["nCantidad"].HeaderText = "Cant.";
            this.dtgEgrDolares.Columns["nCantidad"].Width = 40;
            this.dtgEgrDolares.Columns["nMontoOperacion"].DefaultCellStyle.Format = "N2";
        }

        private void SalIniOpe()
        {
            string msge = "";
            int idUsu = Convert.ToInt32(cboColaborador.SelectedValue);
            clsCNControlOpe saldoIniOpe = new clsCNControlOpe();
            //=====================================================================
            //---Ingresos en Soles
            //=====================================================================
            int idTipResCaj = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);
            DataTable tbSalIniOpe = saldoIniOpe.SaldoinicialOpe(Convert.ToDateTime(this.dtpProceso.Value.ToShortDateString()), idUsu, clsVarGlobal.nIdAgencia, idTipResCaj, ref msge);
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

        private void SaldoCorteFraccionario()
        {
            Decimal nMonSoles = 0.00m, nMonDolar = 0.00m;
            DateTime dFecPro = Convert.ToDateTime(this.dtpProceso.Value.ToShortDateString());
            clsCNControlOpe SalCorteFrac = new clsCNControlOpe();
            int idTipResCaj = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);
            string cRpta = SalCorteFrac.RetMontoCorFracc(dFecPro, Convert.ToInt32(this.cboColaborador.SelectedValue), clsVarGlobal.nIdAgencia, ref nMonSoles, ref nMonDolar, idTipResCaj);
            if (cRpta == "OK")
            {
                if (string.IsNullOrEmpty(nMonSoles.ToString()))
                {
                    nMonSoles = 0.00m;
                }
                if (string.IsNullOrEmpty(nMonDolar.ToString()))
                {
                    nMonDolar = 0.00m;
                }
                this.txtCortSoles.Text = nMonSoles.ToString();
                this.txtCorDolar.Text = nMonDolar.ToString();
                this.txtDifSoles.Text = Convert.ToString(Math.Round((Math.Round(Convert.ToDecimal (this.txtSalFinSol.Text), 2) - Math.Round(nMonSoles, 2)), 2));
                this.txtDifDolar.Text = Convert.ToString(Math.Round(Math.Round(Convert.ToDecimal (this.txtSalFinDol.Text) - Math.Round(nMonDolar, 2)), 2));
            }
            else
            {
                MessageBox.Show(cRpta, "Error al Extraer El Saldo Inicial...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SaldoFinal()
        {
            //====================
            //--SALDO FINA SOLES
            //====================
            this.txtSalFinSol.Text = Convert.ToString(Math.Round((Convert.ToDecimal(this.txtSalIniSol.Text) + Convert.ToDecimal(this.txtMonIngSol.Text) - Convert.ToDecimal(this.txtMonEgrSol.Text)), 2));
           
            //====================
            //--SALDO FINA DOLARES
            //====================
            this.txtSalFinDol.Text = Convert.ToString(Math.Round((Convert.ToDecimal (this.txtSalIniDol.Text) + Convert.ToDecimal (this.txtMonIngDol.Text) - Convert.ToDecimal (this.txtMonEgrDol.Text)), 2));
        }

        private void CuadreOpe()
        {
            string msge = "";
            int idUsu = Convert.ToInt32(this.cboColaborador.SelectedValue);
            clsCNControlOpe CuadreOpe = new clsCNControlOpe();
            int idTipResCaja = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);
            //=====================================================================
            //---Ingresos en Soles
            //=====================================================================
            tbIngSol = CuadreOpe.ConsultaCuadreOpe(Convert.ToDateTime(this.dtpProceso.Value.ToShortDateString()), idUsu, 1, clsVarGlobal.nIdAgencia, 1, 1, ref msge, idTipResCaja);
            if (msge == "OK")
            {
                this.dtgIngSoles.DataSource = tbIngSol;
                if (tbIngSol.Rows.Count > 0)
                {
                    this.txtMonIngSol.Text = tbIngSol.Rows[0]["nTotal"].ToString();
                    this.btnImprimir.Enabled = true;
                    this.btnImprimir1.Enabled = true;
                    this.btnImprimir2.Enabled = idTipResCaja == 3 ? true : false;
                }
            }
            else
            {
                MessageBox.Show(msge, "Error al Extraer Datos de las Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //=====================================================================
            //---Egresos en Soles
            //=====================================================================
            tbEgrSol = CuadreOpe.ConsultaCuadreOpe(Convert.ToDateTime(this.dtpProceso.Value.ToShortDateString()), idUsu, 1, clsVarGlobal.nIdAgencia, 2, 1, ref msge, idTipResCaja);
            if (msge == "OK")
            {
                this.dtgEgrSoles.DataSource = tbEgrSol;
                if (tbEgrSol.Rows.Count > 0)
                {
                    this.txtMonEgrSol.Text = tbEgrSol.Rows[0]["nTotal"].ToString();
                    this.btnImprimir.Enabled = true;
                    this.btnImprimir1.Enabled = true;
                    this.btnImprimir2.Enabled = idTipResCaja == 3 ? true : false;
                }
            }
            else
            {
                MessageBox.Show(msge, "Error al Extraer Datos de las Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //=====================================================================
            //---Ingresos en Dolares
            //=====================================================================
            tbIngDol = CuadreOpe.ConsultaCuadreOpe(Convert.ToDateTime(this.dtpProceso.Value.ToShortDateString()), idUsu, 2, clsVarGlobal.nIdAgencia, 1, 1, ref msge, idTipResCaja);
            if (msge == "OK")
            {
                this.dtgIngDolares.DataSource = tbIngDol;
                if (tbIngDol.Rows.Count > 0)
                {
                    this.txtMonIngDol.Text = tbIngDol.Rows[0]["nTotal"].ToString();
                    this.btnImprimir.Enabled = true;
                    this.btnImprimir1.Enabled = true;
                    this.btnImprimir2.Enabled = idTipResCaja == 3 ? true : false;
                }
            }
            else
            {
                MessageBox.Show(msge, "Error al Extraer Datos de las Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //=====================================================================
            //---Ingresos en Dolares
            //=====================================================================
            tbEgrDol = CuadreOpe.ConsultaCuadreOpe(Convert.ToDateTime(this.dtpProceso.Value.ToShortDateString()), idUsu, 2, clsVarGlobal.nIdAgencia, 2, 1, ref msge, idTipResCaja);
            if (msge == "OK")
            {
                this.dtgEgrDolares.DataSource = tbEgrDol;
                if (tbEgrDol.Rows.Count > 0)
                {
                    this.txtMonEgrDol.Text = tbEgrDol.Rows[0]["nTotal"].ToString();
                    this.btnImprimir.Enabled = true;
                    this.btnImprimir1.Enabled = true;
                    this.btnImprimir2.Enabled = idTipResCaja == 3 ? true : false;
                }
            }
            else
            {
                MessageBox.Show(msge, "Error al Extraer Datos de las Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbcCieOpe_Click(object sender, EventArgs e)
        {
            if (this.cboColaborador.SelectedIndex < 0)
            {
                return;
            }
            //FormatoGridDol();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            DateTime dFecha = Convert.ToDateTime(this.dtpProceso.Value.ToShortDateString());
            int idUsu = Convert.ToInt32(this.cboColaborador.SelectedValue);
            int idAge = clsVarGlobal.nIdAgencia;
            int idTipOpeCaj = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);

            dtslist.Add(new ReportDataSource("dsResOpeSolIng", tbIngSol));
            dtslist.Add(new ReportDataSource("dsResOpeSolEgr", tbEgrSol));
            dtslist.Add(new ReportDataSource("dsResOpeDolEgr", tbEgrDol));
            dtslist.Add(new ReportDataSource("dsResOpeDolIng", tbIngDol));

            string cTipResCaj = cTipoRespobsaleCaja(idTipOpeCaj);
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cTipResCaj", cTipResCaj, false));
            paramlist.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToShortDateString(), false));

            paramlist.Add(new ReportParameter("nSalIniSol", txtSalIniSol.Text, false));
            paramlist.Add(new ReportParameter("nSalFinSol", txtSalFinSol.Text, false));
            paramlist.Add(new ReportParameter("nSalIniDol", txtSalIniDol.Text, false));
            paramlist.Add(new ReportParameter("nSalFinDol", txtSalFinDol.Text, false));

            string reportpath = "rptResOpeConsultaCaj.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

            this.btnImprimir.Enabled = true;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (this.cboColaborador.SelectedIndex < 0)
            {
                MessageBox.Show("Debe Seleccionar un Colaborador", "Consultar Cierre Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(this.cboColaborador.SelectedValue.ToString().Trim()))
            {
                MessageBox.Show("Debe Seleccionar un Colaborador", "Consultar Cierre Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //--Reiniciar Valores
            this.Limpiar();
            //---Procesar Consulta
            this.btnImprimir.Enabled = false;
            this.btnImprimir1.Enabled = false;

            ActualizarCierre();
            tbcCieOpe.SelectedIndex = 1;
            FormatoGridDol();
            tbcCieOpe.SelectedIndex = 0;

            //if (ValidarInicioOpeCaja() == "C")
            //{
            //    btnImprimir1.Enabled = true;
            //    btnImprimir.Enabled = true;

            //}
            //else
            //{
            //    btnImprimir1.Enabled = false;
            //    btnImprimir.Enabled = false;
            //}

        }
        public string ValidarInicioOpeCaja()
        {
            clsCNControlOpe ValidaOpe = new clsCNControlOpe();
            int idTipResCaj = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);
            string cEstCie = ValidaOpe.ValidaIniOpeCaja(clsVarGlobal.dFecSystem, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()), clsVarGlobal.nIdAgencia, idTipResCaj);
            // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada
            //string cRpta = this.ValidarInicioOpe();
            switch (cEstCie) // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada  
            {
                case "F":
                    MessageBox.Show("Falta realizar el inicio de Operaciones \n dirigirse al modulo de caja", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Dispose();
                    break;
                case "A":
                    break;
                case "C":
                    MessageBox.Show("El usuario ya cerró sus operaciones", "Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Dispose();
                    break;
                default:
                    MessageBox.Show(cEstCie, "Error al Validar Estado de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //this.Dispose();
                    break;
            }
            return cEstCie;
        }
        private void Limpiar()
        {
            this.txtSalIniSol.Text = "0.00";
            this.txtMonIngSol.Text = "0.00";
            this.txtMonEgrSol.Text = "0.00";
            this.txtSalFinSol.Text = "0.00";
            this.txtCortSoles.Text = "0.00";
            this.txtDifSoles.Text = "0.00";
            this.txtSalIniDol.Text = "0.00";
            this.txtMonIngDol.Text = "0.00";
            this.txtMonEgrDol.Text = "0.00";
            this.txtSalFinDol.Text = "0.00";
            this.txtCorDolar.Text = "0.00";
            this.txtDifDolar.Text = "0.00";
        }
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFecha = this.dtpProceso.Value;
            int idUsu = Convert.ToInt32(this.cboColaborador.SelectedValue);
            int idAge = clsVarGlobal.nIdAgencia;
            
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            int idTipResCaj = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);
            dtslist.Add(new ReportDataSource("dsKardex", new clsRPTCNCaja().CNDetallOperaciones(dFecha, idUsu, idAge, idTipResCaj)));

            bool lFiltroRSC = false;

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("dFecOpe", dFecha.ToString(), false));
            paramlist.Add(new ReportParameter("idUsu", idUsu.ToString(), false));
            paramlist.Add(new ReportParameter("idAge", idAge.ToString(), false));
            paramlist.Add(new ReportParameter("lFiltroRSC", lFiltroRSC.ToString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"].ToString(), false));

            string reportpath = "rptDetalleOpe.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

            this.btnImprimir1.Enabled = true;
        }

        private void cboColaborador_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnImprimir.Enabled = false;
            this.btnImprimir1.Enabled = false;
            this.Limpiar();
            limpiarGrid();
        }
        public string cTipoRespobsaleCaja(int idTipResCaj)
        {
            string cTipResCaj = "";
            switch (idTipResCaj)
            {
                case 1:
                    cTipResCaj = "Ventanilla";
                    break;
                case 2:
                    cTipResCaj = "Caja pulmón";
                    break;
                case 3:
                    cTipResCaj = "Bóveda";
                    break;
            }
            return cTipResCaj;
        }
        private void btnImprimir2_Click(object sender, EventArgs e)
        {
            //    if (ValidaRespBoveda() != 3)
            //    {
            //        MessageBox.Show("Ud. No es Responsable de Boveda", "Validar Responsable de Boveda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        this.btnImprimir2.Enabled = false;
            //        return;
            //    }
            //    int         idAge     = clsVarGlobal.nIdAgencia;
            //    DateTime    dFecha    = this.dtpProceso.Value;
            //    DateTime    dFechaSis = clsVarGlobal.dFecSystem.Date;
            //    String      cNomAgen  = clsVarGlobal.cNomAge;
            //    String      cRutLogo  = clsVarApl.dicVarGen["CRUTALOGO"]; 

            //    clsRPTCNCaja RPTMov = new clsRPTCNCaja();

            //    DataTable dtMovOpeBov = RPTMov.CNSaldosMovBoveda(dFecha, idAge);

            //    List<ReportDataSource> dtslist = new List<ReportDataSource>();

            //    dtslist.Add(new ReportDataSource("dsOperaBoveda", dtMovOpeBov));

            //    List<ReportParameter> paramlist = new List<ReportParameter>();
            //    paramlist.Add(new ReportParameter("dFechaOpe", dFecha.ToString(), false));            
            //    paramlist.Add(new ReportParameter("idAge", idAge.ToString(), false));
            //    paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen.ToString(), false));
            //    paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString(), false));
            //    paramlist.Add(new ReportParameter("x_cRutLogo", cRutLogo.ToString(), false));


            //    string reportpath = "rptDetalleOpeBoveda.rdlc";
            //    new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

            //    this.btnImprimir2.Enabled = true;
        }
        private int ValidaRespBoveda()
        {
            clsCNControlOpe ValidaResBov = new clsCNControlOpe();
            int idTipResCaj = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);
            DateTime dfecPorceso = dtpProceso.Value;
            //// Si nValUsu es: 0--> usuario no Es Responsable de ventanilla, caja pulmón o Bóveda
            ////                1-->resonsable de ventanilla
            ////                2-->resonsable de caja pulmón
            ////                3-->resonsable de Bóveda
            DataTable dtResBov = ValidaResBov.RetRespBoveda(Convert.ToInt32(this.txtCodUsu.Text.Trim().ToString()), clsVarGlobal.nIdAgencia, idTipResCaj, dfecPorceso);

            pnCantidad = dtResBov.Rows.Count;

            if (pnCantidad == 0)
            {
                return 0;
            }
            return Convert.ToInt32(dtResBov.Rows[0]["idTipResCaj"].ToString());

        }

        private void cboTipResponsableCaja1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)cboTipResponsableCaja1.DataSource;
            if (dt.Rows.Count > 0)
            {
                string cTxtTipResCaj = cboTipResponsableCaja1.SelectedValue.ToString();
                if (cboTipResponsableCaja1.SelectedIndex > -1 && !cTxtTipResCaj.Equals("System.Data.DataRowView"))
                {
                    string idTipResCaj = cboTipResponsableCaja1.SelectedValue.ToString();
                    ListarColAgencia(idTipResCaj, clsVarGlobal.nIdAgencia);
                    cboColaborador.SelectedValue = clsVarGlobal.User.idUsuario;

                }
            }
            else
            {
                cboColaborador.DataSource=null;
            }          
            limpiarGrid();
        }
        private void limpiarGrid()
        {
            DataTable dtIngSol;
            dtIngSol = (DataTable)dtgIngSoles.DataSource;
            if (dtIngSol != null)
            {
                dtgIngSoles.DataSource = dtIngSol.Clone();
            }
            DataTable dtEgrSol;
            dtEgrSol = (DataTable)dtgEgrSoles.DataSource;
            if (dtEgrSol != null)
            {
                dtgEgrSoles.DataSource = dtEgrSol.Clone();
            }
            DataTable dtIngDol;
            dtIngDol = (DataTable)dtgIngDolares.DataSource;
            if (dtIngDol != null)
            {
                dtgIngDolares.DataSource = dtIngDol.Clone();
            }
            DataTable dtEgrDol;
            dtEgrDol = (DataTable)dtgEgrDolares.DataSource;
            if (dtEgrDol != null)
            {
                dtgEgrDolares.DataSource = dtEgrDol.Clone();
            }
        }

        private void dtpProceso_ValueChanged(object sender, EventArgs e)
        {
            DateTime dFecOperacion = dtpProceso.Value;
            cboTipResponsableCaja1.cargarTipoResponsableCajaOpe(clsVarGlobal.nIdAgencia, dFecOperacion);

            cboTipResponsableCaja1_SelectedIndexChanged(sender, e);

        }
    }
}
