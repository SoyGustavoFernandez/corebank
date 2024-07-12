using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class frmSuministros : frmBase
    {
        public DataTable dtSuministros;
        public frmSuministros()
        {
            InitializeComponent();
        }

        private void frmSuministros_Load(object sender, EventArgs e)
        {
            dtgSuministros.DataSource = dtSuministros;
            FormatoGrid();
        }
        private void FormatoGrid()
        {
            dtgSuministros.Columns["idCli"].Width=30;
            dtgSuministros.Columns["cNombre"].Width=100;
            dtgSuministros.Columns["cDireccion"].Width=100;
            dtgSuministros.Columns["cCodSuministro"].Width=50;
            dtgSuministros.Columns["cReferenciaDireccion"].Width=100;
            dtgSuministros.Columns["idUbigeo"].Width = 50;

            dtgSuministros.Columns["idCli"].HeaderText ="Cod.Cli";
            dtgSuministros.Columns["cNombre"].HeaderText ="Cliente";
            dtgSuministros.Columns["cDireccion"].HeaderText ="Dirección";
            dtgSuministros.Columns["cCodSuministro"].HeaderText ="Suministro";
            dtgSuministros.Columns["cReferenciaDireccion"].HeaderText ="Referencia";
            dtgSuministros.Columns["idUbigeo"].HeaderText = "Ubigeo";
        }
    }
}
