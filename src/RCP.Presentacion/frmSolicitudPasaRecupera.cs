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
using System.Net.Mail;
using System.Net;
using GEN.CapaNegocio;

namespace RCP.Presentacion
{
    public partial class frmSolicitudPasaRecupera : frmBase
    {
        #region Variables

        GEN.CapaNegocio.clsCNCredito gencredito = new GEN.CapaNegocio.clsCNCredito();
        CRE.CapaNegocio.clsCNCredito cncredito = new CRE.CapaNegocio.clsCNCredito();
        clsCNSolicitudRecuperacion solicitud = new clsCNSolicitudRecuperacion();
        int idSeleccion = -1;

        #endregion

        public frmSolicitudPasaRecupera()
        {
            InitializeComponent();
        }

        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            estadoControles(1);
        }

        private void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            cargarCreditos();
        }

        private void dtgCreditos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idSeleccion = e.RowIndex;
                conDatCredito1.limpiarcontroles();
                if (dtgCreditos.Rows.Count > 0)
                {
                    conDatCredito1.cargardatoscredito(Convert.ToInt32(dtgCreditos.Rows[e.RowIndex].Cells["idCuenta"].Value));
                    if (Convert.ToBoolean(dtgCreditos.Rows[e.RowIndex].Cells["lRecupera"].Value) || Convert.ToBoolean(dtgCreditos.Rows[e.RowIndex].Cells["lSolicitado"].Value))
                    {
                        estadoControles(4);
                    }
                    else
                    {
                        estadoControles(3);
                    }

                    if (Convert.ToBoolean(dtgCreditos.Rows[e.RowIndex].Cells["lSolicitado"].Value))
                    {
                        cboMotivoMora1.SelectedValue = Convert.ToInt32(dtgCreditos.Rows[e.RowIndex].Cells["idMotivoMora"].Value);
                        txtOpinionTransferencia.Text = dtgCreditos.Rows[e.RowIndex].Cells["cOpinion"].Value.ToString();
                        txtObservaciones.Text = dtgCreditos.Rows[e.RowIndex].Cells["cObservacion"].Value.ToString();
                    }
                }
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            estadoControles(1);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                btnGrabar1.Enabled = false;

                int idCuenta = Convert.ToInt32(dtgCreditos.Rows[idSeleccion].Cells["idCuenta"].Value);
                solicitud.InsertarSolicitudRecuperacion(idCuenta,/*Solicitado*/1, clsVarGlobal.dFecSystem,
                                                        clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem,
                                                        clsVarGlobal.User.idUsuario, conBusCli1.idCli,
                                                        Convert.ToInt32(cboMotivoMora1.SelectedValue), txtObservaciones.Text, txtOpinionTransferencia.Text);
                MessageBox.Show("La solicitud se registró correctamente", "Registro de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargarCreditos();
            }
        }

        #endregion

        #region Metodos

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
            dtgCreditos.Columns["nProvisionSoles"].Visible = true;
            dtgCreditos.Columns["lRecupera"].Visible = true;
            dtgCreditos.Columns["lSolicitado"].Visible = true;
            dtgCreditos.Columns["cProducto"].Visible = true;

            dtgCreditos.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgCreditos.Columns["dFechaDesembolso"].HeaderText = "Fecha Des.";
            dtgCreditos.Columns["cEstado"].HeaderText = "Estado";
            dtgCreditos.Columns["nAtraso"].HeaderText = "Atraso";
            dtgCreditos.Columns["nSalTot"].HeaderText = "Saldo Total";
            dtgCreditos.Columns["nProvisionSoles"].HeaderText = "Prov. Soles";
            dtgCreditos.Columns["cProducto"].HeaderText = "Producto";

            dtgCreditos.Columns["lRecupera"].HeaderText = "En Recuperación";
            dtgCreditos.Columns["lSolicitado"].HeaderText = "Solicitado";

            Font font = new Font(dtgCreditos.DefaultCellStyle.Font.FontFamily, dtgCreditos.DefaultCellStyle.Font.Size, FontStyle.Bold);

            dtgCreditos.Columns["idCuenta"].DefaultCellStyle.Font = font;
            dtgCreditos.Columns["nAtraso"].DefaultCellStyle.Font = font;

            dtgCreditos.Columns["idCuenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgCreditos.Columns["nProvisionSoles"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nSalTot"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nProvisionSoles"].DefaultCellStyle.Format = "N2";
            dtgCreditos.Columns["nSalTot"].DefaultCellStyle.Format = "N2";

            dtgCreditos.Columns["idCuenta"].Width = 60;
            dtgCreditos.Columns["dFechaDesembolso"].Width = 75;
            dtgCreditos.Columns["cEstado"].Width = 75;
            dtgCreditos.Columns["nAtraso"].Width = 50;
            dtgCreditos.Columns["nSalTot"].Width = 90;
            dtgCreditos.Columns["nProvisionSoles"].Width = 90;
            dtgCreditos.Columns["cProducto"].Width = 140;
        }

        private bool validar()
        {
            bool lVal = false;

            if (cboMotivoMora1.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione motivo de mora", "Validación de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }

            if (txtOpinionTransferencia.Text.Length <= 0)
            {
                MessageBox.Show("Ingrese la opinión de transferencia", "Validación de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }

            if (txtObservaciones.Text.Length <= 0)
            {
                MessageBox.Show("Ingrese las observaciones", "Validación de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }

            if (dtgCreditos.Rows.Count < 0)
            {
                MessageBox.Show("Por favor seleccione la cuenta de crédito", "Validación de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }

            if (Convert.ToBoolean(dtgCreditos.SelectedRows[0].Cells["lRecupera"].Value)==true)
            {
                MessageBox.Show("Crédito ya se encuentra en recuperación", "Validación de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }

            if (Convert.ToBoolean(dtgCreditos.SelectedRows[0].Cells["lSolicitado"].Value) == true)
            {
                MessageBox.Show("Crédito ya fue solicitado su paso a recuperaciones", "Validación de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }

            lVal = true;
            return lVal;
        }

        private void cargarCreditos()
        {
            idSeleccion = -1;
            if (conBusCli1.idCli > 0)
            {
                var dtCreditos = solicitud.LisCreRecuperaxCli(conBusCli1.idCli);
                if (dtCreditos.Rows.Count > 0)
                {
                    dtgCreditos.DataSource = dtCreditos;
                    formatoGridCreditos();
                    conDatCredito1.cargardatoscredito(Convert.ToInt32(dtgCreditos.SelectedRows[0].Cells["idCuenta"].Value));
                    dtgCreditos.Rows[0].Selected = true;
                }
                else
                {
                    estadoControles(2);
                }
            }
        }

        private void estadoControles(int idEstado)
        {
            switch (idEstado)
            {
                case 1://caso inicial
                    btnGrabar1.Enabled = false;
                    btnCancelar1.Enabled = false;
                    grbInforme.Enabled = false;
                    dtgCreditos.Enabled = false;

                    conBusCli1.Enabled = true;
                    conBusCli1.limpiarControles();
                    conBusCli1.btnBusCliente.Enabled = true;
                    conBusCli1.txtCodCli.Enabled = true;
                    conBusCli1.txtCodCli.Focus();

                    limpiarControlesInforme();

                    dtgCreditos.DataSource = null;
                    conDatCredito1.limpiarcontroles();
                    break;
                case 2:
                    btnGrabar1.Enabled = false;
                    btnCancelar1.Enabled = true;
                    grbInforme.Enabled = false;
                    dtgCreditos.Enabled = false;

                    conBusCli1.Enabled = false;

                    limpiarControlesInforme();
                    break;
                case 3:
                    btnGrabar1.Enabled = true;
                    btnCancelar1.Enabled = true;
                    grbInforme.Enabled = true;
                    dtgCreditos.Enabled = true;

                    conBusCli1.Enabled = false;

                    limpiarControlesInforme();
                    break;
                case 4:
                    btnGrabar1.Enabled = false;
                    btnCancelar1.Enabled = true;
                    grbInforme.Enabled = false;
                    dtgCreditos.Enabled = true;
                    conBusCli1.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void limpiarControlesInforme()
        {
            cboMotivoMora1.SelectedIndex = -1;
            txtObservaciones.Clear();
            txtOpinionTransferencia.Clear();
        }

        #endregion

    }
}