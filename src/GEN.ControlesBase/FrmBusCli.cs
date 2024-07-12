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
using ADM.CapaNegocio;


namespace GEN.ControlesBase
{
    public partial class FrmBusCli : frmBase
    {

        #region Variables Públicas

        public string pcNroDoc, pcNomCli, pcCodCli, pcDireccion, pcCodCliLargo, pcTipoDocumento, pcRucCli, pcClasifInt = string.Empty, pcTelefono = string.Empty;
        public int      pnTipoDocumento = 1, pnTipoPersona = 1, pnIdClasifInt = 0, pnIdCondDom =0;
        public bool     pIndicaDatoBasico ;
        public int idEstadoCli = 0;//Estado 2: Fallecido(P. Natural), Estado 4:Inactivo(P.Jurídica)
        public int idAgencia = 0; // permite el filtrado por agencia; 0 cuando no filtra
        public int idTipoCliente = 0;
        public int nAniosActEco = 0;
        public int idActividadInterna = 0;
        clsCNBuscarCli listarCli = new clsCNBuscarCli();
        public bool lBloqueaConsultaNombre { get; set; }
        public int idClasificacionInterna = 0;
        #endregion

        public FrmBusCli()
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
                MessageBox.Show("Debe seleccionar el criterio de Búsqueda", "Búsqueda de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCriBusCli.Focus();
                return;
            }

            if (cDatoIngr == "")
            {
                MessageBox.Show("Debe ingresar los datos a buscar", "Búsqueda de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDniNom.Focus();
                return;
            }

            if(lBloqueaConsultaNombre && cCriBus == "1" && cDatoIngr.Length < 8)
            {
                MessageBox.Show("Debe ingresar el documento de identidad completo.", "Búsqueda de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDniNom.Focus();
                return;
            }
                        
            DataTable tablaCli = listarCli.ListarClientes(cCriBus, cDatoIngr, idAgencia);
            dtgClientes.Columns.Clear();        

            dtgClientes.DataSource = tablaCli;
            formatoGridClientes();

            if (dtgClientes.RowCount == 0)
            {
                MessageBox.Show("No existen datos con el criterio de Búsqueda", "Búsqueda de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                pcNroDoc = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cDocumentoID"].Value.ToString();

                AlertaCumpleaños(pcNroDoc);

                if (ValidaCliBaseNegativa(pcNroDoc, clsVarGlobal.idModulo,clsVarGlobal.lBaseNegativa))
                {                    
                    return;
                }
                idEstadoCli = (int)dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["idEstadoCli"].Value;
                pcCodCli = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["idCli"].Value.ToString();
                pcNomCli = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cNombre"].Value.ToString();                                
                pcDireccion = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cDireccion"].Value.ToString();
                pnTipoPersona = (int)dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["IdTipoPersona"].Value;
                pcCodCliLargo = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cCodCliente"].Value.ToString();
                pnTipoDocumento = (int)dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["idTipoDocumento"].Value;
                pIndicaDatoBasico = (bool)dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["lIndDatosBasic"].Value;
                pcTipoDocumento = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cTipoDoc"].Value.ToString();
                pnIdClasifInt = Convert.ToInt32(dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["idClasifInterna"].Value);
                pcClasifInt = Convert.ToString(dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cClasifInterna"].Value);
                pnIdCondDom = Convert.ToInt32(dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["idCondDomicilio"].Value) ;
                pcRucCli = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cDocumentoAdicional"].Value.ToString();
                pcTelefono = dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["cTelefono"].Value.ToString();
                idTipoCliente = (dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["idTipoCliente"].Value == DBNull.Value) ? 0 : Convert.ToInt32(dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["idTipoCliente"].Value);
                this.nAniosActEco = Convert.ToInt32(dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["nAniosActEco"].Value);
                this.idActividadInterna = Convert.ToInt32(dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["idActividadInterna"].Value);
                this.idClasificacionInterna = Convert.ToInt32(dtgClientes.Rows[dtgClientes.SelectedCells[0].RowIndex].Cells["idClasificacionInterna"].Value);
                if (idEstadoCli.In(2,4))
                {
                    if (pnTipoPersona==1)
                    {
                        MessageBox.Show("El cliente se encuentra en estado FALLECIDO","Búsqueda de clientes",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (pnIdCondDom.In(3,4))
                        {
                            MessageBox.Show("La condición del domicilio del cliente se encuentra como NO HABIDO y en estado BAJA DE OFICIO", "Búsqueda de clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show("El cliente se encuentra en estado BAJA DE OFICIO", "Búsqueda de clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        
                    }
                }
                if (idEstadoCli.In(1,3) && pnIdCondDom.In(3,4))
                {
                    MessageBox.Show("La condición del domicilio del cliente se encuentra como NO HABIDO", "Búsqueda de clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                pcCodCli = "";
                pcNroDoc = "";
                pcNomCli = "";
                pcDireccion = "";
                pnTipoPersona = 1;
                pcCodCliLargo = "";
                pnTipoDocumento = 1;
                pcTipoDocumento = "";
                pnIdClasifInt = 0;
                pcClasifInt = string.Empty;
                pcRucCli = "";
                idTipoCliente = 0;
                pcTelefono = string.Empty;
                pcDireccion = string.Empty;
            }
            this.Dispose();
        }

        private void formatoGridClientes()
        {
            foreach (DataGridViewColumn column in dtgClientes.Columns)
            {
                column.Visible = false;
            }

            dtgClientes.Columns["idCli"].Visible = true;
            dtgClientes.Columns["cNombre"].Visible = true;
            dtgClientes.Columns["cDocumentoID"].Visible = true;
            dtgClientes.Columns["cTipoDoc"].Visible = true;

            dtgClientes.Columns["idCli"].HeaderText = "Cod. Cliente";
            dtgClientes.Columns["cNombre"].HeaderText = "Apellidos y Nombres";
            dtgClientes.Columns["cDocumentoID"].HeaderText = "Documento";
            dtgClientes.Columns["cTipoDoc"].HeaderText = "Tipo Documento";

            dtgClientes.Columns["idCli"].Width = 130;
            dtgClientes.Columns["cNombre"].Width = 372;
            dtgClientes.Columns["cDocumentoID"].Width = 90;
            dtgClientes.Columns["cTipoDoc"].Width = 90;

            lblCriterio.Text = "Ape. y Nombres:";
        }

        private void AlertaCumpleaños(string cDocumentoID)
        {
            clsCNExperienciaCliente cnExpCliente = new clsCNExperienciaCliente();

            DataTable dtPerfilAlerta = cnExpCliente.PerfilesAlertaCumpleExpCliente(Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));

            if (dtPerfilAlerta.Rows.Count == 0) 
            {
                return;
            }

            if (Convert.ToBoolean(dtPerfilAlerta.Rows[0]["lVigente"]) == false)
            {
                return;
            }

            DataTable dtAlertaCumple = cnExpCliente.AlertaCumpleExpCliente(cDocumentoID);

            if (dtAlertaCumple.Rows.Count == 0)
            {
                return;
            }

            if (Convert.ToInt32(dtAlertaCumple.Rows[0]["nAlertas"]) < Convert.ToInt32(dtPerfilAlerta.Rows[0]["nAlertasProg"])) 
            {               
                if (Convert.ToString(dtAlertaCumple.Rows[0]["Alerta"]) == "SI")
                {
                    frmExperienciaClienteAlertaCumple frm = new frmExperienciaClienteAlertaCumple();
                    frm.cDocumentoID = Convert.ToString(dtAlertaCumple.Rows[0]["cDocumentoID"]);
                    frm.cNombreCliente = Convert.ToString(dtAlertaCumple.Rows[0]["Nombres"]);
                    frm.cFechaCumpleaños = Convert.ToString(dtAlertaCumple.Rows[0]["Dia"]);
                    frm.cSegmento = Convert.ToString(dtAlertaCumple.Rows[0]["Segmento"]);
                    frm.ShowDialog();
                }
            }

        }

        #endregion
    }
}
