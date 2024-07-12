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

namespace LOG.Presentacion
{
    public partial class frmDetalleActivo : frmBase
    {
        #region Variables Globales
        //Declarar variables globales
        private const string cTituloMensajes = "Detalle de activos";
        public clsActivo objActivo;

        #endregion

        #region Eventos

        //Colocar los eventos de los controles del formulario
        private void Form_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Metodos

        //Colocar los metodos declarados en el formulario

        public frmDetalleActivo()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            if(string.IsNullOrEmpty(txtRubro.Text))
            {
                MessageBox.Show("Ingrese el rubro del activo", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(string.IsNullOrEmpty(txtMarca.Text))
            {
                MessageBox.Show("Ingrese la marca del activo", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(string.IsNullOrEmpty(txtSerie.Text))
            {
                MessageBox.Show("Ingrese la serie del activo", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(string.IsNullOrEmpty(txtModelo.Text))
            {
                MessageBox.Show("Ingrese el modelo del activo", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(string.IsNullOrEmpty(txtColor.Text))
            {
                MessageBox.Show("Ingrese el color del activo", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(string.IsNullOrEmpty(txtMaterial.Text))
            {
                MessageBox.Show("Ingrese el material del activo", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(string.IsNullOrEmpty(txtObservaciones.Text))
            {
                MessageBox.Show("Ingrese el detalle del activo", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(string.IsNullOrEmpty(txtObservaciones.Text))
            {
                MessageBox.Show("Ingrese las observaciones del activo", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;

        }

        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            objActivo = new clsActivo();
            objActivo.cCodInstActivo = string.IsNullOrEmpty(txtCodInst.Text.Trim()) ? string.Empty : txtCodInst.Text.Trim();
            objActivo.cRubro = txtRubro.Text.Trim();
            objActivo.cMarca = txtMarca.Text.Trim();
            objActivo.cSerie = txtSerie.Text.Trim();
            objActivo.cModelo = txtModelo.Text.Trim();
            objActivo.cColor = txtColor.Text.Trim();
            objActivo.cMaterial = txtMaterial.Text.Trim();
            objActivo.cObsActiv = txtObservaciones.Text.Trim();
            objActivo.dFechaReg = clsVarGlobal.dFecSystem;
            objActivo.idAgencia = clsVarGlobal.nIdAgencia;
            objActivo.idTipoActivo = 1;
            objActivo.dFechaCompra = clsVarGlobal.dFecSystem;
            objActivo.idEstadoActivo = 1;
            objActivo.nPorcDeprec = 0;
            objActivo.nMontoDeprec = 0;
            objActivo.idUsuReg = clsVarGlobal.User.idUsuario;
            objActivo.lIndActivo = true;

            this.Dispose();
        }

    }
}
