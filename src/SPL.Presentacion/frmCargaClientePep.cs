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
using SPL.CapaNegocio;
using System.Collections.Generic;
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace SPL.Presentacion
{
    public partial class frmCargaClientePep : frmBase
    {
        #region Variable Globales
        
        private OpenFileDialog OpenDialog;
        DataTable tabla;
        List<string> Columnas = new List<string>();
        clsCNPep cnPep = new clsCNPep();
        int nTamDNI = 8;

        Dictionary<string, Dictionary<string, int>> dColumns = new Dictionary<string, Dictionary<string, int>>
            {
                {"idTipoDoc",	new Dictionary<string, int> { {"id Tipo Doc", 1}}},
                {"cCargo",	new Dictionary<string, int> { {"Cargo", 1}}},
                {"cNombres", new Dictionary<string, int> {{"Nombre", 1}}},
                {"cPaterno", new Dictionary<string, int> { {"Apellido Paterno", 1}}},
                {"cMaterno", new Dictionary<string, int> { {"Apellido Materno", 1}}},
                {"nDocumento", new Dictionary<string, int> { {"Nro Documento", 1}}},
                {"dFechaNac", new Dictionary<string, int> { {"Fecha de Nacimiento", 0}}},
                {"cInstitucion", new Dictionary<string, int> { {"Institución", 0}}},
                {"dFecIni", new Dictionary<string, int> { {"Periodo Inicial", 1}}},
                {"dFecFin", new Dictionary<string, int> { {"Periodo Final", 1}}},
                {"cTipoDocumento", new Dictionary<string, int> { {"Tipo Documento", 1}}},
                {"cTipoOrgPol", new Dictionary<string, int> { {"Tipo Org Politica", 0}}},
                {"cNombreOrgPol", new Dictionary<string, int> { {"Nombre Organización Politica", 0}}},
                {"cPaisNacimiento", new Dictionary<string, int> { {"País de Nacimiento", 1}}},
                {"cNacionalidad", new Dictionary<string, int> { {"Nacionalidad", 0}}},
                {"cCodPais", new Dictionary<string, int> { {"Código de País", 1}}},
                {"cCodUbigeo", new Dictionary<string, int> { {"Cod Ubigeo", 1}}},
                {"cDepartamento", new Dictionary<string, int> { {"Departamento", 1}}},
                {"cProvincia", new Dictionary<string, int> { {"Provincia", 1}}},
                {"cDistrito", new Dictionary<string, int> { {"Distrito", 1}}},
                {"cGenero", new Dictionary<string, int> { {"Genero", 1}}}
            };
        
        #endregion

        public frmCargaClientePep()
        {
            InitializeComponent();
            OpenDialog = new OpenFileDialog();
            CargarListaColumnas();
            btnGrabar1.Enabled = false;
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
        }
        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            activar(true);
            limpiar();
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiar();
            activar(false);
            btnGrabar1.Enabled = false;
            btnNuevo1.Enabled = true;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            DataSet dsGuardar = new DataSet("dsGuardar");
            DataTable dtGuardar = ((DataTable)dtgClientesCargaPep.DataSource);
            if (dtGuardar.Rows.Count == 0)
            {
                MessageBox.Show("No hay Clientes para poder cargar", "Carga de Clientes PEP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            dsGuardar.Tables.Add(dtGuardar.Copy());

            string cGuardar = dsGuardar.GetXml();

            cGuardar = clsCNFormatoXML.EncodingXML(cGuardar);
            DataTable dtResultado = cnPep.CNCargarClientesPEP(cGuardar, clsVarGlobal.dFecSystem);
            MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), "Carga de Clientes PEP", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnGrabar1.Enabled = false;
        }
        #endregion

        #region Métodos
        private void cargar()
        {
            OpenDialog.Filter = "Hojas de Excel(*.xls)|*.xls";
            OpenDialog.ShowDialog();
            txtPath.Text = OpenDialog.FileName;

            if (String.IsNullOrEmpty(txtPath.Text))
            {
                return;
            }

            try
            {
                ExcelHandler ex = new ExcelHandler();
                tabla = ex.ImportExcelToDataTable(txtPath.Text);
                tabla.Columns.Add("cDetalleError", typeof(string));

                tabla = renombrarColumnas(tabla);
                if (ValidarHoja(tabla))
                {
                    // Verificar formato del excel 
                    DataSet ds = SepararFilasValidas(tabla);

                    dtgClientesCargaPep.DataSource = ds.Tables["dtCorrecto"];
                    formatogrid(dtgClientesCargaPep, 1);

                    dtgClientesPepError.DataSource = ds.Tables["dtError"];
                    formatogrid(dtgClientesPepError, 2);
                    //contando registros
                    lblNroRegError.Text = dtgClientesPepError.RowCount.ToString() + " fila(s)";
                    lblNroRegBien.Text = dtgClientesCargaPep.RowCount.ToString() + " fila(s)";

                    btnGrabar1.Enabled = false;
                    if (dtgClientesCargaPep.Rows.Count>0)
                    {
                        btnGrabar1.Enabled = true;
                        btnNuevo1.Enabled = false;
                        btnBusqueda1.Enabled = false;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("No se ha podido cargar la hoja de Excel.", "Carga de Clientes PEP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //throw;
                limpiar();
            }
        }

        private DataTable renombrarColumnas(DataTable dt)
        {
            foreach (KeyValuePair<string, Dictionary<string, int>> item in dColumns)
            {
               // dt.Columns[item.Value[0]].ColumnName = item.Key;
                foreach (KeyValuePair<string, int> item2 in item.Value)
	            {
                    dt.Columns[item2.Key].ColumnName = item.Key;
	            }
                
                
            }
            return dt;
        }

        private bool ValidarHoja(DataTable dt)
        {
            string cColumnasFaltantes = "";
            bool lValido = true;
             foreach (KeyValuePair<string, Dictionary<string, int>> item in dColumns)
             {
                 if (!dt.Columns.Contains(item.Key))
                 {
                     foreach (KeyValuePair<string, int> item2 in item.Value)
                     {
                         cColumnasFaltantes += "\t" + item2.Key + "\n";
                         lValido = false;
                     }
                     
                 }
             }
             
            if (!lValido)
            {
                MessageBox.Show("La tabla no tiene las siguientes columnas:" + cColumnasFaltantes + " ", "Carga de Clientes PEP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPath.Text = "";
            }
            //foreach (var item in Columnas)
            //{
            //    if (!dt.Columns.Contains(item))
            //    {
            //        MessageBox.Show("La tabla no tiene la columna " + item + " ", "Carga de Clientes PEP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        txtPath.Text = "";
            //        return false;
            //    }
            //}
            return lValido;
        }

        private Boolean ValidarCamposObligatorios(DataRow dr)
        {
            int nIndice = 0;
            bool estado = true;
            string cError = "";
            foreach (KeyValuePair<string, Dictionary<string, int>> item in dColumns)
            {
                foreach (KeyValuePair<string, int> item2 in item.Value)
                {
                    if (item2.Value == 1) // valida campo obligatorio
                    {
                        if (String.IsNullOrEmpty(dr[item.Key].ToString()))
                        {
                            if(String.IsNullOrEmpty(cError))
                            {
                                cError = "Campos obligatorios: ";
                            }

                            cError +=  item.Key+ "; ";
                            estado = false;
                        }
                    }
                }
            }
            dr["cDetalleError"] = cError;
            return estado;
            //String.IsNullOrEmpty(Convert.ToString(item["nDocumento"]))
            //           || String.IsNullOrEmpty(Convert.ToString(item["cPaterno"]))
            //           || String.IsNullOrEmpty(Convert.ToString(item["cMaterno"]))
            //           || String.IsNullOrEmpty(Convert.ToString(item["cNombres"]))
            //           || String.IsNullOrEmpty(Convert.ToString(item["idTipoDoc"]))
            //           || String.IsNullOrEmpty(Convert.ToString(item["cTipoDoc"]))
            //           || String.IsNullOrEmpty(Convert.ToString(item["cCargo"]))
        }
        private DataSet SepararFilasValidas(DataTable dt)
        {
            DataSet ds = new DataSet("dsReturn");
            DataTable dtCorrecto = new DataTable("dtCorrecto");
            DataTable dtError = new DataTable("dtError");
            dtCorrecto = dt.Clone();
            dtError = dt.Clone();
            dtCorrecto.TableName = "dtCorrecto";
            dtError.TableName = "dtError";
            //agregarFilas(ref dtCorrecto);
            //agregarFilas(ref dtError);
            dtCorrecto.Clear();
            dtError.Clear();

            foreach (DataRow item in dt.Rows)
            {
                if (!ValidarCamposObligatorios(item))
                {
                    dtError.ImportRow(item);
                }
                else if (Convert.ToInt32(item["idTipoDoc"]) ==1  && item["nDocumento"].ToString().Length != nTamDNI)
                {
                    item["cDetalleError"] = "El DNI solo puede tener 8 digitos";
                    dtError.ImportRow(item);
                }
                else
                {
                    dtCorrecto.ImportRow(item);
                }
            }
            ds.Tables.Add(dtCorrecto);
            ds.Tables.Add(dtError);
            return ds;
        }

        private void agregarFilas(ref DataTable dt) 
        {
            foreach (KeyValuePair<string, Dictionary<string, int>> item in dColumns)
            {
                dt.Columns.Add(item.Key);

            }
            // foreach (KeyValuePair<string, Object> item in dColumns)
            // {
            //     dt.Columns.Add(item.Key);
            // }
            // dt.Columns.Add("cTipoDoc");
            // dt.Columns.Add("nDocumento");
            // dt.Columns.Add("cPaterno");
            // dt.Columns.Add("cMaterno");
            // dt.Columns.Add("cNombres");
            // dt.Columns.Add("cCargo");
            // dt.Columns.Add("idTipoDoc");
            
        }
        private void limpiar()
        {
            txtPath.Clear();

            if (((DataTable)dtgClientesCargaPep.DataSource) != null)
                ((DataTable)dtgClientesCargaPep.DataSource).Clear();

            if (((DataTable)dtgClientesPepError.DataSource) != null)
                ((DataTable)dtgClientesPepError.DataSource).Clear();

            lblNroRegError.Text = "";
            lblNroRegBien.Text = "";
        }

        private void activar(Boolean lBol)
        {
            btnBusqueda1.Enabled = lBol;
            dtgClientesCargaPep.Enabled = lBol;
        }
        private void CargarListaColumnas()
        {
            Columnas.Add("cTipoDoc");
            Columnas.Add("nDocumento");
            Columnas.Add("cPaterno");
            Columnas.Add("cMaterno");
            Columnas.Add("cNombres");
            Columnas.Add("cCargo");
            Columnas.Add("idTipoDoc");
        }
        private void formatogrid(DataGridView dtg, int error)
        {
            foreach (KeyValuePair<string, Dictionary<string, int>> item in dColumns)
            {
                foreach (KeyValuePair<string, int> item2 in item.Value)
                {
                    dtg.Columns[item.Key].HeaderText = item2.Key; // item.Value;    
                    dtg.Columns[item.Key].Visible = false;
                    if(item2.Value == 1) // si es obligatorio
                    {
                        dtg.Columns[item.Key].DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                    
                }
                
            }
            //dtg.Columns["dFecIni"].DefaultCellStyle.Format = "d";
            //dtg.Columns["dFecFin"].DefaultCellStyle.Format = "d";
            //dtg.Columns["dFechaNac"].DefaultCellStyle.Format = "d";

            dtg.Columns["cCargo"].Visible = true;
            dtg.Columns["cNombres"].Visible = true;
            dtg.Columns["cPaterno"].Visible = true;
            dtg.Columns["cMaterno"].Visible = true;
            dtg.Columns["nDocumento"].Visible = true;
            dtg.Columns["dFechaNac"].Visible = true;
            dtg.Columns["cInstitucion"].Visible = true;
            dtg.Columns["dFecIni"].Visible = true;
            dtg.Columns["dFecFin"].Visible = true;
            dtg.Columns["cTipoDocumento"].Visible = true;
            dtg.Columns["cTipoOrgPol"].Visible = true;
            dtg.Columns["cNombreOrgPol"].Visible = true;
            dtg.Columns["cPaisNacimiento"].Visible = true;
            dtg.Columns["cNacionalidad"].Visible = true;
            dtg.Columns["cCodPais"].Visible = true;
            dtg.Columns["cCodUbigeo"].Visible = true;
            dtg.Columns["cDepartamento"].Visible = true;
            dtg.Columns["cProvincia"].Visible = true;
            dtg.Columns["cDistrito"].Visible = true;
            dtg.Columns["cGenero"].Visible = true;
            
            dtg.Columns["cDetalleError"].Visible = (error == 1)? false : true;      
        }
        #endregion

        private void btnExporExcel1_Click(object sender, EventArgs e)
        {

            if (dtgClientesPepError.RowCount == 0)
            {
                MessageBox.Show("No hay Clientes con errores para exportar", "Carga de Clientes PEP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dtSource = ((DataTable)dtgClientesPepError.DataSource);
            if (dtSource.Rows.Count == 0)
            {
                MessageBox.Show("No se ha encontrado a un cliente pep", "Registro PEP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsPepError", dtSource));

            string reportpath = "rptExportablePepErro.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

       
    }
}
