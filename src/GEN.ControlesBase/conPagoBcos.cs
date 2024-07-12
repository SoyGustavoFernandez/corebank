using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAJ.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class conPagoBcos : UserControl
    {
        clsCNComprobantes objCpg = new clsCNComprobantes();
        public int idEntidad = 0, idCuenta = 0;
        public string cNroTrx = "", cResultado = "", cEmpresa="", cCuenta="";
        public Boolean lResulta;

        public conPagoBcos()
        {
            InitializeComponent();
        }
        public void CargaEntidad(int nTipoPago)
        {
            DataTable dtEntidad;
            dtEntidad = objCpg.ListarEntidadesConCuenta(nTipoPago);
            if (dtEntidad.Rows.Count > 0)
            {
                cboEntidad.DataSource = dtEntidad;
                cboEntidad.ValueMember = "idEntidad";
                cboEntidad.DisplayMember = "cNombreCorto";
                cboEntidad.SelectedIndex = -1;
            }
            else
            {
                cboEntidad.DataSource = null;
            }
            
        }

        private void cboEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEntidad.SelectedIndex == -1 || cboEntidad.SelectedValue is DataRowView)
            {
                cboCuenta.DataSource = null;
                return;
            }
            DataTable dt;
            dt = objCpg.ListarCuentaXEntidades(Convert.ToInt32(cboEntidad.SelectedValue));
            cboCuenta.DataSource = dt;
            cboCuenta.ValueMember = "idCuentaInstitucion";
            cboCuenta.DisplayMember = "cNumeroCuenta";
            cboCuenta.SelectedIndex = -1;
        }

        public void CargaResultado()
        {
            if (Convert.ToInt32(cboEntidad.SelectedValue)<=0)
            {
                cResultado = "Seleccione la entidad de la TRX";
                lResulta = false;
                return;
            }
            if (Convert.ToInt32(cboCuenta.SelectedValue) <= 0)
            {
                cResultado = "Seleccione la cuenta de la TRX";
                lResulta = false;
                return;
            }
            if (string.IsNullOrEmpty(txtCodOpera.Text))
            {
                cResultado = "Ingrese el Nro de Operación";
                lResulta = false;
                return;
            }
            idEntidad = Convert.ToInt32(cboEntidad.SelectedValue);
            idCuenta = Convert.ToInt32(cboCuenta.SelectedValue);
            cNroTrx = txtCodOpera.Text;
            cEmpresa = cboEntidad.Text;
            cCuenta = cboCuenta.Text;
            lResulta = true;
        }
        public void LimpiarControles()
        {
            cboEntidad.SelectedValue = 0;
            cboCuenta.SelectedValue = 0;
            txtCodOpera.Text = "";
        }

        public void CargaEntidadMoneda(int nTipoPago, int idMoneda)
        {
            DataTable dtEntidad;
            dtEntidad = objCpg.ListarEntidadesConCuenta(nTipoPago, idMoneda);
            if (dtEntidad.Rows.Count > 0)
            {
                cboEntidad.DataSource = dtEntidad;
                cboEntidad.ValueMember = "idEntidad";
                cboEntidad.DisplayMember = "cNombreCorto";
                cboEntidad.SelectedIndex = -1;
            }
            else
            {
                cboEntidad.DataSource = null;
            }

        }

        public bool ValidarPagoBcos()
        {
            if (cboEntidad.SelectedIndex < 0)
            {
                return false;
            }

            if (cboCuenta.SelectedIndex < 0)
            {
                return false;
            }

            if (String.IsNullOrEmpty(txtCodOpera.Text))
            {
                return false;
            }
            return true;
            
        }

    }
}
