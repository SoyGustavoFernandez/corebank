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
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class frmBuscaCentroCosto : frmBase
    {
        public string pcNombreCentroCosto;
        public int pnNivelOrden = 0;
        public int pnidCentroCosto = 0;
        public int pnIdCentroCostoPadre = 0;
        string pcTipTrx = "";
        private TreeNode m_OldSelectNode;
        clsLstCentroCosto lstCentroCosto = new clsLstCentroCosto();
        clsCNCentroCosto cnBuscaCentroCosto = new clsCNCentroCosto();
        private bool selectPadre = false;

        public frmBuscaCentroCosto(bool selectPadre_ = false)
        {
            InitializeComponent();
            selectPadre = selectPadre_;
        }

        private void frmBuscaCentroCosto_Load(object sender, EventArgs e)
        {
            lstCentroCosto = cnBuscaCentroCosto.CNListCentroCosto(-1);
            conTreeCentroCosto1.LlenarCentroCostos(lstCentroCosto);
            conTreeCentroCosto1.trvNavi.SelectedNode = conTreeCentroCosto1.trvNavi.Nodes[0];
            conTreeCentroCosto1.trvNavi.Select();
        }

        private void conTreeCentroCosto1_Load(object sender, EventArgs e)
        {
            conTreeCentroCosto1.trvNavi.AfterSelect += new TreeViewEventHandler(trvNavi_AfterSelect);
            conTreeCentroCosto1.trvNavi.AfterCollapse += new TreeViewEventHandler(trvNavi_AfterCollapse);
            conTreeCentroCosto1.trvNavi.AfterExpand += new TreeViewEventHandler(trvNavi_AfterExpand);
            conTreeCentroCosto1.trvNavi.AfterExpand += new TreeViewEventHandler(trvNavi_AfterExpand);
            //conTreeCentroCosto1.trvNavi.MouseUp += new MouseEventHandler(trvNavi_MouseUp); 
        }      

        void trvNavi_AfterExpand(object sender, TreeViewEventArgs e)
        {
            int lnPadre;
            lnPadre = ((clsCentroCosto)e.Node.Tag).IdCentroCosto;
            //Habilitar(false, 1);
        }

        void trvNavi_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            int lnPadre;
            lnPadre = ((clsCentroCosto)e.Node.Tag).IdCentroCosto;

        }

        void trvNavi_AfterSelect(object sender, TreeViewEventArgs e)
        {
            cargarDatos();
            e.Node.Expand();
        }
        private void cargarDatos()
        {
            clsCentroCosto clsCentroCosto = ((clsCentroCosto)conTreeCentroCosto1.trvNavi.SelectedNode.Tag);
            pnNivelOrden = clsCentroCosto.nOrden;
            pnidCentroCosto = clsCentroCosto.IdCentroCosto;
            pnIdCentroCostoPadre = clsCentroCosto.IdCentroCostoPadre;
            pcNombreCentroCosto = clsCentroCosto.cCentroCosto;            
        }

        private void txtBuscar1_TextChanged(object sender, EventArgs e)
        {
            txtBuscar1.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtBuscar1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 || e.KeyChar == (char)8)
            {
                buscarXDescripcion(txtBuscar1.Text);
            }
        }
        void buscarXDescripcion(string texto)
        {
            TreeNode trItemSe = buscarPorDescripcion(texto, conTreeCentroCosto1.trvNavi.Nodes);
            if (trItemSe != null)
            {
                conTreeCentroCosto1.trvNavi.CollapseAll();
                conTreeCentroCosto1.trvNavi.SelectedNode = trItemSe;
                conTreeCentroCosto1.trvNavi.Select();
            }
            else
            {
                MessageBox.Show("No se encontro el Catalogo", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public TreeNode buscarPorDescripcion(String DescripCentroCosto, TreeNodeCollection nodos)
        {
            TreeNode padre = null;
            bool encontrado = false;
            int contador = 0;

            while (encontrado == false && contador < nodos.Count)
            {
                clsCentroCosto objCentroCosto = (clsCentroCosto)nodos[contador].Tag;
                if (objCentroCosto.cCentroCosto.IndexOf(DescripCentroCosto) >= 0)
                {
                    encontrado = true;
                    padre = nodos[contador];
                }
                else
                {
                    if (nodos[contador].Nodes.Count > 0)
                    {
                        padre = buscarPorDescripcion(DescripCentroCosto, nodos[contador].Nodes);
                        if (padre != null)
                        {
                            encontrado = true;
                        }
                    }
                }
                contador++;
            }
            return padre;
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (conTreeCentroCosto1.trvNavi.SelectedNode.Nodes.Count > 0 && !selectPadre)
            {
                MessageBox.Show("No seleccionó un Centro de Costo específico", "Seleccion de Centro de Costo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pnidCentroCosto = 0;
            }
            Dispose();
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            pnidCentroCosto = 0;
        }
    }
}
