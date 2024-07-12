using EntityLayer;
using GEN.CapaNegocio;
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

namespace SolIntEls
{
    public partial class frmAlertas : frmBase
    {
        
        public frmAlertas()
        {
            InitializeComponent();
        }

        private void frmAlertas_Load(object sender, EventArgs e)
        {
            DataTable dtAlertas = new clsCNAlerta().ListarAlertas(clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
            dtgAlertas.DataSource = dtAlertas;
            formatearDTGAlertas();
        }

        private void formatearDTGAlertas()
        {
            foreach (DataGridViewColumn columna in dtgAlertas.Columns)
            {
                columna.Visible = false;
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                columna.ReadOnly = true;
            }

            dtgAlertas.Columns["dFechaRegistra"].Visible = true;
            dtgAlertas.Columns["cAlerta"].Visible = true;
            dtgAlertas.Columns["cNombreCliente"].Visible = true;
            dtgAlertas.Columns["idCli"].Visible = true;

            dtgAlertas.Columns["dFechaRegistra"].HeaderText = "Fecha registro";
            dtgAlertas.Columns["cAlerta"].HeaderText = "Alerta";
            dtgAlertas.Columns["cNombreCliente"].HeaderText = "Nombre cliente";
            dtgAlertas.Columns["idCli"].HeaderText = "Cod. cliente";

            dtgAlertas.Columns["dFechaRegistra"].Width = 50;
            dtgAlertas.Columns["idCli"].Width = 50;
            dtgAlertas.Columns["cAlerta"].Width = 180;
            dtgAlertas.Columns["cNombreCliente"].Width = 180;
            
        }
    }
}
