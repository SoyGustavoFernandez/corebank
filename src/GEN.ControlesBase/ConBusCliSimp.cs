#region Referencias
#endregion
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

namespace GEN.ControlesBase
{
    public partial class ConBusCliSimp : UserControl
    {
        #region Variables Globales
        public event EventHandler EventoPostBuscar;
        public event EventHandler EventoPostBuscarCuentas;
        public int idTipoPersona, idClasifInterna;
        public int idTipoDocumento;
        public int idTipoCliente;
        public string cClasifInterna;
        public bool lIndDatosBasicos;
        public int idAgencia = 0;
        public int nAniosActEco = 0;

        public clsCliente objCliente = new clsCliente();

        public int idCli { get; set; }

        [DefaultValue(true)]
        public bool lMostrarDireccion
        {
            get
            {
                return this.plDireccion.Visible;
            }
            set
            {
                this.plDireccion.Visible = value;
            }
        }

        [DefaultValue(true)]
        public bool lMostrarNombre
        {
            get
            {
                return this.plNombre.Visible;
            }
            set
            {
                this.plNombre.Visible = value;
            }
        }
        #endregion

        #region Constructor
        public ConBusCliSimp()
        {
            InitializeComponent();
            lMostrarDireccion = true;
        }

        #endregion

        #region Eventos
        private void btnBusCliente_Click(object sender, EventArgs e)
        {
            buscar();

            if (EventoPostBuscar != null)
                EventoPostBuscar(sender, e);

            if (EventoPostBuscarCuentas != null)
                EventoPostBuscarCuentas(sender, e);
        }

        private void ConBusCliSimp_Load(object sender, EventArgs e)
        {
            txtCodCli.Focus();
        }

        private void txtCodCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Int32 nCifras = txtCodCli.TextLength;

                if (nCifras == 0)
                {
                    MessageBox.Show("Valor de Búsqueda Incorrecto", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limpiarControles();
                }
                else
                {
                    if (Convert.ToInt32(this.txtCodCli.Text) <= 0)
                    {
                        MessageBox.Show("Ingrese un Código de Cliente Válido", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        limpiarControles();
                        return;
                    }

                    cargarDatosCli(Convert.ToInt32(txtCodCli.Text));
                }

                if (EventoPostBuscar != null)
                    EventoPostBuscar(sender, e);

                if (EventoPostBuscarCuentas != null)
                    EventoPostBuscarCuentas(sender, e);
            }
        }

        #endregion

        #region Metodos

        public void buscar()
        {
            clsCNBuscarCli objCNBuscarCli = new clsCNBuscarCli();
            FrmBusCli frmbuscarcli = new FrmBusCli();
            frmbuscarcli.ShowDialog();

            if (!String.IsNullOrWhiteSpace(frmbuscarcli.pcCodCliLargo))
            {
                

                int idCliTemp = Convert.ToInt32(frmbuscarcli.pcCodCli);
                int idClasifInternaTemp = Convert.ToInt32(frmbuscarcli.pnIdClasifInt);

                DataTable Cliente1 = objCNBuscarCli.CNCambiarClasificacionInterna(idCliTemp, idClasifInternaTemp);
             
                lIndDatosBasicos = frmbuscarcli.pIndicaDatoBasico;
                txtCodInst.Text = frmbuscarcli.pcCodCliLargo.Substring(0, 3);
                txtCodAge.Text = frmbuscarcli.pcCodCliLargo.Substring(3, 3);
                txtCodCli.Text = frmbuscarcli.pcCodCliLargo.Substring(6);
                txtNroDoc.Text = frmbuscarcli.pcNroDoc;
                txtNombre.Text = frmbuscarcli.pcNomCli;
                txtDireccion.Text = frmbuscarcli.pcDireccion;
                idTipoPersona = frmbuscarcli.pnTipoPersona;
                idTipoDocumento = frmbuscarcli.pnTipoDocumento;

                if(frmbuscarcli.pnIdClasifInt == 0)
                {
                    idClasifInterna = Convert.ToInt32(Cliente1.Rows[0]["idClasifInterna"]);
                    cClasifInterna = Convert.ToString(Cliente1.Rows[0]["cClasifInterna"]);
                    lblClasificacionCliente.Text = Convert.ToString(Cliente1.Rows[0]["cClasifInterna"]);
                }
                else
                {
                    idClasifInterna = frmbuscarcli.pnIdClasifInt;
                    cClasifInterna = frmbuscarcli.pcClasifInt;
                    lblClasificacionCliente.Text = frmbuscarcli.pcClasifInt;
                }

               VerificarClasificacionInternaxOferta(idCli);

                idTipoCliente = frmbuscarcli.idTipoCliente;
                
                this.nAniosActEco = frmbuscarcli.nAniosActEco;

                
                txtCodCli.Enabled = false;
            }
            else
            {
                limpiarControles();
            }

            idCli = String.IsNullOrWhiteSpace(txtCodCli.Text) ? 0 : Convert.ToInt32(txtCodCli.Text);

            if (idCli != 0)
            {
                this.objCliente.idCli = this.idCli;
                this.objCliente.idTipoDocumento = this.idTipoDocumento;
                this.objCliente.IdTipoPersona = this.idTipoPersona;
                this.objCliente.lIndDatosBasic = this.lIndDatosBasicos;
                this.objCliente.idClasifInterna = this.idClasifInterna;
                this.objCliente.idActivEcoInt = frmbuscarcli.idActividadInterna;
                this.objCliente.nAniosActEco = this.nAniosActEco;
                this.objCliente.cDocumentoID = this.txtNroDoc.Text;
                this.objCliente.idTipoCliente = this.idTipoCliente;
            }
        }

        public void cargarDatosCli(int idCli)
        {
            clsCNBuscarCli objCNBuscarCli = new clsCNBuscarCli();
            DataTable tablaCli = objCNBuscarCli.ListarclixIdCli(idCli);

            if (tablaCli.Rows.Count > 0)
            {
                int idCliTemp = Convert.ToInt32(tablaCli.Rows[0]["idCli"]);
                int idClasifInternaTemp = Convert.ToInt32(tablaCli.Rows[0]["idClasifInterna"]);

                DataTable Cliente1 = objCNBuscarCli.CNCambiarClasificacionInterna(idCliTemp, idClasifInternaTemp);

                txtCodInst.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(0, 3);
                txtCodAge.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(3, 3);
                txtCodCli.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(6);
                txtNroDoc.Text = Convert.ToString(tablaCli.Rows[0]["cDocumentoID"]);
                idTipoDocumento = Convert.ToInt32(tablaCli.Rows[0]["idTipoDocumento"]);
                txtNombre.Text = Convert.ToString(tablaCli.Rows[0]["cNombre"]);
                txtDireccion.Text = Convert.ToString(tablaCli.Rows[0]["cDireccion"]);
                idTipoPersona = Convert.ToInt32(tablaCli.Rows[0]["IdTipoPersona"]);
                idTipoCliente = Convert.ToInt32(tablaCli.Rows[0]["idTipoCliente"]);
                lIndDatosBasicos = Convert.ToBoolean(tablaCli.Rows[0]["lIndDatosBasic"]);

                if(idClasifInternaTemp == 0)
                {
                    idClasifInterna = Convert.ToInt32(Cliente1.Rows[0]["idClasifInterna"]);
                    cClasifInterna = Convert.ToString(Cliente1.Rows[0]["cClasifInterna"]);
                    lblClasificacionCliente.Text = Convert.ToString(Cliente1.Rows[0]["cClasifInterna"]);
                }
                else
                {
                    idClasifInterna = Convert.ToInt32(tablaCli.Rows[0]["idClasifInterna"]);
                    cClasifInterna = Convert.ToString(tablaCli.Rows[0]["cClasifInterna"]);
                    lblClasificacionCliente.Text = Convert.ToString(tablaCli.Rows[0]["cClasifInterna"]);
                }

                VerificarClasificacionInternaxOferta(idCli);

                this.nAniosActEco = Convert.ToInt32(tablaCli.Rows[0]["nAniosActEco"]);
                txtCodCli.Enabled = false;
                this.idCli = txtCodCli.Text == "" ? 0 : Convert.ToInt32(txtCodCli.Text);

                this.objCliente.idCli = this.idCli;
                this.objCliente.cDocumentoID = this.txtNroDoc.Text;
                this.objCliente.idTipoDocumento = this.idTipoDocumento;
                this.objCliente.IdTipoPersona = this.idTipoPersona;
                this.objCliente.lIndDatosBasic = this.lIndDatosBasicos;
                this.objCliente.idClasifInterna = this.idClasifInterna;
                this.objCliente.idActivEcoInt = Convert.ToInt32(tablaCli.Rows[0]["idActividadInterna"]);
                this.objCliente.nAniosActEco = this.nAniosActEco;
                this.objCliente.idTipoCliente = this.idTipoCliente;
            }
            else if (tablaCli.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró ningún Registro", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpiarControles();
            }
        }
        private void VerificarClasificacionInternaxOferta(int idCli)
        {
            clsCNBuscarCli ClasifInterna = new clsCNBuscarCli();
            DataTable dtClasficacionInterna = ClasifInterna.CNVerificaClasificacionInternaxOferta(idCli);

            if (dtClasficacionInterna.Rows.Count != 0)
            {
                if (Convert.ToInt32(dtClasficacionInterna.Rows[0]["nResultado"]) == 0)
                {
                    MessageBox.Show(Convert.ToString(dtClasficacionInterna.Rows[0]["cMensaje"].ToString()), "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (Convert.ToInt32(dtClasficacionInterna.Rows[0]["idClasifInterna"]) != 0 && !dtClasficacionInterna.Rows[0]["cClasifInterna"].ToString().Equals("ninguna"))
                    {
                        idClasifInterna = Convert.ToInt32(dtClasficacionInterna.Rows[0]["idClasifInterna"].ToString());
                        cClasifInterna = Convert.ToString(dtClasficacionInterna.Rows[0]["cClasifInterna"].ToString());
                        lblClasificacionCliente.Text = cClasifInterna;
                    }
                }
            }

        }
        public void limpiarControles()
        {
            lIndDatosBasicos = false;
            txtCodInst.Clear();
            txtCodAge.Clear();
            txtCodCli.Clear();
            txtNroDoc.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            idTipoPersona = 1;
            idTipoDocumento = 1;
            txtCodCli.Enabled = true;
            idClasifInterna = 0;
            cClasifInterna = String.Empty;
            lblClasificacionCliente.Text = String.Empty;
            idCli = 0;
            txtCodCli.Focus();
            objCliente = new clsCliente();
        }
        #endregion
    }
}
