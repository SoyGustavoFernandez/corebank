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
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmListaDocObligatoriosCre : frmBase
    {
        #region Variable Globales

        clsCNControlExp cnExp = new clsCNControlExp();
        DataTable dtDocumentos;
        int idTipoPersona = 0;
        int idProducto = 0;
        int idSolicitud = 0;
        string cTituloMsg = "Lista de documentos para pasar a comité";

        #endregion

        public frmListaDocObligatoriosCre()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="idTipoPer">identificador del tipo de persona: natural | jurídica</param>
        /// <param name="idProd">identificador del producto</param>
        /// <param name="idSol">identificador de la solicitud de crédito</param>
        public frmListaDocObligatoriosCre(int idTipoPer, int idProd, int idSol)
        {
            InitializeComponent();

            idTipoPersona = idTipoPer;
            idProducto = idProd;
            idSolicitud = idSol;

            conProducto1.cargarProductos(1, idProducto);
            conProducto1.Enabled = false;
            
            cboTipoPersona1.SelectedValue = idTipoPersona;
            cboTipoPersona1.Enabled = false;
            btnBusqueda1.Enabled = false;
            btnCancelar1.Enabled = false;
            cargarDatos();
        }
        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            pintarTitulos();
            /// cargarDatos();
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            if (!conProducto1.validarSeleccion())
            {
                return;
            }

            if (Convert.ToInt32(cboTipoPersona1.SelectedIndex) < 0)
            {
                MessageBox.Show("Seleccione el tipo de persona", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            idTipoPersona = Convert.ToInt32(cboTipoPersona1.SelectedValue);
            idProducto = Convert.ToInt32(conProducto1.cboSubProducto.SelectedValue);

            cargarDatos();
        }

        private void dtgListaSeleccionable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;

            if (indice < 0)
            {
                return;
            }

            string cColumna = dtDocumentos.Columns[e.ColumnIndex].ToString();
            if (cColumna.In("lSeleccionado"))
            {
                int idPadre = Convert.ToInt32(dtDocumentos.Rows[indice]["idPadre"]);
                Boolean lSelected = Convert.ToBoolean(dtgListaSeleccionable.Rows[indice].Cells[cColumna].Value);
                if (idPadre != 0)
                {
                    actualizaPadre(idPadre, cColumna);
                    return;
                }

                int idDocExp = Convert.ToInt32(dtDocumentos.Rows[indice]["idDocExp"]);

                SelecionarHijos(idDocExp, lSelected, cColumna);
            }
        }

        private void dtgListaSeleccionable_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgListaSeleccionable.IsCurrentCellDirty)
            {
                dtgListaSeleccionable.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (!conProducto1.validarSeleccion())
            {
                return;
            }

            if (cboTipoPersona1.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un tipo de persona", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dtgListaSeleccionable.RowCount == 0)
            {
                MessageBox.Show("No hay documentos para seleccionar, coordine con el área de TI", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if(!validarSeleccion()) // validar la selección de los valores
            {
                MessageBox.Show("Debe seleccionar los documentos que tiene el cliente", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataSet dsGuardar = new DataSet("dsGuardar");
            if (dtDocumentos.DataSet == null)
            {
                dsGuardar.Tables.Add(dtDocumentos);
            }
            
            string cXml = dsGuardar.GetXml();


            DataTable dtResultado = cnExp.CNGuardaDocTieneSolicitud(idSolicitud, cXml);
            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMsg, MessageBoxButtons.OK, (Convert.ToInt32(dtResultado.Rows[0]["nResultado"]) == 1) ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            
        }
        #endregion

        #region Métodos
        private Boolean validarSeleccion()
        {
            foreach (DataRow item in dtDocumentos.Rows)
            {
                if (Convert.ToBoolean(item["lSeleccionado"]))
                {
                    return true;
                }
            }
            return false;
        }
        private void cargarDatos()
        {
            if (idSolicitud == 0)
            {
                MessageBox.Show("No se ha asignado una solicitud", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dtDocumentos = cnExp.CNObtenerListaDocObligatorios(idTipoPersona, idProducto, idSolicitud);
            foreach (DataColumn item in dtDocumentos.Columns)
            {
                item.ReadOnly = false;
            }

            dtgListaSeleccionable.DataSource = dtDocumentos;
            if (dtDocumentos.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron ningun documento asignado para esa combinación", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            formatoGrid();
        }

        private bool validar()
        {
            bool lValida = false;


            return lValida;
        }

        private void formatoGrid()
        {
            dtgListaSeleccionable.ReadOnly = false;
            foreach (DataGridViewColumn item in dtgListaSeleccionable.Columns)
            {
                item.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }

            dtgListaSeleccionable.Columns["cDocumento"].Width = 435;
            dtgListaSeleccionable.Columns["lSeleccionado"].Width = 50;

            dtgListaSeleccionable.Columns["cDocumento"].Visible = true;
            dtgListaSeleccionable.Columns["cDocumento"].ReadOnly = true;
            dtgListaSeleccionable.Columns["lSeleccionado"].Visible = true;

            dtgListaSeleccionable.Columns["cDocumento"].HeaderText = "Documento";
            dtgListaSeleccionable.Columns["lSeleccionado"].HeaderText = "Sel";

            pintarTitulos();
        }

        private void limpiar()
        {

        }

        private void pintarTitulos()
        {
            foreach (DataGridViewRow item in dtgListaSeleccionable.Rows)
            {
                if (Convert.ToInt32(item.Cells["idPadre"].Value) == 0)
                {
                    item.DefaultCellStyle.BackColor = Color.Silver;
                }
            }
        }

        private void actualizaPadre(int idPadre, string cColumna)
        {
            int nTotalElem = 0;
            int nTotalElemSel = 0;
            foreach (DataRow item in dtDocumentos.Rows)
            {
                if (idPadre == Convert.ToInt32(item["idPadre"]))
                {
                    nTotalElem++;
                    if (Convert.ToBoolean(item[cColumna]))
                    {
                        nTotalElemSel++;
                    }
                }


            }

            foreach (DataRow item in dtDocumentos.Rows)
            {
                if (idPadre == Convert.ToInt32(item["idDocExp"]))
                {
                    item[cColumna] = (nTotalElemSel == nTotalElem) ? true : false;
                }


            }


        }

        private void SelecionarHijos(int idDocExp, Boolean lBol, string cColumna)
        {
            foreach (DataRow item in dtDocumentos.Rows)
            {
                if (Convert.ToInt32(item["idPadre"]) == idDocExp)
                {
                    item[cColumna] = lBol;
                }
            }
            // dtDocumentos.AcceptChanges();
            // pintarTitulos();
        }
        #endregion

        
    }
}
