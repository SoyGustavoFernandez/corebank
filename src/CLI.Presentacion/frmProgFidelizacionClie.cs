using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GEN.ControlesBase;
using RSG.CapaNegocio;
using CLI.CapaNegocio;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.BotonesBase;

namespace CLI.Presentacion
{
    public partial class frmProgFidelizacionClie : frmBase
    {

        #region Variable Globales

        clsCNVisita cnVisita;
        clsCNCliente cnCliente;
        clsCNProgFidelizacionClie cnProgFidelizacionClie;
        clsCNCliReferidos cnCliReferidos;
        clsCNCredito cnCredito;

        DataTable dtListaReferidos;

        int idCli = 0;
        int idAgencia = 0;
        int idUsuAsesor = 0;
        int idEstado = 0;
        int idEstadoNue = 0;
        string cCalificacion = "";        
        
        #endregion


        #region Eventos

        public frmProgFidelizacionClie()
        {
            InitializeComponent();
            btnCancelar.Enabled = true;
        }
        private void frmProgFidelizacionClie_Load(object sender, EventArgs e)
        {           
            conBusCliente.btnBusCliente.Enabled = true;
            conBusCliente.txtCodCli.Enabled = true;                     
        }

        private void conBusCliente_ClicBuscar(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Grabar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Cliente con producto vigente
            if (!ProductoVigente())
            {
                MessageBox.Show("El cliente no puede Agregar referidos, porque no cuenta con productos vigentes.", "Programa de Fidelización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if (ExisteColaborador())
            {
                MessageBox.Show("El cliente no puede Agregar referidos, porque es colaborador de la entidad.", "Mantenimiento de referidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmReferidosClie frm = new frmReferidosClie(idCli, 0, idAgencia, idUsuAsesor, 1);
            frm.ShowDialog();
            //Lista referidos del cliente
            ListaReferidos(idCli);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.dtgReferidos.Rows.Count <= 0)
            {
                MessageBox.Show("No hay referidos en la lista.", "Mantenimiento de referidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.dtgReferidos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un referido de la lista.", "Mantenimiento de referidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Cliente con producto vigente.
            if (!ProductoVigente())
            {
                MessageBox.Show("El cliente no puede Editar referidos, porque no cuenta con productos vigentes.", "Programa de Fidelización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            //Existe como colaborador de la entidad.
            if (ExisteColaborador())
            {
                MessageBox.Show("El cliente no puede Editar referidos, porque es colaborador de la entidad.", "Mantenimiento de referidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }            

            int idCliRef = Convert.ToInt32(this.dtgReferidos.CurrentRow.Cells["idCliRef"].Value);

            if (idCliRef != 0)
            {
                frmReferidosClie frm = new frmReferidosClie(idCli, idCliRef, idAgencia, idUsuAsesor, 2);
                frm.ShowDialog();
                //Lista referidos del cliente.
                ListaReferidos(idCli);
            }

        }        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            HabilitarControles(false);
            btnGrabar.Enabled = false;
        }

        #endregion        
        

        #region Metodos

        public void Buscar() {
            cnVisita = new clsCNVisita();
            cnCliente = new clsCNCliente();
            cnProgFidelizacionClie = new clsCNProgFidelizacionClie();

            if (conBusCliente.txtCodCli.Text.Trim() == "")
            {
                LimpiarControles();
                return;
            }

            idCli = Convert.ToInt32(conBusCliente.txtCodCli.Text);
            
            //Agecia.
            ObtenerAgencia(idCli);
            //Asesor.
            ObtenerAsesor(idCli);
            //Calificación.
            ObtenerCalificacion(idCli);
            //Programa de Fidelización.
            ObtenerProgramaFidelizacion(idCli);
            //Lista referidos del cliente.
            ListaReferidos(idCli);
            
        }

        public void LimpiarControles()
        {
            conBusCliente.txtCodAge.Clear();
            conBusCliente.txtCodInst.Clear();
            conBusCliente.txtCodCli.Clear();
            conBusCliente.txtNroDoc.Clear();
            conBusCliente.txtNombre.Clear();
            conBusCliente.txtDireccion.Clear();
            conBusCliente.txtCodCli.Enabled = true;
            conBusCliente.btnBusCliente.Enabled = true;
            conBusCliente.txtCodCli.Focus();

            idCli = 0;
            idAgencia = 0;
            idUsuAsesor = 0;            
            idEstado = 0;
            idEstadoNue = 0;
            cCalificacion = "";

            txtAgencia.Clear();
            txtAsesor.Clear();
            txtEstado.Clear();            
            txtCalificacion.Clear();

            dtgReferidos.DataSource = "";
        }

        public void HabilitarControles(bool lEstado) {            
            btnEditar.Enabled = lEstado;
            btnAgregar.Enabled = lEstado;
            
        }

        public void ObtenerAgencia(int idCli) {            
            DataTable dtAgencia = cnVisita.CNClienteAgencia(idCli);
            txtAgencia.Text = (dtAgencia.Rows.Count != 0) ? dtAgencia.Rows[0]["cNomCorto"].ToString() : "";
            idAgencia = (dtAgencia.Rows.Count != 0) ? Convert.ToInt32(dtAgencia.Rows[0]["idAgencia"]) : 0;        
        }

        public void ObtenerAsesor(int idCli) {
            DataTable dtAsesor = cnCliente.CNObtenerAsesorCliente(idCli);
            txtAsesor.Text = (dtAsesor.Rows.Count != 0) ? dtAsesor.Rows[0]["cNomAsesor"].ToString() : "";
            idUsuAsesor = (dtAsesor.Rows.Count != 0) ? Convert.ToInt32(dtAsesor.Rows[0]["idAsesor"]) : 0;
        }

        public void ObtenerCalificacion(int idCli)
        {
            cCalificacion = cnCliente.CNObtenerCalificacionCliente(idCli);
            txtCalificacion.Text = cCalificacion;
        }

        public void ObtenerProgramaFidelizacion(int idCli) 
        {
            DataTable dtProgFidelizacionClie = cnProgFidelizacionClie.CNObtenerProgFidelizacionClie(idCli);
            txtEstado.Text = (dtProgFidelizacionClie.Rows.Count != 0) ? dtProgFidelizacionClie.Rows[0]["cEstado"].ToString() : "NO REGISTRADO";
            idEstado = (dtProgFidelizacionClie.Rows.Count != 0) ? Convert.ToInt32(dtProgFidelizacionClie.Rows[0]["idEstado"]) : 0;            
            
            if (cCalificacion.ToUpper() != "CALIFICA")
            {
                MessageBox.Show($" " + MsgNoCalifica(), "Cliente no califica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                                    
            }          
            
            if (idEstado == 0)
            {                                
                btnGrabar.Enabled = true;
                HabilitarControles(true);
            }
            else
            {                                
                btnGrabar.Enabled = false;
                HabilitarControles(true);
            }
        }        

        public string MsgNoCalifica() 
        {
            //Valida si existe la variable.
            bool lExiste = clsVarApl.dicVarGen.ContainsKey("cMsgNoCalifica");
            if (lExiste)
            {
                //Obtiene el mensaje a mostrar cuando no califica.
                return clsVarApl.dicVarGen["cMsgNoCalifica"];                
            }
            else 
            {
                return "";
            }
        }        

        public void Grabar()
        {            
            bool lValidar = Validacion();

            if (!lValidar) 
            {
                return;
            }

            idEstadoNue = 2; //Registrado            

            try
            {
                cnProgFidelizacionClie = new clsCNProgFidelizacionClie();
                DataTable result = cnProgFidelizacionClie.CNRegistrarProgFidelizacionClie(idCli, idEstadoNue, clsVarGlobal.User.idUsuario);

                if (result == null)
                {
                    MessageBox.Show("Error al intentar registrar al cliente.", "Programa de Fidelización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Convert.ToInt32(result.Rows[0]["lResult"]) == 1)
                {
                    cnProgFidelizacionClie.CNRegistrarLogEstClieProgFid(idCli, idEstadoNue, clsVarGlobal.User.idUsuario);

                    ObtenerProgramaFidelizacion(idCli);
                    MessageBox.Show(result.Rows[0]["cMsg"].ToString(), "Programa de Fidelización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    btnGrabar.Enabled = true;
                    HabilitarControles(false);                        
                    MessageBox.Show(result.Rows[0]["cMsg"].ToString(), "Programa de Fidelización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch 
            {
                MessageBox.Show("Error al intentar registrar al cliente.", "Programa de Fidelización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        public bool Validacion()
        {
            bool lRespuesta = false;            

            if (idCli == 0) 
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Programa de Fidelización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return lRespuesta;
            }

            if (idEstado != 0)
            {
                var estProgFid = cnProgFidelizacionClie.CNObtEstProgFidelizacion();

                MessageBox.Show("El cliente ya se encuentra " + estProgFid[idEstado] + ".", "Programa de Fidelización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return lRespuesta;
            }     
            
            if (!ProductoVigente())
            {
                MessageBox.Show("El cliente no puede ser parte del programa de fidelización,\r\nporque no cuenta con productos vigentes.", "Programa de Fidelización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return lRespuesta;
            }

            if (cCalificacion.ToUpper() != "CALIFICA")
            {
                MessageBox.Show(MsgNoCalifica(), "Cliente no califica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return lRespuesta;
            }          

            return true;
        }

        public void ListaReferidos(int idCli) {
            cnCliReferidos = new clsCNCliReferidos();
            dtListaReferidos = cnCliReferidos.CNListaReferidoClie(idCli);
            foreach (DataColumn column in dtListaReferidos.Columns)
            {
                column.ReadOnly = false;
            }            
            dtgReferidos.DataSource = dtListaReferidos;

            FormatoGrid();
        }

        private void FormatoGrid()
        {
            dtgReferidos.Columns["idCli"].Visible = false;
            dtgReferidos.Columns["idCliRef"].Visible = false;            

            dtgReferidos.Columns["cNomCorto"].HeaderText = "TIPO DE DOCUMENTO";
            dtgReferidos.Columns["cNomCorto"].Width = 80;
            dtgReferidos.Columns["cNomCorto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgReferidos.Columns["cDocumentoID"].HeaderText = "NRO. DE DOCUMENTO";
            dtgReferidos.Columns["cDocumentoID"].Width = 80;
            dtgReferidos.Columns["cDocumentoID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgReferidos.Columns["cNombre"].HeaderText = "NOMBRE DEL REFERIDO";
            dtgReferidos.Columns["cNombre"].Width = 200;
            dtgReferidos.Columns["cNombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgReferidos.Columns["cNumeroTelefono2"].HeaderText = "CELULAR";
            dtgReferidos.Columns["cNumeroTelefono2"].Width = 70;
            dtgReferidos.Columns["cNumeroTelefono2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgReferidos.Columns["cCorreoCli"].HeaderText = "CORREO";
            dtgReferidos.Columns["cCorreoCli"].Width = 100;
            dtgReferidos.Columns["cCorreoCli"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgReferidos.Columns["cWinUser"].HeaderText = "ASESOR";
            dtgReferidos.Columns["cWinUser"].Width = 100;
            dtgReferidos.Columns["cWinUser"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            
        }        

        public bool ProductoVigente() 
        {
            cnCliente = new clsCNCliente();
            DataTable dtCliente = cnCliente.CNListaCtaActivaCliente(idCli);
            if (dtCliente == null) { return false; }
            return (dtCliente.Rows.Count > 0) ? true : false;            
        }        

        public bool ExisteColaborador()         
        {
            DataTable result = cnProgFidelizacionClie.CNObtenerDatosColaborador(idCli,"");
            if (result == null) { return false; }
            return (result.Rows.Count > 0) ? true : false;                        
        }
        
        #endregion



    }
}
