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
    public partial class frmBusCliBN : frmBase
    {
        #region Variables Públicas
        public int nTipoBus = 1;
        public string pcNroDoc, pcNomCli, pcCodCli, pcDireccion, pcCodCliLargo, pcNombre, pcApellidoPaterno, pcApellidoMaterno, pcApellidoCasado, pcRazonSocial, pcNombreComercial;
        public int pnTipoDocumento = 1, pnTipoPersona = 1,pnidBaseNegativa=0;
        public bool pIndicaDatoBasico;

        #endregion

        public frmBusCliBN()
        {
            InitializeComponent();
            this.cboCriBusCli.Focus();
        }

        #region Eventos

        private void FrmBusquedaCliBN_Load(object sender, EventArgs e)
        {
            this.cboCriBusCli.SelectedValue = 1;
            txtDniNom.Focus();
        }

        public void establecerTipoBusqueda(int nTipoBus)
        {
            this.nTipoBus = nTipoBus;
        }

        private void cboCriBusCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cCriBus;
            cCriBus = cboCriBusCli.SelectedValue.ToString();
            
            dtgClientes.Columns.Clear();            

            if (cCriBus == "1")
            {
                lblCriterio.Text = "DNI:";
            }
            else if (cCriBus == "2")
            {
                lblCriterio.Text = "Ape. y Nombres:";
            }
            else if (cCriBus == "3")
            {
                lblCriterio.Text = "RUC:";
            }
            else
            {
                lblCriterio.Text = "Otros:";
            }
            txtDniNom.Clear();
            txtDniNom.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }

        private void btnBusCliente_Click(object sender, EventArgs e)
        {
            string cCriBus, cDatoIngr;
            cCriBus = cboCriBusCli.SelectedValue.ToString();
            cDatoIngr = txtDniNom.Text.Trim();

            if (cCriBus == "")
            {
                MessageBox.Show("Debe Seleccionar El Criterio de Busqueda", "Busqueda de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCriBusCli.Focus();
                return;
            }

            if (cDatoIngr == "")
            {
                MessageBox.Show("Debe Ingresar los Datos a Buscar", "Busqueda de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDniNom.Focus();
                return;
            }

            clsCNBuscarCli listarCli = new clsCNBuscarCli();
            DataTable tablaCli = listarCli.ListarClientesBN(nTipoBus, cCriBus, cDatoIngr);
            dtgClientes.Columns.Clear();

            this.dtgClientes.DataSource = tablaCli;

            if (nTipoBus==1)
            {
                for (int i = 3; i < dtgClientes.Columns.Count; i++)
                {
                    dtgClientes.Columns[i].Visible = false;
                }
                dtgClientes.Columns[0].Width = 80;
                dtgClientes.Columns[0].HeaderText = "Cod. Cliente";

                dtgClientes.Columns[1].Width = 150;
                dtgClientes.Columns[1].HeaderText = "Apellidos y Nombres";

                dtgClientes.Columns[2].Width = 80;
                dtgClientes.Columns[2].HeaderText = "Documento";
            }
            else
            {
                dtgClientes.Columns["cNombre"].Visible = false;
                dtgClientes.Columns["cApellidoPaterno"].Visible = false;
                dtgClientes.Columns["cApellidoMaterno"].Visible = false;
                dtgClientes.Columns["cApellidoCasado"].Visible = false;
                dtgClientes.Columns["cRazonSocial"].Visible = false;
                dtgClientes.Columns["cNombreComercial"].Visible = false;
                dtgClientes.Columns["cDireccion"].Visible = false;
                dtgClientes.Columns["IdTipoPersona"].Visible = false;
                dtgClientes.Columns["cCodCliente"].Visible = false;
                dtgClientes.Columns["idTipoDocumento"].Visible = false;
                dtgClientes.Columns["lIndDatosBasic"].Visible = false;
                dtgClientes.Columns["idClasifInterna"].Visible = false;
                dtgClientes.Columns["cClasifInterna"].Visible = false;
                dtgClientes.Columns["idBaseNegativa"].Visible = false;
                dtgClientes.Columns["idModulo"].Visible = false;

                dtgClientes.Columns["idCli"].Width = 30;
                dtgClientes.Columns["idCli"].HeaderText = "Cod. Cliente";

                dtgClientes.Columns["NomCompleto"].Width = 80;
                dtgClientes.Columns["NomCompleto"].HeaderText = "Apellidos y Nombres";

                dtgClientes.Columns["cDocumentoID"].Width = 40;
                dtgClientes.Columns["cDocumentoID"].HeaderText = "Documento";

                dtgClientes.Columns["cModulo"].Width = 80;
                dtgClientes.Columns["cModulo"].HeaderText = "Módulo";
            }
            
            if (dtgClientes.RowCount == 0)
            {
                MessageBox.Show("No Existen Datos con el criterio de Busqueda", "Busqueda de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDniNom.Focus();
                return;
            }
            formatoGridClientes();
            this.dtgClientes.Focus();
        }

        private void txtDniNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBusCliente.PerformClick();
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
            if (dtgClientes.Rows.Count<=0)
            {
                MessageBox.Show("No Exiswten Datos con el criterio de Busqueda...Verificar", "Busqueda de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            switch (Convert.ToInt32(cboCriBusCli.SelectedValue))
            {
                case 1:
                    pcCodCli = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["idCli"].Value.ToString();                    
                    pcNomCli = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["NomCompleto"].Value.ToString();
                    pcNroDoc = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cDocumentoID"].Value.ToString();
                    pcNombre = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cNombre"].Value.ToString();
                    pcApellidoPaterno = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cApellidoPaterno"].Value.ToString();
                    pcApellidoMaterno = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cApellidoMaterno"].Value.ToString();
                    pcApellidoCasado = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cApellidoCasado"].Value.ToString();                    
                    
                    pcDireccion = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cDireccion"].Value.ToString();
                    pnTipoPersona = (int)dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["IdTipoPersona"].Value;
                    if (pnTipoPersona==1)
                    {
                        pcRazonSocial = "";
                        pcNombreComercial = "";
                    }
                    else
                    {
                        pcRazonSocial = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["NomCompleto"].Value.ToString(); ;
                        pcNombreComercial = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["NomCompleto"].Value.ToString(); 
                    }
                    pcCodCliLargo = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cCodCliente"].Value.ToString();
                    pnTipoDocumento = (int)dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["idTipoDocumento"].Value;
                    pIndicaDatoBasico = Convert.ToBoolean(dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["lIndDatosBasic"].Value);
                    pnidBaseNegativa = (int)dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["idBaseNegativa"].Value;
                    break;
                case 2:
                    pcCodCli = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["idCli"].Value.ToString();
                    pcNomCli = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["NomCompleto"].Value.ToString();
                    pcNroDoc = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cDocumentoID"].Value.ToString();
                    pcNombre = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells[3].Value.ToString();
                    pcApellidoPaterno = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells[4].Value.ToString();
                    pcApellidoMaterno = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells[5].Value.ToString();
                    pcApellidoCasado = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells[6].Value.ToString();                    
                    pcRazonSocial = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells[7].Value.ToString();
                    pcNombreComercial = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells[8].Value.ToString();
                    pcDireccion = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells[9].Value.ToString();
                    pnTipoPersona = (int)dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["IdTipoPersona"].Value;
                    pcCodCliLargo = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells[11].Value.ToString();
                    pnTipoDocumento = (int)dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells[12].Value;
                    pIndicaDatoBasico = Convert.ToBoolean(dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells[13].Value);
                    pnidBaseNegativa = (int)dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["idBaseNegativa"].Value;
                    break;
                case 3:
                    pcCodCli = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells[0].Value.ToString();                    
                    pcNomCli = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
                    pcNroDoc = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells[2].Value.ToString();
                    pcNombre = "";
                    pcApellidoPaterno = "";
                    pcApellidoMaterno = "";
                    pcApellidoCasado = "";                    
                    pcRazonSocial = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells[3].Value.ToString();
                    pcNombreComercial = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells[4].Value.ToString();
                    pcDireccion = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells[5].Value.ToString();
                    pnTipoPersona = (int)dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells[6].Value;
                    pcCodCliLargo = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells[7].Value.ToString();
                    pnTipoDocumento = (int)dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells[8].Value;
                    pIndicaDatoBasico = Convert.ToBoolean(dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells[9].Value);
                    pnidBaseNegativa = (int)dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["idBaseNegativa"].Value;
                    break;
                default:
                    pcCodCli = "";
                    pcNomCli = "";
                    pcNroDoc = "";
                    pcNombre = "";         
                    pcApellidoPaterno = "";
                    pcApellidoMaterno = "";
                    pcApellidoCasado = "";                    
                    pcRazonSocial = "";
                    pcNombreComercial = "";
                    pcDireccion = "";
                    pnTipoPersona = 1;
                    pcCodCliLargo = "";
                    pnTipoDocumento = 1;
                    pnidBaseNegativa = 0;
                    break;
            }
            
            this.Dispose();
        }

        private void formatoGridClientes()
        {
            //dtgClientes.Columns[0].Width = 130;
            //dtgClientes.Columns[1].Width = 372;
            //dtgClientes.Columns[0].HeaderText = "Cod. Cliente";
            //dtgClientes.Columns[1].HeaderText = "Apellidos y Nombres";
            //dtgClientes.Columns[2].HeaderText = "Documento";
            lblCriterio.Text = "Ape. y Nombres:";
        }

        #endregion
    }
}
