using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;


namespace CAJ.Presentacion
{
    public partial class frmCorteFraccionario : frmBase
    {
        //================================================
        //--Declarar variables Publicas
        //================================================
        #region variables
        public DataTable tbMonSol;
        public DataTable tbBillSol;
        public DataTable tbBillDol;
        int pnCantidad = 0;
        int pidTipResCaj = 0, pidTipResCaj2 = 0;
        clsCNControlOpe LisMonSol = new clsCNControlOpe();
        private string cXmlBilletes = "";
        private string cEventosBilletes = "";
        #endregion

        public frmCorteFraccionario()
        {
            InitializeComponent();
        }

        private void frmCorteFraccionario_Load(object sender, EventArgs e)
        {
            DatosUsuario();
            btnImprimir.Enabled = false;

            if (string.IsNullOrEmpty(this.txtCodUsu.Text.Trim()))
            {
                MessageBox.Show("No existe código de usuario", "Validar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
                return;
            }

            //--Validar si ya Realizó la carga de voucher Prepago y adelanto cuota
            if (ValidarCargaVoucher() == "ERROR")
            {
                this.Dispose();
                return;
            }
           
            //cargar el tipo de reponsable por usuario.
            cboTipResponsable.SelectedIndexChanged -= new EventHandler(cboTipResponsable_SelectedIndexChanged);
            if (cargarTipoResponsable())
            {
                this.Dispose();
                return;
            }
            cboTipResponsable.SelectedIndexChanged += new EventHandler(this.cboTipResponsable_SelectedIndexChanged);

            pidTipResCaj = ValidaRespCaja();

            if (pidTipResCaj == 0)
            {
                MessageBox.Show("Ud. no es responsable de ventanilla, caja pulmón o bóveda.", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
                return;
            }


            clsCNControlOpe RetSaldos = new clsCNControlOpe();
            if (pnCantidad != 1)//el usuario tiene asignado mas de una responsabilidad
            {
                cboTipResponsable.Enabled = true;
                cboTipResponsable.SelectedIndex = -1;
                habilitarObjetos(true);
            }
            else
            {
                //===========================================================================================
                //--Validar Inicio de Operaciones
                //===========================================================================================
                if (ValidarInicioOpeCaj(pidTipResCaj) != "A")
                {
                    this.Dispose();
                    return;
                }
                if (validarHabilitaPendientes())
                {
                    this.Dispose();
                    return;
                }

                cboTipResponsable.Enabled = false;
                cboTipResponsable.SelectedValue = pidTipResCaj;
                //===========================================================================================
                //--Validar Corte Fraccionario
                //===========================================================================================
                if (ValidarCorteFracc(pidTipResCaj) == "ERROR")
                {
                    //---Llenar Grid
                    ListarMonedaBilletes(2, pidTipResCaj, "1");
                    HabilitarGridCorte(true);
                    //--Desabilitar botones               
                    habilitarObjetos(true);
                }
                else
                {
                    string msge = "";
                    clsCNControlOpe ValCorteFra = new clsCNControlOpe();
                    string cRpta = ValCorteFra.ValAutCorteFracc(this.dtpFechaSis.Value, Convert.ToInt32(this.txtCodUsu.Text), clsVarGlobal.nIdAgencia, 1, ref msge, pidTipResCaj);

                    if (cRpta == "A")
                    {
                        //---Llenar Grid
                        ListarMonedaBilletes(2, pidTipResCaj, "2");
                        HabilitarGridCorte(true);
                        //--Desabilitar botones                              
                        habilitarObjetos(true);
                    }
                    else
                    {
                        //---Llenar Grid
                        ListarMonedaBilletes(1, pidTipResCaj, "3");
                        HabilitarGridCorte(true);
                        //--Desabilitar botones
                        habilitarObjetos(false);
                    }

                    //solo en caso de boveda
                    if (pidTipResCaj == 3)
                    {
                        habilitarObjetos(false);
                        if (ValidarBovedaIni() == 0)
                        {
                            HabilitarGridCorte(true);
                            btnImprimir.Enabled = false;
                        }
                        else if (cRpta == "0")
                        {
                            HabilitarGridCorte(false);
                            btnEditar.Enabled = false;
                            btnGrabar.Enabled = true;
                        }
                        else
                        {
                            HabilitarGridCorte(false);
                            btnEditar.Enabled = true;
                            btnGrabar.Enabled = false;
                        }

                    }
                    ////---Llenar Grid
                    //ListarMonedaBilletes(1, pidTipResCaj);
                    //HabilitarGridCorte(true);
                    ////--Desabilitar botones
                    //habilitarObjetos(false);
                }
                FormatoGrid();
                DeshabilitaOrdGrid();
            }
        }
        public string ValidarInicioOpeCaj(int idTipResCaj)
        {
            clsCNControlOpe ValidaOpe = new clsCNControlOpe();
            string cEstCie = ValidaOpe.ValidaIniOpeCaja(clsVarGlobal.dFecSystem, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()), clsVarGlobal.nIdAgencia, idTipResCaj);
            // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada
            //string cRpta = this.ValidarInicioOpe();

            switch (cEstCie) // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada  
            {
                case "F":
                    switch (idTipResCaj)
                    {
                        case 3: MessageBox.Show("Falta realizar el inicio de Operaciones del Responsable de Bóveda \n dirigirse al modulo de caja", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case 2: MessageBox.Show("Falta realizar el inicio de Operaciones del Responsable de Caja pulmón \n dirigirse al modulo de caja", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        default: MessageBox.Show("Falta realizar el inicio de Operaciones del Responsable de Ventanilla \n dirigirse al modulo de caja", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }
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
        private int ValidaRespCaja()
        {
            clsCNControlOpe ValidaResBov = new clsCNControlOpe();
            int idTipoResCaja = 0;
            //// Si nValUsu es: 0--> usuario no Es Responsable de ventanilla, caja pulmón o Bóveda
            ////                1-->resonsable de ventanilla
            ////                2-->resonsable de caja pulmón
            ////                3-->resonsable de Bóveda
            DataTable dtResBov = ValidaResBov.RetRespBoveda(Convert.ToInt32(this.txtCodUsu.Text.Trim().ToString()), clsVarGlobal.nIdAgencia, idTipoResCaja, clsVarGlobal.dFecSystem);

            pnCantidad = dtResBov.Rows.Count;

            if (pnCantidad == 2)
            {
                pidTipResCaj2 = Convert.ToInt32(dtResBov.Rows[1]["idTipResCaj"].ToString());
            }
            if (pnCantidad == 0)
            {
                return 0;
            }

            return Convert.ToInt32(dtResBov.Rows[0]["idTipResCaj"].ToString());

        }
        private bool cargarTipoResponsable()
        {
            clsCNControlOpe ValCorFra = new clsCNControlOpe();
            DataTable dtResBov = ValCorFra.cargarTipRespPorUsuarioIniOpe(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem);
            bool lRespuesta = false;
            if (dtResBov.Rows.Count == 0)
            {
                MessageBox.Show("Falta realizar el inicio de operaciones", "Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lRespuesta = true;
            }
            cboTipResponsable.DataSource = dtResBov;
            cboTipResponsable.ValueMember = dtResBov.Columns["idTipResCaj"].ToString();
            cboTipResponsable.DisplayMember = dtResBov.Columns["cTipResponsable"].ToString();
            return lRespuesta;
        }
        private string ValidarCorteFracc(int idTipResCaja)
        {
            string cRpta = "OK";
            clsCNControlOpe ValCorFra = new clsCNControlOpe();
            string cCorFra = ValCorFra.ValidaCorteFraccCaja(this.dtpFechaSis.Value, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()), clsVarGlobal.nIdAgencia, idTipResCaja);


            if (cCorFra != "0")
            {
                MessageBox.Show("Ya realizó su billetaje", "Validar billetaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtgMonedas.Enabled = false;
                dtgBilletes.Enabled = false;
                dtgBillDolares.Enabled = false;
                btnCancelar.Enabled = false;
                btnGrabar.Enabled = false;
                cRpta = "ERROR";
            }

            return cRpta;
        }
        private int ValidarBovedaIni()
        {
            clsCNControlOpe ValCorFra = new clsCNControlOpe();
            DataTable dtResp=ValCorFra.CNlistaBillbovedaInicio(clsVarGlobal.nIdAgencia);
            int nIndicaIniOpe = Convert.ToInt32(dtResp.Rows[0]["cEstCorFra"].ToString());
            return nIndicaIniOpe;
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
        private void DeshabilitaOrdGrid()
        {
            dtgMonedas.Columns["cDescripcion"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgMonedas.Columns["nCantidad"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgMonedas.Columns["nTotal"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgBilletes.Columns["cDescripcion"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgBilletes.Columns["nCantidad"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgBilletes.Columns["nTotal"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgBillDolares.Columns["cDescripcion"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgBillDolares.Columns["nCantidad"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgBillDolares.Columns["nTotal"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        private void HabilitarGridCorte(Boolean bVal)
        {
            //grid soles monedas
            dtgMonedas.ReadOnly = !bVal;
            dtgMonedas.Columns["idMoneda"].ReadOnly = bVal;
            dtgMonedas.Columns["idTipBillMon"].ReadOnly = bVal;
            dtgMonedas.Columns["nValor"].ReadOnly = bVal;
            dtgMonedas.Columns["cDescripcion"].ReadOnly = bVal;
            dtgMonedas.Columns["nCantidad"].ReadOnly = !bVal;
            dtgMonedas.Columns["nTotal"].ReadOnly = bVal;
            //grid soles billetes
            dtgBilletes.ReadOnly = !bVal;
            dtgBilletes.Columns["idMoneda"].ReadOnly = bVal;
            dtgBilletes.Columns["idTipBillMon"].ReadOnly = bVal;
            dtgBilletes.Columns["nValor"].ReadOnly = bVal;
            dtgBilletes.Columns["cDescripcion"].ReadOnly = bVal;
            dtgBilletes.Columns["nCantidad"].ReadOnly = !bVal;
            dtgBilletes.Columns["nTotal"].ReadOnly = bVal;
            
            //grid dolares
            dtgBillDolares.ReadOnly = !bVal;
            dtgBillDolares.Columns["idMoneda"].ReadOnly = bVal;
            dtgBillDolares.Columns["idTipBillMon"].ReadOnly = bVal;
            dtgBillDolares.Columns["nValor"].ReadOnly = bVal;
            dtgBillDolares.Columns["cDescripcion"].ReadOnly = bVal;
            dtgBillDolares.Columns["nCantidad"].ReadOnly = !bVal;
            dtgBillDolares.Columns["nTotal"].ReadOnly = bVal;
        }
        private void SumaMonSol()
        {
            Decimal suma = 0.00m;
            int nNumPro = this.dtgMonedas.RowCount;
            for (int i = 0; i < nNumPro; i++)
            {
                suma = suma + Convert.ToDecimal (this.dtgMonedas.Rows[i].Cells["nTotal"].Value);
            }
            this.txtMonMoneda.Text = suma.ToString();
            this.txtMonTotal.Text = Convert.ToString(Math.Round((Math.Round(Convert.ToDecimal (this.txtMonMoneda.Text), 2) + Math.Round(Convert.ToDecimal (this.txtMonBillete.Text), 2)), 2));
        }
        private void SumaBillSol()
        {
            Decimal suma = 0.00m;
            int nNumPro = this.dtgBilletes.RowCount;
            for (int i = 0; i < nNumPro; i++)
            {
                suma = suma + Convert.ToDecimal (this.dtgBilletes.Rows[i].Cells["nTotal"].Value);
            }
            this.txtMonBillete.Text = suma.ToString();
            this.txtMonTotal.Text = Convert.ToString(Math.Round((Convert.ToDecimal (this.txtMonMoneda.Text) + Convert.ToDecimal (this.txtMonBillete.Text)), 2));
        }
        private void SumaBillDol()
        {
            Decimal suma = 0.00m;
            int nNumPro = this.dtgBillDolares.RowCount;
            for (int i = 0; i < nNumPro; i++)
            {
                suma = suma + Convert.ToDecimal (this.dtgBillDolares.Rows[i].Cells["nTotal"].Value);
            }
            this.txtBillDol.Text = suma.ToString();
            this.txtTotDolar.Text = suma.ToString();
        }

        private void ListarMonedaBilletes(int nOpc, int idTipResCaj, string cEvento)
        {
            string msge = "";
            cXmlBilletes = "";
            if(cEventosBilletes != ""){
                cEventosBilletes += ", ";
            }
            cEventosBilletes += cEvento;

            DataSet dsBilletes = new DataSet("dsBilletaje");

            #region solo en caso de boveda
            if (idTipResCaj == 3)
            {
                tbMonSol = LisMonSol.ListarBillBov(clsVarGlobal.nIdAgencia, 1, 1, idTipResCaj, clsVarGlobal.dFecSystem, ref msge);
                if (msge == "OK")
                {
                    tbMonSol.AcceptChanges();
                    tbMonSol.Columns["nCantidad"].ReadOnly = false;
                    tbMonSol.Columns["nTotal"].ReadOnly = false;
                    this.dtgMonedas.DataSource = tbMonSol;
                }
                else
                {
                    MessageBox.Show(msge, "Error al Extraer Datos de Monedas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                tbBillSol = LisMonSol.ListarBillBov(clsVarGlobal.nIdAgencia, 1, 2, idTipResCaj, clsVarGlobal.dFecSystem, ref msge);
                if (msge == "OK")
                {
                    tbBillSol.AcceptChanges();
                    tbBillSol.Columns["nCantidad"].ReadOnly = false;
                    tbBillSol.Columns["nTotal"].ReadOnly = false;
                    this.dtgBilletes.DataSource = tbBillSol;
                }
                else
                {
                    MessageBox.Show(msge, "Error al Extraer Datos de Billetes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                tbBillDol = LisMonSol.ListarBillBov(clsVarGlobal.nIdAgencia, 2, 2, idTipResCaj, clsVarGlobal.dFecSystem, ref msge);
                if (msge == "OK")
                {
                    tbBillDol.AcceptChanges();
                    tbBillDol.Columns["nCantidad"].ReadOnly = false;
                    tbBillDol.Columns["nTotal"].ReadOnly = false;
                    this.dtgBillDolares.DataSource = tbBillDol;
                }
                else
                {
                    MessageBox.Show(msge, "Error al Extraer Billetes en Dólares", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DataTable tbMonSol_ = tbMonSol.Copy();
                DataTable tbBillSol_ = tbBillSol.Copy();
                DataTable tbBillDol_ = tbBillDol.Copy();

                dsBilletes.Tables.Add(tbMonSol_);
                dsBilletes.Tables.Add(tbBillSol_);
                dsBilletes.Tables.Add(tbBillDol_);
                cXmlBilletes = dsBilletes.GetXml();
                return;
            }
            #endregion

            if (nOpc == 1)
            {

                tbMonSol = LisMonSol.ListarBillMon(1, 1, ref msge);
                if (msge == "OK")
                {
                    tbMonSol.AcceptChanges();
                    tbMonSol.Columns["nCantidad"].ReadOnly = false;
                    tbMonSol.Columns["nTotal"].ReadOnly = false;
                    this.dtgMonedas.DataSource = tbMonSol;
                }
                else
                {
                    MessageBox.Show(msge, "Error al Extraer Datos de Monedas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                tbBillSol = LisMonSol.ListarBillMon(1, 2, ref msge);
                if (msge == "OK")
                {
                    tbBillSol.AcceptChanges();
                    tbBillSol.Columns["nCantidad"].ReadOnly = false;
                    tbBillSol.Columns["nTotal"].ReadOnly = false;
                    this.dtgBilletes.DataSource = tbBillSol;
                }
                else
                {
                    MessageBox.Show(msge, "Error al Extraer Datos de Billetes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                tbBillDol = LisMonSol.ListarBillMon(2, 2, ref msge);
                if (msge == "OK")
                {
                    tbBillDol.AcceptChanges();
                    tbBillDol.Columns["nCantidad"].ReadOnly = false;
                    tbBillDol.Columns["nTotal"].ReadOnly = false;
                    this.dtgBillDolares.DataSource = tbBillDol;
                }
                else
                {
                    MessageBox.Show(msge, "Error al Extraer Billetes en Dólares", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                tbMonSol = LisMonSol.ListarCorteFrac(this.dtpFechaSis.Value, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, 1, 1, idTipResCaj, ref msge);
                if (msge == "OK")
                {
                    tbMonSol.AcceptChanges();
                    tbMonSol.Columns["nCantidad"].ReadOnly = false;
                    tbMonSol.Columns["nTotal"].ReadOnly = false;
                    this.dtgMonedas.DataSource = tbMonSol;
                }
                else
                {
                    MessageBox.Show(msge, "Error al Extraer Datos de Monedas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                tbBillSol = LisMonSol.ListarCorteFrac(this.dtpFechaSis.Value, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, 1, 2, idTipResCaj, ref msge);
                if (msge == "OK")
                {
                    tbBillSol.AcceptChanges();
                    tbBillSol.Columns["nCantidad"].ReadOnly = false;
                    tbBillSol.Columns["nTotal"].ReadOnly = false;
                    this.dtgBilletes.DataSource = tbBillSol;
                }
                else
                {
                    MessageBox.Show(msge, "Error al Extraer Datos de Billetes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                tbBillDol = LisMonSol.ListarCorteFrac(this.dtpFechaSis.Value, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, 2, 2, idTipResCaj, ref msge);
                if (msge == "OK")
                {
                    tbBillDol.AcceptChanges();
                    tbBillDol.Columns["nCantidad"].ReadOnly = false;
                    tbBillDol.Columns["nTotal"].ReadOnly = false;
                    this.dtgBillDolares.DataSource = tbBillDol;
                    SumaBillDol();
                }
                else
                {
                    MessageBox.Show(msge, "Error al Extraer Billetes en Dólares", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void FormatoGrid()
        {
            //--Formato Grid Moneda Soles
            this.dtgMonedas.Columns["idMoneda"].Visible = false;
            this.dtgMonedas.Columns["idTipBillMon"].Visible = false;
            this.dtgMonedas.Columns["nValor"].Visible = false;
            this.dtgMonedas.Columns["cDescripcion"].Width = 120;
            this.dtgMonedas.Columns["cDescripcion"].HeaderText = "Denominaciones";
            this.dtgMonedas.Columns["nCantidad"].Width = 60;
            this.dtgMonedas.Columns["nCantidad"].HeaderText = "Cantidad";
            this.dtgMonedas.Columns["nCantidad"].DefaultCellStyle.Format = "N0";
            this.dtgMonedas.Columns["nTotal"].Width = 95;
            this.dtgMonedas.Columns["nTotal"].HeaderText = "Total";
            this.dtgMonedas.Columns["nTotal"].DefaultCellStyle.Format = "N2";
            //--Formato Grid Billetes Soles
            this.dtgBilletes.Columns["idMoneda"].Visible = false;
            this.dtgBilletes.Columns["idTipBillMon"].Visible = false;
            this.dtgBilletes.Columns["nValor"].Visible = false;
            this.dtgBilletes.Columns["cDescripcion"].Width = 120;
            this.dtgBilletes.Columns["cDescripcion"].HeaderText = "Denominaciones";
            this.dtgBilletes.Columns["nCantidad"].Width = 60;
            this.dtgBilletes.Columns["nCantidad"].HeaderText = "Cantidad";
            this.dtgBilletes.Columns["nCantidad"].DefaultCellStyle.Format = "N0";
            this.dtgBilletes.Columns["nTotal"].Width = 95;
            this.dtgBilletes.Columns["nTotal"].HeaderText = "Total";
            this.dtgBilletes.Columns["nTotal"].DefaultCellStyle.Format = "N2";
            ////--Formato Grid Billetes Dolares
            this.tbcCorte.SelectedIndex = 1;
            this.dtgBillDolares.Columns["idMoneda"].Visible = false;
            this.dtgBillDolares.Columns["idTipBillMon"].Visible = false;
            this.dtgBillDolares.Columns["nValor"].Visible = false;
            this.dtgBillDolares.Columns["cDescripcion"].Width = 120;
            this.dtgBillDolares.Columns["cDescripcion"].HeaderText = "Denominaciones";
            this.dtgBillDolares.Columns["nCantidad"].Width = 60;
            this.dtgBillDolares.Columns["nCantidad"].HeaderText = "Cantidad";
            this.dtgBillDolares.Columns["nCantidad"].DefaultCellStyle.Format = "N0";
            this.dtgBillDolares.Columns["nTotal"].Width = 150;
            this.dtgBillDolares.Columns["nTotal"].HeaderText = "Total";
            this.dtgBillDolares.Columns["nTotal"].DefaultCellStyle.Format = "N2";
            this.tbcCorte.SelectedIndex = 0;
        }
        private int ValidaRespBoveda()
        {

            clsCNControlOpe ValidaResBov = new clsCNControlOpe();
            int idTipResCaja = Convert.ToInt32(cboTipResponsable.SelectedValue);
            //// Si nValUsu es: 0--> usuario no Es Responsable de ventanilla, caja pulmón o Bóveda
            ////                1-->resonsable de ventanilla
            ////                2-->resonsable de caja pulmón
            ////                3-->resonsable de Bóveda
            DataTable dtResBov = ValidaResBov.RetRespBoveda(Convert.ToInt32(this.txtCodUsu.Text.Trim().ToString()), clsVarGlobal.nIdAgencia, idTipResCaja, clsVarGlobal.dFecSystem);

            pnCantidad = dtResBov.Rows.Count;

            if (pnCantidad == 0)
            {
                return 0;
            }
            return Convert.ToInt32(dtResBov.Rows[0]["idTipResCaj"].ToString());

        }
        private string VerificaCierreOpe(int idTipResCaj)
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
                        if (idTipResCaj.ToString() != tbvalcierre.Rows[i]["idTipResCaj"].ToString())
                        {
                            cRpta = cRpta + tbvalcierre.Rows[i]["cNombre"].ToString() + cTipoREesCaj(tbvalcierre.Rows[i]["idTipResCaj"].ToString()) + " ;";
                        }
                    }
                    if (tbvalcierre.Rows.Count == 1 && idTipResCaj.ToString() == tbvalcierre.Rows[0]["idTipResCaj"].ToString())
                    {
                        cRpta = "OK";
                    }
                    else
                    {
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
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validarHabilitaPendientes())
            {
                return;
            }

            //===================================================================
            // Validar registro de billetaje en 0 cuando para la opcion habilitada
            //===================================================================
            if (!validarSaldoOperadorCierreZero())
            {
                return;
            }

            var Msg = MessageBox.Show("Está seguro de registrar su billetaje?...", "Registrar billetaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Msg == DialogResult.No)
            {
                return;
            }
            int idTipResCaja = Convert.ToInt32(cboTipResponsable.SelectedValue);
            //===================================================================
            //para el caso de bóveda se debe validar que las ventanillas cierren 
            //sus operaciones
            //===================================================================      
            if (idTipResCaja != 1)
            {
                if (VerificaCierreOpe(idTipResCaja) != "OK")
                {
                    return;
                }
            }

            //===================================================================
            //Guardar Datos de Monedas Mediante XML
            //===================================================================          
            DataSet dsMonSol = new DataSet("dsMonSol");
            dsMonSol.Tables.Add(tbMonSol);
            string xmlMonSol = dsMonSol.GetXml();
            xmlMonSol = clsCNFormatoXML.EncodingXML(xmlMonSol);
            dsMonSol.Tables.Clear();

            //===================================================================
            //Guardar Datos de Billetes Soles Mediante XML
            //===================================================================          
            DataSet dsBillSol = new DataSet("dsBillSol");
            dsBillSol.Tables.Add(tbBillSol);
            string xmlBillSol = dsBillSol.GetXml();
            xmlBillSol = clsCNFormatoXML.EncodingXML(xmlBillSol);
            dsBillSol.Tables.Clear();

            //===================================================================
            //Guardar Datos de Billetes Dol Mediante XML
            //===================================================================          
            DataSet dsBillDol = new DataSet("dsBillDol");
            dsBillDol.Tables.Add(tbBillDol);
            string xmlBillDol = dsBillDol.GetXml();
            xmlBillDol = clsCNFormatoXML.EncodingXML(xmlBillDol);
            dsBillDol.Tables.Clear();

            /*========================================================================================
             * REGISTRO DE RASTREO
             ========================================================================================*/
            this.registrarRastreo(clsVarGlobal.User.idCli, 0, "Guardado Billetaje Boveda: Evento = "+cEventosBilletes+"\n"+cXmlBilletes, btnGrabar);

            //==================================================
            //--Grabar Corte Fraccionario
            //==================================================

            clsCNControlOpe RegCorFra = new clsCNControlOpe();
            string cRpta = RegCorFra.registroCorFrac(Convert.ToInt32(this.txtCodUsu.Text), this.dtpFechaSis.Value, clsVarGlobal.nIdAgencia, xmlMonSol, xmlBillSol, xmlBillDol, idTipResCaja);
            if (cRpta == "OK")
            {
                MessageBox.Show("El billetaje se registro correctamente...", "Registro de billetaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(cRpta, "Error en registro de billetaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.btnGrabar.Enabled = false;
            this.dtgMonedas.Enabled = false;
            this.dtgBilletes.Enabled = false;
            this.dtgBillDolares.Enabled = false;
            this.btnImprimir.Enabled = true;
        }

        private void dtgMonedas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Int32 fila = Convert.ToInt32(this.dtgMonedas.SelectedCells[0].RowIndex);
            if (string.IsNullOrEmpty(this.dtgMonedas.Rows[fila].Cells["nCantidad"].Value.ToString()))
            {
                this.dtgMonedas.Rows[fila].Cells["nCantidad"].Value = 0;
            }
            tbMonSol.Rows[fila]["nTotal"] = Convert.ToDecimal (this.dtgMonedas.Rows[fila].Cells["nCantidad"].Value) * Convert.ToDecimal (this.dtgMonedas.Rows[fila].Cells["nValor"].Value);
            SumaMonSol();
        }

        private void dtgBilletes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Int32 fila = Convert.ToInt32(this.dtgBilletes.SelectedCells[0].RowIndex);
            if (string.IsNullOrEmpty(this.dtgBilletes.Rows[fila].Cells["nCantidad"].Value.ToString()))
            {
                this.dtgBilletes.Rows[fila].Cells["nCantidad"].Value = 0;
            }
            tbBillSol.Rows[fila]["nTotal"] = Convert.ToDecimal (dtgBilletes.Rows[fila].Cells["nCantidad"].Value) * Convert.ToDecimal (this.dtgBilletes.Rows[fila].Cells["nValor"].Value);
            SumaBillSol();

        }

        private void dtgBillDolares_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Int32 fila = Convert.ToInt32(this.dtgBillDolares.SelectedCells[0].RowIndex);
            if (string.IsNullOrEmpty(this.dtgBillDolares.Rows[fila].Cells["nCantidad"].Value.ToString()))
            {
                this.dtgBillDolares.Rows[fila].Cells["nCantidad"].Value = 0;
            }
            tbBillDol.Rows[fila]["nTotal"] = Convert.ToDecimal (dtgBillDolares.Rows[fila].Cells["nCantidad"].Value) * Convert.ToDecimal (this.dtgBillDolares.Rows[fila].Cells["nValor"].Value);
            SumaBillDol();
        }

        private void tbcCorte_Click(object sender, EventArgs e)
        {

        }



        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (cboTipResponsable.SelectedIndex <= -1)
            {
                MessageBox.Show("Debe elegir el tipo de responsable", "Validar billetaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipResponsable.Focus();
                return;
            }
            int idTipResCaj = ValidaRespBoveda();

            string msge = "";
            clsCNControlOpe ValCorteFra = new clsCNControlOpe();
            string cRpta = ValCorteFra.ValAutCorteFracc(this.dtpFechaSis.Value, Convert.ToInt32(this.txtCodUsu.Text), clsVarGlobal.nIdAgencia, 1, ref msge, idTipResCaj);
            if (msge == "OK")
            {
                if (cRpta == "N")
                {
                    MessageBox.Show("Debe solicitar autorización para modificar el billetaje", "Modificar billetaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                MessageBox.Show(msge, "Error al validar billetaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //--Desabilitar botones
            this.dtgMonedas.Enabled = true;
            this.dtgBilletes.Enabled = true;
            this.dtgBillDolares.Enabled = true;
            this.btnGrabar.Enabled = true;
            this.btnEditar.Enabled = false;
            this.btnCancelar.Enabled = true;
            this.btnImprimir.Enabled = false;
            HabilitarGridCorte(true);

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //--Desabilitar botones
            this.dtgMonedas.Enabled = false;
            this.dtgBilletes.Enabled = false;
            this.dtgBillDolares.Enabled = false;
            this.btnGrabar.Enabled = false;
            this.btnEditar.Enabled = true;
            this.btnCancelar.Enabled = false;
            this.btnImprimir.Enabled = false;
            cboTipResponsable_SelectedIndexChanged(sender, e);
        }

        private void dtgMonedas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }
        void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57)
            //{
            //    e.Handled = true;
            //}
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 13)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void dtgBilletes_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }

        private void dtgBillDolares_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este reporte es de carácter informativo, NO LO IMPRIMA.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            DateTime dFecha = this.dtpFechaSis.Value;
            int idUsu = clsVarGlobal.User.idUsuario;
            int idAge = clsVarGlobal.nIdAgencia;
            int idTipResCaja = Convert.ToInt32(cboTipResponsable.SelectedValue);
            dtslist.Add(new ReportDataSource("dsCorteFracc", new clsRPTCNCaja().CNCorteFracc(dFecha, idUsu, idAge, idTipResCaja)));
            List<ReportParameter> param = new List<ReportParameter>();
            param.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            string reportpath = "rptCorteFracc.rdlc";
            new frmReporteLocal(dtslist, reportpath, param).ShowDialog();


            this.btnImprimir.Enabled = true;
        }
        private bool validarHabilitaPendientes()
        {
            //================================================
            //--Valida si Tiene habilitaciones Pendientes
            //================================================
            int idTipoHab = Convert.ToInt32(cboTipResponsable.SelectedValue);
            clsCNControlOpe ValHab = new clsCNControlOpe();
            string cRptahabpen = ValHab.ValidaHabPendientes(this.dtpFechaSis.Value, Convert.ToInt32(this.txtCodUsu.Text), clsVarGlobal.nIdAgencia, 1, idTipoHab);
            if (Convert.ToInt32(cRptahabpen) > 0)
            {
                MessageBox.Show("No puede registrar billetaje porque tiene \n habilitaciones pendientes por APROBAR o RECHAZAR...", "Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }

            //================================================
            //--Valida si Tiene Habilitaciones Generadas
            //================================================          
            string cRptaHabGen = ValHab.ValidaHabPendientes(this.dtpFechaSis.Value, Convert.ToInt32(this.txtCodUsu.Text), clsVarGlobal.nIdAgencia, 2, idTipoHab);
            if (Convert.ToInt32(cRptaHabGen) > 0)
            {
                MessageBox.Show("No puede registrar billetaje porque tiene \n habilitaciones GENERADAS...", "Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            return false;
        }

        private bool validarSaldoOperadorCierreZero()
        {
            clsVarGen objVarGen = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("lCierreOperacionCero"));
            bool lCierreOperacionCero = (objVarGen.cValVar == "1") ? true : false ;

            if(lCierreOperacionCero)
            {
                int idTipoResponsable = Convert.ToInt32(cboTipResponsable.SelectedValue);
                decimal nMontoTotalBilletaje = Convert.ToDecimal(txtMonTotal.Text);
                decimal nMontoTotalBilletajeDolares = Convert.ToDecimal(txtTotDolar.Text);
                if ((nMontoTotalBilletaje != 0 || nMontoTotalBilletajeDolares != 0) && idTipoResponsable != 3 )
                {
                    MessageBox.Show("No se puede registrar el billetaje de un saldo mayor a 0. Por favor habilitar a Bóveda el saldo restante", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                return true;
            }
            else
            {
                return true;
            }
        }

        private void cboTipResponsable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipResponsable.SelectedIndex > -1 && !cboTipResponsable.SelectedValue.ToString().Equals("System.Data.DataRowView"))
            {
                int idTipResCaja = Convert.ToInt32(cboTipResponsable.SelectedValue);
                //===========================================================================================
                //--Validar Corte Fraccionario
                //===========================================================================================
                if (ValidarCorteFracc(idTipResCaja) == "ERROR")
                {
                    //---Llenar Grid
                    ListarMonedaBilletes(2, idTipResCaja, "4");
                    HabilitarGridCorte(true);
                    //--Desabilitar botones                              
                    habilitarObjetos(true);
                }
                else
                {
                    string msge = "";
                    clsCNControlOpe ValCorteFra = new clsCNControlOpe();
                    string cRpta = ValCorteFra.ValAutCorteFracc(this.dtpFechaSis.Value, Convert.ToInt32(this.txtCodUsu.Text), clsVarGlobal.nIdAgencia, 1, ref msge, idTipResCaja);

                    if (cRpta == "A")
                    {
                        //---Llenar Grid
                        ListarMonedaBilletes(2, idTipResCaja, "5");
                        HabilitarGridCorte(true);
                        //--Desabilitar botones                              
                        habilitarObjetos(true);
                    }
                    else
                    {
                        //---Llenar Grid
                        ListarMonedaBilletes(1, idTipResCaja, "6");
                        HabilitarGridCorte(true);
                        //--Desabilitar botones
                        habilitarObjetos(false);

                        //solo en caso de boveda
                        if (idTipResCaja == 3)
                        {
                            habilitarObjetos(false);
                            if (ValidarBovedaIni() == 0)
                            {
                                HabilitarGridCorte(true);
                                btnImprimir.Enabled = false;
                            }
                            else if (cRpta == "0")
                            {
                                HabilitarGridCorte(false);
                                btnEditar.Enabled = false;
                                btnGrabar.Enabled = true;
                            }
                            else
                            {
                                HabilitarGridCorte(false);
                                btnEditar.Enabled = true;
                                btnGrabar.Enabled = false;
                            }

                        }
                    }

                }
                FormatoGrid();
                DeshabilitaOrdGrid();
                SumaBillSol();
                SumaMonSol();
                SumaBillDol();

            }
        }
        private void habilitarObjetos(bool lActiva)
        {
            this.dtgMonedas.Enabled = !lActiva;
            this.dtgBilletes.Enabled = !lActiva;
            this.dtgBillDolares.Enabled = !lActiva;
            this.btnGrabar.Enabled = !lActiva;
            this.btnEditar.Enabled = lActiva;
            this.btnCancelar.Enabled = lActiva;
            this.btnImprimir.Enabled = !lActiva;
        }


        private string ValidarCargaVoucher()
        {
            string cRpta = "OK";

            clsCNControlOpe EstCarVou = new clsCNControlOpe();

            string cEstCarVou = EstCarVou.ValidarCargaVoucher(this.dtpFechaSis.Value, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()));

            if (cEstCarVou != "0")
            {
                 MessageBox.Show("Primero debe realizar la cargar voucher Prepago y/o adelanto cuota ", "Cargar Voucher", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cRpta = "ERROR";
            }
            
            return cRpta;
        }

    }
}
