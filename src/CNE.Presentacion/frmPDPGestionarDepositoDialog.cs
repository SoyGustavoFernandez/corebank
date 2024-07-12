using CNE.CapaNegocio;
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

namespace CNE.Presentacion
{
    public partial class frmPDPGestionarDepositoDialog : frmBase
    {
        clsCNPdp cnRptPdp = new clsCNPdp();
        int idPDPSetDep;

        public frmPDPGestionarDepositoDialog()
        {
            InitializeComponent();
        }

        public void CargarComponentes(int nTipo, int nModalidad, int cboModEstado, int idPDPSetDep, string cIdTran, int idPDPEmisor, decimal nMonto, string cReceptor, string cNombres, string cApellidos, int idPDPEstado, string cMensaje)
        {
            if (nTipo == 1) //Nuevo
            {
                this.idPDPSetDep = idPDPSetDep;
                this.cboPDPEmisor.cargarVigentes();
                this.cboPDPEstado.ModalidadPDPEstado(cboModEstado);

                this.txtIdTran.Enabled = false;
                this.txtIdTran.Text = cIdTran;

                if (nModalidad == 0)
                {
                    this.rbtModalidad1.Checked = false;
                    this.rbtModalidad2.Checked = false;
                }
                else if (nModalidad == 1)
                {
                    this.rbtModalidad1.Checked = true;
                    this.rbtModalidad2.Checked = false;
                }
                else if (nModalidad == 2)
                {
                    this.rbtModalidad1.Checked = false;
                    this.rbtModalidad2.Checked = true;
                }

                this.cboPDPEstado.Enabled = false;

                this.cboPDPEmisor.SelectedValue = idPDPEmisor;
                this.txtMonto.Text = (nMonto == 0) ? string.Empty : nMonto.ToString();
                //this.txtReceptor.Text = cReceptor;
                this.txtNombres.Text = cNombres;
                this.txtApellidos.Text = cApellidos;
                this.cboPDPEstado.SelectedValue = idPDPEstado;
                this.txtMensaje.Text = cMensaje;   
            }
            else if (nTipo == 2) //Actualizacion
            {
                this.rbtModalidad1.Enabled = false;
                this.rbtModalidad2.Enabled = false;

                this.idPDPSetDep = idPDPSetDep;
                this.cboPDPEmisor.cargarVigentes();
                this.cboPDPEstado.ModalidadPDPEstado(cboModEstado);

                this.txtIdTran.Enabled = false;
                this.txtIdTran.Text = cIdTran;

                if (nModalidad == 0)
                {
                    this.rbtModalidad1.Checked = false;
                    this.rbtModalidad2.Checked = false;
                }
                else if (nModalidad == 1)
                {
                    this.rbtModalidad1.Checked = true;
                    this.rbtModalidad2.Checked = false;
                }
                else if (nModalidad == 2)
                {
                    this.rbtModalidad1.Checked = false;
                    this.rbtModalidad2.Checked = true;
                }

                this.cboPDPEstado.Enabled = true;

                this.cboPDPEmisor.SelectedValue = idPDPEmisor;
                this.txtMonto.Text = (nMonto == 0) ? string.Empty : nMonto.ToString();
                this.txtReceptor.Text = cReceptor;
                this.txtNombres.Text = cNombres;
                this.txtApellidos.Text = cApellidos;
                this.cboPDPEstado.SelectedValue = idPDPEstado;
                this.txtMensaje.Text = cMensaje;
            }           
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {            
            if (this.rbtModalidad1.Checked == false && this.rbtModalidad2.Checked == false)
            {
                MessageBox.Show("Debe elegir una modalidad antes de continuar", "Deposito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(this.txtMonto.Text))
            {
                MessageBox.Show("Debe ingresar un monto antes de continuar", "Deposito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.rbtModalidad2.Checked == true && this.txtReceptor.Text.Trim().Length < 11)
            {
                MessageBox.Show("Debe ingresar un MSISDN mayor a 10 caracteres", "Deposito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.rbtModalidad1.Checked == true && this.txtMensaje.Text.Trim().Length < 4)
            {
                MessageBox.Show("Debe ingresar una Referencia correcta como se muestra en el ejemplo", "Deposito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int nModalidad = (this.rbtModalidad1.Checked == true) ? 1 : 2;
            int idPDPSetDep = this.idPDPSetDep;
            int idPDPEmisor = (int)this.cboPDPEmisor.SelectedValue;
            int idUsuario = clsVarGlobal.User.idUsuario;
            decimal nMonto = Convert.ToDecimal(this.txtMonto.Text);
            string cReceptor = this.txtReceptor.Text.Trim();
            string cNombres = this.txtNombres.Text.Trim();
            string cApellidos = this.txtApellidos.Text.Trim();
            int idPDPEstado = (int)this.cboPDPEstado.SelectedValue;
            string cMensaje = this.txtMensaje.Text.Trim();

            if (this.idPDPSetDep == 0) //Nuevo
            {
                this.cnRptPdp.NuevoDeposito(nModalidad, idPDPEmisor, idUsuario, nMonto, cReceptor, cNombres, cApellidos, idPDPEstado, cMensaje);
            }
            else //Actualiza
            {
                this.cnRptPdp.ActualizarDeposito(nModalidad, idPDPSetDep, idPDPEmisor, idUsuario, nMonto, cReceptor, cNombres, cApellidos, idPDPEstado, cMensaje);
            }
            
            this.Close();
        }

        private void rbtModalidad1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtModalidad1.Checked == true)
            {
                this.cboPDPEmisor.SelectedIndex = 0;

                this.txtMonto.Text = string.Empty;

                this.txtReceptor.Text = "FRI:/CA";
                this.txtReceptor.Enabled = false;

                this.lblFriFondeo.Visible = false;

                this.txtNombres.Text = string.Empty;
                this.txtNombres.Enabled = false;

                this.txtApellidos.Text = string.Empty;
                this.txtApellidos.Enabled = false;

                this.txtMensaje.Text = string.Empty;

                this.lblRefCompe.Visible = true;
            }
            else if (this.rbtModalidad2.Checked == true)
            {
                this.cboPDPEmisor.SelectedValue = 28;

                this.txtMonto.Text = string.Empty;

                this.txtReceptor.Text = string.Empty;
                this.txtReceptor.Enabled = true;

                this.lblFriFondeo.Visible = true;

                this.txtNombres.Text = string.Empty;
                this.txtNombres.Enabled = true;

                this.txtApellidos.Text = string.Empty;
                this.txtApellidos.Enabled = true;

                this.txtMensaje.Text = string.Empty;

                this.lblRefCompe.Visible = false;
            }
        }
    }
}
