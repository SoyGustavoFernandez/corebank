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
using EntityLayer;

namespace CNE.Presentacion
{
    public partial class frmPDPGestionarDepositos : frmBase
    {
        clsCNPdp cnObjectPdp = new clsCNPdp();
        frmPDPGestionarDepositoDialog objPDPGesDepDialogUlt = new frmPDPGestionarDepositoDialog();        
        DateTime dFecSystem = clsVarGlobal.dFecSystem;

        public frmPDPGestionarDepositos()
        {
            InitializeComponent();
        }
        
        private void frmPDPGestionarDepositos_Load(object sender, EventArgs e)
        {
            this.cboPDPEmisor1.cargarVigentesTodos();
            this.cboPDPEmisor2.cargarVigentesTodos();
            this.cboPDPEmisor3.cargarVigentesTodos();
            
            this.cboPDPEstado1.ModalidadPDPEstado(3);
            this.cboPDPEstado2.ModalidadPDPEstado(4);
            
            this.dtpFechaInicio1.Value = dFecSystem.Date;
            this.dtpFechaFin1.Value = dFecSystem.Date;

            this.dtpFechaInicio2.Value = dFecSystem.Date;
            this.dtpFechaFin2.Value = dFecSystem.Date;

            this.dtpFechaInicio3.Value = dFecSystem.Date;
            this.dtpFechaFin3.Value = dFecSystem.Date;
        }        

        private void btnConsultar1_Click(object sender, EventArgs e)
        {
            if (this.dtpFechaInicio1.Value.Date > this.dtpFechaFin1.Value.Date)
            {
                MessageBox.Show("La Fecha Inicial no puede ser mayor a la Fecha Final", "Gestionar Depositos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int nModulo = 1;
            int idEmisor = (int)this.cboPDPEmisor1.SelectedValue;
            int idEstado = (int)this.cboPDPEstado1.SelectedValue;
            DateTime dFechaInicial = this.dtpFechaInicio1.Value.Date;
            DateTime dFechaFinal = this.dtpFechaFin1.Value.Date;

            DataTable dt = new DataTable();
            dt = cnObjectPdp.ListarDepositos(nModulo, idEmisor, idEstado, dFechaInicial, dFechaFinal);

            this.dtgConsultarDepositos.DataSource = dt;
        }

        private void btnConsultar2_Click(object sender, EventArgs e)
        {
            int nModulo = 2;
            int idEmisor = (int)this.cboPDPEmisor2.SelectedValue;
            int idEstado = (int)this.cboPDPEstado2.SelectedValue;
            DateTime dFechaInicial = this.dtpFechaInicio2.Value.Date;
            DateTime dFechaFinal = this.dtpFechaFin2.Value.Date;

            DataTable dt = new DataTable();
            dt = cnObjectPdp.ListarDepositos(nModulo, idEmisor, idEstado, dFechaInicial, dFechaFinal);

            this.dtgActualizarDepositos.DataSource = dt;
        }

        private void btnConsultar3_Click(object sender, EventArgs e)
        {
            int nModulo = 3;
            int idEmisor = (int)this.cboPDPEmisor3.SelectedValue;
            int idEstado = -1;
            DateTime dFechaInicial = this.dtpFechaInicio3.Value.Date;
            DateTime dFechaFinal = this.dtpFechaFin3.Value.Date;

            DataTable dt = new DataTable();
            dt = cnObjectPdp.ListarDepositos(nModulo, idEmisor, idEstado, dFechaInicial, dFechaFinal);
            
            dt.Columns["lCheck"].ReadOnly = false;
            dt.Columns["lCheck"].AllowDBNull = true;            

            this.dtgEnviarDepositos.DataSource = dt;
            this.dtgEnviarDepositos.Refresh();

            this.dtgEnviarDepositos.ReadOnly = false;            
            this.dtgEnviarDepositos.Columns["idPDPSetDep3"].ReadOnly = true;
            this.dtgEnviarDepositos.Columns["dFechaProc3"].ReadOnly = true;
            this.dtgEnviarDepositos.Columns["cFechaHoraTransaccion3"].ReadOnly = true;
            this.dtgEnviarDepositos.Columns["idPDPEmisor3"].ReadOnly = true;
            this.dtgEnviarDepositos.Columns["cEmisorCorto3"].ReadOnly = true;
            this.dtgEnviarDepositos.Columns["nMonto3"].ReadOnly = true;
            this.dtgEnviarDepositos.Columns["idPDPEstado3"].ReadOnly = true;
            this.dtgEnviarDepositos.Columns["cEstado3"].ReadOnly = true;
            this.dtgEnviarDepositos.Columns["cWinUser3"].ReadOnly = true;
            this.dtgEnviarDepositos.Columns["dFechaHoraAct3"].ReadOnly = true;
            this.dtgEnviarDepositos.Columns["dFechaEstTrans3"].ReadOnly = true;
            this.dtgEnviarDepositos.Columns["cComentario3"].ReadOnly = true;            
        }        

        private void dtgActualizarDepositos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dtgActualizarDepositos.Columns[e.ColumnIndex].Name == "cAccion12" && e.RowIndex >= 0)
            {
                int idPDPSetDep = Convert.ToInt32(this.dtgActualizarDepositos.Rows[e.RowIndex].Cells["idPDPSetDep2"].Value);

                DataTable dt = new DataTable();
                dt = cnObjectPdp.ListarDeposito(idPDPSetDep);

                DataRow dr = dt.Rows[0];

                int idModalidad = (dr["cReceptor"].ToString().Equals("FRI:/CA"))? 1 : 2;                
                int idPDPEmisor = (int)dr["idPDPEmisor"];
                decimal nMonto = Convert.ToDecimal(dr["nMonto"]);
                string cReceptor = dr["cReceptor"].ToString();
                string cNombres = dr["cNombreTitularReceptor"].ToString();
                string cApellidos = dr["cApellidoTitularReceptor"].ToString();
                int idEstado = (int)dr["idPDPEstado"];
                string cIdTransaccion = dr["cIdTransaccion"].ToString();
                DateTime dFecEstTrans = (string.IsNullOrEmpty(dr["dFechaEstTrans"].ToString())) ? DateTime.Now : Convert.ToDateTime(dr["dFechaEstTrans"].ToString());
                string cComentario = dr["cComentario"].ToString();                                

                this.objPDPGesDepDialogUlt = new frmPDPGestionarDepositoDialog();
                this.objPDPGesDepDialogUlt.CargarComponentes(2, idModalidad, 4, idPDPSetDep, cIdTransaccion, idPDPEmisor, nMonto, cReceptor, cNombres, cApellidos, idEstado, cComentario);
                this.objPDPGesDepDialogUlt.ShowDialog();

                this.btnConsultar2_Click(null, null);
            }
        }

        private void dtgActualizarDepositos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dtgActualizarDepositos.Columns[e.ColumnIndex].Name == "cAccion12" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dtgActualizarDepositos.Rows[e.RowIndex].Cells["cAccion12"] as DataGridViewButtonCell;
                Icon icoAtomico1 = new Icon(Properties.Resources.icoEditar, 16, 16);
                e.Graphics.DrawIcon(icoAtomico1, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.dtgActualizarDepositos.Rows[e.RowIndex].Height = icoAtomico1.Height + 6;
                this.dtgActualizarDepositos.Columns[e.ColumnIndex].Width = icoAtomico1.Width + 6;                

                e.Handled = true;
            }                     
        }

        private void dtgEnviarDepositos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (this.dtgEnviarDepositos.Columns[e.ColumnIndex].Name == "cAccion13" && e.RowIndex >= 0 && (int)(this.dtgEnviarDepositos.Rows[e.RowIndex].Cells["idPDPEstado3"].Value) == 3)
            {
                DialogResult dialogResult = MessageBox.Show("¿Esta seguro de enviar el Deposito?", "Gestionar Depositos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    int idPDPSetDep = Convert.ToInt32(this.dtgEnviarDepositos.Rows[e.RowIndex].Cells["idPDPSetDep3"].Value);
                    this.cnObjectPdp.EnviarDeposito(idPDPSetDep);
                }
            }*/
        }

        private void dtgEnviarDepositos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dtgEnviarDepositos.Columns[e.ColumnIndex].Name == "lCheck3" && e.RowIndex >= 0)
            {
                if ((int)this.dtgEnviarDepositos.Rows[e.RowIndex].Cells["idPDPEstado3"].Value == 6 || (int)this.dtgEnviarDepositos.Rows[e.RowIndex].Cells["idPDPEstado3"].Value == 7)
                {
                    this.dtgEnviarDepositos.Rows[e.RowIndex].Cells["lCheck3"].ReadOnly = true;                    

                    var CellStyle = new DataGridViewCellStyle { Padding = new Padding(100, 0, 0, 0) };
                    this.dtgEnviarDepositos.Rows[e.RowIndex].Cells["lCheck3"].Style = CellStyle;                    
                }
            }           

            /*
            if (e.ColumnIndex >= 0 && this.dtgEnviarDepositos.Columns[e.ColumnIndex].Name == "cAccion13" && e.RowIndex >= 0)
            {
                if ((int)(this.dtgEnviarDepositos.Rows[e.RowIndex].Cells["idPDPEstado3"].Value) == 3)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    DataGridViewButtonCell celBoton = this.dtgEnviarDepositos.Rows[e.RowIndex].Cells["cAccion13"] as DataGridViewButtonCell;
                    Icon icoAtomico1 = new Icon(Properties.Resources.icoEnviar, 16, 16);
                    e.Graphics.DrawIcon(icoAtomico1, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                    this.dtgEnviarDepositos.Rows[e.RowIndex].Height = icoAtomico1.Height + 6;
                    this.dtgEnviarDepositos.Columns[e.ColumnIndex].Width = icoAtomico1.Width + 6;

                    e.Handled = true;
                }
                else
                {
                    var CellStyle = new DataGridViewCellStyle { Padding = new Padding(100, 0, 0, 0) };
                    this.dtgEnviarDepositos.Rows[e.RowIndex].Cells["cAccion13"].Style = CellStyle;
                }
            }*/
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.objPDPGesDepDialogUlt = new frmPDPGestionarDepositoDialog();
            this.objPDPGesDepDialogUlt.CargarComponentes(1, 1, 4, 0, "", 1, 0, "", "", "", 1, "");
            this.objPDPGesDepDialogUlt.ShowDialog();

            this.btnConsultar1_Click(null, null);
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string idSetDeps = string.Empty;
            int count = 0;

            foreach (DataGridViewRow row in dtgEnviarDepositos.Rows)
            {
                if (row.Cells["lCheck3"].Value != DBNull.Value && Convert.ToInt32(row.Cells["lCheck3"].Value) == 1)
                {
                    idSetDeps += row.Cells["idPDPSetDep3"].Value.ToString() + ",";
                    count++;
                }
            }

            if (count == 0)
            {
                MessageBox.Show("Antes de proceder debe seleccionar los Deposito(s) a enviar.", "Gestionar Depositos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            idSetDeps = idSetDeps.Substring(0, idSetDeps .Length-1);

            DialogResult dialogResult = MessageBox.Show("¿Esta seguro de enviar los Deposito(s)?", "Gestionar Depositos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                int idUsuario = clsVarGlobal.User.idUsuario;
                this.cnObjectPdp.EnviarDeposito(idSetDeps, idUsuario);

                this.btnConsultar3_Click(null, null);
            }
        }                        
    }
}
