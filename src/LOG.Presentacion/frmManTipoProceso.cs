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
using LOG.CapaNegocio;
namespace LOG.Presentacion
{
    public partial class frmManTipoProceso : frmBase
    {
        clsListaTipoProceso lstTipPro = new clsListaTipoProceso();
        clsCNTipoProcAdj CNtipoProceso = new clsCNTipoProcAdj();
        int pidTipoProceso;

        public frmManTipoProceso()
        {
            InitializeComponent();
        }

        private void frmMantenimientoTipoProceso_Load(object sender, EventArgs e)
        {

            CargarTipoProceso();
            habilitarControles(grbDetTipoPro, false);
            habilitarBotones(true);
        }
        private void CargarTipoProceso()
        {
            lstTipPro = CNtipoProceso.buscaTipoProceso();
            dtgTipoProceso.DataSource = null;
            dtgTipoProceso.DataSource = lstTipPro;
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            habilitarControles(grbDetTipoPro, true);
            pidTipoProceso = 0;
            habilitarBotones(false);
            limpiarTexto();
            chcVigente.Enabled = false;
            chcVigente.Checked = false;
            dtgTipoProceso.Enabled = false;   
        }

        private void dtgTipoProceso_SelectionChanged(object sender, EventArgs e)
        {
            var itemselc = (clsTipoProceso)dtgTipoProceso.CurrentRow.DataBoundItem;
            txtNombreProceso.Text = itemselc.cTipoProceso;
            txtDesCorta.Text = itemselc.cDescCorta;
        }
        private void limpiarTexto(){
            txtDesCorta.Clear();
            txtNombreProceso.Clear();
        }

        private void txtNombreProceso_TextChanged(object sender, EventArgs e)
        {
            txtNombreProceso.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtDesCorta_TextChanged(object sender, EventArgs e)
        {
            txtDesCorta.CharacterCasing= CharacterCasing.Upper;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreProceso.Text.Trim()))
            {
                 MessageBox.Show("Ingrese Nombre del Proceso","Mantenimiento de Tipo de Proceso",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtDesCorta.Text.Trim()))
            {
                MessageBox.Show("Ingrese la Descripción Corta del Proceso", "Mantenimiento de Tipo de Proceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtgTipoProceso.Rows.Count>0)//Validar que no se inserte elementos repetidos
            {
                int item = lstTipPro.Count(x => x.cDescCorta == txtDesCorta.Text || x.cTipoProceso == txtNombreProceso.Text);
                var itemSel = (clsTipoProceso)dtgTipoProceso.CurrentRow.DataBoundItem;
                if ((item == 1 && pidTipoProceso == 0) || (item == 1 && pidTipoProceso != 0 && itemSel.cTipoProceso != txtNombreProceso.Text.Trim()))
                {
                    MessageBox.Show("Ya Existe el Tipo de Proceso", "Mantenimiento de Tipo de Proceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            
            clsTipoProceso nuevTipoProceso = new clsTipoProceso();
            nuevTipoProceso.cDescCorta = txtDesCorta.Text;
            nuevTipoProceso.cTipoProceso = txtNombreProceso.Text;
            nuevTipoProceso.idTipoProceso = pidTipoProceso;
            nuevTipoProceso.lVigente =(chcVigente.Checked==true )?false: true;
            int nResp=0;
            string mResp="";
            mResp=CNtipoProceso.GrabarTipoProceso(nuevTipoProceso, ref nResp);
            if (nResp == 0)
            {
                MessageBox.Show(mResp, "Mantenimiento de Tipo de Proceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(mResp, "Mantenimiento de Tipo de Proceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTipoProceso();
                habilitarControles(grbDetTipoPro, false);
                habilitarBotones(true);
                chcVigente.Enabled = false;
                chcVigente.Checked = false;

                dtgTipoProceso.Enabled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtgTipoProceso.RowCount<=0)
            {
                return;                
            }
            habilitarControles(grbDetTipoPro, true);
            var itemSelc=(clsTipoProceso)dtgTipoProceso.CurrentRow.DataBoundItem;
            pidTipoProceso = itemSelc.idTipoProceso;
            habilitarBotones(false);
            chcVigente.Enabled = true;
            dtgTipoProceso.Enabled = false;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitarControles(grbDetTipoPro, false);
            habilitarBotones(true);
            CargarTipoProceso();
            chcVigente.Enabled = false;
            chcVigente.Checked = false;
            dtgTipoProceso.Enabled = true;
            
        }
        private void habilitarBotones(bool lActivo)
        {
            btnNuevo1.Enabled=lActivo;
            btnEditar.Enabled = lActivo;
            btnGrabar.Enabled = !lActivo;
            btnCancelar.Enabled = !lActivo;
        }
    }
}
