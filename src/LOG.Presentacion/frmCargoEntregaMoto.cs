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
using System.Xml.Linq;

// CoreBank
using GEN.ControlesBase;
using LOG.CapaNegocio;
using EntityLayer;
#endregion


namespace LOG.Presentacion
{
    public partial class frmCargoEntregaMoto : frmBase
    {
        #region Variables
        clsCNActivos clscnactivos = new clsCNActivos();
        DataTable dtListaMovimientos;
        DataTable dtLisPartesAccesorios = new DataTable();
        int nIdMovimiento;
        const int nIdTipoCargoEntrega = 5;
        int idCargoEntrega = -1;
        DataTable dtCargoEntrega = new DataTable(); // para actualizar
        #endregion
        
        #region Constructor
        public frmCargoEntregaMoto()
        {
            InitializeComponent();
        }

        public frmCargoEntregaMoto(int nIdMovimiento)
        {
            InitializeComponent();
            initForm(nIdMovimiento);
        }
        #endregion

        #region Metodos
        public void initForm(int nIdMovimiento)
        {
            this.nIdMovimiento = nIdMovimiento;
            dtListaMovimientos = clscnactivos.CNLisMovActCarEnt(nIdMovimiento);
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

            dtLisPartesAccesorios = new DataTable();
            txtFechaEntrega.Text = clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy");
            txtOficinaActivo.Text = dtListaMovimientos.Rows[0]["cNombreAgeA"].ToString();
            txtMotoMarca.Text = dtListaMovimientos.Rows[0]["cMarca"].ToString();
            txtMotoModelo.Text = dtListaMovimientos.Rows[0]["cModelo"].ToString();
            txtMotoSerie.Text = dtListaMovimientos.Rows[0]["cSerie"].ToString();
            txtMotoColor.Text = dtListaMovimientos.Rows[0]["cColor"].ToString();
            txtNombreColaborador.Text = dtListaMovimientos.Rows[0]["cNombre"].ToString();
            txtCargoColaborador.Text = dtListaMovimientos.Rows[0]["cCargo"].ToString();

            string[] aColumnas = new string[] { "cDescripcion", "cSi", "cNo", "cRoto", "cNumero", "cObservacion" };
            dtLisPartesAccesorios = frmCargoEntregaCamionetas.cargarColumnas(dtLisPartesAccesorios, aColumnas);

            if (idCargoEntrega != -1)
            {
                XElement xReporte = XElement.Parse(dtCargoEntrega.Rows[0]["xDetalles"].ToString());
                XElement xListReportParameter = xReporte.Element("ListReportParameter");
                XElement xListReportDataSource = xReporte.Element("ListReportDataSource");

                dtLisPartesAccesorios.Merge(
                    frmCargoEntregaCamionetas.xmlADatatable(
                        xListReportDataSource.Element("dtLisPartesAccesorios").Element("DocumentElement")
                    )
                );

                txtFechaEntrega.Text = xListReportParameter.Element("dFechaSistema").Value.ToString();
                txtLicConducir.Text = xListReportParameter.Element("txtLicConducir").Value.ToString();
                txtLicClase.Text = xListReportParameter.Element("txtLicClase").Value.ToString();
                txtLicCategoria.Text = xListReportParameter.Element("txtLicCategoria").Value.ToString();
                txtMotoMotor.Text = xListReportParameter.Element("txtMotoMotor").Value.ToString();
                txtMotoPlaca.Text = xListReportParameter.Element("txtMotoPlaca").Value.ToString();
                txtMotoAnioFab.Text = xListReportParameter.Element("txtMotoAnioFab").Value.ToString();
                txtKilometraje.Text = xListReportParameter.Element("txtKilometraje").Value.ToString();

            }
            else 
            {
                dtLisPartesAccesorios.Rows.Add("TARJETA DE PROPIEDAD", " ", " ", " ", " ", " ");
                dtLisPartesAccesorios.Rows.Add("TARJETA SOAT", " ", " ", " ", " ", " ");
                dtLisPartesAccesorios.Rows.Add("CARGO", " ", " ", " ", " ", " ");
                dtLisPartesAccesorios.Rows.Add("LLAVE ORIGINAL", " ", " ", " ", " ", " ");
                dtLisPartesAccesorios.Rows.Add("PLACA", " ", " ", " ", " ", " ");
                dtLisPartesAccesorios.Rows.Add("ESPEJOS EXTERIORES", " ", " ", " ", " ", " ");
                dtLisPartesAccesorios.Rows.Add("ESTUCHE DE HERRAMIENTAS", " ", " ", " ", " ", " ");
                dtLisPartesAccesorios.Rows.Add("ALICATE", " ", " ", " ", " ", " ");
                dtLisPartesAccesorios.Rows.Add("DESARMADOR", " ", " ", " ", " ", " ");
                dtLisPartesAccesorios.Rows.Add("LLAVE DE BOCA", " ", " ", " ", " ", " ");
                dtLisPartesAccesorios.Rows.Add("LLAVE DE BOCA", " ", " ", " ", " ", " ");
                dtLisPartesAccesorios.Rows.Add("TAPA DE GASOLINA", " ", " ", " ", " ", " ");
                dtLisPartesAccesorios.Rows.Add("FUNCIONAMIENTO DE LUCES", " ", " ", " ", " ", " ");
                dtLisPartesAccesorios.Rows.Add("FAROS DELANTEROS", " ", " ", " ", " ", " ");
                dtLisPartesAccesorios.Rows.Add("FAROS POSTERIORES", " ", " ", " ", " ", " ");
                dtLisPartesAccesorios.Rows.Add("DIRECCIONALES", " ", " ", " ", " ", " ");
                dtLisPartesAccesorios.Rows.Add("BATERIA", " ", " ", " ", " ", " ");
                dtLisPartesAccesorios.Rows.Add("BOCINA", " ", " ", " ", " ", " ");
                dtLisPartesAccesorios.Rows.Add("CUADERNO BITACORA", " ", " ", " ", " ", " ");
                dtLisPartesAccesorios.Rows.Add("HOLOGRAMA", " ", " ", " ", " ", " ");
                dtLisPartesAccesorios.Rows.Add("MANUAL DE USUARIO, LIBRO DE SERVICIOS Y GARANTIA", " ", " ", " ", " ", " ");            
            }

            dtgPartesAccesorios.DataSource = dtLisPartesAccesorios;
            dtgPartesAccesorios.AllowUserToAddRows = false;

            dtgPartesAccesorios.Columns["cDescripcion"].HeaderText = "PARTES Y ACCESORIOS";
            dtgPartesAccesorios.Columns["cDescripcion"].Width = 180;
            dtgPartesAccesorios.Columns["cDescripcion"].ReadOnly = true;
            dtgPartesAccesorios.Columns["cSi"].HeaderText = "SI";
            dtgPartesAccesorios.Columns["cNo"].HeaderText = "NO";
            dtgPartesAccesorios.Columns["cRoto"].HeaderText = "ROTO";
            dtgPartesAccesorios.Columns["cNumero"].HeaderText = "NUMERO";
            dtgPartesAccesorios.Columns["cObservacion"].HeaderText = "OBSERVACION";

        }
        public bool validarFormulario()
        {
            if (txtLicConducir.Text == "")
            {
                MessageBox.Show("Ingrese licencia de conducir del responsable", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtLicClase.Text == "")
            {
                MessageBox.Show("Ingrese la clase del responsable", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtLicCategoria.Text == "")
            {
                MessageBox.Show("Ingrese categoria del responsable", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtMotoMotor.Text == "")
            {
                MessageBox.Show("Ingrese motor de la unidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtMotoPlaca.Text == "")
            {
                MessageBox.Show("Ingrese placa de la unidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtMotoAnioFab.Text == "")
            {
                MessageBox.Show("Ingrese año de fabricación de la unidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (txtKilometraje.Text == "")
            {
                MessageBox.Show("Ingrese kilometraje de la unidad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
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
            string reportpath = "RptFormatoCEMoto.rdlc";
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            paramlist.Add(new ReportParameter("dFechaSistema", txtFechaEntrega.Text, false));
            paramlist.Add(new ReportParameter("txtLicConducir", txtLicConducir.Text, false));
            paramlist.Add(new ReportParameter("txtLicCategoria", txtLicCategoria.Text, false));
            paramlist.Add(new ReportParameter("txtLicClase", txtLicClase.Text, false));
            paramlist.Add(new ReportParameter("tmrLicFecRevalidacion", tmrLicFecRevalidacion.Text, false));
            paramlist.Add(new ReportParameter("txtMotoMotor", txtMotoMotor.Text, false));
            paramlist.Add(new ReportParameter("txtMotoSerie", txtMotoSerie.Text, false));
            paramlist.Add(new ReportParameter("txtMotoPlaca", txtMotoPlaca.Text, false));
            paramlist.Add(new ReportParameter("txtMotoAnioFab", txtMotoAnioFab.Text, false));
            paramlist.Add(new ReportParameter("txtKilometraje", txtKilometraje.Text, false));

            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cNomAge", clsVarGlobal.cNomAge, false));

            dtslist.Add(new ReportDataSource("LisMovActCarEnt", dtListaMovimientos));
            dtslist.Add(new ReportDataSource("dtLisPartesAccesorios", dtLisPartesAccesorios));

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
                frmCargoEntregaCamionetas.convertirReportAXml(dtslist, reportpath, paramlist).ToString(),
                Convert.ToInt32(dtCargoEntrega.Rows[0]["nVecesImpreso"]) + 1
            );

            if (idCargoEntrega != -1)
            {
                MessageBox.Show("Se guardo una copia en la base de datos, Numero de Cargo de Entrega: " + idCargoEntrega.ToString(), "Registro en Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }


        private void dtgPartesAccesorios_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int nCeldasSeleccionadas = dtgPartesAccesorios.GetCellCount(DataGridViewElementStates.Selected);
            if (nCeldasSeleccionadas > 0)
            {
                int nFila = dtgPartesAccesorios.SelectedCells[0].RowIndex;
                int nColumna = dtgPartesAccesorios.SelectedCells[0].ColumnIndex;
                if (nColumna != 0)
                {
                    if (nColumna == 1)
                    {
                        if (dtgPartesAccesorios.Rows[nFila].Cells["cSi"].Value.ToString().Length != 0)
                            dtgPartesAccesorios.Rows[nFila].Cells["cNo"].Value = "";
                    }
                    else if (nColumna == 2)
                    {
                        if (dtgPartesAccesorios.Rows[nFila].Cells["cNo"].Value.ToString().Length != 0)
                            dtgPartesAccesorios.Rows[nFila].Cells["cSi"].Value = "";
                    }
                }
            }
        }
        #endregion
    }
}
