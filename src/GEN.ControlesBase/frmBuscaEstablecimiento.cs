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
using GRH.CapaNegocio;
using CAJ.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class frmBuscaEstablecimiento : frmBase
    {
        #region Variables
        public string pcNombreEstablecimiento;
        public int pnNivelOrden = 0;
        public int pnidEstablecimiento = 0;
        public int pnIdEstablecimientoPadre = 0;
        string pcTipTrx = "";
        private TreeNode m_OldSelectNode;
        clsLstCentroCosto lstEstablecimiento = new clsLstCentroCosto();
        clsCNEstablecimeinto cnBuscaEstablecimiento = new clsCNEstablecimeinto();

        public int idZona = 0;
        public int idAgencia = 0;
        public bool lSelectAgencia = false;
        public bool lFiltroZona = false;
        private Dictionary<string, object> dConfig = null;
        #endregion

        #region Metodos
        public frmBuscaEstablecimiento()
        {
            InitializeComponent();
        }

        private void habilitarControles(int idPerfil)
        {
            if (clsVarApl.dicVarGen["cPerfilSupervisionOficina"] != "")
            {
                this.dConfig = parseConfig(clsVarApl.dicVarGen["cPerfilSupervisionOficina"]);
                string[] supervisorOperaciones = (string[])dConfig["supervisorOperaciones"];
                string[] supervisorRecuperaciones = (string[])dConfig["supervisorRecuperaciones"];
                string[] jefeOficina = (string[])dConfig["jefeOficina"];
                string[] gerenteRegional = (string[])dConfig["gerenteRegional"];
                string[] jefeOperaciones = (string[])dConfig["jefeOperaciones"];
                string[] jefeRecuperaciones = (string[])dConfig["jefeRecuperaciones"];
                string[] monitorCorporativo = (string[])dConfig["monitorCorporativo"];

                if (Array.IndexOf(supervisorOperaciones, idPerfil.ToString()) != -1)
                {
                    cboZona1.cargarZonasAsignadas(clsVarGlobal.User.idUsuario);
                }
                else if (Array.IndexOf(supervisorRecuperaciones, idPerfil.ToString()) != -1)
                {
                    cboZona1.cargarZonasAsignadas(clsVarGlobal.User.idUsuario);
                }
                else if (Array.IndexOf(jefeOficina, idPerfil.ToString()) != -1)
                {
                    cboZona1.cargarZona(true, false);
                    DataTable dtRes = new clsCNVisitaSupervisionOperacion().getZonaUsuario(clsVarGlobal.User.idUsuario);
                    int idZona = Convert.ToInt32(dtRes.Rows[0]["idZona"]);
                    cboZona1.SelectedValue = (int)idZona;
                    cboZona1.Enabled = false;
                }
                else if (Array.IndexOf(gerenteRegional, idPerfil.ToString()) != -1)
                {
                    cboZona1.cargarZonasAsignadas(clsVarGlobal.User.idUsuario);
                }
                else if (Array.IndexOf(jefeOperaciones, idPerfil.ToString()) != -1)
                {
                    cboZona1.cargarZona(true, false);
                }
                else if (Array.IndexOf(jefeRecuperaciones, idPerfil.ToString()) != -1)
                {
                    cboZona1.cargarZona(true, false);
                }
                else if (Array.IndexOf(monitorCorporativo, idPerfil.ToString()) != -1)
                {
                    cboZona1.cargarZona(true, false);
                }
                else
                {
                    cboZona1.SelectedIndex = -1;
                }
            }
        }

        public Dictionary<string, object> parseConfig(string sConfig)
        {
            Dictionary<string, object> config = new Dictionary<string, object>();
            string[] configs = sConfig.Split(';');
            for (int i = 0; i < configs.Length; i++)
            {
                string[] parts = configs[i].Split(':');
                if (parts.Length == 2)
                {
                    config.Add(parts[0], parts[1].Split(','));
                }
            }
            return config;
        }

        private void mostrarAgenciaEstablecimiento(int idPadre, int idZona_, int idAgencia_)
        {
            DataTable lstEstab = cnBuscaEstablecimiento.ListadoEstablecimientos(idPadre, idZona_, idAgencia_);

            if (lstEstab.Rows.Count > 0)
            {
                lstEstablecimiento.Clear();
                foreach (DataRow item in lstEstab.Rows)
                {
                    lstEstablecimiento.Add(new clsCentroCosto()
                    {
                        IdCentroCosto = Convert.ToInt32(item["IdEstablecimiento"].ToString()),
                        cCentroCosto = item["cEstablecimiento"].ToString(),
                        IdCentroCostoPadre = Convert.ToInt32(item["IdEstablecimientoPadre"].ToString()),
                        lVigente = Convert.ToBoolean(item["lVigente"].ToString()),
                        nOrden = Convert.ToInt32(item["nOrden"].ToString()),
                    });
                }

                conTreeEstablecimiento1.LlenarCentroCostos(lstEstablecimiento);
                conTreeEstablecimiento1.trvNavi.SelectedNode = conTreeEstablecimiento1.trvNavi.Nodes[0];
                conTreeEstablecimiento1.trvNavi.Select();
            }
        }
        #endregion

        #region Eventos
        private void frmBuscaEstablecimiento_Load(object sender, EventArgs e)
        {
            conTreeEstablecimiento1.trvNavi.Nodes.Clear();

            cboZona1.SelectedIndexChanged -= cboZona1_SelectedIndexChanged;
            if (lFiltroZona)
            {
                habilitarControles(clsVarGlobal.PerfilUsu.idPerfil);
            }
            else
            {
                cboZona1.cargarZona(true, false);
            }

            if (cboZona1.SelectedIndex >= 0)
            {
                mostrarAgenciaEstablecimiento(0, Convert.ToInt32(cboZona1.SelectedValue), idAgencia);
            }

            cboZona1.SelectedIndexChanged += cboZona1_SelectedIndexChanged;

            if (idZona != 0)
            {
                cboZona1.SelectedValue = idZona;
                cboZona1.Enabled = false;
            }
        }

        private void conTreeEstablecimiento1_Load(object sender, EventArgs e)
        {
            conTreeEstablecimiento1.trvNavi.AfterSelect += new TreeViewEventHandler(trvNavi_AfterSelect);
            conTreeEstablecimiento1.trvNavi.AfterCollapse += new TreeViewEventHandler(trvNavi_AfterCollapse);
            conTreeEstablecimiento1.trvNavi.AfterExpand += new TreeViewEventHandler(trvNavi_AfterExpand);
            conTreeEstablecimiento1.trvNavi.AfterExpand += new TreeViewEventHandler(trvNavi_AfterExpand);
        }

        void trvNavi_AfterExpand(object sender, TreeViewEventArgs e)
        {
            int lnPadre = 0;
            if ((clsCentroCosto)e.Node.Tag != null)
            {
                lnPadre = ((clsCentroCosto)e.Node.Tag).IdCentroCosto;
            }
        }

        void trvNavi_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            int lnPadre = 0;
            if ((clsCentroCosto)e.Node.Tag != null)
            {
                lnPadre = ((clsCentroCosto)e.Node.Tag).IdCentroCosto;
            }
        }

        void trvNavi_AfterSelect(object sender, TreeViewEventArgs e)
        {
            cargarDatos();
            e.Node.Expand();
        }
        private void cargarDatos()
        {
            if ((clsCentroCosto)conTreeEstablecimiento1.trvNavi.SelectedNode.Tag != null)
            {
                clsCentroCosto clsCentroCosto = ((clsCentroCosto)conTreeEstablecimiento1.trvNavi.SelectedNode.Tag);
                pnNivelOrden = clsCentroCosto.nOrden;
                pnidEstablecimiento = clsCentroCosto.IdCentroCosto;
                pnIdEstablecimientoPadre = clsCentroCosto.IdCentroCostoPadre;
                pcNombreEstablecimiento = clsCentroCosto.cCentroCosto;
            }
            
        }

        private void txtBuscar1_TextChanged(object sender, EventArgs e)
        {
            txtBuscar1.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtBuscar1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                buscarXDescripcion(txtBuscar1.Text);
            }
        }
        void buscarXDescripcion(string texto)
        {
            TreeNode trItemSe = buscarPorDescripcion(texto, conTreeEstablecimiento1.trvNavi.Nodes);
            if (trItemSe != null)
            {
                conTreeEstablecimiento1.trvNavi.CollapseAll();
                conTreeEstablecimiento1.trvNavi.SelectedNode = trItemSe;
                conTreeEstablecimiento1.trvNavi.Select();
            }
            else
            {
                MessageBox.Show("No se encontro la Agencia / Establecimiento", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (!lSelectAgencia)
            {
                if (conTreeEstablecimiento1.trvNavi.SelectedNode.Nodes.Count > 0)
                {
                    MessageBox.Show("No seleccionó una Agencia / Establecimiento", "Seleccion de Agencia / Establecimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pnidEstablecimiento = 0;
                    return;
                }
            }
            this.FormClosing -= frmBuscaEstablecimiento_FormClosing;

            Dispose();
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            pnidEstablecimiento = 0;
        }

        private void frmBuscaEstablecimiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            pnidEstablecimiento = 0;
        }

        private void cboZona1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboZona1.SelectedIndex >= 0)
            {
                mostrarAgenciaEstablecimiento(0, Convert.ToInt32(cboZona1.SelectedValue), idAgencia);
            }
        }
        #endregion
    }
}
