using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmProyeccionEstacionalRural : frmBase
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        #region Variables

        List<clsProyeccionIngresos> listaProyeccionIngresos;
        List<clsInversionInsumo> listaInversionInsumos;
        List<clsEgresosEstacionales> listaEgresosEstacionales;
        
        clsCNEvalCrediRural Proyecciones = new clsCNEvalCrediRural();

        private int idEvalCred;
        private int nCuotas;
        private DateTime dFechaDesembolso;
        public bool lGuardado = false;

        #endregion


        #region Metodos Publicos

        public frmProyeccionEstacionalRural(int _cuotas, DateTime _fechaDesembolso, int _idEval)
        {
            this.idEvalCred = _idEval;
            this.nCuotas = _cuotas;
            this.dFechaDesembolso = _fechaDesembolso;
            InitializeComponent();
            this.conIngresosEstacionales.Enabled = false;
            this.conEgresosEstacionales.Enabled = false;
        }

        #endregion


        #region Metodos Privados

        private void RecuperarDetalleProyeccionEstacional()
        {
            DataSet ds = new clsCNEvalCrediRural().ObtenerProyeccionRural(this.idEvalCred);
            this.listaProyeccionIngresos = DataTableToList.ConvertTo<clsProyeccionIngresos>(ds.Tables[0]) as List<clsProyeccionIngresos>;
            this.listaInversionInsumos = DataTableToList.ConvertTo<clsInversionInsumo>(ds.Tables[1]) as List<clsInversionInsumo>;
            this.listaEgresosEstacionales = DataTableToList.ConvertTo<clsEgresosEstacionales>(ds.Tables[2]) as List<clsEgresosEstacionales>;

            foreach (var item in this.listaProyeccionIngresos)
            {
                item.listaInversionInsumo = this.listaInversionInsumos.FindAll(x => x.idProyeccionIngreso == item.idIngresoEstacional);
            }

            this.conIngresosEstacionales.AsignarDatos(this.listaProyeccionIngresos, this.listaInversionInsumos, this.nCuotas, this.dFechaDesembolso);
            this.conEgresosEstacionales.AsignarDatos(this.listaProyeccionIngresos, this.listaEgresosEstacionales);
        }

        public void ObtenerListaEgresos()
        {
            this.listaEgresosEstacionales = conEgresosEstacionales.ExportarListaEgresos(conIngresosEstacionales.ExportListaIngresos());
        }

        private void ObtenerListaIngresos()
        {
            this.listaProyeccionIngresos = conIngresosEstacionales.ExportListaIngresos();
        }

        private void ObtenerListaInversionInsumos()
        {
            this.listaInversionInsumos = conIngresosEstacionales.ExportListaInversionInsumos();
        }

        private string IngresoEstacionalEnXML(List<clsProyeccionIngresos> lstIngresos)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idIngresoEstacional", typeof(Guid));
            dt.Columns.Add("idCultivo", typeof(int));
            dt.Columns.Add("idVariedad", typeof(int));
            dt.Columns.Add("cParcela", typeof(string));
            dt.Columns.Add("nExtension", typeof(decimal));
            dt.Columns.Add("idUnidad", typeof(int));
            dt.Columns.Add("idMoneda", typeof(int));
            dt.Columns.Add("idEtapaProduccion", typeof(int));
            dt.Columns.Add("idCondicionTerreno", typeof(int));
            dt.Columns.Add("idCondicionTenencia", typeof(int));
            dt.Columns.Add("nRendAnterior", typeof(decimal));
            dt.Columns.Add("nRendMinimo", typeof(decimal));
            dt.Columns.Add("nRendMaximo", typeof(decimal));
            dt.Columns.Add("nPrecioVenta", typeof(decimal));
            dt.Columns.Add("nFecha", typeof(int));
            dt.Columns.Add("nRendPonderado", typeof(decimal));
            dt.Columns.Add("nCantidadVenta", typeof(decimal));
            dt.Columns.Add("nIngresos", typeof(decimal));
            dt.Columns.Add("lInversionRealizada", typeof(bool));
            dt.Columns.Add("nMontoInversionTotal", typeof(decimal));

            foreach (var detInsum in lstIngresos)
            {
                DataRow row = dt.NewRow();

                row["idIngresoEstacional"] = detInsum.idIngresoEstacional;
                row["idCultivo"] = detInsum.idCultivo;
                row["idVariedad"] = detInsum.idVariedad;
                row["cParcela"] = detInsum.cParcela;
                row["nExtension"] = detInsum.nExtension;
                row["idUnidad"] = detInsum.idUnidad;
                row["idMoneda"] = detInsum.idMoneda;
                row["idEtapaProduccion"] = detInsum.idEtapaProduccion;
                row["idCondicionTerreno"] = detInsum.idCondicionTerreno;
                row["idCondicionTenencia"] = detInsum.idCondicionTenencia;
                row["nRendAnterior"] = detInsum.nRendAnterior;
                row["nRendMinimo"] = detInsum.nRendMinimo;
                row["nRendMaximo"] = detInsum.nRendMaximo;
                row["nPrecioVenta"] = detInsum.nPrecioVenta;
                row["nFecha"] = detInsum.nFecha;
                row["nRendPonderado"] = detInsum.nRendPonderado;
                row["nCantidadVenta"] = detInsum.nCantidadVenta;
                row["nIngresos"] = detInsum.nIngresos;
                row["lInversionRealizada"] = detInsum.lInversionRealizada;
                row["nMontoInversionTotal"] = detInsum.nMontoInversionTotal;

                dt.Rows.Add(row);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "DetIngresoEstacional", "Item");
        }

        private string EgresoEstacionalEnXML(List<clsEgresosEstacionales> lstInsumos)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idEgresoEstacional", typeof(Guid));
            dt.Columns.Add("cNombreInsumo", typeof(string));
            dt.Columns.Add("nExtension", typeof(decimal));
            dt.Columns.Add("nCantidad", typeof(decimal));
            dt.Columns.Add("nPrecio", typeof(decimal));
            dt.Columns.Add("nGasto", typeof(decimal));
            dt.Columns.Add("nFecha", typeof(int));
            dt.Columns.Add("idIngresoEstacional", typeof(Guid));

            foreach (var detInsum in lstInsumos)
            {
                DataRow row = dt.NewRow();

                row["idEgresoEstacional"] = detInsum.idEgresoEstacional;
                row["cNombreInsumo"] = detInsum.cNombreInsumo;
                row["nExtension"] = detInsum.nExtension;
                row["cNombreInsumo"] = detInsum.cNombreInsumo;
                row["nCantidad"] = detInsum.nCantidad;
                row["nPrecio"] = detInsum.nPrecio;
                row["nGasto"] = detInsum.nGasto;
                row["nFecha"] = detInsum.nFecha;
                row["idIngresoEstacional"] = detInsum.idIngresoEstacional;

                dt.Rows.Add(row);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "DetEgresoEstacional", "Item");

        }

        private string InversionInsumoEnXML(List<clsInversionInsumo> lstInversionInsumos)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idInversionInsumo", typeof(Guid));
            dt.Columns.Add("cNombreInsumo", typeof(string));
            dt.Columns.Add("nUnidadMedida", typeof(decimal));
            dt.Columns.Add("idUnidad", typeof(int));
            dt.Columns.Add("nExtension", typeof(decimal));
            dt.Columns.Add("nCantidad", typeof(decimal));
            dt.Columns.Add("nPrecio", typeof(decimal));
            dt.Columns.Add("nTotal", typeof(decimal));
            dt.Columns.Add("idProyeccionIngreso", typeof(Guid));

            foreach (var detInsum in lstInversionInsumos)
            {
                DataRow row = dt.NewRow();

                row["idInversionInsumo"] = detInsum.idInversionInsumo;
                row["cNombreInsumo"] = detInsum.cNombreInsumo;
                row["nUnidadMedida"] = detInsum.nUnidadMedida;
                row["idUnidad"] = detInsum.idUnidad;
                row["nExtension"] = detInsum.nExtension;
                row["nCantidad"] = detInsum.nCantidad;
                row["nPrecio"] = detInsum.nPrecio;
                row["nTotal"] = detInsum.nTotal;
                row["idProyeccionIngreso"] = detInsum.idProyeccionIngreso;

                dt.Rows.Add(row);
            }
            return clsUtils.ConvertToXML(dt.Copy(), "DetinversionInsumo", "Item");
        }

        #endregion


        #region Eventos

        private void frmProyeccionEstacionalRural_Load(object sender, EventArgs e)
        {
            this.conIngresosEstacionales.inicializarControl();
            this.conEgresosEstacionales.inicializarControl(this.nCuotas, this.dFechaDesembolso);
            RecuperarDetalleProyeccionEstacional();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            conEgresosEstacionales.ObtenerListaIngresos(conIngresosEstacionales.ExportListaIngresos());
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            ObtenerListaIngresos();
            ObtenerListaEgresos();
            ObtenerListaInversionInsumos();

            string xmlDetalleIngresoRural = IngresoEstacionalEnXML(this.listaProyeccionIngresos);
            string xmlDetalleEgresoRural = EgresoEstacionalEnXML(this.listaEgresosEstacionales);
            string xmlDetalleInversionInsumo = InversionInsumoEnXML(this.listaInversionInsumos);

            Proyecciones.GuardarProyeccionEstacional(this.idEvalCred, xmlDetalleIngresoRural, xmlDetalleEgresoRural, xmlDetalleInversionInsumo);

            this.conIngresosEstacionales.Enabled = false;
            this.conEgresosEstacionales.Enabled = false;
            this.btnEditar.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;

            this.lGuardado = true;

            RecuperarDetalleProyeccionEstacional();
            this.tabControl.SelectedTab = this.tabPage1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.conIngresosEstacionales.Enabled = true;
            this.conEgresosEstacionales.Enabled = true;

            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.conIngresosEstacionales.Enabled = false;
            this.conEgresosEstacionales.Enabled = false;
            this.conIngresosEstacionales.LimpiarFormulario();

            this.btnEditar.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;

            RecuperarDetalleProyeccionEstacional();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
