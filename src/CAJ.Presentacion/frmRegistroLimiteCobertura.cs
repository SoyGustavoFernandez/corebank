using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;

using CAJ.CapaNegocio;
using EntityLayer;

namespace CAJ.Presentacion
{
    public partial class frmRegistroLimiteCobertura : frmBase
    {
        #region constructor
        public frmRegistroLimiteCobertura()
        {
            InitializeComponent();
         //cargarDatos();
        
            dtpFecIni.Value = clsVarGlobal.dFecSystem;
            cboMoneda.MonedasLimiteCob();
            //cboMoneda.SelectedIndex = -1;
               cboAgencia.SelectedIndex= - 1;
        }
        #endregion

        #region metodos
        private void cargarDatos()
        {


            //===================================================================================
            //--Cargando Datos del limite de cobertura
            //===================================================================================
            clsCNControlOpe listLimCob = new clsCNControlOpe();

            int IdTipoResponsable = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);
            int idAgecias = Convert.ToInt32(cboAgencia.SelectedValue);
            int idMoneda = 1;//moneda en soles ;
            DataTable ListLimCobertura = listLimCob.listarLimitesCobertura(IdTipoResponsable, idAgecias, idMoneda);
            if (ListLimCobertura.Rows.Count > 0)
            {
                this.txtMontoSoles.Text = ListLimCobertura.Rows[0]["nMontoLim"].ToString();
                this.txtSustento.Text = ListLimCobertura.Rows[0]["cSustento"].ToString();
                this.txtXLimMenorSol.Text = ListLimCobertura.Rows[0]["nXlimMenor"].ToString();
                this.txtXLimInterSol.Text = ListLimCobertura.Rows[0]["nXlimMedio"].ToString();
                this.txtXLimMayorSol.Text = ListLimCobertura.Rows[0]["nXlimMayor"].ToString();

                this.txtMontoDolares.Text = ListLimCobertura.Rows[0]["nMontoLimDol"].ToString();
                this.txtXLimMenorDol.Text = ListLimCobertura.Rows[0]["nXlimMenorDol"].ToString();
                this.txtXLimInterDol.Text = ListLimCobertura.Rows[0]["nXlimMedioDol"].ToString();
                this.txtXLimMayorDol.Text = ListLimCobertura.Rows[0]["nXlimMayorDol"].ToString();
                this.cboMoneda.SelectedValue = Convert.ToInt32(ListLimCobertura.Rows[0]["idControLimTipMon"].ToString());
                this.dtpFecIni.Value = Convert.ToDateTime(ListLimCobertura.Rows[0]["dFechaIni"]);
                habilitarObjetos(2);
            }
            else
            {
                this.txtMontoSoles.Text = "0.00";
                this.txtMontoDolares.Text = "0.00";
                this.txtSustento.Text = "";
                cboMoneda.SelectedIndex = -1;
                grbSoles.Visible = true;
                grbDolares.Visible = false;
                habilitarObjetos(1);
            }
        }
        private void habilitarObjetos(int opcion)
        {
            //No Existe REgistros
            if (opcion == 1)
            {
                btnGrabar.Enabled = true;
                btnEditar.Enabled = false;
                btnCancelar.Enabled = true;
                cboMoneda.Enabled = true;
                txtMontoSoles.Enabled = true;
                txtMontoDolares.Enabled = true;
                dtpFecIni.Enabled = true;
                txtSustento.Enabled = true;
                txtXLimInterSol.Enabled = true;
                txtXLimMenorSol.Enabled = true;
                txtXLimMayorSol.Enabled = true;
                txtXLimInterDol.Enabled = true;
                txtXLimMenorDol.Enabled = true;
                txtXLimMayorDol.Enabled = true;
            }
            else if (opcion == 3)
            {
                btnGrabar.Enabled = false;
                btnEditar.Enabled = false;
                btnCancelar.Enabled = false;
                cboMoneda.Enabled = false;
                txtMontoSoles.Enabled = false;
                txtMontoDolares.Enabled = false;
                dtpFecIni.Enabled = false;
                txtSustento.Enabled = false;
                txtXLimInterSol.Enabled = false;
                txtXLimMenorSol.Enabled = false;
                txtXLimMayorSol.Enabled = false;
                txtXLimInterDol.Enabled = false;
                txtXLimMenorDol.Enabled = false;
                txtXLimMayorDol.Enabled = false;
            }
            else//existe REgistro
            {
                btnGrabar.Enabled = false;
                btnEditar.Enabled = true;
                btnCancelar.Enabled = false;
                cboMoneda.Enabled = false;
                txtMontoSoles.Enabled = false;
                txtMontoDolares.Enabled = false;
                dtpFecIni.Enabled = false;
                txtSustento.Enabled = false;
                txtXLimInterSol.Enabled = false;
                txtXLimMenorSol.Enabled = false;
                txtXLimMayorSol.Enabled = false;
                txtXLimInterDol.Enabled = false;
                txtXLimMenorDol.Enabled = false;
                txtXLimMayorDol.Enabled = false;

            }
        }
        private int validacion()
        {
            int rsult = 0;
            if (cboTipResponsableCaja1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe elegir el tipo de responsable, Verificar...", "Validar Limite de Cobertura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 1;
            }
            if ((txtMontoSoles.Text.Trim() == "" || Convert.ToDecimal(txtMontoSoles.Text) == 0) && Convert.ToInt32(cboMoneda.SelectedValue) == 1)
            {
                MessageBox.Show("El monto de cobertura en soles debe ser válido, Verificar...", "Validar Limite de Cobertura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 1;
            }
            if ((txtMontoDolares.Text.Trim() == "" || Convert.ToDecimal(txtMontoDolares.Text) == 0) && Convert.ToInt32(cboMoneda.SelectedValue) == 2)
            {
                MessageBox.Show("El monto de cobertura en dólares debe ser válido, Verificar...", "Validar Limite de Cobertura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 1;
            }
            if (cboMoneda.SelectedIndex == -1)
            {
                MessageBox.Show("Debe elegir el tipo de  control del límite, Verificar...", "Validar Limite de Cobertura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 1;
            }
            if (Convert.ToInt32(cboMoneda.SelectedValue) == 3)
            {
                if ((txtMontoSoles.Text.Trim() == "" || Convert.ToDecimal(txtMontoSoles.Text) == 0))
                {
                    MessageBox.Show("El monto de cobertura en soles debe ser válido, Verificar...", "Validar Limite de Cobertura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return 1;
                }
                if ((txtMontoDolares.Text.Trim() == "" || Convert.ToDecimal(txtMontoDolares.Text) == 0))
                {
                    MessageBox.Show("El monto de cobertura en dólares debe ser válido, Verificar...", "Validar Limite de Cobertura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return 1;
                }
            }
            if (Convert.ToInt32(cboMoneda.SelectedValue) == 1)
            {
                if (txtXLimMenorSol.Text.Trim() == "" || txtXLimMenorSol.Text.Equals("0"))
                {
                    MessageBox.Show("El porcentaje de límite menor en soles debe ser válido, Verificar...", "Validar  Limite de Cobertura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return 1;
                }
                else if (txtXLimInterSol.Text.Trim() == "" || Convert.ToDecimal(txtXLimInterSol.Text) < Convert.ToDecimal(txtXLimMenorSol.Text))
                {
                    MessageBox.Show("El porcentaje de límite intermedio en soles debe ser válido, Verificar...", "Validar Limite de Cobertura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return 1;
                }
                else if (txtXLimMayorSol.Text.Trim() == "" || Convert.ToDecimal(txtXLimMayorSol.Text) < Convert.ToDecimal(txtXLimInterSol.Text))
                {
                    MessageBox.Show("El porcentaje de límite mayor en soles debe ser válido, Verificar...", "Validar  Limite de Cobertura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return 1;
                }

            }
            if (Convert.ToInt32(cboMoneda.SelectedValue) == 2)
            {
                if (txtXLimMenorDol.Text.Trim() == "" || txtXLimMenorDol.Text.Equals("0"))
                {
                    MessageBox.Show("El porcentaje de límite menor en dólares debe ser válido, Verificar...", "Validar  Limite de Cobertura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return 1;
                }
                else if (txtXLimInterDol.Text.Trim() == "" || Convert.ToDecimal(txtXLimInterDol.Text) < Convert.ToDecimal(txtXLimMenorDol.Text))
                {
                    MessageBox.Show("El porcentaje de límite intermedio en dólares debe ser válido, Verificar...", "Validar Limite de Cobertura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return 1;
                }
                else if (txtXLimMayorDol.Text.Trim() == "" || Convert.ToDecimal(txtXLimMayorDol.Text) < Convert.ToDecimal(txtXLimInterDol.Text))
                {
                    MessageBox.Show("El porcentaje de límite mayor en dólares debe ser válido, Verificar...", "Validar  Limite de Cobertura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return 1;
                }

            }
            if (Convert.ToInt32(cboMoneda.SelectedValue) == 3)
            {
                if (txtXLimMenorSol.Text.Trim() == "" || txtXLimMenorSol.Text.Equals("0"))
                {
                    MessageBox.Show("El porcentaje de límite menor en soles debe ser válido, Verificar...", "Validar  Limite de Cobertura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return 1;
                }
                else if (txtXLimInterSol.Text.Trim() == "" || Convert.ToDecimal(txtXLimInterSol.Text) < Convert.ToDecimal(txtXLimMenorSol.Text))
                {
                    MessageBox.Show("El porcentaje de límite intermedio en soles debe ser válido, Verificar...", "Validar Limite de Cobertura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return 1;
                }
                else if (txtXLimMayorSol.Text.Trim() == "" || Convert.ToDecimal(txtXLimMayorSol.Text) < Convert.ToDecimal(txtXLimInterSol.Text))
                {
                    MessageBox.Show("El porcentaje de límite mayor en soles debe ser válido, Verificar...", "Validar  Limite de Cobertura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return 1;
                }
                if (txtXLimMenorDol.Text.Trim() == "" || txtXLimMenorDol.Text.Equals("0"))
                {
                    MessageBox.Show("El porcentaje de límite menor en dólares debe ser válido, Verificar...", "Validar  Limite de Cobertura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return 1;
                }
                else if (txtXLimInterDol.Text.Trim() == "" || Convert.ToDecimal(txtXLimInterDol.Text) < Convert.ToDecimal(txtXLimMenorDol.Text))
                {
                    MessageBox.Show("El porcentaje de límite intermedio en dólares debe ser válido, Verificar...", "Validar Limite de Cobertura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return 1;
                }
                else if (txtXLimMayorDol.Text.Trim() == "" || Convert.ToDecimal(txtXLimMayorDol.Text) < Convert.ToDecimal(txtXLimInterDol.Text))
                {
                    MessageBox.Show("El porcentaje de límite mayor en dólares debe ser válido, Verificar...", "Validar  Limite de Cobertura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return 1;
                }
            }

            if (txtSustento.Text.Trim() == "" || txtSustento.Text.Trim().Length < 6)
            {
                MessageBox.Show("Debe ingresar un sustento válido, Verificar...", "Validar Limite de Cobertura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 1;
            }
            return rsult;

        }
        #endregion
        #region eventos
        private void btnEditar_Click(object sender, EventArgs e)
        {
            cboAgencia.Enabled = false;
            cboTipResponsableCaja1.Enabled = false;
            habilitarObjetos(1);
            btnCancelar.Enabled = true;
            if (Convert.ToInt32(cboMoneda.SelectedValue) == 3)//ambas monedas
            {
                txtMontoDolares.Enabled = true;
                txtMontoSoles.Enabled = true;
            }
            else if (Convert.ToInt32(cboMoneda.SelectedValue) == 1)//soles
            {
                txtMontoDolares.Enabled = false;
                txtMontoSoles.Enabled = true;
            }
            else if (Convert.ToInt32(cboMoneda.SelectedValue) == 2)//dolares
            {
                txtMontoDolares.Enabled = true;
                txtMontoSoles.Enabled = false;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validacion() == 0)
            {
                int idusu = clsVarGlobal.PerfilUsu.idUsuario;
                int idTipResCaj = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);
                int idAge = Convert.ToInt32(cboAgencia.SelectedValue); ;
                DateTime dFecIni = dtpFecIni.Value;
                decimal nMonLimiteSol = Convert.ToDecimal(txtMontoSoles.Text);
                decimal nMonLimiteDol = Convert.ToDecimal(txtMontoDolares.Text);
                string cSustento = txtSustento.Text;

                decimal nXLimMenorSol = Convert.ToDecimal(txtXLimMenorSol.Text);
                decimal nXLimInterSol = Convert.ToDecimal(txtXLimInterSol.Text);
                decimal nXLimMayorSol = Convert.ToDecimal(txtXLimMayorSol.Text);
                decimal nXLimMenorDol = Convert.ToDecimal(txtXLimMenorDol.Text);
                decimal nXLimInterDol = Convert.ToDecimal(txtXLimInterDol.Text);
                decimal nXLimMayorDol = Convert.ToDecimal(txtXLimMayorDol.Text);

                int idControlTipoMoneda = Convert.ToInt32(cboMoneda.SelectedValue);

                //===================================================================================
                //--Grabando el limite de cobertura
                //===================================================================================
                clsCNControlOpe listLimCob = new clsCNControlOpe();
                string cRpta = listLimCob.RegLimiteCobertura(idusu, idAge, idTipResCaj, dFecIni, nMonLimiteSol, cSustento, nXLimMenorSol, nXLimInterSol, nXLimMayorSol, nMonLimiteDol, nXLimMenorDol, nXLimInterDol, nXLimMayorDol, idControlTipoMoneda);
                if (cRpta == "OK")
                {
                    MessageBox.Show("Se grabó correctamente el límite de cobertura....", "Límite de Cobertura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    habilitarObjetos(2);
                    cboAgencia.Enabled = true;
                    cboTipResponsableCaja1.Enabled = true;
                }
                else
                {
                    MessageBox.Show(cRpta, "Límite de Cobertura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cboAgencia.Enabled = true;
            cboTipResponsableCaja1.Enabled = true;
            habilitarObjetos(2);
            cargarDatos();

        }

        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencia.SelectedIndex > -1)
            {
                DataRow row = ((DataTable)cboAgencia.DataSource).Rows[cboAgencia.SelectedIndex];
                string IdTipEsq = row["idTipEsquemaCaja"].ToString();
                if (IdTipEsq.Equals(""))
                {


                    cboTipResponsableCaja1.DataSource = null;
                    MessageBox.Show("La agencia no tiene asignado el esquema de trabajo", "Mantenimiento de Responsables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    habilitarObjetos(3);
                    return;
                }
                else if (Convert.ToInt32(IdTipEsq) <= 0)
                {


                    cboTipResponsableCaja1.DataSource = null;
                    MessageBox.Show("La agencia no tiene asignado el esquema de trabajo", "Mantenimiento de Responsables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    habilitarObjetos(3);
                    return;

                }

                int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);
                cboTipResponsableCaja1.SelectedIndexChanged -= new EventHandler(cboTipResponsableCaja1_SelectedIndexChanged);
                cboTipResponsableCaja1.cargarTipoResponsableCajaAdm(idAgencia);
                cboTipResponsableCaja1.SelectedIndex = -1;
                this.txtMontoSoles.Text = "0.00";
                this.txtMontoDolares.Text = "0.00";
                this.txtSustento.Text = "";
                habilitarObjetos(1);
                cboMoneda.SelectedIndex = -1;
                grbDolares.Visible = false;
                cboTipResponsableCaja1.SelectedIndexChanged += new EventHandler(cboTipResponsableCaja1_SelectedIndexChanged);

            }


        }


        #endregion

        private void txtXLimMenor_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtXLimMenorSol.Text))
            {
                txtNumRea2.Text = txtXLimMenorSol.Text;
            }
            else
            {
                txtNumRea2.Text = (Convert.ToDecimal(txtXLimMenorSol.Text) + 1).ToString();
            }

        }

        private void txtXLimInter_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtXLimInterSol.Text))
            {
                txtNumRea3.Text = txtXLimInterSol.Text;

            }
            else
            {
                txtNumRea3.Text = (Convert.ToDecimal(txtXLimInterSol.Text) + 1).ToString();
            }
        }

        private void frmRegistroLimiteCobertura_Load(object sender, EventArgs e)
        {
            cargarDatos();


        }

        private void cboTipResponsableCaja1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDatos();

        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboMoneda.SelectedValue) == 3)//ambas monedas
            {
                grbDolares.Enabled = true;
                grbSoles.Enabled = true;
                grbDolares.Visible = true;
                grbSoles.Visible = true;
                txtMontoDolares.Enabled = true;
                txtMontoSoles.Enabled = true;
            }
            else if (Convert.ToInt32(cboMoneda.SelectedValue) == 1)//soles
            {
                grbDolares.Enabled = false;
                grbSoles.Enabled = true;
                grbDolares.Visible = false;
                grbSoles.Visible = true;

                txtMontoDolares.Enabled = false;
                txtMontoSoles.Enabled = true;
                txtMontoDolares.Text = "0.00";


            }
            else if (Convert.ToInt32(cboMoneda.SelectedValue) == 2)//dolares
            {
                grbDolares.Enabled = true;
                grbSoles.Enabled = false;
                grbDolares.Visible = true;
                grbSoles.Visible = false;
                txtMontoDolares.Enabled = true;
                txtMontoSoles.Enabled = false;
                txtMontoSoles.Text = "0.00";

            }
        }

        private void txtXLimMenorDol_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtXLimMenorDol.Text))
            {
                txtNumRea6.Text = txtXLimMenorDol.Text;
            }
            else
            {
                txtNumRea6.Text = (Convert.ToDecimal(txtXLimMenorDol.Text) + 1).ToString();
            }
        }

        private void txtXLimInterDol_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtXLimInterDol.Text))
            {
                txtNumRea5.Text = txtXLimInterDol.Text;
            }
            else
            {
                txtNumRea5.Text = (Convert.ToDecimal(txtXLimInterDol.Text) + 1).ToString();
            }
        }
    }
}
