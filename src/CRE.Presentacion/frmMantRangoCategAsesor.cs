using CRE.CapaNegocio;
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

namespace CRE.Presentacion
{
    public partial class frmMantRangoCategAsesor : frmBase
    {
        #region

        Transaccion operacion = Transaccion.Selecciona;
        clsCNMeta cnmeta = new clsCNMeta();
        string cTituloMsg = "Mantenimiento categoria asesor";

        #endregion

        public frmMantRangoCategAsesor()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmMantRangoCategAsesor_Load(object sender, EventArgs e)
        {
            cboCategoriaPersonal1.cargarCategoria(0, true);
            seleccionarCategoria();
            habilitarControles(false);
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (this.cboCategoria.Items.Count == 0)
            {
                MessageBox.Show("No existe registros por editar", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            operacion = Transaccion.Edita;
            btnEditar1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
            habilitarControles(true);
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            operacion = Transaccion.Selecciona;
            btnEditar1.Enabled = true;
            btnCancelar1.Enabled = false;
            btnGrabar1.Enabled = false; seleccionarCategoria();
            habilitarControles(false);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                int idCategoria = Convert.ToInt32(txtCodigo.Text);
                decimal nValMin = txtSaldoMinGes.nDecValor;
                decimal nValMax = txtSaldoMaxGes.nDecValor;
                Boolean lVigente = chcVigente.Checked;
                int nNroCliMinGes = Convert.ToInt32(txtNroCliMinGes.Text.Trim());
                int nNroCliMaxGes = Convert.ToInt32(txtNroCliMaxGes.Text.Trim());
                decimal nSaldoMaxTras = txtSaldoMaxTras.nDecValor;
                int nNroCliMaxTras = Convert.ToInt32(txtNroCliMaxTras.Text.Trim());
                decimal nMontoColocacion = txtSaldoCol.nDecValor;
                int nNroCreColocacion = Convert.ToInt32(txtNroCreCol.Text.Trim());
                int idCategoriaPersonal = Convert.ToInt32(cboCategoriaPersonal1.SelectedValue);

                string cmensaje = "";
                DataTable dtResultado;

                dtResultado = this.cnmeta.CNActualizarCategoriaAsesor(
                        idCategoria                 , nValMin               , nValMax               , nNroCliMaxTras
                        , nSaldoMaxTras             , nNroCliMinGes         , nNroCliMaxGes         , nMontoColocacion
                        , nNroCreColocacion         , idCategoriaPersonal   , lVigente);

                cmensaje = "Se registro correctamente los datos ingresados";

                if ((int)dtResultado.Rows[0][0] == 1)
                {
                    MessageBox.Show("Error al registrar los datos. \n comuníquese con el área de T.I.", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else //igual a 0
                {
                    MessageBox.Show(cmensaje, cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                btnEditar1.Enabled = true;
                btnCancelar1.Enabled = false;
                btnGrabar1.Enabled = false;
                operacion = Transaccion.Selecciona;
                seleccionarCategoria();
                habilitarControles(false);
                cboCategoria.cargarDatos();
            }
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccionarCategoria();
        }

        #endregion

        #region Métodos

        private void seleccionarCategoria()
        {
            if (this.cboCategoria.Items.Count > 0)
            {
                var drActividadInterna = (DataRowView)cboCategoria.SelectedItem;
                this.txtDescripción.Text = drActividadInterna["cCategoriaAsesor"].ToString();
                this.txtCodigo.Text = drActividadInterna["idCategoriaAsesor"].ToString();

                this.txtSaldoMinGes.Text = drActividadInterna["nMinSaldoCarteraGestion"].ToString();
                this.txtSaldoMaxGes.Text = drActividadInterna["nMaxSaldoCarteraGestion"].ToString();

                this.txtNroCliMinGes.Text = drActividadInterna["nMinNroClientesGestion"].ToString();
                this.txtNroCliMaxGes.Text = drActividadInterna["nMaxNroClientesGestion"].ToString();

                this.txtNroCliMaxTras.Text = drActividadInterna["nTopeTransNroCliMax"].ToString();
                this.txtSaldoMaxTras.Text = drActividadInterna["nTopeTransSaldoMax"].ToString();

                this.txtNroCreCol.Text = drActividadInterna["nNroCreditosMetaColocacion"].ToString();
                this.txtSaldoCol.Text = drActividadInterna["nMontoMetaColocacion"].ToString();
                this.chcVigente.Checked = Convert.ToBoolean(drActividadInterna["lVigente"]);
                this.cboCategoriaPersonal1.SelectedValue = Convert.ToInt32(drActividadInterna["idCategoriaPersonal"]);
            }
        }

        private void habilitarControles(bool lEstado)
        {
            this.cboCategoria.Enabled = !lEstado;

            this.txtSaldoMaxGes.Enabled = lEstado;
            this.txtSaldoMinGes.Enabled = lEstado;
            this.txtNroCliMaxGes.Enabled = lEstado;
            this.txtNroCliMinGes.Enabled = lEstado;
            this.txtNroCliMaxTras.Enabled = lEstado;
            this.txtSaldoMaxTras.Enabled = lEstado;
            this.txtNroCreCol.Enabled = lEstado;
            this.txtSaldoCol.Enabled = lEstado;
            this.cboCategoriaPersonal1.Enabled = lEstado;
            this.chcVigente.Enabled = lEstado;
        }

        private bool validar()
        {
            bool lValida = false;

            if (cboCategoriaPersonal1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar la categoría del personal", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCategoriaPersonal1.Focus();
                return lValida;
            }

            if (txtSaldoMinGes.nvalor >= txtSaldoMaxGes.nvalor)
            {
                MessageBox.Show("Gestion de cartera: el saldo mímino no puede ser mayor o igual a el saldo máximo", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSaldoMinGes.Focus();
                return lValida;
            }

            if (txtNroCliMinGes.nvalor >= txtNroCliMaxGes.nvalor)
            {
                MessageBox.Show("Gestion de cartera: el número de clientes mímino no puede ser mayor o igual a el Nro. de clientes máximo", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNroCliMinGes.Focus();
                return lValida;
            }

            if (String.IsNullOrEmpty(txtSaldoMaxTras.Text.Trim()))
            {
                MessageBox.Show("Tope transferencia de cartera: ingrese un valor para el saldo máximo", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSaldoMaxTras.Focus();
                return lValida;
            }

            if (String.IsNullOrEmpty(txtNroCliMaxTras.Text.Trim()))
            {
                MessageBox.Show("Tope transferencia de cartera: ingrese un valor para el Nro. clientes máximo", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNroCliMaxTras.Focus();
                return lValida;
            }

            if (String.IsNullOrEmpty(txtSaldoCol.Text.Trim()))
            {
                MessageBox.Show("Metas colocaciones: ingrese un valor para el Monto colocación", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSaldoCol.Focus();
                return lValida;
            }

            if (String.IsNullOrEmpty(txtNroCreCol.Text.Trim()))
            {
                MessageBox.Show("Metas colocaciones: ingrese un valor para el Nro. créditos", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNroCreCol.Focus();
                return lValida;
            }

            lValida = true;
            return lValida;
        }

        #endregion
    }
}
