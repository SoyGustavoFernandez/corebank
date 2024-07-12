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
    public partial class frmDesvinPagare : frmBase
    {

        #region Variable Globales

        public int npagare { get; set; }
        public bool lVinculado { get; set; }
        clsCNPagare cnpagare = new clsCNPagare();

        #endregion

        public frmDesvinPagare()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            if (npagare == 0)
            {
                MessageBox.Show("Código de pagare de crédito no es válido", "Desvinculación de pagaré", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
            }
        }

        #endregion

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
             if (validar())
            {
                var dResul = MessageBox.Show("¿Está seguro de realizar la desvinculación con el pagaré de la Solicitud: " + txtNumSolicitud.Text.Trim() + "?",
                                                "Desvinculación de Pagaré", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dResul == System.Windows.Forms.DialogResult.Yes)
                {
                    cnpagare.CNDesvincularPagareCredito(Convert.ToInt32(txtNumSolicitud.Text.Trim()), clsVarGlobal.dFecSystem, Convert.ToInt32(clsVarGlobal.User.idUsuario));
                    MessageBox.Show("La vinculación de realizó correctamente", "Registro de vinculación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lVinculado = true;
                    this.Dispose();
                }
            }
        }

        private bool validar()
        {
            bool lValida = false;

            if (string.IsNullOrEmpty(txtNumSolicitud.Text))
            {
                MessageBox.Show("Debe de ingresar el número del pagaré", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumSolicitud.Focus();
                txtNumSolicitud.SelectAll();
                return lValida;
            }

            lValida = true;
            return lValida;
        }

        private void frmDesvinPagare_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
        }
    }
}
