using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using GEN.CapaNegocio;
using CLI.CapaNegocio;
using RPT.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using GEN.Funciones;
using DEP.CapaNegocio;
using SPL.CapaNegocio;
using System.Text.RegularExpressions;


namespace CLI.Presentacion
{
    public partial class frmRegistroNumerosTelf : frmBase
    {

        #region Variables Globales

        public string cNumeroPrincipal = "";
        string idCli = "";
        string cDocumentoID = "";
        string cNombre = "";
        clsCNCliente Cliente = new clsCNCliente();
        string cTituloMsjes = "Registro de números de teléfono.";
        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
        int idUsuario = Convert.ToInt32(clsVarGlobal.PerfilUsu.idUsuario);

        int idRegtel = 0;

        #endregion


        public frmRegistroNumerosTelf()
        {
            InitializeComponent();
            this.txtNumerico1.ContextMenuStrip = new ContextMenuStrip();
            this.txtNumerico2.ContextMenuStrip = new ContextMenuStrip();
            
        }

        public frmRegistroNumerosTelf(string idCli, string cDocumentoID,string cNombre)
        {
            InitializeComponent();
            this.txtNumerico1.ContextMenuStrip = new ContextMenuStrip();
            this.txtNumerico2.ContextMenuStrip = new ContextMenuStrip();

            this.idCli = idCli;
            this.cDocumentoID = cDocumentoID;
            this.cNombre = cNombre;
            
         

            this.txtDNI.Text = cDocumentoID;
            this.txtCodCli.Text = idCli;
            this.txtNombre.Text = cNombre;
            RellenarDatos();
            CargarCodCiudad();
            CambiarTxt();
        }

        private void txtNumerico1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Back))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == Convert.ToChar("."))
            {
                e.Handled = true;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
                //Validando estructura básica: Nombres y paréntesis
            string cCadena = this.txtNumerico1.Text.ToString();
            string idTipoTel = this.cboTipoTelefono1.SelectedValue.ToString();
            
            Regex patronCelular = new Regex("^[9][0-9]{8}$");
            Match matchCel = patronCelular. Match(cCadena);

            string cCadenaFijo = this.txtNumerico2.Text.ToString();
            Regex patronFijo = new Regex("^[1-9][0-9]{5,6}$");
            Match matchFijo = patronFijo.Match(cCadenaFijo);


            if (string.IsNullOrEmpty(cCadenaFijo))
            {
                cCadenaFijo = "0";
            }

            DataTable ValidaCadena = Cliente.CNValidaCadena(cCadenaFijo);


            if (Convert.ToInt32(idTipoTel) == 1)
            {
                if (string.IsNullOrEmpty(cCadena))
                {
                    MessageBox.Show("Debe de ingresar un número de contacto.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else if (Convert.ToInt32(cCadena) == 999999999)
                {
                    MessageBox.Show("No es un número válido.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (matchCel.Success == true)
                {
                    MessageBox.Show("Se agregó correctamente el Número: " + cCadena, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cliente.CNCambiarPrincipal(Convert.ToInt32(idCli), 3, cDocumentoID, txtNumerico1.Text.ToString(), Convert.ToInt32(idTipoTel), 2, idUsuario, idRegtel,0);
                    dtgRegTelefonos.DataSource = null;
                    RellenarDatos();
                    this.txtNumerico1.Text = "";
                    this.txtNumerico2.Text = "";

                }
                else
                {
                    MessageBox.Show("No es un número válido.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else if (Convert.ToInt32(idTipoTel) == 2)
            {
                if (string.IsNullOrEmpty(cCadenaFijo))
                {
                    MessageBox.Show("Debe de ingresar un número de contacto.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Convert.ToInt32(ValidaCadena.Rows[0]["nResul"].ToString()) > 0)
                {
                    MessageBox.Show("No es un número válido.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (matchFijo.Success == true)
                {
                    string cNumeroFijo = this.cboCodCiudad.Text.ToString() + cCadenaFijo;
                    MessageBox.Show("Se agregó correctamente el Número: " + cNumeroFijo, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cliente.CNCambiarPrincipal(Convert.ToInt32(idCli), 3, cDocumentoID, cCadenaFijo, Convert.ToInt32(idTipoTel), 2, idUsuario, idRegtel, Convert.ToInt32(this.cboCodCiudad.SelectedValue.ToString()));
                    dtgRegTelefonos.DataSource = null;
                    RellenarDatos();

                }
                else
                {
                    MessageBox.Show("No es un número válido.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }



        }

 
        private void btnEliminar1_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Se eliminará el número seleccionado.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);

            Cliente.CNCambiarPrincipal(Convert.ToInt32(idCli), 2, cDocumentoID, "0", 0, 1, idUsuario, idRegtel,0);
            dtgRegTelefonos.DataSource = null;
            RellenarDatos();
            this.txtNumerico1.Text = "";
            this.txtNumerico2.Text = "";

        }

       

        private void formatoGridClientes()
        {
            foreach (DataGridViewColumn column in this.dtgRegTelefonos.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            
            dtgRegTelefonos.Columns["cNumeroTelefonico"].Visible = true;
            dtgRegTelefonos.Columns["cTipoTelefono"].Visible = true;
            dtgRegTelefonos.Columns["cCondicionTelf"].Visible = true;


            dtgRegTelefonos.Columns["cNumeroTelefonico"].HeaderText = "Número de Teléfono";
            dtgRegTelefonos.Columns["cTipoTelefono"].HeaderText = "Tipo de Teléfono";
            dtgRegTelefonos.Columns["cCondicionTelf"].HeaderText = "Condición de Telf";

          
        }


        public void RellenarDatos()
        {

            DataTable dtTelefonos = new DataTable();

            dtTelefonos = Cliente.CNListarDatosTelefono(1,1,cDocumentoID,"0",0,1,0,0,0);

            if (dtTelefonos.Rows.Count == 0)
            {
                MessageBox.Show("No tiene algún número de celular, por favor registrar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                dtgRegTelefonos.DataSource = null;
                dtgRegTelefonos.Enabled = false;
            }
            else
            {
                dtgRegTelefonos.Enabled = true;
                dtgRegTelefonos.DataSource = dtTelefonos;
                formatoGridClientes();
                
            }

        }


            
      
        private void btnMarcar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se marcará el número seleccionado como principal y los demás como secundarios.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);


            idRegtel = Convert.ToInt32(dtgRegTelefonos.SelectedRows[0].Cells["idRegTel"].Value);

            Cliente.CNCambiarPrincipal(Convert.ToInt32(idCli), 4, cDocumentoID, "0", 0, 1, idUsuario, idRegtel,0);
            dtgRegTelefonos.DataSource = null;
            RellenarDatos();

        }

        private void dtgRegTelefonos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            idRegtel = Convert.ToInt32(dtgRegTelefonos.Rows[dtgRegTelefonos.SelectedCells[0].RowIndex].Cells["idRegTel"].Value.ToString());
        }

        private void CargarCodCiudad()
        {
            DataTable dtCodCiudad = Cliente.CNListaCodCiudad();
            cboCodCiudad.DataSource = dtCodCiudad;
            cboCodCiudad.DisplayMember = dtCodCiudad.Columns["cDescripcion"].ToString();
            cboCodCiudad.ValueMember = dtCodCiudad.Columns["idCodCiudad"].ToString();
            this.cboCodCiudad.SelectedIndex = 0;
        }
        private void CambiarTxt()
        {
            int idTipoTel = Convert.ToInt32(this.cboTipoTelefono1.SelectedValue.ToString());

            if (idTipoTel == 1)
            {
                this.txtNumerico1.Enabled = true;
                this.txtNumerico1.Visible = true;
                this.txtNumerico2.Enabled = false;
                this.txtNumerico2.Visible = false;
                this.cboCodCiudad.Visible = false;
                this.cboCodCiudad.Enabled = false;

            }
            else if (idTipoTel == 2)
            {
                this.txtNumerico1.Enabled = false;
                this.txtNumerico1.Visible = false;
                this.txtNumerico2.Enabled = true;
                this.txtNumerico2.Visible = true;
                this.cboCodCiudad.Visible = true;
                this.cboCodCiudad.Enabled = true;

            }
        
        }


        private void cboTipoTelefono1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CambiarTxt();    
        }

        private void txtNumerico2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Back))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == Convert.ToChar("."))
            {
                e.Handled = true;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }

        private void dtgRegTelefonos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idRegtel = Convert.ToInt32(dtgRegTelefonos.Rows[dtgRegTelefonos.SelectedCells[0].RowIndex].Cells["idRegTel"].Value.ToString());
        }


        private void cboCodCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtNumerico2.Text = "";
        }


        private void txtNumerico2_TextChanged(object sender, EventArgs e)
        {
            int nCodCiudad = Convert.ToInt32(cboCodCiudad.SelectedValue.ToString());

            if (nCodCiudad == 1 || nCodCiudad == 2)
            {
                this.txtNumerico2.MaxLength = 7;
            }
            else
            {
                this.txtNumerico2.MaxLength = 6;
            }
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {

            /*
             1 no debe de haber dos principales
             * 2 no debe de haber repetidos.
             * 
             */
            DataTable dtCantidad;
            dtCantidad = Cliente.CNCambiarPrincipal(Convert.ToInt32(idCli), 5, cDocumentoID, "0", 0, 1, idUsuario, idRegtel, 0);
            int idCantidad = Convert.ToInt32(dtCantidad.Rows[0]["cNro"].ToString());
            int idRepetidos = Convert.ToInt32(dtCantidad.Rows[0]["nRepetidos"].ToString());


            if (idCantidad > 1 || idRepetidos > 0)
            {
                MessageBox.Show("Existen varios números principales y/o existen números duplicados en la lista, por favor corregir para continuar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            else if (idCantidad == 1 && idRepetidos == 0)
            {
                MessageBox.Show("Registro completado con éxito.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                string cNroPrinc = Convert.ToString(dtCantidad.Rows[0]["cNroTelef"].ToString());

                cNumeroPrincipal = cNroPrinc;

                this.Close();


            }
            else if (idCantidad == 0)
            {

                MessageBox.Show("No existe un número principal, por favor seleccionar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            else
            {
                MessageBox.Show("No existen datos para validar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
        }

    }
}
