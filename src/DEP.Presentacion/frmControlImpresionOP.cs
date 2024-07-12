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
    public partial class frmControlImpresionOP : frmBase
    {
        DataTable dtDetOP, dtAnulados;
        DataTable dtNuevos = new DataTable();
        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsCNValorados clsOpeValorado = new clsCNValorados();
        DataTable dtConfigOP = new DataTable();
        public frmControlImpresionOP()
        {
            InitializeComponent();
        }

        private void frmControlImpresionOP_Load(object sender, EventArgs e)
        {
            FoliosNuevos();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            LimpiarCtrls();
            btnDetalle.Enabled = false;
            chcEditar.Checked = false;
            chcEditar.Enabled = false;
            dtgSolOP.Enabled = false;
            if (!ValidarDatos())
            {
                return;
            }
            DataTable dtSolOP = clsOpeValorado.CNListarSolicitudOP(Convert.ToInt16(cboAgencias.SelectedValue), Convert.ToInt16(cboMoneda.SelectedValue));
            if (dtSolOP.Rows.Count <= 0)
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
                dtgSolOP.Enabled = true;
                btnDetalle.Focus();
            }
        }

        private void FormatoGrid()
        {
            dtgSolOP.Columns["idMoneda"].Visible = false;
            dtgSolOP.Columns["idAgencia"].Visible = false;
            dtgSolOP.Columns["idEstadoVal"].Visible = false;

            dtgSolOP.Columns["idSolicitudOP"].HeaderText = "Solicitud";
            dtgSolOP.Columns["idSolicitudOP"].Width = 60;
            dtgSolOP.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgSolOP.Columns["idCuenta"].Width = 100;
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
            if (dtgValoradoAnu.Rows.Count > 0)
            {
                ((DataTable)dtgValoradoAnu.DataSource).Rows.Clear();
            }
            dtgValoradoAnu.Refresh();
            if (dtgNuevos.Rows.Count > 0)
            {
                ((DataTable)dtgNuevos.DataSource).Rows.Clear();
            }
            dtgNuevos.Refresh();
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

        private void HabDesabCabecera(bool Val)
        {
            cboAgencias.Enabled = Val;
            cboMoneda.Enabled = Val;
            btnProcesar.Enabled = Val;
            dtgSolOP.Enabled = Val;
        }

        private void FomatoGridDetalleOp()
        {
            dtgValorado.Columns["idVincuCuenta"].Visible = false;
            dtgValorado.Columns["idValorado"].Visible = false;
            dtgValorado.Columns["idEstado"].Visible = false;
            dtgValorado.Columns["idCuenta"].Visible = false;

            dtgValorado.Columns["nNroFolio"].HeaderText = "Nro. Folio";
            dtgValorado.Columns["nNroFolio"].Width = 60;
            dtgValorado.Columns["nSerie"].HeaderText = "Serie";
            dtgValorado.Columns["nSerie"].Width = 60;
            dtgValorado.Columns["nNumero"].HeaderText = "Numero";
            dtgValorado.Columns["nNumero"].Width = 80;
            dtgValorado.Columns["cEstadoVal"].HeaderText = "Estado";
            dtgValorado.Columns["cEstadoVal"].Width = 120;
            dtgValorado.Columns["lVigente"].HeaderText = "OK";
            dtgValorado.Columns["lVigente"].Width = 40;
        }

        private void FomatoGridAnulados()
        {
            dtgValoradoAnu.Columns["idVincuCuenta"].Visible = false;
            dtgValoradoAnu.Columns["idValorado"].Visible = false;
            dtgValoradoAnu.Columns["idEstado"].Visible = false;
            dtgValoradoAnu.Columns["idCuenta"].Visible = false;

            dtgValoradoAnu.Columns["nNroFolio"].HeaderText = "Nro. Folio";
            dtgValoradoAnu.Columns["nNroFolio"].Width = 60;
            dtgValoradoAnu.Columns["nSerie"].HeaderText = "Serie";
            dtgValoradoAnu.Columns["nSerie"].Width = 60;
            dtgValoradoAnu.Columns["nNumero"].HeaderText = "Numero";
            dtgValoradoAnu.Columns["nNumero"].Width = 80;
            dtgValoradoAnu.Columns["cEstadoVal"].HeaderText = "Estado";
            dtgValoradoAnu.Columns["cEstadoVal"].Width = 120;
            dtgValoradoAnu.Columns["lVigente"].HeaderText = "OK";
            dtgValoradoAnu.Columns["lVigente"].Width = 40;
        }

        private void DesactivarBotones(bool val)
        {
            btnMiniPasarDerecha.Enabled = val;
            btnMiniPasarIzquierda.Enabled = val;
            nudFolio.Enabled = val;
            btnAgregar.Enabled = val;
            btnQuitar.Enabled = val;
            dtgValorado.Enabled = val;
            dtgValoradoAnu.Enabled = val;
            dtgNuevos.Enabled = val;
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            btnVincular.Enabled = false;
            btnImprimir.Enabled = false;
            DesactivarBotones(false);

            dtgSolOP.Refresh();
            if (dtgValorado.Rows.Count > 0)
            {
                ((DataTable)dtgValorado.DataSource).Rows.Clear();
            }
            dtgValorado.Refresh();

            if (dtgSolOP.Rows.Count <= 0)
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
                    MessageBox.Show("Primero Debe Vincular las Ordenes Pago", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                    break;
                case 2: //--Vinculado
                    btnImprimir.Enabled = true;
                    break;
                case 3: //--Impreso
                    btnImprimir.Enabled = true;
                    break;
                default:
                    break;
            }



            dtDetOP = clsOpeValorado.CNListarDetalleOP(Convert.ToInt16(cboAgencias.SelectedValue), Convert.ToInt16(cboMoneda.SelectedValue), x_nCantLot, x_idCuenta, x_idSolOP, x_idEstadoVal);            
            dtgValorado.DataSource = dtDetOP;
            FomatoGridDetalleOp();

            //--Crear Estructura para el Grid de Anulados
            dtAnulados = dtDetOP.Clone();
            dtgValoradoAnu.DataSource = dtAnulados;
            FomatoGridAnulados();

            dtgSolOP.Enabled = false;
            btnDetalle.Enabled = false;
            HabDesabCabecera(false);
            dtgValorado.Enabled = true;
            chcEditar.Enabled = true;
            chcEditar.Focus();            
        }

        private void FoliosNuevos()
        {
            dtNuevos.Columns.Add("nNroFolio", typeof(int));
            dtNuevos.Columns.Add("cDescripcion", typeof(string));
            dtNuevos.Columns.Add("nSerie", typeof(int));
            dtNuevos.Columns.Add("nNumero", typeof(int));
            dtNuevos.Columns.Add("idSolicitudOP", typeof(int));

            dtgNuevos.DataSource = dtNuevos;

            dtgNuevos.Columns["nSerie"].Visible = false;
            dtgNuevos.Columns["nNumero"].Visible = false;
            dtgNuevos.Columns["idSolicitudOP"].Visible = false;
                        
            dtgNuevos.Columns["nNroFolio"].HeaderText = "Nro. Folio";
            dtgNuevos.Columns["nNroFolio"].Width = 50;
            dtgNuevos.Columns["cDescripcion"].HeaderText = "Descripción";
            dtgNuevos.Columns["cDescripcion"].Width = 100;

        }

        private void btnMiniPasarDerecha_Click(object sender, EventArgs e)
        {
            if (dtDetOP.Rows.Count <= 0)
            {
                MessageBox.Show("No existen Órdenes de Pago para Anular", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dtAnulados.ImportRow(dtDetOP.Rows[dtgValorado.CurrentRow.Index]);
            dtDetOP.Rows.Remove(dtDetOP.Rows[dtgValorado.CurrentRow.Index]);
        }

        private void btnMiniPasarIzquierda_Click(object sender, EventArgs e)
        {
            if (dtAnulados.Rows.Count <= 0)
            {
                MessageBox.Show("No existen ódenes de pago Abulados...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
                        
            if (dtNuevos.Rows.Count > 0 && dtAnulados.Rows.Count == dtNuevos.Rows.Count)
            {
                btnQuitar.PerformClick();
            }
            dtDetOP.ImportRow(dtAnulados.Rows[dtgValoradoAnu.CurrentRow.Index]);
            dtAnulados.Rows.Remove(dtAnulados.Rows[dtgValoradoAnu.CurrentRow.Index]);
           
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nudFolio.Value.ToString()))
            {
                 MessageBox.Show("Debe ingresar el número de Folio", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 nudFolio.Focus();
                 nudFolio.Select(0, 5);
                 return;
            }
            if (nudFolio.Value<=0)
            {
                MessageBox.Show("Debe ingresar un número de folio válido", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nudFolio.Focus();
                nudFolio.Select(0, 5);
                return;
            }
            if (dtNuevos.Rows.Count>=dtAnulados.Rows.Count)
            {
                MessageBox.Show("No puede agregar Ordenes de Pago, para ello primero debe anular alguna de la órdenes de pago Vigentes", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int k = 0;

            for (int i = 0; i < dtNuevos.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtgNuevos.Rows[i].Cells["nNroFolio"].Value.ToString()) == nudFolio.Value)
	            {
		            k=1;
                    break;
	            }                
            }

            if (k==1)
            {
                 MessageBox.Show("El Número de Folio ya fue Registrado como Nuevo", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 nudFolio.Focus();
                 nudFolio.Select(0, 5);
                 return;
            }

            k = 0;
            for (int i = 0; i < dtgValorado.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtgValorado.Rows[i].Cells["nNroFolio"].Value.ToString()) == nudFolio.Value)
                {
                    k = 1;
                }
            }

            if (k == 1)
            {
                MessageBox.Show("El Número de Folio esta Registrado en el Listado Actual...Revisar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nudFolio.Focus();
                nudFolio.Select(0, 5);
                return;
            }

            k = 0;
            for (int i = 0; i < dtgValoradoAnu.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtgValoradoAnu.Rows[i].Cells["nNroFolio"].Value.ToString()) == nudFolio.Value)
                {
                    k = 1;
                }
            }

            if (k == 1)
            {
                MessageBox.Show("El Número de Folio esta Registrado en el Listado de Anulados...Revisar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nudFolio.Focus();
                nudFolio.Select(0, 5);
                return;
            }

            DataTable dtFolio = clsOpeValorado.CNValidaNroFolio(Convert.ToInt32(nudFolio.Value));
            if (dtFolio.Rows.Count <= 0)
            {
                MessageBox.Show("El Número de Folio no es Válido (No existe o esta siendo ya usado), por favor revisar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nudFolio.Focus();
                nudFolio.Select(0, 5);
                return;
            }

            //==============================================
            //--Agregar Datos el Grid 
            //==============================================
            DataRow dr = dtNuevos.NewRow();
            dr["nNroFolio"] = nudFolio.Value;
            dr["cDescripcion"] = "Nuevo";
            dtNuevos.Rows.Add(dr);

            if (dtNuevos.Rows.Count>0)
            {
                btnVincular.Enabled = true;
            }
            else
            {
                btnVincular.Enabled = false;
            }
            nudFolio.Value = 0;
            nudFolio.Focus();
            nudFolio.Select(0, 5);
        }

        private void NuevosFolios()
        {
            int x_idSolOP = Convert.ToInt32(dtgSolOP.Rows[dtgSolOP.SelectedCells[0].RowIndex].Cells["idSolicitudOP"].Value.ToString());
            for (int i = 0; i < dtgValoradoAnu.Rows.Count; i++)
            {
                dtNuevos.Rows[i]["nSerie"] =Convert.ToInt32(dtAnulados.Rows[i]["nSerie"]);
                dtNuevos.Rows[i]["nNumero"] = Convert.ToInt32(dtAnulados.Rows[i]["nNumero"]);
                dtNuevos.Rows[i]["idSolicitudOP"] = x_idSolOP;
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgNuevos.Rows.Count > 0)
            {
                this.dtgNuevos.Rows.Remove(dtgNuevos.CurrentRow);
                this.dtgNuevos.Refresh();
                if (dtNuevos.Rows.Count <= 0)
                {
                    btnVincular.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("No Existe Datos a Eliminar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnAgregar.Focus();
                return;
            }
        }

        private void btnVincular_Click(object sender, EventArgs e)
        {
            if (dtgValoradoAnu.Rows.Count<=0)
            {
                MessageBox.Show("No Existe Valorados Anulados...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dtgNuevos.Rows.Count <= 0)
            {
                MessageBox.Show("No Existe Valorados Nuevos que Reemplacen...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dtgValoradoAnu.Rows.Count!=dtgNuevos.Rows.Count)
            {
                MessageBox.Show("Los valorados Anulados, deben ser iguales a los valorados nuevos que se han agregado...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            NuevosFolios();

            var Msg = MessageBox.Show("Esta seguro de vincular con dichas Ordenes de Pago?...", "Vincular Ordenes de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Msg == DialogResult.No)
            {
                return;
            }

            //---Generar los Archivos XML
            DataSet dsFolioAnu = new DataSet("dsFolios");
            dsFolioAnu.Tables.Add(dtAnulados);
            string xmlFolioAnu = clsCNFormatoXML.EncodingXML(dsFolioAnu.GetXml());

            DataSet dsFolioNue = new DataSet("dsFolios");
            dsFolioNue.Tables.Add(dtNuevos);
            string xmlFolioNue = clsCNFormatoXML.EncodingXML(dsFolioNue.GetXml());

            int x_idSolOP = Convert.ToInt32(dtgSolOP.Rows[dtgSolOP.SelectedCells[0].RowIndex].Cells["idSolicitudOP"].Value.ToString());
            int x_idCuenta = Convert.ToInt32(dtgSolOP.Rows[dtgSolOP.SelectedCells[0].RowIndex].Cells["idCuenta"].Value.ToString());

            DataTable dtVinFolio = clsOpeValorado.CNRegistraCambioOP(x_idCuenta, x_idSolOP, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, xmlFolioAnu, xmlFolioNue);
            if (Convert.ToInt32(dtVinFolio.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(dtVinFolio.Rows[0]["cMensage"].ToString(), "Cambio de Ordenes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(dtVinFolio.Rows[0]["cMensage"].ToString(), "RCambio de Ordenes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DesactivarBotones(false);            
            btnVincular.Enabled = false;
            btnImprimir.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DesactivarBotones(false);
            LimpiarCtrls();
            nudFolio.Value=0;
            btnProcesar.Enabled = true;
            btnDetalle.Enabled = false;
            btnImprimir.Enabled = false;
            btnVincular.Enabled = false;
            chcEditar.Checked = false;
            chcEditar.Enabled = false;
            btnProcesar.Focus();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var Msg = MessageBox.Show("Esta seguro de Realizar la Impresión de las Ordenes de Pago?...", "Imprimir Ordenes de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Msg == DialogResult.No)
            {
                return;
            }

            int x_idCuenta = Convert.ToInt32(dtgSolOP.Rows[dtgSolOP.SelectedCells[0].RowIndex].Cells["idCuenta"].Value.ToString()),
               x_nCantLot = dtgNuevos.RowCount,
               x_idSolOP = Convert.ToInt32(dtgSolOP.Rows[dtgSolOP.SelectedCells[0].RowIndex].Cells["idSolicitudOP"].Value.ToString()),
               x_idEstadoVal = Convert.ToInt32(dtgSolOP.Rows[dtgSolOP.SelectedCells[0].RowIndex].Cells["idEstadoVal"].Value.ToString());

            frmConfigCantOP frmConfigOP = new frmConfigCantOP(1);
            frmConfigOP.nNumImpresion = x_nCantLot;
            frmConfigOP.ShowDialog();
            dtConfigOP = frmConfigOP.dtConfigOOP;
            if (dtConfigOP.Rows.Count>0)
            {
                DataSet dsConfigOP = new DataSet("dsConfigOP");
                dsConfigOP.Tables.Add(dtConfigOP);
                string xmlConfigOP = clsCNFormatoXML.EncodingXML(dsConfigOP.GetXml());

                DataTable tbRegImpOP = clsOpeValorado.CNImprimirOP(xmlConfigOP, x_idCuenta, x_idSolOP, 1, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem);
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
                MessageBox.Show("No se ha configurado los valores para la impresión de las órdenes de pago", "Imprimir Ordenes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            btnImprimir.Enabled = false;
        }

        private void chcEditar_CheckedChanged(object sender, EventArgs e)
        {
            if (chcEditar.Checked)
            {
                DesactivarBotones(true);
                btnImprimir.Enabled = false;
                btnVincular.Enabled = true;
                chcEditar.Enabled = false;
                btnMiniPasarDerecha.Focus();
            }
        }

    }
}
