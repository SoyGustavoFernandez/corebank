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
    public partial class frmTasaEspecial : frmBase
    {
        DataTable tbDatosCuenta;
        DataTable tbDatosSolici;
        clsCNDeposito liberarCta = new clsCNDeposito();
        public int p_idCuenta = 0;

        public frmTasaEspecial()
        {
            InitializeComponent();
        }

        private void frmTasaEspecial_Load(object sender, EventArgs e)
        {
            conBusCtaAho.nTipOpe = 16; //--Antes 12;
            conBusCtaAho.idMoneda = 0;
            cboMotivos.CargarMotivos(3);
            cboPersSolicitud.PersTodasAgen();
            LimpiarControles();
            conBusCtaAho.idcuenta = 0;
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            conBusCtaAho.txtCodAge.Focus();
        }

        private void frmTasaEspecial_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (p_idCuenta != 0)
                liberarCta.CNUpdNoUsoCuenta(p_idCuenta);
        }

        private void conBusCtaAho1_ClicBusCta(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            liberarCta.CNUpdNoUsoCuenta(p_idCuenta);
            btnAceptar.Enabled = false;
            btnEnviar.Enabled = false;
            btnCancelar.Enabled = false;
            txtTasaEsp.Enabled = false;
            cboMotivos.Enabled = false;
            txtMotivoDetalle.Enabled = false;
            dtFecSolicitud.Enabled = false;
            cboPersSolicitud.Enabled = false;
            LimpiarControles();
            p_idCuenta = 0;
            conBusCtaAho.idcuenta = 0;
            conBusCtaAho.LimpiarControles();
            conBusCtaAho.btnBusCliente.Enabled = true;
            conBusCtaAho.HabDeshabilitarCtrl(true);
            conBusCtaAho.txtCodAge.Focus();
        }

        private void btnEnviar1_Click(object sender, EventArgs e)
        {
            if (conBusCtaAho.txtNroCta.Text.Trim() == "")
            {
                MessageBox.Show("Debe asignar una cuenta valida", "Solicitud para uso de Tasa Especial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(txtTasaEsp.Text.Trim()) )
            {
                MessageBox.Show("Ingrese la Tasa Especial", "Solicitud para uso de Tasa Especial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaEsp.Focus();
                return;
            }
            if (Convert.ToDecimal(txtTasaEsp.Text.Trim())<=0)
            {
                MessageBox.Show("El monto de la tasa no es válido...Verificar", "Solicitud para uso de Tasa Especial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaEsp.Focus();
                return;
            }
            if (Convert.ToDecimal(txtTasaEsp.Text.Trim()) > clsVarApl.dicVarGen["nMonMaxTasa"])
            {
                MessageBox.Show("El monto de la tasa no puede ser mayor, al maximo establecido:  "+clsVarApl.dicVarGen["nMonMaxTasa"].ToString(), "Solicitud para uso de Tasa Especial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaEsp.Focus();
                return;
            }
            if (cboMotivos.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar un motivo", "Solicitud para uso de Tasa Especial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtMotivoDetalle.Text.Length < 11)
            {
                MessageBox.Show("Debe asignar una breve descripción para el Motivo (Mín. 10 caracteres)", "Solicitud para uso de Tasa Especial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            string cPlazo = Convert.ToString(tbDatosCuenta.Rows[0]["nPlazoCta"]);
            string cSaldoDis = Convert.ToString(tbDatosCuenta.Rows[0]["nSaldoDis"]);
            string cMotivo = "(Saldo Disponible :"+cSaldoDis+", Plazo :"+cPlazo+")"+txtMotivoDetalle.Text;

            clsCNAutorTasaEsp solicitud = new clsCNAutorTasaEsp();
            solicitud.EnviarSolicitud(Convert.ToInt32(clsVarGlobal.nIdAgencia), Convert.ToInt32(conBusCtaAho.txtCodCli.Text), 54, 1, Convert.ToInt32(tbDatosCuenta.Rows[0]["idMoneda"]), Convert.ToInt32(tbDatosCuenta.Rows[0]["idProducto"]),
                                      (Convert.ToDecimal(txtTasaEsp.Text)), p_idCuenta, Convert.ToDateTime(dtFecSolicitud.Value),
                                      Convert.ToInt32(cboMotivos.SelectedValue), cMotivo, 1, Convert.ToDateTime("01/01/1900"), Convert.ToInt32(clsVarGlobal.User.idUsuario));
            MessageBox.Show("Su solicitud fue enviada correctamente", "Solicitud de Aplicación de Tasa Especial", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //lVigente=0, para la solicitud Rechazada anteriormente
            if (CBNewSol.Checked == true && CBNewSol.Visible == true)
            {
                solicitud.AnularSol(Convert.ToInt32(tbDatosSolici.Rows[0]["idSolAproba"]));
            }
            Buscar();
            dtgSolicitudes.Enabled = false;
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {            
            if (Convert.ToInt32(tbDatosSolici.Rows[0]["idEstadoSol"]) == 1)// ESTADO SOLICITADO
            {
                MessageBox.Show("No de puede realizar la Aplicación de Tasa Especial a esta Cuenta, ya que la Solicitud aún no ha sido APROBADA", "Solicitud para uso de Tasa Especial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (Convert.ToInt32(tbDatosSolici.Rows[0]["idEstadoSol"]) == 2)//ESTADO APROBADO
            {
                clsCNAutorTasaEsp Exoneracion = new clsCNAutorTasaEsp();
                Exoneracion.AplicarTasaEsp(Convert.ToDecimal(txtTasaEsp.Text), p_idCuenta, Convert.ToInt32(tbDatosSolici.Rows[0]["idSolAproba"]));

                MessageBox.Show("La Aplicación de Tasa Especial a esta Cuenta se realizó correctamente", "Solicitud para uso de Tasa Especial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Buscar();
                return;
            }

            if (Convert.ToInt32(tbDatosSolici.Rows[0]["idEstadoSol"]) == 4)//ESTADO RECHAZADO
            {
                MessageBox.Show("No se puede la Aplicación de Tasa Especial, su solicitud fue RECHAZADA", "Solicitud para uso de Tasa Especial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
            dtgSolicitudes.Enabled = false;
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            if (p_idCuenta != 0)
                liberarCta.CNUpdNoUsoCuenta(p_idCuenta);
        }

        private void btnExtorAprob_Click(object sender, EventArgs e)
        {
            frmListaSolTasaEspAprob frmLiSolApr = new frmListaSolTasaEspAprob();
            frmLiSolApr.ShowDialog();
            if (frmLiSolApr.idCuenta != 0)
            {
                this.conBusCtaAho.idcuenta = frmLiSolApr.idCuenta;
                this.conBusCtaAho.txtCodIns.Text = frmLiSolApr.cNroCuenta.Substring(0, 3);
                this.conBusCtaAho.txtCodAge.Text = frmLiSolApr.cNroCuenta.Substring(3, 3);
                this.conBusCtaAho.txtCodMod.Text = frmLiSolApr.cNroCuenta.Substring(6, 3);
                this.conBusCtaAho.txtCodMon.Text = frmLiSolApr.cNroCuenta.Substring(9, 1);
                this.conBusCtaAho.txtNroCta.Text = frmLiSolApr.cNroCuenta.Substring(10,12);
                this.conBusCtaAho.txtCodCli.Text = frmLiSolApr.cCodCliente;
                this.conBusCtaAho.txtNroDoc.Text = frmLiSolApr.cDocumentoDNI;
                this.conBusCtaAho.txtNombre.Text = frmLiSolApr.cNomCliente;

                Buscar();
            }
        }

        private void CBNewSol_CheckedChanged(object sender, EventArgs e)
        {
            if (CBNewSol.Visible == true)
            {
                if (CBNewSol.Checked == true)
                {
                    this.cboMotivos.SelectedIndex = -1;
                    this.txtMotivoDetalle.Text = "";

                    dtFecSolicitud.Value = clsVarGlobal.dFecSystem;
                    cboPersSolicitud.SelectedValue = clsVarGlobal.User.idUsuario;
                    txtTasaEsp.Text = "";
                    txtTasaEsp.Enabled = true;
                    cboMotivos.Enabled = true;
                    txtMotivoDetalle.Enabled = true;
                    lblEstExoner.Text = "NUEVA SOLICITUD";
                    btnEnviar.Enabled = true;
                    btnAceptar.Enabled = false;
                }
                if (CBNewSol.Checked == false)
                {
                    cboMotivos.SelectedValue = Convert.ToInt32(tbDatosSolici.Rows[0]["idMotivo"]);
                    txtMotivoDetalle.Text = Convert.ToString(tbDatosSolici.Rows[0]["cSustento"]);
                    dtFecSolicitud.Value = Convert.ToDateTime(tbDatosSolici.Rows[0]["dFecSolici"]);
                    cboPersSolicitud.SelectedValue = Convert.ToInt32(tbDatosSolici.Rows[0]["idUsuRegist"]);
                    txtTasaEsp.Text = Convert.ToString(Convert.ToDecimal(tbDatosCuenta.Rows[0]["nMonTasa"]) + Convert.ToDecimal(tbDatosSolici.Rows[0]["nValAproba"]));
                    txtTasaEsp.Enabled = false;
                    cboMotivos.Enabled = false;
                    txtMotivoDetalle.Enabled = false;
                    lblEstExoner.Text = Convert.ToString(tbDatosSolici.Rows[0]["cEstadoSol"]);
                    btnEnviar.Enabled = false;
                    btnAceptar.Enabled = true;
                }
            }
        }
        private void Buscar()
        {
            p_idCuenta = 0;
            if (conBusCtaAho.txtNroCta.Text.Trim() == "")
            {
                LimpiarControles();
                conBusCtaAho.btnBusCliente.Focus();
                conBusCtaAho.HabDeshabilitarCtrl(true);
                conBusCtaAho.txtCodAge.Focus();
                return;
            }

            LimpiarControles();

            int NroCuenta = Convert.ToInt32(conBusCtaAho.idcuenta);
            p_idCuenta = NroCuenta;

            clsCNAutorTasaEsp BuscarDatosCuenta = new clsCNAutorTasaEsp();
            tbDatosCuenta = BuscarDatosCuenta.DatosCuenta(p_idCuenta);
            tbDatosSolici = BuscarDatosCuenta.DatosSolicitud(p_idCuenta);

            if (Convert.ToInt32(tbDatosCuenta.Rows[0]["idTipoTasa"]) == 1)
            {
                lblTasa.Text = "TASA NORMAL";
            }
            if (Convert.ToInt32(tbDatosCuenta.Rows[0]["idTipoTasa"]) == 2)
            {
                lblTasa.Text = "TASA ESPECIAL";
            }

            lblTipoCta.Text = Convert.ToString(tbDatosCuenta.Rows[0]["cTipoCuenta"]);
            lblTipoPers.Text = Convert.ToString(tbDatosCuenta.Rows[0]["cTipoPersona"]);
            lblTipoProd.Text = Convert.ToString(tbDatosCuenta.Rows[0]["cProducto"]);
            lblEstadoCuenta.Text = Convert.ToString(tbDatosCuenta.Rows[0]["cEstado"]);
            lblCaract.Text = Convert.ToString(tbDatosCuenta.Rows[0]["cCaracteristica"]);
            lblSaldoDisp.Text = Convert.ToString(tbDatosCuenta.Rows[0]["nSaldoDis"]);
            lblSaldoCont.Text = Convert.ToString(tbDatosCuenta.Rows[0]["nSaldoCnt"]);
            lblTasaEfec.Text = Convert.ToString(tbDatosCuenta.Rows[0]["nMonTasa"]);

            if (tbDatosSolici.Rows.Count == 0)
            {
                lblEstExoner.Text = "SIN SOLICITUD";
                txtTasaEsp.Enabled = true;
                this.txtMotivoDetalle.Enabled = true;
                this.cboMotivos.SelectedIndex = -1;
                txtMotivoDetalle.Text = "";
                this.dtFecSolicitud.Value = clsVarGlobal.dFecSystem;
                this.cboPersSolicitud.SelectedValue = clsVarGlobal.User.idUsuario;
                cboMotivos.Enabled = true;
                txtMotivoDetalle.Enabled = true;
                btnEnviar.Enabled = true;
                btnAceptar.Enabled = false;
                CBNewSol.Visible = false;
                txtTasaEsp.Focus();

            }
            if (tbDatosSolici.Rows.Count > 0)
            {

                lblEstExoner.Text = Convert.ToString(tbDatosSolici.Rows[0]["cEstadoSol"]);
                cboMotivos.SelectedValue = Convert.ToInt32(tbDatosSolici.Rows[0]["idMotivo"]);
                txtMotivoDetalle.Text = Convert.ToString(tbDatosSolici.Rows[0]["cSustento"]);
                dtFecSolicitud.Value = Convert.ToDateTime(tbDatosSolici.Rows[0]["dFecSolici"]);
                cboPersSolicitud.SelectedValue = Convert.ToInt32(tbDatosSolici.Rows[0]["idUsuRegist"]);
                //txtTasaEsp.Text = Convert.ToString(Convert.ToDecimal(tbDatosCuenta.Rows[0]["nMonTasa"]) + Convert.ToDecimal(tbDatosSolici.Rows[0]["nValAproba"]));
                txtTasaEsp.Text = tbDatosSolici.Rows[0]["nValAproba"].ToString();
                txtTasaEsp.Enabled = false;
                cboMotivos.Enabled = false;
                txtMotivoDetalle.Enabled = false;
                btnEnviar.Enabled = false;
                btnAceptar.Enabled = true;
                btnAceptar.Focus();
                if (Convert.ToInt32(tbDatosSolici.Rows[0]["idEstadoSol"]) == 4)
                {
                    CBNewSol.Visible = true;
                }
                else
                {
                    CBNewSol.Visible = false;
                }
            }

            CargarSolicitudesTasasEspeciales(p_idCuenta);

            btnCancelar.Enabled = true;
            conBusCtaAho.btnBusCliente.Enabled = false;
            conBusCtaAho.HabDeshabilitarCtrl(false);
        }

        private void CargarSolicitudesTasasEspeciales(int idCuenta)
        {
            clsCNAutorTasaEsp solicitud = new clsCNAutorTasaEsp();
            DataTable dtSolTas = solicitud.SolicitudTasaEspecial(idCuenta);
            dtgSolicitudes.DataSource = dtSolTas;
            if (dtSolTas.Rows.Count > 0)
            {
                dtgSolicitudes.Enabled = true;
            }
            else
            {
                dtgSolicitudes.Enabled = false;
            }

            dtgSolicitudes.Columns["idSolAproba"].Width = 40;
            dtgSolicitudes.Columns["idSolAproba"].HeaderText = "Solicitud";
            dtgSolicitudes.Columns["idSolAproba"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgSolicitudes.Columns["dFecSolici"].Width = 40;
            dtgSolicitudes.Columns["dFecSolici"].HeaderText = "Fec. Solicitud";
            dtgSolicitudes.Columns["dFecSolici"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgSolicitudes.Columns["cTipoOperacion"].Width = 70;
            dtgSolicitudes.Columns["cTipoOperacion"].HeaderText = "Tipo Solicitud";
            dtgSolicitudes.Columns["cTipoOperacion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgSolicitudes.Columns["cEstadoSol"].Width = 60;
            dtgSolicitudes.Columns["cEstadoSol"].HeaderText = "Estado";
            dtgSolicitudes.Columns["cEstadoSol"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgSolicitudes.Columns["dFecAprSol"].Width = 40;
            dtgSolicitudes.Columns["dFecAprSol"].HeaderText = "Fec. Aprobación";
            dtgSolicitudes.Columns["dFecAprSol"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgSolicitudes.Columns["cNomAprobador"].Width = 180;
            dtgSolicitudes.Columns["cNomAprobador"].HeaderText = "Aprobador";
            dtgSolicitudes.Columns["cNomAprobador"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void LimpiarControles()
        {
            lblTasa.Text = "";            
            lblTasaEfec.Text = "";
            lblEstExoner.Text = "";
            lblTipoCta.Text = "";
            lblTipoPers.Text = "";
            lblTipoProd.Text = "";
            lblEstadoCuenta.Text = "";
            lblCaract.Text = "";
            lblSaldoDisp.Text = "";
            lblSaldoCont.Text = "";

            txtTasaEsp.Text = "";
            cboMotivos.SelectedIndex = -1;
            txtMotivoDetalle.Text = "";
            dtFecSolicitud.Value = clsVarGlobal.dFecSystem;
            cboPersSolicitud.SelectedIndex = -1;
            CBNewSol.Visible = false;
            CBNewSol.Checked = false;
            if (dtgSolicitudes.Rows.Count > 0)
            {
                ((DataTable)dtgSolicitudes.DataSource).Rows.Clear();
            }
            dtgSolicitudes.Refresh();
        }
                

        private void txtTasaEsp_Validating(object sender, CancelEventArgs e)
        {
            if (txtTasaEsp.Text.Trim() != "")
                txtTasaEsp.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtTasaEsp.Text), 4).ToString("#.0000"));
        }

    }
}
