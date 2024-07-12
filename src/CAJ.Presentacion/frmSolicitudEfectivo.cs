using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using CAJ.CapaNegocio;
using System.Globalization;


namespace CAJ.Presentacion
{
    public partial class frmSolicitudEfectivo : frmBase
    {
        private const string cTituloMensajes = "Registrar remesa";
        public int nTipoAccion;
        public int idRemesa;
        public decimal nDiferencia;
        public decimal nFaltaRecepcionar;
        public int ActualizarLista;

        private clsRemesa objRemesa;
        public clsRemesa objTmpRemesa = new clsRemesa();
        private clsMontoRemesa objMontoRemesa;
        private clsCNRemesa objCNRemesa = new clsCNRemesa();
        private readonly DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;

        private int idModalidadRemesa
        {
            get
            {
                return int.Parse(cboModalidadRemesa.SelectedValue.ToString());
            }
        }

        public frmSolicitudEfectivo()
        {
            InitializeComponent(); 
        }

        private void frmSolicitudEfectivo_Load(object sender, EventArgs e)
        {
            cargarDatos();
            iniForm();
        }

        private void btnBuscarCuenta_Click(object sender, EventArgs e)
        {
            buscarCuenta();
        }

        private void buscarCuenta()
        {
            frmBusquedaCuentaInst buscarCuentaInst = new frmBusquedaCuentaInst();
            buscarCuentaInst.pidAgencia = 1;
            buscarCuentaInst.ShowDialog();

            if (buscarCuentaInst.pidCuentaInstitucion == 0)
                return;

            txtSaldoContable.Text = buscarCuentaInst.pcSaldoContable;
            txtSaldoDisponible.Text = buscarCuentaInst.pcSaldoDisponible;
            txtNroCuenta1.Text = buscarCuentaInst.pcNumeroCuenta;
            cboEntidad.CargarEntidades(buscarCuentaInst.pidTipoEntidad);
            cboEntidad.SelectedValue = buscarCuentaInst.pidEntidad;
            cboTipoCuentaBco.SelectedValue = buscarCuentaInst.pidTipoCuenta;
            cboMoneda1.SelectedValue = buscarCuentaInst.pidMoneda;
            objTmpRemesa.idCuentaInstitucion = buscarCuentaInst.pidCuentaInstitucion;
                   
        }

        public void cargarDatos()
        {
            txtEstablecimiento.Text = clsVarGlobal.User.cEstablecimiento;
            objTmpRemesa.idEstablecimientoRemesa = clsVarGlobal.User.idEstablecimiento;

            cboEstadoRemesa.ListarEstadoRemesa(0, 0, 0);
        }
        public void cargarModalidadesRemesa(int idTipoRemesa)
        {
            clsCNRemesa objModalidadRemesa = new clsCNRemesa();
            DataTable dtModalidadRemesa = objModalidadRemesa.CNListarModalidadRemesa(idTipoRemesa);
            if (dtModalidadRemesa.Rows.Count > 0)
            {
                cboModalidadRemesa.DataSource = dtModalidadRemesa;
                cboModalidadRemesa.ValueMember = dtModalidadRemesa.Columns[0].ToString();
                cboModalidadRemesa.DisplayMember = dtModalidadRemesa.Columns[1].ToString();
                cboModalidadRemesa.Enabled = true;
            }
            else
            {
                cboModalidadRemesa.DataSource = null;
                cboModalidadRemesa.Items.Clear();
                cboModalidadRemesa.Enabled = false;
            }
        }
        private void iniForm()
        {
            txtFechaHoraRemesa.Enabled = false;
            txtEstablecimiento.Enabled = false;
            txtNomSolicitante.Enabled = false;
            txtDniSolicitante.Enabled = false;
            txtCelSolicitante.Enabled = false;
            txtNomApruebSol.Enabled = false;
            txtDniApruebSol.Enabled = false;
            txtNomPersonHabilitar.Enabled = false;
            txtDniPersonHabilitar.Enabled = false;
            txtNomRemesante.Enabled = false;
            txtDniRemesante.Enabled = false;
            txtEstabHabilitador.Enabled = false;
            cboEntidad.Enabled = false;
            cboTipoCuentaBco.Enabled = false;
            txtNroCuenta1.Enabled = false;
            txtSaldoDisponible.Enabled = false;
            txtSaldoContable.Enabled = false;
            cboMoneda1.Enabled = false;
            dtpFechaHabilitacion.Enabled = false;
            dtpFechaRecepcion.Enabled = false;
            txtEstabRecepcion.Enabled = false;
            pnlEstabRecepcion.Enabled = false;
            txtFechaHoraRemesa.Text = dFechaSis.ToShortDateString().ToString();
            dtpFechaHabilitacion.Value = dFechaSis;
            dtpFechaRecepcion.Value = dFechaSis;
            pnlDatosHabilitador.Visible = false;
            pnlExpaDatosHabilitador.Visible = false;
            pnlDatosApruebaSolicitud.Visible = false;
            pnlExpApruebaSolicitud.Visible = false;
            pnlDatosSolicitante.Enabled = false;
            pnlDatosApruebaSolicitud.Enabled = false;
            pnlDatosHabilitador.Enabled = false;

            if (nTipoAccion == 1)
            {
                cboTipoRemesa.SelectedValue = 1;
                cboEstadoRemesa.SelectedValue = 1;
                cboModalidadRemesa.SelectedValue = 1;
                cboMoneda.SelectedValue = 1;
                cboEstadoRemesa.Enabled = false;

                objTmpRemesa.idTipoRemesa = 1;
                objTmpRemesa.idMoneda = 1;
                objTmpRemesa.idEstadoRemesa = Convert.ToInt32(cboEstadoRemesa.SelectedValue);
                
                funcionTipoRemesa();
            }
            else
            {
                cboTipoRemesa.Enabled = false;
                
                cargarDatosRemesa();

                cboEstadoRemesa.ListarEstadoRemesa(objTmpRemesa.idTipoRemesa, clsVarGlobal.PerfilUsu.idPerfil, objTmpRemesa.idEstadoRemesaRec);
                
                objTmpRemesa.idEstadoRemesa = objTmpRemesa.idEstadoRemesaRec;
                
                cboTipoRemesa.SelectedValue = objTmpRemesa.idTipoRemesa;
                
                funcionTipoRemesa();
                funcionesEstadoRemesa();
                
                cboModalidadRemesa.SelectedValue = objTmpRemesa.idModalidadSolicitud;
                
                funcionesModalidadRemesa();
                if (idRemesa > 0)
                {
                    if (objTmpRemesa.idEstadoRemesa == 3 || objTmpRemesa.idEstadoRemesa == 5)
                    {
                        pnlDatosGenerales.Enabled = false;
                    }

                    btnGrabar.Enabled = false;

                    if (objTmpRemesa.idEstadoRemesa == 2)
                    {
                        pnlDatosHabilitador.Enabled = true;
                    }
                    if (objTmpRemesa.idEstadoRemesa == 4)
                    {
                        if (string.IsNullOrEmpty(txtNroCuenta1.Text))
                        {
                            pnlExpCuentaInst.Visible = false;
                        }
                    }
                }
                
                deshabilitarPaneles();
            }
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cboModalidadRemesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModalidadRemesa.ValueMember == "")
                return;
            if (int.Parse(cboModalidadRemesa.SelectedValue.ToString()) < 0)
                return;
            funcionesModalidadRemesa();
        }

        private void cboTipoRemesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoRemesa.SelectedValue) <= 0)
                return;

            objTmpRemesa.idTipoRemesa = Convert.ToInt32(cboTipoRemesa.SelectedValue);
            
            funcionTipoRemesa();
        }

        private void cboEstadoRemesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEstadoRemesa.ValueMember == "")
                return;
            if (Convert.ToInt32(cboEstadoRemesa.SelectedValue) <= 0 || objTmpRemesa.idTipoRemesa == 0)
                return;
            objTmpRemesa.idEstadoRemesa = Convert.ToInt32(cboEstadoRemesa.SelectedValue);
            funcionesEstadoRemesa();
        }

        public void funcionTipoRemesa()
        {
            pnlDatosGenerales.Visible = true;
            pnlEstabHabilitacion.Visible = false;
            pnlDatosHabilitacion.Visible = false;
            pnlDatosRecepcion.Visible = false;
            pnlEstabRecepcion.Visible = false;
            switch (objTmpRemesa.idTipoRemesa)
            {
                case 1:
                    pnlDatosPersona1.Visible = false;
                    pnlExpCuentaInst.Visible = false;
                    pnlMonto.Visible = false;
                    pnlDescripcion.Visible = false;
                    pnlDatosPersona.Visible = true;
                    pnlModalidad.Visible = true;
                    pnlSustento.Visible = true;
                    pnlDatosGenerales.Enabled = true;
                    pnlModalidad.Enabled = true;
                    pnlSustento.Enabled = true;
                    if (nTipoAccion == 1 && idRemesa == 0)
                    {
                        cboEstadoRemesa.SelectedValue = 1;
                        objTmpRemesa.idEstadoRemesa = 1;

                        DataTable dtDatosPersona = objCNRemesa.CNBuscarDatosPersonal(clsVarGlobal.User.idUsuario);

                        objTmpRemesa.idPersonalSolicitante = clsVarGlobal.User.idUsuario;

                        txtNomSolicitante.Text = dtDatosPersona.Rows[0]["cNombre"].ToString();
                        txtDniSolicitante.Text = dtDatosPersona.Rows[0]["cDNI"].ToString();
                        if (!string.IsNullOrEmpty(dtDatosPersona.Rows[0]["nCelular"].ToString()))
                        {
                            txtCelSolicitante.Text = dtDatosPersona.Rows[0]["nCelular"].ToString();
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(dtDatosPersona.Rows[0]["nCelular1"].ToString()))
                            {
                                txtCelSolicitante.Text = dtDatosPersona.Rows[0]["nCelular1"].ToString();
                            }
                            else
                            {
                                txtCelSolicitante.Text = dtDatosPersona.Rows[0]["nCelular2"].ToString();  
                            }
                        }

                    }
                    cargarModalidadesRemesa(objTmpRemesa.idTipoRemesa);
                    break;
                case 2:
                    pnlDatosPersona.Visible = false;
                    pnlSustento.Visible = false;
                    pnlDatosPersona1.Visible = true;
                    pnlModalidad.Visible = true;
                    pnlExpCuentaInst.Visible = true;
                    pnlMonto.Visible = true;
                    pnlDescripcion.Visible = true;
                    pnlDatosPersona1.Enabled = true;
                    pnlModalidad.Enabled = true;
                    pnlCuentaInst.Enabled = true;
                    pnlMonto.Enabled = true;
                    pnlDescripcion.Enabled = true;
                    if (nTipoAccion == 1 && idRemesa == 0)
                    {
                        cboEstadoRemesa.SelectedValue = 9;
                        objTmpRemesa.idEstadoRemesa = 9;
                        objTmpRemesa.idPersonalRemesante = clsVarGlobal.User.idUsuario;

                        DataTable dtDatosPersona = objCNRemesa.CNBuscarDatosPersonal(clsVarGlobal.User.idUsuario);

                        txtNomRemesante.Text = dtDatosPersona.Rows[0]["cNombre"].ToString();
                        txtDniRemesante.Text = dtDatosPersona.Rows[0]["cDNI"].ToString();
                    }
                    cargarModalidadesRemesa(objTmpRemesa.idTipoRemesa);
                    break;
            }

            funcionesModalidadRemesa();
        }

        public void funcionesEstadoRemesa()
        {
            if (idRemesa == 0)
                return;

            pnlDatosApruebaSolicitud.Visible = false;
            pnlExpApruebaSolicitud.Visible = false;
            pnlDatosHabilitador.Visible = false;
            pnlExpaDatosHabilitador.Visible = false;

            if (objTmpRemesa.idEstadoRemesa <= 0)
            {
                btnGrabar.Enabled = false;
            }
            else
            {
                btnGrabar.Enabled = true;
            }
            if (objTmpRemesa.idTipoRemesa == 1)
            {
                if (objTmpRemesa.idEstadoRemesa > 1)
                {
                    pnlDatosApruebaSolicitud.Visible = true;
                    pnlExpApruebaSolicitud.Visible = true;
                    if (string.IsNullOrEmpty(txtNomApruebSol.Text))
                    {
                        objTmpRemesa.idPersonalApruebaSolicitud = clsVarGlobal.User.idUsuario;

                        DataTable dtDatosPersona = objCNRemesa.CNBuscarDatosPersonal(clsVarGlobal.User.idUsuario);

                        txtNomApruebSol.Text = dtDatosPersona.Rows[0]["cNombre"].ToString();
                        txtDniApruebSol.Text = dtDatosPersona.Rows[0]["cDNI"].ToString();
                    }
                }
                if (((objTmpRemesa.idEstadoRemesaRec == 2 && objTmpRemesa.idEstadoRemesaRec != objTmpRemesa.idEstadoRemesa) || !string.IsNullOrEmpty(txtNomPersonHabilitar.Text)) && objTmpRemesa.idEstadoRemesa > 2)
                {
                    pnlDatosHabilitador.Visible = true;
                    pnlExpaDatosHabilitador.Visible = true;
                    if (string.IsNullOrEmpty(txtNomPersonHabilitar.Text))
                    {
                        objTmpRemesa.idPersonalHabilitar = clsVarGlobal.User.idUsuario;

                        DataTable dtDatosPersona = objCNRemesa.CNBuscarDatosPersonal(clsVarGlobal.User.idUsuario);
                        txtNomPersonHabilitar.Text = dtDatosPersona.Rows[0]["cNombre"].ToString();
                        txtDniPersonHabilitar.Text = dtDatosPersona.Rows[0]["cDNI"].ToString();
                        if (!string.IsNullOrEmpty(dtDatosPersona.Rows[0]["nCelular"].ToString()))
                        {
                            txtCelPersonHabilitar.Text = dtDatosPersona.Rows[0]["nCelular"].ToString();
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(dtDatosPersona.Rows[0]["nCelular1"].ToString()))
                            {
                                txtCelPersonHabilitar.Text = dtDatosPersona.Rows[0]["nCelular1"].ToString();
                            }
                            else
                            {
                                txtCelPersonHabilitar.Text = dtDatosPersona.Rows[0]["nCelular2"].ToString();
                            }
                        }
                    }
                } 
            }
            if (objTmpRemesa.idEstadoRemesa <= 3 || objTmpRemesa.idEstadoRemesa == 9)
            {
                pnlEstabHabilitacion.Visible = false;
                pnlDatosHabilitacion.Visible = false;
                deshabilitarPaneles();
                if (objTmpRemesa.idEstadoRemesaRec == 2)
                {
                    pnlExpCuentaInst.Visible = false;
                    pnlMonto.Visible = false;
                    pnlDescripcion.Visible = false;
                }
                return;
            }
            if (objTmpRemesa.idEstadoRemesa >= 4 )
            {
                deshabilitarPaneles();
                if (objTmpRemesa.idEstadoRemesa == 4)
                {
                    pnlEstabHabilitacion.Visible = true;
                    pnlExpCuentaInst.Visible = true;
                    pnlMonto.Visible = true;
                    pnlDatosHabilitacion.Visible = true;
                    pnlDescripcion.Visible = true;

                    if (!objTmpRemesa.lHabilitacion)
                    {
                        pnlDatosHabilitador.Enabled = true;
                        pnlCuentaInst.Enabled = true;
                        pnlMonto.Enabled = true;
                        pnlDatosHabilitacion.Enabled = true;
                        pnlDescripcion.Enabled = true;
                    }
                    if (objTmpRemesa.idEstablecimientoHabilita == 0)
                    {
                        objTmpRemesa.idEstablecimientoHabilita = clsVarGlobal.User.idEstablecimiento;
                        objTmpRemesa.idAgenciaHabilita = clsVarGlobal.nIdAgencia;
                        txtEstabHabilitador.Text = clsVarGlobal.User.cEstablecimiento;
                        txtMonto1.Text = txtMonto.Text;
                    }
                }
                if (objTmpRemesa.idEstadoRemesa == 5 || objTmpRemesa.idEstadoRemesa == 6 || objTmpRemesa.idEstadoRemesa == 7 || objTmpRemesa.idEstadoRemesa == 8)
                {
                    pnlExpCuentaInst.Visible = true;
                    pnlMonto.Visible = true;
                    pnlDescripcion.Visible = true;
                    pnlDatosRecepcion.Visible = true;
                    pnlEstabRecepcion.Visible = true;
                    pnlDatosRecepcion.Enabled = true;
                    if (objTmpRemesa.idTipoRemesa == 1)
                    {
                        pnlEstabHabilitacion.Visible = true;
                        pnlDatosHabilitacion.Visible = true;
                    }
                    if (objTmpRemesa.idEstadoRemesaRec == 6 || objTmpRemesa.idEstadoRemesaRec == 8)
                    {
                        txtCostoRecepcion.Enabled = false;
                    }
                    if (objTmpRemesa.idEstablecimientoRecepcion == 0)
                    {
                        objTmpRemesa.idEstablecimientoRecepcion = clsVarGlobal.User.idEstablecimiento;
                        objTmpRemesa.idAgenciaRecepcion = clsVarGlobal.nIdAgencia;
                        txtEstabRecepcion.Text = clsVarGlobal.User.cEstablecimiento;
                    }
                }
            }
        }

        public void funcionesModalidadRemesa()
        {
            pnlModalidad1.Visible = false;
            pnlModalidad2.Visible = false;
            pnlModalidad3.Visible = false;
            pnlModalidad4.Visible = false;
            pnlModalidad5.Visible = false;
            if (objTmpRemesa.idTipoRemesa == 1)
            {
                switch (idModalidadRemesa)
                {
                    case 1:
                        pnlModalidad1.Visible = true;
                        break;
                    case 2:
                        pnlModalidad2.Visible = true;
                        break;
                    case 3:
                        pnlModalidad3.Visible = true;
                        break;
                    case 4:
                        pnlModalidad3.Visible = true;
                        break;
                    case 5:
                        pnlModalidad4.Visible = true;
                        break;
                    case 6:
                        pnlModalidad5.Visible = true;
                        break;
                } 
            }
            
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!validarDatos())
            {
                return;
            }

            DialogResult drConfirmacion = MessageBox.Show("¿Está seguro de guardar los datos?", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (drConfirmacion == DialogResult.Yes) 
            {
                guardarDatos();
                deshabilitarPaneles();

                btnGrabar.Enabled = false;
                pnlDatosGenerales.Enabled = false;

                ActualizarLista = 1;
            }
        }
        private void guardarDatos()
        {
            objRemesa = new clsRemesa();
            objMontoRemesa = new clsMontoRemesa();

            if (idRemesa == 0)
            {
                objRemesa.idTipoRemesa = objTmpRemesa.idTipoRemesa;
                objRemesa.idEstadoRemesa = objTmpRemesa.idEstadoRemesa;
                objRemesa.idEstadoRegistro = objTmpRemesa.idEstadoRemesa;
                objRemesa.idAgenciaRemesa = clsVarGlobal.nIdAgencia;
                objRemesa.idEstablecimientoRemesa = objTmpRemesa.idEstablecimientoRemesa;

                switch (objTmpRemesa.idTipoRemesa)
                {
                    case 1:
                        objRemesa.idPersonalSolicitante = objTmpRemesa.idPersonalSolicitante;
                        objRemesa.idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
                        objRemesa.nMontoRemesa = Convert.ToDecimal(txtMonto.Text);
                        objRemesa.idModalidadSolicitud = idModalidadRemesa;

                        switch (objRemesa.idModalidadSolicitud)
                        {
                            case 1:
                                objRemesa.cEntidad = txtEntidad1.Text;
                                objRemesa.cNroCuenta = txtNroCuenta.Text;
                                objRemesa.cCCI = txtCciSolicitud.Text;
                                break;
                            case 2:
                                objRemesa.cDireccion = txtDirOficina.Text;
                                objRemesa.cDniChequeGiro = txtDniChequeGiro.Text;
                                objRemesa.cNombreChequeGiro = txtNomChequeGiro.Text;

                                break;
                            case 3:
                                objRemesa.cEntidad = txtEntidad2.Text;
                                objRemesa.cDniChequeGiro = txtDniChequeGiro1.Text;
                                objRemesa.cNombreChequeGiro = txtNomChequeGiro1.Text;
                                break;
                            case 4:
                                objRemesa.cEntidad = txtEntidad2.Text;
                                objRemesa.cDniChequeGiro = txtDniChequeGiro1.Text;
                                objRemesa.cNombreChequeGiro = txtNomChequeGiro1.Text;
                                break;
                            case 5:
                                objRemesa.cEntidad = txtEntidad3.Text;
                                objRemesa.cCCI = txtCciSolicitud1.Text;
                                break;
                            case 6:
                                objRemesa.cOtro = txtModalidadOtro.Text;
                                break;
                        }

                        objRemesa.cSustento = txtSustentoSolicitud.Text;

                        break;
                    case 2:
                        objRemesa.idPersonalRemesante = objTmpRemesa.idPersonalRemesante;
                        objRemesa.idModalidadSolicitud = idModalidadRemesa;
                        objRemesa.idCuentaInstitucion = objTmpRemesa.idCuentaInstitucion;
                        objRemesa.idMoneda = Convert.ToInt32(cboMoneda1.SelectedValue);
                        objRemesa.cDescripcion = txtDescripcion.Text;
                        objRemesa.nMontoRemesa = Convert.ToDecimal(txtMonto1.Text);

                        break;
                }
            }
            else
            {
                objRemesa.idRemesa = idRemesa;

                if (objTmpRemesa.idEstadoRemesa == 2 || objTmpRemesa.idEstadoRemesa == 3)
                {
                    objRemesa.idEstadoRemesa = objTmpRemesa.idEstadoRemesa;
                    objRemesa.idEstadoRespuesta = objTmpRemesa.idEstadoRemesa;
                    objRemesa.idPersonalApruebaSolicitud = objTmpRemesa.idPersonalApruebaSolicitud;
                    if (objTmpRemesa.idPersonalHabilitar > 0)
                    {
                        objRemesa.idPersonalHabilitar = objTmpRemesa.idPersonalHabilitar;
                    }
                    if(objTmpRemesa.idEstadoRemesaRec == 2)
                    {
                        objRemesa.nCelular = Convert.ToInt32(txtCelPersonHabilitar.Text);
                    }
                }
                if (objTmpRemesa.idEstadoRemesa == 4)
                {
                    objRemesa.idEstadoRemesa = objTmpRemesa.idEstadoRemesa;
                    objRemesa.idEstadoHabilitar = objTmpRemesa.idEstadoRemesa;
                    objRemesa.idCuentaInstitucion = objTmpRemesa.idCuentaInstitucion;
                    objRemesa.lHabilitacion = true;
                    objRemesa.idAgenciaHabilita = objTmpRemesa.idAgenciaHabilita;
                    objRemesa.idEstablecimientoHabilita = objTmpRemesa.idEstablecimientoHabilita;
                    objRemesa.idPersonalHabilitar = objTmpRemesa.idPersonalHabilitar;
                    objRemesa.nCelular = Convert.ToInt32(txtCelPersonHabilitar.Text);
                    objRemesa.cMotivoOperacion = txtMotivoOperacion.Text;
                    objRemesa.nCostoHabilitacion = Convert.ToDecimal(txtCostoHabilitacion.Text);
                    objRemesa.nMontoHabilitacion = Convert.ToDecimal(txtMonto1.Text);
                    objRemesa.cDescripcion = txtDescripcion.Text;
                }
                if (objTmpRemesa.idEstadoRemesa == 5 || objTmpRemesa.idEstadoRemesa == 6 || objTmpRemesa.idEstadoRemesa == 7 || objTmpRemesa.idEstadoRemesa == 8)
                {
                    objRemesa.idEstadoRemesa = objTmpRemesa.idEstadoRemesa;
                    objRemesa.idAgenciaRecepcion = objTmpRemesa.idAgenciaRecepcion;
                    objRemesa.idEstablecimientoRecepcion = objTmpRemesa.idEstablecimientoRecepcion;
                    objRemesa.nCostoRecepcion = Convert.ToDecimal(txtCostoRecepcion.Text);
                    objRemesa.nMontoRecepcion = objTmpRemesa.nMontoRecepcion + Convert.ToDecimal(txtMontoRecepcion.Text);

                    objMontoRemesa.idRemesa = idRemesa;
                    objMontoRemesa.idUsuario = clsVarGlobal.User.idUsuario;
                    objMontoRemesa.nMonto = Convert.ToDecimal(txtMontoRecepcion.Text);
                    objMontoRemesa.idEstadoRemesa = objTmpRemesa.idEstadoRemesa;

                    if (objTmpRemesa.idEstadoRemesa == 6 && objTmpRemesa.nMontoRecepcion > 0)
                    {
                        if (nDiferencia == 0)
                        {
                            objRemesa.idEstadoRemesa = 5;
                            objMontoRemesa.idEstadoRemesa = objRemesa.idEstadoRemesa;
                        }
                    }
                    if (objTmpRemesa.idEstadoRemesa == 8 && objTmpRemesa.nMontoRecepcion > 0)
                    {
                        if (nDiferencia == 0)
                        {
                            objRemesa.idEstadoRemesa = 7;
                            objMontoRemesa.idEstadoRemesa = objRemesa.idEstadoRemesa;
                        }
                    }
                }
            }

            clsDBResp objDbResp = objCNRemesa.InsertarActualizarRemesa(objRemesa, objMontoRemesa, idRemesa);

            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool validarDatos()
        {
            if (objTmpRemesa.idEstadoRemesa == 1 && idRemesa == 0)
            {
                if (objTmpRemesa.idTipoRemesa == 1)
                {
                    if (objTmpRemesa.idMoneda == 0)
                    {
                        MessageBox.Show("Seleccionar tipo de moneda", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtMonto.Text))
                    {
                        MessageBox.Show("Ingresar monto a solicitar", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (decimal.Parse(txtMonto.Text) < 1)
                    {
                        MessageBox.Show("El monto solicitado debe ser mayor a CERO", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (idModalidadRemesa == 0)
                    {
                        MessageBox.Show("Seleccionar modalidad", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    switch (idModalidadRemesa)
                    {
                        case 1:
                            if (string.IsNullOrEmpty(txtEntidad1.Text))
                            {
                                MessageBox.Show("Ingresar nombre de entidad", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            if (string.IsNullOrEmpty(txtNroCuenta.Text))
                            {
                                MessageBox.Show("Ingresar Nro. de cuenta", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            if (txtNroCuenta.Text.Length < 10)
                            {
                                MessageBox.Show("El Nro. de cuenta contiene " + txtNroCuenta.Text.Length + " dígito(s), debe ser mayor a 9", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            if (string.IsNullOrEmpty(txtCciSolicitud.Text))
                            {
                                MessageBox.Show("Ingresar CCI", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            if (txtCciSolicitud.Text.Length < 20 || txtCciSolicitud.Text.Length > 20)
                            {
                                MessageBox.Show("El CCI contiene " + txtCciSolicitud.Text.Length + " dígito(s), debe contener 20 dígitos", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            break;
                        case 2:
                            if (string.IsNullOrEmpty(txtDirOficina.Text))
                            {
                                MessageBox.Show("Ingresar dirección de oficina", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            if (string.IsNullOrEmpty(txtNomChequeGiro.Text))
                            {
                                MessageBox.Show("Ingresar nombre por prosegur", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            if (string.IsNullOrEmpty(txtDniChequeGiro.Text))
                            {
                                MessageBox.Show("Ingresar DNI por prosegur", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            if (txtDniChequeGiro.Text.Length < 8 || txtDniChequeGiro.Text.Length > 8)
                            {
                                MessageBox.Show("DNI por prosegur contiene " + txtDniChequeGiro.Text.Length + " dígitos, debe contener 8 dígitos", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            break;
                        case 3:
                            if (string.IsNullOrEmpty(txtEntidad2.Text))
                            {
                                MessageBox.Show("Ingresar nombre de entidad", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            if (string.IsNullOrEmpty(txtNomChequeGiro1.Text))
                            {
                                MessageBox.Show("Ingresar nombre por cheque de gerencia", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            if (string.IsNullOrEmpty(txtDniChequeGiro1.Text))
                            {
                                MessageBox.Show("Ingresar DNI por cheque de gerencia", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            if (txtDniChequeGiro1.Text.Length < 8 || txtDniChequeGiro1.Text.Length > 8)
                            {
                                MessageBox.Show("DNI por prosegur contiene " + txtDniChequeGiro1.Text.Length + " dígitos, debe contener 8 dígitos", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            break;
                        case 4:
                            if (string.IsNullOrEmpty(txtEntidad2.Text))
                            {
                                MessageBox.Show("Ingresar nombre de entidad", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            if (string.IsNullOrEmpty(txtNomChequeGiro1.Text))
                            {
                                MessageBox.Show("Ingresar nombre por giro", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            if (string.IsNullOrEmpty(txtDniChequeGiro1.Text))
                            {
                                MessageBox.Show("Ingresar DNI por giro", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            if (txtDniChequeGiro1.Text.Length < 8 || txtDniChequeGiro1.Text.Length > 8)
                            {
                                MessageBox.Show("DNI por prosegur contiene " + txtDniChequeGiro1.Text.Length + " dígitos, debe contener 8 dígitos", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            break;
                        case 5:
                            if (string.IsNullOrEmpty(txtEntidad3.Text))
                            {
                                MessageBox.Show("Ingresar nombre de entidad", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            if (string.IsNullOrEmpty(txtCciSolicitud1.Text))
                            {
                                MessageBox.Show("Ingresar CCI", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            if (txtCciSolicitud1.Text.Length < 20 || txtCciSolicitud1.Text.Length > 20)
                            {
                                MessageBox.Show("El CCI contiene " + txtCciSolicitud1.Text.Length + " dígitos, debe contener 20 dígitos", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            break;
                        case 6:
                            if (string.IsNullOrEmpty(txtModalidadOtro.Text))
                            {
                                MessageBox.Show("Ingresar texto en otro", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            break;
                    }
                    if (string.IsNullOrEmpty(txtSustentoSolicitud.Text))
                    {
                        MessageBox.Show("Debe ingresar sustento", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                else 
                {
                    if (objTmpRemesa.idCuentaInstitucion <= 0)
                    {
                        MessageBox.Show("Debe seleccionar cuenta de institucion", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtMonto1.Text))
                    {
                        MessageBox.Show("Ingresar Monto", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (decimal.Parse(txtMonto1.Text) < 1)
                    {
                        MessageBox.Show("Monto debe ser mayor a cero", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (decimal.Parse(txtMonto1.Text) > objTmpRemesa.nMontoRemesa)
                    {
                        MessageBox.Show("Monto debe ser menor o igual a monto solicitado", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtDescripcion.Text))
                    {
                        MessageBox.Show("Ingrese descripción", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                
            }
            else
            {
                if (objTmpRemesa.idEstadoRemesa == 3 && objTmpRemesa.idEstadoRemesaRec == 2)
                {
                    if (!string.IsNullOrEmpty(txtCelPersonHabilitar.Text))
                    {
                        if (txtCelPersonHabilitar.Text.Length < 9 || txtCelPersonHabilitar.Text.Length > 9)
                        {
                            MessageBox.Show("El número de celular contiene " + txtCelPersonHabilitar.Text.Length + " dígitos, debe contener 9 dígitos", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                    }
                }
                if (objTmpRemesa.idEstadoRemesa == 9)
                {
                    if (objTmpRemesa.idPersonalRemesante <= 0)
                    {
                        MessageBox.Show("Seleccionar personal remesante", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (idModalidadRemesa <= 0)
                    {
                        MessageBox.Show("Seleccionar modalidad", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (objTmpRemesa.idCuentaInstitucion <= 0)
                    {
                        MessageBox.Show("Seleccionar cuenta", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtMonto1.Text))
                    {
                        MessageBox.Show("Ingresar monto", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (decimal.Parse(txtMonto1.Text) < 1)
                    {
                        MessageBox.Show("Monto debe ser mayor a cero", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtDescripcion.Text))
                    {
                        MessageBox.Show("Ingrese descripcion", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                else
                {
                    if (objTmpRemesa.idEstadoRemesa == 4)
                    {
                        if (Convert.ToInt32(txtCelPersonHabilitar.Text) != 0)
                        {
                            if (txtCelPersonHabilitar.Text.Length < 9 || txtCelPersonHabilitar.Text.Length > 9)
                            {
                                MessageBox.Show("El número de celular contiene " + txtCelPersonHabilitar.Text.Length + " dígitos, debe contener 9 dígitos", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                        }
                        if (objTmpRemesa.idModalidadSolicitud != 6 || objTmpRemesa.idCuentaInstitucion > 0)
                        {
                            if (objTmpRemesa.idCuentaInstitucion <= 0)
                            {
                                MessageBox.Show("Seleccionar cuenta", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            if (Convert.ToDecimal(txtSaldoDisponible.Text) <= decimal.Parse(txtMonto1.Text))
                            {
                                MessageBox.Show("No cuenta con saldo suficiente el Nro. de cuenta", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                            if (Convert.ToInt32(cboMoneda1.SelectedValue) != objTmpRemesa.idMoneda)
                            {
                                MessageBox.Show("El tipo de moneda es diferente", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                        }
                        if (string.IsNullOrEmpty(txtMonto1.Text))
                        {
                            MessageBox.Show("Ingresar monto", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        if (decimal.Parse(txtMonto1.Text) < 1)
                        {
                            MessageBox.Show("Monto debe ser mayor a cero", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        if (decimal.Parse(txtMonto1.Text) > decimal.Parse(txtMonto.Text))
                        {
                            MessageBox.Show("Monto de habilitación debe ser menor o igual a monto", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        } 
                        if (string.IsNullOrEmpty(txtCostoHabilitacion.Text))
                        {
                            MessageBox.Show("Ingrese costo habilitación", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        if (string.IsNullOrEmpty(txtMotivoOperacion.Text))
                        {
                            MessageBox.Show("Ingrese motivo de operación", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        if (string.IsNullOrEmpty(txtDescripcion.Text))
                        {
                            MessageBox.Show("Ingrese descripción", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                    }
                    if (objTmpRemesa.idEstadoRemesa == 5 || objTmpRemesa.idEstadoRemesa == 6 || objTmpRemesa.idEstadoRemesa == 7 || objTmpRemesa.idEstadoRemesa == 8)
                    {
                        if (string.IsNullOrEmpty(txtMontoRecepcion.Text))
                        {
                            MessageBox.Show("Ingresar Monto de recepcion", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        } 
                        if (decimal.Parse(txtMontoRecepcion.Text) < 1)
                        {
                            MessageBox.Show("Monto recepción debe ser mayor a cero", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        if (string.IsNullOrEmpty(txtCostoRecepcion.Text))
                        {
                            MessageBox.Show("Ingresar costo de recepcion", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        if (decimal.Parse(txtCostoRecepcion.Text) < 0)
                        {
                            MessageBox.Show("Costo de recepción debe ser mayor a cero", "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        nFaltaRecepcionar = objTmpRemesa.nMontoEnviado - objTmpRemesa.nMontoRecepcion;
                        nDiferencia = nFaltaRecepcionar - Convert.ToDecimal(txtMontoRecepcion.Text);

                        if ((objTmpRemesa.idEstadoRemesa == 6 || objTmpRemesa.idEstadoRemesa == 8) && nDiferencia < 0)
                        {
                            MessageBox.Show("Monto recepción máximo " + nFaltaRecepcionar, "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                        if ((objTmpRemesa.idEstadoRemesa == 5 || objTmpRemesa.idEstadoRemesa == 7) && nDiferencia != 0)
                        {
                            MessageBox.Show("Monto recepción debe ser igual a " + nFaltaRecepcionar, "Validación de solicitud de efectivo / remesa salida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                    }
                }
                
            }
            return true;
        }
        public void deshabilitarPaneles()
        {
            pnlDatosGenerales.Enabled = true;
            pnlMonedaMonto.Enabled = false;
            pnlDatosPersona1.Enabled = false;
            pnlModalidad.Enabled = false;
            pnlModalidad1.Enabled = false;
            pnlModalidad2.Enabled = false;
            pnlModalidad3.Enabled = false;
            pnlModalidad4.Enabled = false;
            pnlModalidad5.Enabled = false;
            fpnl1.Enabled = false;
            pnlSustento.Enabled = false;
            pnlEstabHabilitacion.Enabled = false;
            pnlCuentaInst.Enabled = false;
            pnlMonto.Enabled = false;
            pnlDatosHabilitacion.Enabled = false;
            pnlDatosHabilitador.Enabled = false;
            pnlDescripcion.Enabled = false;
            pnlDatosRecepcion.Enabled = false;
        
        }
        public void habilitarPaneles()
        {
            pnlDatosGenerales.Enabled = true;
            pnlDatosPersona1.Enabled = true;
            pnlModalidad.Enabled = true;
            fpnl1.Enabled = true;
            pnlSustento.Enabled = true;
            pnlEstabHabilitacion.Enabled = false;
            pnlCuentaInst.Enabled = true;
            pnlMonto.Enabled = true;
            pnlDatosHabilitacion.Enabled = true;
            pnlDescripcion.Enabled = true;
            pnlDatosRecepcion.Enabled = true;
            pnlEstabRecepcion.Enabled = false;
        }
        private void cargarDatosRemesa()
        {
            DataTable dtbTmpRemesa = objCNRemesa.CNBuscarRemesa(idRemesa);

            objTmpRemesa.idAgenciaRemesa= int.Parse(dtbTmpRemesa.Rows[0]["idAgenciaRemesa"].ToString());
            objTmpRemesa.idEstablecimientoRemesa = int.Parse(dtbTmpRemesa.Rows[0]["idEstablecimientoRemesa"].ToString());

            txtEstablecimiento.Text = dtbTmpRemesa.Rows[0]["cEstablecimientoRemesa"].ToString();

            lblEstadoRemesa.Text = dtbTmpRemesa.Rows[0]["cTipoRemesa"].ToString();
            txtFechaHoraRemesa.Text = dtbTmpRemesa.Rows[0]["dFechaHoraRegistro"].ToString();

            objTmpRemesa.idTipoRemesa = int.Parse(dtbTmpRemesa.Rows[0]["idTipoRemesa"].ToString());
            objTmpRemesa.idEstadoRemesa = int.Parse(dtbTmpRemesa.Rows[0]["idEstadoRemesa"].ToString());
            objTmpRemesa.idEstadoRemesaRec = objTmpRemesa.idEstadoRemesa;
            objTmpRemesa.idModalidadSolicitud = int.Parse(dtbTmpRemesa.Rows[0]["idModalidadSolicitud"].ToString());
            
            if (objTmpRemesa.idTipoRemesa == 1)
            {
                txtNomSolicitante.Text = dtbTmpRemesa.Rows[0]["cNomPersonaSolicitante"].ToString();
                txtDniSolicitante.Text = dtbTmpRemesa.Rows[0]["cDniPersonaSolicitante"].ToString();
                txtCelSolicitante.Text = dtbTmpRemesa.Rows[0]["nCelular"].ToString();
                txtNomApruebSol.Text = dtbTmpRemesa.Rows[0]["cNomAprobSolicitud"].ToString();
                txtDniApruebSol.Text = dtbTmpRemesa.Rows[0]["cDniAproSolicitud"].ToString();
                txtCelSolicitante.Text = dtbTmpRemesa.Rows[0]["nNumeroTelefono"].ToString();
                txtNomPersonHabilitar.Text = dtbTmpRemesa.Rows[0]["cNomPersonHabilitar"].ToString();
                txtDniPersonHabilitar.Text = dtbTmpRemesa.Rows[0]["cDniPersonHabilitar"].ToString();
                txtCelPersonHabilitar.Text = dtbTmpRemesa.Rows[0]["nCelular"].ToString();
                cboMoneda.SelectedValue = int.Parse(dtbTmpRemesa.Rows[0]["idMoneda"].ToString());
                txtMonto.Text = dtbTmpRemesa.Rows[0]["nMontoRemesa"].ToString();
                txtSustentoSolicitud.Text = dtbTmpRemesa.Rows[0]["cSustento"].ToString();

                objTmpRemesa.idMoneda = int.Parse(dtbTmpRemesa.Rows[0]["idMoneda"].ToString());
                objTmpRemesa.nMontoRemesa = decimal.Parse(dtbTmpRemesa.Rows[0]["nMontoRemesa"].ToString());

                switch (objTmpRemesa.idModalidadSolicitud)
                { 
                    case 1:
                        txtEntidad1.Text = dtbTmpRemesa.Rows[0]["cEntidad"].ToString();
                        txtNroCuenta.Text = dtbTmpRemesa.Rows[0]["cNroCuenta"].ToString();
                        txtCciSolicitud.Text = dtbTmpRemesa.Rows[0]["cCCI"].ToString();
                        break;
                    case 2:
                        txtDirOficina.Text = dtbTmpRemesa.Rows[0]["cDireccion"].ToString();
                        txtDniChequeGiro.Text = dtbTmpRemesa.Rows[0]["cDniChequeGiro"].ToString();
                        txtNomChequeGiro.Text = dtbTmpRemesa.Rows[0]["cNombreChequeGiro"].ToString();
                        break;
                    case 3:
                        txtEntidad2.Text = dtbTmpRemesa.Rows[0]["cEntidad"].ToString();
                        txtDniChequeGiro1.Text = dtbTmpRemesa.Rows[0]["cDniChequeGiro"].ToString();
                        txtNomChequeGiro1.Text = dtbTmpRemesa.Rows[0]["cNombreChequeGiro"].ToString();
                        break;
                    case 4:
                        txtEntidad2.Text = dtbTmpRemesa.Rows[0]["cEntidad"].ToString();
                        txtDniChequeGiro1.Text = dtbTmpRemesa.Rows[0]["cDniChequeGiro"].ToString();
                        txtNomChequeGiro1.Text = dtbTmpRemesa.Rows[0]["cNombreChequeGiro"].ToString();
                        break;
                    case 5:
                        txtEntidad3.Text = dtbTmpRemesa.Rows[0]["cEntidad"].ToString();
                        txtCciSolicitud1.Text = dtbTmpRemesa.Rows[0]["cCCI"].ToString();
                        break;
                    case 6:
                        txtModalidadOtro.Text = dtbTmpRemesa.Rows[0]["cOtro"].ToString();
                        break;
                }
                if (objTmpRemesa.idEstadoRemesa >= 4)
                {
                    objTmpRemesa.idAgenciaHabilita = int.Parse(dtbTmpRemesa.Rows[0]["idAgenciaHabilita"].ToString());
                    objTmpRemesa.idEstablecimientoHabilita = int.Parse(dtbTmpRemesa.Rows[0]["idEstablecimientoHabilita"].ToString());

                    if (int.Parse(dtbTmpRemesa.Rows[0]["idCuentaInstitucion"].ToString()) != 0)
                    {
                        cboEntidad.CargarEntidades(int.Parse(dtbTmpRemesa.Rows[0]["idTipoEntidad"].ToString()));

                        cboEntidad.SelectedValue = int.Parse(dtbTmpRemesa.Rows[0]["idEntidad1"].ToString());
                        txtSaldoDisponible.Text = dtbTmpRemesa.Rows[0]["nSaldoDisponible"].ToString();
                        txtNroCuenta1.Text = dtbTmpRemesa.Rows[0]["cNumeroCuenta"].ToString();
                        txtSaldoContable.Text = dtbTmpRemesa.Rows[0]["nSaldoContable"].ToString();
                        cboTipoCuentaBco.SelectedValue = int.Parse(dtbTmpRemesa.Rows[0]["idTipoCuentaInst"].ToString());
                    }

                    cboMoneda1.SelectedValue = int.Parse(dtbTmpRemesa.Rows[0]["idMoneda"].ToString());

                    txtMonto1.Text = dtbTmpRemesa.Rows[0]["nMontoEnvio"].ToString();
                    txtCostoHabilitacion.Text = dtbTmpRemesa.Rows[0]["nCostoHabilitacion"].ToString();
                    dtpFechaHabilitacion.Value = DateTime.Parse(dtbTmpRemesa.Rows[0]["dFechaHabilitacion"].ToString());
                    txtMotivoOperacion.Text = dtbTmpRemesa.Rows[0]["cMotivoOperacion"].ToString();
                    txtDescripcion.Text = dtbTmpRemesa.Rows[0]["cDescripcion"].ToString();
                    txtEstabHabilitador.Text = dtbTmpRemesa.Rows[0]["cEstablecimientoHabilita"].ToString();

                    objTmpRemesa.lHabilitacion = Convert.ToBoolean(dtbTmpRemesa.Rows[0]["lHabilitacion"].ToString());
                    objTmpRemesa.nMontoEnviado = Convert.ToDecimal(dtbTmpRemesa.Rows[0]["nMontoEnvio"].ToString());
                }
            }
            if (objTmpRemesa.idTipoRemesa == 2)
            {
                txtNomRemesante.Text = dtbTmpRemesa.Rows[0]["cNomRemesante"].ToString();
                txtDniRemesante.Text = dtbTmpRemesa.Rows[0]["cDniRemesante"].ToString();
                cboEntidad.CargarEntidades(int.Parse(dtbTmpRemesa.Rows[0]["idTipoEntidad"].ToString()));
                cboEntidad.SelectedValue = int.Parse(dtbTmpRemesa.Rows[0]["idEntidad"].ToString());
                txtSaldoDisponible.Text = dtbTmpRemesa.Rows[0]["nSaldoDisponible"].ToString();
                txtNroCuenta1.Text = dtbTmpRemesa.Rows[0]["cNumeroCuenta"].ToString();
                txtSaldoContable.Text = dtbTmpRemesa.Rows[0]["nSaldoContable"].ToString();
                cboTipoCuentaBco.SelectedValue = int.Parse(dtbTmpRemesa.Rows[0]["idTipoCuentaInst"].ToString());
                cboMoneda1.SelectedValue = int.Parse(dtbTmpRemesa.Rows[0]["idMoneda"].ToString());
                txtMonto1.Text = dtbTmpRemesa.Rows[0]["nMontoRemesa"].ToString();
                txtDescripcion.Text = dtbTmpRemesa.Rows[0]["cDescripcion"].ToString();

                objTmpRemesa.nMontoEnviado = Convert.ToDecimal(dtbTmpRemesa.Rows[0]["nMontoRemesa"].ToString());
            }
            if (objTmpRemesa.idEstadoRemesa == 5 || objTmpRemesa.idEstadoRemesa == 7)
            {
                asignarEstabRecep(int.Parse(dtbTmpRemesa.Rows[0]["idAgenciaRecepcion"].ToString()), int.Parse(dtbTmpRemesa.Rows[0]["idEstablecimientoRecepcion"].ToString()), dtbTmpRemesa.Rows[0]["cEstablecimientoRecepcion"].ToString());

                objTmpRemesa.nMontoRecepcion = decimal.Parse(dtbTmpRemesa.Rows[0]["nMontoRecepcion"].ToString());

                txtMontoRecepcion.Text = objTmpRemesa.nMontoRecepcion.ToString();
                txtCostoRecepcion.Text = dtbTmpRemesa.Rows[0]["nCostoRecepcion"].ToString();
                txtTotalRecepcion.Text = objTmpRemesa.nMontoRecepcion.ToString();

                dtpFechaRecepcion.Value = DateTime.Parse(dtbTmpRemesa.Rows[0]["dFechaRecepcion"].ToString());
            }
            if (objTmpRemesa.idEstadoRemesa == 6 || objTmpRemesa.idEstadoRemesa == 8)
            {
                asignarEstabRecep(int.Parse(dtbTmpRemesa.Rows[0]["idAgenciaRecepcion"].ToString()), int.Parse(dtbTmpRemesa.Rows[0]["idEstablecimientoRecepcion"].ToString()), dtbTmpRemesa.Rows[0]["cEstablecimientoRecepcion"].ToString());

                txtCostoRecepcion.Text = dtbTmpRemesa.Rows[0]["nCostoRecepcion"].ToString();
                txtTotalRecepcion.Text = dtbTmpRemesa.Rows[0]["nMontoRecepcion"].ToString();

                objTmpRemesa.nMontoRecepcion = Convert.ToDecimal(dtbTmpRemesa.Rows[0]["nMontoRecepcion"].ToString());
            }
        }

        public void asignarEstabRecep(int idAgencia, int idEstablecimiento, string cEstablecimiento)
        {
            objTmpRemesa.idAgenciaRecepcion = idAgencia;
            objTmpRemesa.idEstablecimientoRecepcion = idEstablecimiento;

            txtEstabRecepcion.Text = cEstablecimiento;
        }

        private void txtCelPersonHabilitar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }

        private void txtCciSolicitud_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }

        private void txtCciSolicitud1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }

        private void txtNroCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
