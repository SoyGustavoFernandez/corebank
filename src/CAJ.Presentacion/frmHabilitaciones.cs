using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;
using CRE.CapaNegocio;
using GEN.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmHabilitaciones : frmBase
    {
        private int idIngEgr;
        DataTable tbTipHab;
        DataTable tbTipoHabilitacion;
        DataTable tbMoneda;
        DataTable tbBillete;
        private int pidTipResCaj = 0;
        clsCNControlOpe LisMonBill = new clsCNControlOpe();
        int pnCantidad = 0;
        bool lPideBilletaje;

        public frmHabilitaciones()
        {
            InitializeComponent();
        }

        private void frmHabilitaciones_Load(object sender, EventArgs e)
        {
            DatosUsuario();

            if (string.IsNullOrEmpty(this.txtCodUsu.Text.Trim()))
            {
                MessageBox.Show("No Existe Usuario", "Validar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (cargarTipoResponsable())
            {
                this.Dispose();
                return;
            }
            cboTipResponsable.SelectedIndexChanged += new EventHandler(cboTipResponsable_SelectedIndexChanged);
            if (pnCantidad == 1)//el usuario tiene asignado una sola responsabilidad
            {
                if (validarLimiteCobertura(pidTipResCaj))
                {
                    this.Dispose();
                    return;
                }
                //===========================================================
                //--Validar Inicio de Operaciones
                //===========================================================
                if (validaInicioOpeRegBill(pidTipResCaj))
                {
                    this.Dispose();
                    return;
                }

                if (!CargarTipoHab(pidTipResCaj))
                {
                    this.Dispose();
                    return;
                }
                cboTipResponsable.SelectedValue = pidTipResCaj;
            }
            else
            {
                cboTipResponsable.SelectedIndex = -1;

            }
            this.cboTipoTransaccion.Visible = false;
            this.lblTipoTransac.Visible = false;
     
        }
        private bool validarLimiteCobertura(int idTipoRespCaja)
        {
            bool lRespuesta = false;
            clsCNPerfilUsu Perfil = new clsCNPerfilUsu();
            List<clsLimCobertura> listMonCobert = new List<clsLimCobertura>();
            listMonCobert = Perfil.limiteCobertura(idTipoRespCaja, clsVarGlobal.nIdAgencia);
            if (listMonCobert.Count <= 0)
            {

                MessageBox.Show("Debe asignar los montos del límite de cobertura \n para " + cTipoRespobsaleCaja(idTipoRespCaja), "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lRespuesta = true;
            }
            return lRespuesta;

        }
        private bool cargarTipoResponsable()
        {
            DataTable dtResBov = LisMonBill.cargarTipRespPorUsuarioIniOpe(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem);
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
        public string ValidarInicioOpeCaj(int idTipResCaj)
        {
            string cEstCie = LisMonBill.ValidaIniOpeCaja(clsVarGlobal.dFecSystem, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()), clsVarGlobal.nIdAgencia, idTipResCaj);
            // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada

            switch (cEstCie) // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada  
            {
                case "F":
                    MessageBox.Show("El usuario no inició sus operaciones", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "A":
                    break;
                case "C":
                    MessageBox.Show("El usuario ya cerró sus operaciones", "Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;
                default:
                    MessageBox.Show(cEstCie, "Error al Validar Estado de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;
            }
            return cEstCie;
        }
        private bool ValidaSiInicioOperaciones()
        {
            int idTipResCaj = Convert.ToInt32(cboTipoHab.SelectedValue);
            string cEstCie = LisMonBill.ValidaIniOpeCaja(dtpFechaSis.Value, Convert.ToInt32(cboUsuario.SelectedValue), clsVarGlobal.nIdAgencia, idTipResCaj);
            // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada  
            switch (cEstCie) // Si Estado es: F--> Falta Iniciar, A--> Caja Abierta, C--> Caja Cerrada  
            {
                case "F":
                    MessageBox.Show("El usuario al que está habilitando, NO inició sus operaciones", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                case "A":
                    break;
                case "C":
                    MessageBox.Show("NO puede habilitar, \n El usuario ya cerro sus operaciones", "Validar Cierre de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                default:
                    MessageBox.Show(cEstCie, "Error al Validar Estado de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
            }
            return true;
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
        //private int ValidaRespBoveda()
        //{
        //    int idTipResCaja = Convert.ToInt32(cboTipResponsable.SelectedValue);

        //    clsCNControlOpe ValidaResBov = new clsCNControlOpe();

        //    //// Si nValUsu es: 0--> usuario no Es Responsable de ventanilla, caja pulmón o Bóveda
        //    ////                1-->resonsable de ventanilla
        //    ////                2-->resonsable de caja pulmón
        //    ////                3-->resonsable de Bóveda
        //    DataTable dtResBov = ValidaResBov.RetRespBoveda(Convert.ToInt32(this.txtCodUsu.Text.Trim().ToString()), clsVarGlobal.nIdAgencia, idTipResCaja, clsVarGlobal.dFecSystem);

        //    pnCantidad = dtResBov.Rows.Count;

        //    if (pnCantidad == 0)
        //    {
        //        return 0;
        //    }
        //    return Convert.ToInt32(dtResBov.Rows[0]["idTipResCaj"].ToString());
        //}

        private string ValidadatIng()
        {

            if (this.cboTipoHab.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar el Tipo de Habilitación", "Registro de Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboTipoHab.Select();
                this.cboTipoHab.Focus();
                return "ERROR";
            }

            if (Convert.ToInt32(this.cboTipoTransaccion.SelectedValue) == 0 && cboTipoTransaccion.Visible == true)
            {
                MessageBox.Show("Debe seleccionar el Tipo de Operación", "Registro de Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboTipoTransaccion.Select();
                this.cboTipoTransaccion.Focus();
                return "ERROR";
            }
            if (string.IsNullOrEmpty(this.cboTipoHab.SelectedValue.ToString().Trim()))
            {
                MessageBox.Show("Debe Seleccionar el Tipo de Habilitación", "Registro de Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboTipoHab.Select();
                this.cboTipoHab.Focus();
                return "ERROR";
            }
            if (string.IsNullOrEmpty(this.cboMoneda.SelectedValue.ToString().Trim()))
            {
                MessageBox.Show("Debe Seleccionar el Tipo de Moneda", "Registro de Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboMoneda.Select();
                this.cboMoneda.Focus();
                return "ERROR";
            }
            if (this.cboUsuario.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccionar al Colaborador a quien se Realiza la Habilitación", "Registro de Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboUsuario.Select();
                this.cboUsuario.Focus();
                return "ERROR";
            }
            if (string.IsNullOrEmpty(this.cboUsuario.SelectedValue.ToString().Trim()))
            {
                MessageBox.Show("Debe Seleccionar Usuario Destino", "Registro de Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboUsuario.Select();
                this.cboUsuario.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(this.txtMonHab.Text))
            {
                MessageBox.Show("Debe Ingresar el Monto de la habilitación", "Registro de Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtMonHab.Select();
                this.txtMonHab.Focus();
                return "ERROR";
            }

            if (Convert.ToDecimal (this.txtMonHab.Text) <= 0)
            {
                MessageBox.Show("El Monto de habilitacion debe ser Mayor Cero(0)", "Registro de Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtMonHab.Select();
                this.txtMonHab.Focus();
                return "ERROR";
            }
            if (Convert.ToInt32(cboTipResponsable.SelectedValue) == Convert.ToInt32(cboTipoHab.SelectedValue) && txtCodUsu.Text.Equals(cboUsuario.SelectedValue.ToString()))
            {
                MessageBox.Show("Debe seleccionar un usuario distinto para habilitar", "Registro de Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboUsuario.Select();
                this.cboUsuario.Focus();
                return "ERROR";
            }
            if (string.IsNullOrEmpty(this.txtSustento.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Sustento de la habilitación", "Registro de Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcBase1.SelectedTab = tabPage1;
                this.txtSustento.Select();
                this.txtSustento.Focus();
                return "ERROR";
            }

            return "OK";
        }

        private void LimpiarControles()
        {
            this.txtMonHab.Clear();
            this.txtSustento.Clear();
            this.cboTipoHab.SelectedValue = 1;
            this.cboMoneda.SelectedValue = 1;
            this.cboTipoTransaccion.SelectedValue = 1;
        }

        private void desabilitaCtr(Boolean val)
        {
            this.cboMoneda.Enabled = val;
            this.cboUsuario.Enabled = val;
            this.cboTipoTransaccion.Enabled = val;
            this.txtMonHab.Enabled = val;
            this.txtSustento.Enabled = val;
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

        private bool CargarTipoHab(int idTipResponsable)
        {
            string msg = "";

            clsCNControlOpe LisTipHab = new clsCNControlOpe();
            DataTable tbTipHab = LisTipHab.LisTipHab(clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.nIdAgencia, clsVarGlobal.User.idUsuario, ref msg, idTipResponsable);

            if (msg == "OK")
            {
                if (tbTipHab.Rows.Count <= 0)
                {
                    MessageBox.Show("No Existe Tipos de Habilitación para el Perfil", "Tipos de Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboTipoHab.DataSource = tbTipHab;
                    return false;
                }
                tbTipoHabilitacion = tbTipHab;
                cboTipoHab.DataSource = tbTipHab;
                cboTipoHab.ValueMember = tbTipHab.Columns["idTipHab"].ToString();
                cboTipoHab.DisplayMember = tbTipHab.Columns["cDescripcion"].ToString();

            }
            else
            {
                MessageBox.Show(msg, "Tipos de habilitación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void cargarResHab(int idCargo, string cTipRes)
        {
            string msg = "";
            clsCNControlOpe LisResHab = new clsCNControlOpe();
            DataTable tbTipRes = LisResHab.LisRespHab(idCargo, clsVarGlobal.nIdAgencia, cTipRes, clsVarGlobal.User.idUsuario, ref msg, clsVarGlobal.dFecSystem);
            if (msg == "OK")
            {
                this.cboUsuario.DataSource = tbTipRes;
                this.cboUsuario.ValueMember = tbTipRes.Columns["idUsuario"].ToString();
                this.cboUsuario.DisplayMember = tbTipRes.Columns["cNombre"].ToString();
                this.cboUsuario.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show(msg, "Responsables de habilitación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cboTipoHab_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idTipoHab = cboTipoHab.SelectedValue.ToString();
            if (cboTipoHab.SelectedIndex > -1)
            {
                if (!idTipoHab.Equals("System.Data.DataRowView"))
                {
                    cargarResHab(5, idTipoHab.ToString());

                    lPideBilletaje = MostrarBilletaje();
                    txtMonHab.ReadOnly = lPideBilletaje == true ? true : false;
                    if (lPideBilletaje)
                    {

                        ListarMonedaBilletes();
                        lblMensajeBill.Visible = true;
                    }
                    else
                    {
                        lblMensajeBill.Visible = false;
                    }
                }
            }

        }
        private bool validaBilletajeHab()
        {
            string msge = "";
            int idTipResCaj = Convert.ToInt32(cboTipResponsable.SelectedValue);
            if (idTipResCaj == 3)
            {
                int idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);

                DataTable tbBilHab = LisMonBill.ListarBillBov(clsVarGlobal.nIdAgencia, idMoneda, 2, idTipResCaj, clsVarGlobal.dFecSystem, ref msge);
                for (int i = 0; i < tbBillete.Rows.Count; i++)
                {
                    if (Convert.ToInt32(tbBilHab.Rows[i]["nCantidad"]) < Convert.ToInt32(tbBillete.Rows[i]["nCantidad"]))
                    {
                        MessageBox.Show("Usted no cuenta con la cantidad suficiente para habilitación en denominación de " + tbBilHab.Rows[i]["cDescripcion"].ToString(), "Validar Efectivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true;
                    }
                }

                DataTable tbMonHab = LisMonBill.ListarBillBov(clsVarGlobal.nIdAgencia, idMoneda, 1, idTipResCaj, clsVarGlobal.dFecSystem, ref msge);
                for (int i = 0; i < tbMoneda.Rows.Count; i++)
                {
                    if (Convert.ToInt32(tbMonHab.Rows[i]["nCantidad"]) < Convert.ToInt32(tbMoneda.Rows[i]["nCantidad"]))
                    {
                        MessageBox.Show("Cantidad de " + tbMonHab.Rows[i]["cDescripcion"].ToString() + " , excede para la habilitación", "Validar Efectivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true;
                    }
                }
            }
            return false;
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidadatIng() == "ERROR")
            {
                return;
            }
            this.btnGrabar.Enabled = false;
            //==================================================
            //--Datos de la Habilitación
            //==================================================
            int nTiphab = Convert.ToInt32(this.cboTipoHab.SelectedValue);
            int nTipMon = Convert.ToInt32(this.cboMoneda.SelectedValue);
            int nidUsuOri = Convert.ToInt32(this.txtCodUsu.Text);
            int nidUsuDes = Convert.ToInt32(this.cboUsuario.SelectedValue);
            Decimal nMonHab = Convert.ToDecimal (this.txtMonHab.Text);
            string cSust = this.txtSustento.Text.Trim();
            int idTipResCaja = Convert.ToInt32(this.cboTipResponsable.SelectedValue);

            if (validarLimiteCobertura(nTiphab))
            {
                return;
            }
            if (validarLimiteCobertura(idTipResCaja))
            {
                return;
            }
            //--Valida si inicio operaciones
            if (!ValidaSiInicioOperaciones())
            {
                return;
            }           

            if (this.ValidarBilletaje(nTiphab, clsVarGlobal.dFecSystem, nidUsuDes, "Usuario ya registró billetaje").Equals("R"))
            {
                return;
            }
            //--Valida si tiene monto suficiente para la habilitacion para egresos
            if (ValidaEfectivoSuficiente())
            {
                return;
            }
            if (validaBilletajeHab())
            {
                return;
            }




            if (mostarLimiteCobertura(idTipResCaja))
            {
                return;
            }
            if (mostarLimiteCobertura(nTiphab))
            {
                return;
            }
            //===================================================================
            //Guardar Datos de Monedas Mediante XML
            //===================================================================          
            DataSet dsMoneda = new DataSet("dsMoneda");
            if (tbMoneda != null)
            {
                dsMoneda.Tables.Add(tbMoneda);
            }
            string xmlMoneda = dsMoneda.GetXml();
            xmlMoneda = clsCNFormatoXML.EncodingXML(xmlMoneda);
            dsMoneda.Tables.Clear();

            //===================================================================
            //Guardar Datos de Billetes Mediante XML
            //===================================================================          
            DataSet dsBillete = new DataSet("dsBillete");
            if (tbBillete != null)
            {
                dsBillete.Tables.Add(tbBillete);
            }

            string xmlBillete = dsBillete.GetXml();
            xmlBillete = clsCNFormatoXML.EncodingXML(xmlBillete);
            dsBillete.Tables.Clear();

            //==================================================
            //--Grabar Habilitacion
            //==================================================
            string msge = "";
            clsCNControlOpe GuardarHab = new clsCNControlOpe();
            string nidHab = GuardarHab.GuardarHabilitacion(dtpFechaSis.Value, clsVarGlobal.nIdAgencia, nTiphab,
                                                        nTipMon, nMonHab, cSust, nidUsuOri, nidUsuDes, ref msge, idIngEgr, idTipResCaja, xmlBillete, xmlMoneda, lPideBilletaje);
            if (msge == "OK")
            {
                MessageBox.Show("La Habilitación se Registro Correctamente, NRO HABILITACION: " + nidHab, "Registro de Habilitaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.objFrmSemaforo.oControlBoveda.comprobarLimiteBoveda();
                //this.btnNuevo.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.cboTipoHab.Enabled = false;
                desabilitaCtr(false);
            }
            else
            {
                MessageBox.Show(msge, "Error al Registrar la Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool mostarLimiteCobertura(int idTipResCaj)
        {
            clsCNPerfilUsu PerfilesHab = new clsCNPerfilUsu();
            List<clsLimCobertura> lstMontoCoberturHab = new List<clsLimCobertura>();
            lstMontoCoberturHab = PerfilesHab.limiteCobertura(idTipResCaj, clsVarGlobal.nIdAgencia);
            if (lstMontoCoberturHab.Count <= 0)
            {
                MessageBox.Show("Debe asignar el monto del límite de cobertura para " + cTipoRespobsaleCaja(idTipResCaj), "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
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
        private bool ValidaEfectivoSuficiente()
        {
            int idTipResCaj = Convert.ToInt32(this.cboTipResponsable.SelectedValue);
            clsCNControlOpe ValidaEfectivo = new clsCNControlOpe();
            decimal nMonto = ValidaEfectivo.ObtieneEfectivoActual(clsVarGlobal.nIdAgencia, dtpFechaSis.Value, Convert.ToInt32(txtCodUsu.Text.Trim().ToString()), Convert.ToInt32(cboMoneda.SelectedValue), idTipResCaj);
            if (nMonto < Convert.ToDecimal(txtMonHab.Text))
            {
                MessageBox.Show("Efectivo insuficiente para la habilitación", "Validar Efectivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            desabilitaCtr(true);

            cboTipoHab.Enabled = true;
            this.btnNuevo.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.cboTipoHab.Focus();
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            this.txtMonHab.Text = "0.00";
            Int32 nIdUsuAsesor = Convert.ToInt32(this.cboUsuario.SelectedValue);
            frmLisSolDesembCampo frmLisDesCam = new frmLisSolDesembCampo();
            frmLisDesCam.CargaDatos(nIdUsuAsesor);
            frmLisDesCam.ShowDialog();
            if (frmLisDesCam.nSumDesembCampo > 0.00m)
            {
                this.txtMonHab.Text = frmLisDesCam.nSumDesembCampo.ToString();
            }
            this.txtMonHab.Focus();
        }

        private void cboTipoTransaccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cboTipoTransaccion.SelectedValue.ToString())
            {
                case "1"://origen
                    this.grbUsuDes.Text = "Usuario Origen";
                    idIngEgr = 1;
                    break;
                case "2"://destino                   
                    this.grbUsuDes.Text = "Usuario Destino";
                    idIngEgr = 2;
                    break;
            }
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMoneda.SelectedIndex > -1)
            {
                if (lPideBilletaje)
                {
                    ListarMonedaBilletes();
                }
            }
        }
        private void ListarMonedaBilletes()
        {
            string msge = "";
            int idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
            tbMoneda = LisMonBill.ListarBillMon(idMoneda, 1, ref msge);
            tbBillete = LisMonBill.ListarBillMon(idMoneda, 2, ref msge);

            dtgBilletes.DataSource = tbBillete;
            dtgMonedas.DataSource = tbMoneda;

            dtgBilletes.Enabled = true;
            dtgBilletes.ReadOnly = false;
            dtgMonedas.Enabled = true;
            dtgMonedas.ReadOnly = false;
            tbBillete.Columns["cDescripcion"].ReadOnly = true;
            tbMoneda.Columns["cDescripcion"].ReadOnly = true;
            tbBillete.Columns["nCantidad"].ReadOnly = false;
            tbBillete.Columns["nTotal"].ReadOnly = false;
            tbMoneda.Columns["nCantidad"].ReadOnly = false;
            tbMoneda.Columns["nTotal"].ReadOnly = false;
            dtgMonedas.Columns["nCantidadSI"].ReadOnly = false;
            dtgMonedas.Columns["nTotalSI"].ReadOnly = true;
            dtgBilletes.Columns["nCantidadB"].ReadOnly = false;
            dtgBilletes.Columns["nTotalB"].ReadOnly = true;
            dtgBilletes.Columns["cDescripcionB"].ReadOnly = true;
            dtgMonedas.Columns["cDescripcionSI"].ReadOnly = true;

            txtMonBillete.Text = "0.00";
            txtMonTotal.Text = "0.00";
            txtMonMoneda.Text = "0.00";
            txtMonHab.Text = "0.00";

        }
        private bool MostrarBilletaje()
        {
            bool lRespuesta = false;
            foreach (DataRow dtRow in tbTipoHabilitacion.Rows)
            {
                if (dtRow["idTipHab"].ToString().Equals(cboTipoHab.SelectedValue.ToString()))
                {
                    lRespuesta = Convert.ToBoolean(dtRow["lNecBilletaje"].ToString());
                }
            }
            return lRespuesta;
        }

        private void dtgBilletes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {  
            if (e.RowIndex == -1) return;

            if (dtgBilletes.Columns[e.ColumnIndex].Name == "nCantidadB")
            {

                decimal sumB = 0;
                foreach (DataGridViewRow row in dtgBilletes.Rows)
                {
                    row.Cells["nTotalB"].Value = Convert.ToDecimal(row.Cells["nCantidadB"].Value) * Convert.ToDecimal(row.Cells["nValorB"].Value);
                    sumB = sumB + Convert.ToDecimal(row.Cells["nTotalB"].Value);
                }
                txtMonBillete.Text = sumB.ToString();
                txtMonTotal.Text = (Convert.ToDecimal(txtMonMoneda.Text) + sumB).ToString();
                txtMonHab.Text = txtMonTotal.Text;
            }
        }

        private void dtgMonedas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (dtgMonedas.Columns[e.ColumnIndex].Name == "nCantidadSI")
            {
                decimal sumM = 0;
                foreach (DataGridViewRow row in dtgMonedas.Rows)
                {
                    row.Cells["nTotalSI"].Value = Convert.ToDecimal(row.Cells["nCantidadSI"].Value) * Convert.ToDecimal(row.Cells["nValorSI"].Value);
                    sumM = sumM + Convert.ToDecimal(row.Cells["nTotalSI"].Value);
                }
                txtMonMoneda.Text = sumM.ToString();
                txtMonTotal.Text = (Convert.ToDecimal(txtMonBillete.Text) + sumM).ToString();
                txtMonHab.Text = txtMonTotal.Text;
            }
        }
        private void tabPage2_Enter(object sender, EventArgs e)
        {
            if (!lPideBilletaje)
            {
                MessageBox.Show("El tipo de habilitación no requiere billetaje", "Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcBase1.SelectedIndex = 0;
            }
        }

        private void cboTipResponsable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipResponsable.SelectedIndex > -1)
            {
                string idTipoRes = this.cboTipResponsable.SelectedValue.ToString();
                if (!idTipoRes.Equals("System.Data.DataRowView"))
                {


                    if (validaInicioOpeRegBill(Convert.ToInt32(idTipoRes)))
                    {
                        return;
                    }

                    CargarTipoHab(Convert.ToInt32(idTipoRes));
                }
            }
        }
        private bool validaInicioOpeRegBill(int idTipoRes)
        {
            //===========================================================
            //--Validar Inicio de Operaciones
            //===========================================================
            string cResp = ValidarInicioOpeCaj(Convert.ToInt32(idTipoRes));
            if (!cResp.Equals("A"))
            {
                btnGrabar.Enabled = false;
                grbSustento.Enabled = false;
                grbTipoHa.Enabled = false;
                grbUsuDes.Enabled = false;
                grbBilletes.Enabled = false;
                return true;
            }
            else
            {
                if (this.ValidarBilletaje(Convert.ToInt32(idTipoRes), clsVarGlobal.dFecSystem, Convert.ToInt32(txtCodUsu.Text), "Usuario ya registró billetaje").Equals("R"))
                {
                    btnGrabar.Enabled = false;
                    grbSustento.Enabled = false;
                    grbTipoHa.Enabled = false;
                    grbUsuDes.Enabled = false;
                    grbBilletes.Enabled = false;
                    return true;
                }
                else
                {


                    btnGrabar.Enabled = true;
                    grbSustento.Enabled = true;
                    grbTipoHa.Enabled = true;
                    grbUsuDes.Enabled = true;
                    grbBilletes.Enabled = true;
                }
            }
            return false;
        }
        private void cboUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

 
        private void dtgBilletes_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (this.dtgBilletes.Columns[e.ColumnIndex].Name == "nCantidadB")
            {
                if (e != null)
                {
                    if (e.Value != null)
                    {
                        try
                        {
                            int numValue;
                            bool parsed = Int32.TryParse(e.Value.ToString(), out numValue);

                            if (!parsed)
                                e.Value = 0;
                            else
                            {
                                e.Value = numValue;
                            }
                            
                            // Show the event is handled.
                            e.ParsingApplied = true;

                        }
                        catch (FormatException)
                        {
                            e.ParsingApplied = false;
                        }
                    }
                }
            }
        }

        private void dtgMonedas_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (this.dtgMonedas.Columns[e.ColumnIndex].Name == "nCantidadSI")
            {
                if (e != null)
                {
                    if (e.Value != null)
                    {
                        try
                        {
                            int numValue;
                            bool parsed = Int32.TryParse(e.Value.ToString(), out numValue);

                            if (!parsed)
                                e.Value = 0;
                            else
                            {
                                e.Value = numValue;
                            }

                            // Show the event is handled.
                            e.ParsingApplied = true;

                        }
                        catch (FormatException)
                        {
                            e.ParsingApplied = false;
                        }
                    }
                }
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
        void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 13)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void dtgMonedas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }
    }
}
