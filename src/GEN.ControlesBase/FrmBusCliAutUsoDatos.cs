using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.CapaNegocio;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class FrmBusCliAutUsoDatos : frmBase
    {

        #region Variables Públicas

        public string pcCodCliAutUsoDat="0",pcNroDoc, pcNomCli, pcCodCli, pcDireccion, pcCodCliLargo, pcTipoDocumento, pcRucCli,pcTelefono;
        public string pcDistrito, pcProvincia, pcDepartamento, pcCorreoCli;

        public int  pnTipoDocumento = 1, pnTipoPersona = 1   ;
    
         clsCNBuscarCli listarCli = new clsCNBuscarCli();
        public bool lBloqueaConsultaNombre { get; set; }
        public int idClasificacionInterna = 0;
        public bool lAceptar = false;

        private string pcCriBus=string.Empty;
        #endregion

        public FrmBusCliAutUsoDatos()
        {
            InitializeComponent();
            lBloqueaConsultaNombre = false;
            this.cboCriBusCli.Focus();  
        }

        #region Eventos

        private void FrmBusquedaCli_Load(object sender, EventArgs e)
        {
            this.cboCriBusCli.cargaDatos(lBloqueaConsultaNombre);
            this.cboCriBusCli.SelectedValue = 1;
            txtDniNom.Focus();
        }

        private void cboCriBusCli1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cCriBus;
            cCriBus = cboCriBusCli.SelectedValue.ToString();
            pcCriBus = cCriBus;
            if (cCriBus=="1")
            {
                lblCriterio.Text = "Doc.Identidad:";
                txtDniNom.MaxLength = 15;
            }
            else if (cCriBus == "2")
            {
                lblCriterio.Text = "Ape. y Nombres:";
                txtDniNom.MaxLength = 200;
            }
            else if (cCriBus == "3")
            {
                lblCriterio.Text = "RUC:";
                txtDniNom.MaxLength = 15;
            }
            else
            {
                lblCriterio.Text = "Otros:";
            }
            txtDniNom.Clear();
            txtDniNom.Focus();
        }
        private void validarSoloLetras(txtBase txt, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 8 || e.KeyChar == 32 || e.KeyChar == 209 || e.KeyChar == 241)
            {
                e.Handled = false;
                if (txt.Text.Trim().Length == 0 && e.KeyChar == ' ')
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();                                 
        }
          
        private void btnBusCliente_Click(object sender, EventArgs e)
        {
            string cCriBus, cDatoIngr;
            cCriBus     = cboCriBusCli.SelectedValue.ToString();
            cDatoIngr   = txtDniNom.Text.Trim();

            if (cCriBus == "")
            {
                MessageBox.Show("Debe seleccionar el criterio de Búsqueda.", "Búsqueda de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCriBusCli.Focus();
                return;
            }

            if (cDatoIngr == "")
            {
                MessageBox.Show("Debe ingresar los datos a buscar.", "Búsqueda de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDniNom.Focus();
                return;
            }

            if(lBloqueaConsultaNombre && cCriBus == "1" && cDatoIngr.Length < 8)
            {
                MessageBox.Show("Debe ingresar el documento de identidad completo.", "Búsqueda de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDniNom.Focus();
                return;
            }

            DataTable tablaCli = listarCli.ListarClientesAutUsoDatos(cCriBus, cDatoIngr, 0);
            dtgClientes.Columns.Clear();        

            dtgClientes.DataSource = tablaCli;
            formatoGridClientes();

            if (dtgClientes.RowCount == 0)
            {
                MessageBox.Show("No existen datos con el criterio de Búsqueda.", "Búsqueda de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDniNom.Focus();
                return;
            }
            
            this.dtgClientes.Focus();            
        }

        private void txtDniNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                btnBusCliente.PerformClick();
            }
       

           
            if (pcCriBus=="1")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (pcCriBus == "2")
            {
                 validarSoloLetras((txtBase)sender, e);
            }
           
       
        
        }

        private void dtgClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                aceptar();
            }
        }

        #endregion

        #region Metodos

        private void aceptar()
        {
            if (dtgClientes.RowCount > 0)
            {
                pcNroDoc = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cNroDocumento"].Value.ToString(); 
                pcCodCliAutUsoDat = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["idCliAutUsoDat"].Value.ToString(); 
                pcCodCli = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["idCli"].Value.ToString();
                pcNomCli = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cNombres"].Value.ToString();                                
                pcDireccion = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cDireccion"].Value.ToString();
                pnTipoPersona = (int)dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["IdTipoPersona"].Value;
                pcCodCliLargo = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cCodCliente"].Value.ToString();
                pnTipoDocumento = (int)dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["idTipoDocumento"].Value;
                pcTipoDocumento = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cTipoDoc"].Value.ToString();
                pcTelefono = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cTelefono"].Value.ToString();

                pcDistrito     = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cDistrito"].Value.ToString();
                pcProvincia    = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cProvincia"].Value.ToString();
                pcDepartamento = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cDepartamento"].Value.ToString();
                pcCorreoCli    = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cCorreoCli"].Value.ToString();   
                
            }
            else
            {
                pcCodCliAutUsoDat = "0";
                pcCodCli = "";
                pcNroDoc = "";
                pcNomCli = "";
                pcDireccion = "";
                pnTipoPersona = 1;
                pcCodCliLargo = "";
                pnTipoDocumento = 1;
                pcTipoDocumento = "";  
                pcRucCli = "";
                pcTelefono = string.Empty;
                pcDistrito = string.Empty;
                pcProvincia    =string.Empty;
                pcDepartamento =string.Empty;
                pcCorreoCli = string.Empty;  
            }
            this.lAceptar = true;
            this.Dispose();
        }

        private void formatoGridClientes()
        {
            foreach (DataGridViewColumn column in dtgClientes.Columns)
            {
                column.Visible = false;
            }
            dtgClientes.Columns["idCliAutUsoDat"].Visible = false;
            dtgClientes.Columns["idCli"].Visible = true;
            dtgClientes.Columns["cNombres"].Visible = true;
            dtgClientes.Columns["cNroDocumento"].Visible = true;
            dtgClientes.Columns["cTipoDoc"].Visible = true;
            

            dtgClientes.Columns["idCli"].HeaderText = "Cód. Cliente";
            dtgClientes.Columns["cNombres"].HeaderText = "Apellidos y Nombres";
            dtgClientes.Columns["cNroDocumento"].HeaderText = "Documento";
            dtgClientes.Columns["cTipoDoc"].HeaderText = "Tipo Documento";

            dtgClientes.Columns["idCli"].Width = 130;
            dtgClientes.Columns["cNombres"].Width = 372;
            dtgClientes.Columns["cNroDocumento"].Width = 90;
            dtgClientes.Columns["cTipoDoc"].Width = 90;

            string cCriBus;
            cCriBus = cboCriBusCli.SelectedValue.ToString();
            pcCriBus = cCriBus;
            if (cCriBus == "1")
            {
                lblCriterio.Text = "Doc.Identidad:";
                txtDniNom.MaxLength = 15;
            }
            else if (cCriBus == "2")
            {
                lblCriterio.Text = "Ape. y Nombres:";
                txtDniNom.MaxLength = 200;
            }
            else if (cCriBus == "3")
            {
                lblCriterio.Text = "RUC:";
                txtDniNom.MaxLength = 15;
            }
            else
            {
                lblCriterio.Text = "Otros:";
            }
            txtDniNom.Clear();
            txtDniNom.Focus();
        }

        #endregion

        private void txtDniNom_KeyUp(object sender, KeyEventArgs e)
        {
            //this.txtDniNom.Text = this.txtDniNom.Text.Replace("  ", " ");
            //this.txtDniNom.SelectionStart = this.txtDniNom.Text.Length;
            //this.txtDniNom.SelectionLength = 0;
        }
    }
}
