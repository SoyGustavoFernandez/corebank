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
using CAJ.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;
using GEN.BotonesBase;
using Microsoft.Reporting.WinForms;

namespace CAJ.Presentacion
{
    public partial class frmInicioOpe : frmBase
    {
        #region Variables Globales

        string mRespValExis = "";
        private int pidTipResCaj = 0;
        private int pnCantidad = 0;
        clsCNControlOpe cncontrolope = new clsCNControlOpe();
        string cResp;

        #endregion

        public frmInicioOpe()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmInicioOP_Load(object sender, EventArgs e)
        {
            btnProcesar.Enabled = true;
            btnImprimirVoucher.Enabled = false;
            DatosUsuario();
            if (string.IsNullOrEmpty(this.txtCodUsu.Text.Trim()))
            {
                MessageBox.Show("No existe usuario", "Validar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
                return;
            }
            if (ValidarSiExisteRespBoveda() == 0)
            {
                MessageBox.Show("No puede iniciar su caja, " + mRespValExis, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
                return;
            }

            if (ValidarCierreRespBoveda())
            {
                MessageBox.Show("Boveda ya cerró, No puede iniciar operaciones", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
                return;
            }


            if (!TiposDeCambio())
            {
                this.Dispose();
                return;
            }
            pidTipResCaj = ValidaRespCaja();
            if (pidTipResCaj == 0)
            {
                MessageBox.Show("Ud. no es responsable de ventanilla, caja pulmón o bóveda.", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
                return;
            }
            cboTipResponsable.SelectedIndexChanged -= new EventHandler(cboTipResponsable_SelectedIndexChanged);
            cargarTipoResponsable();
            cboTipResponsable.SelectedIndexChanged += new EventHandler(cboTipResponsable_SelectedIndexChanged);

            grbBase3.Visible = false;

            if (pnCantidad == 1)//el usuario tiene asignado una sola responsabilidad
            {
                cboTipResponsable.SelectedValue = pidTipResCaj;
                if (validarLimiteCobertura(pidTipResCaj))
                {
                    return;
                }

                DataTable tbSaldos = cncontrolope.ListarSaldos(dtpFechaSis.Value, Convert.ToInt32(txtCodUsu.Text.Trim().ToString()), clsVarGlobal.nIdAgencia, pidTipResCaj);
                if (tbSaldos.Rows.Count > 0)
                {
                    txtMonSoles.Text = tbSaldos.Rows[0]["nMontoCieSol"].ToString();
                    txtMonDolares.Text = tbSaldos.Rows[1]["nMontoCieDol"].ToString();
                }
                else
                {
                    txtMonSoles.Text = "0.00";
                    txtMonDolares.Text = "0.00";
                }
                cboTipResponsable.Enabled = false;
            }
            else
            {
                cboTipResponsable.SelectedIndex = -1;
            }

        }

        private void cboTipResponsable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipResponsable.SelectedIndex > -1)
            {
                string idTipoRes = this.cboTipResponsable.SelectedValue.ToString();
                if (!idTipoRes.Equals("System.Data.DataRowView"))
                {
                    cResp = ValidarInicioOpeCaj(Convert.ToInt32(idTipoRes));
                    btnImprimirVoucher.Enabled = false;
                    // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada
                    switch (cResp)
                    {
                        case "F":
                            btnProcesar.Enabled = true;
                            break;
                        case "A":
                            btnProcesar.Enabled = false;
                            btnImprimirVoucher.Enabled = true;
                            cargarSaldoApertura(Convert.ToInt32(idTipoRes), Convert.ToInt32(txtCodUsu.Text.Trim().ToString()));
                            MessageBox.Show(@"El Usuario ya Inicio sus Operaciones", @"Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case "C":
                            btnProcesar.Enabled = false;
                            MessageBox.Show(@"El usuario ya cerró sus operaciones", @"Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        default:
                            btnProcesar.Enabled = false;
                            MessageBox.Show(cResp, @"Error al Validar Estado de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    if (!cResp.Equals("A"))
                    {
                        DataTable tbSaldos = cncontrolope.ListarSaldos(dtpFechaSis.Value, Convert.ToInt32(txtCodUsu.Text.Trim().ToString()), clsVarGlobal.nIdAgencia, Convert.ToInt32(idTipoRes));
                        if (tbSaldos.Rows.Count > 0)
                        {
                            txtMonSoles.Text = tbSaldos.Rows[0]["nMontoCieSol"].ToString();
                            txtMonDolares.Text = tbSaldos.Rows[1]["nMontoCieDol"].ToString();
                        }
                        else
                        {
                            txtMonSoles.Text = "0.00";
                            txtMonDolares.Text = "0.00";
                        }
                    }

                }
            }
        }

        private void cargarSaldoApertura(int idTipResCaj,int idUsuario)
        {
            string msge = "";
            DataTable tbSalIniOpe = cncontrolope.SaldoinicialOpe(dtpFechaSis.Value, idUsuario, clsVarGlobal.nIdAgencia, idTipResCaj, ref msge);
            if (msge == "OK")
            {
                if (tbSalIniOpe.Rows.Count > 0)
                {
                    txtMonSoles.Text = tbSalIniOpe.Rows[0]["nSalIniSol"].ToString();
                    txtMonDolares.Text = tbSalIniOpe.Rows[0]["nSalIniDol"].ToString();
                }
            }
        }
        private void btnImprimirVoucher_Click(object sender, EventArgs e)
        {
            var dtIdIniOpe = cncontrolope.CNRetornaIdIniOpeCaj(clsVarGlobal.dFecSystem, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()), clsVarGlobal.nIdAgencia, Convert.ToInt32(this.cboTipResponsable.SelectedValue));

            if (dtIdIniOpe.Rows.Count > 0)
            {
                ImpresionVoucher(Convert.ToInt32(dtIdIniOpe.Rows[0][0]), 3, 0, 0, 0, 0, 0, 1);
            }
            else
            {
                MessageBox.Show(@"No se encontró información de inicio de operaciones", "Validar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            int idTipResCaj = Convert.ToInt32(cboTipResponsable.SelectedValue);
            if (idTipResCaj == 0)
            {
                MessageBox.Show("Debe elegir el tipo de responsable...", "Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            clsCNControlOpe GrabarOpe = new clsCNControlOpe();

            if (validarLimiteCobertura(idTipResCaj))
            {
                return;
            }
            if (idTipResCaj == 3)
            {
                if (validaSaldoBovedaAnt())
                {
                    MessageBox.Show(@"El saldo de boveda le debe ser reasignado...", @"Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var Msg = MessageBox.Show(@"Esta seguro de Realizar el Inicio de Operaciones?...", @"Inicio de Operaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Msg == DialogResult.Yes)
            {
                int Rpta = 0;
                Decimal nMonSol = Convert.ToDecimal(txtMonSoles.Text);
                Decimal nMonDol = Convert.ToDecimal(txtMonDolares.Text);


                Rpta = GrabarOpe.GrabarIniOpe(dtpFechaSis.Value, Convert.ToInt32(txtCodUsu.Text), nMonSol, nMonDol, clsVarGlobal.nIdAgencia, idTipResCaj);

                if (Rpta != 0)
                {
                    MessageBox.Show(@"El Inicio de Operaciones se Realizó Correctamente...", @"Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnProcesar.Enabled = false;
                    btnImprimirVoucher.Enabled = true;
                    int idIniOpe = Convert.ToInt32(Rpta);
                    ImpresionVoucher(idIniOpe, 3, 0, 0, 0, 0, 0, 1);
                    if (idTipResCaj == 1)
                    {
                        this.objFrmSemaforo.ValidarSaldoSemaforo();
                    }
                    this.objFrmSemaforo.oControlBoveda.comprobarLimiteBoveda();
                }
                else
                {
                    MessageBox.Show(@"Error al iniciar operaciones", @"Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Métodos
        private bool validaSaldoBovedaAnt()
        {
            bool lSalBov = false;

            clsCNControlOpe LisTipRes = new clsCNControlOpe();
            DataTable dtValBov = LisTipRes.CNValorBoveda(clsVarGlobal.nIdAgencia, Convert.ToInt32(txtCodUsu.Text));
            if (dtValBov.Rows.Count > 0)
            {
                decimal nSaldoSol = Convert.ToDecimal(dtValBov.Rows[0]["nValorSol"].ToString());
                decimal nSaldoDol = Convert.ToDecimal(dtValBov.Rows[0]["nValorDol"].ToString());
                if ((nSaldoSol + nSaldoDol) > 0)
                {
                    lSalBov = true;
                }
            }
            return lSalBov;
        }
        private bool validarLimiteCobertura(int nTipoRespCaja)
        {
            bool lRespuesta = false;
            clsCNPerfilUsu Perfil = new clsCNPerfilUsu();
            List<clsLimCobertura> listMonCobert = new List<clsLimCobertura>();
            listMonCobert = Perfil.limiteCobertura(nTipoRespCaja, clsVarGlobal.nIdAgencia);
            if (listMonCobert.Count <= 0)
            {

                MessageBox.Show("Debe asignar los montos del límite de cobertura \n para " + cTipoRespobsaleCaja(nTipoRespCaja), "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lRespuesta = true;
            }
            return lRespuesta;

        }

        public string cTipoRespobsaleCaja(int idTipResCaj)
        {
            string cTipResCaj = "";
            switch (idTipResCaj)
            {
                case 1:
                    cTipResCaj = "VENTANILLA";
                    break;
                case 2:
                    cTipResCaj = "CAJA PULMÓN";
                    break;
                case 3:
                    cTipResCaj = "BÓVEDA";
                    break;
            }
            return cTipResCaj;
        }

        private bool cargarTipoResponsable()
        {
            clsCNControlOpe LisTipRes = new clsCNControlOpe();
            DataTable dtResBov = LisTipRes.cargarTipRespPorUsuarioAsg(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem);
            bool lRespuesta = false;
            if (dtResBov.Rows.Count == 1)
            {
                //===========================================================
                //--Validar Inicio de Operaciones por el tipo de responsable
                //===========================================================
                cResp = ValidarInicioOpeCaj(Convert.ToInt32(dtResBov.Rows[0]["idTipResCaj"].ToString()));
                // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada
                switch (cResp)
                {
                    case "F":
                        break;
                    case "A":
                        btnProcesar.Enabled = false;
                        btnImprimirVoucher.Enabled = true;
                        MessageBox.Show("El Usuario ya Inicio sus Operaciones", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lRespuesta = true;
                        break;
                    case "C":
                        MessageBox.Show("El usuario ya cerró sus operaciones", "Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lRespuesta = true;
                        break;
                    default:
                        MessageBox.Show(cResp, "Error al Validar Estado de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lRespuesta = true;
                        break;
                }
            }
            else
            {
                string cMensaje = "El usuario como : \n ";

                int nCantidad = dtResBov.Rows.Count;
                DataTable dtResultado = dtResBov.Clone();
                for (int i = 0; i <= nCantidad - 1; i++)
                {

                    //===========================================================
                    //--Validar Inicio de Operaciones por el tipo de responsable
                    //===========================================================
                    string cResp = ValidarInicioOpeCaj(Convert.ToInt32(dtResBov.Rows[i]["idTipResCaj"].ToString()));
                    if (cResp.Equals("F"))
                    {
                        string exprecion = "idTipResCaj = " + dtResBov.Rows[i]["idTipResCaj"].ToString();
                        DataRow[] dt = dtResBov.Select(exprecion);
                        dtResultado.Rows.Add(dt[0]["idTipResCaj"], dt[0]["cTipResponsable"].ToString());
                    }
                    else
                    {
                        cMensaje = cMensaje + "• " + dtResBov.Rows[i]["cTipResponsable"] + retornaMensaje(cResp) + " \n ";
                    }

                    if (nCantidad - 1 == i && dtResultado.Rows.Count <= 0)
                    {
                        MessageBox.Show(cMensaje, "Validar inicio de operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lRespuesta = true;
                    }
                }
                btnProcesar.Enabled = false;
            }
            cboTipResponsable.ValueMember = dtResBov.Columns["idTipResCaj"].ToString();
            cboTipResponsable.DisplayMember = dtResBov.Columns["cTipResponsable"].ToString();
            cboTipResponsable.DataSource = dtResBov;
            return lRespuesta;

        }

        private string retornaMensaje(string cResp)
        {
            string cMensaje = "";
            // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada
            switch (cResp)
            {
                case "F":
                    break;
                case "A":
                    cMensaje = " ya inicio sus operaciones.";
                    break;
                case "C":
                    cMensaje = " ya cerró sus operaciones.";
                    break;
                default:
                    cMensaje = ", error al validar estado de operaciones.";
                    break;
            }
            return cMensaje;
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

            if (pnCantidad == 0)
            {
                return 0;
            }

            return Convert.ToInt32(dtResBov.Rows[0]["idTipResCaj"].ToString());

        }

        public string ValidarInicioOpeCaj(int idTipResCaj)
        {
            string cEstCie = cncontrolope.ValidaIniOpeCaja(clsVarGlobal.dFecSystem, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()), clsVarGlobal.nIdAgencia, idTipResCaj);
            return cEstCie;
        }

        private int ValidarSiExisteRespBoveda()
        {
            clsCNControlOpe ValResBov = new clsCNControlOpe();
            return ValResBov.CNValidarExisRespBoveda(clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, ref mRespValExis);
        }

        private bool ValidarCierreRespBoveda()
        {
            clsCNControlOpe ValResBov = new clsCNControlOpe();
            return ValResBov.CNValidarCierreBoveda(clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem); //True--No Puede Iniciar Ope.
        }

        private bool TiposDeCambio()
        {
            clsCNGenAdmOpe dtTipCam = new clsCNGenAdmOpe();
            DataTable tbTipCam = dtTipCam.RetornaTiposCambio(clsVarGlobal.dFecSystem);
            if (tbTipCam.Rows.Count <= 0)
            {
                MessageBox.Show("No Existe Tipos de Cambio, para Iniciar Operaciones", "Validar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
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

        #endregion
    }
}
