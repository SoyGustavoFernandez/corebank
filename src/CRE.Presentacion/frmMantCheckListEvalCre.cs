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
    public partial class frmMantCheckListEvalCre : frmBase
    {
        #region Variable Globales
        
        clsCNControlExp cnExp = new clsCNControlExp();
        DataTable dtDocumentos;
        int nCodPro = 1;
        string cTituloMsg = "Check list - créditos";
        int idProducto = 0;
        Transaccion nTrans;
        #endregion

        public frmMantCheckListEvalCre()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            nTrans =  Transaccion.Selecciona;
            controlBotones();
        }


        #endregion

        #region Métodos
        private void cargarDtGrid()
        {
            dtDocumentos = cnExp.CNListaDocsPorProducto(idProducto); // Documentos Créditos
            foreach (DataColumn item in dtDocumentos.Columns)
            {
                item.ReadOnly = false;
            }

            dtgListaDocumentos.DataSource = dtDocumentos;
            dtgListaDocumentos.ReadOnly = false;
            formatoGrid();
            pintarTitulos();
            actualizarTodosPadres();
            MessageBox.Show("Se cargo los documentos del producto", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private bool validar()
        {
            bool lValida = false;


            return lValida;
        }

        private void formatoGrid()
        {
            foreach (DataGridViewColumn item in dtgListaDocumentos.Columns)
            {
                item.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }

            dtgListaDocumentos.Columns["cDocumento"].Width = 424;
            dtgListaDocumentos.Columns["lObligaPerNat"].Width = 100;
            dtgListaDocumentos.Columns["lObligaPerJur"].Width = 100;

            dtgListaDocumentos.Columns["cDocumento"].ReadOnly = true;
            dtgListaDocumentos.Columns["lObligaPerNat"].ReadOnly = false;
            dtgListaDocumentos.Columns["lObligaPerJur"].ReadOnly = false;

            dtgListaDocumentos.Columns["cDocumento"].Visible = true;
            dtgListaDocumentos.Columns["lObligaPerNat"].Visible = true;
            dtgListaDocumentos.Columns["lObligaPerJur"].Visible = true;

            dtgListaDocumentos.Columns["cDocumento"].HeaderText = "Documento";
            dtgListaDocumentos.Columns["lObligaPerNat"].HeaderText = "P. Natural";
            dtgListaDocumentos.Columns["lObligaPerJur"].HeaderText = "P. Jurídica";
        }

        private void limpiar()
        {
            conProducto1.limpiar();

            if (dtgListaDocumentos.DataSource != null)
            {
                ((DataTable)dtgListaDocumentos.DataSource).Clear();
            }
        }

        private void pintarTitulos()
        {
            foreach (DataGridViewRow item in dtgListaDocumentos.Rows)
            {
                if (Convert.ToInt32(item.Cells["idPadre"].Value) == 0)
                {
                    item.DefaultCellStyle.BackColor = Color.Silver;
                }
            }
        }

        private void controlBotones()
        {
            switch (nTrans)
            { 
                case Transaccion.Selecciona:
                    btnBusqueda1.Enabled = true;
                    btnEditar1.Enabled = false;
                    btnCancelar1.Enabled = false;
                    btnGrabar1.Enabled = false;
                    break;
                case Transaccion.Edita:
                    btnBusqueda1.Enabled = false;
                    btnEditar1.Enabled = false;
                    btnCancelar1.Enabled = true;
                    btnGrabar1.Enabled = true;
                    break;
                case Transaccion.Elimina:
                case Transaccion.Nuevo:
                    btnBusqueda1.Enabled = true;
                    btnEditar1.Enabled = true;
                    btnCancelar1.Enabled = false;
                    btnGrabar1.Enabled = false;
                    
                    break;
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

        private Boolean validarSeleccionDocs()
        {
            int nSeleccionados = 0;
            foreach (DataRow item in dtDocumentos.Rows)
            {
                if (Convert.ToBoolean(item["lObligaPerNat"]) == true)
                {
                    nSeleccionados++;
                }
                if (Convert.ToBoolean(item["lObligaPerJur"]) == true)
                {
                    nSeleccionados++;
                }
            }

            return (nSeleccionados > 0) ? true : false;
        }

        private DataTable obtenerDatos(DataTable dt)
        {
            DataTable dtRes = new DataTable("dtDocumentos");
            dtRes.Columns.Add("idDocExp", typeof(int));
            dtRes.Columns.Add("idPadre", typeof(int));
            dtRes.Columns.Add("lObligaPerNat", typeof(Boolean));
            dtRes.Columns.Add("lObligaPerJur", typeof(Boolean));

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dtRes.NewRow();
                dr["idDocExp"] = item["idDocExp"];
                dr["idPadre"] = item["idPadre"];
                dr["lObligaPerNat"] = item["lObligaPerNat"];
                dr["lObligaPerJur"] = item["lObligaPerJur"];
                dtRes.Rows.Add(dr);
            }

            return dtRes;
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
                    item[cColumna] = (nTotalElemSel == nTotalElem)? true: false;    
                }                
            }

        }

        private void actualizarTodosPadres()
        {
            foreach (DataRow item in dtDocumentos.Rows)
            {
                actualizaPadre(Convert.ToInt32(item["idPadre"]), "lObligaPerNat");
                actualizaPadre(Convert.ToInt32(item["idPadre"]), "lObligaPerJur");
            }
        }

        private void bloquearFrm(Boolean lBol)
        {
            ReadOnlyGrid(!lBol);
            conProducto1.Enabled = !lBol;
        }

        private void ReadOnlyGrid(Boolean lBol)
        {
            dtgListaDocumentos.Columns["lObligaPerNat"].ReadOnly = lBol;
            dtgListaDocumentos.Columns["lObligaPerJur"].ReadOnly = lBol;
        }
        #endregion

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (!conProducto1.validarSeleccion())
            {
                return;
            }

            if (!validarSeleccionDocs())
            {
                MessageBox.Show("Seleccione al menos un documento", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idProducto = Convert.ToInt32(conProducto1.cboSubProducto.SelectedValue);
            DataSet dsGuardar = new DataSet("dsDocumentos");
            dsGuardar.Tables.Add(obtenerDatos(dtDocumentos));
            string cXml = dsGuardar.GetXml();
            
            DataTable dtResultado = cnExp.CNGuardarListaDocsXProducto(idProducto, cXml);

            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMsg, MessageBoxButtons.OK, (Convert.ToInt32(dtResultado.Rows[0]["nResultado"]) == 1) ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            nTrans = Transaccion.Nuevo;
            controlBotones();
            bloquearFrm(false);
            cargarDtGrid();
            ReadOnlyGrid(true);

        }

        private void dtgListaDocumentos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            int indice = e.RowIndex;

            if (indice < 0)
            {
                return;
            }

            string cColumna = dtDocumentos.Columns[e.ColumnIndex].ToString();
            if (cColumna.In("lObligaPerNat", "lObligaPerJur"))
            {
                int idPadre = Convert.ToInt32(dtDocumentos.Rows[indice]["idPadre"]);
                Boolean lSelected = Convert.ToBoolean(dtgListaDocumentos.Rows[indice].Cells[cColumna].Value);
                if (idPadre != 0)
                {
                    actualizaPadre(idPadre, cColumna);
                    return;
                }

                int idDocExp = Convert.ToInt32(dtDocumentos.Rows[indice]["idDocExp"]);
                
                SelecionarHijos(idDocExp, lSelected, cColumna);
            }  
        }

        private void dtgListaDocumentos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgListaDocumentos.IsCurrentCellDirty)
            {
                dtgListaDocumentos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            if (!conProducto1.validarSeleccion())
            {
                return;
            }

            idProducto = Convert.ToInt32(conProducto1.cboSubProducto.SelectedValue);
            cargarDtGrid();
            nTrans = Transaccion.Nuevo;
            ReadOnlyGrid(true);
            controlBotones();
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (!conProducto1.validarSeleccion())
            {
                return;
            }
            if (dtDocumentos.Rows.Count == 0)
            {
                MessageBox.Show("Tiene que buscar los documentos por producto", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBusqueda1.Focus();
                return;
            }
            nTrans = Transaccion.Edita;
            controlBotones();
            bloquearFrm(true);
            ReadOnlyGrid(false);
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            nTrans = Transaccion.Nuevo;
            controlBotones();
            bloquearFrm(false);
            cargarDtGrid();
            ReadOnlyGrid(true);
        }
    }
}
