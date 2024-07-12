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
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class frmAnulaTasaNegociable : frmBase
    {
        public int idTasaNegociada, idEstado;
        public bool lDenegado = false;

        public frmAnulaTasaNegociable()
        {
            InitializeComponent();
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (cboMotivoAnula.Text == "")
            {
                MessageBox.Show("Debe seleccionar el motivo de ANULACIÓN.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboMotivoAnula.Text == "OTROS" && txtOtrosAnula.Text == "")
            {
                MessageBox.Show("Debe especificar el motivo OTROS.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsCNSolicitud cnsolicitud = new clsCNSolicitud();
            DataTable dsSolxid = cnsolicitud.CNBuscaSolicitudxidTasaNegociable(idTasaNegociada);
            if (dsSolxid.Rows.Count > 0)
            {
                if (dsSolxid.Rows[0]["idEstado"].ToString() == "5")
                {
                    MessageBox.Show("La solicitud se encuentra ANULADO.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                if (dsSolxid.Rows[0]["idEstado"].ToString() == "4")
                {
                    MessageBox.Show("La solicitud se encuentra DENEGADO.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.OK;
                    return;
                }
            }

            string cTipoEvento = "";
            if (lDenegado == true) 
            {
                cTipoEvento = "D";
            }
            else 
            {
                cTipoEvento = "A";
            }

            DataTable Resultado = cnsolicitud.CNAnularDenegarSolicitudTasaNegociable(idTasaNegociada, idEstado, clsVarGlobal.User.idUsuario, Convert.ToInt32(cboMotivoAnula.SelectedValue.ToString()),txtOtrosAnula.Text, cTipoEvento);
            if (Resultado.Rows.Count > 0)
            {
                MessageBox.Show(Resultado.Rows[0]["cMensaje"].ToString(), "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (Resultado.Rows[0]["idError"].ToString() == "0") 
                { 
                    this.DialogResult = DialogResult.OK;                
                }               
           
            }
            else
            {
                MessageBox.Show("No se pudo anular/denegar la solicitud.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void listarMotivosAnulacion(int nItemvalue)
        {
            clsCNSolicitud cnsolicitudMT = new clsCNSolicitud();
            DataTable dtResultado = cnsolicitudMT.CNListaMotivoAnulaTasa();
            cboMotivoAnula.DataSource = dtResultado;
            cboMotivoAnula.ValueMember = dtResultado.Columns[0].ToString();
            cboMotivoAnula.DisplayMember = dtResultado.Columns[1].ToString();
            cboMotivoAnula.SelectedValue = nItemvalue;
        }

        private void frmAnulaTasaNegociable_Load(object sender, EventArgs e)
        {
            listarMotivosAnulacion(-1);
        }

        private void cboMotivoAnula_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMotivoAnula.Text == "OTROS")
            {
                lblOtrosAnula.Visible = true;
                txtOtrosAnula.Visible = true;
            }
            else
            {
                lblOtrosAnula.Visible = false;
                txtOtrosAnula.Visible = false;
            }
            txtOtrosAnula.Text = string.Empty;
        }


    }
}
