using GEN.ControlesBase;
using CNE.CapaNegocio;
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

namespace CNE.Presentacion
{
    public partial class frmPDPGestionaPagoDialog : frmBase
    {
        clsCNPdp cnRptPdp = new clsCNPdp();        

        public frmPDPGestionaPagoDialog()
        {
            InitializeComponent();
        }

        public void CargarComponentes(int idSetPar, int idPDPEmisor, string cIdInsPago, int idEstado, string cComentario)
        {
            this.cboPDPEmisor.cargarVigentes();
            this.cboPDPEstado.ModalidadPDPEstado(2);            

            this.txtItem.Text = Convert.ToString(idSetPar);
            this.cboPDPEmisor.SelectedValue = idPDPEmisor;
            this.txtIdInsPago.Text = cIdInsPago;            
            this.cboPDPEstado.SelectedValue = idEstado;

            if (cComentario.Equals("SUCCESS"))
            {
                this.rbtSuccess.Checked = true;
                this.rbtFailed.Checked = false;    
            }
            else if (cComentario.Equals("FAILED"))
            {
                this.rbtSuccess.Checked = false;
                this.rbtFailed.Checked = true;
            }            
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtIdInsPago.Text))
	        {
                MessageBox.Show("Ingrese la Instrucción de Pago antes de continuar.", "Instrucciones de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
	        }            

            if (this.rbtSuccess.Checked == false && this.rbtFailed.Checked == false)
	        {
		        MessageBox.Show("Elija una comentario de respuesta para continuar.", "Instrucciones de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
	        }

            int idSetPar = Convert.ToInt32(this.txtItem.Text);            
            string cIdInsPago = this.txtIdInsPago.Text;            
            int idEstado = (int)this.cboPDPEstado.SelectedValue;
            int idUsuario = clsVarGlobal.User.idUsuario;
            string cComentario = string.Empty;

            if (this.rbtSuccess.Checked == true)
            {
                cComentario = "SUCCESS";
            }
            else if (this.rbtFailed.Checked == true)
            {
                cComentario = "FAILED";
            }            

            this.cnRptPdp.GuardarPago(idSetPar, idEstado, idUsuario, cComentario);            

            this.Close();
        }              
    }
}
