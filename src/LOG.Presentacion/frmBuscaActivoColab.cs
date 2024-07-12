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

namespace LOG.Presentacion
{
    public partial class frmBuscaActivoColab : frmBase
    {
        public string cNom, cDocID, idCargoPer, cCargoPer, idCliPer, idAct="0";
        public int idUsu=0, nidAgencia=0;
        public string cIdEstado = "1,2,3";
        string cSerie="";
        clsCNActivos Activos = new clsCNActivos();
        public DataTable dtDetalleActivo= new DataTable();
        DataTable dtActivo = new DataTable();  

        public frmBuscaActivoColab()
        {
            InitializeComponent();
        }       

        private void ActivaControl(bool lActivo)
        {
            btnBusqCol.Enabled = lActivo;
            txtCodActivo.Enabled = lActivo;
            txtSerie.Enabled = lActivo;        
        }

        private void chcPersResponsable_CheckedChanged(object sender, EventArgs e)
        {
            if (chcPersResponsable.Checked)
            {
                btnBusqCol.Enabled = true;               
            }
            else 
            {
                btnBusqCol.Enabled = false;
                CleanDataUsu();
                txtColabResp.Text = "";
                cboAgencias.SelectedValue = 0;
                Buscar(idUsu, nidAgencia, idAct, cSerie,cIdEstado);
            }
        }

        private void chcCodActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (chcCodActivo.Checked)
            {
                txtCodActivo.Enabled = true;
            }
            else
            {
                txtCodActivo.Enabled = false;
                txtCodActivo.Text = "";
                idAct = "0";
                Buscar(idUsu, nidAgencia, idAct, cSerie, cIdEstado);
            }
        }

        private void chcSerieActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (chcSerieActivo.Checked)
            {
                txtSerie.Enabled = true;
            }
            else
            {
                txtSerie.Enabled = false;
                txtSerie.Text = "";
                cSerie = "";
                Buscar(idUsu, nidAgencia, idAct, cSerie, cIdEstado);
            }
        }

        private void frmBuscaActivoColab_Load(object sender, EventArgs e)
        {
            dtDetalleActivo.Columns.Add("idActivo", typeof(Int32));
            ActivaControl(false);
            //Buscar(0, 0, "0", "", cIdEstado);
        }

        private void btnBusqCol_Click(object sender, EventArgs e)
        {
            CleanDataUsu();
            BuscaColaborador();
            txtColabResp.Text = cNom;
            cboAgencias.SelectedValue = nidAgencia;

            Buscar(idUsu, nidAgencia, idAct, cSerie, cIdEstado);	        
        }

        private void CleanDataUsu()
        {
            idUsu = 0;
            cNom = "";
            cDocID = "";
            idCargoPer = "";
            cCargoPer = "";
            idCliPer = "";
            nidAgencia = 0;
        }

        private void BuscaColaborador()
        {
            FrmBusCol frm = new FrmBusCol();
            frm.ShowDialog();
            if (Convert.ToString(frm.idUsu) != "")
            {
                idUsu = Convert.ToInt32(frm.idUsu);
                cNom = frm.cNom;
                cDocID = frm.cDocID;
                idCargoPer = frm.idCargoPer;
                cCargoPer = frm.cCargoPer;
                idCliPer = frm.idCliPer;
                nidAgencia = Convert.ToInt32(frm.nidAgencia);                
            }            
        }

        public void Buscar(int idUsuReg, int idAgencia, string idActivo, string cSerie,string cIdEstado)
        {
            dtActivo = Activos.CNListaActivosResponsable(idUsuReg, idAgencia, idActivo, cSerie, cIdEstado);
            dtgActivoOrigen.DataSource = dtActivo.DefaultView;

            FormatoDataGrid();           
        }

        private void FormatoDataGrid()
        {
            foreach (DataGridViewColumn item in this.dtgActivoOrigen.Columns)
            {
                item.Visible = false;
            }
            dtgActivoOrigen.Columns["chk"].Visible = true;
            dtgActivoOrigen.Columns["idActivo"].Visible = true;
            dtgActivoOrigen.Columns["idCatalogo"].Visible = true;           
            dtgActivoOrigen.Columns["cProducto"].Visible = true;            
            dtgActivoOrigen.Columns["cNombreColReg"].Visible = true;
            dtgActivoOrigen.Columns["cNombreColResp"].Visible = true;

            dtgActivoOrigen.Columns["chk"].FillWeight = 4;
            dtgActivoOrigen.Columns["idActivo"].FillWeight = 5;
            dtgActivoOrigen.Columns["idCatalogo"].FillWeight = 5;
            dtgActivoOrigen.Columns["cProducto"].FillWeight = 37;
            dtgActivoOrigen.Columns["cNombreColReg"].FillWeight = 27;
            dtgActivoOrigen.Columns["cNombreColResp"].FillWeight = 27;

        }

        private void txtCodActivo_KeyPress(object sender, KeyPressEventArgs e)
        {    
            if (e.KeyChar == 13)
            {
                if (txtCodActivo.Text == "")
                {
                    MessageBox.Show("No se encuentra datos del código de Activo", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }                
                else
                {
                    idAct = txtCodActivo.Text;
                    Buscar(idUsu, nidAgencia, idAct, cSerie,cIdEstado);
                }
            }
        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtSerie.Text == "")
                {
                    MessageBox.Show("No se encuentra datos del código de Activo", "Valida Activo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }               
                else
                {
                    cSerie = txtSerie.Text;
                    Buscar(idUsu, nidAgencia, idAct, cSerie,cIdEstado);
                }
            }
        }

        private void chcTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chcTodos.Checked)
            {

                for (int i = 0; i < dtgActivoOrigen.RowCount; i++)
                {
                    dtgActivoOrigen[0, i].Value = chcTodos.Checked;                    
                }
                dtgActivoOrigen.EndEdit();
            }
            else 
            {
                for (int i = 0; i < dtgActivoOrigen.RowCount; i++)
                {
                    dtgActivoOrigen[0, i].Value = !chcTodos.Checked;
                }
                dtgActivoOrigen.EndEdit();
            }

        }

        private void dtgActivoOrigen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgActivoOrigen.CurrentRow == null)
            {
                return;
            }
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)dtgActivoOrigen.Rows[dtgActivoOrigen.CurrentRow.Index].Cells[0];
            Int32 fila = e.RowIndex;

            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;

                    break;
                case "False":
                    {
                        ch1.Value = true;
                    }
                    break;
            }    
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dtgActivoOrigen.RowCount; i++)
                {                
                    if ( Convert.ToBoolean(dtgActivoOrigen[0, i].Value) ==true)
	                {
                        DataRow dr = dtDetalleActivo.NewRow();
                        dr["idActivo"] = this.dtgActivoOrigen.Rows[i].Cells["idActivo"].Value;
                        dtDetalleActivo.Rows.Add(dr);                        
	                }                    
                }
            this.Dispose();
        }
    }
}
