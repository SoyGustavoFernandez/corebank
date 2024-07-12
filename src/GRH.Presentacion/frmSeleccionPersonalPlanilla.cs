using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;

namespace GRH.Presentacion
{
    public partial class frmSeleccionPersonalPlanilla : frmBase
    {
        public DataTable x_dtListadoPersonal;

        public DataTable dtNoSeleccionados;
        public DataTable dtSeleccionados;

        public frmSeleccionPersonalPlanilla()
        {
            InitializeComponent();
        }

        private void frmSeleccionPersonalPlanilla_Load(object sender, EventArgs e)
        {
            dtNoSeleccionados = x_dtListadoPersonal.Copy();
            dtgNoSeleccionados.DataSource = dtNoSeleccionados;

            dtSeleccionados = x_dtListadoPersonal.Clone();
            dtgSeleccionados.DataSource = dtSeleccionados;
        }

        private void btnAgregarTodos_Click(object sender, EventArgs e)
        {
            if (dtNoSeleccionados.Rows.Count > 0)
            {
                dtNoSeleccionados.Clear();
                dtSeleccionados.Clear();
                foreach (DataRow dr in x_dtListadoPersonal.Rows)
                {
                    dtSeleccionados.ImportRow(dr);
                }
                txtNroNoSelec.Text = dtNoSeleccionados.Rows.Count.ToString();
                txtNroSelec.Text = dtSeleccionados.Rows.Count.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dtNoSeleccionados.Rows.Count > 0)
            {
                DataRow drNuevo = dtSeleccionados.NewRow();
                drNuevo["idUsuario"] = Convert.ToInt32(dtgNoSeleccionados.CurrentRow.Cells[0].Value);
                drNuevo["idRelacionLab"] = Convert.ToInt32(dtgNoSeleccionados.CurrentRow.Cells[1].Value);
                drNuevo["cNombre"] = Convert.ToString(dtgNoSeleccionados.CurrentRow.Cells[2].Value);
                dtSeleccionados.Rows.Add(drNuevo);
                dtNoSeleccionados.Rows.RemoveAt(dtgNoSeleccionados.CurrentRow.Index);
                txtNroNoSelec.Text = dtNoSeleccionados.Rows.Count.ToString();
                txtNroSelec.Text = dtSeleccionados.Rows.Count.ToString();
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtSeleccionados.Rows.Count > 0)
            {
                DataRow drNuevo = dtNoSeleccionados.NewRow();
                drNuevo["idUsuario"] = Convert.ToInt32(dtgSeleccionados.CurrentRow.Cells[0].Value);
                drNuevo["idRelacionLab"] = Convert.ToInt32(dtgSeleccionados.CurrentRow.Cells[1].Value);
                drNuevo["cNombre"] = Convert.ToString(dtgSeleccionados.CurrentRow.Cells[2].Value);
                dtNoSeleccionados.Rows.Add(drNuevo);
                dtSeleccionados.Rows.RemoveAt(dtgSeleccionados.CurrentRow.Index);
                txtNroNoSelec.Text = dtNoSeleccionados.Rows.Count.ToString();
                txtNroSelec.Text = dtSeleccionados.Rows.Count.ToString();
            }
        }

        private void btnQuitarTodos_Click(object sender, EventArgs e)
        {
            if (dtSeleccionados.Rows.Count > 0)
            {
                dtSeleccionados.Clear();
                dtNoSeleccionados.Clear();
                foreach(DataRow dr in x_dtListadoPersonal.Rows)
                {
                    dtNoSeleccionados.ImportRow(dr);
                }
                txtNroNoSelec.Text = dtNoSeleccionados.Rows.Count.ToString();
                txtNroSelec.Text = dtSeleccionados.Rows.Count.ToString();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dtSeleccionados.Clear();
            dtNoSeleccionados.Clear();
            this.Dispose();
        }
    }
}