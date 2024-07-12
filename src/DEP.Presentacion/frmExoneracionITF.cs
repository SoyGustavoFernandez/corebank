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
    public partial class frmExoneracionITF : frmBase
    {
        DataTable tbDatosCuenta;
        DataTable tbDatosSolici;
        clsCNDeposito liberarCta = new clsCNDeposito();
        public int p_idCuenta = 0;

        public frmExoneracionITF()
        {
            InitializeComponent();
        }

        private void frmExoneracionITF_Load(object sender, EventArgs e)
        {
            conBusCtaAho.nTipOpe = 16;  //Altes 12
            conBusCtaAho.idMoneda = 0;
            cboMotivos.CargarMotivos(3);
            cboPersSolicitud.PersTodasAgen();
            LimpiarControles();
            conBusCtaAho.idcuenta = 0;
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            conBusCtaAho.txtCodAge.Focus();
        }
        private void frmExoneracionITF_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (p_idCuenta != 0)
                liberarCta.CNUpdNoUsoCuenta(p_idCuenta);
        }
        private void conBusCtaAho_ClicBusCta(object sender, EventArgs e)
        {
            Buscar();
            cboMotivos.Focus();
           
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            liberarCta.CNUpdNoUsoCuenta(p_idCuenta);
            btnAceptar.Enabled = false;
            btnEnviar.Enabled = false;
            btnCancelar.Enabled = false;
            p_idCuenta = 0;
            LimpiarControles();
            conBusCtaAho.LimpiarControles();
            conBusCtaAho.HabDeshabilitarCtrl(true);
            dtgExoneraciones.Enabled = false;
            conBusCtaAho.idcuenta = 0;
            conBusCtaAho.btnBusCliente.Enabled = true;
            conBusCtaAho.txtCodAge.Focus();
            
            cboMotivos.Enabled = false;
            txtMotivoDetalle.Enabled = false;

        }
        private void btnEnviar1_Click(object sender, EventArgs e)
        {
            if (conBusCtaAho.txtNroCta.Text.Trim() == "")
            {
                MessageBox.Show("Debe asignar una cuenta valida", "Solicitud de Exoneración de ITF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboMotivos.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar un motivo", "Solicitud de Exoneración de ITF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtMotivoDetalle.Text.Length < 11)
            {
                MessageBox.Show("Debe asignar una breve descripción para el Motivo (Mín. 10 caracteres)", "Solicitud de Exoneración de ITF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int TipoOperacion = 0;
            if (Convert.ToBoolean(tbDatosCuenta.Rows[0]["lIsAfectoITF"]) == true)
            {
                TipoOperacion = 49;//Exoneracion
            }

            if (Convert.ToBoolean(tbDatosCuenta.Rows[0]["lIsAfectoITF"]) == false)
            {
                TipoOperacion = 53;//Afectacion
            }

            clsCNExoneracionITF solicitud = new clsCNExoneracionITF();
            DataTable dtSol = solicitud.EnviarSolicitud(Convert.ToInt32(clsVarGlobal.nIdAgencia), Convert.ToInt32(conBusCtaAho.txtCodCli.Text), TipoOperacion, 1, Convert.ToInt32(tbDatosCuenta.Rows[0]["idMoneda"]), Convert.ToInt32(tbDatosCuenta.Rows[0]["idProducto"]),
                                       Convert.ToDecimal(tbDatosCuenta.Rows[0]["nSaldoDis"]), p_idCuenta, Convert.ToDateTime(dtFecSolicitud.Value),
                                       Convert.ToInt32(cboMotivos.SelectedValue), txtMotivoDetalle.Text, 1, Convert.ToDateTime("01/01/1900"), Convert.ToInt32(clsVarGlobal.User.idUsuario),false);
            if (!dtSol.Rows[0]["idSolAproba"].ToString().Equals("0"))
            {
                if (dtSol.Rows[0]["idEstadoSol"].ToString().Equals("4"))
                {
                    MessageBox.Show(dtSol.Rows[0]["cMensaje"].ToString(), "Solicitud de Exoneración de ITF", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                }
                else
                {
                    MessageBox.Show("Su solicitud fue enviada correctamente", "Solicitud de Exoneración de ITF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //lVigente=0, para la solicitud Rechazada anteriormente
                    if (CBNewSol.Checked == true && CBNewSol.Visible == true)
                    {
                        solicitud.AnularSol(Convert.ToInt32(tbDatosSolici.Rows[0]["idSolAproba"]));
                    }
                    int idSolicitud = Convert.ToInt32(dtSol.Rows[0]["idSolAproba"]);
                    solicitud.CNEnviaCorreoSolExoITF(Convert.ToInt32(conBusCtaAho.txtCodCli.Text), conBusCtaAho.idcuenta, TipoOperacion, clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.nIdAgencia, idSolicitud);
                }
            }
            else
            {
                MessageBox.Show("Error al generar su solicitud", "Solicitud de Exoneración de ITF", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
            }
            Buscar();
            dtgExoneraciones.Enabled = false;

        }
        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            String TipoOperacion = "";

            if (Convert.ToInt32(tbDatosCuenta.Rows[0]["lIsAfectoITF"]) == 1)
                TipoOperacion = "Exoneración";
            if (Convert.ToInt32(tbDatosCuenta.Rows[0]["lIsAfectoITF"]) == 0)
                TipoOperacion = "Afectación";


            if (Convert.ToInt32(tbDatosSolici.Rows[0]["idEstadoSol"]) == 1)// ESTADO SOLICITADO
            {
                MessageBox.Show("No se puede realizar la " + TipoOperacion + " de ITF, ya que la Solicitud aún no ha sido APROBADA", "Solicitud de Exoneración de ITF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (Convert.ToInt32(tbDatosSolici.Rows[0]["idEstadoSol"]) == 2)//ESTADO APROBADO
            {
                clsCNExoneracionITF Exoneracion = new clsCNExoneracionITF();
                Exoneracion.ExonerarAfectarITF(Convert.ToInt32(tbDatosCuenta.Rows[0]["lIsAfectoITF"]), p_idCuenta, Convert.ToInt32(tbDatosSolici.Rows[0]["idSolAproba"]),
                                        Convert.ToDateTime(clsVarGlobal.dFecSystem), Convert.ToInt32(clsVarGlobal.nIdAgencia), Convert.ToInt32(clsVarGlobal.User.idUsuario));

                MessageBox.Show("La " + TipoOperacion + " de ITF a esta cuenta se realizó correctamente", "Solicitud de Exoneración de ITF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Buscar();
                return;
            }

            if (Convert.ToInt32(tbDatosSolici.Rows[0]["idEstadoSol"]) == 4)//ESTADO RECHAZADO
            {
                MessageBox.Show("No se puede realizar la " + TipoOperacion + " de ITF, su solicitud fue RECHAZADA", "Solicitud de Exoneración de ITF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
            dtgExoneraciones.Enabled = false;
        }
        private void btnSalir1_Click(object sender, EventArgs e)
        {
            if (p_idCuenta != 0)
                liberarCta.CNUpdNoUsoCuenta(p_idCuenta);
        }
        private void btnExtorAprob_Click(object sender, EventArgs e)
        {
            frmListSolExonAprob frmLiSolApr = new frmListSolExonAprob();
            frmLiSolApr.ShowDialog();
            if (frmLiSolApr.idCuenta != 0)
            {
                this.conBusCtaAho.txtCodIns.Text = frmLiSolApr.cNroCuenta.Substring(0, 3);
                this.conBusCtaAho.txtCodAge.Text = frmLiSolApr.cNroCuenta.Substring(3, 3);
                this.conBusCtaAho.txtCodMod.Text = frmLiSolApr.cNroCuenta.Substring(6, 3);
                this.conBusCtaAho.txtCodMon.Text = frmLiSolApr.cNroCuenta.Substring(9, 1);
                this.conBusCtaAho.txtNroCta.Text = frmLiSolApr.cNroCuenta.Substring(10, 12);
                this.conBusCtaAho.txtCodCli.Text = frmLiSolApr.cCodCliente;
                this.conBusCtaAho.txtNroDoc.Text = frmLiSolApr.cDocumentoDNI;
                this.conBusCtaAho.txtNombre.Text = frmLiSolApr.cNomCliente;
                this.conBusCtaAho.idcuenta = frmLiSolApr.idCuenta;
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
                    this.txtDetMotivo.Clear();
                    dtFecSolicitud.Value = clsVarGlobal.dFecSystem;
                    cboPersSolicitud.SelectedValue = clsVarGlobal.User.idUsuario;
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

            clsCNExoneracionITF BuscarDatosCuenta = new clsCNExoneracionITF();
            tbDatosCuenta = BuscarDatosCuenta.DatosCuenta(p_idCuenta);
            tbDatosSolici = BuscarDatosCuenta.DatosSolicitud(p_idCuenta);

            if (Convert.ToBoolean(tbDatosCuenta.Rows[0]["lIsAfectoITF"]) == true)
            {
                lblEstITF.Text = "CUENTA AFECTA A ITF";
            }
            if (Convert.ToBoolean(tbDatosCuenta.Rows[0]["lIsAfectoITF"]) == false)
            {
                lblEstITF.Text = "CUENTA EXONERADA DE ITF";
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
            }

            if (tbDatosSolici.Rows.Count > 0)
            {
                lblEstExoner.Text = Convert.ToString(tbDatosSolici.Rows[0]["cEstadoSol"]);
                cboMotivos.SelectedValue = Convert.ToInt32(tbDatosSolici.Rows[0]["idMotivo"]);
                txtMotivoDetalle.Text = Convert.ToString(tbDatosSolici.Rows[0]["cSustento"]);
                dtFecSolicitud.Value = Convert.ToDateTime(tbDatosSolici.Rows[0]["dFecSolici"]);
                cboPersSolicitud.SelectedValue = Convert.ToInt32(tbDatosSolici.Rows[0]["idUsuRegist"]);
                cboMotivos.Enabled = false;
                txtMotivoDetalle.Enabled = false;
                btnEnviar.Enabled = false;
                btnAceptar.Enabled = true;
                if (Convert.ToInt32(tbDatosSolici.Rows[0]["idEstadoSol"]) == 4)
                {
                    CBNewSol.Visible = true;
                }
                else
                {
                    CBNewSol.Visible = false;
                }
            }

            if (Convert.ToBoolean(tbDatosCuenta.Rows[0]["lIsAfectoITF"]) == true)
            {
                lblAfectoExoner.Text = "SOLICITUD DE EXONERACIÓN DE ITF";
            }

            if (Convert.ToBoolean(tbDatosCuenta.Rows[0]["lIsAfectoITF"]) == false)
            {
                lblAfectoExoner.Text = "SOLICITUD DE AFECTACIÓN DE ITF";
            }

            ListarSolExoneracionITF(p_idCuenta);

            btnCancelar.Enabled = true;
            conBusCtaAho.btnBusCliente.Enabled = false;
            conBusCtaAho.HabDeshabilitarCtrl(false);
            
            cboMotivos.Enabled = true;
            txtMotivoDetalle.Enabled = true;

        }

        private void ListarSolExoneracionITF(int idCuenta)
        {
            clsCNExoneracionITF solicitud = new clsCNExoneracionITF();
            DataTable dtSolExo = solicitud.SolicitudesExoneracionITF(idCuenta);
            dtgExoneraciones.DataSource = dtSolExo;
            if (dtSolExo.Rows.Count > 0)
            {
                dtgExoneraciones.Enabled = true;
            }
            else
            {
                dtgExoneraciones.Enabled = false;
            }

            dtgExoneraciones.Columns["idSolAproba"].Width = 40;
            dtgExoneraciones.Columns["idSolAproba"].HeaderText = "Solicitud";
            dtgExoneraciones.Columns["idSolAproba"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgExoneraciones.Columns["dFecSolici"].Width = 40;
            dtgExoneraciones.Columns["dFecSolici"].HeaderText = "Fec. Solicitud";
            dtgExoneraciones.Columns["dFecSolici"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgExoneraciones.Columns["cTipoOperacion"].Width = 70;
            dtgExoneraciones.Columns["cTipoOperacion"].HeaderText = "Tipo Solicitud";
            dtgExoneraciones.Columns["cTipoOperacion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgExoneraciones.Columns["cEstadoSol"].Width = 60;
            dtgExoneraciones.Columns["cEstadoSol"].HeaderText = "Estado";
            dtgExoneraciones.Columns["cEstadoSol"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgExoneraciones.Columns["dFecAprSol"].Width = 40;
            dtgExoneraciones.Columns["dFecAprSol"].HeaderText = "Fec. Aprobación";
            dtgExoneraciones.Columns["dFecAprSol"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgExoneraciones.Columns["cNomAprobador"].Width = 180;
            dtgExoneraciones.Columns["cNomAprobador"].HeaderText = "Aprobador";
            dtgExoneraciones.Columns["cNomAprobador"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void LimpiarControles()
        {

            lblEstITF.Text = "";
            lblAfectoExoner.Text = "SOLICITUD EXONERACIÓN/AFECTACIÓN";
            lblTasaEfec.Text = "";
            lblEstExoner.Text = "";
            lblTipoCta.Text = "";
            lblTipoPers.Text = "";
            lblTipoProd.Text = "";
            lblEstadoCuenta.Text = "";
            lblCaract.Text = "";
            lblSaldoDisp.Text = "";
            lblSaldoCont.Text = "";

            cboMotivos.SelectedIndex = -1;
            txtMotivoDetalle.Clear();
            txtDetMotivo.Clear();
            dtFecSolicitud.Value = clsVarGlobal.dFecSystem;
            cboPersSolicitud.SelectedIndex = -1;
            CBNewSol.Visible = false;
            CBNewSol.Checked = false;

            if (dtgExoneraciones.Rows.Count > 0)
            {
                ((DataTable)dtgExoneraciones.DataSource).Rows.Clear();
            }
            dtgExoneraciones.Refresh();

        }

        private void cboMotivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMotivos.SelectedIndex>-1)
            {
                DataTable dtMotivos = (DataTable)cboMotivos.DataSource;
                int idRow = cboMotivos.SelectedIndex;
                txtDetMotivo.Text = dtMotivos.Rows[idRow]["cDetalleMotivo"].ToString(); 
            }            
        }
    }
}
