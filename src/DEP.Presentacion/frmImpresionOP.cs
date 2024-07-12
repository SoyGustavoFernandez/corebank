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
using DEP.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using CLI.CapaNegocio;
using GEN.Funciones;
using Microsoft.Reporting.WinForms;

namespace DEP.Presentacion
{
    public partial class frmImpresionOP : frmBase
    {
        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsCNValorados clsOpeValorado = new clsCNValorados();
        DataTable dtConfigOP = new DataTable();
        public frmImpresionOP()
        {
            InitializeComponent();
        }

        private void frmImpresionOP_Load(object sender, EventArgs e)
        {

        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            LimpiarCtrls();
            btnDetalle.Enabled = false;
            if (!ValidarDatos())
            {
                return;
            }
            DataTable dtSolOP = clsOpeValorado.CNListarSolicitudOP(Convert.ToInt16(cboAgencias.SelectedValue), Convert.ToInt16(cboMoneda.SelectedValue));
            if (dtSolOP.Rows.Count<=0)
            {
                MessageBox.Show("No Existe Solicitudes de Ordenes de Pago", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgencias.Focus();
                return;
            }
            else
            {                
                dtgSolOP.DataSource = dtSolOP;
                FormatoGrid();
                btnDetalle.Enabled = true;
            }
        }

        private void FormatoGrid()
        {
            dtgSolOP.Columns["idMoneda"].Visible = false;
            dtgSolOP.Columns["idAgencia"].Visible = false;
            dtgSolOP.Columns["idEstadoVal"].Visible = false;

            dtgSolOP.Columns["idSolicitudOP"].HeaderText = "Solicitud";
            dtgSolOP.Columns["idSolicitudOP"].Width = 60;
            dtgSolOP.Columns["idCuenta"].HeaderText = "ID Cuenta";
            dtgSolOP.Columns["idCuenta"].Width = 100;
            dtgSolOP.Columns["cNroCuenta"].HeaderText = "Nro. Cuenta";
            dtgSolOP.Columns["cNroCuenta"].Width = 150;
            dtgSolOP.Columns["nNumTalonarios"].HeaderText = "Talonarios";
            dtgSolOP.Columns["nNumTalonarios"].Width = 60;
            dtgSolOP.Columns["nCantidadPorTal"].HeaderText = "Cantidad";
            dtgSolOP.Columns["nCantidadPorTal"].Width = 50;
            dtgSolOP.Columns["dFechaSol"].HeaderText = "Fec. Solicitud";
            dtgSolOP.Columns["dFechaSol"].Width = 70;
            dtgSolOP.Columns["cNomCorto"].HeaderText = "Agencia";
            dtgSolOP.Columns["cNomCorto"].Width = 120;
            dtgSolOP.Columns["cModPagOP"].HeaderText = "Modalidad Pago";
            dtgSolOP.Columns["cModPagOP"].Width = 100;
            dtgSolOP.Columns["cEstadoVal"].HeaderText = "Estado";
            dtgSolOP.Columns["cEstadoVal"].Width = 100;
        }

        private void FomatoGridDetalleOp()
        {
            dtgValorado.Columns["idVincuCuenta"].Visible = false;
            dtgValorado.Columns["idValorado"].Visible = false;
            dtgValorado.Columns["idEstado"].Visible = false;

            dtgValorado.Columns["nNroFolio"].HeaderText = "Nro. Folio";
            dtgValorado.Columns["nNroFolio"].Width = 60;
            dtgValorado.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgValorado.Columns["idCuenta"].Width = 90;
            dtgValorado.Columns["nSerie"].HeaderText = "Serie";
            dtgValorado.Columns["nSerie"].Width = 60;
            dtgValorado.Columns["nNumero"].HeaderText = "Numero";
            dtgValorado.Columns["nNumero"].Width = 80;
            dtgValorado.Columns["cEstadoVal"].HeaderText = "Estado";
            dtgValorado.Columns["cEstadoVal"].Width = 120;
            dtgValorado.Columns["lVigente"].HeaderText = "OK";
            dtgValorado.Columns["lVigente"].Width = 40;
        }

        private void LimpiarCtrls()
        {
            if (dtgSolOP.Rows.Count > 0)
            {
                ((DataTable)dtgSolOP.DataSource).Rows.Clear();
            }
            dtgSolOP.Refresh();
            if (dtgValorado.Rows.Count > 0)
            {
                ((DataTable)dtgValorado.DataSource).Rows.Clear();
            }
            dtgValorado.Refresh();
        }

        private bool ValidarDatos()
        {
            if (cboAgencias.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar una Agencia", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgencias.Focus();
                return false;
            }
            if (cboMoneda.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar la Moneda", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMoneda.Focus();
                return false;
            }           
            return true;
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            btnVincular.Enabled = false;
            btnImprimir.Enabled = false;
            dtgSolOP.Refresh();
            if (dtgValorado.Rows.Count > 0)
            {
                ((DataTable)dtgValorado.DataSource).Rows.Clear();
            }
            dtgValorado.Refresh();
            
            if (dtgSolOP.Rows.Count<=0)
            {
                 MessageBox.Show("No Existe Solicitudes de Ordenes de Pago", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 return;
            }
            if (string.IsNullOrEmpty(dtgSolOP.Rows[dtgSolOP.SelectedCells[0].RowIndex].Cells["idSolicitudOP"].Value.ToString()))
            {
                MessageBox.Show("No Existe Ninguna Solicitud Seleccionada", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //--===================================================================
            //--Realizar las Validaciones
            //--===================================================================
            int x_idCuenta = Convert.ToInt32(dtgSolOP.Rows[dtgSolOP.SelectedCells[0].RowIndex].Cells["idCuenta"].Value.ToString()),
                x_nCantLot = Convert.ToInt32(dtgSolOP.Rows[dtgSolOP.SelectedCells[0].RowIndex].Cells["nCantidadPorTal"].Value.ToString()),
                x_idSolOP = Convert.ToInt32(dtgSolOP.Rows[dtgSolOP.SelectedCells[0].RowIndex].Cells["idSolicitudOP"].Value.ToString()),
                x_idEstadoVal = Convert.ToInt32(dtgSolOP.Rows[dtgSolOP.SelectedCells[0].RowIndex].Cells["idEstadoVal"].Value.ToString());

            switch (x_idEstadoVal)
            {
                case 0: //--Ingresado
                    btnVincular.Enabled = true;
                    break;
                case 2: //--Vinculado
                    btnImprimir.Enabled = true;
                    break;
                case 3: //--Impreso
                    btnImprimir.Enabled = false;
                    break;
                default:
                    break;
            }

            DataTable dtDetOP = clsOpeValorado.CNListarDetalleOP(Convert.ToInt16(cboAgencias.SelectedValue), Convert.ToInt16(cboMoneda.SelectedValue), x_nCantLot, x_idCuenta, x_idSolOP, x_idEstadoVal);
            if (dtDetOP.Rows.Count == x_nCantLot)
            {
                if (Convert.ToInt32(dtDetOP.Rows[0]["idEstado"].ToString()) == 0)
                {

                }
                dtgValorado.DataSource = dtDetOP;
                FomatoGridDetalleOp();
            }
            else
            {
                MessageBox.Show("No hay Suficiente Ordenes de Pago, solo hay: " + dtDetOP.Rows.Count.ToString(), "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            HabDesabCabecera(false);
        }

        private void HabDesabCabecera(bool Val)
        {
            cboAgencias.Enabled = Val;
            cboMoneda.Enabled = Val;
            btnProcesar.Enabled = Val;
            dtgSolOP.Enabled = Val;
        }
  
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCtrls();
            HabDesabCabecera(true);
            cboAgencias.SelectedValue = 0;
            cboMoneda.SelectedValue = 1;
            btnDetalle.Enabled = false;
            btnProcesar.Enabled = true;
            cboAgencias.Focus();
        }

        private void btnVincular_Click(object sender, EventArgs e)
        {
            var Msg=MessageBox.Show("Esta seguro de Vincular con Dichas Ordenes de Pago?...", "Vincular Ordenes de Pago", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (Msg == DialogResult.No)
	        {
		        return;
	        }

            HabDesabCabecera(false);
            btnDetalle.Enabled = false;
            //===================================================================
            //--Generar XML del Detalle de OP a Vincular
            //===================================================================
            DataTable dtVal = (DataTable)dtgValorado.DataSource;
            DataSet dsValorado = new DataSet("dsValorado");
            dsValorado.Tables.Add(dtVal);
            string xmlDetOP = clsCNFormatoXML.EncodingXML(dsValorado.GetXml());

            //===================================================================
            //--Registro de Vinculo con las OP
            //===================================================================
            int x_idSolOp = Convert.ToInt32(dtgSolOP.Rows[dtgSolOP.SelectedCells[0].RowIndex].Cells["idSolicitudOP"].Value.ToString());

            DataTable tbRegVinOP = clsOpeValorado.CNRegistroVinculoOP(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, x_idSolOp, clsVarGlobal.dFecSystem, xmlDetOP);

            if (Convert.ToInt32(tbRegVinOP.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(tbRegVinOP.Rows[0]["cMensage"].ToString(), "Vinculación de Cta con las OP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HabDesabCabecera(false);

                foreach (DataGridViewRow nRow in dtgValorado.Rows)
                {
                    nRow.Cells["idEstado"].Value = 2;
                    nRow.Cells["cEstadoVal"].Value = "VINCULADO";
                }
            }
            else
            {
                MessageBox.Show(tbRegVinOP.Rows[0]["cMensage"].ToString(), "Vinculación de Cta con las OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            btnVincular.Enabled = false;
            btnImprimir.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var Msg=MessageBox.Show("Esta seguro de Realizar la Impresión de las Ordenes de Pago?...", "Imprimir Ordenes de Pago", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (Msg == DialogResult.No)
            {
                return;
            }


            int x_idCuenta = Convert.ToInt32(dtgSolOP.Rows[dtgSolOP.SelectedCells[0].RowIndex].Cells["idCuenta"].Value.ToString()),
               x_nCantLot = Convert.ToInt32(dtgSolOP.Rows[dtgSolOP.SelectedCells[0].RowIndex].Cells["nCantidadPorTal"].Value.ToString()),
               x_idSolOP = Convert.ToInt32(dtgSolOP.Rows[dtgSolOP.SelectedCells[0].RowIndex].Cells["idSolicitudOP"].Value.ToString()),
               x_idEstadoVal = Convert.ToInt32(dtgSolOP.Rows[dtgSolOP.SelectedCells[0].RowIndex].Cells["idEstadoVal"].Value.ToString());
            frmConfigCantOP frmConfigOP = new frmConfigCantOP(2);
            frmConfigOP.nNumImpresion = x_nCantLot;
            frmConfigOP.ShowDialog();
            dtConfigOP = frmConfigOP.dtConfigOOP;
            if (dtConfigOP.Rows.Count>0)
            {
                DataSet dsConfigOP = new DataSet("dsConfigOP");
                dsConfigOP.Tables.Add(dtConfigOP);
                string xmlConfigOP = clsCNFormatoXML.EncodingXML(dsConfigOP.GetXml());

                DataTable tbRegImpOP = clsOpeValorado.CNImprimirOP(xmlConfigOP, x_idCuenta, x_idSolOP, 1, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem);
                if (tbRegImpOP.Rows.Count>0)
                {
                    foreach (DataGridViewRow nRow in dtgValorado.Rows)
                    {
                        nRow.Cells["idEstado"].Value = 3;
                        nRow.Cells["cEstadoVal"].Value = "IMPRESO";
                    }

                    if (Convert.ToInt32(tbRegImpOP.Rows[0]["idRpta"].ToString()) == 0)
                    {
                        //--=================================================================================
                        //--- Proceso de Impresión
                        //--=================================================================================

                        clsCodigoBarra Funcion = new clsCodigoBarra();
                        tbRegImpOP.Columns.Add("bCodBar", typeof(Byte[]));
                        tbRegImpOP.Columns.Add("cNroCod", typeof(string));
                        if (tbRegImpOP.Rows.Count > 0)
                        {
                            string cNroCod;
                            for (int i = 0; i < tbRegImpOP.Rows.Count; i++)
                            {
                                cNroCod = tbRegImpOP.Rows[i]["cNroCuenta"].ToString() + "-" + Convert.ToInt32(tbRegImpOP.Rows[i]["nSerie"]).ToString() + "-" + Convert.ToInt32(tbRegImpOP.Rows[i]["nNumero"]).ToString();
                                tbRegImpOP.Rows[i]["cNroCod"] = cNroCod;
                                tbRegImpOP.Rows[i]["bCodBar"] = Funcion.Convert(cNroCod);
                                cNroCod = "";
                            }

                        }

                        List<ReportParameter> paramlist = new List<ReportParameter>();
                        paramlist.Clear();
                        paramlist.Add(new ReportParameter("x_idCuenta", x_idCuenta.ToString(), false));
                        paramlist.Add(new ReportParameter("x_idSolOP", x_idSolOP.ToString(), false));
                        paramlist.Add(new ReportParameter("x_idOpcion", "1", false));
                        paramlist.Add(new ReportParameter("x_idUsuario", clsVarGlobal.User.idUsuario.ToString(), false));
                        paramlist.Add(new ReportParameter("x_idAgencia", clsVarGlobal.nIdAgencia.ToString(), false));
                        paramlist.Add(new ReportParameter("x_dFechaReg", clsVarGlobal.dFecSystem.ToString(), false));

                        List<ReportDataSource> dtslist = new List<ReportDataSource>();
                        dtslist.Clear();

                        dtslist.Add(new ReportDataSource("dtsOrdenes", tbRegImpOP));

                        string reportpath = "rptOrdenPago.rdlc";
                        new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show(tbRegImpOP.Rows[0]["cMensage"].ToString(), "Imprimir Ordenes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    } 
                }
                else
                {
                    MessageBox.Show("No existen datos para la búsqueda", "Imprimir Ordenes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
             
            }
            else
            {
                MessageBox.Show("No se ha configurado los valores para la impresión de las órdenes de pago","Imprimir Ordenes de Pago",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);               
            }
          
            btnImprimir.Enabled = false;
        }

    }
}
