#region Referencias
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CLI.CapaNegocio;
using CLI.Servicio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
#endregion
namespace CLI.Presentacion
{
    public partial class frmResolSolActCliente : frmBase
    {
        #region Variable Globales
        private clsCNSolActCliente objSolActCliente = new clsCNSolActCliente();
        private clsCNRetDatosCliente RetTipCli = new clsCNRetDatosCliente();
        private DataTable tbClienteVinculado;
        private DataTable dtTipoActCliente;
        private DateTime pdFecSistem = clsVarGlobal.dFecSystem;
        private string cRutaArchivo = string.Empty;
        private int idSolicitudCarga = 0;
        private string cDescripcionCarga = string.Empty;
        private int idEstadoCarga = 0;
        private byte[] bArchivo = null;
        private string cIdTipoActualizacion = string.Empty;
        private int idCli = 0;
        #endregion

        #region Metodos
        public frmResolSolActCliente()
        {
            InitializeComponent();
            this.Iniciar();
        }
        private void Iniciar()
        {
            this.tbcCliente.SizeMode = TabSizeMode.Fixed;
            this.tbcCliente.ItemSize = new System.Drawing.Size(0, 1);
            this.dtTipoActCliente = this.objSolActCliente.CNListarTipoActualizacion();
            this.tbcCliente.Enabled = false;
            this.cboZonaBuscar.cargarZona(true, false);
            this.cboAgenciaBuscar.cargarAgencia(0);
            this.cboEstadoCivil.CargarEstadoCivil(0);
            this.cboEstadoCivilAct.CargarEstadoCivil(0);
            BuscarSolicitudes();
        }
        private void BuscarSolicitudes()
        {
            this.dtgSolicitudes.RowEnter -= dtgSolicitudes_RowEnter;
            int idZona = Convert.ToInt32(this.cboZonaBuscar.SelectedValue);
            int idAgencia = Convert.ToInt32(this.cboAgenciaBuscar.SelectedValue);
            int idUsuarioSol = 0;
            int idUsuarioApro = 0;
            int idEstado = 12;
            if(this.rbtPendientes.Checked)
            {
                idUsuarioApro = 0;
                idEstado = 12;
            }
            else if (this.rbtAprobados.Checked)
            {
                idUsuarioApro = clsVarGlobal.User.idUsuario;
                idEstado = 7;
            }
            else if (this.rbtRechazados.Checked)
            {
                idUsuarioApro = clsVarGlobal.User.idUsuario;
                idEstado = 40;
            }
            this.dtgSolicitudes.DataSource = null;
            clsCNSolActCliente objSolicitudes = new clsCNSolActCliente();
            this.dtgSolicitudes.DataSource = objSolicitudes.CNBuscarSolicitudes(idZona, idAgencia, idUsuarioSol, idUsuarioApro, idEstado);

            dtgSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dtgSolicitudes.Columns["idSolicitud"].Visible = false;
            dtgSolicitudes.Columns["idGrupo"].HeaderText = "N° Solicitud";
            dtgSolicitudes.Columns["idEstado"].Visible = false;
            dtgSolicitudes.Columns["idGrupo"].Width = 70;
            dtgSolicitudes.Columns["cEstado"].HeaderText = "Estado";
            dtgSolicitudes.Columns["cEstado"].Width = 75;
            dtgSolicitudes.Columns["cNombreAge"].HeaderText = "Oficina";
            dtgSolicitudes.Columns["cNombreAge"].Width = 130;
            dtgSolicitudes.Columns["dFechaOpe"].HeaderText = "Fcha. Op.";
            dtgSolicitudes.Columns["dFechaOpe"].Width = 80;
            dtgSolicitudes.Columns["dFechaRegistro"].HeaderText = "Fecha y Hora";
            dtgSolicitudes.Columns["dFechaRegistro"].Width = 110;
            dtgSolicitudes.Columns["cNombre"].HeaderText = "Nombre Cliente";
            dtgSolicitudes.Columns["cNombre"].Visible = false;
            dtgSolicitudes.Columns["cNombreSol"].HeaderText = "Nombre Solicitante";
            dtgSolicitudes.Columns["cNombreSol"].Width = 200;
            dtgSolicitudes.Columns["cTipoActualizacion"].HeaderText = "Tipo de Actualización";
            dtgSolicitudes.Columns["cTipoActualizacion"].Width = 260;
            dtgSolicitudes.Columns["cSustentoApro"].HeaderText = "Comentario del Aprobador";
            dtgSolicitudes.Columns["cSustentoApro"].Width = 300;
            dtgSolicitudes.Columns["idCli"].Visible = false;
            dtgSolicitudes.Columns["idPerfil"].Visible = false;
            dtgSolicitudes.Columns["cPerfil"].Visible = false;

            this.dtgSolicitudes.RowEnter += dtgSolicitudes_RowEnter;
            this.dtgSolicitudes_RowEnter(null, null);
        }
        private void CargarSolicitud()
        {
            clsCNSolActCliente objSolicitud = new clsCNSolActCliente();
            DataSet dtCargaSolicitud = objSolicitud.CNCargarSolicitud(this.idSolicitudCarga, this.cDescripcionCarga, this.idEstadoCarga);
            DataTable dtSolicitud = dtCargaSolicitud.Tables[0];
            DataTable dtCliJur = dtCargaSolicitud.Tables[1];
            DataTable dtActClienteNatural = dtCargaSolicitud.Tables[1];
            if (dtSolicitud.Rows.Count == 0 || dtCliJur.Rows.Count == 0 || dtActClienteNatural.Rows.Count == 0)
            {
                this.idSolicitudCarga = 0;
                this.idCli = 0;
                this.txtNroSolicitud.Text = string.Empty;
                this.cboAgenciaSol.SelectedValue = -1;
                this.txtUsuarioSol.Text = string.Empty;
                this.txtNroDocumentoSol.Text = string.Empty;
                this.txtClienteSol.Text = string.Empty;
                this.txtPerfilSol.Text = string.Empty;
                this.bArchivo = null;
                this.cIdTipoActualizacion = string.Empty;
                this.txtSustento.Text = string.Empty;
                this.txtSustentoApro.Text = string.Empty;
                return;
            }
            this.txtNroSolicitud.Text = dtSolicitud.Rows[0]["idSolicitud"].ToString();
            this.cboAgenciaSol.SelectedValue = Convert.ToInt32(dtSolicitud.Rows[0]["idAgencia"]);
            this.txtUsuarioSol.Text = dtSolicitud.Rows[0]["cNombreSol"].ToString();
            this.txtNroDocumentoSol.Text = dtSolicitud.Rows[0]["cDocumentoID"].ToString();
            this.txtClienteSol.Text = dtSolicitud.Rows[0]["cNombre"].ToString();
            this.txtPerfilSol.Text = dtSolicitud.Rows[0]["cPerfil"].ToString();
            this.dtpFechaHoraSolicitud.Value = Convert.ToDateTime(dtSolicitud.Rows[0]["dFechaRegistro"]);
            this.bArchivo = (byte[])dtSolicitud.Rows[0]["bArchivo"];
            this.cIdTipoActualizacion = dtSolicitud.Rows[0]["cTipoActualizacion"].ToString();
            this.txtSustento.Text = dtSolicitud.Rows[0]["cSustentoSol"].ToString();
            this.txtSustentoApro.Text = dtSolicitud.Rows[0]["cSustentoApro"].ToString();
            this.txtSustentoApro.ReadOnly = !this.rbtPendientes.Checked;
            this.idCli = Convert.ToInt32(dtSolicitud.Rows[0]["idCli"]);
            if (dtSolicitud.Rows[0]["idTipoPersona"].ToString() == "1")
            {
                // Tab 1
                this.txtApePat.Text = dtActClienteNatural.Rows[0]["cApellidoPaterno"].ToString();
                this.txtApeMat.Text = dtActClienteNatural.Rows[0]["cApellidoMaterno"].ToString();
                this.txtApeCasado.Text = dtActClienteNatural.Rows[0]["cApellidoCasado"].ToString();
                this.txtNom1.Text = dtActClienteNatural.Rows[0]["cNombre"].ToString();
                this.txtNom2.Text = dtActClienteNatural.Rows[0]["CNombreSeg"].ToString();
                this.txtNom3.Text = dtActClienteNatural.Rows[0]["cNombreOtros"].ToString();
                // Tab 2
                this.dtFecNac.Value = (String.IsNullOrEmpty(dtActClienteNatural.Rows[0]["dFechaNacimiento"].ToString())) ? clsVarGlobal.dFecSystem : Convert.ToDateTime(dtActClienteNatural.Rows[0]["dFechaNacimiento"].ToString());
                // Tab 3
                this.cboEstadoCivil.SelectedValue = (String.IsNullOrEmpty(dtActClienteNatural.Rows[0]["idEstadoCivil"].ToString())) ? 0 : Convert.ToInt32(dtActClienteNatural.Rows[0]["idEstadoCivil"].ToString());
                // Tab 4
                this.CargarVinculados(dtCargaSolicitud.Tables[2]);
                // Tab 5
                this.cboSexo.SelectedValue = (String.IsNullOrEmpty(dtActClienteNatural.Rows[0]["idSexo"].ToString())) ? 0 : Convert.ToInt32(dtActClienteNatural.Rows[0]["idSexo"].ToString());
                // Tab 6
                this.cboEstadoCliNat.ListaEstadoCli(1);
                this.cboEstadoCliNat.SelectedValue = (String.IsNullOrEmpty(dtActClienteNatural.Rows[0]["idEstadoCli"].ToString())) ? 0 : Convert.ToInt32(dtActClienteNatural.Rows[0]["idEstadoCli"].ToString());

                this.dtpFecFallec.Value = (String.IsNullOrEmpty(dtActClienteNatural.Rows[0]["dFechaFallecimiento"].ToString())) ? DateTime.Now : Convert.ToDateTime(dtActClienteNatural.Rows[0]["dFechaFallecimiento"]);
                // Tab 7
                this.cboTipDocumento.CargarDocumentos("T");
                this.cboTipDocumento.SelectedValue = (String.IsNullOrEmpty(dtActClienteNatural.Rows[0]["idTipoDocumento"].ToString())) ? 0 : Convert.ToInt32(dtActClienteNatural.Rows[0]["idTipoDocumento"].ToString());
                // Tab 8
                this.txtCBDoc.Text = dtActClienteNatural.Rows[0]["cDocumentoID"].ToString();
                this.txtCBDigVerificador.Text = dtActClienteNatural.Rows[0]["cDigitoVerificador"].ToString();

                if (dtSolicitud.Rows[0]["idEstado"].ToString() == "7")
                {
                    this.lblBase2.Visible = false;
                    this.lblBase24.Location = this.lblBase2.Location;
                    this.txtApePatAct.Visible = false;
                    this.txtApePat.Location = this.txtApePatAct.Location;
                    this.txtApeMatAct.Visible = false;
                    this.txtApeMat.Location = this.txtApeMatAct.Location;
                    this.txtNom1Act.Visible = false;
                    this.txtNom1.Location = this.txtNom1Act.Location;
                    this.txtNom2Act.Visible = false;
                    this.txtNom2.Location = this.txtNom2Act.Location;
                    this.txtNom3Act.Visible = false;
                    this.txtNom3.Location = this.txtNom3Act.Location;
                    this.txtApeCasadoAct.Visible = false;
                    this.txtApeCasado.Location = this.txtApeCasadoAct.Location;
                    // Tab 2
                    this.lblBase3.Visible = false;
                    this.lblBase25.Location = this.lblBase3.Location;
                    this.dtFecNacAct.Visible = false;
                    this.dtFecNac.Location = this.dtFecNacAct.Location;
                    // Tab 3
                    this.lblBase5.Visible = false;
                    this.lblBase30.Location = this.lblBase5.Location;
                    this.cboEstadoCivilAct.Visible = false;
                    this.cboEstadoCivil.Location = this.cboEstadoCivilAct.Location;
                    this.lblEstadoCivil.Location = new System.Drawing.Point(310, 41);
                    // Tab 5
                    this.lblBase7.Visible = false;
                    this.lblBase31.Location = this.lblBase7.Location;
                    this.cboSexoAct.Visible = false;
                    this.cboSexo.Location = this.cboSexoAct.Location;
                    // Tab 6
                    this.lblBase8.Visible = false;
                    this.lblBase32.Location = this.lblBase8.Location;
                    this.cboEstadoCliNatAct.Visible = false;
                    this.cboEstadoCliNat.Location = this.cboEstadoCliNatAct.Location;
                    this.lblBase83.Location = new System.Drawing.Point(195 - 193, 83);
                    this.dtpFecFallec.Location = new System.Drawing.Point(340 - 185, 77);
                    // Tab 7
                    this.lblBase14.Visible = false;
                    this.lblBase33.Location = this.lblBase14.Location;
                    this.cboTipDocumentoAct.Visible = false;
                    this.cboTipDocumento.Location = this.cboTipDocumentoAct.Location;
                    // Tab 8
                    this.lblBase15.Visible = false;
                    this.lblBase34.Location = this.lblBase15.Location;
                    this.txtCBDocAct.Visible = false;
                    this.txtCBDoc.Location = this.txtCBDocAct.Location;
                    this.txtCBDigVerificadorAct.Visible = false;
                    this.txtCBDigVerificador.Location = this.txtCBDigVerificadorAct.Location;
                }
                else
                {
                    this.lblBase2.Visible = true;
                    this.lblBase24.Location = new System.Drawing.Point(341, 17);
                    this.txtApePatAct.Visible = true;
                    this.txtApePat.Location = new System.Drawing.Point(317, 33);
                    this.txtApeMatAct.Visible = true;
                    this.txtApeMat.Location = new System.Drawing.Point(317, 58);
                    this.txtNom1Act.Visible = true;
                    this.txtNom1.Location = new System.Drawing.Point(317, 83);
                    this.txtNom2Act.Visible = true;
                    this.txtNom2.Location = new System.Drawing.Point(317, 109);
                    this.txtNom3Act.Visible = true;
                    this.txtNom3.Location = new System.Drawing.Point(317, 133);
                    this.txtApeCasadoAct.Visible = true;
                    this.txtApeCasado.Location = new System.Drawing.Point(317, 157);
                    // Tab 2
                    this.lblBase3.Visible = true;
                    this.lblBase25.Location = new System.Drawing.Point(329, 15);
                    this.dtFecNacAct.Visible = true;
                    this.dtFecNac.Location = new System.Drawing.Point(318, 31);
                    this.lblEstadoCivil.Location = new System.Drawing.Point(464, 41);
                    // Tab 3
                    this.lblBase5.Visible = true;
                    this.lblBase30.Location = new System.Drawing.Point(341, 22);
                    this.cboEstadoCivilAct.Visible = true;
                    this.cboEstadoCivil.Location = new System.Drawing.Point(331, 38);
                    // Tab 5
                    this.lblBase7.Visible = true;
                    this.lblBase31.Location = new System.Drawing.Point(323, 19);
                    this.cboSexoAct.Visible = true;
                    this.cboSexo.Location = new System.Drawing.Point(313, 35);
                    // Tab 6
                    this.lblBase8.Visible = true;
                    this.lblBase32.Location = new System.Drawing.Point(366, 18);
                    this.cboEstadoCliNatAct.Visible = true;
                    this.cboEstadoCliNat.Location = new System.Drawing.Point(340, 34);
                    this.lblBase83.Location = new System.Drawing.Point(195, 83);
                    this.dtpFecFallec.Location = new System.Drawing.Point(340, 77);
                    // Tab 7
                    this.lblBase14.Visible = true;
                    this.lblBase33.Location = new System.Drawing.Point(353, 15);
                    this.cboTipDocumentoAct.Visible = true;
                    this.cboTipDocumento.Location = new System.Drawing.Point(341, 31);
                    // Tab 8
                    this.lblBase15.Visible = true;
                    this.lblBase34.Location = new System.Drawing.Point(357, 15);
                    this.txtCBDocAct.Visible = true;
                    this.txtCBDoc.Location = new System.Drawing.Point(358, 31);
                    this.txtCBDigVerificadorAct.Visible = true;
                    this.txtCBDigVerificador.Location = new System.Drawing.Point(475, 31);
                }
            }
            else if (Convert.ToInt32(dtSolicitud.Rows[0]["idTipoPersona"]) == 2 || Convert.ToInt32(dtSolicitud.Rows[0]["idTipoPersona"]) == 3)
            {
                // Tab 4
                this.CargarVinculados(dtCargaSolicitud.Tables[2]);
                // Tab 6
                this.cboEstadoCliNat.ListaEstadoCli(Convert.ToInt32(dtSolicitud.Rows[0]["idTipoPersona"]));
                this.cboEstadoCliNat.SelectedValue = (String.IsNullOrEmpty(dtCliJur.Rows[0]["idEstadoCli"].ToString())) ? 0 : Convert.ToInt32(dtCliJur.Rows[0]["idEstadoCli"].ToString());

                this.lblBase8.Visible = !this.rbtAprobados.Checked;
                this.cboEstadoCliNatAct.Visible = !this.rbtAprobados.Checked;
            }

            List<int> ltsId = this.cIdTipoActualizacion.Split(',').Select(int.Parse).ToList();

            this.cboTipoActCliente.SelectedIndexChanged -= cboTipoActCliente_SelectedIndexChanged;
            this.cboTipoActCliente.DataSource = null;
            this.cboTipoActCliente.DataSource = this.dtTipoActCliente.AsEnumerable()
                .Where(row => ltsId.Contains(row.Field<int>("idTipoActCliente")))
                .CopyToDataTable();
            this.cboTipoActCliente.ValueMember = dtTipoActCliente.Columns[0].ToString();
            this.cboTipoActCliente.DisplayMember = dtTipoActCliente.Columns[1].ToString();
            this.cboTipoActCliente.SelectedIndexChanged += cboTipoActCliente_SelectedIndexChanged;
            this.cboTipoActCliente.SelectedIndex = 0;
            this.cboTipoActCliente_SelectedIndexChanged(null, null);
            this.BuscarCliente(Convert.ToInt32(dtSolicitud.Rows[0]["idCli"]));
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
        private void CargarVinculados(DataTable dtVinculado)
        {
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

            dtVinculado.DefaultView.RowFilter = ("Estado <> 'E'");

            if (dtVinculado.Rows.Count > 0)
            {
                //agrego esta parte para mostrar solo  las fechas que tienen fecha final, las que no tienen fecha final se muestran en campo vacio.
                for (int i = 0; i < dtVinculado.Rows.Count; i++)
                {
                    if (dtVinculado.Rows[i]["dFechaFinal"].ToString() == "1/01/1900 12:00:00 a. m." || dtVinculado.Rows[i]["dFechaFinal"].ToString() == "1/01/1900")
                    {
                        dtVinculado.Rows[i]["dFechaFinal"] = DBNull.Value;
                    }
                }
                //
            }
            dtgVinculo.DataSource = dtVinculado.DefaultView;
            formatoGridVin();
        }
        private void BuscarCliente(int idCli)
        {
            DataTable DatosTipCli = RetTipCli.ListarDatosCli(idCli, "O");

            if (DatosTipCli.Rows[0]["idTipoPersona"].ToString() == "1")
            {
                DataTable DatosCliNat = RetTipCli.ListarDatosCli(idCli, "N");
                // Tab 1
                this.txtApePatAct.Text = DatosCliNat.Rows[0]["cApellidoPaterno"].ToString();
                this.txtApeMatAct.Text = DatosCliNat.Rows[0]["cApellidoMaterno"].ToString();
                this.txtApeCasadoAct.Text= DatosCliNat.Rows[0]["cApellidoCasado"].ToString();
                this.txtNom1Act.Text = DatosCliNat.Rows[0]["cNombre"].ToString();
                this.txtNom2Act.Text = DatosCliNat.Rows[0]["CNombreSeg"].ToString();
                this.txtNom3Act.Text = DatosCliNat.Rows[0]["cNombreOtros"].ToString();
                // Tab 2
                this.dtFecNacAct.Value = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["dFechaNacimiento"].ToString())) ? clsVarGlobal.dFecSystem : Convert.ToDateTime(DatosCliNat.Rows[0]["dFechaNacimiento"].ToString());
                // Tab 3
                this.cboEstadoCivilAct.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idEstadoCivil"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idEstadoCivil"].ToString());
                // Tab 4
                // Tab 5
                this.cboSexoAct.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idSexo"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idSexo"].ToString());
                // Tab 6
                this.cboEstadoCliNatAct.ListaEstadoCli(1);
                this.cboEstadoCliNatAct.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idEstadoCli"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idEstadoCli"].ToString());
                // Tab 7
                this.cboTipDocumentoAct.CargarDocumentos("T");
                this.cboTipDocumentoAct.SelectedValue = (String.IsNullOrEmpty(DatosCliNat.Rows[0]["idTipoDocumento"].ToString())) ? 0 : Convert.ToInt32(DatosCliNat.Rows[0]["idTipoDocumento"].ToString());
                // Tab 8
                this.txtCBDocAct.Text = DatosCliNat.Rows[0]["cDocumentoID"].ToString();
                this.txtCBDigVerificadorAct.Text = DatosCliNat.Rows[0]["cDigitoVerificador"].ToString();
            }
            else if (Convert.ToInt32(DatosTipCli.Rows[0]["idTipoPersona"]) == 2 || Convert.ToInt32(DatosTipCli.Rows[0]["idTipoPersona"]) == 3)
            {
                DataTable DatosCliJur = RetTipCli.ListarDatosCli(idCli, "J");
                // Tab 4
                // Tab 6
                this.cboEstadoCliNatAct.ListaEstadoCli(Convert.ToInt32(DatosTipCli.Rows[0]["idTipoPersona"]));
                this.cboEstadoCliNatAct.SelectedValue = (String.IsNullOrEmpty(DatosCliJur.Rows[0]["idEstadoCli"].ToString())) ? 0 : Convert.ToInt32(DatosCliJur.Rows[0]["idEstadoCli"].ToString());
            }
        }
        #endregion

        #region Eventos
        private void cboTipVinculo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void frmRegSolActCliente_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            this.CargarSolicitud();
        }
        private void cboTipoActCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(Convert.ToInt32(this.cboTipoActCliente.SelectedValue) > 0))
            {
                return;
            }
            DataRowView dtTmp = (DataRowView)this.cboTipoActCliente.SelectedItem;
            this.lblRequisitos.Text = dtTmp["cDescripcion"].ToString();
            if (Convert.ToInt32(this.cboTipoActCliente.SelectedValue) == 3)
            {
                this.cboEstadoCivil_SelectedIndexChanged(null, null);
            }
            switch (Convert.ToInt32(cboTipoActCliente.SelectedValue))
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
                    if ((1).In(2, 3)) //tipo persona
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
            if(Convert.ToInt32(this.cboTipoActCliente.SelectedValue) != 3)
            {
                return;
            }
            if (Convert.ToInt32(this.cboEstadoCivil.SelectedValue) == 4) //VIUDO(A)
            {
                this.lblEstadoCivil.Visible = true;
            }
            else
            {
                this.lblEstadoCivil.Visible = false;
            }
            this.lblRequisitos.Text = string.Empty;
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
        private void btnCargarSustento_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos PDF|*.pdf";
            openFileDialog.Title = "Seleccionar archivo PDF";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                cRutaArchivo = openFileDialog.FileName;
            }
        }
        private void btnMiniBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarSolicitudes();
        }
        private void dtgSolicitudes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dtgSolicitudes.Rows.Count>0 && e != null)
            {
                int nFila = e.RowIndex;
                DataTable dtTmp = (DataTable)dtgSolicitudes.DataSource;
                this.idSolicitudCarga = Convert.ToInt32(dtTmp.Rows[nFila]["idGrupo"]);
                this.cDescripcionCarga = dtTmp.Rows[nFila]["cTipoActualizacion"].ToString();
                this.idEstadoCarga = Convert.ToInt32(dtTmp.Rows[nFila]["idEstado"]);
                this.CargarSolicitud();
            }
        }
        private void btnRechazar1_Click(object sender, EventArgs e)
        {
            if (this.idSolicitudCarga == 0)
            {
                MessageBox.Show("Seleccione una solicitud para aprobar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(this.txtSustentoApro.Text.ToString().Trim()))
            {
                MessageBox.Show("Ingrese su comentario de sustento de no aprobación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(MessageBox.Show("¿Está seguro de RECHAZAR la Solicitud Nro. " + this.idSolicitudCarga + "?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
            {
                return;
            }
            int diTipoActualizacion = Convert.ToInt32(this.cboTipoActCliente.SelectedValue);
            string cSustentoApro = txtSustentoApro.Text;
            clsCNSolActCliente objSolicitud = new clsCNSolActCliente();
            clsRespuestaServidor objRespuesta = objSolicitud.CNResolucionSolicitud(this.idSolicitudCarga, 40, clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, diTipoActualizacion, cSustentoApro); //DENEGADO

            if (objRespuesta.idResultado == ResultadoServidor.Correcto)
            {
                MessageBox.Show(objRespuesta.cMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtSustentoApro.Text = "";
            }
            else
            {
                MessageBox.Show(objRespuesta.cMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.CargarSolicitud();
        }
        private void btnAprobar1_Click(object sender, EventArgs e)
        {
            if (this.idSolicitudCarga == 0)
            {
                MessageBox.Show("Seleccione una solicitud para aprobar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(this.txtSustentoApro.Text.ToString().Trim()))
            {
                MessageBox.Show("Ingrese su comentario de sustento de aprobación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("¿Está seguro de APROBAR la Solicitud Nro. " + this.idSolicitudCarga + "?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
            {
                return;
            }
            int diTipoActualizacion = Convert.ToInt32(this.cboTipoActCliente.SelectedValue);
            string cSustentoApro = txtSustentoApro.Text;
            clsCNSolActCliente objSolicitud = new clsCNSolActCliente();
            clsRespuestaServidor objRespuesta = objSolicitud.CNResolucionSolicitud(this.idSolicitudCarga, 7, clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, diTipoActualizacion, cSustentoApro); //APROBADO

            if (objRespuesta.idResultado == ResultadoServidor.Correcto)
            {
                MessageBox.Show(objRespuesta.cMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtSustentoApro.Text = "";
            }
            else
            {
                MessageBox.Show(objRespuesta.cMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.CargarSolicitud();
        }
        private void btnCargarFile1_Click(object sender, EventArgs e)
        {
            if (this.bArchivo != null)
            {
                frmDisplayPDF pdf = new frmDisplayPDF("sustento", ".pdf", this.bArchivo);
                pdf.ShowDialog();
            }
        }
        private void btnMantClientes_Click(object sender, EventArgs e)
        {
            if (this.idCli == 0)
            {
                frmRegistroClientes frmMantCliente = new frmRegistroClientes();
                frmMantCliente.ShowDialog();
            }
            else
            {
                frmRegistroClientes frmMantCliente = new frmRegistroClientes(idCli);
                frmMantCliente.ShowDialog();
            }
        }
        private void cboEstadoCliNat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cboEstadoCliNat.SelectedIndex) == 1)
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
