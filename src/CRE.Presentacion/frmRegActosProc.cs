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
using CRE.CapaNegocio;
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class frmRegActosProc : frmBase
    {
        DataTable dtProcJudicial = new DataTable("dtProcJudicial");
        DataTable dtLstProcJud;
        DataTable dtActProc;
        clsCNProcJud objProcJud = new clsCNProcJud();
        private string cDetActProc = "";
        private int idEncargAud = 0;
        private bool lFlagValidar = true;

        public frmRegActosProc()
        {
            InitializeComponent();
        }

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            int idProcJudicial = 0, idCli = 0, idEstado = 0, idJuzgado = 0, idJuez = 0,
                idSecretario = 0, idAbogado = 0, idTipoProceso = 0, idTipoMedida = 0;
            string cJuzgado = "", cJuez = "", cSecretario = "", cNroExpediente = "", cAbogado = "",
                    cTipoProceso = "", cTipoMedida = "", cAbogDemand = "";
            DateTime dFecRegExp = DateTime.Now.Date, dFecEntrAsesor = DateTime.Now.Date;
            bool lIndTerceria = false;

            if (string.IsNullOrEmpty(conBusCli.txtCodCli.Text))
            {
                MessageBox.Show("Elija un cliente primero", "Registro de Actos Procesales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            dtLstProcJud = objProcJud.BusLstProcJud(Convert.ToInt32(conBusCli.txtCodCli.Text));
            if (dtLstProcJud.Rows.Count > 0)
            {
                if (dtLstProcJud.Rows.Count > 1)
                {
                    frmListaProcJud frm = new frmListaProcJud();
                    frm.CargarDatos(Convert.ToInt32(conBusCli.txtCodCli.Text), (string.IsNullOrEmpty(txtNroProc.Text) ? 0 : Convert.ToInt32(txtNroProc.Text)));
                    frm.ShowDialog();
                    if (frm.idProcJudicial > 0)
                    {
                        idProcJudicial = frm.idProcJudicial;
                        dtProcJudicial = objProcJud.BusProcJud(idProcJudicial);
                    }
                    else
                    {
                        MessageBox.Show("No eligio ningun proceso judicial.\nRealice nuevamente la busqueda.", "Registro de Actos Procesales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        Habilitar(1);
                        return;
                    }
                }
                else
                {
                    idProcJudicial = Convert.ToInt32(dtLstProcJud.Rows[0]["idProcJudicial"]);
                    dtProcJudicial = objProcJud.BusProcJud(idProcJudicial);
                }

                cNroExpediente = Convert.ToString(dtProcJudicial.Rows[0]["cNroExpediente"]);
                idCli = Convert.ToInt32(dtProcJudicial.Rows[0]["idCli"]);
                idEstado = Convert.ToInt16(dtProcJudicial.Rows[0]["idEstado"]);
                idJuzgado = Convert.ToInt16(dtProcJudicial.Rows[0]["idJuzgado"]);
                cJuzgado = Convert.ToString(dtProcJudicial.Rows[0]["idProcJudicial"]);
                idJuez = Convert.ToInt32(dtProcJudicial.Rows[0]["idJuez"]);
                cJuez = Convert.ToString(dtProcJudicial.Rows[0]["cJuez"]);
                idSecretario = Convert.ToInt32(dtProcJudicial.Rows[0]["idSecretario"]);
                cSecretario = Convert.ToString(dtProcJudicial.Rows[0]["cSecretario"]);
                idAbogado = Convert.ToInt32(dtProcJudicial.Rows[0]["idAbogado"]);
                cAbogado = Convert.ToString(dtProcJudicial.Rows[0]["cAbogado"]);
                idTipoProceso = Convert.ToInt32(dtProcJudicial.Rows[0]["idTipoProceso"]);
                cTipoProceso = Convert.ToString(dtProcJudicial.Rows[0]["cTipoProceso"]);
                idTipoMedida = Convert.ToInt32(dtProcJudicial.Rows[0]["idTipoMedida"]);
                cTipoMedida = Convert.ToString(dtProcJudicial.Rows[0]["cTipoMedida"]);
                dFecRegExp = Convert.ToDateTime(dtProcJudicial.Rows[0]["dFecRegExp"]);
                dFecEntrAsesor = Convert.ToDateTime(dtProcJudicial.Rows[0]["dFecEntrAsesor"]);
                lIndTerceria = Convert.ToBoolean(dtProcJudicial.Rows[0]["lIndTerceria"]);
                cAbogDemand = Convert.ToString(dtProcJudicial.Rows[0]["cAbogDemand"]);

                conBusCli.txtCodCli.Text = idCli.ToString();
                txtNroProc.Text = idProcJudicial.ToString();
                txtNroExp.Text = cNroExpediente.Substring(24, 2);
                cboEstProcJud.SelectedValue = Convert.ToInt16(idEstado);
                cboJuzgado.SelectedValue = Convert.ToInt16(idJuzgado);
                cboJuez.SelectedValue = Convert.ToInt16(idJuez);
                cboAbogado.SelectedValue = Convert.ToInt16(idAbogado);
                cboSecretario.SelectedValue = Convert.ToInt16(idSecretario);
                cboTipoProcJud.SelectedValue = Convert.ToInt16(idTipoProceso);
                cboTipMedJud.SelectedValue = Convert.ToInt16(idTipoMedida);
                txtAbogContr.Text = cAbogDemand;

                dtActProc = objProcJud.BusActProc(idProcJudicial);
                if (dtActProc.Rows.Count > 0)
                {
                    dtgActProc.Columns.Clear();

                    CalendarColumn dtpFecRecepcion = new CalendarColumn();
                    dtpFecRecepcion.Name = "dtpFecRecepcion";
                    dtpFecRecepcion.DataPropertyName = "dFecRecepcion";
                    TimePickerColumn dtpHora = new TimePickerColumn();
                    dtpHora.Name = "dtpHora";
                    dtpHora.DataPropertyName = "dHora";

                    dtgActProc.Columns.Add(dtpFecRecepcion);
                    dtgActProc.Columns.Add(dtpHora);

                    dtActProc.DefaultView.RowFilter = ("lVigente <> 0");                  
                    dtgActProc.DataSource = dtActProc;
                    FormatoGridViewActProc();

                    txtDetActProc.DataBindings.Add("Text", dtActProc, "cDetActProc", false, DataSourceUpdateMode.OnPropertyChanged);
                    cboEncAud.DataBindings.Add("SelectedValue", dtActProc, "idEncargAud", false, DataSourceUpdateMode.OnPropertyChanged);
                    cboTipoActoProcesal1.DataBindings.Add("SelectedValue", dtActProc, "idTipoActoProcesal", false, DataSourceUpdateMode.OnPropertyChanged);
                    cboTipoPersonaEjecActProc1.DataBindings.Add("SelectedValue", dtActProc, "idTipoPersonaEjec", false, DataSourceUpdateMode.OnPropertyChanged);

                    //txtDetActProc.Text = Convert.ToString(dtActProc.Rows[0]["cDetActProc"]);
                    //cboEncAud.SelectedValue = Convert.ToInt16(dtActProc.Rows[0]["idEncargAud"]);
                    dtgActProc.Columns["cWinUser"].Visible = true;
                    dtgActProc.Columns["cWinUser"].ReadOnly = true;
                    dtgActProc.Columns["cWinUser"].FillWeight = 15;
                    dtgActProc.Columns["cWinUser"].HeaderText = "Usu. Reg.";
                    dtgActProc.ReadOnly = true;

                    btnEditar.Enabled = true;
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                }
                else
                {
                    btnEditar.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = true;
                }               
            }
            else
            {
                btnEditar.Enabled = false;
                btnNuevo.Enabled = false;
                btnCancelar.Enabled = true;
            }

            conBusCli.btnBusCliente.Enabled = false;

        }

        private void frmRegActosProc_Load(object sender, EventArgs e)
        {
            Habilitar(1);
            cboTipoActoProcesal1.cargar();
            cboTipoPersonaEjecActProc1.cargar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Habilitar(3);
        }

        private void FormatoGridViewActProc()
        {
            dtgActProc.ReadOnly = false;

            dtActProc.Columns["dFecRecepcion"].DateTimeMode = DataSetDateTime.Unspecified;
            dtActProc.Columns["dHora"].DateTimeMode = DataSetDateTime.Unspecified;

            dtgActProc.Columns["idActoProcesal"].Visible=false;
            dtgActProc.Columns["idProcJudicial"].Visible=false;
            dtgActProc.Columns["dtpFecRecepcion"].Visible = true;
            dtgActProc.Columns["nNroDias"].Visible=true;
            dtgActProc.Columns["dFecVenc"].Visible = true;
            dtgActProc.Columns["dtpHora"].Visible = true;
            dtgActProc.Columns["lRealizdo"].Visible = true;
            dtgActProc.Columns["lPrn"].Visible = true;
            dtgActProc.Columns["dFecha"].Visible = true;
            dtgActProc.Columns["idUsuario"].Visible = false;
            dtgActProc.Columns["lAudiencia"].Visible = true;
            dtgActProc.Columns["lVigente"].Visible=false;
            dtgActProc.Columns["cDetActProc"].Visible = false;
            dtgActProc.Columns["idEncargAud"].Visible = false;
            dtgActProc.Columns["idTipoActoProcesal"].Visible = false;
            dtgActProc.Columns["idTipoPersonaEjec"].Visible = false;

            dtActProc.Columns["dHora"].ReadOnly = false;         

            dtgActProc.Columns["dtpFecRecepcion"].ReadOnly = false;
            dtgActProc.Columns["nNroDias"].ReadOnly = false;
            dtgActProc.Columns["dFecVenc"].ReadOnly = true;
            dtgActProc.Columns["dtpHora"].ReadOnly = false;
            dtgActProc.Columns["lRealizdo"].ReadOnly = false;
            dtgActProc.Columns["lPrn"].ReadOnly = false;
            dtgActProc.Columns["dFecha"].ReadOnly = true;
            dtgActProc.Columns["lAudiencia"].ReadOnly = false;
            dtgActProc.Columns["idTipoActoProcesal"].ReadOnly = false;

            dtgActProc.Columns["dtpFecRecepcion"].HeaderText = "Fec. Recep.";
            dtgActProc.Columns["nNroDias"].HeaderText = "Nro. Dias";
            dtgActProc.Columns["dFecVenc"].HeaderText = "Fec. Venc.";
            dtgActProc.Columns["dtpHora"].HeaderText = "Hora";
            dtgActProc.Columns["lRealizdo"].HeaderText = "Rlzdo.";
            dtgActProc.Columns["lPrn"].HeaderText = "Prn";
            dtgActProc.Columns["dFecha"].HeaderText = "Fecha";
            dtgActProc.Columns["lAudiencia"].HeaderText = "Aud.";
            dtgActProc.Columns["idTipoActoProcesal"].HeaderText = "Tipo";

            dtgActProc.Columns["dtpFecRecepcion"].FillWeight = 15;
            dtgActProc.Columns["nNroDias"].FillWeight = 7;
            dtgActProc.Columns["dFecVenc"].FillWeight = 15;
            dtgActProc.Columns["dtpHora"].FillWeight = 17;
            dtgActProc.Columns["lRealizdo"].FillWeight = 9;
            dtgActProc.Columns["lPrn"].FillWeight = 8;
            dtgActProc.Columns["dFecha"].FillWeight = 15;
            dtgActProc.Columns["lAudiencia"].FillWeight = 10;
            dtgActProc.Columns["idTipoActoProcesal"].FillWeight = 7;

            dtgActProc.Columns["dtpFecRecepcion"].DisplayIndex = 0;
            dtgActProc.Columns["nNroDias"].DisplayIndex = 1;
            dtgActProc.Columns["dFecVenc"].DisplayIndex = 2;
            dtgActProc.Columns["dtpHora"].DisplayIndex = 3;
            dtgActProc.Columns["lRealizdo"].DisplayIndex = 4;
            dtgActProc.Columns["lPrn"].DisplayIndex = 5;
            dtgActProc.Columns["dFecha"].DisplayIndex = 6;
            dtgActProc.Columns["lAudiencia"].DisplayIndex = 7;
            dtgActProc.Columns["idTipoActoProcesal"].DisplayIndex = 7;
        }

        private void btnAgrActProc_Click(object sender, EventArgs e)
        {
            DataRow row = dtActProc.NewRow();
            row["idActoProcesal"] = -1;
            row["idProcJudicial"] = txtNroProc.Text;
            row["dFecRecepcion"] = clsVarGlobal.dFecSystem.Date;
            row["dFecVenc"] = clsVarGlobal.dFecSystem.Date;
            row["dHora"] = clsVarGlobal.dFecSystem;
            row["lRealizdo"] = 0;
            row["lPrn"] = 0;
            row["dFecha"] = clsVarGlobal.dFecSystem.Date;
            row["idUsuario"] = clsVarGlobal.User.idCli;
            row["lAudiencia"] = 0;
            row["lVigente"] = 1;

            dtActProc.Rows.Add(row);
        }

        private void btnQuitActProc_Click(object sender, EventArgs e)
        {
            if (this.dtgActProc.SelectedCells.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar el Registro a Eliminar", "Registro de Actos Procesales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Int32 nFilaActual = Convert.ToInt32(this.dtgActProc.SelectedCells[0].RowIndex);
                if (Convert.ToInt32(dtgActProc.Rows[nFilaActual].Cells["idActoProcesal"].Value) == -1)
                {
                    dtgActProc.Rows.RemoveAt(nFilaActual);
                }
                else
                {
                    dtgActProc.Rows[nFilaActual].Cells["lVigente"].Value = 0;
                }
                this.dtgActProc.Focus();
                ProcessTabKey(true);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //Validar();
            //if (!lFlagValidar) return;

            cDetActProc = txtDetActProc.Text;
            idEncargAud = Convert.ToInt32(cboEncAud.SelectedValue);

            dtActProc.TableName = "dtActProc";
            DataSet dsActProc = new DataSet("dsActProc");
            dsActProc.Tables.Add(dtActProc);
            string xmlActProc = dsActProc.GetXml();

            dsActProc.Tables.Clear();

            DataTable result = objProcJud.RegActProc(xmlActProc,cDetActProc,idEncargAud);

            if (result.Rows[0]["idMsje"].ToString() == "0")
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Registro de Actos Procesales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Habilitar(4);
            }
            else
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Registro de Actos Procesales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Habilitar(int nOpcion)
        {
            if (nOpcion == 1) //Inicio o Cancelar
            {
                LimpiarComponentes();

                txtNroProc.Text = "";
                txtNroExp.Text = "";

                conBusCli.txtCodAge.Text = "";
                conBusCli.txtCodInst.Text = "";
                conBusCli.txtCodCli.Text = "";
                conBusCli.txtCodAge.Text = "";
                conBusCli.txtNroDoc.Text = "";
                conBusCli.txtNombre.Text = "";
                conBusCli.txtDireccion.Text = "";

                conBusCli.txtCodCli.Enabled = true;

                btnAgrActProc.Enabled = false;
                btnQuitActProc.Enabled = false;

                txtDetActProc.Enabled = false;
                cboEncAud.Enabled = false;

                cboEstProcJud.Enabled = false;
                cboJuzgado.Enabled = false;
                cboJuez.Enabled = false;
                cboSecretario.Enabled = false;
                cboAbogado.Enabled = false;
                cboTipoProcJud.Enabled = false;
                cboTipMedJud.Enabled = false;

                btnNuevo.Enabled = false;
                btnCancelar.Enabled = false;
                btnEditar.Enabled = false;
                btnGrabar.Enabled = false;
                cboTipoActoProcesal1.Enabled = false;
                cboTipoPersonaEjecActProc1.Enabled = false;
            }
            else if (nOpcion == 2) //Nuevo
            {
                conBusCli.txtCodCli.Enabled = true;

                btnAgrActProc.Enabled = true;
                btnQuitActProc.Enabled = true;

                dtgActProc.ReadOnly = false;

                txtDetActProc.Enabled = true;
                cboEncAud.Enabled = true;

                cboEstProcJud.Enabled = false;
                cboJuzgado.Enabled = false;
                cboJuez.Enabled = false;
                cboSecretario.Enabled = false;
                cboAbogado.Enabled = false;
                cboTipoProcJud.Enabled = false;
                cboTipMedJud.Enabled = false;

                btnNuevo.Enabled = false;
                btnCancelar.Enabled = true;
                btnEditar.Enabled = false;
                btnGrabar.Enabled = true;
                cboTipoActoProcesal1.Enabled = true;
                cboTipoActoProcesal1.SelectedIndex = -1;
                cboTipoPersonaEjecActProc1.Enabled = true;
                cboTipoPersonaEjecActProc1.SelectedIndex = -1;

                dtgActProc.Columns["cWinUser"].Visible = false;
            }
            else if (nOpcion == 3) //Editar
            {
                conBusCli.txtCodCli.Enabled = false;

                btnAgrActProc.Enabled = true;
                btnQuitActProc.Enabled = true;

                dtgActProc.ReadOnly = false;

                txtDetActProc.Enabled = true;
                cboEncAud.Enabled = true;

                cboEstProcJud.Enabled = false;
                cboJuzgado.Enabled = false;
                cboJuez.Enabled = false;
                cboSecretario.Enabled = false;
                cboAbogado.Enabled = false;
                cboTipoProcJud.Enabled = false;
                cboTipMedJud.Enabled = false;

                btnNuevo.Enabled = false;
                btnCancelar.Enabled = true;
                btnEditar.Enabled = false;
                btnGrabar.Enabled = true;
                cboTipoActoProcesal1.Enabled = true;
                cboTipoPersonaEjecActProc1.Enabled = true;

                dtgActProc.Columns["cWinUser"].Visible = false;
                dtgActProc.Columns["dFecha"].ReadOnly = true;
                dtgActProc.Columns["dFecVenc"].ReadOnly = true;
            }
            else if (nOpcion == 4) // Grabar
            {
                conBusCli.txtCodCli.Enabled = false;

                btnAgrActProc.Enabled = false;
                btnQuitActProc.Enabled = false;

                dtgActProc.ReadOnly = true;

                txtDetActProc.Enabled = false;
                cboEncAud.Enabled = false;

                cboEstProcJud.Enabled = false;
                cboJuzgado.Enabled = false;
                cboJuez.Enabled = false;
                cboSecretario.Enabled = false;
                cboAbogado.Enabled = false;
                cboTipoProcJud.Enabled = false;
                cboTipMedJud.Enabled = false;

                btnNuevo.Enabled = false;
                btnCancelar.Enabled = true;
                btnEditar.Enabled = false;
                btnGrabar.Enabled = false;
                cboTipoActoProcesal1.Enabled = false;
                cboTipoPersonaEjecActProc1.Enabled = false;
            }
        }

        private void LimpiarComponentes()
        {
            txtNroProc.Text = "";
            txtNroExp.Text = "";
            dtgActProc.DataSource = null;
            txtDetActProc.Text = "";
            cboEncAud.SelectedIndex = -1;
            cboJuzgado.SelectedIndex = -1;
            cboJuez.SelectedIndex = -1;
            cboSecretario.SelectedIndex = -1;
            cboAbogado.SelectedIndex = -1;
            txtAbogContr.Text = "";
            cboTipoProcJud.SelectedIndex = -1;
            cboTipMedJud.SelectedIndex = -1;
            cboEstProcJud.SelectedIndex = -1;
            cboTipoActoProcesal1.SelectedIndex = -1;
            cboTipoPersonaEjecActProc1.SelectedIndex = -1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dtgActProc.Columns.Clear();

            CalendarColumn dtpFecRecepcion = new CalendarColumn();
            dtpFecRecepcion.Name = "dtpFecRecepcion";
            dtpFecRecepcion.DataPropertyName = "dFecRecepcion";
            TimePickerColumn dtpHora = new TimePickerColumn();
            dtpHora.Name = "dtpHora";
            dtpHora.DataPropertyName = "dHora";

            dtgActProc.Columns.Add(dtpFecRecepcion);
            dtgActProc.Columns.Add(dtpHora);

            dtActProc = objProcJud.BusActProc(0);

            dtActProc.DefaultView.RowFilter = ("lVigente <> 0");
            dtgActProc.DataSource = dtActProc;
            FormatoGridViewActProc();

            txtDetActProc.DataBindings.Add("Text", dtActProc, "cDetActProc", false, DataSourceUpdateMode.OnPropertyChanged);
            cboEncAud.DataBindings.Add("SelectedValue", dtActProc, "idEncargAud", false, DataSourceUpdateMode.OnPropertyChanged);

            Habilitar(2);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtDetActProc.DataBindings.Clear();
            cboEncAud.DataBindings.Clear();
            Habilitar(1);
            conBusCli.btnBusCliente.Enabled = true;
            conBusCli.txtCodCli.Focus();
        }

        private void dtgActProc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dtgActProc.CurrentCell.OwningColumn.Name == "nNroDias")
                {
                    dtgActProc.CurrentRow.Cells["dFecVenc"].Value = Convert.ToDateTime(dtgActProc.CurrentRow.Cells["dtpFecRecepcion"].Value)
                                                                    .AddDays(Convert.ToInt32(dtgActProc.CurrentRow.Cells["nNroDias"].Value));
                }
            }
        }

        private void txtDetActProc_Leave(object sender, EventArgs e)
        {
            dtgActProc.CurrentRow.Cells["cDetActProc"].Value = txtDetActProc.Text;
        }

        private void cboTipoActoProcesal1_Leave(object sender, EventArgs e)
        {
            dtgActProc.CurrentRow.Cells["idTipoActoProcesal"].Value = cboTipoActoProcesal1.SelectedValue;
        }

        private void cboTipoPersonaEjecActProc1_Leave(object sender, EventArgs e)
        {
            dtgActProc.CurrentRow.Cells["idTipoPersonaEjec"].Value = cboTipoPersonaEjecActProc1.SelectedValue;
        }

        private void tabActProc_Click(object sender, EventArgs e)
        {

        }

    }
}
