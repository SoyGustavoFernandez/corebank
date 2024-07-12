using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GEN.ControlesBase;
using GEN.CapaNegocio;
using RSG.CapaNegocio;

namespace RSG.Presentacion
{
    public partial class frmMantParamClasCred : frmBase
    {
        public frmMantParamClasCred()
        {
            InitializeComponent();
        }

        #region Variables Globales

        String cTituloMensaje = "Mant. de Parámetros para la Clasificación de Créditos Refinanciados";
        clsCNMantenimiento listaParametros = new clsCNMantenimiento();
        int idParamClasif = 0;

        #endregion
        
        #region Eventos

        private void frmMantenParamClasifCredito_Load(object sender, EventArgs e)
        {
            ListarTiposParametro();
            CargarParametros();
            HabilitarControles(false);
        }
        
        private void cboTiposParametro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarParametros();
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (this.dtgParametros.Rows.Count <= 0)
            {
                MessageBox.Show("No existen parametros para editar", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            HabilitarControles(true);
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            VerDetalle();
            HabilitarControles(false);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                return;
            }

            DataTable dtInsercion = listaParametros.guardaParamClasifCreditos(this.idParamClasif, Convert.ToInt32(this.nudCuotasPagadas.Value), Convert.ToInt32(this.nudMinDias.Value), Convert.ToInt32(this.nudMaxDias.Value), Convert.ToInt32(this.nudNivel.Value));
            MessageBox.Show(dtInsercion.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, ((int)dtInsercion.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            
            LimpiarControles();
            CargarParametros();
            HabilitarControles(false);
        }

        #endregion

        #region Metodos

        private void CargarParametros()
        {
            int nTipoParametro = Convert.ToInt32(cboTiposParametro.SelectedIndex);
            DataTable dtParametros = listaParametros.listaParamClasifCreditos(nTipoParametro);
            this.dtgParametros.DataSource = dtParametros;
            FormatoDtgParametros();
        }
        
        private void FormatoDtgParametros()
        {
            foreach (DataGridViewColumn item in this.dtgParametros.Columns)
            {
                item.Visible = false;
            }

            this.dtgParametros.Columns["idParamClasif"].Visible = true;
            this.dtgParametros.Columns["cTipo"].Visible = true;
            this.dtgParametros.Columns["cModalidad"].Visible = true;
            this.dtgParametros.Columns["nCuotasPagadas"].Visible = true;
            this.dtgParametros.Columns["nMinDiasAtraso"].Visible = true;
            this.dtgParametros.Columns["nMaxDiasAtraso"].Visible = true;
            this.dtgParametros.Columns["nNivelMejora"].Visible = true;
            this.dtgParametros.Columns["lVigente"].Visible = true;

            this.dtgParametros.Columns["idParamClasif"].FillWeight = 10;
            this.dtgParametros.Columns["cTipo"].FillWeight = 15;
            this.dtgParametros.Columns["cModalidad"].FillWeight = 25;
            this.dtgParametros.Columns["nCuotasPagadas"].FillWeight = 20;
            this.dtgParametros.Columns["nMinDiasAtraso"].FillWeight = 20;
            this.dtgParametros.Columns["nMaxDiasAtraso"].FillWeight = 20;
            this.dtgParametros.Columns["nNivelMejora"].FillWeight = 15;
            this.dtgParametros.Columns["lVigente"].FillWeight = 15;

            this.dtgParametros.Columns["idParamClasif"].HeaderText = "Id";
            this.dtgParametros.Columns["cTipo"].HeaderText = "Tipo";
            this.dtgParametros.Columns["cModalidad"].HeaderText = "Modalidad";
            this.dtgParametros.Columns["nCuotasPagadas"].HeaderText = "N Cuotas Pagadas";
            this.dtgParametros.Columns["nMinDiasAtraso"].HeaderText = "Min Días Atraso";
            this.dtgParametros.Columns["nMaxDiasAtraso"].HeaderText = "Max Días Atraso";
            this.dtgParametros.Columns["lVigente"].HeaderText = "Vigencia";

            if (this.cboTiposParametro.SelectedIndex == 1)
            {
                this.dtgParametros.Columns["nNivelMejora"].HeaderText = "Nivel Mejora";
                this.lblNivel.Text = "Nivel de Mejora:";
            }
            else
            {
                this.dtgParametros.Columns["nNivelMejora"].HeaderText = "Nivel Deterioro";
                this.lblNivel.Text = "Nivel de Deterioro:";
            }

            this.dtgParametros.Columns["idParamClasif"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgParametros.Columns["nCuotasPagadas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgParametros.Columns["nMinDiasAtraso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgParametros.Columns["nMaxDiasAtraso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgParametros.Columns["nNivelMejora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgParametros.Columns["lVigente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 

        }

        private void ListarTiposParametro()
        {
            cboTiposParametro.Items.Insert(0, "DETERIORO");
            cboTiposParametro.Items.Insert(1, "MEJORA");

            cboTiposParametro.SelectedIndex = 1;
        }

        private void dtgParametros_SelectionChanged(object sender, EventArgs e)
        {
            VerDetalle();
        }

        private void VerDetalle()
        {
            if (this.dtgParametros.SelectedRows.Count > 0)
            {
                this.idParamClasif = Convert.ToInt32(this.dtgParametros.SelectedRows[0].Cells["idParamClasif"].Value);
                this.nudCuotasPagadas.Text = Convert.ToString(this.dtgParametros.SelectedRows[0].Cells["nCuotasPagadas"].Value);
                this.nudNivel.Text = Convert.ToString(this.dtgParametros.SelectedRows[0].Cells["nNivelMejora"].Value);
                this.nudMinDias.Text = Convert.ToString(this.dtgParametros.SelectedRows[0].Cells["nMinDiasAtraso"].Value);
                this.nudMaxDias.Text = Convert.ToString(this.dtgParametros.SelectedRows[0].Cells["nMaxDiasAtraso"].Value);
                this.CBVigente.Checked = Convert.ToBoolean(this.dtgParametros.SelectedRows[0].Cells["lVigente"].Value);
                this.txtModalidad.Text = Convert.ToString(this.dtgParametros.SelectedRows[0].Cells["cModalidad"].Value);
            }
        }

        private void HabilitarControles(Boolean Val)
        {
            this.txtModalidad.Enabled = false;
            this.CBVigente.Enabled = false;

            this.cboTiposParametro.Enabled = !Val;
            this.nudCuotasPagadas.Enabled = Val;
            this.nudMinDias.Enabled = Val;
            this.nudMaxDias.Enabled = Val;
            this.nudNivel.Enabled = Val;

            this.btnNuevo1.Enabled = !Val;
            this.btnEditar1.Enabled = !Val;
            this.btnCancelar1.Enabled = Val;
            this.btnGrabar1.Enabled = Val;

            this.dtgParametros.Enabled = !Val;
        }

        private void LimpiarControles()
        {
            this.nudCuotasPagadas.Value = 0;
            this.nudNivel.Value = 0;
            this.nudMinDias.Value = 0;
            this.nudMaxDias.Value = 0;
        }

        private Boolean ValidarDatos()
        {
            if (String.IsNullOrEmpty(this.nudCuotasPagadas.Text))
            {
                MessageBox.Show("Debe de ingresar el número de cuotas pagadas", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nudCuotasPagadas.Focus();
                return true;
            }
            if (String.IsNullOrEmpty(this.nudNivel.Text))
            {
                MessageBox.Show("Debe de ingresar el nivel de mejora/deterioro", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nudNivel.Focus();
                return true;
            }
            if (String.IsNullOrEmpty(this.nudMinDias.Text))
            {
                MessageBox.Show("Debe de ingresar el número mínimo de días", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nudMinDias.Focus();
                return true;
            }
            if (String.IsNullOrEmpty(this.nudMaxDias.Text))
            {
                MessageBox.Show("Debe de ingresar el número máximo de días", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nudMinDias.Focus();
                return true;
            }
            if ( Convert.ToInt32(this.nudMinDias.Text) >= Convert.ToInt32(this.nudMaxDias.Text) )
            {
                MessageBox.Show("Días de atraso: El número mínimo no puede ser igual o mayor al número máximo", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nudMinDias.Focus();
                return true;
            }
            return false;
        }

        #endregion

    }
}
