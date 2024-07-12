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
using EntityLayer;

namespace SolIntEls
{
    public partial class frmAprExtorno : frmBase
    {
        public frmAprExtorno()
        {
            InitializeComponent();
        }

        private void frmAprExtorno_Load(object sender, EventArgs e)
        {

        }

        private void txtDatBus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                //btnProcesar.PerformClick();
            }
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {   //pendiente por revisar
            frmBuscarSolExt frmExtPen = new frmBuscarSolExt();
            frmExtPen.pidMod = 1;
            frmExtPen.ShowDialog();
            LimpiarCtr();
            int nidKar= frmExtPen.pidKardex;
            if (nidKar!=0)
            {
                CargarDatos(nidKar);
                this.btnAceptar.Enabled = true;
                this.btnRechazar.Enabled = true;
            }
            else
            {
                this.txtNroKardex.Clear();
                this.btnAceptar.Enabled = false;
                this.btnRechazar.Enabled = false;
            }
        }

        private void CargarDatos(int idKar)
        {
            clsCNGenAdmOpe ListarExt = new clsCNGenAdmOpe();
            DataTable tbExt = ListarExt.ListadoSolExtPend(idKar, clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia, clsVarGlobal.User.idUsuario,
                                                        0, 0, 0, clsVarGlobal.PerfilUsu.idPerfilUsu, 2);
            this.txtNroKardex.Text = idKar.ToString();
            this.txtNroSol.Text = tbExt.Rows[0]["idSolExtorno"].ToString();
            this.txtFecSol.Text = tbExt.Rows[0]["dFecHorSol"].ToString();
            this.txtNomSol.Text = tbExt.Rows[0]["cNombre"].ToString();
            this.txtNomAge.Text = tbExt.Rows[0]["cNombreAge"].ToString();
            this.txtNomMod.Text = tbExt.Rows[0]["cModulo"].ToString();
            this.txtTipOpe.Text = tbExt.Rows[0]["cTipoOperacion"].ToString();
            this.cboMoneda.SelectedValue = Convert.ToInt32(tbExt.Rows[0]["idMoneda"].ToString());
            this.txtMonGiro.Text = tbExt.Rows[0]["nMontoOpe"].ToString();
            this.txtMotExt.Text = tbExt.Rows[0]["cMotivoExt"].ToString();
            this.txtSustento.Text = tbExt.Rows[0]["cSustentoExt"].ToString();
        }

        private void LimpiarCtr()
        {
            this.txtNroSol.Clear();
            this.txtFecSol.Clear();
            this.txtNomSol.Clear();
            this.txtNomAge.Clear();
            this.txtNomMod.Clear();
            this.txtTipOpe.Clear();
            this.cboMoneda.SelectedValue = 1;
            this.txtMonGiro.Text = "0.00";
            this.txtMotExt.Clear();
            this.txtSustento.Clear();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            LimpiarCtr();
            if (string.IsNullOrEmpty(this.txtNroKardex.Text.Trim()))
            {
                MessageBox.Show("Primero debe Ingresar el Numero de Kardex a Buscar", "Buscar Operación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNroKardex.Focus();
                return;
            }
            int idKar = Convert.ToInt32(this.txtNroKardex.Text);
            CargarDatos(idKar);
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            RegAprRechaSolExt(2);
        }

        private void RegAprRechaSolExt(int nOpc)
        {
            if (string.IsNullOrEmpty(this.txtNroSol.Text.Trim()))
            {
                MessageBox.Show("No Existe Número de Solicitud para Aprobar/Rechazar", "Aprobar/Rechazar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnBusqueda.Focus();
                return;
            }
            if (nOpc==2)
            {
                var Msg=MessageBox.Show("Esta Seguro de APROBAR la Solicitud de Extorno?...", "Aprobar Solicitud de Extorno", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                if (Msg == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                var Msg = MessageBox.Show("Esta Seguro de RECHAZAR la Solicitud de Extorno?...", "Rechazar Solicitud de Extorno", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Msg == DialogResult.No)
                {
                    return;
                }
            }

            int idSol = Convert.ToInt32(this.txtNroSol.Text);
            clsCNGenAdmOpe dtExt = new clsCNGenAdmOpe();
            DataTable tbExt = dtExt.RegAprRechazoSolExt(idSol, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, nOpc);
            if (Convert.ToInt32(tbExt.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(tbExt.Rows[0]["cMensage"].ToString(), "Aprobar/Rechazar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnAceptar.Enabled = false;
                this.btnRechazar.Enabled = false;
            }
            else
            {
                MessageBox.Show(tbExt.Rows[0]["cMensage"].ToString(), "Aprobar/Rechazar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            RegAprRechaSolExt(3);
        }

    }
}
