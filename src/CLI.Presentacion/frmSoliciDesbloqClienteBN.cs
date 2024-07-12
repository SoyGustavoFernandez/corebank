using CLI.CapaNegocio;
using DEP.CapaNegocio;
using EntityLayer;
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
using GEN.CapaNegocio;

namespace CLI.Presentacion
{
    public partial class frmSoliciDesbloqClienteBN : frmBase
    {
        public int p_idbasenegativa=0;
        public int p_idTipoPersona = 0, p_idTipoDoc = 0;
        int TipoOperacion = 124;
        public int idCli = 0;
        public int idMotivoBloq = 0;
        ToolTip buttonToolTip = new ToolTip();

        public frmSoliciDesbloqClienteBN()
        {
            InitializeComponent();
            resetSoliciDesbloqClienteBN();
        }

        public void resetSoliciDesbloqClienteBN()
        {
            this.rbtEsCliente.Checked = false;
            this.rbtNoEsCliente.Checked = false;

            this.cboTipoPersona.SelectedIndex = -1;
            this.cboTipoDocumento.SelectedIndex = -1;
            this.txtNroDoc.Text = "";
            this.txtNomRazon.Text = "";
            this.txtMotivoDesbloq.Text = "";
        }

        public void inicializarSoliciDesbloqClienteBN(int nEsCLiente, int idCli, int idTipoPersona, int idTipoDocumento, string cNroDoc, string cNomRazon)
        {
            if (idCli == 0)
            {
                this.rbtEsCliente.Checked = false;
                this.rbtNoEsCliente.Checked = true;
            }
            else
            {
                this.rbtEsCliente.Checked = true;
                this.rbtNoEsCliente.Checked = false;
            }

            this.idCli = idCli;
            cboTipoPersona.SelectedValue = idTipoPersona;
            cboTipoDocumento.SelectedValue = idTipoDocumento;
            txtNroDoc.Text = cNroDoc;
            txtNomRazon.Text = cNomRazon;
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            frmBusCliBN frmbuscarclibn = new frmBusCliBN();
            frmbuscarclibn.establecerTipoBusqueda(2);
            frmbuscarclibn.ShowDialog();            

            if (frmbuscarclibn.pnTipoPersona == 1)
            {
                idCli = Convert.ToInt32(frmbuscarclibn.pcCodCli);
                if (idCli == 0)
                {
                    this.rbtEsCliente.Checked = true;
                    this.rbtNoEsCliente.Checked = false;
                }
                else
                {
                    this.rbtEsCliente.Checked = false;
                    this.rbtNoEsCliente.Checked = true;
                }

                cboTipoDocumento.SelectedValue = frmbuscarclibn.pnTipoDocumento;
                txtNroDoc.Text = frmbuscarclibn.pcNroDoc;
                txtNomRazon.Text = frmbuscarclibn.pcNomCli;
            }
            else if (frmbuscarclibn.pnTipoPersona == 2)
            {
                idCli = Convert.ToInt32(frmbuscarclibn.pcCodCli);
                if (idCli == 0)
                {
                    this.rbtEsCliente.Checked = true;
                    this.rbtNoEsCliente.Checked = false;
                }
                else
                {
                    this.rbtEsCliente.Checked = false;
                    this.rbtNoEsCliente.Checked = true;
                }
                
                cboTipoDocumento.SelectedValue = frmbuscarclibn.pnTipoDocumento;
                txtNroDoc.Text = frmbuscarclibn.pcNroDoc;
                txtNomRazon.Text = frmbuscarclibn.pcRazonSocial;                
            }
            else
            {
                idCli = 0;                
                this.rbtEsCliente.Checked = false;
                this.rbtNoEsCliente.Checked = true;                
                
                cboTipoDocumento.SelectedIndex = -1;
                txtNroDoc.Text = "";
                txtNomRazon.Text = "";                
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            //Validaciones
            if (cboMotivos.SelectedIndex==-1)
            {
                MessageBox.Show("Debe seleccionar el motivo del desbloqueo", "Solicitud de Debloqueo de Cliente de Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMotivos.Focus();
                return;
            }
            if (this.txtMotivoDesbloq.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un motivo de desbloqueo para continuar", "Solicitud de Debloqueo de Cliente de Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotivoDesbloq.Focus();
                return;
            }

            if (this.cboTipoPersona.SelectedIndex != -1 && this.cboTipoDocumento.SelectedIndex != -1 && this.txtNroDoc.Text.Trim() != "")
            {
                DateTime dtFecSolicitud = clsVarGlobal.dFecSystem;
                clsCNBaseNegativaClientes objBaseNegativa = new clsCNBaseNegativaClientes();

                DataTable dtRegSolDesbloqPerBN = objBaseNegativa.CNRegSolicitudDesbloqPersonaBN(this.idCli, Convert.ToInt32(this.cboTipoPersona.SelectedValue), Convert.ToInt32(this.cboTipoDocumento.SelectedValue), this.txtNroDoc.Text, this.txtNomRazon.Text,p_idbasenegativa);

                if (dtRegSolDesbloqPerBN.Rows.Count > 0)
                {
                    clsCNAprobacion dtSolApr = new clsCNAprobacion();
                    int idSolBN = Convert.ToInt32(dtRegSolDesbloqPerBN.Rows[0]["idSolPersonaBN"]);
                    if (this.idMotivoBloq == Convert.ToInt32(clsVarApl.dicVarGen["idMotivoBloqScoring"]))//bloqueo por Scoring alto
                    {
                        TipoOperacion = Convert.ToInt32(clsVarApl.dicVarGen["idTipOpeBloqCliScoring"]);
                    }
                    DataTable tbSolApr = dtSolApr.GuardarSolicitudAprobac(clsVarGlobal.nIdAgencia, this.idCli, TipoOperacion, 1,
                                                               1, 0, 0,
                                                               idSolBN, clsVarGlobal.dFecSystem, Convert.ToInt16(cboMotivos.SelectedValue),
                                                               this.txtMotivoDesbloq.Text, 1, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, 0, clsVarGlobal.User.idEstablecimiento, Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));

                    if (Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"].ToString()) != 0)
                    {
                        MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString() + ", Nro. Solicitud: " + tbSolApr.Rows[0]["idSolAproba"].ToString(), "Registro de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Error al enviar la solicitud", "Solicitud de Debloqueo de Cliente de Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }            
            }
            else
            {
                MessageBox.Show("Seleccione a una persona de la base negativa antes de continuar", "Solicitud de Debloqueo de Cliente de Base Negativa", MessageBoxButtons.OK, MessageBoxIcon.Warning);   
            }

            this.Close();
        }

        private void frmSoliciDesbloqClienteBN_Load(object sender, EventArgs e)
        {
            cboMotivos.CargarMotivos(8);
            cboTipoPersona.SelectedValue = p_idTipoPersona;
            cboTipoDocumento.SelectedValue = p_idTipoDoc;
            cboMotivos.Focus();
        }

        private void cboMotivos_MouseHover(object sender, EventArgs e)
        {
            buttonToolTip.ToolTipTitle = "Motivo Desbloqueo";
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.IsBalloon = true;
            buttonToolTip.ShowAlways = true;
            buttonToolTip.AutoPopDelay = 5000;
            buttonToolTip.InitialDelay = 1000;
            buttonToolTip.ReshowDelay = 0;

            buttonToolTip.SetToolTip(this.cboMotivos, cboMotivos.GetItemText(cboMotivos.SelectedItem));

        }
    }
}
