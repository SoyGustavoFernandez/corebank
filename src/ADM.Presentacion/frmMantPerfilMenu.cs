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
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;

namespace ADM.Presentacion
{
    public partial class frmMantPerfilMenu : frmBase
    {

        #region Variable Globales

        clslisMenu listamenumodulo = new clslisMenu();
        clslisMenu listaselec;
        clsCNMenu cnmenu = new clsCNMenu();

        #endregion

        public frmMantPerfilMenu()
        {
            InitializeComponent();
        }

        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            cboModulo1.SelectedValue = 1;
            cargarMenu(1, 1);
        }

        private void cboListaPerfil1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboListaPerfil1.SelectedIndex >= 0)
            {
                if (cboModulo1.SelectedValue != null)
                {
                    cargarMenu((int)cboListaPerfil1.SelectedValue, (int)cboModulo1.SelectedValue);

                }
            }
        }

        private void cboModulo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModulo1.SelectedIndex >= 0)
            {
                if (cboListaPerfil1.SelectedValue != null)
                {
                    cargarMenu((int)cboListaPerfil1.SelectedValue, (int)cboModulo1.SelectedValue);
                }
            }
        }
        
        private void btnEditar1_Click(object sender, EventArgs e)
        {
            trvchMenu.Enabled = true;
            this.cboListaPerfil1.Enabled = false;
            this.cboModulo1.Enabled = false;
            btnGrabar1.Enabled = true;
            btnEditar1.Enabled = false;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            trvchMenu.Enabled = false;
            this.cboListaPerfil1.Enabled = true;
            this.cboModulo1.Enabled = true;
            btnGrabar1.Enabled = false;
            btnEditar1.Enabled = true;
            cargarMenu((int)cboListaPerfil1.SelectedValue, (int)cboModulo1.SelectedValue);

        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            /*========================================================================================
           * REGISTRO DE RASTREO
           ========================================================================================*/

            this.registrarRastreo(clsVarGlobal.User.idUsuario, clsVarGlobal.User.idUsuario, "Inicio-Asignacion de opciones menu a perfil", this.btnGrabar1);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/

            listaselec = null;
            listaselec = new clslisMenu();
            foreach (TreeNode n in trvchMenu.Nodes)
            {
                listarSelecionados(n);
            }

            cnmenu.insertarMenuPerfil(listaselec, (int)this.cboListaPerfil1.SelectedValue);
            MessageBox.Show("Se actualizó correctamente las opciones del perfil", "Menú por perfil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cargarMenu((int)cboListaPerfil1.SelectedValue, (int)cboModulo1.SelectedValue);
            this.trvchMenu.Enabled = false;
            this.cboListaPerfil1.Enabled = true;
            this.cboModulo1.Enabled = true;
            btnGrabar1.Enabled = false;
            btnEditar1.Enabled = true;

            /*========================================================================================
           * REGISTRO DE RASTREO
           ========================================================================================*/

            this.registrarRastreo(clsVarGlobal.User.idUsuario, clsVarGlobal.User.idUsuario, "Fin-Asignacion de opciones menu a perfil", this.btnGrabar1);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
        }

        #endregion

        #region Métodos

        private clslisMenu listarPorModulo(int idPerfil, int idModulo)
        {
            var lista = new clsCNMenu().listarMenuPorPerfil(idPerfil).Where(x => x.idModulo == idModulo);
            listamenumodulo.Clear();
            listamenumodulo.AddRange(lista.ToList());
            return listamenumodulo;
        }

        private void cargarMenu(int idPerfil, int idModulo)
        {
            var listamenu = listarPorModulo(idPerfil, idModulo);
            trvchMenu.Nodes.Clear();

            agregarNodos(listamenu);
            trvchMenu.ExpandAll();

            if (trvchMenu.GetNodeCount(true) > 0)
            {
                this.trvchMenu.SelectedNode = trvchMenu.Nodes[0];
                this.trvchMenu.Focus();
            }
        }

        private void agregarNodos(clslisMenu listamenu)
        {
            TreeNode padre;
            TreeNode hijo;

            for (int i = 0; i < listamenu.Count; i++)
            {
                hijo = new TreeNode();
                hijo.Name = listamenu[i].cFormMenu;
                hijo.Text = listamenu[i].idTipoMenu.In(1, 2) ? "WIN - " + listamenu[i].cMenu : listamenu[i].idTipoMenu.In(3, 4) ? "WEB - " + listamenu[i].cMenu : "MOVIL - " + listamenu[i].cMenu;
                hijo.Tag = listamenu[i];
                hijo.NodeFont = new Font("Comic Sans", 8F, System.Drawing.FontStyle.Regular);
                hijo.ToolTipText = listamenu[i].cMenu;
                hijo.Checked = listamenu[i].lActivo;

                padre = buscarPadre(listamenu[i].idMenuPadre.ToString(), trvchMenu.Nodes);
                if (padre == null)
                    this.trvchMenu.Nodes.Add(hijo);
                else
                    padre.Nodes.Add(hijo);
                padre = null;
            }


        }

        private TreeNode buscarPadre(String NodoBusqueda, TreeNodeCollection nodos)
        {
            TreeNode padre = null;
            bool encontrado = false;
            int contador = 0;

            while (encontrado == false && contador < nodos.Count)
            {
                if (((clsMenu)nodos[contador].Tag).idMenu == Convert.ToInt32(NodoBusqueda))
                {
                    encontrado = true;
                    padre = nodos[contador];
                }
                else
                {
                    if (nodos[contador].Nodes.Count > 0)
                    {
                        padre = buscarPadre(NodoBusqueda, nodos[contador].Nodes);
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

        private void listarSelecionados(TreeNode treeMenu)
        {
            clsMenu item = (clsMenu)treeMenu.Tag;
            item.lActivo = treeMenu.Checked;
            listaselec.Add(item);

            foreach (TreeNode itemTree in treeMenu.Nodes)
            {

                listarSelecionados(itemTree);
            }
        }        

        #endregion
		
    }
}
