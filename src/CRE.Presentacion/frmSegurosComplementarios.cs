using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmSegurosComplementarios : frmBase
    {
        clsCNPaqueteSeguro PaqueteSeguros = new clsCNPaqueteSeguro();
        clsMantenimientoPaqueteSeguro _clsMantenimientoPaqueteSeguro = new clsMantenimientoPaqueteSeguro();
        List<clsSeguroComplementario> listaSegurosComplementario = new List<clsSeguroComplementario>();
        List<clsSeguroComplementario> listaSegurosComplementarioInicial = new List<clsSeguroComplementario>();
        clsSeguroComplementario _clsSeguroComplementario = new clsSeguroComplementario();

        private string cNombreCompleto = "";
        public int nfilaseleccionada, idUsuario = clsVarGlobal.User.idUsuario;
        BindingSource bsSeguroComplementario = new BindingSource();

        public frmSegurosComplementarios()
        {
            InitializeComponent();
            CargaDatosInicial();
        }
        public frmSegurosComplementarios(clsMantenimientoPaqueteSeguro oPaquete)
        {
            InitializeComponent();
            CargaDatosInicial();
            _clsMantenimientoPaqueteSeguro = oPaquete;
            listaSegurosComplementarioInicial = new List<clsSeguroComplementario>(_clsMantenimientoPaqueteSeguro.listaSeguroCommplementario);
            cargarDatos();
        }
        private void CargaDatosInicial()
        {
            cboEstados.Cargar();
            cboEstados.SelectedIndex = -1;
        }
        public void cargarDatos()
        {
            listaSegurosComplementario.Clear();
            listaSegurosComplementario.AddRange(PaqueteSeguros.CNListarSeguroComplementario().ToList<clsSeguroComplementario>());
            seguroComplementarioAgregado();
        }
        public void seguroComplementarioAgregado()
        {

            foreach (var seguroComplementario in listaSegurosComplementario)
            {
                var seguroTemp = listaSegurosComplementarioInicial.FirstOrDefault(x => x.idSeguro == seguroComplementario.idSeguro);
                seguroComplementario.lSelecciona = seguroTemp == null ? false : seguroTemp.lSelecciona;
            }
            TipoEstadoFiltro();
         }
        private void frmSegurosComplementarios_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            cboEstados.SelectedValue = -1;
        }

        public void TipoEstadoFiltro()
        {
            if (cboEstados.SelectedIndex == 1)
            {
                llenarGridSeguroComplementarios(listaSegurosComplementario.FindAll(x => x.lVigente).ToList());
            }
            else if (cboEstados.SelectedIndex == 2)
            {
                llenarGridSeguroComplementarios(listaSegurosComplementario.FindAll(x => !x.lVigente).ToList());
            }
            else if(cboEstados.SelectedIndex == 0)
            {
                llenarGridSeguroComplementarios(listaSegurosComplementario.ToList());
            }
        }
        public void llenarGridSeguroComplementarios(List<clsSeguroComplementario> listSeguroComplementario)
        {
            bsSeguroComplementario.DataSource = listSeguroComplementario;
            dtgSeguroComplementario.DataSource = bsSeguroComplementario;
            dtgSeguroComplementario.AutoResizeColumns();
            dtgSeguroComplementario.ClearSelection();
            styleGridSeguroComplementarios();
            dtgSeguroComplementario.Refresh();
        }
        public void styleGridSeguroComplementarios()
        {
            foreach (DataGridViewColumn columna in dtgSeguroComplementario.Columns)
            {
                columna.Visible = false;
            }
            dtgSeguroComplementario.Columns["lSelecciona"].ReadOnly = false;
            dtgSeguroComplementario.Columns["lSelecciona"].DisplayIndex = 0;
            dtgSeguroComplementario.Columns["cSeguro"].DisplayIndex = 1;
            dtgSeguroComplementario.Columns["cSeguroCorto"].DisplayIndex = 2;
            dtgSeguroComplementario.Columns["nPrecio"].DisplayIndex = 3;
            dtgSeguroComplementario.Columns["lVigente"].DisplayIndex = 4;
            dtgSeguroComplementario.Columns["lSelecciona"].Visible = true;
            dtgSeguroComplementario.Columns["cSeguro"].Visible = true;
            dtgSeguroComplementario.Columns["cSeguroCorto"].Visible = true;
            dtgSeguroComplementario.Columns["nPrecio"].Visible = true;
            dtgSeguroComplementario.Columns["lVigente"].Visible = true;
            dtgSeguroComplementario.Columns["lSelecciona"].HeaderText = "Sel";
            dtgSeguroComplementario.Columns["cSeguro"].HeaderText = "Nombre Seguro";
            dtgSeguroComplementario.Columns["cSeguroCorto"].HeaderText = "Abreviatura";
            dtgSeguroComplementario.Columns["nPrecio"].HeaderText = "Precio";
            dtgSeguroComplementario.Columns["lVigente"].HeaderText = "Estado";
        }
        private void cboEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoEstadoFiltro();
        }
        private void btnMiniBusqueda1_Click(object sender, EventArgs e)
        {
            cNombreCompleto = txtBuscarSeguroComplementario.Text;
            llenarGridSeguroComplementarios(listaSegurosComplementario.FindAll(x => x.cSeguro.Contains(cNombreCompleto) || x.cSeguroCorto.Contains(cNombreCompleto)).ToList());
        }
        private void dtgSeguroComplementario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            else if (e.ColumnIndex == dtgSeguroComplementario.Columns["lSelecciona"].Index)
            {
                bool isChecked = (bool)dtgSeguroComplementario.Rows[e.RowIndex].Cells["lSelecciona"].Value;
                int idSeguro = Convert.ToInt32(dtgSeguroComplementario.Rows[e.RowIndex].Cells["idSeguro"].Value);

                dtgSeguroComplementario.Rows[e.RowIndex].Cells["lSelecciona"].Value = !isChecked;
                dtgSeguroComplementario.Refresh();
                if (!isChecked)
                {
                    listaSegurosComplementario.Find(x => x.idSeguro == idSeguro).lSelecciona = true;
                    listaSegurosComplementarioInicial.Add(listaSegurosComplementario.Find(x => x.idSeguro == idSeguro));
                }
                else
                {
                    listaSegurosComplementario.Find(x => x.idSeguro == idSeguro).lSelecciona = false;
                    listaSegurosComplementarioInicial.RemoveAll(x => x.idSeguro == idSeguro);
                }
            }
            else
            {
                dtgSeguroComplementario.Rows[e.RowIndex].Selected = true;
            }
        }
        private bool validarSeguroDuplicado(int idSeguro)
        {           
            bool existeSimilitud = false;
            _clsMantenimientoPaqueteSeguro.listaSeguroCommplementario.AsEnumerable
                    ().ToList().ForEach(x =>
                    {
                        if (x.idSeguro == idSeguro)
                        {
                            existeSimilitud = true;                            
                        }
                    });
            return existeSimilitud;           
        }
        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            foreach (var inicial in listaSegurosComplementarioInicial.ToList())
            {
                var actual = listaSegurosComplementario.FirstOrDefault(a => a.idSeguro == inicial.idSeguro);
                if (actual != null)
                {
                    inicial.cSeguro = actual.cSeguro;
                    inicial.cSeguroCorto = actual.cSeguroCorto;
                    inicial.nPrecio = actual.nPrecio;
                    inicial.lVigente = actual.lVigente;
                    inicial.lSelecciona = actual.lSelecciona;
                }
            }

            bool noVigente = listaSegurosComplementarioInicial.Any(x => x.lSelecciona && !x.lVigente);
            if (noVigente)
            {
                MessageBox.Show("No se puede agregar seguros complementarios no vigentes.", "Seguros Complementarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _clsMantenimientoPaqueteSeguro.listaSeguroCommplementario = listaSegurosComplementarioInicial;
            this.Close();
        }
        private void btnMiniNuevo1_Click(object sender, EventArgs e)
        {
            _clsSeguroComplementario.idSeguro = 0;
            frmEditarSeguroComplementario frmEditarSeguroComplementario = new frmEditarSeguroComplementario(_clsSeguroComplementario);
            frmEditarSeguroComplementario.ShowDialog();
            cargarDatos();
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMiniEditar1_Click(object sender, EventArgs e)
        {
            if (dtgSeguroComplementario.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una fila para editar.", "Seguros Complementarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                nfilaseleccionada = Convert.ToInt32(dtgSeguroComplementario.CurrentCell.RowIndex);
                _clsSeguroComplementario.idSeguro = Convert.ToInt32(dtgSeguroComplementario.Rows[nfilaseleccionada].Cells["idSeguro"].Value.ToString());
                _clsSeguroComplementario.cSeguro = dtgSeguroComplementario.Rows[nfilaseleccionada].Cells["cSeguro"].Value.ToString();
                _clsSeguroComplementario.cSeguroCorto = dtgSeguroComplementario.Rows[nfilaseleccionada].Cells["cSeguroCorto"].Value.ToString();
                _clsSeguroComplementario.lVigente = Convert.ToBoolean(dtgSeguroComplementario.Rows[nfilaseleccionada].Cells["lVigente"].Value.ToString());
                _clsSeguroComplementario.nPrecio = Convert.ToDecimal(dtgSeguroComplementario.Rows[nfilaseleccionada].Cells["nPrecio"].Value.ToString());
                frmEditarSeguroComplementario frmEditarSeguroComplementario = new frmEditarSeguroComplementario(_clsSeguroComplementario);
                frmEditarSeguroComplementario.ShowDialog();
                cargarDatos();
            }
        }
    }
}