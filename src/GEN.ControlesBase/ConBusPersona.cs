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
    public partial class ConBusPersona : UserControl
    {
        #region Variables Globales
        public int idCliente { get; set; }
        public int idTipoDocumento { get; set; }
        public string cDocumentoID { get; set; }
        public string cNombreCompleto { get; set; }
        public string cDireccion { get; set; }
        public bool lEsCliente { get; set; }
        
        public event EventHandler ClickBuscar;

        #endregion

        #region Constructores
        public ConBusPersona()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            int nCifras = txtDocumentoID.TextLength;

            if (nCifras == 0)
            {
                MessageBox.Show("Valor de Búsqueda Incorrecto", "Buscar Persona", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                this.lEsCliente = false;
            }
            else
            {
                CargarDatosCliente(Convert.ToString(txtDocumentoID.Text), 1);
            }

            if (ClickBuscar != null)
                ClickBuscar(sender, e);
        }

        private void ConBusPersona_Load(object sender, EventArgs e)
        {
            txtDocumentoID.Focus();
        }

        private void txtDocumentoID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Int32 nCifras = txtDocumentoID.TextLength;

                if (nCifras == 0)
                {
                    MessageBox.Show("Valor de Búsqueda Incorrecto", "Buscar Persona", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    this.lEsCliente = false;
                }
                else
                {
                    CargarDatosCliente(Convert.ToString(txtDocumentoID.Text), 1);
                }

                if (ClickBuscar != null)
                    ClickBuscar(sender, e);

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

                this.idCliente = Convert.ToInt32(dtCliente.Rows[0]["idCli"]);
                this.cDocumentoID = Convert.ToString(dtCliente.Rows[0]["cDocumentoID"]);
                this.idTipoDocumento = Convert.ToInt32(dtCliente.Rows[0]["idCli"]);
                this.cNombreCompleto = Convert.ToString(dtCliente.Rows[0]["cNombre"]);
                this.cDireccion = Convert.ToString(dtCliente.Rows[0]["cDireccion"]);
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
                    this.idCliente = 0;
                    this.cDocumentoID = String.Empty;
                    this.cNombreCompleto = String.Empty;
                    this.cDireccion = String.Empty;
                    this.idTipoDocumento = 0;
                    lEsCliente = false;
                }
                else
                {
                    lEsCliente = false;
                }
                
            }
        }

        public void MostrarDatosNoCliente()
        {
            this.txtDocumentoID.Text = (!String.IsNullOrWhiteSpace(cDocumentoID)) ? cDocumentoID : String.Empty ;
            this.txtNombreCompleto.Text = (!String.IsNullOrWhiteSpace(cNombreCompleto)) ? cNombreCompleto : String.Empty; ;
            this.txtDireccion.Text = (!String.IsNullOrWhiteSpace(cDireccion)) ? cDireccion : String.Empty;
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
            this.lEsCliente = false;
            lblNoEscliente.Visible = false;
            txtDocumentoID.Enabled = true;
            txtDocumentoID.Focus();
            btnBuscarCliente.Enabled = true;
            
        }
        #endregion
    }
}
