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
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmVincularPagare : frmBase
    {
        #region Variable Globales

        public int idSolicitud { get; set; }
        public int idTipoPagare { get; set; }
        public bool lVinculado { get; set; }
        public int idSolCredGrupoSol { get; set; }

        clsCNPagare cnpagare = new clsCNPagare();

        #endregion

        public frmVincularPagare()
        {
            InitializeComponent();
        }

        public frmVincularPagare(int _idSolicitud, int _idTipoPagare = 1, int _idSolCredGrupoSol = 0)
        {
            InitializeComponent();
            idSolicitud = _idSolicitud;
            this.idTipoPagare = _idTipoPagare;
            this.idSolCredGrupoSol = _idSolCredGrupoSol;
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            if (idSolicitud == 0 && this.idSolCredGrupoSol == 0)
            {
                MessageBox.Show("Código de solicitud de crédito no es válido", "Vinculación de pagaré", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
            }
            activarControles(EventoFormulario.NUEVO);
            cargarDatos();
        }

        #endregion

        #region Métodos

        private bool validar()
        {
            bool lValida = false;

            if (string.IsNullOrEmpty(txtPagare.Text))
            {
                MessageBox.Show("Debe de ingresar el número del pagaré", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPagare.Focus();
                txtPagare.SelectAll();
                return lValida;
            }
            
            var dtPagare = cnpagare.CNValidarPagareCredito(txtPagare.Text.Trim(), this.idTipoPagare);
            if(dtPagare.Rows.Count > 0 && Convert.ToBoolean(dtPagare.Rows[0]["lPagareAnulado"]))
            {
                MessageBox.Show("Número de Pagaré ya fue anulado, por favor verificar", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValida;
            }
            if (dtPagare.Rows.Count > 0)
            {
                MessageBox.Show("Número de Pagaré ya fue registrado , por favor verificar", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValida;
            }

            lValida = true;
            return lValida;
        }

        private void limpiar()
        {
            txtPagare.Clear();
        }

        private void activarControles(EventoFormulario eAccionFormulario)
        {
            switch(eAccionFormulario)
            {
                case EventoFormulario.DEFECTO:
                    txtPagare.Enabled       = false;
                    btnAceptar1.Enabled     = false;
                    btnSalir1.Enabled       = false;
                    btnMiniQuitar.Enabled   = false;
                    btnMiniAnular.Enabled   = false;
                    break;
                case EventoFormulario.NUEVO:
                    txtPagare.Enabled       = true;
                    btnAceptar1.Enabled     = true;
                    btnMiniQuitar.Enabled   = false;
                    btnMiniAnular.Enabled   = false;
                    btnSalir1.Enabled       = true;
                    break;
                case EventoFormulario.VINCULADO:
                    txtPagare.Enabled       = false;
                    btnAceptar1.Enabled     = false;
                    btnMiniQuitar.Enabled   = true;
                    btnMiniAnular.Enabled   = true;
                    btnSalir1.Enabled       = true;
                    break;
                case EventoFormulario.DESVINCULADO:
                    txtPagare.Enabled       = true;
                    btnAceptar1.Enabled     = true;
                    btnMiniQuitar.Enabled   = false;
                    btnMiniAnular.Enabled   = false;
                    btnSalir1.Enabled       = true;
                    break;
                
            }
        }

        private void cargarDatos()
        {
            DataTable dtDatosPagare = cnpagare.CNObtenerDatosPagareCredito(idSolicitud, idSolCredGrupoSol);
            if(dtDatosPagare.Rows.Count > 0)
            {
                txtPagare.Text = Convert.ToString(dtDatosPagare.Rows[0]["cPagare"]);
                activarControles(EventoFormulario.VINCULADO);
            }
            else
            {
                activarControles(EventoFormulario.NUEVO);
            } 
        }

        #endregion

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                var dResul = MessageBox.Show("¿Está seguro de realizar la vinculación con el pagaré: " + txtPagare.Text.Trim() + " con la solicitud " + ((idSolicitud == 0) ? Convert.ToString(idSolCredGrupoSol) : Convert.ToString(idSolicitud))  + "?",
                                                "Vinculación de Pagaré", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dResul == System.Windows.Forms.DialogResult.Yes)
                {
                    cnpagare.CNInsertarPagareCredito(txtPagare.Text.Trim(),idSolicitud,clsVarGlobal.dFecSystem,clsVarGlobal.User.idUsuario,true,  this.idTipoPagare,  this.idSolCredGrupoSol);
                    MessageBox.Show("La vinculación de realizó correctamente", "Registro de vinculación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lVinculado = true;
                    this.Dispose();
                }
            }
        }
        private void btnMiniQuitar_Click(object sender, EventArgs e)
        {
            DialogResult drResultado = MessageBox.Show("¿Está seguro de desvincular el pagaré de créditos?", "Vinculación de Pagaré de Créditos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResultado == DialogResult.Yes)
            {
                DataTable dtResultado = cnpagare.CNDesvincularPagareGeneralCredito(idSolicitud, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario);

                if (dtResultado.Rows.Count > 0)
                {
                    if(Convert.ToInt32(dtResultado.Rows[0]["dtResultado"]) != 0)
                    {
                        MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), "Vinculación de Pagaré de Créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                        activarControles(EventoFormulario.NUEVO);
                    }
                    else
                    {
                        MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), "Vinculación de Pagaré de Créditos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        activarControles(EventoFormulario.VINCULADO);
                    }
                }
                else
                {
                    MessageBox.Show("La desvicunlación de Pagaré de Crédito no se completó de manera correcta.", "Vinculación de Pagaré de Créditos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    activarControles(EventoFormulario.VINCULADO);
                }
            }
        }

        private void btnMiniAnular_Click(object sender, EventArgs e)
        {
            DialogResult drResultado = MessageBox.Show("¿Está seguro de anular el pagaré de créditos? Este no se podrá usar nuevamente.", "Vinculación de Pagaré de Créditos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResultado == DialogResult.Yes)
            {
                DataTable dtResultado = cnpagare.CNAnularPagareGeneralCredito(idSolicitud, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario);

                if (dtResultado.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) != 0)
                    {
                        MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), "Vinculación de Pagaré de Créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                        activarControles(EventoFormulario.NUEVO);
                    }
                    else
                    {
                        MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), "Vinculación de Pagaré de Créditos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        activarControles(EventoFormulario.VINCULADO);
                    }
                }
                else
                {
                    MessageBox.Show("La desvicunlación de Pagaré de Crédito no se completó de manera correcta.", "Vinculación de Pagaré de Créditos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    activarControles(EventoFormulario.VINCULADO);
                }
            }
        }

        #region Enumeradores
        private enum EventoFormulario
        {
            DEFECTO         = 0,
            NUEVO           = 1,
            VINCULADO       = 3,
            DESVINCULADO    = 4,
        }
        #endregion
    }
}
