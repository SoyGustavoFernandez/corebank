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

namespace CNT.Presentacion
{
    public partial class frmBuscarAccionesReg : frmBase
    {
        public DataRow dtRows=null;
      
        public frmBuscarAccionesReg()
        {
            InitializeComponent();
        }
        public frmBuscarAccionesReg(DataTable dtListaAcciones)
        {
            InitializeComponent();
            dtgAccionista.DataSource = dtListaAcciones;
            dtgAccionista.Columns["idAccionista"].HeaderText = "Cod accionista";
            dtgAccionista.Columns["idCli"].Visible = false;
            dtgAccionista.Columns["cCliente"].HeaderText = "Cliente";
            //dtgAccionista.Columns["cCliente"].Width = 120;
            dtgAccionista.Columns["idTipoAccion"].Visible=false;
            dtgAccionista.Columns["cTipoAccionEmpresa"].HeaderText = "Tipo acción";
            dtgAccionista.Columns["idTipoAcciones"].Visible=false;
            dtgAccionista.Columns["cTipoAccionesEmpresa"].HeaderText = "Tipo acciones";
            dtgAccionista.Columns["nNroAcciones"].HeaderText = "Nro acciones";
            dtgAccionista.Columns["nValorNominal"].HeaderText = "Valor nominal";
            dtgAccionista.Columns["cObservacion"].Visible=false;
            dtgAccionista.Columns["nNroFolio"].HeaderText = "Nro folio";
            dtgAccionista.Columns["dFecAdquisicion"].HeaderText = "Fec. Adquisición";
            dtgAccionista.Columns["lVigente"].Visible=false;
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (dtgAccionista.RowCount > 0)
            {
                dtRows = ((DataRowView)dtgAccionista.CurrentRow.DataBoundItem).Row;
            }            
            this.Dispose();
        }

        private void frmBuscarAccionesReg_Load(object sender, EventArgs e)
        {

        }
    }
}
