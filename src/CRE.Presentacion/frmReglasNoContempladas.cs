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
using GEN.CapaNegocio;
using GEN.Funciones;
using GEN.BotonesBase;
using EntityLayer;
using Microsoft.Reporting.WinForms;
namespace CRE.Presentacion
{
    public partial class frmReglasNoContempladas : frmBase
    {

        #region Variables Generales
        private int idSolicitud = 0;
        private string cTituloFormulario = "Gestión de Excepciones no contempladas.";
        clsCNSolicitud obCNSolicitud = new clsCNSolicitud();
        DataTable dtReglaSolicitud = new DataTable();
        int idReglaNoContem=0;
        int idExcepGen = 0;
        int idUsuario = clsVarGlobal.User.idUsuario;
        string sustento = "";
        DataTable dtSolicitud = new DataTable();
        private DataTable dtSoli;
        DataTable dtDatosENC = new DataTable();
        
        #endregion

        #region Eventos
        public frmReglasNoContempladas()
        {
            InitializeComponent();
            limpiarDatos();
            this.txtNumerico1.Enabled = false;
            this.btnSolicitar1.Enabled = false;
            this.btnDetalle1.Enabled = false;
            this.txtSustento.Enabled = false;
            this.btnImprimir1.Enabled = false;
            this.btnOtrasRNC.Enabled = false;
        }
        private void frmReglasNoContempladas_Load(object sender, EventArgs e)
        {
            this.Text = cTituloFormulario;

        }
        private void btnBusSolicitud1_Click(object sender, EventArgs e)
        {
            limpiarDatos();
            invocarBandeja();
        }
        private void dtgBase1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.btnBusSolicitud1.Enabled = false;
            if (dtgBase1.Rows.Count == 1)
            {
                if (dtgBase1.SelectedRows.Count != 0)
                {
                    DataGridViewRow row = this.dtgBase1.SelectedRows[0];
                    this.txtIdRegla.Text = row.Cells["nIdRegla"].Value.ToString();
                    this.txtNombreRegla.Text = row.Cells["cMensajeError"].Value.ToString();
                    //this.lblEstadoSolicitud.Text = row.Cells["cEstado"].Value.ToString();
                    idReglaNoContem = Convert.ToInt32(this.txtIdRegla.Text = row.Cells["nIdRegla"].Value.ToString());
                    idExcepGen = Convert.ToInt32(this.txtIdRegla.Text = row.Cells["idExcepGen"].Value.ToString());
                    this.btnSolicitar1.Enabled = true;
                    this.btnDetalle1.Enabled = true;
                    this.txtSustento.Enabled = false;
                    this.btnImprimir1.Enabled = true;
                    dtDatosENC = obCNSolicitud.obtenerDatosReporteRNC(idSolicitud,idReglaNoContem);
                    if (dtDatosENC.Rows.Count > 0)
                    {
                        this.txtSustento.Text = Convert.ToString(this.dtDatosENC.Rows[0]["cSustento"]);
                    }
                }
            }
            else if (dtgBase1.Rows.Count > 1)
            {
                this.btnSolicitar1.Enabled = false;
                this.btnDetalle1.Enabled = false;
                this.btnImprimir1.Enabled = false;
                MessageBox.Show("No pueden continuar con el flujo aquellas solicitudes que tengan mas de (1) una Regla No Excepcionable.",
                           cTituloFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void btnSolicitar1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtNumerico1.Text.Trim()) || String.IsNullOrEmpty(this.txtSustento.Text.Trim()))
            {
                MessageBox.Show("No existen datos para solicitar.",
                       cTituloFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult dlres = MessageBox.Show("¿Está seguro de Solicitar con estos datos la aprobacion de la Excepción No Contemplada?, una vez hecha la solicitud no podrá editarla de nuevo.",
                       cTituloFormulario, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dlres == DialogResult.Yes)
                {
                    idSolicitud = Convert.ToInt32(this.txtNumerico1.Text.Trim());
                    sustento = Convert.ToString(this.txtSustento.Text.Trim());
                    int idNivelAprob = 2;

                    DataTable dtConsulta = new DataTable();
                    dtConsulta = obCNSolicitud.consultaSolReglaNoContemplada(idSolicitud, idReglaNoContem, idExcepGen, idNivelAprob, idUsuario, sustento);
                    int idFilas = Convert.ToInt32(dtConsulta.Rows[0]["filas"]);
                     
                    if (idFilas == 0)
                    {
                        if (idReglaNoContem == 0 || idExcepGen == 0)
                        {
                            MessageBox.Show("Seleccione una regla no excepcionable dentro del recuadro o esta solicitud no generó reglas no excepcionables",
                                cTituloFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else
                        {
                            if (sustento.Length < 5) // Cambiar mediante coordinacion con usuario experto
                            {
                                MessageBox.Show("Ingrese un sustento válido.",
                                cTituloFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (sustento != "")
                            {
                                //  MessageBox.Show("soli: " + idSolicitud + " sus: " + sustento + " IdRegla: " + idReglaNoContem + " Usuario: " + idUsuario
                                //      + " IdExcepGen " + idExcepGen + "Nivel de Aprobación : " + 1);

                                dtSoli = obCNSolicitud.obtenerDatosReporteRNC(idSolicitud,idReglaNoContem);

                                if (dtSoli.Rows.Count > 0)
                                {
                                    dtSolicitud = obCNSolicitud.insertarSolReglaNoContemplada(idSolicitud, idReglaNoContem, idExcepGen, idNivelAprob, idUsuario, sustento);
                                    MessageBox.Show("La solicitud se realizó correctamente.", cTituloFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    limpiarDatos();
                                }
                                else
                                {
                                    MessageBox.Show("Debe completar los campos requeridos en DETALLES para el Reporte de Excepciones No Contempladas", cTituloFormulario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }



                            }
                        }

                    }
                    else if (idFilas != 0)
                    {
                        MessageBox.Show("Ya existe una solicitud con estos datos.", cTituloFormulario, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    return;
                }
            }
        }
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            Reporte();
        }

        private void boton1_Click(object sender, EventArgs e)
        {

            string cIdRNC = Convert.ToString(clsVarApl.dicVarGen["idRNC"]);
            string cIdExcepGenRNC = Convert.ToString(clsVarApl.dicVarGen["idExcepGenRNC"]);

            this.txtIdRegla.Text = cIdRNC;
            this.txtNombreRegla.Text = "Otras Excepciones No Contempladas.";

            idReglaNoContem = Convert.ToInt32(cIdRNC);
            idExcepGen = Convert.ToInt32(cIdExcepGenRNC); ;

            this.btnDetalle1.Enabled = true;
            this.btnSolicitar1.Enabled = true;
            this.btnImprimir1.Enabled = true;
            this.btnBusSolicitud1.Enabled = false;
            this.btnOtrasRNC.Enabled = false;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiarDatos();
        }
        private void btnDetalle1_Click(object sender, EventArgs e)
        {
            invocarObtenerDatos();
        }
        #endregion

        #region Metodos
        private void invocarBandeja()
        {
            frmBandejaSolicitudes obBandejaSolicitudes = new frmBandejaSolicitudes();
            obBandejaSolicitudes.ShowDialog();
            idSolicitud = obBandejaSolicitudes.idSolicitud;
            if (idSolicitud == 0)
            {
                return;
            }
            else
	        {
                dtReglaSolicitud = obCNSolicitud.listarReglaSolicitud(idSolicitud);
                cargarDatos();
	        }
        }
        private void invocarObtenerDatos()
        {
            frmObtenerDatosReporteRNC obDatosReporte = new frmObtenerDatosReporteRNC(idSolicitud,idReglaNoContem);
            obDatosReporte.ShowDialog();
            sustento = obDatosReporte.cSustento;
            this.txtSustento.Text = sustento;            
        }
        private void limpiarDatos()
        {
            this.txtNumerico1.Clear();
            dtgBase1.DataSource = null;
            idReglaNoContem = 0;
            idExcepGen = 0;
            idSolicitud = 0;
            sustento = "";
            this.txtNombreRegla.Clear();
            this.txtIdRegla.Clear();
            this.txtSustento.Clear();
            /************/
            this.btnOtrasRNC.Enabled = false;
            this.btnDetalle1.Enabled = false;
            this.btnImprimir1.Enabled = false;
            this.btnSolicitar1.Enabled = false;
            this.btnBusSolicitud1.Enabled = true;
        }
        private void cargarDatos()
        {
            txtNumerico1.Text = idSolicitud.ToString();
            txtNumerico1.Enabled = false;
            dtgBase1.DataSource = dtReglaSolicitud;
            if (dtReglaSolicitud.Rows.Count == 0)
            {
                this.btnOtrasRNC.Enabled = true;
            }
            else
            {
                this.btnOtrasRNC.Enabled = false;
            }
            formatoGridSolicitudes();

        }
        private void formatoGridSolicitudes()
        {
            foreach (DataGridViewColumn column in this.dtgBase1.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgBase1.Columns["idSolicitud"].Visible = true;
            dtgBase1.Columns["nIdRegla"].Visible = true;
            dtgBase1.Columns["cMensajeError"].Visible = true;

            dtgBase1.Columns["idSolicitud"].HeaderText = "N° de Solicitud";
            dtgBase1.Columns["nIdRegla"].HeaderText = "N° de Regla";
            dtgBase1.Columns["cMensajeError"].HeaderText = "Descripción de Regla";

        }
        private void Reporte()
        {
            clsCNSolicitud cnRptRNC = new clsCNSolicitud();
            DateTime dFecOpe = clsVarGlobal.dFecSystem;
            string cNomAgen = clsVarGlobal.cNomAge;
            string cSustento = this.txtSustento.Text;
            DataTable dtData2 = cnRptRNC.ObtenerReporteRNCIni(idSolicitud,idReglaNoContem,cSustento);
            DataTable dtData3 = cnRptRNC.ObtenerReporteRNC1(idSolicitud);


            if (dtData2.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsSolicitud", dtData2));
                dtsList.Add(new ReportDataSource("dsSolicitud2", dtData3));

                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("idsolicitud", idSolicitud.ToString(), false));
                paramlist.Add(new ReportParameter("dFecOpe", dFecOpe.ToString(), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen.ToString(), false));
                paramlist.Add(new ReportParameter("idRegla", idReglaNoContem.ToString(), false));
                paramlist.Add(new ReportParameter("cSustento", cSustento.ToString(), false));

                string reportPath = "rptSolcitudRNCIni.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para esta Solicitud de Excepcion No Contemplada.", cTituloFormulario, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        #endregion

    }
}
