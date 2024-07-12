using CNT.CapaNegocio;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class frmBuscaCtaCtb : frmBase
    {
        int gnHijo;
        public string pcCtaCtb="", pcDesCtaCtb;
        public bool lAceptar =false;
        public frmBuscaCtaCtb()
        {
            InitializeComponent();
        }

        private void frmBuscaCtaCtb_Load(object sender, EventArgs e)
        {
            cargarTree();
        }


        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                string ctactb = this.txtBusCtaCtb.Text.Trim();
                clsCtaContable objctactb = new clsCNCtaContable().detallectactb(ctactb);
                cargarTreeByPadre(objctactb.idCuenta);
            }
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            lAceptar = true;
            Dispose();
        }

        private void conTreePlanCtb_Load(object sender, EventArgs e)
        {
            conTreePlanCtb.trvNavi.AfterSelect += new TreeViewEventHandler(trvNavi_AfterSelect);
            conTreePlanCtb.trvNavi.AfterCollapse += new TreeViewEventHandler(trvNavi_AfterCollapse);
            conTreePlanCtb.trvNavi.AfterExpand += new TreeViewEventHandler(trvNavi_AfterExpand);
        }

        void trvNavi_AfterExpand(object sender, TreeViewEventArgs e)
        {
            int lnPadre;
            lnPadre = ((clsCtaContable)e.Node.Tag).idCuenta;
//            Habilitar(false);

        }

        void trvNavi_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            int lnPadre;
            lnPadre = ((clsCtaContable)e.Node.Tag).idCuenta;
          
        }

        void trvNavi_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int lnPadre;
            lnPadre = ((clsCtaContable)conTreePlanCtb.trvNavi.SelectedNode.Tag).idCuenta;
            cargarTreeByPadre(lnPadre);
            this.gnHijo = lnPadre;
            
        }
        void cargarTree()
        {
            conTreePlanCtb.LlenarCuenta(new clsCNCtaContable().listarctabyidpadre(0));
            conTreePlanCtb.trvNavi.ExpandAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPadre"></param>
        void cargarTreeByPadre(int idPadre)
        {
            List<clsCtaContable> lisctactb = new List<clsCtaContable>();

            lisctactb.AddRange(new clsCNCtaContable().listarctabyidpadre(0));

            foreach (var item in (new clsCNCtaContable().listarpadresnodo(idPadre)))
            {
                lisctactb.AddRange(new clsCNCtaContable().listarctabyidpadre(item.idCuenta));
            }

            conTreePlanCtb.LlenarCuenta(lisctactb);

            conTreePlanCtb.trvNavi.ExpandAll();

            TreeNode trItemSe = buscar(idPadre.ToString(), conTreePlanCtb.trvNavi.Nodes);

            if (trItemSe != null)
            {
                clsCtaContable objCtaCtb = ((clsCtaContable)trItemSe.Tag);
                trItemSe.BackColor = Color.RoyalBlue;
                trItemSe.ForeColor = Color.White;
                trItemSe.NodeFont = new Font("Calibri", 8F, System.Drawing.FontStyle.Bold);
                trItemSe.ImageIndex = 0;

                pcCtaCtb = objCtaCtb.cCuentaContable;
                pcDesCtaCtb = objCtaCtb.cDesCtaCtb;



                if (trItemSe.FirstNode != null)
                {
                    lblInidicaUltimoNivel.Visible =false;
                }
                else
                {
                    lblInidicaUltimoNivel.Text = "La cuenta " + pcCtaCtb + " es de último nivel";
                    lblInidicaUltimoNivel.Visible = true;
                }
            }
            else
            {
                lblInidicaUltimoNivel.Visible = false;
                MessageBox.Show("No se encontro la cuenta contable", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        public TreeNode buscar(String idCuenta, TreeNodeCollection nodos)
        {
            TreeNode padre = null;
            bool encontrado = false;
            int contador = 0;

            while (encontrado == false && contador < nodos.Count)
            {
                if (((clsCtaContable)nodos[contador].Tag).idCuenta == Convert.ToInt32(idCuenta))
                {
                    encontrado = true;
                    padre = nodos[contador];
                   
                }
                else
                {
                    if (nodos[contador].Nodes.Count > 0)
                    {
                        padre = buscar(idCuenta, nodos[contador].Nodes);
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
        public TreeNode buscarbyctactb(String ctactb, TreeNodeCollection nodos)
        {
            TreeNode padre = null;
            bool encontrado = false;
            int contador = 0;

            while (encontrado == false && contador < nodos.Count)
            {
                clsCtaContable objctactb = (clsCtaContable)nodos[contador].Tag;
                if (objctactb.cDesCtaCtb.Substring(0, objctactb.nLongitud) == ctactb)
                {
                    encontrado = true;
                    padre = nodos[contador];
                  
                }
                else
                {

                    if (nodos[contador].Nodes.Count > 0)
                    {
                        padre = buscarbyctactb(ctactb, nodos[contador].Nodes);
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

        private void txtBusCtaCtb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                txtBusCtaCtb.Text  = Clipboard.GetText().Trim();
                txtBusCtaCtb.Select(txtBusCtaCtb.Text.Length, 0);
            }
        }
    }
}
