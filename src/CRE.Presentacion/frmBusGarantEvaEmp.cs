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
using CRE.CapaNegocio;
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class frmBusGarantEvaEmp : frmBase
    {
        clsCNGarantia objGar = new clsCNGarantia();
        clsListGarantia lstGarantias = new clsListGarantia();
        public clsGarantia itemGarantia;
        
        public frmBusGarantEvaEmp()
        {
            InitializeComponent();
        }

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            lstGarantias = objGar.listarGarantias(Convert.ToInt32(conBusCli.txtCodCli.Text));
            dtgGarantias.DataSource = lstGarantias;

            FormatDataGridView();
            conBusCli.txtCodCli.Enabled = true;
        }

        private void FormatDataGridView()
        {
            dtgGarantias.Columns["idGarantia"].Visible = true;
            dtgGarantias.Columns["cGarantia"].Visible = true;
            dtgGarantias.Columns["idTipoGarantia"].Visible = false;
            dtgGarantias.Columns["idClaseGarantia"].Visible = false;
            dtgGarantias.Columns["idMoneda"].Visible = false;
            dtgGarantias.Columns["idEstado"].Visible = false;
            dtgGarantias.Columns["dFecRegistro"].Visible = false;
            dtgGarantias.Columns["nTipoCambio"].Visible = false;
            dtgGarantias.Columns["nMonGarantia"].Visible = true;
            dtgGarantias.Columns["nValorComercial"].Visible = true;
            dtgGarantias.Columns["nValorMercado"].Visible = true;
            dtgGarantias.Columns["nValorEdifica"].Visible = true;
            dtgGarantias.Columns["nValorNuevo"].Visible = true;
            dtgGarantias.Columns["nValorRealiza"].Visible = true;
            dtgGarantias.Columns["cDesObserva"].Visible = true;
            dtgGarantias.Columns["idUbigeo"].Visible = false;
            dtgGarantias.Columns["cDireccion"].Visible = true;
            dtgGarantias.Columns["cReferencia"].Visible = false;
            dtgGarantias.Columns["nMonGravamen"].Visible = true;

            dtgGarantias.Columns["idGrupoGarantia"].Visible = false;
            dtgGarantias.Columns["nValorVenta"].Visible = false;
            dtgGarantias.Columns["lIndSabana"].Visible = false;
            dtgGarantias.Columns["lIndPriVenta"].Visible = false;

            dtgGarantias.Columns["idGarantia"].HeaderText = "N° Garantía";
            dtgGarantias.Columns["cGarantia"].HeaderText = "Descripción";
            dtgGarantias.Columns["nMonGarantia"].HeaderText = "Mont. Garantía";
            dtgGarantias.Columns["nValorComercial"].HeaderText = "Val. Comerc.";
            dtgGarantias.Columns["nValorMercado"].HeaderText = "Val. Mercado";
            dtgGarantias.Columns["nValorEdifica"].HeaderText = "Val. Edifica";
            dtgGarantias.Columns["nValorNuevo"].HeaderText = "Val. Nuevo";
            dtgGarantias.Columns["nValorRealiza"].HeaderText = "Val. Realiza.";
            dtgGarantias.Columns["cDesObserva"].HeaderText = "Observaciones";
            dtgGarantias.Columns["cDireccion"].HeaderText = "Dirección";
            dtgGarantias.Columns["nMonGravamen"].HeaderText = "Mont. Gravamen";

            dtgGarantias.Columns["idGarantia"].FillWeight = 40;
            dtgGarantias.Columns["cGarantia"].FillWeight = 60;
            dtgGarantias.Columns["cDireccion"].FillWeight = 60;
            dtgGarantias.Columns["cDesObserva"].FillWeight = 60;
            dtgGarantias.Columns["nMonGarantia"].FillWeight = 40;
            dtgGarantias.Columns["nValorComercial"].FillWeight = 40;
            dtgGarantias.Columns["nValorMercado"].FillWeight = 40;
            dtgGarantias.Columns["nValorEdifica"].FillWeight = 40;
            dtgGarantias.Columns["nValorNuevo"].FillWeight = 40;
            dtgGarantias.Columns["nValorRealiza"].FillWeight = 40;
            dtgGarantias.Columns["nMonGravamen"].FillWeight = 40;

            dtgGarantias.Columns["idGarantia"].DisplayIndex = 0;
            dtgGarantias.Columns["cGarantia"].DisplayIndex = 1;
            dtgGarantias.Columns["cDireccion"].DisplayIndex = 2;
            dtgGarantias.Columns["cDesObserva"].DisplayIndex = 3;            
            dtgGarantias.Columns["nMonGarantia"].DisplayIndex = 4;
            dtgGarantias.Columns["nValorComercial"].DisplayIndex = 5;
            dtgGarantias.Columns["nValorMercado"].DisplayIndex = 6;
            dtgGarantias.Columns["nValorEdifica"].DisplayIndex = 7;
            dtgGarantias.Columns["nValorNuevo"].DisplayIndex = 8;
            dtgGarantias.Columns["nValorRealiza"].DisplayIndex = 9;            
            dtgGarantias.Columns["nMonGravamen"].DisplayIndex = 10;
        }

        private void Aceptar()
        {
            if (dtgGarantias.SelectedRows.Count > 0)
            {
                itemGarantia = (clsGarantia)dtgGarantias.CurrentRow.DataBoundItem;
            }
            else
            {
                MessageBox.Show("No selecciono niguna garantia.Seleccione una garantia.", "Buscar Garantias Evaluacion Empresarial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtgGarantias.Focus();
                return;
            }
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void dtgGarantias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Aceptar();
            }
        }
    }
}
