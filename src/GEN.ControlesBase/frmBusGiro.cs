using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SER.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;

namespace GEN.ControlesBase
{
    
    public partial class frmBusGiro : frmBase
    {
        public int pnGiro,cOpcForm;

        public frmBusGiro()
        {
            InitializeComponent();
        }
        //public frmBusGiro(int cOpcForm)
        //{
        //    InitializeComponent();
        //}
        private void frmBusGiro_Load(object sender, EventArgs e)
        {
            
            CargarDatosIni(0, "", "", 0, 1);
            FormatoGridGiro();
            switch (cOpcForm)
            {
                //--Para Pago de Giros
                case 5:
                    CargarCriterioGiro(1);                   
                    break;
                //--Para Devolución de Giros
                case 4:
                    CargarCriterioGiro(2);                    
                    break;
            }            
        }

        private void CargarCriterioGiro(int nOpc)
        {
            clsCNControlServ cncontrolserv = new clsCNControlServ();
            DataTable TablaCriBus = cncontrolserv.ListadoCriBusGiro(nOpc);
            this.cboCriterioBus.DataSource = TablaCriBus;
            this.cboCriterioBus.ValueMember = TablaCriBus.Columns["idCriBusGiro"].ToString();
            this.cboCriterioBus.DisplayMember = TablaCriBus.Columns["cDesCriBus"].ToString();
        }

        private void CargarDatos(int idGiro, string cDniRem, string cDniBen, int idAge, int nOpc)
        {
            clsCNControlServ cncontrolserv = new clsCNControlServ();
            DataTable tbGiros = cncontrolserv.ListadodeGiros(idGiro, cDniRem, cDniBen, idAge, nOpc);
            this.dtgGiros.DataSource = tbGiros;

            if (dtgGiros.RowCount == 0)
            {
                MessageBox.Show("No Existen Datos con el criterio de Busqueda", "Busqueda de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtDatBus.Focus();
                return;
            }
        }

        private void CargarDatosIni(int idGiro, string cDniRem, string cDniBen, int idAge, int nOpc)
        {
            clsCNControlServ cncontrolserv = new clsCNControlServ();
            DataTable tbGiros = cncontrolserv.ListadodeGiros(idGiro, cDniRem, cDniBen, idAge, nOpc);
            this.dtgGiros.DataSource = tbGiros;
        }

        private void FormatoGridGiro()
        {
             this.dtgGiros.Columns["idServGiro"].Width = 50;
            this.dtgGiros.Columns["idServGiro"].HeaderText = "Giro";
            this.dtgGiros.Columns["dFechaGiro"].Width = 60;
            this.dtgGiros.Columns["dFechaGiro"].HeaderText = "Fec.Giro";
            this.dtgGiros.Columns["cNomAgeRem"].Width = 80;
            this.dtgGiros.Columns["cNomAgeRem"].HeaderText = "AG. Remitente";
            this.dtgGiros.Columns["nMontoGiro"].Width = 50;
            this.dtgGiros.Columns["nMontoGiro"].HeaderText = "Monto";
            this.dtgGiros.Columns["cMoneda"].Width = 50;
            this.dtgGiros.Columns["cMoneda"].HeaderText = "Moneda";
            this.dtgGiros.Columns["cNombreRem"].Width = 180;
            this.dtgGiros.Columns["cNombreRem"].HeaderText = "REMITENTE";
            this.dtgGiros.Columns["cNombreDes"].Width = 180;
            this.dtgGiros.Columns["cNombreDes"].HeaderText = "BENEFICIARIO";
            this.dtgGiros.Columns["cNomAgeDes"].Width = 80;
            this.dtgGiros.Columns["cNomAgeDes"].HeaderText = "AG. Destino";
            this.dtgGiros.Columns["cNomEstado"].Width = 50;
            this.dtgGiros.Columns["cNomEstado"].HeaderText = "Estado";

        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            BuscarDatos();
        }

        private void BuscarDatos()
        {
            if (string.IsNullOrEmpty(this.cboCriterioBus.SelectedValue.ToString()))
            {
                this.dtgGiros.DataSource = "";
                MessageBox.Show("Debe Seleccionar el Criterio de Busqueda", "Buscar de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboCriterioBus.Focus();
                return;
            }
                        
            string cCriBus;
            cCriBus = this.cboCriterioBus.SelectedValue.ToString();
            string cDatBus = this.txtDatBus.Text.Trim();
            switch (cCriBus)
            {
                case "1":
                    if (string.IsNullOrEmpty(this.txtDatBus.Text.Trim()))
                    {
                        MessageBox.Show("Debe Ingresar Datos Para el Criterio de Busqueda", "Buscar de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtDatBus.Select();
                        this.txtDatBus.Focus();                      
                        return;
                    }
                    CargarDatos(Convert.ToInt32(cDatBus), "", "", 0, 1);
                    FormatoGridGiro();
                    this.dtgGiros.Focus();
                    this.dtgGiros.Select();
                    break;
                case "2":
                    if (string.IsNullOrEmpty(this.txtDatBus.Text.Trim()))
                    {
                        MessageBox.Show("Debe Ingresar Datos Para el Criterio de Busqueda", "Buscar de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtDatBus.Select();
                        this.txtDatBus.Focus();
                        return;
                    }
                    if (this.txtDatBus.Text.Trim().Length < 8)
                    {
                        MessageBox.Show("El NRO de documento es inválido", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtDatBus.Select();
                        this.txtDatBus.Focus();
                        return;
                    }
                    CargarDatos(0, cDatBus, "", 0, 2);
                    FormatoGridGiro();
                    this.dtgGiros.Focus();
                    this.dtgGiros.Select();
                    break;
                case "3":
                    if (string.IsNullOrEmpty(this.txtDatBus.Text.Trim()))
                    {
                        MessageBox.Show("Debe Ingresar Datos Para el Criterio de Busqueda", "Buscar de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtDatBus.Focus();
                        return;
                    }
                    if (this.txtDatBus.Text.Trim().Length < 8)
                    {
                        MessageBox.Show("El NRO de documento es inválido", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtDatBus.Select();
                        this.txtDatBus.Focus();
                        return;
                    }
                    CargarDatos(0, "", cDatBus, 0, 3);
                    FormatoGridGiro();
                    this.dtgGiros.Focus();
                    this.dtgGiros.Select();
                    break;
                case "4":
                    CargarDatos(0, "", "", clsVarGlobal.nIdAgencia, 4);
                    FormatoGridGiro();
                    this.dtgGiros.Focus();
                    this.dtgGiros.Select();
                    break;
                case "5":
                    CargarDatos(0, "", "", clsVarGlobal.nIdAgencia, 5); ;
                    FormatoGridGiro();
                    this.dtgGiros.Focus();
                    this.dtgGiros.Select();
                    break;
            }
        }
 
        private void cboCriterioBus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cCriBus = this.cboCriterioBus.SelectedValue.ToString();
            this.txtDatBus.Text="";
            switch (cCriBus)
            {
                case "1":
                    this.lblCriterio.Text = "Nº DE GIRO:";
                    this.txtDatBus.Enabled = true;
                    this.txtDatBus.MaxLength = 25;
                    this.txtDatBus.Focus();
                    break;
                case "2":
                    this.lblCriterio.Text = "Nº DOC:";
                    this.txtDatBus.Enabled = true;
                    this.txtDatBus.MaxLength = 14;
                    this.txtDatBus.Focus();
                    break;
                case "3":
                    this.lblCriterio.Text = "Nº DOC:";
                    this.txtDatBus.Enabled = true;
                    this.txtDatBus.MaxLength = 14;
                    this.txtDatBus.Focus();
                    break;
                case "4":
                    this.lblCriterio.Text = "GIROS REMITIDOS:";
                    this.txtDatBus.Enabled = false;                    
                    break;
                case "5":
                    this.lblCriterio.Text = "GIROS POR PAGAR:";
                    this.txtDatBus.Enabled = false;                    
                    break;
            }
        }      

        private void txtDatBus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BuscarDatos();
            }
        }

        private void txtBase1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                BuscarDatos();
                //btnProcesar.PerformClick();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.dtgGiros.RowCount > 0)
            {
                pnGiro = Convert.ToInt32(dtgGiros.Rows[dtgGiros.SelectedCells[0].RowIndex].Cells["idServGiro"].Value.ToString());
            }
            else
            {
                pnGiro = 0;
            }

            this.Dispose();
        }

        private void dtgGiros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgGiros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnAceptar.PerformClick();
            }
        }

        private void dtgGiros_DoubleClick(object sender, EventArgs e)
        {
            this.btnAceptar.PerformClick();
        }
    }
}
