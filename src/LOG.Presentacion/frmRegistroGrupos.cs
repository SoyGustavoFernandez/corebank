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
using EntityLayer;
namespace LOG.Presentacion
{
    public partial class frmRegistroGrupos : frmBase
    {
        public int nOpcion = 0;
        public clsListaDetalleProcesoAdj lisDetProAdj = new clsListaDetalleProcesoAdj();     
        clsListaDetalleProcesoAdj lisDetProAdjConGrp = new clsListaDetalleProcesoAdj();
        clsListaDetalleProcesoAdj lstDetProAdjBackUp = new clsListaDetalleProcesoAdj();
        private List<int> nIndices = new List<int>();
            
        public frmRegistroGrupos()
        {
            InitializeComponent();
        }

        private void frmRegistroGrupos_Load(object sender, EventArgs e)
        {         
            dtgGrupo.SelectionChanged -= new EventHandler(dtgGrupo_SelectionChanged);          
            
            foreach (var item in lisDetProAdj)
            {
                lstDetProAdjBackUp.Add(item);   
            }

            int? idGrupoVerif = 0;
            bool lExiste = false;
            foreach (var item in lstDetProAdjBackUp)
            {
                lExiste = false;
                if (item.idGrupo!=null)
                {
                    foreach (DataGridViewRow item2 in dtgGrupo.Rows)
                    {
                        if (item.idGrupo == Convert.ToInt32(item2.Cells[0].Value))
                        {
                            lExiste = true;      
                        }
                    }
                    
                    if (!lExiste)
                    {
                        dtgGrupo.Rows.Add(item.idGrupo, item.cDesGrupo);
                        idGrupoVerif = item.idGrupo;
                        nIndices.Add(Convert.ToInt32(item.idGrupo));
                    }
                } 
            }

            foreach (var item in lisDetProAdj )
            {
                if (item.idGrupo != null)
                {
                    lisDetProAdjConGrp.Add(item);

                    var listQuit = lstDetProAdjBackUp.Where(x => x.nItem == item.nItem).ToList();
                    foreach (var objQuit in listQuit)
                    {
                        lstDetProAdjBackUp.Remove(objQuit);
                    }
                }
            }

            dtgGrupo.SelectionChanged += new EventHandler(dtgGrupo_SelectionChanged);
            
            ActualizarDetalleGrupo();            

            dtgDetalleAdj.DataSource = null;
            dtgDetalleAdj.DataSource = lstDetProAdjBackUp;
            HabilitControles(nOpcion);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (lstDetProAdjBackUp.Count > 0)
            {
                MessageBox.Show("Debe Asignar todos los Articulos a Un Grupo", "Validar Grupo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            lisDetProAdj = lisDetProAdjConGrp;

            this.Dispose();
        }

        private void btnAgregItem_Click(object sender, EventArgs e)
        {
            if (dtgGrupo.RowCount == 0)
            {
                MessageBox.Show("No existe ningun grupo creado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtgDetalleAdj.RowCount > 0)
            {
                var itenselc = (clsDetalleProcesoAdj)dtgDetalleAdj.CurrentRow.DataBoundItem;
                int fila = dtgGrupo.CurrentRow.Index;
                itenselc.idGrupo = Convert.ToInt32(dtgGrupo.Rows[fila].Cells[0].Value.ToString());
                itenselc.cDesGrupo = dtgGrupo.Rows[fila].Cells[1].Value.ToString();

                lisDetProAdjConGrp.Add(itenselc);

                lstDetProAdjBackUp.Remove(itenselc);
                ActualizarDetalleGrupo();
               
            }
        }

        private void btnQuitItem_Click(object sender, EventArgs e)
        {
            if (dtgDetConGrp.RowCount > 0)
            {
                var itenselc = (clsDetalleProcesoAdj)dtgDetConGrp.CurrentRow.DataBoundItem;

                var listQuit = lisDetProAdjConGrp.Where(x => x.nItem == itenselc.nItem).ToList();
                foreach (var objQuit in listQuit)
                {
                    lisDetProAdjConGrp.Remove(objQuit);
                }

                itenselc.idGrupo = null;
                itenselc.cDesGrupo = null;

                lstDetProAdjBackUp.Add(itenselc);
                ActualizarDetalleGrupo();
            }

        }

        private void btnAgregGrupo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDesGrupo.Text.Trim()))
            {
                return;
            }

            foreach (DataGridViewRow Row in dtgGrupo.Rows)
            {
                string valor = Convert.ToString(Row.Cells["Descripcion"].Value);
                if (valor == this.txtDesGrupo.Text)
                {
                    MessageBox.Show("Ya Existe el Grupo", "Valida Grupo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }	
            }
            int NroGrupo = nObtenerIndice(); 
            
            dtgGrupo.Rows.Add(NroGrupo, txtDesGrupo.Text);

            txtDesGrupo.Clear();

        }

        private int nObtenerIndice()
        { 
            int nContador = 1;
            var nIndTemp = nIndices.OrderBy(item => item);

            foreach (int item in nIndTemp)
            {
                if (item != nContador)
                {
                    break;
                }
                else
                nContador++;
            }

            nIndices = nIndTemp.ToList();
            nIndices.Add(nContador);
            return nContador;
        }
        
        private void QuitarIndice(int nInd)
        {
            nIndices.Remove(nInd);
        }

        private void btnQuitGrupo_Click(object sender, EventArgs e)
        {
            if (dtgGrupo.Rows.Count > 0)
            {
                int NroGrupo = dtgGrupo.SelectedRows[0].Index;
                int idGrupo = Convert.ToInt32(dtgGrupo.SelectedRows[0].Cells[0].Value);
                if (validarQuitarGrupo(idGrupo))
                {
                    dtgGrupo.Rows.RemoveAt(NroGrupo);
                    QuitarIndice(idGrupo);
                }
                else
                {
                    MessageBox.Show("El grupo a eliminar tiene items, no se puede eliminar ", "Valida Grupo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private bool validarQuitarGrupo(int NroGrupo)
        {
            bool lBool = true;
            foreach (clsDetalleProcesoAdj item in ((List<clsDetalleProcesoAdj>)dtgDetConGrp.DataSource))
            {
                if (Convert.ToInt32(item.idGrupo) == NroGrupo)
                {
                    lBool = false;
                }
            }
            return lBool;
        }
        private void txtDesGrupo_TextChanged(object sender, EventArgs e)
        {
            txtDesGrupo.CharacterCasing = CharacterCasing.Upper;
        }

        private void dtgGrupo_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarDetalleGrupo();          
        }       

        private void ActualizarDetalleGrupo()
        {
            if (dtgGrupo.RowCount > 0)
            {
                int fila = dtgGrupo.CurrentRow.Index;
                int xidGrupo = Convert.ToInt32(dtgGrupo.Rows[fila].Cells[0].Value.ToString());

                lblGrupo.Visible = true;
                lblGrupo.Text = dtgGrupo.Rows[fila].Cells[1].Value.ToString();

                dtgDetConGrp.DataSource = null;
                dtgDetConGrp.DataSource = lisDetProAdjConGrp.Where(x => x.idGrupo == xidGrupo).ToList();
            }
            else
            {

                lblGrupo.Visible = false;
                lblGrupo.Text = "";
            }
        }

        private void HabilitControles(int nOpcion)
        {
            if (nOpcion == 1)
            {
                txtDesGrupo.Enabled = true;
                btnAgregGrupo.Enabled = true;
                btnQuitGrupo.Enabled = true;
                btnAgrItem.Enabled = true;
                btnQuitItem.Enabled = true;

                //txtDesGrupo.Enabled = false;
                //btnAgregGrupo.Enabled = false;
                //btnQuitGrupo.Enabled = false;
                //btnAgrItem.Enabled = false;
                //btnQuitItem.Enabled = false;
            }
            else if (nOpcion == 2)
            {
                txtDesGrupo.Enabled = false;
                btnAgregGrupo.Enabled = false;
                btnQuitGrupo.Enabled = false;
                btnAgrItem.Enabled = false;
                btnQuitItem.Enabled = false;
            }
            else if (nOpcion == 3)
            {
                txtDesGrupo.Enabled = true;
                btnAgregGrupo.Enabled = true;
                btnQuitGrupo.Enabled = true;
                btnAgrItem.Enabled = true;
                btnQuitItem.Enabled = true;
            }
        }
    }
}
