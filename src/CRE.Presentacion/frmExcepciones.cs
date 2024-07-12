using GEN.CapaNegocio;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmExcepciones : frmBase
    {
        #region Variables

        clsCNSolicitud cnSolicitud = new clsCNSolicitud();
        DataTable dtExcepGen = new DataTable();
        DataTable dtExcepManuales = new DataTable();
        String tmpSustento = "";
        int nIdSolicitud;
        int nIdAgencia;
        int nIdCliente;
        int nIdMoneda;
        int nIdProducto;
        decimal nValAproba;
        int nIdUsuRegist;
        int nIdReglaTmp;
        String cOpcion;

        #endregion

        public frmExcepciones()
        {
            InitializeComponent();
        }

        public frmExcepciones(int nIdSolicitud, int nIdAgencia, int nIdCliente, int nIdMoneda, int nIdProducto, decimal nValAproba, int nIdUsuRegist, String cOpcion)
        {
            this.nIdSolicitud = nIdSolicitud;
            this.nIdAgencia = nIdAgencia;
            this.nIdCliente = nIdCliente;
            this.nIdMoneda = nIdMoneda;
            this.nIdProducto = nIdProducto;
            this.nValAproba = nValAproba;
            this.nIdUsuRegist = nIdUsuRegist;
            this.cOpcion = cOpcion;
            InitializeComponent();
        }

        #region Eventos

        private void frmExcepGen_Load(object sender, EventArgs e)
        {
            btnMiniQuitar1.Enabled = false;
            btnMiniEditar1.Enabled = false;
            btnMiniAcept1.Enabled = false;
            btnNuevo.Enabled = false;
            btnMiniCancelEst1.Enabled = false;
            btnGrabar1.Enabled = false;
            cboReglas.Enabled = false;
            btnCancelar1.Enabled = false;
            dtgExcepGeneradas.Enabled = false;
            cargarGridsView();
            cboReglas.SelectedIndex = -1;
            if (dtgExcepGeneradas.Rows.Count > 0)
            {
                dtgExcepGeneradas.SelectedRows[0].Selected = false;    
            }
            txtSustento.Enabled = false;
            txtReglaDescripcion.Enabled = false;
            dtgExcepGeneradas.CellDoubleClick -= dtgExcepGeneradas_CellDoubleClick;
            dtgExcepGeneradas.SelectionChanged -= dtgExcepGeneradas_SelectionChanged;
        }
        private void btnMiniCancelEst1_Click(object sender, EventArgs e)
        {
            cboReglas.SelectedIndex = -1;
            cboReglas.Enabled = false;
            txtSustento.Enabled = false;
            txtReglaDescripcion.Enabled = false;
            btnMiniCancelEst1.Enabled = false;
            btnNuevo.Enabled = true;
            btnMiniQuitar1.Enabled = true;
            btnMiniEditar1.Enabled = true;
            btnMiniAcept1.Enabled = false;
            btnGrabar1.Enabled = true;
            dtgExcepGeneradas.Enabled = true;
            btnCancelar1.Enabled = true;
            limpiarControles();
            dtgExcepGeneradas.CellDoubleClick += dtgExcepGeneradas_CellDoubleClick;
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            btnMiniEditar1.Enabled = true;
            btnMiniQuitar1.Enabled = true;
            btnMiniCancelEst1.Enabled = false;
            btnNuevo.Enabled = true;
            btnCancelar1.Enabled = true;
            btnEditar1.Enabled = false;
            btnGrabar1.Enabled = true;
            dtgExcepGeneradas.Enabled = true;
            if (dtgExcepGeneradas.Rows.Count > 0)
            {
                dtgExcepGeneradas.Rows[0].Cells["nIdRegla"].Selected = true;
            }
            else
            {
                btnMiniEditar1.Enabled = false;
                btnMiniQuitar1.Enabled = false;
            }
            dtgExcepGeneradas.CellDoubleClick += dtgExcepGeneradas_CellDoubleClick;
            dtgExcepGeneradas.SelectionChanged += dtgExcepGeneradas_SelectionChanged;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            dtgExcepGeneradas.CellDoubleClick -= dtgExcepGeneradas_CellDoubleClick;
            btnMiniQuitar1.Enabled = false;
            btnMiniEditar1.Enabled = false;
            btnMiniAcept1.Enabled = false;
            btnNuevo.Enabled = false;
            btnMiniCancelEst1.Enabled = false;
            btnGrabar1.Enabled = false;
            cboReglas.Enabled = false;
            btnCancelar1.Enabled = false;
            btnEditar1.Enabled = true;
            txtSustento.Enabled = false;
            dtgExcepGeneradas.Enabled = false;
            limpiarControles();
            cargarGridsView();
            cboReglas.SelectedIndex = -1;
            dtgExcepGeneradas.SelectionChanged -= dtgExcepGeneradas_SelectionChanged;
            dtgExcepGeneradas.ClearSelection();
        }

        private void btnMiniQuitar1_Click(object sender, EventArgs e)
        {
            if (dtgExcepGeneradas.Rows.Count <= 1)
            {
                btnMiniEditar1.Enabled = false;
            }
            if (dtgExcepGeneradas.SelectedRows.Count > 0)
            {
                if (dtgExcepGeneradas.SelectedRows[0].Cells["cAutomatico"].Value.ToString() == "Manual")
                {
                    DataRow dtSelect = dtExcepManuales.NewRow();
                    dtSelect["nIdRegla"] = Convert.ToInt32(dtgExcepGeneradas.SelectedRows[0].Cells["nIdRegla"].Value.ToString());
                    dtSelect["cMensajeError"] = dtgExcepGeneradas.SelectedRows[0].Cells["cMensajeError"].Value.ToString();
                    dtSelect["nIdOpcion"] = Convert.ToInt32(dtgExcepGeneradas.SelectedRows[0].Cells["nIdOpcion"].Value);
                    dtSelect["idTipoOperacion"] = dtgExcepGeneradas.SelectedRows[0].Cells["idTipoOperacion"].Value.ToString();
                    dtExcepGen.Rows[dtgExcepGeneradas.SelectedRows[0].Index].Delete();
                    dtExcepGen.AcceptChanges();

                }
                else
                {
                    MessageBox.Show("No se pueden quitar excepciones automaticas", "Excepciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                foreach (DataGridViewRow dr in dtgExcepGeneradas.Rows)
                {
                    if (dr.Cells["cAutomatico"].Value.ToString() == "Automatico")
                    {
                        dr.DefaultCellStyle.BackColor = Color.FromArgb(173, 239, 156);
                    }
                    else
                    {
                        dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 222, 188);
                    }
                }

            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (dtExcepManuales.Rows.Count > 0)
            {
                cboReglas.SelectedIndex = 0;
                txtReglaDescripcion.Enabled = false;
                cboReglas.Enabled = true;
                txtSustento.Enabled = true;
                btnMiniEditar1.Enabled = false;
                btnMiniQuitar1.Enabled = false;
                btnMiniAcept1.Enabled = true;
                btnMiniCancelEst1.Enabled = true;
                btnNuevo.Enabled = false;
                btnGrabar1.Enabled = false;
                dtgExcepGeneradas.Enabled = false;
                btnCancelar1.Enabled = false;
                limpiarControles();
                dtgExcepGeneradas.CellDoubleClick -= dtgExcepGeneradas_CellDoubleClick;    
            }
            else
            {
                MessageBox.Show("No existen reglas para agregar", "Excepciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnMiniEditar1_Click(object sender, EventArgs e)
        {
            cboReglas.SelectedIndex = -1;
            cboReglas.Enabled = false;
            txtReglaDescripcion.Enabled = false;
            btnNuevo.Enabled = false;
            btnMiniCancelEst1.Enabled = true;
            btnMiniAcept1.Enabled = true;
            txtSustento.Enabled = true;
            btnMiniQuitar1.Enabled = false;
            btnMiniEditar1.Enabled = false;
            btnGrabar1.Enabled = false;
            dtgExcepGeneradas.Enabled = false;
            btnCancelar1.Enabled = false;
            nIdReglaTmp = Convert.ToInt32(dtgExcepGeneradas.SelectedRows[0].Cells["nIdRegla"].Value);
            txtReglaDescripcion.Text = dtgExcepGeneradas.SelectedRows[0].Cells["cMensajeError"].Value.ToString();
            txtSustento.Text = dtgExcepGeneradas.SelectedRows[0].Cells["cSustento"].Value.ToString();
            dtgExcepGeneradas.CellDoubleClick -= dtgExcepGeneradas_CellDoubleClick;
        }

        private void btnMiniAcept1_Click(object sender, EventArgs e)
        {
            var dtExcepManual = (DataTable)cboReglas.DataSource;
            bool lValida = true;
            
            if (cboReglas.SelectedIndex < 0)
            {
                foreach (DataRow dtRow in dtExcepGen.Rows)
                {
                    if (Convert.ToInt32(dtRow["nIdRegla"]) == nIdReglaTmp)
                    {
                        dtRow["cSustento"] = txtSustento.Text;
                        btnMiniAcept1.Enabled = false;
                        btnMiniCancelEst1.Enabled = false;
                        btnNuevo.Enabled = true;
                        btnMiniEditar1.Enabled = true;
                        btnMiniQuitar1.Enabled = true;
                        cboReglas.Enabled = false;
                        txtSustento.Enabled = false;
                        dtgExcepGeneradas.Enabled = true;
                        btnGrabar1.Enabled = true;
                        btnCancelar1.Enabled = true;
                    }
                }
            }
            else
            {
                foreach (DataRow dtRow in dtExcepManual.Rows)
                {
                    if (Convert.ToInt32(cboReglas.SelectedValue) == Convert.ToInt32(dtRow["nIdRegla"]))
                    {
                        foreach (DataRow item in dtExcepGen.Rows)
                        {
                            if (Convert.ToInt32(item["nIdRegla"]) == Convert.ToInt32(dtRow["nIdRegla"]))
                            {
                                lValida = false;
                            }
                        }
                        if (lValida)
                        {
                            DataRow dtSelect = dtExcepGen.NewRow();
                            dtSelect["nIdRegla"] = Convert.ToInt32(dtRow["nIdRegla"]);
                            dtSelect["cMensajeError"] = Convert.ToString(dtRow["cMensajeError"]);
                            dtSelect["nIdOpcion"] = Convert.ToInt32(dtRow["nIdOpcion"]);
                            dtSelect["cAutomatico"] = "Manual";
                            dtSelect["cSustento"] = txtSustento.Text;
                            dtSelect["idSolicitud"] = nIdSolicitud;
                            dtSelect["idTipoOperacion"] = Convert.ToString(dtRow["idTipoOperacion"]);
                            dtSelect["idExcepGen"] = 0;
                            dtExcepGen.Rows.Add(dtSelect);
                            dtExcepGen.AcceptChanges();
                            btnMiniAcept1.Enabled = false;
                            btnMiniCancelEst1.Enabled = false;
                            btnNuevo.Enabled = true;
                            btnMiniEditar1.Enabled = true;
                            btnMiniQuitar1.Enabled = true;
                            cboReglas.Enabled = false;
                            txtSustento.Enabled = false;
                            dtgExcepGeneradas.Rows[dtgExcepGeneradas.Rows.Count - 1].Selected = true;
                            dtgExcepGeneradas.Enabled = true;
                            btnGrabar1.Enabled = true;
                            btnCancelar1.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("La excepción que intenta agregar ya existe", "Excepciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cboReglas.Enabled = true;
                            txtSustento.Enabled = true;
                            dtgExcepGeneradas.Enabled = false;
                        }
                    }
                }
            }


            foreach (DataGridViewRow dr in dtgExcepGeneradas.Rows)
            {
                if (dr.Cells["cAutomatico"].Value.ToString() == "Automatico")
                {
                    dr.DefaultCellStyle.BackColor = Color.FromArgb(173, 239, 156);
                }
                else
                {
                    dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 222, 188);
                }
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            
            DataTable dtRegistroExcepcion = new DataTable();
            dtRegistroExcepcion.Columns.Add("idExcepGen");
            dtRegistroExcepcion.Columns.Add("nIdRegla");
            dtRegistroExcepcion.Columns.Add("nIdTipoOperacion");
            dtRegistroExcepcion.Columns.Add("nIdOpcion");
            dtRegistroExcepcion.Columns.Add("cSustento");

            foreach (DataGridViewRow row in dtgExcepGeneradas.Rows)
            {

                DataRow rowDatos = dtRegistroExcepcion.NewRow();
                rowDatos["idExcepGen"] = row.Cells["idExcepGen"].Value;
                rowDatos["nIdRegla"] = Convert.ToInt32(row.Cells["nIdRegla"].Value);
                rowDatos["nIdTipoOperacion"] = Convert.ToInt32(row.Cells["idTipoOperacion"].Value);
                rowDatos["nIdOpcion"] = row.Cells["nIdOpcion"].Value;
                rowDatos["cSustento"] = row.Cells["cSustento"].Value;
                dtRegistroExcepcion.Rows.Add(rowDatos);
                dtRegistroExcepcion.AcceptChanges();

            }

            if (MessageBox.Show("¿Desea efectuar cambios?", "Excepciones Manuales", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(dtRegistroExcepcion);
                String XmlExcepcionManual = ds.GetXml();
                XmlExcepcionManual = clsCNFormatoXML.EncodingXML(XmlExcepcionManual);
                System.Console.WriteLine(XmlExcepcionManual);
                cnSolicitud.CNInsertarExcepcionManual(nIdSolicitud, nIdAgencia, nIdCliente, nIdMoneda, nIdProducto, nValAproba, nIdUsuRegist, XmlExcepcionManual);
                MessageBox.Show("Datos grabados correctamente", "Excepciones Manuales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtRegistroExcepcion.AcceptChanges();
                dtExcepGen.AcceptChanges();
                btnMiniQuitar1.Enabled = false;
                btnMiniEditar1.Enabled = false;
                btnMiniAcept1.Enabled = false;
                btnNuevo.Enabled = false;
                btnMiniCancelEst1.Enabled = false;
                btnGrabar1.Enabled = false;
                cboReglas.Enabled = false;
                btnCancelar1.Enabled = false;
                btnEditar1.Enabled = true;
                cargarGridsView();
                cboReglas.SelectedIndex = -1;
                limpiarControles();
                dtgExcepGeneradas.ClearSelection();
                dtgExcepGeneradas.Enabled = false;
            }

        }

        private void dtgExcepGeneradas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cboReglas.SelectedIndex = -1;
            cboReglas.Enabled = false;
            txtReglaDescripcion.Enabled = false;
            btnNuevo.Enabled = false;
            btnMiniCancelEst1.Enabled = true;
            btnMiniEditar1.Enabled = false;
            btnMiniAcept1.Enabled = true;
            txtSustento.Enabled = true;
            btnMiniQuitar1.Enabled = false;
            btnGrabar1.Enabled = false;
            btnCancelar1.Enabled = false;
            txtReglaDescripcion.Text = dtgExcepGeneradas.SelectedRows[0].Cells["cMensajeError"].Value.ToString();
            txtSustento.Text = dtgExcepGeneradas.SelectedRows[0].Cells["cSustento"].Value.ToString();
            nIdReglaTmp = Convert.ToInt32(dtgExcepGeneradas.SelectedRows[0].Cells["nIdRegla"].Value);
            dtgExcepGeneradas.CellDoubleClick -= dtgExcepGeneradas_CellDoubleClick;
            dtgExcepGeneradas.Enabled = false;
        }
        
        private void dtgExcepGeneradas_SelectionChanged(object sender, EventArgs e)
        {  
            if (dtgExcepGeneradas.Focused)
            {
                    txtReglaDescripcion.Text = dtgExcepGeneradas.SelectedRows[0].Cells["cMensajeError"].Value.ToString();
                    txtSustento.Text = dtgExcepGeneradas.SelectedRows[0].Cells["cSustento"].Value.ToString();
                    nIdReglaTmp = Convert.ToInt32(dtgExcepGeneradas.SelectedRows[0].Cells["nIdRegla"].Value);
                    txtSustento.Enabled = false;
                    btnMiniEditar1.Enabled = true;
                    cboReglas.Enabled = false;
                    cboReglas.SelectedIndex = -1;
                    btnMiniAcept1.Enabled = false;
                    btnMiniCancelEst1.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnGrabar1.Enabled = true;
                    btnMiniQuitar1.Enabled = true;
                    dtgExcepGeneradas.CellDoubleClick += dtgExcepGeneradas_CellDoubleClick;
            }
            
            
        }
        private void frmExcepciones_paint(object sender, System.Windows.Forms.PaintEventArgs pe)
        {
            System.Drawing.SolidBrush myBrushAuto = new System.Drawing.SolidBrush(System.Drawing.Color.LimeGreen);
            System.Drawing.SolidBrush myBrushMan = new System.Drawing.SolidBrush(System.Drawing.Color.Orange);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(myBrushAuto, new Rectangle(450, 10, 13, 13));
            formGraphics.FillRectangle(myBrushMan, new Rectangle(547, 10, 13, 13));
            myBrushAuto.Dispose();
            myBrushMan.Dispose();

            formGraphics.Dispose();
        }

        #endregion

        #region Metodos

        public void cargarGridsView()
        {
            dtExcepGen = cnSolicitud.CNExcepcionesGeneradas(nIdSolicitud);
            frmRegistroSolicitudCredito registrosolicitudCredito = new frmRegistroSolicitudCredito();
            String cIdsReglas = "";
            if (dtExcepGen.Rows.Count > 0)
            {
                dtgExcepGeneradas.DataSource = dtExcepGen;
                foreach (DataGridViewRow dr in dtgExcepGeneradas.Rows)
                {
                    cIdsReglas = dr.Cells["nIdRegla"].Value.ToString() + "," + cIdsReglas;
                    if (dr.Cells["cAutomatico"].Value.ToString() == "Automatico")
                    {
                        dr.DefaultCellStyle.BackColor = Color.FromArgb(173, 239, 156);
                    }
                    else
                    {
                        dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 222, 188);
                    }
                }

                cIdsReglas = cIdsReglas.Length <= 0 ? " " : cIdsReglas.Remove(cIdsReglas.Length - 1);
                int idOpcion = Convert.ToInt32(dtgExcepGeneradas.Rows[0].Cells["nIdOpcion"].Value);
                dtExcepManuales = cnSolicitud.CNReglasPorFormulario(cIdsReglas, cOpcion);
                lblTotalExcep.Text = Convert.ToString(dtExcepGen.Rows.Count);
            }
            else
            {
                dtExcepManuales = cnSolicitud.CNReglasPorFormulario("", cOpcion);
                dtgExcepGeneradas.DataSource = dtExcepGen;
            }

            cboReglas.DataSource = dtExcepManuales;
            cboReglas.ValueMember = dtExcepManuales.Columns["nIdRegla"].ToString();
            cboReglas.DisplayMember = dtExcepManuales.Columns["cMensajeError"].ToString();

            formatoGrids();
        }

        public void formatoGrids()
        {
            foreach (DataGridViewColumn item in dtgExcepGeneradas.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;

            }

            dtgExcepGeneradas.Columns["nIdRegla"].HeaderText = "Regla";
            dtgExcepGeneradas.Columns["cMensajeError"].HeaderText = "Excepción";
            dtgExcepGeneradas.Columns["cAutomatico"].HeaderText = "Tipo Excepción";
            dtgExcepGeneradas.Columns["cSustento"].HeaderText = "Sustento";

            dtgExcepGeneradas.Columns["nIdRegla"].Visible = true;
            dtgExcepGeneradas.Columns["cMensajeError"].Visible = true;
            dtgExcepGeneradas.Columns["cAutomatico"].Visible = true;
            dtgExcepGeneradas.Columns["cSustento"].Visible = true;            

            dtgExcepGeneradas.Columns["nIdRegla"].Width = 35;
            dtgExcepGeneradas.Columns["cMensajeError"].Width = 215;
            dtgExcepGeneradas.Columns["cSustento"].Width = 280;
            dtgExcepGeneradas.Columns["cAutomatico"].Width = 55;
            
            dtgExcepGeneradas.Columns["nIdRegla"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgExcepGeneradas.Columns["cAutomatico"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgExcepGeneradas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgExcepGeneradas.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;

        }

        private void limpiarControles()
        {
            txtReglaDescripcion.Text = "";
            txtSustento.Text = "";
        }
        #endregion   
    }

}
