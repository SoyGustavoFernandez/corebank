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
using DEP.CapaNegocio;
using GEN.Funciones;
using CRE.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;
using CLI.CapaNegocio; 


namespace DEP.Presentacion
{
    public partial class frmTransferencias : frmBase
    {
        bool  lIsAfectoITFRep, lIsDepAhoProg, lisBloCta, lisCtaOP, lIsDepMenEdad,lIsProdCTS,lPagarInscripcion=false;
        int x_nTipOpe = 11, p_idCta = 0, idCliOrigen, idCliDestino, idTipoPersonaOrigen, idProductoOrigen, nPlaCtaOrigen, nTipoTransfer,
            x_idMonedaOrigen, x_idMonedaDestino, nContOrden = 0, idInscripcion = 0;
        Decimal nMonMinOpeOri = 0.00m, nMonMinSalDisOrigen = 0.00m, nSaldoDisp = 0.00m, nMonBloqCta = 0.00m;
        string xmlPpg;
        decimal nmonAportePac, nmonFondoPac, nMora;
        DataTable dtbIntervCtaRet = new DataTable();
        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsCNTransferencia clsTransfer = new clsCNTransferencia();
        List<clsDetalleAporte> detalleAporte = new List<clsDetalleAporte>();
        List<clsDetalleFondo> detalleFondo = new List<clsDetalleFondo>();
        clsSocio objsocio = new clsSocio();
        clsCNSocio cnsocio = new clsCNSocio();
        clsCNAporte cnaporte = new clsCNAporte();
        clsCNFondoMortuorio cnfondo = new clsCNFondoMortuorio();
        DataTable dtAporte = new DataTable();
        DataTable dtFondo = new DataTable();
        DataTable dtDetallePago = new DataTable();
        DataTable dtDetalleRetiro = new DataTable();
        DataTable dtComisionRet = new DataTable();
        DataTable dtComisionOpe = new DataTable();
        DataTable dtComisionOpeTotal = new DataTable();
        DataTable dtComisionRetTotal = new DataTable();
        DataTable dtPlanPago = new DataTable();
        clsFunUtiles FunTruncar = new clsFunUtiles();
        DataTable dtListTipTrans;
        clsCNBuscarCli BusPerson = new clsCNBuscarCli();
        public frmTransferencias()
        {
            InitializeComponent();
            TipoTransferencia();
        }

        private void frmTransferencias_Load(object sender, EventArgs e)
        {
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }
            //---------------------------------------------------
            //--Validar si se va a Trabajar con Tarjetas o NO.
            //---------------------------------------------------
            if (clsVarApl.dicVarGen["nIndTrabTarj"] == 1)
            {
                this.Text = "Transferencia de Cuentas (Presione F5 para Trabajar con Tarjetas)";
            }
            else
            {
                this.Text = "Transferencia de Cuentas";
            }
            conBusCtaAhoOrigen.nTipOpe = x_nTipOpe;  //--Operación de Retiro
            conBusCtaAhoOrigen.pnIdMon = 0;  //--Para Retiro No es Necesario la MOneda, debe Listar Todas las Cuentas.
            conSolesDolar.iMagenMoneda(0);
            EstructurPago();
        }
        private void conBusCtaAhoOrigen_ClicBusCta(object sender, EventArgs e)
        {
            LimpiarCtrl();
            p_idCta = 0;
            if (!string.IsNullOrEmpty(conBusCtaAhoOrigen.txtNroCta.Text) && Convert.ToInt32(conBusCtaAhoOrigen.txtNroCta.Text) > 0)
            {
                p_idCta = Convert.ToInt32(conBusCtaAhoOrigen.txtNroCta.Text);
                idCliOrigen = conBusCtaAhoOrigen.idcli;
                DatosCuenta(p_idCta);
            }
        }
        public void LimpiarCtrl()
        {
            p_idCta = 0;
            txtProductoOrigen.Text = "";
            txtNumFirOri.Text = "0";
            cboMonedaOrigen.SelectedValue = 1;
            txtSaldoDisp.Text = "0.00";
            cboTipoCuentaOrigen.SelectedValue = 1;
            txtITFRet.Text = "0.00";
            txtComisionRetiro.Text = "0.00";
            txtTotalOpeTrans.Text = "0.00";
            txtMonto.Text="0.00";
        }
        public void LimpiarValores()
        {
            idCliOrigen = 0;
            idCliDestino = 0;
            idTipoPersonaOrigen = 0;
            idProductoOrigen = 0;
            nPlaCtaOrigen = 0;
            x_idMonedaOrigen = 0;
            x_idMonedaDestino = 0;
            nContOrden = 0;
            idInscripcion = 0;
            nMonMinOpeOri = 0.00m;
            nMonMinSalDisOrigen = 0.00m;
            nSaldoDisp = 0.00m;
            nMonBloqCta = 0.00m;
            nmonAportePac = 0;
            nmonFondoPac = 0;
            nMora = 0;
            if (dtbIntervCtaRet.Rows.Count>0)
            {
                dtbIntervCtaRet.Rows.Clear();
            }
            if (dtAporte.Rows.Count>0)
            {
                dtAporte.Rows.Clear();
            }
            if (dtFondo.Rows.Count>0)
            {
                dtFondo.Rows.Clear();
            }
            if (dtDetallePago.Rows.Count>0)
            {
                dtDetallePago.Rows.Clear();
            }
            if (dtDetalleRetiro.Rows.Count>0)
            {
                dtDetalleRetiro.Rows.Clear();
            }
            if (dtComisionRet.Rows.Count>0)
            {
                dtComisionRet.Rows.Clear();
            }
            if (dtComisionOpe.Rows.Count>0)
            {
                dtComisionOpe.Rows.Clear();
            }
            if (dtComisionOpeTotal.Rows.Count>0)
            {
                dtComisionOpeTotal.Rows.Clear();
            }
            if (dtComisionRetTotal.Rows.Count>0)
            {
                dtComisionRetTotal.Rows.Clear();
            }
            if (dtPlanPago.Rows.Count>0)
            {
                dtPlanPago.Rows.Clear();
            }
                    
            
        }
        //==================================================
        //--Buscar Datos de la Cuenta
        //==================================================
        private void DatosCuenta(int idCta)
        { 
            btnGrabar.Enabled = false;

            conSolesDolar.iMagenMoneda(0);
            //--===================================================================================
            //--ValidarBloqueo de la Cuenta
            //--===================================================================================
            string cMsg = "";
            clsCNOperacionDep clsBloq = new clsCNOperacionDep();
            if (!clsBloq.ValidarBloqueoCta(idCta, x_nTipOpe, ref cMsg))
            {
                MessageBox.Show(cMsg, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                p_idCta = 0;
                LimpiarOtrosCtrl();
                return;
            }

            //--===================================================================================
            //--Cargar Datos de la Cuenta
            //--===================================================================================
            DataTable dtbNumCuentas = clsDeposito.CNRetornaDatosCuenta(idCta, "1", x_nTipOpe);

            if (dtbNumCuentas.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtbNumCuentas.Rows[0]["idUsuarioqBlo"].ToString()))
                {
                    int idusuBlo = Convert.ToInt32(dtbNumCuentas.Rows[0]["idUsuarioqBlo"].ToString());
                    clsCNRetornaNumCuenta RetUsuario = new clsCNRetornaNumCuenta();
                    DataTable dtUsu = RetUsuario.BusUsuBlo(idusuBlo);
                    string cUserBloqueo = dtUsu.Rows[0][0].ToString();
                    MessageBox.Show("La Cuenta esta Siendo Consultada por Otro Usuario: " + cUserBloqueo, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    p_idCta = 0;
                    LimpiarOtrosCtrl();
                    btnGrabar.Enabled = false;
                    return;
                }
                if (Convert.ToInt16(dtbNumCuentas.Rows[0]["idCaracteristica"].ToString()) == 4)
                {
                    MessageBox.Show("La Cuenta se Encuentra Inmovilizada, No puede Realizar Operaciones", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimpiarOtrosCtrl();
                    btnGrabar.Enabled = false;
                    return;
                }
                txtProductoOrigen.Text = dtbNumCuentas.Rows[0]["cProducto"].ToString();
                idTipoPersonaOrigen = Convert.ToInt16(dtbNumCuentas.Rows[0]["idTipoPersona"].ToString());
                idProductoOrigen = Convert.ToInt16(dtbNumCuentas.Rows[0]["idProducto"].ToString());
                cboMonedaOrigen.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idMoneda"].ToString());
                x_idMonedaOrigen = Convert.ToInt16(dtbNumCuentas.Rows[0]["idMoneda"].ToString());
                cboTipoCuentaOrigen.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idTipoCuenta"].ToString());
                txtNumFirOri.Text = dtbNumCuentas.Rows[0]["nNumeroFirmas"].ToString();
                txtSaldoDisp.Text = dtbNumCuentas.Rows[0]["nSaldoDis"].ToString();
                lIsAfectoITFRep = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsAfectoITF"].ToString());
                nMonMinOpeOri = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nMonMinOpe"].ToString());
                nMonMinSalDisOrigen = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nSaldoMinimo"].ToString());
                lIsDepAhoProg = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsDepAhoProg"].ToString());
                nSaldoDisp = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nSaldoDis"].ToString());
                nPlaCtaOrigen = Convert.ToInt32(dtbNumCuentas.Rows[0]["nPlazoCta"].ToString());
                nMonBloqCta = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nMonTotBloq"].ToString());
                lisBloCta = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lisBloqCta"].ToString());
                lisCtaOP = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsCtaOrdPago"].ToString());
                lIsDepMenEdad = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsDepMenEdad"].ToString());
                lIsProdCTS = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lisCtaCTS"].ToString());
                if (nMonBloqCta >= nSaldoDisp)
                {
                    MessageBox.Show("La Cuenta no Tiene Saldo, porque Tiene Bloqueo por Monto", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimpiarCtrl();
                    LimpiarOtrosCtrl();
                    btnGrabar.Enabled = false;
                    return;
                }

                if (nSaldoDisp - nMonBloqCta < nMonMinOpeOri + nMonMinSalDisOrigen)
                {
                    MessageBox.Show("El Saldo Disponible, es Menor a Monto Mínimo Permitido", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimpiarCtrl();
                    LimpiarOtrosCtrl();
                    btnGrabar.Enabled = false;
                    return;
                }

                if (nSaldoDisp - nMonBloqCta < nMonMinSalDisOrigen)
                {
                    MessageBox.Show("El Saldo de la Cuenta, es Menor al Saldo Mínimo", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimpiarCtrl();
                    LimpiarOtrosCtrl();
                    btnGrabar.Enabled = false;
                    return;
                }

            }
            else
            {
                LimpiarOtrosCtrl();
                return;
            }
            //--===================================================================================
            //--Cargar de Intervinientes de la Cuenta
            //--===================================================================================
            dtbIntervCtaRet = clsDeposito.CNRetornaIntervinientesCuenta(idCta);

            if (dtbIntervCtaRet.Rows.Count == 0)
            {
                MessageBox.Show("La Cuenta no Tiene Intervinientes..VERIFICAR...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarCtrl();
                LimpiarOtrosCtrl();
                btnGrabar.Enabled = false;
                return;
            }
            conBusCtaAhoOrigen.btnBusCliente.Enabled = false;
            conBusCtaAhoOrigen.txtNroCta.Enabled = false;
            clsDeposito.CNUpdUsoCuenta(p_idCta, clsVarGlobal.User.idUsuario);
            conSolesDolar.iMagenMoneda(Convert.ToInt32(cboMonedaOrigen.SelectedValue));
            btnCancelar1.Enabled = true;
            btnBusqueda.Enabled = true;
          //  txtNroCta.Enabled = true;
            cboTipoTransfer.Enabled = true;

        }
          private void LimpiarOtrosCtrl()
        {
            conBusCtaAhoOrigen.txtCodIns.Text = "";
            conBusCtaAhoOrigen.txtCodAge.Text = "";
            conBusCtaAhoOrigen.txtCodMod.Text = "";
            conBusCtaAhoOrigen.txtCodMon.Text = "";
            conBusCtaAhoOrigen.txtNroCta.Text = "";
            conBusCtaAhoOrigen.txtCodCli.Text = "";
            conBusCtaAhoOrigen.txtNroDoc.Text = "";
            conBusCtaAhoOrigen.txtNombre.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void TipoTransferencia()
        {
            dtListTipTrans = clsTransfer.CNListaTipoTransferencia();
            if (dtListTipTrans.Rows.Count>0)
            {
                cboTipoTransfer.DataSource = dtListTipTrans;
                cboTipoTransfer.ValueMember = dtListTipTrans.Columns[0].ToString();
                cboTipoTransfer.DisplayMember = dtListTipTrans.Columns[1].ToString();
                cboTipoTransfer.SelectedIndex = 1;
            }
 
        }

        private void cboTipoTransfer_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarCuentaTrans();
            idCliDestino = 0;
            btnAgregar1.Enabled = false;
            x_idMonedaDestino = 0;
            if (cboTipoTransfer.SelectedIndex>0)
            {
                nTipoTransfer = Convert.ToInt32(cboTipoTransfer.SelectedValue);
                
            }
            
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            LimpiarCuentaTrans();
            //Desbloquear las cuentas si
            idCliDestino = 0;
            x_idMonedaDestino = 0;

            FrmBusCli frmbuscarcli = new FrmBusCli();
            frmbuscarcli.ShowDialog();

            if (frmbuscarcli.pcCodCli!= null)
            {
                if (Convert.ToInt32(frmbuscarcli.pcCodCli) == clsVarGlobal.User.idCli)
                {
                    MessageBox.Show("El Mismo usuario No Puede Realizar Operaciones con su Cuenta", "Validar Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //--===================================================================================
                //--Validar la actualizacion de Datos en caso de menores de edad
                //--===================================================================================

                idCliDestino = Convert.ToInt32(frmbuscarcli.pcCodCli);
                DataTable dtValActCli = clsDeposito.CNValidarActDatCli(idCliDestino);
                
                if (Convert.ToBoolean(dtValActCli.Rows[0]["lReqUpdate"]))
                {
                    MessageBox.Show("Debe de actualizar información del cliente", "Validación de datos de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                switch (nTipoTransfer)
                {
                    //CREDITOS
                    case 1:
                        DatosCuentaCre();
                        break;
                    //AHORROS
                    case 2:
                        DatoCuentasDep(idCliDestino);
                        break;
                    //PAGO DE APORTE Y FONDO
                    default:
                        if (frmbuscarcli.pcCodCliLargo != null && frmbuscarcli.pcCodCliLargo != "")
                        {
                            txtCodIns.Text = frmbuscarcli.pcCodCliLargo.Substring(0, 3);
                            txtCodAge.Text = frmbuscarcli.pcCodCliLargo.Substring(3, 3);
                            txtCodMod.Text = "";
                            txtCodMon.Text = "";

                            txtCliente.Text = frmbuscarcli.pcNomCli;
                        }
                        else //CUANDO NO SELECCIONA NADA, CANCELA O CIERRA
                        {
                            LimpiarCuentaTrans();
                        }
                        DatosAporte();
                        break;
                }
                EstructuraGrid();
            }
            
        }
        private void EstructuraGrid()
        {

            if (dtDetallePago.Columns.Count <= 0)
            {
                dtDetallePago.Columns.Add("idOrden", typeof(int));
                dtDetallePago.Columns.Add("idCuenta", typeof(int));
                dtDetallePago.Columns.Add("idcli", typeof(int));
                dtDetallePago.Columns.Add("idTipoOpe", typeof(int));
                dtDetallePago.Columns.Add("cTipoOpe", typeof(string));
                dtDetallePago.Columns.Add("nMontoSugerido", typeof(decimal));
                dtDetallePago.Columns.Add("nMontoOpe", typeof(decimal));
                dtDetallePago.Columns.Add("nComision", typeof(decimal));
                dtDetallePago.Columns.Add("nITF", typeof(decimal));
                dtDetallePago.Columns.Add("nMontoTotal", typeof(decimal));
                dtDetallePago.Columns.Add("idAgenciacue", typeof(int));
                dtDetallePago.Columns.Add("nPlazo", typeof(int));
                dtDetallePago.Columns.Add("idProducto", typeof(int));
                dtDetallePago.Columns.Add("idMoneda", typeof(int));
                dtDetallePago.Columns.Add("idTipoPersona", typeof(int));
                dtDetallePago.Columns.Add("lIndicaPago", typeof(bool));
            }
            dtgCuentasPago.DataSource = dtDetallePago;
            dtgCuentasPago.Columns["idOrden"].Visible = false;
            dtgCuentasPago.Columns["idcli"].Visible = false;
            dtgCuentasPago.Columns["idTipoOpe"].Visible = false;
            dtgCuentasPago.Columns["idAgenciacue"].Visible = false;
            dtgCuentasPago.Columns["nPlazo"].Visible = false;
            dtgCuentasPago.Columns["idProducto"].Visible = false;
            dtgCuentasPago.Columns["idMoneda"].Visible = false;
            dtgCuentasPago.Columns["idTipoPersona"].Visible = false;
            dtgCuentasPago.Columns["lIndicaPago"].Visible = false;

            dtgCuentasPago.Columns["idOrden"].HeaderText = "Nro";
            dtgCuentasPago.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgCuentasPago.Columns["cTipoOpe"].HeaderText = "Tipo Ope";
            dtgCuentasPago.Columns["nMontoSugerido"].HeaderText = "Monto sugerido";
            dtgCuentasPago.Columns["nMontoOpe"].HeaderText = "Monto";
            dtgCuentasPago.Columns["nComision"].HeaderText = "Comisión";
            dtgCuentasPago.Columns["nITF"].HeaderText = "ITF";
            dtgCuentasPago.Columns["nMontoTotal"].HeaderText = "Mon.Tot";

            dtgCuentasPago.Columns["idOrden"].Width = 15;
            dtgCuentasPago.Columns["idCuenta"].Width = 30;
            dtgCuentasPago.Columns["cTipoOpe"].Width = 90;
            dtgCuentasPago.Columns["nMontoSugerido"].Width=50 ;
            dtgCuentasPago.Columns["nMontoOpe"].Width = 60;
            dtgCuentasPago.Columns["nComision"].Width = 60;
            dtgCuentasPago.Columns["nITF"].Width = 60;
            dtgCuentasPago.Columns["nMontoTotal"].Width = 60;
            DeshabilitarSortGrid();
            HabilitarGrid(true);
           
        }
        private void EstructurPago()
        {
            if (dtDetalleRetiro.Columns.Count <= 0)
            {
                dtDetalleRetiro.Columns.Add("idOrden", typeof(int));
                dtDetalleRetiro.Columns.Add("nMontoOpe", typeof(decimal));
                dtDetalleRetiro.Columns.Add("nComision", typeof(decimal));
                dtDetalleRetiro.Columns.Add("nITF", typeof(decimal));
                dtDetalleRetiro.Columns.Add("nMontoTotal", typeof(decimal));
            }
        }
        private void DeshabilitarSortGrid()
        {
            dtgCuentasPago.Columns["idOrden"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgCuentasPago.Columns["idCuenta"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgCuentasPago.Columns["cTipoOpe"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgCuentasPago.Columns["nMontoSugerido"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgCuentasPago.Columns["nMontoOpe"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgCuentasPago.Columns["nComision"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgCuentasPago.Columns["nITF"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgCuentasPago.Columns["nMontoTotal"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        private void HabilitarGrid(Boolean bVal)
        {
            dtgCuentasPago.ReadOnly = !bVal;
            dtgCuentasPago.Columns["idOrden"].ReadOnly = bVal;
            dtgCuentasPago.Columns["idCli"].ReadOnly = bVal;
            dtgCuentasPago.Columns["idCuenta"].ReadOnly = bVal;
            dtgCuentasPago.Columns["cTipoOpe"].ReadOnly = bVal;
            dtgCuentasPago.Columns["nMontoSugerido"].ReadOnly = bVal;
            dtgCuentasPago.Columns["nMontoOpe"].ReadOnly = !bVal;
            dtgCuentasPago.Columns["nComision"].ReadOnly = bVal;
            dtgCuentasPago.Columns["nITF"].ReadOnly = bVal;
            dtgCuentasPago.Columns["nMontoTotal"].ReadOnly = bVal;
            dtgCuentasPago.Columns["idAgenciacue"].ReadOnly = bVal;
        }
        private void DatosAporte()
        {
            objsocio = cnsocio.retornardatossocio(idCliDestino);

            if (objsocio == null)
            {
                MessageBox.Show("Persona seleccionada no es un socio activo", "Validación Socio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                LimpiarCuentaTrans();
              //  this.txtNroCta.Focus();

                return;
            }
            else
            {
                //============== Recuperar Solicitudes Pendientes para Uso Montos especiales (Inscripc, Aporte, Fondo Seg) ==============>
                //Supuesto: Si hay solicitudes pendientes por uso de montos especiales, entonces no debe permitirse pagar hasta que se
                //haya aprobado las solicitudes
                DataTable dtSolAprobac = cnsocio.RecuperarSolAprobacMontosEspeciales(objsocio.idSocio);
                if (dtSolAprobac.Rows.Count > 0)
                {
                    string cmensaje = "";
                    for (int i = 0; i < dtSolAprobac.Rows.Count; i++)
                    {
                        string cTipoOperac = dtSolAprobac.Rows[i]["cTipoOperacion"].ToString();
                        cmensaje = cmensaje + dtSolAprobac.Rows[i]["idSolAproba"].ToString() + " - " + cTipoOperac + " - " + dtSolAprobac.Rows[i]["cEstadoSol"].ToString() + "." + Environment.NewLine;
                    }
                    MessageBox.Show("La inscripción del socio tiene solicitudes pendientes de Aprobación:" + Environment.NewLine + Environment.NewLine + cmensaje, "Búsqueda de Solicitudes de Aprobación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                lPagarInscripcion = cnsocio.EstaPagadoInscripcion(objsocio.idInscripcion);
                txtEstado.Text = "ACTIVO";
                txtNroCta.Text = objsocio.idSocio.ToString();
                idInscripcion = objsocio.idInscripcion;
                if (lPagarInscripcion)
                {
                    txtInscripcion.Text = "0.00";

                }
                else
                {
                    txtInscripcion.Text = string.Format("{0:#,##0.00}", Convert.ToDecimal (objsocio.nInscripcion.ToString()));
                    this.txtInscripcion.Visible = true;
                    this.lblBase2.Visible = true;
                }
                if (Convert.ToInt32(cboTipoTransfer.SelectedValue)==3)
                {
                    RetornarAportes(objsocio.idAporte);
                }
                else
                {
                    RetornarFondoMortuorio(objsocio.idFondo);
                }
                btnAgregar1.Enabled = true;
            }
        }
        public void LiberarCuenta(int nValBusqueda)
        {
            if (nValBusqueda > 0)
            {
                new clsCNRetornaNumCuenta().UpdEstCuenta(nValBusqueda, 0);
            }
        }
        private void RetornarAportes(int idAporte)
        {
            var datAporte = cnaporte.retornardatosaporte(idAporte);
            if (datAporte==null)
            {
                MessageBox.Show("El cliente no cuenta ","Validación Transferencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                cboTipoTransfer.Focus();
                return;
            }

            nmonAportePac = datAporte.nMonAporte;
            
            var lisdetaporte = datAporte.objDetalleAportes.Where(x => x.idEstado == 1).OrderBy(y => y.dFecVenApo).ToList();
            lisdetaporte.ForEach(p => p.lPago = false);
            detalleAporte.AddRange(lisdetaporte);
            //dtAporte = null;

            //dtAporte = convertToDataTable(lisdetaporte);

             x_idMonedaDestino = datAporte.idMoneda;
        }

        private void RetornarFondoMortuorio(int idAporte)
        {
            var datFondo = cnfondo.retornardatosfondo(objsocio.idFondo);
            if (datFondo == null)//Socio que se inscribió sin FONDO DE SEGURO
            {

                MessageBox.Show("","Validación de transferencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            nmonFondoPac = datFondo.nMonFondo;

            var lisdetfondo = datFondo.objDetalleFondo.Where(x => x.idEstado == 1).OrderBy(y => y.dFecVenApo).ToList();
            lisdetfondo.ForEach(p => p.lPago = false);
            detalleFondo.AddRange(lisdetfondo);
            x_idMonedaDestino = datFondo.idMoneda;
        }
        public clslisDetalleAporte listardetalleaporte(decimal nmonto)
        {
            decimal nAportePactado = 0.00M;

            DateTime dfecUltimo = clsVarGlobal.dFecSystem;
            decimal nmonTotalAprt = nmonto;
            clslisDetalleAporte lista = new clslisDetalleAporte();
            int i = 0, j = 1;

            if (dtAporte.Rows.Count > 0)
            {
                var aportes = (List<clsDetalleAporte>)detalleAporte;
                dfecUltimo = Convert.ToDateTime(aportes.Max(p => p.dFecVenApo));

                nAportePactado = Convert.ToDecimal(aportes.Max(p => p.nMonApoPac));

                lista.Add(new clsDetalleAporte()
                {
                    idAporte = aportes.Max(p => p.idAporte),
                    idDetAporte = aportes.Where(x => x.dFecVenApo == dfecUltimo).Sum(p => p.idDetAporte),
                    cPeriodo = aportes.Where(x => x.dFecVenApo == dfecUltimo).Max(p => p.cPeriodo),

                    dFecVenApo = dfecUltimo,
                    idEstado = aportes.Where(x => x.dFecVenApo == dfecUltimo).Max(p => p.idEstado),
                    nMonApoPac = nmonTotalAprt < nAportePactado ? nmonTotalAprt : aportes.Where(x => x.dFecVenApo == dfecUltimo).Max(p => p.nMonApoPac),
                    nMonApoPag = aportes.Where(x => x.dFecVenApo == dfecUltimo).Max(p => p.nMonApoPag),
                    nMonApoPac1 = nmonAportePac,
                    lPago = nmonTotalAprt > 0.00M ? true : false
                });
                nmonTotalAprt = nmonTotalAprt - aportes.Max(p => p.nMonApoPac);
                i += 1;
                j += 1;
            }
            else
            {
                DataTable ndata = cnsocio.retornarUltFecAporte(objsocio.idAporte, -1, 1);
                if (ndata.Rows.Count>1)
                {
                   dfecUltimo = Convert.ToDateTime(ndata.Rows[0]["dFecVenApo"].ToString()).AddMonths(1); 
                }
                else
                {
                    dfecUltimo = clsVarGlobal.dFecSystem;
                }
            }
            if (nmonTotalAprt>0)
            {
                while (nmonAportePac <= nmonTotalAprt)
                {
                    lista.Add(new clsDetalleAporte()
                    {
                        idAporte = objsocio.idAporte,
                        idDetAporte = -j,
                        cPeriodo = dfecUltimo.AddMonths(i).Date.ToString("dd/MM/yyyy"),
                        dFecVenApo = dfecUltimo.AddMonths(i),
                        idEstado = 1,
                        nMonApoPac = nmonAportePac,
                        nMonApoPag = 0.00M,
                        nMonApoPac1 = nmonAportePac,
                        lPago = true
                    });
                    nmonTotalAprt = nmonTotalAprt - nmonAportePac;
                    i += 1;
                    j += 1;
                }
            }
            
            if (nmonTotalAprt > 0)
            {
                lista.Add(new clsDetalleAporte()
                {
                    idAporte = objsocio.idAporte,
                    idDetAporte = -j,
                    cPeriodo = dfecUltimo.AddMonths(i).Date.ToString("dd/MM/yyyy"),
                    dFecVenApo = dfecUltimo.AddMonths(i),
                    idEstado = 1,
                    nMonApoPac = nmonTotalAprt,
                    nMonApoPag = 0.00M,
                    nMonApoPac1 = nmonAportePac,
                    lPago = true
                });
            }
            return lista;
        }

        public clslisDetalleFondo listarFondoMortuorio(decimal nmonto)
        {
            decimal nPagoFondoPactado = 0.00M;

            DateTime dfecUltimo = clsVarGlobal.dFecSystem;
            decimal nmonTotalFondo = nmonto;

            clsCNGenVariables RetVar = new clsCNGenVariables();
            int nVerSis = Convert.ToInt32(RetVar.RetornaVariable("nFrecFondMor", 0));
            clslisDetalleFondo listaFondoMort = new clslisDetalleFondo();
            int i = 0, j = 1;

            if (dtFondo.Rows.Count > 1)
            {
                var fondo = (List<clsDetalleFondo>)detalleFondo;
                dfecUltimo = Convert.ToDateTime(fondo.Max(p => p.dFecVenApo));

                nPagoFondoPactado = Convert.ToDecimal(fondo.Max(p => p.nMontoPac));

                listaFondoMort.Add(new clsDetalleFondo()
                {
                    idFondo = fondo.Max(p => p.idFondo),
                    idDetFondo = fondo.Where(p => p.dFecVenApo == dfecUltimo).Sum(p => p.idDetFondo),
                    cPeriodo = fondo.Where(x => x.dFecVenApo == dfecUltimo).Max(p => p.cPeriodo),

                    dFecVenApo = dfecUltimo,
                    idEstado = fondo.Where(x => x.dFecVenApo == dfecUltimo).Max(p => p.idEstado),
                    nMontoPac = nmonTotalFondo < nPagoFondoPactado ? nmonTotalFondo : fondo.Where(x => x.dFecVenApo == dfecUltimo).Max(p => p.nMontoPac),
                    nMontoPag = fondo.Where(x => x.dFecVenApo == dfecUltimo).Max(p => p.nMontoPag),
                    nMontoPac1 = nmonFondoPac,
                    lPago = nmonTotalFondo > 0.00M ? true : false
                });
                nmonTotalFondo = nmonTotalFondo - fondo.Max(p => p.nMontoPac);
                i += 1;
                j += 1;
            }
            else
            {
                DataTable ndata = cnsocio.retornarUltFecAporte(-1, objsocio.idFondo, 2);
                if (ndata.Rows.Count>1)
                {
                    dfecUltimo = Convert.ToDateTime(ndata.Rows[0]["dFecVenApo"].ToString()).AddMonths(nVerSis);
                }
                else
                {
                    dfecUltimo = clsVarGlobal.dFecSystem;
                }
            }
            if (nmonTotalFondo>0)
            {
                while (nmonFondoPac <= nmonTotalFondo)
                {
                    listaFondoMort.Add(new clsDetalleFondo()
                    {
                        idFondo = objsocio.idFondo,
                        idDetFondo = -j,
                        cPeriodo = dfecUltimo.AddMonths(i).Date.ToString("dd/MM/yyyy"),
                        dFecVenApo = dfecUltimo.AddMonths(i),
                        idEstado = 1,
                        nMontoPac = nmonFondoPac,
                        nMontoPag = 0.00M,
                        nMontoPac1 = nmonFondoPac,
                        lPago = true
                    });
                    nmonTotalFondo = nmonTotalFondo - nmonFondoPac;
                    i += 1;
                    j += 1;
                }
            }
            

            if (nmonTotalFondo > 0)
            {
                listaFondoMort.Add(new clsDetalleFondo()
                {
                    idFondo = objsocio.idFondo,
                    idDetFondo = -j,
                    cPeriodo = dfecUltimo.AddMonths(i).Date.ToString("dd/MM/yyyy"),
                    dFecVenApo = dfecUltimo.AddMonths(i),
                    idEstado = 1,
                    nMontoPac = nmonTotalFondo,
                    nMontoPag = 0.00M,
                    nMontoPac1 = nmonFondoPac,
                    lPago = true
                });
            }
            return listaFondoMort;
        }
        private DataTable convertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            string name; Type type;

            foreach (PropertyDescriptor prop in properties)
            {
                name = (prop.Name == "idPlanPago" ? "idPlanPagos" : prop.Name);
                name = (name == "idEstadocuota" ? "idEstadoCuota" : name);
                type = (prop.Name == "dFechaPago" ? typeof(DateTime) : Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                table.Columns.Add(name, type);
            }
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    name = (prop.Name == "idPlanPago" ? "idPlanPagos" : prop.Name);
                    row[name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }
        private void DatosCuentaCre()
        {
            string cTipoBusqueda = "C";
            int idcuenta = 0;
            int nidUserBloqueo;
            string cUserBloqueo;
            clsCNRetornaNumCuenta RetornaNumCuenta = new clsCNRetornaNumCuenta();
            clsCNRetornsCuentaSolCliente RetornaCuentaSolCliente = new clsCNRetornsCuentaSolCliente();
            DataTable dtDatosNumCuenta;
            DataTable dtEstCuenta;
            DataTable dtDatosCuentaSolCliente = RetornaCuentaSolCliente.RetornaCuentaSolCliente(idCliDestino, cTipoBusqueda, "5");
            switch (dtDatosCuentaSolCliente.Rows.Count)
            {
                case 0:
                    MessageBox.Show("No se ha encotrando valores para la cuenta en búsqueda","Validación de Transferencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    break;
                case 1:
                    idcuenta = Convert.ToInt32(dtDatosCuentaSolCliente.Rows[0][0]);
                    x_idMonedaDestino = Convert.ToInt32(dtDatosCuentaSolCliente.Rows[0]["IdMoneda"]);
                    dtDatosNumCuenta = RetornaNumCuenta.RetornaNumCuenta(idcuenta, cTipoBusqueda, "5");
                    
                    dtEstCuenta = RetornaNumCuenta.VerifEstCuenta(idcuenta);
                    nidUserBloqueo = (Int32)dtEstCuenta.Rows[0][0];
                    if (nidUserBloqueo != 0)
                    {
                        DataTable dtUsu = new DataTable();
                        dtUsu = RetornaNumCuenta.BusUsuBlo((int)nidUserBloqueo);
                        cUserBloqueo = dtUsu.Rows[0][0].ToString();
                        MessageBox.Show("Cuenta Bloqueada por usuario: " + cUserBloqueo, "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LimpiarCuentaTrans();

                        this.txtNroCta.Focus();
                        idcuenta = 0;
                    }
                    else
                    {

                        if (x_idMonedaDestino==x_idMonedaOrigen)
                        {
                            RetornaNumCuenta.UpdEstCuenta(idcuenta, clsVarGlobal.User.idUsuario);

                            this.txtCodIns.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(0, 3);
                            this.txtCodAge.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(3, 3);
                            this.txtCodMod.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(6, 2);
                            this.txtCodMon.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(8, 1);
                            this.txtNroCta.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(9);
                            this.txtCliente.Text = dtDatosNumCuenta.Rows[0]["cNombre"].ToString();
                            this.txtEstado.Text = dtDatosNumCuenta.Rows[0]["cEstado"].ToString();
                            btnAgregar1.Enabled = true;
                            btnBusqueda.Enabled = true; 
                        }
                        else
                        {
                            MessageBox.Show("La moneda origen es diferente a la moneda destino", "Validación de Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    break;
                default:
                    FrmBuscaCuentaCliente frmBusCuenCli = new FrmBuscaCuentaCliente();
                    frmBusCuenCli.CargarDatos(idCliDestino, cTipoBusqueda, "1");
                    frmBusCuenCli.ShowDialog();
                    idcuenta = Convert.ToInt32(frmBusCuenCli.cIdCreSol);

                    this.txtNroCta.Text = frmBusCuenCli.cIdCreSol;
                    this.txtCliente.Text = frmBusCuenCli.cNombre;
                    this.txtEstado.Text = frmBusCuenCli.cEstado;
                    dtDatosNumCuenta = RetornaNumCuenta.RetornaNumCuenta(idcuenta, cTipoBusqueda, "1");
                    dtEstCuenta = RetornaNumCuenta.VerifEstCuenta(idcuenta);
                    nidUserBloqueo = (int)dtEstCuenta.Rows[0][0];
                    if (nidUserBloqueo != 0)
                    {
                        DataTable dtUsu = new DataTable();
                        dtUsu = RetornaNumCuenta.BusUsuBlo((int)nidUserBloqueo);
                        cUserBloqueo = dtUsu.Rows[0][0].ToString();
                        MessageBox.Show("Cuenta Bloqueada por usuario: " + cUserBloqueo, "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        LimpiarCuentaTrans();
                        this.btnBusqueda.Focus();
                        idcuenta = 0;
                    }
                    else
                    {
                        btnBusqueda.Enabled = false;
                        RetornaNumCuenta.UpdEstCuenta(idcuenta, clsVarGlobal.User.idUsuario);
                        x_idMonedaDestino = Convert.ToInt32(dtDatosNumCuenta.Rows[0]["IdMoneda"].ToString());
                        if (x_idMonedaDestino==x_idMonedaOrigen)
                        {
                            this.txtCodIns.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(0, 3);
                            this.txtCodAge.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(3, 3);
                            this.txtCodMod.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(6, 2);
                            this.txtCodMon.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(8, 1);
                            this.txtNroCta.Text = dtDatosNumCuenta.Rows[0]["cNroCuenta"].ToString().Substring(9);
                            this.txtCliente.Text = dtDatosNumCuenta.Rows[0]["cNombre"].ToString();
                            this.txtEstado.Text = dtDatosNumCuenta.Rows[0]["cEstado"].ToString();

                            btnAgregar1.Enabled = true; 
                        }
                        else
                        {
                            MessageBox.Show("La moneda destino es diferente a la moneda destino", "Validación de Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return; 
                        }
                        
                    }
                    break;
            }
            

        }
        private void DatoCuentasDep(int idCli)
        {
            int nidTipoPersona = 0;
            txtNroCta.Text = "";
            clsCNDeposito objDeposito = new clsCNDeposito();
            DataTable dtbNumCuentas = objDeposito.CNCuentasAhorros(idCli, 1, 0, 10);
            switch (dtbNumCuentas.Rows.Count)
            {
                case 0:  //--No existe Cuentas
                    LimpiarCuentaTrans();
                    
                    MessageBox.Show("No se Encontró Datos", "Buscar Cuentas del Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case 1: //--El cliente solo tiene una cuenta
                    x_idMonedaDestino = Convert.ToInt32(dtbNumCuentas.Rows[0]["idMoneda"].ToString());
                    if (x_idMonedaDestino==x_idMonedaOrigen)
                    {
                        txtCodIns.Text = dtbNumCuentas.Rows[0]["cNroCuenta"].ToString().Substring(0, 3);
                        txtCodAge.Text = dtbNumCuentas.Rows[0]["cNroCuenta"].ToString().Substring(3, 3);
                        txtCodMod.Text = dtbNumCuentas.Rows[0]["cNroCuenta"].ToString().Substring(6, 2);
                        txtCodMon.Text = dtbNumCuentas.Rows[0]["cNroCuenta"].ToString().Substring(8, 1);
                        txtNroCta.Text = dtbNumCuentas.Rows[0]["cNroCuenta"].ToString().Substring(9, 9);
                        txtEstado.Text = dtbNumCuentas.Rows[0]["cEstado"].ToString();
                        txtCliente.Text = dtbNumCuentas.Rows[0]["cNombre"].ToString();
                        nidTipoPersona = (int)dtbNumCuentas.Rows[0]["nidTipoPersona"];
                        btnAgregar1.Enabled = true;
                        clsDeposito.CNUpdUsoCuenta(Convert.ToInt32(txtNroCta.Text.Trim()), clsVarGlobal.User.idUsuario);
                    }
                    else
                    {
                        MessageBox.Show("La moneda destino es diferente a la moneda destino", "Validación de Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return; 
                    }
                    break;
                default: //--El Cliente tiene mas de Una Cuenta
                    //==================================================
                    //--Llamar al Formulario
                    //==================================================
                    frmBusCtaAho frmbuscarCta = new frmBusCtaAho();
                    frmbuscarCta.idCli = idCli;
                    frmbuscarCta.pTipBus = 2;
                    frmbuscarCta.nTipOpe = 10;  //--Tipo de Operación: 11 Retiro, 10 Deposito
                    frmbuscarCta.idestado = 1;
                    frmbuscarCta.idMon = 0;  //--Se Enviará Moneda en Caso sea Necesario
                    frmbuscarCta.ShowDialog();
                    if (!string.IsNullOrEmpty(frmbuscarCta.pnCta))
                    {
                        if (x_idMonedaOrigen==x_idMonedaDestino)
                        {
                            txtCodIns.Text = frmbuscarCta.pcNroCta.Substring(0, 3);
                            txtCodAge.Text = frmbuscarCta.pcNroCta.Substring(3, 3);
                            txtCodMod.Text = frmbuscarCta.pcNroCta.Substring(6, 2);
                            txtCodMon.Text = frmbuscarCta.pcNroCta.Substring(8, 1);
                            txtNroCta.Text = frmbuscarCta.pcNroCta.Substring(9, 9);
                            txtEstado.Text = dtbNumCuentas.Rows[0]["cEstado"].ToString();
                            txtCliente.Text = dtbNumCuentas.Rows[0]["cNombre"].ToString();
                            nidTipoPersona = (int)dtbNumCuentas.Rows[0]["nidTipoPersona"];
                            x_idMonedaDestino = frmbuscarCta.idMon;
                            btnAgregar1.Enabled = true;
                            clsDeposito.CNUpdUsoCuenta(Convert.ToInt32(txtNroCta.Text.Trim()), clsVarGlobal.User.idUsuario);

                        }
                        else
                        {
                            MessageBox.Show("La moneda destino es diferente a la moneda destino", "Validación de Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;                        
                        }

                    }
                    break;
            }
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            
            //Validaciones
            if (string.IsNullOrEmpty(txtNroCta.Text))
            {
                MessageBox.Show("Ingrese número de cuenta válida","Validación de Transferencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                btnBusqueda.Focus();
                return;
            }
           
            int idCuenta= Convert.ToInt32(txtNroCta.Text.ToString());
            DataTable dtDatCue = clsTransfer.CNRetornaDatCuenta(idCuenta, nTipoTransfer,clsVarGlobal.nIdAgencia);
            decimal nMontoSugerido=0;
                

            if (dtDatCue.Rows.Count>0)
            {
                switch (nTipoTransfer)
	            {
		            case   3:
                        nMontoSugerido=nmonAportePac;
                        break;
                    case  4:
                        nMontoSugerido=nmonFondoPac;
                        break;
                    default:
                        nMontoSugerido = Convert.ToDecimal(dtDatCue.Rows[0]["nMontoPendiente"].ToString()) +Convert.ToDecimal(txtInscripcion.Text.Trim());
                        break;
	            }
                DataRow Dr = dtDetallePago.NewRow();
                Dr["idOrden"] = nContOrden+1;
                Dr["idcli"] =idCliDestino;
                Dr["idCuenta"]=idCuenta;
                Dr["idTipoOpe"] = nTipoTransfer;
                Dr["cTipoOpe"]=cboTipoTransfer.Text;
                Dr["nMontoSugerido"]=nMontoSugerido;
                Dr["nMontoOpe"]=0;
                Dr["nITF"]=0;
                Dr["nMontoTotal"]=0;
                Dr["idAgenciacue"] = Convert.ToInt32(dtDatCue.Rows[0]["idAgenciaOrigen"].ToString());
                Dr["nPlazo"] = Convert.ToInt32(dtDatCue.Rows[0]["nPlazo"].ToString());
                Dr["idProducto"] = Convert.ToInt32(dtDatCue.Rows[0]["idProducto"].ToString());
                Dr["idMoneda"] = Convert.ToInt32(dtDatCue.Rows[0]["idMoneda"].ToString());
                Dr["idTipoPersona"] = Convert.ToInt32(dtDatCue.Rows[0]["idTipoPersona"].ToString());
                dtDetallePago.Rows.Add(Dr);
                nContOrden++;
            }
            else
            {
                MessageBox.Show("No se encontró información de cuenta. Verifique","Validación de Transferencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
     
            btnGrabar.Enabled = true;
            //Recuperando Información necesaria
            LimpiarCuentaTrans();
            btnAgregar1.Enabled = false;
            btnQuitar1.Enabled = true;
        }
        private void LimpiarCuentaTrans()
        {
            txtCodIns.Text = "";
            txtCodAge.Text = "";
            txtCodMod.Text = "";
            txtCodMon.Text = "";
            txtNroCta.Text = "";
            txtCliente.Text = "";
            txtEstado.Text = "";
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            DesbloqueoCuentas();
            LimpiarCtrl();
            LimpiarOtrosCtrl();
            LimpiarCuentaTrans();
            LimpiarValores();
            btnGrabar.Enabled = false;
            btnAgregar1.Enabled = false;
            btnQuitar1.Enabled = false;
            cboTipoTransfer.Enabled = false;
            btnBusqueda.Enabled = false;
            conBusCtaAhoOrigen.txtNroCta.Enabled = true;
            conBusCtaAhoOrigen.btnBusCliente.Enabled = true;
            conBusCtaAhoOrigen.btnBusCliente.Focus();
            
        }
        private void DesbloqueoCuentas()
        {
            if (p_idCta>0)
            {
                clsDeposito.CNUpdNoUsoCuenta(p_idCta);
            }
            foreach (DataRow item in dtDetallePago.Rows)
            {
                int idcuenta = Convert.ToInt32(item["idCuenta"]);
                int idTipoOpe = Convert.ToInt32(item["idTipoOpe"]);
                switch (idTipoOpe)
                {
                    case 1:
                        LiberarCuenta(idcuenta);
                        break;
                    case 2:
                        clsDeposito.CNUpdNoUsoCuenta(idcuenta);
                        break;
                }
            }
            
            
        }
        private void lblBase2_Click(object sender, EventArgs e)
        {

        }

        private void txtInscripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumRea1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtgCuentasPago_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }
        void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 8)
            {

                e.Handled = false;
                return;

            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                e.Handled = false;
            }

            else
            {

                var fff = (from L in this.Text.ToString()

                           where L.ToString() == "."
                           select L).Count();
                if (fff <= 0 && e.KeyChar.ToString() == ".")

                    e.Handled = false;
                else

                    e.Handled = true;
            }
        }

        private void dtgCuentasPago_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgCuentasPago.Rows.Count>0)
            {
                Int32 fila = Convert.ToInt32(this.dtgCuentasPago.SelectedCells[0].RowIndex);
                Decimal nMonto = 0;
                if (string.IsNullOrEmpty(this.dtgCuentasPago.Rows[fila].Cells["nMontoOpe"].Value.ToString()))
                {
                    this.dtgCuentasPago.Rows[fila].Cells["nMontoOpe"].Value = 0;
                }
                else
                {
                    nMonto = Convert.ToDecimal (this.dtgCuentasPago.Rows[fila].Cells["nMontoOpe"].Value);
                    //--==========================================================
                    //--Comisiones de la Cuenta
                    //--==========================================================
                    int idcli = Convert.ToInt32(this.dtgCuentasPago.Rows[fila].Cells["idcli"].Value);
                    int nOrden = Convert.ToInt32(this.dtgCuentasPago.Rows[fila].Cells["idOrden"].Value);
                    int idCuenta = Convert.ToInt32(this.dtgCuentasPago.Rows[fila].Cells["idCuenta"].Value);
                    int idProducto = Convert.ToInt32(this.dtgCuentasPago.Rows[fila].Cells["idProducto"].Value);
                    int idTipoOpe = Convert.ToInt32(this.dtgCuentasPago.Rows[fila].Cells["idTipoOpe"].Value);
                    int idMoneda = Convert.ToInt32(this.dtgCuentasPago.Rows[fila].Cells["idMoneda"].Value);
                    int nplazo = Convert.ToInt32(this.dtgCuentasPago.Rows[fila].Cells["nPlazo"].Value);
                    int idTipoPersona = Convert.ToInt32(this.dtgCuentasPago.Rows[fila].Cells["idTipoPersona"].Value);
                    dtDetallePago.Rows[fila]["nComision"] = Comision(idProducto, idTipoOpe, idTipoPersona, idMoneda, idCuenta, nMonto, nplazo, nOrden);
                    //this.dtgCuentasPago.Rows[fila].Cells["nComision"].Value = Comision(idProducto, idTipoOpe, idTipoPersona, idMoneda, idCuenta, nMonto, nplazo, nOrden);
                    Decimal nComision = Convert.ToDecimal (this.dtgCuentasPago.Rows[fila].Cells["nComision"].Value);

                    Decimal nITF;
                    if (!lIsAfectoITFRep)
                    {
                        nITF = 0.00m;
                    }
                    else
                    {
                        if (idCliDestino==idCliOrigen)
                        {
                            nITF = 0.00m;
                        }
                        else
                            nITF = FunTruncar.truncar((Decimal)clsVarGlobal.nITF / 100.00m * (Decimal)nMonto, 2, idMoneda);
                    }
                    dtDetallePago.Rows[fila]["nITF"] = nITF;
                    dtDetallePago.Rows[fila]["nMontoTotal"] = Calcular(nMonto, nITF, nComision);
                    //this.dtgCuentasPago.Rows[fila].Cells["nITF"].Value = nITF;
                    //this.dtgCuentasPago.Rows[fila].Cells["nMontoTotal"].Value = Calcular(nMonto, nITF, nComision);
                    Decimal nMontoRetiro = nMonto + nITF + nComision;

                    Retiro(nMontoRetiro, nOrden, fila);
                }
            }
            
        }
        private void Retiro(Decimal nMontoRetiro, int nOrden, int nFila)
        {
            int nfila=0;
           
            Decimal nComision=Comision(idProductoOrigen, x_nTipOpe, idTipoPersonaOrigen, x_idMonedaOrigen, p_idCta, nMontoRetiro, nPlaCtaOrigen, nOrden);
             Decimal nITF =0;
            if (!lIsAfectoITFRep)
            {
                nITF = 0.00m;
            }
            else
            {
                if (idCliDestino==idCliOrigen)
                {
                    nITF = 0.00m;
                }
                else
                    nITF = FunTruncar.truncar((Decimal)clsVarGlobal.nITF / 100.00m * (Decimal)nMontoRetiro, 2, x_idMonedaOrigen);
            }
            Decimal nMontoTotal=Calcular(nMontoRetiro, nITF, nComision);
            bool lIndFila= false;
		    foreach (DataRow  item in dtDetalleRetiro.Rows)
            {
                if (Convert.ToInt32(item["idOrden"])==nOrden)
                    {
                        dtDetalleRetiro.Rows[nfila]["nMontoOpe"] = nMontoRetiro;    
                        dtDetalleRetiro.Rows[nfila]["nITF"]=nITF;
                        dtDetalleRetiro.Rows[nfila]["nComision"]=nComision;
                        dtDetalleRetiro.Rows[nfila]["nMontoTotal"]=nMontoTotal;
                        lIndFila=true;
                    }
                if (dtDetalleRetiro.Rows.Count==0)
                {
                    break;
                }
                nfila++;
            }
            if (!lIndFila)
            {
                DataRow dr = dtDetalleRetiro.NewRow();
                dr["idOrden"] = nOrden;
                dr["nMontoOpe"] = nMontoRetiro;
                dr["nComision"] = nComision;
                dr["nITF"] = nITF;
                dr["nMontoTotal"] = nMontoTotal;
                dtDetalleRetiro.Rows.Add(dr);
            }
        
            SumaPagos();
        }
        private Decimal Comision(int idProducto, int idTipoOpe, int idTipoPersona, int idMoneda, int idCuenta, Decimal nMonto, int nplazo, int nOrden)
        {
            dtComisionOpe = null;
            dtComisionRet = null;
            clsCNOperacionDep clsBloq = new clsCNOperacionDep();

            if (idTipoOpe==11)
            {
                dtComisionRet=clsBloq.RetornaComisionesCtaOpe(idProducto, idTipoOpe, idTipoPersona,idMoneda,
                                                        idCuenta, 1, clsVarGlobal.nIdAgencia, nMonto, nplazo,2);
                if (dtComisionRetTotal.Columns.Count==0)
                {
                    dtComisionRetTotal = dtComisionRet.Clone();
                    dtComisionRetTotal.Columns.Add("nOrden", typeof(int));
                }
                else
                {
                    int nfilas = dtComisionRetTotal.Rows.Count;
                    int nFilaElimina = 0;
                    for (int i = 0; i < nfilas; i++)
                    {
                        if (Convert.ToInt32(dtComisionRetTotal.Rows[i - nFilaElimina]["nOrden"]) == nOrden)
                        {
                            dtComisionRetTotal.Rows.RemoveAt(i - nFilaElimina);
                            nFilaElimina++;
                        }
                        if (dtComisionRetTotal.Rows.Count == 0)
                        {
                            break;
                        }
                    }
                }
                
                if (dtComisionRet.Rows.Count > 0)
                {
                    
                    for (int f = 0; f < dtComisionRet.Rows.Count; f++)
                    {

                        DataRow dr = dtComisionRetTotal.NewRow();
                        for (int c = 0; c < dtComisionRet.Columns.Count; c++)
                        {
                            dr[f] = dtComisionRet.Rows[f][c];
                        }
                        dtComisionRetTotal.Rows.Add(dr);
                    }
                    
                    for (int i = 0; i < dtComisionRetTotal.Rows.Count; i++)
                    {
                        dtComisionRetTotal.Rows[i]["nOrden"] = nOrden;
                    }
                    Decimal nTotCom = Convert.ToDecimal (dtComisionRet.Compute("SUM(nValorAplica)", ""));
                    return nTotCom;
                }
                else
                {
                    DataRow dr = dtComisionRetTotal.NewRow();
                    dr["nOrden"] = nOrden;
                    dr["idConfigGastComiSeg"]=0;
                    dr["idConcepto"]=0;
                    dr["cNombreCorto"]="";
                    dr["nValorAplica"]=false;
                    dr["lAplicaContable"]=false;
                    dr["lAplicaImpreOpe"]=false;
                    dtComisionRetTotal.Rows.Add(dr);
                    return 0;
                }
            }
            else
            {
                dtComisionOpe = clsBloq.RetornaComisionesCtaOpe(idProducto, idTipoOpe, idTipoPersona, idMoneda,
                                                        idCuenta, 1, clsVarGlobal.nIdAgencia, nMonto, nplazo,2);
                if (dtComisionOpeTotal.Columns.Count==0)
                {
                    dtComisionOpeTotal = dtComisionOpe.Clone();
                    dtComisionOpeTotal.Columns.Add("nOrden", typeof(int));
                }
                else
                {
                    int nFilas = dtComisionOpeTotal.Rows.Count;
                    int nFilaElimina = 0;
                    for (int i = 0; i < nFilas; i++)
                    {
                        if (Convert.ToInt32(dtComisionOpeTotal.Rows[i - nFilaElimina]["nOrden"]) == nOrden)
                        {
                            dtComisionOpeTotal.Rows.RemoveAt(i);
                            nFilaElimina++;
                        }
                        if (dtComisionOpeTotal.Rows.Count==0)
	                    {
		                    break;
	                    }
                    }
                }
                if (dtComisionOpe.Rows.Count > 0)
                {
                    
                    Decimal nTotCom = Convert.ToDecimal (dtComisionOpe.Compute("SUM(nValorAplica)", ""));
           
                    for (int f = 0; f < dtComisionOpe.Rows.Count; f++)
                    {

                        DataRow dr = dtComisionOpeTotal.NewRow();
                        for (int c = 0; c < dtComisionOpe.Columns.Count; c++)
			            {
                            dr[f] = dtComisionOpe.Rows[f][c];   
			            }
                        dtComisionOpeTotal.Rows.Add(dr);
                    }
                    
                    for (int i = 0; i < dtComisionOpeTotal.Rows.Count; i++)
                    {
                        dtComisionOpeTotal.Rows[i]["nOrden"] = nOrden;
                    }

                    return nTotCom;
                }
                else
                {
                    DataRow dr = dtComisionOpeTotal.NewRow();
                    dr["nOrden"] = nOrden;
                    dr["idConfigGastComiSeg"] = 0;
                    dr["idConcepto"] = 0;
                    dr["cNombreCorto"] = "";
                    dr["nValorAplica"] = false;
                    dr["lAplicaContable"] = false;
                    dr["lAplicaImpreOpe"] = false;
                    dtComisionOpeTotal.Rows.Add(dr);
                    return 0;
                }
            }

            
        }
        private Decimal Calcular(Decimal nMonto, Decimal nITF, Decimal nComision)
        {
            
            Decimal nMontoTotal = 0;
            nMontoTotal = (Decimal)nMonto + Math.Round(nITF, 2) + (Decimal) Math.Round(Convert.ToDecimal (nComision), 2);
            return nMontoTotal;
  
        }
        private void SumaPagos()
        {
            Decimal sumaCapital = 0.00m, sumaComision = 0.00m, sumaITF = 0.00m;
            int nNumPro = this.dtDetalleRetiro.Rows.Count;
            for (int i = 0; i < nNumPro; i++)
            {
                sumaCapital = sumaCapital + Convert.ToDecimal (dtDetalleRetiro.Rows[i]["nMontoOpe"]);
                sumaComision = sumaComision + Convert.ToDecimal (dtDetalleRetiro.Rows[i]["nComision"]);
                sumaITF = sumaITF + Convert.ToDecimal (dtDetalleRetiro.Rows[i]["nITF"]);
            }
            txtMonto.Text = sumaCapital.ToString();
            txtComisionRetiro.Text = sumaComision.ToString();
            txtITFRet.Text = sumaITF.ToString();
            txtTotalOpeTrans.Text = (sumaCapital+sumaComision+sumaITF).ToString();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            /*========================================================================================
                * REGISTRO DE RASTREO
            ========================================================================================*/
            this.registrarRastreo(this.conBusCtaAhoOrigen.idcli, this.conBusCtaAhoOrigen.idcuenta, "Inicio-Transferencia de Cuenta de ahorro", btnGrabar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
            
            if (dtDetallePago.Rows.Count<=0)
            {
                MessageBox.Show("No se ha encontrado cuentas para la transferencia","Validación de Transferencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            if (Convert.ToDecimal (txtTotalOpeTrans.Text) == 0)
            {
                MessageBox.Show("El Monto de la Operación no Puede Ser Cero(0)", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidaRetiro())
            {
                return;
            }
            //Validación de los montos
            foreach (DataRow item in dtDetallePago.Rows)
            {
                if (Convert.ToDecimal(item["nMontoTotal"])==0)
                {
                    MessageBox.Show("No puede existir una cuenta con monto Cero(0) a transferir. Verifique","Validación de Transferencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
            }
            //Transferencia
            //===================================================================
            //--Generar XML de Datos Intervinientes-Retiro
            //===================================================================
            string cNombre = "";
            string cDireccion = "";
            string cDocIde = "";
            cDocIde = conBusCtaAhoOrigen.txtNroDoc.ToString().Trim();
            Decimal nMontoOpe = 0;
            DataTable dtPerson = BusPerson.ListarClientes("1", cDocIde);

            if (dtPerson.Rows.Count > 0)
            {
                cNombre = Convert.ToString(dtPerson.Rows[0]["cNombre"]);
                cDireccion = Convert.ToString(dtPerson.Rows[0]["cDireccion"]);
            }
            //Grabar las operaciones
            foreach (DataRow item in dtDetallePago.Rows)
	        {
		        
                int idTipoOpe=0, nOrden= 0, idCliItfRet=0,idCliItfOpe=0, idCuenta=0;

                nOrden= Convert.ToInt32(item["idOrden"]);
                idTipoOpe=Convert.ToInt32(item["idTipoOpe"]);
                idCuenta=Convert.ToInt32(item["idCuenta"]);
                nMontoOpe = Convert.ToDecimal (item["nMontoOpe"]);
                DataTable dtIntervOpe = new DataTable();

                //============================================================
                //--Retorna Estructura Para Datos del Pago
                //============================================================
                clsCNAperturaCta DatTipPago = new clsCNAperturaCta();
                DataTable dtPag = DatTipPago.ListaCamposDep(3);
                DataRow drPag = dtPag.NewRow();
                //--Asignar Datos Para Registrar Apertura
                    drPag["idTipoValorado"] = 0;
                    drPag["cNroCuentaDoc"] = idCliDestino;
                    drPag["cNroDocumento"] = "000";
                    drPag["cSerieDocumento"] = "0";
                    drPag["idEntidad"] = clsVarApl.dicVarGen["idInstFin"];
                    drPag["dFechaReg"] = clsVarGlobal.dFecSystem.ToShortDateString();
                    drPag["nDiasValoriz"] = 0;
                    dtPag.Rows.Add(drPag);
                //===================================================================
                //--Generar XML de Datos del Tipo de Pago
                //===================================================================
                DataTable dtPagDep = dtPag;
                DataSet dsTipPagoRet = new DataSet("dsRetiro");
                dsTipPagoRet.Tables.Add(dtPag);
                string xmlTipPagoRet = clsCNFormatoXML.EncodingXML(dsTipPagoRet.GetXml());

                //DataSet dsTipPagoDep = new DataSet("dsDeposito");
                //dsTipPagoDep.Tables.Add(dtPagDep);
                //string xmlTipPagoDep = clsCNFormatoXML.EncodingXML(dsTipPagoDep.GetXml());
                //===================================================================
                //Generar XML deRetiro
                //===================================================================
                DataSet dsRetiro = new DataSet("dsRetiro");
                dtDetalleRetiro.DefaultView.RowFilter = ("idOrden=" + nOrden.ToString());
                DataView dvretiro = dtDetalleRetiro.DefaultView;
                dsRetiro.Tables.Add(dvretiro.ToTable());
                string xmlRetiro = clsCNFormatoXML.EncodingXML(dsRetiro.GetXml());
                //===================================================================
                //Generar XML de Comisiones Retiro
                //===================================================================
                DataSet dsComisionRetiro = new DataSet("dsRetiro");
                dtComisionRetTotal.DefaultView.RowFilter = ("nOrden=" + nOrden.ToString());
                DataView dvComRetiro =  dtComisionRetTotal.DefaultView;
                dsComisionRetiro.Tables.Add(dvComRetiro.ToTable());
                string xmlComisionRetiro = clsCNFormatoXML.EncodingXML(dsComisionRetiro.GetXml());
                //===================================================================
                //Generar XML de Comisiones Operacion
                //===================================================================
                DataSet dsComisionOpe = new DataSet("dsRetiro");
                dtComisionOpeTotal.DefaultView.RowFilter = ("nOrden=" + nOrden.ToString());
                DataView dvComOpe = dtComisionOpeTotal.DefaultView;
                dsComisionOpe.Tables.Add(dvComOpe.ToTable());
                string xmlComisionOpe = clsCNFormatoXML.EncodingXML(dsComisionOpe.GetXml());
                //===================================================================
                //Generar XML de Operacion
                //===================================================================
                DataSet dsOperacion = new DataSet("dsTransferencia");
                dtDetallePago.DefaultView.RowFilter = ("idOrden=" + nOrden.ToString());
                DataView dvOperacion = dtDetallePago.DefaultView;
                dsOperacion.Tables.Add(dvOperacion.ToTable());
                string xmlOperacion = clsCNFormatoXML.EncodingXML(dsOperacion.GetXml());
                //===================================================================
                //--Generar XML de Datos Intervinientes-Retiro
                //===================================================================
                DataSet dsIntervinRet = new DataSet("dsRetiro");
                dsIntervinRet.Tables.Add(dtbIntervCtaRet);
                string xmlInterv = clsCNFormatoXML.EncodingXML(dsIntervinRet.GetXml());
                //--==================================================
                //--id Cliente Afe ITF Retiro
                //--==================================================
                idCliItfRet = RetornaIdCli(dtbIntervCtaRet);
                 //--==================================================
                //--id Cliente Afe ITF Ope
                //--==================================================
                switch (idTipoOpe)
	            {
		            case 1:
                        dtIntervOpe=clsDeposito.CNRetornaIntervinientesCuenta(0);
                        idCliItfOpe = RetornaIdCli(dtIntervOpe);
                        break;
                    case 2:
                        
                        dtIntervOpe= clsDeposito.CNRetornaIntervinientesCuenta(idCuenta);
                        idCliItfOpe = RetornaIdCli(dtIntervOpe);
                        break;
                    default:
                        dtIntervOpe=clsDeposito.CNRetornaIntervinientesCuenta(0);;
                        idCliItfOpe = 0;
                        break;
	            }
                //===================================================================
                //--Generar XML de Datos Intervinientes-Retiro
                //===================================================================
                DataSet dsIntervinOpe = new DataSet("dsretiro");
                dsIntervinOpe.Tables.Add(dtIntervOpe);
                string xmlIntervOpe = clsCNFormatoXML.EncodingXML(dsIntervinOpe.GetXml());
                //===================================================================
                //Datos adicionales por tipo de operación
                //===================================================================
                clslisDetalleAporte dtDetAportePag;
                clslisDetalleFondo dtDetFondoPag;
                switch (idTipoOpe)
                {
                    case 1://CREDITOS
                        //dtPagado = DistribuirPlanPagos(idCuenta, nMontoOpe);
                        if (!CobroCredito(idCuenta, nMontoOpe))
                        {
                            return;
                        }
                        dtDetAportePag = listardetalleaporte(0);
                        dtDetFondoPag = listarFondoMortuorio(0);

                        break;
                    case 2://AHORROS
                        //dtPagado = DistribuirPlanPagos(0, nMontoOpe);
                        if(!CobroCredito(0, 0))
                        {
                            return;
                        }
                        dtDetAportePag = listardetalleaporte(0);
                        dtDetFondoPag=listarFondoMortuorio(0);
                        break;
                    case 3://APORTE
                        //dtPagado = DistribuirPlanPagos(0, nMontoOpe);
                        if(!CobroCredito(0, 0))
                        {
                            return;
                        }
                        dtDetAportePag = listardetalleaporte((decimal)nMontoOpe);
                        dtDetFondoPag=listarFondoMortuorio(0);
                        break;
                    default://FONDO
                        //dtPagado = DistribuirPlanPagos(0, nMontoOpe);
                        if(!CobroCredito(0, 0))
                        {
                            return;
                        }
                        dtDetAportePag = listardetalleaporte(0);
                        dtDetFondoPag=listarFondoMortuorio((decimal)nMontoOpe);
                        break;
                }

                //===================================================================
                //--Generar XML de Plan de pagos créditos
                //===================================================================


                DataTable dtRpta = clsTransfer.CNGuardaTransferencia(idTipoOpe, xmlRetiro, xmlTipPagoRet, xmlOperacion, xmlInterv, xmlIntervOpe, xmlComisionOpe, xmlComisionRetiro,
                                                                    xmlPpg,idCuenta,clsVarGlobal.User.idUsuario,clsVarGlobal.nIdAgencia,clsVarGlobal.dFecSystem,1,
                                                                    idProductoOrigen,cDocIde,cNombre,cDireccion,idCliItfRet,idCliItfOpe,x_idMonedaOrigen,nMora,dtDetAportePag,
                                                                    dtDetFondoPag,lPagarInscripcion,idInscripcion);
                                                                        
                //if (dtRpta.Rows[0]["idRpta"]==0)
                //{
                //    dtDetallePago.Rows[]["lIndicaPago"]=true;
                //}

                /*========================================================================================
               * REGISTRO DE RASTREO
                ========================================================================================*/
                this.registrarRastreo(this.conBusCtaAhoOrigen.idcli, this.conBusCtaAhoOrigen.idcuenta, "Fin-Transferencia de Cuenta de ahorro", btnGrabar);
                /*========================================================================================
                 * FIN DEL REGISTRO DE RASTREO
                 ========================================================================================*/
           }
        }
        private bool CobroCredito(int idcuenta, Decimal nMontoOpe)
        {

            CRE.CapaNegocio.clsCNCredito Credito = new CRE.CapaNegocio.clsCNCredito();
            DataTable dtCredito = Credito.CNdtDataCreditoCobro(idcuenta);
            
            //   dtCredito = Credito.CNdtDataCreditoCobro(nNumCredito);
            Decimal nMonSalCre = Credito.nSaldoCredito(dtCredito);
            nMonSalCre = Convert.ToDecimal (string.Format("{0:#,##0.##}", Convert.ToDecimal (nMonSalCre.ToString())));
            if (Math.Round(nMonSalCre, 2) < nMontoOpe)
            {
                MessageBox.Show("Monto a Pagar no puede exceder al Saldo del Crédito: " + nMonSalCre.ToString(), "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                return false;
            }
            clsCNPlanPago PlanPago = new clsCNPlanPago();
            dtPlanPago = PlanPago.CNdtPlanPago(idcuenta);
            DataTable dtPlanPagado = new DataTable("dtPlanPagado");
            dtPlanPagado = PlanPago.dtCNPagoDistribuido(dtPlanPago, nMontoOpe, true);
            if (dtPlanPagado.Rows.Count > 0)
            {
                nMora = Convert.ToDecimal(dtPlanPagado.Rows[0]["nMoraPag"].ToString());
            }
            else
            {
                nMora = 0;
            }

            DataSet ds = new DataSet("dsPlanPagos");
            ds.Tables.Add(dtPlanPago);
            xmlPpg = ds.GetXml();//Solo Plan Pagos

            DataTable dtDetalleCargaGasto = PlanPago.DistribuirGastosPagados(dtPlanPago);
            dtDetalleCargaGasto.TableName = "TablaDetalleCargaGasto";
            ds.Tables.Add(dtDetalleCargaGasto);

            xmlPpg = ds.GetXml();//Plan Pagos y DetalleCargaGastos en caso se haya realizado pagos
            xmlPpg = GEN.CapaNegocio.clsCNFormatoXML.EncodingXML(xmlPpg);

            ds.Tables.Clear();
            return true;
        }

        private int RetornaIdCli(DataTable dtInterv)
        {
            int idCli = 0;
            for (int i = 0; i < dtInterv.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtInterv.Rows[i]["lCliAfeITF"]))
                {
                    idCli = Convert.ToInt32(dtInterv.Rows[i]["idCli"]);
                    break;
                }
            }
            return idCli;
        }
        private bool ValidaRetiro()
        {
     
            Decimal nMonOpeVal = Convert.ToDecimal (this.txtTotalOpeTrans.Text.ToString());
            if (nMonOpeVal < nMonMinOpeOri)
            {
                MessageBox.Show("El Monto Mínimo de Operación debe Ser: " + nMonMinOpeOri.ToString(), "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (lisBloCta)
            {
                //--Validar Monto Máximo a Retirar
                if (nSaldoDisp - nMonBloqCta < nMonOpeVal)
                {
                    MessageBox.Show("El Saldo Disponible es Menor al Monto a Retirar...(Cuenta Tiene Bloqueo por Monto)", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else
            {
                //--Validar Monto Máximo a Retirar
                if (nSaldoDisp - nMonBloqCta < nMonOpeVal)
                {
                    MessageBox.Show("El Saldo Disponible es Menor al Monto a Retirar...VERIFICAR", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            if (nSaldoDisp - nMonBloqCta - nMonOpeVal < nMonMinSalDisOrigen)
            {
                MessageBox.Show("El Saldo Mínimo Disponible es Menor al Monto a Retirar...VERIFICAR", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }
            return true;
        }

        private void btnQuitar1_Click(object sender, EventArgs e)
        {
            if (dtgCuentasPago.SelectedRows.Count>0)
            {
                Int32 nFila = Convert.ToInt32(this.dtgCuentasPago.SelectedCells[0].RowIndex);
                int nOrden = Convert.ToInt32(this.dtgCuentasPago.Rows[nFila].Cells["idOrden"].Value);
                int idcuenta = Convert.ToInt32(this.dtgCuentasPago.Rows[nFila].Cells["idCuenta"].Value);
                switch (nTipoTransfer)
                {
                    case 1:
                        LiberarCuenta(idcuenta);
                        break;
                    case 2:
                        clsDeposito.CNUpdNoUsoCuenta(idcuenta);
                        break;
                }
                dtDetallePago.Rows.RemoveAt(nFila);
                foreach (DataRow item in dtDetalleRetiro.Rows)
                {
                    if (Convert.ToInt32(item["idOrden"])==nOrden)
                    {
                        dtDetalleRetiro.Rows.RemoveAt(nFila);
                        break;
                    }
                }
                SumaPagos();
            }
            else
            {
                MessageBox.Show("No existe valor a eliminar","Validación de Transferencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {

        }

        private void frmTransferencias_FormClosed(object sender, FormClosedEventArgs e)
        {
            DesbloqueoCuentas();
        }
    }
}
