using EntityLayer;
using GEN.ControlesBase;
using SER.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SER.Presentacion
{
    public partial class frmBloqueoDesbloqueoGiro : frmBase
    {
        #region variables
        clsCNControlServ cncontrolserv = new clsCNControlServ();
        String cTituloMensajes = "Desbloqueo de giros";
        int idGiro = 0;

        #endregion
       
        public frmBloqueoDesbloqueoGiro()
        {
            InitializeComponent();
        }

        #region eventos
        private void frmBloqueoDesbloqueoGiro_Load(object sender, EventArgs e)
        {
            
        }
        private void btnLiberar_Click(object sender, EventArgs e)
        {
            DataTable dtDesbloquear = cncontrolserv.DesbloquearGiro(this.idGiro, clsVarGlobal.User.idUsuario);
            MessageBox.Show(dtDesbloquear.Rows[0]["cMensaje"].ToString(), this.cTituloMensajes, MessageBoxButtons.OK, ((int)dtDesbloquear.Rows[0]["idResultado"] == -1 ? MessageBoxIcon.Exclamation : MessageBoxIcon.Information));
            limpiarControles();
        }
        private void btnMiniBusq_Click(object sender, EventArgs e)
        {
            buscarGiro();
        }
        private void chcDesbloqueados_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chcDesbloqueados.Checked)
            {
                cargarDTVGiros(true);
            }
            else
            {
                limpiarControles();
            }
        }
        private void dtgGiros_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgGiros.SelectedRows.Count > 0)
            {
                this.idGiro = Convert.ToInt32(dtgGiros.SelectedRows[0].Cells["idServGiro"].Value);
                this.txtUsuarioBlo.Text = Convert.ToString(dtgGiros.SelectedRows[0].Cells["cWinUser"].Value);
                this.txtAgeBlo.Text = Convert.ToString(dtgGiros.SelectedRows[0].Cells["cNombreAge"].Value);
                if (Convert.ToBoolean(dtgGiros.SelectedRows[0].Cells["lBloqueo"].Value))
                {
                    this.btnLiberar.Enabled = true;
                }
                else
                {
                    this.btnLiberar.Enabled = false;
                }
            }
        }
        #endregion

        #region metodos
        private void cargarDTVGiros(Boolean bloqueados)
        {
            DataTable dtGiros = cncontrolserv.ListadoGirosXbloqueo(0, bloqueados);
            this.dtgGiros.DataSource = dtGiros;
            formatoDTGGiros();
        }
        private void formatoDTGGiros()
        {
            foreach (DataGridViewColumn item in this.dtgGiros.Columns)
            {
                item.Visible = false;
            }
            this.dtgGiros.Columns["idServGiro"].Visible = true;
            this.dtgGiros.Columns["dFechaGiro"].Visible = true;
            this.dtgGiros.Columns["cSimbolo"].Visible = true;
            this.dtgGiros.Columns["nMontoGiro"].Visible = true;
            this.dtgGiros.Columns["cAgenciaRem"].Visible = true;
            this.dtgGiros.Columns["cRemitente"].Visible = true;
            this.dtgGiros.Columns["cNroDniRem"].Visible = true;
            this.dtgGiros.Columns["cAgenciaDes"].Visible = true;
            this.dtgGiros.Columns["cDestinatario"].Visible = true;
            this.dtgGiros.Columns["cNroDniDes"].Visible = true;
            this.dtgGiros.Columns["cNomEstado"].Visible = true;

            this.dtgGiros.Columns["idServGiro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgGiros.Columns["nMontoGiro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dtgGiros.Columns["idServGiro"].HeaderText = "Nº Giro";
            this.dtgGiros.Columns["dFechaGiro"].HeaderText = "Fech.Giro";
            this.dtgGiros.Columns["cSimbolo"].HeaderText = "";
            this.dtgGiros.Columns["nMontoGiro"].HeaderText = "Monto";
            this.dtgGiros.Columns["cAgenciaRem"].HeaderText = "Ag. Remitente";
            this.dtgGiros.Columns["cRemitente"].HeaderText = "Remitente";
            this.dtgGiros.Columns["cNroDniRem"].HeaderText = "Doc.Remit.";
            this.dtgGiros.Columns["cAgenciaDes"].HeaderText = "Ag. Destino";
            this.dtgGiros.Columns["cDestinatario"].HeaderText = "Beneficiario";
            this.dtgGiros.Columns["cNroDniDes"].HeaderText = "Doc.Dest.";
            this.dtgGiros.Columns["cNomEstado"].HeaderText = "Estado Giro";

            this.dtgGiros.Columns["idServGiro"].Width = 25;
            this.dtgGiros.Columns["dFechaGiro"].Width = 55;
            this.dtgGiros.Columns["cSimbolo"].Width = 20;
            this.dtgGiros.Columns["nMontoGiro"].Width = 50;
            this.dtgGiros.Columns["cAgenciaRem"].Width = 60;
            this.dtgGiros.Columns["cRemitente"].Width = 120;
            this.dtgGiros.Columns["cNroDniRem"].Width = 50;
            this.dtgGiros.Columns["cAgenciaDes"].Width = 60;
            this.dtgGiros.Columns["cDestinatario"].Width = 120;
            this.dtgGiros.Columns["cNroDniDes"].Width = 50;
            this.dtgGiros.Columns["cNomEstado"].Width = 50;        
        }
        private void limpiarControles()
        {
            DataTable dtGiros = cncontrolserv.ListadoGirosXbloqueo(-1, this.chcDesbloqueados.Checked);
            this.dtgGiros.DataSource = dtGiros;
            formatoDTGGiros();
            this.txtUsuarioBlo.Clear();
            this.txtAgeBlo.Clear();
            this.chcDesbloqueados.Checked = false;
        }
        private void buscarGiro()
        {
            int i;            
            if (!String.IsNullOrEmpty(this.txtBuscarNroGiro.Text) && int.TryParse(this.txtBuscarNroGiro.Text, out i))
            {
                limpiarControles();
                DataTable dtGiros = cncontrolserv.ListadoGirosXbloqueo(Convert.ToInt32(this.txtBuscarNroGiro.Text), this.chcDesbloqueados.Checked);
                this.dtgGiros.DataSource = dtGiros;
                formatoDTGGiros();
                this.txtBuscarNroGiro.Clear();
            }
        }
        #endregion 

        private void txtBuscarNroGiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buscarGiro();
            }
        }

    }
}
