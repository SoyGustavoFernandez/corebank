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
using SPL.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmCierreOperaciones : frmBase
    {
        //================================================
        //--Declarar variables Publicas
        //================================================
        public DataTable tbIngSol;
        public DataTable tbEgrSol;
        public DataTable tbIngDol;
        public DataTable tbEgrDol;
        string mRespValExis = "";
        int pnCantidad = 0;
        int idTipOpeCaj = 1;//solo ventanilla
        
        public frmCierreOperaciones()
        {
            InitializeComponent();
        }

        private void frmCierreOperaciones_Load(object sender, EventArgs e)
        {
            DatosUsuario();
            if (string.IsNullOrEmpty(this.txtCodUsu.Text.Trim()))
            {
                MessageBox.Show("No Existe Usuario", "Validar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
                return;
            }
            //===================================================================
            //--Validar existencia de responsable de boveda
            //===================================================================          

            if (ValidarSiExisteRespBoveda() == 0)
            {
                MessageBox.Show("No Puede Iniciar Su Caja, " + mRespValExis, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
                return;
            }

            //===========================================================================================
            //--Validar responsable de caja
            //===========================================================================================
            int idTipResCaj = ValidaRespBoveda();

            if (idTipResCaj == 0)
            {
                MessageBox.Show("Ud. no es responsable de ventanilla, caja pulmón o bóveda", "Responsable de ventanilla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
                return;
            }
            if (idTipResCaj == 2)
            {
                MessageBox.Show("Ud. es responsable de caja pulmón , Debe usar la \n opción de cierre de caja pulmón", "Responsable de ventanilla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
                return;
            }
            if (idTipResCaj == 3)
            {
                MessageBox.Show("Ud. es responsable de bóveda, Debe usar la \n opción cierre de bóveda", "Responsable de ventanilla", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
                return;
            }
          

            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            if (this.ValidarInicioOpeSoloCaja() != "A")
            {
                this.Dispose();
                return;
            }

            //--Validar si ya Realizó su corte Fraccionario
            if (ValidarCorteFracc() == "ERROR")
            {
                this.Dispose();
                return;
            }
            clsCNControlOpe ValidaOpe = new clsCNControlOpe();
            //valida inicio de operaciones de boveda
            string cEstCie = ValidaOpe.CNValidarIniOpeBov(clsVarGlobal.dFecSystem,clsVarGlobal.nIdAgencia, 3);

            if (cEstCie == "F")
            {
                MessageBox.Show("Falta realizar el inicio de Operaciones del responsable de bóveda", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
                return;
            }
            var msgeCuadreOpe = CuadreOpe();
            if (msgeCuadreOpe != "OK")
            {
                MessageBox.Show(msgeCuadreOpe, "Error al Extraer Datos de las Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnGrabar.Enabled = false;
                return;
            }
            FormatoGrid();
            var msgeSalIniOpe = SalIniOpe();
            if (msgeSalIniOpe != "OK")
            {
                MessageBox.Show(msgeSalIniOpe, "Error al Extraer Datos de las Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnGrabar.Enabled = false;
                return;
            }

            if (!validarCargaSustentoOperaciones())
            {
                this.Dispose();
                return;
            }

            SaldoFinal();
            //--Saldo de Corte Fraccionario
            var msgeSaldoCorteFraccionario = SaldoCorteFraccionario();
            if (msgeSaldoCorteFraccionario != "OK")
            {
                MessageBox.Show(msgeSaldoCorteFraccionario, "Error al Extraer Datos de las Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnGrabar.Enabled = false;
                return;
            }
            //this.tbcCieOpe.TabPages["TabDolares"].Parent = null;
            tbcCieOpe.SelectedIndex = 1;
            FormatoGridDol();
            tbcCieOpe.SelectedIndex = 0;
            this.btnGrabar.Enabled = true;

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
        private string ValidarCorteFracc()
        {
            string cRpta = "OK";

            clsCNControlOpe ValCorFra = new clsCNControlOpe();
            int idTipResCaja = 1; //ventanilla

            string cCorFra = ValCorFra.ValidaCorteFraccCaja(this.dtpFechaSis.Value, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()), clsVarGlobal.nIdAgencia, idTipResCaja);

            if (cCorFra == "0")
            {
                MessageBox.Show("Primero debe realizar su billetaje ... por Favor..", "Validar billetaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cRpta = "ERROR";
            }

            return cRpta;
        }

        private bool validarCargaSustentoOperaciones()
        {
            clsCNBuscaKardex clsKardex = new clsCNBuscaKardex();
            DataTable dt = clsKardex.CNValidaSubidaArchivosSustento(clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
            if (dt.Rows.Count > 0)
            {
                string cMensaje = "";
                foreach (DataRow item in dt.Rows)
                {
                    if (!string.IsNullOrEmpty(item["cSuperaUmbralDolar"].ToString()))
                    {
                        cMensaje += item["IdKardex"].ToString() + ": " + item["cSuperaUmbralDolar"].ToString()+ "\n";
                    }
                    else if (!string.IsNullOrEmpty(item["cSuperaUmbralSoles"].ToString())) 
                    {
                        cMensaje += item["IdKardex"].ToString() + ": " + item["cSuperaUmbralSoles"].ToString() + "\n"; 
                    }
                }

                MessageBox.Show("Operaciones que no tienen carga de archivos: \n" + cMensaje, "Validar Sustento de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }
            
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

        private int ValidarSiExisteRespBoveda()
        {
            clsCNControlOpe ValResBov = new clsCNControlOpe();
            return ValResBov.CNValidarExisRespBoveda(clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, ref mRespValExis);
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
            this.dtgIngSoles.Columns["nMontoOperacion"].DefaultCellStyle.Format = "N2"; //FORMATO
            this.dtgIngSoles.Columns["nCantidad"].HeaderText = "Cant.";
            this.dtgIngSoles.Columns["nCantidad"].Width = 40;
            //--Formato Grid Egreso Soles
            this.dtgEgrSoles.Columns["idTipoOperacion"].Visible = false;
            this.dtgEgrSoles.Columns["nTotal"].Visible = false;
            this.dtgEgrSoles.Columns["cTipoOperacion"].Width = 250;
            this.dtgEgrSoles.Columns["cTipoOperacion"].HeaderText = "Tipo Operación";
            this.dtgEgrSoles.Columns["nMontoOperacion"].Width = 120;
            this.dtgEgrSoles.Columns["nMontoOperacion"].HeaderText = "Total Operación";
            this.dtgEgrSoles.Columns["nMontoOperacion"].DefaultCellStyle.Format = "N2"; //FORMATO
            this.dtgEgrSoles.Columns["nCantidad"].HeaderText = "Cant.";
            this.dtgEgrSoles.Columns["nCantidad"].Width = 40;
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
            this.dtgIngDolares.Columns["nMontoOperacion"].DefaultCellStyle.Format = "N2"; //FORMATO
            this.dtgIngDolares.Columns["nCantidad"].HeaderText = "Cant.";
            this.dtgIngDolares.Columns["nCantidad"].Width = 40;
            //--Formato Grid Egreso Dólares
            this.dtgEgrDolares.Columns["idTipoOperacion"].Visible = false;
            this.dtgEgrDolares.Columns["nTotal"].Visible = false;
            this.dtgEgrDolares.Columns["cTipoOperacion"].Width = 250;
            this.dtgEgrDolares.Columns["cTipoOperacion"].HeaderText = "Tipo Operación";
            this.dtgEgrDolares.Columns["nMontoOperacion"].Width = 120;
            this.dtgEgrDolares.Columns["nMontoOperacion"].HeaderText = "Total Operación";
            this.dtgEgrDolares.Columns["nMontoOperacion"].DefaultCellStyle.Format = "N2"; //FORMATO
            this.dtgEgrDolares.Columns["nCantidad"].HeaderText = "Cant.";
            this.dtgEgrDolares.Columns["nCantidad"].Width = 40;
        }

        private string SalIniOpe()
        {
            string msge = "";
            int idUsu = Convert.ToInt32(this.txtCodUsu.Text);
            clsCNControlOpe saldoIniOpe = new clsCNControlOpe();
            //=====================================================================
            //---Ingresos en Soles y Dólares
            //=====================================================================
            DataTable tbSalIniOpe = saldoIniOpe.SaldoinicialOpe(this.dtpFechaSis.Value, idUsu, clsVarGlobal.nIdAgencia, 1, ref msge);
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
                return msge;
                // MessageBox.Show(msge, "Error al Extraer El Saldo Inicial...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "OK";
        }

        private string SaldoCorteFraccionario()
        {
            Decimal nMonSoles = 0.00m, nMonDolar = 0.00m;
            clsCNControlOpe SalCorteFrac = new clsCNControlOpe();
            int idTipResCaj = 1;
            string cRpta = SalCorteFrac.RetMontoCorFracc(this.dtpFechaSis.Value, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, ref nMonSoles, ref nMonDolar, idTipResCaj);
            if (cRpta == "OK")
            {
                this.txtCortSoles.Text = nMonSoles.ToString();
                this.txtCorDolar.Text = nMonDolar.ToString();
                this.txtDifSoles.Text = Convert.ToString(Math.Round((Math.Round(nMonSoles, 2) - Math.Round(Convert.ToDecimal(this.txtSalFinSol.Text), 2)), 2));
                this.txtDifDolar.Text = Convert.ToString(Math.Round((Math.Round(nMonDolar, 2) - Math.Round(Convert.ToDecimal(this.txtSalFinDol.Text), 2)), 2));
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
                return cRpta;
                //MessageBox.Show(cRpta, "Error al Extraer El Saldo Inicial...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return "OK";
        }


        private void SaldoFinal()
        {
            //====================
            //--SALDO FINA SOLES
            //====================
            this.txtSalFinSol.Text = Convert.ToString(Math.Round((Math.Round(Convert.ToDecimal (this.txtSalIniSol.Text), 2) + Math.Round(Convert.ToDecimal(this.txtMonIngSol.Text), 2) - Math.Round(Convert.ToDecimal(this.txtMonEgrSol.Text), 2)), 2));
            //====================
            //--SALDO FINA DOLARES
            //====================
            this.txtSalFinDol.Text = Convert.ToString(Math.Round((Math.Round(Convert.ToDecimal (this.txtSalIniDol.Text), 2) + Math.Round(Convert.ToDecimal(this.txtMonIngDol.Text), 2) - Math.Round(Convert.ToDecimal(this.txtMonEgrDol.Text), 2)), 2));
        }

        private string CuadreOpe()
        {
            string msge = "";
            int idUsu = Convert.ToInt32(this.txtCodUsu.Text);
            clsCNControlOpe CuadreOpe = new clsCNControlOpe();
            //=====================================================================
            //---Ingresos en Soles
            //=====================================================================
            tbIngSol = CuadreOpe.CuadreOperaciones(this.dtpFechaSis.Value, idUsu, 1, clsVarGlobal.nIdAgencia, 1, ref msge);
            if (msge == "OK")
            {
                this.dtgIngSoles.DataSource = tbIngSol;
                if (tbIngSol.Rows.Count > 0)
                {
                    this.txtMonIngSol.Text = tbIngSol.Rows[0]["nTotal"].ToString();
                }
            }
            else
            {
                //MessageBox.Show(msge, "Error al Extraer Datos de las Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return msge;
            }

            //=====================================================================
            //---Egresos en Soles
            //=====================================================================
            tbEgrSol = CuadreOpe.CuadreOperaciones(this.dtpFechaSis.Value, idUsu, 1, clsVarGlobal.nIdAgencia, 2, ref msge);
            if (msge == "OK")
            {
                this.dtgEgrSoles.DataSource = tbEgrSol;
                if (tbEgrSol.Rows.Count > 0)
                {
                    this.txtMonEgrSol.Text = tbEgrSol.Rows[0]["nTotal"].ToString();
                }
            }
            else
            {
                // MessageBox.Show(msge, "Error al Extraer Datos de las Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return msge;
            }



            //=====================================================================
            //---Ingresos en Dolares
            //=====================================================================
            tbIngDol = CuadreOpe.CuadreOperaciones(this.dtpFechaSis.Value, idUsu, 2, clsVarGlobal.nIdAgencia, 1, ref msge);
            if (msge == "OK")
            {
                this.dtgIngDolares.DataSource = tbIngDol;
                if (tbIngDol.Rows.Count > 0)
                {
                    this.txtMonIngDol.Text = tbIngDol.Rows[0]["nTotal"].ToString();
                }
            }
            else
            {
                //MessageBox.Show(msge, "Error al Extraer Datos de las Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return msge;
            }

            //=====================================================================
            //---Ingresos en Dolares
            //=====================================================================
            tbEgrDol = CuadreOpe.CuadreOperaciones(this.dtpFechaSis.Value, idUsu, 2, clsVarGlobal.nIdAgencia, 2, ref msge);
            if (msge == "OK")
            {
                this.dtgEgrDolares.DataSource = tbEgrDol;
                if (tbEgrDol.Rows.Count > 0)
                {
                    this.txtMonEgrDol.Text = tbEgrDol.Rows[0]["nTotal"].ToString();
                }
            }
            else
            {
                //MessageBox.Show(msge, "Error al Extraer Datos de las Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return msge;
            }
            return msge;

        }

        private int ValidaRespBoveda()
        {
            clsCNControlOpe ValidaResBov = new clsCNControlOpe();
            int idTipoResCaja = 0;//todas las responsabilidades
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
            DataTable tbvalcierre = ValCieOpe.ValidarCierreOpe(this.dtpFechaSis.Value, clsVarGlobal.nIdAgencia, ref msg);
            if (msg == "OK")
            {
                if (tbvalcierre.Rows.Count > 0)
                {
                    for (int i = 0; i < tbvalcierre.Rows.Count; i++)
                    {
                        cRpta = cRpta + tbvalcierre.Rows[i]["cNombre"].ToString() + cTipoREesCaj(tbvalcierre.Rows[i]["idTipResCaj"].ToString()) + " ;";
                    }
                    cRpta = "FALTA QUE CIERREN CAJA: " + cRpta;
                    MessageBox.Show(cRpta, "Validar Cierre de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void tbcCieOpe_Click(object sender, EventArgs e)
        {
            //FormatoGridDol();
        }
        private bool ValidarIniOpeResCajaGeneral()
        {
            clsCNControlOpe ValResBov = new clsCNControlOpe();

            string cRpta = ValResBov.CNValidaIniOpeCajGen(clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia);
            // cRpta: Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada  

            if (cRpta.Equals("F"))
            {
                MessageBox.Show("Reponsable de Caja General Debe Iniciar Operaciones: VERIFICAR...", "Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            return false;
        }
        private bool ValidaUsurioEsResBoveda()
        {
            clsCNControlOpe ValidaResBov = new clsCNControlOpe();
            int idTipoResCaja = 0;//muestra todas las responsabilidades
            
            DataTable dtResBov = ValidaResBov.RetRespBoveda(Convert.ToInt32(this.txtCodUsu.Text.Trim().ToString()), clsVarGlobal.nIdAgencia, idTipoResCaja, clsVarGlobal.dFecSystem);
    
            if (dtResBov.Rows.Count > 0)
            {
                foreach (DataRow item in dtResBov.Rows)
                {
                    
                    if ( item[0].ToString().Equals("2"))
                    {
                        MessageBox.Show("Ud. es responsable de caja pulmón debe finalizar con cero, \n habilite su saldo a caja pulmón", "Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return true;
                    }
                    if (item[0].ToString().Equals("3"))
                    {
                        MessageBox.Show("Ud. es responsable de bóveda debe finalizar con cero, \n habilite su saldo a caja pulmón/bóveda", "Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return true;
                    }
                }        
            }
            return false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //===================================================================
            //--Validar existencia de responsable de boveda
            //===================================================================          

            if (ValidarSiExisteRespBoveda() == 0)
            {
                MessageBox.Show("No Puede Iniciar Su Caja, " + mRespValExis, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


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
            //===================================================================
            //--Valida Inicio de Operacion de Caja General(Boveda)
            //===================================================================          

            if (ValidarIniOpeResCajaGeneral())
            {
                return;
            }
            if (validarHabilitaPendientes())
            {
                return;
            }
           
            if (Convert.ToDecimal(txtSalFinSol.Text) != 0)
            {
                if (ValidaUsurioEsResBoveda())
                {
                    return;
                }
            }

            var Msg = MessageBox.Show("Esta Seguro de Cerrar su Caja?...", "Validar Cierre de Operaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Msg == DialogResult.No)
            {
                return;
            }

            //===================================================================
            //Guardar Datos de Ingreso en Soles XML
            //===================================================================          
            DataSet dsIngSol = new DataSet("dsIngSol");
            dsIngSol.Tables.Add(tbIngSol);
            string xmlIngSol = dsIngSol.GetXml();
            xmlIngSol = clsCNFormatoXML.EncodingXML(xmlIngSol);
            dsIngSol.Tables.Clear();

            //===================================================================
            //Guardar Datos de Egresos en Soles XML
            //===================================================================          
            DataSet dsEgrSol = new DataSet("dsEgrSol");
            dsEgrSol.Tables.Add(tbEgrSol);
            string xmlEgrSol = dsEgrSol.GetXml();
            xmlEgrSol = clsCNFormatoXML.EncodingXML(xmlEgrSol);
            dsEgrSol.Tables.Clear();

            //===================================================================
            //Guardar Datos de ingreso en Dólares XML
            //===================================================================          
            DataSet dsIngDol = new DataSet("dsIngDol");
            dsIngDol.Tables.Add(tbIngDol);
            string xmlIngDol = dsIngDol.GetXml();
            xmlIngDol = clsCNFormatoXML.EncodingXML(xmlIngDol);
            dsIngDol.Tables.Clear();

            //===================================================================
            //Guardar Datos de Egresos en Dolares XML
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
            clsCNControlOpe RegCieOpe = new clsCNControlOpe();

            string cRpta = RegCieOpe.RegCierreOperaciones(this.dtpFechaSis.Value, Convert.ToInt32(this.txtCodUsu.Text), clsVarGlobal.nIdAgencia, idTipOpeCaj,
                                            nSalIniSol, nSalIniDol, nSalFinSol, nSalFinDol, xmlIngSol, xmlEgrSol, xmlIngDol, xmlEgrDol);
            if (cRpta == "OK")
            {
                MessageBox.Show("El Cierre de Operaciones se Realizó Correctamente...", "Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //==================================================
                //--Actualizar Cierre
                //==================================================
                ActualizarCierre();
                this.btnGrabar.Enabled = false;
                this.btnImprimir.Enabled = true;
                this.btnImpDetall.Enabled = true;
            }
            else
            {
                MessageBox.Show(cRpta, "Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private bool validarHabilitaPendientes()
        {
            //================================================
            //--Valida si Tiene habilitaciones Pendientes
            //================================================
            clsCNControlOpe ValHab = new clsCNControlOpe();
            string cRptahabpen = ValHab.ValidaHabPendientes(this.dtpFechaSis.Value, Convert.ToInt32(this.txtCodUsu.Text), clsVarGlobal.nIdAgencia, 1,1);
            if (Convert.ToInt32(cRptahabpen) > 0)
            {
                MessageBox.Show("No puede Cerrar porque Tiene Habilitaciones Pendientes por APROBAR o RECHAZAR...", "Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }

            //================================================
            //--Valida si Tiene Habilitaciones Generadas
            //================================================          
            string cRptaHabGen = ValHab.ValidaHabPendientes(this.dtpFechaSis.Value, Convert.ToInt32(this.txtCodUsu.Text), clsVarGlobal.nIdAgencia, 2,1);
            if (Convert.ToInt32(cRptaHabGen) > 0)
            {
                MessageBox.Show("No puede Cerrar porque Tiene Habilitaciones GENERADAS...", "Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            return false;
        }

        //private void btnImprimir_Click(object sender, EventArgs e)
        //{
        //    List<ReportParameter> paramlist = new List<ReportParameter>();
        //    DateTime dFecha = this.dtpFechaSis.Value;
        //    int idUsu = clsVarGlobal.User.idUsuario;
        //    int idAge = clsVarGlobal.nIdAgencia;
        //    paramlist.Add(new ReportParameter("dFechaOpe", dFecha.ToString(), false));
        //    paramlist.Add(new ReportParameter("idUsu", idUsu.ToString(), false));
        //    paramlist.Add(new ReportParameter("idAge", idAge.ToString(), false));
        //    string reportpath = "/RPT/RptResumenOpe";
        //    new frmReporte(paramlist, reportpath).ShowDialog();
        //    this.btnImprimir.Enabled = true;
        //}

        //private void btnImpDetall_Click(object sender, EventArgs e)
        //{
        //    List<ReportParameter> paramlist = new List<ReportParameter>();
        //    DateTime dFecha = this.dtpFechaSis.Value;
        //    int idUsu = clsVarGlobal.User.idUsuario;
        //    int idAge = clsVarGlobal.nIdAgencia;
        //    paramlist.Add(new ReportParameter("dFecOpe", dFecha.ToString(), false));
        //    paramlist.Add(new ReportParameter("idUsu", idUsu.ToString(), false));
        //    paramlist.Add(new ReportParameter("idAge", idAge.ToString(), false));
        //    string reportpath = "/RPT/RptDetalleOpe";
        //    new frmReporte(paramlist, reportpath).ShowDialog();
        //    this.btnImprimir.Enabled = true;
        //}


        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Este reporte es de carácter informativo, NO LO IMPRIMA.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            DateTime dFecha = this.dtpFechaSis.Value;
            int idUsu = clsVarGlobal.User.idUsuario;
            int idAge = clsVarGlobal.nIdAgencia;


            dtslist.Add(new ReportDataSource("dsResOpeSolIng", tbIngSol));
            dtslist.Add(new ReportDataSource("dsResOpeSolEgr", tbEgrSol));
            dtslist.Add(new ReportDataSource("dsResOpeDolEgr", tbEgrDol));
            dtslist.Add(new ReportDataSource("dsResOpeDolIng", tbIngDol));

            string cTipResCaj = "RESPONSABLE DE VENTANILLA";
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

        private void btnImpDetall_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Este reporte es de carácter informativo, NO LO IMPRIMA.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            DateTime dFecha = this.dtpFechaSis.Value;
            int idUsu = clsVarGlobal.User.idUsuario;
            int idAge = clsVarGlobal.nIdAgencia;
            int idTipResCaj = 1;
            DataTable dtDetOpe = new clsRPTCNCaja().CNDetallOperaciones(dFecha, idUsu, idAge, idTipResCaj);

            if (dtDetOpe.Rows.Count <= 0)
            {
                MessageBox.Show("No existen datos para mostrar.", "Reporte de Detalle de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Add(new ReportDataSource("dsKardex", dtDetOpe));

            bool lFiltroRSC = false;

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("dFecOpe", dFecha.ToString(), false));
            paramlist.Add(new ReportParameter("idUsu", idUsu.ToString(), false));
            paramlist.Add(new ReportParameter("idAge", idAge.ToString(), false));
            paramlist.Add(new ReportParameter("lFiltroRSC", lFiltroRSC.ToString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            string reportpath = "rptDetalleOpe.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

            this.btnImprimir.Enabled = true;
        }
    }
}
