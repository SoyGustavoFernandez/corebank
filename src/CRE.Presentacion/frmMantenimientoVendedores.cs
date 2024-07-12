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
    public partial class frmMantenimientoVendedores : frmBase
    {
        private clsCNMantenimientoCanales clsMantenimientoVendedores = new clsCNMantenimientoCanales();

        public frmMantenimientoVendedores()
        {
            InitializeComponent();
        }

        private void frmMantenimientoVendedores_Load(object sender, EventArgs e)
        {
            CargarDatos();
            cboCanalVendedor1.listapromotores();
            cboCanalVendedor1.SelectedValue = 0;
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (dtgMantenimientoVendedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un Canal para editar", "Validación Mantenimiento Canales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int idVendedor = Convert.ToInt32(dtgMantenimientoVendedores.CurrentRow.Cells[0].Value);
                int nCodCanal = Convert.ToInt32(dtgMantenimientoVendedores.CurrentRow.Cells[1].Value);
                int idUsuario = Convert.ToInt32(dtgMantenimientoVendedores.CurrentRow.Cells[3].Value);
                string cNombreVendedor = dtgMantenimientoVendedores.CurrentRow.Cells[4].Value.ToString();
                int idRegion = Convert.ToInt32(dtgMantenimientoVendedores.CurrentRow.Cells[5].Value);
                int idOficina = Convert.ToInt32(dtgMantenimientoVendedores.CurrentRow.Cells[7].Value);
                string cNombreCorto = dtgMantenimientoVendedores.CurrentRow.Cells[9].Value.ToString();
                bool lActivo = Convert.ToBoolean(dtgMantenimientoVendedores.CurrentRow.Cells[10].Value);

                frmRegistroVendedores frmVendedores = new frmRegistroVendedores(idVendedor,nCodCanal,idUsuario,cNombreVendedor, idRegion, idOficina, cNombreCorto, lActivo);
                frmVendedores.objFrmSemaforo = this.objFrmSemaforo;
                frmVendedores.ShowDialog();
                CargarDatos();
            }
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            frmRegistroVendedores frmVendedores = new frmRegistroVendedores();
            frmVendedores.objFrmSemaforo = this.objFrmSemaforo;
            frmVendedores.ShowDialog();
            CargarDatos();
        }

        private void CargarDatos() {
            int idCodCanal = Convert.ToInt32(cboCanalVendedor1.SelectedValue);
            if (idCodCanal == 0)
            {
                dtgMantenimientoVendedores.DataSource = clsMantenimientoVendedores.ListaMantenimientoVendedores(0, 0);
            }
            else
            {
                dtgMantenimientoVendedores.DataSource = clsMantenimientoVendedores.ListaMantenimientoVendedores(1, idCodCanal);
            }
            FormatoMantenimientoVendedores();
        }

        private void cboCanalVendedor1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void FormatoMantenimientoVendedores() 
        {
            foreach (DataGridViewColumn item in dtgMantenimientoVendedores.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgMantenimientoVendedores.Columns["idVendedor"].Visible = false;
            dtgMantenimientoVendedores.Columns["idCanal"].Visible = true;
            dtgMantenimientoVendedores.Columns["cDescripcion"].Visible = true;
            dtgMantenimientoVendedores.Columns["idUsuario"].Visible = true;
            dtgMantenimientoVendedores.Columns["cNombreVendedor"].Visible = true;
            dtgMantenimientoVendedores.Columns["idRegion"].Visible = false;
            dtgMantenimientoVendedores.Columns["cDesZona"].Visible = true;
            dtgMantenimientoVendedores.Columns["idOficina"].Visible = false;
            dtgMantenimientoVendedores.Columns["cNombreAge"].Visible = true;
            dtgMantenimientoVendedores.Columns["cNombreCorto"].Visible = true;
            dtgMantenimientoVendedores.Columns["lActivo"].Visible = true;

            dtgMantenimientoVendedores.Columns["idCanal"].HeaderText = "Cod. Canal";
            dtgMantenimientoVendedores.Columns["cDescripcion"].HeaderText = "Nombre Canal";
            dtgMantenimientoVendedores.Columns["idUsuario"].HeaderText = "idUsuario";
            dtgMantenimientoVendedores.Columns["cNombreVendedor"].HeaderText = "Nomb. Vendedor";
            dtgMantenimientoVendedores.Columns["cDesZona"].HeaderText = "Región";
            dtgMantenimientoVendedores.Columns["cNombreAge"].HeaderText = "Agencia";
            dtgMantenimientoVendedores.Columns["cNombreCorto"].HeaderText = "Nomb. Corto";
            dtgMantenimientoVendedores.Columns["lActivo"].HeaderText = "Activo";

            dtgMantenimientoVendedores.Columns["idCanal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgMantenimientoVendedores.Columns["idUsuario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgMantenimientoVendedores.Columns["cNombreCorto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgMantenimientoVendedores.Columns["lActivo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgMantenimientoVendedores.Columns["idCanal"].FillWeight = 70;
            dtgMantenimientoVendedores.Columns["idUsuario"].FillWeight = 70;
            dtgMantenimientoVendedores.Columns["cNombreCorto"].FillWeight = 80;
            dtgMantenimientoVendedores.Columns["lActivo"].FillWeight = 70;
        }
    }
}
