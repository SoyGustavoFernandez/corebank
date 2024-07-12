#region Referencias
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.CapaNegocio;
#endregion



namespace GEN.ControlesBase
{
    public partial class ConBusDocumento : UserControl
    {
        #region Variables Globales
        public int idCliente { get; set; }
        public int idTipoDocumento { get; set; }
        public string cDocumentoID { get; set; }
        public string cNombreCompleto { get; set; }
        public string cDireccion { get; set; }
        public bool lEsCliente { get; set; }
        public int idTipoPersona { get; set; }

        public int idClasifInterna { get; set; }
        public string cClasifInterna { get; set; }
        
        public event EventHandler ClickBuscar;

        #endregion

        #region Constructores
        public ConBusDocumento()
        {
            InitializeComponent();

            cboTipoDocumento.cargarTipDocEspecificos("1,4");
        }

        #endregion

        #region Eventos
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            int nCifras = txtDocumentoID.TextLength;


            if (nCifras == 0 || cboTipoDocumento.SelectedIndex == -1)
            {
                string cMensaje = (nCifras == 0) ? "Ingrese el Número de Documento" : "Seleccione el Tipo de Documento: DNI o RUC";
                MessageBox.Show(cMensaje, "Buscar Persona", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.txtDocumentoID.Focus();
                txtCodigoInstitucion.Text = String.Empty;
                txtCodigoAgencia.Text = String.Empty;
                txtCodigoCliente.Text = String.Empty;
                txtDocumentoID.Text = String.Empty;
                txtNombreCompleto.Text = String.Empty;
                txtDireccion.Text = String.Empty;
                txtDocumentoID.Enabled = true;
                txtDocumentoID.Focus();
                cboTipoDocumento.Enabled = true;

                this.idCliente = 0;
                this.cDocumentoID = String.Empty;
                this.cNombreCompleto = String.Empty;
                this.cDireccion = String.Empty;
                this.idTipoDocumento = 0;
                this.idTipoPersona = 0;
                this.idClasifInterna = 0;
                this.cClasifInterna = String.Empty;
                this.lEsCliente = false;
            }
            else
            {
                idTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                CargarDatosCliente(Convert.ToString(txtDocumentoID.Text), idTipoDocumento);
            }

            if (ClickBuscar != null)
                ClickBuscar(sender, e);
        }

        private void ConBusDocumento_Load(object sender, EventArgs e)
        {
            txtDocumentoID.Focus();
        }

        private void txtDocumentoID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                e.Handled = false;
            }
            else
            {
                var fff = (from L in this.Text.ToString()
                           where L.ToString() == "."
                           select L).Count();

                if (fff > 0)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    if (e.KeyChar == 13)
                    {
                        Int32 nCifras = txtDocumentoID.TextLength;

                        if (nCifras == 0 || cboTipoDocumento.SelectedIndex == -1)
                        {
                            string cMensaje = (nCifras == 0) ? "Ingrese el Número de Documento" : "Seleccione el Tipo de Documento: DNI o RUC";
                            MessageBox.Show(cMensaje, "Buscar Persona", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.txtDocumentoID.Focus();
                            txtCodigoInstitucion.Text = String.Empty;
                            txtCodigoAgencia.Text = String.Empty;
                            txtCodigoCliente.Text = String.Empty;
                            txtDocumentoID.Text = String.Empty;
                            txtNombreCompleto.Text = String.Empty;
                            txtDireccion.Text = String.Empty;
                            txtDocumentoID.Enabled = true;
                            txtDocumentoID.Focus();

                            this.idCliente = 0;
                            this.cDocumentoID = String.Empty;
                            this.cNombreCompleto = String.Empty;
                            this.cDireccion = String.Empty;
                            this.idTipoDocumento = 0;
                            this.idTipoPersona = 0;
                            this.idClasifInterna = 0;
                            this.cClasifInterna = String.Empty;
                            this.lEsCliente = false;
                        }
                        else
                        {
                            idTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                            CargarDatosCliente(Convert.ToString(txtDocumentoID.Text), idTipoDocumento);
                        }

                        if (ClickBuscar != null)
                            ClickBuscar(sender, e);

                    }
                }
            }
        }
        #endregion

        #region Metodos
        public void CargarDatosCliente(string cDocumentoID, int idTipoDocumento)
        {
            clsCNBuscarCli objCNBuscarCli = new clsCNBuscarCli();
            DataTable dtCliente = objCNBuscarCli.CNBuscarClienteXDocumentoID(cDocumentoID, idTipoDocumento);

            if (dtCliente.Rows.Count > 0)
            {
                txtCodigoInstitucion.Text = Convert.ToString(dtCliente.Rows[0]["cCodCliente"]).Substring(0, 3);
                txtCodigoAgencia.Text = Convert.ToString(dtCliente.Rows[0]["cCodCliente"]).Substring(3, 3);
                txtCodigoCliente.Text = Convert.ToString(dtCliente.Rows[0]["cCodCliente"]).Substring(6);

                txtDocumentoID.Text = Convert.ToString(dtCliente.Rows[0]["cDocumentoID"]);
                txtNombreCompleto.Text = Convert.ToString(dtCliente.Rows[0]["cNombre"]);
                txtDireccion.Text = Convert.ToString(dtCliente.Rows[0]["cDireccion"]);
                txtDocumentoID.Enabled = false;
                cboTipoDocumento.SelectedValue = Convert.ToString(dtCliente.Rows[0]["idTipoDocumento"]);
                cboTipoDocumento.Enabled = false;

                this.idCliente = Convert.ToInt32(dtCliente.Rows[0]["idCli"]);
                this.cDocumentoID = Convert.ToString(dtCliente.Rows[0]["cDocumentoID"]);
                this.idTipoDocumento = Convert.ToInt32(dtCliente.Rows[0]["idTipoDocumento"]);
                this.cNombreCompleto = Convert.ToString(dtCliente.Rows[0]["cNombre"]);
                this.cDireccion = Convert.ToString(dtCliente.Rows[0]["cDireccion"]);
                this.idTipoPersona = Convert.ToInt32(dtCliente.Rows[0]["idTipoPersona"]);
                this.idClasifInterna = Convert.ToInt32(dtCliente.Rows[0]["idClasifInterna"]); ;
                this.cClasifInterna = Convert.ToString(dtCliente.Rows[0]["cClasifInterna"]);
                this.lEsCliente = true;
            }
            else if (dtCliente.Rows.Count == 0)
            {
                if(ClickBuscar == null)
                {
                    MessageBox.Show("No se encontró ningún Registro", "Buscar Persona", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodigoInstitucion.Text = String.Empty;
                    txtCodigoAgencia.Text = String.Empty;
                    txtCodigoCliente.Text = String.Empty;

                    txtDocumentoID.Text = String.Empty;
                    txtNombreCompleto.Text = String.Empty;
                    txtDireccion.Text = String.Empty;
                    txtDocumentoID.Enabled = true;
                    txtDocumentoID.Focus();
                    cboTipoDocumento.SelectedIndex = -1;
                    cboTipoDocumento.Enabled = true;
                    this.idCliente = 0;
                    this.cDocumentoID = String.Empty;
                    this.cNombreCompleto = String.Empty;
                    this.cDireccion = String.Empty;
                    this.idTipoDocumento = 0;
                    this.idTipoPersona = 0;
                    lEsCliente = false;
                }
                else
                {
                    lEsCliente = false;
                    this.idCliente = 0;
                    this.cDocumentoID = txtDocumentoID.Text;
                    this.cNombreCompleto = String.Empty;
                    this.cDireccion = String.Empty;
                    this.idTipoDocumento = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                    this.idTipoPersona = (idTipoDocumento == 1) ? 1 : 2;
                    MostrarDatosNoCliente();
                }
                
            }
        }

        public void MostrarDatosNoCliente()
        {
            this.txtDocumentoID.Text = (!String.IsNullOrWhiteSpace(cDocumentoID)) ? cDocumentoID : String.Empty ;
            this.cboTipoDocumento.Enabled = (!String.IsNullOrWhiteSpace(cDocumentoID)) ? true : false;
            this.txtNombreCompleto.Text = (!String.IsNullOrWhiteSpace(cNombreCompleto)) ? cNombreCompleto : String.Empty; ;
            this.txtDireccion.Text = (!String.IsNullOrWhiteSpace(cDireccion)) ? cDireccion : String.Empty;
            this.txtDocumentoID.Enabled = false;
            this.txtNombreCompleto.Enabled = false;
            this.txtDireccion.Enabled = false;
            lblNoEscliente.Visible = !lEsCliente;
        }

        public void limpiarControles()
        {
            txtCodigoInstitucion.Clear();
            txtCodigoAgencia.Clear();
            txtCodigoCliente.Clear();
            txtDocumentoID.Clear();
            txtNombreCompleto.Clear();
            txtDireccion.Clear();
            txtCodigoInstitucion.Clear();
            this.idCliente = 0;
            this.cDocumentoID = String.Empty;
            this.cNombreCompleto = String.Empty;
            this.cDireccion = String.Empty;
            this.idTipoDocumento = 0;
            this.idTipoPersona = 0;
            this.lEsCliente = false;
            lblNoEscliente.Visible = false;
            txtDocumentoID.Enabled = true;
            txtDocumentoID.Focus();
            btnBuscarCliente.Enabled = true;
            cboTipoDocumento.SelectedIndex = -1;
            cboTipoDocumento.Enabled = true;
            
        }
        #endregion
    }
}
