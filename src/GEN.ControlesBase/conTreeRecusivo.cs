using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
    using System.Windows.Forms;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class conTreeRecusivo : UserControl
    {
        #region Variables
        public int gnPadre;
        public string cDescrip;
        public new event EventHandler DblClick;
        public new event KeyPressEventHandler KeyTrv;
        #endregion

        #region Constructor
        public conTreeRecusivo()
        {
            InitializeComponent();
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Recibe una lista de la clase clsCtaContable que contiene el plan contable con la estructura de Padre - Hijo
        /// </summary>
        /// <param name="lstCuentas"></param>
        public void LlenarCuenta(List<clsCtaContable> lstCuentas)
        {
            this.trvNavi.Nodes.Clear();
            agregarNodos(lstCuentas);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstCuentas"></param>
        private void agregarNodos(List<clsCtaContable> lstCuentas)
        {
            TreeNode padre;
            TreeNode hijo;
            try
            {
                for (int i = 0; i < lstCuentas.Count; i++)
                {
                    hijo = new TreeNode();
                    hijo.Text = lstCuentas[i].cDesCtaCtb.ToString();
                    hijo.Tag = lstCuentas[i];//.idCuenta.ToString();                                      
                    hijo.ToolTipText = lstCuentas[i].idCuenta.ToString();
                    padre = buscarPadre(lstCuentas[i].idCuentaPadre.ToString(), trvNavi.Nodes);

                    clsCtaContable objctactbhijo = (clsCtaContable)hijo.Tag;
                    if (!objctactbhijo.lVigente)
                    {
                        hijo.BackColor = Color.Red;
                        hijo.ForeColor = Color.White;
                    }
                    

                    if (padre == null)
                        this.trvNavi.Nodes.Add(hijo);
                    else
                    {
                        clsCtaContable objctactb = (clsCtaContable)padre.Tag;
                        if (!objctactb.lVigente)
                        {
                            hijo.BackColor = Color.Red;
                            hijo.ForeColor = Color.White;
                            objctactbhijo.lVigente=false;
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
                if (((clsCtaContable)nodos[ncontador].Tag).idCuenta == Convert.ToInt32(NodoBusqueda))
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

        #endregion

        private void trvNavi_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (DblClick!= null)
                DblClick(sender, e);
        }

        private void trvNavi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyTrv != null)
                KeyTrv(sender, e);
        }
    }
}
