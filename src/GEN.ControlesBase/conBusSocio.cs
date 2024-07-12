using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.CapaNegocio;
namespace GEN.ControlesBase
{
    public partial class conBusSocio : UserControl
    {
        public event EventHandler ClicBuscar;
        public int nidTipoPersona;
        public int idCerrado=0;
        public int idCli { get; set; }
        public conBusSocio()
        {
            InitializeComponent();
        }

        private void txtCodCli_KeyPress(object sender, KeyPressEventArgs e)
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
                        Int32 nCifras = this.txtCodCli.TextLength;

                        if (nCifras == 0)
                        {
                            MessageBox.Show("Valor de Búsqueda Incorrecto", "Buscar Cuenta Socio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.txtCodCli.Focus();
                            txtCodInst.Text = "";
                            txtCodAge.Text = "";
                            txtCodCli.Text = "";
                            txtNroDoc.Text = "";
                            txtNombre.Text = "";
                            txtDireccion.Text = "";
                            txtCodCli.Enabled = true;
                            txtCodCli.Focus();
                        }

                        else
                        {

                            clsCNBuscarCli listarCli = new clsCNBuscarCli();
                            DataTable tablaCli = listarCli.ListarclixIdCli(Convert.ToInt32(this.txtCodCli.Text));

                            if (tablaCli.Rows.Count > 0)
                            {
                                txtCodInst.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(0, 3);
                                txtCodAge.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(3, 3);
                                txtCodCli.Text = Convert.ToString(tablaCli.Rows[0]["cCodCliente"]).Substring(6);

                                txtNroDoc.Text = Convert.ToString(tablaCli.Rows[0]["cDocumentoID"]);
                                txtNombre.Text = Convert.ToString(tablaCli.Rows[0]["cNombre"]);
                                txtDireccion.Text = Convert.ToString(tablaCli.Rows[0]["cDireccion"]);
                                nidTipoPersona = Convert.ToInt32(tablaCli.Rows[0]["IdTipoPersona"]);
                                txtCodCli.Enabled = false;
                            }
                            else if (tablaCli.Rows.Count == 0)
                            {
                                MessageBox.Show("No se encontró ningún Registro", "Buscar Cuenta Socio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtCodInst.Text = "";
                                txtCodAge.Text = "";
                                txtCodCli.Text = "";

                                txtNroDoc.Text = "";
                                txtNombre.Text = "";
                                txtDireccion.Text = "";
                                txtCodCli.Enabled = true;
                                txtCodCli.Focus();
                            }
                        }
                    }

                    else
                    {
                        return;
                    }
                    idCli = txtCodCli.Text == "" ? 0 : Convert.ToInt32(txtCodCli.Text);
                    if (ClicBuscar != null)
                        ClicBuscar(sender, e);
                }
            }
        }
        public void buscar()
        {
            FrmBusCli frmbuscarcli = new FrmBusCli();
            frmbuscarcli.ShowDialog();

            if (frmbuscarcli.pcCodCliLargo != null)
            {
                txtCodInst.Text = frmbuscarcli.pcCodCliLargo.Substring(0, 3);
                txtCodAge.Text = frmbuscarcli.pcCodCliLargo.Substring(3, 3);
                txtCodCli.Text = frmbuscarcli.pcCodCliLargo.Substring(6);
                txtNroDoc.Text = frmbuscarcli.pcNroDoc;
                txtNombre.Text = frmbuscarcli.pcNomCli;
                txtDireccion.Text = frmbuscarcli.pcDireccion;
                nidTipoPersona = frmbuscarcli.pnTipoPersona;
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
                txtCodCli.Enabled = true;
                txtCodCli.Focus();
            }


            idCli = txtCodCli.Text == "" ? 0 : Convert.ToInt32(txtCodCli.Text);

        }

        private void btnBusCliente1_Click(object sender, EventArgs e)
        {
            idCerrado = 0;

            FrmBusCli frmbuscarcli = new FrmBusCli();
            frmbuscarcli.ShowDialog();


            if (!string.IsNullOrEmpty(frmbuscarcli.pcCodCliLargo))
            {
                txtCodInst.Text = frmbuscarcli.pcCodCliLargo.Substring(0, 3);
                txtCodAge.Text = frmbuscarcli.pcCodCliLargo.Substring(3, 3);
                txtCodCli.Text = frmbuscarcli.pcCodCliLargo.Substring(6);
                txtNroDoc.Text = frmbuscarcli.pcNroDoc;
                txtNombre.Text = frmbuscarcli.pcNomCli;
                txtDireccion.Text = frmbuscarcli.pcDireccion;
                nidTipoPersona = frmbuscarcli.pnTipoPersona;
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
                txtCodCli.Enabled = true;
                txtCodCli.Focus();
                idCerrado = 1;
            }


            idCli = txtCodCli.Text == "" ? 0 : Convert.ToInt32(txtCodCli.Text);

            if (ClicBuscar != null)
                ClicBuscar(sender, e);
        }

        private void txtCodCli_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
