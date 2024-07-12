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
    public partial class frmCondHistSolCred : frmBase
    {
        #region Variables Globales
        private string cMotivo      = "";
        private bool lMotivoCerrar  = false;
        public bool lCerrar         = false;
        #endregion

        public frmCondHistSolCred()
        {
            InitializeComponent();
        }

        public frmCondHistSolCred(DateTime _dFechaAnterior, DateTime _dFechaModificado, string _cMotivo)
        {
            InitializeComponent();
            this.dtpFecha1.Value = _dFechaAnterior;
            this.dtpFecha2.Value = _dFechaModificado;
            this.txtMotivo.Text  = _cMotivo;
        }

        #region Eventos
        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (!validaMotivo())
            {
                MessageBox.Show("Debe ingresar un motivo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            lMotivoCerrar = true;
            this.Dispose();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            lMotivoCerrar = false;
            this.Dispose();
        }

        private void frmCondHistSolCred_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.lCerrar)
            {
                e.Cancel = true;
                return;
            }
        }
        #endregion

        #region Métodos
        private bool validaMotivo()
        {
            if (txtMotivo.Text.Trim().Length > 0)
            {
                cMotivo = txtMotivo.Text;
                return true;
            }
            else
            {
                return false;
            }
        }

        public string RetornaMotivo()
        {
            return cMotivo;
        }

        public bool ValidarMotivoCancelar()
        {
            return lMotivoCerrar;
        }
        #endregion
    }
}
