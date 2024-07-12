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
using GEN.CapaNegocio;
using EntityLayer;
using GEN.Funciones;

namespace ADM.Presentacion
{
    public partial class frmMantProdRiesgos : frmBase
    {
        List<clsProductoTipEval> listaOriginal;
        List<clsProductoTipEval> listaModificada;
        clsCNEvalCred objEval;
        public frmMantProdRiesgos()
        {
            InitializeComponent();
        }

        private void frmMantProdRiesgos_Load(object sender, EventArgs e)
        {
            this.cboTipEvalCred1.cargarTipEvaluacion(2);
            this.ControlEventos(EventoFormulario.INICIO);
        }

        private void CargarProductos()
        {
            this.objEval = new clsCNEvalCred();
            int idTipEvalCredSel = 0;
            idTipEvalCredSel = Convert.ToInt32(cboTipEvalCred1.SelectedValue);
            DataTable dtProd = this.objEval.ListarProductosPorTipoEvaluacion(idTipEvalCredSel);
            this.listaOriginal = DataTableToList.ConvertTo<clsProductoTipEval>(dtProd).ToList<clsProductoTipEval>();
            this.listaModificada = (List<clsProductoTipEval>) this.listaOriginal.Clone<clsProductoTipEval>();

            this.bindingSourceProductos.DataSource = this.listaModificada;

            dtgBase1.DataSource = this.bindingSourceProductos;
            FormatoGrid();            
        }

        private void FormatoGrid()
        {
            foreach (DataGridViewColumn item in dtgBase1.Columns)
            {
                item.Visible = false;
            }

            dtgBase1.Columns["cProducto"].HeaderText = "Producto";
            dtgBase1.Columns["cProducto"].Visible = true;

            dtgBase1.Columns["lInfoRiesgosResum"].HeaderText = "Info. Riesgos";
            dtgBase1.Columns["lInfoRiesgosResum"].Visible = true;
            dtgBase1.Columns["lInfoRiesgosResum"].Width = 40;
        }

        private void cboTipEvalCred1_SelectedValueChanged(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void limpiarFormulario() 
        {
            cboTipEvalCred1.SelectedIndex = -1;
        }

        private void ControlEventos(EventoFormulario eForm)
        {
            switch (eForm)
            {
                case EventoFormulario.INICIO:
                case EventoFormulario.CANCELAR:
                    btnEditar1.Enabled = true;
                    btnGrabar1.Enabled = false;
                    btnCancelar1.Enabled = false;
                    dtgBase1.Enabled = true;
                    dtgBase1.ReadOnly = true;
                    dtgBase1.Columns["lInfoRiesgosResum"].ReadOnly = true;
                    break;
                case EventoFormulario.EDITAR:
                    btnEditar1.Enabled = false;
                    btnGrabar1.Enabled = true;
                    btnCancelar1.Enabled = true;
                    dtgBase1.Enabled = true;
                    dtgBase1.ReadOnly = false;
                    dtgBase1.Columns["cProducto"].ReadOnly = true;
                    dtgBase1.Columns["lInfoRiesgosResum"].ReadOnly = false;
                    break;
                
                default:
                    break;
            }
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            this.ControlEventos(EventoFormulario.EDITAR);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            List<clsProductoTipEval> list = this.ObtenerElementosModificados();
            if (list.Count == 0)
            {
                MessageBox.Show("No se ha modificado ningún registro", "Producto Opinión de Riesgos - Evaluación Resumida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable dtGuardado = this.objEval.GuardarProductosOpinionRiesgosEvalResumida(list.ListObjectToXml(), clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
            MessageBox.Show("Se ha registrado los productos correctamente", "Producto Opinión de Riesgos - Evaluación Resumida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.ControlEventos(EventoFormulario.INICIO);
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.ControlEventos(EventoFormulario.INICIO);
        }

        private List<clsProductoTipEval> ObtenerElementosModificados()
        {
            List<clsProductoTipEval> listaGuardar = new List<clsProductoTipEval>();

            foreach (clsProductoTipEval item1 in listaModificada)
            {
                foreach (clsProductoTipEval item2 in listaOriginal)
                {
                    if (item1.idProductoTipEval == item2.idProductoTipEval)
                    {
                        if (item1.lInfoRiesgosResum != item2.lInfoRiesgosResum)
                        {
                            listaGuardar.Add((clsProductoTipEval)item1.Clone());
                        }
                    }
                }
            }
            return listaGuardar;
        }
    }
}
