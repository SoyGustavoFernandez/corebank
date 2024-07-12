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
using LOG.CapaNegocio;
using EntityLayer;

namespace LOG.Presentacion
{
    public partial class frmBuscarRecepcionPropuesta : frmBase
    {

        clsCNProcesoAdjudicacion objProAdj = new clsCNProcesoAdjudicacion();
        //int nOper = 1;
        string msgBox = "Proceso de Adjudicación";
        public int idProcesoAdj = 0;
        public bool lAcepta = false;
        public frmBuscarRecepcionPropuesta()
        {
            InitializeComponent();
        }

        private void frmBuscarRecepcionPropuesta_Load(object sender, EventArgs e)
        {
            
            habilitarControles();
            rbtProcesoAdj.Checked = true;
        }

        public void cargarEstadoProcLog()
        {
            DataTable dtEstProcAdj = objProAdj.CNCargarEstProcAdj();
            cboEstadoProcLog.DataSource = dtEstProcAdj;

            cboEstadoProcLog.ValueMember = "idEstadoLog";
            cboEstadoProcLog.DisplayMember = "cNombre";
        }

        public void habilitarControles()
        {
            limpiar();
            if (rbtProcesoAdj.Checked)
            {
                txtNroProcesoAdj.Enabled = true;
                cboEstadoProcLog.Enabled = false;
                dFechaIni.Enabled = false;
                dFechaFin.Enabled = false;
            }
            if (rbtEstado.Checked)
            {
                txtNroProcesoAdj.Enabled = false;
                cboEstadoProcLog.Enabled = true;
                dFechaIni.Enabled = false;
                dFechaFin.Enabled = false;
                cargarEstadoProcLog();
            }
            if (rbtFecha.Checked)
            {
                txtNroProcesoAdj.Enabled = false;
                cboEstadoProcLog.Enabled = false;
                dFechaIni.Enabled = true;
                dFechaFin.Enabled = true;
            }
        }

        public void limpiar()
        {
            txtNroProcesoAdj.Text = String.Empty;
            cboEstadoProcLog.SelectedIndex = -1;
            dFechaIni.Value = clsVarGlobal.dFecSystem;
            dFechaFin.Value = clsVarGlobal.dFecSystem;
            //dtgProcesoAdj.DataSource = null;
            dtgProcesoAdj.DataBindings.Clear();
        }

        public void rbtProcesoAdj_CheckedChanged(object sender, EventArgs e)
        {
            
            habilitarControles();
        }

        public void rbtEstado_CheckedChanged(object sender, EventArgs e)
        {
            
            habilitarControles();
        }

        public void rbtFecha_CheckedChanged(object sender, EventArgs e)
        {
            
            habilitarControles();
        }

        public void btnBusqueda_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }
            int idProceso = 0; 
            int idEstProAdj = 0;
            DateTime dFechIni = clsVarGlobal.dFecSystem;
            DateTime dFechFin = clsVarGlobal.dFecSystem;
            DataTable dtProcAdj = new DataTable();
            if(rbtProcesoAdj.Checked)
            {
                idProceso = Convert.ToInt32(txtNroProcesoAdj.Text);
                dtProcAdj = objProAdj.CNBuscarFrmProcAdj(idProceso, dFechIni, dFechFin, idEstProAdj, 1);
            }
            if (rbtEstado.Checked)
            {
                idEstProAdj = (int)cboEstadoProcLog.SelectedValue;
                dtProcAdj = objProAdj.CNBuscarFrmProcAdj(idProceso, dFechIni, dFechFin, idEstProAdj, 2);
            }
            if (rbtFecha.Checked)
            {
                dFechIni = dFechaIni.Value;
                dFechFin = dFechaFin.Value;
                dtProcAdj = objProAdj.CNBuscarFrmProcAdj(idProceso, dFechIni, dFechFin, idEstProAdj, 3);
            }
            dtgProcesoAdj.DataSource = dtProcAdj;
            
        }

        public Boolean validar()
        {
            if (rbtProcesoAdj.Checked)
            { 
                if(String.IsNullOrEmpty(txtNroProcesoAdj.Text))
                {
                    MessageBox.Show("Ingrese el número del proceso",msgBox,MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNroProcesoAdj.Focus();
                    return false;
                }
            }
            if (rbtEstado.Checked)
            {
                if (cboEstadoProcLog.SelectedIndex < -1)
                {
                    MessageBox.Show("Seleccione un estado del Proceso de Adjudicación", msgBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboEstadoProcLog.Focus();
                    return false;
                }
            }
            if (rbtFecha.Checked)
            {
                DateTime fIni = dFechaIni.Value;
                DateTime fFin = dFechaFin.Value;
                TimeSpan d = fFin - fIni;
                if (dFechaFin.Value == clsVarGlobal.dFecSystem)
                {
                    return false;
                }
                else {
                    if (Convert.ToInt32(d.Days) < 0)
                    {
                        MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final", msgBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dFechaIni.Value = clsVarGlobal.dFecSystem;
                        dFechaFin.Value = clsVarGlobal.dFecSystem;
                        dFechaIni.Focus();
                        return false;
                    }
                }

            }
            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            //int cIndex = dtgProcesoAdj.CurrentCell.ColumnIndex;
            if (dtgProcesoAdj.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un Proceso de Adjudicación", "Buscar Proceso Adjudicación", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                return;
            }
            else {
                int rIndex = dtgProcesoAdj.CurrentCell.RowIndex;
                idProcesoAdj = Convert.ToInt32(dtgProcesoAdj.Rows[rIndex].Cells[0].Value.ToString());
                lAcepta = true;
                this.Dispose();
            }           
       }
    }
}
