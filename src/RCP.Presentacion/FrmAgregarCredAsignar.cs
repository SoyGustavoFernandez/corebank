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

namespace RCP.Presentacion
{
    public partial class FrmAgregarCredAsignar : frmBase
    {
        public bool lAceptar = false;
        public DataTable dtCodigos = new DataTable();
        public FrmAgregarCredAsignar()
        {
            InitializeComponent();
        }

        private void txtCodigos_Leave(object sender, EventArgs e)
        {
            if (txtCodigos.Text.Trim().Length > 0)
            {
                actualizar();
            }
        }

        private void actualizar()
        {
            try
            {
                dtCodigos.Rows.Clear();
                string[] cCodigos = txtCodigos.Text.Split(',');
                string final = "";
                foreach (string cCodigo in cCodigos)
                {
                    if (cCodigo.Trim().Length > 0)
                    {
                        final += (cCodigo.Trim() + ",");
                        DataRow drCodigo = dtCodigos.NewRow();
                        drCodigo["idCuenta"] = cCodigo.Trim();
                        dtCodigos.Rows.Add(drCodigo);
                    }
                }

                txtCodigos.Text = final.Substring(0, final.Length - 1);
                txtCodigos.SelectAll();
                lblContador.Text = "Total: " + dtCodigos.Rows.Count.ToString();
                btnAceptar1.Enabled = dtCodigos.Rows.Count > 0;
                btnAceptar1.Focus();
            }
            catch
            {
                MessageBox.Show("La cadena de entrada no tiene el formato correcto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblContador.Text = "Total: 0";
                txtCodigos.Clear();                
                btnAceptar1.Enabled = false;
            }
        }

        private void FrmAgregarCredAsignar_Load(object sender, EventArgs e)
        {
            btnAceptar1.Enabled = false;
            txtCodigos.MaxLength = int.MaxValue;
            dtCodigos.Columns.Add("idCuenta", typeof(int));
        }

        private void txtCodigos_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigos.Text.Trim().Length > 0)
            {
                actualizar();
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            this.lAceptar = true;
            this.Dispose();
        }
    }
}
