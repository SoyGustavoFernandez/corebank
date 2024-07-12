using EntityLayer;
using GEN.ControlesBase;
using SER.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SER.Presentacion
{
    public partial class frmMantDeTarifarioGiro : frmBase
    {

        #region Variables

        String cTituloMensajes = "Mantenimiento de tarifario";

        int idGiroTarifario = 0;

        private clsCNControlServ objCNControlServ = new clsCNControlServ();

        #endregion


        #region Constructor

        public frmMantDeTarifarioGiro()
        {
            InitializeComponent();
        }

        #endregion
        

        #region Eventos

        private void frmMantDeTarifarioGiro_Load(object sender, EventArgs e)
        {
            cboMontos.CargarMontos(9);

            DataTable dataTable = objCNControlServ.CNObtenerTarifario();
            dtgTarifario.DataSource = dataTable;
    
            establecerPropiedades();
            
            formatearDtgTarifario();

            estadoFormulario(0);

        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (lCamposSonValidos() == false) return;

            DataTable respuesta;

            if (idGiroTarifario != 0) 
            { 
                respuesta = objCNControlServ.CNActualizarTarifario(
                    idGiroTarifario,
                    Convert.ToInt32(chcEstado.Checked),
                    clsVarGlobal.User.idUsuario
                );
            }
            else
            {
                respuesta = objCNControlServ.CNRegistrarTarifario(

                    Convert.ToInt32(cboMoneda.SelectedValue),
                    Convert.ToInt32(cboTipoPersona.SelectedValue),
                    Convert.ToInt32(cboTipoComisionGiro.SelectedValue),
                    Convert.ToInt32(cboTipoGiroTarifario.SelectedValue),
                    Convert.ToInt32(cboMontos.SelectedValue),
                    Convert.ToDecimal(txtMontoComision.Text),
                    Convert.ToInt32(chcEstado.Checked),
                    clsVarGlobal.User.idUsuario
                );
            }
            
            if (respuesta.Rows.Count > 0)
            { 
                if (respuesta.Rows[0]["idError"].ToString() == "0")
                {
                    MessageBox.Show(respuesta.Rows[0]["cMensaje"].ToString(), cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DataTable dataTable = objCNControlServ.CNObtenerTarifario();

                    dtgTarifario.DataSource = dataTable;

                    establecerPropiedades();

                    formatearDtgTarifario(); 
                }
                else
                {
                    MessageBox.Show(respuesta.Rows[0]["cMensaje"].ToString(), cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

            limpiarCampos();

            estadoFormulario(0);

            dtgTarifario.CurrentCell = dtgTarifario[0, dtgTarifario.RowCount-1];

            establecerDatosVariable();
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            this.idGiroTarifario = 0;
            limpiarCampos();
            estadoFormulario(1);
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            estadoFormulario(0);
            limpiarCampos();
            establecerDatosVariable();
        }

        private void dtgTarifario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgTarifario_SelectionChanged(sender, e);
        }

        private void dtgTarifario_SelectionChanged(object sender, EventArgs e)
        {
            establecerDatosVariable();
            estadoFormulario(0);
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            estadoFormulario(2);
        }

        #endregion


        #region Métodos

        private void estadoFormulario(int idEstadoFormulario)
        {
            switch (idEstadoFormulario)
            {
                case 0:
                    grbMantenimientoTarifario.Enabled = false;
                    btnNuevo1.Enabled = true;
                    btnGrabar1.Enabled = false;
                    btnEditar1.Enabled = true;
                    btnCancelar1.Enabled = false;
                    break;

                case 1:
                    grbMantenimientoTarifario.Enabled = true;

                    cboMoneda.Enabled = true;
                    cboTipoPersona.Enabled = true;
                    cboTipoComisionGiro.Enabled = true;
                    cboTipoGiroTarifario.Enabled = true;
                    cboMontos.Enabled = true;
                    txtMontoComision.Enabled = true;

                    btnNuevo1.Enabled = false;
                    btnGrabar1.Enabled = true;
                    btnEditar1.Enabled = false;
                    btnCancelar1.Enabled = true;
                    break;
                case 2:
                    grbMantenimientoTarifario.Enabled = true;

                    cboMoneda.Enabled = false;
                    cboTipoPersona.Enabled = false;
                    cboTipoComisionGiro.Enabled = false;
                    cboTipoGiroTarifario.Enabled = false;
                    cboMontos.Enabled = false;
                    txtMontoComision.Enabled = false;

                    btnNuevo1.Enabled = false;
                    btnGrabar1.Enabled = true;
                    btnEditar1.Enabled = true;
                    btnCancelar1.Enabled = true;
                    break;
            }
        }

        private void formatearDtgTarifario()
        {

            foreach (DataGridViewColumn column in dtgTarifario.Columns)
            {
                column.Visible = false;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dtgTarifario.Columns["cMoneda"].Visible = true;
            dtgTarifario.Columns["cTipoPersona"].Visible = true;
            dtgTarifario.Columns["cTipoComision"].Visible = true;
            dtgTarifario.Columns["cDesTipoGiroTarifario"].Visible = true;
            dtgTarifario.Columns["cMonto"].Visible = false;
            dtgTarifario.Columns["nMontoMinimo"].Visible = true;
            dtgTarifario.Columns["nMontoMaximo"].Visible = true;
            dtgTarifario.Columns["nMontoComision"].Visible = true;
            dtgTarifario.Columns["lVigente"].Visible = true;


            dtgTarifario.Columns["cMoneda"].HeaderText = "Tipo de moneda";
            dtgTarifario.Columns["cTipoPersona"].HeaderText = "Tipo de persona";
            dtgTarifario.Columns["cDesTipoGiroTarifario"].HeaderText = "Tipo de tarifario";
            dtgTarifario.Columns["nMontoMinimo"].HeaderText = "Monto mínimo";
            dtgTarifario.Columns["nMontoMaximo"].HeaderText = "Monto máximo";
            dtgTarifario.Columns["cTipoComision"].HeaderText = "Tipo de comisión";
            dtgTarifario.Columns["nMontoComision"].HeaderText = "Monto de comisión";
            dtgTarifario.Columns["lVigente"].HeaderText = "Vigencia del tarifario";

            int nOrden = 1;
            dtgTarifario.Columns["cMoneda"].DisplayIndex = nOrden++;
            dtgTarifario.Columns["cTipoPersona"].DisplayIndex = nOrden++;
            dtgTarifario.Columns["cTipoComision"].DisplayIndex = nOrden++;
            dtgTarifario.Columns["cDesTipoGiroTarifario"].DisplayIndex = nOrden++;
            dtgTarifario.Columns["nMontoMinimo"].DisplayIndex = nOrden++;
            dtgTarifario.Columns["nMontoMaximo"].DisplayIndex = nOrden++;
            dtgTarifario.Columns["nMontoComision"].DisplayIndex = nOrden++;
            dtgTarifario.Columns["lVigente"].DefaultCellStyle.Format = "N";
        }
        
        private void establecerPropiedades()
        {
            dtgTarifario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgTarifario.AllowUserToResizeColumns = false;
            dtgTarifario.AllowUserToResizeRows = false;
            dtgTarifario.AllowUserToAddRows = false;
            dtgTarifario.AllowUserToDeleteRows = false;
            dtgTarifario.MultiSelect = false;
        }

        private void limpiarCampos()
        {
            this.cboMoneda.SelectedIndex = 0;
            this.cboTipoPersona.SelectedIndex = 0;
            this.cboTipoComisionGiro.SelectedIndex = 0;
            this.cboTipoGiroTarifario.SelectedIndex = 0;
            this.cboMontos.SelectedIndex = 0;
            this.txtMontoComision.Clear();

            this.chcEstado.Checked = true;
        }

        private void establecerDatosVariable()
        {
            if (dtgTarifario.RowCount > 0 && dtgTarifario.SelectedRows.Count > 0 && dtgTarifario.CurrentRow != null)
            {
                this.idGiroTarifario = Convert.ToInt32(dtgTarifario.CurrentRow.Cells["idGiroTarifario"].Value);

                this.cboMoneda.SelectedValue = Convert.ToInt32(this.dtgTarifario.CurrentRow.Cells["idMoneda"].Value);
                this.cboTipoPersona.SelectedValue = Convert.ToInt32(this.dtgTarifario.CurrentRow.Cells["idTipoPersona"].Value);
                this.cboTipoComisionGiro.SelectedValue = Convert.ToInt32(this.dtgTarifario.CurrentRow.Cells["idTipComGiro"].Value);
                this.cboTipoGiroTarifario.SelectedValue = Convert.ToInt32(this.dtgTarifario.CurrentRow.Cells["idGiroTarifarioTipo"].Value);
                this.cboMontos.SelectedValue = Convert.ToInt32(this.dtgTarifario.CurrentRow.Cells["idMonto"].Value);

                this.txtMontoComision.Text = Convert.ToString(Convert.ToDecimal(this.dtgTarifario.CurrentRow.Cells["nMontoComision"].Value));
                this.chcEstado.Checked = Convert.ToBoolean(this.dtgTarifario.CurrentRow.Cells["lVigente"].Value);
            }
        }

        private Boolean lCamposSonValidos()
        {

            //=====================================================
            // Verificació de los campos
            //=====================================================

            List<string> mensajesErrorEmpty = new List<string>();

            if (string.IsNullOrEmpty(txtMontoComision.Text))
                mensajesErrorEmpty.Add("Debe ingresar el monto de la comisión");

            if (mensajesErrorEmpty.Count > 0)
            {
                string mensajeFinal = string.Join(Environment.NewLine, mensajesErrorEmpty);
                MessageBox.Show(mensajeFinal, this.cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //=====================================================
            // Verificación de datos ingresados en los campos
            //=====================================================

            List<string> mensajesErrorIncorrect = new List<string>();

            DataTable respuesta = objCNControlServ.CNVerificarTarifario(idGiroTarifario,
                                                                          Convert.ToInt32(cboTipoGiroTarifario.SelectedValue),
                                                                          Convert.ToInt32(cboMontos.SelectedValue),
                                                                          Convert.ToInt32(cboMoneda.SelectedValue),
                                                                          Convert.ToInt32(cboTipoPersona.SelectedValue)
                                                                      );

            if (respuesta.Rows[0]["idError"].ToString() == "1")
                mensajesErrorIncorrect.Add(respuesta.Rows[0]["cMensaje"].ToString());

            if (Convert.ToDecimal(txtMontoComision.Text) < 0.00m)
                mensajesErrorIncorrect.Add("El monto de la comisión no debe de ser negativo.");

            if (mensajesErrorIncorrect.Count > 0)
            {
                string mensajeFinal = string.Join(Environment.NewLine, mensajesErrorIncorrect);
                MessageBox.Show(mensajeFinal, this.cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion
    }
}
