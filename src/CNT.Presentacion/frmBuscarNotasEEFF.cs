using CNT.CapaNegocio;
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
    public partial class frmBuscarNotasEEFF : frmBase
    {
        public string idNotasEEFF="0";
        public string cNomArchivo;
        public DateTime dFecPerContable;
        public string cExtension;
        public byte[] vArchivo;
        public string cDescripcion;
        public frmBuscarNotasEEFF()
        {
            InitializeComponent();
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            clsCNProcesosAsientos clsNota = new clsCNProcesosAsientos();
            DataTable dt= clsNota.CNListarNotaEEFF(dtpDesde.Value.Date, dtpHasta.Value.Date);

            dtgListaNotas.DataSource = dt;
            formatoGridClientes();

        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (dtgListaNotas.RowCount > 0)
            {
                idNotasEEFF = dtgListaNotas.Rows[dtgListaNotas.SelectedCells[0].RowIndex].Cells["idNotasEEFF"].Value.ToString();
                cNomArchivo = dtgListaNotas.Rows[dtgListaNotas.SelectedCells[0].RowIndex].Cells["cNomArchivo"].Value.ToString();
                dFecPerContable = Convert.ToDateTime(dtgListaNotas.Rows[dtgListaNotas.SelectedCells[0].RowIndex].Cells["dFecPerContable"].Value.ToString());
                cExtension = dtgListaNotas.Rows[dtgListaNotas.SelectedCells[0].RowIndex].Cells["cExtension"].Value.ToString();
                vArchivo = (byte[])dtgListaNotas.Rows[dtgListaNotas.SelectedCells[0].RowIndex].Cells["vArchivo"].Value;
                cDescripcion = dtgListaNotas.Rows[dtgListaNotas.SelectedCells[0].RowIndex].Cells["cDescripcion"].Value.ToString();
                this.Dispose();
                
            }
         }
    
         

        private void formatoGridClientes()
        {
             dtgListaNotas.Columns["idNotasEEFF"].HeaderText = "Código";
            dtgListaNotas.Columns["nAñoContable"].HeaderText = "Años contable";
            dtgListaNotas.Columns["nMesContable"].HeaderText = "Mes contable";
            dtgListaNotas.Columns["cNomArchivo"].HeaderText="Nombre Archivo";

            dtgListaNotas.Columns["vArchivo"].Visible = false;
            dtgListaNotas.Columns["cExtension"].Visible = false;
            dtgListaNotas.Columns["dFecPerContable"].Visible = false;
            dtgListaNotas.Columns["cDescripcion"].Visible = false;
            dtgListaNotas.Columns["dFecReg"].HeaderText = "Fecha Registro";



            dtgListaNotas.Columns["idNotasEEFF"].Width = 80;
            dtgListaNotas.Columns["nAñoContable"].Width = 120;
            dtgListaNotas.Columns["nMesContable"].Width = 120;
            dtgListaNotas.Columns["cNomArchivo"].Width = 150;
            dtgListaNotas.Columns["dFecReg"].Width = 90;
        }
    }
}
