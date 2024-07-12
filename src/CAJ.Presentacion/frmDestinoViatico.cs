using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;

namespace CAJ.Presentacion
{
    public partial class frmDestinoViatico : frmBase
    {
        public int pnTibBus=0,xnidUbigeo=0;
        public string x_cNomDestino = "";
        public Decimal x_nMonVia = 0.00m;

        private int _nIdNodo = 0;

        public int nIdNodo
        {
            get { return _nIdNodo; }
            set { _nIdNodo = value; }
        }

        public frmDestinoViatico()
        {
            InitializeComponent();
        }

        private void frmDestinoViatico_Load(object sender, EventArgs e)
        {
            cargar();
            if (pnTibBus==1)  //--Viaticos Nacional
            {
                this.cboPais.SelectedValue = 173;
                this.cboPais.Enabled = false;
                this.cboDepartamento.Enabled = true;
            }
            else if (pnTibBus == 2) //--Viaticos Extrangero
            {
                this.cboPais.SelectedValue = 11;
                this.cboPais.Enabled = true;
                this.cboDepartamento.Enabled = false;
                this.cboProvincia.Enabled = false;
            }
            else
            {
                this.cboPais.Enabled = false;
            }
        }

        public void cargar()
        {
            this.cboPais.CargarUbigeo(nIdNodo);
        }

        public void cargarUbigeo(int idUbigeo)
        {
            clsCNRetDatosCliente RetCliNat = new clsCNRetDatosCliente();
            DataTable tbDatUbi = RetCliNat.RetUbiCli(idUbigeo);

            this.cboPais.SelectedValue = tbDatUbi.Rows[3]["idUbigeo"].ToString();
            this.cboDepartamento.SelectedValue = tbDatUbi.Rows[2]["idUbigeo"].ToString();
            this.cboProvincia.SelectedValue = tbDatUbi.Rows[1]["idUbigeo"].ToString();
        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPais.SelectedIndex > 0)
            {
                nIdNodo = Convert.ToInt32(cboPais.SelectedValue);
                cboDepartamento.CargarUbigeo(nIdNodo);
                cboDepartamento.Enabled = true;
                if (cboPais.Text.Trim() != "PERU")
                {
                    cboDepartamento.SelectedIndex = 1;
                    cboDepartamento.Enabled = false;
                }
            }
            else
            {
                cboDepartamento.DataSource = null;
                cboProvincia.DataSource = null;
                cboDepartamento.Enabled = false;
                cboProvincia.Enabled = false;
                cboPais.SelectedIndex = 0;
            }
        }

        private void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.SelectedIndex > 0)
            {
                nIdNodo = Convert.ToInt32(cboDepartamento.SelectedValue);
                cboProvincia.CargarUbigeo(nIdNodo);
                cboProvincia.Enabled = true;
                if (cboPais.Text.Trim() != "PERU")
                {
                    cboProvincia.SelectedIndex = 1;
                    cboProvincia.Enabled = false;
                }
            }
            else
            {
                cboProvincia.DataSource = null;
                cboProvincia.Enabled = false;
                cboDepartamento.SelectedIndex = 0;
            }
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ObtenerMontoVia(int idUbigeo)
        {
            clsCNControlViaticos Lista = new clsCNControlViaticos();
            DataTable tbMonUbi = Lista.CNRetornaMontoVia(idUbigeo);
            if (tbMonUbi.Rows.Count>0)
            {
                x_nMonVia =Convert.ToDecimal (tbMonUbi.Rows[0]["nMontoViatico"]);
            }
            else
            {
                x_nMonVia = 0.00m;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLugar.Text))
            {
                MessageBox.Show("Debe Registrar la Referencia del Destino...", "Destino Viático", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                xnidUbigeo = 0;
                return;
            }
            if (pnTibBus == 1)  //--Viaticos Nacional
            {
                if (string.IsNullOrEmpty(cboDepartamento.Text))
                {
                    MessageBox.Show("Debe Seleccionar el Departamento...", "Destino Viático", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboDepartamento.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cboProvincia.Text))
                {
                    MessageBox.Show("Debe Seleccionar la Provincia...", "Destino Viático", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboProvincia.Focus();
                    return;
                }
                x_cNomDestino = cboProvincia.Text;
                xnidUbigeo = Convert.ToInt32(cboProvincia.SelectedValue);
                ObtenerMontoVia(xnidUbigeo);
            }
            else if (pnTibBus == 2) //--Viaticos Extrangero
            {
                if (string.IsNullOrEmpty(cboPais.Text))
                {
                    MessageBox.Show("Debe Seleccionar elPais...", "Destino Viático", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboPais.Focus();
                    return;
                }
                x_cNomDestino = cboPais.Text;
                xnidUbigeo = Convert.ToInt32(cboPais.SelectedValue);
                ObtenerMontoVia(xnidUbigeo);
            }
            else
            {
                xnidUbigeo = 0;
                x_cNomDestino = "";
            }
            this.Dispose();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            xnidUbigeo = 0;
            x_nMonVia = 0.00m;
            x_cNomDestino = "";
        }

    }
}
