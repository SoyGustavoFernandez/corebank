using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using CNT.CapaNegocio;
using EntityLayer;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace CNT.Presentacion
{
    public partial class frmPlanContable : frmBase
    {
        int gnHijo, pnTipTrx = 1;
        public string pcCtaCtb, pcDesCtaCtb;
        private TreeNode m_OldSelectNode;
        public frmPlanContable()
        {
            InitializeComponent();
        }

        private void Solintels_Form1_Load(object sender, EventArgs e)
        {
            cargarTree();
        }

        private void conTreeRecusivo1_Load(object sender, EventArgs e)
        {
            conTreeRecusivo1.trvNavi.AfterSelect += new TreeViewEventHandler(trvNavi_AfterSelect);
            conTreeRecusivo1.trvNavi.AfterCollapse += new TreeViewEventHandler(trvNavi_AfterCollapse);
            conTreeRecusivo1.trvNavi.AfterExpand += new TreeViewEventHandler(trvNavi_AfterExpand);
            conTreeRecusivo1.trvNavi.AfterExpand+=new TreeViewEventHandler(trvNavi_AfterExpand);
            conTreeRecusivo1.trvNavi.MouseUp += new MouseEventHandler(trvNavi_MouseUp);
            conTreeRecusivo1.cmsMenuCta.Items[0].Click += new EventHandler(frmPlanContable_Click);
            conTreeRecusivo1.cmsMenuCta.Items[1].Click += new EventHandler(frmPlanContable2_Click);
            conTreeRecusivo1.cmsMenuCta.Items[2].Click += new EventHandler(frmPlanContable3_Click);
        }

        void frmPlanContable_Click(object sender, EventArgs e)
        {
            // NUEVO
            pnTipTrx = 1;
            pcCtaCtb = this.txtCtaCtb.Text;
            this.txtCtaCtb.Enabled = true;
            this.txtDescripcion.Enabled = true;
            this.chcAgencia.Enabled = false;
            this.chcIndicaSBS.Enabled = true;
            this.chcVigente.Enabled = false;
            this.chcVigente.Checked = true;
            this.cboNaturalezaCnt.Enabled = true;
            this.txtDescripcion.Text = "";
            this.btnGrabar1.Enabled = true;
            btnImprimirAli.Enabled = false;
            btnImprimirSBS.Enabled = false;
        }

        void frmPlanContable2_Click(object sender, EventArgs e)
        {         
            //EDITAR
            pnTipTrx = 2;
            pcCtaCtb = txtCtaCtb.Text;
            this.txtCtaCtb.Enabled = false;
            this.txtDescripcion.Enabled = true;
            this.btnGrabar1.Enabled = true;
            this.chcAgencia.Enabled = true;
            this.chcIndicaSBS.Enabled = true;
            this.chcVigente.Enabled = true;
            this.cboNaturalezaCnt.Enabled = true;
            btnImprimirAli.Enabled = false;
            btnImprimirSBS.Enabled = false;
        }

        void frmPlanContable3_Click(object sender, EventArgs e)
        {
            //ELIMINAR
            pnTipTrx = 3;
            pcCtaCtb = this.txtCtaCtb.Text;
            clsCtaContable objctactb = new clsCNCtaContable().detallectactb(pcCtaCtb);
            DataTable dtTrx;
            if (objctactb.nHijos > 0)
            {
                MessageBox.Show("Cuenta tiene sub cuentas... No es Posible Desactivar", "Desactivar Cuenta Contable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (objctactb.nValSoles != 0 || objctactb.nValDolares != 0)
            {
                MessageBox.Show("Cuenta tiene saldo... No es Posible Desactivar", "Desactivar Cuenta Contable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dtTrx = new clsCNCtaContable().CNDesactivarCtaCtb(this.txtCtaCtb.Text);

            if (dtTrx.Rows.Count > 0)
            {
                MessageBox.Show(dtTrx.Rows[0]["cMensaje"].ToString(), "Actualiza Cuenta Contable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            cargarTreeByPadre(objctactb.idCuenta);
        }

        void trvNavi_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Point where the mouse is clicked.
                Point p = new Point(e.X, e.Y);

                // Get the node that the user has clicked.
                TreeNode node = conTreeRecusivo1.trvNavi.GetNodeAt(p);
                if (node != null)
                {
                    m_OldSelectNode = conTreeRecusivo1.trvNavi.SelectedNode;
                    conTreeRecusivo1.trvNavi.SelectedNode = node;
                }

                TreeNode trItemSe = buscar(((clsCtaContable)node.Tag).idCuenta.ToString(), conTreeRecusivo1.trvNavi.Nodes);
                if (trItemSe != null)
                {
                    clsCtaContable objCtaCtb = ((clsCtaContable)trItemSe.Tag);
                    trItemSe.BackColor = Color.RoyalBlue;
                    trItemSe.ForeColor = Color.White;
                    trItemSe.NodeFont = new Font("Calibri", 8F, System.Drawing.FontStyle.Bold);
                    trItemSe.ImageIndex = 0;

                    this.txtCtaCtb.Text = objCtaCtb.cCuentaContable.Substring(0, objCtaCtb.nLongitud);
                    this.txtDescripcion.Text = objCtaCtb.cDescripcion;
                    this.cboNaturalezaCnt.SelectedValue =objCtaCtb.idNaturalezaCta;
                    this.chcIndicaSBS.Checked =objCtaCtb.lIndicaSBS;
                }
                
            }

        }

        void trvNavi_AfterExpand(object sender, TreeViewEventArgs e)
        {
            int lnPadre;
            lnPadre = ((clsCtaContable)e.Node.Tag).idCuenta;
            Habilitar(false);
        }

        void trvNavi_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            int lnPadre;
            lnPadre = ((clsCtaContable)e.Node.Tag).idCuenta;
            
        }

        void trvNavi_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int lnPadre;
            lnPadre = ((clsCtaContable)conTreeRecusivo1.trvNavi.SelectedNode.Tag).idCuenta;            
            cargarTreeByPadre(lnPadre);
            this.gnHijo = lnPadre;
        }

        /// <summary>
        /// 
        /// </summary>
        void cargarTree()
        {
            conTreeRecusivo1.LlenarCuenta(new clsCNCtaContable().listarctabyidpadre(0));
            conTreeRecusivo1.trvNavi.ExpandAll();
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

            conTreeRecusivo1.LlenarCuenta(lisctactb);

            conTreeRecusivo1.trvNavi.ExpandAll();

            TreeNode trItemSe = buscar(idPadre.ToString(), conTreeRecusivo1.trvNavi.Nodes);

            if (trItemSe != null)
            {
                clsCtaContable objCtaCtb=((clsCtaContable)trItemSe.Tag);
                trItemSe.BackColor = Color.RoyalBlue;
                trItemSe.ForeColor = Color.White;
                trItemSe.NodeFont = new Font("Calibri", 8F, System.Drawing.FontStyle.Bold);
                trItemSe.ImageIndex = 0;

                txtCtaCtb.Text = objCtaCtb.cCuentaContable.Substring(0,objCtaCtb.nLongitud);
                txtBusCtaCtb.Text = objCtaCtb.cCuentaContable.Substring(0, objCtaCtb.nLongitud);
                txtDescripcion.Text = objCtaCtb.cDescripcion;
                txtValSoles.Text = objCtaCtb.nValSoles.ToString();
                txtValDolares.Text = objCtaCtb.nValDolares.ToString();
                txtValIntegrado.Text = objCtaCtb.nValorIntegrado.ToString();
                cboNaturalezaCnt.SelectedValue = objCtaCtb.idNaturalezaCta;
                chcIndicaSBS.Checked = objCtaCtb.lIndicaSBS;
                chcVigente.Checked = objCtaCtb.lVigente;
            }
            else
            {
                MessageBox.Show("No se encontro la cuenta contable", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// realiza la busqueda de un nodo en especifico
        /// </summary>
        /// <param name="idCuenta">nodo a realizar la busqueda</param>
        /// <param name="nodos"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctactb"></param>
        /// <param name="nodos"></param>
        /// <returns></returns>
        public TreeNode buscarbyctactb(String ctactb, TreeNodeCollection nodos)
        {
            TreeNode padre = null;
            bool encontrado = false;
            int contador = 0;

            while (encontrado == false && contador < nodos.Count)
            {
                clsCtaContable objctactb=(clsCtaContable)nodos[contador].Tag;
                if (objctactb.cDesCtaCtb.Substring(0,objctactb.nLongitud) == ctactb)
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string ctactb = this.txtBusCtaCtb.Text.Trim();
            clsCtaContable objctactb= new clsCNCtaContable().detallectactb(ctactb);
            cargarTreeByPadre(objctactb.idCuenta);
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            clsCtaContable objctactb = new clsCNCtaContable().detallectactb(pcCtaCtb);
            DataTable dtTrx;

            switch (pnTipTrx)
            {
                case 1: //INSERTAR 
                    if (Validar(objctactb.nLongitud, this.txtCtaCtb.Text,this.txtDescripcion.Text, objctactb.lAgencia,objctactb.nHijos,objctactb.nAgencia,objctactb.lVigente))
                    {
                        //if (chcAgencia.Checked)
                        //{
                        //    dtTrx = new clsCNCtaContable().CNInsertaCtaCtb(this.txtCtaCtb.Text, chcIndicaSBS.Checked, Convert.ToInt32(cboNaturalezaCnt.SelectedValue));
                        //}
                        //else
                        //{
                            dtTrx = new clsCNCtaContable().CNInsertaCtaCtb(this.txtCtaCtb.Text, this.txtDescripcion.Text,chcIndicaSBS.Checked,Convert.ToInt32(cboNaturalezaCnt.SelectedValue));
                        //}
                        if (dtTrx.Rows.Count > 0)
                        {
                            MessageBox.Show(dtTrx.Rows[0]["cMensaje"].ToString(), "Graba Cuenta Contable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        return;
                    }
                    break;
                case 2: //EDITAR
                    if (!string.IsNullOrEmpty(this.txtDescripcion.Text))
                    {
    
                        if (chcAgencia.Checked)
                        {
                            if (objctactb.lAgencia)
                            {
                                MessageBox.Show("El ultimo nivel de una Cuenta es la Agencia", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            dtTrx = new clsCNCtaContable().CNInsertaCtaCtb(this.txtCtaCtb.Text, chcIndicaSBS.Checked,
                                Convert.ToInt32(cboNaturalezaCnt.SelectedValue));
                        }
                        else
                        {
                            dtTrx = new clsCNCtaContable().CNActualizaCtaCtb(this.txtCtaCtb.Text,
                                this.txtDescripcion.Text, chcIndicaSBS.Checked,
                                Convert.ToInt32(cboNaturalezaCnt.SelectedValue), chcVigente.Checked);
                        }
                        if (dtTrx.Rows.Count > 0)
                        {
                            MessageBox.Show(dtTrx.Rows[0]["cMensaje"].ToString(), "Actualiza Cuenta Contable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                        break;
                case 3: //ELIMINAR
                    break;
                default:
                    break;
            }

            this.txtCtaCtb.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.chcAgencia.Checked = false;
            this.chcAgencia.Enabled = false;
            this.btnGrabar1.Enabled = false;
            this.cboNaturalezaCnt.Enabled = false;
            this.chcIndicaSBS.Enabled = false;
            this.chcVigente.Enabled = false;
            btnImprimirAli.Enabled = true;
            btnImprimirSBS.Enabled = true;

//            cargarTreeByPadre(objctactb.idCuenta);
        }
        void Habilitar(Boolean lHabilita)
        {
            this.txtCtaCtb.Enabled = lHabilita;
            this.txtDescripcion.Enabled = lHabilita;
            this.chcAgencia.Checked = false;
            this.chcAgencia.Enabled = lHabilita;
            this.btnGrabar1.Enabled = false;
            this.cboNaturalezaCnt.Enabled=false;
            this.chcIndicaSBS.Enabled = false;
            this.chcVigente.Enabled = false;
            btnImprimirAli.Enabled = true;
            btnImprimirSBS.Enabled = true;
        }

        private Boolean Validar(int nLongitudPadre, string cNuevaCuenta, string cDescri, Boolean lAgencia, int nHijos, int nAgencia, Boolean lVigente)
        {
            if (!lVigente)
            {
                MessageBox.Show("Cuenta no se encuentra activa", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (lAgencia)
            {
                MessageBox.Show("El ultimo nivel de una Cuenta es la Agencia", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (chcAgencia.Checked)
            {
                if (nLongitudPadre != cNuevaCuenta.Length)
                {
                    MessageBox.Show("Se generan agencias para la cuenta seleccionada", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (nHijos>0 & nAgencia==0)
                {
                    MessageBox.Show("Existen sub cuenta(s) sin Agencia", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                if (nLongitudPadre + 2 != cNuevaCuenta.Length)
                {
                    MessageBox.Show("La sub cuenta a crear no tiene la longitud correcta", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (string.IsNullOrEmpty(cDescri))
                {
                    MessageBox.Show("Debe registrar la descripcion de la cuenta", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }

        private void frmPlanContable_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void txtBusCtaCtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar== 13)
            {
                string ctactb = this.txtBusCtaCtb.Text.Trim();
                clsCtaContable objctactb= new clsCNCtaContable().detallectactb(ctactb);
                cargarTreeByPadre(objctactb.idCuenta);
            }
        }

        private void conTreeRecusivo1_DblClick(object sender, EventArgs e)
        {
            //this.Dispose();
        }

        private void conTreeRecusivo1_KeyTrv(object sender, KeyPressEventArgs e)
        {
            switch (Convert.ToInt32(e.KeyChar))
            {
                case 37:
                    {
                        string ctactb = this.txtBusCtaCtb.Text.Trim();
                        clsCtaContable objctactb = new clsCNCtaContable().detallectactb(ctactb);
                        cargarTreeByPadre(objctactb.idCuenta);
                        break;
                    }
                case 39:
                    {
                        string ctactb = this.txtBusCtaCtb.Text.Trim();
                        clsCtaContable objctactb = new clsCNCtaContable().detallectactb(ctactb);
                        cargarTreeByPadre(objctactb.idCuenta);
                        break;
                    }
            }
        }

        private void btnImprimirSBS_Click(object sender, EventArgs e)
        {
            bool lValor = true;
            DataTable objctactb = new clsRPTCNContabilidad().CNListaCtaCtb(lValor);
            DataTable dtSoles = objctactb.Clone();
            DataTable dtDolar = objctactb.Clone();

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            string cAgencia = clsVarApl.dicVarGen["cNomAge"];
            paramlist.Add(new ReportParameter("x_cRutaLogo", cRutaLogo, false));
            paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.ToShortDateString(), false));
            paramlist.Add(new ReportParameter("x_cAgencia", cAgencia, false));
            paramlist.Add(new ReportParameter("lIndicaSBS", lValor.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsPlanCuentas", objctactb));

            string reportpath = "rptPlanContable.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void btnImprimirAli_Click(object sender, EventArgs e)
        {
            bool lValor = false;
            DataTable objctactb = new clsRPTCNContabilidad().CNListaCtaCtb(lValor);
           
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            string cAgencia = clsVarApl.dicVarGen["cNomAge"];
            paramlist.Add(new ReportParameter("x_cRutaLogo", cRutaLogo, false));
            paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.ToShortDateString(), false));
            paramlist.Add(new ReportParameter("x_cAgencia", cAgencia, false));
            paramlist.Add(new ReportParameter("lIndicaSBS", lValor.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsPlanCuentas", objctactb));

            string reportpath = "rptPlanContable.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }
    }
}
