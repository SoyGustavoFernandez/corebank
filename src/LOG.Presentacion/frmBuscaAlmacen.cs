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
using EntityLayer;

namespace LOG.Presentacion
{
    public partial class frmBuscaAlmacen : frmBase
    {
        public int idAgenciaOri, idAgenciaDes, idAlmacenOri, idAlmacenDes;
        public string cAgenciaOri, cAgenciaDes, cAlmacenOri, cAlmacenDes;

        public frmBuscaAlmacen()
        {            
            InitializeComponent();           
        }

        private void frmBuscaAlmacen_Load(object sender, EventArgs e)
        {
            cboAgenciaOri.SelectedIndex = -1;
            cboAgenciaDes.SelectedIndex = -1;
            cboAgenciaDes.SelectedValue = clsVarGlobal.nIdAgencia;
            cboAlmacenesOri.SelectedIndex = -1;
            if (cboAlmacenesDes.Items.Count <= 0)
            {
                cboAlmacenesDes.SelectedIndex = -1;
            }

            if (clsVarGlobal.nIdAgencia == 1)
            {
                cboAgenciaDes.Enabled = true;
            }
            else
            {
                cboAgenciaDes.Enabled = false;
            }
        }
        
        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (!ValidaSeleccion())
            {
                return;
            }

            idAgenciaOri = Convert.ToInt32(cboAgenciaOri.SelectedValue);
            idAgenciaDes = Convert.ToInt32(cboAgenciaDes.SelectedValue);
            idAlmacenOri = Convert.ToInt32(cboAlmacenesOri.SelectedValue);
            idAlmacenDes = Convert.ToInt32(cboAlmacenesDes.SelectedValue);

            cAgenciaOri = cboAgenciaOri.Text;
            cAgenciaDes = cboAgenciaDes.Text;
            cAlmacenOri = cboAlmacenesOri.Text;
            cAlmacenDes = cboAlmacenesDes.Text;

            this.Dispose();
        }

        private bool ValidaSeleccion()
        {
            if (Convert.ToInt32(cboAgenciaOri.SelectedValue)<=0)
            {
                MessageBox.Show("Debe Seleccionar Agencia de Origen", "Valida Almacen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgenciaOri.Focus();
                return false;
            }

            if (Convert.ToInt32(cboAgenciaDes.SelectedValue) <= 0)
            {
                MessageBox.Show("Debe Seleccionar Agencia de Destino", "Valida Almacen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgenciaDes.Focus();
                return false;
            }

            if (Convert.ToInt32(cboAlmacenesOri.SelectedValue) <= 0)
            {
                MessageBox.Show("Debe Seleccionar Almacen de Origen", "Valida Almacen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAlmacenesOri.Focus();
                return false;
            }

            if (Convert.ToInt32(cboAlmacenesDes.SelectedValue) <= 0)
            {
                MessageBox.Show("Debe Seleccionar Almacen de Destino", "Valida Almacen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAlmacenesDes.Focus();
                return false;
            }
            if (Convert.ToInt32(cboAlmacenesOri.SelectedValue) == Convert.ToInt32(cboAlmacenesDes.SelectedValue))
            {
                MessageBox.Show("El Almacen de Origen y Destino deben ser diferentes", "Valida Almacen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAlmacenesOri.Focus();
                return false;
            }
            return true;
        }

        private void cboAgenciaOri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboAgenciaOri.SelectedValue) > 0)
            {
                cboAlmacenesOri.CargarAlmacenOfi(Convert.ToInt32(cboAgenciaOri.SelectedValue));
            }
        }

        private void cboAgenciaDes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboAgenciaDes.SelectedValue) > 0)
            {
                cboAlmacenesDes.CargarAlmacenOfi(Convert.ToInt32(cboAgenciaDes.SelectedValue));
            }
        }

        
    }
}
