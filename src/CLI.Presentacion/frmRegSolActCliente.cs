#region Referencias
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CLI.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
#endregion
namespace CLI.Presentacion
{
    public partial class frmRegSolActCliente : frmBase
    {
        #region Variable Globales
        private clsCNSolActCliente objSolActCliente= new clsCNSolActCliente();
        private clsCNRetDatosCliente RetTipCli = new clsCNRetDatosCliente();
        private clsCNCliente Cliente = new clsCNCliente();
        private clslisTipoVinculo tbVinculo;
        private DataTable tbClienteVinculado;
        private DataTable tbClienteVinculadoAct;
        private DataTable dtTipoActCliente;
        private DataTable dtDatosTipoCli;
        private DataTable dtCliente;
        private DateTime pdFecSistem = clsVarGlobal.dFecSystem;
        private string cRutaArchivo = string.Empty;
        private string cIdTipoActCliente = "";
        private int nFilaVinc;
        #endregion

        #region Metodos
        public frmRegSolActCliente()
        {
            InitializeComponent();
            this.Iniciar();
        }
        public frmRegSolActCliente(int idCli)
        {
            InitializeComponent();
            this.Iniciar();
            this.conBusCliente.CargardatosCli(idCli);
            this.BuscarCliente();
        }
        private void Iniciar()
        {
            this.tbcCliente.Enabled = false;
            this.btnEnviarSolicitud.Enabled = false;
            this.btnCargarSustento.Enabled = false;
            this.tbcCliente.SizeMode = TabSizeMode.Fixed;
            this.tbcCliente.ItemSize = new System.Drawing.Size(0, 1);
            this.dtTipoActCliente = this.objSolActCliente.CNListarTipoActualizacion();
            this.CargarTipoActualizacionCliente(0);
            clsCNTipVinculo ListaVin = new clsCNTipVinculo();
            tbVinculo = ListaVin.ListarTipVinculo();
            this.cboEstadoCivil.SelectedIndexChanged -= cboEstadoCivil_SelectedIndexChanged;
            this.cboEstadoCivil.CargarEstadoCivil(0);
            this.cboEstadoCivil.SelectedIndexChanged += cboEstadoCivil_SelectedIndexChanged;
            this.cboEstadoCivilAct.CargarEstadoCivil(0);
            this.cboEstadoCliNat.ListaEstadoCli(1);
            this.BuscarSolicitudes(0, 0, clsVarGlobal.User.idUsuario, 0);
        }
        private void BuscarSolicitudes(int idZona, int idAgencia, int idUsuarioSol, int idUsuarioApro)
        {
            this.dtgSolicitudes.DataSource = null;
            clsCNSolActCliente objSolicitudes = new clsCNSolActCliente();
            this.dtgSolicitudes.DataSource = objSolicitudes.CNBuscarSolicitudes(idZona, idAgencia, idUsuarioSol, idUsuarioApro, 0);

            dtgSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dtgSolicitudes.Columns["idSolicitud"].Visible = false;
            dtgSolicitudes.Columns["idGrupo"].HeaderText = "N° Solicitud";
            dtgSolicitudes.Columns["idGrupo"].Width = 70;
            dtgSolicitudes.Columns["idEstado"].Visible = false;
            dtgSolicitudes.Columns["cEstado"].HeaderText = "Estado";
            dtgSolicitudes.Columns["cEstado"].Width = 75;
            dtgSolicitudes.Columns["cNombreAge"].HeaderText = "Oficina";
            dtgSolicitudes.Columns["cNombreAge"].Width = 130;
            dtgSolicitudes.Columns["dFechaOpe"].HeaderText = "Fcha. Op.";
            dtgSolicitudes.Columns["dFechaOpe"].Width = 80;
            dtgSolicitudes.Columns["dFechaRegistro"].HeaderText = "Fecha y Hora";
            dtgSolicitudes.Columns["dFechaRegistro"].Width = 100;
            dtgSolicitudes.Columns["cNombre"].HeaderText = "Nombre Cliente";
            dtgSolicitudes.Columns["cNombre"].Width = 200;
            dtgSolicitudes.Columns["cNombreSol"].HeaderText = "Nombre Solicitante";
            dtgSolicitudes.Columns["cNombreSol"].Visible = false;
            dtgSolicitudes.Columns["cTipoActualizacion"].HeaderText = "Tipo de Actualización";
            dtgSolicitudes.Columns["cTipoActualizacion"].Width = 260;
            dtgSolicitudes.Columns["cSustentoApro"].HeaderText = "Comentario del Aprobador";
            dtgSolicitudes.Columns["cSustentoApro"].Width = 300;
            dtgSolicitudes.Columns["idCli"].Visible = false;
            dtgSolicitudes.Columns["idPerfil"].Visible = false;
            dtgSolicitudes.Columns["cPerfil"].Visible = false;
        }
        private void CargarTipoActualizacionCliente(int idTipoPersona)
        {
            this.cboTipoActCliente.SelectedIndexChanged -= cboTipoActCliente_SelectedIndexChanged;
            this.cboTipoActCliente.DataSource = null;
            if (idTipoPersona == 1)
            {
                var filasFiltradas = dtTipoActCliente.AsEnumerable().Where(row => ((int)row["idTipoPersona"] == 1));
                this.cboTipoActCliente.DataSource = filasFiltradas.Any() ? filasFiltradas.CopyToDataTable() : dtTipoActCliente.Clone();
                this.cboTipoActCliente.ValueMember = dtTipoActCliente.Columns[0].ToString();
                this.cboTipoActCliente.DisplayMember = dtTipoActCliente.Columns[1].ToString();
            }
            else if (idTipoPersona == 2 || idTipoPersona == 3)
            {
                var filasFiltradas = dtTipoActCliente.AsEnumerable().Where(row => ((int)row["idTipoPersona"] == 2) || ((int)row["idTipoPersona"] == 3)); ;
                this.cboTipoActCliente.DataSource = filasFiltradas.Any() ? filasFiltradas.CopyToDataTable() : dtTipoActCliente.Clone();
                this.cboTipoActCliente.ValueMember = dtTipoActCliente.Columns[0].ToString();
                this.cboTipoActCliente.DisplayMember = dtTipoActCliente.Columns[1].ToString();
            }
            else
            {
                this.cboTipoActCliente.DataSource = dtTipoActCliente;
                this.cboTipoActCliente.ValueMember = dtTipoActCliente.Columns[0].ToString();
                this.cboTipoActCliente.DisplayMember = dtTipoActCliente.Columns[1].ToString();
            }
            this.cboTipoActCliente.SelectedIndexChanged += cboTipoActCliente_SelectedIndexChanged;
            this.cboTipoActCliente.SelectedIndex = -1;
            this.cboTipoActCliente_SelectedIndexChanged(null, null);
        }
        private void formatoGridVin()
        {
            dtgVinculo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dtgVinculo.Columns["idCli"].Visible = false;
            dtgVinculo.Columns["idCliVin"].Visible = false;
            dtgVinculo.Columns["idTipoVinculo"].Visible = false;
            dtgVinculo.Columns["Estado"].Visible = false;
            dtgVinculo.Columns["nPorCapSocVot"].Visible = false;
            dtgVinculo.Columns["dFechaFinal"].Visible = false;

            dtgVinculo.Columns["cNombre"].Width = 300;
            dtgVinculo.Columns["cTipoVinculo"].Width = 120;
            dtgVinculo.Columns["dFechaInicio"].Width = 90;
            dtgVinculo.Columns["dFechaFinal"].Width = 90;
            dtgVinculo.Columns["cDocumentoID"].Width = 100;

            dtgVinculo.Columns["cDocumentoID"].HeaderText = "N° Documento";
            dtgVinculo.Columns["cNombre"].HeaderText = "Nombre Cliente";
            dtgVinculo.Columns["cTipoVinculo"].HeaderText = "Vinculo";
            dtgVinculo.Columns["dFechaInicio"].HeaderText = "Fec. Ini";
            dtgVinculo.Columns["dFechaFinal"].HeaderText = "Fec. Fin";
        }
        private void BuscarCliente()
        {
            if (conBusCliente.txtCodCli.Text.Trim() == "")
            {
                this.conBusCliente.limpiarControles();
                return;
            }
            this.CargarTipoActualizacionCliente(conBusCliente.nidTipoPersona);
            int idCli = Convert.ToInt32(conBusCliente.txtCodCli.Text);
            dtDatosTipoCli = RetTipCli.ListarDatosCli(idCli, "O");

            this.cboEstadoCliNatAct.ListaEstadoCli(Convert.ToInt32((dtDatosTipoCli.Rows[0]["idTipoPersona"])));

            if (dtDatosTipoCli.Rows[0]["idTipoPersona"].ToString() == "1")
            {
                dtCliente = RetTipCli.ListarDatosCli(idCli, "N");

                // Tab 1
                this.txtApePatAct.Text = this.txtApePat.Text = dtCliente.Rows[0]["cApellidoPaterno"].ToString();
                this.txtApeMatAct.Text = this.txtApeMat.Text = dtCliente.Rows[0]["cApellidoMaterno"].ToString();
                this.txtApeCasadoAct.Text = this.txtApeCasado.Text = dtCliente.Rows[0]["cApellidoCasado"].ToString();
                this.txtNom1Act.Text = this.txtNom1.Text = dtCliente.Rows[0]["cNombre"].ToString();
                this.txtNom2Act.Text = this.txtNom2.Text = dtCliente.Rows[0]["CNombreSeg"].ToString();
                this.txtNom3Act.Text = this.txtNom3.Text = dtCliente.Rows[0]["cNombreOtros"].ToString();
                // Tab 2
                this.dtFecNacAct.Value = this.dtFecNac.Value = (String.IsNullOrEmpty(dtCliente.Rows[0]["dFechaNacimiento"].ToString())) ? clsVarGlobal.dFecSystem : Convert.ToDateTime(dtCliente.Rows[0]["dFechaNacimiento"].ToString());
                // Tab 3
                this.cboEstadoCivilAct.SelectedValue = this.cboEstadoCivil.SelectedValue = (String.IsNullOrEmpty(dtCliente.Rows[0]["idEstadoCivil"].ToString())) ? 0 : Convert.ToInt32(dtCliente.Rows[0]["idEstadoCivil"].ToString());
                this.cboEstadoCivil.CargarEstadoCivil(0);
                if (Convert.ToInt32(cboEstadoCivilAct.SelectedValue).In(1, 3, 4))
                {
                    DataTable dtTmp = (DataTable)this.cboEstadoCivil.DataSource;
                    dtTmp.Rows.Remove(dtTmp.Select("idEstadoCivil = 2").FirstOrDefault());
                    dtTmp.Rows.Remove(dtTmp.Select("idEstadoCivil = 5").FirstOrDefault());
                    this.cboEstadoCivil.DataSource = dtTmp;
                }
                this.cboEstadoCivil.SelectedValue = this.cboEstadoCivilAct.SelectedValue;
                // Tab 4
                this.CargarVinculados(idCli);
                // Tab 5
                this.cboSexo.SelectedValue = this.cboSexoAct.SelectedValue = (String.IsNullOrEmpty(dtCliente.Rows[0]["idSexo"].ToString())) ? 0 : Convert.ToInt32(dtCliente.Rows[0]["idSexo"].ToString());
                // Tab 6
                this.cboEstadoCliNat.ListaEstadoCli(1);
                this.cboEstadoCliNatAct.ListaEstadoCli(1);
                this.cboEstadoCliNatAct.SelectedValue = this.cboEstadoCliNat.SelectedValue = (String.IsNullOrEmpty(dtCliente.Rows[0]["idEstadoCli"].ToString())) ? 0 : Convert.ToInt32(dtCliente.Rows[0]["idEstadoCli"].ToString());
                // Tab 7
                if (Convert.ToInt32(dtCliente.Rows[0]["idNacionalidad"]) == 0)
                {
                    this.cboTipDocumento.CargarDocumentos("N");
                }
                else if (Convert.ToInt32(dtCliente.Rows[0]["idNacionalidad"]) == 1)
                {
                    this.cboTipDocumento.CargarDocumentos("Z");
                }
                this.cboTipDocumentoAct.CargarDocumentos("T");
                this.cboTipDocumentoAct.SelectedValue = this.cboTipDocumento.SelectedValue = (String.IsNullOrEmpty(dtCliente.Rows[0]["idTipoDocumento"].ToString())) ? 0 : Convert.ToInt32(dtCliente.Rows[0]["idTipoDocumento"].ToString());
                // Tab 8
                this.txtCBDocAct.Text = this.txtCBDoc.Text = dtCliente.Rows[0]["cDocumentoID"].ToString();
                this.txtCBDigVerificadorAct.Text = this.txtCBDigVerificador.Text = dtCliente.Rows[0]["cDigitoVerificador"].ToString();
            }
            else if (Convert.ToInt32(dtDatosTipoCli.Rows[0]["idTipoPersona"]) == 2 || Convert.ToInt32(dtDatosTipoCli.Rows[0]["idTipoPersona"]) == 3)
            {
                dtCliente = RetTipCli.ListarDatosCli(idCli, "J");

                // Tab 4
                this.CargarVinculados(idCli);
                // Tab 6
                this.cboSexo.SelectedValue = this.cboSexoAct.SelectedValue = -1;
                this.cboEstadoCliNat.ListaEstadoCli(Convert.ToInt32(dtDatosTipoCli.Rows[0]["idTipoPersona"]));
                this.cboEstadoCliNatAct.ListaEstadoCli(Convert.ToInt32(dtDatosTipoCli.Rows[0]["idTipoPersona"]));
                this.cboEstadoCliNatAct.SelectedValue = this.cboEstadoCliNatAct.SelectedValue = (String.IsNullOrEmpty(dtCliente.Rows[0]["idEstadoCli"].ToString())) ? 0 : Convert.ToInt32(dtCliente.Rows[0]["idEstadoCli"].ToString());
            }
            this.txtArchivo.Text = string.Empty;
            this.txtSustento.Text = string.Empty;
            this.cRutaArchivo = string.Empty;
            this.tbcCliente.Enabled = true;
            this.btnEnviarSolicitud.Enabled = true;
            this.btnCargarSustento.Enabled = true;
            this.btnNuevo1.Enabled = false;
        }
        private string ListarCambios()
        {
            DataTable dtTmp = (DataTable)this.cboTipoActCliente.DataSource;
            var nListaIds = this.cIdTipoActCliente.Split(',').Select(x => int.Parse(x)).ToList();
            var aTipoActualizacion = new List<string>();
            string cResp = "\n";
            foreach (DataRow row in dtTmp.Rows)
            {
                if (nListaIds.Contains(Convert.ToInt32(row["idTipoActCliente"])))
                {
                    cResp = cResp + "\n-" + row["cTipoActualizacion"].ToString();
                }
            }
            return cResp;
        }
        static bool SonIguales(DataTable dt1, DataTable dt2)
        {
            if (dt1.Rows.Count != dt2.Rows.Count || dt1.Columns.Count != dt2.Columns.Count)
            {
                return false;
            }
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                for (int j = 0; j < dt1.Columns.Count; j++)
                {
                    if (!dt1.Rows[i][j].Equals(dt2.Rows[i][j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int CalcularDigitoVerificador(string cDNI)
        {
            const string cNumeroEstablecido = "89456789";
            const string cSecuenciaCaracteres = "FGHIJKABCDE";
            string cNumeroDNI = cDNI;
            int nSumaTotal = 0, nProductoDigito = 0, nValorCaracter = 0, nPosicionCaracter = -1;
            char cCaracterCalculado;

            for (int i = 0; i < cNumeroEstablecido.Length; i++)
            {
                nProductoDigito = Convert.ToInt32(cNumeroDNI.Substring(i, 1)) * Convert.ToInt32(cNumeroEstablecido.Substring(i, 1));
                nSumaTotal += nProductoDigito;
            }

            nValorCaracter = (nSumaTotal % 11 == 0) ? 11 : nSumaTotal % 11;
            cCaracterCalculado = Convert.ToChar(Convert.ToInt32('A') + nValorCaracter - 1);
            nPosicionCaracter = cSecuenciaCaracteres.IndexOf(cCaracterCalculado) + 1;

            return nPosicionCaracter % 10;
        }
        private bool Validar()
        {
            int nCantidadCambios = 0;
            this.cIdTipoActCliente = "";
            if (conBusCliente.nidTipoPersona == 1)
            {
                if (this.txtApePat.Text != this.txtApePatAct.Text || this.txtApeMat.Text != this.txtApeMatAct.Text ||
                    this.txtNom1.Text != this.txtNom1Act.Text || this.txtNom2.Text != this.txtNom2Act.Text ||
                    this.txtNom3.Text != this.txtNom3Act.Text || this.txtApeCasado.Text != this.txtApeCasadoAct.Text)
                {
                    this.cIdTipoActCliente += "1,";
                    nCantidadCambios++;
                }
                if (this.dtFecNac.Text != this.dtFecNacAct.Text)
                {
                    this.cIdTipoActCliente += "2,";
                    nCantidadCambios++;
                }
                if (Convert.ToInt32(this.cboEstadoCivil.SelectedValue) != Convert.ToInt32(this.cboEstadoCivilAct.SelectedValue))
                {
                    this.cIdTipoActCliente += "3,";
                    nCantidadCambios++;
                }
                if (!SonIguales(this.tbClienteVinculado, this.tbClienteVinculadoAct))
                {
                    this.cIdTipoActCliente += "4,";
                    nCantidadCambios++;
                }
                if (Convert.ToInt32(this.cboSexo.SelectedValue) != Convert.ToInt32(this.cboSexoAct.SelectedValue))
                {
                    this.cIdTipoActCliente += "5,";
                    nCantidadCambios++;
                }
                if (Convert.ToInt32(this.cboEstadoCliNat.SelectedValue) != Convert.ToInt32(this.cboEstadoCliNatAct.SelectedValue))
                {
                    this.cIdTipoActCliente += "6,";
                    nCantidadCambios++;
                }
                if (Convert.ToInt32(this.cboTipDocumento.SelectedValue) != Convert.ToInt32(this.cboTipDocumentoAct.SelectedValue))
                {
                    if (this.cboTipDocumento.SelectedValue == null)
                    {
                        MessageBox.Show("Seleccione un Tipo de documento.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.cboTipoActCliente.SelectedValue = 7;
                        return false;
                    }
                    this.cIdTipoActCliente += "7,";
                    nCantidadCambios++;
                }
                if (this.txtCBDoc.Text != this.txtCBDocAct.Text || this.txtCBDigVerificador.Text != this.txtCBDigVerificadorAct.Text)
                {
                    this.cIdTipoActCliente += "8,";
                    nCantidadCambios++;

                    long nTmpResult = 0;
                    if (!long.TryParse(txtCBDoc.Text, out nTmpResult))
                    {
                        MessageBox.Show("Solo se permiten números para el número de documento.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.cboTipoActCliente.SelectedValue = 8;
                        return false;
                    }
                    else if (conBusCliente.nidTipoPersona.In(2, 3) && this.txtCBDoc.Text.Length != 11)
                    {
                        MessageBox.Show("El numero de RUC debe tener 11 digitos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.cboTipoActCliente.SelectedValue = 8;
                        return false;
                    }
                    else if (this.txtCBDoc.Text.Length != 8 && Convert.ToInt32(dtCliente.Rows[0]["idNacionalidad"]) == 0)
                    {
                        MessageBox.Show("El numero de DNI debe tener 8 digitos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.cboTipoActCliente.SelectedValue = 8;
                        return false;
                    }
                    else if (this.txtCBDoc.Text.Length != 9 && Convert.ToInt32(dtCliente.Rows[0]["idNacionalidad"]) == 1)
                    {
                        MessageBox.Show("El número de Carnet de Extranjería debe tener 9 dígitos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.cboTipoActCliente.SelectedValue = 8;
                        return false;
                    }
                    
                    if(Convert.ToInt32(dtCliente.Rows[0]["idNacionalidad"]) == 0)
                    {
                        int nDigito = this.CalcularDigitoVerificador(this.txtCBDoc.Text.Trim());
                        if(nDigito.ToString() != this.txtCBDigVerificador.Text.Trim())
                        {
                            MessageBox.Show("El Digito Verificador es incorrecto, por favor ingrese nuevamente el Digito Verificador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.cboTipoActCliente.SelectedValue = 8;
                            return false;
                        }
                    }
                }
            }
            else if (conBusCliente.nidTipoPersona.In(2, 3))
            {
                if (!SonIguales(this.tbClienteVinculado, this.tbClienteVinculadoAct))
                {
                    this.cIdTipoActCliente += "9,";
                    nCantidadCambios++;
                }
            }
            if (nCantidadCambios == 0)
            {
                MessageBox.Show("No existe modificación para solicitar.", this.Text.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!File.Exists(cRutaArchivo))
            {
                MessageBox.Show("Adjunte el Archivo de Sustento.", this.Text.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrEmpty(this.txtSustento.Text.Trim()))
            {
                MessageBox.Show("Ingrese un Sustento.", this.Text.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            this.cIdTipoActCliente = this.cIdTipoActCliente.Remove(this.cIdTipoActCliente.Length - 1);
            return true;
        }
        private void CargarVinculados(int nIdCliente)
        {
            clsCNClienteVinculado ListaClienteVinculado = new clsCNClienteVinculado();
            tbClienteVinculado = ListaClienteVinculado.ListaClienteVinculado(nIdCliente);
            this.tbClienteVinculadoAct = tbClienteVinculado.Copy();
            if (dtgVinculo.ColumnCount > 0)
            {
                dtgVinculo.Columns.Remove("idCli");
                dtgVinculo.Columns.Remove("idCliVin");
                dtgVinculo.Columns.Remove("cNombre");
                dtgVinculo.Columns.Remove("dFechaInicio");
                dtgVinculo.Columns.Remove("dFechaFinal");
                dtgVinculo.Columns.Remove("cTipoVinculo");
                dtgVinculo.Columns.Remove("Estado");
                dtgVinculo.Columns.Remove("nPorCapSocVot");
            }

            tbClienteVinculado.DefaultView.RowFilter = ("Estado <> 'E'");

            if (tbClienteVinculado.Rows.Count > 0)
            {
                //agrego esta parte para mostrar solo  las fechas que tienen fecha final, las que no tienen fecha final se muestran en campo vacio.
                for (int i = 0; i < tbClienteVinculado.Rows.Count; i++)
                {
                    if (tbClienteVinculado.Rows[i]["dFechaFinal"].ToString() == "1/01/1900 12:00:00 a. m." || tbClienteVinculado.Rows[i]["dFechaFinal"].ToString() == "1/01/1900")
                    {
                        tbClienteVinculado.Rows[i]["dFechaFinal"] = DBNull.Value;
                    }
                }
                //
            }
            dtgVinculo.DataSource = tbClienteVinculado;
            formatoGridVin();
        }
        #endregion

        #region Eventos
        private void conBusCliente_ClicBuscar(object sender, EventArgs e)
        {
            this.BuscarCliente();
        }
        private void frmRegSolActCliente_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
        }
        private void cboTipoActCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!(Convert.ToInt32(this.cboTipoActCliente.SelectedValue) > 0))
            {
                this.lblRequisitos.Text = string.Empty;
                return;
            }
            DataRowView dtTmp = (DataRowView)this.cboTipoActCliente.SelectedItem;
            this.lblRequisitos.Text = dtTmp["cDescripcion"].ToString();
            if(Convert.ToInt32(this.cboTipoActCliente.SelectedValue) == 3)
            {
                this.cboEstadoCivil_SelectedIndexChanged(null, null);
            }
            switch (Convert.ToInt32(this.cboTipoActCliente.SelectedValue))
            {
                case 1:
                    tbcCliente.SelectedIndex = 0;
                    break;
                case 2:
                    tbcCliente.SelectedIndex = 1;
                    break;
                case 3:
                    tbcCliente.SelectedIndex = 2;
                    break;
                case 4:
                    tbcCliente.SelectedIndex = 3;
                    break;
                case 5:
                    tbcCliente.SelectedIndex = 4;
                    break;
                case 6:
                    tbcCliente.SelectedIndex = 5;
                    break;
                case 7:
                    tbcCliente.SelectedIndex = 6;
                    break;
                case 8:
                    tbcCliente.SelectedIndex = 7;
                    break;
                case 9:
                    tbcCliente.SelectedIndex = 3;
                    break;
                case 10:
                    tbcCliente.SelectedIndex = 5;
                    break;
                default:
                    this.lblRequisitos.Text = string.Empty;
                    if (conBusCliente.nidTipoPersona.In(2, 3))
                    {
                        this.tbcCliente.SelectedIndex = 5;
                    }
                    else
                    {
                        this.tbcCliente.SelectedIndex = 0;
                    }
                    break;
            }
        }
        private void cboEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cboTipoActCliente.SelectedValue) != 3)
            {
                return;
            }
            if(Convert.ToInt32(this.cboEstadoCivilAct.SelectedValue) != Convert.ToInt32(this.cboEstadoCivil.SelectedValue) && Convert.ToInt32(this.cboEstadoCivil.SelectedValue) == 4) //VIUDO(A)
            {
                this.lblEstadoCivil.Visible = true;
            }
            else
            {
                this.lblEstadoCivil.Visible = false;
            }
            this.lblRequisitos.Text = string.Empty;
            if (Convert.ToInt32(this.cboEstadoCivil.SelectedValue) != Convert.ToInt32(this.cboEstadoCivilAct.SelectedValue))
            {
                switch (Convert.ToInt32(this.cboEstadoCivil.SelectedValue))
                {
                    case 1:
                        this.lblRequisitos.Text = "Declaración jurada de no convivencia o separación de hecho.";
                        break;
                    case 2:
                        this.lblRequisitos.Text = "Partida de matrimonio/DNI.";
                        break;
                    case 3:
                        this.lblRequisitos.Text = "DOI/sentencia judicial de divorcio/acta notarial/acta de resolución.";
                        break;
                    case 4:
                        this.lblRequisitos.Text = "Partida de matrimonio y de defunción del cónyuge/ inscripción de sucesión intestada.";
                        break;
                    case 5:
                        this.lblRequisitos.Text = string.Empty;
                        break;
                    case 6:
                        this.lblRequisitos.Text = "DJ de no convivencia con firma legalizada/copia de denuncia policial de separación.";
                        break;
                    default:
                        this.lblRequisitos.Text = string.Empty;
                        break;
                }
            }
        }
        private void btnEnviarSolicitud_Click(object sender, EventArgs e)
        {
            if(!this.Validar())
            {
                return;
            }

            DataSet dsVin = new DataSet("dsVinculo");
            dsVin.Tables.Add(tbClienteVinculado);
            string xmlVinc = dsVin.GetXml();
            xmlVinc = clsCNFormatoXML.EncodingXML(xmlVinc);
            dsVin.Tables.Clear();

            byte[] bArchivo = File.ReadAllBytes(cRutaArchivo);
            string cArchivo = Path.GetFileName(cRutaArchivo);

            if (conBusCliente.nidTipoPersona == 1)
            {
                string cApePat = txtApePat.Text.Trim();
                string cApeMat = txtApeMat.Text.Trim();
                string cNom1 = txtNom1.Text.Trim();
                string cNom2 = txtNom2.Text.Trim();
                string cNom3 = txtNom3.Text.Trim();
                string cApeCas = txtApeCasado.Text.Trim();
                string cNombCliente = cApePat + " " + cApeMat + " " + cApeCas + " " + cNom1 + " " + cNom2 + " " + cNom3;
                string cDocumentoID = txtCBDoc.Text.Trim();
                string cDigitoVerificador = txtCBDigVerificador.Text.Trim();
                cNombCliente = cNombCliente.Trim();
                cNombCliente = Regex.Replace(cNombCliente, @"\s+", " ");
                int idSexo = Convert.ToInt32(cboSexo.SelectedValue.ToString().Trim());
                string tcDocIde = txtCBDoc.Text.Trim();
                DateTime tdFecNac = dtFecNac.Value;
                int idEstadoCliNat = Convert.ToInt32(cboEstadoCliNat.SelectedValue);
                DateTime dFechaFallecimiento = this.dtpFecFallec.Value;
                int idEstCiv = 0;
                int idTipoDocumneto = Convert.ToInt32(cboTipDocumento.SelectedValue.ToString().Trim());
                string cSustentoSol = txtSustento.Text.Trim();

                //===================================================================
                //Validar Cliente Homónimos
                //===================================================================
                DataTable dtHomonimos = Cliente.CNValidaHomonimos(cNombCliente, tcDocIde);
                if (dtHomonimos.Rows.Count > 0 && txtApePat.Enabled == true && txtApeMat.Enabled == true && txtNom1.Enabled == true)
                {
                    frmClientesHomonimos frmHomonimos = new frmClientesHomonimos();
                    frmHomonimos.dtClientesHomonimos = dtHomonimos;
                    frmHomonimos.ShowDialog();
                    if (MessageBox.Show("¿Desea continuar con el registro del cliente?", "Registro de Solicitud de Actualización de Clientes", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                //===================================================================
                if (cboEstadoCivil.SelectedIndex > -1)
                {
                    idEstCiv = Convert.ToInt32(cboEstadoCivil.SelectedValue.ToString().Trim());
                }
                clsRespuestaServidor objRespuesta = objSolActCliente.CNRegistroSolActCliente(0, conBusCliente.idCli, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, this.cIdTipoActCliente, clsVarGlobal.PerfilUsu.idPerfil,
                    cSustentoSol, 12, 1, idTipoDocumneto, cDocumentoID, cDigitoVerificador, cApePat, cApeMat, cNom1, cNom2, cNom3, cApeCas, 0, tdFecNac, idSexo, idEstCiv, idEstadoCliNat, dFechaFallecimiento, xmlVinc, 1, cArchivo, bArchivo);
                if (objRespuesta.idResultado == ResultadoServidor.Correcto)
                {
                    MessageBox.Show(objRespuesta.cMensaje + this.ListarCambios(), this.Text.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(objRespuesta.cMensaje, this.Text.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (conBusCliente.nidTipoPersona == 2 || conBusCliente.nidTipoPersona == 3)
            {
                string cSustentoSol = txtSustento.Text.Trim();
                DateTime dFechaFallecimiento = this.dtpFecFallec.Value;
                clsRespuestaServidor objRespuesta = objSolActCliente.CNRegistroSolActCliente(0, conBusCliente.idCli, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, this.cIdTipoActCliente, clsVarGlobal.PerfilUsu.idPerfil,
                    cSustentoSol, 12, 1, 1, "", "", "", "", "", "", "", "", 0, clsVarGlobal.dFecSystem, 1, 1, 1, dFechaFallecimiento, xmlVinc, 1, cArchivo, bArchivo);
                if (objRespuesta.idResultado == ResultadoServidor.Correcto)
                {
                    MessageBox.Show(objRespuesta.cMensaje + this.ListarCambios(), this.Text.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(objRespuesta.cMensaje, this.Text.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            this.BuscarSolicitudes(0, 0, clsVarGlobal.User.idUsuario, 0);
            this.tbcCliente.Enabled = false;
            this.btnEnviarSolicitud.Enabled = false;
            this.btnCargarSustento.Enabled = false;
            this.btnNuevo1.Enabled = true;
        }
        private void btnCargarSustento_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos PDF|*.pdf";
            openFileDialog.Title = "Seleccionar archivo PDF";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                cRutaArchivo = openFileDialog.FileName;
                long nBytes = new System.IO.FileInfo(cRutaArchivo).Length;
                long nMBytes = nBytes / (1024 * 1024);
                if (nMBytes > 2)
                {
                    MessageBox.Show("El tamaño del archivo excede los 2MB. Por favor seleccione un archivo más pequeño.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.txtArchivo.Text = Path.GetFileName(cRutaArchivo);
            }
        }
        private void btnQuiVinc_Click(object sender, EventArgs e)
        {
            int nContador;
            nContador = dtgVinculo.Rows.Count;
            if (nContador == 0)
            {
                MessageBox.Show("No Existe Registro a Eliminar", this.Text);
                return;
            }
            else
            {
                if (dtgVinculo.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Debe de seleccionar Registro que desea Eliminar", this.Text);
                    return;
                }
                else if (!Convert.ToInt32(dtgVinculo.SelectedRows[0].Cells["idTipoVinculo"].Value).In(1, 2))
                {
                    MessageBox.Show("El tipo vinculo " + dtgVinculo.SelectedRows[0].Cells["cTipoVinculo"].Value.ToString() + ", no requiere solicitud para su desvinculación.", this.Text);
                    return;
                }
                else
                {
                    int nFila = Convert.ToInt32(dtgVinculo.SelectedCells[0].RowIndex);
                    tbClienteVinculado.Columns["Estado"].ReadOnly = false;
                    if (dtgVinculo.Rows[nFila].Cells["Estado"].Value.ToString() == "N")
                    {
                        ((DataTable)dtgVinculo.DataSource).Rows[nFila].Delete();
                        ((DataTable)dtgVinculo.DataSource).AcceptChanges();
                    }
                    else
                    {
                        this.dtgVinculo.Rows[nFila].Cells["Estado"].Value = "E";
                        ((DataTable)dtgVinculo.DataSource).AcceptChanges();
                    }
                }
            }
        }
        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            this.BuscarCliente();
        }
        private void cboEstadoCliNat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Convert.ToInt32(this.cboEstadoCliNat.SelectedIndex) == 1)
            {
                this.lblBase83.Visible = true;
                this.dtpFecFallec.Visible = true;
            }
            else
            {
                this.lblBase83.Visible = false;
                this.dtpFecFallec.Visible = false;
            }
        }
        #endregion

    }
}
