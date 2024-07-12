using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.Funciones;
using CLI.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace CRE.Presentacion
{
    public partial class frmRegGrupoSolidario : frmBase
    {
        #region Variables
        private clsCNGrupoSolidario objCNGrupoSolidario;
        private List<clsGrupoSolidarioIntegrante> lstGrupoSolidarioIntegrante;
        private const string TITULO_FORM = "Registro Grupo Solidario";
        private int idDireccion;
        private int idGrupoSolidario;
        private bool lEditar;
        #endregion

        #region Constructor
        public frmRegGrupoSolidario()
        {
            InitializeComponent();

            objCNGrupoSolidario = new clsCNGrupoSolidario();

            this.HabilitarControles(false);

            this.dtgIntegrantes.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idDireccion = 0;
            this.idGrupoSolidario = 0;
            this.lEditar = true;

            this.conBusGrupoSol1.HabilitarBusqueda();
        }
        #endregion

        #region Métodos Privados
        private void AccionesFormulario(FormButtonAction formAccion)
        {
            if (formAccion == FormButtonAction.Nuevo)
            {
                this.btnEditar.Enabled = false;
                this.btnGrabar.Enabled = true;
                //this.btnCancelar.Enabled = true;
                this.cboCiclo.Enabled = true;
                this.cboGrupoSolidarioTipo.Enabled = true;
                this.cboTipoGrupoSolidario1.Enabled = true;
            }
            else if (formAccion == FormButtonAction.Editar)
            {
                this.btnEditar.Enabled = false;
                this.btnGrabar.Enabled = true;
                //this.btnCancelar.Enabled = true;
                this.cboCiclo.Enabled = true;
                this.cboGrupoSolidarioTipo.Enabled = true;
                this.cboTipoGrupoSolidario1.Enabled = true;
            }
            else if (formAccion == FormButtonAction.Grabar)
            {
                this.btnEditar.Enabled = true;
                this.btnGrabar.Enabled = false;
                //this.btnCancelar.Enabled = false;
                this.cboCiclo.Enabled = false;
                this.cboGrupoSolidarioTipo.Enabled = false;
                this.cboTipoGrupoSolidario1.Enabled = false;
                //this.conBusGrupoSol1.HabilitarEdicion();
            }
            else if (formAccion == FormButtonAction.Cancelar)
            {
                this.btnEditar.Enabled = false;
                this.btnGrabar.Enabled = false;
                //this.btnCancelar.Enabled = false;
                this.cboCiclo.Enabled = false;
                this.cboGrupoSolidarioTipo.Enabled = false;
                this.cboTipoGrupoSolidario1.Enabled = false;
                //this.conBusGrupoSol1.HabilitarBusqueda();
            }

            this.btnCancelar.Enabled = true;
            //this.btnNuevo.Enabled = true;
        }

        private void LimpiarControles()
        {
            conBusGrupoSol1.LimpiarControl();
            this.conBusGrupoSol1.txtNombreGrupo.CharacterCasing = CharacterCasing.Normal;

            if (this.lstGrupoSolidarioIntegrante != null)
            {
                this.lstGrupoSolidarioIntegrante.Clear();
                this.bindingIntegrantes.ResetBindings(false);
            }
        }

        private void HabilitarControles(bool lHabilitado)
        {
            this.btnAgregarInteg.Enabled = lHabilitado;
            this.btnQuitarInteg.Enabled = lHabilitado;
        }

        private void FormatearDataGrid()
        {
            foreach (DataGridViewColumn column in this.dtgIntegrantes.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgIntegrantes.Columns["idCli"].DisplayIndex = 0;
            dtgIntegrantes.Columns["cNombreCliente"].DisplayIndex = 1;
            dtgIntegrantes.Columns["cNumDocumento"].DisplayIndex = 2;
            dtgIntegrantes.Columns["cCargo"].DisplayIndex = 3;
            //dtgIntegrantes.Columns["cCiclo"].DisplayIndex = 4;
            dtgIntegrantes.Columns["dFechaIntegracion"].DisplayIndex = 5;
            dtgIntegrantes.Columns["lDomicilioGrupo"].DisplayIndex = 6;

            dtgIntegrantes.Columns["idCli"].Visible = true;
            dtgIntegrantes.Columns["cNombreCliente"].Visible = true;
            dtgIntegrantes.Columns["cNumDocumento"].Visible = true;
            dtgIntegrantes.Columns["cCargo"].Visible = true;
            //dtgIntegrantes.Columns["cCiclo"].Visible = true;
            dtgIntegrantes.Columns["dFechaIntegracion"].Visible = true;
            dtgIntegrantes.Columns["lDomicilioGrupo"].Visible = true;

            dtgIntegrantes.Columns["idCli"].HeaderText = "Código";
            dtgIntegrantes.Columns["cNombreCliente"].HeaderText = "Cliente";
            dtgIntegrantes.Columns["cNumDocumento"].HeaderText = "Documento";
            dtgIntegrantes.Columns["cCargo"].HeaderText = "Cargo";
            //dtgIntegrantes.Columns["cCiclo"].HeaderText = "Ciclo";
            dtgIntegrantes.Columns["dFechaIntegracion"].HeaderText = "Fecha Integración";
            dtgIntegrantes.Columns["lDomicilioGrupo"].HeaderText = "Domicilio Grupo";

            dtgIntegrantes.Columns["idCli"].FillWeight = 20;
            dtgIntegrantes.Columns["cNombreCliente"].FillWeight = 100;
            dtgIntegrantes.Columns["cNumDocumento"].FillWeight = 30;
            dtgIntegrantes.Columns["cCargo"].FillWeight = 30;
            //dtgIntegrantes.Columns["cCiclo"].FillWeight = 18;
            dtgIntegrantes.Columns["dFechaIntegracion"].FillWeight = 30;
            dtgIntegrantes.Columns["lDomicilioGrupo"].FillWeight = 20;

            dtgIntegrantes.Columns["dFechaIntegracion"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dtgIntegrantes.Columns["cNombreCliente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgIntegrantes.Columns["cCargo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dtgIntegrantes.Columns["cCiclo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private bool EsValidoDatos()
        {
            //=============================================================
            //--Validar Datos de Ingreso
            //=============================================================

            if (this.conBusGrupoSol1.txtNombreGrupo.Enabled == true && string.IsNullOrEmpty(this.conBusGrupoSol1.txtNombreGrupo.Text.Trim()))
            {
                MessageBox.Show("Ingrese el Nombre del Grupo Solidario", TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.conBusGrupoSol1.txtNombreGrupo.Focus();
                return false;
            }

            if (!lstGrupoSolidarioIntegrante.Exists(x => x.idGrupoSolidarioCargo == 1))
            {
                MessageBox.Show("Ingrese un presidente del Grupo", TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            int nCount = this.lstGrupoSolidarioIntegrante.Count;
            //if (nCount < 5 || nCount > 25)
            //{
            //    MessageBox.Show("La cantidad mínimo de integrantes es 5 y máximo 25", TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}

            int idTipoGrupoSol = Convert.ToInt32(cboTipoGrupoSolidario1.SelectedValue);
            int nNroIntegrantes = Convert.ToInt32(txtBase1.Text);

            DataTable dtRes = objCNGrupoSolidario.CNValidaIngregrantesPorTipoGrupoSolidario(idTipoGrupoSol, nNroIntegrantes);
            if (!Convert.ToBoolean(dtRes.Rows[0]["nRes"]))
            {
                MessageBox.Show(dtRes.Rows[0]["cMsg"].ToString(), TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            /*int nCount = this.lstGrupoSolidarioIntegrante.Count;
            if (nCount < 5 || nCount > 25)
            {
                MessageBox.Show("La cantidad mínimo de integrantes es 5 y máximo 10", TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }*/

            return true;
        }

        private string GrupoSolidarioToXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idGrupoSolidario", typeof(int));
            dt.Columns.Add("cNombre", typeof(string));
            dt.Columns.Add("cAdjetivo", typeof(string));
            dt.Columns.Add("dFechaCreacion", typeof(DateTime));
            dt.Columns.Add("idDireccion", typeof(int));
            dt.Columns.Add("cUbigeo", typeof(string));
            dt.Columns.Add("idUsuReg", typeof(int));
            dt.Columns.Add("idUsuMod", typeof(int));
            dt.Columns.Add("dFecHoraReg", typeof(DateTime));
            dt.Columns.Add("dFecHoraMod", typeof(DateTime));
            dt.Columns.Add("idGrupoSolidarioCiclo", typeof(int));
            dt.Columns.Add("idGrupoSolidarioTipo", typeof(int));
            dt.Columns.Add("idTipoGrupoSolidario", typeof(int));

            DataRow row = dt.NewRow();

            row["idGrupoSolidario"] = this.idGrupoSolidario;
            row["cNombre"] = this.conBusGrupoSol1.txtNombreGrupo.Text;
            row["idUsuReg"] = clsVarGlobal.User.idUsuario;
            row["idUsuMod"] = clsVarGlobal.User.idUsuario;
            row["dFecHoraReg"] = clsVarGlobal.dFecSystem;
            row["dFecHoraMod"] = clsVarGlobal.dFecSystem;
            row["idGrupoSolidarioCiclo"] = Convert.ToInt32(this.cboCiclo.SelectedValue);
            row["idGrupoSolidarioTipo"] = Convert.ToInt32(this.cboGrupoSolidarioTipo.SelectedValue);
            row["idTipoGrupoSolidario"] = Convert.ToInt32(this.cboTipoGrupoSolidario1.SelectedValue);

            dt.Rows.Add(row);

            return clsUtils.ConvertToXML(dt.Copy(), "GrupoSolidario", "Item");
        }

        private void BuscarGrupoSolidario(int idGrupoSolidario)
        {
            DataSet ds = objCNGrupoSolidario.ObtenerGrupoSolidario(idGrupoSolidario);

            // --Datos del Grupo Solidario
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró ningún resultado.", TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarControles();

                return;
            }

            this.conBusGrupoSol1.txtIdGrupoSolidario.Text = Convert.ToString(idGrupoSolidario);
            this.conBusGrupoSol1.txtNombreGrupo.Text = dt.Rows[0]["cNombre"].ToString();
            this.conBusGrupoSol1.txtDireccion.Text = dt.Rows[0]["cDireccion"].ToString();

            this.cboCiclo.SelectedValue = Convert.ToInt32(dt.Rows[0]["idGrupoSolidarioCiclo"]);
            this.cboGrupoSolidarioTipo.SelectedValue = Convert.ToInt32(dt.Rows[0]["idGrupoSolidarioTipo"]);
            this.cboTipoGrupoSolidario1.SelectedValue = Convert.ToInt32(dt.Rows[0]["idTipoGrupoSolidario"]);
            this.lEditar = Convert.ToBoolean(dt.Rows[0]["lEditar"]);
            //-----------------
            // --Lista de integrantes del Grupo Solidario
            this.lstGrupoSolidarioIntegrante = DataTableToList.ConvertTo<clsGrupoSolidarioIntegrante>(ds.Tables[1]) as List<clsGrupoSolidarioIntegrante>;

            CargarDatosDataGrid(this.lstGrupoSolidarioIntegrante);
            int nCount = this.lstGrupoSolidarioIntegrante.Count;
            this.txtBase1.Text = Convert.ToString(nCount);
            
            AccionesFormulario(FormButtonAction.Cancelar);

            this.btnImprimir.Enabled = true;

            if (this.lEditar == true)
            {
                this.btnEditar.Enabled = true;
                this.Text = "Registro y Mantenimiento de Grupo Solidario";
            }
            else
            {
                this.btnEditar.Enabled = false;
                this.Text = "Registro y Mantenimiento de Grupo Solidario - (solo lectura)";
            }

            activarControlObjetos(this, EventoFormulario.INICIO);
        }

        private void CargarDatosDataGrid(List<clsGrupoSolidarioIntegrante> _lstGrupoSolIntegrante)
        {
            this.bindingIntegrantes.DataSource = _lstGrupoSolIntegrante;
            this.dtgIntegrantes.DataSource = this.bindingIntegrantes;

            FormatearDataGrid();
        }

        private void contarIntegrantes()
        {
            string nFilas = Convert.ToString(this.dtgIntegrantes.RowCount);
            this.txtBase1.Text = nFilas;
        }
        #endregion

        #region Eventos
        private void btnQuitarInteg_Click(object sender, EventArgs e)
        {

            var objIntegrante = this.bindingIntegrantes.Current as clsGrupoSolidarioIntegrante;
            int idCliente = Convert.ToInt32(objIntegrante.idCli);
            int idGS = Convert.ToInt32(objIntegrante.idGrupoSolidario);
            DataTable dt = (new CRE.CapaNegocio.clsCNGrupoSolidario()).BuscarCreditosActivosGS(idCliente, idGS);
            int resultado = Convert.ToInt32(dt.Rows[0]["cNumero"]);
            if (resultado > 0)
            {
                MessageBox.Show("No puede eliminar a este integrante por tener créditos activos con este grupo.",
                    TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (objIntegrante != null)
                {
                    DialogResult diagResult = MessageBox.Show("¿Estas seguro de eliminar el registro?", "Grupo Solidario",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (diagResult == DialogResult.Yes)
                    {
                        lstGrupoSolidarioIntegrante.Remove(objIntegrante);

                        this.bindingIntegrantes.ResetBindings(false);
                    }
                }
                contarIntegrantes();
            }
        }

        private void btnAgregarInteg_Click(object sender, EventArgs e)
        {
            frmIntegranteGrupoSol frmIntegranteGrupoSol = new frmIntegranteGrupoSol();
            frmIntegranteGrupoSol.ShowDialog();

            var objIntegrante = frmIntegranteGrupoSol.Integrante as clsGrupoSolidarioIntegrante;

            if (objIntegrante.idCli != 0)
            {
                if (lstGrupoSolidarioIntegrante.Exists(x => x.idCli == objIntegrante.idCli))
                {
                    MessageBox.Show("Ya se tiene registrado al Cliente.", TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (lstGrupoSolidarioIntegrante.Exists(x => x.lDomicilioGrupo == true && objIntegrante.lDomicilioGrupo == true))
                {
                    MessageBox.Show("Ya existe un Domicilio del grupo.", TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (lstGrupoSolidarioIntegrante.Exists(x => x.idGrupoSolidarioCargo == 1 && objIntegrante.idGrupoSolidarioCargo == 1))  //Presidente
                {
                    MessageBox.Show("Ya exite un Presidente.", TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (lstGrupoSolidarioIntegrante.Exists(x => x.idGrupoSolidarioCargo == 2 && objIntegrante.idGrupoSolidarioCargo == 2))  //Tesorero
                {
                    MessageBox.Show("Ya existe un Tesorero.", TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                lstGrupoSolidarioIntegrante.Add(objIntegrante);
                this.bindingIntegrantes.ResetBindings(false);
            }
            contarIntegrantes();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.lstGrupoSolidarioIntegrante = new List<clsGrupoSolidarioIntegrante>();

            CargarDatosDataGrid(this.lstGrupoSolidarioIntegrante);

            LimpiarControles();
            AccionesFormulario(FormButtonAction.Nuevo);
            HabilitarControles(true);

            this.idGrupoSolidario = 0;
            this.idDireccion = 0;

            this.conBusGrupoSol1.txtIdGrupoSolidario.Enabled = false;
            this.conBusGrupoSol1.txtNombreGrupo.Focus();
            this.conBusGrupoSol1.txtNombreGrupo.CharacterCasing = CharacterCasing.Upper;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            conBusGrupoSol1.txtNombreGrupo.Enabled = true;
            AccionesFormulario(FormButtonAction.Editar);
            HabilitarControles(true);

            this.conBusGrupoSol1.txtNombreGrupo.CharacterCasing = CharacterCasing.Upper;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!EsValidoDatos()) return;

            string cXmlGrupoSolidario = GrupoSolidarioToXML();
            //string cXmlDireccion = DireccionToXML();
            string cXmlGrupoSolidarioIntegrante = this.lstGrupoSolidarioIntegrante.GetXml();

            DataTable td = objCNGrupoSolidario.GuardarGrupoSolidario(idGrupoSolidario, cXmlGrupoSolidario, cXmlGrupoSolidarioIntegrante);

            if (td.Rows.Count > 0)
            {
                if (td.Rows[0]["idMsje"].ToString().Equals("0"))
                {
                    MessageBox.Show(td.Rows[0]["cMsje"].ToString(), TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.idGrupoSolidario = Convert.ToInt32(td.Rows[0]["idGrupoSolidario"]);
                    this.idDireccion = Convert.ToInt32(td.Rows[0]["idDireccion"]);

                    AccionesFormulario(FormButtonAction.Grabar);
                    conBusGrupoSol1.txtNombreGrupo.Enabled = false;
                    HabilitarControles(false);
                    BuscarGrupoSolidario(this.idGrupoSolidario);
                }
                else if (td.Rows[0]["idMsje"].ToString().Equals("1"))
                {
                    MessageBox.Show(td.Rows[0]["cMsje"].ToString(), TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //HabilitarControles(false);
                }
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();

            AccionesFormulario(FormButtonAction.Cancelar);
            HabilitarControles(false);

            this.btnImprimir.Enabled = false;

            this.conBusGrupoSol1.txtIdGrupoSolidario.Focus();
        }

        //Buscar:
        private void conBusGrupoSol1_ClicBuscar(object sender, EventArgs e)
        {
            DataTable dtGrupo = conBusGrupoSol1.dtGrupo;

            if (dtGrupo == null) { return; }
            if (dtGrupo.Rows.Count == 0) { return; }

            this.idGrupoSolidario = Convert.ToInt32(dtGrupo.Rows[0]["idGrupoSolidario"]);

            if (this.idGrupoSolidario == 0) return;

            BuscarGrupoSolidario(this.idGrupoSolidario);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (this.idGrupoSolidario == 0) return;

            DataSet dsProp = objCNGrupoSolidario.ReporteGrupoSolidario(this.idGrupoSolidario);
            string cNomAgen = clsVarGlobal.cNomAge.ToString();
            string cNomUsuario = clsVarGlobal.User.cWinUser;

            List<ReportParameter> paramList = new List<ReportParameter>();
            List<ReportDataSource> dtsList = new List<ReportDataSource>();

            dtsList.Add(new ReportDataSource("dataGrupoSolidario", dsProp.Tables[0]));
            dtsList.Add(new ReportDataSource("dataIntegrantes", dsProp.Tables[1]));

            paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));
            paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramList.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramList.Add(new ReportParameter("idGrupoSolidario", this.idGrupoSolidario.ToString(), false));
            paramList.Add(new ReportParameter("cNomUsuario", cNomUsuario, false));

            string reportpath = "rptGrupoSolidario.rdlc";
            new frmReporteLocal(dtsList, reportpath, paramList).ShowDialog();
            this.btnImprimir.Enabled = true;
        }

        private void frmRegGrupoSolidario_Shown(object sender, EventArgs e)
        {
            this.conBusGrupoSol1.txtIdGrupoSolidario.Focus();
        }

        private void frmRegGrupoSolidario_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
        }
        #endregion

    }
}
