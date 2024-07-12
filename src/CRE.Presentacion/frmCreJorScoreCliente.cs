#region Referencias
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
using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using CLI.Servicio;
using Microsoft.Reporting.WinForms;
#endregion

namespace CRE.Presentacion
{
    public partial class frmCreJorScoreCliente : frmBase
    {
        #region Variables
        private bool lCargado = false;
        private DataSet dsItems;
        private clsCreJorScoreJornalero oScoreJornalero = new clsCreJorScoreJornalero();
        private clsCNCreditoJornalero cncrejor = new clsCNCreditoJornalero();
        private string[] aListaCalcular = { "lblExperiencia", "lblExpFinanciera", "lblReferencias", "lblEstadoCivil", "lblTiempoResidencia", "lblVivienda", "lblEstadoVivienda", "lblRespaldo", "lblEdad" };
        private string[] aDestinos;
        private frmCreJorReferencia oFormReferencias = new frmCreJorReferencia();
        private DataSet dsRangoMontos;
        public bool lValidarAval = true;
        private txtNumRea txtMonto;
        private string cTituloMensaje = "CALIFICACIÓN CREDI JORNAL";
        public decimal nMonto;
        public bool lValido = false;
        private DataSet dsVariablesRechazo;
        private decimal nVariables = 0; // el valor de las variables
        private int idDestino = -1;
        private int nNumCuotas = -1;
        private string cCalificacionInterna;
        private int idTipoCliente;
        #endregion
        #region Constructor
        /** Constructor con idSolicitud: -1 Opcional **/
        public frmCreJorScoreCliente(
            int idCli, 
            ref txtNumRea txtMonto, 
            int idDestino, 
            int nNumCuotas, 
            int idSolicitud)
        {
            InitializeComponent();
            this.oScoreJornalero.idCli = idCli;
            this.txtMonto = txtMonto;
            this.idDestino = idDestino;
            this.nNumCuotas = nNumCuotas;
            this.oScoreJornalero.idSolicitud = idSolicitud;
            if (idSolicitud == -1) 
            {
                this.lValidarAval = false;
            }
            this.init();
        }
        /** Constructor para validaciones **/
        public frmCreJorScoreCliente(
            int idCli, 
            int idSolicitud)
        {
            InitializeComponent();
            this.oScoreJornalero.idCli = idCli;
            this.txtMonto = new txtNumRea();
            DataTable dtSolicitud = (new clsCNSolicitud()).ConsultaSolicitud(idSolicitud);
            if (dtSolicitud.Rows.Count > 0)
            {
                this.idDestino = Convert.ToInt32(dtSolicitud.Rows[0]["idDestino"]);
                this.nNumCuotas = Convert.ToInt32(dtSolicitud.Rows[0]["nCuotas"]);
                this.oScoreJornalero.idSolicitud = idSolicitud;
                this.txtMonto.Text = Convert.ToString(dtSolicitud.Rows[0]["nCapitalSolicitado"]);
            }
            this.init();
        }
        /** Constructor sin destino **/
        public frmCreJorScoreCliente(int idCli, decimal nMonto, int nNumCuotas, int idSolicitud)
        {
            InitializeComponent();
            this.oScoreJornalero.idCli = idCli;
            this.txtMonto = new txtNumRea();
            this.txtMonto.Text = nMonto.ToString();
            this.nNumCuotas = nNumCuotas;
            this.oScoreJornalero.idSolicitud = idSolicitud;
            DataTable dtSolicitud = (new clsCNSolicitud()).ConsultaSolicitud(idSolicitud);
            if(dtSolicitud.Rows.Count > 0)
            {
                this.idDestino = Convert.ToInt32(dtSolicitud.Rows[0]["idDestino"]);
            }
            this.init();
        }
        #endregion
        #region Metodos
        private void init()
        {
            DataTable dtCliente = (new clsCNBuscarCli()).ListarclixIdCli(this.oScoreJornalero.idCli);
            this.idTipoCliente = dtCliente.Rows[0]["idTipoCliente"] == DBNull.Value ? 0 : Convert.ToInt32(dtCliente.Rows[0]["idTipoCliente"]);
            this.cCalificacionInterna = (new clsCNBuscarCli()).ListarclixIdCli(this.oScoreJornalero.idCli).Rows[0]["cClasifInterna"].ToString();
            this.aDestinos = Convert.ToString(clsVarApl.dicVarGen["CreJorDestinos"]).Split(',');
            this.dsItems = cncrejor.dsItemsScore();
            /* Cargar rango de montos **/
            this.dsRangoMontos = cncrejor.listaMontos();

            /** cboAccionCultivar ***/
            this.cboAccionCultivo.DataSource = cncrejor.listaAccionesCultivo();
            this.cboAccionCultivo.ValueMember = "idAccion";
            this.cboAccionCultivo.DisplayMember = "cAccion";

            /*** Labels **/
            this.label16.Text = this.dsItems.Tables[0].Rows[0]["cItem"].ToString();
            this.label17.Text = this.dsItems.Tables[0].Rows[1]["cItem"].ToString();
            this.label18.Text = this.dsItems.Tables[0].Rows[2]["cItem"].ToString();
            this.label19.Text = this.dsItems.Tables[0].Rows[3]["cItem"].ToString();
            this.label20.Text = this.dsItems.Tables[0].Rows[4]["cItem"].ToString();
            this.label21.Text = this.dsItems.Tables[0].Rows[5]["cItem"].ToString();
            this.label22.Text = this.dsItems.Tables[0].Rows[6]["cItem"].ToString();
            this.label23.Text = this.dsItems.Tables[0].Rows[7]["cItem"].ToString();
            this.label24.Text = this.dsItems.Tables[0].Rows[8]["cItem"].ToString();

            /*** Comboboxs **/
            this.cboExperiencia.DataSource = this.dsItems.Tables[1];
            this.cboExperiencia.ValueMember = "idValor";
            this.cboExperiencia.DisplayMember = "cValor";
            this.cboExperiencia.SelectedIndex = this.dsItems.Tables[1].Rows.Count - 1;

            this.cboExpFinanciera.DataSource = this.dsItems.Tables[2];
            this.cboExpFinanciera.ValueMember = "idValor";
            this.cboExpFinanciera.DisplayMember = "cValor";
            this.cboExpFinanciera.SelectedIndex = this.dsItems.Tables[2].Rows.Count - 1;

            this.cboReferencias.DataSource = this.dsItems.Tables[3];
            this.cboReferencias.ValueMember = "idValor";
            this.cboReferencias.DisplayMember = "cValor";
            this.cboReferencias.SelectedIndex = this.dsItems.Tables[3].Rows.Count - 1;

            this.cboEstadoCivil.DataSource = this.dsItems.Tables[4];
            this.cboEstadoCivil.ValueMember = "idValor";
            this.cboEstadoCivil.DisplayMember = "cValor";
            this.cboEstadoCivil.SelectedIndex = this.dsItems.Tables[4].Rows.Count - 1;

            this.cboTiempoResidencia.DataSource = this.dsItems.Tables[5];
            this.cboTiempoResidencia.ValueMember = "idValor";
            this.cboTiempoResidencia.DisplayMember = "cValor";
            this.cboTiempoResidencia.SelectedIndex = this.dsItems.Tables[5].Rows.Count - 1;

            this.cboVivienda.DataSource = this.dsItems.Tables[6];
            this.cboVivienda.ValueMember = "idValor";
            this.cboVivienda.DisplayMember = "cValor";
            this.cboVivienda.SelectedIndex = this.dsItems.Tables[6].Rows.Count - 1;

            this.cboEstadoVivienda.DataSource = this.dsItems.Tables[7];
            this.cboEstadoVivienda.ValueMember = "idValor";
            this.cboEstadoVivienda.DisplayMember = "cValor";
            this.cboEstadoVivienda.SelectedIndex = this.dsItems.Tables[7].Rows.Count - 1;

            this.cboRespaldo.DataSource = this.dsItems.Tables[8];
            this.cboRespaldo.ValueMember = "idValor";
            this.cboRespaldo.DisplayMember = "cValor";
            this.cboRespaldo.SelectedIndex = this.dsItems.Tables[8].Rows.Count - 1;

            this.cboEdad.DataSource = this.dsItems.Tables[9];
            this.cboEdad.ValueMember = "idValor";
            this.cboEdad.DisplayMember = "cValor";
            this.cboEdad.SelectedIndex = this.dsItems.Tables[9].Rows.Count - 1;

            this.cargarScoreJornalero();
            this.lCargado = true;
        }
        public static bool esProductoJornalero(int idProducto)
        {
            string[] aProductos = Convert.ToString(clsVarApl.dicVarGen["cListaCreditoJornalero"]).Split(',');
            return aProductos.Contains(idProducto.ToString());
        }
        public static bool esSolicitudJornalero(int idSolicitud)
        {
            int idProducto = Convert.ToInt32((new clsCNSolicitud()).ConsultaSolicitud(idSolicitud).Rows[0]["idProducto"]);
            return frmCreJorScoreCliente.esProductoJornalero(idProducto);
        }
        private void cargarScoreJornalero()
        { 
            /** CARGAR DATOS GUARDADOS **/
            this.oScoreJornalero = cncrejor.listaScoreCliente(this.oScoreJornalero.idCli, this.oScoreJornalero.idSolicitud);

            if (this.oScoreJornalero.idAccionCultivo != 0)
            {
                this.cboAccionCultivo.SelectedValue = this.oScoreJornalero.idAccionCultivo;
            }
            if (this.oScoreJornalero.oExperiencia.idValor != 0)
            {
                this.cboExperiencia.SelectedValue = this.oScoreJornalero.oExperiencia.idValor;
            }
            if (this.oScoreJornalero.oExpFinanciera.idValor != 0)
            {
                this.cboExpFinanciera.SelectedValue = this.oScoreJornalero.oExpFinanciera.idValor;
            }
            if (this.oScoreJornalero.oReferencias.idValor != 0)
            {
                this.cboReferencias.SelectedValue = this.oScoreJornalero.oReferencias.idValor;
            }
            if (this.oScoreJornalero.oEstadoCivil.idValor != 0)
            {
                this.cboEstadoCivil.SelectedValue = this.oScoreJornalero.oEstadoCivil.idValor;
            }
            if (this.oScoreJornalero.oTiempoResidencia.idValor != 0)
            {
                this.cboTiempoResidencia.SelectedValue = this.oScoreJornalero.oTiempoResidencia.idValor;
            }
            if (this.oScoreJornalero.oVivienda.idValor != 0)
            {
                this.cboVivienda.SelectedValue = this.oScoreJornalero.oVivienda.idValor;
            }
            if (this.oScoreJornalero.oEstadoVivienda.idValor != 0)
            {
                this.cboEstadoVivienda.SelectedValue = this.oScoreJornalero.oEstadoVivienda.idValor;
            }
            if (this.oScoreJornalero.oRespaldo.idValor != 0)
            {
                this.cboRespaldo.SelectedValue = this.oScoreJornalero.oRespaldo.idValor;
            }
            if (this.oScoreJornalero.oEdad.idValor != 0)
            {
                this.cboEdad.SelectedValue = this.oScoreJornalero.oEdad.idValor;
            }

            /** CARGAR DATOS AUTOGENERADOS **/
            this.dsVariablesRechazo = this.cncrejor.listaVariablesCliente(this.oScoreJornalero.idCli);
            this.cargarDatosClienteAuto();
        }
        private void cargarDatosClienteAuto()
        {
            string cEdad = "";
            string cExpFin = "";
            if (this.dsVariablesRechazo.Tables[0].Rows.Count > 0)
            {
                cEdad = this.dsVariablesRechazo.Tables[0].Rows[0]["nAnios"].ToString() + " años y " + this.dsVariablesRechazo.Tables[0].Rows[0]["nDias"].ToString() + " dias";
                for (int i = 0; i < this.dsItems.Tables[9].Rows.Count; i++)
                {
                    DataRow oRow = this.dsItems.Tables[9].Rows[i];
                    int nMin = Convert.ToInt32(oRow["nMinimo"]);
                    int nMax = Convert.ToInt32(oRow["nMaximo"]);
                    if (
                        (nMin == -1 || nMin <= Convert.ToInt32(this.dsVariablesRechazo.Tables[0].Rows[0]["nAnios"])) && 
                        (nMax == -1 || Convert.ToInt32(this.dsVariablesRechazo.Tables[0].Rows[0]["nAnios"]) <= nMax))
                    {
                        this.cboEdad.SelectedIndex = i;
                    }
                }
            }
            if (this.dsVariablesRechazo.Tables[1].Rows.Count > 0)
            {
                cExpFin = this.dsVariablesRechazo.Tables[1].Rows[0]["nMesesExpFin"].ToString() + " meses";
                if (this.oScoreJornalero.idScoreJornalero == 0) 
                {
                    for (int i = 0; i < this.dsItems.Tables[2].Rows.Count; i++)
                    {
                        DataRow oRow = this.dsItems.Tables[2].Rows[i];
                        int nMin = Convert.ToInt32(oRow["nMinimo"]);
                        int nMax = Convert.ToInt32(oRow["nMaximo"]);
                        if (
                            (nMin == -1 || nMin <= Convert.ToInt32(this.dsVariablesRechazo.Tables[1].Rows[0]["nMesesExpFin"])) &&
                            (nMax == -1 || Convert.ToInt32(this.dsVariablesRechazo.Tables[1].Rows[0]["nMesesExpFin"]) <= nMax))
                        {
                            this.cboExpFinanciera.SelectedIndex = i;
                        }
                    }
                }
            }
            this.toolTip1.SetToolTip(
                this.lblInfoCliente,
                "Cliente: " + Environment.NewLine +
                " - Edad: " + cEdad + Environment.NewLine +
                " - Empezo historial en RCC - SBS hace: " + cExpFin + " meses");
        }
        private void calcularTotal()
        {
            this.lblTotal.Value = 0;
            this.lblTotal.Value += this.nVariables;
            foreach (string cVal in this.aListaCalcular)
            {
                Control[] aCtrl = this.tlpItems.Controls.Find(cVal, true);
                if (aCtrl.Length > 0)
                {
                    this.lblTotal.Value += (aCtrl[0] as lblNumber).Value;
                }
            }
        }
        private void calcularMonto()
        {
            if (this.dsRangoMontos.Tables[0].Rows.Count > 0)
            { 
                this.lblMonto.Text = "S/ 0";
                decimal nTotal = this.lblTotal.Value;
                foreach (DataRow oDtrow in this.dsRangoMontos.Tables[0].Rows)
                {
                    decimal nMin = Convert.ToDecimal(oDtrow["nMinimo"]);
                    decimal nMax = Convert.ToDecimal(oDtrow["nMaximo"]);
                    if (
                        (
                            nMin == -1 || nMin < nTotal
                        ) &&
                        (
                            nMax == -1 || nMax >= nTotal
                        )
                    )
                    {
                        this.nMonto = Convert.ToDecimal(oDtrow["nMonto"]);
                        this.lblMonto.Text = "S/ " + (Convert.ToDecimal(oDtrow["nMonto"])).ToString(",0.00");
                    }
                }
            }
        }
        public void guardarScoreJornalero(bool lMostrarMensaje = true)
        {
            this.oScoreJornalero.idAccionCultivo = Convert.ToInt32(this.cboAccionCultivo.SelectedValue);
            this.oScoreJornalero.nPuntaje = this.lblTotal.Value;
            this.oScoreJornalero.nMonto = this.nMonto;

            /** guardar scores **/
            this.oScoreJornalero.oExperiencia.idValor = (int)this.cboExperiencia.SelectedValue;
            this.oScoreJornalero.oExperiencia.nValor = this.lblExperiencia.Value;
            this.oScoreJornalero.oExpFinanciera.idValor = (int)this.cboExpFinanciera.SelectedValue;
            this.oScoreJornalero.oExpFinanciera.nValor = this.lblExpFinanciera.Value;
            this.oScoreJornalero.oReferencias.idValor = (int)this.cboReferencias.SelectedValue;
            this.oScoreJornalero.oReferencias.nValor = this.lblReferencias.Value;
            this.oScoreJornalero.oEstadoCivil.idValor = (int)this.cboEstadoCivil.SelectedValue;
            this.oScoreJornalero.oEstadoCivil.nValor = this.lblEstadoCivil.Value;
            this.oScoreJornalero.oTiempoResidencia.idValor = (int)this.cboTiempoResidencia.SelectedValue;
            this.oScoreJornalero.oTiempoResidencia.nValor = this.lblTiempoResidencia.Value;
            this.oScoreJornalero.oVivienda.idValor = (int)this.cboVivienda.SelectedValue;
            this.oScoreJornalero.oVivienda.nValor = this.lblVivienda.Value;
            this.oScoreJornalero.oEstadoVivienda.idValor = (int)this.cboEstadoVivienda.SelectedValue;
            this.oScoreJornalero.oEstadoVivienda.nValor = this.lblEstadoVivienda.Value;
            this.oScoreJornalero.oRespaldo.idValor = (int)this.cboRespaldo.SelectedValue;
            this.oScoreJornalero.oRespaldo.nValor = this.lblRespaldo.Value;
            this.oScoreJornalero.oEdad.idValor = (int)this.cboEdad.SelectedValue;
            this.oScoreJornalero.oEdad.nValor = this.lblEdad.Value;

            this.oScoreJornalero = this.cncrejor.guardarScoreJornalero(this.oScoreJornalero);

            if (lMostrarMensaje)
            {
                MessageBox.Show("Cambios en Score Jornalero guardados", this.cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private int obtenerItemDeCbo(cboBase cboItem)
        {
            int nResult = -1;
            if (cboItem.DataSource != null)
            {
                DataTable dtValues = (DataTable)cboItem.DataSource;
                nResult = dtValues.Columns.Contains("idItem") 
                    ? ( dtValues.Rows.Count > 0 
                        ? Convert.ToInt32(dtValues.Rows[0]["idItem"]) 
                        : -1) 
                    : -1;
            }
            return nResult;
        }
        public bool validar()
        {
            if (this.txtMonto.nDecValor > this.nMonto)
            {
                MessageBox.Show("El monto es mayor al admitido por el score", this.cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtMonto.Text = this.nMonto.ToString();
                return false;
            }
            if (!this.aDestinos.Contains(this.idDestino.ToString()))
            {
                MessageBox.Show("Los destinos posibles a seleccionar solo deben ser: • Libre disponibilidad • Vivienda", this.cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (this.nMonto == 0)
            {
                MessageBox.Show("El cliente no cumple con el puntaje mínimo para ser evaluado por esta campaña", this.cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!this.validarReferencias())
            {
                MessageBox.Show("El cliente no tiene suficientes referencias", this.cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (this.Modal) 
                {
                    this.mostrarReferencias();
                }
                return false;
            }
            if (this.lValidarAval) 
            {
                try
                {
                    DataTable dtintervinientes = (new clsCNIntervCre()).CNdtIntervCre(this.oScoreJornalero.idSolicitud, clsVarGlobal.idModulo);
                    if (dtintervinientes.Rows.Count > 0)
                    {
                        DataRow drFila = ((DataTable)this.cboRespaldo.DataSource).Rows[this.cboRespaldo.SelectedIndex];
                        int nMin = Convert.ToInt32(drFila["nMinimo"]);
                        int nMax = Convert.ToInt32(drFila["nMaximo"]);
                        DataRow[] aInterv = dtintervinientes.Select("idTipoInterv = 3");
                        if (aInterv.Length == 0) {
                            if (nMin != -1 || nMax != -1) 
                            {
                                MessageBox.Show("No hay fiador solidario", this.cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                        }
                        foreach (DataRow oRow in dtintervinientes.Select("idTipoInterv = 3"))
                        {
                            DataSet dsFiador = this.cncrejor.listaVariablesCliente(Convert.ToInt32(oRow["idCli"]));
                            int nEdadFiador = Convert.ToInt32(dsFiador.Tables[0].Rows[0]["nAnios"]);
                            if (!((nMin == -1 || nMin <= nEdadFiador) &&
                                (nMax == -1 || nMax >= nEdadFiador))) {
                                MessageBox.Show("El interviniente " +
                                    Convert.ToString(oRow["cNombre"])
                                    + " no cumple con la edad definida para el score, Edad: "
                                    + nEdadFiador.ToString(), this.cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                        }
                    }
                }
                catch (Exception e) {
                    MessageBox.Show("Error, no se pudo validar la edad de los fiadores solidarios", this.cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            /** validar destino, periodo, calificacion, tipo cliente **/
            int nNumCreditos = this.idTipoCliente == 2 ? 1 : 0;
            DataRow[] aRowMontos = this.dsRangoMontos
                                    .Tables[1]
                                    .Select("nMinimo <= " + Convert.ToDecimal(this.txtMonto.Text).ToString() +
                                            " AND nMaximo >= " + Convert.ToDecimal(this.txtMonto.Text).ToString() + 
                                            " AND nNumCreditos = " + nNumCreditos.ToString());
            
            if (aRowMontos.Length > 0 && nNumCreditos == 1)
            {
                DataTable aRowMontosTemp = aRowMontos.CopyToDataTable().Clone();
                foreach (DataRow oRow in aRowMontos)
                {
                    if (oRow["cCalificaciones"].ToString().Split(',').Contains(this.cCalificacionInterna))
                    {
                        aRowMontosTemp.Rows.Add(oRow.ItemArray);
                    }
                }
                if (aRowMontosTemp.Rows.Count == 0)
                {
                    MessageBox.Show("No hay un monto para su calificación", this.cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                aRowMontos = aRowMontosTemp.Select();
            }

            if (aRowMontos.Length > 0)
            {
                aRowMontos = aRowMontos.CopyToDataTable().Select("idDestino = " + this.idDestino.ToString());
            }
            else
            {
                MessageBox.Show("El Monto no esta dentro de un rango aceptable", this.cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (aRowMontos.Length > 0)
            {
                aRowMontos = aRowMontos.CopyToDataTable().Select("nPlazo >= " + this.nNumCuotas.ToString());
            }
            else
            {
                MessageBox.Show("El destino no es correcto", this.cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (aRowMontos.Length > 0)
            {
                aRowMontos = aRowMontos.CopyToDataTable().Select("nNumCreditos >= " + nNumCreditos.ToString());
            }
            else
            {
                MessageBox.Show("El numero de cuotas no es correcto", this.cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        public static void cargarReporteJornalero(int idCli, int idSolicitud)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DataSet dSScore = (new clsCNCreditoJornalero()).dsListaScoreCliente(idCli, idSolicitud);

            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));

            dtslist.Add(new ReportDataSource("dtScoreJornalero", dSScore.Tables[0]));
            dtslist.Add(new ReportDataSource("dtScorePuntaje", dSScore.Tables[1]));
            dtslist.Add(new ReportDataSource("dtReferencias", dSScore.Tables[2]));

            new frmReporteLocal(dtslist, "rptScoreJornalero.rdlc", paramlist).ShowDialog();
        }
        private void preguntarMostrarScore() {
            if (
                MessageBox.Show("Mostrar el Score Jornalero", this.cTituloMensaje, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes
                ) {
                    this.Show();
            }
        }
        private bool validarPeriodo()
        {
            bool lRespuesta = true;

            return lRespuesta;
        }
        private bool validarReferencias()
        {
            if (this.cboReferencias.SelectedIndex >= 0 && this.cboReferencias.SelectedIndex < this.dsItems.Tables[3].Rows.Count && this.dsItems.Tables[3].Columns.Contains("nMaximo"))
            {
                int CRPR, CRLR, CRP, CRL;
                CRLR = this.cantidadDeReferenciasLaboralesRequeridas();
                CRPR = this.cantidadDeReferenciasPersonalesRequeridas();
                CRL = this.oScoreJornalero.cantidadReferenciasLaborales();
                CRP = this.oScoreJornalero.cantidadReferenciasPersonales();
                if (CRLR <= CRL &&
                    CRPR <= CRP)
                {
                    return true;
                }
            }
            return false;
        }
        private int cantidadDeReferenciasPersonalesRequeridas() 
        {
            return Convert.ToInt32(this.dsItems.Tables[3].Rows[this.cboReferencias.SelectedIndex]["nMaximo"]);
        }
        private int cantidadDeReferenciasLaboralesRequeridas()
        {
            return Convert.ToInt32(this.dsItems.Tables[3].Rows[this.cboReferencias.SelectedIndex]["nMinimo"]);
        }
        private void mostrarReferencias()
        {
            this.oFormReferencias.oScoreJornalero = this.oScoreJornalero;
            this.oFormReferencias.ShowDialog();
        }
        #endregion
        #region Eventos
        private void cboEdad_SelectedValueChanged(object sender, EventArgs e)
        {
            if (sender != null)
            {
                cboBase cboControl = sender as cboBase;

                if (this.tlpItems.Controls != null && this.tlpItems.Controls.Count > 0)
                {
                    TableLayoutControlCollection oControls = this.tlpItems.Controls;

                    if (cboControl.Tag != null)
                    {
                        Control[] ctrls = oControls.Find(cboControl.Tag.ToString(), true);
                        if (ctrls.Length > 0)
                        {
                            lblNumber lblControl = ctrls[0] as lblNumber;
                            lblControl.Value = Convert.ToDecimal(((DataTable)cboControl.DataSource).Rows[cboControl.SelectedIndex]["nValor"]);
                        }
                    }
                }
            }
        }
        private void lblEdad_TextChanged(object sender, EventArgs e)
        {
            this.calcularTotal();
        }
        private void cboReferencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lCargado)
            {
                DataRow oRowReferencias = ((DataTable)this.cboReferencias.DataSource).Rows[this.cboReferencias.SelectedIndex];
                if (!this.validarReferencias()) 
                {
                    this.mostrarReferencias();
                }
            }
        }
        private void btnShowRef_Click(object sender, EventArgs e)
        {
            this.mostrarReferencias();
        }
        private void lblTotal_TextChanged(object sender, EventArgs e)
        {
            this.calcularMonto();
        }
        private void cboExperiencia_MouseHover(object sender, EventArgs e)
        {
            var oSelect = sender as ComboBox;
            this.toolTip1.SetToolTip(oSelect, oSelect.Text);
        }
        private void btnValidar1_Click(object sender, EventArgs e)
        {
            this.validar();
            this.guardarScoreJornalero(false);
        }
        private void btnContinuar1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion

    }
}
