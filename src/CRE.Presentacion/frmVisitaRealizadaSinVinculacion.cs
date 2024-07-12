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
using GEN.CapaNegocio;
using EntityLayer;
using System.Data;
using GEN.Funciones;

namespace CRE.Presentacion
{
    public partial class frmVisitaRealizadaSinVinculacion : frmBase
    {
        List<clsVisita> lista;
        clsCNVisitas objVisita;
        BindingSource bs;
        public clsVisita objSel; 
        int idCli = 0;

        public frmVisitaRealizadaSinVinculacion(int _idCli)
        {
            InitializeComponent();
            this.objVisita = new clsCNVisitas();
            this.idCli = _idCli;
            this.bs = new BindingSource();
        }

        private void frmVisitaRealizadaSinVinculacion_Load(object sender, EventArgs e)
        {
            DataTable dtRes = this.objVisita.CNWSListarVisita(clsVarGlobal.User.idUsuario, this.idCli, EstadoVisita.VISITADO);
            this.lista = dtRes.ToList<clsVisita>().ToList();
            this.bs.DataSource = lista;
            this.dtgVisitas.DataSource = bs;
            this.formatoGrid();
        }

        #region Public
        #endregion

        #region Private

        private void formatoGrid()
        {
            foreach (DataGridViewColumn item in dtgVisitas.Columns)
            {
                item.Visible = false;
            }

            dtgVisitas.Columns["idVisita"].Visible = true;
            dtgVisitas.Columns["idCliente"].Visible = true;
            dtgVisitas.Columns["cNombre"].Visible = true;
            dtgVisitas.Columns["cDireccion"].Visible = true;
            dtgVisitas.Columns["cObservacion"].Visible = true;

            dtgVisitas.Columns["idVisita"].HeaderText = "Nro. Visita";
            dtgVisitas.Columns["idCliente"].HeaderText = "Nro. Cli";
            dtgVisitas.Columns["cNombre"].HeaderText = "Nombres";
            dtgVisitas.Columns["cDireccion"].HeaderText = "Dirección";
            dtgVisitas.Columns["cObservacion"].HeaderText = "Comentario";

            dtgVisitas.Columns["idVisita"].DisplayIndex = 0;
            dtgVisitas.Columns["idCliente"].DisplayIndex = 1;
            dtgVisitas.Columns["cNombre"].DisplayIndex = 2;
            dtgVisitas.Columns["cDireccion"].DisplayIndex = 3;
            dtgVisitas.Columns["cObservacion"].DisplayIndex = 4;
        }
        #endregion

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (dtgVisitas.RowCount == 0)
                return;

            objSel = new clsVisita();
            objSel = (clsVisita)dtgVisitas.SelectedRows[0].DataBoundItem;
            this.Dispose();
        }

        private void btnDetalle1_Click(object sender, EventArgs e)
        {
            if (dtgVisitas.RowCount == 0)
                return;

            clsVisita obj = new clsVisita();
            obj = (clsVisita)dtgVisitas.SelectedRows[0].DataBoundItem;
            frmVisita frmVisita = new frmVisita(obj.idVisita, 0);
            frmVisita.ShowDialog();
        }

        private void btnAceptar2_Click(object sender, EventArgs e)
        {
            if (dtgVisitas.RowCount == 0)
                return;

            objSel = new clsVisita();
            objSel = (clsVisita)dtgVisitas.SelectedRows[0].DataBoundItem;
            this.Dispose();
        }

        private void btnDetalle2_Click(object sender, EventArgs e)
        {
            if (dtgVisitas.RowCount == 0)
                return;

            clsVisita obj = new clsVisita();
            obj = (clsVisita)dtgVisitas.SelectedRows[0].DataBoundItem;
            frmVisita frmVisita = new frmVisita(obj.idVisita, 0);
            frmVisita.ShowDialog();
        }
    }
}
