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

namespace LOG.Presentacion
{
    public partial class frmSeleccionaGrupoProceso : frmBase
    {
        private DataTable dtBuenaPro;
        private DataTable dtGrupo;
        private DataTable dtDetalleBP; 

        public frmSeleccionaGrupoProceso(string tipoProceso = "4toNivel")
        {
            InitializeComponent();
        }
    
        public frmSeleccionaGrupoProceso(DataTable dt)
        {
            InitializeComponent();
            dtBuenaPro = dt;
        }

        private void frmSeleccionaGrupoProceso_Load(object sender, EventArgs e)
        {
            cargarGrupo();
        }

        private void cargarGrupo()
        {
            dtgGruposProceso.DataSource = obtenerGrupos();
            dtgGruposProceso.Columns["nGrupo"].HeaderText = "Nro. Grupo";
            dtgGruposProceso.Columns["cDesGrupo"].HeaderText = "Grupo";
            txtProceso.Text = dtBuenaPro.Rows[0]["cDesGrupo"].ToString();
        }

        public DataTable obtenerGrupos()
        {
            dtGrupo = new DataTable();
            dtGrupo.Columns.Add("nGrupo", typeof(int));
            dtGrupo.Columns.Add("cDesGrupo", typeof(string));

            DataTable tmp = dtGrupo.Clone();
            bool lExiste = false;
            foreach (DataRow item in dtBuenaPro.Rows)
	        {
                if(dtGrupo.Rows.Count == 0)
                {
                    DataRow dr = tmp.NewRow();
                    dr["nGrupo"] = item["nGrupo"];
                    dr["cDesGrupo"] = item["cDesGrupo"];
                    tmp.Rows.Add(dr);
                    dtGrupo = tmp.Copy();
                }
                else
	            {
                    foreach (DataRow row in dtGrupo.Rows)
	                {
		                if(Convert.ToInt32(item["nGrupo"]) == Convert.ToInt32(row["nGrupo"]))
                        {
                            lExiste = true;
                        }
	                }

                    if (!lExiste)
                    {
                        DataRow dr = tmp.NewRow();
                        dr["nGrupo"] = item["nGrupo"];
                        dr["cDesGrupo"] = item["cDesGrupo"];
                        tmp.Rows.Add(dr);
                        dtGrupo = tmp.Copy();
                    }

                    lExiste = false;
                    
	            }
	        }

            return dtGrupo;
    
        }

        private void dtgGruposProceso_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgGruposProceso.RowCount == 0) 
            {
                return;
            }

            cargaItems(Convert.ToInt32(dtgGruposProceso.Rows[e.RowIndex].Cells["nGrupo"].Value));

        }

        private void cargaItems(int idGrupo)
        {
            dtgDetalleGrupo.DataSource = ObtenerItems(idGrupo);

            foreach (DataGridViewColumn item in dtgDetalleGrupo.Columns)
            {
                item.Visible = false;
            }
            dtgDetalleGrupo.Columns["cProducto"].Visible = true;
            dtgDetalleGrupo.Columns["cNombre"].Visible = true;

            dtgDetalleGrupo.Columns["cProducto"].HeaderText = "Producto";
            dtgDetalleGrupo.Columns["cNombre"].HeaderText = "Proveedor Ganador";
        }

        private DataTable ObtenerItems(int idGrupo)
        {
            dtDetalleBP = dtBuenaPro.Clone();
            foreach (DataRow item in dtBuenaPro.Rows)
            {
                if (Convert.ToInt32(item["nGrupo"]) == idGrupo)
                {
                    dtDetalleBP.ImportRow(item);
                }
                
            }
            return dtDetalleBP;
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public DataTable obtenerDtDetalleBP()
        {
            return dtDetalleBP;
        }
    }
}
