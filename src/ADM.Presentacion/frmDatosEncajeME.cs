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
    public partial class frmDatosEncajeME : frmBase
    {
        int x_nOpcNueEdit = 2;
        clsCNMantenimiento clsMto = new clsCNMantenimiento();

        public frmDatosEncajeME()
        {
            InitializeComponent();
        }

        private void frmDatosEncajeME_Load(object sender, EventArgs e)
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

            DataTable dtParamEnc = clsMto.CNListarEncajeME(cPeriodo);
            if (dtParamEnc.Rows.Count > 0)
            {
                conPeriodoTose.ActualizaPeriodo(Convert.ToInt16(dtParamEnc.Rows[0]["nMesTose"]), Convert.ToInt16(dtParamEnc.Rows[0]["nAñoTose"]));
                txtTose.Text = dtParamEnc.Rows[0]["nMontoTose"].ToString();
                conPeriodoEncaje.ActualizaPeriodo(Convert.ToInt16(dtParamEnc.Rows[0]["nMesEnc"]), Convert.ToInt16(dtParamEnc.Rows[0]["nAñoEnc"]));
                txtEncajeExi.Text = dtParamEnc.Rows[0]["nMontoEncajeExig"].ToString();
                txtTasaEncaje.Text = dtParamEnc.Rows[0]["nTasaEncaje"].ToString();
                txtTasaMarginal.Text = dtParamEnc.Rows[0]["nTasaMarginal"].ToString();
                txtTasaEncMin.Text = dtParamEnc.Rows[0]["nTasaEncajeMin"].ToString();
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
            conPeriodoTose.Enabled = Val;
            txtTose.Enabled = Val;
            conPeriodoEncaje.Enabled = Val;
            txtEncajeExi.Enabled = Val;
            txtTasaEncaje.Enabled = Val;
            txtTasaMarginal.Enabled = Val;
            txtTasaEncMin.Enabled = Val;
        }

        private void LimpiarCtrls()
        {
            txtTose.Clear();
            txtEncajeExi.Clear();
            txtTasaEncaje.Clear();
            txtTasaMarginal.Clear();
            txtTasaEncMin.Clear();
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(txtTose.Text))
            {
                MessageBox.Show("Debe registrar el monto del TOSE", "Parametros Encaje ME", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTose.Focus();
                return false;
            }
            if (Convert.ToDecimal(txtTose.Text) <= 0)
            {
                MessageBox.Show("El monto del TOSE, no puede ser cero (0)", "Parametros Encaje ME", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTose.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtEncajeExi.Text))
            {
                MessageBox.Show("Debe registrar el monto del encaje exigible", "Parametros Encaje ME", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEncajeExi.Focus();
                return false;
            }
            if (Convert.ToDecimal(txtEncajeExi.Text) <= 0)
            {
                MessageBox.Show("El monto del encaje exigible, no puede ser cero (0)", "Parametros Encaje ME", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEncajeExi.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTasaEncaje.Text))
            {
                MessageBox.Show("Debe registrar la tasa de encaje", "Parametros Encaje ME", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaEncaje.Focus();
                return false;
            }
            if (Convert.ToDecimal(txtTasaEncaje.Text) <= 0)
            {
                MessageBox.Show("El monto de la Tasa de Encaje, no puede ser cero (0)", "Parametros Encaje ME", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaEncaje.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTasaMarginal.Text))
            {
                MessageBox.Show("Debe registrar la tasa marginal", "Parametros Encaje ME", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaMarginal.Focus();
                return false;
            }
            if (Convert.ToDecimal(txtTasaMarginal.Text) <= 0)
            {
                MessageBox.Show("El monto de la Tasa marginal, no puede ser cero (0)", "Parametros Encaje ME", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaMarginal.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTasaEncMin.Text))
            {
                MessageBox.Show("Debe registrar la tasa de encaje mínimo", "Parametros Encaje ME", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaEncMin.Focus();
                return false;
            }
            if (Convert.ToDecimal(txtTasaEncMin.Text) <= 0)
            {
                MessageBox.Show("La tasa de encaje mínimo, no puede ser cero (0)", "Parametros Encaje ME", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaEncMin.Focus();
                return false;
            }
            return true;
        }


        #endregion

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ValidarDatosEncaje(conPeriodo.cPeriodoEncaje);
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
            txtTose.Focus();
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
            txtTose.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }

            //---Datos para almacenar
            string cPeriodo = conPeriodo.cPeriodoEncaje,
                    cPeriodoTose = conPeriodoTose.cPeriodoEncaje,
                    cPeriodoEnc = conPeriodoEncaje.cPeriodoEncaje;
            decimal nMonoTose=Convert.ToDecimal(txtTose.Text),
                    nMonEncExi=Convert.ToDecimal(txtEncajeExi.Text),
                    nTasaEncaje = Convert.ToDecimal(txtTasaEncaje.Text),
                    nTasaMarginal = Convert.ToDecimal(txtTasaMarginal.Text),
                    nTasaEncMinimo = Convert.ToDecimal(txtTasaEncMin.Text);

            DataTable dtParamEncMN = clsMto.CNRegistrarEncajeME(cPeriodo, cPeriodoTose, nMonoTose,cPeriodoEnc,nMonEncExi,nTasaEncaje,nTasaMarginal,nTasaEncMinimo,
                                                                clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, x_nOpcNueEdit);
            if (Convert.ToInt16(dtParamEncMN.Rows[0]["idRpta"]) == 0)
            {
                MessageBox.Show(dtParamEncMN.Rows[0]["cMensaje"].ToString(), "Registrar datos del Encaje ME", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(dtParamEncMN.Rows[0]["cMensaje"].ToString(), "Registrar datos del Encaje ME", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void txtTose_TextChanged(object sender, EventArgs e)
        {
            calcularTasaEncaje();
        }

        private void txtEncajeExi_TextChanged(object sender, EventArgs e)
        {
            calcularTasaEncaje();
        }
        private void calcularTasaEncaje()
        {
            if (!txtTose.Text.Trim().Equals("") && !txtEncajeExi.Text.Trim().Equals(""))
            {
                if (Convert.ToDecimal(txtTose.Text) > 0)
                {
                    txtTasaEncaje.Text = Math.Round((Convert.ToDecimal(txtEncajeExi.Text) / Convert.ToDecimal(txtTose.Text))*100, 4).ToString();
                }
                else
                {
                    txtTasaEncaje.Text = "0.0000";
                }
            }
            else
            {
                txtTasaEncaje.Text = "0.0000";
            }
           
        }
    }
}
