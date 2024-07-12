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
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;
using GEN.Funciones;
using GEN.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmModificarRecibo : frmBase
    {
        private int nIndAfecITF = 0,idConcepAnt = 0;
        private bool lAfectaCaja = false,lAfectoItf=false;
        private DataTable tbConcep;

        public frmModificarRecibo()
        {
            InitializeComponent();
        }

        private void frmModificarRecibo_Load(object sender, EventArgs e)
        {
            CargarTiporecibos();            
            nudNroRecibo.Select();
            nudNroRecibo.Focus();
        }

        private void BuscarRecibo()
        {
            LimpiarControlesBus();

            if (this.nudNroRecibo.Value<=0)
            {
                MessageBox.Show("Debe Ingresar el Número de Recibo a Buscar...", "Buscar Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nudNroRecibo.Select();
                this.nudNroRecibo.Focus();
                return;
            }

            string msge = "";
            clsCNControlOpe DatosRecibo = new clsCNControlOpe();
            DataTable tbRec = DatosRecibo.BuscarRecibo(Convert.ToInt32(nudNroRecibo.Value), ref msge);
            if (msge == "OK")
            {
                if (tbRec.Rows.Count == 0)
                {
                    MessageBox.Show("El Nro de Recibo Buscado no Existe...", "Buscar Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.nudNroRecibo.Select();
                    this.nudNroRecibo.Focus();
                    this.btnCancelar.Enabled = true;
                    return;
                }

                if (tbRec.Rows[0]["cEstadoRec"].ToString() == "X")
                {
                    MessageBox.Show("El Nro de Recibo Buscado Esta ELIMINADO...", "Buscar Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.nudNroRecibo.Select();
                    this.nudNroRecibo.Focus();
                    this.btnCancelar.Enabled = true;
                    return;
                }
                               
                //============================================================
                //--Cargar Datos del Recibo
                //============================================================
                this.cboTipRec.SelectedValue = tbRec.Rows[0]["idTipRecibo"];
                this.cboMoneda.SelectedValue = tbRec.Rows[0]["idMoneda"];
                CargarConceptos(Convert.ToInt32(cboTipRec.SelectedValue));
                this.cboConcepto.SelectedValue = tbRec.Rows[0]["idConcepto"];
                idConcepAnt = Convert.ToInt32(tbRec.Rows[0]["idConcepto"]);

                this.conBusCli.CargardatosCli(Convert.ToInt32(tbRec.Rows[0]["idCli"].ToString()));
                                
                this.txtMonRec.Text = tbRec.Rows[0]["nMontoRec"].ToString();
                this.txtMonItf.Text = tbRec.Rows[0]["nMontoITF"].ToString();
                this.txtTotRec.Text = tbRec.Rows[0]["nMontoTot"].ToString();
                this.txtSustento.Text = tbRec.Rows[0]["cSustento"].ToString();

                lAfectaCaja = Convert.ToBoolean(tbRec.Rows[0]["lAfectaCaja"].ToString());
                //lAfectoItf = Convert.ToBoolean(tbRec.Rows[0]["nAfectoITF"].ToString());

                btnEditar.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.conBusCli.btnBusCliente.Enabled = false;
                nudNroRecibo.Enabled = false;
            }
            else
            {
                MessageBox.Show(msge, "Error al Extraer Datos del Recibo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarControlesBus()
        {
            this.conBusCli.limpiarControles();
            this.txtMonRec.Text = "0.00";
            this.txtMonItf.Text = "0.00";
            this.txtTotRec.Text = "0.00";
            this.txtSustento.Clear();
            txtMotivoCambio.Clear();
        }

        private void CargarTiporecibos()
        {
            clsCNControlOpe LisTiprec = new clsCNControlOpe();
            DataTable tbTipRec = LisTiprec.ListarTipRec();
            cboTipRec.DataSource = tbTipRec;
            cboTipRec.ValueMember = tbTipRec.Columns["idTipRecibo"].ToString();
            cboTipRec.DisplayMember = tbTipRec.Columns["cDescripcion"].ToString();
            cboTipRec.SelectedValue = 1;
        }

        private void CargarConceptos(int nTipRec)
        {
            /*C.idConcepto,C.cConcepto,C.cTipMonto,C.nMontoCon,C.nAfectoITF*/
            clsCNControlOpe LisConcep = new clsCNControlOpe();
            tbConcep = LisConcep.ListaConceptosPer(nTipRec, Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));

            cboConcepto.DataSource = tbConcep;
            cboConcepto.ValueMember = tbConcep.Columns["idConcepto"].ToString();
            cboConcepto.DisplayMember = tbConcep.Columns["cConcepto"].ToString();
            if (tbConcep.Rows.Count > 1)
            {
                cboConcepto.SelectedIndex = 1;
            }
            else
            {
                cboConcepto.SelectedIndex = 0;
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(cboConcepto.Text.ToString().Trim()))
            {
                MessageBox.Show("Debe Elegir un Concepto para el Recibo", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboConcepto.Select();
                cboConcepto.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMotivoCambio.Text))
            {
                MessageBox.Show("Debe Ingresar el Motivo de Cambio del Recibo", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMotivoCambio.Focus();
                return false;
            }

            if (Convert.ToInt32(cboConcepto.SelectedValue) == idConcepAnt)
            {
                MessageBox.Show("El nuevo concepto a cambiar, NO puede ser el Mismo concepto", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMotivoCambio.Focus();
                return false;
            }

            if (lAfectaCaja)
            {
                if (chcAfectaCaja.Checked ==false)
                {
                    MessageBox.Show("El concepto del recibo afectaba a Caja, el nuevo cocepto no Afecta a Caja, no es válido este cambio...Revisar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMotivoCambio.Focus();
                    return false;
                }
            }
            else
            {
                if (chcAfectaCaja.Checked == true)
                {
                    MessageBox.Show("El concepto del recibo NO afectaba a Caja, el nuevo cocepto SI Afecta a Caja, no es válido este cambio...Revisar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMotivoCambio.Focus();
                    return false;
                }
            }
            return true;
        }

        private void cboConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            nIndAfecITF = (int)tbConcep.Rows[this.cboConcepto.SelectedIndex]["nAfectoITF"];
            chcAfectaCaja.Checked = false;
            if (cboConcepto.SelectedIndex > 0)
            {
                chcAfectaCaja.Checked = (bool)tbConcep.Rows[this.cboConcepto.SelectedIndex]["lAfectaCaja"];
            }
        }

        private void nudNroRecibo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                BuscarRecibo();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControlesBus();
            btnEditar.Enabled = false;
            btnGrabar.Enabled = false;
            nudNroRecibo.Enabled = true;
            idConcepAnt = 0;
            lAfectaCaja = false;
            nudNroRecibo.Value = 0;
            nudNroRecibo.Select();
            nudNroRecibo.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cboConcepto.Enabled = true;
            txtMotivoCambio.Enabled = true;
            cboConcepto.Focus();
            btnEditar.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
	        {
                return;		 
	        }

            //======================================================================
            //--Obtener Datos Generales
            //======================================================================
            int idRecibo = Convert.ToInt32(nudNroRecibo.Value);
            int TipRec = Convert.ToInt32(this.cboTipRec.SelectedValue.ToString());
            int TipCon = Convert.ToInt32(this.cboConcepto.SelectedValue.ToString());
            string cMotCambio = txtMotivoCambio.Text;

            clsCNControlOpe GuardarRec = new clsCNControlOpe();

            DataTable dtResul = GuardarRec.ActualizarRecibo(idRecibo,TipCon,cMotCambio,clsVarGlobal.User.idUsuario,clsVarGlobal.nIdAgencia,clsVarGlobal.dFecSystem);
            if (Convert.ToInt16(dtResul.Rows[0]["idRpta"]) == 0)
            {
                MessageBox.Show(dtResul.Rows[0]["cMensaje"].ToString(), "Actualizar Datos del Recibo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(dtResul.Rows[0]["cMensaje"].ToString(), "Actualizar Datos del Recibo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            cboConcepto.Enabled = false;
            txtMotivoCambio.Enabled = false;
            btnEditar.Enabled = false;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = true;
        }
    }
}
