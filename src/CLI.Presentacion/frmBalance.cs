using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;

namespace CLI.Presentacion
{
    public partial class frmBalance : frmBase
    {
        clsCNBalanceFueIng cnbalancefueing = new clsCNBalanceFueIng();
        clslisBalanceFueIng lisbalances;

        clsBalanceFueIng objbalancenue = new clsBalanceFueIng();

        public int idCli { get; set; }
        public clsCliente clienteFuente { get; set; }
        public int idFuenteIngreso { get; set; }

        public frmBalance()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listarBalances();
        }

        private void listarBalances()
        {
            lisbalances=  cnbalancefueing.retornarBalances(idCli, clienteFuente.idCli);
            if (lisbalances.Count>0)
            {
                this.cboBalances.DataSource = lisbalances.ToList();
                this.cboBalances.ValueMember = "idBalance";
                this.cboBalances.DisplayMember = "cDateBalance";
                this.cboBalances.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            }
            else
            {
                this.cboBalances.Enabled = false;
            }          

        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            conTLVBalance1.cargarPlantilla(2);
            habilitarControles(true);
            limpiarControles();
        }

        private void limpiarControles()
        {
            txtCodCpp.Text = "";
            txtContador.Text = "";
            txtDireccion.Text = "";
            txtDocIde.Text = "";
            txtEmail1.Text = "";
            txtTelefono.Text = "";
            rbtAuditaSi.Checked = false;
            rbtAuditaNo.Checked = true;
            rbtMonedaSi.Checked = false ;
            rbtMonedaNo.Checked = true;
        }

        private void habilitarControles(bool estado)
        {
            this.grbAuditado.Enabled = estado;
            this.grbMonExt.Enabled = estado;
            this.grbDatContador.Enabled = estado;
            this.conTLVBalance1.Enabled = estado;
        }

        private void cboBalances_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBalances.SelectedIndex >= 0)
            {
                if (cboBalances.SelectedValue is clsBalanceFueIng)
                {
                    return;
                }
                int idBalance = ((int)cboBalances.SelectedValue);
                cargarDetalleBalance(idBalance);

                clsBalanceFueIng balancesel = (clsBalanceFueIng)cboBalances.SelectedItem;
                txtCodCpp.Text = balancesel.cCodCpp;
                txtContador.Text = balancesel.cContador;
                txtDireccion.Text = balancesel.cDirConta;
                txtDocIde.Text = balancesel.cDocideCon;
                txtEmail1.Text = balancesel.cMailConta;
                txtTelefono.Text = balancesel.cNumTelCon;
                rbtAuditaSi.Checked = balancesel.lAuditado == true ? true : false;
                rbtAuditaNo.Checked = balancesel.lAuditado == true ? false : true;
                rbtMonedaSi.Checked = balancesel.lMonExtran == true ? true : false;
                rbtMonedaNo.Checked = balancesel.lMonExtran == true ? false : true;

            }

            
        }

        private void cargarDetalleBalance(int idBalance)
        {
            this.conTLVBalance1.cargarBalance(idBalance);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            clslisDetalleBalance detalle = new clslisDetalleBalance();

            foreach (ListViewItem item in conTLVBalance1.listViewEditable1.Items)
            {
                clsItemBalance itembal = (clsItemBalance)item.Tag;

                clsDetalleBalance detbal= new clsDetalleBalance();
                detbal.cDesItem = itembal.cDesItem;
                detbal.nOrden= itembal.nOrden;
                detbal.nNivel= itembal.nNivel;
                detbal.lVigente= itembal.lVigente;
                detbal.nMonto= Convert.ToDecimal(item.SubItems[1].Text);
                detalle.Add(detbal);
            }

            objbalancenue.cCodCpp = txtCodCpp.Text.Trim();
            objbalancenue.cContador = txtContador.Text.Trim();
            objbalancenue.cDirConta = txtDireccion.Text.Trim();
            objbalancenue.cNumTelCon = txtTelefono.Text.Trim();
            objbalancenue.lAuditado = rbtAuditaSi.Checked == true ? true : false;
            objbalancenue.lMonExtran = rbtMonedaSi.Checked == true ? true : false;
            objbalancenue.cMailConta = txtEmail1.Text.Trim();
            objbalancenue.cDocideCon = txtDocIde.Text.Trim();
            objbalancenue.idFuenteIngreso = idFuenteIngreso;
            objbalancenue.dFechaReg = clsVarGlobal.dFecSystem;
            objbalancenue.idUsuReg = clsVarGlobal.User.idUsuario;
            objbalancenue.idEstado = 1;

            cnbalancefueing.insertarBalance(objbalancenue, detalle);
            

            MessageBox.Show("Se grabaron correctamente los datos ingresados", "Registro de Balance", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listarBalances();
        }

        private void btnExportar1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
