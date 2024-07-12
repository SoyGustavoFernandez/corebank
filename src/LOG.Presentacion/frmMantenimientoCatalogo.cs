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
using LOG.CapaNegocio;
namespace LOG.Presentacion
{
    public partial class frmMantenimientoCatalogo : frmBase
    {

        #region Variables

        int pnNivelOrden = 0;
        int pnidGrupo = 0;
        int pnIdPadre = 0;
        string pcTipTrx = "";
        private TreeNode m_OldSelectNode;
        clsLstGrupoActivo lstGrupoActivo = new clsLstGrupoActivo();
        clsCNCatalogo cnBuscaGrupo = new clsCNCatalogo();

        #endregion

        #region Eventos

        private void frmMantenimientoGrupos_Load(object sender, EventArgs e)
        {
            int idTipoBien = Convert.ToInt32(cboTipoBien.SelectedValue);
            lstGrupoActivo = cnBuscaGrupo.buscaGrupoActivo(idTipoBien, -1);

            conTreeCatalogo.LlenarGrupoActivo(lstGrupoActivo);
            
            if (conTreeCatalogo.trvNavi.Nodes.Count > 0)
            {
                conTreeCatalogo.trvNavi.SelectedNode = conTreeCatalogo.trvNavi.Nodes[0];
                conTreeCatalogo.trvNavi.Select();
            }
            
            cboTipoNivel.Enabled = false;            
        }

        private void cboTipoBien_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnNivelOrden = 0;
            pnidGrupo = 0;
            pnIdPadre = 0;

            int idTipoBien = Convert.ToInt32(cboTipoBien.SelectedValue);
            lstGrupoActivo.Clear();
            lstGrupoActivo = cnBuscaGrupo.buscaGrupoActivo(idTipoBien, -1);
            conTreeCatalogo.LlenarGrupoActivo(lstGrupoActivo);
            if (conTreeCatalogo.trvNavi.Nodes.Count <= 0)
            {
                btnEditar.Enabled = false;
                btnNuevo.Enabled = true;

                lblGrupo.Visible = true;
                lblSubGrupo.Visible = false;
                lblRubro.Visible = false;
                lblNiv.Text = "Grupo";
                txtNombre.Clear();
                txtContable.Clear();
                LimpiarDatos();
            }
        }

        private void conTreeCatalogo_Load(object sender, EventArgs e)
        {
            conTreeCatalogo.trvNavi.AfterSelect += new TreeViewEventHandler(trvNavi_AfterSelect);
            conTreeCatalogo.trvNavi.AfterCollapse += new TreeViewEventHandler(trvNavi_AfterCollapse);
            conTreeCatalogo.trvNavi.AfterExpand += new TreeViewEventHandler(trvNavi_AfterExpand);
            conTreeCatalogo.trvNavi.MouseUp += new MouseEventHandler(trvNavi_MouseUp);
            conTreeCatalogo.trvNavi.ItemDrag += conTreeCatalogo_ItemDrag;
            conTreeCatalogo.trvNavi.DragDrop += conTreeCatalogo_DragDrop;
            conTreeCatalogo.trvNavi.DragEnter += conTreeCatalogo_DragEnter;
        }

        private void trvNavi_AfterSelect(object sender, TreeViewEventArgs e)
        {
            cargarDatos();
            e.Node.Expand();
        }

        private void trvNavi_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            int lnPadre;
            lnPadre = ((clsGrupoActivo)e.Node.Tag).idGrupoActivo;
        }

        private void trvNavi_AfterExpand(object sender, TreeViewEventArgs e)
        {
            int lnPadre;
            lnPadre = ((clsGrupoActivo)e.Node.Tag).idGrupoActivo;
            Habilitar(false, 1);
        }

        private void trvNavi_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Point where the mouse is clicked.
                Point p = new Point(e.X, e.Y);

                // Get the node that the user has clicked.
                TreeNode node = conTreeCatalogo.trvNavi.GetNodeAt(p);

                if (node != null)
                {
                    m_OldSelectNode = conTreeCatalogo.trvNavi.SelectedNode;
                    conTreeCatalogo.trvNavi.SelectedNode = node;
                }

                TreeNode trItemSe = buscar(((clsGrupoActivo)node.Tag).idGrupoActivo.ToString(), conTreeCatalogo.trvNavi.Nodes);
                if (trItemSe != null)
                {
                    clsGrupoActivo objCtaCtb = ((clsGrupoActivo)trItemSe.Tag);

                    this.txtNombre.Text = objCtaCtb.cNombreGrupo;
                }
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            txtNombre.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtContable_TextChanged(object sender, EventArgs e)
        {
            txtContable.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            txtDescripcion.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            txtBuscar1.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                buscarXDescripcion(txtBuscar1.Text);
            }
        }

        private void cboNivelMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitarPorNivelMenu();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cboTipoBien.Enabled = false;
            txtBuscar1.Enabled = false;

            if (pnNivelOrden == 0)
            {
                cboTipoNivel.SelectedValue = 2;
                cboTipoNivel.Enabled = false;
            }
            if (pnNivelOrden == 1 || pnNivelOrden == 2 || pnNivelOrden == 3)
            {
                cboTipoNivel.SelectedValue = 2;
                cboTipoNivel.Enabled = true;
            }
            if (pnNivelOrden == 4)
            {
                cboTipoNivel.SelectedValue = 1;
                cboTipoNivel.Enabled = false;
            }

            HabilitarPorNivelMenu();
            conTreeCatalogo.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cboTipoBien.Enabled = false;
            txtBuscar1.Enabled = false;
            cboTipoNivel.Enabled = false;

            if (pnNivelOrden == 4)
            {
                Habilitar(true, 2);
                grbCatalogo.Enabled = true;
            }
            else
            {
                Habilitar(true, 1);
                grbCatalogo.Enabled = false;
            }

            conTreeCatalogo.Enabled = false;
            pcTipTrx = "E";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (conTreeCatalogo.trvNavi.Nodes.Count > 0)
            {
                cargarDatos();
                if (pnNivelOrden == 4)
                {
                    Habilitar(false, 2);
                }
                else
                {
                    Habilitar(false, 1);
                }
                pcTipTrx = "";
                conTreeCatalogo.Enabled = true;
            }
            else
            {
                this.txtNombre.Enabled = false;
                this.txtContable.Enabled = false;
                btnDebe.Enabled = false;
                btnCancelar.Enabled = true;
                btnGrabar.Enabled = false;
                btnEditar.Enabled = false;
                btnNuevo.Enabled = true;
                pcTipTrx = "";
                conTreeCatalogo.Enabled = true;
            }
            cboTipoBien.Enabled = true;
            cboTipoNivel.Enabled = false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //pcTipTrx == "N" // Mismo Nivel
            //pcTipTrx == "A" // Nivel Hijo
            //pcTipTrx == "E" // Editar

            if ((pcTipTrx == "N" && pnNivelOrden == 4) || (pcTipTrx == "A" && pnNivelOrden == 3))
            {
                if (validarDatosCatalogo())
                {
                    return;
                }
                string cProducto = txtDescripcion.Text;
                int idTipoBien = Convert.ToInt32(cboTipoBien.SelectedValue);
                int idGrupo = (pcTipTrx == "N") ? pnIdPadre : pnidGrupo;
                bool lVigente = true;
                int idUnidadCompra = Convert.ToInt32(cboUniMedCom.SelectedValue);
                int idUnidadAlmacenaje = Convert.ToInt32(cboUniMedAlm.SelectedValue);
                decimal nValConversion = Convert.ToDecimal(txtValCon.Text);
                int idUsuReg = clsVarGlobal.User.idUsuario;
                DateTime dFechaReg = clsVarGlobal.dFecSystem;
                bool lIndActivo = chcActivo.Checked;
                int idEstado = 1;

                DataTable dtResp = cnBuscaGrupo.GrabarNuevoCatalogo(cProducto, idTipoBien, idGrupo, lVigente,
                                                idUnidadCompra, idUnidadAlmacenaje, nValConversion,
                                                idUsuReg, dFechaReg, lIndActivo, idEstado);
                if (dtResp.Rows[0][0].ToString() != "0")
                {
                    MessageBox.Show(dtResp.Rows[0][1].ToString() + " Nº " + dtResp.Rows[0][0].ToString(), "Registro de Catalogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conTreeCatalogo.Enabled = true;

                    lstGrupoActivo.Clear();
                    lstGrupoActivo = cnBuscaGrupo.buscaGrupoActivo(idTipoBien, -1);
                    conTreeCatalogo.LlenarGrupoActivo(lstGrupoActivo);
                    buscarXDescripcion(cProducto);
                    cboTipoBien.Enabled = true;
                    txtBuscar1.Enabled = true;
                }
            }
            else if (pcTipTrx == "E" && pnNivelOrden == 4)
            {
                if (validarDatosCatalogo())
                {
                    return;
                }
                string cProducto = txtDescripcion.Text;
                int idTipoBien = Convert.ToInt32(cboTipoBien.SelectedValue);
                int idGrupo = pnIdPadre;
                bool lVigente = chcActivo.Checked;
                int idUnidadCompra = Convert.ToInt32(cboUniMedCom.SelectedValue);
                int idUnidadAlmacenaje = Convert.ToInt32(cboUniMedAlm.SelectedValue);
                decimal nValConversion = Convert.ToDecimal(txtValCon.Text);
                int idUsuReg = clsVarGlobal.User.idUsuario;
                DateTime dFechaReg = clsVarGlobal.dFecSystem;
                bool lIndActivo = chcActivo.Checked;
                int idEstado = 1;
                int idCatalogo = Convert.ToInt32(txtCodigo.Text);

                DataTable dtResp = cnBuscaGrupo.GrabarEdicionCatalogo(idCatalogo, cProducto, idTipoBien, idGrupo, lVigente,
                                                idUnidadCompra, idUnidadAlmacenaje, nValConversion,
                                                idUsuReg, dFechaReg, lIndActivo, idEstado);
                if (dtResp.Rows[0][0].ToString() != "0")
                {
                    MessageBox.Show(dtResp.Rows[0][1].ToString() + " Nº " + dtResp.Rows[0][0].ToString(), "Registro de Catalogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conTreeCatalogo.Enabled = true;
                    lstGrupoActivo.Clear();
                    lstGrupoActivo = cnBuscaGrupo.buscaGrupoActivo(idTipoBien, -1);
                    conTreeCatalogo.LlenarGrupoActivo(lstGrupoActivo);
                    buscarXDescripcion(cProducto);
                    cboTipoBien.Enabled = true;
                    txtBuscar1.Enabled = true;
                }
            }
            else if (pcTipTrx == "N" && (pnNivelOrden == 1 || pnNivelOrden == 2 || pnNivelOrden == 3))
            {
                if (validarDatosGrupo())
                {
                    return;
                }
                if (conTreeCatalogo.trvNavi.Nodes.Count <= 0)
                {
                    pnIdPadre = 0;
                }

                int idGrupoActivo = 0;
                string cNombreGrupo = txtNombre.Text;
                int idPadre = pnIdPadre;
                int idTipoBien = Convert.ToInt32(cboTipoBien.SelectedValue);
                bool lvigente = true;
                string cCuentaContable = txtContable.Text;
                DataTable dtResp = cnBuscaGrupo.GrabarGrupoCatalogo(idGrupoActivo, cNombreGrupo, idPadre,
                                                                idTipoBien, lvigente, cCuentaContable);
                if (dtResp.Rows[0][0].ToString() != "0")
                {
                    MessageBox.Show(dtResp.Rows[0][1].ToString() + " Nº " + dtResp.Rows[0][0].ToString(), "Registro de Catalogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conTreeCatalogo.Enabled = true;
                    lstGrupoActivo.Clear();
                    lstGrupoActivo = cnBuscaGrupo.buscaGrupoActivo(idTipoBien, -1);
                    conTreeCatalogo.LlenarGrupoActivo(lstGrupoActivo);
                    buscarXDescripcion(cNombreGrupo);
                    cboTipoBien.Enabled = true;
                    txtBuscar1.Enabled = true;
                }
            }
            else if (pcTipTrx == "E" && (pnNivelOrden == 1 || pnNivelOrden == 2 || pnNivelOrden == 3))
            {
                if (validarDatosGrupo())
                {
                    return;
                }
                if (conTreeCatalogo.trvNavi.Nodes.Count <= 0)
                {
                    pnIdPadre = 0;
                }
                int idGrupoActivo = pnidGrupo;
                string cNombreGrupo = txtNombre.Text;
                int idPadre = pnIdPadre;
                int idTipoBien = Convert.ToInt32(cboTipoBien.SelectedValue);
                bool lvigente = true;
                string cCuentaContable = txtContable.Text;
                DataTable dtResp = cnBuscaGrupo.GrabarGrupoCatalogo(idGrupoActivo, cNombreGrupo, idPadre,
                                                                idTipoBien, lvigente, cCuentaContable);
                if (dtResp.Rows[0][0].ToString() != "0")
                {
                    MessageBox.Show(dtResp.Rows[0][1].ToString() + " Nº " + dtResp.Rows[0][0].ToString(), "Registro de Catalogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conTreeCatalogo.Enabled = true;
                    lstGrupoActivo.Clear();
                    lstGrupoActivo = cnBuscaGrupo.buscaGrupoActivo(idTipoBien, -1);
                    conTreeCatalogo.LlenarGrupoActivo(lstGrupoActivo);
                    buscarXDescripcion(cNombreGrupo);
                    cboTipoBien.Enabled = true;
                    txtBuscar1.Enabled = true;
                }
            }
            else if (pcTipTrx == "A" && (pnNivelOrden == 0 || pnNivelOrden == 1 || pnNivelOrden == 2))
            {
                if (validarDatosGrupo())
                {
                    return;
                }
                if (conTreeCatalogo.trvNavi.Nodes.Count <= 0)
                {
                    pnIdPadre = 0;
                }
                int idGrupoActivo = 0;
                string cNombreGrupo = txtNombre.Text;
                int idPadre = pnidGrupo;
                int idTipoBien = Convert.ToInt32(cboTipoBien.SelectedValue);
                bool lvigente = true;
                string cCuentaContable = txtContable.Text;
                DataTable dtResp = cnBuscaGrupo.GrabarGrupoCatalogo(idGrupoActivo, cNombreGrupo, idPadre,
                                                                idTipoBien, lvigente, cCuentaContable);
                if (dtResp.Rows[0][0].ToString() != "0")
                {
                    MessageBox.Show(dtResp.Rows[0][1].ToString() + " Nº " + dtResp.Rows[0][0].ToString(), "Registro de Catalogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conTreeCatalogo.Enabled = true;
                    lstGrupoActivo.Clear();
                    lstGrupoActivo = cnBuscaGrupo.buscaGrupoActivo(idTipoBien, -1);
                    conTreeCatalogo.LlenarGrupoActivo(lstGrupoActivo);
                    buscarXDescripcion(cNombreGrupo);
                    cboTipoBien.Enabled = true;
                    txtBuscar1.Enabled = true;
                }
            }

            if (pnNivelOrden == 4)
            {
                Habilitar(false, 2);
            }
            else
            {
                Habilitar(false, 1);
            }
            pcTipTrx = "";
            cboTipoNivel.Enabled = false;
        }

        #endregion 

        #region Metodos

        public frmMantenimientoCatalogo()
        {
            InitializeComponent();
        }

        private void cargarDatos()
        {
            clsGrupoActivo clsCatalago = ((clsGrupoActivo)conTreeCatalogo.trvNavi.SelectedNode.Tag);

            if (clsCatalago.nOrden == 1)
            {
                lblGrupo.Visible = true;
                lblSubGrupo.Visible = false;
                lblRubro.Visible = false;
                lblNiv.Text = "Grupo";
            }
            if (clsCatalago.nOrden == 2)
            {
                lblGrupo.Visible = false;
                lblSubGrupo.Visible = true;
                lblRubro.Visible = false;

                lblNiv.Text = @"Grupo \ Sub Grupo";
            }
            if (clsCatalago.nOrden == 3)
            {
                lblGrupo.Visible = false;
                lblSubGrupo.Visible = false;
                lblRubro.Visible = true;
                lblNiv.Text = @"Grupo \ Sub Grupo \ Rubro";
            }

            if (clsCatalago.nOrden == 1 || clsCatalago.nOrden == 2 || clsCatalago.nOrden == 3)
            {
                txtNombre.Text = clsCatalago.cNombreGrupo;
                txtContable.Text = clsCatalago.cContable;

                LimpiarDatos();
                grbCatalogo.Enabled = false;

            }
            if (clsCatalago.nOrden == 4)
            {
                txtDescripcion.Text = clsCatalago.cNombreGrupo;

                var itemLst = lstGrupoActivo.Where(x => x.idGrupoActivo == clsCatalago.idPadre && x.nOrden == 3).ToList();

                foreach (var item1 in itemLst)
                {
                    txtNombre.Text = item1.cNombreGrupo;
                    txtContable.Text = item1.cContable;
                    lblGrupo.Visible = false;
                    lblSubGrupo.Visible = false;
                    lblRubro.Visible = true;
                }
                BuscarDatosCatalogo(clsCatalago.idGrupoActivo);
                Habilitar(false, 2);

            }
            pnNivelOrden = clsCatalago.nOrden;
            pnidGrupo = clsCatalago.idGrupoActivo;
            pnIdPadre = clsCatalago.idPadre;
        }

        private void LimpiarDatos()
        {
            txtCodigo.Clear();
            cboUniMedCom.SelectedIndex = -1;
            cboUniMedAlm.SelectedIndex = -1;
            txtDescripcion.Clear();
            txtValCon.Text = "0.00";
            chcActivo.Checked = false;
        }

        private void Habilitar(Boolean lHabilita, int opcion)
        {
            if (opcion == 1)//Grupos
            {
                this.txtNombre.Enabled = lHabilita;
                this.txtContable.Enabled = lHabilita;
                btnDebe.Enabled = lHabilita;
            }
            if (opcion == 2)//Catalogo
            {
                grbCatalogo.Enabled = !lHabilita;
                cboUniMedAlm.Enabled = lHabilita;
                cboUniMedCom.Enabled = lHabilita;
                txtValCon.Enabled = lHabilita;
                txtDescripcion.Enabled = lHabilita;
                chcActivo.Enabled = lHabilita;
            }
            btnCancelar.Enabled = lHabilita;
            btnGrabar.Enabled = lHabilita;
            btnEditar.Enabled = !lHabilita;
            btnNuevo.Enabled = !lHabilita;
        }

        private void BuscarDatosCatalogo(int idCatalogo)
        {
            DataTable datCat = new clsCNCatalogo().buscarDatosCatalogoXid(idCatalogo);
            foreach (DataRow item in datCat.Rows)
            {
                txtCodigo.Text = item[0].ToString();
                cboUniMedAlm.SelectedValue = item[4];
                cboUniMedCom.SelectedValue = item[5];
                txtValCon.Text = item[3].ToString();
                txtDescripcion.Text = item[1].ToString();
                chcActivo.Checked = Convert.ToBoolean(item[7].ToString());
            }
        }

        private void cargarTreeByPadre(int idPadre, int idTipoPedido)
        {
            clsLstGrupoActivo lstGrupAct = new clsLstGrupoActivo();

            lstGrupAct.AddRange(new clsCNCatalogo().buscaGrupoActivo(idTipoPedido, 0));
            foreach (var item in lstGrupAct.ToList())
            {
                lstGrupAct.AddRange(new clsCNCatalogo().buscaGrupoActivo(idTipoPedido, item.idGrupoActivo));
            }

            lstGrupoActivo.AddRange(lstGrupAct);
            conTreeCatalogo.LlenarGrupoActivo(lstGrupoActivo);

            conTreeCatalogo.trvNavi.ExpandAll();

            TreeNode trItemSe = buscar(idPadre.ToString(), conTreeCatalogo.trvNavi.Nodes);

            if (trItemSe != null)
            {
                clsGrupoActivo objCtaCtb = ((clsGrupoActivo)trItemSe.Tag);
                trItemSe.BackColor = Color.RoyalBlue;
                trItemSe.ForeColor = Color.White;
                trItemSe.NodeFont = new Font("Calibri", 8F, System.Drawing.FontStyle.Bold);
                trItemSe.ImageIndex = 0;

                cargarDatos();
            }
            else
            {
                MessageBox.Show("No se encontro el Catalogo", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public TreeNode buscar(String idGrupoActivo, TreeNodeCollection nodos)
        {
            TreeNode padre = null;
            bool encontrado = false;
            int contador = 0;

            while (encontrado == false && contador < nodos.Count)
            {
                if (((clsGrupoActivo)nodos[contador].Tag).idGrupoActivo == Convert.ToInt32(idGrupoActivo))
                {
                    encontrado = true;
                    padre = nodos[contador];
                }
                else
                {
                    if (nodos[contador].Nodes.Count > 0)
                    {
                        padre = buscar(idGrupoActivo, nodos[contador].Nodes);
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

        public TreeNode buscarPorDescripcion(String DesGrupoCat, TreeNodeCollection nodos)
        {
            TreeNode padre = null;
            bool encontrado = false;
            int contador = 0;

            while (encontrado == false && contador < nodos.Count)
            {
                clsGrupoActivo objctactb = (clsGrupoActivo)nodos[contador].Tag;
                if (objctactb.cNombreGrupo.IndexOf(DesGrupoCat) >= 0)
                {
                    encontrado = true;
                    padre = nodos[contador];
                }
                else
                {
                    if (nodos[contador].Nodes.Count > 0)
                    {
                        padre = buscarPorDescripcion(DesGrupoCat, nodos[contador].Nodes);
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

        private bool validarDatosCatalogo()
        {
            if (String.IsNullOrEmpty(txtDescripcion.Text.Trim()))
            {
                MessageBox.Show("Ingrese la Descripción del Catalogo", "Registro de Catalogo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (cboUniMedCom.SelectedIndex == -1)
            {
                MessageBox.Show("Ingrese la Unidad de Medida de Compra del Catalogo", "Registro de Catalogo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (cboUniMedAlm.SelectedIndex == -1)
            {
                MessageBox.Show("Ingrese la Unidad de Medida de Almacenamiento del Catalogo", "Registro de Catalogo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        private bool validarDatosGrupo()
        {
            if (String.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                string mensg = "";
                if (lblGrupo.Visible)
                {
                    mensg = lblGrupo.Text;
                }
                if (lblSubGrupo.Visible)
                {
                    mensg = lblSubGrupo.Text;
                }
                if (lblRubro.Visible)
                {
                    mensg = lblRubro.Text;
                }

                MessageBox.Show("Ingrese " + mensg, "Registro de Catalogo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        private void buscarXDescripcion(string texto)
        {
            TreeNode trItemSe = buscarPorDescripcion(texto, conTreeCatalogo.trvNavi.Nodes);
            if (trItemSe != null)
            {
                conTreeCatalogo.trvNavi.CollapseAll();
                conTreeCatalogo.trvNavi.SelectedNode = trItemSe;
                conTreeCatalogo.trvNavi.Select();
            }
            else
            {
                MessageBox.Show("No se encontro el Catalogo", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void HabilitarPorNivelMenu()
        {
            // Mismo Nivel
            if ((int)cboTipoNivel.SelectedValue == 1)
            {
                if (pnNivelOrden == 4)
                {
                    LimpiarDatos();
                    Habilitar(true, 2);
                    grbCatalogo.Enabled = true;
                    chcActivo.Enabled = false;
                }
                else
                {
                    txtContable.Clear();
                    txtNombre.Clear();
                    Habilitar(true, 1);
                    grbCatalogo.Enabled = false;
                }
                pcTipTrx = "N";
            }

            // Nivel Hijo
            if ((int)cboTipoNivel.SelectedValue == 2)
            {
                if (pnNivelOrden == 4)
                {
                    Habilitar(false, 1);
                    Habilitar(false, 2);
                    LimpiarDatos();
                }
                else
                {
                    if (pnNivelOrden == 3)
                    {
                        Habilitar(false, 1);
                        Habilitar(true, 2);
                        LimpiarDatos();
                        grbCatalogo.Enabled = true;
                        cboUniMedCom.Focus();
                        chcActivo.Enabled = false;
                    }
                    else
                    {
                        if (pnNivelOrden == 1)
                        {
                            lblGrupo.Visible = false;
                            lblSubGrupo.Visible = true;
                            lblRubro.Visible = false;
                        }
                        if (pnNivelOrden == 2)
                        {
                            lblGrupo.Visible = false;
                            lblSubGrupo.Visible = false;
                            lblRubro.Visible = true;
                        }
                        Habilitar(true, 1);
                        txtNombre.Clear();
                        txtNombre.Focus();
                        txtContable.Clear();
                    }
                }
                pcTipTrx = "A";
            }
        }

        #endregion

        private void conTreeCatalogo_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void conTreeCatalogo_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode NewNode;

            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pt);
                NewNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                if (DestinationNode != NewNode)
                {
                    DestinationNode.Nodes.Add((TreeNode)NewNode.Clone());
                    DestinationNode.Expand();
                    //Remove Original Node
                    NewNode.Remove();
                }
            }
        }

        private void conTreeCatalogo_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void btnDebe_Click(object sender, EventArgs e)
        {
            frmBuscaCtaCtb frmBscCtaCtb = new frmBuscaCtaCtb();
            frmBscCtaCtb.ShowDialog();
            if (string.IsNullOrEmpty(frmBscCtaCtb.pcCtaCtb)) return;
            txtContable.Text = frmBscCtaCtb.pcCtaCtb;
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            frmFamiliaCatalogo frmFamilia = new frmFamiliaCatalogo();
            frmFamilia.ShowDialog();
        } 
    }
}
