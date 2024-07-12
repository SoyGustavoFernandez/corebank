using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class ConBusCliRuc : UserControl
    {
        public event EventHandler ClicBuscar;
        public int nidTipoPersona, nIdClasifInterna;
        public string nidTipoDocumento, cClasifInterna;
        public bool lIndDatosBasicos;
        public int idAgencia = 0; // permite el filtrado por agencia
        public ConBusCliRuc()
        {
            InitializeComponent();
        }
        public int idCli { get; set; }
        private void btnBusCliente_Click(object sender, EventArgs e)
        {
            buscar();

            if (ClicBuscar != null)
                ClicBuscar(sender, e);
        }

        private void ConBusCli_Load(object sender, EventArgs e)
        {
            txtCodCli.Focus();
        }
        public void buscar()
        {
            FrmBusCli frmbuscarcli = new FrmBusCli();
            frmbuscarcli.ShowDialog();

            if (!string.IsNullOrEmpty(frmbuscarcli.pcCodCliLargo))
            {
                lIndDatosBasicos = frmbuscarcli.pIndicaDatoBasico;
                txtCodInst.Text = frmbuscarcli.pcCodCliLargo.Substring(0, 3);
                txtCodAge.Text = frmbuscarcli.pcCodCliLargo.Substring(3, 3);
                txtCodCli.Text = frmbuscarcli.pcCodCliLargo.Substring(6);
                txtNroDoc.Text = frmbuscarcli.pcNroDoc;
                txtNombre.Text = frmbuscarcli.pcNomCli;
                txtDireccion.Text = frmbuscarcli.pcDireccion;
                nidTipoPersona = frmbuscarcli.pnTipoPersona;
                if (nidTipoPersona==1)
                {
                    txtRuc.Text = frmbuscarcli.pcRucCli;
                }
                else
                {
                    txtRuc.Text = frmbuscarcli.pcNroDoc;
                }
                nidTipoDocumento = frmbuscarcli.pnTipoDocumento.ToString();
                nIdClasifInterna = frmbuscarcli.pnIdClasifInt;
                cClasifInterna = frmbuscarcli.pcClasifInt;

                txtCodCli.Enabled = false;
            }
            else //CUANDO NO SELECCIONA NADA, CANCELA O CIERRA
            {
                txtCodInst.Text = "";
                txtCodAge.Text = "";
                txtCodCli.Text = "";
                txtNroDoc.Text = "";
                txtRuc.Text = "";
                txtNombre.Text = "";
                txtDireccion.Text = "";
                nidTipoPersona = 1;
                nidTipoDocumento = "";
                txtCodCli.Enabled = true;
                nIdClasifInterna = 0;
                cClasifInterna = string.Empty;
                txtCodCli.Focus();
            }

            idCli = txtCodCli.Text == "" ? 0 : Convert.ToInt32(txtCodCli.Text);
        }

        private void txtCodCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Int32 nCifras = txtCodCli.TextLength;

                if (nCifras == 0)
                {
                    MessageBox.Show("Valor de Búsqueda Incorrecto", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtCodCli.Focus();
                    txtCodInst.Text = "";
                    txtCodAge.Text = "";
                    txtCodCli.Text = "";
                    txtNroDoc.Text = "";
                    txtRuc.Text = "";
                    txtNombre.Text = "";
                    txtDireccion.Text = "";
                    txtCodCli.Enabled = true;
                    txtCodCli.Focus();
                    idCli = 0;
                }
                else
                {
                    if (Convert.ToInt32(this.txtCodCli.Text) <= 0)
                    {
                        MessageBox.Show("Ingrese un Código de Cliente Válido", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.txtCodCli.Focus();
                        this.txtCodCli.SelectAll();
                        idCli = 0;
                        return;
                    }

                    CargardatosCli(Convert.ToInt32(txtCodCli.Text));
                }

                if (ClicBuscar != null)
                    ClicBuscar(sender, e);
            }

        }

        public void CargardatosCli(int idCli)
        {
            clsCNBuscarCli listarCli = new clsCNBuscarCli();
            DataTable tablaCli = listarCli.ListarclixIdCli(idCli);

            if (tablaCli.Rows.Count > 0)
            {
                txtCodInst.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(0, 3);
                txtCodAge.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(3, 3);
                txtCodCli.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(6);

                txtNroDoc.Text = Convert.ToString(tablaCli.Rows[0]["cDocumentoID"]);
                txtNombre.Text = Convert.ToString(tablaCli.Rows[0]["cNombre"]);
                txtDireccion.Text = Convert.ToString(tablaCli.Rows[0]["cDireccion"]);
                nidTipoPersona = Convert.ToInt32(tablaCli.Rows[0]["IdTipoPersona"]);
                if (nidTipoPersona ==1) //--Si es Persona Natural
                {
                    txtRuc.Text = tablaCli.Rows[0]["cDocumentoAdicional"].ToString();
                }
                else
                {
                    txtRuc.Text = tablaCli.Rows[0]["cDocumentoID"].ToString();
                }

                lIndDatosBasicos = Convert.ToBoolean(tablaCli.Rows[0]["lIndDatosBasic"]);
                nIdClasifInterna = Convert.ToInt32(tablaCli.Rows[0]["idClasifInterna"]);
                cClasifInterna = Convert.ToString(tablaCli.Rows[0]["cClasifInterna"]);
                txtCodCli.Enabled = false;
                this.idCli = txtCodCli.Text == "" ? 0 : Convert.ToInt32(txtCodCli.Text);
            }
            else if (tablaCli.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró ningún Registro", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodInst.Text = "";
                txtCodAge.Text = "";
                txtCodCli.Text = "";
                txtNroDoc.Text = "";
                txtRuc.Text = "";
                txtNombre.Text = "";
                txtDireccion.Text = "";
                txtCodCli.Enabled = true;
                nIdClasifInterna = 0;
                cClasifInterna = string.Empty;
                txtCodCli.Focus();
                this.idCli = 0;
            }
        }

        public void limpiarControles()
        {
            txtCodInst.Clear();
            txtCodAge.Clear();
            txtCodCli.Clear();
            txtNroDoc.Clear();
            txtRuc.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtCodInst.Clear();
            nidTipoPersona = 0;
            nIdClasifInterna = 0;
            cClasifInterna = string.Empty;
            idCli = 0;
        }
    }
}
