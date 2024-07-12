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
using DEP.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;

namespace DEP.Presentacion
{
    
    public partial class frmMantenimientoCertificadoPF : frmBase
    {
        clsCNValorados clsOpeValorado = new clsCNValorados();

        public frmMantenimientoCertificadoPF()
        {
            InitializeComponent();
        }

        private void frmMantenimientoCertificadoPF_Load(object sender, EventArgs e)
        {
            nudFolio.Focus();
            nudFolio.Select(0,2);
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }
            LimpiarCtrls();
            DataTable dtCert = clsOpeValorado.CNRetornaDatosCertificado(Convert.ToInt32(nudFolio.Value));
            if (dtCert.Rows.Count>0)
            {
                txtEstado.Text = dtCert.Rows[0]["cEstadoVal"].ToString();
                nudLote.Value = Convert.ToInt32(dtCert.Rows[0]["nNumeroLote"].ToString());
                dtpFecReg.Value = Convert.ToDateTime(dtCert.Rows[0]["dFechaReg"].ToString());
                txtCodCertificado.Text = dtCert.Rows[0]["nNroCertificado"].ToString();
                txtNroCuenta.Text = dtCert.Rows[0]["idCuenta"].ToString();
                txtAgencia.Text = dtCert.Rows[0]["cNomCorto"].ToString();
                txtMotEnvio.Text = dtCert.Rows[0]["cDescriEnvio"].ToString();
                txtMotRecep.Text = dtCert.Rows[0]["cDescriRecepcion"].ToString();
                txtMotAnu.Text = dtCert.Rows[0]["cMotivoAnula"].ToString();
                chcAnular.Enabled = false;
                if (Convert.ToInt32(dtCert.Rows[0]["idEstado"].ToString())<=6) //6-- Estado Activo
                {
                    chcAnular.Enabled = true;
                }
                nudFolio.Enabled = false;
                btnProcesar.Enabled = false;
                chcAnular.Focus();
            }
            else
            {
                MessageBox.Show("El Número de Folio Buscado, No existe", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nudFolio.Focus();
                return;
            }
        }

        private void LimpiarCtrls()
        {
            txtEstado.Clear();
            dtpFecReg.Value = clsVarGlobal.dFecSystem;
            txtCodCertificado.Clear();
            txtNroCuenta.Clear();
            txtAgencia.Clear();
            txtMotEnvio.Clear();
            txtMotRecep.Clear();
            txtMotAnu.Clear();
            chcAnular.Checked = false;
            txtAnular.Clear();
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(nudFolio.Value.ToString()))
            {
                MessageBox.Show("Debe Ingresar un Número de Folio a Buscar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nudFolio.Focus();
                return false;
            }
            if (nudFolio.Value <= 0)
            {
                MessageBox.Show("Debe ingresar un Número de Folio Válido", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nudFolio.Focus();
                nudFolio.Select();
                return false;
            }
            return true;
        }

        private void chcAnular_CheckedChanged(object sender, EventArgs e)
        {
            txtAnular.Clear();
            if (chcAnular.Checked)
            {
                btnAnular.Enabled = true;
                txtAnular.Enabled = true;
                txtAnular.Focus();
            }
            else
            {                
                btnAnular.Enabled = false;
                txtAnular.Enabled = false;
            }
        }

        private void nudFolio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                this.btnProcesar.PerformClick();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCtrls();
            chcAnular.Enabled = false;
            txtAnular.Enabled = false;
            nudFolio.Enabled = true;
            btnProcesar.Enabled = true;
            btnAnular.Enabled = false;
            nudFolio.Value = 0;
            nudFolio.Focus();
            nudFolio.Select();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nudFolio.Value.ToString()))
            {
                MessageBox.Show("El número de folio no puede estar vacio..Revisar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (nudFolio.Value<=0)
            {
                MessageBox.Show("El número de folio No puede ser cero o Menor", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(txtAnular.Text))
            {
                MessageBox.Show("Debe ingresar el motivo de la anulación del Certificado", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var Msg = MessageBox.Show("Esta Seguro de Eliminar el Certificado?...", "Validar Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Msg == DialogResult.No)
            {
                return;
            }
            int idCuenta=0;
            //-----Datos paar Guardar
            if (!string.IsNullOrEmpty(txtNroCuenta.Text))
	        {
                idCuenta=Convert.ToInt32(txtNroCuenta.Text);		 
	        }
            string cMotivo=txtAnular.Text;

            DataTable dtAnuCert = clsOpeValorado.CNAnularCertificado(Convert.ToInt32(nudFolio.Value), idCuenta, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, cMotivo);
            if (Convert.ToInt32(dtAnuCert.Rows[0]["idRpta"].ToString()) == 0)
            {
                btnAnular.Enabled = false;
                MessageBox.Show(dtAnuCert.Rows[0]["cMensage"].ToString(), "Anular Certificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chcAnular.Enabled = false;
                txtAnular.Enabled = false;
            }
            else
            {
                MessageBox.Show(dtAnuCert.Rows[0]["cMensage"].ToString(), "Anular Certificado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

    }
}
