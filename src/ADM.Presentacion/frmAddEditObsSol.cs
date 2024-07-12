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

namespace ADM.Presentacion
{
    public partial class frmAddEditObsSol : frmBase
    {
        #region Variables Globales

        public DataRow drObservacion = null;
        public bool lAceptado = false;
        private const string cTituloMsjes = "Validación de campos.";

        #endregion

        #region Eventos
        //Colocar los eventos de los controles del formulario
        private void Form_Load(object sender, EventArgs e)
        {
            if (drObservacion != null)
            {
                cboTipObsSol.SelectedValue = Convert.ToInt32(drObservacion["idTipObsSol"]);
                txtDetObservacion.Text = Convert.ToString(drObservacion["cObservacion"]);
                chcSubsanado.Checked = Convert.ToBoolean(drObservacion["lSubsanado"]);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            drObservacion["idTipObsSol"] = Convert.ToInt32(cboTipObsSol.SelectedValue);
            drObservacion["cTipObsSol"] = cboTipObsSol.Text;
            drObservacion["cObservacion"] = txtDetObservacion.Text;
            drObservacion["lSubsanado"] = chcSubsanado.Checked;
            drObservacion["idUsuario"] = clsVarGlobal.User.idUsuario;
            drObservacion["dFecha"] = clsVarGlobal.dFecSystem.Date;

            lAceptado = true;

            this.Dispose();
        }

        #endregion

        #region Metodos

        //Colocar los metodos declarados en el formulario

        public frmAddEditObsSol()
        {
            InitializeComponent();
        }

        private bool Validar()
        {          
            if (cboTipObsSol.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tipo de observación.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        
            if (string.IsNullOrEmpty(txtDetObservacion.Text.Trim()))
            {
                MessageBox.Show("Ingrese el detalle de la observación.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion

        

    }
}
