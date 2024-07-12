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
using EntityLayer;
using CRE.CapaNegocio;
using GEN.CapaNegocio;
using System.Threading;
using GEN.Funciones;

namespace CRE.Presentacion
{
    public partial class frmReglasGrupo : frmBase
    {
        #region Variables Globales
        string cTitulo = "Validacion de Reglas Dinámicas - Grupo Solidario";
        public bool lEstado = false;
        CRE.CapaNegocio.clsCNGrupoSolidario objCNGrupoSolidario = new CRE.CapaNegocio.clsCNGrupoSolidario();
        clsCNValidaReglasDinamicas cnregladinamica = new clsCNValidaReglasDinamicas();
        
        clsSolicitudCredGrupoSol oSolicitudCredGrupoSol;
        List<clsSolCredGSIntegrante> olstSolCredGSIntegrante;

        private string cFormularioPadre;
        //private int idGrupoSolidario;

        private string cFechaActual = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
        private int idAgencia = clsVarGlobal.nIdAgencia;
        private int idUsuario = clsVarGlobal.User.idUsuario;
        private int idPaso;

        #endregion
        public frmReglasGrupo(int idPaso, string cNombreFormulario, clsSolicitudCredGrupoSol oSolicitudCredGrupoSol, List<clsSolCredGSIntegrante> olstSolCredGSIntegrante)
        {
            InitializeComponent();
            this.Text = cTitulo;
            this.cFormularioPadre = cNombreFormulario;
            this.oSolicitudCredGrupoSol = oSolicitudCredGrupoSol;
            this.olstSolCredGSIntegrante = olstSolCredGSIntegrante;
            this.idPaso = idPaso;
            cargarInformacionSolicitud();
            cargarInformacionGrupo();
        }
        #region Metodos
        private void cargarInformacionGrupo()
        {
            bindingGrupo.DataSource = this.oSolicitudCredGrupoSol;
            dtgGrupo.DataSource = bindingGrupo;

            DataGridViewImageColumn dtgcReglas = new DataGridViewImageColumn();
            dtgcReglas.Name = "imgReglas";
            dtgcReglas.ValuesAreIcons = true;
            dtgGrupo.Columns.Add(dtgcReglas);

            formatearGridGrupo();
        }
        private void cargarInformacionSolicitud()
        {
            bindingSolicitudes.DataSource = this.olstSolCredGSIntegrante;
            dtgSolicitudes.DataSource = bindingSolicitudes;

            DataGridViewImageColumn dtgcReglas = new DataGridViewImageColumn();
            dtgcReglas.Name = "imgReglas";
            dtgcReglas.ValuesAreIcons = true;
            dtgSolicitudes.Columns.Add(dtgcReglas); 

            formatearGridSolicitud();
        }
        private void formatearGridGrupo()
        {
            foreach (DataGridViewColumn column in this.dtgGrupo.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dtgGrupo.Columns["idSolicitudCredGrupoSol"].DisplayIndex = 0;
            dtgGrupo.Columns["cNombreGrupo"].DisplayIndex = 1;
            dtgGrupo.Columns["imgReglas"].DisplayIndex = 2;
            dtgGrupo.Columns["cProcesado"].DisplayIndex = 3;

            dtgGrupo.Columns["idSolicitudCredGrupoSol"].Visible = true;
            dtgGrupo.Columns["cNombreGrupo"].Visible = true;
            dtgGrupo.Columns["imgReglas"].Visible = true;
            dtgGrupo.Columns["cProcesado"].Visible = true;

            dtgGrupo.Columns["idSolicitudCredGrupoSol"].HeaderText = "Cód. Grupo";
            dtgGrupo.Columns["cNombreGrupo"].HeaderText = "Nombre del Grupo";
            dtgGrupo.Columns["imgReglas"].HeaderText = "Reglas";
            dtgGrupo.Columns["cProcesado"].HeaderText = "Procesado";

            dtgGrupo.Columns["idSolicitudCredGrupoSol"].FillWeight = 30;
            dtgGrupo.Columns["cNombreGrupo"].FillWeight = 140;
            dtgGrupo.Columns["imgReglas"].FillWeight = 15;
            dtgGrupo.Columns["cProcesado"].FillWeight = 25;

            dtgGrupo.FirstDisplayedCell = null;
            dtgGrupo.ClearSelection();
        }
        private void formatearGridSolicitud()
        {
            foreach (DataGridViewColumn column in this.dtgSolicitudes.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgSolicitudes.Columns["idSolicitud"].DisplayIndex = 0;
            dtgSolicitudes.Columns["cNombreCompleto"].DisplayIndex = 1;
            dtgSolicitudes.Columns["imgReglas"].DisplayIndex = 2;
            dtgSolicitudes.Columns["nExcepciones"].DisplayIndex = 3;
            dtgSolicitudes.Columns["cProcesado"].DisplayIndex = 4;

            dtgSolicitudes.Columns["idSolicitud"].Visible = true;
            dtgSolicitudes.Columns["cNombreCompleto"].Visible = true;
            dtgSolicitudes.Columns["imgReglas"].Visible = true;
            dtgSolicitudes.Columns["nExcepciones"].Visible = true;
            dtgSolicitudes.Columns["cProcesado"].Visible = true;

            dtgSolicitudes.Columns["idSolicitud"].HeaderText = "Cód. Solicitud";
            dtgSolicitudes.Columns["cNombreCompleto"].HeaderText = "Nombre";
            dtgSolicitudes.Columns["imgReglas"].HeaderText = "Reglas";
            dtgSolicitudes.Columns["nExcepciones"].HeaderText = "Excepciones";
            dtgSolicitudes.Columns["cProcesado"].HeaderText = "Procesado";

            dtgSolicitudes.Columns["idSolicitud"].FillWeight = 30;
            dtgSolicitudes.Columns["cNombreCompleto"].FillWeight = 125;
            dtgSolicitudes.Columns["imgReglas"].FillWeight = 15;
            dtgSolicitudes.Columns["nExcepciones"].FillWeight = 25;
            dtgSolicitudes.Columns["cProcesado"].FillWeight = 25;
        }

        private void verExcepcionesIndividuales()
        {
            clsSolCredGSIntegrante oCeldaActual = (clsSolCredGSIntegrante)dtgSolicitudes.CurrentRow.DataBoundItem;
            int nIdSolicitud = oCeldaActual.idSolicitud;
            int nIdAgencia = idAgencia;
            int nIdCliente = oCeldaActual.idCli;
            int nIdMoneda = oSolicitudCredGrupoSol.idMoneda;
            int nIdProducto = oSolicitudCredGrupoSol.idProducto;
            decimal nValAproba = oCeldaActual.nMonto;
            int nIdUsuRegist = idUsuario;
            String cOpcion = cFormularioPadre;
            frmExcepciones excepciones = new frmExcepciones(nIdSolicitud, nIdAgencia, nIdCliente, nIdMoneda, nIdProducto, nValAproba, nIdUsuRegist, cOpcion);
            excepciones.ShowDialog();
        }
        private void verificarReglasSolicitudes()
        {
            string cCumpleReglas = String.Empty;
            int c = 0;
            foreach (var item in olstSolCredGSIntegrante)
            {
                DataTable dtnExcepcionesManuales = cnregladinamica.obtenerCantidadExcepcionesManuales(item.idSolicitud, cFormularioPadre);
                
                dtgSolicitudes.Rows[c].Selected = true;
                c++;
                int nContExcepNocumplidas = Convert.ToInt32(dtnExcepcionesManuales.Rows[0]["nCantidad"]);

                DataTable dtParametros = ArmarTablaParametros(item);
                int idCliente = item.idCli;
                int idEstadoOperac = 1;
                int idMoneda = oSolicitudCredGrupoSol.idMoneda;
                int idProducto = oSolicitudCredGrupoSol.idProducto;
                Decimal nValAproba = item.nMonto;
                int idDocument = item.idSolicitud;                    //Documento de Transacción (Nro Kardex, Nro de solicitud, etc)
                DateTime dFecSolici = clsVarGlobal.dFecSystem;
                int idMotivo = 2;                                      //Motivo:                                                                                                                                                                                                                                                                                          
                int idEstadoSol = item.idEstadoSol;
                int idUsuRegis = clsVarGlobal.User.idUsuario;
                int idSolApr = 0;
                bool lMostrarAlerta = true;

                cCumpleReglas = vertificarIntegrante(dtParametros, cFormularioPadre, idAgencia, idCliente, idEstadoOperac,
                                    idMoneda, idProducto, nValAproba, idDocument, dFecSolici,
                                    idMotivo, idEstadoSol, idUsuRegis, ref idSolApr, lMostrarAlerta);

                dtnExcepcionesManuales = cnregladinamica.obtenerCantidadExcepcionesManuales(item.idSolicitud, cFormularioPadre);
                nContExcepNocumplidas = Convert.ToInt32(dtnExcepcionesManuales.Rows[0]["nCantidad"]);

                if (cCumpleReglas == "Cumple")
                {
                    olstSolCredGSIntegrante.Where(w => w.idCli == item.idCli).ToList().ForEach(s => { s.lReglas = true; s.cProcesado = "Procesado"; s.nExcepciones = nContExcepNocumplidas; });
                    dtgSolicitudes.Refresh();
                }
                else if (cCumpleReglas == "NoCumpleSoloExcp")
                {

                    olstSolCredGSIntegrante.Where(w => w.idCli == item.idCli).ToList().ForEach(s => { s.lReglas = true; s.cProcesado = "Procesado"; s.nExcepciones = nContExcepNocumplidas; });
                    dtgSolicitudes.Refresh();
                }
                else if(cCumpleReglas == "NoCumple")
                {
                    olstSolCredGSIntegrante.Where(w => w.idCli == item.idCli).ToList().ForEach(s => { s.lReglas = false; s.cProcesado = "Procesado"; s.nExcepciones = nContExcepNocumplidas; });
                    dtgSolicitudes.Refresh();
                }
                /**Iconos**/
                if (item.lReglas)
                {
                    refrescarIcono(dtgSolicitudes, true, olstSolCredGSIntegrante.IndexOf(item));
                }
                else
                {
                    refrescarIcono(dtgSolicitudes, false, olstSolCredGSIntegrante.IndexOf(item));
                }
           }

        }
        private void verificarReglasGrupo()
        {
            string cMensajeAlerta = string.Empty;
            bool lNoCumpleITF = false;
            bool lNoCumpleCantidadIntegrantes = false;
            bool lNoCumpleTipoUrbano = false;
            bool lNoCumpleTipoRural = false;
            bool lNoCumpleClasificacion = false;
            bool lNoCumpleCantidadExcepcion = false;

            DataTable dtVariablesReglasGrupo = objCNGrupoSolidario.obtenerVariablesGrupoSolidario();
            

            int nMinimoGrupoSolidariio = 0;
            int nMaximoGrupoSolidariio = 0;
            string cProductosGrupoSolidario = string.Empty;
            List<int> listnProductoGrupoSolidario = new List<int>();

            for (int i = 0; i < dtVariablesReglasGrupo.Rows.Count; i++)
            {
                if (dtVariablesReglasGrupo.Rows[i]["cVariable"].ToString() == "nMinimoGrupoSolidariio")
                {
                    nMinimoGrupoSolidariio = Convert.ToInt16(dtVariablesReglasGrupo.Rows[i]["cValVar"].ToString());
                }
                if (dtVariablesReglasGrupo.Rows[i]["cVariable"].ToString() == "nMaximoGrupoSolidariio")
                {
                    nMaximoGrupoSolidariio = Convert.ToInt16(dtVariablesReglasGrupo.Rows[i]["cValVar"].ToString());
                }
                if (dtVariablesReglasGrupo.Rows[i]["cVariable"].ToString() == "cProductosGrupoSolidario")
                {
                    cProductosGrupoSolidario = dtVariablesReglasGrupo.Rows[i]["cValVar"].ToString();
                }
            }
            listnProductoGrupoSolidario = cProductosGrupoSolidario.Split(',').Select(Int32.Parse).ToList();

            //1.SOLICITUD + EVALUACION Y GRUPO SOLIDARIO
            if (idPaso == 2 || idPaso == 3 || listnProductoGrupoSolidario.Contains(oSolicitudCredGrupoSol.idProducto))//2 Solicitud, 3 Evaluacion
            {//1.1ITF PARA GRUPO SOLIDARIO
                decimal nTtotal = olstSolCredGSIntegrante.Sum(item => item.nMonto);
                decimal nITF = objCNGrupoSolidario.obtenerITF();
                int idGrupoSol = oSolicitudCredGrupoSol.idGrupoSolidario;
                DataTable dtResultado = objCNGrupoSolidario.CNConsultaUits(idGrupoSol);
                //int nTipoGrupoSol = Convert.ToInt32(dtResultado.Rows[0]["idTipoGrupoSolidario"]);
                int nUits = Convert.ToInt32(dtResultado.Rows[0]["nUit"]);
                
                if (nTtotal > nITF*nUits)
                {
                    lNoCumpleITF = true;
                    cMensajeAlerta = cMensajeAlerta + "• El monto solicitado para créditos grupales no puede superar un máximo de UITs de acuerdo al tipo de grupo." + Environment.NewLine;
                   // MessageBox.Show("Se encontraron reglas no excepcionables:" + Environment.NewLine + cMensajeAlerta + Environment.NewLine, "Reglas Generadas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    lNoCumpleITF = false;
                }
            //1.2 URBANO Y RURAL //solo para estacional
                if (oSolicitudCredGrupoSol.idModalidadCredito == 3)
                {
                    if (oSolicitudCredGrupoSol.idGrupoSolidarioTipo == 1)
                    {
                        if (oSolicitudCredGrupoSol.idTipoPeriodo == 2 && oSolicitudCredGrupoSol.nPlazoCuota / 30 >= 1 && oSolicitudCredGrupoSol.nPlazoCuota / 30 <= 4)//urbanoy periodo fijo
                        {
                            lNoCumpleTipoUrbano = false;
                        }
                        else if (oSolicitudCredGrupoSol.idTipoPeriodo == 1)
                        {
                            lNoCumpleTipoUrbano = false;
                        }
                        else
                        {
                            lNoCumpleTipoUrbano = true;
                            cMensajeAlerta = cMensajeAlerta + "• Para créditos grupales de tipo [Urbano] solo son permisibles los créditos mensual, bimensual, trimensual y cuatrimensual." + Environment.NewLine;
                        }
                    }
                    else
                    {
                        if (oSolicitudCredGrupoSol.idTipoPeriodo == 2 && oSolicitudCredGrupoSol.nPlazoCuota / 30 >= 1 && oSolicitudCredGrupoSol.nPlazoCuota / 30 <= 4)
                        {
                            lNoCumpleTipoRural = false;
                        }
                        else if (oSolicitudCredGrupoSol.idTipoPeriodo == 1)
                        {
                            lNoCumpleTipoRural = false;
                        }
                        else
                        {
                            lNoCumpleTipoRural = true;
                            cMensajeAlerta = cMensajeAlerta + "• Para créditos grupales de tipo [Rural] solo son permisibles los créditos mensual, bimensual, trimensual y cuatrimensual." + Environment.NewLine;
                        }
                    }
                }
            }
            
            bool lResultado = olstSolCredGSIntegrante.Exists(x => x.lReglas == false);

            if (lResultado == true)
            {
                cMensajeAlerta = cMensajeAlerta + "• Existen reglas sin detallar el sustento o reglas no excepcionables." + Environment.NewLine;
            }

            DataTable dtExcep = objCNGrupoSolidario.consultaNroExcep(oSolicitudCredGrupoSol.idSolicitudCredGrupoSol);
            //int nExcep= Convert.ToInt32(dtExcep.Rows[0]["nroExcep"]);
            if (Convert.ToInt32(dtExcep.Rows[0]["nroExcep"])==0)
            {
                lNoCumpleCantidadExcepcion = true;
                cMensajeAlerta = cMensajeAlerta + Convert.ToString(dtExcep.Rows[0]["cMensaje"]) + Environment.NewLine;
            }
            else
            {
                lNoCumpleCantidadExcepcion = false;
            }

            if (lResultado || lNoCumpleITF || lNoCumpleCantidadIntegrantes || lNoCumpleClasificacion || lNoCumpleCantidadExcepcion || lNoCumpleTipoUrbano || lNoCumpleTipoRural )
            {
                refrescarIcono(dtgGrupo, false, 0);//error
                lEstado = false;
                MessageBox.Show("Se encontraron reglas:" + Environment.NewLine + cMensajeAlerta, "Reglas Generadas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                refrescarIcono(dtgGrupo, true, 0);//ok
                lEstado = true;
            }
            oSolicitudCredGrupoSol.cProcesado = "Procesado";
            dtgGrupo.Refresh();
        }
        private string vertificarIntegrante(DataTable dtParametros    , string cNombreFormulario  , int idAgencia           , int idCliente     , int idEstadoOperac,
                                                int idMoneda            , int idProducto            , Decimal nValAproba    , int idDocument    , DateTime dFecSolici,
                                                int idMotivo            , int idEstadoSol           , int idUsuRegis        , ref int idSolApr  , bool lMostrarAlerta)
        {
            string cCumpleReglas = String.Empty;
            cCumpleReglas = cnregladinamica.ValidarReglasCreditos(dtParametros  , cNombreFormulario , idAgencia     , idCliente     , idEstadoOperac    ,
                                                                   idMoneda     , idProducto        , nValAproba    , idDocument    , dFecSolici        ,
                                                                   idMotivo, idEstadoSol            , idUsuRegis    , ref idSolApr, lMostrarAlerta);
            return cCumpleReglas;
        }
        private DataTable ArmarTablaParametros(clsSolCredGSIntegrante item)
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");
            DataRow drfila;

            DataTable dtResultado = objCNGrupoSolidario.consultaCargoCli(oSolicitudCredGrupoSol.idSolicitudCredGrupoSol, item.idCli);

            clsFunUtiles oUtil = new clsFunUtiles();


            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSolicitud";
            drfila[1] = item.idSolicitud;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";
            drfila[1] = item.idCli;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idOperacion";
            drfila[1] = item.idOperacion;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPersona";
            drfila[1] = 1;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "SubProducto";
            drfila[1] = oSolicitudCredGrupoSol.idProducto;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = cFechaActual;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoCredito";
            drfila[1] = oSolicitudCredGrupoSol.idTipoPeriodo;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMonto";
            drfila[1] = item.nMonto;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCiclo";
            drfila[1] = oSolicitudCredGrupoSol.idGrupoSolidarioCiclo;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nPlazoCuotaMes";
            drfila[1] = oUtil.obtenerPlazoMeses(oSolicitudCredGrupoSol.idTipoPeriodo, oSolicitudCredGrupoSol.nCuotas, oSolicitudCredGrupoSol.nPlazoCuota);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idGrupoSolidario";
            drfila[1] = oSolicitudCredGrupoSol.idGrupoSolidario;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idGrupoSolidarioTipo";
            drfila[1] = oSolicitudCredGrupoSol.idGrupoSolidarioTipo;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idModalidadCredito";
            drfila[1] = oSolicitudCredGrupoSol.idModalidadCredito;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSolicitudCredGrupoSol";
            drfila[1] = oSolicitudCredGrupoSol.idSolicitudCredGrupoSol;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idModalidadDes";
            drfila[1] = oSolicitudCredGrupoSol.idModalidadDes;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPeriodo";
            drfila[1] = oSolicitudCredGrupoSol.idTipoPeriodo;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTasa";
            drfila[1] = oSolicitudCredGrupoSol.idTasa;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCargoCli";
            drfila[1] = Convert.ToInt32(dtResultado.Rows[0]["idGrupoSolidarioCargo"]);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idDestino";
            drfila[1] = Convert.ToInt32(dtResultado.Rows[0]["idDestino"]);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUsuRegistro";
            drfila[1] = oSolicitudCredGrupoSol.idUsuario;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaUltimaCuota";
            drfila[1] = "'"+oSolicitudCredGrupoSol.dFechaUltimaCuota.ToString("yyyy-MM-dd")+"'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idDetGasto";
            drfila[1] = item.idDetalleGasto;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nPlazo";
            drfila[1] = oSolicitudCredGrupoSol.nPlazoCuota;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nCuotas";
            drfila[1] = oSolicitudCredGrupoSol.nCuotas;
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }
        private void refrescarIcono(DataGridView dtgAfectar,bool lReglas, int nFila)
        {
            Image imgSi = Properties.Resources.success;
            Image imgNo = Properties.Resources.delete;

            Icon iconSi = Icon.FromHandle(((Bitmap)imgSi).GetHicon());
            Icon iconNO = Icon.FromHandle(((Bitmap)imgNo).GetHicon());

                if (lReglas)
                {
                    dtgAfectar.Rows[nFila].Cells["imgReglas"].Value = iconSi;
                }
                else
                {
                    dtgAfectar.Rows[nFila].Cells["imgReglas"].Value = iconNO;
                }
                

        }
        private void mostrarIconoCargar()
        {
            Image imgCargar = Properties.Resources.loading;
            Icon iconCargar = Icon.FromHandle(((Bitmap)imgCargar).GetHicon());
            dtgSolicitudes.Columns["imgReglas"].DefaultCellStyle.NullValue = iconCargar;
            dtgGrupo.Columns["imgReglas"].DefaultCellStyle.NullValue = iconCargar;
        }
        #endregion
        #region Eventos
        private void frmReglasGrupo_Shown(object sender, EventArgs e)
        {
            mostrarIconoCargar();
            verificarReglasSolicitudes();
            verificarReglasGrupo();
        }
        private void dtgGrupo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dtgGrupo.Rows[0].Selected = false;
        }
        private void btnDetalle1_Click(object sender, EventArgs e)
        {
            verExcepcionesIndividuales();
        }
        private void btnActualizar1_Click(object sender, EventArgs e)
        {
            mostrarIconoCargar();
            verificarReglasSolicitudes();
            verificarReglasGrupo();
        }
        #endregion      
    }
}
