using CRE.CapaNegocio;
using EntityLayer;
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

namespace CRE.Presentacion
{
    public partial class frmListarExtComisionCartaFianza : frmBase
    {
        public int idKardexSelec { get; set; }
        public int idSolicitoAproba { get; set; }  
        clsCNCartaFianza cnCartaFianza = new clsCNCartaFianza();
        public frmListarExtComisionCartaFianza()
        {
            InitializeComponent();
            idKardexSelec = 0;
        }

        private void frmListarExtComisionCartaFianza_Load(object sender, EventArgs e)
        {
            DataTable dtExtornosAprobados = cnCartaFianza.listaExtornosAprobados(clsVarGlobal.PerfilUsu.idUsuario,clsVarGlobal.dFecSystem);
            if (dtExtornosAprobados.Rows.Count > 0)
            {
                dtgExtornosAprob.DataSource = dtExtornosAprobados;
            }
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dtgExtornosAprob_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idKardexSelec = Convert.ToInt32(dtgExtornosAprob.Rows[e.RowIndex].Cells["idKardex"].Value);
                idSolicitoAproba = Convert.ToInt32(dtgExtornosAprob.Rows[e.RowIndex].Cells["idSolAproba"].Value);
            }
        }
    }
}
