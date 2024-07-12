#region Referencias
using System;
using System.Data;
using System.Windows.Forms;
using CLI.CapaNegocio;
#endregion

namespace GEN.ControlesBase
{
    public partial class ConBusUbig : UserControl
    {
        #region Variables
        private int _nIdNodo = 0;
        public event EventHandler CambioDeIndex;
        public int nIdNodo
        {
            get { return _nIdNodo; }
            set { _nIdNodo = value; }
        }
        #endregion

        #region Metodos
        public ConBusUbig()
        {
            InitializeComponent();
        }

        private void ConBusUbig_Load(object sender, EventArgs e)
        {

        }

        public void cargar()
        {
            this.cboPais.CargarUbigeo(0);
        }

        public void cargarUbigeo(int idUbigeo)
        {
            clsCNRetDatosCliente RetCliNat = new clsCNRetDatosCliente();
            DataTable tbDatUbi = RetCliNat.RetUbiCli(idUbigeo);
            actualizarCombos(tbDatUbi);
        }

        public void cargarUbigeo(string cUbigeoRENIEC)
        {
            clsCNRetDatosCliente RetCliNat = new clsCNRetDatosCliente();
            DataTable tbDatUbi = RetCliNat.RetUbiCliPorCodigoReniec(cUbigeoRENIEC);
            actualizarCombos(tbDatUbi);
        }

        private void actualizarCombos(DataTable tbDatUbi)
        {
            this.cargar();
            switch (tbDatUbi.Rows.Count)
            {
                case 0:
                    break;
                case 1:
                    this.cboPais.SelectedValue = tbDatUbi.Rows[0]["idUbigeo"].ToString();
                    this.cboDepartamento.SelectedIndex = -1;
                    break;
                case 2:
                    this.cboPais.SelectedValue = tbDatUbi.Rows[1]["idUbigeo"].ToString();
                    this.cboDepartamento.SelectedValue = tbDatUbi.Rows[0]["idUbigeo"].ToString();
                    this.cboProvincia.SelectedIndex = -1;
                    break;
                case 3:
                    this.cboPais.SelectedValue = tbDatUbi.Rows[2]["idUbigeo"].ToString();
                    this.cboDepartamento.SelectedValue = tbDatUbi.Rows[1]["idUbigeo"].ToString();
                    this.cboProvincia.SelectedValue = tbDatUbi.Rows[0]["idUbigeo"].ToString();
                    this.cboDistrito.SelectedIndex = -1;
                    break;
                case 4:
                    this.cboPais.SelectedValue = tbDatUbi.Rows[3]["idUbigeo"].ToString();
                    this.cboDepartamento.SelectedValue = tbDatUbi.Rows[2]["idUbigeo"].ToString();
                    this.cboProvincia.SelectedValue = tbDatUbi.Rows[1]["idUbigeo"].ToString();
                    this.cboDistrito.SelectedValue = tbDatUbi.Rows[0]["idUbigeo"].ToString();
                    this.cboAnexo.SelectedIndex = -1;
                    break;
                case 5:
                    this.cboPais.SelectedValue = tbDatUbi.Rows[4]["idUbigeo"].ToString();
                    this.cboDepartamento.SelectedValue = tbDatUbi.Rows[3]["idUbigeo"].ToString();
                    this.cboProvincia.SelectedValue = tbDatUbi.Rows[2]["idUbigeo"].ToString();
                    this.cboDistrito.SelectedValue = tbDatUbi.Rows[1]["idUbigeo"].ToString();
                    this.cboAnexo.SelectedValue = tbDatUbi.Rows[0]["idUbigeo"].ToString();
                    break;
            }
        }

        public string ObtenerUbigeoReniec()
        {
            if(this.cboDistrito.SelectedIndex>-1)
            {
                DataTable dtTmp = (DataTable)this.cboDistrito.DataSource;
                return dtTmp.Rows[this.cboDistrito.SelectedIndex]["cUbigeoRENIEC"].ToString();
            }
            return "";
        }
        #endregion
        #region Eventos
        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPais.SelectedIndex > 0)
            {
                nIdNodo = Convert.ToInt32(cboPais.SelectedValue);
                cboDepartamento.CargarUbigeo(nIdNodo);
                if (cboPais.Text.Trim() != "PERU" && ((DataTable)cboDepartamento.DataSource).Rows.Count >1)
                {
                    cboDepartamento.SelectedIndex = 1;
                    cboDepartamento.Enabled = false;
                }

                if (CambioDeIndex != null)
                {
                    CambioDeIndex(sender, e);
                }
            }
            else
            {
                cboDepartamento.DataSource = null;
                cboProvincia.DataSource = null;
                cboDistrito.DataSource = null;
                cboAnexo.DataSource = null;
                cboDepartamento.Enabled = false;
                cboProvincia.Enabled = false;
                cboDistrito.Enabled = false;
                cboAnexo.Enabled = false;
                cboPais.SelectedIndex = 0;
            }
        }

        private void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.SelectedIndex > 0)
            {
                nIdNodo = Convert.ToInt32(cboDepartamento.SelectedValue);
                cboProvincia.CargarUbigeo(nIdNodo);
                if (cboPais.Text.Trim() != "PERU" && ((DataTable)cboProvincia.DataSource).Rows.Count > 1)
                {
                    cboProvincia.SelectedIndex = 1;
                    cboProvincia.Enabled = false;
                }
            }
            else
            {
                cboProvincia.DataSource = null;
                cboDistrito.DataSource = null;
                cboAnexo.DataSource = null;
                cboProvincia.Enabled = false;
                cboDistrito.Enabled = false;
                cboAnexo.Enabled = false;
                cboDepartamento.SelectedIndex = 0;
                nIdNodo = Convert.ToInt32(cboPais.SelectedValue);
            }
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedIndex > 0)
            {
                nIdNodo = Convert.ToInt32(cboProvincia.SelectedValue);
                cboDistrito.CargarUbigeo(nIdNodo);
                if (cboPais.Text.Trim() != "PERU" && ((DataTable)cboDistrito.DataSource).Rows.Count > 1)
                {
                    cboDistrito.SelectedIndex = 1;
                    cboDistrito.Enabled = false;
                }
            }
            else
            {
                cboDistrito.DataSource = null;
                cboAnexo.DataSource = null;
                cboDistrito.Enabled = false;
                cboAnexo.Enabled = false;
                cboProvincia.SelectedIndex = 0;
                nIdNodo = Convert.ToInt32(cboDepartamento.SelectedValue);
            }
        }

        private void cboDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDistrito.SelectedIndex > 0)
            {
                nIdNodo = Convert.ToInt32(cboDistrito.SelectedValue);
                cboAnexo.CargarUbigeo(nIdNodo);
                cboAnexo.Enabled = true;
                if (cboPais.Text.Trim() != "PERU" && ((DataTable)cboAnexo.DataSource).Rows.Count > 1)
                {
                    cboAnexo.SelectedIndex = 1;
                    cboAnexo.Enabled = false;
                }
            }
            else
            {
                cboAnexo.DataSource = null;
                cboAnexo.Enabled = false;
                cboDistrito.SelectedIndex = 0;
                nIdNodo = Convert.ToInt32(cboProvincia.SelectedValue);
            }
        }

        private void cboAnexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAnexo.SelectedIndex > 0)
            {
                nIdNodo = Convert.ToInt32(cboAnexo.SelectedValue);
            }
            else
            {
                nIdNodo = Convert.ToInt32(cboDistrito.SelectedValue);
            }
        }
        #endregion
    }
}
