using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using RCP.CapaNegocio;
using CLI.CapaNegocio;

namespace RCP.Presentacion
{
    public partial class frmRegistroVisita : frmBase
    {
        #region Variables Globales

        clsCNEventoRecupera eventorecupera = new clsCNEventoRecupera();
        CRE.CapaNegocio.clsCNCredito cncredito = new CRE.CapaNegocio.clsCNCredito();
        GEN.CapaNegocio.clsCNDirecCli cndireccioncli = new GEN.CapaNegocio.clsCNDirecCli();
        clsCNRetDatosCliente cndatoscliente = new clsCNRetDatosCliente();
        GEN.CapaNegocio.clsCNUbigeo cnubigeo = new GEN.CapaNegocio.clsCNUbigeo();
        GEN.CapaNegocio.clsCNAgencia cnagencia = new GEN.CapaNegocio.clsCNAgencia();

        #endregion

        public frmRegistroVisita()
        {
            InitializeComponent();
        }

        public frmRegistroVisita(int idCli)
        {
            InitializeComponent();
            conBusCli1.idCli = idCli;
            conBusCli1.CargardatosCli(conBusCli1.idCli);
            conBusCli1.Enabled = false;
            cargardatos();
        }

        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            dtpProxContacto.Value = clsVarGlobal.dFecSystem;
            dtpHoraProx.Value = clsVarGlobal.dFecSystem;
            if(conBusCli1.idCli ==  0)
                limpiarControles();
            
            dtpProxContacto.MaxDate = lastDayOfMonthFromDateTime(clsVarGlobal.dFecSystem);
            dtpProxContacto.MinDate = clsVarGlobal.dFecSystem;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiarControles();
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            cargardatos();
        }


        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            if (dtgCreditos.Rows.Count > 0)
            {
                conBusCli1.Enabled = false;
                cboTipoEventoRecupera1.Enabled = true;
                cboTipoRespuestaRecuperacion1.Enabled = true;
                cboProcesoRecupera1.Enabled = false;
                cboMotivoRecupera1.Enabled = true;
                cboContactoRecupera1.Enabled = true;
                cboTipoEfecto1.Enabled = true;
                txtTelefCel1.Enabled = true;
                txtTelefFijo1.Enabled = true;
                txtObservaciones.Enabled = true;
                btnGrabar1.Enabled = true;
                btnNuevo1.Enabled = false;
                dtgCreditos.Enabled = true;
                dtpProxContacto.Enabled = true;
                dtpHoraProx.Enabled = true;
                txtMontoMovilidad.Enabled = true;
                chcProxContacto.Enabled = true;
                chcProxContacto.Checked = true;
                txtMontoMovilidad.Text = "0.00";
                txtOrigen.Enabled = true;
                txtDestino.Enabled = true;
                asignarArea();
                cboTipoEventoRecupera1.SelectedIndex = -1;
                cboTipoRespuestaRecuperacion1.SelectedIndex = -1;
                cboMotivoRecupera1.SelectedIndex = -1;
                cboContactoRecupera1.SelectedIndex = -1;
                cboTipoEfecto1.SelectedIndex = -1;
                txtTelefCel1.Clear();
                txtMontoMovilidad.Text = "0.00";
                txtOrigen.Clear();
                txtDestino.Clear();
                txtTelefFijo1.Clear();
                chcProxContacto.Checked = false;
                dtpProxContacto.Value = clsVarGlobal.dFecSystem;
                dtpHoraProx.Value = clsVarGlobal.dFecSystem;
                txtObservaciones.Clear();
            }
            else
            {
                MessageBox.Show("Cliente seleccionado no tiene cuentas de crédito vigentes", "Validación de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                int idCuenta=Convert.ToInt32(dtgCreditos.Rows[dtgCreditos.SelectedCells[0].RowIndex].Cells["idCuenta"].Value);
                eventorecupera.InsertarEventoRecupera(Convert.ToInt32(cboProcesoRecupera1.SelectedValue),
                                                   Convert.ToInt32(cboTipoEventoRecupera1.SelectedValue), Convert.ToInt32(cboTipoEfecto1.SelectedValue),clsVarGlobal.dFecSystem,
                                                   clsVarGlobal.User.idUsuario,Convert.ToInt32(cboContactoRecupera1.SelectedValue), Convert.ToInt32(cboMotivoRecupera1.SelectedValue),
                                                   txtTelefFijo1.Text.Trim() + "-" +txtTelefCel1.Text.Trim(),dtpProxContacto.Value,txtObservaciones.Text.Trim(),
                                                   conBusCli1.idCli, idCuenta, dtpHoraProx.Value.ToShortTimeString(),
                                                   chcProxContacto.Checked,txtMontoMovilidad.nDecValor,txtOrigen.Text.Trim(),txtDestino.Text.Trim(),
                                                   Convert.ToInt32(cboTipoRespuestaRecuperacion1.SelectedValue));
                MessageBox.Show("Los datos se guardaron correctamente", "Registro de Evento", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cboTipoEventoRecupera1.Enabled = false;
                cboTipoRespuestaRecuperacion1.Enabled = false;
                cboProcesoRecupera1.Enabled = false;
                cboMotivoRecupera1.Enabled = false;
                cboContactoRecupera1.Enabled = false;
                cboTipoEfecto1.Enabled = false;
                txtTelefCel1.Enabled = false;
                txtTelefFijo1.Enabled = false;
                txtObservaciones.Enabled = false;
                dtgCreditos.Enabled = false;
                dtpProxContacto.Enabled = false;
                dtpHoraProx.Enabled = false;
                chcProxContacto.Enabled = false;
                txtMontoMovilidad.Enabled = false;
                txtOrigen.Enabled = false;
                txtDestino.Enabled = false;
                btnGrabar1.Enabled = false;
                btnNuevo1.Enabled = true;
            }
        }

        public DateTime lastDayOfMonthFromDateTime(DateTime dateTime)
        {
            DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
            return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
        }

        private void dtpProxContacto_ValueChanged(object sender, EventArgs e)
        {
            if ((dtpProxContacto.Value - clsVarGlobal.dFecSystem).Ticks < 0)
            {
                MessageBox.Show("Debe seleccionar una fecha válida", "Validación de fecha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpProxContacto.Value = clsVarGlobal.dFecSystem;
            }

            if (lastDayOfMonthFromDateTime(clsVarGlobal.dFecSystem) < dtpProxContacto.Value)
            {
                MessageBox.Show("Debe seleccionar una fecha válida dentro del MES actual", "Validación de fecha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpProxContacto.Value = clsVarGlobal.dFecSystem;
            }
        }

        private void chcProxContacto_CheckedChanged(object sender, EventArgs e)
        {
            if (chcProxContacto.Checked)
            {
                dtpHoraProx.Enabled = true;
                dtpProxContacto.Enabled = true;
            }
            else
            {
                dtpProxContacto.Value = clsVarGlobal.dFecSystem;
                dtpHoraProx.Enabled = false;
                dtpProxContacto.Enabled = false;
            }
        }

        private void cboTipoEventoRecupera1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cboTipoEventoRecupera1.SelectedValue is DataRowView))
            {
                if (cboTipoEventoRecupera1.SelectedIndex > -1)
                {
                    if (Convert.ToInt32(cboTipoEventoRecupera1.SelectedValue).In(1, 5))//Para visita y operativo
                    {
                        lblMovilidad.Visible = true;
                        txtMontoMovilidad.Visible = true;
                        txtMontoMovilidad.Text = "0.00";

                        lblOrigen.Visible = true;
                        txtOrigen.Visible = true;
                        lblDestino.Visible = true;
                        txtDestino.Visible = true;
                        asignarOrigenDestino();
                    }
                    else
                    {
                        lblMovilidad.Visible = false;
                        txtMontoMovilidad.Visible = false;
                        txtMontoMovilidad.Text = "0.00";
                        lblOrigen.Visible = false;
                        txtOrigen.Visible = false;
                        txtOrigen.Text = "";
                        lblDestino.Visible = false;
                        txtDestino.Visible = false;
                        txtDestino.Text = "";
                    }
                }
            }
        }


        #endregion

        #region Metodos

        private bool validarCampos()
        {
            bool lval = false;

            if (conBusCli1.idCli==0)
            {
                MessageBox.Show("Debe seleccionar a un cliente válido", "Validación de cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lval;
            }

            if (cboTipoEventoRecupera1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar la acción realizada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoEventoRecupera1.Focus();
                return lval;
            }

            if (cboMotivoRecupera1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el motivo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMotivoRecupera1.Focus();
                return lval;
            }

            if (cboContactoRecupera1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el contacto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboContactoRecupera1.Focus();
                return lval;
            }

            if (cboTipoEfecto1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el resultado obtenido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoEfecto1.Focus();
                return lval;
            }

            if (cboTipoRespuestaRecuperacion1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el Tipo de Respuesta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoRespuestaRecuperacion1.Focus();
                return lval;
            }


            lval = true;
            return lval;
        }

        private void cargardatos()
        {
            if (conBusCli1.idCli > 0)
            {
                var dtCreditos = cncredito.CNdtLisCrexCli(conBusCli1.idCli);

                var dtCreditosActivos = dtCreditos.Clone();

                (from item in dtCreditos.AsEnumerable()
                where item["cEstado"].ToString() == "ACTIVO"
                select item).CopyToDataTable(dtCreditosActivos, LoadOption.OverwriteChanges);

                if (dtCreditosActivos.Rows.Count > 0)
                {
                    dtgCreditos.DataSource = dtCreditosActivos;
                    formatoGridCreditos();
                    btnNuevo1.Enabled = true;
                    asignarOrigenDestino();
                }
                else
                {
                    btnNuevo1.Enabled = false;
                }
            }
            else
            {
                btnNuevo1.Enabled = false;
            }
        }

        private void formatoGridCreditos()
        {
            foreach (DataGridViewColumn columna in dtgCreditos.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                columna.Visible = false;
            }


            dtgCreditos.Columns["idCuenta"].Visible = true;
            dtgCreditos.Columns["dFechaDesembolso"].Visible = true;
            dtgCreditos.Columns["cEstado"].Visible = true;
            dtgCreditos.Columns["nAtraso"].Visible = true;
            dtgCreditos.Columns["nSalTot"].Visible = true;
            dtgCreditos.Columns["nTotSalVEn"].Visible = true;
            dtgCreditos.Columns["nTotCuoVen"].Visible = true;
            dtgCreditos.Columns["cMoneda"].Visible = true;

            dtgCreditos.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgCreditos.Columns["dFechaDesembolso"].HeaderText = "Fecha Des.";
            dtgCreditos.Columns["cEstado"].HeaderText = "Estado";
            dtgCreditos.Columns["nAtraso"].HeaderText = "Atraso";
            dtgCreditos.Columns["nSalTot"].HeaderText = "Saldo";
            dtgCreditos.Columns["nTotSalVEn"].HeaderText = "Saldo Vencido";
            dtgCreditos.Columns["nTotCuoVen"].HeaderText = "Cuotas Vencidas";
            dtgCreditos.Columns["cMoneda"].HeaderText = "Moneda";

            dtgCreditos.Columns["nSalTot"].DefaultCellStyle.Format = "N2";
            dtgCreditos.Columns["nTotSalVEn"].DefaultCellStyle.Format = "N2";

            dtgCreditos.Columns["nSalTot"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nTotSalVEn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nTotCuoVen"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgCreditos.Columns["nAtraso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void limpiarControles()
        {
            cboProcesoRecupera1.SelectedIndex = -1;
            cboTipoEventoRecupera1.SelectedIndex = -1;
            cboTipoRespuestaRecuperacion1.SelectedIndex = -1;
            cboTipoEfecto1.SelectedIndex = -1;
            cboMotivoRecupera1.SelectedIndex = -1;
            cboContactoRecupera1.SelectedIndex = -1;

            conBusCli1.Enabled = true;
            conBusCli1.limpiarControles();
            conBusCli1.txtCodCli.Enabled = true;
            conBusCli1.txtCodCli.Focus();
            btnNuevo1.Enabled = false;
            btnGrabar1.Enabled = false;
            txtTelefCel1.Text = "";
            txtTelefFijo1.Text = "";
            txtObservaciones.Text = "";

            cboTipoEventoRecupera1.Enabled = false;
            cboTipoRespuestaRecuperacion1.Enabled = false;
            cboProcesoRecupera1.Enabled = false;
            cboMotivoRecupera1.Enabled = false;
            cboContactoRecupera1.Enabled = false;
            cboTipoEfecto1.Enabled = false;
            txtTelefCel1.Enabled = false;
            txtTelefFijo1.Enabled = false;
            txtObservaciones.Enabled = false;
            dtgCreditos.DataSource = null;
            dtgCreditos.Enabled = false;
            dtpProxContacto.Enabled = false;
            dtpHoraProx.Enabled = false;
            txtOrigen.Enabled = false;
            txtDestino.Enabled = false;
            txtMontoMovilidad.Enabled = false;

        }

        private void asignarOrigenDestino()
        {
            var dtDireccion= cndireccioncli.ListaDirCli(conBusCli1.idCli);
            var idUbigeoDirCli = Convert.ToInt32(dtDireccion.AsEnumerable().Where(x => (bool)x["lDirPrincipal"] == true).ToList()[0]["idUbigeo"]);
            txtDestino.Text = cnubigeo.ListarNombresUbig(0, 0, 0, idUbigeoDirCli).Rows[0][0].ToString();

            var idUbigeoAge = Convert.ToInt32(cnagencia.LisAgen().AsEnumerable().Where(x => (int)x["idAgencia"] == clsVarGlobal.nIdAgencia).ToList()[0]["idUbigeo"]);

            txtOrigen.Text = cnubigeo.ListarNombresUbig(0, 0, 0, idUbigeoAge).Rows[0][0].ToString();
        }


        public void asignarArea()
        {
            string[] cPerfilesNegocios = ((string)clsVarApl.dicVarGen["nPerfilesNegocios"]).Split(',');
            string[] cPerfilesRecuperaciones = ((string)clsVarApl.dicVarGen["nPerfilesRecuperaciones"]).Split(',');
            string[] cPerfilesJudicial = ((string)clsVarApl.dicVarGen["nPerfilesJudicial"]).Split(',');
            cboProcesoRecupera1.SelectedValue = 4;
            for (int i = 0; i < cPerfilesNegocios.Length; i++)
            {
                if (clsVarGlobal.PerfilUsu.idPerfil == Convert.ToInt32(cPerfilesNegocios[i]))
                {
                    cboProcesoRecupera1.SelectedValue = 1;
                    return;
                }
            }
            for (int i = 0; i < cPerfilesRecuperaciones.Length; i++)
            {
                if (clsVarGlobal.PerfilUsu.idPerfil == Convert.ToInt32(cPerfilesRecuperaciones[i]))
                {
                    cboProcesoRecupera1.SelectedValue = 2;
                    return;
                }
            }
            for (int i = 0; i < cPerfilesJudicial.Length; i++)
            {
                if (clsVarGlobal.PerfilUsu.idPerfil == Convert.ToInt32(cPerfilesJudicial[i]))
                {
                    cboProcesoRecupera1.SelectedValue = 3;
                    return;
                }
            }
        }

        #endregion


    }
}
