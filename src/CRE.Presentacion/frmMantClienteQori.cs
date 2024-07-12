using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using EntityLayer;
using CRE.CapaNegocio;
using GEN.Funciones;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using CLI.Servicio;
using GEN.Servicio;
using System.Text;
using System.Data.OleDb;

namespace CRE.Presentacion
{
    public partial class frmMantClienteQori : frmBase
    {
        
        #region Variables Globales

        clsCNBuscarCli listarCli = new clsCNBuscarCli();
        string cTituloMsjes = "Mantenimiento de Clientes Q'ori";
        #endregion



        #region Eventos

        public frmMantClienteQori()
        {
            InitializeComponent();

        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Se procesará haciendo un recálculo sobre todos los clientes en la tabla, a fin de reasignar los plazos y montos de acuerdo a su actual situación.\n ¿Está seguro de realizar esta operación?", cTituloMsjes, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                recalcularMontosPlazos();
            }
            else
            {
                return;
            }
            


        }
        private void btnDescargar1_Click(object sender, EventArgs e)
        {
            exportarDataGridViewExcel();
        }

        private void btnCargarFile1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Documentos(*.xls, *.xlsx ) | *.xls; *.xlsx";
            string cRuta = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                cRuta = ofd.FileName;
                string cConnnectionOle = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = " + cRuta + ";Extended Properties = " + '"' + "Excel 12.0 Xml;HDR = YES" + '"';
                string cConsultaSqlExcel = "Select * From [Hoja1$]";
                DataTable DS = new DataTable();
                OleDbConnection oledbConn = new OleDbConnection(cConnnectionOle);
                try
                {
                    oledbConn.Open();
                    OleDbCommand oledbCmd = new OleDbCommand(cConsultaSqlExcel, oledbConn);
                    OleDbDataAdapter da = new OleDbDataAdapter(oledbCmd);

                    da.Fill(DS);
                    dtgCargaClientes.DataSource = DS;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void btnGrabar2_Click(object sender, EventArgs e)
        {
            insertarNuevosClientes();
        }

        private void btnCancelar3_Click(object sender, EventArgs e)
        {
            dtgCargaClientes.DataSource = null;
        }

        private void frmMantClienteQori_Load(object sender, EventArgs e)
        {
            cargarClientesQori();
            cargarAsesorQori();
            cargarCreditosQori();
        }

        
        #endregion



        #region Metodos

        private void cargarClientesQori()
        {
            
            DataTable dtClientes = new DataTable();
            dtClientes = listarCli.CNListarClientesQori();

            if (dtClientes.Rows.Count == 0)
            {
                MessageBox.Show("No existen Clientes Qori.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                dtgClientesQ.DataSource = null;
                dtgClientesQ.Enabled = false;
            }
            else
            {
                dtgClientesQ.Enabled = true;
                dtgClientesQ.DataSource = dtClientes;
                formatearGridClientes();
              
            }
       
        }
        
        private void formatearGridClientes()
        {
            foreach (DataGridViewColumn column in this.dtgClientesQ.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgClientesQ.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dtgClientesQ.Columns["idCli"].Visible = true;
            dtgClientesQ.Columns["cNombre"].Visible = true;
            dtgClientesQ.Columns["cClasifInterna"].Visible = true;
            dtgClientesQ.Columns["cWinUser"].Visible = true;
            dtgClientesQ.Columns["nPlazoCapitalTrabajo"].Visible = true;
            dtgClientesQ.Columns["nPlazoActivoFijo"].Visible = true;
            dtgClientesQ.Columns["nTasa"].Visible = true;
            dtgClientesQ.Columns["nMontoPreAprobado"].Visible = true;
            dtgClientesQ.Columns["nMonto"].Visible = true;
            dtgClientesQ.Columns["nPlazoCapitalTrabajoPreAprobado"].Visible = true;
            dtgClientesQ.Columns["nPlazoActivoFijoPreAprobado"].Visible = true;

            dtgClientesQ.Columns["idCli"].Width = 60;
            dtgClientesQ.Columns["cNombre"].Width = 200;
            dtgClientesQ.Columns["cClasifInterna"].Width = 60;
            dtgClientesQ.Columns["cWinUser"].Width = 100;
            dtgClientesQ.Columns["nPlazoCapitalTrabajo"].Width = 100;
            dtgClientesQ.Columns["nPlazoActivoFijo"].Width = 100;
            dtgClientesQ.Columns["nTasa"].Width = 100;
            dtgClientesQ.Columns["nMontoPreAprobado"].Width = 100;
            dtgClientesQ.Columns["nMonto"].Width = 100;
            dtgClientesQ.Columns["nPlazoCapitalTrabajoPreAprobado"].Width = 100;
            dtgClientesQ.Columns["nPlazoActivoFijoPreAprobado"].Width = 100;
                        
            dtgClientesQ.Columns["idCli"].HeaderText = "Nro Cliente";
            dtgClientesQ.Columns["cNombre"].HeaderText = "Nombre";
            dtgClientesQ.Columns["cClasifInterna"].HeaderText = "Clasif.Interna";
            dtgClientesQ.Columns["cWinUser"].HeaderText = "Asesor";
            dtgClientesQ.Columns["nPlazoCapitalTrabajo"].HeaderText = "Plazo Capital Trabajo";
            dtgClientesQ.Columns["nPlazoActivoFijo"].HeaderText = "Plazo Activo Fijo";
            dtgClientesQ.Columns["nTasa"].HeaderText = "Tasa";
            dtgClientesQ.Columns["nMontoPreAprobado"].HeaderText = "Monto PreAprobado";
            dtgClientesQ.Columns["nMonto"].HeaderText = "Monto";
            dtgClientesQ.Columns["nPlazoCapitalTrabajoPreAprobado"].HeaderText = "Plazo Capital Trabajo PreAprobado";
            dtgClientesQ.Columns["nPlazoActivoFijoPreAprobado"].HeaderText = "Plazo Activo Fijo PreAprobado";

            dtgClientesQ.Refresh();

        }
        private void cargarAsesorQori()
        {

            DataTable dtAsesor = new DataTable();
            dtAsesor = listarCli.CNListarAsesorQori();

            if (dtAsesor.Rows.Count == 0)
            {
                MessageBox.Show("No existen Asesores Qori.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                dtgAsesor.DataSource = null;
                dtgAsesor.Enabled = false;
            }
            else
            {
                dtgAsesor.Enabled = true;
                dtgAsesor.DataSource = dtAsesor;
                formatearGridAsesor();

            }
        }
        private void cargarCreditosQori()
        {

            DataTable dtCreditos = new DataTable();
            dtCreditos = listarCli.CNListarCreditoQori();

            if (dtCreditos.Rows.Count == 0)
            {
                MessageBox.Show("No existen Créditos Qori.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                dtgListadoCreditos.DataSource = null;
                dtgListadoCreditos.Enabled = false;
            }
            else
            {
                dtgListadoCreditos.Enabled = true;
                dtgListadoCreditos.DataSource = dtCreditos;
                formatearGridCreditos();

            }


        }
        private void formatearGridAsesor()
        {
            foreach (DataGridViewColumn column in this.dtgAsesor.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgAsesor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dtgAsesor.Columns["idUsuario"].Visible = true;
            dtgAsesor.Columns["cNombre"].Visible = true;
            dtgAsesor.Columns["cWinUser"].Visible = true;
            dtgAsesor.Columns["cEstado"].Visible = true;
            dtgAsesor.Columns["nCantidad"].Visible = true;

            dtgAsesor.Columns["idUsuario"].Width = 60;
            dtgAsesor.Columns["cNombre"].Width = 250;
            dtgAsesor.Columns["cWinUser"].Width = 200;
            dtgAsesor.Columns["cEstado"].Width = 100;
            dtgAsesor.Columns["nCantidad"].Width = 60;

            dtgAsesor.Columns["idUsuario"].HeaderText = "ID Usuario";
            dtgAsesor.Columns["cNombre"].HeaderText = "Nombre";
            dtgAsesor.Columns["cWinUser"].HeaderText = "Identificador";
            dtgAsesor.Columns["cEstado"].HeaderText = "Estado Créditos";
            dtgAsesor.Columns["nCantidad"].HeaderText = "Cantidad";

            dtgAsesor.Refresh();
        }
        private void formatearGridCreditos()
        {
            foreach (DataGridViewColumn column in this.dtgListadoCreditos.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgListadoCreditos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dtgListadoCreditos.Columns["idCuenta"].Visible = true;
            dtgListadoCreditos.Columns["idCli"].Visible = true;
            dtgListadoCreditos.Columns["cNombre"].Visible = true;
            dtgListadoCreditos.Columns["cProducto"].Visible = true;
            dtgListadoCreditos.Columns["cEstado"].Visible = true;
            dtgListadoCreditos.Columns["nCapitalDesembolso"].Visible = true;
            dtgListadoCreditos.Columns["nCapitalPagado"].Visible = true;
            dtgListadoCreditos.Columns["nAtraso"].Visible = true;
            dtgListadoCreditos.Columns["cWinUser"].Visible = true;
            dtgListadoCreditos.Columns["dFechaDesembolso"].Visible = true;
            dtgListadoCreditos.Columns["dFechaCancelacion"].Visible = true;
            dtgListadoCreditos.Columns["dFechaCulminacion"].Visible = true;

            dtgListadoCreditos.Columns["idCuenta"].Width = 70;
            dtgListadoCreditos.Columns["idCli"].Width = 70;
            dtgListadoCreditos.Columns["cNombre"].Width = 250;
            dtgListadoCreditos.Columns["cProducto"].Width = 150;
            dtgListadoCreditos.Columns["cEstado"].Width = 100;
            dtgListadoCreditos.Columns["nCapitalDesembolso"].Width = 100;
            dtgListadoCreditos.Columns["nCapitalPagado"].Width = 100;
            dtgListadoCreditos.Columns["nAtraso"].Width = 100;
            dtgListadoCreditos.Columns["cWinUser"].Width = 100;
            dtgListadoCreditos.Columns["dFechaDesembolso"].Width = 100;
            dtgListadoCreditos.Columns["dFechaCancelacion"].Width = 100;
            dtgListadoCreditos.Columns["dFechaCulminacion"].Width = 100;

            dtgListadoCreditos.Columns["idCuenta"].HeaderText = "Nro Cuenta";
            dtgListadoCreditos.Columns["idCli"].HeaderText = "Id Cliente";
            dtgListadoCreditos.Columns["cNombre"].HeaderText = "Nombre Cliente";
            dtgListadoCreditos.Columns["cProducto"].HeaderText = "Producto";
            dtgListadoCreditos.Columns["cEstado"].HeaderText = "Est. Crédito";
            dtgListadoCreditos.Columns["nCapitalDesembolso"].HeaderText = "Cap. Desembolsado";
            dtgListadoCreditos.Columns["nCapitalPagado"].HeaderText = "Cap. Pagado";
            dtgListadoCreditos.Columns["nAtraso"].HeaderText = "Atraso";
            dtgListadoCreditos.Columns["cWinUser"].HeaderText = "Usuario";
            dtgListadoCreditos.Columns["dFechaDesembolso"].HeaderText = "Fec. desembolso";
            dtgListadoCreditos.Columns["dFechaCancelacion"].HeaderText = "Fec. Cancelación";
            dtgListadoCreditos.Columns["dFechaCulminacion"].HeaderText = "Fec. Culminación";

            dtgListadoCreditos.Refresh();

        }
        private void recalcularMontosPlazos()
        {
            DataTable dtRec = new DataTable();
            dtRec = listarCli.CNRecalculoCondiciones();

            string cMsj = dtRec.Rows[0]["cMsj"].ToString();

            MessageBox.Show("-> "+cMsj, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);

            cargarClientesQori();

        }
        
        private void exportarDataGridViewExcel()
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo =
                    (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                hoja_trabajo.Cells[1,1] = "idCli";
                hoja_trabajo.Cells[1,2] = "idUsuario";

                libros_trabajo.SaveAs(fichero.FileName,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                aplicacion.Quit();
            }
        }

        private void insertarNuevosClientes()
        {
            DataTable dtRec = new DataTable();

            DataSet dsCargaCliQ = GetDataSet(dtgCargaClientes);
            var xmlCargaCli = dsCargaCliQ.GetXml();

            dtRec = listarCli.CNInsertaClientes(xmlCargaCli,Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()));

            string cMsj = dtRec.Rows[0]["cMsj"].ToString();

            MessageBox.Show(cMsj, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            dtgCargaClientes.DataSource = null;
        }

        private DataSet GetDataSet(DataGridView dgv) 
        {
            var ds = new DataSet();
            var dt = new DataTable();

            foreach (var column in dgv.Columns.Cast<DataGridViewColumn>()) 
            {
                if (column.Visible) 
                {
                    dt.Columns.Add();
                }
            }

            var objCellValues = new object[dgv.Columns.Count];
            foreach (var row in dgv.Rows.Cast<DataGridViewRow>()) 
            {
                for (int i = 0; i < row.Cells.Count; i++) 
                {
                    objCellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(objCellValues);
            }
            ds.Tables.Add(dt);
            return ds;
         }


        #endregion

       
       




    }
}
