using EntityLayer;
using GEN.ControlesBase;
using CNE.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNE.Presentacion
{
    public partial class frmPDPGestionarReversa : frmBase
    {
        clsCNPdp cnObjectPdp = new clsCNPdp();
        frmPDPGestionarReversaDialog objPDPGestionarReversaDialog = new frmPDPGestionarReversaDialog();

        public frmPDPGestionarReversa()
        {
            InitializeComponent();
            InicializarFechas();
        }

        public void InicializarFechas()
        {
            this.dtpFechaInicio1.Value = clsVarGlobal.dFecSystem.Date;
            this.dtpFechaFin1.Value = clsVarGlobal.dFecSystem.Date;
            this.dtpFechaInicio2.Value = clsVarGlobal.dFecSystem.Date;
            this.dtpFechaFin2.Value = clsVarGlobal.dFecSystem.Date;
            this.dtpFechaInicio3.Value = clsVarGlobal.dFecSystem.Date;
            this.dtpFechaFin3.Value = clsVarGlobal.dFecSystem.Date;
        }

        private void btnConsultar1_Click(object sender, EventArgs e)
        {
            if (this.dtpFechaInicio1.Value.Date > this.dtpFechaFin1.Value.Date)
            {
                MessageBox.Show("La Fecha Inicial no puede ser mayor a la Fecha Final", "Gestionar Reversa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }            

            int nModalidad = 1;
            DateTime dFechaInicial = this.dtpFechaInicio1.Value.Date;
            DateTime dFechaFinal = this.dtpFechaFin1.Value.Date;       

            DataTable dt = new DataTable();
            dt = cnObjectPdp.ListarDepRevParaGenValEnv(nModalidad, dFechaInicial, dFechaFinal);            
            
            this.dtgConsultarReversa.DataSource = dt;                   
        }

        private void btnConsultar2_Click(object sender, EventArgs e)
        {
            if (this.dtpFechaInicio2.Value.Date > this.dtpFechaFin2.Value.Date)
            {
                MessageBox.Show("La Fecha Inicial no puede ser mayor a la Fecha Final", "Gestionar Reversa", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            int nModalidad = 2;
            DateTime dFechaInicial = this.dtpFechaInicio2.Value.Date;
            DateTime dFechaFinal = this.dtpFechaFin2.Value.Date;

            DataTable dt = new DataTable();
            dt = cnObjectPdp.ListarDepRevParaGenValEnv(nModalidad, dFechaInicial, dFechaFinal);

            this.dtgValidarReversa.DataSource = dt;
        }

        private void btnConsultar3_Click(object sender, EventArgs e)
        {
            if (this.dtpFechaInicio3.Value.Date > this.dtpFechaFin3.Value.Date)
            {
                MessageBox.Show("La Fecha Inicial no puede ser mayor a la Fecha Final", "Gestionar Reversa", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            int nModalidad = 3;
            DateTime dFechaInicial = this.dtpFechaInicio3.Value.Date;
            DateTime dFechaFinal = this.dtpFechaFin3.Value.Date;

            DataTable dt = new DataTable();
            dt = cnObjectPdp.ListarDepRevParaGenValEnv(nModalidad, dFechaInicial, dFechaFinal);            

            dt.Columns["lCheck"].ReadOnly = false;
            dt.Columns["lCheck"].AllowDBNull = true;

            this.dtgEnviarReversa.DataSource = dt;
            this.dtgEnviarReversa.Refresh();

            this.dtgEnviarReversa.ReadOnly = false;
            this.dtgEnviarReversa.Columns["idSetRevDep3"].ReadOnly = true;
            this.dtgEnviarReversa.Columns["dFechaProc3"].ReadOnly = true;
            this.dtgEnviarReversa.Columns["cFechaHoraTransaccion3"].ReadOnly = true;
            this.dtgEnviarReversa.Columns["cEmisorCorto3"].ReadOnly = true;
            this.dtgEnviarReversa.Columns["cReceptorOriginal3"].ReadOnly = true;
            this.dtgEnviarReversa.Columns["nMontoOriginal3"].ReadOnly = true;
            this.dtgEnviarReversa.Columns["idPDPEstado3"].ReadOnly = true;
            this.dtgEnviarReversa.Columns["cEstado3"].ReadOnly = true;
            this.dtgEnviarReversa.Columns["cIdTransaccion3"].ReadOnly = true;
            this.dtgEnviarReversa.Columns["cWinUser3"].ReadOnly = true;
            this.dtgEnviarReversa.Columns["dFechaHoraAct3"].ReadOnly = true;
            this.dtgEnviarReversa.Columns["dFechaEstTrans3"].ReadOnly = true;
            this.dtgEnviarReversa.Columns["cComentario3"].ReadOnly = true;
        }

        private void btnExporExcel_Click(object sender, EventArgs e)
        {

        }

        private void dtgConsultarReversa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgConsultarReversa.Columns[e.ColumnIndex].Name == "cAccion11" && e.RowIndex >= 0 && this.dtgConsultarReversa.Rows[e.RowIndex].Cells["idSetRevDep1"].Value.ToString() == "")
            {
                int idPDPSetDep = (int)this.dtgConsultarReversa.Rows[e.RowIndex].Cells["idPDPSetDep1"].Value;

                this.objPDPGestionarReversaDialog = new frmPDPGestionarReversaDialog();
                this.objPDPGestionarReversaDialog.CargarComponentes(idPDPSetDep);
                this.objPDPGestionarReversaDialog.ShowDialog();

                this.btnConsultar1_Click(null, null);
            }
        }

        private void dtgConsultarReversa_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dtgConsultarReversa.Columns[e.ColumnIndex].Name == "cAccion11" && e.RowIndex >= 0)
            {                
                if (this.dtgConsultarReversa.Rows[e.RowIndex].Cells["idSetRevDep1"].Value.ToString() == "")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);                    

                    DataGridViewButtonCell celBoton = this.dtgConsultarReversa.Rows[e.RowIndex].Cells["cAccion11"] as DataGridViewButtonCell;                    
                    Icon icoAtomico1 = new Icon(Properties.Resources.icoEditar, 16, 16);
                    e.Graphics.DrawIcon(icoAtomico1, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                    this.dtgConsultarReversa.Rows[e.RowIndex].Height = icoAtomico1.Height + 6;
                    this.dtgConsultarReversa.Columns[e.ColumnIndex].Width = icoAtomico1.Width + 6;

                    e.Handled = true;
                }
                else
                {
                    var CellStyle = new DataGridViewCellStyle { Padding = new Padding(100, 0, 0, 0) };
                    this.dtgConsultarReversa.Rows[e.RowIndex].Cells["cAccion11"].Style = CellStyle;
                }
            }
        }

        private void dtgValidarReversa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgValidarReversa.Columns[e.ColumnIndex].Name == "cAccion12" && e.RowIndex >= 0 && (int)(this.dtgValidarReversa.Rows[e.RowIndex].Cells["idPDPEstado2"].Value) == 4)
            {
                int idModalidad = 2;
                int idSetRevDep = (int)this.dtgValidarReversa.Rows[e.RowIndex].Cells["idSetRevDep2"].Value;

                DialogResult dialogResult = MessageBox.Show("¿Desea confirmar validación?", "Gestionar Reversa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    cnObjectPdp.RegistrarReversa(idModalidad, idSetRevDep, clsVarGlobal.User.idUsuario, "");
                    this.btnConsultar2_Click(null, null);
                }                
            }            
        }

        private void dtgValidarReversa_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dtgValidarReversa.Columns[e.ColumnIndex].Name == "cAccion12" && e.RowIndex >= 0)
            {
                if ((int)(this.dtgValidarReversa.Rows[e.RowIndex].Cells["idPDPEstado2"].Value) == 4)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    DataGridViewButtonCell celBoton = this.dtgValidarReversa.Rows[e.RowIndex].Cells["cAccion12"] as DataGridViewButtonCell;
                    Icon icoAtomico1 = new Icon(Properties.Resources.icoEditar, 16, 16);
                    e.Graphics.DrawIcon(icoAtomico1, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                    this.dtgValidarReversa.Rows[e.RowIndex].Height = icoAtomico1.Height + 6;
                    this.dtgValidarReversa.Columns[e.ColumnIndex].Width = icoAtomico1.Width + 6;

                    e.Handled = true;
                }
                else
                {
                    var CellStyle = new DataGridViewCellStyle { Padding = new Padding(100, 0, 0, 0) };
                    this.dtgValidarReversa.Rows[e.RowIndex].Cells["cAccion12"].Style = CellStyle;
                }
            }
        }

        private void dtgEnviarReversa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (this.dtgEnviarReversa.Columns[e.ColumnIndex].Name == "cAccion13" && e.RowIndex >= 0 && (int)(this.dtgEnviarReversa.Rows[e.RowIndex].Cells["idPDPEstado3"].Value) == 5)
            {
                int idModalidad = 3;
                int idSetRevDep = (int)this.dtgEnviarReversa.Rows[e.RowIndex].Cells["idSetRevDep3"].Value;

                DialogResult dialogResult = MessageBox.Show("¿Desea confirmar envío?", "Gestionar Reversa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    cnObjectPdp.GenValEnvReversa(idModalidad, idSetRevDep, clsVarGlobal.User.idUsuario, "");
                    this.btnConsultar3_Click(null, null);
                }                
            }*/
        }

        private void dtgEnviarReversa_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dtgEnviarReversa.Columns[e.ColumnIndex].Name == "lCheck3" && e.RowIndex >= 0)
            {
                if ((int)this.dtgEnviarReversa.Rows[e.RowIndex].Cells["idPDPEstado3"].Value == 6 || (int)this.dtgEnviarReversa.Rows[e.RowIndex].Cells["idPDPEstado3"].Value == 7)
                {
                    this.dtgEnviarReversa.Rows[e.RowIndex].Cells["lCheck3"].ReadOnly = true;

                    var CellStyle = new DataGridViewCellStyle { Padding = new Padding(100, 0, 0, 0) };
                    this.dtgEnviarReversa.Rows[e.RowIndex].Cells["lCheck3"].Style = CellStyle;
                }
            }

            /*if (e.ColumnIndex >= 0 && this.dtgEnviarReversa.Columns[e.ColumnIndex].Name == "cAccion13" && e.RowIndex >= 0)
            {
                if ((int)(this.dtgEnviarReversa.Rows[e.RowIndex].Cells["idPDPEstado3"].Value) == 5)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    DataGridViewButtonCell celBoton = this.dtgEnviarReversa.Rows[e.RowIndex].Cells["cAccion13"] as DataGridViewButtonCell;
                    Icon icoAtomico1 = new Icon(Properties.Resources.icoEditar, 16, 16);
                    e.Graphics.DrawIcon(icoAtomico1, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                    this.dtgEnviarReversa.Rows[e.RowIndex].Height = icoAtomico1.Height + 6;
                    this.dtgEnviarReversa.Columns[e.ColumnIndex].Width = icoAtomico1.Width + 6;

                    e.Handled = true;
                }
                else
                {
                    var CellStyle = new DataGridViewCellStyle { Padding = new Padding(100, 0, 0, 0) };
                    this.dtgEnviarReversa.Rows[e.RowIndex].Cells["cAccion13"].Style = CellStyle;
                }
            }*/
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string idSetRevDeps = string.Empty;
            int count = 0;

            foreach (DataGridViewRow row in dtgEnviarReversa.Rows)
            {
                if (row.Cells["lCheck3"].Value != DBNull.Value && Convert.ToInt32(row.Cells["lCheck3"].Value) == 1)
                {
                    idSetRevDeps += row.Cells["idSetRevDep3"].Value.ToString() + ",";
                    count++;
                }
            }

            if (count == 0)
            {
                MessageBox.Show("Antes de proceder debe seleccionar las Reversa(s) a enviar.", "Gestionar Reversas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            idSetRevDeps = idSetRevDeps.Substring(0, idSetRevDeps.Length - 1);

            DialogResult dialogResult = MessageBox.Show("¿Esta seguro de enviar las Reversa(s)?", "Gestionar Reversas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                int idUsuario = clsVarGlobal.User.idUsuario;
                this.cnObjectPdp.EnviarReversa(idSetRevDeps, idUsuario);

                this.btnConsultar3_Click(null, null);
            }
        }    
    }
}
