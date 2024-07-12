using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CLI.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using DEP.CapaNegocio;
using CAJ.CapaNegocio;

namespace CLI.Presentacion
{
    public partial class frmPagoAporteFondo : frmBase
    {
#region Variables
        clsCNSocio cnsocio = new clsCNSocio();
        clsCNAporte cnaporte = new clsCNAporte();
        clsCNFondoMortuorio cnfondo = new clsCNFondoMortuorio();
        clsCNBeneficiario cnbeneficiario = new clsCNBeneficiario();
        clsCNComprobantes objCpg = new clsCNComprobantes();
        clslisBeneficiario listabeneficiarios = new clslisBeneficiario();
        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsSocio objsocio = null;
        decimal nmonAportePac=0, nmonFondoPac=0;
        Boolean lSocioTieneFondoDeSeguro = false;
        int idTipoAporte = 0;
#endregion

        public frmPagoAporteFondo()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {           
            dtpFecIniAporte.Value   = clsVarGlobal.dFecSystem;
            dtpIniFondo.Value       = clsVarGlobal.dFecSystem;
            CargarComboModalidad(true);
            habilitarBtnProcesar(false);
            HabilitarControlesPagador(false);
            //------- Asignar tipo de seguro ---------------->
            DataTable dtTipoFondoSeguro = new clsCNSocio().listarTipoFondoSeguro();

            dtTipoFondoSeguro.Rows.Add(0, "Sin Fondo");

            cboTipoFondoSeguro.DataSource = dtTipoFondoSeguro;
            this.cboTipoFondoSeguro.ValueMember = dtTipoFondoSeguro.Columns["idTipoFondoSeguro"].ToString();
            this.cboTipoFondoSeguro.DisplayMember = dtTipoFondoSeguro.Columns["cTipoFondoSeguro"].ToString();
            cboTipoFondoSeguro.SelectedIndex = -1;
          
            dtgDetalleFondo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
        }

        private void CargarComboModalidad(Boolean lEsClienteInstitucion)
        {
            //====================== Cargar Modalidad =================================>
            cboModalidad.SelectedIndexChanged -= new
            EventHandler(cboModalidad_SelectedIndexChanged);

            cboModalidad.DataSource = cnsocio.ListarModalidadPagoAportesFondo(lEsClienteInstitucion);
            cboModalidad.ValueMember = "idModPagoAporteFondoSeg";
            cboModalidad.DisplayMember = "cModPagoAporteFondoSeg";

            cboModalidad.SelectedIndexChanged += new
            EventHandler(cboModalidad_SelectedIndexChanged);
            //========================================================================>
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            if (conBusCli1.idCli == 0)
            {
                conBusCli1.txtCodCli.Enabled = true ;
                conBusCli1.txtCodCli.Focus();
                dtgAportes.DataSource = null;
                dtgDetalleFondo.DataSource = null;
				btnImprSocio.Enabled = false;
                return;                
            }
            limpiarControlesFormulario();
            grbAportes.Enabled = true;
            if (conBusCli1.nidTipoPersona == 1)//PERSONA NATURAL
            {
                grbFondoSeguro.Enabled = true;
            }
            else //PERSONA JURÍDICA
            {
                grbFondoSeguro.Enabled = false;
            }
            cargarDatos(conBusCli1.idCli);
            LimpiarCtrlPagador();
            cboModalidad.SelectedValue = 1;
            dtgDetalleFondo.Enabled = true;
            dtgAportes.Enabled = true;
        }

        private void HabilitarControlesPagador(Boolean lActivo)
        {
            cboModalidad.Enabled = lActivo;

            chcNoEsCli.Enabled = lActivo;

            this.conBusCliPagador.Enabled               = lActivo;
            this.conBusCliPagador.btnBusCliente.Enabled = lActivo;
            this.conBusCliPagador.txtCodCli.Enabled     = lActivo;
            this.txtApePatRem.Enabled                   = lActivo;
            this.txtApeMatRem.Enabled                   = lActivo;
            this.txtNomCliRem.Enabled                   = lActivo;
            this.txtCBDNIRem.Enabled                    = lActivo;
            this.txtDirRem.Enabled                      = lActivo;                   
        }

        private void cargarDatos(int idCli)
        {
            objsocio = cnsocio.retornardatossocio(idCli);

            if (objsocio == null)
            {
                limpiarControlesBus();
                MessageBox.Show("Persona seleccionada no es un socio activo", "Validación Socio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCli1.txtCodCli.Enabled = true;
                conBusCli1.txtCodCli.Focus(); 
                dtgAportes.DataSource = null;
                dtgDetalleFondo.DataSource = null;

                HabilitarControlesPagador(false); 
				btnImprSocio.Enabled = false;
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
                //=======================================================================================================================>

                Boolean lInscripcionPagado = cnsocio.EstaPagadoInscripcion(objsocio.idInscripcion);//Para incluir en el pago
                if (lInscripcionPagado)
                {
                    txtInscripcion.Text = "0.00";
                }
                else
                {
                    txtInscripcion.Text = string.Format("{0:#,##0.00}", Convert.ToDecimal (objsocio.nInscripcion.ToString()));
                }                

                RetornarAportes(objsocio.idAporte);
                RetornarFondoMortuorio(objsocio.idFondo);
                habilitarBtnProcesar(true);
                formatoGrids();
                btnGrabar1.Enabled = true;

                HabilitarControlesPagador(true);               
				btnImprSocio.Enabled = true;
            }           
        }
        private void RetornarAportes(int idAporte)
        { 
            var datAporte = cnaporte.retornardatosaporte(idAporte);
    
            dtpFecIniAporte.Value   = datAporte.dFechaAporte;
            nmonAportePac           = datAporte.nMonAporte;
                
            var lisdetaporte = datAporte.objDetalleAportes.Where(x=>x.idEstado==1).OrderBy(y=>y.dFecVenApo).ToList();
            lisdetaporte.ForEach(p => p.lPago = false);

            dtgAportes.DataSource = null;
            
            dtgAportes.DataSource = lisdetaporte;
            
            cboMoneda1.SelectedValue = datAporte.idMoneda;
        }

        private void RetornarFondoMortuorio(int idAporte)
        { 
            var datFondo        = cnfondo.retornardatosfondo(objsocio.idFondo);
            if (datFondo == null)//Socio que se inscribió sin FONDO DE SEGURO
            {
                grbFondoSeguro.Enabled      = false;
                lSocioTieneFondoDeSeguro    = false;
                return;
            }

            lSocioTieneFondoDeSeguro = true;
            cboTipoFondoSeguro.SelectedValue = objsocio.idTipoFondoSeguro;
            //if (objsocio.idTipoFondoSeguro == 0) sin FONDO DE SEGURO
            //{
            //    grbFondoSeguro.Enabled = false;
            //    lSocioTieneFondoDeSeguro = false;
            //}

            nmonFondoPac        = datFondo.nMonFondo;
            dtpIniFondo.Value   = datFondo.dFechaPago;

            var lisdetfondo = datFondo.objDetalleFondo.Where(x => x.idEstado == 1).OrderBy(y => y.dFecVenApo).ToList();
            lisdetfondo.ForEach(p => p.lPago = false);

            dtgDetalleFondo.DataSource = null;
            dtgDetalleFondo.DataSource = lisdetfondo;
        }
        private void formatoGrids()
        {
            dtgAportes.ReadOnly         = false;
            dtgDetalleFondo.ReadOnly    = false;

            foreach (DataGridViewColumn item in dtgAportes.Columns)
            {
                item.ReadOnly = true;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (item.HeaderText=="Sel.")
                {
                    item.ReadOnly = false;    
                } 
            }
            foreach (DataGridViewColumn item in dtgDetalleFondo.Columns)
            {
                item.ReadOnly = true;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (item.HeaderText == "Sel.")
                {
                    item.ReadOnly = false;
                } 
            }
            formatoGridAprt();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiarControlesBus();
            limpiarControlesFormulario();
			btnImprSocio.Enabled = false;
           
        }

        private void limpiarControlesFormulario()
        {
            dtgAportes.DataSource = null;
            dtgDetalleFondo.DataSource = null;
            btnGrabar1.Enabled = false;
            habilitarBtnProcesar(false);
            cboMoneda1.SelectedIndex = 0;
            txtTotFondo.Clear();
            txtTotAporte.Clear();
            dtpIniFondo.Value = clsVarGlobal.dFecSystem;
            dtpFecIniAporte.Value = clsVarGlobal.dFecSystem;
            txtTotPagar.Clear();
            conBusCli1.txtCodCli.Enabled = true;
            txtInscripcion.Text = "0.00";
            conBusCli1.txtCodCli.Focus();

            //-------------- Controles Pagador ------------>
            LimpiarCtrlPagador();
            HabilitarControlesPagador(false);
            chcNoEsCli.Checked = false;
            //--------------------------------------------->

            //-------- Deshabilitar contenedores ---------->
            grbAportes.Enabled = true;
            grbFondoSeguro.Enabled = true;
            pnlDatosPagador.Enabled = true;
            //-------------------------------------------->
        }

        private void dtgAportes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgAportes.CurrentCell is DataGridViewCheckBoxCell)
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dtgAportes.CurrentCell;

                bool isChecked = (bool)checkbox.EditedFormattedValue;

                var detalleSele = ((clsDetalleAporte)dtgAportes.CurrentRow.DataBoundItem);
                var listadetalleaporte = (List<clsDetalleAporte>)dtgAportes.DataSource;

                var validaorden = listadetalleaporte.Where(x => x.dFecVenApo < detalleSele.dFecVenApo && x.lPago == false).Count();
                var validaorden2 = listadetalleaporte.Where(x => x.lPago == true
                                                            && isChecked == false
                                                            && x.dFecVenApo > detalleSele.dFecVenApo).Count();

                if (validaorden <= 0 && validaorden2 <= 0)
                {
                    detalleSele.lPago = isChecked;
                    sumarTotal();
                }
                else
                {
                    MessageBox.Show("Existe pagos pendientes al seleccionado", "Validación pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtgAportes.CancelEdit();
                }
            }
        }

        private void dtgDetalleFondo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgDetalleFondo.CurrentCell is DataGridViewCheckBoxCell)
            {
                DataGridViewCheckBoxCell checkbox1 = (DataGridViewCheckBoxCell)dtgDetalleFondo.CurrentCell;

                bool isChecked = (bool)checkbox1.EditedFormattedValue;

                var detallefondo = ((clsDetalleFondo)dtgDetalleFondo.CurrentRow.DataBoundItem);
                var listadetallefondo = (List<clsDetalleFondo>)dtgDetalleFondo.DataSource;

                var validaorden = listadetallefondo.Where(x => x.dFecVenApo < detallefondo.dFecVenApo && x.lPago == false).Count();

                var validaorden2 = listadetallefondo.Where(x => x.lPago == true 
                                                          && isChecked == false 
                                                          && x.dFecVenApo > detallefondo.dFecVenApo).Count();

                if (validaorden <= 0 && validaorden2<=0)
                {
                    detallefondo.lPago = isChecked;
                    sumarTotal();
                }
                else
                {
                    MessageBox.Show("Existe pagos pendientes al seleccionado", "Validación pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtgDetalleFondo.CancelEdit();
                }
            }
        }

        private void sumarTotal()
        {
            txtTotPagar.ReadOnly = false;
            var aportes = (List<clsDetalleAporte>)dtgAportes.DataSource;

            decimal totPagar = 0.00M;
            if (lSocioTieneFondoDeSeguro == true)//Si el cliente tiene fondo de seguro
            {
                var fondo = (List<clsDetalleFondo>)dtgDetalleFondo.DataSource;

                totPagar = aportes.Where(x => x.lPago == true).Sum(p => p.nMonApoPac) +
                                    fondo.Where(x => x.lPago == true).Sum(p => p.nMontoPac) + Convert.ToDecimal(txtInscripcion.Text);
            }
            else
            {
                totPagar = aportes.Where(x => x.lPago == true).Sum(p => p.nMonApoPac) +
                            Convert.ToDecimal(txtInscripcion.Text);
            }            

            txtTotPagar.Text = string.Format("{0:0.00}", totPagar);
            txtTotPagar.ReadOnly = true;
        }

        private void limpiarControlesBus()
        {
            foreach (Control item in conBusCli1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        Boolean CamposSonValidos()
        {
            if (string.IsNullOrEmpty(this.txtTotPagar.Text))
            {
                MessageBox.Show("Seleccione los aportes a cobrar(checks) o ingrese el monto de aporte", "Validación Monto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotPagar.Focus();
                return false;
            }

            if ((this.txtTotPagar.nvalor) <= 0.00)
            {
                MessageBox.Show("Seleccione los aportes a cobrar", "Validación Monto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotPagar.Focus();
                return false;
            }
            if (Convert.ToInt32(cboModalidad.SelectedValue) <=0)
            {
                MessageBox.Show("Seleccione la modalidad de pago del aporte o fondo", "Validación Monto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboModalidad.Focus();
                return false;
            }
            //----------------------- Campos Pagador ---------------------------------->
            if (chcNoEsCli.Checked)
            {
                if (string.IsNullOrEmpty(txtApePatRem.Text))
                {
                    MessageBox.Show("Debe ingresar el APELLIDO PATERNO del PAGADOR", "Validar Datos Pagador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtApePatRem.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtApeMatRem.Text))
                {
                    MessageBox.Show("Debe ingresar el APELLIDO MATERNO del PAGADOR", "Validar Datos Pagador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtApeMatRem.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtNomCliRem.Text))
                {
                    MessageBox.Show("Debe ingresar el(los) nombre(s) del PAGADOR", "Validar Datos Pagador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNomCliRem.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtCBDNIRem.Text))
                {
                    MessageBox.Show("Debe ingresar el DNI del PAGADOR", "Validar Datos Pagador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCBDNIRem.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtDirRem.Text))
                {
                    MessageBox.Show("Debe ingresar la dirección del PAGADOR", "Validar Datos Pagador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDirRem.Focus();
                    return false;
                }
            }
            
            if (Convert.ToInt32(cboModalidad.SelectedValue) == 0)
            {
                MessageBox.Show("Debe seleccionar la modalidad de Pago", "Validar Datos Pagador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboModalidad.Focus();
                return false;
            }

            if (Convert.ToInt32(cboModalidad.SelectedValue) == 3)//CHEQUE
            {
                if (cboTipoEntidad.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar el Tipo de Entidad Financiera", "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (cboEntidad1.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar la Entidad Financiera", "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboEntidad1.Focus();
                    return false;
                }
                if (txtNroCuenta.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Debe INGRESAR Nro de Cuenta.", "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboCuenta.Focus();
                    return false;
                }
                if (txtNroSerie.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Debe INGRESAR Nro de Serie Cheque", "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboCuenta.Focus();
                    return false;
                }
                if (txtNroDocumento.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Debe INGRESAR Nro de Cheque", "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboCuenta.Focus();
                    return false;
                }
            }
            if (Convert.ToInt32(cboModalidad.SelectedValue) == 4)//INTERBANCARIO
            {
                if (cboTipoEntidad.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar el Tipo de Entidad Financiera", "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (cboEntidad1.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar la Entidad Financiera", "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboEntidad1.Focus();
                    return false;
                }
                if (cboCuenta.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar Nro de Cuenta.", "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboCuenta.Focus();
                    return false;
                }
                if (txtNroSerie.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Debe INGRESAR Nro de Serie.", "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboCuenta.Focus();
                    return false;
                }
                if (txtNroDocumento.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Debe INGRESAR Nro de Documento", "Pago de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboCuenta.Focus();
                    return false;
                }
            }
            //------------------------------------------------------------------------->
            return true;
        }

        private DataSet ObtenerDatosPagador()
        {            
            DataTable dtUsuarioPagador = new DataTable("dtUsuarioPagador");
            dtUsuarioPagador.Columns.Add("idCli", typeof(int));
            dtUsuarioPagador.Columns.Add("cNombre", typeof(string));
            dtUsuarioPagador.Columns.Add("cDocumentoID", typeof(string));
            dtUsuarioPagador.Columns.Add("cDireccion", typeof(string));
            dtUsuarioPagador.Columns.Add("idModPagoAporteFondoSeg", typeof(int));
            dtUsuarioPagador.Columns.Add("idTipoPersona", typeof(int));
            dtUsuarioPagador.Columns.Add("idSocio", typeof(int));
            dtUsuarioPagador.Columns.Add("idEntidad", typeof(int));
            dtUsuarioPagador.Columns.Add("cNroCuenta", typeof(string));
            dtUsuarioPagador.Columns.Add("idCuenta", typeof(int));
            dtUsuarioPagador.Columns.Add("cSerie", typeof(string));
            dtUsuarioPagador.Columns.Add("cNroDocuemto", typeof(string));

            DataRow fila = dtUsuarioPagador.NewRow();
           //if (chcNoEsCli.Checked)
            //{
            //    fila["idCli"]               = 0;


            //    fila["cNombre"]             = txtApePatRem.Text + " " + txtApeMatRem.Text + ", " + txtNomCliRem.Text;
            //    fila["cDocumentoID"]        = txtCBDNIRem.Text;
            //    fila["cDireccion"]          = txtDirRem.Text;
            //    fila["idModPagoAporteFondoSeg"] = Convert.ToInt32(cboModalidad.SelectedValue);

            //    fila["idTipoPersona"]       = 1;
            //    fila["idSocio"]             = objsocio.idSocio;//Identificador del socio al que está relacionado (por el  que va a pagar)
            //    fila["idCuenta"]            = 0;
            //}
            
            if (Convert.ToInt32(cboModalidad.SelectedValue) == 1)
            {
                fila["idCli"]               = conBusCli1.idCli;
                fila["cNombre"]             = conBusCli1.txtNombre.Text;
                fila["cDocumentoID"]        = conBusCli1.txtNroDoc.Text;
                fila["cDireccion"]          = conBusCli1.txtDireccion.Text;
                fila["idModPagoAporteFondoSeg"] = Convert.ToInt32(cboModalidad.SelectedValue);
                fila["idTipoPersona"]       = conBusCli1.nidTipoPersona;
                fila["idSocio"]             = objsocio.idSocio;//Identificador del socio al que está relacionado (por el  que va a pagar)
                fila["idCuenta"]            = 0;
            }
			else if (Convert.ToInt32(cboModalidad.SelectedValue) == 2)//Trasferencia
            {
                fila["idCli"] = conBusCliPagador.idCli;
                fila["cNombre"] = conBusCliPagador.txtNombre.Text;
                fila["cDocumentoID"] = conBusCliPagador.txtNroDoc.Text;
                fila["cDireccion"] = conBusCliPagador.txtDireccion.Text;
                fila["idModPagoAporteFondoSeg"] = Convert.ToInt32(cboModalidad.SelectedValue);
                fila["idTipoPersona"] = conBusCliPagador.nidTipoPersona;
                fila["idSocio"] = objsocio.idSocio;//Identificador del socio al que está relacionado (por el  que va a pagar)
                fila["idCuenta"] = Convert.ToInt32(txtIdCtaAho.Text);
            }
             else if (Convert.ToInt32(cboModalidad.SelectedValue) == 3)//cheque
            {
                 fila["idCli"]               = conBusCliPagador.idCli;
                fila["cNombre"]             = conBusCliPagador.txtNombre.Text;
                fila["cDocumentoID"]        = conBusCliPagador.txtNroDoc.Text;
                fila["cDireccion"]          = conBusCliPagador.txtDireccion.Text;
                fila["idModPagoAporteFondoSeg"] = Convert.ToInt32(cboModalidad.SelectedValue);
                fila["idTipoPersona"]       = conBusCliPagador.nidTipoPersona;
                fila["idSocio"]             = objsocio.idSocio;//Identificador del socio al que está relacionado (por el  que va a pagar)
                fila["idEntidad"] = Convert.ToInt32(cboEntidad1.SelectedValue);
                fila["idCuenta"] = Convert.ToInt32(cboCuenta.SelectedValue);
                fila["cNroCuenta"] = txtNroCuenta.Text;
                fila["cSerie"] = txtNroSerie.Text;
                fila["cNroDocuemto"] = txtNroDocumento.Text;
            }
            else if (Convert.ToInt32(cboModalidad.SelectedValue) == 4)//interbancario
            {
                fila["idCli"] = conBusCliPagador.idCli;
                fila["cNombre"] = conBusCliPagador.txtNombre.Text;
                fila["cDocumentoID"] = conBusCliPagador.txtNroDoc.Text;
                fila["cDireccion"] = conBusCliPagador.txtDireccion.Text;
                fila["idModPagoAporteFondoSeg"] = Convert.ToInt32(cboModalidad.SelectedValue);
                fila["idTipoPersona"] = conBusCliPagador.nidTipoPersona;
                fila["idSocio"] = objsocio.idSocio;//Identificador del socio al que está relacionado (por el  que va a pagar)
                fila["idEntidad"]    = Convert.ToInt32(cboEntidad1.SelectedValue);
                fila["idCuenta"] = Convert.ToInt32(cboCuenta.SelectedValue);
                fila["cNroCuenta"] = txtNroCuenta.Text;
                fila["cSerie"]       = txtNroSerie.Text;
                fila["cNroDocuemto"] = txtNroDocumento.Text;
            }

            dtUsuarioPagador.Rows.Add(fila);

            DataSet dsUsuarioPagador = new DataSet("dsUsuarioPagador");
            dsUsuarioPagador.Tables.Add(dtUsuarioPagador);

            return dsUsuarioPagador;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if(CamposSonValidos()==false) return;          

            clslisDetalleAporte detalleaporte   = new clslisDetalleAporte();
            clslisDetalleFondo detallefondo     = new clslisDetalleFondo();

            detalleaporte.AddRange(((List<clsDetalleAporte>)dtgAportes.DataSource).Where(x => x.lPago == true).ToList());

            if (lSocioTieneFondoDeSeguro==true)
            {
                detallefondo.AddRange(((List<clsDetalleFondo>)dtgDetalleFondo.DataSource).Where(x => x.lPago == true).ToList());
            }            

            Boolean lPagarInscripcion    = Convert.ToDecimal(txtInscripcion.Text) > 0.00M ? true: false;
        
            DataSet dsUsuarioPagador     = ObtenerDatosPagador();
            dsUsuarioPagador.DataSetName = "dsUsuarioPagador";

            String xmlUsuarioPagador= dsUsuarioPagador.GetXml();
            xmlUsuarioPagador       = GEN.CapaNegocio.clsCNFormatoXML.EncodingXML(xmlUsuarioPagador);

            /*========================================================================================
            * REGISTRO DE RASTREO
            ========================================================================================*/
            this.registrarRastreo(this.conBusCli1.idCli, this.conBusCli1.idCli, "Inicio-Pago de aporte y fondo de socio", this.btnGrabar1);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/

            /*=========================      REALIZA MONITOREO DE SALDOS   ==========================*/
            Decimal nMonOpe = Convert.ToDecimal (txtTotPagar.Text);

            if (Convert.ToInt32(cboModalidad.SelectedValue) == 1)//TRANSFERENCIA A CUENTA
            {
                var Msg = MessageBox.Show("¿Estas Seguro de Realizar el Pago en Efectivo?...", "Pago de aporte y fondo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Msg == DialogResult.No)
                {
                    return;
                }

                if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt32(cboMoneda1.SelectedValue), 1, nMonOpe))
                {
                    return;
                }

               
            }
            /*==========================     FIN MONITOREO DE SALDOS    ===============================*/

            bool lModificaSaldoLinea = false;

            if (Convert.ToInt32(cboModalidad.SelectedValue) == 1)
                lModificaSaldoLinea = true;

            int idTipoTransac = 1; //INGRESO
            int idUsu = clsVarGlobal.User.idUsuario;
            int idMoneda_Saldo = Convert.ToInt32(cboMoneda1.SelectedValue);

            DataTable dtRpta = cnsocio.registrarPagoAporteFondo(detalleaporte, detallefondo, lPagarInscripcion, objsocio.idInscripcion, xmlUsuarioPagador, (int)cboTipoAporte1.SelectedValue, lModificaSaldoLinea, idTipoTransac, nMonOpe, idMoneda_Saldo);
            if (dtRpta.Rows.Count>0)
            {
                if (Convert.ToInt32(dtRpta.Rows[0]["idRpta"]) == 1)//CORRECTO 
                {
                    // RQ-412 Integracion de Saldos en Linea
                    new Semaforo().ValidarSaldoSemaforo();
                    
                    MessageBox.Show(dtRpta.Rows[0]["msg"].ToString(), "Pago de aporte y fondo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGrabar1.Enabled      = false;
                    dtgDetalleFondo.Enabled = false;
                    dtgAportes.Enabled      = false;

                    //-------- Deshabilitar contenedores ---------->
                    grbAportes.Enabled      = false;
                    grbFondoSeguro.Enabled  = false;
                    pnlDatosPagador.Enabled = false;
                    //-------------------------------------------->

                    //==================================-IMPRIMIR VOUCHER ==================================>
                    int idKarAporte = Convert.ToInt32(dtRpta.Rows[0]["idKardexAporte"]);
                    int idKarFondo  = Convert.ToInt32(dtRpta.Rows[0]["idKardexFondoSeg"]);
                    int idKarInscr  = Convert.ToInt32(dtRpta.Rows[0]["idKardexInscr"]);
                    int idCli       = conBusCli1.idCli;
                    int idMoneda    = Convert.ToInt32(cboMoneda1.SelectedValue);
                    int idUsuario   = clsVarGlobal.User.idUsuario;
                    
                    DataTable dtCli = cnsocio.CNDatosCli(idKarFondo, idKarAporte);
                    string nSaldoAporte = dtCli.Rows[0]["nSaldoAporte"].ToString();
                    string nSaldoFondo = dtCli.Rows[0]["nSaldoFondo"].ToString();
                    EmitirVoucher(idKarAporte, idKarFondo, idKarInscr, idCli, idMoneda, idUsuario, false, nSaldoAporte, nSaldoFondo);
                    //======================================================================================>
                }
                else//CON ERROR
                {
                    MessageBox.Show(dtRpta.Rows[0]["msg"].ToString(), "Pago de aporte y fondo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            /*========================================================================================
            * REGISTRO DE RASTREO
            ========================================================================================*/
            this.registrarRastreo(this.conBusCli1.idCli, this.conBusCli1.idCli, "Fin-Pago de aporte y fondo de socio", this.btnGrabar1);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
        }

        public void EmitirVoucher(int idKarAporte, int idKarFondo, int idKarInscr, int idCli, int idMoneda, int idUsuario, bool lIndSaldo, string nSaldoAporte, string nSaldoFondo)
        {
            string cVarVal = clsVarApl.dicVarGen["CRUTALOGO"];
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("idKarAporte", idKarAporte.ToString(), false));
            paramlist.Add(new ReportParameter("idKarFondo", idKarFondo.ToString(), false));
            paramlist.Add(new ReportParameter("idKarInscr", idKarInscr.ToString(), false));

            paramlist.Add(new ReportParameter("idCli", idCli.ToString(), false));
            paramlist.Add(new ReportParameter("idMoneda", idMoneda.ToString(), false));
            paramlist.Add(new ReportParameter("idUsuario", idUsuario.ToString(), false));

			paramlist.Add(new ReportParameter("nSaldoAporte", nSaldoAporte, false));
            paramlist.Add(new ReportParameter("nSaldoFondo", nSaldoFondo, false));
            paramlist.Add(new ReportParameter("lIndicaSaldo", lIndSaldo.ToString(), false));
            paramlist.Add(new ReportParameter("cNombreVariable", cVarVal, false));
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsPagoAporteFondo", cnsocio.CNReportePagoAporteFondo(idKarInscr, idKarAporte, idKarFondo, idCli, idMoneda, idUsuario)));
            string reportpath = "RptVoucherAporte.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();
        }

        private void formatoGridAprt()
        {
            //dtgAportes.Columns["idDetAporte"].Visible = false;
            //dtgAportes.Columns["idAporte"].Visible = false;
          
            //dtgAportes.Columns["idEstado"].Visible = false;

            //dtgAportes.Columns["cPeriodo"].HeaderText = "Periodo";
            //dtgAportes.Columns["dFecVenApo"].HeaderText = "Vence";
            //dtgAportes.Columns["nMonApoPac"].HeaderText = "Por Pagar";
            //dtgAportes.Columns["nMonApoPag"].HeaderText = "Monto Pago";
            //dtgAportes.Columns["lPago"].HeaderText = "Sel.";
            //dtgAportes.Columns["lPago"].ReadOnly = false;

            //dtgDetalleFondo.Columns["idDetFondo"].Visible = false;
            //dtgDetalleFondo.Columns["idFondo"].Visible = false;
            
            //dtgDetalleFondo.Columns["idEstado"].Visible = false;

            //dtgDetalleFondo.Columns["cPeriodo"].HeaderText = "Periodo";
            //dtgDetalleFondo.Columns["dFecVenApo"].HeaderText = "Vence";
            //dtgDetalleFondo.Columns["nMontoPac"].HeaderText = "Por Pagar";
            //dtgDetalleFondo.Columns["nMontoPag"].HeaderText = "Monto Pago";
            //dtgDetalleFondo.Columns["lPago"].HeaderText = "Sel.";
            //dtgDetalleFondo.Columns["lPago"].ReadOnly = false;
        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            idTipoAporte = Convert.ToInt32(cboTipoAporte1.SelectedValue);
            if (string.IsNullOrEmpty(txtTotAporte.Text.Trim()))// || Convert.ToDecimal(txtTotAporte.Text.Trim()) <= 0)
            {
                MessageBox.Show("El Monto de Aporte debe ser mayor que 0.00", "Registro de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotAporte.Focus();
            }
            RetornarAportes(objsocio.idAporte);
            decimal nmonto = txtTotAporte.nDecValor;
            txtTotAporte.Text = nmonto.ToString();
            dtgAportes.DataSource = listardetalleaporte(nmonto, idTipoAporte);
            formatoGridAprt();
            sumarTotal();
            dtgAportes.Enabled = true;
            dtgAportes.ReadOnly = false;
            dtgDetalleFondo.Enabled = true;
            dtgDetalleFondo.ReadOnly = false;

            if (dtgAportes.RowCount > 0)
            {
                dtgAportes.Rows[dtgAportes.RowCount - 1].Selected = true;
                dtgAportes.FirstDisplayedScrollingRowIndex = dtgAportes.RowCount - 1;
            }
        }

        private void btnBusFondo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTotFondo.Text.Trim()) || Convert.ToDecimal(txtTotFondo.Text.Trim()) <= 0)
            {
                MessageBox.Show("El Monto de Fondo de Seguro debe ser mayor que 0.00", "Registro de Fondo de Seguro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotFondo.Focus();
            }

            RetornarFondoMortuorio(objsocio.idFondo);

            decimal nmonto = txtTotFondo.nDecValor;
            txtTotFondo.Text = nmonto.ToString();

            dtgDetalleFondo.DataSource = listarFondoMortuorio(nmonto);
            formatoGridAprt();
            sumarTotal();
            dtgAportes.Enabled = true;
            dtgAportes.ReadOnly = false;
            dtgDetalleFondo.Enabled = true;
            dtgDetalleFondo.ReadOnly = false;

            if (dtgDetalleFondo.RowCount > 0)
            {
                dtgDetalleFondo.Rows[dtgDetalleFondo.RowCount - 1].Selected = true;
                dtgDetalleFondo.FirstDisplayedScrollingRowIndex = dtgDetalleFondo.RowCount - 1;
            }           
        }

        public clslisDetalleAporte listardetalleaporte(decimal nmonto, int idTipoAporte)
        {
            decimal nAportePactado = 0.00M;

            DateTime dfecMinCalculo;
            DateTime dfecUltimo     = clsVarGlobal.dFecSystem;
            decimal nmonTotalAprt   = nmonto;

            clslisDetalleAporte lista = new clslisDetalleAporte();
            int i = 0, j = 1;

            if (dtgAportes.Rows.Count > 0)
            {
                if (idTipoAporte==1)
                {
                    var aportes = (List<clsDetalleAporte>)dtgAportes.DataSource;
                    dfecMinCalculo = Convert.ToDateTime(aportes.Min(p => p.dFecVenApo)).AddDays(-1);

                    int nReg = 0;
                    while (nmonTotalAprt > 0.00M && nReg < dtgAportes.Rows.Count)
                    {
                        dfecUltimo = Convert.ToDateTime(aportes.Where(p => p.dFecVenApo > dfecMinCalculo).Min(p => p.dFecVenApo));
                        nAportePactado = Convert.ToDecimal(aportes.Where(p => p.dFecVenApo > dfecMinCalculo).Min(p => p.nMonApoPac));

                        lista.Add(new clsDetalleAporte()
                        {
                            idAporte = aportes.Min(p => p.idAporte),
                            idDetAporte = aportes.Where(x => x.dFecVenApo == dfecUltimo).Min(p => p.idDetAporte),
                            cPeriodo = aportes.Where(x => x.dFecVenApo == dfecUltimo).Min(p => p.cPeriodo),

                            dFecVenApo = dfecUltimo,
                            idEstado = aportes.Where(x => x.dFecVenApo == dfecUltimo).Min(p => p.idEstado),
                            nMonApoPac = nmonTotalAprt < nAportePactado ? nmonTotalAprt : nAportePactado,
                            nMonApoPag = aportes.Where(x => x.dFecVenApo == dfecUltimo).Min(p => p.nMonApoPag),
                            nMonApoPac1 = nmonAportePac,
                            lPago = nmonTotalAprt > 0.00M ? true : false
                        });
                        nmonTotalAprt = nmonTotalAprt - (nmonTotalAprt < nAportePactado ? nmonTotalAprt : nAportePactado);
                        dfecMinCalculo = dfecUltimo;
                        nReg += 1;
                    }
                    i += 1;
                    j += 1;
                }
                else
                {
                  //  dtgAportes.DataSource = null;
                    dfecUltimo = clsVarGlobal.dFecSystem;
                    lista.Add(new clsDetalleAporte()
                    {
                        idAporte = objsocio.idAporte,
                        idDetAporte = -j,
                        cPeriodo = dfecUltimo.Date.ToString("dd/MM/yyyy"),
                        dFecVenApo = dfecUltimo,
                        idEstado = 2,
                        nMonApoPac = nmonTotalAprt,
                        nMonApoPag = 0.00M,
                        nMonApoPac1 = nmonTotalAprt,
                        lPago = true
                    });
                }
               
            }
            else
            {
                DataTable ndata = cnsocio.retornarUltFecAporte(objsocio.idAporte, -1, 1);
                if (idTipoAporte==2)
                {
                    dfecUltimo = clsVarGlobal.dFecSystem;
                }
                else
                {
                    dfecUltimo = Convert.ToDateTime(ndata.Rows[0]["dFecVenApo"].ToString()).AddMonths(1);
                }
                  
            }

            if (idTipoAporte == 2 && dtgAportes.Rows.Count==0)
            {
                lista.Add(new clsDetalleAporte()
                {
                    idAporte = objsocio.idAporte,
                    idDetAporte = -j,
                    cPeriodo = dfecUltimo.Date.ToString("dd/MM/yyyy"),
                    dFecVenApo = dfecUltimo,
                    idEstado = 2,
                    nMonApoPac = nmonTotalAprt,
                    nMonApoPag = 0.00M,
                    nMonApoPac1 = nmonTotalAprt,
                    lPago = true
                });
            }
            else if (idTipoAporte == 1)
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
            }
             
            return lista;
        }

        public clslisDetalleFondo listarFondoMortuorio(decimal nmonto)
        {
            decimal nPagoFondoPactado = 0.00M;

            DateTime dfecMinCalculo;
            DateTime dfecUltimo = clsVarGlobal.dFecSystem;
            decimal nmonTotalFondo = nmonto;
            
            clsCNGenVariables RetVar = new clsCNGenVariables();
            int nVerSis = Convert.ToInt32(RetVar.RetornaVariable("nFrecFondMor", 0));
            clslisDetalleFondo listaFondoMort = new clslisDetalleFondo();
            int i = 0, j = 1;

            if (dtgDetalleFondo.Rows.Count > 0)
            {
                var fondo = (List<clsDetalleFondo>)dtgDetalleFondo.DataSource;
                dfecMinCalculo = Convert.ToDateTime(fondo.Min(p => p.dFecVenApo)).AddDays(-1);

                int nReg = 0;
                while (nmonTotalFondo > 0.00M && nReg < dtgDetalleFondo.Rows.Count)
                {
                    dfecUltimo = Convert.ToDateTime(fondo.Where(p => p.dFecVenApo > dfecMinCalculo).Min(p => p.dFecVenApo));
                    nPagoFondoPactado = Convert.ToDecimal(fondo.Where(p => p.dFecVenApo > dfecMinCalculo).Min(p => p.nMontoPac));

                    listaFondoMort.Add(new clsDetalleFondo()
                    {
                        idFondo = fondo.Max(p => p.idFondo),
                        idDetFondo = fondo.Where(p => p.dFecVenApo == dfecUltimo).Min(p => p.idDetFondo),
                        cPeriodo = fondo.Where(x => x.dFecVenApo == dfecUltimo).Min(p => p.cPeriodo),

                        dFecVenApo = dfecUltimo,
                        idEstado = fondo.Where(x => x.dFecVenApo == dfecUltimo).Min(p => p.idEstado),
                        nMontoPac = nmonTotalFondo < nPagoFondoPactado ? nmonTotalFondo : nPagoFondoPactado,
                        nMontoPag = fondo.Where(x => x.dFecVenApo == dfecUltimo).Min(p => p.nMontoPag),
                        nMontoPac1 = nmonFondoPac,
                        lPago = nmonTotalFondo > 0.00M ? true : false
                    });
                    nmonTotalFondo = nmonTotalFondo - (nmonTotalFondo < nPagoFondoPactado ? nmonTotalFondo : nPagoFondoPactado);
                    dfecMinCalculo = dfecUltimo;
                    nReg += 1;
                }
                i += 1;
                j += 1;
            }
            else
            {
                DataTable ndata = cnsocio.retornarUltFecAporte(-1, objsocio.idFondo, 2);
                dfecUltimo = Convert.ToDateTime(ndata.Rows[0]["dFecVenApo"].ToString()).AddMonths(nVerSis);
            }

            while (nmonFondoPac <= nmonTotalFondo)
            {
                listaFondoMort.Add(new clsDetalleFondo()
                {
                    idFondo     = objsocio.idFondo,
                    idDetFondo  = -j,
                    cPeriodo    = dfecUltimo.AddMonths(i).Date.ToString("dd/MM/yyyy"),
                    dFecVenApo  = dfecUltimo.AddMonths(i),
                    idEstado    = 1,
                    nMontoPac   = nmonFondoPac,
                    nMontoPag   = 0.00M,
                    nMontoPac1  = nmonFondoPac,
                    lPago       = true
                });
                nmonTotalFondo = nmonTotalFondo - nmonFondoPac;
                i += 1;
                j += 1;
            }

            if (nmonTotalFondo > 0)
            {
                listaFondoMort.Add(new clsDetalleFondo()
                {
                    idFondo     = objsocio.idFondo,
                    idDetFondo  = -j,
                    cPeriodo    = dfecUltimo.AddMonths(i).Date.ToString("dd/MM/yyyy"),
                    dFecVenApo  = dfecUltimo.AddMonths(i),
                    idEstado    = 1,
                    nMontoPac   = nmonTotalFondo,
                    nMontoPag   = 0.00M,
                    nMontoPac1  = nmonFondoPac,
                    lPago       = true
                });
            }
            return listaFondoMort;
        }

        private bool validaMontoPagoAporte()
        {
            decimal suma = 0;
            bool validar = true;
            if (Convert.ToDecimal(txtTotAporte.Text.Trim())>=9100000)
            {
                MessageBox.Show("El Monto Total de Aporte Es Demasiado Grande", "Validar Aporte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotAporte.Focus();
                validar = false;
            }
            var Aporte = (List<clsDetalleAporte>)dtgAportes.DataSource;
            suma = Aporte.Where(p => Convert.ToDateTime(p.cPeriodo) <= clsVarGlobal.dFecSystem).Sum(y => y.nMonApoPac);
            if (Convert.ToDecimal(txtTotAporte.Text.Trim()) == 0.00M)
            {
                MessageBox.Show("El Monto del Aporte Ingresado debe ser diferente a 0.00", "Validar Aporte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotAporte.Focus();
                validar = false;
            }
            return validar;
        }

        private bool validaMontoPagoFondo()
        {
            decimal suma=0;
            bool validar = true;
            if (Convert.ToDecimal(txtTotFondo.Text.Trim()) >= 9100000)
            {
                MessageBox.Show("El Monto Total del Fondo Es Demasiado Grande", "Validar Aporte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotAporte.Focus();
                validar = false;
            }
            var fondo = (List<clsDetalleFondo>)dtgDetalleFondo.DataSource;
            suma=fondo.Where(p => Convert.ToDateTime(p.cPeriodo) <= clsVarGlobal.dFecSystem).Sum(y => y.nMontoPac);
            if (suma > Convert.ToDecimal(txtTotFondo.Text.Trim()))
            {
                MessageBox.Show("El Monto del Fondo Ingresado es Menor al Pactado","Validar Fondo Mortuorio",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtTotFondo.Focus();
                validar = false;
            }
            return validar;
        }        

        private void txtTotAporte_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTotAporte.Text))
            {
                if (Convert.ToDecimal (txtTotAporte.Text) > 0)
                {
                    btnProcesar1_Click(sender, e);
                }
            }  
        }    

        private void habilitarBtnProcesar(bool lactiva)
        {
            btnProcesar1.Enabled    = lactiva;
            btnProcesaFondo.Enabled = lactiva;
            txtTotAporte.Enabled    = lactiva;
            txtTotFondo.Enabled     = lactiva;
        }

        private void txtTotAporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                btnProcesar1_Click(sender,e);
            }
        }

        private void txtTotFondo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBusFondo_Click(sender, e);
            }
        }

        private void cboModalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboModalidad.SelectedValue) == 0 || Convert.ToInt32(cboModalidad.SelectedValue) == 1)//Sin seleccionar - EFECTIVO 
            {
                grbCuentaAhorro.Enabled = false;
                grbCheInter.Enabled = false;//panel chueque e interbancario
                txtIdCtaAho.Text = "";
                txtCuentaAho.Text = "";

                cboTipoEntidad.SelectedIndex = -1;
                cboEntidad1.SelectedIndex = -1;
                txtNroSerie.Clear();
                txtNroDocumento.Clear();
                txtNroCuenta.Clear();
                cboCuenta.SelectedIndex = -1;
                txtIdCtaAho.Clear();
                txtCuentaAho.Clear();

            }

          //TRANSFERENCIA A CUENTA AHORRO CORRIENTE
            else if (Convert.ToInt32(cboModalidad.SelectedValue) == 2)
            {
                grbCuentaAhorro.Enabled = true;
                grbCuentaAhorro.Visible = true;

                grbCheInter.Enabled = false;
                grbCheInter.Visible = false;

                txtIdCtaAho.Clear();
                txtCuentaAho.Clear();
            }
            //INTERBANCARIOS
            else if (Convert.ToInt32(cboModalidad.SelectedValue) == 4)
            {
                CargarCtasbancosInterbancarios();
                grbCuentaAhorro.Enabled = false;
                grbCuentaAhorro.Visible = false;

                grbCheInter.Enabled = true;
                grbCheInter.Visible = true;
                cboCuenta.Visible = true;
                cboCuenta.Enabled = true;

                txtNroCuenta.Visible = false;
                cboTipoEntidad.SelectedIndex = -1;
                cboTipoEntidad.Enabled = false;
                cboEntidad1.SelectedIndex = -1;
                cboCuenta.SelectedIndex = -1;
                txtNroSerie.Clear();
                txtNroDocumento.Clear();
                txtNroCuenta.Clear();
                txtNroSerie.ReadOnly = false;
                txtNroDocumento.ReadOnly = false;
                txtNroCuenta.ReadOnly = false;

            }
            //PAGO CON CHEQUE
            else if (Convert.ToInt32(cboModalidad.SelectedValue) == 3)
            {
                grbCuentaAhorro.Enabled = false;
                grbCuentaAhorro.Visible = false;

                grbCheInter.Enabled = true;
                grbCheInter.Visible = true;
                cboCuenta.Visible = false;
                cboTipoEntidad.Enabled = true;

                cboTipoEntidad.SelectedIndex = -1;
                cboEntidad1.SelectedIndex = -1;
                txtNroSerie.Clear();
                txtNroDocumento.Clear();
                txtNroCuenta.Clear();
                txtNroSerie.ReadOnly = false;
                txtNroDocumento.ReadOnly = false;
                txtNroCuenta.Visible = true;
                txtNroCuenta.ReadOnly = false;
                txtNroCuenta.Enabled = true;
                txtNroDocumento.Enabled = true;
            }

        }
        private void CargarCtasbancosInterbancarios()
        {
            DataTable dtEntidad;
            dtEntidad = clsDeposito.ListarEntidadesConCuenta();
            //--Cheques Externos
            cboEntidad1.DataSource = dtEntidad;
            cboEntidad1.ValueMember = "idEntidad";
            cboEntidad1.DisplayMember = "cNombreCorto";
        }
        private void chcNoEsCli_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarCtrlPagador();
            if (chcNoEsCli.Checked)
            {
                conBusCliPagador.Visible = false;
                grbRem.Visible = true;

                Boolean lEsClienteInstitucion = false;
                CargarComboModalidad(lEsClienteInstitucion);                
            }
            else
            {
                conBusCliPagador.Visible    = true;
                grbRem.Visible              = false;

                Boolean lEsClienteInstitucion = true;
                CargarComboModalidad(lEsClienteInstitucion);
            } 
        }

        private void LimpiarCtrlPagador()
        {
            //---Datos del Pagador
            this.conBusCliPagador.txtCodInst.Clear();
            this.conBusCliPagador.txtCodAge.Clear();
            this.conBusCliPagador.txtCodCli.Clear();
            this.conBusCliPagador.txtNombre.Clear();
            this.conBusCliPagador.txtNroDoc.Clear();
            this.conBusCliPagador.txtDireccion.Clear();
            this.txtApePatRem.Clear();
            this.txtApeMatRem.Clear();
            this.txtNomCliRem.Clear();
            this.txtCBDNIRem.Clear();
            this.txtDirRem.Clear();

            cboModalidad.SelectedIndex = 0;
            txtIdCtaAho.Clear();
            txtCuentaAho.Clear();
        }

        private void btnBuscaCtaAho_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.conBusCliPagador.txtCodCli.Text))
            {
                MessageBox.Show("Seleccione el socio(a) de quien se realizará la búsqueda de la cuenta para la transferencia.", "Validar Cuenta de Ahorro",  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCliPagador.txtCodCli.Focus();
                return;
            }

            int idCliBenefic = Convert.ToInt32(this.conBusCliPagador.txtCodCli.Text); ;
            frmBusCtaAho frmCtaAho = new frmBusCtaAho();
            frmCtaAho.idCli     = idCliBenefic;
            frmCtaAho.pTipBus   = 1;
            frmCtaAho.idMon     = 1;//Actualmente el StoreProcedure retorna todas las Cuentas disponibles para retiro (no se tiene en cuenta la moneda) 
            frmCtaAho.nTipOpe   = 11; //--Cuentas para Operación de Retiro         

            clsCNDeposito objDeposito = new clsCNDeposito();
            DataTable dtbNumCuentas = objDeposito.CNRetornaCuentasAhorros(idCliBenefic, 1, 1, frmCtaAho.nTipOpe);

            if (dtbNumCuentas.Rows.Count > 0)
            {
                frmCtaAho.ShowDialog();
                txtIdCtaAho.Text    = frmCtaAho.pnCta;
                txtCuentaAho.Text   = frmCtaAho.pcNroCta;
                //nMontoCuentaCoriente = string.IsNullOrEmpty(frmCtaAho.pnMonDisp) ? 0.00 : Convert.ToDecimal(frmCtaAho.pnMonDisp);
                //idMonedaCuenta = Convert.ToInt32(cboMoneda.SelectedValue);
            }
            else
            {
                MessageBox.Show("NO EXISTE CUENTA DE AHORRO PARA VINCULAR" + "\n" + "Debe aperturar una cuenta de ahorro", "Validar Cuenta de Ahorro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdCtaAho.Text = "";
                txtCuentaAho.Text = "";
                return;
            }
        }

        private void cboTipoAporte1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTotAporte.Text))
            {
                if (Convert.ToDecimal (txtTotAporte.Text) > 0)
                {
                    btnProcesar1_Click(sender, e);
                }
            }
            
        }

        private void txtTotFondo_Leave(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtTotFondo.Text))
            {
                if (Convert.ToDecimal (txtTotFondo.Text) > 0)
                {
                    btnBusFondo_Click(sender, e);
                }
            }
        }

        private void grbAportes_Enter(object sender, EventArgs e)
        {

        }

        private void txtTotAporte_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cboTipoEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoEntidad.SelectedIndex > 0)
            {
                int nTipEnt = Convert.ToInt32(this.cboTipoEntidad.SelectedValue);
                cboEntidad1.CargarEntidades(nTipEnt);
                cboEntidad1.SelectedIndex = -1;

            }
        }

        private void cboEntidad1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEntidad1.SelectedIndex == -1 || cboEntidad1.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }
            DataTable dt;
            int idEntidad = Convert.ToInt32(cboEntidad1.SelectedValue);
            dt = objCpg.ListarCuentaXEntidades(idEntidad);
            cboCuenta.DataSource = dt;
            cboCuenta.ValueMember = "idCuentaInstitucion";
            cboCuenta.DisplayMember = "cNumeroCuenta";
            cboCuenta.SelectedIndex = -1;
        }
		 private void btnImprSocio_Click(object sender, EventArgs e)
        {
            int idCli = conBusCli1.idCli;
            int idEstado = 1;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            String AgenEmision = clsVarApl.dicVarGen["cNomAge"];

            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            paramlist.Add(new ReportParameter("x_cNombEmpresa", cNomEmp, false));
            paramlist.Add(new ReportParameter("x_AgenEmision", AgenEmision, false));
            paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("pnidCli", idCli.ToString(), false));
            paramlist.Add(new ReportParameter("idCli", idCli.ToString(), false));
            paramlist.Add(new ReportParameter("cNombreVariable", "CRUTALOGO", false));

            int lMostrarCuentaAhorro = 1;

            paramlist.Add(new ReportParameter("lMostrarCuentaAhorro", lMostrarCuentaAhorro.ToString(), false));

            dtslist.Add(new ReportDataSource("DataSet1", new clsRPTCNClientes().CNRetornoCliente(idCli)));
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsAportes", cnsocio.CNHistoricoAportes(idCli, idEstado)));
            dtslist.Add(new ReportDataSource("dtsFondoSeg", cnsocio.CNHistoricoFondoSeguro(idCli, idEstado)));
            dtslist.Add(new ReportDataSource("dtsCliAval", cnsocio.CNHistoricoCliComoAval(idCli, idEstado)));
            dtslist.Add(new ReportDataSource("dtsCreCli", cnsocio.CNHistoricoCre(idCli, idEstado)));
            dtslist.Add(new ReportDataSource("dtsAhorrroCli", cnsocio.CNHistoricoDeposito(idCli, idEstado)));

            string reportpath = "rptCuentasCli.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog(); 

        }

         private void conBusCliPagador_ClicBuscar(object sender, EventArgs e)
         {
             if (Convert.ToInt32(cboModalidad.SelectedValue)==2)
             {   
                 txtIdCtaAho.Clear();
                 txtCuentaAho.Clear();
                 
             }
          
         }
    }
}
