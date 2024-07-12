#region Referencias
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
using GEN.BotonesBase;
using GEN.CapaNegocio;
using EntityLayer;
using clsCNGrupoSolidario = CRE.CapaNegocio.clsCNGrupoSolidario;
using Microsoft.Reporting.WinForms;
#endregion

namespace CRE.Presentacion
{
    public partial class frmGruSolAprExcNoCon : frmBase
    {
        struct MensajesDelFormulario
        {
            public static String SUS_VALID = "Debe de escribir un sustento válido.";
            public static String NO_DATA_SOL_CON = "No existen datos para esta Solicitud No Contemplada.";
            public static String MAS_4_RNC = "No se puede proceder con la solicitud de excepciones, porque hay mas de 4 excepciones automáticas/manuales generadas";
            public static String SEG_DEN = "Seguro(a) de realizar esta acción. Al DENEGAR la excepción se anulará la solicitud de crédito.";
        }
        #region Variables
        private clsCNGrupoSolidario cngruposolidario = new clsCNGrupoSolidario();
        private int idSolicitud = -1;
        private int idNivelAprob = -1;
        private int idReglaNoContemplada = -1;
        private clsCNSolicitud obCNSolicitud = new clsCNSolicitud();
        private DataTable dtNivelesAut;
        private DataTable dtAutorizacion;
        private bool isLoaded = false;
        private int idSolicitudCredGrupoSol = -1;
        private int idGrupoSolidario = -1;
        private int nNivelAprob;
        #endregion
        #region Getters y Setters
        #endregion
        #region Constructor
        public frmGruSolAprExcNoCon()
        {
            InitializeComponent();
            this.cargarBotonesNivelesdeAut(); // solo debe de hacerse una vez
            this.btnAnular1.Enabled = clsVarGlobal.PerfilUsu.idPerfil == 118;
        }
        #endregion
        #region Metodos
        /** Genera los botones para la aprovacion */
        private void cargarBotonesNivelesdeAut()
        {
            DataSet dsAutorizacion = cngruposolidario.listaAutorizadores();
            this.dtNivelesAut = dsAutorizacion.Tables[0];
            this.dtAutorizacion = dsAutorizacion.Tables[1];
            if (this.dtNivelesAut.Rows.Count > 0)
            {
                /** cargar nivel de aprobacion **/
                this.nNivelAprob = Convert.ToInt32(this.dtNivelesAut.Rows[this.dtNivelesAut.Rows.Count - 1]["nOrden"]);
                int nXposicion = 89;
                int i = Convert.ToInt32(this.dtNivelesAut.Rows[0]["nOrden"]);
                for (int ij = 0; ij < this.dtNivelesAut.Rows.Count; ij++)
                {
                    DataRow drFila = this.dtNivelesAut.Rows[ij];
                    btnGruSolAprobar btn = new btnGruSolAprobar();
                    btn.Location = new System.Drawing.Point(nXposicion, 43);
                    btn.Name = "btnApr-" + i.ToString();
                    btn.Size = new System.Drawing.Size(75, 23);
                    btn.TabIndex = 15;
                    btn.Text = "Espera";
                    btn.UseVisualStyleBackColor = true;
                    btn.idNivelAprob = Convert.ToInt32(drFila["nOrden"]);
                    btn.idPerfil = Convert.ToInt32(drFila["idPerfil"]);
                    btn.Click += this.btnAut_Click;
                    btn.Enabled = false;
                    this.grbEstado.Controls.Add(btn);
                    string cAutorizadores = "";
                    DataRow[] aAutorizadores = this.dtAutorizacion.Select("idPerfil = " + Convert.ToString(drFila["idPerfil"]));
                    if(aAutorizadores.Length > 0)
                    {
                        foreach(DataRow oRow in aAutorizadores)
                        {
                            cAutorizadores += Convert.ToString(oRow["cNombre"]) + " - " + Convert.ToString(oRow["cWinUser"]) + Environment.NewLine;
                        }
                    }
                    lblGrow lbl = new lblGrow();
                    lbl.Font = new System.Drawing.Font("Verdana", 5.5F);
                    lbl.ForeColor = System.Drawing.Color.Navy;
                    lbl.Location = new System.Drawing.Point(nXposicion, 13);
                    lbl.Name = "lblApr-" + i.ToString();
                    lbl.Size = new System.Drawing.Size(75, 23);
                    lbl.TabIndex = 16;
                    lbl.Text = drFila["cCargo"].ToString();
                    lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    toolTip1.SetToolTip(lbl,
                        "Aprobadores:" + Environment.NewLine + cAutorizadores
                        );
                    this.grbEstado.Controls.Add(lbl);

                    i++;
                    nXposicion += 80;
                }
            }
        }
        /** Carga las solicitudes grupo solidario **/
        private void cargarSolicitudes()
        {
            this.dtgSolicitudes.DataSource = cngruposolidario.listaSolicitudesAgencia(clsVarGlobal.nIdAgencia);
            this.dtgSolicitudes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            foreach(DataGridViewColumn oCol in this.dtgSolicitudes.Columns)
            {
                oCol.Visible = false;
                oCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            this.dtgSolicitudes.Columns["idGrupoSolidario"].HeaderText = "Grupo Solidario";
            this.dtgSolicitudes.Columns["idGrupoSolidario"].Visible = true;
            this.dtgSolicitudes.Columns["idGrupoSolidario"].Width = 50;
            this.dtgSolicitudes.Columns["cNombre"].HeaderText = "Nombre Grupo Solidario";
            this.dtgSolicitudes.Columns["cNombre"].Visible = true;
            this.dtgSolicitudes.Columns["cNombre"].Width = 151;
        }
        private void cargarMiembros()
        {
            this.idReglaNoContemplada = -1;
            this.idNivelAprob = -1;
            if (dtgSolicitudes.SelectedRows.Count > 0)
            {
                DataRow drFila = ((DataRowView)dtgSolicitudes.SelectedRows[0].DataBoundItem).Row;
                this.idSolicitudCredGrupoSol = Convert.ToInt32(drFila["idSolicitudCredGrupoSol"]);
                this.idGrupoSolidario = Convert.ToInt32(drFila["idGrupoSolidario"]);
                /** Carga de miembros **/
                DataSet dsGrupoSolidario = cngruposolidario.solicitudMiembros(this.idSolicitudCredGrupoSol);
                if (Convert.ToInt32(dsGrupoSolidario.Tables[2].Rows[0]["nExcepciones"]) > 4)
                {
                    if (this.isLoaded)
                    {
                        MessageBox.Show(MensajesDelFormulario.MAS_4_RNC, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else 
                {
                    this.dtgMiembros.DataSource = dsGrupoSolidario.Tables[3];
                    this.dtgMiembros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    foreach (DataGridViewColumn oCol in this.dtgMiembros.Columns)
                    {
                        oCol.Visible = false;
                        oCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    this.dtgMiembros.Columns["idSolicitud"].HeaderText = "Solicitud";
                    this.dtgMiembros.Columns["idSolicitud"].Visible = true;
                    this.dtgMiembros.Columns["idSolicitud"].Width = 65;
                    this.dtgMiembros.Columns["cNombre"].HeaderText = "Nombre";
                    this.dtgMiembros.Columns["cNombre"].Visible = true;
                    this.dtgMiembros.Columns["cNombre"].Width = 250;
                    this.dtgMiembros.Columns["idNivelActual"].HeaderText = "Nivel de Aprobación  Actual";
                    this.dtgMiembros.Columns["idNivelActual"].Visible = true;
                    this.dtgMiembros.Columns["idNivelActual"].Width = 74;
                    this.dtgMiembros.Columns["idNivelAprobacion"].HeaderText = "Nivel de Aprobación ";
                    this.dtgMiembros.Columns["idNivelAprobacion"].Visible = true;
                    this.dtgMiembros.Columns["idNivelAprobacion"].Width = 74;
                    return;
                }
            }
            this.dtgMiembros.DataSource = new DataTable();
        }
        private void cargarSolicitud()
        {
            if (dtgMiembros.SelectedRows.Count > 0)
            {
                DataRow drFila = ((DataRowView)dtgMiembros.SelectedRows[0].DataBoundItem).Row;
                this.idSolicitud = Convert.ToInt32(drFila["idSolicitud"]);
                this.idReglaNoContemplada = Convert.ToInt32(drFila["idReglaNoContemplada"]);
            }
            else
            {
                this.idSolicitud = -1;
                this.idReglaNoContemplada = -1;
            }

            this.cargarDatosSolicitud(this.idSolicitud);
            this.cargarEstadoAprobacion(this.idReglaNoContemplada);
        }
        private void cargarDatosSolicitud(int idSolicitud)
        {
            DataTable dtSolicitud2 = obCNSolicitud.listarBandejaDatosSolicitud(idSolicitud);//consulta solicitud
            if (dtSolicitud2.Rows.Count > 0 && idSolicitud > 0)
            {
                this.txtBase1.Text = Convert.ToString(dtSolicitud2.Rows[0]["idRegla"]);
                this.txtBase2.Text = Convert.ToString(dtSolicitud2.Rows[0]["cMensajeError"]);
                this.txtBase5.Text = Convert.ToString(dtSolicitud2.Rows[0]["idCli"]);
                this.txtBase3.Text = Convert.ToString(dtSolicitud2.Rows[0]["cNombre"]);
                this.txtBase6.Text = Convert.ToString(dtSolicitud2.Rows[0]["cDocumentoID"]);
                this.txtBase7.Text = Convert.ToString(dtSolicitud2.Rows[0]["cOperacion"]);
                this.txtBase8.Text = Convert.ToString(dtSolicitud2.Rows[0]["cMoneda"]);
                this.txtBase9.Text = Convert.ToString(dtSolicitud2.Rows[0]["nCuotas"]);
                this.txtBase10.Text = Convert.ToString(dtSolicitud2.Rows[0]["cDescripTipoPeriodo"]);
                this.txtBase11.Text = Convert.ToString(dtSolicitud2.Rows[0]["cProducto"]);
                this.txtBase12.Text = Convert.ToString(dtSolicitud2.Rows[0]["nCapitalSolicitado"]);
                this.txtBase13.Text = Convert.ToString(dtSolicitud2.Rows[0]["nPlazoCuota"]);
                this.txtBase14.Text = Convert.ToString(dtSolicitud2.Rows[0]["nCuotasGracia"]);
            }
            else{
                this.txtBase1.Text = "";
                this.txtBase2.Text = "";
                this.txtBase5.Text = "";
                this.txtBase3.Text = "";
                this.txtBase6.Text = "";
                this.txtBase7.Text = "";
                this.txtBase8.Text = "";
                this.txtBase9.Text = "";
                this.txtBase10.Text = "";
                this.txtBase11.Text = "";
                this.txtBase12.Text = "";
                this.txtBase13.Text = "";
                this.txtBase14.Text = "";
            }
        }
        private void cargarEstadoAprobacion(int idReglaNoContemplada)
        {
            // CARGAR NIVEL DE APROBACION - Estado
            foreach (Control ctrl in grbEstado.Controls)
            {
                if (ctrl.GetType().ToString() == "GEN.BotonesBase.btnGruSolAprobar")
                {
                    btnGruSolAprobar btn = ctrl as btnGruSolAprobar;
                    btn.Text = "Espera";
                    btn.Enabled = false;

                    if (idReglaNoContemplada == -1) continue;

                    DataTable dtSustento = obCNSolicitud.cargarSustentoSolicitudRNC(idReglaNoContemplada, btn.idNivelAprob);
                    if (dtSustento.Rows.Count > 0)
                    {
                        DataRow drSustento = dtSustento.Rows[dtSustento.Rows.Count - 1];

                        int lAprobDesaprob = Convert.ToInt32(drSustento["lAprobDesaprob"]);
                        btn.Enabled = true;
                        if (lAprobDesaprob == 0)
                        {
                            btn.Text = "Denegado";
                            return;
                        }
                        else {
                            btn.Text = "Aprobado";
                        }
                    }
                    else if(btn.idPerfil == clsVarGlobal.PerfilUsu.idPerfil)
                    {
                        btn.Enabled = true;
                    }
                }
            }
            this.cargarSustento(this.idReglaNoContemplada, 1);
        }
        private void cargarSustento(int idRNC, int idNivelAprob, int idPerfil = -1)
        {
            this.activarBtnAprobador(false);
            DataTable dtSolicitud3 = obCNSolicitud.cargarSustentoSolicitudRNC(idRNC, idNivelAprob);//consulta solicitud
            if (dtSolicitud3.Rows.Count > 0)
            {
                this.txtNomApro.Text = dtSolicitud3.Rows[0]["cNombre"].ToString();
                this.txtNomApro.Enabled = false;
                this.txtSustento.Text = dtSolicitud3.Rows[0]["cSustento"].ToString();
                this.txtSustento.Enabled = false;
            }
            else
            {
                this.txtNomApro.Text = "";
                this.txtNomApro.Enabled = false;
                this.txtSustento.Text = "";
                this.txtSustento.Enabled = false;

                if (idPerfil != -1 && idPerfil == clsVarGlobal.PerfilUsu.idPerfil)
                {
                    this.txtNomApro.Text = clsVarGlobal.User.cNomUsu;
                    this.txtSustento.Enabled = true;
                    this.activarBtnAprobador(true);
                }
            }
        }
        private void activarBtnAprobador(bool lEstado)
        {
            this.btnAprobar1.Enabled = lEstado;
            this.btnDenegar1.Enabled = lEstado;
        }
        #endregion
        #region Eventos
        private void btnAsesor_Click(object sender, EventArgs e)
        {
            this.cargarSustento(this.idReglaNoContemplada, 1);
        }
        private void btnAut_Click(object sender, EventArgs e)
        {
            btnGruSolAprobar btn = sender as btnGruSolAprobar;
            this.idNivelAprob = btn.idNivelAprob;
            this.cargarSustento(this.idReglaNoContemplada, btn.idNivelAprob, btn.idPerfil);
        }
        private void btnAprobar1_Click(object sender, EventArgs e)
        {
            string cTituloMsjes = "Información";
            if (String.IsNullOrEmpty(this.txtSustento.Text.Trim()))
            {
                MessageBox.Show(MensajesDelFormulario.SUS_VALID,
                       cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string cSustento = Convert.ToString(this.txtSustento.Text.Trim());
                clsDBResp objDbResp = obCNSolicitud.CNAprobacionesSolicitudRNC(
                    this.idReglaNoContemplada
                    , cSustento
                    , this.idNivelAprob
                    , this.idNivelAprob == this.nNivelAprob ? 1 : 5
                    , clsVarGlobal.User.idUsuario);
                if (objDbResp.nMsje == 0)
                {
                    MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information); //ACEPTADA SOLICITUD
                    this.cargarMiembros();
                }
                else
                {
                    MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning); // LA SOLICITUD YA ESTA APROBADA / DENEGADA
                }
            }
        }
        private void btnAnular1_Click(object sender, EventArgs e)
        {
            if (((DataTable)this.dtgMiembros.DataSource).Rows.Count > 0 && this.dtgMiembros.SelectedRows.Count > 0)
            {
                int nNivelAActual = Convert.ToInt32(this.dtgMiembros.SelectedRows[0].Cells["idNivelActual"].Value);
                int nNivelAprobacion = Convert.ToInt32(this.dtgMiembros.SelectedRows[0].Cells["idNivelAprobacion"].Value);
                if (nNivelAActual == nNivelAprobacion) 
                {
                    MessageBox.Show("No se puede anular la solicitud de regla no contemplada, la solicitud de regla no contemplada ya fue aprobada",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    return;
                }
            }
            else 
            {
                MessageBox.Show("No hay Solicitud de regla no contemplada",
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            if (
                MessageBox.Show(
                    "Seguro(a)?", "Anulación"
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Warning)
                == System.Windows.Forms.DialogResult.Yes)
            {
                string cTituloMsjes = "Información";
                clsDBResp objDbResp = new clsCNSolicitud().anularExcepcionNC(this.idReglaNoContemplada, clsVarApl.dicVarGen["dFechaAct"], clsVarGlobal.User.idUsuario);
                if (objDbResp.nMsje == 0)
                {
                    MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information); //ACEPTADA SOLICITUD
                    this.cngruposolidario.anularSustentoDeRNC(this.idReglaNoContemplada);
                    this.cargarMiembros();
                }
                else
                {
                    MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning); // LA SOLICITUD YA ESTA APROBADA / DENEGADA
                }
            }
        }
        private void anularSolicitudCredGrupoSolidario() {
            if (Convert.ToInt16(clsVarApl.dicVarGen["lGruSolAnularSolDenGruSol"]) == 1)
            {
                DataTable dtRes = this.cngruposolidario.CambiarEstadoSolCredGrupoSol(
                    this.idGrupoSolidario,
                    this.idSolicitudCredGrupoSol);
                this.cngruposolidario.notificarAnulacion(this.idSolicitudCredGrupoSol, this.idReglaNoContemplada);
            }
        }
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            clsCNSolicitud cnRptRNC = new clsCNSolicitud();
            DateTime dFecOpe = clsVarGlobal.dFecSystem;
            string cNomAgen = clsVarGlobal.cNomAge;
            DataTable dtData2 = cnRptRNC.ObtenerReporteRNC(this.idSolicitud);
            DataTable dtData3 = cnRptRNC.ObtenerReporteRNC1(this.idSolicitud);
            if (dtData2.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsSolicitud", dtData2));
                dtsList.Add(new ReportDataSource("dsSolicitud2", dtData3));
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("idsolicitud", this.idSolicitud.ToString(), false));
                paramlist.Add(new ReportParameter("dFecOpe", dFecOpe.ToString(), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen.ToString(), false));

                string reportPath = "rptSolcitudRNC.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show(MensajesDelFormulario.NO_DATA_SOL_CON, "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnDenegar1_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(
                    MensajesDelFormulario.SEG_DEN, "Denegación"
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Warning)
                == System.Windows.Forms.DialogResult.Yes)
            {
                if (String.IsNullOrEmpty(this.txtSustento.Text.Trim()))
                {
                    MessageBox.Show("Debe de escribir un sustento válido.",
                           "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    string cSustento = Convert.ToString(this.txtSustento.Text.Trim());
                    clsDBResp objDbResp = obCNSolicitud.CNAprobacionesSolicitudRNC(
                        this.idReglaNoContemplada
                        , cSustento
                        , this.idNivelAprob
                        , 0
                        , clsVarGlobal.User.idUsuario);
                    this.anularSolicitudCredGrupoSolidario();
                    this.cargarMiembros();
                }
            }
        }
        private void dtgSolicitudes_SelectionChanged(object sender, EventArgs e)
        {
            this.cargarMiembros();
        }
        private void dtgMiembros_SelectionChanged(object sender, EventArgs e)
        {
            this.cargarSolicitud();
        }
        private void frmGruSolAprExcNoCon_Load(object sender, EventArgs e)
        {
            this.cargarSolicitudes(); // carga solicitudes correspondientes al perfil
            this.isLoaded = true;
        }
        #endregion
    }
}
