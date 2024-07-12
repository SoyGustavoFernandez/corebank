using CRE.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class frmValorizacionInventario : frmBase
    {
        private clsCNEvalAgrop objCapaNegocio;
        private int idValorizacionInventario;
        private int idEvaluacionPecuaria;
        private int idTipoInventario;
        public decimal nValorActual;

        private int idPlantelFijo = 10;
        private int idSaca = 11;
        private decimal nCantidadTotal = 0;

        public frmValorizacionInventario(int _idEvaluacionPecuaria, int _idTipoInventario)
        {
            InitializeComponent();

            this.idEvaluacionPecuaria = _idEvaluacionPecuaria;
            this.idTipoInventario = _idTipoInventario;
            this.nValorActual = 0;
            this.objCapaNegocio = new clsCNEvalAgrop();
            DataSet dsPec = this.objCapaNegocio.ObtenerMovimientosEvalPecuario(_idEvaluacionPecuaria);
            this.nCantidadTotal = 0;

            for (int i = 0; i < dsPec.Tables[0].Rows.Count; i++)
            {
                DataRow myRow = dsPec.Tables[0].Rows[i];
                if (Convert.ToInt32(myRow["idTipMovEvalPecuario"]) == 1)
                {
                    this.nCantidadTotal = this.nCantidadTotal + Convert.ToDecimal(myRow["nCantidad"]);
                }
            }
            this.lblCantidadMaxima.Text = Convert.ToString(this.nCantidadTotal);

            if (this.idTipoInventario == this.idPlantelFijo)
            {
                this.tabControl1.TabPages.RemoveAt(0);
                this.tabControl1.TabPages.RemoveAt(0);
                this.txtTotalAjustadoSaca.Text = "0";
                this.lblBase9.Text = "";
                this.lblCantidadMaxima.Text = "";
            }
            else if (this.idTipoInventario == this.idSaca)
            {
                this.tabControl1.TabPages.RemoveAt(2);
                this.inicializarComboBoxUnidadMedida();
                this.txtTotalAjustadoPFP.Text = "0";
                this.txtTotalAjustadoPFC.Text = "0";
            }

            this.leerValoracion();
        }

        private void inicializarComboBoxUnidadMedida()
        {
            DataTable dtUnidadVenta = new DataTable("unidad");
            dtUnidadVenta.Columns.Add("idUnidad", typeof(Int32));
            dtUnidadVenta.Columns.Add("cUnidad", typeof(string));

            dtUnidadVenta.Rows.Add(1, "Kg");
            dtUnidadVenta.Rows.Add(2, "Cabeza");
            dtUnidadVenta.Rows.Add(3, "Colmena");
            dtUnidadVenta.Rows.Add(4, "Unidad");
            dtUnidadVenta.Rows.Add(5, "Millar");
            dtUnidadVenta.Rows.Add(6, "Ciento");

            this.cboUniVentaPFP.DisplayMember = "cUnidad";
            this.cboUniVentaPFP.ValueMember = "idUnidad";
            this.cboUniVentaPFP.DataSource = dtUnidadVenta;
        }

        private void leerValoracion()
        {
            DataTable dtValoracion = this.objCapaNegocio.ObtenerValoracionInventario(this.idEvaluacionPecuaria);
            this.idValorizacionInventario = Convert.ToInt32(dtValoracion.Rows[0]["idValorizacionInventario"]);

            if (this.idTipoInventario == this.idSaca)
            {
                this.txtCantidadPFP.Text = Convert.ToString(dtValoracion.Rows[0]["nCantidadPP"]);
                this.cboUniVentaPFP.SelectedValue = Convert.ToInt32(dtValoracion.Rows[0]["idUnidadVentaPP"]);
                this.txtRendPFP.Text = Convert.ToString(dtValoracion.Rows[0]["nRendimientoPP"]);
                this.txtPrecioUniPFP.Text = Convert.ToString(dtValoracion.Rows[0]["nPrecioPP"]);
                this.txtTotalPFP.Text = Convert.ToString(dtValoracion.Rows[0]["nTotalPP"]);
                this.txtTotalAjustadoPFP.Text = Convert.ToString(dtValoracion.Rows[0]["nTotalAjustadoPP"]);

                this.txtCantidadPFC.Text = Convert.ToString(dtValoracion.Rows[0]["nCantidadPC"]);
                this.txtCostoCompraPFC.Text = Convert.ToString(dtValoracion.Rows[0]["nCostoCompraPC"]);
                this.txtGastoAlimentoPFC.Text = Convert.ToString(dtValoracion.Rows[0]["nGastoAlimentoPC"]);
                this.txtCostoTotalPFC.Text = Convert.ToString(dtValoracion.Rows[0]["nTotalPC"]);
                this.txtTotalAjustadoPFC.Text = Convert.ToString(dtValoracion.Rows[0]["nTotalAjustadoPC"]);

                this.nValorActual = Convert.ToDecimal(dtValoracion.Rows[0]["nTotalAjustadoPP"]) + Convert.ToDecimal(dtValoracion.Rows[0]["nTotalAjustadoPC"]);
            }
            else if (this.idTipoInventario == this.idPlantelFijo)
            {
                this.txtCantidadSaca.Text = Convert.ToString(dtValoracion.Rows[0]["nCantidadSaca"]);
                this.txtRendimientoUniSaca.Text = Convert.ToString(dtValoracion.Rows[0]["nRendimientoSaca"]);
                this.txtPrecioUniSaca.Text = Convert.ToString(dtValoracion.Rows[0]["nPrecioSaca"]);
                this.txtTotalSaca.Text = Convert.ToString(dtValoracion.Rows[0]["nTotalSaca"]);
                this.txtTotalAjustadoSaca.Text = Convert.ToString(dtValoracion.Rows[0]["nTotalAjustadoSaca"]);

                this.nValorActual = Convert.ToDecimal(dtValoracion.Rows[0]["nTotalAjustadoSaca"]);
            }
        }

        #region Plantel Fijo(produccion)
        private void txtCantidadPFP_TextChanged(object sender, EventArgs e)
        {
            this.validarFormularioPFP();
        }

        private void txtRendPFP_TextChanged(object sender, EventArgs e)
        {
            this.validarFormularioPFP();
        }

        private void txtPrecioUniPFP_TextChanged(object sender, EventArgs e)
        {
            this.validarFormularioPFP();
        }
        private void validarFormularioPFP()
        {
            if (
                this.txtCantidadPFP.Text == null ||
                this.txtCantidadPFP.Text.Trim() == "" ||
                this.txtRendPFP.Text == null ||
                this.txtRendPFP.Text.Trim() == "" ||
                this.txtPrecioUniPFP.Text == null ||
                this.txtPrecioUniPFP.Text.Trim() == ""
            )
            {
                this.txtTotalPFP.Text = Convert.ToString(0);
            }
            else
            {
                decimal nCantidad = Convert.ToDecimal(this.txtCantidadPFP.Text);
                decimal nRendimmiento = Convert.ToDecimal(this.txtRendPFP.Text);
                decimal nPrecio = Convert.ToDecimal(this.txtPrecioUniPFP.Text);
                this.txtTotalPFP.Text = (nCantidad * nRendimmiento * nPrecio).ToString("n2");
            }
        }
        private void txtTotalPFP_TextChanged(object sender, EventArgs e)
        {
            if (this.txtTotalPFP.Text == null || this.txtTotalPFP.Text.Trim() == "")
            {
                this.txtTotalAjustadoPFP.Text = Convert.ToString(0);
            }
            else
            {
                decimal nAjustado = (Convert.ToDecimal(this.txtTotalPFP.Text) * 90) / 100;
                this.txtTotalAjustadoPFP.Text = nAjustado.ToString("n2");
            }
        }
        #endregion

        #region Plantel Fijo(comercio)
        private void txtCantidadPFC_TextChanged(object sender, EventArgs e)
        {
            this.validarFormularioPFC();
        }

        private void txtCostoCompraPFC_TextChanged(object sender, EventArgs e)
        {
            this.validarFormularioPFC();
        }

        private void txtGastoAlimentoPFC_TextChanged(object sender, EventArgs e)
        {
            this.validarFormularioPFC();
        }

        private void validarFormularioPFC()
        {
            if (
                this.txtCantidadPFC.Text == null ||
                this.txtCantidadPFC.Text.Trim() == "" ||
                this.txtCostoCompraPFC.Text == null ||
                this.txtCostoCompraPFC.Text.Trim() == "" ||
                this.txtGastoAlimentoPFC.Text == null ||
                this.txtGastoAlimentoPFC.Text.Trim() == ""
            )
            {
                this.txtCostoTotalPFC.Text = Convert.ToString(0);
            }
            else
            {
                decimal nCantidad = Convert.ToDecimal(this.txtCantidadPFC.Text);
                decimal nCostoCompra = Convert.ToDecimal(this.txtCostoCompraPFC.Text);
                decimal nGastoAlimento = Convert.ToDecimal(this.txtGastoAlimentoPFC.Text);
                this.txtCostoTotalPFC.Text = (nCantidad * nCostoCompra + nCantidad * nGastoAlimento).ToString("n2");
            }
        }

        private void txtCostoTotalPFC_TextChanged(object sender, EventArgs e)
        {
            if (this.txtCostoTotalPFC.Text == null || this.txtCostoTotalPFC.Text.Trim() == "")
            {
                this.txtTotalAjustadoPFC.Text = Convert.ToString(0);
            }
            else
            {
                decimal nAjustado = (Convert.ToDecimal(this.txtCostoTotalPFC.Text) * 90) / 100;
                this.txtTotalAjustadoPFC.Text = nAjustado.ToString("n2");
            }
        }
        #endregion

        #region Saca
        private void txtCantidadSaca_TextChanged(object sender, EventArgs e)
        {
            this.validarFormularioSaca();
        }

        private void txtRendimientoUniSaca_TextChanged(object sender, EventArgs e)
        {
            this.validarFormularioSaca();
        }

        private void txtPrecioUniSaca_TextChanged(object sender, EventArgs e)
        {
            this.validarFormularioSaca();
        }
        private void validarFormularioSaca()
        {
            if (
                this.txtCantidadSaca.Text == null ||
                this.txtCantidadSaca.Text.Trim() == "" ||
                this.txtRendimientoUniSaca.Text == null ||
                this.txtRendimientoUniSaca.Text.Trim() == "" ||
                this.txtPrecioUniSaca.Text == null ||
                this.txtPrecioUniSaca.Text.Trim() == ""
            )
            {
                this.txtTotalSaca.Text = Convert.ToString(0);
            }
            else
            {
                decimal nCantidad = Convert.ToDecimal(this.txtCantidadSaca.Text);
                decimal nRendimmiento = Convert.ToDecimal(this.txtRendimientoUniSaca.Text);
                decimal nPrecio = Convert.ToDecimal(this.txtPrecioUniSaca.Text);
                this.txtTotalSaca.Text = (nCantidad * nRendimmiento * nPrecio).ToString("n2");
            }
        }
        private void txtTotalSaca_TextChanged(object sender, EventArgs e)
        {
            if (this.txtTotalSaca.Text == null || this.txtTotalSaca.Text.Trim() == "")
            {
                this.txtTotalAjustadoSaca.Text = Convert.ToString(0);
            }
            else
            {
                decimal nAjustado = (Convert.ToDecimal(this.txtTotalSaca.Text) * 90) / 100;
                this.txtTotalAjustadoSaca.Text = nAjustado.ToString("n2");
            }
        }
        #endregion

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (this.idTipoInventario == this.idSaca)
            {
                if (this.cboUniVentaPFP.SelectedValue == null || Convert.ToInt32(this.cboUniVentaPFP.SelectedValue) < 1)
                {
                    MessageBox.Show("Debe seleccionar unidad de medida", "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal nCantidadPP = Convert.ToDecimal(this.txtCantidadPFP.Text);
                int idUnidadVentaPP = Convert.ToInt32(this.cboUniVentaPFP.SelectedValue);
                decimal nRendimientoPP = Convert.ToDecimal(this.txtRendPFP.Text);
                decimal nPrecioPP = Convert.ToDecimal(this.txtPrecioUniPFP.Text);
                decimal nTotalPP = Convert.ToDecimal(this.txtTotalPFP.Text);
                decimal nTotalAjustadoPP = Convert.ToDecimal(this.txtTotalAjustadoPFP.Text);

                decimal nCantidadPC = Convert.ToDecimal(this.txtCantidadPFC.Text);
                decimal nCostoCompraPC = Convert.ToDecimal(this.txtCostoCompraPFC.Text);
                decimal nGastoAlimentoPC = Convert.ToDecimal(this.txtGastoAlimentoPFC.Text);
                decimal nTotalPC = Convert.ToDecimal(this.txtCostoTotalPFC.Text);
                decimal nTotalAjustadoPC = Convert.ToDecimal(this.txtTotalAjustadoPFC.Text);

                decimal nCantidadSaca = 0;
                decimal nRendimientoSaca = 0;
                decimal nPrecioSaca = 0;
                decimal nTotalSaca = 0;
                decimal nTotalAjustadoSaca = 0;

                if (nCantidadPP + nCantidadPC > this.nCantidadTotal)
                {
                    MessageBox.Show("La cantidad no puede ser mayor a " + Convert.ToString(this.nCantidadTotal), "Registro de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.nValorActual = nTotalAjustadoPP + nTotalAjustadoPC;
                this.objCapaNegocio.InsActValoracionInventario(
                    this.idValorizacionInventario,
                    this.idEvaluacionPecuaria,
                    this.idTipoInventario,

                    nCantidadPP,
                    idUnidadVentaPP,
                    nRendimientoPP,
                    nPrecioPP,
                    nTotalPP,
                    nTotalAjustadoPP,

                    nCantidadPC,
                    nCostoCompraPC,
                    nGastoAlimentoPC,
                    nTotalPC,
                    nTotalAjustadoPC,

                    nCantidadSaca,
                    nRendimientoSaca,
                    nPrecioSaca,
                    nTotalSaca,
                    nTotalAjustadoSaca
                    );
            }
            else if (this.idTipoInventario == this.idPlantelFijo)
            {
                decimal nCantidadPP = 0;
                int idUnidadVentaPP = 0;
                decimal nRendimientoPP = 0;
                decimal nPrecioPP = 0;
                decimal nTotalPP = 0;
                decimal nTotalAjustadoPP = 0;

                decimal nCantidadPC = 0;
                decimal nCostoCompraPC = 0;
                decimal nGastoAlimentoPC = 0;
                decimal nTotalPC = 0;
                decimal nTotalAjustadoPC = 0;

                decimal nCantidadSaca = Convert.ToDecimal(this.txtCantidadSaca.Text);
                decimal nRendimientoSaca = Convert.ToDecimal(this.txtRendimientoUniSaca.Text);
                decimal nPrecioSaca = Convert.ToDecimal(this.txtPrecioUniSaca.Text);
                decimal nTotalSaca = Convert.ToDecimal(this.txtTotalSaca.Text);
                decimal nTotalAjustadoSaca = Convert.ToDecimal(this.txtTotalAjustadoSaca.Text);

                this.nValorActual = nTotalAjustadoSaca;
                this.objCapaNegocio.InsActValoracionInventario(
                    this.idValorizacionInventario,
                    this.idEvaluacionPecuaria,
                    this.idTipoInventario,

                    nCantidadPP,
                    idUnidadVentaPP,
                    nRendimientoPP,
                    nPrecioPP,
                    nTotalPP,
                    nTotalAjustadoPP,

                    nCantidadPC,
                    nCostoCompraPC,
                    nGastoAlimentoPC,
                    nTotalPC,
                    nTotalAjustadoPC,

                    nCantidadSaca,
                    nRendimientoSaca,
                    nPrecioSaca,
                    nTotalSaca,
                    nTotalAjustadoSaca
                    );
            }
                    
            this.Close();
        }
    }
}
