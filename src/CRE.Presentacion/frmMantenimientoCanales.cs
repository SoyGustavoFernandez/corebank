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
    public partial class frmMantenimientoCanales : frmBase
    {
        private clsCNMantenimientoCanales clsMantenimientoCanales = new clsCNMantenimientoCanales();

        public frmMantenimientoCanales()
        {
            InitializeComponent();
        }

        private void frmMantenimientoCanales_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (DtgMantenimientoCanales.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un Canal para editar", "Validación Mantenimiento Canales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else {              
                int idCanal = Convert.ToInt32(DtgMantenimientoCanales.CurrentRow.Cells[0].Value);
                string cDescripcion = DtgMantenimientoCanales.CurrentRow.Cells[1].Value.ToString();
                bool lInterno = Convert.ToBoolean(DtgMantenimientoCanales.CurrentRow.Cells[2].Value);
                bool lActivo = Convert.ToBoolean(DtgMantenimientoCanales.CurrentRow.Cells[3].Value);
               
                frmRegistroCanales frmCanales = new frmRegistroCanales(idCanal, cDescripcion, lInterno, lActivo);
                frmCanales.objFrmSemaforo = this.objFrmSemaforo;
                frmCanales.ShowDialog();
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            DtgMantenimientoCanales.DataSource = clsMantenimientoCanales.ListaMantenimientoCanales(0);
            FormatoMantenimientoCanales();
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            frmRegistroCanales frmCanales = new frmRegistroCanales();
            frmCanales.objFrmSemaforo = this.objFrmSemaforo;
            frmCanales.ShowDialog();
            CargarDatos();
        }

        private void FormatoMantenimientoCanales()
        {
            foreach (DataGridViewColumn item in DtgMantenimientoCanales.Columns)
            {
                item.Visible = true;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            DtgMantenimientoCanales.Columns["idCanal"].HeaderText = "Cod. Canal";
            DtgMantenimientoCanales.Columns["cDescripcion"].HeaderText = "Nombre Canal";
            DtgMantenimientoCanales.Columns["lInterno"].HeaderText = "Interno";
            DtgMantenimientoCanales.Columns["lActivo"].HeaderText = "Activo";

            DtgMantenimientoCanales.Columns["idCanal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
