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
    public partial class frmMantenimientoMenu : frmBase
    {

        #region Variable Globales

        clsCNMenu cnmenu = new clsCNMenu();
        Transaccion ope;

        #endregion

        public frmMantenimientoMenu()
        {
            InitializeComponent();
        }

        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cboModulo1.SelectedValue = 1;
            cargarMenu(1);
        }
                
        private void cboModulo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModulo1.SelectedIndex >= 0)
            {
                cargarMenu((int)cboModulo1.SelectedValue);
            }
        }

        private void trvMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {


            clsMenu menusel = (clsMenu)trvMenu.SelectedNode.Tag;

            txtDescripcion.Text = menusel.cMenu;
            txtNameSpace.Text = menusel.cNameSpace;
            txtnombreForm.Text = menusel.cFormMenu;

            rbtnActivo.Checked = menusel.lVigente == true ? true : false;
            rbtnInactivo.Checked = menusel.lVigente == true ? false : true;
            txtOrden.Text = menusel.nOrden.ToString();
            chcBaseNegativa.Checked=menusel.lBaseNegativa;

            this.cboTipoControl1.SelectedValue = menusel.idTipoClass;
            this.cboTipoMenu1.SelectedValue = menusel.idTipoMenu;
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            grbDetMenu.Enabled = true;
            this.trvMenu.Enabled = false;
            btnGrabar1.Enabled = true;
            btnCancelar1.Enabled = true;
            btnAgregar1.Enabled = false;
            ope = Transaccion.Edita;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            grbDetMenu.Enabled = false;
            this.trvMenu.Enabled = true;

            btnGrabar1.Enabled = false;
            btnCancelar1.Enabled = false;
            btnAgregar1.Enabled = true;
            btnEditar1.Enabled = true;

            ope = Transaccion.Edita;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if ((int)this.cboTipoMenu1.SelectedValue == 1)
            {

                if (string.IsNullOrEmpty(this.txtNameSpace.Text))
                {
                    MessageBox.Show("Debe ingresar el name space del formulario/control", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNameSpace.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(this.txtnombreForm.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre del formulario/control", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtnombreForm.Focus();
                    return;
                }

            }

            clsMenu menuselecionado = (clsMenu)trvMenu.SelectedNode.Tag; ;
            clsMenu nuevomenu = null;
            if (ope == Transaccion.Edita)
            {
                nuevomenu = menuselecionado;
            }
            else
            {
                nuevomenu = new clsMenu();
                nuevomenu.idMenu = 0;
                nuevomenu.idModulo = menuselecionado.idModulo;
            }

            nuevomenu.cMenu = txtDescripcion.Text.Trim();
            nuevomenu.cFormMenu = txtnombreForm.Text.Trim();
            nuevomenu.cNameSpace = txtNameSpace.Text.Trim();
            nuevomenu.lVigente = rbtnActivo.Checked == true ? true : false;
            nuevomenu.idTipoClass = (int)this.cboTipoControl1.SelectedValue;
            nuevomenu.idTipoMenu = (int)this.cboTipoMenu1.SelectedValue;
            nuevomenu.nOrden = Convert.ToInt32(txtOrden.Text);
            nuevomenu.idTipoProc = 1;
            nuevomenu.lBaseNegativa = chcBaseNegativa.Checked;

            if (ope == Transaccion.Nuevo)
            {
                if ((int)cboNivelMenu1.SelectedValue == 2)
                {
                    nuevomenu.idMenuPadre = menuselecionado.idMenu;
                }
                else
                {
                    nuevomenu.idMenuPadre = menuselecionado.idMenuPadre;
                }
            }
            if ((int)this.cboTipoMenu1.SelectedValue == 2)
            {
                nuevomenu.cFormMenu = "";
                nuevomenu.cNameSpace = "";
            }


            cnmenu.insertActMenu(nuevomenu);

            MessageBox.Show("Se grabaron los datos correctamente", "Registro Menú", MessageBoxButtons.OK, MessageBoxIcon.Information);

            cargarMenu((int)cboModulo1.SelectedValue);
            grbDetMenu.Enabled = false;
            trvMenu.Enabled = true;

            btnGrabar1.Enabled = false;
            btnCancelar1.Enabled = false;
            btnAgregar1.Enabled = true;
            btnEditar1.Enabled = true;
            ope = Transaccion.Edita;
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            if (trvMenu.SelectedNode == null)
            {
                MessageBox.Show("Seleccione una opción para agregar una opción nueva", "Agregar menú", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            limpiarControles();
            grbDetMenu.Enabled = true;
            btnGrabar1.Enabled = true;
            btnCancelar1.Enabled = true;
            btnEditar1.Enabled = false;
            ope = Transaccion.Nuevo;
        }
        
        #endregion

        #region Métodos

        private void cargarMenu(int idModulo)
        {
            var listamenu = cnmenu.listaropcionesmenu(idModulo);
            this.trvMenu.Nodes.Clear();

            agregarNodos(listamenu);
            trvMenu.ExpandAll();

            if (trvMenu.GetNodeCount(true) > 0)
            {
                this.trvMenu.SelectedNode = trvMenu.Nodes[0];
                this.trvMenu.Focus();
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
                hijo.Text = listamenu[i].cMenu;
                hijo.Tag = listamenu[i];
                hijo.NodeFont = new Font("Comic Sans", 8F, System.Drawing.FontStyle.Regular);
                hijo.ToolTipText = listamenu[i].cMenu;
                hijo.Checked = listamenu[i].lActivo;
                if (listamenu[i].idTipoMenu == 2)
                {
                    hijo.ImageIndex = 4;
                }
                if (listamenu[i].idTipoMenu == 4)
                {
                    hijo.ImageIndex = 1;
                }
                padre = buscarPadre(listamenu[i].idMenuPadre.ToString(), this.trvMenu.Nodes);
                if (padre == null)
                    this.trvMenu.Nodes.Add(hijo);
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
        
        private void limpiarControles()
        {
            txtDescripcion.Text = "";
            txtOrden.Text = "0";
            txtnombreForm.Text = "";
            txtNameSpace.Text = "";
            this.cboNivelMenu1.SelectedValue = 1;
            this.cboTipoControl1.SelectedValue = 1;
            this.cboTipoMenu1.SelectedValue = 1;
        }

        #endregion
       
    }
}
;