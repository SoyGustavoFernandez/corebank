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
using CRE.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;

namespace RCP.Presentacion
{
    public partial class frmTrasCarteraRecupera : frmBase
    {
        CRE.CapaNegocio.clsCNCredito credito = new CRE.CapaNegocio.clsCNCredito();
        clsCNListaCargoPersonal cargopersonal = new clsCNListaCargoPersonal();

        public frmTrasCarteraRecupera()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EntityLayer.EventoFormulario.INICIO);
            cargarGestoresRecupera();
            cargarCreditosOrigen();
            cargarGestoresDest();

        }

        private void cargarGestoresRecupera()
        {
            cboRecupOri.cargarPersonal("nCargosRecuperadores", Convert.ToInt32(cboAgenciasOri.SelectedValue));
        }

        private void cargarGestoresDest()
        {
            cboRecupDes.cargarPersonal("nCargosRecuperadores", Convert.ToInt32(cboAgenciasDes.SelectedValue));
        }

        private bool validar()
        {
            bool lVal = false;

            lVal = true;
            return lVal;
        }

        private void formatoGrid()
        {

        }

        private void limpiarControles()
        {

        }

        private void habiitarControles()
        {

        }

        private void cboAgenciasOri_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGestoresRecupera();
        }

        private void cboAgenciasDes_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGestoresDest();
        }

        private void cargarCreditosOrigen()
        {
            if (cboRecupOri.SelectedValue != null && !(cboRecupOri.SelectedValue is DataRowView))
            {
                var dtUpd = credito.LisCreByAna(Convert.ToInt32(cboRecupOri.SelectedValue));
                if (dtUpd.Rows.Count > 0)
                {
                    dtUpd.Columns["lSeleCta"].ReadOnly = false;
                    dtgCreOri.DataSource = dtUpd;
                    foreach (DataGridViewColumn item in dtgCreOri.Columns)
                    {
                        item.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
            }
            else
            {
                dtgCreOri.DataSource = null;
            }
            lblBase1.Text = dtgCreOri.Rows.Count.ToString() + " Créditos.";
        }

        private void cargarCreditosDestino()
        {
            if (cboRecupDes.SelectedValue != null && !(cboRecupDes.SelectedValue is DataRowView))
            {
                var dtUpd = credito.LisCreByAna(Convert.ToInt32(cboRecupDes.SelectedValue));
                if (dtUpd.Rows.Count > 0)
                {
                    dtgCreDes.DataSource = dtUpd;
                    foreach (DataGridViewColumn item in dtgCreDes.Columns)
                    {
                        item.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
            }
            else
            {
                dtgCreDes.DataSource = null;
            }
            lblBase2.Text = dtgCreDes.Rows.Count.ToString() + " Créditos.";
        }

        private void cboRecuperadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCreditosOrigen();
        }

        private void chcTodos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dtgCreOri.Rows)
            {
                row.Cells["lSeleCta"].Value = chcTodos.Checked;
            }
        }

        private void cboRecupDes_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCreditosDestino();
        }
    }
}
