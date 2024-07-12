using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class conNroTarjeta : UserControl
    {
        private string _NroTarjeta;

        public string NroTarjeta
        {
            get { return this.txtBind.Text + this.txtProd.Text + this.txtNroTarj.Text; }
            set { _NroTarjeta = value; }
        }


        public conNroTarjeta()
        {
            InitializeComponent();
        }

        private void conNroTarjeta_Load(object sender, EventArgs e)
        {

        }

        public void limpiar()
        {
            this.txtBind.Clear();
            this.txtProd.Clear();
            this.txtNroTarj.Clear();
        }

        public void HabDeshabilitarCtr(bool val)
        {
            this.txtBind.Enabled = val;
            this.txtProd.Enabled = val;
            this.txtNroTarj.Enabled = val;
        }

        public bool Validar(ref string cMensaje)
        {
            if (string.IsNullOrEmpty(this.txtBind.Text))
            {
                cMensaje = "Debe Ingresar el Número BIND de la Tarjeta";
                this.txtBind.Focus();
                this.txtBind.SelectAll();
                return false;
            }
            if (this.txtBind.Text.Trim().Length!=6)
            {
                cMensaje = "El Numero BIND de la Tarjeta es de 6 Dígitos";
                this.txtBind.Focus();
                this.txtBind.SelectAll();
                return false;
            }

            if (string.IsNullOrEmpty(this.txtProd.Text))
            {
                cMensaje = "Debe Ingresar el Producto de la Tarjeta";
                this.txtProd.Focus();
                this.txtProd.SelectAll();
                return false;
            }
            if (this.txtProd.Text.Trim().Length != 2)
            {
                cMensaje = "El Producto de la tarjeta es de 2 Dígitos";
                this.txtProd.Focus();
                this.txtProd.SelectAll();
                return false;
            }

            if (string.IsNullOrEmpty(this.txtNroTarj.Text))
            {
                cMensaje = "Debe Ingresar el Número de la Tarjeta";
                this.txtNroTarj.Focus();
                this.txtNroTarj.SelectAll();
                return false;
            }
            if (this.txtNroTarj.Text.Trim().Length != 8)
            {
                cMensaje = "El Número de la tarjeta es de 8 Dígitos";
                this.txtNroTarj.Focus();
                this.txtNroTarj.SelectAll();
                return false;
            }
            return true;
        }

        public void MostrarNroTarjeta(string cNroTarjeta)
        {
            this.txtBind.Text = cNroTarjeta.Substring(0, 6);
            this.txtProd.Text = cNroTarjeta.Substring(6, 2);
            this.txtNroTarj.Text = cNroTarjeta.Substring(8, 8);
        }

        private void txtNroTarj_TextChanged(object sender, EventArgs e)
        {

        }
       
    }
}
