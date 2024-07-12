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
    public partial class frmConfirmarRetiroCTS : frmBase
    {
        public int p_idSolicitud = 0;
        clsCNDeposito clsDeposito = new clsCNDeposito();

        public frmConfirmarRetiroCTS()
        {
            InitializeComponent();
        }

        private void frmConfirmarRetiroCTS_Load(object sender, EventArgs e)
        {
            this.cboMotivoOperacion.ListarMotivoOperacion(11, 0);
            ListarDatosSolicitudCTS(p_idSolicitud);
        }

        private void ListarDatosSolicitudCTS(int idSolicitud)
        {
            DataTable dtSol = clsDeposito.CNRetornaSolicitudCTS(idSolicitud);
            if (dtSol.Rows.Count>0)
            {
                dtpFecSolicitud.Value = Convert.ToDateTime(dtSol.Rows[0]["dFecSolici"].ToString());
                txtColaborador.Text = dtSol.Rows[0]["cNomSolicita"].ToString();
                cboMotivoOperacion.SelectedValue = Convert.ToInt16(dtSol.Rows[0]["idMotivo"].ToString());
                txtMonRetiro.Text = string.Format("{0:#,#0.00}", dtSol.Rows[0]["nValAproba"].ToString());
                txtMotCambio.Text = dtSol.Rows[0]["cSustento"].ToString();

                dtgAprobadores.DataSource = dtSol;
                FormatoGrid();
                btnAceptar.Enabled = true;
            }
            else
            {
                MessageBox.Show("No existe datos de la solicitud...Por favor Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
                return;
            }
        }

        private void FormatoGrid()
        {
            dtgAprobadores.Columns["idSolAproba"].Visible = false;
            dtgAprobadores.Columns["idTipoOperacion"].Visible = false;
            dtgAprobadores.Columns["idDocument"].Visible = false;
            dtgAprobadores.Columns["dFecSolici"].Visible = false;
            dtgAprobadores.Columns["idMotivo"].Visible = false;
            dtgAprobadores.Columns["nValAproba"].Visible = false;
            dtgAprobadores.Columns["cSustento"].Visible = false;
            dtgAprobadores.Columns["cNomSolicita"].Visible = false;
   
            dtgAprobadores.Columns["dFechaEmiOpi"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgAprobadores.Columns["dFechaEmiOpi"].HeaderText = "Fec. Apr";
            dtgAprobadores.Columns["dFechaEmiOpi"].Width=70;

            dtgAprobadores.Columns["cNomAproba"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgAprobadores.Columns["cNomAproba"].HeaderText = "Aprobador";
            dtgAprobadores.Columns["cNomAproba"].Width = 180;

            dtgAprobadores.Columns["cPerfil"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgAprobadores.Columns["cPerfil"].HeaderText = "Perfil";
            dtgAprobadores.Columns["cPerfil"].Width = 170;

            dtgAprobadores.Columns["cOpinion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgAprobadores.Columns["cOpinion"].HeaderText = "Opinión";

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        
    }
}
