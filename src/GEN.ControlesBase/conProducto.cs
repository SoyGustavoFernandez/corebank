using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.CapaNegocio;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class conProducto : UserControl
    {
        private int idOperacion;
        int nCodPro = 1;
        string cTituloMsg = "Productos";
        private bool _lMostrarTipoCredito;
        clsCNProducto cnProducto = new clsCNProducto();
        public bool lNivel { get; set; }
        public string cIDsTipEvalCred { get; set; }

        public event EventHandler ChangeProducto;

        String cTitTipoProducto = "Tipo Crédito";
        #region "Properties"
        public bool lMostrarTipoCredito
        {
            set
            {
                pnlTipCred.Visible = value;
                _lMostrarTipoCredito = value;
            }
            get
            {
                return _lMostrarTipoCredito;
            }
        }

        private bool _lBloquear3Niveles;

        public bool lBloquear3Niveles
        {
            set 
            {
                cboTipoCredito.Enabled = !value;
                cboSubTipoCredito.Enabled = !value;
                cboProducto.Enabled = !value;
                _lBloquear3Niveles = !value;
            }
            get
            {
                return _lBloquear3Niveles;
            }
        }

        #endregion

        public conProducto()
        {
            InitializeComponent();
            cboTipoCredito.CargarProducto(nCodPro);
            this.lblBase11.Text = this.cTitTipoProducto;
            limpiar();
        }

        public void limpiar()
        {
            cboTipoCredito.SelectedIndex = -1;
            cboSubTipoCredito.SelectedIndex = -1;
            cboProducto.SelectedIndex = -1;
            cboSubProducto.SelectedIndex = -1;

            errorProvider.SetError(this.cboTipoCredito, String.Empty);
            errorProvider.SetError(this.cboSubTipoCredito, String.Empty);
            errorProvider.SetError(this.cboProducto, String.Empty);
            errorProvider.SetError(this.cboSubProducto, String.Empty);
        }

        public Boolean validarSeleccion()
        {
            if (cboTipoCredito.SelectedIndex <= 0)
            {
                MessageBox.Show("Seleccione un tipo de crédito", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cboSubTipoCredito.SelectedIndex <= 0)
            {
                MessageBox.Show("Seleccione un sub tipo de crédito", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cboProducto.SelectedIndex <= 0)
            {
                MessageBox.Show("Seleccione un producto", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cboSubProducto.SelectedIndex <= 0)
            {
                MessageBox.Show("Seleccione un sub producto", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        public clsMsjError Validar()
        {
            var objMsjError = new clsMsjError();

            errorProvider.SetError(this.cboTipoCredito, String.Empty);
            errorProvider.SetError(this.cboSubTipoCredito, String.Empty);
            errorProvider.SetError(this.cboProducto, String.Empty);
            errorProvider.SetError(this.cboSubProducto, String.Empty);

            if (!EsTipoCreditoValido())
            {
                objMsjError.AddError("Tipo de Crédito, Seleccione una opción.");
                errorProvider.SetError(this.cboTipoCredito, "Seleccione un tipo de Crédito.");
            }

            if (!EsSubTipoCreditoValido())
            {
                objMsjError.AddError("Sub Tipo de Crédito, Seleccione una opción.");
                errorProvider.SetError(this.cboSubTipoCredito, "Seleccione un sub tipo de Crédito.");
            }

            if (!EsProductoValido())
            {
                objMsjError.AddError("Producto, Seleccione una opción.");
                errorProvider.SetError(this.cboProducto, "Seleccione un Producto.");
            }

            if (!EsSubProductoValido())
            {
                objMsjError.AddError("Sub Producto, Seleccione una opción.");
                errorProvider.SetError(this.cboSubProducto, "Seleccione un sub Producto.");
            }

            return objMsjError;
        }

        /// <summary>
        /// Carga de productos por modulo e idSubProducto
        /// </summary>
        /// <param name="idModulo">indice de la tabla SI_FinModulo</param>
        /// <param name="idSubProducto">indice de la tabla SI_FinProducto, el ultimo nivel</param>
        public void cargarProductos(int idModulo, int idSubProducto, int idOperacion = 0)
        {
            DataTable dtResultado = cnProducto.CNListaNivelesSupProductos(idModulo, idSubProducto);
            if (dtResultado.Rows.Count == 0)
            {
                MessageBox.Show("No se encontro datos", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.idOperacion = idOperacion;
            cboTipoCredito.SelectedValue = Convert.ToInt32(dtResultado.Rows[0]["IdProducto"]);
            cboSubTipoCredito.SelectedValue = Convert.ToInt32(dtResultado.Rows[1]["IdProducto"]);
            cboProducto.SelectedValue = Convert.ToInt32(dtResultado.Rows[2]["IdProducto"]);
            cboSubProducto.SelectedValue = Convert.ToInt32(dtResultado.Rows[3]["IdProducto"]);
        }

        /// <summary>
        /// Carga de productos por modulo e idProducto variable
        /// </summary>
        /// <param name="idModulo">indice de la tabla SI_FinModulo</param>
        /// <param name="idProducto">indice de la tabla SI_FinProducto, nivel de producto</param>
        public void cargarProductosVariable(int idModulo, int idProducto)
        {
            DataTable dtResultado = cnProducto.CNListaNivelesSupProductos(idModulo, idProducto);
            if (dtResultado.Rows.Count == 0)
            {
                MessageBox.Show("No se encontro datos", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dtResultado.Rows.Count == 1)
            {
                cboTipoCredito.SelectedValue = Convert.ToInt32(dtResultado.Rows[0]["IdProducto"]);
            }
            
            if (dtResultado.Rows.Count == 2)
            {
                cboTipoCredito.SelectedValue = Convert.ToInt32(dtResultado.Rows[0]["IdProducto"]);
                cboSubTipoCredito.SelectedValue = Convert.ToInt32(dtResultado.Rows[1]["IdProducto"]);
            }

            if (dtResultado.Rows.Count == 3)
            {
                cboTipoCredito.SelectedValue = Convert.ToInt32(dtResultado.Rows[0]["IdProducto"]);
                cboSubTipoCredito.SelectedValue = Convert.ToInt32(dtResultado.Rows[1]["IdProducto"]);
                cboProducto.SelectedValue = Convert.ToInt32(dtResultado.Rows[2]["IdProducto"]);
            }

            if (dtResultado.Rows.Count == 4)
            {
                cboTipoCredito.SelectedValue = Convert.ToInt32(dtResultado.Rows[0]["IdProducto"]);
                cboSubTipoCredito.SelectedValue = Convert.ToInt32(dtResultado.Rows[1]["IdProducto"]);
                cboProducto.SelectedValue = Convert.ToInt32(dtResultado.Rows[2]["IdProducto"]);
                cboSubProducto.SelectedValue = Convert.ToInt32(dtResultado.Rows[3]["IdProducto"]);
            }
            
        }

        public int idSubproducto()
        {
            if (cboProducto.SelectedIndex <= 0) return 0;

            return Convert.ToInt32(cboSubProducto.SelectedValue);
        }
        /// <summary>
        /// Carga de productos de otros modulos con IdProductoModulo
        /// </summary>
        /// <param name="nCodPro">indice de la tabla SI_FinModulo</param>        
        public void cargarProductosOtroModulo(int nCodPro)
        {
            cboTipoCredito.CargarProducto(nCodPro);
            this.lblBase11.Text = "Tipo Prod.";
            limpiar();
        }
        public void conProductoNivelTipEvalCred(int nNivel)
        {
            cboTipoCredito.CargarProductoNivelTipEvalCred(cIDsTipEvalCred, 1, 1);
            this.lblBase11.Text = this.cTitTipoProducto;
            limpiar();
        }

        #region Métodos Privados
        private bool EsTipoCreditoValido()
        {
            if (cboTipoCredito.SelectedIndex <= 0) return false;
            return true;
        }

        private bool EsSubTipoCreditoValido()
        {
            if (cboSubTipoCredito.SelectedIndex <= 0) return false;
            return true;
        }

        private bool EsProductoValido()
        {
            if (cboProducto.SelectedIndex <= 0) return false;
            return true;
        }

        private bool EsSubProductoValido()
        {
            if (cboSubProducto.SelectedIndex <= 0) return false;
            return true;
        }
        #endregion

        #region Eventos
        private void cboTipoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoCredito.SelectedIndex > 0)
            {
                nCodPro = Convert.ToInt32(cboTipoCredito.SelectedValue);
                    
                if (lNivel)
                {
                    nCodPro = Convert.ToInt32(cboTipoCredito.SelectedValue);
                    cboSubTipoCredito.CargarProductoNivelTipEvalCred(cIDsTipEvalCred, 2, nCodPro);
                }
                else 
                {
                    cboSubTipoCredito.CargarProducto(nCodPro);
                }
            }
            else
            {
                cboTipoCredito.SelectedIndex = 0;
                cboSubTipoCredito.CargarProducto(999);
            }

            if (ChangeProducto != null)
                ChangeProducto(sender, e);
        }

        private void cboSubTipoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubTipoCredito.SelectedIndex > 0)
            {
                nCodPro = Convert.ToInt32(cboSubTipoCredito.SelectedValue);
                    
                if (lNivel)
                {
                    nCodPro = Convert.ToInt32(cboSubTipoCredito.SelectedValue);
                    cboProducto.CargarProductoNivelTipEvalCred(cIDsTipEvalCred, 3, nCodPro);
                }
                else
                {
                    cboProducto.CargarProducto(nCodPro);
                }
            }
            else
            {
                cboSubTipoCredito.SelectedIndex = 0;
                cboProducto.CargarProducto(999);
            }

            if (ChangeProducto != null)
                ChangeProducto(sender, e);
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex > 0)
            {
                nCodPro = Convert.ToInt32(cboProducto.SelectedValue);

                if (lNivel)
                {
                    nCodPro = Convert.ToInt32(cboProducto.SelectedValue);
                    cboSubProducto.CargarProductoNivelTipEvalCred(cIDsTipEvalCred, 4, nCodPro);
                }
                else
                {
                    cboSubProducto.CargarProducto(nCodPro, this.idOperacion);
                }
            }
            else
            {
                cboProducto.SelectedIndex = 0;
                cboSubProducto.CargarProducto(999);
            }

            if (ChangeProducto != null)
                ChangeProducto(sender, e);
        }

        private void cboSubProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChangeProducto != null)
                ChangeProducto(sender, e);
        }

        private void cboTipoCredito_Validating(object sender, CancelEventArgs e)
        {
            if (!EsTipoCreditoValido())
                errorProvider.SetError(this.cboTipoCredito, "Seleccione un tipo de Crédito.");
            else
                errorProvider.SetError(this.cboTipoCredito, String.Empty);
        }

        private void cboSubTipoCredito_Validating(object sender, CancelEventArgs e)
        {
            if (!EsSubTipoCreditoValido())
                errorProvider.SetError(this.cboSubTipoCredito, "Seleccione un sub tipo de Crédito.");
            else
                errorProvider.SetError(this.cboSubTipoCredito, String.Empty);

        }

        private void cboProducto_Validating(object sender, CancelEventArgs e)
        {
            if (!EsProductoValido())
                errorProvider.SetError(this.cboProducto, "Seleccione un Producto.");
            else
                errorProvider.SetError(this.cboProducto, String.Empty);
        }

        private void cboSubProducto_Validating(object sender, CancelEventArgs e)
        {
            if (!EsSubProductoValido())
                errorProvider.SetError(this.cboSubProducto, "Seleccione un sub Producto.");
            else
                errorProvider.SetError(this.cboSubProducto, String.Empty);

        }
        #endregion
    }
}
