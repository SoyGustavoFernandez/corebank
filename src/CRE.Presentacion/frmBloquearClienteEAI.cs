using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using System.Drawing.Printing;
using GEN.PrintHelper;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using GEN.Funciones;
using DEP.CapaNegocio;
using SPL.Presentacion;
using CAJ.CapaNegocio;
using System.Xml;
using CLI.Servicio;
using CLI.CapaNegocio;
using CLI.Presentacion;


namespace CRE.Presentacion
{
    public partial class frmBloquearClienteEAI : frmBase
    {
        #region Variables Globales
        clsCNCredito cnCredito = new clsCNCredito();
        clsCliente objCliente = new clsCliente();
        DataTable dtClienteBloq = new DataTable();
        DataTable dtMotivoBloq = new DataTable();
        #endregion

        public frmBloquearClienteEAI()
        {
            InitializeComponent();
        }

        private void frmBloquearClienteEAI_Load(object sender, EventArgs e)
        {
            int idPerfil = clsVarGlobal.PerfilUsu.idPerfil;
            if (idPerfil == 34 || idPerfil == 56 || idPerfil == 85)
            {
                grbBase3.Visible = false;
                Size = new Size(400, 430);
            }

            cboMotivoBloq.Enabled = false;
            txtSustentoBloq.Enabled = false;
            txtSustentoDesbloq.Enabled = false;
            btnDesbloquear.Enabled = false;
            btnBloquear.Enabled = false;
        }
        
        private void conBusCliSimp_EventoPostBuscar(object sender, EventArgs e)
        {
            objCliente = conBusCliSimp.objCliente;

            if (objCliente.idCli == 0)
            {
                MessageBox.Show("No se encontró los Datos del Cliente", "Validación de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            cargarDatos();
            conBusCliSimp.Enabled = false;
        }

        private void cargarDatos()
        {

            dtClienteBloq = cnCredito.CNCargarCliBloqEAI(objCliente.idCli);

            dtMotivoBloq = cnCredito.CNListarMotivoBloqEAI();
            cboMotivoBloq.ValueMember = "idMotBloqEAI";
            cboMotivoBloq.DisplayMember = "cDescripcion";
            cboMotivoBloq.DataSource = dtMotivoBloq;

            if (dtClienteBloq.Rows.Count > 0)
            {
                cboMotivoBloq.SelectedValue = Convert.ToInt32(dtClienteBloq.Rows[0]["idMotBloqEAI"].ToString());
                txtSustentoBloq.Text = Convert.ToString(dtClienteBloq.Rows[0]["cSustentoBloq"].ToString());

                cboMotivoBloq.Enabled = false;
                txtSustentoBloq.Enabled = false;
                btnBloquear.Enabled = false;
                txtSustentoDesbloq.Enabled = true;
                btnDesbloquear.Enabled = true;
            }
            else
            {
                cboMotivoBloq.Enabled = true;
                btnBloquear.Enabled = true;
                txtSustentoDesbloq.Enabled = false;
                btnDesbloquear.Enabled = false;
            }
        }
                
        private void cboMotivoBloq_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboMotivoBloq.SelectedValue.ToString()) == 6)
            {
                txtSustentoBloq.Enabled = true;
            }
            else
            {
                txtSustentoBloq.Text = "";
                txtSustentoBloq.Enabled = true;
            }
        }
                        
        private void btnBloquear_Click(object sender, EventArgs e)
        {
            DataTable dtBloqCliEAI = new DataTable();

            dtBloqCliEAI = cnCredito.CNBloqCliEAI(objCliente.idCli,
                                                    Convert.ToInt32(cboMotivoBloq.SelectedValue.ToString()),
                                                    txtSustentoBloq.Text,
                                                    clsVarGlobal.PerfilUsu.idUsuario,
                                                    clsVarGlobal.PerfilUsu.idPerfil);

            if (Convert.ToInt32(dtBloqCliEAI.Rows[0]["idMsg"].ToString()) == 0)
            {
                MessageBox.Show("Cliente Bloqueado Correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cboMotivoBloq.Enabled = false;
                txtSustentoBloq.Enabled = false;
                btnBloquear.Enabled = false;
            }
            else if (Convert.ToInt32(dtBloqCliEAI.Rows[0]["idMsg"].ToString()) == 1)
            {
                MessageBox.Show("Error al Bloquear Cliente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            DataTable dtDesbloqCliEAI = new DataTable();

            if(String.IsNullOrEmpty(txtSustentoDesbloq.Text))
            {
                MessageBox.Show("Debe registrar el sustento para el Desbloqueo del Cliente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dtDesbloqCliEAI = cnCredito.CNDesbloqCliEAI(objCliente.idCli,
                                                        clsVarGlobal.PerfilUsu.idUsuario,
                                                        clsVarGlobal.PerfilUsu.idPerfil,
                                                        txtSustentoDesbloq.Text,
                                                        Convert.ToInt32(dtClienteBloq.Rows[0]["idCliBloqEAI"].ToString()));


            if (Convert.ToInt32(dtDesbloqCliEAI.Rows[0]["idMsg"].ToString()) == 0)
            {
                MessageBox.Show("Cliente Desbloqueado Correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cboMotivoBloq.Enabled = false;
                txtSustentoBloq.Enabled = false;
                btnBloquear.Enabled = false;

                txtSustentoDesbloq.Enabled = false;
                btnDesbloquear.Enabled = false;
            }
            else if (Convert.ToInt32(dtDesbloqCliEAI.Rows[0]["idMsg"].ToString()) == 1)
            {
                MessageBox.Show("Error al Desbloquear Cliente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            conBusCliSimp.limpiarControles();
            conBusCliSimp.Enabled = true;

            cboMotivoBloq.Text = "";
            txtSustentoBloq.Text = "";
            txtSustentoDesbloq.Text = "";
            txtSustentoDesbloq.Enabled = false;
            btnBloquear.Enabled = false;
            btnDesbloquear.Enabled = false;
        }
    }
}
