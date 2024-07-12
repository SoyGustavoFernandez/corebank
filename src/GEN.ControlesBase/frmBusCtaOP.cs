using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using DEP.CapaNegocio;
using EntityLayer;
using CLI.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class frmBusCtaOP : frmBase
    {
        public int pnCta=0,pcidMoneda;
        public string pcNroCuenta;

        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsCNFirmas cnFirma = new clsCNFirmas();

        public frmBusCtaOP()
        {
            InitializeComponent();
        }

        private void frmBusCtaOP_Load(object sender, EventArgs e)
        {
            this.conBusCtaOP.nTipOpe = 13;
            this.conBusCtaOP.pnIdMon = pcidMoneda;
            this.conBusCtaOP.idcuenta = 0;
            this.conBusCtaOP.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            this.conBusCtaOP.txtCodAge.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnAceptar.Enabled = false;
            btnCancelar.Enabled = false;
            this.conBusCtaOP.idcuenta = 0;
            pnCta = 0;
            pcNroCuenta = "";
            LimpiarCtrl();
            conBusCtaOP.LimpiarControles();
            conBusCtaOP.HabDeshabilitarCtrl(true);
            conBusCtaOP.txtCodAge.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }
            if (!ValidarFirmasReqOpe())  //--Validar Firmas Requeridas
            {
                return;
            }
            pnCta = conBusCtaOP.idcuenta;
            pcNroCuenta=conBusCtaOP.txtCodIns.Text + conBusCtaOP.txtCodAge.Text + conBusCtaOP.txtCodMod.Text + conBusCtaOP.txtCodMon.Text + conBusCtaOP.txtNroCta.Text;
            this.Dispose();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            pnCta = 0;
            pcNroCuenta = "";
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(conBusCtaOP.txtNroCta.Text))
            {
                MessageBox.Show("El número de Cuenta No puede estar Vacio....Revisar", "Búsqueda de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrEmpty(conBusCtaOP.txtCodCli.Text))
            {
                MessageBox.Show("El Codigo del Cliente esta vacio....Revisar", "Búsqueda de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrEmpty(conBusCtaOP.txtNombre.Text))
            {
                MessageBox.Show("El Nombre del Cliente esta vacio....Revisar", "Búsqueda de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (conBusCtaOP.idcuenta<=0)
            {
                MessageBox.Show("El Codigo de la Cuenta no es Válido...Revisar", "Búsqueda de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private Boolean ValidarFirmasReqOpe()
        {
            //--idTipoDocumento --
            int nNroFirmas = 0;
            //-----------------------------------------------------------------
            //--Validamos que una Jurídica no puede Firmar
            //-----------------------------------------------------------------
            for (int i = 0; i < dtgIntervinientes.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtgIntervinientes.Rows[i].Cells["isReqFirma"].Value) && Convert.ToInt16(dtgIntervinientes.Rows[i].Cells["idTipoPersona"].Value) >= 2)
                {
                    nNroFirmas++;
                    MessageBox.Show("La Persona Jurídica no pede Firmar para la Operación...Por Favor Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }

                if (Convert.ToBoolean(dtgIntervinientes.Rows[i].Cells["isReqFirma"].Value) && Convert.ToInt16(dtgIntervinientes.Rows[i].Cells["idTipoPersona"].Value) == 1 && Convert.ToInt16(dtgIntervinientes.Rows[i].Cells["nEdadCli"].Value) < 18)
                {
                    nNroFirmas++;
                    MessageBox.Show("El Cliente es menor de Edad, No puede firmar para la operación...Por Favor Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }

            }

            if (nNroFirmas > 0)
            {
                return false;
            }

            //-----------------------------------------------------------------
            //--Validamos la cantidad de firmas Requeridas
            //-----------------------------------------------------------------
            nNroFirmas = 0;
            for (int i = 0; i < dtgIntervinientes.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtgIntervinientes.Rows[i].Cells["isReqFirma"].Value))
                {
                    nNroFirmas++;
                }
            }
            Int16 nNroFirReq = Convert.ToInt16(conBusCtaOP.txtNumFirmas.Text);
            if (nNroFirmas != nNroFirReq)
            {
                MessageBox.Show("El Número de Firmas Requeridos, no es igual a lo Establecido para la Cuenta", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void LimpiarCtrl()
        {
            ptbFirma.Image = null;

            //--Datos del Cliente
            if (dtgIntervinientes.Rows.Count > 0)
            {
                ((DataTable)dtgIntervinientes.DataSource).Rows.Clear();
            }
            dtgIntervinientes.Refresh();
        }

        private void MostrarFirma(int idCliente)
        {
            ptbFirma.Image = null;
            var objFirma = cnFirma.retornaFirma(idCliente);
            if (objFirma != null)
            {
                ptbFirma.Image = objFirma.imgFirma;
                ptbFirma.Refresh();
            }

        }

        private void conBusCtaOP_ClicBusCta(object sender, EventArgs e)
        {
            LimpiarCtrl();
            if (conBusCtaOP.idcuenta<0)
            {
                MessageBox.Show("La búsqueda de la cuenta no es válido...Revisar", "Búsqueda de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCtaOP.txtCodAge.Focus();
                return;
            }
            if (string.IsNullOrEmpty(conBusCtaOP.txtNroCta.Text))
            {
                MessageBox.Show("La búsqueda de la cuenta no es válido...Revisar", "Búsqueda de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCtaOP.txtCodAge.Focus();
                return;
            }
            else
            {
                //--===================================================================================
                //--Cargar de Intervinientes de la Cuenta
                //--===================================================================================
                DataTable dtbIntervCta = clsDeposito.CNRetornaIntervinientesCuenta(conBusCtaOP.idcuenta);
                dtgIntervinientes.ReadOnly = false;
                if (dtbIntervCta.Rows.Count > 0)
                {
                    dtgIntervinientes.DataSource = dtbIntervCta;
                    if (dtbIntervCta.Rows.Count > 1)
                    {
                        dtgIntervinientes.Columns["cDocumentoID"].ReadOnly = true;
                        dtgIntervinientes.Columns["cNombre"].ReadOnly = true;
                        dtgIntervinientes.Columns["cTipoIntervencion"].ReadOnly = true;
                        dtbIntervCta.Columns["isReqFirma"].ReadOnly = false;
                        dtgIntervinientes.Columns["isReqFirma"].ReadOnly = false;
                    }
                    else
                    {
                        dtgIntervinientes.ReadOnly = true;
                    }
                }
                else
                {
                    conBusCtaOP.LimpiarControles();
                    conBusCtaOP.txtCodAge.Focus();
                    MessageBox.Show("El Cuenta no Tiene Intervinientes..VERIFICAR...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                conBusCtaOP.HabDeshabilitarCtrl(false);
                btnAceptar.Enabled = true;
                btnCancelar.Enabled = true;
                btnAceptar.Focus();
            }
        }

        private void dtgIntervinientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgIntervinientes.Rows.Count > 0)
            {
                MostrarFirma(Convert.ToInt32(dtgIntervinientes.CurrentRow.Cells["idCli"].Value));
            }
        }
    }
}
