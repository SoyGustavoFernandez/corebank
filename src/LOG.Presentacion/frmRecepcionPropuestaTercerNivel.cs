using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using LOG.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;

namespace LOG.Presentacion
{
    public partial class frmRecepcionPropuestaTercerNivel : frmBase
    {
        private clsCNProcesoAdquisicion clsCNProcAdq = new clsCNProcesoAdquisicion();
        private clsSolicitudProcesoAdquisicion objProcAdq;
        private const string cTituloMsjes = "Propuestas de Adquisicion";
        
        private int idcliProveedor = 0;


        public frmRecepcionPropuestaTercerNivel()
        {
            InitializeComponent();
        }

        private void txtCodigoPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;

            if (string.IsNullOrEmpty(txtNumNotaSal.Text.ToString()))
            {
                MessageBox.Show("Valor de Búsqueda No Válido", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int idProcAdq = Convert.ToInt32(txtNumNotaSal.Text.ToString().Trim());
            if (idProcAdq == 0)
            {
                MessageBox.Show("Ingrese Valor Diferente de Cero(0)", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            BuscarProcesoAdquisicion(idProcAdq);

            if (objProcAdq != null)
            {
                cboProveedorProcesoAdq1.listarProveedoresProcAdq(objProcAdq.idProcAdq);
                cboProveedorProcesoAdq1.Enabled = true;

                cboProveedorProcesoAdq1.SelectedIndex = -1;
            }
            else
            {
                txtNumNotaSal.Text = "";
                txtNumNotaSal.Focus();
            }
                
        }

        private void BuscarProcesoAdquisicion(int idProcAdq)
        {
            clsCNProcesoAdquisicion objCargaNotaSalida = new clsCNProcesoAdquisicion();

            objProcAdq = clsCNProcAdq.CNBuscarProcesoAdquisicion(idProcAdq, 0);
            if (objProcAdq == null)
            {
                MessageBox.Show("No se encontró información de la Solicitud.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (objProcAdq.idEstadoLog == 1)
            {
                MessageBox.Show("El Proceso NO tiene APROBACIÓN.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (objProcAdq.idEstadoLog == 4)
            {
                MessageBox.Show("El Proceso tiene estado de DENEGADO.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //ActivarControles(false);
            MapeaEntidadCampos(objProcAdq);
            //txtNumNotaSal.Enabled = false;
            //btnEvaluar.Enabled = true;
            if (objProcAdq.idEstadoLog == 2)
                habilitarControles("inicio");
            else
            {
                evaluarProceso();
                habilitarControles("consulta");
            }
        }

         private void LimpiarCampos()
        {
            txtNumNotaSal.Clear();
            txtEstadoNotaSal.SelectedIndex = -1;
            cboMoneda1.SelectedIndex = -1;
            //dtpFechaNS.Value = dFechaSis;
            
            txtNumNotaSal.Text = string.Empty;
            txtNumNotaSal.Focus();
            dtgDetalleNS.DataSource = null;
            dtgDetallePropuesta.DataSource = null;
            dtgDetalleResultados.DataSource = null;
            cboProveedorProcesoAdq1.Enabled = false;
            txtNombreProveedor.Text = "";
            cboTipoComprobanteLog1.SelectedIndex = -1;
            txtObservacion.Text = "";
            chkIgv.Checked = false;

            habilitarControles("load");
        }

         private void IniForm()
         {
             //dtpFechaNS.Value = clsVarGlobal.dFecSystem;

             //DatosUsuario(clsVarGlobal.User.idCli);

             ActivarControles(false);
             txtNumNotaSal.Text = string.Empty;
             txtNumNotaSal.Focus();
         }

         private void ActivarControles(bool lHab, bool lEdit = false)
         {
             txtNumNotaSal.Enabled = !lHab;


             btnProveedor1.Enabled = !lHab;
             

             //btnBusqueda.Enabled = !lHab;
             //btnEditar.Enabled = false;
             btnGrabar.Enabled = lHab;
             //btnCancelar.Enabled = lHab;

             /*if (lEdit)
             {
                 dtgDetalleNS.Columns["cDetalleProducto"].ReadOnly = false;
                 dtgDetalleNS.Columns["nCantidad"].ReadOnly = false;
             }*/
         }

         private void MapeaEntidadCampos(clsSolicitudProcesoAdquisicion objProcAdq)
         {
             txtNumNotaSal.Text = objProcAdq.idProcAdq.ToString();
             txtEstadoNotaSal.Text = objProcAdq.cEstLog;
             txtEstadoNotaSal.SelectedValue = objProcAdq.idEstadoLog;
             cboMoneda1.SelectedValue = objProcAdq.idMoneda;

             dtgDetalleNS.DataSource = objProcAdq.LstDetProcAdq.Where(x => x.lVigente).ToList();
             FormatoGridView();

             dtgDetalleNS.ReadOnly = true;
         }

         private void FormatoGridView(bool lSoloLectura = false)
         {
             dtgDetalleNS.ReadOnly = false;
             foreach (DataGridViewColumn column in dtgDetalleNS.Columns)
             {
                 column.ReadOnly = true;
                 column.Visible = false;
             }
             dtgDetalleNS.Columns["cUnidMedida"].Visible = true;
             dtgDetalleNS.Columns["cProducto"].Visible = true;
             dtgDetalleNS.Columns["cDetalleProducto"].Visible = true;
             dtgDetalleNS.Columns["nCantidad"].Visible = true;
             dtgDetalleNS.Columns["nPrecioRef"].Visible = true;
             dtgDetalleNS.Columns["nDiasRef"].Visible = true;
             dtgDetalleNS.Columns["nLineaCreditoRef"].Visible = true;

             dtgDetalleNS.Columns["cUnidMedida"].HeaderText = "U.M.";
             dtgDetalleNS.Columns["cProducto"].HeaderText = "Producto";
             dtgDetalleNS.Columns["cDetalleProducto"].HeaderText = "Detalle";
             dtgDetalleNS.Columns["nCantidad"].HeaderText = "Cantidad";
             dtgDetalleNS.Columns["nPrecioRef"].HeaderText = "Prec Ref";
             dtgDetalleNS.Columns["nDiasRef"].HeaderText = "Dias Ref";
             dtgDetalleNS.Columns["nLineaCreditoRef"].HeaderText = "LnCred Ref";

             dtgDetalleNS.Columns["cUnidMedida"].DisplayIndex = 0;
             dtgDetalleNS.Columns["cProducto"].DisplayIndex = 1;
             dtgDetalleNS.Columns["cDetalleProducto"].DisplayIndex = 2;
             dtgDetalleNS.Columns["nCantidad"].DisplayIndex = 3;
             dtgDetalleNS.Columns["nPrecioRef"].DisplayIndex = 4;
             dtgDetalleNS.Columns["nDiasRef"].DisplayIndex = 5;
             dtgDetalleNS.Columns["nLineaCreditoref"].DisplayIndex = 6;

             dtgDetalleNS.Columns["cUnidMedida"].FillWeight = 5;
             dtgDetalleNS.Columns["cProducto"].FillWeight = 36;
             dtgDetalleNS.Columns["cDetalleProducto"].FillWeight = 36;
             dtgDetalleNS.Columns["nCantidad"].FillWeight = 5;
             dtgDetalleNS.Columns["nPrecioRef"].FillWeight = 6;
             dtgDetalleNS.Columns["nDiasRef"].FillWeight = 6;
             dtgDetalleNS.Columns["nLineaCreditoRef"].FillWeight = 6;

             dtgDetalleNS.Columns["cDetalleProducto"].ReadOnly = false;
             dtgDetalleNS.Columns["nCantidad"].ReadOnly = false;
             dtgDetalleNS.Columns["nPrecioRef"].ReadOnly = false;
             dtgDetalleNS.Columns["nDiasRef"].ReadOnly = false;
             dtgDetalleNS.Columns["nLineaCreditoRef"].ReadOnly = false;

             dtgDetalleNS.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

             for (int i = 0; i < dtgDetalleNS.Rows.Count; i++)
             {
                 dtgDetalleNS.Rows[i].Height = 42;
             }
         }

         private void frmRecepcionPropuestaTercerNivel_Load(object sender, EventArgs e)
         {
             txtEstadoNotaSal.listarEstadoProcesoAdj(1);
             cboMoneda1.CargaDatos();
             txtEstadoNotaSal.SelectedIndex = -1;
             cboMoneda1.SelectedIndex = -1;
             cboTipoComprobanteLog1.CargarTipoComporbantes();
             IniForm();
             LimpiarCampos();
         }

         /*private void btnCancelar_Click(object sender, EventArgs e)
         {
             IniForm();
             LimpiarCampos();
             objProcAdq.idProveedor = 0;
         }*/

         public void FormatoGridViewPropuesta()
         {
             dtgDetallePropuesta.ReadOnly = false;
             foreach (DataGridViewColumn column in dtgDetallePropuesta.Columns)
             {
                 column.ReadOnly = true;
                 column.Visible = false;
             }
             dtgDetallePropuesta.Columns["cUnidMedida"].Visible = true;
             dtgDetallePropuesta.Columns["cProducto"].Visible = true;
             dtgDetallePropuesta.Columns["nCantidad"].Visible = true;
             dtgDetallePropuesta.Columns["nPrecio"].Visible = true;
             dtgDetallePropuesta.Columns["nDias"].Visible = true;
             dtgDetallePropuesta.Columns["nLineaCredito"].Visible = true;
             dtgDetallePropuesta.Columns["nPuntaje"].Visible = true;

             dtgDetallePropuesta.Columns["cUnidMedida"].HeaderText = "U.M.";
             dtgDetallePropuesta.Columns["cProducto"].HeaderText = "Producto";
             dtgDetallePropuesta.Columns["nCantidad"].HeaderText = "Cant";
             dtgDetallePropuesta.Columns["nPrecio"].HeaderText = "Precio";
             dtgDetallePropuesta.Columns["nDias"].HeaderText = "Dias";
             dtgDetallePropuesta.Columns["nLineaCredito"].HeaderText = "Ln Cred";
             dtgDetallePropuesta.Columns["nPuntaje"].HeaderText = "Puntaje";

             dtgDetallePropuesta.Columns["cUnidMedida"].DisplayIndex = 0;
             dtgDetallePropuesta.Columns["cProducto"].DisplayIndex = 1;
             dtgDetallePropuesta.Columns["nCantidad"].DisplayIndex = 2;
             dtgDetallePropuesta.Columns["nPrecio"].DisplayIndex = 3;
             dtgDetallePropuesta.Columns["nDias"].DisplayIndex = 4;
             dtgDetallePropuesta.Columns["nLineaCredito"].DisplayIndex = 5;
             dtgDetallePropuesta.Columns["nPuntaje"].DisplayIndex = 6;


             dtgDetallePropuesta.Columns["cUnidMedida"].FillWeight = 8;
             dtgDetallePropuesta.Columns["cProducto"].FillWeight = 52;
             dtgDetallePropuesta.Columns["nCantidad"].FillWeight = 8;
             dtgDetallePropuesta.Columns["nPrecio"].FillWeight = 8;
             dtgDetallePropuesta.Columns["nDias"].FillWeight = 8;
             dtgDetallePropuesta.Columns["nLineaCredito"].FillWeight = 8;
             dtgDetallePropuesta.Columns["nPuntaje"].FillWeight = 8;

             dtgDetallePropuesta.Columns["nPrecio"].ReadOnly = false;
             dtgDetallePropuesta.Columns["nDias"].ReadOnly = false;
             dtgDetallePropuesta.Columns["nLineaCredito"].ReadOnly = false;

             dtgDetallePropuesta.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

         }


         private void calcularPuntaje(int rowIndex)
         {
             decimal puntaje = 0;
             decimal puntPrecio = clsVarApl.dicVarGen["nPesoPrecio"] * (2 * Convert.ToDecimal(dtgDetalleNS.Rows[rowIndex].Cells["nPrecioRef"].Value) - Convert.ToDecimal(dtgDetallePropuesta.Rows[rowIndex].Cells["nPrecio"].Value)) / Convert.ToDecimal(dtgDetalleNS.Rows[rowIndex].Cells["nPrecioRef"].Value);
             decimal puntDias = clsVarApl.dicVarGen["nPesoDias"] * (2 * Convert.ToDecimal(dtgDetalleNS.Rows[rowIndex].Cells["nDiasRef"].Value) - Convert.ToDecimal(dtgDetallePropuesta.Rows[rowIndex].Cells["nDias"].Value)) / Convert.ToDecimal(dtgDetalleNS.Rows[rowIndex].Cells["nDiasRef"].Value);
             decimal puntLnCred = clsVarApl.dicVarGen["nPesoLineaCredito"] * (Convert.ToDecimal(dtgDetallePropuesta.Rows[rowIndex].Cells["nLineaCredito"].Value)) / Convert.ToDecimal(dtgDetalleNS.Rows[rowIndex].Cells["nLineaCreditoRef"].Value);

             puntaje = (puntPrecio + puntDias + puntLnCred);
             puntaje = Math.Round(puntaje * 100) / 100;

             if(Convert.ToDecimal(dtgDetalleNS.Rows[rowIndex].Cells["nPrecio"].Value) == 0 && Convert.ToDecimal(dtgDetalleNS.Rows[rowIndex].Cells["nDias"].Value) == 0 && Convert.ToDecimal(dtgDetalleNS.Rows[rowIndex].Cells["nLineaCredito"].Value) == 0 )
             {
                 puntaje = 0;    
             }
             

             dtgDetallePropuesta.Rows[rowIndex].Cells["nPuntaje"].Value = puntaje;
         }

         private void dtgDetallePropuesta_CellValueChanged(object sender, DataGridViewCellEventArgs e)
         {
             int nPrecioreIndex = dtgDetallePropuesta.Columns["nPrecio"].Index;
             int nDiasRefIndex = dtgDetallePropuesta.Columns["nDias"].Index;
             int nLnCredRefIndex = dtgDetallePropuesta.Columns["nLineacredito"].Index;

             if (dtgDetallePropuesta.CurrentCell == null)
                 return;

             if (dtgDetallePropuesta.CurrentCell.ColumnIndex.Equals(nPrecioreIndex) || dtgDetallePropuesta.CurrentCell.ColumnIndex.Equals(nDiasRefIndex) || dtgDetallePropuesta.CurrentCell.ColumnIndex.Equals(nLnCredRefIndex))
             {
                 calcularPuntaje(dtgDetallePropuesta.CurrentCell.RowIndex);
             }
         }

         private void btnGrabar_Click(object sender, EventArgs e)
         {
             if (Convert.ToInt32(cboTipoComprobanteLog1.SelectedValue) <= 0)
             {
                 MessageBox.Show("Seleccione el Tipo de Comprobante", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return;
             }

             clsDBResp objDBResp = null;

             objDBResp = clsCNProcAdq.CNGuardarPropuestaProcesoAdquisicion(objProcAdq, chkIgv.Checked, Convert.ToInt32(cboTipoComprobanteLog1.SelectedValue), txtObservacion.Text);
             
             if (objDBResp.nMsje == 0)
             {
                 MessageBox.Show(objDBResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                 //BuscarProcesoAdquisicion(objDBResp.idGenerado);
                 limpiarPropuesta();
                 int idProcAdq = Convert.ToInt32(txtNumNotaSal.Text.ToString().Trim());
                 BuscarProcesoAdquisicion(idProcAdq);
                 cboProveedorProcesoAdq1.listarProveedoresProcAdq(objProcAdq.idProcAdq);
             }
             else
             {
                 MessageBox.Show(objDBResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }
             
         }

         private void btnLimpiarPropuesta_Click(object sender, EventArgs e)
         {
             limpiarPropuesta();
         }

         private void limpiarPropuesta()
         {
             dtgDetallePropuesta.DataSource = null;
             objProcAdq.idProveedor = 0;
             txtNombreProveedor.Text = "";
             chkIgv.Checked = false;
             cboTipoComprobanteLog1.SelectedIndex = -1;
             txtObservacion.Text = "";
             habilitarControles("addProveedor");
         }

         private void btnProveedor1_Click(object sender, EventArgs e)
         {
             frmBusquedaProveedor frmBusProveedor = new frmBusquedaProveedor();
             frmBusProveedor.ShowDialog();

             if (frmBusProveedor.objProveedor == null)
             {
                 MessageBox.Show("No se seleccionó ningún proveedor.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 return;
             }

             if (existeProveedor(frmBusProveedor.objProveedor.idProveedor))
             {
                 MessageBox.Show("Ya se tiene la Propuesta de este Proveedor", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 cboProveedorProcesoAdq1.SelectedValue = frmBusProveedor.objProveedor.idProveedor;
                 return;
             }

             objProcAdq.idProveedor = frmBusProveedor.objProveedor.idProveedor;
             txtNombreProveedor.Text = frmBusProveedor.objProveedor.cNombre;
             idcliProveedor = frmBusProveedor.objProveedor.idCli;

             dtgDetallePropuesta.CellValueChanged -= dtgDetallePropuesta_CellValueChanged;
             dtgDetallePropuesta.DataSource = objProcAdq.LstDetProcAdq.Where(x => x.lVigente).ToList();
             FormatoGridViewPropuesta();
             dtgDetallePropuesta.CellValueChanged += dtgDetallePropuesta_CellValueChanged;

             habilitarControles("addProveedor");
         }

         private bool existeProveedor(int idProveedor)
         {
             foreach(DataRowView item in cboProveedorProcesoAdq1.Items)
            {
                if (Convert.ToInt32(item.Row[0]) == idProveedor)
                {
                    return true;
                }
            }
             return false ;
         }

         private void btnEvaluar_Click(object sender, EventArgs e)
         {
             evaluarProceso();
         }

         private void evaluarProceso()
         {
             DataTable dbRes = clsCNProcAdq.CNGetResultadosProcesoAdquisicion(objProcAdq.idProcAdq);

             if (dbRes.Rows.Count == 0)
             {
                 MessageBox.Show("No se tiene Resultados para esta Solicitud", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 return;
             }

             dtgDetalleResultados.DataSource = dbRes;
             formatoDtgResultados();
             habilitarControles("evaluar");
         }

         private void formatoDtgResultados()
         {
             dtgDetalleResultados.ReadOnly = false;
             foreach (DataGridViewColumn column in dtgDetalleResultados.Columns)
             {
                 column.ReadOnly = true;
                 column.Visible = false;
             }
             dtgDetalleResultados.Columns["cUnidMedida"].Visible = true;
             dtgDetalleResultados.Columns["cProducto"].Visible = true;
             dtgDetalleResultados.Columns["nPrecio"].Visible = true;
             dtgDetalleResultados.Columns["nDias"].Visible = true;
             dtgDetalleResultados.Columns["nLineaCredito"].Visible = true;
             dtgDetalleResultados.Columns["nPuntaje"].Visible = true;
             dtgDetalleResultados.Columns["cProveedor"].Visible = true;

             dtgDetalleResultados.Columns["cUnidMedida"].HeaderText = "U.M.";
             dtgDetalleResultados.Columns["cProducto"].HeaderText = "Producto";
             dtgDetalleResultados.Columns["nPrecio"].HeaderText = "Precio";
             dtgDetalleResultados.Columns["nDias"].HeaderText = "Dias";
             dtgDetalleResultados.Columns["nLineaCredito"].HeaderText = "Ln Cred";
             dtgDetalleResultados.Columns["nPuntaje"].HeaderText = "Puntaje";
             dtgDetalleResultados.Columns["cProveedor"].HeaderText = "Proveedor";

             dtgDetalleResultados.Columns["cUnidMedida"].DisplayIndex = 0;
             dtgDetalleResultados.Columns["cProducto"].DisplayIndex = 1;
             dtgDetalleResultados.Columns["nPrecio"].DisplayIndex = 2;
             dtgDetalleResultados.Columns["nDias"].DisplayIndex = 3;
             dtgDetalleResultados.Columns["nLineaCredito"].DisplayIndex = 4;
             dtgDetalleResultados.Columns["nPuntaje"].DisplayIndex = 5;
             dtgDetalleResultados.Columns["cProveedor"].DisplayIndex = 6;


             dtgDetalleResultados.Columns["cUnidMedida"].FillWeight = 8;
             dtgDetalleResultados.Columns["cProducto"].FillWeight = 40;
             dtgDetalleResultados.Columns["nPrecio"].FillWeight = 8;
             dtgDetalleResultados.Columns["nDias"].FillWeight = 8;
             dtgDetalleResultados.Columns["nLineaCredito"].FillWeight = 8;
             dtgDetalleResultados.Columns["nPuntaje"].FillWeight = 8;
             dtgDetalleResultados.Columns["cProveedor"].FillWeight = 20;
         }

         private void btnCancelar1_Click(object sender, EventArgs e)
         {
             IniForm();
             LimpiarCampos();
             objProcAdq.idProveedor = 0;
         }

         private void btnSalir1_Click(object sender, EventArgs e)
         {
             this.Dispose();
         }

         private void btnGrabarResultado_Click(object sender, EventArgs e)
         {
             string xmlResultado = convertXMLFiles((DataTable)dtgDetalleResultados.DataSource);
             
             clsDBResp objDBResp = null;

             objDBResp = clsCNProcAdq.CNGuardarResultadoProcesoAdquisicion(xmlResultado);

             if (objDBResp.nMsje == 0)
             {
                 MessageBox.Show(objDBResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                 btnGrabarResultado.Enabled = false;
                 btnLimpiarResultado.Enabled = false;
                 btnImprimir1.Enabled = true;
                 /*limpiarPropuesta();
                 int idProcAdq = Convert.ToInt32(txtNumNotaSal.Text.ToString().Trim());
                 BuscarProcesoAdquisicion(idProcAdq);*/
             }
             else
             {
                 MessageBox.Show(objDBResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }
         }

         public string convertXMLFiles(DataTable dt)
         {
             dt.TableName = "detResultado";
             DataSet ds = new DataSet();
             if (dt.DataSet != null)
             {
                 ds = dt.DataSet;
             }
             else
             {
                 ds.Tables.Add(dt);
             }


             return ds.GetXml();
         }

         public void habilitarControles(string estado)
         {
             btnProveedor1.Enabled = false;
             panelPropuesta.Visible = false;
             btnGrabar.Enabled = false;
             panelResultado.Visible = false;
             btnGrabarResultado.Enabled = false;
             btnEvaluar.Enabled = false;
             btnImprimir1.Enabled = false;
             btnLimpiarResultado.Enabled = true;
             chkIgv.Enabled = false;
             cboTipoComprobanteLog1.Enabled = false;
             txtObservacion.Enabled = false;

             if (estado == "inicio")
             {
                 btnProveedor1.Enabled = true;
                 btnEvaluar.Enabled = true;
             }
             else if (estado == "addProveedor")
             {
                 panelPropuesta.Visible = true;
                 btnGrabar.Enabled = true;
                 chkIgv.Enabled = true;
                 cboTipoComprobanteLog1.Enabled = true;
                 txtObservacion.Enabled = true;
             }
             else if (estado == "evaluar")
             {
                 panelResultado.Visible = true;
                 btnGrabarResultado.Enabled = true;
             }
             else if (estado == "consulta")
             {
                 btnImprimir1.Enabled = true;
                 panelResultado.Visible = true;
                 btnLimpiarResultado.Enabled = false;
             }
         }

         private void btnLimpiarResultado_Click(object sender, EventArgs e)
         {
             habilitarControles("inicio");
         }

         private void btnImprimir1_Click(object sender, EventArgs e)
         {
             DataTable dtsPropuestas = clsCNProcAdq.CNListarPropuestasProveedores(objProcAdq.idProcAdq);
             DataTable dtsGanadores = clsCNProcAdq.CNListarGanadoresProveedores(objProcAdq.idProcAdq);


             List<ReportParameter> paramlist = new List<ReportParameter>();

             
             
             paramlist.Add(new ReportParameter("cNomAgencia", clsVarGlobal.cNomAge, false));
             paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
             paramlist.Add(new ReportParameter("idProcAdq", objProcAdq.idProcAdq.ToString()));
             paramlist.Add(new ReportParameter("dFechaSol", objProcAdq.dFechaRegistro.ToString(), false));

             List<ReportDataSource> dtslist = new List<ReportDataSource>();

             dtslist.Add(new ReportDataSource("dtsPropuestas", dtsPropuestas));
             dtslist.Add(new ReportDataSource("dtsGanadores", dtsGanadores));


             string reportpath = "rptCuadroComparativo.rdlc";
             new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
         }

         private void txtLineaCredito_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (e.KeyChar != 13)
                 return;
             ponerLineaCredito();
         }

         private void txtLineaCredito_Leave(object sender, EventArgs e)
         {
             ponerLineaCredito();
         }

         private void ponerLineaCredito()
         {
             decimal lnCred = Convert.ToDecimal(txtLineaCredito.Text);
             foreach (DataGridViewRow row in dtgDetallePropuesta.Rows)
             {
                 row.Cells["nLineaCredito"].Value = lnCred.ToString();
                 calcularPuntaje(row.Index);
             }
         }
    }
}
