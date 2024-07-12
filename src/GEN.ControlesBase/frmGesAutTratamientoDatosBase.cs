using ADM.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.ControlesBase.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class frmGesAutTratamientoDatosBase : frmBase
    {
        #region variables
        public string pcTipOpe = "N"; //Puede ser N --> Nuevo, A--> Actualizar 
         BindingList<AutorizaTratamientoUsoDatos> lstHistoricoData = new BindingList<AutorizaTratamientoUsoDatos>();
         
        public int nidTipoPersona  ;
        public int nidTipoDocumento ;
  
        public int idAgencia = 0; // permite el filtrado por agencia
        public int idCli { get; set; }
        private string pCodCliente = "";
        bool lIndicadorConcentimientoAnterior;
        #endregion 
        #region eventos
        public frmGesAutTratamientoDatosBase()
        {
            InitializeComponent();
        }

        private async void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (pcTipOpe.Equals("A"))
            {
                this.btnGrabar1.Enabled = false;
                if (conAutDatosBase1.dataMaestro.idMaestroAutorizacion == 0)
                {
                    if (this.lIndicadorConcentimientoAnterior == this.conAutDatosBase1.dataMaestro.detalleAutorizacion.Find(x => x.idTipoAutorizacion == 2).lIndicadorConcentimiento)
                    {
                        MessageBox.Show("La autorización de uso de datos no tuvo cambios.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.btnGrabar1.Enabled = true;
                        return;
                    }

                    this.btnGrabar1.Enabled = false;
                    bool respuesta = await conAutDatosBase1.grabarAutorizacionDatos(nidTipoDocumento, nidTipoPersona,txtNroDoc.Text.Trim(),
                        txtNombre.Text.Trim(),
                        txtDireccion.Text.Trim(),
                        txtTelefono.Text.Trim(),
                        pCodCliente,
                        idCli,
                        chcIngresarDatos.Checked,
                         conAutDatosBase1.dataMaestro.idMaestroAutOrigen
                        );
                    if (respuesta)
                    {
                        this.btnGrabar1.Enabled = false;
                        this.activarcontroles(false);
                        this.btnCancelar1.Enabled = false;
                        if (conAutDatosBase1.dataMaestro.idMaestroAutorizacion > 0)
                        {
                            this.btnImprimir1.Enabled = true;
                            this.chcIngresarDatos.Enabled = true;
                            this.btnBusCliente.Enabled = true;
                            this.txtCodCli.Enabled = false;
                            if (clsVarApl.dicVarGen["nPerfilEdiTrabAutTraDat"] == clsVarGlobal.PerfilUsu.idPerfil)
                            {
                                btnEditar1.Enabled = true;
                            }

                        }
                        this.BuscarHistoricoAutTratamientoDatos(nidTipoDocumento,txtNroDoc.Text.Trim());
                    }
                    else
                    {
                        this.btnGrabar1.Enabled = true;
                        this.btnCancelar1.Enabled = true;
                    }
                }
                else
                {

                    bool respuesta = await conAutDatosBase1.grabarEdicionArchivoAutorizacionDatos();
                    if (respuesta)
                    {
                        this.btnGrabar1.Enabled = false;
                        this.btnCancelar1.Enabled = false;
                        if (conAutDatosBase1.dataMaestro.idMaestroAutorizacion > 0)
                        {
                            this.btnImprimir1.Enabled = true;
                            this.chcIngresarDatos.Enabled = true;
                            this.btnBusCliente.Enabled = true;
                            this.txtCodCli.Enabled = false;
                            if (clsVarApl.dicVarGen["nPerfilEdiTrabAutTraDat"] == clsVarGlobal.PerfilUsu.idPerfil)
                            {
                                btnEditar1.Enabled = true;
                            }

                        }
                        this.BuscarHistoricoAutTratamientoDatos(nidTipoDocumento,txtNroDoc.Text.Trim());
                    }
                    else
                    {
                        this.btnGrabar1.Enabled = true;
                        this.btnCancelar1.Enabled = true;
                    }
                }
            }
            else
            {
                this.btnGrabar1.Enabled = false;
                if (this.chcIngresarDatos.Checked)
                {
                    nidTipoDocumento = Convert.ToInt32(cboTipDocumento.SelectedValue);
                    nidTipoPersona = 1;
                     
                }
                bool respuesta = await conAutDatosBase1.grabarAutorizacionDatos(nidTipoDocumento,nidTipoPersona,txtNroDoc.Text.Trim(),
                    txtNombre.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    pCodCliente,
                    idCli,
                    chcIngresarDatos.Checked
                    );
                if (respuesta)
                {
                    this.btnGrabar1.Enabled = false;
                    this.activarcontroles(false);
                    this.btnCancelar1.Enabled = false;
                    if (conAutDatosBase1.dataMaestro.idMaestroAutorizacion > 0)
                    {
                        this.btnImprimir1.Enabled = true;
                        this.chcIngresarDatos.Enabled = true;
                        this.btnBusCliente.Enabled = true;
                        this.txtCodCli.Enabled = false;
                        if (clsVarApl.dicVarGen["nPerfilEdiTrabAutTraDat"] == clsVarGlobal.PerfilUsu.idPerfil)
                        {
                            btnEditar1.Enabled = true;
                        }

                    }
                    this.BuscarHistoricoAutTratamientoDatos(nidTipoDocumento,txtNroDoc.Text.Trim()); 
                }
                else
                {
                    this.btnGrabar1.Enabled = true;
                    this.btnCancelar1.Enabled = true; 
                }
            }
           
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 0)
            {
                MessageBox.Show("Servicio de autorización de uso de datos no habilitado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((this.txtNroDoc.Text.Trim().Length == 8 && nidTipoDocumento==1) || (this.txtNroDoc.Text.Trim().Length >= 1 && nidTipoDocumento ==2) || (this.txtNroDoc.Text.Trim().Length >= 1 && nidTipoDocumento == 3))
            {
                 
                if (conAutDatosBase1.dataMaestro.idMaestroAutorizacion == 0)
                {
                    MessageBox.Show("No existe autorización a editar, debe elegir uno.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                pcTipOpe = "A";
                this.conAutDatosBase1.cTipoOpcion = pcTipOpe;
                this.habilitarBotones(false);
                this.chcIngresarDatos.Enabled = false;
                this.btnBusCliente.Enabled = false;
                this.txtCodCli.Enabled = false;
                
                this.btnEditar1.Enabled = false;
                this.btnImprimir1.Enabled = false;
                this.conAutDatosBase1.habilitarEdicion();

                if (clsVarApl.dicVarGen["nPerfilEdiTrabAutTraDat"] == clsVarGlobal.PerfilUsu.idPerfil)
                {
                    this.conAutDatosBase1.habilitarBotonAdjuntar(true);
                    this.conAutDatosBase1.limpiarArchivoEdicion();
                }
                else
                {
                    this.conAutDatosBase1.habilitarControlesEdicionGestions();
                    this.conAutDatosBase1.limpiarTodoEdicion();
                    this.conAutDatosBase1.habilitarBotonAdjuntar(false);
                    this.conAutDatosBase1.habilitarControlEdicion();
                    int idMaestroAutorizacion = this.conAutDatosBase1.dataMaestro.idMaestroAutorizacion;
                    this.conAutDatosBase1.dataMaestro.idMaestroAutorizacion = 0;
                    this.conAutDatosBase1.dataMaestro.idMaestroAutOrigen = idMaestroAutorizacion;
                    this.lIndicadorConcentimientoAnterior = this.conAutDatosBase1.dataMaestro.detalleAutorizacion.Find(x => x.idTipoAutorizacion == 2).lIndicadorConcentimiento;
                }

            }
            else if (this.txtNroDoc.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe elegir a un cliente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }  
            
        }
       

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
          
            if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 0)
            {
                MessageBox.Show("Servicio de autorización de uso de datos no habilitado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            if (chcIngresarDatos.Checked)
            {
                this.pcTipOpe = "N";
                this.conAutDatosBase1.limpiarContenido();
                this.habilitarBotones(false);
                this.lstHistoricoData.Clear();
                this.tbcBase1.SelectedTab = tabPage1;
                this.conAutDatosBase1.cargarDatosNuevo();
            }
            else
            {

                if (!string.IsNullOrEmpty(this.txtNroDoc.Text.Trim()) &&  ((this.txtNroDoc.Text.Trim().Length == 8 && nidTipoDocumento == 1) || (this.txtNroDoc.Text.Trim().Length >= 1 && nidTipoDocumento == 2) || (this.txtNroDoc.Text.Trim().Length >= 1 && nidTipoDocumento == 3)))
                {
                    this.pcTipOpe = "N";
                    this.conAutDatosBase1.limpiarContenido();
                    this.habilitarBotones(false);    
                    this.btnBusCliente.Enabled = false;
                    this.chcIngresarDatos.Enabled = false;

                    this.tbcBase1.SelectedTab = tabPage1;
                    conAutDatosBase1.cargarDatosNuevo();

                }
                else
                {
                    MessageBox.Show("Debe elegir a un cliente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            } 
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        { 
            this.conAutDatosBase1.deshabilitarControles();
            this.conAutDatosBase1.limpiarContenido(); 
            this.habilitarBotones(true); 
            this.btnBusCliente.Enabled = true;
            if(chcIngresarDatos.Checked){
              
                this.chcIngresarDatos.Checked = false;
                this.btnBusCliente.Enabled = true;
                this.limpiarControles();
            
            }
            this.txtCodCli.Enabled = false; 
            this.lstHistoricoData.Clear();
            this.limpiarControles();
            this.txtCodCli.Enabled = true;
             
            this.btnBusCliente.Enabled = true;
            this.chcIngresarDatos.Enabled = true;
            this.conAutDatosBase1.cTipoOpcion = string.Empty;

        } 
 
        private void frmGesAutTratamientoDatos_Load(object sender, EventArgs e)
        {
            this.dtgHistorico.DataSource = null;
            this.dtgHistorico.DataSource = lstHistoricoData;
            this.conAutDatosBase1.titulo = this.Text;
            this.conAutDatosBase1.deshabilitarControles();

            this.habilitarBotones(true);
            this.conAutDatosBase1.cargarCanal();
            
        } 

        private void dtgHistorico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(lstHistoricoData.Count()>0){
                var dataselHis = (AutorizaTratamientoUsoDatos)dtgHistorico.CurrentRow.DataBoundItem;

                if (e.ColumnIndex == 35)
                {
                    if (dataselHis != null)
                    {
                         

                        this.BuscarArchivoAutTratamientoDatos(dataselHis.cNroDocumento, dataselHis.idArchivo);
  

                    }
                }
            }
        }
   

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnBusCliente_Click(object sender, EventArgs e)
        {
            buscar( sender,  e);
        }


        private void chcIngresarDatos_CheckedChanged(object sender, EventArgs e)
        {
            if (chcIngresarDatos.Checked)
            {
                this.activarcontroles(true);
                this.limpiarControles();
                btnEditar1.Enabled = false;
                btnBusCliente.Enabled = false;
                btnCancelar1.Enabled = true; 
                this.lstHistoricoData.Clear();
                this.txtCodCli.Enabled = false;
                btnImprimir1.Enabled = false;
                btnNuevo1_Click(sender,e);
                this.cboTipDocumento.CargarDocumentos("V");
                this.cboTipDocumento.SelectedIndex = -1;
            }
            else
            {
                this.activarcontroles(false);
                this.txtCodCli.Enabled = true;
                this.btnCancelar1_Click(sender,e);
            }
        }

        private void txtCodCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 13)
            {
                e.Handled = false;
                if (e.KeyChar == 13)
                {
                    Int32 nCifras = txtCodCli.TextLength;

                    if (nCifras == 0)
                    {
                        MessageBox.Show("Valor de Búsqueda Incorrecto.", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtCodCli.Focus();
                        txtCodInst.Text = string.Empty;
                        txtCodAge.Text = string.Empty;
                        txtCodCli.Text = string.Empty;
                        txtNroDoc.Text = string.Empty;
                        txtNombre.Text = string.Empty;
                        txtDireccion.Text = string.Empty;
                        txtCodCli.Enabled = true;
                        txtCodCli.Focus();
                        idCli = 0;
                        this.txtTelefono.Text = string.Empty;
                    }
                    else
                    {
                        if (Convert.ToInt32(this.txtCodCli.Text) <= 0)
                        {
                            MessageBox.Show("Ingrese un Código de Cliente Válido.", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.txtCodCli.Focus();
                            this.txtCodCli.SelectAll();
                            idCli = 0;
                            return;
                        }

                        CargardatosCli(Convert.ToInt32(txtCodCli.Text), sender, e);
                    }
                }
            }
            else
            {
                e.Handled = true;
            }    
        }

        private void txtNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
             
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && ((e.KeyChar != '(') || (e.KeyChar != ')')))
            {
                e.Handled = true;
            }

            if (((e.KeyChar == '(') && ((sender as TextBox).Text.IndexOf('(') > -1)) || ((e.KeyChar == ')') && ((sender as TextBox).Text.IndexOf(')') > -1)))
            {
                e.Handled = true;
            }
        }

        private void txtNroDoc_Leave(object sender, EventArgs e)
        {
            if(chcIngresarDatos.Checked){
                if (!string.IsNullOrEmpty(txtNroDoc.Text.Trim()) && txtNroDoc.Text.Trim().Length==8 )
                {
                    clsCNBuscarCli listarCli = new clsCNBuscarCli();

                    DataTable tablaCli = listarCli.ListarClientesAutUsoDatos("1", txtNroDoc.Text, 0);


                    if (tablaCli.Rows.Count > 0)
                    {
                        this.txtNroDoc.Leave -= txtNroDoc_Leave;
                        activarcontroles(false);
                        this.txtNroDoc.Leave += txtNroDoc_Leave;
                        chcIngresarDatos.CheckedChanged -= chcIngresarDatos_CheckedChanged;
                        chcIngresarDatos.Checked = false;
                        chcIngresarDatos.CheckedChanged += chcIngresarDatos_CheckedChanged;
                        if (MessageBox.Show("Nro. de documento ya existe, ¿Desea proceder a cargar las datos del cliente?. ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            string pcNroDoc = tablaCli.Rows[0]["cNroDocumento"].ToString();
                            string pcNomCli = tablaCli.Rows[0]["cNombres"].ToString();
                            string pcDireccion = tablaCli.Rows[0]["cDireccion"].ToString();
                            int pnTipoPersona = (int)tablaCli.Rows[0]["IdTipoPersona"];
                            string pcCodCliLargo = tablaCli.Rows[0]["cCodCliente"].ToString();
                            int pnTipoDocumento = (int)tablaCli.Rows[0]["idTipoDocumento"];

                            string pcTelefono = tablaCli.Rows[0]["cTelefono"].ToString();
                            string pcCorreoCli = tablaCli.Rows[0]["cCorreoCli"].ToString();


                            if (!string.IsNullOrEmpty(pcCodCliLargo))
                            {
                                txtCodInst.Text = pcCodCliLargo.Substring(0, 3);
                                txtCodAge.Text = pcCodCliLargo.Substring(3, 3);
                                txtCodCli.Text = pcCodCliLargo.Substring(6);
                                pCodCliente = pcCodCliLargo;
                            }
                            txtNroDoc.Text = pcNroDoc;
                            txtNombre.Text = pcNomCli;
                            txtTelefono.Text = pcTelefono;
                            txtDireccion.Text = pcDireccion;
                            cboTipDocumento.SelectedValue = pnTipoDocumento;

                            nidTipoPersona = pnTipoPersona;
                            nidTipoDocumento = pnTipoDocumento;
                            txtCodCli.Enabled = false;
                            btnBusCliente.Enabled = true;
                            this.conAutDatosBase1.deshabilitarControles(); 
                            if (nidTipoPersona == 2 || nidTipoPersona == 3)// PERSONA JURIDICO
                            {
                                //CARGAR DATOS DE REPRESETANTE

                                this.limpiarControles();
                                MessageBox.Show("Autorización de tratamiento de datos no aplica para persona jurídica.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            if ((txtNroDoc.Text.Trim().Length == 8 && nidTipoDocumento == 1) || (txtNroDoc.Text.Trim().Length >= 2 && nidTipoDocumento == 2) || (txtNroDoc.Text.Trim().Length >= 2 &&  nidTipoDocumento == 3))
                            {
                                conAutDatosBase1.BuscarAutTratamientoDatos(nidTipoDocumento,txtNroDoc.Text.Trim(), sender,  e);
                                this.BuscarHistoricoAutTratamientoDatos(nidTipoDocumento,txtNroDoc.Text.Trim());
                            }


                        }
                        else
                        {
                            btnCancelar1_Click(sender, e);
                        }
                    }
                }                
            }           
            
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarSoloLetras((txtBase)sender, e);
        }



        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.validaEspacioInicio((txtBase)sender, e);
        } 
     
        private void txtComentario_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.validaEspacioInicio((txtBase)sender, e);
        }
        #endregion

        #region metodos
        private void CargardatosCli(int codCliente, object sender, EventArgs e)
        {
            clsCNBuscarCli listarCli = new clsCNBuscarCli();

            DataTable tablaCli = listarCli.ListarClixIdCliAutUsoDatos(codCliente);

            if (tablaCli.Rows.Count > 0)
            {
                txtCodInst.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(0, 3);
                txtCodAge.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(3, 3);
                txtCodCli.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(6);

                txtNroDoc.Text = Convert.ToString(tablaCli.Rows[0]["cNroDocumento"]);
                txtNombre.Text = Convert.ToString(tablaCli.Rows[0]["cNombres"]);
                txtDireccion.Text = Convert.ToString(tablaCli.Rows[0]["cDireccion"]);
                nidTipoPersona = Convert.ToInt32(tablaCli.Rows[0]["IdTipoPersona"]);
                this.pCodCliente = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]);
                txtCodCli.Enabled = false;
                this.idCli = txtCodCli.Text == "" ? 0 : Convert.ToInt32(txtCodCli.Text);
                this.txtTelefono.Text = tablaCli.Rows[0]["cTelefono"].ToString();
         
                    if ((nidTipoDocumento == 1 && txtNroDoc.Text.Trim().Length == 8)|| (txtNroDoc.Text.Trim().Length >=2 && nidTipoDocumento == 2) || (txtNroDoc.Text.Trim().Length >= 2 && nidTipoDocumento == 3))
                {
                        this.conAutDatosBase1.BuscarAutTratamientoDatos(nidTipoDocumento,txtNroDoc.Text.Trim(), sender,  e);
                        this.BuscarHistoricoAutTratamientoDatos(nidTipoDocumento,txtNroDoc.Text.Trim());
                    }
                
                else
                {
                    if (nidTipoPersona == 2 || nidTipoPersona == 3)// PERSONA JURIDICO
                    {
                        //CARGAR DATOS DE REPRESETANTE

                        this.limpiarControles();
                        MessageBox.Show("Autorización de tratamiento de datos no aplica para persona jurídica.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                
            }
            else if (tablaCli.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró ningún Registro.", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodInst.Text = string.Empty;
                txtCodAge.Text = string.Empty;
                txtCodCli.Text = string.Empty;
                txtNroDoc.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtCodCli.Enabled = true;
                txtCodCli.Focus();
                this.idCli = 0;
                this.txtTelefono.Text = string.Empty;
                this.pCodCliente = string.Empty;
            }
        }
        private void validarSoloLetras(txtBase txt, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 8 || e.KeyChar == 32 || e.KeyChar == 209 || e.KeyChar == 241)
            {
                e.Handled = false;
                this.validaEspacioInicio(txt, e);

            }
            else
            {
                e.Handled = true;
            }
        }
        private void validaEspacioInicio(txtBase txt, KeyPressEventArgs e)
        {
            if (txt.Text.Trim().Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }
        public async void buscar(object sender, EventArgs e)
        {
            this.lstHistoricoData.Clear();
             if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 1)
            {
                FrmBusCliAutUsoDatos frmbuscarcli = new FrmBusCliAutUsoDatos();
                frmbuscarcli.ShowDialog();
                if (frmbuscarcli.lAceptar && (!string.IsNullOrEmpty(frmbuscarcli.pcCodCliLargo) || !string.IsNullOrEmpty(frmbuscarcli.pcNroDoc)))
                {
                    if (!string.IsNullOrEmpty(frmbuscarcli.pcCodCliLargo))
                    {
                        txtCodInst.Text = frmbuscarcli.pcCodCliLargo.Substring(0, 3);
                        txtCodAge.Text = frmbuscarcli.pcCodCliLargo.Substring(3, 3);
                        txtCodCli.Text = frmbuscarcli.pcCodCliLargo.Substring(6);
                        pCodCliente = frmbuscarcli.pcCodCliLargo;
                    }
                    cboTipDocumento.SelectedValue = frmbuscarcli.pnTipoDocumento;
                    txtNroDoc.Text = frmbuscarcli.pcNroDoc;
                    txtNombre.Text = frmbuscarcli.pcNomCli;
                    txtTelefono.Text = frmbuscarcli.pcTelefono;
                    txtDireccion.Text = frmbuscarcli.pcDireccion;
                    nidTipoPersona = frmbuscarcli.pnTipoPersona;
                    nidTipoDocumento = frmbuscarcli.pnTipoDocumento;
                    //cboTipDocumento.SelectedIndexChanged -= cboTipDocumento_SelectedIndexChanged;
                    //cboTipDocumento.SelectedValue = frmbuscarcli.pnTipoDocumento;
                    //cboTipDocumento.SelectedIndexChanged += cboTipDocumento_SelectedIndexChanged;

                    this.conAutDatosBase1.limpiarContenido();
                    txtCodCli.Enabled = false;
                    if (nidTipoPersona == 2 || nidTipoPersona == 3)// PERSONA JURIDICO
                    {
                        //CARGAR DATOS DE REPRESETANTE
                        this.limpiarControles();
                        MessageBox.Show("Autorización de tratamiento de datos no aplica para persona jurídica.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                else //CUANDO NO SELECCIONA NADA, CANCELA O CIERRA
                {
                    txtCodInst.Text = string.Empty;
                    txtCodAge.Text = string.Empty;
                    txtCodCli.Text = string.Empty;
                    txtNroDoc.Text = string.Empty;
                    txtNombre.Text = string.Empty;
                    txtTelefono.Text = string.Empty;
                    txtDireccion.Text = string.Empty;
                    nidTipoPersona = 1;
                    nidTipoDocumento = 1; 
                    txtCodCli.Enabled = true;
                    txtCodCli.Focus();
                    this.conAutDatosBase1.limpiarContenido();
                    this.btnEditar1.Enabled = false;
                    this.btnImprimir1.Enabled = false;

                }

                idCli = string.IsNullOrEmpty(txtCodCli.Text.Trim()) ? 0 : Convert.ToInt32(txtCodCli.Text);
                if ((nidTipoDocumento == 1 && txtNroDoc.Text.Trim().Length == 8) || nidTipoDocumento == 2 || nidTipoDocumento == 3)
                {
                    bool resultad = await this.conAutDatosBase1.BuscarAutTratamientoDatos(nidTipoDocumento,txtNroDoc.Text.Trim(), sender,  e);
                    if (this.conAutDatosBase1.dataMaestro!=null)
                    {
                        if (this.conAutDatosBase1.dataMaestro.detalleAutorizacion.Count(x => x.idTipoAutorizacion == 1 && x.lIndicadorConcentimiento == true) >= 1)
                        {
                            this.btnEditar1.Enabled = true;
                        }
                    }
                    
                    this.BuscarHistoricoAutTratamientoDatos(nidTipoDocumento,txtNroDoc.Text.Trim());
                }
            }
            else
            {
                MessageBox.Show("Servicio de autorización de uso de datos no habilitado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public void limpiarControles()
        {
            txtCodInst.Clear();
            txtCodAge.Clear();
            txtCodCli.Clear();
            txtNroDoc.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtCodInst.Clear();
            txtTelefono.Clear();
            nidTipoPersona = 0;

            idCli = 0;
            txtCodCli.Enabled = true;
            txtCodCli.Focus();
            pCodCliente = string.Empty;
        }

        public void formatoHistorico()
        {
            this.idAutTraDatosBtn.Text = "Ver documento";
        }
        public void activarcontroles(bool lActivar)
        {
            txtNroDoc.Enabled = lActivar;
            txtNombre.Enabled = lActivar;
            txtDireccion.Enabled = lActivar;
            txtTelefono.Enabled = lActivar;
            cboTipDocumento.Enabled = lActivar;
        } 
        private async void BuscarHistoricoAutTratamientoDatos(int nidTipoDocumento, string cNroDoc)
        {

            string Uri = clsVarApl.dicVarGen["CRUTAAUTUSODATOS"] + "HistoricoAutTraDatos?cNroDoc=" + cNroDoc +  "&idTipoDoc=" + nidTipoDocumento.ToString();
            //Creamos el listado de Posts a llenar
            FiltroReporteAutorizacion dataFiltro = new FiltroReporteAutorizacion();
            //Instanciamos un objeto Reply
            clsApiRespuesta oRespuesta = new clsApiRespuesta();
            //poblamos el objeto con el método generic Execute
            oRespuesta = await clsApiConsumer.Execute<RespLisAutorizacionTraDatosDTO>(Uri, methodHttp.GET, dataFiltro);
            //Poblamos el datagridview
            RespLisAutorizacionTraDatosDTO respuesta = (RespLisAutorizacionTraDatosDTO)oRespuesta.Data;

            //Mostramos el statuscode devuelto, podemos añadirle lógica de validación
            if (oRespuesta.StatusCode == "OK")
            {
                if (respuesta != null)
                {
                    this.lstHistoricoData.Clear();
                    foreach (var item in respuesta.LisAutorizacion)
                    { 
                        item.cVerDocumento = "Ver Documento";
                        lstHistoricoData.Add(item);
                    }
                     this.formatoHistorico();
                }
            }
            else
            {
                MessageBox.Show("Error al buscar los datos históricos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private async void BuscarArchivoAutTratamientoDatos(string cNroDoc, int idArchivo)
        {
            if (this.cprogressbar2.Visible)
            {
                return;
            }
            this.cprogressbar2.Visible = true;

            string Uri = clsVarApl.dicVarGen["CRUTAAUTUSODATOS"] + "DocumentoAutTraDatos?idDocumento=" + idArchivo;
            //Creamos el listado de Posts a llenar
            FiltroReporteAutorizacion dataFiltro = new FiltroReporteAutorizacion();
            //Instanciamos un objeto Reply
            clsApiRespuesta oRespuesta = new clsApiRespuesta();
            //poblamos el objeto con el método generic Execute
            oRespuesta = await clsApiConsumer.Execute<RespLisAutorizacionTraDatosDTO>(Uri, methodHttp.GET, dataFiltro);
            //Poblamos el datagridview
            RespLisAutorizacionTraDatosDTO respuesta = (RespLisAutorizacionTraDatosDTO)oRespuesta.Data;

            //Mostramos el statuscode devuelto, podemos añadirle lógica de validación
            if (oRespuesta.StatusCode == "OK")
            {
                this.cprogressbar2.Visible = false;

                if (respuesta != null)
                {
                    if (respuesta.DocumentoAutorizacionRpt.lResultado)
                    {
                        frmVerPdf frmdoc = new frmVerPdf();
                        frmdoc.cArchivo = respuesta.DocumentoAutorizacionRpt.cNombre;
                        frmdoc.bArchivoBinary = clsAuditoria.String2ByteArray(respuesta.DocumentoAutorizacionRpt.cArchivo);

                        frmdoc.ShowDialog();
                    } 
                }
            }
            else
            {
                this.cprogressbar2.Visible = false;
                MessageBox.Show("Error al descargar el documento.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void habilitarBotones(bool lActivo)
        {
            this.btnNuevo1.Enabled = lActivo; 
            this.btnGrabar1.Enabled = !lActivo;
            this.btnCancelar1.Enabled = !lActivo;
        } 
     
        #endregion

        private void tbcBase1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (conAutDatosBase1.dataMaestro.idMaestroAutorizacion>0)
            {
                frmVerPdf frmdoc = new frmVerPdf();
                frmdoc.cArchivo = conAutDatosBase1.dataMaestro.cArchivo;
                frmdoc.bArchivoBinary = clsAuditoria.String2ByteArray(conAutDatosBase1.dataMaestro.cArchivoBinary);
                frmdoc.ShowDialog();
            }
           
        }

        private void conAutDatosBase1_ClicCargarDatos(object sender, EventArgs e)
        {
            if (conAutDatosBase1.dataMaestro != null)
            {
                if (conAutDatosBase1.dataMaestro.idMaestroAutorizacion > 0)
                {
                    btnNuevo1.Enabled = false;
                    btnEditar1.Enabled = false;
                    btnImprimir1.Enabled = true;
                    btnGrabar1.Enabled = false;
                    btnCancelar1.Enabled = false;
                    if (clsVarApl.dicVarGen["nPerfilEdiTrabAutTraDat"] == clsVarGlobal.PerfilUsu.idPerfil)
                    {
                        btnEditar1.Enabled = true;
                    }
                }
                else
                {
                    btnNuevo1.Enabled = true;
                    btnEditar1.Enabled = false;
                    btnImprimir1.Enabled = false;
                    btnGrabar1.Enabled = false;
                    btnCancelar1.Enabled = false; 
                }
            }
            else
            {
                btnNuevo1.Enabled = true;
                btnEditar1.Enabled = false;
                btnImprimir1.Enabled = false;
                btnGrabar1.Enabled = false;
                btnCancelar1.Enabled = false;
             }
            
        }

        private void lblBase3_Click(object sender, EventArgs e)
        {

        }

        private void cboTipDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipDocumento.SelectedValue)==1)
            {
                txtNroDoc.MaxLength = 8;
                txtNroDoc.Clear();
            }
            else if(Convert.ToInt32(cboTipDocumento.SelectedValue) == 2 || Convert.ToInt32(cboTipDocumento.SelectedValue) == 3)
            {
                txtNroDoc.MaxLength = 20;
                txtNroDoc.Clear();
            }
            else
            {
                txtNroDoc.MaxLength = 12;
                txtNroDoc.Clear();
            }
        }
    }
}
