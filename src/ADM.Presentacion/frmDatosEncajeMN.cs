using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADM.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;


namespace ADM.Presentacion
{
    public partial class frmDatosEncajeMN : frmBase
    {
        int x_nOpcNueEdit = 2;
        clsCNMantenimiento clsMto = new clsCNMantenimiento();

        public frmDatosEncajeMN()
        {
            InitializeComponent();
        }

        private void frmDatosEncajeMN_Load(object sender, EventArgs e)
        {
            conPeriodo.ActualizaPeriodo(clsVarGlobal.dFecSystem.Month, clsVarGlobal.dFecSystem.Year);
            ValidarDatosEncaje(conPeriodo.cPeriodoEncaje);
        }

        #region MetodosEncaje

        private void ValidarDatosEncaje(string cPeriodo)
        {
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
            conPeriodo.Enabled = false;
            btnConsultar.Enabled = false;
            HabDesabilitarCtrls(false);
            LimpiarCtrls();

            DataTable dtParamEnc = clsMto.CNListarEncajeMN(cPeriodo);
            if (dtParamEnc.Rows.Count>0)
            {
                txtTasaEncaje.Text = dtParamEnc.Rows[0]["nTasaEncaje"].ToString();
                txtTasaLegal.Text = dtParamEnc.Rows[0]["nTasaEncLegal"].ToString();
                txtPatrimonio.Text = dtParamEnc.Rows[0]["nPatrimonioEfec"].ToString();
                x_nOpcNueEdit = 2;                
                btnEditar.Enabled = true;
            }
            else
            {
                x_nOpcNueEdit = 1;
                btnNuevo.Enabled = true;
            }
            btnCancelar.Enabled = true;
        }

        private void HabDesabilitarCtrls(bool Val)
        {
            txtTasaEncaje.Enabled = Val;
            txtTasaLegal.Enabled = Val;
            txtPatrimonio.Enabled = Val;
        }

        private void LimpiarCtrls()
        {
            txtTasaEncaje.Clear();
            txtTasaLegal.Clear();
            txtPatrimonio.Clear();
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(txtTasaEncaje.Text))
            {
                MessageBox.Show("Debe registrar la tasa de encaje", "Parametros Encaje MN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaEncaje.Focus();
                return false;
            }
            if (Convert.ToDecimal(txtTasaEncaje.Text)<=0)
            {
                MessageBox.Show("El monto de la Tasa de Encaje, no puede ser cero (0)", "Parametros Encaje MN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaEncaje.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTasaLegal.Text))
            {
                MessageBox.Show("Debe registrar la tasa de encaje mínimo legal", "Parametros Encaje MN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaLegal.Focus();
                return false;
            }
            if (Convert.ToDecimal(txtTasaLegal.Text) <= 0)
            {
                MessageBox.Show("El monto de la Tasa de Encaje mínimo legal, no puede ser cero (0)", "Parametros Encaje MN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaLegal.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPatrimonio.Text))
            {
                MessageBox.Show("Debe registrar el patrimonio efectivo", "Parametros Encaje MN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPatrimonio.Focus();
                return false;
            }
            if (Convert.ToDecimal(txtPatrimonio.Text) <= 0)
            {
                MessageBox.Show("El monto del patrimonio efectivo, no puede ser cero (0)", "Parametros Encaje MN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPatrimonio.Focus();
                return false;
            }
            return true;
        }


        #endregion

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }

            //---Datos para almacenar
            string cPeriodo = conPeriodo.cPeriodoEncaje;
            decimal nTasaEncaje = Convert.ToDecimal(txtTasaEncaje.Text),
                    nTasaEncLegal = Convert.ToDecimal(txtTasaLegal.Text),
                    nPatriEfectivo = Convert.ToDecimal(txtPatrimonio.Text);

            DataTable dtParamEncMN = clsMto.CNRegistrarEncajeMN(cPeriodo, nTasaEncaje, nTasaEncLegal, nPatriEfectivo, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, x_nOpcNueEdit);
            if (Convert.ToInt16(dtParamEncMN.Rows[0]["idRpta"])==0)
            {
                MessageBox.Show(dtParamEncMN.Rows[0]["cMensaje"].ToString(), "Registrar datos del Encaje MN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(dtParamEncMN.Rows[0]["cMensaje"].ToString(), "Registrar datos del Encaje MN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            x_nOpcNueEdit = 2;
            HabDesabilitarCtrls(false);
            btnNuevo.Enabled = false;
            btnEditar.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = true;
            conPeriodo.Enabled = false;
            btnConsultar.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            x_nOpcNueEdit = 1;
            HabDesabilitarCtrls(true);
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            conPeriodo.Enabled = false;
            btnConsultar.Enabled = false;
            txtTasaEncaje.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            x_nOpcNueEdit = 2;
            HabDesabilitarCtrls(true);
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            conPeriodo.Enabled = false;
            btnConsultar.Enabled = false;
            txtTasaEncaje.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            x_nOpcNueEdit = 2;
            ValidarDatosEncaje(conPeriodo.cPeriodoEncaje);
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = true;            
            HabDesabilitarCtrls(false);           
            conPeriodo.Enabled = true;
            btnConsultar.Enabled = true;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ValidarDatosEncaje(conPeriodo.cPeriodoEncaje);
        }
    }
}
