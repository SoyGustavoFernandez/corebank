using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CLI.CapaNegocio;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class conDatCli : UserControl
    {
        public conDatCli()
        {
            InitializeComponent();
        }

        public clsCliente cliente { get; set; }

        public void cargarCliente(int idCli)
        {
            cliente = new clsCNRetDatosCliente().retornarCliente(idCli, "N");
            cliente.idCli = idCli;
            this.txtCodCli.Text = cliente.cCodCliente;
            this.txtNombre.Text = cliente.ToString();
            this.txtNroDoc.Text = cliente.cDocumentoID;
        }

        public void cargarClienteJur(int idCli)
        {
            cliente = new clsCNRetDatosCliente().retornarCliente(idCli, "J");
            cliente.idCli = idCli;
            this.txtCodCli.Text = cliente.cCodCliente;
            this.txtNombre.Text = cliente.ToString();
            this.txtNroDoc.Text = cliente.cDocumentoID;
        }

        public void limpiarcontroles()
        {
            this.txtCodCli.Text = "";
            this.txtNombre.Text = "";
            this.txtNroDoc.Text = "";
            cliente = null;
        }

        private void conDatCli_Load(object sender, EventArgs e)
        {

        }
    }
}
