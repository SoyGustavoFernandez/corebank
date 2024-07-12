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
using GEN.CapaNegocio;
using DEP.CapaNegocio;
using EntityLayer;

namespace DEP.Presentacion
{
    public partial class frmSolCambioTitular : frmBase
    {
        DataTable dtIntervAct = null;
        DataTable dtIntervRet = null;
        DataTable dtInt = new DataTable();
        int p_idProd = 0;
        int p_idCta = 0;

        clsCNDeposito clsDeposito = new clsCNDeposito();

        public frmSolCambioTitular()
        {
            InitializeComponent();
        }

        private void frmSolCambioTitular_Load(object sender, EventArgs e)
        {
            conBusCtaAho.nTipOpe = 12;  //--Ope Cancelación, Igual Lista todas las cuentas vigentes
            cargarcolumnas();
            cboMotivos.CargarMotivos(5);
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            dtgIntervActivos.AutoGenerateColumns = false;
            dtgIntervRet.AutoGenerateColumns = false;
            dtgIntervinientes.AutoGenerateColumns = false;
            conBusCtaAho.Focus();
            conBusCtaAho.txtCodAge.Focus();
        }

        private void conBusCtaAho_ClicBusCta(object sender, EventArgs e)
        {
            limpiarcontroles();
            if (conBusCtaAho.idcuenta > 0)
            {
                DatosCuenta(Convert.ToInt32(conBusCtaAho.idcuenta));
            }
        }

        private void DatosCuenta(int idCta)
        {
            p_idCta = idCta;
            DataTable dtbNumCuentas = clsDeposito.CNRetornaDatosCuenta(idCta, "1", 12);
            if (dtbNumCuentas.Rows.Count > 0)
            {
                //----------------------------------------------------------------------------
                //--Validar Si tiene solicitudes pendientes
                //----------------------------------------------------------------------------
                clsCNAutorTasaEsp solicitud = new clsCNAutorTasaEsp();
                DataTable dtValSol = solicitud.ValidaSolCambioTitxCta(p_idCta);
                if (dtValSol.Rows.Count > 0)
                {
                    int x_idEstSol = Convert.ToInt32(dtValSol.Rows[0]["idEstadoSol"]);
                    switch (x_idEstSol)
                    {
                        case 1: //--Solicitado
                            MessageBox.Show("La Cuenta, tiene Solicitudes pendientes por Aprobación...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            p_idCta = 0;
                            conBusCtaAho.LimpiarControles();
                            conBusCtaAho.txtCodAge.Focus();
                            return;
                        case 2: //--Aprobado
                            MessageBox.Show("La Cuenta, tiene Solicitudes Aprobadas pendientes de confirmación...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            p_idCta = 0;
                            conBusCtaAho.LimpiarControles();
                            conBusCtaAho.txtCodAge.Focus();
                            return;
                    }
                }

                if (!string.IsNullOrEmpty(dtbNumCuentas.Rows[0]["idUsuarioqBlo"].ToString()))
                {
                    int idusuBlo = Convert.ToInt32(dtbNumCuentas.Rows[0]["idUsuarioqBlo"].ToString());
                    clsCNRetornaNumCuenta RetUsuario = new clsCNRetornaNumCuenta();
                    DataTable dtUsu = RetUsuario.BusUsuBlo(idusuBlo);
                    string cUserBloqueo = dtUsu.Rows[0][0].ToString();
                    MessageBox.Show("La Cuenta esta Siendo Consultada por Otro Usuario: " + cUserBloqueo, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    p_idCta = 0;
                    conBusCtaAho.LimpiarControles();
                    conBusCtaAho.txtCodAge.Focus();
                    return;
                }

                if (Convert.ToInt16(dtbNumCuentas.Rows[0]["idTipoPersona"].ToString()) == 1)
                {
                    MessageBox.Show("El Cambio de Titulares, es solo para personas Jurídicas", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    p_idCta = 0;
                    return;
                }

                txtProducto.Text = dtbNumCuentas.Rows[0]["cProducto"].ToString();
                cboMoneda.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idMoneda"].ToString());
                cboTipoCuenta.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idTipoCuenta"].ToString());
                txtTipoPersona.Text = dtbNumCuentas.Rows[0]["cPersona"].ToString();
                dtFecApertura.Value = Convert.ToDateTime(dtbNumCuentas.Rows[0]["dFechaApertura"].ToString());
                txtNroFirmas.Text = dtbNumCuentas.Rows[0]["nNumeroFirmas"].ToString();
                chcITF.Checked = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsAfectoITF"].ToString());
                p_idProd = Convert.ToInt32(dtbNumCuentas.Rows[0]["idProducto"]);

                //--===================================================================================
                //--Cargar de Intervinientes de la Cuenta
                //--===================================================================================
                dtIntervAct = clsDeposito.CNRetornaIntervinientesCuenta(idCta);
                dtgIntervActivos.DataSource = dtIntervAct;

                //--===================================================================================
                //--Cargar de Intervinientes de la Cuenta
                //--===================================================================================
                dtIntervRet = clsDeposito.CNRetornaIntervinientesCuenta(0);
                dtgIntervRet.DataSource = dtIntervRet;

                //--===================================================================================
                //--Habilitar Controles
                //--===================================================================================
                conBusCtaAho.HabDeshabilitarCtrl(false);
                conBusCtaAho.btnBusCliente.Enabled = false;
                HabilitarCtrl(true);
                btnEnviar.Enabled = true;
                clsDeposito.CNUpdUsoCuenta(p_idCta, clsVarGlobal.User.idUsuario);
                btnMiniPasarDerecha.Focus();
            }
            else
            {
                MessageBox.Show("No Existen datos, por favor Verificar...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsDeposito.CNUpdNoUsoCuenta(p_idCta);
                return;
            }
        }

        private void cargarcolumnas()
        {
            //Estructura de Intervinientes:
            if (dtgIntervinientes.Columns.Count > 0)
            {
                dtgIntervinientes.Columns.Remove("codigo");
                dtgIntervinientes.Columns.Remove("nombres");
                dtgIntervinientes.Columns.Remove("tipodoc");
                dtgIntervinientes.Columns.Remove("documento");
                dtgIntervinientes.Columns.Remove("cmb");
                dtgIntervinientes.Columns.Remove("idTipoInterv");
                dtgIntervinientes.Columns.Remove("direccion");
                dtgIntervinientes.Columns.Remove("lEsAfeItf");
            }

            dtInt.Columns.Add("codigo", typeof(string));
            dtInt.Columns.Add("nombres", typeof(string));
            dtInt.Columns.Add("tipodoc", typeof(string));
            dtInt.Columns.Add("documento", typeof(string));
            dtInt.Columns.Add("idTipoInterv", typeof(string));
            dtInt.Columns.Add("idCuenta", typeof(string));
            dtInt.Columns.Add("direccion", typeof(string));
            dtInt.Columns.Add("lEsAfeItf", typeof(bool));

            this.dtgIntervinientes.DataSource = dtInt.DefaultView;

            clsCNInterviniente TipoInterv = new clsCNInterviniente();
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "Int.";
            cmb.Name = "cmb";
            cmb.FillWeight = 50;
            cmb.MaxDropDownItems = 4;
            cmb.DataSource = TipoInterv.CNListaTipoIntervDep();
            cmb.DisplayMember = "CTIPOINTERVENCION";
            cmb.ValueMember = "idtipointerv";

            dtgIntervinientes.Columns.Add(cmb);
            dtgIntervinientes.Columns["codigo"].HeaderText = "Código Cli.";
            dtgIntervinientes.Columns["nombres"].HeaderText = "Nombres y Apellidos";
            dtgIntervinientes.Columns["tipodoc"].HeaderText = "Tipo de Documento";
            dtgIntervinientes.Columns["documento"].HeaderText = "Documento";
            dtgIntervinientes.Columns["lEsAfeItf"].HeaderText = "ITF";
            dtgIntervinientes.Columns["idTipoInterv"].Visible = false;
            dtgIntervinientes.Columns["idCuenta"].Visible = false;
            dtgIntervinientes.Columns["direccion"].Visible = false;

            dtgIntervinientes.Columns["cmb"].Width = 130;
            dtgIntervinientes.Columns["codigo"].Width = 100;
            dtgIntervinientes.Columns["nombres"].Width = 320;
            dtgIntervinientes.Columns["tipodoc"].Width = 100;
            dtgIntervinientes.Columns["documento"].Width = 140;
            dtgIntervinientes.Columns["lEsAfeItf"].Width = 60;

            dtgIntervinientes.Columns["cmb"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgIntervinientes.Columns["codigo"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgIntervinientes.Columns["nombres"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgIntervinientes.Columns["tipodoc"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgIntervinientes.Columns["documento"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dtgIntervinientes.Columns["lEsAfeItf"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dtgIntervinientes.Columns["cmb"].ReadOnly = false;
            dtgIntervinientes.Columns["codigo"].ReadOnly = true;
            dtgIntervinientes.Columns["nombres"].ReadOnly = true;
            dtgIntervinientes.Columns["tipodoc"].ReadOnly = true;
            dtgIntervinientes.Columns["documento"].ReadOnly = true;
            dtgIntervinientes.Columns["direccion"].ReadOnly = true;
            dtgIntervinientes.Columns["lEsAfeItf"].ReadOnly = false;
            //Estructura de Datos Cuenta:
        }

        private void CargarIntervinientes(int idCuenta)
        {
            DataTable dtbIntervCta = clsDeposito.CNRetornaIntervinientesCuenta(idCuenta);
            dtgIntervActivos.DataSource = dtbIntervCta;  
        }

        private void limpiarcontroles()
        {
            //---Datos de la Cuenta
            txtProducto.Clear();
            cboMoneda.SelectedValue = 1;
            cboTipoCuenta.SelectedValue = 1;
            txtTipoPersona.Clear();
            dtFecApertura.Value = clsVarGlobal.dFecSystem;
            txtNroFirmas.Clear();
            chcITF.Checked = false;

            //---Datos de los Grid
            if (dtgIntervActivos.Rows.Count > 0)
            {
                ((DataTable)dtgIntervActivos.DataSource).Rows.Clear();
            }
            dtgIntervActivos.Refresh();

            if (dtgIntervRet.Rows.Count > 0)
            {
                ((DataTable)dtgIntervRet.DataSource).Rows.Clear();
            }
            dtgIntervRet.Refresh();

            if (dtgIntervinientes.Rows.Count > 0)
            {
                dtInt.Rows.Clear();
            }

            //---Datos de la Solicitud
            cboMotivos.SelectedValue = 1;
            txtMotCambio.Clear();
            txtFirmasNue.Clear();
            txtDocRef.Clear();
            dtpFechaDoc.Value = clsVarGlobal.dFecSystem;
            txtCorreo.Clear();
            txtNroTelf.Clear();
            p_idCta = 0;
        }

        private bool ValidarIntervinientesCta()
        {
            int nVal = 0;
            int nRepres = 0;
            for (int i = 0; i < dtIntervAct.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtIntervAct.Rows[i]["idTipoInterv"].ToString()) == 6) //--Titular
                {
                    nVal = nVal + 1;
                }
                if (Convert.ToInt32(dtIntervAct.Rows[i]["idTipoInterv"].ToString()) == 7) //--Representantes
                {
                    nRepres = nRepres + 1;
                }
            }
            if (nVal==0)
            {
                MessageBox.Show("En los Intervinientes Actuales, debe estar el titular de la cuenta...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (nVal >1)
            {
                MessageBox.Show("El número de Titulares de la Cuenta, debe ser 1, por favor verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            for (int i = 0; i < dtInt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtInt.Rows[i]["idTipoInterv"].ToString()) == 7) //--Representantes
                {
                    nRepres = nRepres + 1;
                }
            }
            if (nRepres==0)
            {
                MessageBox.Show("Mínimamente la cuenta debe tener un Representante...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrEmpty(txtFirmasNue.Text))
            {
                MessageBox.Show("Debe registrar el nuevo número de firmas requeridos...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtFirmasNue.Focus();
                return false;
            }
            if (Convert.ToInt32(txtFirmasNue.Text)>nRepres)
            {
                MessageBox.Show("El número de Firmas, No puede ser mayor al Nro de Representantes...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtFirmasNue.Focus();
                return false;
            }

            if (Convert.ToInt32(txtFirmasNue.Text)<=0)
            {
                MessageBox.Show("El número de Firmas, No puede ser Menor o igual a cero(0)...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtFirmasNue.Focus();
                return false;
            }

            return true;
        }

        
        private void btnMiniPasarDerecha_Click(object sender, EventArgs e)
        {
            if (dtIntervAct.Rows.Count<=1)
            {
                MessageBox.Show("No se Puede Cambiar Todos los Intervinientes, Incluyendo el Titular", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Convert.ToInt32(dtgIntervActivos.Rows[dtgIntervActivos.SelectedCells[0].RowIndex].Cells["idTipoInterv"].Value)==6)
            {
                MessageBox.Show("El Titular de la Cuenta, no puede ser Cambiado", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            dtIntervRet.ImportRow(dtIntervAct.Rows[dtgIntervActivos.CurrentRow.Index]);
            dtIntervAct.Rows.Remove(dtIntervAct.Rows[dtgIntervActivos.CurrentRow.Index]);
        }

        private void btnMiniPasarIzquierda_Click(object sender, EventArgs e)
        {
            if (dtIntervRet.Rows.Count<=0)
            {
                MessageBox.Show("No existen Intervinientes Retirados...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dtIntervAct.ImportRow(dtIntervRet.Rows[dtgIntervRet.CurrentRow.Index]);
            dtIntervRet.Rows.Remove(dtIntervRet.Rows[dtgIntervRet.CurrentRow.Index]);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(conBusCtaAho.txtCodCli.Text))
            {
                MessageBox.Show("Primero debe Buscar la cuenta...Verificar", "Validación de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //==========================================
            //--Bucar Clientes
            //==========================================
            FrmBusCli busca = new FrmBusCli();
            busca.ShowDialog();

            if (string.IsNullOrEmpty(busca.pcCodCli))
            {
                return;
            }

            if (busca.pIndicaDatoBasico == true)
            {
                MessageBox.Show("Debe Registrar Datos Completos del Cliente", "Validación de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //--===============================================================
            //--Validar que el Mismo Cliente no Puede Realizar Aperturas
            //--===============================================================
            if (Convert.ToInt32(busca.pcCodCli) == clsVarGlobal.User.idCli)
            {
                MessageBox.Show("El Mismo Usuario No Puede Aperturar una Cuenta a su Nombre", "Validación del Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //=================================================
            //--Validar Tipo de Cliente: Natural, Jurídica
            //=================================================
            if (Convert.ToInt32(busca.pnTipoPersona) != 1)
            {
                MessageBox.Show("El Tipo de Persona a Agregar debe ser: Persona Natural", "Validación Interviniente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!ValidarCliente(Convert.ToInt32(busca.pcCodCli)))
            {
                return;
            }

            //==============================================
            //--Validar Si ya Registro el Cliente
            //==============================================
            foreach (DataRow item in dtInt.Rows)
            {
                if (item["codigo"].ToString() == busca.pcCodCli)
                {
                    MessageBox.Show("Ya agrego al cliente seleccionado", "Validación Interviniente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            //==============================================================================
            //--Validar Si el Cliente es Representante de la Empresa
            //==============================================================================
            clsCNCliVinculDep clsInterv = new clsCNCliVinculDep();
            DataTable dtValInterv = clsInterv.ValidaIntervinienteJur(Convert.ToInt32(conBusCtaAho.txtCodCli.Text),Convert.ToInt32(busca.pcCodCli));
            if (dtValInterv.Rows.Count>0)
            {
                if (!(Convert.ToDateTime(dtValInterv.Rows[0]["dFechaInicio"].ToString())<=clsVarGlobal.dFecSystem && Convert.ToDateTime(dtValInterv.Rows[0]["dFechaFinal"].ToString())>=clsVarGlobal.dFecSystem ))
                {
                    MessageBox.Show("El representante de la empresa no esta Vigente, por favor verificar...", "Validación Interviniente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                MessageBox.Show("El cliente, no es Representante de la Empresa, por favor verificar su datos registrados...", "Validación Interviniente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            //==============================================
            //--Agregar Datos el Grid 
            //==============================================
            DataRow dr = dtInt.NewRow();
            dr["codigo"] = Convert.ToInt32(busca.pcCodCli);
            dr["nombres"] = busca.pcNomCli;
            dr["tipodoc"] = busca.pcTipoDocumento;
            dr["documento"] = busca.pcNroDoc;
            dr["idTipoInterv"] = "7";
            dr["idCuenta"] = "0";
            dr["direccion"] = busca.pcDireccion;
            dr["lEsAfeItf"] = false;
            dtgIntervinientes.Columns["lEsAfeItf"].ReadOnly = false;
            dtgIntervinientes.Columns["cmb"].ReadOnly = false;

            dtInt.Rows.Add(dr);
            int nReg = dtInt.Rows.Count - 1;
            dtgIntervinientes.Rows[nReg].Cells["cmb"].Value = 7;      
        }

        private bool ValidarCliente(int idCli)
        {
            for (int i = 0; i < dtIntervAct.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtIntervAct.Rows[i]["idCli"].ToString())==idCli)
                {
                    MessageBox.Show("El Cliente ya esta Registrado como Representante...Verificar", "Validación Interviniente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            for (int i = 0; i < dtIntervRet.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtIntervRet.Rows[i]["idCli"].ToString()) == idCli)
                {
                    MessageBox.Show("El Cliente ya esta Registrado como Representante...Verificar", "Validación Interviniente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            
            return true;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgIntervinientes.Rows.Count > 0)
            {
                this.dtgIntervinientes.Rows.Remove(dtgIntervinientes.CurrentRow);
                this.dtgIntervinientes.Refresh();
            }
            else
            {
                MessageBox.Show("No Existe Datos a Eliminar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnAgregar.Focus();
                return;
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (!ValidarIntervinientesCta())
            {
                return;
            }
            if (!ValidarDatosIngresados())
            {
                return;
            }
            //---Generar los Archivos XML
            DataSet dsIntervAct = new DataSet("dsInterviniente");
            dsIntervAct.Tables.Add(dtIntervAct);
            string xmlIntervAct = clsCNFormatoXML.EncodingXML(dsIntervAct.GetXml());

            DataSet dsIntervRet = new DataSet("dsInterviniente");
            dsIntervRet.Tables.Add(dtIntervRet);
            string xmlIntervRet = clsCNFormatoXML.EncodingXML(dsIntervRet.GetXml());

            DataSet dsIntervNue = new DataSet("dsInterviniente");
            dsIntervNue.Tables.Add(dtInt);
            string xmlIntervNue = clsCNFormatoXML.EncodingXML(dsIntervNue.GetXml());

            //---Asignar Datos a Guardar
            string x_cMotCambio = txtMotCambio.Text,
                    x_cDocRef   = txtDocRef.Text,
                    x_cCorreo   = txtCorreo.Text,
                    x_cNroTelf  = txtNroTelf.Text;
            int x_nNroFirmas = Convert.ToInt16(txtFirmasNue.Text),
                x_idCuenta = conBusCtaAho.idcuenta,
                x_idMotivo=Convert.ToInt16(cboMotivos.SelectedValue);

            DateTime x_dFechaDoc = dtpFechaDoc.Value;

            clsCNAutorTasaEsp solicitud = new clsCNAutorTasaEsp();
            DataTable dtSol= solicitud.EnviarSolicitud(clsVarGlobal.nIdAgencia, Convert.ToInt32(conBusCtaAho.txtCodCli.Text), 113, 1, Convert.ToInt32(cboMoneda.SelectedValue), 
                                        p_idProd,0, x_idCuenta, clsVarGlobal.dFecSystem,Convert.ToInt32(cboMotivos.SelectedValue), x_cMotCambio, 1, 
                                        Convert.ToDateTime("01/01/1900"), Convert.ToInt32(clsVarGlobal.User.idUsuario));
            
            if (Convert.ToInt32(dtSol.Rows[0]["idEstadoSol"].ToString()) == 1)
            {
                int x_idSolicitud = Convert.ToInt32(dtSol.Rows[0]["idSolAproba"].ToString());
                DataTable dtRegSol=solicitud.RegistraSolCambioInterv(x_idCuenta,x_idMotivo,x_cMotCambio,x_nNroFirmas,x_cDocRef,x_dFechaDoc,x_cCorreo,x_cNroTelf,
                                                                       x_idSolicitud,clsVarGlobal.User.idUsuario,clsVarGlobal.nIdAgencia,xmlIntervRet,xmlIntervNue);
                if (Convert.ToInt32(dtSol.Rows[0]["idSolAproba"].ToString()) > 0)
	            {
                    MessageBox.Show(dtSol.Rows[0]["cMensaje"].ToString() + ", Nro. Solicitud: " + dtSol.Rows[0]["idSolAproba"].ToString(), "Registro de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);  
	            }
                else
                {
                    MessageBox.Show(dtRegSol.Rows[0]["cMensaje"].ToString(), "Registro de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);  
                }
                
            }
            else
	        {
                MessageBox.Show(dtSol.Rows[0]["cMensaje"].ToString(), "Registro de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	        }

            HabilitarCtrl(false);
            btnEnviar.Enabled = false;

            dsIntervAct.Dispose();
            dtIntervAct.Dispose();
            dsIntervRet.Dispose();
            dtIntervRet.Dispose();
            dsIntervNue.Dispose();
            dtInt.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (p_idCta > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(p_idCta);
            }
            limpiarcontroles();
            HabilitarCtrl(false);
            conBusCtaAho.LimpiarControles();
            btnEnviar.Enabled = false;
            conBusCtaAho.HabDeshabilitarCtrl(true);
            conBusCtaAho.btnBusCliente.Enabled = true;
            conBusCtaAho.txtCodAge.Focus();
        }

        private bool ValidarDatosIngresados()
        {
            if (Convert.ToInt32(cboMotivos.SelectedIndex)==-1)
            {
                MessageBox.Show("Debe seleccionar el Motivo de cambio de titulares...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboMotivos.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMotCambio.Text))
            {
                MessageBox.Show("Debe registrar el motivo de cambio de Intervinientes...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtMotCambio.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtFirmasNue.Text))
            {
                MessageBox.Show("Debe registrar el nuevo número de firmas requeridos...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtFirmasNue.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDocRef.Text))
            {
                MessageBox.Show("Debe registrar el documento de referencia...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtDocRef.Focus();
                return false;
            }
            if (dtpFechaDoc.Value>clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La Fecha del Documento, no pede ser posterior a la Fecha Actual del Sistema", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtpFechaDoc.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                MessageBox.Show("Debe registrar el correo del contacto...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtCorreo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNroTelf.Text))
            {
                MessageBox.Show("Debe registrar el Numero de teléfono del contacto...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtNroTelf.Focus();
                return false;
            }
            if (dtgIntervRet.Rows.Count<=0 && dtgIntervinientes.Rows.Count<=0)
            {
                MessageBox.Show("Por los menos, se debe agregar o quitar los representantes", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtgIntervActivos.Focus();
                return false;
            }

            return true;
        }

        private void HabilitarCtrl(bool val)
        {
            dtgIntervActivos.Enabled = val;
            dtgIntervRet.Enabled = val;
            dtgIntervinientes.Enabled = val;
            btnMiniPasarDerecha.Enabled = val;
            btnMiniPasarIzquierda.Enabled = val;
            btnAgregar.Enabled = val;
            btnQuitar.Enabled = val;
            cboMotivos.Enabled = val;
            txtMotCambio.Enabled = val;
            txtFirmasNue.Enabled = val;
            txtDocRef.Enabled = val;
            dtpFechaDoc.Enabled = val;
            txtCorreo.Enabled = val;
            txtNroTelf.Enabled = val;
        }

        private void frmSolCambioTitular_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (p_idCta > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(p_idCta);
            }
        }

    }
}
