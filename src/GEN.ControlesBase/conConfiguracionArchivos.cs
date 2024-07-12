using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using CRE.CapaNegocio;
using GEN.CapaNegocio;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace GEN.ControlesBase
{
    public partial class conConfiguracionArchivos : UserControl
    {
        DataTable dtAgencia = new DataTable();
        private clsCNCargaArchivo clsConfiguracion = new clsCNCargaArchivo();
        clsListaConfiguracionTipoArchivoEscaneado pListaConfiguracion = new clsListaConfiguracionTipoArchivoEscaneado();
        BindingList<clsConfigSubProArcEscaneado> _configuracion = new BindingList<clsConfigSubProArcEscaneado>();

        clsTipoArchivoEscaneado pDocumento;
        List<clsConfigTipoPersona> _TipoPersonaSel= new List<clsConfigTipoPersona>();
        List<clsConfigTipoOperacion> _TipoOperacionSel = new List<clsConfigTipoOperacion>();
        List<clsConfigDestinoCredito> _DesCreditoSel = new List<clsConfigDestinoCredito>();

        clsCNProducto ListaProducto = new clsCNProducto();
        clsListaConfiguracionDocumento lstTipoOperacion = new clsListaConfiguracionDocumento();
        clsListaConfiguracionDocumento lstDestinoCredito = new clsListaConfiguracionDocumento();
        clsListaConfiguracionDocumento lstTipoPersona = new clsListaConfiguracionDocumento();
        clsListaConfiguracionDocumento lstTipoEvalCred = new clsListaConfiguracionDocumento();
        clsListaConfigDocxMonto lstMonto = new clsListaConfigDocxMonto();
        clsListaConfiguracionDocumento lstTipCredSubProd = new clsListaConfiguracionDocumento();
        EventoFormulario eventoFormulario = EventoFormulario.INICIO;
        public event EventHandler ClicEventosNuevo;
        public event EventHandler ClicEventosEditar;
        public event EventHandler ClicEventosGuardar;
        public event EventHandler ClicEventosCancelar;
        public string titulo = "Configuración de Carga de Archivos";

        private int pIdGrupoArchivo;
        public conConfiguracionArchivos()
        {
            InitializeComponent();
        }
        public void CargarDatosIniciales()
        {
            pListaConfiguracion = new clsListaConfiguracionTipoArchivoEscaneado();
            _configuracion = new BindingList<clsConfigSubProArcEscaneado>();
        
            int CodPro = 1;
            DataTable dtTipCreSubProd = ListaProducto.listarTipoCreditoProducto(CodPro, true, true, 0);
            List<DataTable> dtConfig = clsConfiguracion.CNParametrosConfiguracionCargaArchivo();
            lstTipoOperacion.Clear();
            lstTipCredSubProd.Clear();
            foreach (DataRow dtRow in dtTipCreSubProd.Rows)
            {
                lstTipCredSubProd.Add(new clsConfiguracionDocumento()
                {
                    id = Convert.ToInt32(dtRow["IdProducto"].ToString()),
                    cDescripcion = dtRow["cProducto"].ToString(),
                    idPadre = Convert.ToInt32(dtRow["IdProductoPadre"].ToString()),
                });
            }
            dtgTipCredSubProd.DataSource = lstTipCredSubProd;

            lstTipoPersona.Clear();
            foreach (DataRow dtRow in dtConfig[2].Rows)
            {
                lstTipoPersona.Add(new clsConfiguracionDocumento()
                {
                    id = Convert.ToInt32(dtRow["idTipoPersona"].ToString()),
                    cDescripcion = dtRow["cTipoPersona"].ToString()
                });
            }
            dtgTipoPersona.DataSource = lstTipoPersona;


            foreach (DataRow dtRow in dtConfig[0].Rows)
            {
                lstTipoOperacion.Add(new clsConfiguracionDocumento()
                {
                    id = Convert.ToInt32(dtRow["idOperacion"].ToString()),
                    cDescripcion = dtRow["cOperacion"].ToString()
                });
            }
            dtgTipoOperacion.DataSource = lstTipoOperacion;

            lstDestinoCredito.Clear();
            foreach (DataRow dtRow in dtConfig[3].Rows)
            {
                lstDestinoCredito.Add(new clsConfiguracionDocumento()
                {
                    id = Convert.ToInt32(dtRow["idDestino"].ToString()),
                    cDescripcion = dtRow["cDestino"].ToString()
                });
            }
            dtgDestinoCredito.DataSource = lstDestinoCredito;

            lstMonto.Clear();
            foreach (DataRow dtRow in dtConfig[4].Rows)
            {
                lstMonto.Add(new clsConfigDocxMonto()
                {
                    id = Convert.ToInt32(dtRow["idNivelMonto"].ToString()),
                    cDescripcion = dtRow["cNivelMonto"].ToString(),
                    nMontoMinimo = Convert.ToDecimal(dtRow["nMontoMinimo"].ToString()),
                    nMontoMaximo = Convert.ToDecimal(dtRow["nMontoMaximo"].ToString())
                });
            }
            dtgMonto.DataSource = lstMonto;
        }
        public void CargarTipoPersonaConfiguracionArchivos(int ColumnIndex = 2)
        {
            List<int> IdsSubProducto = seleccionSubProducto();
            if (_configuracion.Count() > 0)
             {
                var tipoPer = _configuracion.FirstOrDefault(c => IdsSubProducto.Contains(c.idSubProducto));
                if (tipoPer != null)
                {
                    foreach (var item in lstTipoPersona)
                    {
                        foreach (var _item in tipoPer.detalleTipoPersona)
                        {
                            if (item.id == _item.idTipoPersona)
                            {
                                item.lVisible = _item.lVisible;
                                item.lObligatorio = _item.lObligatorio;
                            }
                        }
                    }
                }
                else
                {
                    foreach (var item in lstTipoPersona)
                    {
                        item.lVisible = false;
                        item.lObligatorio = false;
                    }
                }
                var dataselTipoCred = (clsConfiguracionDocumento)dtgTipCredSubProd.CurrentRow.DataBoundItem;
                GridReadOnlyCell(dtgTipoPersona,  ColumnIndex , !dataselTipoCred.lVisible, !dataselTipoCred.lObligatorio);
                dtgTipoPersona.RefreshEdit(); 
                dtgTipoPersona.Refresh();
             }

        }
        public void CargarTipoOperacionConfiguracionArchivos(int  ColumnIndex=2)
        {
            if (dtgTipoPersona.CurrentRow == null)
            {
                return;
            }
            if (dtgTipoOperacion.CurrentRow == null)
            {
                return;
            }
            List<int> IdsSubProducto = seleccionSubProducto();
            if (_configuracion.Count() > 0)
            {
                var tipoSubPro = _configuracion.FirstOrDefault(c => IdsSubProducto.Contains(c.idSubProducto));
                if (tipoSubPro != null)
                {
                    DataGridViewRow filSelTipoPersona = dtgTipoPersona.CurrentRow;
                    int idTipoPersona = Convert.ToInt32(filSelTipoPersona.Cells[0].Value);

                    DataGridViewRow filSelTipoOpe= dtgTipoOperacion.CurrentRow;
                    int idTipoOpe = Convert.ToInt32(filSelTipoOpe.Cells[0].Value);
                    var tipotipoOper = tipoSubPro.detalleTipoPersona.FirstOrDefault(x => x.idTipoPersona == idTipoPersona);
                    if (tipotipoOper != null)
                    {

                        foreach (var item in lstTipoOperacion)
                        {
                            foreach (var itemTP in tipotipoOper.detalleTipoOperacion)
                            {
                                if (item.id == itemTP.idTipoOperacion)
                                {
                                    item.lVisible = itemTP.lVisible;
                                    item.lObligatorio = itemTP.lObligatorio;
                                }
                             
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in lstTipoOperacion)
                        {
                            item.lVisible = false;
                            item.lObligatorio = false;
                        }
                    }
                    
                }
                else
                {
                    foreach (var item in lstTipoOperacion)
                    {
                        item.lVisible = false;
                        item.lObligatorio = false;
                    }
                }
                var dataselTipoPersona = (clsConfiguracionDocumento)dtgTipoPersona.CurrentRow.DataBoundItem;
                GridReadOnlyCell(dtgTipoOperacion,  Convert.ToInt32(ColumnIndex)  , !dataselTipoPersona.lVisible, !dataselTipoPersona.lObligatorio);
                dtgTipoOperacion.RefreshEdit();
                dtgTipoOperacion.Refresh();
            }
        }
        public void CargarDestinoCreditoConfiguracionArchivos(int  ColumnIndex = 2)
        {
            if (dtgTipoPersona.CurrentRow == null)
            {
                return;
            }
            if (dtgTipoOperacion.CurrentRow == null)
            {
                return;
            }
            if (dtgDestinoCredito.CurrentRow == null)
            {
                return;
            }
            List<int> IdsSubProducto = seleccionSubProducto();
            if (_configuracion.Count() > 0)
            {
                var tipoSubPro = _configuracion.FirstOrDefault(c => IdsSubProducto.Contains(c.idSubProducto));
                if (tipoSubPro != null)
                {
                    DataGridViewRow filSelTipoPersona = dtgTipoPersona.CurrentRow;
                    int idTipoPersona = Convert.ToInt32(filSelTipoPersona.Cells[0].Value);

                    DataGridViewRow filSelTipoOpe = dtgTipoOperacion.CurrentRow;
                    int idTipoOpe = Convert.ToInt32(filSelTipoOpe.Cells[0].Value);

                    var tipoOperacion = tipoSubPro.detalleTipoPersona.FirstOrDefault(x => x.idTipoPersona == idTipoPersona);
                    if (tipoOperacion != null)
                    {
                        var tipoDesCred = tipoOperacion.detalleTipoOperacion.FirstOrDefault(x => x.idTipoOperacion == idTipoOpe);
                        if (tipoDesCred != null)
                        {

                            foreach (var item in lstDestinoCredito)
                            {
                                
                                foreach (var itemTP in tipoDesCred.detalleDestinoCredito)
                                {
                                    if (item.id == itemTP.idDestinoCredito)
                                    {

                                        item.lVisible = itemTP.lVisible;
                                        item.lObligatorio = itemTP.lObligatorio;
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (var item in lstDestinoCredito)
                            {
                                item.lVisible = false;
                                item.lObligatorio = false;
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in lstDestinoCredito)
                        {
                            item.lVisible = false;
                            item.lObligatorio = false;
                        }
                    }
                    

                }
                else
                {
                    foreach (var item in lstDestinoCredito)
                    {
                        item.lVisible = false;
                        item.lObligatorio = false;
                    }
                }
                var dataselTipoOpe = (clsConfiguracionDocumento)dtgTipoOperacion.CurrentRow.DataBoundItem;
                GridReadOnlyCell(dtgDestinoCredito,  ColumnIndex , !dataselTipoOpe.lVisible, !dataselTipoOpe.lObligatorio);
                dtgDestinoCredito.RefreshEdit();
                dtgDestinoCredito.Refresh();
            }
        }
        public void CargarRangoMontoConfiguracionArchivos(int ColumnIndex = 2)
        {
            if (dtgTipoPersona.CurrentRow == null)
            {
                return;
            }
            if (dtgTipoOperacion.CurrentRow == null)
            {
                return;
            }
            if (dtgDestinoCredito.CurrentRow == null)
            {
                return;
            }
            List<int> IdsSubProducto = seleccionSubProducto();
            if (_configuracion.Count() > 0)
            {
                var tipoSubPro = _configuracion.FirstOrDefault(c => IdsSubProducto.Contains(c.idSubProducto));
                if (tipoSubPro != null)
                {
                    DataGridViewRow filSelTipoPersona = dtgTipoPersona.CurrentRow;
                    int idTipoPersona = Convert.ToInt32(filSelTipoPersona.Cells[0].Value);

                    DataGridViewRow filSelTipoOpe = dtgTipoOperacion.CurrentRow;
                    int idTipoOpe = Convert.ToInt32(filSelTipoOpe.Cells[0].Value);

                    DataGridViewRow filSelDesCred = dtgDestinoCredito.CurrentRow;
                    int idDesCred = Convert.ToInt32(filSelDesCred.Cells[0].Value);
                     
                    var tipoOperacion = tipoSubPro.detalleTipoPersona.FirstOrDefault(x => x.idTipoPersona == idTipoPersona);
                    if (tipoOperacion != null)
                    {
                        var tipoDesCred = tipoOperacion.detalleTipoOperacion.FirstOrDefault(x => x.idTipoOperacion == idTipoOpe);

                        if (tipoDesCred != null)
                        {
                                        var tipoMonto = tipoDesCred.detalleDestinoCredito.FirstOrDefault(x => x.idDestinoCredito == idDesCred);

                                        if (tipoMonto != null)
                                        {

                                            foreach (var item in lstMonto)
                                            {
                                                foreach (var itemTP in tipoMonto.detalleRangoMonto)
                                                {
                                                    if (item.id == itemTP.idRangoMonto)
                                                    {
                                                        item.lVisible = itemTP.lVisible;
                                                        item.lObligatorio = itemTP.lObligatorio;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            foreach (var item in lstMonto)
                                            {
                                                item.lVisible = false;
                                                item.lObligatorio = false;
                                            }
                                        }
                        }
                        else
                        {
                            foreach (var item in lstMonto)
                            {
                                item.lVisible = false;
                                item.lObligatorio = false;
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in lstMonto)
                        {
                            item.lVisible = false;
                            item.lObligatorio = false;
                        }
                    }
                }
                else
                {
                    foreach (var item in lstMonto)
                    {
                        item.lVisible = false;
                        item.lObligatorio = false;
                    }
                }
                var dataselDesCred = (clsConfiguracionDocumento)dtgDestinoCredito.CurrentRow.DataBoundItem;
                GridReadOnlyCell(dtgMonto,  ColumnIndex , !dataselDesCred.lVisible, !dataselDesCred.lObligatorio);

                dtgMonto.RefreshEdit();
                dtgMonto.Refresh();
            }
        }

        private List<int> seleccionSubProducto()
        {
            List<int> IdsSubProducto = new List<int>();
            foreach (DataGridViewRow row in dtgTipCredSubProd.SelectedRows)
            {
                // Obtener el valor de la primera celda de la fila seleccionada
                int valor = Convert.ToInt32(row.Cells[0].Value);
                IdsSubProducto.Add(valor);
            }
            return IdsSubProducto;
        }
        private void limpiarChecks()
        {
            foreach (var item in lstTipCredSubProd)
            {
                item.lVisible = false;
                item.lObligatorio = false;
            }
            foreach (var item in lstTipoPersona)
            {
                item.lVisible = false;
                item.lObligatorio = false;
            }
            foreach (var item in lstTipoOperacion)
            {
                item.lVisible = false;
                item.lObligatorio = false;
            }
            foreach (var item in lstDestinoCredito)
            {
                item.lVisible = false;
                item.lObligatorio = false;
            }
            foreach (var item in lstMonto)
            {
                item.lVisible = false;
                item.lObligatorio = false;
            }
            dtgTipCredSubProd.RefreshEdit();
            dtgTipCredSubProd.Refresh();
            dtgTipoPersona.RefreshEdit();
            dtgTipoPersona.Refresh();
            dtgTipoOperacion.RefreshEdit();
            dtgTipoOperacion.Refresh();
            dtgDestinoCredito.RefreshEdit();
            dtgDestinoCredito.Refresh();
            dtgMonto.RefreshEdit();
            dtgMonto.Refresh();
        }
        public void cargarfigurarCargaArchivoNuevoReg(clsTipoArchivoEscaneado _documento, clsListaConfiguracionTipoArchivoEscaneado listaConfiguracion)
        {
            this.txtNuevoArchivo.ReadOnly = true;
            this.dtpFechaVigencia.Enabled = false;
            this._configuracion = new BindingList<clsConfigSubProArcEscaneado>();
       
            this.txtNuevoArchivo.Text = _documento.cTipoArchivo;
         
            this.rbtIndeterminado.Checked = _documento.lIndefinido;
            this.rbtConFechaVigencia.Checked = _documento.lConFechaVigencia;
            this.pIdGrupoArchivo = _documento.idGrupoArchivo;
            this.dtpFechaVigencia.Visible = false;
            this.lblBase8.Visible = false;
            if (_documento.lConFechaVigencia)
            {
                this.dtpFechaVigencia.Value = (DateTime)_documento.dFechaVigencia;
                this.dtpFechaVigencia.Visible = true;
                this.lblBase8.Visible = true;
            }
            pDocumento = _documento;
            pListaConfiguracion = listaConfiguracion;
            limpiarChecks();
   
            //generar
            var tipoProducto = pListaConfiguracion.GroupBy(o => new { o.idSubProducto,o.idTipoCredito, o.cTipoCreditoSubProducto}).ToList();
            foreach (var itemSubProd in tipoProducto)
            {
                clsConfigSubProArcEscaneado _tipoCred = new clsConfigSubProArcEscaneado();
                _tipoCred.idSubProducto = itemSubProd.FirstOrDefault().idSubProducto;
                _tipoCred.idTipoCredito = itemSubProd.FirstOrDefault().idTipoCredito;
                _tipoCred.cSubProducto = itemSubProd.FirstOrDefault().cSubProducto;
             
                _tipoCred.detalleTipoPersona = new BindingList<clsConfigTipoPersona>();
                _tipoCred.idTipoArchivo = pDocumento.idTipoArchivo;
                _tipoCred.idGrupoArchivo = pDocumento.idGrupoArchivo;

                var _TipoPersonaBD = pListaConfiguracion.Where(x => x.idSubProducto == itemSubProd.FirstOrDefault().idSubProducto).GroupBy(o => new { o.idTipoPersona, o.cTipoPersona }).ToList();

                foreach (var itemTipPer in lstTipoPersona)
                {
                    var itemTP = _TipoPersonaBD.FirstOrDefault(x => x.FirstOrDefault().idTipoPersona == itemTipPer.id);
                    clsConfigTipoPersona _tipoPer = new clsConfigTipoPersona(itemTipPer.id, itemTipPer.cDescripcion, _tipoCred); 
                    _tipoPer.detalleTipoOperacion = new BindingList<clsConfigTipoOperacion>();
                    var _TipoOperacionBD = pListaConfiguracion.Where(x => x.idSubProducto == itemSubProd.FirstOrDefault().idSubProducto
                                                                        && x.idTipoPersona == _tipoPer.idTipoPersona).GroupBy(o => new { o.idTipoOperacion, o.cTipoOperacion }).ToList();

                    foreach (var itemTipOpe in lstTipoOperacion)
                    {
                        var itemTOP = _TipoOperacionBD.FirstOrDefault(x => x.FirstOrDefault().idTipoOperacion == itemTipOpe.id);
                        clsConfigTipoOperacion _tipoOpe = new clsConfigTipoOperacion(itemTipOpe.id, itemTipOpe.cDescripcion, _tipoPer); 
                        _tipoOpe.detalleDestinoCredito = new BindingList<clsConfigDestinoCredito>();

                        var _DestinoCreditoBD = pListaConfiguracion.Where(x => x.idSubProducto == itemSubProd.FirstOrDefault().idSubProducto
                                                    && x.idTipoPersona == _tipoPer.idTipoPersona
                                                     && x.idTipoOperacion == _tipoOpe.idTipoOperacion).GroupBy(o => new { o.idDestinoCredito, o.cDestinoCredito }).ToList();

                        foreach (var itemDesCred in lstDestinoCredito)
                        {
                            var itemDC = _DestinoCreditoBD.FirstOrDefault(x => x.FirstOrDefault().idDestinoCredito == itemDesCred.id);
                            clsConfigDestinoCredito _tipoDesCred = new clsConfigDestinoCredito(itemDesCred.id, itemDesCred.cDescripcion, _tipoOpe);  
                            _tipoDesCred.detalleRangoMonto = new BindingList<clsConfigRangoMonto>();
                            var _RangoMontoBD = pListaConfiguracion.Where(x => x.idSubProducto == itemSubProd.FirstOrDefault().idSubProducto
                                                && x.idTipoPersona == _tipoPer.idTipoPersona
                                                 && x.idTipoOperacion == _tipoOpe.idTipoOperacion
                                                 && x.idDestinoCredito == _tipoDesCred.idDestinoCredito).GroupBy(o => new { o.idRangoMonto, o.cRangoMonto, o.lVisible, o.lObligatorio }).ToList();

                            foreach (var itemRanMonto in lstMonto)
                            {
                                var itemRM = _RangoMontoBD.FirstOrDefault(x => x.FirstOrDefault().idRangoMonto == itemRanMonto.id);
                                clsConfigRangoMonto _tipoRanMonto = new clsConfigRangoMonto(itemRanMonto.id, itemRanMonto.cDescripcion, _tipoDesCred); 

                                _tipoRanMonto.lObligatorio = itemRM==null? false : itemRM.FirstOrDefault().lObligatorio;
                                _tipoRanMonto.lVisible = itemRM == null ? false : itemRM.FirstOrDefault().lVisible;
                                _tipoDesCred.detalleRangoMonto.Add(_tipoRanMonto);
                            }
                            _tipoDesCred.validarVisibilidadObligatoriedad(); 
                            _tipoOpe.detalleDestinoCredito.Add(_tipoDesCred);
                        }
                        _tipoOpe.validarVisibilidadObligatoriedad(); 
                        _tipoPer.detalleTipoOperacion.Add(_tipoOpe);

                    }
                    _tipoPer.validarVisibilidadObligatoriedad();  
                    _tipoCred.detalleTipoPersona.Add(_tipoPer);
                }
                _tipoCred.validarVisibilidadObligatoriedad(); 
                _configuracion.Add(_tipoCred);

            }
            foreach (var item in lstTipCredSubProd)
            {
                foreach (var _item in _configuracion)
                {
                    if (item.id == _item.idSubProducto)
                    {
                        item.lVisible = _item.lVisible;
                        item.lObligatorio = _item.lObligatorio;
                    }
                }
            }
            this.CargarTipoPersonaConfiguracionArchivos();
            this.CargarTipoOperacionConfiguracionArchivos();
            this.CargarDestinoCreditoConfiguracionArchivos();
            this.CargarRangoMontoConfiguracionArchivos();

            dtgTipCredSubProd.RefreshEdit();
            dtgTipCredSubProd.Refresh();
            dtgTipoPersona.RefreshEdit();
            dtgTipoPersona.Refresh();
            dtgTipoOperacion.RefreshEdit();
            dtgTipoOperacion.Refresh();
            dtgDestinoCredito.RefreshEdit();
            dtgDestinoCredito.Refresh();
            dtgMonto.RefreshEdit();
            dtgMonto.Refresh();
        }
        #region Eventos

        public List<int> SelecccionarTipoCredito(chklbBase chklbCredito)
        {
            List<int> idsProductos = new List<int>();
            foreach (DataRowView item in chklbCredito.CheckedItems)
            {
                idsProductos.Add(Convert.ToInt32(item["IdProducto"]));
            }
            return idsProductos;
        }
        #endregion

        private void btnAgregarMonto_Click(object sender, EventArgs e)
        {
            frmConRanMonCarArc frmConfgMonto = new frmConRanMonCarArc();
            frmConfgMonto.ShowDialog(); 
            if (frmConfgMonto.lGuardado)
            {
                 lstMonto.Add(new clsConfigDocxMonto()
                {
                    id =  frmConfgMonto.pDataConfiguracion.id,
                    cDescripcion = frmConfgMonto.pDataConfiguracion.cDescripcion,
                    nMontoMinimo = frmConfgMonto.pDataConfiguracion.nMontoMinimo,
                    nMontoMaximo =frmConfgMonto.pDataConfiguracion.nMontoMaximo
                });
                 dtgMonto.RefreshEdit();
                 dtgMonto.Refresh();
            }
        }

        private void btnEditarMonto_Click_1(object sender, EventArgs e)
        {
            var dataselMonto = (clsConfigDocxMonto)dtgMonto.CurrentRow.DataBoundItem;
            frmConRanMonCarArc frmConfgMonto = new frmConRanMonCarArc(dataselMonto);
            frmConfgMonto.ShowDialog();
            if (frmConfgMonto.lGuardado)
            {
                dataselMonto.cDescripcion = frmConfgMonto.pDataConfiguracion.cDescripcion; 
                dataselMonto.nMontoMinimo = frmConfgMonto.pDataConfiguracion.nMontoMinimo; 
                dataselMonto.nMontoMaximo = frmConfgMonto.pDataConfiguracion.nMontoMaximo;

            }
             
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            eventoFormulario = EventoFormulario.EDITAR;
            habilitar(true);
            menuStrip1.Enabled = false; 
            GridReadOnlyColumn(dtgTipCredSubProd);
            GridReadOnlyColumn(dtgTipoPersona);
            GridReadOnlyColumn(dtgTipoOperacion);
            GridReadOnlyColumn(dtgDestinoCredito);
            GridReadOnlyColumn(dtgMonto);

            var dataselTipoCred = (clsConfiguracionDocumento)dtgTipCredSubProd.CurrentRow.DataBoundItem;
            GridReadOnlyCell(dtgTipoPersona, 2, !dataselTipoCred.lVisible, !dataselTipoCred.lObligatorio);
            var dataselTipoPersona = (clsConfiguracionDocumento)dtgTipoPersona.CurrentRow.DataBoundItem;
            GridReadOnlyCell(dtgTipoOperacion, 2, !dataselTipoPersona.lVisible, !dataselTipoPersona.lObligatorio);
            var dataselTipoOpe = (clsConfiguracionDocumento)dtgTipoOperacion.CurrentRow.DataBoundItem;
            GridReadOnlyCell(dtgDestinoCredito, 2, !dataselTipoOpe.lVisible, !dataselTipoOpe.lObligatorio);
            var dataselDesCred = (clsConfiguracionDocumento)dtgDestinoCredito.CurrentRow.DataBoundItem;
            GridReadOnlyCell(dtgMonto, 2, !dataselDesCred.lVisible, !dataselDesCred.lObligatorio);

            if (ClicEventosEditar != null)
                ClicEventosEditar(sender, e);
        }
        private void GridReadOnlyColumn(DataGridView dtg)
        {
            dtg.ReadOnly = false;
            foreach (DataGridViewColumn col in dtg.Columns)
            {
                col.ReadOnly = true; 
                if (col.Index == 2 || col.Index == 4)
                {
                    col.ReadOnly = false;
                }
            }
        }
        

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            eventoFormulario= EventoFormulario.NUEVO;
            habilitar(true);

            menuStrip1.Enabled = false;
            GridReadOnlyColumn(dtgTipCredSubProd);
            GridReadOnlyColumn(dtgTipoPersona);
            GridReadOnlyColumn(dtgTipoOperacion);
            GridReadOnlyColumn(dtgDestinoCredito);
            GridReadOnlyColumn(dtgMonto);

            var dataselTipoCred = (clsConfiguracionDocumento)dtgTipCredSubProd.CurrentRow.DataBoundItem;
            GridReadOnlyCell(dtgTipoPersona, 2, !dataselTipoCred.lVisible, !dataselTipoCred.lObligatorio);
            var dataselTipoPersona = (clsConfiguracionDocumento)dtgTipoPersona.CurrentRow.DataBoundItem;
            GridReadOnlyCell(dtgTipoOperacion, 2, !dataselTipoPersona.lVisible, !dataselTipoPersona.lObligatorio);
            var dataselTipoOpe = (clsConfiguracionDocumento)dtgTipoOperacion.CurrentRow.DataBoundItem;
            GridReadOnlyCell(dtgDestinoCredito, 2, !dataselTipoOpe.lVisible, !dataselTipoOpe.lObligatorio);
            var dataselDesCred = (clsConfiguracionDocumento)dtgDestinoCredito.CurrentRow.DataBoundItem;
            GridReadOnlyCell(dtgMonto, 2, !dataselDesCred.lVisible, !dataselDesCred.lObligatorio);

            if (ClicEventosNuevo != null)
                ClicEventosNuevo(sender, e);
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            eventoFormulario = EventoFormulario.CANCELAR;
            habilitar(false);

            menuStrip1.Enabled = true; 
            dtgTipCredSubProd.ReadOnly = true;
            dtgTipoPersona.ReadOnly = true;
            dtgTipoOperacion.ReadOnly = true;
            dtgDestinoCredito.ReadOnly = true;
            dtgMonto.ReadOnly = true;

            if (ClicEventosCancelar != null)
                ClicEventosCancelar(sender, e);
        }
        private void habilitar(bool lactiva)
        {
            btnGrabar1.Enabled = lactiva;
            btnEditar1.Enabled = !lactiva;
            btnNuevo1.Enabled = !lactiva;
            btnCancelar1.Enabled = lactiva;

            chcSelecTodoVisbleTipoPersona.Enabled = lactiva;
            chcSelecTodoObliTipoPersona.Enabled = lactiva;
            chcSelecTodosTipOpeVisible.Enabled = lactiva;
            chcSelecTodosTipOpeObli.Enabled = lactiva;
            chcSelecTodoVisibleDestinoCredito.Enabled = lactiva;
            chcSelecTodoObliDestinoCredito.Enabled = lactiva; 
            chcSelecTodoVisibleMonto.Enabled = lactiva;
            chcSelecTodoObliMonto.Enabled = lactiva;
        }

        private void btnGrabar1_Click_1(object sender, EventArgs e)
        {
            eventoFormulario = EventoFormulario.GRABAR;
            pListaConfiguracion = new clsListaConfiguracionTipoArchivoEscaneado();
            this.btnGrabar1.Enabled = false;
            foreach (var _config in _configuracion)
            {
                foreach (var _tipoPer in _config.detalleTipoPersona)
                { 
                    foreach (var _tipoOpe in _tipoPer.detalleTipoOperacion)
                    { 
                        foreach (var _tipoDesCred in _tipoOpe.detalleDestinoCredito)
                        { 
                            foreach (var _tipoRanMonto in _tipoDesCred.detalleRangoMonto)
                            {
                                pListaConfiguracion.Add(new clsConfiguracionTipoArchivoEscaneado()
                                {
                                   idSubProducto    = _config.idSubProducto,
                                   idTipoCredito    = _config.idTipoCredito, 
                                   idTipoPersona    = _tipoPer.idTipoPersona,
                                   idTipoOperacion  = _tipoOpe.idTipoOperacion,
                                   idDestinoCredito = _tipoDesCred.idDestinoCredito,
                                   idRangoMonto     = _tipoRanMonto.idRangoMonto,
                                   idTipoArchivo    = _config.idTipoArchivo,
                                   lVisible         = _tipoRanMonto.lVisible,
                                   lObligatorio     = _tipoRanMonto.lObligatorio
                                });
                            }
                        }
                    }
                } 
            }

            if (MessageBox.Show("¿Está seguro de guardar la configuración?", this.titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                clsDBResp dtRes = clsConfiguracion.CNGuardarConfiguracion2(pListaConfiguracion.obtenerXml(), clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem.Date, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem.Date
                    );
                if (dtRes.nMsje == 0)
                {
                    habilitar(false);
                    this.btnNuevo1.Enabled = false; 
                    dtgTipCredSubProd.ReadOnly = true;
                    dtgTipoPersona.ReadOnly = true;
                    dtgTipoOperacion.ReadOnly = true;
                    dtgDestinoCredito.ReadOnly = true;
                    dtgMonto.ReadOnly = true; 
                     
                    menuStrip1.Enabled = true;
                    if (ClicEventosGuardar != null)
                        ClicEventosGuardar(sender, e);
                    MessageBox.Show(dtRes.cMsje, this.titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.btnGrabar1.Enabled = true;
                    MessageBox.Show(dtRes.cMsje, this.titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                this.btnGrabar1.Enabled = true;
            }


        }

        private void conConfiguracionArchivos_Load(object sender, EventArgs e)
        {

        }

        private void chcSelecTodosTipOpeVisible_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in lstTipoOperacion)
            {
                item.lVisible = this.chcSelecTodosTipOpeVisible.Checked;
            }
            dtgTipoOperacion.RefreshEdit();
            dtgTipoOperacion.Refresh();
        }

        private void chcSelecTodosTipOpeObli_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in lstTipoOperacion)
            {
                item.lObligatorio = this.chcSelecTodosTipOpeObli.Checked;
            }
            dtgTipoOperacion.RefreshEdit();
            dtgTipoOperacion.Refresh();
        }

        private void chcSelecTodoVisbleTipoPersona_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in lstTipoPersona)
            {
                item.lVisible = this.chcSelecTodoVisbleTipoPersona.Checked;
            }
            dtgTipoPersona.RefreshEdit();
            dtgTipoPersona.Refresh();
        }

        private void chcSelecTodoObliTipoPersona_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in lstTipoPersona)
            {
                item.lObligatorio = this.chcSelecTodoObliTipoPersona.Checked;
            }
            dtgTipoPersona.RefreshEdit();
            dtgTipoPersona.Refresh();
        }

        private void chcSelecTodoVisibleDestinoCredito_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in lstDestinoCredito)
            {
                item.lVisible = this.chcSelecTodoVisibleDestinoCredito.Checked;
            }
            dtgDestinoCredito.RefreshEdit();
            dtgDestinoCredito.Refresh();
        }

        private void chcSelecTodoObliDestinoCredito_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in lstDestinoCredito)
            {
                item.lObligatorio = this.chcSelecTodoObliDestinoCredito.Checked;
            }
            dtgDestinoCredito.RefreshEdit();
            dtgDestinoCredito.Refresh();
        }

        private void chcSelecTodoVisibleMonto_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in lstMonto)
            {
                item.lVisible = this.chcSelecTodoVisibleMonto.Checked;
            }
            dtgMonto.RefreshEdit();
            dtgMonto.Refresh();
        }

        private void chcSelecTodoObliMonto_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in lstMonto)
            {
                item.lObligatorio = this.chcSelecTodoObliMonto.Checked;
            }
            dtgMonto.RefreshEdit();
            dtgMonto.Refresh();
        }
 
        private void generarConfigurarion(clsConfiguracionDocumento item)
        {
            if (pDocumento == null)
            {
                return;
           }
                
                if (_configuracion.Count(x => x.idSubProducto == item.id ) > 0)
                {
                    var _condiguracion = _configuracion.FirstOrDefault(x => x.idSubProducto == item.id);
                    _condiguracion.lVisible = item.lVisible;
                    _condiguracion.lObligatorio = item.lObligatorio;
                    _condiguracion.idGrupoArchivo = this.pIdGrupoArchivo;
                    foreach (var _tipoPer in _condiguracion.detalleTipoPersona)
                    {
                        _tipoPer.lObligatorio = item.lObligatorio;
                        _tipoPer.lVisible = item.lVisible;
                        foreach (var _tipoOpe in _tipoPer.detalleTipoOperacion)
                        { 
                            _tipoOpe.lObligatorio = item.lObligatorio;
                            _tipoOpe.lVisible = item.lVisible;
                            foreach (var _tipoDesCred in _tipoOpe.detalleDestinoCredito)
                            {
                                 
                                _tipoDesCred.lObligatorio = item.lObligatorio;
                                _tipoDesCred.lVisible = item.lVisible;
                                foreach (var _tipoRanMonto in _tipoDesCred.detalleRangoMonto)
                                { 
                                    _tipoRanMonto.lObligatorio = item.lObligatorio;
                                    _tipoRanMonto.lVisible = item.lVisible; 
                                }
                             } 
                        }
                     }
                }
                else
                {
                    clsConfigSubProArcEscaneado _tipoCred = new clsConfigSubProArcEscaneado();
                    _tipoCred.idSubProducto = item.id;
                    _tipoCred.idTipoCredito = item.idPadre;
                    _tipoCred.cSubProducto = item.cDescripcion;
                    _tipoCred.lObligatorio = item.lObligatorio;
                    _tipoCred.lVisible = item.lVisible;
                    _tipoCred.detalleTipoPersona = new BindingList<clsConfigTipoPersona>();
                    _tipoCred.idTipoArchivo = pDocumento.idTipoArchivo;
                    _tipoCred.idGrupoArchivo = pDocumento.idGrupoArchivo;
                    foreach (var itemTipPer in lstTipoPersona)
                    {
                        clsConfigTipoPersona _tipoPer = new clsConfigTipoPersona(itemTipPer.id, itemTipPer.cDescripcion, _tipoCred); 
                        _tipoPer.lObligatorio = item.lObligatorio;
                        _tipoPer.lVisible = item.lVisible;
                        _tipoPer.detalleTipoOperacion = new BindingList<clsConfigTipoOperacion>();
                        foreach (var itemTipOpe in lstTipoOperacion)
                        {
                            clsConfigTipoOperacion _tipoOpe = new clsConfigTipoOperacion(itemTipOpe.id, itemTipOpe.cDescripcion,_tipoPer); 
                            _tipoOpe.lObligatorio = item.lObligatorio;
                            _tipoOpe.lVisible = item.lVisible;
                            _tipoOpe.detalleDestinoCredito = new BindingList<clsConfigDestinoCredito>();
                            foreach (var itemDesCred in lstDestinoCredito)
                            {
                                clsConfigDestinoCredito _tipoDesCred = new clsConfigDestinoCredito(itemDesCred.id, itemDesCred.cDescripcion, _tipoOpe); 
                                _tipoDesCred.lObligatorio = item.lObligatorio;
                                _tipoDesCred.lVisible = item.lVisible;
                                _tipoDesCred.detalleRangoMonto = new BindingList<clsConfigRangoMonto>();
                                foreach (var itemRanMonto in lstMonto)
                                {
                                    clsConfigRangoMonto _tipoRanMonto = new clsConfigRangoMonto(itemRanMonto.id, itemRanMonto.cDescripcion, _tipoDesCred); 
                                    _tipoRanMonto.lObligatorio = item.lObligatorio;
                                    _tipoRanMonto.lVisible = item.lVisible;
                                    _tipoDesCred.detalleRangoMonto.Add(_tipoRanMonto);
                                }
                                _tipoOpe.detalleDestinoCredito.Add(_tipoDesCred);
                            }
                            _tipoPer.detalleTipoOperacion.Add(_tipoOpe);

                        }
                        _tipoCred.detalleTipoPersona.Add(_tipoPer);
                    }
                    _configuracion.Add(_tipoCred);
                }
                 
       
        }
 

        private void dtgTipCredSubProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (dtgTipCredSubProd.ReadOnly) return;
            this.CargarTipoPersonaConfiguracionArchivos();
            this.CargarTipoOperacionConfiguracionArchivos();
            this.CargarDestinoCreditoConfiguracionArchivos(); 
            this.CargarRangoMontoConfiguracionArchivos();
            if (e.ColumnIndex == 4 || e.ColumnIndex == 2) // Columna del checkbox obligatorio
            {
                dtgTipCredSubProd.CommitEdit(DataGridViewDataErrorContexts.Commit);
                ActualizaTipCredSubProd(e.ColumnIndex, e.RowIndex);

            }
        }

        private void dtgTipoPersona_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (dtgTipoPersona.ReadOnly) return;
            this.CargarTipoOperacionConfiguracionArchivos();
            this.CargarDestinoCreditoConfiguracionArchivos();
            this.CargarRangoMontoConfiguracionArchivos();

            if (e.ColumnIndex == 4 || e.ColumnIndex == 2) // Columna del checkbox obligatorio
            {
                dtgTipoPersona.CommitEdit(DataGridViewDataErrorContexts.Commit);
                ActualizaTipoPersona(e.ColumnIndex, e.RowIndex);
                
            }
        }
        private void dtgTipoOperacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1) return; 
            if (dtgTipoOperacion.ReadOnly) return;

            if (e.ColumnIndex == 4 || e.ColumnIndex == 2) // Columna del checkbox obligatorio
            {
                dtgTipoOperacion.CommitEdit(DataGridViewDataErrorContexts.Commit); 
                ActualizaTipoOperacion(e.ColumnIndex, e.RowIndex);

            }
        }

        private void dtgDestinoCredito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return; 
            if (dtgDestinoCredito.ReadOnly) return;
            this.CargarRangoMontoConfiguracionArchivos();

            if (e.ColumnIndex == 4 || e.ColumnIndex == 2) // Columna del checkbox obligatorio
            {
                dtgDestinoCredito.CommitEdit(DataGridViewDataErrorContexts.Commit);
                ActualizaDestino(e.ColumnIndex, e.RowIndex);
                
            }
        }
        private void dtgMonto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (dtgMonto.ReadOnly) return;
            this.obtenerTipoPersonaSeleccionado();
            this.obtenerTipoOperacionSeleccionado();
            this.obtenerDestinoCreditoSeleccionado();

            if (e.ColumnIndex == 4 || e.ColumnIndex == 2) // Columna del checkbox obligatorio
            {
               
                dtgMonto.CommitEdit(DataGridViewDataErrorContexts.Commit);
                ActualizaMonto(e.ColumnIndex, e.RowIndex);
            } 
        }
        private void GridReadOnlyCell(DataGridView dtgParam, int colIndex, bool lReadOnlyVisible, bool lReadOnlyObligatorio)
        {
            if (this.eventoFormulario == EventoFormulario.EDITAR || this.eventoFormulario == EventoFormulario.NUEVO)
            {
                dtgParam.ReadOnly = false;
                foreach (DataGridViewColumn col in dtgParam.Columns)
                {
                    col.ReadOnly = true;
                    if (colIndex == 2 && (col.Index == 2 || col.Index == 4))
                    {
                        col.ReadOnly = lReadOnlyVisible; 
                    }
                    else if (colIndex == 4 && (col.Index == 2 || col.Index == 4))
                    {
                        if (lReadOnlyObligatorio && !lReadOnlyVisible)
                        {
                            col.ReadOnly = false;
                        }
                        else
                        {
                            col.ReadOnly = lReadOnlyObligatorio; 
                        }
                       
                    }
                   
                }
                dtgParam.RefreshEdit();
                dtgParam.Refresh();
            }
            
        }
        private void dtgTipCredSubProd_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (dtgTipCredSubProd.SelectedRows.Count > 1)
            {
                if (!CompareSelectedRows(e.RowIndex))
                {
                    dtgTipCredSubProd.Rows[e.RowIndex].Selected = false;
                    dtgTipCredSubProd.RefreshEdit();
                    dtgTipCredSubProd.Refresh();
                    MessageBox.Show("Tiene configuraciones diferentes", this.titulo,MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void dtgTipoPersona_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            this.CargarTipoOperacionConfiguracionArchivos();
            this.CargarDestinoCreditoConfiguracionArchivos();
            this.CargarRangoMontoConfiguracionArchivos();
        }
        private void dtgTipoOperacion_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            this.CargarDestinoCreditoConfiguracionArchivos();
            this.CargarRangoMontoConfiguracionArchivos();
        }
        private void dtgDestinoCredito_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            this.CargarRangoMontoConfiguracionArchivos();
        }

      
        private void actualizarIconoGrid()
        {
            // Obtener la celda de CheckBox
            DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dtgTipoPersona.Rows[0].Cells[4];
            // Establecer el icono de cuadrado 
            checkBoxCell.ThreeState = true;
            checkBoxCell.Value = checkBoxCell.FalseValue;
            checkBoxCell.IndeterminateValue = true;
        }
        private void activarObligatorio(ref DataGridView dtg, ref clsListaConfiguracionDocumento lstConfiguracion, int RowIndex, int ColumnIndex, bool lEstadoSel)
        {
            foreach (var item in lstConfiguracion)
            {
                item.lObligatorio = lEstadoSel;
            }
            dtg.ReadOnly = false;
            dtg.RefreshEdit();
            dtg.Refresh();
        }

        private void dtgTipCredSubProd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;  
            var dataselTipoCred = (clsConfiguracionDocumento)dtgTipCredSubProd.CurrentRow.DataBoundItem;
            if (dataselTipoCred.lVisible && !dataselTipoCred.lObligatorio)
            {
                this.CargarTipoPersonaConfiguracionArchivos(4);
            }
            else
            {
                this.CargarTipoPersonaConfiguracionArchivos();
            }
             
            var dataselTipoPersona = (clsConfiguracionDocumento)dtgTipoPersona.CurrentRow.DataBoundItem;
            if (dataselTipoPersona.lVisible && !dataselTipoPersona.lObligatorio)
            {
                this.CargarTipoOperacionConfiguracionArchivos(4);
            }
            else
            {
                this.CargarTipoOperacionConfiguracionArchivos();
            }
            var dataselTipoOpe = (clsConfiguracionDocumento)dtgTipoOperacion.CurrentRow.DataBoundItem;
            if (dataselTipoOpe.lVisible && !dataselTipoOpe.lObligatorio)
            {
                this.CargarDestinoCreditoConfiguracionArchivos(4);
            }
            else
            {
                this.CargarDestinoCreditoConfiguracionArchivos();
            }

            var dataselDesCred = (clsConfiguracionDocumento)dtgDestinoCredito.CurrentRow.DataBoundItem;
            if (dataselDesCred.lVisible && !dataselDesCred.lObligatorio)
            {
                this.CargarRangoMontoConfiguracionArchivos(4);
            }
            else
            {
                this.CargarRangoMontoConfiguracionArchivos();
            }
        }

        private void dtgTipoPersona_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return; 
            this.obtenerTipoPersonaSeleccionado();
            var dataselTipoPersona = (clsConfiguracionDocumento)dtgTipoPersona.CurrentRow.DataBoundItem;
            if (dataselTipoPersona.lVisible && !dataselTipoPersona.lObligatorio)
            {
                this.CargarTipoOperacionConfiguracionArchivos(4);
            }
            else
            {
                this.CargarTipoOperacionConfiguracionArchivos();
            }
            var dataselTipoOpe = (clsConfiguracionDocumento)dtgTipoOperacion.CurrentRow.DataBoundItem;
            if (dataselTipoOpe.lVisible && !dataselTipoOpe.lObligatorio)
            {
                this.CargarDestinoCreditoConfiguracionArchivos(4);
            }
            else
            {
                this.CargarDestinoCreditoConfiguracionArchivos();
            }

            var dataselDesCred = (clsConfiguracionDocumento)dtgDestinoCredito.CurrentRow.DataBoundItem;
            if (dataselDesCred.lVisible && !dataselDesCred.lObligatorio)
            {
                this.CargarRangoMontoConfiguracionArchivos(4);
            }
            else
            {
                this.CargarRangoMontoConfiguracionArchivos();
            }
        }
        private void obtenerTipoPersonaSeleccionado() {
            var datasel = (clsConfiguracionDocumento)dtgTipoPersona.CurrentRow.DataBoundItem;
            _TipoPersonaSel = new List<clsConfigTipoPersona>();
            List<int> IdsSubProducto = seleccionSubProducto();
            foreach (var itemConfig in _configuracion.Where(c => IdsSubProducto.Contains(c.idSubProducto)))
            {
                var _TipPerSel = itemConfig.detalleTipoPersona.FirstOrDefault(x => x.idTipoPersona == datasel.id);
                _TipoPersonaSel.Add(_TipPerSel);
            }
        }

        private void dtgTipoOperacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            this.obtenerTipoPersonaSeleccionado();
            this.obtenerTipoOperacionSeleccionado(); 

            var dataselTipoOpe = (clsConfiguracionDocumento)dtgTipoOperacion.CurrentRow.DataBoundItem;
            if (dataselTipoOpe.lVisible && !dataselTipoOpe.lObligatorio)
            {
                this.CargarDestinoCreditoConfiguracionArchivos(4);
            }
            else
            {
                this.CargarDestinoCreditoConfiguracionArchivos();
            }

            var dataselDesCred = (clsConfiguracionDocumento)dtgDestinoCredito.CurrentRow.DataBoundItem;
            if (dataselDesCred.lVisible && !dataselDesCred.lObligatorio)
            {
                this.CargarRangoMontoConfiguracionArchivos(4);
            }
            else
            {
                this.CargarRangoMontoConfiguracionArchivos();
            }


        }
        private void obtenerTipoOperacionSeleccionado(){
            var dataselTipOpe = (clsConfiguracionDocumento)dtgTipoOperacion.CurrentRow.DataBoundItem;
            _TipoOperacionSel = new List<clsConfigTipoOperacion>();
            foreach (var itemTipOpe in _TipoPersonaSel)
            {
                var _TipOpeSel = itemTipOpe.detalleTipoOperacion.FirstOrDefault(x => x.idTipoOperacion == dataselTipOpe.id);
                _TipoOperacionSel.Add(_TipOpeSel);
            }
        }
        private void dtgDestinoCredito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            this.obtenerTipoPersonaSeleccionado();
            this.obtenerTipoOperacionSeleccionado();
            this.obtenerDestinoCreditoSeleccionado();

            var dataselDesCred = (clsConfiguracionDocumento)dtgDestinoCredito.CurrentRow.DataBoundItem;
            if (dataselDesCred.lVisible && !dataselDesCred.lObligatorio)
            {
                this.CargarRangoMontoConfiguracionArchivos(4);
            }
            else
            {
                this.CargarRangoMontoConfiguracionArchivos();
            }
            
        }
        
        private void obtenerDestinoCreditoSeleccionado()
        {
            var dataselDesCred = (clsConfiguracionDocumento)dtgDestinoCredito.CurrentRow.DataBoundItem;
            _DesCreditoSel = new List<clsConfigDestinoCredito>();

            foreach (var itemOperacionSel in _TipoOperacionSel)
            {
                var _DesCredSel = itemOperacionSel.detalleDestinoCredito.FirstOrDefault(x => x.idDestinoCredito == dataselDesCred.id);
                _DesCreditoSel.Add(_DesCredSel);
            }
        }
        private bool CompareSelectedRows(int index)
        {
            List<int> selectedRows = new List<int>();
            DataGridViewRow lastSelectedRow = dtgTipCredSubProd.Rows[index];
            int idSubProdTipCredUltimo = Convert.ToInt32(lastSelectedRow.Cells[0].Value);
            selectedRows.Add(idSubProdTipCredUltimo);
            foreach (DataGridViewRow row in dtgTipCredSubProd.SelectedRows)
            {
                int idSubProdTipCred = Convert.ToInt32(row.Cells[0].Value);
                if (idSubProdTipCredUltimo != idSubProdTipCred)
                { 
                    selectedRows.Add(idSubProdTipCred);
                }
            }
            if (selectedRows.Count() > 1)
            {
                var configu1 = _configuracion.FirstOrDefault(x => x.idSubProducto == Convert.ToInt32(selectedRows[0]));
                var configu2 = _configuracion.FirstOrDefault(x => x.idSubProducto == Convert.ToInt32(selectedRows[1]));
                if (configu1 == null && configu2 == null)
                {
                    return true;
                }
                if (configu1 == null && configu2 != null)
                {
                    return false;
                }
                if (configu1 != null && configu2 == null)
                {
                    return false;
                }
                return configu1.Equals(configu2);

            }
            return false;

        }

        private void dtgMonto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            this.obtenerTipoPersonaSeleccionado();
            this.obtenerTipoOperacionSeleccionado();
            this.obtenerDestinoCreditoSeleccionado();
        }

        private void dtgTipCredSubProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && (e.KeyCode == Keys.Down ||e.KeyCode == Keys.Up))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void dtgMonto_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void dtgMonto_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dtgTipCredSubProd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.dtgTipCredSubProd.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void dtgTipoPersona_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.dtgTipoPersona.CommitEdit(DataGridViewDataErrorContexts.Commit); 
        }
        private void dtgTipoOperacion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.dtgTipoOperacion.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void dtgTipCredSubProd_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtgTipCredSubProd.DataSource != null)
            {
                if (e.RowIndex == -1) return;
                if (dtgTipCredSubProd.ReadOnly) return;

                if ((e.ColumnIndex == dtgTipCredSubProd.Columns["dataGridViewCheckBoxColumn7"].Index && e.RowIndex != -1)
                    || (e.ColumnIndex == dtgTipCredSubProd.Columns["dataGridViewCheckBoxColumn8"].Index && e.RowIndex != -1))
                {
                    ActualizaTipCredSubProd(e.ColumnIndex, e.RowIndex);

                    dtgTipCredSubProd.EndEdit(); 
                }
            }
        }

        private void dtgTipoPersona_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtgTipoPersona.DataSource != null)
            {
                if (e.RowIndex == -1) return;
                if (dtgTipoPersona.ReadOnly) return;
                if ((e.ColumnIndex == dtgTipoPersona.Columns["lVisibleDataGridViewCheckBoxColumn1"].Index && e.RowIndex != -1)
                     || (e.ColumnIndex == dtgTipoPersona.Columns["lObligatorioDataGridViewCheckBoxColumn1"].Index && e.RowIndex != -1))
                {
                    ActualizaTipoPersona(e.ColumnIndex, e.RowIndex);
                    dtgTipoPersona.EndEdit();
                }
            }
        }



        private void dtgTipoOperacion_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtgTipoOperacion.DataSource != null)
            {
                if (e.RowIndex == -1) return;
                if (dtgTipoOperacion.ReadOnly) return;
                if ((e.ColumnIndex == dtgTipoOperacion.Columns["lVisibleDataGridViewCheckBoxColumn3"].Index && e.RowIndex != -1)
                    || (e.ColumnIndex == dtgTipoOperacion.Columns["lObligatorioDataGridViewCheckBoxColumn3"].Index && e.RowIndex != -1))
                {
                    ActualizaTipoOperacion(e.ColumnIndex, e.RowIndex);
                    dtgTipoOperacion.EndEdit();
                }
            } 
        }
        private void dtgDestinoCredito_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtgDestinoCredito.DataSource != null)
            {
                if (e.RowIndex == -1) return;
                if (dtgDestinoCredito.ReadOnly) return;
                if ((e.ColumnIndex == dtgDestinoCredito.Columns["lObligatorio"].Index && e.RowIndex != -1)
                    || (e.ColumnIndex == dtgDestinoCredito.Columns["lVisibleDataGridViewCheckBoxColumn2"].Index && e.RowIndex != -1))
                {
                    ActualizaDestino(e.ColumnIndex, e.RowIndex);
                    dtgDestinoCredito.EndEdit();
                }
            }
        }
        private void dtgMonto_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtgMonto.DataSource != null)
            {
                if (e.RowIndex == -1) return;
                if (dtgMonto.ReadOnly) return;
                if ((e.ColumnIndex == dtgMonto.Columns["dtgColumnVisibleMonto"].Index && e.RowIndex != -1)
                    || (e.ColumnIndex == dtgMonto.Columns["dtgColumnObligatorioMonto"].Index && e.RowIndex != -1))
                {
                    ActualizaMonto(e.ColumnIndex, e.RowIndex);
                    dtgMonto.EndEdit();
                }
            }
        }
        private void ActualizaTipCredSubProd(int ColumnIndex, int RowIndex)
        {
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dtgTipCredSubProd.Rows[RowIndex].Cells[ColumnIndex];
            var datasel = (clsConfiguracionDocumento)dtgTipCredSubProd.CurrentRow.DataBoundItem;
            bool lEstadoSel = (chk.Value == null || (bool)chk.Value == false) ? false : true;
            string cMensaje = string.Empty;
            if (datasel.actualizar(ColumnIndex, lEstadoSel, ref cMensaje))
            {
                if (!string.IsNullOrEmpty(cMensaje))
                {
                    MessageBox.Show(cMensaje, this.titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                dtgTipCredSubProd.RefreshEdit();
                dtgTipCredSubProd.Refresh();
                return;
            }

            // GridReadOnlyCell(dtgTipoPersona, e.ColumnIndex, !datasel.lVisible, !datasel.lObligatorio);
            this.generarConfigurarion(datasel);

            this.CargarTipoPersonaConfiguracionArchivos(ColumnIndex);
            this.CargarTipoOperacionConfiguracionArchivos(ColumnIndex);
            this.CargarDestinoCreditoConfiguracionArchivos(ColumnIndex);
            this.CargarRangoMontoConfiguracionArchivos(ColumnIndex);
            this.dtgTipCredSubProd.RefreshEdit();
            this.dtgTipCredSubProd.Refresh();
        }
        private void ActualizaTipoPersona(int ColumnIndex, int RowIndex)
        {
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dtgTipoPersona.Rows[RowIndex].Cells[ColumnIndex];
            var dataselTipPersona = (clsConfiguracionDocumento)dtgTipoPersona.CurrentRow.DataBoundItem;
            var dataselTipCredSubProd = (clsConfiguracionDocumento)dtgTipCredSubProd.CurrentRow.DataBoundItem;
            bool lEstadoSel = (chk.Value == null || (bool)chk.Value == false) ? false : true;
            string cMensaje = string.Empty;
            if (dataselTipPersona.actualizar(ColumnIndex, lEstadoSel, dataselTipCredSubProd.lVisible, dataselTipCredSubProd.lObligatorio, ref cMensaje))
            {
                if (!String.IsNullOrEmpty(cMensaje))
                {
                    MessageBox.Show(cMensaje, this.titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.dtgTipoPersona.RefreshEdit();
                this.dtgTipoPersona.Refresh();
                return;
            }

            _TipoPersonaSel = new List<clsConfigTipoPersona>();
            List<int> IdsSubProducto = seleccionSubProducto();
            if (_configuracion.Where(c => IdsSubProducto.Contains(c.idSubProducto)).Count() <= 0)
            {
                dataselTipPersona.lVisible = false;
                dataselTipPersona.lObligatorio = false;
                this.CargarTipoOperacionConfiguracionArchivos();
                this.CargarDestinoCreditoConfiguracionArchivos();
                this.CargarRangoMontoConfiguracionArchivos();

                dtgTipoPersona.RefreshEdit();
                dtgTipoPersona.Refresh();
                return;
            }

            foreach (var _itemConfiguracion in _configuracion.Where(c => IdsSubProducto.Contains(c.idSubProducto)))
            {
                if (_itemConfiguracion.lVisible == false)
                {
                    dataselTipPersona.lVisible = false;
                    dataselTipPersona.lObligatorio = false;
                    this.CargarTipoOperacionConfiguracionArchivos();
                    this.CargarDestinoCreditoConfiguracionArchivos();
                    this.CargarRangoMontoConfiguracionArchivos();

                    dtgTipoPersona.RefreshEdit();
                    dtgTipoPersona.Refresh();
                    return;
                }
                var _SetTipoPersona = _itemConfiguracion.detalleTipoPersona.FirstOrDefault(x => x.idTipoPersona == dataselTipPersona.id);
                _SetTipoPersona.lObligatorio = lEstadoSel;
                _SetTipoPersona.lVisible = ColumnIndex == 2 ? lEstadoSel : _SetTipoPersona.lVisible;

                foreach (var item in _SetTipoPersona.detalleTipoOperacion)
                {
                    item.lObligatorio = lEstadoSel;
                    item.lVisible = ColumnIndex == 2 ? lEstadoSel : (ColumnIndex == 4 && lEstadoSel ? lEstadoSel : item.lVisible);

                    foreach (var itemDC in item.detalleDestinoCredito)
                    {
                        itemDC.lObligatorio = lEstadoSel;
                        itemDC.lVisible = ColumnIndex == 2 ? lEstadoSel : (ColumnIndex == 4 && lEstadoSel ? lEstadoSel : itemDC.lVisible);

                        foreach (var itemRM in itemDC.detalleRangoMonto)
                        {
                            itemRM.lObligatorio = lEstadoSel;
                            itemRM.lVisible = ColumnIndex == 2 ? lEstadoSel : (ColumnIndex == 4 && lEstadoSel ? lEstadoSel : itemRM.lVisible);

                        }
                    }
                }
                _TipoPersonaSel.Add(_SetTipoPersona);
                _itemConfiguracion.validarVisibilidadObligatoriedad();
                dataselTipCredSubProd.lObligatorio = _itemConfiguracion.lObligatorio;
                dataselTipCredSubProd.lVisible = _itemConfiguracion.lVisible;

            }

            this.CargarTipoOperacionConfiguracionArchivos(ColumnIndex);
            this.CargarDestinoCreditoConfiguracionArchivos(ColumnIndex);
            this.CargarRangoMontoConfiguracionArchivos(ColumnIndex);
            dtgTipCredSubProd.RefreshEdit();
            dtgTipCredSubProd.Refresh();
            dtgTipoPersona.RefreshEdit();
            dtgTipoPersona.Refresh();

        }
        private void ActualizaTipoOperacion(int ColumnIndex, int RowIndex)
        {
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dtgTipoOperacion.Rows[RowIndex].Cells[ColumnIndex];
            bool lEstadoSel = (chk.Value == null || (bool)chk.Value == false) ? false : true;
            var dataselTipOpe = (clsConfiguracionDocumento)dtgTipoOperacion.CurrentRow.DataBoundItem;
            var dataselTipoPersona = (clsConfiguracionDocumento)dtgTipoPersona.CurrentRow.DataBoundItem;

            string cMensaje = string.Empty;
            if (dataselTipOpe.actualizar(ColumnIndex, lEstadoSel, dataselTipoPersona.lVisible, dataselTipoPersona.lObligatorio, ref cMensaje))
            {
                if (!String.IsNullOrEmpty(cMensaje))
                {
                    MessageBox.Show(cMensaje, this.titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.dtgTipoOperacion.RefreshEdit();
                this.dtgTipoOperacion.Refresh();
                return;
            }


            if (_TipoOperacionSel.Count() <= 0)
            {
                dataselTipOpe.lVisible = false;
                dataselTipOpe.lObligatorio = false;
                this.CargarDestinoCreditoConfiguracionArchivos();
                this.CargarRangoMontoConfiguracionArchivos();
                this.dtgTipoOperacion.RefreshEdit();
                this.dtgTipoOperacion.Refresh();
                return;
            }
            foreach (var _itemTipoPersonaSel in _TipoPersonaSel)
            {
                if (_itemTipoPersonaSel.lVisible == false)
                {
                    dataselTipOpe.lVisible = false;
                    dataselTipOpe.lObligatorio = false;
                    this.CargarDestinoCreditoConfiguracionArchivos();
                    this.CargarRangoMontoConfiguracionArchivos();
                    this.dtgTipoOperacion.RefreshEdit();
                    this.dtgTipoOperacion.Refresh();
                    return;
                }

                var _TipOpeSel = _itemTipoPersonaSel.detalleTipoOperacion.FirstOrDefault(x => x.idTipoOperacion == dataselTipOpe.id);
                _TipOpeSel.lObligatorio = lEstadoSel;
                _TipOpeSel.lVisible = ColumnIndex == 2 ? lEstadoSel : _TipOpeSel.lVisible;

                foreach (var itemDC in _TipOpeSel.detalleDestinoCredito)
                {
                    itemDC.lObligatorio = lEstadoSel;
                    itemDC.lVisible = ColumnIndex == 2 ? lEstadoSel : (ColumnIndex == 4 && lEstadoSel ? lEstadoSel : itemDC.lVisible);

                    foreach (var itemRM in itemDC.detalleRangoMonto)
                    {
                        itemRM.lObligatorio = lEstadoSel; 
                        itemRM.lVisible = ColumnIndex == 2 ? lEstadoSel : (ColumnIndex == 4 && lEstadoSel ? lEstadoSel : itemRM.lVisible);

                    }
                }

                _TipoOperacionSel.Add(_TipOpeSel);

                _itemTipoPersonaSel.validarVisibilidadObligatoriedad();

                dataselTipoPersona.lObligatorio = _itemTipoPersonaSel.lObligatorio;
                dataselTipoPersona.lVisible = _itemTipoPersonaSel.lVisible;
            }

            foreach (var item in _configuracion)
            {
                item.validarVisibilidadObligatoriedad();
                foreach (DataGridViewRow row in this.dtgTipCredSubProd.SelectedRows)
                {
                    var dataselTipCredSubProd = (clsConfiguracionDocumento)row.DataBoundItem;
                    if (item.idSubProducto == dataselTipCredSubProd.id)
                    {
                        dataselTipCredSubProd.lObligatorio = item.lObligatorio;
                        dataselTipCredSubProd.lVisible = item.lVisible;
                    }
                }
            }
            this.CargarDestinoCreditoConfiguracionArchivos(ColumnIndex);
            this.CargarRangoMontoConfiguracionArchivos(ColumnIndex);
            this.dtgTipCredSubProd.Refresh();
            this.dtgTipCredSubProd.RefreshEdit();
            this.dtgTipoPersona.RefreshEdit();
            this.dtgTipoPersona.Refresh();
            this.dtgTipoOperacion.RefreshEdit();
            this.dtgTipoOperacion.Refresh();
        }
        private void ActualizaDestino(int ColumnIndex, int RowIndex)
        {
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dtgDestinoCredito.Rows[RowIndex].Cells[ColumnIndex];
            bool lEstadoSel = (chk.Value == null || (bool)chk.Value == false) ? false : true;
            var dataselDesCred = (clsConfiguracionDocumento)dtgDestinoCredito.CurrentRow.DataBoundItem;
            var dataselTipOpe = (clsConfiguracionDocumento)dtgTipoOperacion.CurrentRow.DataBoundItem;

            string cMensaje = string.Empty;
            if (dataselDesCred.actualizar(ColumnIndex, lEstadoSel, dataselTipOpe.lVisible, dataselTipOpe.lObligatorio, ref cMensaje))
            {
                if (!String.IsNullOrEmpty(cMensaje))
                {
                    MessageBox.Show(cMensaje, this.titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.dtgTipoOperacion.RefreshEdit();
                this.dtgTipoOperacion.Refresh();
                return;
            }


            if (_TipoOperacionSel.Count() <= 0)
            {
                dataselDesCred.lVisible = false;
                dataselDesCred.lObligatorio = false;
                this.CargarRangoMontoConfiguracionArchivos();
                dtgDestinoCredito.RefreshEdit();
                dtgDestinoCredito.Refresh();
                return;
            }
            foreach (var _itemTipoOperacion in _TipoOperacionSel)
            {
                if (_itemTipoOperacion.lVisible == false)
                {
                    dataselDesCred.lVisible = false;
                    dataselDesCred.lObligatorio = false;
                    this.CargarRangoMontoConfiguracionArchivos();
                    dtgDestinoCredito.RefreshEdit();
                    dtgDestinoCredito.Refresh();
                    return;
                }


                var _DesCredSel = _itemTipoOperacion.detalleDestinoCredito.FirstOrDefault(x => x.idDestinoCredito == dataselDesCred.id);
                _DesCredSel.lObligatorio = lEstadoSel;
                _DesCredSel.lVisible = ColumnIndex == 2 ? lEstadoSel : _DesCredSel.lVisible;
                foreach (var itemRM in _DesCredSel.detalleRangoMonto)
                {
                    itemRM.lObligatorio = lEstadoSel;
                    itemRM.lVisible = ColumnIndex == 2 ? lEstadoSel : (ColumnIndex == 4 && lEstadoSel ? lEstadoSel : itemRM.lVisible);

                }
                _DesCreditoSel.Add(_DesCredSel);

                _itemTipoOperacion.validarVisibilidadObligatoriedad();
                dataselTipOpe.lObligatorio = _itemTipoOperacion.lObligatorio;
                dataselTipOpe.lVisible = _itemTipoOperacion.lVisible;
            }
            foreach (var item in _TipoPersonaSel)
            {
                item.validarVisibilidadObligatoriedad();
                var dataselTipPer = (clsConfiguracionDocumento)dtgTipoPersona.CurrentRow.DataBoundItem;
                dataselTipPer.lObligatorio = item.lObligatorio;
                dataselTipPer.lVisible = item.lVisible;
            }
            foreach (var item in _configuracion)
            {
                item.validarVisibilidadObligatoriedad();
                foreach (DataGridViewRow row in this.dtgTipCredSubProd.SelectedRows)
                {
                    var dataselTipCredSubProd = (clsConfiguracionDocumento)row.DataBoundItem;
                    if (item.idSubProducto == dataselTipCredSubProd.id)
                    {
                        dataselTipCredSubProd.lObligatorio = item.lObligatorio;
                        dataselTipCredSubProd.lVisible = item.lVisible;
                    }
                }
            }

            this.CargarRangoMontoConfiguracionArchivos(ColumnIndex);
            dtgTipCredSubProd.Refresh();
            dtgTipCredSubProd.RefreshEdit();
            dtgTipoPersona.Refresh();
            dtgTipoPersona.RefreshEdit();
            dtgTipoOperacion.RefreshEdit();
            dtgTipoOperacion.Refresh();
            dtgDestinoCredito.RefreshEdit();
            dtgDestinoCredito.Refresh();
        }
        private void ActualizaMonto(int ColumnIndex, int RowIndex)
        {
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dtgMonto.Rows[RowIndex].Cells[ColumnIndex];
            bool lEstadoSel = (chk.Value == null || (bool)chk.Value == false) ? false : true;
            var dataselMonto = (clsConfigDocxMonto)dtgMonto.CurrentRow.DataBoundItem;

            var dataselDesCred = (clsConfiguracionDocumento)dtgDestinoCredito.CurrentRow.DataBoundItem;

            string cMensaje = string.Empty;
            if (dataselMonto.actualizar(ColumnIndex, lEstadoSel, dataselDesCred.lVisible, dataselDesCred.lObligatorio, ref cMensaje))
            {
                if (!String.IsNullOrEmpty(cMensaje))
                {
                    MessageBox.Show(cMensaje, this.titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.dtgMonto.RefreshEdit();
                this.dtgMonto.Refresh();
                return;
            }



            if (_DesCreditoSel.Count() <= 0)
            {
                dataselMonto.lVisible = false;
                dataselMonto.lObligatorio = false;
                dtgMonto.RefreshEdit();
                dtgMonto.Refresh();
                return;
            }

            foreach (var itemDesCred in _DesCreditoSel)
            {
                itemDesCred.detalleRangoMonto.FirstOrDefault(x => x.idRangoMonto == dataselMonto.id).lObligatorio = lEstadoSel;
                itemDesCred.detalleRangoMonto.FirstOrDefault(x => x.idRangoMonto == dataselMonto.id).lVisible = ColumnIndex == 2 ? lEstadoSel : itemDesCred.detalleRangoMonto.FirstOrDefault(x => x.idRangoMonto == dataselMonto.id).lVisible;
                itemDesCred.validarVisibilidadObligatoriedad();
                dataselDesCred.lObligatorio = itemDesCred.lObligatorio;
                dataselDesCred.lVisible = itemDesCred.lVisible;
            }
            foreach (var item in _TipoOperacionSel)
            {
                item.validarVisibilidadObligatoriedad();
                var dataselTipOpe = (clsConfiguracionDocumento)dtgTipoOperacion.CurrentRow.DataBoundItem;
                dataselTipOpe.lObligatorio = item.lObligatorio;
                dataselTipOpe.lVisible = item.lVisible;
            }
            foreach (var item in _TipoPersonaSel)
            {
                item.validarVisibilidadObligatoriedad();
                var dataselTipPer = (clsConfiguracionDocumento)dtgTipoPersona.CurrentRow.DataBoundItem;
                dataselTipPer.lObligatorio = item.lObligatorio;
                dataselTipPer.lVisible = item.lVisible;
            }

            foreach (var item in _configuracion)
            {
                item.validarVisibilidadObligatoriedad();
                foreach (DataGridViewRow row in this.dtgTipCredSubProd.SelectedRows)
                {
                    var dataselTipCredSubProd = (clsConfiguracionDocumento)row.DataBoundItem;
                    if (item.idSubProducto == dataselTipCredSubProd.id)
                    {
                        dataselTipCredSubProd.lObligatorio = item.lObligatorio;
                        dataselTipCredSubProd.lVisible = item.lVisible;
                    }
                }
            }

            dtgTipCredSubProd.Refresh();
            dtgTipCredSubProd.RefreshEdit();
            dtgTipoPersona.Refresh();
            dtgTipoPersona.RefreshEdit();
            dtgTipoOperacion.Refresh();
            dtgTipoOperacion.RefreshEdit();
            dtgDestinoCredito.Refresh();
            dtgDestinoCredito.RefreshEdit();
            dtgMonto.RefreshEdit();
            dtgMonto.Refresh(); 
        }

    }
}
