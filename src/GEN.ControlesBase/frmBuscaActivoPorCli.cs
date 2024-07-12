using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LOG.CapaNegocio;
using EntityLayer;


namespace GEN.ControlesBase
{
    public partial class frmBuscaActivoPorCli : frmBase
    {
        #region Variables

        public int idCatalogo = 0;
        public string cProducto = "";
        public string cAgencia = "";
        public string cMoneda = "";
        public int idAgenciaOrigen = 0;
        public bool lBuscaCli = false;
        public int idMoneda = 0;
        public List<clsDetTransferenciasActivo> listaActivosSeleccionados = new List<clsDetTransferenciasActivo>();
        public List<clsActivo> listaActivosSel = new List<clsActivo>(); 

        List<clsDetTransferenciasActivo> listaActivos = new List<clsDetTransferenciasActivo>();
        
        BindingSource bs = new BindingSource();

        #endregion
        
        public frmBuscaActivoPorCli()
        {
            InitializeComponent();
        }

        private void frmBuscaActivoPorCli_Load(object sender, EventArgs e)
        {
            lblProducto.Text = cProducto;
            lblAgencia.Text = cAgencia;
            lblMoneda.Text = cMoneda;
            string cSerie = txtSerie.Text;
            buscarActivosPorUsuario(cSerie, idAgenciaOrigen, idCatalogo, 0, idMoneda);
            conBusCol1.Visible = lBuscaCli;
        }

        private void conBusCol1_BuscarUsuario(object sender, EventArgs e)
        {
        }

        #region Métodos

        private void buscarActivosPorUsuario(string cSerie, int idAgencia, int idCatalogo, int idUsuario = 0, int idMoneda = 0)
        {
            listaActivos = new clsCNAlmacen().CNListaActivosPorUsuarioResponsable(cSerie, idAgencia, idCatalogo, idUsuario, idMoneda);

            if (listaActivos.Count == 0)
            {
                MessageBox.Show("No se encotraron ", "Busca activo por usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            dtgActivosUsuario.DataSource = null;
            bs.DataSource = listaActivos;
            dtgActivosUsuario.DataSource = bs;
            formatoGrid();
        }

        private void formatoGrid()
        {
            dtgActivosUsuario.ReadOnly = false;
            foreach (DataGridViewColumn item in dtgActivosUsuario.Columns)
            {
                item.Visible = false;
                item.ReadOnly = true;

            }
            dtgActivosUsuario.Columns["lSel"].ReadOnly = false;

            dtgActivosUsuario.Columns["lSel"].Visible = true;
            dtgActivosUsuario.Columns["cNomAgencia"].Visible = true;
            dtgActivosUsuario.Columns["cProducto"].Visible = true;
            dtgActivosUsuario.Columns["cSerie"].Visible = true;
            dtgActivosUsuario.Columns["cWinUser"].Visible = true;

            dtgActivosUsuario.Columns["lSel"].HeaderText = "S.";
            dtgActivosUsuario.Columns["cNomAgencia"].HeaderText = "Agencia";
            dtgActivosUsuario.Columns["cProducto"].HeaderText = "Producto";
            dtgActivosUsuario.Columns["cSerie"].HeaderText = "Serie";
            dtgActivosUsuario.Columns["cWinUser"].HeaderText = "Usu. Resp.";
        }

        private void checkTodos()
        {
            foreach (clsDetTransferenciasActivo item in listaActivos)
            {
                item.lSel = chcTodos.Checked;
            }
            dtgActivosUsuario.DataSource = null;
            bs.DataSource = listaActivos;
            dtgActivosUsuario.DataSource = bs;
            formatoGrid();
        }

        private void validarTodosSel()
        {
            int nElementos = listaActivos.Count;
            int nElemSel = 0;
            foreach (clsDetTransferenciasActivo item in listaActivos)
            {
                if (item.lSel)
                {
                    nElemSel++;
                }
            }
            chcTodos.Checked = (nElementos == nElemSel) ? true : false;
        }

        #endregion

        #region Eventos
        
        private void dtgActivosUsuario_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgActivosUsuario.DataSource == null)
                return;

            if (dtgActivosUsuario.RowCount == 0)
                return;

            if (dtgActivosUsuario.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay ninguna activo", "Busca activo por usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            validarTodosSel();
        }

        #endregion

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            foreach (clsDetTransferenciasActivo item in listaActivos)
            {
                if (item.lSel)
                {
                    listaActivosSeleccionados.Add(item);
                    listaActivosSel.Add(item.getActivo());
                }
            }

            this.Dispose();
        }

        private void chcTodos_CheckedChanged(object sender, EventArgs e)
        {
            checkTodos();
        }

        private void dtgActivosUsuario_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgActivosUsuario.IsCurrentCellDirty)
            {
                dtgActivosUsuario.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnMiniBusq1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSerie.Text))
            {
                MessageBox.Show("Ingrese una serie", "Busca activo por usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            buscarActivosPorUsuario(txtSerie.Text, idAgenciaOrigen, idCatalogo, idMoneda);
        }

        private void conBusCol1_BuscarUsuario_1(object sender, EventArgs e)
        {

            if (conBusCol1.idUsu == null)
            {
                return;
            }
            buscarActivosPorUsuario("", idAgenciaOrigen, 0, Convert.ToInt32(conBusCol1.idUsu), idMoneda);
        }        
    }
}
