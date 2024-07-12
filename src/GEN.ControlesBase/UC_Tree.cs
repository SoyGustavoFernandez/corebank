using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class UC_Tree : UserControl
    {

        #region Variables
        public int gnPadre;
        DataTable dtMenu = new DataTable();
        Dictionary<string, Form> dictForm = new Dictionary<string, Form>();
        Dictionary<string, UserControl> dictUC = new Dictionary<string, UserControl>();
        Error error = new Error();
        clsCNError errorbll = new clsCNError();

        public Semaforo objTreeSemaforo;

        public int TipoRes = 0;

        private int _nTotNodes;

        public int nTotNodes
        {
            get { return _nTotNodes; }
            set { _nTotNodes = value; }
        }
        

        #endregion

        #region Constructor
        public UC_Tree()
        {
            InitializeComponent();
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Recibe un datatable y crea el menu tree
        /// </summary>
        /// <param name="dt"></param>
        public void LoadTree(DataTable dt)
        {
            dtMenu = dt;
            tvMenu.Nodes.Clear();
            if (dt.Rows.Count > 0)
            {
                AddNodes(dtMenu);
                tvMenu.ExpandAll();
                this.tvMenu.SelectedNode = tvMenu.Nodes[0];
                this.tvMenu.Focus();
            }
            _nTotNodes=tvMenu.Nodes.Count;          
            
        }

        private void AddNodes(DataTable dt)
        {
            TreeNode padre;
            TreeNode hijo;
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    hijo = new TreeNode();
                    hijo.Name = dt.Rows[i]["cFormMenu"].ToString();
                    hijo.Text = dt.Rows[i]["cMenu"].ToString();
                    hijo.Tag = dt.Rows[i]["idMenu"].ToString();
                    hijo.NodeFont = new Font("Comic Sans", 8F, System.Drawing.FontStyle.Regular);
                    if (dt.Rows[i]["idTipoMenu"].ToString()=="2")
                    {
                        hijo.ImageIndex = 4;
                        hijo.Text = hijo.Text.ToUpper();
                        hijo.NodeFont = new Font("Comic Sans", 7F, System.Drawing.FontStyle.Bold);
                    }
                    hijo.ToolTipText = dt.Rows[i]["cMenu"].ToString();
                    padre = FindParent(dt.Rows[i]["idMenuPadre"].ToString(), tvMenu.Nodes);
                    if (padre == null)
                        this.tvMenu.Nodes.Add(hijo);
                    else
                        padre.Nodes.Add(hijo);
                    padre = null;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private TreeNode FindParent(String NodoBusqueda, TreeNodeCollection nodos)
        {
            TreeNode padre = null;
            bool encontrado = false;
            int contador = 0;

            while (encontrado == false && contador < nodos.Count)
            {
                if (Convert.ToInt32(nodos[contador].Tag) == Convert.ToInt32(NodoBusqueda))
                {
                    encontrado = true;
                    padre = nodos[contador];
                }
                else
                {
                    if (nodos[contador].Nodes.Count > 0)
                    {
                        padre = FindParent(NodoBusqueda, nodos[contador].Nodes);
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

        #region Eventos

        private void UC_Tree_Load(object sender, EventArgs e)
        {
            this.tvMenu.NodeMouseClick += new TreeNodeMouseClickEventHandler(tvMenu_NodeMouseClick);
            this.tvMenu.KeyPress += tvMenu_KeyPress;
        }

        void tvMenu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter)
            {
                TreeNode node = this.tvMenu.SelectedNode;
                cargarForm(node);               
            }
            
        }        
        
        void  tvMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            cargarForm(e.Node);            
        }

        void cargarForm(TreeNodeMouseClickEventArgs e)
        {
            string cNomObjRef;
            string cNameSpace;
            int idTipoMenu;
            int idTipoClass;
            bool lBaseNegativa;
            bool lBloqueaBusquedaNombre;

            try
            {
                var query = from item in dtMenu.AsEnumerable()
                            where item["idMenu"].ToString() == e.Node.Tag.ToString()
                            select new
                            {
                                a = item["cNameSpace"],
                                b = item["cFormMenu"],
                                c = item["cNameSpace"] + "." + item["cFormMenu"],
                                d = item["idTipoMenu"],
                                e = item["idTipoClass"],
                                f = item["idMenu"],
                                g = item["lBaseNegativa"],
                                h = item ["lBloqueaBusquedaNombre"]
                            };
                cNameSpace = query.ToList()[0].a.ToString();
                cNomObjRef = query.ToList()[0].c;
                idTipoMenu = Convert.ToInt32(query.ToList()[0].d);
                idTipoClass = Convert.ToInt32(query.ToList()[0].e);
                lBaseNegativa = Convert.ToBoolean(query.ToList()[0].g);
                lBloqueaBusquedaNombre = Convert.ToBoolean(query.ToList()[0].h);

                clsVarGlobal.idMenu = Convert.ToInt32(query.ToList()[0].f);
                clsVarGlobal.lBaseNegativa = lBaseNegativa;

                if (idTipoMenu == 1)
                {
                    if (idTipoClass == 1)
                    {
                        Form frm;
                        frmBase frmShow;
                        if (!dictForm.TryGetValue(cNomObjRef, out frm) || frm.IsDisposed)
                        {
                            frm = (Form)Activator.CreateInstance(cNameSpace, cNomObjRef).Unwrap();
                        }
                        frmShow = (frmBase)frm;
                        frmShow.objFrmSemaforo = objTreeSemaforo;
                        frmShow.lBloqueaBusquedaNombre = lBloqueaBusquedaNombre;
                        frmShow.ShowDialog();                        
                        TipoRes = idTipoClass;

                    }
                    else if (idTipoClass == 2)
                    {
                        UserControl UC;

                        if (!dictUC.TryGetValue(cNomObjRef, out UC) || UC.IsDisposed)
                        {
                            UC = (UserControl)Activator.CreateInstance(cNameSpace, cNomObjRef).Unwrap();
                        }

                        TipoRes = idTipoClass;
                    }
                }
                else if (idTipoMenu == 2)
                {
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string innerexeption = ex.InnerException == null ? "" : ex.InnerException.Message;

                if ((innerexeption == "Se agotó el tiempo de espera del semáforo" || innerexeption == "No se ha encontrado la ruta de acceso de la red")
               && ex.Source == ".Net SqlClient Data Provider")
                {
                    MessageBox.Show(this, "Error de conexión con el servidor de base de datos" + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    error.cNomForGen = this.Name; error.cNomModGen = ex.Source; error.cNomObjGen = ex.TargetSite.Name; error.cTipErrGen = "02";
                    error.nLinGenErr = ex.LineNumber; error.cDesErrGen = ex.Message;
                    errorbll.RegistrarError(error);
                    MessageBox.Show(this, ex.Message + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                string innerexeption = ex.InnerException == null ? "" : ex.InnerException.Message;

                if ((innerexeption == "Se agotó el tiempo de espera del semáforo" || innerexeption == "No se ha encontrado la ruta de acceso de la red")
               && ex.Source == ".Net SqlClient Data Provider")
                {
                    MessageBox.Show(this, "Error de conexión con el servidor de base de datos" + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    error.cNomForGen = this.Name; error.cNomModGen = ex.Source; error.cNomObjGen = ex.TargetSite.Name;
                    error.cTipErrGen = "01"; error.nLinGenErr = 0; error.cDesErrGen = ex.Message;
                    errorbll.RegistrarError(error);
                    MessageBox.Show(this, ex.Message + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        void cargarForm(TreeNode nodo)
        {
            string cNomObjRef;
            string cNameSpace;
            int idTipoMenu;
            int idTipoClass;
            bool lBaseNegativa;
            bool lBloqueaBusquedaNombre;

            try
            {
                var query = from item in dtMenu.AsEnumerable()
                            where item["idMenu"].ToString() == nodo.Tag.ToString()
                            select new
                            {
                                a = item["cNameSpace"],
                                b = item["cFormMenu"],
                                c = item["cNameSpace"] + "." + item["cFormMenu"],
                                d = item["idTipoMenu"],
                                e = item["idTipoClass"],
                                f = item["idMenu"],
                                g = item["lBaseNegativa"],
                                h = item["lBloqueaBusquedaNombre"]

                            };

                cNameSpace = query.ToList()[0].a.ToString();
                cNomObjRef = query.ToList()[0].c;
                idTipoMenu = Convert.ToInt32(query.ToList()[0].d);
                idTipoClass = Convert.ToInt32(query.ToList()[0].e);

                lBaseNegativa = Convert.ToBoolean(query.ToList()[0].g);
                lBloqueaBusquedaNombre = Convert.ToBoolean(query.ToList()[0].h);

                clsVarGlobal.idMenu = Convert.ToInt32(query.ToList()[0].f);
                clsVarGlobal.lBaseNegativa = lBaseNegativa;
                
                if (idTipoMenu == 1)
                {
                    if (idTipoClass == 1)
                    {
                        Form frm;
                        frmBase frmShow;
                        if (!dictForm.TryGetValue(cNomObjRef, out frm) || frm.IsDisposed)
                        {
                            frm = (Form)Activator.CreateInstance(cNameSpace, cNomObjRef).Unwrap();
                        }
                        frmShow = (frmBase)frm;
                        frmShow.objFrmSemaforo = objTreeSemaforo;
                        frmShow.lBloqueaBusquedaNombre = lBloqueaBusquedaNombre;
                        frmShow.ShowDialog(); 
                        TipoRes = idTipoClass;

                    }
                    else if (idTipoClass == 2)
                    {
                        UserControl UC;

                        if (!dictUC.TryGetValue(cNomObjRef, out UC) || UC.IsDisposed)
                        {
                            UC = (UserControl)Activator.CreateInstance(cNameSpace, cNomObjRef).Unwrap();
                        }

                        TipoRes = idTipoClass;
                    }
                }
                else if (idTipoMenu == 2)
                {
                }

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string innerexeption = ex.InnerException == null ? "" : ex.InnerException.Message;

                if ((innerexeption == "Se agotó el tiempo de espera del semáforo" || innerexeption == "No se ha encontrado la ruta de acceso de la red")
               && ex.Source == ".Net SqlClient Data Provider")
                {
                    MessageBox.Show(this, "Error de conexión con el servidor de base de datos" + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    error.cNomForGen = this.Name; error.cNomModGen = ex.Source; error.cNomObjGen = ex.TargetSite.Name; error.cTipErrGen = "02";
                    error.nLinGenErr = ex.LineNumber; error.cDesErrGen = ex.Message;
                    errorbll.RegistrarError(error);
                    MessageBox.Show(this, ex.Message + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                string innerexeption = ex.InnerException == null ? "" : ex.InnerException.Message;

                if ((innerexeption == "Se agotó el tiempo de espera del semáforo" || innerexeption == "No se ha encontrado la ruta de acceso de la red")
               && ex.Source == ".Net SqlClient Data Provider")
                {
                    MessageBox.Show(this, "Error de conexión con el servidor de base de datos" + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    error.cNomForGen = this.Name; error.cNomModGen = ex.Source; error.cNomObjGen = ex.TargetSite.Name;
                    error.cTipErrGen = "01"; error.nLinGenErr = 0; error.cDesErrGen = ex.Message;
                    errorbll.RegistrarError(error);
                    MessageBox.Show(this, ex.Message + "\n" + innerexeption, "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        #endregion
    }
}
