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
    public partial class conTreeCatalogo : UserControl
    {
        public int gnPadre;
        public conTreeCatalogo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Recibe una lista de la clase clsLstGrupoActivo que contiene el Grupo de los Activos con la estructura de Padre - Hijo
        /// </summary>
        /// <param name="lstGrupoActivo"></param>
        public void LlenarGrupoActivo(clsLstGrupoActivo lstGrupoActivo)
        {
            this.trvNavi.Nodes.Clear();
            agregarNodos(lstGrupoActivo);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstCuentas"></param>
        private void agregarNodos(clsLstGrupoActivo lstCuentas)
        {
            TreeNode padre;
            TreeNode hijo;
            try
            {
                foreach (var item in lstCuentas)
                {
                    hijo = new TreeNode();
                    hijo.Text = item.cNombreGrupo;
                    hijo.Tag = item;//.idCuenta.ToString();                                      
                    hijo.ToolTipText = item.idGrupoActivo.ToString();
                    padre = buscarPadre(item.idPadre.ToString(), trvNavi.Nodes);

                    clsGrupoActivo objctactbhijo = (clsGrupoActivo)hijo.Tag;
                    if (!objctactbhijo.lvigente)
                    {
                        hijo.BackColor = Color.Red;
                        hijo.ForeColor = Color.White;
                    }
                    if (padre == null)
                        this.trvNavi.Nodes.Add(hijo);
                    else
                    {
                        clsGrupoActivo objctactb = (clsGrupoActivo)padre.Tag;
                        if (!objctactb.lvigente)
                        {
                            hijo.BackColor = Color.Red;
                            hijo.ForeColor = Color.White;
                            objctactbhijo.lvigente = false;
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
                if (((clsGrupoActivo)nodos[ncontador].Tag).idGrupoActivo == Convert.ToInt32(NodoBusqueda))
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
                if (((clsCtaContable)nodos[contador].Tag).idCuenta == Convert.ToInt32(NodoBusqueda))
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
