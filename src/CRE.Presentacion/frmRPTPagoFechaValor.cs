using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmRPTPagoFechaValor : frmBase
    {
        #region Variables Globales

        private const string cTituloForm = "Reporte de Pagos con Fecha Valor";
        private readonly clsCNFechaValor clsCNFechaValor = new clsCNFechaValor();

        #endregion

        #region Constructor

        public frmRPTPagoFechaValor()
        {
            InitializeComponent();
        }

        #endregion

        #region Métodos Privados

        private bool Validar()
        {
            if (dtpDesde.Value > dtpHasta.Value)
            {
                MessageBox.Show("La fecha \"Desde\" no debe ser posterior a la fecha \"Hasta\"", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void PintarDatosGridView(List<clsRPTCabecereFechaValor> lsRPTCabecereFechaValor)
        {
            foreach (clsRPTCabecereFechaValor item in lsRPTCabecereFechaValor)
            {
                dtgDatos.Rows.Add(item.idRegistro, item.cMotivo, item.cSustento, item.cWinUser, item.dFechaValor, item.cNombreArchivo, item.bArchivoBinary);
            }
        }

        private void ConfigurarDataGridView()
        {
            dtgDatos.Columns.Clear();
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "idRegistro", HeaderText = "ID", ReadOnly = true, Visible = false });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "cMotivo", HeaderText = "Motivo", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "cSustento", HeaderText = "Sustento", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "cWinUser", HeaderText = "Usuario", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "dFechaValor", HeaderText = "Fecha Valor", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }, ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "cNombreArchivo", HeaderText = "Nombre Archivo", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "bArchivoBinaryHidden", HeaderText = "Plantilla Oculta", ReadOnly = true, Visible = false  });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "lstSustento", HeaderText = "Archivos Sustento", ReadOnly = true });
            dtgDatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "lstDetalle", HeaderText = "Ver Detalle", ReadOnly = true });

            //Ajusto las columnas y filas al contenido
            dtgDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgDatos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //Habilito scroll
            dtgDatos.ScrollBars = ScrollBars.Both;
        }

        private void MostrarReporteDetalle(int idRegistro)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DataTable dtDatosReporte = clsCNFechaValor.CNListarDetallePagosRealizados(idRegistro);

            if (dtDatosReporte.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            paramlist.Add(new ReportParameter("cNomEmp", clsVarApl.dicVarGen["cNomEmpresa"], false));
            paramlist.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cUsuWin", clsVarGlobal.User.cNomUsu, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            dtslist.Add(new ReportDataSource("dsRPTDetallePagosFechaValor", dtDatosReporte));

            string reportpath = "rptDetallePagosFechaValor.rdlc";

            frmReporteLocal frmReporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmReporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            frmReporte.ShowDialog();
        }

        private void MostrarSustentos(int idRegistro)
        {
            List<clsArchivoCargadoFechaValor> lsRPTSustento = clsCNFechaValor.CNListarSustentos(idRegistro);

            if (lsRPTSustento.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmCargarArchivosFechaValor frmRPTSustento = new frmCargarArchivosFechaValor(lsRPTSustento, Name);
            frmRPTSustento.ShowDialog();
        }

        private List<clsRPTCabecereFechaValor> CargarDatos()
        {
            try
            {
                return clsCNFechaValor.CNListarPagosRealizados(dtpDesde.Value, dtpHasta.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<clsRPTCabecereFechaValor>();
            }
        }

        #endregion

        #region Métodos Públicos

        #endregion

        #region Eventos

        private void frmRPTPagoFechaValor_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
        }

        private void btnBucar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validar())
                    return;

                dtgDatos.Rows.Clear();

                List<clsRPTCabecereFechaValor> lsRPTCabecereFechaValor = CargarDatos();

                if (lsRPTCabecereFechaValor.Count == 0)
                {
                    MessageBox.Show("No se encontraron registros", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ConfigurarDataGridView();
                PintarDatosGridView(lsRPTCabecereFechaValor);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar datos: {ex.Message}", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            dtgDatos.Columns.Clear();
        }

        private void dtgDatos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verificar si la columna es la que contiene el nombre del archivo ("cNombreArchivo")
            if (e.ColumnIndex == dtgDatos.Columns["cNombreArchivo"].Index)
            {
                // Convertir la celda en un enlace
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Underline);
                e.CellStyle.ForeColor = Color.Blue;
            }

            //Verificar si la columna es "lstSustento"
            if (e.ColumnIndex == dtgDatos.Columns["lstSustento"].Index)
            {
                // Convertir la celda en un enlace
                e.Value = "Ver"; // Texto del enlace
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Underline);
                e.CellStyle.ForeColor = Color.Blue;
            }

            // Verificar si la columna es "lstDetalle"
            if (e.ColumnIndex == dtgDatos.Columns["lstDetalle"].Index)
            {
                // Convertir la celda en un enlace
                e.Value = "Imprimir"; // Texto del enlace
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Underline);
                e.CellStyle.ForeColor = Color.Blue;
            }
        }

        private void dtgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region Plantilla

                if (e.ColumnIndex == dtgDatos.Columns["cNombreArchivo"].Index && e.RowIndex >= 0)
                {
                    string nombreArchivo = dtgDatos.Rows[e.RowIndex].Cells["cNombreArchivo"].Value?.ToString();
                    byte[] archivoBinary = (byte[])dtgDatos.Rows[e.RowIndex].Cells["bArchivoBinaryHidden"].Value;

                    if (archivoBinary.Length > 0)
                    {
                        if (string.IsNullOrEmpty(nombreArchivo))
                        {
                            nombreArchivo = $"Plantilla_FV_{Guid.NewGuid()}.xlsx";
                        }
                        else
                        {
                            nombreArchivo = $"{nombreArchivo}";
                        }
                        string rutaArchivo = Path.Combine(Path.GetTempPath(), nombreArchivo);

                        File.WriteAllBytes(rutaArchivo, archivoBinary);
                        Process.Start(rutaArchivo);
                    }
                    else
                    {
                        MessageBox.Show("El archivo de la plantilla está vacío.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                #endregion

                #region Sustentos
                try
                {
                    if (e.ColumnIndex == dtgDatos.Columns["lstSustento"].Index && e.RowIndex >= 0)
                    {
                        int idRegistro = (int)dtgDatos.Rows[e.RowIndex].Cells["idRegistro"].Value;
                        MostrarSustentos(idRegistro);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al mostrar los sustentos: {ex.Message}", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                #endregion

                #region Detalle

                try
                {
                    if (e.ColumnIndex == dtgDatos.Columns["lstDetalle"].Index && e.RowIndex >= 0)
                    {
                        int idRegistro = (int)dtgDatos.Rows[e.RowIndex].Cells["idRegistro"].Value;
                        MostrarReporteDetalle(idRegistro);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al mostrar el detalle: {ex.Message}", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al descargar el archivo: {ex.Message}", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgDatos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgDatos.Rows.Count == 0)
                return;

            if (e.ColumnIndex == dtgDatos.Columns["cNombreArchivo"].Index || e.ColumnIndex == dtgDatos.Columns["lstDetalle"].Index || e.ColumnIndex == dtgDatos.Columns["lstSustento"].Index && e.RowIndex >= 0)
            {
                dtgDatos.Cursor = Cursors.Hand;
            }
        }

        private void dtgDatos_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            dtgDatos.Cursor = Cursors.Default;
        }

        #endregion
    }
}