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
using DEP.CapaNegocio;
using EntityLayer;
namespace GEN.ControlesBase
{
    public partial class frmListaValoradosAsignados : frmBase
    {
        public int idValorado, nSerie, nInicio, nFin, idTipoValorado,
                   idMoneda, nEstadoVal, nOrden;

        public frmListaValoradosAsignados()
        {
            InitializeComponent();
        }
        private void BuscarValorados(int nEstadoVal)
        {
            clsCNValorados ObjVal = new clsCNValorados();
            DataTable dt ;
            if (nEstadoVal==1)//Lista Valores Asignados a Agencia, pendientes de generar
	        {
		        dt = ObjVal.CNListaValAsigAge(clsVarGlobal.nIdAgencia);
	        }
            else//Lista Valorados Generados, pendientes a vincular
	        {
                dt=ObjVal.CNListaValGenAge(clsVarGlobal.nIdAgencia,idMoneda,idValorado);
	        }
           
            this.dtgValAsigAge.DataSource = dt;
            this.FormatoGrid();
        }

        private void frmListaValoradosAsignados_Load(object sender, EventArgs e)
        {
            this.BuscarValorados(nEstadoVal);
        }
        private void FormatoGrid()
        {
                this.dtgValAsigAge.Columns["idValorado"].Visible = false;
                this.dtgValAsigAge.Columns["idTipoValorado"].Visible = false;
                this.dtgValAsigAge.Columns["idValorado"].Visible = false;
                this.dtgValAsigAge.Columns["idMoneda"].Visible = false;
                this.dtgValAsigAge.Columns["idMoneda"].Visible = false;
                this.dtgValAsigAge.Columns["idMoneda"].Visible = false;
                this.dtgValAsigAge.Columns["cNomCorto"].Visible = false;
                this.dtgValAsigAge.Columns["cNombreAge"].Visible = false;

                this.dtgValAsigAge.Columns["Row"].HeaderText = "Nro";
                this.dtgValAsigAge.Columns["nSerie"].HeaderText = "Serie";
                this.dtgValAsigAge.Columns["nInicio"].HeaderText = "Ini.Serie";
                this.dtgValAsigAge.Columns["nFin"].HeaderText = "Fin.Serie";
                this.dtgValAsigAge.Columns["cMoneda"].HeaderText = "Moneda";
                this.dtgValAsigAge.Columns["cNomCorto"].HeaderText = "Tipo.Val";
            
                this.dtgValAsigAge.Columns["Row"].Width = 25;
                this.dtgValAsigAge.Columns["nSerie"].Width = 80;
                this.dtgValAsigAge.Columns["nInicio"].Width = 80;
                this.dtgValAsigAge.Columns["nFin"].Width=80;
                this.dtgValAsigAge.Columns["cMoneda"].Width = 80;
                this.dtgValAsigAge.Columns["cValorado"].Width = 100;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            this.Aceptar();
        }
        private void Aceptar()
        {
            if (dtgValAsigAge.Rows.Count > 0)
            {
                nOrden=Convert.ToInt32(this.dtgValAsigAge.Rows[dtgValAsigAge.SelectedCells[0].RowIndex].Cells["Row"].Value); 
                idValorado = (int)this.dtgValAsigAge.Rows[dtgValAsigAge.SelectedCells[0].RowIndex].Cells["idValorado"].Value;
                nSerie = Convert.ToInt32(this.dtgValAsigAge.Rows[dtgValAsigAge.SelectedCells[0].RowIndex].Cells["nSerie"].Value);
                nInicio = Convert.ToInt32(this.dtgValAsigAge.Rows[dtgValAsigAge.SelectedCells[0].RowIndex].Cells["nInicio"].Value);
                nFin = Convert.ToInt32(this.dtgValAsigAge.Rows[dtgValAsigAge.SelectedCells[0].RowIndex].Cells["nFin"].Value);
                idTipoValorado = (int)this.dtgValAsigAge.Rows[dtgValAsigAge.SelectedCells[0].RowIndex].Cells["idTipoValorado"].Value;
                idMoneda = (int)this.dtgValAsigAge.Rows[dtgValAsigAge.SelectedCells[0].RowIndex].Cells["idMoneda"].Value;
            }
            else
            {
                nOrden = 0;
                idValorado = 0;
                nSerie = 0;
                nInicio = 0;
                nFin = 0;
                idTipoValorado = 0;
                idMoneda = 0;
            }
            this.Dispose();
        }

        private void dtgValAsigAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                this.Aceptar();
            }
        }

        private void dtgValAsigAge_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Aceptar();
        }

        private void dtgValAsigAge_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Aceptar();
        }
    }
}
