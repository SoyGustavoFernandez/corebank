using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;

namespace CAJ.Presentacion
{
    public partial class frmManCajaChica : frmBase
    {
        public int nAccion = 1; //1--> Registro Nuevo de Caja Chica, 2--> Actualizar Datos Caja Chica

        public frmManCajaChica()
        {
            InitializeComponent();
        }

        private void frmManCajaChica_Load(object sender, EventArgs e)
        {
            
            CargarEstCajChica();
            ListaCajChica(0);
            HabDesControles(false);
            cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
            cboAgencias_SelectedIndexChanged(sender,e);
        }

        private void CargarEstCajChica()
        {
            clsCNCajaChica Lista = new clsCNCajaChica();
            DataTable tb = Lista.ListaEstCajaChica();
            this.cboEstCajChica.DataSource = tb;
            this.cboEstCajChica.ValueMember = tb.Columns["idEstCajChi"].ToString();
            this.cboEstCajChica.DisplayMember = tb.Columns["cDescripcion"].ToString();
            this.cboEstCajChica.SelectedValue = 1;
        }

        private void ListaCajChica(int idAge)
        {
            this.dtgLisCajChi.Refresh();
            this.dtgLisCajChi.DataSource = "";
            clsCNCajaChica Lista = new clsCNCajaChica();
            DataTable tb = Lista.ListadoCajaChica(idAge);
            this.dtgLisCajChi.DataSource = tb;
            if (tb.Rows.Count>0)
            {
                this.btnEditar.Enabled = true;
                //this.btnEliminar.Enabled = true;
            }
            else
            {
                this.btnEditar.Enabled = false;
                this.btnEliminar.Enabled = false;
            }
            FormatoGrid();
        }

        private void FormatoGrid()
        {
            this.dtgLisCajChi.Columns["idCajChica"].Width = 40;
            this.dtgLisCajChi.Columns["idCajChica"].HeaderText = "ID";
            this.dtgLisCajChi.Columns["cNomCajChi"].Width = 140;
            this.dtgLisCajChi.Columns["cNomCajChi"].HeaderText = "NOMBRE CAJA CHICA";
            this.dtgLisCajChi.Columns["idMoneda"].Visible = false;
            this.dtgLisCajChi.Columns["cMoneda"].Width = 70;
            this.dtgLisCajChi.Columns["cMoneda"].HeaderText = "MONEDA";
            this.dtgLisCajChi.Columns["nMonMaxCaj"].Width = 60;
            this.dtgLisCajChi.Columns["nMonMaxCaj"].HeaderText = "FONDO FIJO";
            this.dtgLisCajChi.Columns["nMonMaxCpg"].Width = 60;
            this.dtgLisCajChi.Columns["nMonMaxCpg"].HeaderText = "MONTO CPG";
            this.dtgLisCajChi.Columns["idResCajChi"].Visible = false;

            this.dtgLisCajChi.Columns["cNombre"].Width = 160;
            this.dtgLisCajChi.Columns["cNombre"].HeaderText = "RESPONSABLE";
            this.dtgLisCajChi.Columns["cCargo"].Visible = false;
            this.dtgLisCajChi.Columns["idEstCajChi"].Visible = false;
            this.dtgLisCajChi.Columns["nCajChicHabi"].Visible = false;
            this.dtgLisCajChi.Columns["nNumCpg"].Visible = false;
            this.dtgLisCajChi.Focus();
            
        }

        private void AsignaDatControles()
        {
            if (this.dtgLisCajChi.RowCount>0)
            {
                this.txtNomCajChi.Text = this.dtgLisCajChi.Rows[dtgLisCajChi.SelectedCells[2].RowIndex].Cells["cNomCajChi"].Value.ToString();
                this.cboMoneda.SelectedValue = this.dtgLisCajChi.Rows[dtgLisCajChi.SelectedCells[2].RowIndex].Cells["idMoneda"].Value.ToString();
                this.txtMonMax.Text = this.dtgLisCajChi.Rows[dtgLisCajChi.SelectedCells[2].RowIndex].Cells["nMonMaxCaj"].Value.ToString();
                this.txtMonCpg.Text = this.dtgLisCajChi.Rows[dtgLisCajChi.SelectedCells[2].RowIndex].Cells["nMonMaxCpg"].Value.ToString();
                this.conBusCol.txtCod.Text = this.dtgLisCajChi.Rows[dtgLisCajChi.SelectedCells[2].RowIndex].Cells["idResCajChi"].Value.ToString();
                this.conBusCol.txtCargo.Text = this.dtgLisCajChi.Rows[dtgLisCajChi.SelectedCells[2].RowIndex].Cells["cCargo"].Value.ToString();
                this.conBusCol.txtNom.Text = this.dtgLisCajChi.Rows[dtgLisCajChi.SelectedCells[2].RowIndex].Cells["cNombre"].Value.ToString();
                this.cboEstCajChica.SelectedValue = this.dtgLisCajChi.Rows[dtgLisCajChi.SelectedCells[2].RowIndex].Cells["idEstCajChi"].Value.ToString();

                if (Convert.ToInt32(this.dtgLisCajChi.Rows[dtgLisCajChi.SelectedCells[2].RowIndex].Cells["nCajChicHabi"].Value) > 0 ||
                   Convert.ToInt32(this.dtgLisCajChi.Rows[dtgLisCajChi.SelectedCells[2].RowIndex].Cells["nNumCpg"].Value) > 0)
                {
                    this.btnEliminar.Enabled = false;
                }
                else
                {
                    this.btnEliminar.Enabled = true;
                }
            }          
        }

        private void HabDesControles(bool Valor)
        {
            this.txtNomCajChi.Enabled = Valor;
            this.cboMoneda.Enabled = Valor;
            this.txtMonMax.Enabled = Valor;
            this.txtMonCpg.Enabled = Valor;
            this.conBusCol.txtCod.Enabled=Valor;
            this.conBusCol.btnConsultar.Enabled = Valor;
        }

        private void LimpiarControles()
        {
            this.txtNomCajChi.Clear();
            this.cboMoneda.SelectedValue = 1;
            this.txtMonMax.Text = "0.00";
            this.txtMonCpg.Text = "0.00";
            this.cboEstCajChica.SelectedValue = 3;
            this.conBusCol.txtCod.Clear();
            this.conBusCol.txtCargo.Clear();
            this.conBusCol.txtNom.Clear();
            this.dtgLisCajChi.DataSource ="";
        }

        private string ValidarDatos()
        {
            //=======================================================================
            //--Validar Datos del Remitente
            //=======================================================================
            if (string.IsNullOrEmpty(this.txtNomCajChi.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Nombre de la Caja Chica", "Registro de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNomCajChi.Select();
                this.txtNomCajChi.Focus();
                return "ERROR";
            }

            //=======================================================================
            //--Validar Datos de la Agencia
            //=======================================================================
            if (string.IsNullOrEmpty(this.cboAgencias.SelectedValue.ToString()))
            {
                MessageBox.Show("Debe Seleccionar La Agencia", "Registro de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgencias.Select();
                this.cboAgencias.Focus();
                return "ERROR";
            }

            if (this.cboAgencias.SelectedIndex < 0)
            {
                MessageBox.Show("Debe Seleccionar La Agencia", "Registro de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgencias.Select();
                this.cboAgencias.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(this.cboMoneda.SelectedValue.ToString()))
            {
                MessageBox.Show("Debe Seleccionar la Moneda.", "Registro de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboMoneda.Select();
                this.cboMoneda.Focus();
                return "ERROR";
            }
            if (string.IsNullOrEmpty(this.txtMonMax.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Monto del Fondo Fijo.", "Registro de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtMonMax.Select();
                this.txtMonMax.Focus();
                return "ERROR";
            }

            if (Convert.ToDecimal (this.txtMonMax.Text) <= 0)
            {
                MessageBox.Show("Debe Ingresar el Monto Válido de Fondo Fijo.", "Registro de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtMonMax.Select();
                this.txtMonMax.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(this.txtMonCpg.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Monto Maximo por Comprobante para el Fondo Fijo de Caja Chica", "Registro de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtMonCpg.Select();
                this.txtMonCpg.Focus();
                return "ERROR";
            }

            if (Convert.ToDecimal (this.txtMonCpg.Text) <= 0)
            {
                MessageBox.Show("Debe Ingresar el Monto Maximo Válido", "Registro de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtMonCpg.Select();
                this.txtMonCpg.Focus();
                return "ERROR";
            }

            if (Convert.ToDecimal (this.txtMonCpg.Text) > Convert.ToDecimal (this.txtMonMax.Text))
            {
                MessageBox.Show("El monto máximo por comprobante no puede ser mayor al monto del Fondo Fijo.", "Registro de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtMonCpg.Select();
                this.txtMonCpg.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(this.conBusCol.txtCod.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Responsable de Caja Chica", "Registro de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.conBusCol.txtCod.Select();
                this.conBusCol.txtCod.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(this.conBusCol.txtNom.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Responsable de Caja Chica", "Registro de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.conBusCol.txtCod.Select();
                this.conBusCol.txtCod.Focus();
                return "ERROR";
            }

            return "OK";
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos() == "ERROR")
            {
                return;
            }
            conBusCol.BusPerByCod();
            if (string.IsNullOrEmpty(conBusCol.idUsu))
            {
                MessageBox.Show("Debe Ingresar el Responsable de Caja Chica", "Registro de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.conBusCol.txtCod.Select();
                this.conBusCol.txtCod.Focus();
                return;
            } 
            //===============================================================================
            //--Asignar Datos a las Variables
            //===============================================================================
            int idAge = Convert.ToInt32(this.cboAgencias.SelectedValue.ToString());
            string cNomCaj = this.txtNomCajChi.Text.Trim();
            int idMon = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());
            Decimal nMontoMax = Convert.ToDecimal (this.txtMonMax.Text);
            Decimal nMontoCpg = Convert.ToDecimal (this.txtMonCpg.Text);
            int idRes = Convert.ToInt32(this.conBusCol.txtCod.Text);

            if (nAccion==1)
            {
                //===============================================================================
                //--Registra Caja Chica
                //===============================================================================
                clsCNCajaChica dtCajChi = new clsCNCajaChica();
                DataTable tbdtCajChi = dtCajChi.RegistraCajaChica(idAge, cNomCaj, idMon, nMontoMax,nMontoCpg, idRes);
                if (Convert.ToInt32(tbdtCajChi.Rows[0]["idRpta"].ToString()) == 0)
                {
                    MessageBox.Show(tbdtCajChi.Rows[0]["cMensage"].ToString(), "Registro de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HabDesControles(false);
                    ListaCajChica(Convert.ToInt32(this.cboAgencias.SelectedValue.ToString()));
                    this.btnNuevo.Enabled = true;
                    this.btnEditar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.btnEliminar.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.dtgLisCajChi.Enabled = true;
                    this.dtgLisCajChi.Focus();
                }
                else
                {
                    MessageBox.Show(tbdtCajChi.Rows[0]["cMensage"].ToString(), "Registro de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }                
            }
            else
            {
                //===============================================================================
                //--Actualiza Datos de Caja Chica
                //===============================================================================
                int idCaj = Convert.ToInt32(this.dtgLisCajChi.Rows[dtgLisCajChi.SelectedCells[1].RowIndex].Cells["idCajChica"].Value.ToString());
                clsCNCajaChica dtCajChi = new clsCNCajaChica();
                DataTable tbdtCajChi = dtCajChi.ActEliCajaChica(idCaj, cNomCaj, idMon, nMontoMax,nMontoCpg, idRes,1);
                if (Convert.ToInt32(tbdtCajChi.Rows[0]["idRpta"].ToString()) == 0)
                {
                    MessageBox.Show(tbdtCajChi.Rows[0]["cMensage"].ToString(), "Actualizar Datos de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HabDesControles(false);
                    ListaCajChica(Convert.ToInt32(this.cboAgencias.SelectedValue.ToString()));
                    this.btnNuevo.Enabled = true;
                    this.btnEditar.Enabled = true;
                    this.btnCancelar.Enabled = false;
                    this.btnEliminar.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.dtgLisCajChi.Enabled = true;
                    this.dtgLisCajChi.Focus();
                }
                else
                {
                    MessageBox.Show(tbdtCajChi.Rows[0]["cMensage"].ToString(), "Actualizar Datos de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                nAccion = 1;
            }
            
        }

        private void cboAgencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboAgencias.SelectedIndex == -1)
            {
                return;
            }
            LimpiarControles();
            int idAgencia = Convert.ToInt32(this.cboAgencias.SelectedValue.ToString());
            ListaCajChica(idAgencia);
            AsignaDatControles();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboAgencias.SelectedValue)==0)
            {
                MessageBox.Show("Debe Seleccionar una Agencias","Mantenimiento de fondo fijo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            nAccion = 1;
            LimpiarControles();
            HabDesControles(true);            
            this.cboAgencias.Enabled = false;
            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnCancelar.Enabled = true;
            this.btnEliminar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.dtgLisCajChi.Enabled = false;
            this.txtNomCajChi.Focus();
        }

        private void dtgLisCajChi_Click(object sender, EventArgs e)
        {            
            AsignaDatControles();
        }

        private void dtgLisCajChi_SelectionChanged(object sender, EventArgs e)
        {
            //AsignaDatControles();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            nAccion = 2;
            this.cboAgencias.Enabled = false;
            HabDesControles(true);
            this.dtgLisCajChi.Enabled = false;
            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnCancelar.Enabled = true;
            this.btnEliminar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.txtNomCajChi.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
            this.HabDesControles(false);
        
            this.cboAgencias.Focus();
            this.cboAgencias.Select();
            this.cboAgencias.SelectedIndex =-1;
            this.cboAgencias.Enabled = true;
            this.btnNuevo.Enabled = true;
            this.btnEditar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.btnGrabar.Enabled = false;
            this.dtgLisCajChi.Enabled = true;
            this.dtgLisCajChi.Focus();
            this.dtgLisCajChi.Select();
            nAccion = 1;
        }

        private void dtgLisCajChi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AsignaDatControles();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var Msg = MessageBox.Show("Estas Seguro de Eliminar la Caja Chica?...", "Eliminar Caja Chica", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Msg == DialogResult.No)
            {
                return;
            }

            //===============================================================================
            //--Eliminar Caja Chica
            //===============================================================================
            int idCaj = Convert.ToInt32(this.dtgLisCajChi.Rows[dtgLisCajChi.SelectedCells[1].RowIndex].Cells["idCajChica"].Value.ToString());
            clsCNCajaChica dtCajChi = new clsCNCajaChica();
            DataTable tbdtCajChi = dtCajChi.ActEliCajaChica(idCaj, "", 0, 0, 0, 0, 2);
            if (Convert.ToInt32(tbdtCajChi.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(tbdtCajChi.Rows[0]["cMensage"].ToString(), "Eliminar Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HabDesControles(false);
                ListaCajChica(Convert.ToInt32(this.cboAgencias.SelectedValue.ToString()));
                AsignaDatControles();
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
                //this.btnEliminar.Enabled = false;
                this.btnGrabar.Enabled = false;
                this.dtgLisCajChi.Enabled = true;
                this.dtgLisCajChi.Focus();
            }
            else
            {
                MessageBox.Show(tbdtCajChi.Rows[0]["cMensage"].ToString(), "Eliminar Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

      
    }
}
