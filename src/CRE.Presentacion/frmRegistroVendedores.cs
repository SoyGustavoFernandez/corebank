using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmRegistroVendedores : frmBase
    {
        private clsCNMantenimientoCanales clsMantenimientoCanales = new clsCNMantenimientoCanales();
        private int idVendedor_;
        private int nCodCanal_;
        private int idUsuario_;
        private string cNombreVendedor_;
        private int idRegion_;
        private int idOficina_;
        private string cNombreCorto_;
        private bool lActivo_;
        private bool lLlenarFormularioMantenimiento = false;

        public frmRegistroVendedores()
        {
            InitializeComponent();
        }

        public frmRegistroVendedores(int idVendedor, int nCodCanal, int idUsuario, string cNombreVendedor, int idRegion, int idOficina, string cNombreCorto, bool lActivo)
        {
            idVendedor_ = idVendedor;
            nCodCanal_ = nCodCanal;
            idUsuario_ = idUsuario;
            cNombreVendedor_ = cNombreVendedor;
            idRegion_ = idRegion;
            idOficina_ = idOficina;
            cNombreCorto_ = cNombreCorto;
            lActivo_ = lActivo;
            lLlenarFormularioMantenimiento = true;
            InitializeComponent();
        }

        private void frmRegistroVendedores_Load(object sender, EventArgs e)
        {
            conBusCol1.lMinDat = true;
            cboAgencias1.FiltrarPorZonaTodos(0);
            chbVigente.Checked = true;
            if (lLlenarFormularioMantenimiento)
            {
                llenarFormulario();
            }
            if (txtCodCanal.Text == "")
            {
                cboCanalVendedor1.SelectedIndexChanged -= cboCanalVendedor1_SelectedIndexChanged;
                cboCanalVendedor1.SelectedIndex = -1;
                cboCanalVendedor1.SelectedIndexChanged += cboCanalVendedor1_SelectedIndexChanged;

                cboZona1.SelectedIndexChanged -= cboZona1_SelectedIndexChanged;
                cboZona1.SelectedIndex = -1;
                cboZona1.SelectedIndexChanged += cboZona1_SelectedIndexChanged;

                cboAgencias1.SelectedIndexChanged -= cboAgencias1_SelectedIndexChanged;
                cboAgencias1.SelectedIndex = -1;
                cboAgencias1.SelectedIndexChanged += cboAgencias1_SelectedIndexChanged;

                chbVigente.Enabled = false;
            }
            else { conBusCol1.BusPerByCod(); }
        }

        private void llenarFormulario()
        {
            conBusCol1.txtCod.Text = idUsuario_.ToString();
            conBusCol1.txtNom.Text = cNombreVendedor_;
            cboCanalVendedor1.SelectedValue = nCodCanal_;
            txtCodCanal.Text = nCodCanal_.ToString();
            cboZona1.SelectedValue = idRegion_;
            cboAgencias1.SelectedValue = idOficina_;
            txtNombreCorto.Text = cNombreCorto_.ToString();
            rblActivo.Checked = lActivo_;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (conBusCol1.txtCod.Text == "" || conBusCol1.txtNom.Text == "" || cboCanalVendedor1.SelectedIndex < 0 || cboZona1.SelectedIndex < 0 || cboAgencias1.SelectedIndex < 0 || txtNombreCorto.Text == "")
            {
                MessageBox.Show("Por favor llene todos los campos solicitados", "Validación Mantenimiento Canales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DialogResult dRes = MessageBox.Show("¿Esta seguro de realizar la operación?", "Mantenimiento Canales", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dRes == DialogResult.Yes)
                {
                    int nCodCanal = Convert.ToInt32(cboCanalVendedor1.SelectedValue);
                    int idUsu = Convert.ToInt32(conBusCol1.txtCod.Text);
                    string cNombVend = conBusCol1.txtNom.Text;
                    int idReg = Convert.ToInt32(cboZona1.SelectedValue);
                    int idOfi = Convert.ToInt32(cboAgencias1.SelectedValue);
                    if (chbVigente.Checked == true)
                    {
                        clsMantenimientoCanales.RegistrarVendedores(idVendedor_, nCodCanal, idUsu, cNombVend, idReg, idOfi, txtNombreCorto.Text, rblActivo.Checked, true);
                    }
                    else
                    {
                        clsMantenimientoCanales.RegistrarVendedores(idVendedor_, nCodCanal, idUsu, cNombVend, idReg, idOfi, txtNombreCorto.Text, rblActivo.Checked, false);
                    }
                    DialogResult dRes2 = MessageBox.Show("Operación realizada con éxito", "Validación Mantenimiento Canales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dRes2 == DialogResult.OK)
                    {
                        this.Dispose();
                    }
                    return;
                }
            }
        }

        private void cboCanalVendedor1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCodCanal = Convert.ToInt32(cboCanalVendedor1.SelectedValue);
            txtCodCanal.Text = idCodCanal.ToString();
        }

        private void cboZona1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboAgencias1.FiltrarPorZonaTodos(Convert.ToInt32(cboZona1.SelectedValue));
            cboAgencias1.SelectedValue = 0;
        }

        private void cboAgencias1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.conBusCol1.txtCod.Clear();
            this.conBusCol1.txtCargo.Clear();
            this.conBusCol1.txtNom.Clear();
            this.txtCodCanal.Clear();
            this.conBusCol1.txtCod.Enabled = true;
            this.conBusCol1.btnConsultar.Enabled = true;
            this.txtNombreCorto.Clear();

            cboCanalVendedor1.SelectedIndexChanged -= cboCanalVendedor1_SelectedIndexChanged;
            cboCanalVendedor1.SelectedIndex = -1;
            cboCanalVendedor1.SelectedIndexChanged += cboCanalVendedor1_SelectedIndexChanged;

            cboZona1.SelectedIndexChanged -= cboZona1_SelectedIndexChanged;
            cboZona1.SelectedIndex = -1;
            cboZona1.SelectedIndexChanged += cboZona1_SelectedIndexChanged;

            cboAgencias1.SelectedIndexChanged -= cboAgencias1_SelectedIndexChanged;
            cboAgencias1.SelectedIndex = -1;
            cboAgencias1.SelectedIndexChanged += cboAgencias1_SelectedIndexChanged;
        }

        private void chbVigente_CheckedChanged(object sender, EventArgs e)
        {
            if (chbVigente.Checked == false)
            {
                conBusCol1.txtCod.Enabled = false;
                conBusCol1.btnConsultar.Enabled = false;
                cboCanalVendedor1.Enabled = false;
                cboZona1.Enabled = false;
                cboAgencias1.Enabled = false;
                txtNombreCorto.Enabled = false;
                rblActivo.Enabled = false;
                rblNoActivo.Enabled = false;
            }
            else
            {
                conBusCol1.txtCod.Enabled = true;
                conBusCol1.btnConsultar.Enabled = true;
                cboCanalVendedor1.Enabled = true;
                cboZona1.Enabled = true;
                cboAgencias1.Enabled = true;
                txtNombreCorto.Enabled = true;
                rblActivo.Enabled = true;
                rblNoActivo.Enabled = true;
            }
        }
    }
}
