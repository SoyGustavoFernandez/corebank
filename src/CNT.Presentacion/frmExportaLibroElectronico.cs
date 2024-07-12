using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using CNT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNT.Presentacion
{
    public partial class frmExportaLibroElectronico : frmBase
    {

        public frmExportaLibroElectronico()
        {
            InitializeComponent();
           
            DataTable dtReportes = new clsCNAsiento().CNListaLESBS();
            dtgListaReporte.DataSource = dtReportes;
        }

        private void frmExportaLibroElectronico_Load(object sender, EventArgs e)
        {
            this.dtpFecFin.Value = clsVarGlobal.dFecSystem;            
        }

        private void dtgListaReporte_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string cCodigoLibro = Convert.ToString(dtgListaReporte.CurrentRow.Cells["cCodLibroSBS"].Value);
            string cNombreSp = Convert.ToString(dtgListaReporte.CurrentRow.Cells["cNombreSp"].Value);
            string cNombreTxt = Convert.ToString(dtgListaReporte.CurrentRow.Cells["cNombreLibroTxt"].Value);
            
            if (dtgListaReporte.Columns[e.ColumnIndex].CellType == typeof(DataGridViewButtonCell) && Convert.ToInt32(dtgListaReporte.Columns[e.ColumnIndex].DisplayIndex) == 4)
            {

                Procesa(cCodigoLibro, cNombreSp, cNombreTxt);
             }
           
        }

        private void Procesa(string cCodigoLibro, string cNombreSp, string cNombreTxt)
        {
           
            Cursor.Current = Cursors.WaitCursor;
            if (!Validar())
            {
                return;
            }
            DateTime dFecFin = dtpFecFin.Value;
            int idMoneda = 1;
            DataTable dtLibro = new clsCNAsiento().CNPLELibroGeneralInvBal(dFecFin, cNombreSp);
            DialogResult result;
            result = folderBrowserDialog1.ShowDialog();
            string cRuta;
            string cNomArc;

            if (result == DialogResult.OK)
            {
                cRuta = folderBrowserDialog1.SelectedPath;
                cNomArc = cRuta + "\\" + new clsCNAsiento().cNomArcPLELibro(idMoneda.ToString(), dFecFin, cCodigoLibro, dtLibro.Rows.Count);
                new clsCNAsiento().ExportarArchivo(dtLibro, @cNomArc);
                MessageBox.Show("El archivo " + cNomArc + " se generó correctamente", "PLE - Libro", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            Cursor.Current = Cursors.Default;
        }
        Boolean Validar()
        {
            if (clsVarGlobal.dFecSystem < this.dtpFecFin.Value.Date)
            {
                MessageBox.Show("La Fecha Final debe ser mayor o igual a la Fecha inicial");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
