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
using Microsoft.Reporting.WinForms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace CRE.Presentacion
{
    public partial class frmReclasificacionCliente : frmBase
    {

        #region Variables
        clsCNCalificacion cncalifica = new clsCNCalificacion();
        clsCNProvision cnprovision = new clsCNProvision();
        private const string cTituloMsjes = "Reclasificación del clientes";

        #endregion

        #region Constructores

        public frmReclasificacionCliente()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            conBusCli.limpiarControles();
            limpiarControles();
            conBusCli.txtCodCli.Enabled = true;
            conBusCli.btnBusCliente.Enabled = true;
            HabilitarControles(false);

            btnGrabar.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = false;

            conBusCli.Focus();
            conBusCli.txtCodCli.Focus();
            conBusCli.txtCodCli.Select();
        }

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            conBusCli.limpiarControles();
            limpiarControles();
            conBusCli.txtCodCli.Enabled = true;
            conBusCli.btnBusCliente.Enabled = true;

            HabilitarControles(false);

            btnGrabar.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (cboCalifIni.SelectedIndex < 0)
            {
                MessageBox.Show("Calificación inicial no encontrada, no se puede editar", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HabilitarControles(true);

            btnEditar.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!validar()) return;

            DialogResult result = MessageBox.Show("¿Esta seguro de realizar la reclasificación?", cTituloMsjes, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            int idCli = conBusCli.idCli;
	        int idClasifIni = Convert.ToInt32(cboCalifIni.SelectedValue);
	        int idClasifFin = Convert.ToInt32(cboCalifFin.SelectedValue);
	        int idMotReclasifCli  = Convert.ToInt32(cboMotReclasifCli.SelectedValue);
	        string cObservacion = txtObservacion.Text.Trim();
	        DateTime dFecReclasif = dtpFecReclasif.Value.Date;
	        DateTime dFecRegistro = clsVarGlobal.dFecSystem.Date;
            int idUsuario = clsVarGlobal.User.idUsuario;

            if (idClasifFin < idClasifIni)
            {
                result = MessageBox.Show("La clasificación del cliente está mejorando.¿Desea continuar?", cTituloMsjes, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                    return;
            }

            clsDBResp objDbResp = cncalifica.CNReclasificaCliente(idCli, idClasifIni, idClasifFin, idMotReclasifCli,
                                                                    cObservacion, dFecReclasif, dFecRegistro, idUsuario);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                HabilitarControles(false);

                btnGrabar.Enabled = false;
                btnEditar.Enabled = false;
                btnCancelar.Enabled = true;
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dtpFecReclasif_ValueChanged(object sender, EventArgs e)
        {
            cargarCalificacion();
        }

        #endregion

        #region Métodos

        private void cargarDatos()
        {
            limpiarControles();
            HabilitarControles(false);

            if (conBusCli.idCli > 0)
            {
                dtpFecReclasif.Value = new DateTime(clsVarGlobal.dFecSystem.Date.Year, clsVarGlobal.dFecSystem.Date.Month, 1).AddDays(-1);
                cargarCalificacion();

                btnEditar.Enabled = true;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
            }
            else
            {
                conBusCli.limpiarControles();
                conBusCli.txtCodCli.Enabled = true;
                conBusCli.btnBusCliente.Enabled = true;

                btnEditar.Enabled = false;
                btnCancelar.Enabled = false;

                conBusCli.Focus();
                conBusCli.txtCodCli.Focus();
                conBusCli.txtCodCli.Select();
            }

            btnGrabar.Enabled = false;
        }

        private bool validar()
        {
            if (conBusCli.idCli==0)
            {
                MessageBox.Show("Seleccione un cliente para la reclasificación", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (Convert.ToInt32(cboCalifIni.SelectedValue) == Convert.ToInt32(cboCalifFin.SelectedValue))
            {
                MessageBox.Show("La nueva calificación debe de ser distinta a la actual", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboMotReclasifCli.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el motivo de reclasificación del cliente", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtObservacion.Text))
            {
                MessageBox.Show("Ingrese el sustento para la reclasificación.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void HabilitarControles(bool lHabil)
        {
            cboCalifFin.Enabled = lHabil;
            cboMotReclasifCli.Enabled = lHabil;
            txtObservacion.Enabled = lHabil;
        }

        private void limpiarControles()
        {
            // dtpFecReclasif.Value = clsVarGlobal.dFecSystem.Date;
            dtpFecReclasif.Value = new DateTime(clsVarGlobal.dFecSystem.Date.Year, clsVarGlobal.dFecSystem.Date.Month, 1).AddDays(-1);
            cboCalifIni.SelectedIndex = -1;
            cboCalifFin.SelectedIndex = -1;
            cboCalifAlineamiento.SelectedIndex = -1;
            cboMotReclasifCli.SelectedIndex = -1;
            txtObservacion.Text = string.Empty;
        }

        private void cargarCalificacion()
        {
            DataTable dtCalifica = cncalifica.retornaCalificacionEspCli(conBusCli.idCli, dtpFecReclasif.Value);

            if (dtCalifica.Rows.Count > 0)
            {
                DataRow drCalifica = dtCalifica.Rows[0];
                cboCalifIni.SelectedValue = drCalifica["idCalificaEspecial"] == DBNull.Value ? -1 : Convert.ToInt32(drCalifica["idCalificaEspecial"]);
                cboCalifAlineamiento.SelectedValue = drCalifica["idCalificaAlineamiento"] == DBNull.Value ? -1 : Convert.ToInt32(drCalifica["idCalificaAlineamiento"]);
            }
            else
            {
                cboCalifIni.SelectedIndex = -1;
            }
        }

        #endregion

        private void btnProcesarProviciones_Click(object sender, EventArgs e)
        {
            string cFechaReclasif = dtpFecReclasif.Value.ToString("dd/MM/yyyy");
            var confirmResult = MessageBox.Show("Está apunto de Procesar Provisiones a la fecha " + cFechaReclasif + " ¿Continuar?", "Confirmar Proceso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable resultado = cnprovision.CalcularProvicionFecha(dtpFecReclasif.Value);

                string nResultado = Convert.ToString(resultado.Rows[0]["nResultado"]);
                string cMensaje = Convert.ToString(resultado.Rows[0]["cMensaje"]);

                if (nResultado == "1")
                {
                    MessageBox.Show(cMensaje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Cursor = Cursors.Default;
                    return;
                }
                else
                {
                    MessageBox.Show(cMensaje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    return;
                }
            }
            else
            {
                return;
            }

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            dtslist.Clear();

            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cNomAgencia", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("x_dFecha", dtpFecReclasif.Value.ToString("dd/MM/yyyy"), false));

            DataTable resultado = cnprovision.ReportarRiesgoProvisiones(dtpFecReclasif.Value);
            dtslist.Add(new ReportDataSource("propiedades", resultado));

            this.Cursor = Cursors.Default;
            string reportpath = "RptRiesgoClientesProvisiones.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void btnExporExcel1_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Esto puede tomar algunos minutos ¿Continuar?", "Exportar en csv", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes)
            {
                return;
            }


            this.Cursor = Cursors.WaitCursor;
            DataTable dtResultado = cnprovision.ReportarRiesgoProvisiones(dtpFecReclasif.Value);
            this.Cursor = Cursors.Default;

            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.csv)|*.csv";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    IEnumerable<string> columnNames = dtResultado.Columns.Cast<DataColumn>().
                                                      Select(column => column.ColumnName);
                    sb.AppendLine(string.Join(",", columnNames));

                    foreach (DataRow row in dtResultado.Rows)
                    {
                        IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                        sb.AppendLine(string.Join(",", fields));
                    }

                    File.WriteAllText(fichero.FileName, sb.ToString());

                    //Excel.Application oXL;
                    //Excel._Workbook oWB;
                    //Excel._Worksheet oSheet;
                    //Excel.Range oRng;
                    //object misvalue = System.Reflection.Missing.Value;

                    //oXL = new Microsoft.Office.Interop.Excel.Application();

                    //oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(""));
                    //oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                    //oSheet.Cells[1, 1] = "nReg";
                    //oSheet.Cells[1, 2] = "idCliente";
                    //oSheet.Cells[1, 3] = "Cuenta";
                    //oSheet.Cells[1, 4] = "Saldo";
                    //oSheet.Cells[1, 5] = "nProvision";
                    //oSheet.Cells[1, 6] = "Atraso";
                    //oSheet.Cells[1, 7] = "TipoGarantia";
                    //oSheet.Cells[1, 8] = "ImporteGar";
                    //oSheet.Cells[1, 9] = "MonedaGar";
                    //oSheet.Cells[1, 10] = "CapitalDesembolso";
                    //oSheet.Cells[1, 11] = "Contable";
                    //oSheet.Cells[1, 12] = "NombreAge";
                    //oSheet.Cells[1, 13] = "TasaCompensatoria";
                    //oSheet.Cells[1, 14] = "Producto";
                    //oSheet.Cells[1, 15] = "TipCre";
                    //oSheet.Cells[1, 16] = "CalificaInterna";
                    //oSheet.Cells[1, 17] = "idCalificaEspecial";
                    //oSheet.Cells[1, 18] = "PorNor";
                    //oSheet.Cells[1, 19] = "PorCpp";
                    //oSheet.Cells[1, 20] = "PorDef";
                    //oSheet.Cells[1, 21] = "PorDud";
                    //oSheet.Cells[1, 22] = "PorPer";
                    //oSheet.Cells[1, 23] = "SalRCCSol";
                    //oSheet.Cells[1, 24] = "Moneda";
                    //oSheet.Cells[1, 25] = "Calificacion";
                    //oSheet.Cells[1, 26] = "CalificaSist";
                    //oSheet.Cells[1, 27] = "CalificaAlineamiento";
                    //oSheet.Cells[1, 28] = "FechaDesembolso";
                    //oSheet.Cells[1, 29] = "FechaCulminacion";
                    //oSheet.Cells[1, 30] = "SaldoDevengado";
                    //oSheet.Cells[1, 31] = "SaldoIntComp";
                    //oSheet.Cells[1, 32] = "SaldoDiferido";
                    //oSheet.Cells[1, 33] = "PlazoCtr";
                    //oSheet.Cells[1, 34] = "Modalidad";
                    //oSheet.Cells[1, 35] = "Gracia";

                    //int i = 2;
                    //foreach (DataRow row in dtResultado.Rows)
                    //{
                    //    oSheet.Cells[i, 1] = row["nreg"];
                    //    oSheet.Cells[i, 2] = row["idcli"];
                    //    oSheet.Cells[i, 3] = row["idcuenta"];
                    //    oSheet.Cells[i, 4] = row["nsaldo"];
                    //    oSheet.Cells[i, 5] = row["nprovision"];
                    //    oSheet.Cells[i, 6] = row["natraso"];
                    //    oSheet.Cells[i, 7] = row["cTipoGarantia"];
                    //    oSheet.Cells[i, 8] = row["nImporteGar"];
                    //    oSheet.Cells[i, 9] = row["nMonedaGar"];
                    //    oSheet.Cells[i, 10] = row["nCapitalDesembolso"];
                    //    oSheet.Cells[i, 11] = row["cContable"];
                    //    oSheet.Cells[i, 12] = row["cNombreAge"];
                    //    oSheet.Cells[i, 13] = row["nTasaCompensatoria"];
                    //    oSheet.Cells[i, 14] = row["cProducto"];
                    //    oSheet.Cells[i, 15] = row["cTipCre"];
                    //    oSheet.Cells[i, 16] = row["idCalificaInterna"];
                    //    oSheet.Cells[i, 17] = row["idCalificaEspecial"];
                    //    oSheet.Cells[i, 18] = row["nPorNor"];
                    //    oSheet.Cells[i, 19] = row["nPorCpp"];
                    //    oSheet.Cells[i, 20] = row["nPorDef"];
                    //    oSheet.Cells[i, 21] = row["nPorDud"];
                    //    oSheet.Cells[i, 22] = row["nPorPer"];
                    //    oSheet.Cells[i, 23] = row["nSalRCCSol"];
                    //    oSheet.Cells[i, 24] = row["idMoneda"];
                    //    oSheet.Cells[i, 25] = row["idCalificacion"];
                    //    oSheet.Cells[i, 26] = row["idCalificSist"];
                    //    oSheet.Cells[i, 27] = row["idCalificaAlineamiento"];
                    //    oSheet.Cells[i, 28] = row["dFechaDesembolso"];
                    //    oSheet.Cells[i, 29] = row["dFechaCulminacion"];
                    //    oSheet.Cells[i, 30] = row["nSaldoDevengado"];
                    //    oSheet.Cells[i, 31] = row["nSaldoIntComp"];
                    //    oSheet.Cells[i, 32] = row["nSaldoDiferido"];
                    //    oSheet.Cells[i, 33] = row["nPlazoCtr"];
                    //    oSheet.Cells[i, 34] = row["cModalidad"];
                    //    oSheet.Cells[i, 35] = row["nGracia"];
                    //    i++;
                    //}

                    //oWB.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                    //    false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                    //    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                    //oWB.Close();

                    /*for (int i = 0; i < dtgCobs.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            for (int j = 0; j < dtgCobs.Columns.Count; j++)
                            {
                                if (j <= 9)
                                {
                                    hoja_trabajo.Cells[i + 1, b + 1] = dtgCobs.Columns[j].HeaderText;
                                    b++;
                                }
                            }
                        }
                        b = 0;
                        for (int j = 0; j < dtgCobs.Columns.Count; j++)
                        {
                            //if (j != 1 && j <= 8)
                            if (j <= 9)
                            {
                                if (j == 0)
                                    hoja_trabajo.Cells[i + 2, b + 1] = Convert.ToDateTime(dtgCobs.Rows[i].Cells[j].Value).ToString("yyyy-MM-dd");
                                else
                                    hoja_trabajo.Cells[i + 2, b + 1] = dtgCobs.Rows[i].Cells[j].Value.ToString();
                                b++;
                            }
                        }
                    }*/

                    //Libro_Trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);

                    //Libro_Trabajo.Close(null, null, null);
                    //App.Quit();
                    MessageBox.Show("Exportado completo", "Busqueda Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);



                    //libros_trabajo.SaveAs(fichero.FileName,Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    

                }
                catch (SystemException ex)
                {
                    MessageBox.Show("Error al guardar el archivo \n" + ex.Message, "Busqueda Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

    }
}
