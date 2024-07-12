using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CRE.Presentacion
{
    public partial class frmCargarMatrizAgricola : frmBase
    {
        private DataTable dtRegistro = new DataTable();

        List<clsMatrizAgricola> ltMatrizAgricola;

        clsCNEvalAgrico objCNEvalAgrico = new clsCNEvalAgrico();

        public frmCargarMatrizAgricola()
        {
            InitializeComponent();
            dtRegistro.Columns.Add("cUsuario", typeof(string));
            dtRegistro.Columns.Add("cPerfil", typeof(char));
            dtRegistro.Columns.Add("cAgencia", typeof(char));
            dtRegistro.Columns.Add("dFechaHoraRegistro", typeof(char));
            this.cargarRegistros();
            this.btnRegistrarMatriz.Enabled = false;
        }

        #region métodos privados
        private void cargarRegistros()
        {
            this.dtgRegistro.DataSource = this.objCNEvalAgrico.dtRegistroMatriz();
        }

        private void seleccionarArchivo()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string nombreArchivo = openFileDialog.SafeFileName;
                string rutaArchivo = openFileDialog.FileName;

                this.lblNombreArchivo.Text = nombreArchivo;
                this.cargarArchivo(rutaArchivo);
            }
        }

        private void cargarArchivo(string rutaArchivo)
        {
            try   
            {  
                Excel.Application excel = new Excel.Application();
                Excel.Workbook libro = excel.Workbooks.Open(rutaArchivo);  
  
                string nombreLibro = libro.Name; 
                int contadorHojas = libro.Worksheets.Count;  
  
                Excel.Worksheet hojaMatrizAgricola = (Excel.Worksheet) libro.Worksheets[1];
                this.leerMatrizEXCEL(hojaMatrizAgricola);
            }
            catch (Exception ex)   
            {  
                MessageBox.Show(ex.Message);
            }
        }

        private List<string> ltValorRango(Excel.Worksheet hojaEXCEL, int nFila, int nColumna)
        {
            string cTexto = ((Excel.Range)hojaEXCEL.Cells[nFila, nColumna]).Text.Trim();
            if (string.IsNullOrEmpty(cTexto))
                throw new SystemException(string.Format("Se encontró un valor vacío/nulo: fila {0} - columna - {1}", nFila, nColumna));
            //else if (Regex.IsMatch(cTexto, @"\s+[yYoO]\s+"))
            //{
            //    var result = MessageBox.Show(
            //        string.Format("Se debe usar una coma (,) como separador.\n\nContenido: {0}\n\nCelda: Fila {1} - Columna - {2}\n\n¿Desea continuar?", cTexto, nFila, nColumna),
            //        "Advertencia",
            //        MessageBoxButtons.YesNo,
            //        MessageBoxIcon.Warning
            //    );
            //    if (result == DialogResult.Yes)
            //        return cTexto.Split(',').Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToList();
            //    else
            //        throw new SystemException(string.Format("Se debe usar una coma (,) como separador: fila {0} - columna - {1}", nFila, nColumna));
            //}
            //return new List<string>();
            return cTexto.Split(',').Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToList();
        }

        private string cValorRango(Excel.Worksheet hojaEXCEL, int nFila, int nColumna)
        {
            string cTexto = ((Excel.Range)hojaEXCEL.Cells[nFila, nColumna]).Text.Trim();
            if (string.IsNullOrEmpty(cTexto))
                throw new SystemException(string.Format("Se encontró un valor vacío/nulo: fila {0} - columna - {1}", nFila, nColumna));
            else
                return cTexto;
        }

        private decimal? nDecimal(string cCadena)
        {
            if (Regex.IsMatch(cCadena.Trim(), @"[\.|,|\d]"))
                return decimal.Parse(cCadena);
            else
                return null;
        }

        private void leerMatrizEXCEL(Excel.Worksheet hojaEXCEL)
        {
            this.ltMatrizAgricola = new List<clsMatrizAgricola>();
            clsMatrizAgricola objMatrizAgricolaTMP;
            List<string> ltOficinaTMP, ltVariedadCultivoTMP;
            string cPorcentajeTMP;

            try
            {
                for (int i = 3; !string.IsNullOrEmpty(((Excel.Range)hojaEXCEL.Cells[i, 3]).Text); i++)
                {
                    objMatrizAgricolaTMP = new clsMatrizAgricola();
                    objMatrizAgricolaTMP.cCultivoEval = this.cValorRango(hojaEXCEL, i, 4);
                    objMatrizAgricolaTMP.cTipoFinanciamientoCultivo = this.cValorRango(hojaEXCEL, i, 5);
                    objMatrizAgricolaTMP.cTipoCultivo = this.cValorRango(hojaEXCEL, i, 7);
                    objMatrizAgricolaTMP.nPeriodoFenologico = int.Parse(this.cValorRango(hojaEXCEL, i, 8));
                    objMatrizAgricolaTMP.nPeriodoComercializacion = int.Parse(this.cValorRango(hojaEXCEL, i, 9));
                    objMatrizAgricolaTMP.nPlazoCredito = int.Parse(this.cValorRango(hojaEXCEL, i, 10));
                    objMatrizAgricolaTMP.nFrecuenciaPago = int.Parse(this.cValorRango(hojaEXCEL, i, 11));
                    objMatrizAgricolaTMP.nCostoProduccionMN = this.nDecimal(this.cValorRango(hojaEXCEL, i, 12));
                    objMatrizAgricolaTMP.cRiesgoEvalCultivo = this.cValorRango(hojaEXCEL, i, 13);
                    cPorcentajeTMP = Regex.Replace(this.cValorRango(hojaEXCEL, i, 14), @"%", "");
                    objMatrizAgricolaTMP.nPorcentajeFinanciamiento = this.nDecimal(cPorcentajeTMP);
                    objMatrizAgricolaTMP.nMontoFinanciamientoMN = this.nDecimal(this.cValorRango(hojaEXCEL, i, 15));
                    objMatrizAgricolaTMP.nRendimiento = this.nDecimal(this.cValorRango(hojaEXCEL, i, 16));
                    objMatrizAgricolaTMP.cUnidadMedida = this.cValorRango(hojaEXCEL, i, 17);
                    objMatrizAgricolaTMP.nPrecioUnidadMN = this.nDecimal(this.cValorRango(hojaEXCEL, i, 18));
                    objMatrizAgricolaTMP.nIngresoVentasMN = this.nDecimal(this.cValorRango(hojaEXCEL, i, 19));
                    objMatrizAgricolaTMP.nUtilidadMN = this.nDecimal(this.cValorRango(hojaEXCEL, i, 20));
                    cPorcentajeTMP = Regex.Replace(this.cValorRango(hojaEXCEL, i, 21), @"%", "");
                    objMatrizAgricolaTMP.nRentabilidad = this.nDecimal(cPorcentajeTMP);

                    ltOficinaTMP = this.ltValorRango(hojaEXCEL, i, 3);
                    ltVariedadCultivoTMP = this.ltValorRango(hojaEXCEL, i, 6);

                    foreach (string cOficina in ltOficinaTMP)
                    {
                        foreach (string cVariedad in ltVariedadCultivoTMP)
                        {
                            objMatrizAgricolaTMP.cAgencia = cOficina;
                            objMatrizAgricolaTMP.cVariedadCultivoEval = cVariedad;
                            this.ltMatrizAgricola.Add(objMatrizAgricolaTMP.Copia());
                        }
                    }
                }

                this.btnRegistrarMatriz.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al leer la Matriz Agrícola");
                return;
            }
        }

        private void registrarMatriz()
        {
            if (this.ltMatrizAgricola == null)
                return;

            try
            {
                string xmlMatrizAgricola = this.ltMatrizAgricola.ListObjectToXml<clsMatrizAgricola>("clsMatrizAgricola", "dsDataSet");
                DataTable dt = this.objCNEvalAgrico.dtRegistrarMatrizAgricola(
                    xmlMatrizAgricola,
                    clsVarGlobal.PerfilUsu.idUsuario,
                    clsVarGlobal.nIdAgencia,
                    clsVarGlobal.PerfilUsu.idPerfil
                );

                MessageBox.Show("Se registró correctamente");

                this.cargarRegistros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al registrar la Matriz Agrícola");
            }
        }
        #endregion

        #region eventos
        private void frmCargarMatrizAgricola_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
        }

        private void btnSeleccionarArchivo_Click(object sender, EventArgs e)
        {
            this.seleccionarArchivo();
        }

        private void btnRegistrarMatriz_Click(object sender, EventArgs e)
        {
            this.registrarMatriz();
        }
        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
