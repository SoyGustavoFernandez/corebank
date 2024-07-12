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
using ADM.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class ConBusCli : UserControl
    {
        public event EventHandler ClicBuscar;
        public event EventHandler CliBuscarCuentas;
        public new event EventHandler ChangeDocumentoID;
        public int nidTipoPersona, nIdClasifInterna;
        public string nidTipoDocumento, cClasifInterna,cTelefono;
        public bool lIndDatosBasicos;
        public int idAgencia = 0; // permite el filtrado por agencia
        public int nAniosActEco = 0;
        public ConBusCli()
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
                nidTipoDocumento = frmbuscarcli.pnTipoDocumento.ToString();
                nIdClasifInterna = frmbuscarcli.pnIdClasifInt;
                cClasifInterna = frmbuscarcli.pcClasifInt;
                cTelefono = frmbuscarcli.pcTelefono;
                this.nAniosActEco = frmbuscarcli.nAniosActEco;

                txtCodCli.Enabled = false;
            }
            else //CUANDO NO SELECCIONA NADA, CANCELA O CIERRA
            {
                txtCodInst.Text = "";
                txtCodAge.Text = "";
                txtCodCli.Text = "";
                txtNroDoc.Text = "";
                txtNombre.Text = "";
                txtDireccion.Text = "";
                nidTipoPersona = 1;
                nidTipoDocumento = "";
                txtCodCli.Enabled = true;
                nIdClasifInterna = 0;
                cClasifInterna = string.Empty;
                txtCodCli.Focus();
                cTelefono = "";
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
                    txtNombre.Text = "";
                    txtDireccion.Text = "";
                    txtCodCli.Enabled = true;
                    txtCodCli.Focus();
                    idCli = 0;
                    cTelefono = "";
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

                if (CliBuscarCuentas != null)
                    CliBuscarCuentas(sender, e);
                
            }

        }

        public void CargardatosCli(int idCli)
        {
            clsCNBuscarCli listarCli = new clsCNBuscarCli();
            DataTable tablaCli = listarCli.ListarclixIdCli(idCli);

            if (tablaCli.Rows.Count > 0)
            {

                AlertaCumpleaños(Convert.ToString(tablaCli.Rows[0]["cDocumentoID"]));

                txtCodInst.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(0, 3);
                txtCodAge.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(3, 3);
                txtCodCli.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(6);

                txtNroDoc.Text = Convert.ToString(tablaCli.Rows[0]["cDocumentoID"]);
                txtNombre.Text = Convert.ToString(tablaCli.Rows[0]["cNombre"]);
                txtDireccion.Text = Convert.ToString(tablaCli.Rows[0]["cDireccion"]);
                nidTipoPersona = Convert.ToInt32(tablaCli.Rows[0]["IdTipoPersona"]);
                lIndDatosBasicos = Convert.ToBoolean(tablaCli.Rows[0]["lIndDatosBasic"]);
                nIdClasifInterna = Convert.ToInt32(tablaCli.Rows[0]["idClasifInterna"]);
                cClasifInterna = Convert.ToString(tablaCli.Rows[0]["cClasifInterna"]);
                this.nAniosActEco = Convert.ToInt32(tablaCli.Rows[0]["nAniosActEco"]);
                this.nidTipoDocumento = Convert.ToString(tablaCli.Rows[0]["idTipoDocumento"]); 
                txtCodCli.Enabled = false;
                this.idCli = txtCodCli.Text == "" ? 0 : Convert.ToInt32(txtCodCli.Text);
                cTelefono = tablaCli.Rows[0]["cTelefono"].ToString();
            }
            else if (tablaCli.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró ningún Registro", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodInst.Text = "";
                txtCodAge.Text = "";
                txtCodCli.Text = "";

                txtNroDoc.Text = "";
                txtNombre.Text = "";
                txtDireccion.Text = "";
                txtCodCli.Enabled = true;
                nIdClasifInterna = 0;
                cClasifInterna = string.Empty;
                txtCodCli.Focus();
                this.idCli = 0;
                cTelefono = "";
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
            nidTipoPersona = 0;
            nIdClasifInterna = 0;
            cClasifInterna = string.Empty;
            idCli = 0;
            txtCodCli.Enabled = true;
            txtCodCli.Focus();
            cTelefono = "";
        }

        private void txtNroDoc_TextChanged(object sender, EventArgs e)
        {
            if (this.ChangeDocumentoID != null)
            {
                this.ChangeDocumentoID(sender, e);
            }
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
    }
}
