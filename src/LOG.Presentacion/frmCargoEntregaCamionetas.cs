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

using Microsoft.Reporting.WinForms;
using System.IO;
using System.Xml.Linq;

// CoreBank
using GEN.ControlesBase;
using LOG.CapaNegocio;
using EntityLayer;
#endregion

namespace LOG.Presentacion
{
    public partial class frmCargoEntregaCamionetas : frmBase
    {
        #region Variables
        clsCNActivos clscnactivos = new clsCNActivos();
        DataTable dtListaMovimientos;
        DataTable dtAccesoriosHerramientas = new DataTable();
        DataTable dtCamioneta = new DataTable();
        DataTable dtLlantas = new DataTable();
        int nIdMovimiento;
        const int nIdTipoCargoEntrega = 4;
        int idCargoEntrega = -1;
        DataTable dtCargoEntrega = new DataTable(); // para actualizar
        #endregion

        #region Constructor
        public frmCargoEntregaCamionetas()
        {
            InitializeComponent();
        }
        public frmCargoEntregaCamionetas(int nIdMovimiento)
        {
            InitializeComponent();
            initForm(nIdMovimiento);
        }
        #endregion

        #region Metodos
        /**
        * 
        * Inicializacion del formulario
        * 
        */
        public void initForm(int nIdMovimiento) 
        {
            // defincion de las variables locales
            this.nIdMovimiento = nIdMovimiento;
            // datos del activo importantes para el cargo de entrega
            dtListaMovimientos = clscnactivos.CNLisMovActCarEnt(nIdMovimiento);
            // el ultimo cargo de entrega
            dtCargoEntrega = clscnactivos.CNUltCargoEntrega(nIdMovimiento, 2);
            idCargoEntrega = Convert.ToInt32(dtCargoEntrega.Rows[0]["idCargoEntrega"]);
            
            // comprobar si ha cambiado el tipo de cargo de entrega 
            if (Convert.ToInt32(dtCargoEntrega.Rows[0]["idTipoCargoEntrega"]) != nIdTipoCargoEntrega && idCargoEntrega != -1)
            {
                idCargoEntrega = -1;
                if (MessageBox.Show("Vas a cambiar el tipo de cargo de entrega, estas seguro?", "Registro en Base de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != System.Windows.Forms.DialogResult.Yes)
                {
                    Load += (s, e) => Close();
                    return;
                }
            }

            /**
             * 
             * inmutable
             * 
             */
            dtLlantas = new DataTable();
            dtAccesoriosHerramientas = new DataTable();
            dtCamioneta = new DataTable();
            txtFechaEntrega.Text = clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy");
            txtHoraSis.Text = DateTime.Now.ToString("h:mm:ss tt");
            txtDependencia.Text = dtListaMovimientos.Rows[0]["cArea"].ToString() + " REGION " + dtListaMovimientos.Rows[0]["cDepartamento"].ToString();
            txtUnidadMarca.Text = dtListaMovimientos.Rows[0]["cMarca"].ToString();
            txtUnidadModelo.Text = dtListaMovimientos.Rows[0]["cModelo"].ToString();
            txtUnidadSerie.Text = dtListaMovimientos.Rows[0]["cSerie"].ToString();
            txtUnidadColor.Text = dtListaMovimientos.Rows[0]["cColor"].ToString();
            txtNombreColaborador.Text = dtListaMovimientos.Rows[0]["cNombre"].ToString();

            if (idCargoEntrega == -1)
            {
                /**
                 * 
                 * Cargar nuevo Cargo entrega
                 * 
                 */
                initDtgAccesoriosHerramientas();
                initDtgCamioneta();
                initDtgLlantas();
            }
            else 
            {
                /**
                 * 
                 * editar cargo de entrega existente
                 * Carga todos los datos de la base de datos
                 * 
                 */
                XElement xReporte = XElement.Parse(dtCargoEntrega.Rows[0]["xDetalles"].ToString());
                XElement xListReportParameter = xReporte.Element("ListReportParameter");
                XElement xListReportDataSource = xReporte.Element("ListReportDataSource");

                chbTarjetaPropiedad.Checked = Convert.ToBoolean(Convert.ToInt32(xListReportParameter.Element("chbTarjetaPropiedad").Value.ToString()));
                chbPolizaSeguro.Checked = Convert.ToBoolean(Convert.ToInt32(xListReportParameter.Element("chbPolizaSeguro").Value.ToString()));
                chbPlacaDelantera.Checked = Convert.ToBoolean(Convert.ToInt32(xListReportParameter.Element("chbPlacaDelantera").Value.ToString()));
                chbPlacaTrasera.Checked = Convert.ToBoolean(Convert.ToInt32(xListReportParameter.Element("chbPlacaTrasera").Value.ToString()));
                chbRevisionTecnica.Checked = Convert.ToBoolean(Convert.ToInt32(xListReportParameter.Element("chbRevisionTecnica").Value.ToString()));

                txtUnidadPlaca.Text = xListReportParameter.Element("txtUnidadPlaca").Value.ToString();
                txtUnidadClase.Text = xListReportParameter.Element("txtUnidadClase").Value.ToString();
                txtUnidadAnioFab.Text = xListReportParameter.Element("txtUnidadAnioFab").Value.ToString();
                txtUnidadMotor.Text = xListReportParameter.Element("txtUnidadMotor").Value.ToString();
                txtUnidadCilindros.Text = xListReportParameter.Element("txtUnidadCilindros").Value.ToString();
                txtKilometraje.Text = xListReportParameter.Element("txtKilometraje").Value.ToString();
                txtTipoCombustible.Text = xListReportParameter.Element("txtTipoCombustible").Value.ToString();
                txtBitacora.Text = xListReportParameter.Element("txtBitacora").Value.ToString();
                txtObsRecepcion.Text = xListReportParameter.Element("txtObsRecepcion").Value.ToString();
                txtObsDevVeh.Text = xListReportParameter.Element("txtObsDevVeh").Value.ToString();

                txtFechaEntrega.Text = xListReportParameter.Element("cFechaSis").Value.ToString();
                txtHoraSis.Text = xListReportParameter.Element("cHoraSis").Value.ToString();

                dtAccesoriosHerramientas.Merge(xmlADatatable(xListReportDataSource.Element("dtAccesoriosHerramientas").Element("DocumentElement")));
                dtAccesoriosHerramientas.Merge(xmlADatatable(xListReportDataSource.Element("dtAccesoriosHerramientas1").Element("DocumentElement")));
                dtAccesoriosHerramientas.Merge(xmlADatatable(xListReportDataSource.Element("dtAccesoriosHerramientas2").Element("DocumentElement")));
                dtAccesoriosHerramientas.Merge(xmlADatatable(xListReportDataSource.Element("dtAccesoriosHerramientas3").Element("DocumentElement")));

                dtCamioneta.Merge(xmlADatatable(xListReportDataSource.Element("dtCamioneta").Element("DocumentElement")));
                dtCamioneta.Merge(xmlADatatable(xListReportDataSource.Element("dtCamioneta1").Element("DocumentElement")));
                dtCamioneta.Merge(xmlADatatable(xListReportDataSource.Element("dtCamioneta2").Element("DocumentElement")));

                dtLlantas.Merge(xmlADatatable(xListReportDataSource.Element("dtLlantas").Element("DocumentElement")));
                dtLlantas.Merge(xmlADatatable(xListReportDataSource.Element("dtLlantas1").Element("DocumentElement")));
                dtLlantas.Merge(xmlADatatable(xListReportDataSource.Element("dtLlantas2").Element("DocumentElement")));

                initDtgAccesoriosHerramientas(true);
                initDtgCamioneta(true);
                initDtgLlantas(true);
            }
        }
        static public DataTable cargarColumnas(DataTable dtLista, string[] aColumnas)
        {
            foreach (string cColumna in aColumnas)
            {
                if (!dtLista.Columns.Contains(cColumna))
                {
                    dtLista.Columns.Add(cColumna);
                }
            }
            return dtLista;
        }
        private void initDtgLlantas(bool soloDtg = false)
        {
            string[] aColumnas = new string[] { "cDescripcion", "N", "B", "R", "M"};

            dtLlantas = cargarColumnas(dtLlantas, aColumnas);

            if (!soloDtg) 
            {
                // dtLlantas
                dtLlantas.Rows.Add("LLANTA DELANTERA DERECHA");
                dtLlantas.Rows.Add("LLANTA DELANTERA IZQUIERDA");
                dtLlantas.Rows.Add("LLANTA TRASERA DERECHA");
                dtLlantas.Rows.Add("LLANTA TRASERA IZQUIERDA");
                dtLlantas.Rows.Add("LLANTA DE REPUESTO CON ARO");
            }
            

            dtgLlantas.DataSource = dtLlantas;
            dtgLlantas.AllowUserToAddRows = false;
            dtgLlantas.Columns["cDescripcion"].HeaderText = "DESCRIPCION";
            dtgLlantas.Columns["cDescripcion"].Width = 320;
            dtgLlantas.Columns["cDescripcion"].ReadOnly = true;
            dtgLlantas.Columns["N"].Width = 40;
            dtgLlantas.Columns["B"].Width = 40;
            dtgLlantas.Columns["R"].Width = 40;
            dtgLlantas.Columns["M"].Width = 40;
        }
        private void initDtgCamioneta(bool soloDtg = false)
        {
            string[] aColumnas = new string[] { "cDescripcion", "N", "B", "R", "M" };

            dtCamioneta = cargarColumnas(dtCamioneta, aColumnas);

            if (!soloDtg) 
            { 
                // insertar datos a el datatable
                dtCamioneta.Rows.Add("COSTADO DERECHO");
                dtCamioneta.Rows.Add("COSTADO IZQUIERDO");
                dtCamioneta.Rows.Add("CAPOT DE MOTOR");
                dtCamioneta.Rows.Add("TOLVA");
                dtCamioneta.Rows.Add("PORTATRASERA");
                dtCamioneta.Rows.Add("PINTURA");
                dtCamioneta.Rows.Add("LUNAS CORTAVIENTO");
                dtCamioneta.Rows.Add("PUERTAS");
                dtCamioneta.Rows.Add("TANQUE DE COMBUSTIBLE");
                dtCamioneta.Rows.Add("LUNAS LATERALES");
                dtCamioneta.Rows.Add("PARACHOQUES POSTERIOR");
                dtCamioneta.Rows.Add("PARACHOQUES DELANTEROS");
            }

            dtgCamioneta.DataSource = dtCamioneta;
            dtgCamioneta.AllowUserToAddRows = false;

            dtgCamioneta.Columns["cDescripcion"].HeaderText = "DESCRIPCION";
            dtgCamioneta.Columns["cDescripcion"].Width = 320;
            dtgCamioneta.Columns["cDescripcion"].ReadOnly = true;
            //dtgCamioneta.Columns["cObservacion"].HeaderText = "OBSERVACIONES";
            //dtgCamioneta.Columns["cObservacion"].Width = 120;
            dtgCamioneta.Columns["N"].Width = 40;
            dtgCamioneta.Columns["B"].Width = 40;
            dtgCamioneta.Columns["R"].Width = 40;
            dtgCamioneta.Columns["M"].Width = 40;
        }
        private void initDtgAccesoriosHerramientas(bool soloDtg = false)
        {
            string[] aColumnas = new string[] { "cDescripcion", "cSi", "cNo" };

            dtAccesoriosHerramientas = cargarColumnas(dtAccesoriosHerramientas, aColumnas);

            if (!soloDtg)
            {
                //dtAccesoriosHerramientas.Columns.Add("cDescripcion");
                //dtAccesoriosHerramientas.Columns.Add("cSi");
                //dtAccesoriosHerramientas.Columns.Add("cNo");
                // insertar datos a el datatable
                dtAccesoriosHerramientas.Rows.Add("LLAVE DE ENCENDIDO");
                dtAccesoriosHerramientas.Rows.Add("VELOCIMETRO");
                dtAccesoriosHerramientas.Rows.Add("ASIENTOS");
                dtAccesoriosHerramientas.Rows.Add("AIRE ACONDICIONADO BASICO");
                dtAccesoriosHerramientas.Rows.Add("CENICEROS");
                dtAccesoriosHerramientas.Rows.Add("CHAPAS DE PUERTAS");
                dtAccesoriosHerramientas.Rows.Add("CINTURON DE SEGURIDAD");
                dtAccesoriosHerramientas.Rows.Add("RADIO");
                dtAccesoriosHerramientas.Rows.Add("ENCENDEDORES");
                dtAccesoriosHerramientas.Rows.Add("PARLANTES");
                dtAccesoriosHerramientas.Rows.Add("TAPIZADO");
                dtAccesoriosHerramientas.Rows.Add("LUZ DE SALON");
                dtAccesoriosHerramientas.Rows.Add("DESARMADOR ESTRELLA");
                dtAccesoriosHerramientas.Rows.Add("DESARMADOR PLANO");
                dtAccesoriosHerramientas.Rows.Add("CABLE DE REMOLQUE");
                dtAccesoriosHerramientas.Rows.Add("CABLE PARA BATERIA");
                dtAccesoriosHerramientas.Rows.Add("ELEVA LUNAS MANUAL");
                dtAccesoriosHerramientas.Rows.Add("CLAXON");
                dtAccesoriosHerramientas.Rows.Add("CODERAS");
                dtAccesoriosHerramientas.Rows.Add("ESPEJOS RETROVISORES");
                dtAccesoriosHerramientas.Rows.Add("FAROS DELANTEROS");
                dtAccesoriosHerramientas.Rows.Add("LUCES DIRECCIONALES");
                dtAccesoriosHerramientas.Rows.Add("FRENO DE MANO");
                dtAccesoriosHerramientas.Rows.Add("MANIJAS EXTERIORES");
                dtAccesoriosHerramientas.Rows.Add("MANIJAS INTERIORES");
                dtAccesoriosHerramientas.Rows.Add("ANTENA DE RADIO");
                dtAccesoriosHerramientas.Rows.Add("MASCARAS");
                dtAccesoriosHerramientas.Rows.Add("RADIADOR");
                dtAccesoriosHerramientas.Rows.Add("TAPASOL");
                dtAccesoriosHerramientas.Rows.Add("PARABRISAS");
                dtAccesoriosHerramientas.Rows.Add("PERILLAS ELECTRONICAS");
                dtAccesoriosHerramientas.Rows.Add("PALA Y PICO");
                dtAccesoriosHerramientas.Rows.Add("SEGURO DE VASOS");
                dtAccesoriosHerramientas.Rows.Add("TANQUE DE AGUA");
                dtAccesoriosHerramientas.Rows.Add("TAPA DE ACEITE");
                dtAccesoriosHerramientas.Rows.Add("TAPA DIESEL");
                dtAccesoriosHerramientas.Rows.Add("TAPA DE RADIADOR");
                dtAccesoriosHerramientas.Rows.Add("TAPA DE DEP. LIQ HIDRAULICO");
                dtAccesoriosHerramientas.Rows.Add("TAPA DE DEP. LIQ FRENOS");
                dtAccesoriosHerramientas.Rows.Add("SEGURO DE RUEDAS");
                dtAccesoriosHerramientas.Rows.Add("BATERIA");
                dtAccesoriosHerramientas.Rows.Add("COPAS DE RUEDAS");
                dtAccesoriosHerramientas.Rows.Add("MOTOR LIMPIAPARABRISAS");
                dtAccesoriosHerramientas.Rows.Add("BOTIQUIN DE PRIMEROS AUXILIOS");
                dtAccesoriosHerramientas.Rows.Add("GATA TIPO: MECANICO");
                dtAccesoriosHerramientas.Rows.Add("PALANCA DE GATA");
                dtAccesoriosHerramientas.Rows.Add("CONOS DE SEGURIDAD: 02");
                dtAccesoriosHerramientas.Rows.Add("MANUAL DE CONDUCTOR");
                dtAccesoriosHerramientas.Rows.Add("CONTROL DE MANTENIMIENTO");
                dtAccesoriosHerramientas.Rows.Add("ESTUCHE DE DOCUMENTOS");
                dtAccesoriosHerramientas.Rows.Add("LINTERNA DE MANO");
                dtAccesoriosHerramientas.Rows.Add("LISTA DE EMERGENCIA");
                dtAccesoriosHerramientas.Rows.Add("LLAVE DE RUEDAS");
                dtAccesoriosHerramientas.Rows.Add("LLAVE DE BUJIAS");
                dtAccesoriosHerramientas.Rows.Add("LLAVE FRANCESA");
                dtAccesoriosHerramientas.Rows.Add("LLAVE DE BOCA 8, 12");
                dtAccesoriosHerramientas.Rows.Add("ALICATE MECANICO");
                dtAccesoriosHerramientas.Rows.Add("EXTINTOR PQS DE 02");
                dtAccesoriosHerramientas.Rows.Add("MEDIDOR DE AIRE");
                dtAccesoriosHerramientas.Rows.Add("PROTECTOR DE TOLVA");
                dtAccesoriosHerramientas.Rows.Add("PASAMANOS DE TOLVA");
                dtAccesoriosHerramientas.Rows.Add("SEGURO DE FARO CONTRAROBO");
                dtAccesoriosHerramientas.Rows.Add("TUBO CONTRAVUELCO");
                dtAccesoriosHerramientas.Rows.Add("NEBLINEROS");
            }

            dtgAccesoriosHerramientas.DataSource = dtAccesoriosHerramientas;
            dtgAccesoriosHerramientas.AllowUserToAddRows = false;

            dtgAccesoriosHerramientas.Columns["cDescripcion"].HeaderText = "DESCRIPCION";
            dtgAccesoriosHerramientas.Columns["cDescripcion"].Width = 400;
            dtgAccesoriosHerramientas.Columns["cDescripcion"].ReadOnly = true;
            dtgAccesoriosHerramientas.Columns["cSi"].HeaderText = "SI";
            dtgAccesoriosHerramientas.Columns["cNo"].HeaderText = "NO";
            dtgAccesoriosHerramientas.Columns["csi"].Width = 40;
            dtgAccesoriosHerramientas.Columns["cNo"].Width = 40;
        }
        /**
         * 
         * Divide un Datatable en una lista de datatables
         * segun la cantidad de partes
         * 
         */
        static public List<DataTable> dividirDatatable(DataTable dtPartes, int nPartes)
        {
            int nCountdtNew = dtPartes.Rows.Count / nPartes;
            int nResiduo = dtPartes.Rows.Count % nPartes;

            List<DataTable> lDtrespuesta = new List<DataTable>();

            int nIterador = 0;
            for (int i = 0; i < nPartes; i++)
            {
                int j = 0;
                DataTable dtTemporal = new DataTable();
                dtTemporal = dtPartes.Clone();
                for (; j < nCountdtNew; j++)
                {
                    dtTemporal.Rows.Add(dtPartes.Rows[nIterador].ItemArray);
                    nIterador++;
                }
                if(i < nResiduo && nResiduo != 0)
                {
                    dtTemporal.Rows.Add(dtPartes.Rows[nIterador].ItemArray);
                    nIterador++;
                }
                lDtrespuesta.Add(dtTemporal);
            }
            return lDtrespuesta;
        }

        /**
         * 
         * Convertir todos los datos que se envian a un reporte
         * en xml para guardarlos en la base de datos
         * 
         */
        static public XElement convertirReportAXml(List<ReportDataSource> dtslist, string reportpath, List<ReportParameter> paramlist)
        {
            XElement xListReportParameter = new XElement("ListReportParameter");
            paramlist.ForEach(delegate(ReportParameter item)
            {
                xListReportParameter.Add(new XElement(item.Name, item.Values));
            });

            XElement xListReportDataSource = new XElement("ListReportDataSource");
            dtslist.ForEach(delegate(ReportDataSource item)
            {
                DataTable dtItem = (DataTable)item.Value;

                // convertir DataTable a XML
                StringWriter sw = new StringWriter();
                dtItem.TableName = item.Name;
                dtItem.WriteXml(sw);
                string cDtItem = sw.ToString();

                // convertir a XElement
                XElement xDtItem = XElement.Parse(cDtItem);

                xListReportDataSource.Add(new XElement(item.Name, xDtItem));
            });

            XElement xReportPath = new XElement("reportpath", reportpath);

            XElement xReport = new XElement("report");
            xReport.Add(xReportPath);
            xReport.Add(xListReportDataSource);
            xReport.Add(xListReportParameter);
            xReport.Add(new XElement("version", "0.1"));

            return xReport;
        }
        /**
         * 
         * Convierte un objeto XElement a datatable
         * 
         */
        static public DataTable xmlADatatable(XElement xTabla)
        {
            StringReader srXmlData = new StringReader(xTabla.ToString()) ;
            DataSet dtsLector = new DataSet();
            dtsLector.ReadXml(srXmlData);
            return dtsLector.Tables[0];
        }
        public bool validarFormulario()
        {
            if (txtUnidadPlaca.Text == "")
            {
                MessageBox.Show("Ingrese numero de placa de la unidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtUnidadClase.Text == "")
            {
                MessageBox.Show("Ingrese clase de la unidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtUnidadAnioFab.Text == "")
            {
                MessageBox.Show("Ingrese Año de fabricación de la unidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtUnidadMotor.Text == "")
            {
                MessageBox.Show("Ingrese Motor de la unidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtUnidadCilindros.Text == "")
            {
                MessageBox.Show("Ingrese numero de cilindros de la unidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtKilometraje.Text == "")
            {
                MessageBox.Show("Ingrese kilometraje de la unidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtTipoCombustible.Text == "")
            {
                MessageBox.Show("Ingrese tipo de combustible de la unidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtBitacora.Text == "")
            {
                MessageBox.Show("Ingrese bitacora de la unidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtObsRecepcion.Text == "")
            {
                txtObsRecepcion.Text = " ";
            }
            if (txtObsDevVeh.Text == "")
            {
                txtObsDevVeh.Text = " ";
            }
            return true;
        }
        #endregion

        #region Eventos
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (!validarFormulario())
            {
                return;
            }

            List<DataTable> lDtAccHer = dividirDatatable(dtAccesoriosHerramientas, 4);
            List<DataTable> lDtDesCam = dividirDatatable(dtCamioneta, 3);
            List<DataTable> lDtDesLla = dividirDatatable(dtLlantas, 3);

            string reportpath = "RptFormatoCECamioneta.rdlc";

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            paramlist.Add(new ReportParameter("txtDependencia", txtDependencia.Text, false));
            paramlist.Add(new ReportParameter("cHoraSis", txtHoraSis.Text, false));
            paramlist.Add(new ReportParameter("cFechaSis", txtFechaEntrega.Text, false));
            paramlist.Add(new ReportParameter("chbTarjetaPropiedad", Convert.ToInt32(chbTarjetaPropiedad.Checked).ToString(), false));
            paramlist.Add(new ReportParameter("txtUnidadPlaca", txtUnidadPlaca.Text, false));
            paramlist.Add(new ReportParameter("chbPolizaSeguro", Convert.ToInt32(chbPolizaSeguro.Checked).ToString(), false));
            paramlist.Add(new ReportParameter("chbPlacaDelantera", Convert.ToInt32(chbPlacaDelantera.Checked).ToString(), false));
            paramlist.Add(new ReportParameter("chbPlacaTrasera", Convert.ToInt32(chbPlacaTrasera.Checked).ToString(), false));
            paramlist.Add(new ReportParameter("chbRevisionTecnica", Convert.ToInt32(chbRevisionTecnica.Checked).ToString(), false));
            paramlist.Add(new ReportParameter("txtUnidadClase", txtUnidadClase.Text, false));
            paramlist.Add(new ReportParameter("txtUnidadAnioFab", txtUnidadAnioFab.Text, false));
            paramlist.Add(new ReportParameter("txtUnidadMotor", txtUnidadMotor.Text, false));
            paramlist.Add(new ReportParameter("txtUnidadCilindros", txtUnidadCilindros.Text, false));
            paramlist.Add(new ReportParameter("txtKilometraje", txtKilometraje.Text, false));
            paramlist.Add(new ReportParameter("txtTipoCombustible", txtTipoCombustible.Text, false));
            paramlist.Add(new ReportParameter("txtBitacora", txtBitacora.Text, false));
            paramlist.Add(new ReportParameter("txtObsRecepcion", txtObsRecepcion.Text, false));
            paramlist.Add(new ReportParameter("txtObsDevVeh", txtObsDevVeh.Text, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cNomAge", clsVarGlobal.cNomAge, false));

            dtslist.Add(new ReportDataSource("LisMovActCarEnt", dtListaMovimientos));
            dtslist.Add(new ReportDataSource("dtCamioneta", lDtDesCam[0]));
            dtslist.Add(new ReportDataSource("dtCamioneta1", lDtDesCam[1]));
            dtslist.Add(new ReportDataSource("dtCamioneta2", lDtDesCam[2]));
            dtslist.Add(new ReportDataSource("dtLlantas", lDtDesLla[0]));
            dtslist.Add(new ReportDataSource("dtLlantas1", lDtDesLla[1]));
            dtslist.Add(new ReportDataSource("dtLlantas2", lDtDesLla[2]));
            dtslist.Add(new ReportDataSource("dtAccesoriosHerramientas", lDtAccHer[0]));
            dtslist.Add(new ReportDataSource("dtAccesoriosHerramientas1", lDtAccHer[1]));
            dtslist.Add(new ReportDataSource("dtAccesoriosHerramientas2", lDtAccHer[2]));
            dtslist.Add(new ReportDataSource("dtAccesoriosHerramientas3", lDtAccHer[3]));

            // guardar en base de datos
            if (MessageBox.Show("Se guardara una copia en la base de datos, asegurese que todos los campos estan completados, ¿Desea continuar?", "Registro en Base de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            idCargoEntrega = clscnactivos.CNInsertCargoEntrega(
                idCargoEntrega,
                this.nIdMovimiento,
                nIdTipoCargoEntrega,
                clsVarGlobal.User.idUsuario,
                convertirReportAXml(dtslist, reportpath, paramlist).ToString(),
                Convert.ToInt32(dtCargoEntrega.Rows[0]["nVecesImpreso"]) + 1
            );

            //initForm(nIdMovimiento);
            if (idCargoEntrega != -1)
            {
                MessageBox.Show("Se guardo una copia en la base de datos, Numero de Cargo de Entrega: " + idCargoEntrega.ToString(), "Registro en Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void dtgAccesoriosHerramientas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int nCeldasSeleccionadas = dtgAccesoriosHerramientas.GetCellCount(DataGridViewElementStates.Selected);
            if (nCeldasSeleccionadas > 0)
            {
                int nFila = dtgAccesoriosHerramientas.SelectedCells[0].RowIndex;
                int nColumna = dtgAccesoriosHerramientas.SelectedCells[0].ColumnIndex;
                if (nColumna != 0)
                {
                    if (nColumna == 1)
                    {
                        if (dtgAccesoriosHerramientas.Rows[nFila].Cells["cSi"].Value.ToString().Length != 0)
                            dtgAccesoriosHerramientas.Rows[nFila].Cells["cNo"].Value = "";
                    }
                    else
                    {
                        if (dtgAccesoriosHerramientas.Rows[nFila].Cells["cNo"].Value.ToString().Length != 0)
                            dtgAccesoriosHerramientas.Rows[nFila].Cells["cSi"].Value = "";
                    }
                }
            }
        }
        #endregion
    }
}
