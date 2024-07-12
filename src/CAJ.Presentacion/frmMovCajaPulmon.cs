using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using EntityLayer;
using CAJ.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using GEN.CapaNegocio;


namespace CAJ.Presentacion
{
    public partial class frmMovCajaPulmon : frmBase
    {
        #region  variables
        //================================================
        //--Declarar variables Publicas
        //================================================
        public DataTable tbIngSol;
        public DataTable tbEgrSol;
        public DataTable tbIngDol;
        public DataTable tbEgrDol;
        int pnCantidad = 0;
        clsCNControlOpe ValidaOpe = new clsCNControlOpe();
        #endregion

        public frmMovCajaPulmon()
        {
            InitializeComponent();
        }

        private void frmMovCajaPulmon_Load(object sender, EventArgs e)
        {

            DatosUsuario();
            if (string.IsNullOrEmpty(this.txtCodUsu.Text.Trim()))
            {
                MessageBox.Show("No Existe Usuario", "Validar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
                return;
            }
            //===========================================================================================
            //--Validar responsable de Operaciones se boveda
            //===========================================================================================         
            if (ValidaRespCaja() == 0)
            {
                MessageBox.Show("Ud. no es responsable de Caja pulmón", "Validar Responsable de Boveda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
                return;
            }
            dtpProceso.Value = clsVarGlobal.dFecSystem;
            cboTipResponsableCaja1.cargarTipoResponsableCajaAdm(clsVarGlobal.nIdAgencia);
            cboTipResponsableCaja1.SelectedValue = 2;
            cboTipResponsableCaja1.Enabled = false;


            int idTipResCaj = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);
            string cEstCie = ValidaOpe.ValidaIniOpeCaja(clsVarGlobal.dFecSystem, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()), clsVarGlobal.nIdAgencia, idTipResCaj);

            if (cEstCie == "F")
            {
                MessageBox.Show("Falta realizar el inicio de Operaciones del responsable de caja pulmón", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
                return;
            }

            //valida inicio de operaciones de boveda
            string cEstCieB = ValidaOpe.CNValidarIniOpeBov(clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia, 3);

            if (cEstCieB == "F")
            {
                MessageBox.Show("Falta realizar el inicio de Operaciones del responsable de bóveda", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
                return;
            }
            //--Validar si ya Realizó su corte Fraccionario
            if (ValidarCorteFracc() == "ERROR")
            {
                this.Dispose();
                return;
            }
            if (VerificaCierreOpe() != "OK")
            {
                //this.Dispose();
                return;
            }
           

            des_HabilitaObjeto(true, 0);
        }
        #region Metodos
        private int ValidaRespCaja()
        {
            clsCNControlOpe ValidaResBov = new clsCNControlOpe();
            int idTipoResCaja = 2;
            //// Si nValUsu es: 0--> usuario no Es Responsable de ventanilla, caja pulmón o Bóveda
            ////                1-->resonsable de ventanilla
            ////                2-->resonsable de caja pulmón
            ////                3-->resonsable de Bóveda
            DataTable dtResBov = ValidaResBov.RetRespBoveda(Convert.ToInt32(this.txtCodUsu.Text.Trim().ToString()), clsVarGlobal.nIdAgencia, idTipoResCaja, clsVarGlobal.dFecSystem);

            pnCantidad = dtResBov.Rows.Count;

            if (pnCantidad == 0)
            {
                return 0;
            }

            return Convert.ToInt32(dtResBov.Rows[0]["idTipResCaj"].ToString());

        }
        private string VerificaCierreOpe()
        {
            string cRpta = "";
            clsCNControlOpe ValCieOpe = new clsCNControlOpe();
            string msg = "";
            DataTable tbvalcierre = ValCieOpe.ValidarCierreOpe(this.dtpProceso.Value, clsVarGlobal.nIdAgencia, ref msg);
            if (msg == "OK")
            {
                if (tbvalcierre.Rows.Count > 0)
                {
                    if (tbvalcierre.Rows.Count == 1)
                    {

                        if (tbvalcierre.Rows[0]["idTipResCaj"].ToString().Equals("2"))
                        {
                            cRpta = "OK";
                        }
                        else
                        {
                            cRpta = "FALTA QUE CIERREN CAJA: " + cRpta  + cTipoREesCaj(tbvalcierre.Rows[0]["idTipResCaj"].ToString()) ;
                            MessageBox.Show(cRpta, "Validar Cierre de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < tbvalcierre.Rows.Count; i++)
                        {
                            if (!tbvalcierre.Rows[i]["idTipResCaj"].ToString().Equals("2"))
                            {
                                cRpta = cRpta + tbvalcierre.Rows[i]["cNombre"].ToString() + cTipoREesCaj(tbvalcierre.Rows[i]["idTipResCaj"].ToString()) + " ;";
                            }
                        }
                        cRpta = "FALTA QUE CIERREN CAJA: " + cRpta;
                        MessageBox.Show(cRpta, "Validar Cierre de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    cRpta = "OK";
                }
            }
            return cRpta;
        }
        private string cTipoREesCaj(string idTipResCaj)
        {
            string cMensaje = "";
            if (idTipResCaj.Equals("1"))
            {
                cMensaje = " (Ventanilla) ";
            }
            if (idTipResCaj.Equals("2"))
            {
                cMensaje = " (Caja pulmón) ";
            }
            if (idTipResCaj.Equals("3"))
            {
                cMensaje = " (Bóveda) ";
            }
            return cMensaje;
        }
        private void ValorInicial()
        {
            this.txtSalIniSol.Text = "0.00";
            this.txtMonIngSol.Text = "0.00";
            this.txtMonEgrSol.Text = "0.00";
            this.txtSalFinSol.Text = "0.00";
            this.txtSalIniDol.Text = "0.00";
            this.txtMonIngDol.Text = "0.00";
            this.txtMonEgrDol.Text = "0.00";
            this.txtSalFinDol.Text = "0.00";
            this.txtDifSoles.Text = "0.00";
            this.txtDifDolar.Text = "0.00";
            this.txtCortSoles.Text = "0.00";
            this.txtCorDolar.Text = "0.00";
        }
        private void SaldoCorteFraccionario()
        {
            Decimal nMonSoles = 0.00m, nMonDolar = 0.00m;
            clsCNControlOpe SalCorteFrac = new clsCNControlOpe();
            int idTipResCaj = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);
            string cRpta = SalCorteFrac.RetMontoCorFracc(this.dtpProceso.Value, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, ref nMonSoles, ref nMonDolar, idTipResCaj);
            if (cRpta == "OK")
            {
                this.txtCortSoles.Text = nMonSoles.ToString();
                this.txtCorDolar.Text = nMonDolar.ToString();
                this.txtDifSoles.Text = Convert.ToString(Math.Round((Math.Round(nMonSoles, 2) - Math.Round(Convert.ToDecimal (this.txtSalFinSol.Text), 2)), 2));
                this.txtDifDolar.Text = Convert.ToString(Math.Round((Math.Round(nMonDolar, 2) - Math.Round(Convert.ToDecimal (this.txtSalFinDol.Text), 2)), 2));
                //=========================================================================
                //-----Validar Cierre de Operaciones en Soles
                //=========================================================================
                Decimal nDifSol = Math.Round(Convert.ToDecimal (this.txtDifSoles.Text), 2);
                if (nDifSol == 0)
                {
                    this.lblSoles.Text = "CIERRE EN SOLES OK...";
                    this.lblSoles.ForeColor = Color.Blue;
                }
                else
                {
                    if (nDifSol > 0)
                    {
                        this.lblSoles.Text = "EXISTE DIFERENCIAS, VERIFICAR!!! (Emitir Recibo de INGRESO por SOBRANTE)";
                        this.lblSoles.ForeColor = Color.Red;
                    }
                    else
                    {
                        this.lblSoles.Text = "EXISTE DIFERENCIAS, VERIFICAR!!! (Emitir Recibo de EGRESO por FALTANTE)";
                        this.lblSoles.ForeColor = Color.Red;
                    }
                }

                //=========================================================================
                //-----Validar Cierre de Operaciones en Dólares
                //=========================================================================
                Decimal nDifDol = Math.Round(Convert.ToDecimal (this.txtDifDolar.Text), 2);
                if (nDifDol == 0)
                {
                    this.lblDolar.Text = "CIERRE EN DÓLARES OK...";
                    this.lblDolar.ForeColor = Color.Blue;
                }
                else
                {
                    if (nDifDol > 0)
                    {
                        this.lblDolar.Text = "EXISTE DIFERENCIAS, VERIFICAR!!! (Emitir Recibo de INGRESO por SOBRANTE)";
                        this.lblDolar.ForeColor = Color.Red;
                    }
                    else
                    {
                        this.lblDolar.Text = "EXISTE DIFERENCIAS, VERIFICAR!!! (Emitir Recibo de EGRESO por FALTANTE)";
                        this.lblDolar.ForeColor = Color.Red;
                    }
                }

            }
            else
            {
                MessageBox.Show(cRpta, "Error al Extraer El Saldo Inicial...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string ValidarCorteFracc()
        {
            string cRpta = "OK";

            clsCNControlOpe ValCorFra = new clsCNControlOpe();
            int idTipResCaja = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);
            //string cCorFra = ValCorFra.ValidaCorteFracc(this.dtpFechaSis.Value, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()), clsVarGlobal.nIdAgencia, ref msge, idTipResCaja);
            string cCorFra = ValCorFra.ValidaCorteFraccCaja(this.dtpFechaSis.Value, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()), clsVarGlobal.nIdAgencia, idTipResCaja);

            if (cCorFra == "0")
            {
                MessageBox.Show("Primero debe realizar su billetaje... por Favor..", "Validar billetaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cRpta = "ERROR";
            }

            return cRpta;
        }

        private int ValidaRespBoveda()
        {

            clsCNControlOpe ValidaResBov = new clsCNControlOpe();
            //string cValUsu = ValidaResBov.RetRespBoveda(Convert.ToInt32(this.txtCodUsu.Text.Trim().ToString()), clsVarGlobal.nIdAgencia);
            int idTipoResCaja = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);

            //// Si nValUsu es: 0--> usuario no Es Responsable de ventanilla, caja pulmón o Bóveda
            ////                1-->resonsable de ventanilla
            ////                2-->resonsable de caja pulmón
            ////                3-->resonsable de Bóveda
            DataTable dtResBov = ValidaResBov.RetRespBoveda(Convert.ToInt32(this.txtCodUsu.Text.Trim().ToString()), clsVarGlobal.nIdAgencia, idTipoResCaja, clsVarGlobal.dFecSystem);

            pnCantidad = dtResBov.Rows.Count;

            if (pnCantidad == 0)
            {
                return 0;
            }
            return Convert.ToInt32(dtResBov.Rows[0]["idTipResCaj"].ToString());
        }
        private void DatosUsuario()
        {
            this.dtpFechaSis.Value = clsVarGlobal.dFecSystem;
            this.txtCodUsu.Text = clsVarGlobal.User.idUsuario.ToString();
            this.txtUsuario.Text = clsVarGlobal.User.cWinUser;

            this.dtpProceso.Enabled = true;

            int nidCli = Convert.ToInt32(clsVarGlobal.User.idCli);
            clsCNRetDatosCliente RetDatCli = new clsCNRetDatosCliente();
            DataTable DatosCli = RetDatCli.ListarDatosCli(nidCli, "D");
            if (DatosCli.Rows.Count > 0)
            {
                this.txtNomUsu.Text = DatosCli.Rows[0]["cNombre"].ToString();
            }
            else
            {
                this.txtNomUsu.Text = "";
            }
        }
        private void des_HabilitaObjeto(bool valor, int opcion)
        {
            btnCancelar.Enabled = !valor;
            btnGrabar.Enabled = !valor;
            btnProcesar.Enabled = valor;
            //cuando se inicia
            if (opcion == 0)
            {
                btnImprimir.Enabled = !valor;
                btnTransferir.Enabled = !valor;
            }
            //cuando se Graba o Existe Movimiento
            if (opcion == 2)
            {
                btnImprimir.Enabled = valor;

            }
        }
        private void FormatoGrid()
        {
            //--Formato Grid Ingreso Soles
            this.dtgIngSoles.Columns["idTipoOperacion"].Visible = false;
            this.dtgIngSoles.Columns["cTipoOperacion"].Width = 250;
            this.dtgIngSoles.Columns["cTipoOperacion"].HeaderText = "Tipo Operación";
            this.dtgIngSoles.Columns["nMontoOperacion"].Width = 120;
            this.dtgIngSoles.Columns["nMontoOperacion"].HeaderText = "Total Operación";
            this.dtgIngSoles.Columns["nCantidad"].HeaderText = "Cant.";
            this.dtgIngSoles.Columns["nCantidad"].Width = 40;


            //--Formato Grid Egreso Soles
            this.dtgEgrSoles.Columns["idTipoOperacion"].Visible = false;
            this.dtgEgrSoles.Columns["cTipoOperacion"].Width = 250;
            this.dtgEgrSoles.Columns["cTipoOperacion"].HeaderText = "Tipo Operación";
            this.dtgEgrSoles.Columns["nMontoOperacion"].Width = 120;
            this.dtgEgrSoles.Columns["nMontoOperacion"].HeaderText = "Total Operación";
            this.dtgEgrSoles.Columns["nCantidad"].HeaderText = "Cant.";
            this.dtgEgrSoles.Columns["nCantidad"].Width = 40;
        }
        private void FormatoGridDol()
        {
            this.tbcMovCaja.SelectedIndex = 1;
            //--Formato Grid Ingreso Dólares
            this.dtgIngDolares.Columns["idTipoOperacion"].Visible = false;
            this.dtgIngDolares.Columns["nCantidad"].HeaderText = "Cant.";
            this.dtgIngDolares.Columns["nCantidad"].Width = 40;
            this.dtgIngDolares.Columns["cTipoOperacion"].HeaderText = "Tipo Operación";
            this.dtgIngDolares.Columns["nMontoOperacion"].HeaderText = "Total Operación";

            //--Formato Grid Egreso Dólares
            this.dtgEgrDolares.Columns["idTipoOperacion"].Visible = false;
            this.dtgEgrDolares.Columns["cTipoOperacion"].HeaderText = "Tipo Operación";
            this.dtgEgrDolares.Columns["nMontoOperacion"].HeaderText = "Total Operación";
            this.dtgEgrDolares.Columns["nCantidad"].HeaderText = "Cant.";
            this.dtgEgrDolares.Columns["nCantidad"].Width = 40;

            this.tbcMovCaja.SelectedIndex = 0;
        }
        private void SalIniOpe()
        {
            string msge = "";
            int idUsu = Convert.ToInt32(this.txtCodUsu.Text);
            clsCNControlOpe saldoIniOpe = new clsCNControlOpe();
            int idTipResCaj = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);


            //=====================================================================
            //---Ingresos en Soles
            //=====================================================================

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
        private void CuadreOpe()
        {
            string msge = "";
            int idUsu = Convert.ToInt32(this.txtCodUsu.Text);
            int idTipResCaj = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);


            clsCNControlOpe CuadreOpe = new clsCNControlOpe();
            //=====================================================================
            //---Ingresos en Soles
            //=====================================================================
            tbIngSol = CuadreOpe.MovCajaPulmonBoveda(Convert.ToDateTime(this.dtpProceso.Value.ToShortDateString()), idUsu, 1, clsVarGlobal.nIdAgencia, 1, idTipResCaj, ref msge);
            if (msge == "OK")
            {
                this.dtgIngSoles.DataSource = tbIngSol;
                this.txtMonIngSol.Text = "0.00";
                if (tbIngSol.Rows.Count > 0)
                {
                    this.txtMonIngSol.Text = tbIngSol.Compute("Sum(nMontoOperacion)", "").ToString();
                    this.btnImprimir.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show(msge, "Error al Extraer Datos de las Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //=====================================================================
            //---Egresos en Soles
            //=====================================================================
            tbEgrSol = CuadreOpe.MovCajaPulmonBoveda(Convert.ToDateTime(this.dtpProceso.Value.ToShortDateString()), idUsu, 1, clsVarGlobal.nIdAgencia, 2, idTipResCaj, ref msge);
            if (msge == "OK")
            {
                this.dtgEgrSoles.DataSource = tbEgrSol;
                this.txtMonEgrSol.Text = "0.00";
                if (tbEgrSol.Rows.Count > 0)
                {
                    this.txtMonEgrSol.Text = tbEgrSol.Compute("Sum(nMontoOperacion)", "").ToString();
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
            tbIngDol = CuadreOpe.MovCajaPulmonBoveda(Convert.ToDateTime(this.dtpProceso.Value.ToShortDateString()), idUsu, 2, clsVarGlobal.nIdAgencia, 1, idTipResCaj, ref msge);
            if (msge == "OK")
            {
                this.dtgIngDolares.DataSource = tbIngDol;
                this.txtMonIngDol.Text = "0.00";
                if (tbIngDol.Rows.Count > 0)
                {
                    this.txtMonIngDol.Text = tbIngDol.Compute("Sum(nMontoOperacion)", "").ToString();
                    this.btnImprimir.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show(msge, "Error al Extraer Datos de las Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //=====================================================================
            //---engresos en Dolares
            //=====================================================================
            tbEgrDol = CuadreOpe.MovCajaPulmonBoveda(Convert.ToDateTime(this.dtpProceso.Value.ToShortDateString()), idUsu, 2, clsVarGlobal.nIdAgencia, 2, idTipResCaj, ref msge);
            if (msge == "OK")
            {
                this.dtgEgrDolares.DataSource = tbEgrDol;
                if (tbEgrDol.Rows.Count > 0)
                {
                    this.txtMonEgrDol.Text = tbEgrDol.Compute("Sum(nMontoOperacion)", "").ToString();
                    this.btnImprimir.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show(msge, "Error al Extraer Datos de las Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaldoFinal()
        {
            //====================
            //--SALDO FINA SOLES
            //====================
            this.txtSalFinSol.Text = Convert.ToString(Math.Round((Convert.ToDecimal (this.txtSalIniSol.Text) + Convert.ToDecimal (this.txtMonIngSol.Text) - Convert.ToDecimal (this.txtMonEgrSol.Text)), 2));
            //====================
            //--SALDO FINA DOLARES
            //====================
            this.txtSalFinDol.Text = Convert.ToString(Math.Round((Convert.ToDecimal (this.txtSalIniDol.Text) + Convert.ToDecimal (this.txtMonIngDol.Text) - Convert.ToDecimal (this.txtMonEgrDol.Text)), 2));
        }
        #endregion
        #region Evento



        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //===================================================================
            //--Validar Datos del Cuadre
            //===================================================================          
            if (Convert.ToDecimal (this.txtSalFinSol.Text) < 0)
            {
                MessageBox.Show("El Saldo Final en SOLES NO Puede ser NEGATIVO: VERIFICAR...", "Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToDecimal (this.txtSalFinDol.Text) < 0)
            {
                MessageBox.Show("El Saldo Final en DÓLARES, NO Puede ser NEGATIVO: VERIFICAR...", "Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToDecimal (this.txtDifSoles.Text) != 0)
            {
                MessageBox.Show("Existe Diferencia en SOLES entre el BILLETAJE y CUADRE CAJA.. VERIFICAR...", "Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToDecimal (this.txtDifDolar.Text) != 0)
            {
                MessageBox.Show("Existe Diferencia en DOLARES entre el BILLETAJE y CUADRE CAJA.. VERIFICAR...", "Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           
            //================================================
            //--Valida si Tiene habilitaciones Pendientes
            //================================================
            clsCNControlOpe ValHabPen = new clsCNControlOpe();
            string cRptahabpen = ValHabPen.ValidaHabPendientes(this.dtpFechaSis.Value, Convert.ToInt32(this.txtCodUsu.Text), clsVarGlobal.nIdAgencia, 1,2);
            if (Convert.ToInt32(cRptahabpen) > 0)
            {
                MessageBox.Show("No puede Cerrar porque Tiene Habilitaciones Pendientes por APROBAR o RECHAZAR...", "Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //================================================
            //--Valida si Tiene Habilitaciones Generadas
            //================================================
            clsCNControlOpe ValHabGen = new clsCNControlOpe();
            string cRptaHabGen = ValHabGen.ValidaHabPendientes(this.dtpFechaSis.Value, Convert.ToInt32(this.txtCodUsu.Text), clsVarGlobal.nIdAgencia, 2,2);
            if (Convert.ToInt32(cRptaHabGen) > 0)
            {
                MessageBox.Show("No puede Cerrar porque Tiene Habilitaciones GENERADAS...", "Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


          

            var Msg = MessageBox.Show("Esta Seguro de Registrar y Realizar el Cierre de " + grbMovimiento.Text + "?...", "Registrar " + grbMovimiento.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Msg == DialogResult.No)
            {
                return;
            }
            //===================================================================
            //Guardar Datos Ingreso soles Mediante XML
            //===================================================================          
            DataSet dsIngSol = new DataSet("dsIngSol");
            dsIngSol.Tables.Add(tbIngSol);
            string xmlIngSol = dsIngSol.GetXml();
            xmlIngSol = clsCNFormatoXML.EncodingXML(xmlIngSol);
            dsIngSol.Tables.Clear();

            //===================================================================
            //Guardar Datos Egreso soles Mediante XML
            //===================================================================          
            DataSet dsEgrSol = new DataSet("dsEgrSol");
            dsEgrSol.Tables.Add(tbEgrSol);
            string xmlEgrSol = dsEgrSol.GetXml();
            xmlEgrSol = clsCNFormatoXML.EncodingXML(xmlEgrSol);
            dsEgrSol.Tables.Clear();

            //===================================================================
            //Guardar Datos Ingreso Dol Mediante XML
            //===================================================================          
            DataSet dsIngDol = new DataSet("dsIngDol");
            dsIngDol.Tables.Add(tbIngDol);
            string xmlIngDol = dsIngDol.GetXml();
            xmlIngDol = clsCNFormatoXML.EncodingXML(xmlIngDol);
            dsIngDol.Tables.Clear();

            //===================================================================
            //Guardar Datos Egreso Dol Mediante XML
            //===================================================================          
            DataSet dsEgrDol = new DataSet("dsEgrDol");
            dsEgrDol.Tables.Add(tbEgrDol);
            string xmlEgrDol = dsEgrDol.GetXml();
            xmlEgrDol = clsCNFormatoXML.EncodingXML(xmlEgrDol);
            dsEgrDol.Tables.Clear();

            //==================================================
            //--Grabar Cuadre Operaciones
            //==================================================
            Decimal nSalIniSol = Convert.ToDecimal (this.txtSalIniSol.Text);
            Decimal nSalIniDol = Convert.ToDecimal (this.txtSalIniDol.Text);
            Decimal nSalFinSol = Convert.ToDecimal (this.txtSalFinSol.Text);
            Decimal nSalFinDol = Convert.ToDecimal (this.txtSalFinDol.Text);

            int idTipResCaja = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);// 1:movimiento Caja Pulmon 2:Movimiento Boveda

            //==================================================
            //--Grabar movimiento Caja Pulmon - Boveda
            //==================================================
            clsCNControlOpe RegMovPulBov = new clsCNControlOpe();

            string cRpta = RegMovPulBov.RegCierreOperaciones(this.dtpFechaSis.Value, Convert.ToInt32(this.txtCodUsu.Text), clsVarGlobal.nIdAgencia, idTipResCaja, nSalIniSol, nSalIniDol
                , nSalFinSol, nSalFinDol, xmlIngSol,
                xmlEgrSol, xmlIngDol, xmlEgrDol);



            if (cRpta == "OK")
            {
                MessageBox.Show("Se grabó correctamente el cierre de movimientos de caja pulmón", grbMovimiento.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                des_HabilitaObjeto(true, 2);
                if (idTipResCaja == 2)
                {
                    MessageBox.Show("Proceda a Grabar el Movimiento Boveda, Para Realizar el Cierre de la Agencia", "Movimiento Boveda", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show(cRpta, "Error en Registro de " + grbMovimiento.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            //==================================================
            //--Datos de la Habilitación
            //==================================================

            int nTipMon = this.tbcMovCaja.SelectedIndex == 0 ? 1 : 2;//1:soles 2:dolares            
            int nidUsuOri = Convert.ToInt32(this.txtCodUsu.Text);
            Decimal nMonHab = Convert.ToDecimal (this.tbcMovCaja.SelectedIndex == 0 ? txtSalFinSol.Text : txtSalFinDol.Text);
            if (nTipMon == 1 && Convert.ToDecimal (txtSalFinSol.Text) <= 0 || nTipMon == 2 && Convert.ToDecimal (txtSalFinDol.Text) <= 0)
            {
                MessageBox.Show("El Monto a Transferir Debe Ser Mayor a Cero...", "Transferencia a Boveda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ////==================================================
            ////--Grabar Habilitacion mediante una trasferencia
            ////==================================================
            string msge = "";
            clsCNControlOpe GuardarHab = new clsCNControlOpe();
            string nidHab = GuardarHab.TrasferirHabilitacionBoveda(dtpFechaSis.Value, clsVarGlobal.nIdAgencia, nTipMon, nMonHab, nidUsuOri, ref msge);
            if (msge == "OK")
            {
                MessageBox.Show("La Transferencia se Registro Correctamente, NRO HABILITACION: " + nidHab, "Registro de Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnProcesar_Click(sender, e);
                btnTransferir.Enabled = true;
            }
            else
            {
                MessageBox.Show(msge, "Error al Registrar la Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void rbtBoveda_CheckedChanged(object sender, EventArgs e)
        //{
        //    btnCancelar_Click(sender, e);
        //}

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dFecha = this.dtpProceso.Value;
            int idUsu = clsVarGlobal.User.idUsuario;
            int idAge = clsVarGlobal.nIdAgencia;
            int idTipOpeCaj = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);// 1:movimiento Caja Pulmon 2:Movimiento Boveda

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            string cTipResCaj = cboTipResponsableCaja1.Text;
            cTipResCaj = cTipResCaj.Replace("RESP. DE ", "RESPONSABLE DE ");

            dtslist.Add(new ReportDataSource("rptResumenOpe", new clsRPTCNCaja().CNResumenOpeSol(dFecha, idUsu, idAge, idTipOpeCaj, 1)));
            dtslist.Add(new ReportDataSource("rptResumenDol", new clsRPTCNCaja().CNResumenOpeSol(dFecha, idUsu, idAge, idTipOpeCaj, 2)));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cTipResCaj", cTipResCaj, false));
            string reportpath = "rptResumenOpe.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

            this.btnImprimir.Enabled = true;

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {

            //valida inicio de operaciones de boveda
            string cEstCieB = ValidaOpe.CNValidarIniOpeBov(dtpProceso.Value,  clsVarGlobal.nIdAgencia, 3);
            ValorInicial();
            if (cEstCieB == "F")
            {
                MessageBox.Show("Falta realizar el inicio de Operaciones del responsable de bóveda", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGrabar.Enabled = false;

                return;
            }

            //des_HabilitaObjeto(true, 2);
            CuadreOpe();
            SalIniOpe();
            FormatoGrid();
            FormatoGridDol();

            SaldoFinal();

            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            string cRespIniOpeCaj = ValidarInicioOpeCaja();
            if (cRespIniOpeCaj == "C")
            {
                grbBase1.Visible = false;
                grbBase5.Visible = false;
                lblSoles.Visible = false;
                lblDolar.Visible = false;
                btnGrabar.Enabled = false;
                btnImprimir.Enabled = true;

            }
            else if (cRespIniOpeCaj == "F")
            {
                btnGrabar.Enabled = false;

            }
            else
            {
                //--Saldo de Corte Fraccionario
                SaldoCorteFraccionario();
                grbBase1.Visible = true;
                grbBase5.Visible = true;
                lblSoles.Visible = true;
                lblDolar.Visible = true;
                btnGrabar.Enabled = true;
                btnImprimir.Enabled = false;

            }
            btnCancelar.Enabled = true;
            dtpProceso.Enabled = false;


        }
        public string ValidarInicioOpeCaja()
        {
            int idTipResCaj = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);
            string cEstCie = ValidaOpe.ValidaIniOpeCaja(dtpProceso.Value, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()), clsVarGlobal.nIdAgencia, idTipResCaj);
            // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada
            //string cRpta = this.ValidarInicioOpe();
            switch (cEstCie) // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada  
            {
                case "F":
                    MessageBox.Show("Falta realizar el inicio de Operaciones de caja pulmón", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            des_HabilitaObjeto(true, 0);
            dtpProceso.Enabled = true;
            btnCancelar.Enabled = false;
            this.dtgEgrDolares.DataSource = null;
            this.dtgIngDolares.DataSource = null;
            this.dtgEgrSoles.DataSource = null;
            this.dtgIngSoles.DataSource = null;
            //--Reiniciar Valores
            ValorInicial();
            this.lblSoles.Text = "CIERRE EN SOLES OK...";
            this.lblSoles.ForeColor = Color.Blue;
            this.lblDolar.Text = "CIERRE EN DÓLARES OK...";
            this.lblDolar.ForeColor = Color.Green;
        }

        #endregion
    }
}
