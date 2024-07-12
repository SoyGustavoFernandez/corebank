using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
namespace GEN.ControlesBase
{
    public partial class conTreeCentroCosto : UserControl
    {
        public int gnPadre;
        public conTreeCentroCosto()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Recibe una lista de la clase clsLstCentroCosto que contiene el Grupo de los centros de costos con la estructura de Padre - Hijo
        /// </summary>
        /// <param name="lstGrupoActivo"></param>
        public void LlenarCentroCostos(clsLstCentroCosto lstGrupoActivo)
        {
            this.trvNavi.Nodes.Clear();
            agregarNodos(lstGrupoActivo);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstCuentas"></param>
        private void agregarNodos(clsLstCentroCosto lstCuentas)
        {
            TreeNode padre;
            TreeNode hijo;
            try
            {
                foreach (var item in lstCuentas)
                {
                    hijo = new TreeNode();
                    hijo.Text = item.cCentroCosto;
                    hijo.Tag = item;//.idCuenta.ToString();                                      
                    hijo.ToolTipText = item.IdCentroCosto.ToString();
                    padre = buscarPadre(item.IdCentroCostoPadre.ToString(), trvNavi.Nodes);

                    clsCentroCosto objctactbhijo = (clsCentroCosto)hijo.Tag;
                    if (!objctactbhijo.lVigente)
                    {
                        hijo.BackColor = Color.Red;
                        hijo.ForeColor = Color.White;
                    }
                    if (padre == null)
                        this.trvNavi.Nodes.Add(hijo);
                    else
                    {
                        clsCentroCosto objctactb = (clsCentroCosto)padre.Tag;
                        if (!objctactb.lVigente)
                        {
                            hijo.BackColor = Color.Red;
                            hijo.ForeColor = Color.White;
                            objctactbhijo.lVigente = false;
                        }
                        padre.Nodes.Add(hijo);
                    }
                    padre = null;
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private TreeNode buscarPadre(String NodoBusqueda, TreeNodeCollection nodos)
        {
            TreeNode nodoPadre = null;
            var encontrado = false;
            int ncontador = 0;

            while (encontrado == false && ncontador < nodos.Count)
            {
                if (((clsCentroCosto)nodos[ncontador].Tag).IdCentroCosto == Convert.ToInt32(NodoBusqueda))
                {
                    encontrado = true;
                    nodoPadre = nodos[ncontador];
                }
                else
                {
                    if (nodos[ncontador].Nodes.Count > 0)
                    {
                        nodoPadre = buscarPadre(NodoBusqueda, nodos[ncontador].Nodes);
                        if (nodoPadre != null)
                        {
                            encontrado = true;
                        }
                    }
                }
                ncontador++;
            }
            return nodoPadre;
        }

        /// <summary>
        /// realiza la busqueda de un nodo en especifico
        /// </summary>
        /// <param name="nidNodo">id del nodo a buscar</param>
        /// <returns>TreeNode nodoencontrado</returns>
        public TreeNode BusCue(int nidNodo)
        {
            return buscar(nidNodo.ToString(), trvNavi.Nodes);
        }

        /// <summary>
        /// realiza la busqueda de un nodo en especifico
        /// </summary>
        /// <param name="NodoBusqueda">nodo a realizar la busqueda</param>
        /// <param name="nodos"></param>
        /// <returns></returns>
        public TreeNode buscar(String NodoBusqueda, TreeNodeCollection nodos)
        {
            TreeNode padre = null;
            bool encontrado = false;
            int contador = 0;

            while (encontrado == false && contador < nodos.Count)
            {
                if (((clsCentroCosto)nodos[contador].Tag).IdCentroCosto == Convert.ToInt32(NodoBusqueda))
                {
                    encontrado = true;
                    padre = nodos[contador];
                }
                else
                {
                    if (nodos[contador].Nodes.Count > 0)
                    {
                        padre = buscar(NodoBusqueda, nodos[contador].Nodes);
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
    }
}
