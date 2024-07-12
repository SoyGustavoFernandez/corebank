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
using RCP.CapaNegocio;
using Microsoft.Reporting.WinForms;
using GEN.CapaNegocio;
using CRE.CapaNegocio;
using CRE.Presentacion;

namespace RCP.Presentacion
{
    public partial class frmAprobacionSolRecupera : frmBase
    {

        #region Variables

        DataTable dtSolPendientes;
        clsCNSolicitudRecuperacion solicitud = new clsCNSolicitudRecuperacion();
        clsCNBuscarCli cncliente = new clsCNBuscarCli();
        clsCNIntervCre cninterviniente = new clsCNIntervCre();

        #endregion

        public frmAprobacionSolRecupera()
        {
            InitializeComponent();
        }

        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            cboPersonalCargo1.cargarPersonal("nCargosRecuperadores", clsVarGlobal.nIdAgencia);
            cboAgencia1.SelectedIndex = 0;
            cargarPendientesAproba();
        }

        private void dtgSolicitudes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgSolicitudes.CurrentCell is DataGridViewCheckBoxCell)
            {
                if (btnAprobar1.Enabled)
                {
                    int nfilaseleccionada = Convert.ToInt32(this.dtgSolicitudes.CurrentRow.Index);
                    dtSolPendientes.Columns["lAprobado"].ReadOnly = false;
                    dtSolPendientes.Rows[nfilaseleccionada]["lAprobado"] = !Convert.ToBoolean(dtgSolicitudes.CurrentCell.Value);

                    if (!Convert.ToBoolean(dtgSolicitudes.CurrentCell.Value))
                    {
                        chcTodos.Checked = false;
                    }
                }
            }
        }

        private void chcTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (btnAprobar1.Enabled)
            {
                dtSolPendientes.Columns["lAprobado"].ReadOnly = false;
                foreach (DataRow item in dtSolPendientes.Rows)
                {
                    item["lAprobado"] = chcTodos.Checked;
                }
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            if (dtgSolicitudes.Rows.Count > 0)
            {
                if (btnAprobar1.Enabled)
                {
                    dtSolPendientes.Columns["lAprobado"].ReadOnly = false;
                    foreach (DataRow item in dtSolPendientes.Rows)
                    {
                        item["lAprobado"] = false;
                        chcTodos.Checked = false;
                    }
                }
            }
        }

        private void btnAprobar1_Click(object sender, EventArgs e)
        {
            if (dtgSolicitudes.Rows.Count > 0)
            {
                if (validar())
                {
                    var xmlSolRecupera = crearEstructuraXml(2);
                    solicitud.AprobarSolicitudRecuperacion(xmlSolRecupera);
                    MessageBox.Show("Las solicitudes de paso a recuperaciones se guardaron correctamente \n a continuación puede imprimir el acta", "Aprobación de solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnImprimirActa.Enabled = true;
                    btnDenegar1.Enabled = false;
                    btnAprobar1.Enabled = false;
                    btnCancelar1.Enabled = false;
                    chcTodos.Enabled = false;
                }
            }
        }

        private void btnDenegar1_Click(object sender, EventArgs e)
        {
            if (dtgSolicitudes.Rows.Count > 0)
            {
                if (validar())
                {
                    var xmlSolRecupera = crearEstructuraXml(4);
                    solicitud.AprobarSolicitudRecuperacion(xmlSolRecupera);
                    MessageBox.Show("Las solicitudes se denegaron correctamente", "Aprobación de solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnDenegar1.Enabled = false;
                    btnActualizar1.Enabled = true;
                    btnAprobar1.Enabled = false;
                }
            }
        }

        private void btnActualizar1_Click(object sender, EventArgs e)
        {
            cargarPendientesAproba();
        }

        private void btnImprimirActa_Click(object sender, EventArgs e)
        {
            int idCuenta = Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idCuenta"].Value);
            var lAprobado = Convert.ToBoolean(dtgSolicitudes.SelectedRows[0].Cells["lAprobado"].Value);

            if (lAprobado)
            {

                var datocre = solicitud.DatosCreTransRecupera(idCuenta);
                var datosinterv = solicitud.DatosIntervTransRecupera(idCuenta);
                var eventos = solicitud.EventosTransRecupera(idCuenta);

                if (datocre.Rows.Count > 0)
                {
                    List<ReportDataSource> dtsList = new List<ReportDataSource>();
                    dtsList.Add(new ReportDataSource("dsDatoCreTrans", datocre));
                    dtsList.Add(new ReportDataSource("ds_IntervTransRecupera", datosinterv));
                    dtsList.Add(new ReportDataSource("dsEventosTrans", eventos));

                    List<ReportParameter> paramList = new List<ReportParameter>();
                    paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                    paramList.Add(new ReportParameter("idCuenta", idCuenta.ToString(), false));
                    paramList.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
                    paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));


                    string reportPath = "rptActaTransRecupera.rdlc";
                    new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
                }
                else
                {
                    MessageBox.Show("No existen datos", "Acta Recuperación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar las filas de solicitudes aprobadas", "Acta Recuperación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBlanco1_Click(object sender, EventArgs e)
        {
            if (dtgSolicitudes.Rows.Count > 0)
            {
                string cDocumentoID = dtgSolicitudes.SelectedRows[0].Cells["cDocumentoID"].Value.ToString();
                string cNombre = dtgSolicitudes.SelectedRows[0].Cells["cNombre"].Value.ToString();
                int idCliente = Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idCli"].Value);
                new frmPosicionInterv().MostrarReporte(cDocumentoID, cNombre, idCliente);
                //MostrarReporte(cDocumentoID, cNombre, idCliente);
            }
        }

        private void btnBlanco1_Click_1(object sender, EventArgs e)
        {
            if (dtgSolicitudes.Rows.Count > 0)
            {
                int idCliente = Convert.ToInt32(dtgSolicitudes.SelectedRows[0].Cells["idCli"].Value);
                frmHistorialRecupera frmHistorialRecupera = new frmHistorialRecupera(idCliente);
                frmHistorialRecupera.ShowDialog();
            }
        }

        private void cboAgencia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencia1.SelectedIndex >= 0)
            {
                cargarPendientesAproba();
            }
        }

        #endregion

        #region Metodos

        private void cargarPendientesAproba()
        {
            dtSolPendientes = solicitud.ListarSoliRecuperaPendiAprob(Convert.ToInt32(cboAgencia1.SelectedValue));

            if (dtSolPendientes.Rows.Count > 0)
            {
                dtgSolicitudes.DataSource = dtSolPendientes;
                formatoGridCreditos();
                btnBlanco1.Enabled = true;
                btnImprimir.Enabled = true;
                chcTodos.Enabled = true;
                btnAprobar1.Enabled = true;
                btnDenegar1.Enabled = true;
                btnCancelar1.Enabled = true;                
            }
            else
            {
                dtgSolicitudes.DataSource = null;
                btnBlanco1.Enabled = false;
                btnImprimir.Enabled = false;
                chcTodos.Enabled = false;
                btnAprobar1.Enabled = false;
                btnDenegar1.Enabled = false;
                btnCancelar1.Enabled = false;
            }

            chcTodos.Checked = false;
            btnImprimirActa.Enabled = false;
        }

        private void formatoGridCreditos()
        {
            dtgSolicitudes.ReadOnly = false;
            foreach (DataGridViewColumn columna in dtgSolicitudes.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                columna.Visible = false;
                columna.ReadOnly = true;
            }

            dtgSolicitudes.Columns["lAprobado"].Visible = true;
            dtgSolicitudes.Columns["idCuenta"].Visible = true;
            dtgSolicitudes.Columns["dFechaReg"].Visible = true;
            dtgSolicitudes.Columns["idCli"].Visible = true;
            dtgSolicitudes.Columns["cNombre"].Visible = true;
            dtgSolicitudes.Columns["cWinUser"].Visible = true;
            dtgSolicitudes.Columns["nAtraso"].Visible = true;
            dtgSolicitudes.Columns["nSaldo"].Visible = true;

            dtgSolicitudes.Columns["lAprobado"].HeaderText = "Aprob.";
            dtgSolicitudes.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgSolicitudes.Columns["dFechaReg"].HeaderText = "Fecha Reg.";
            dtgSolicitudes.Columns["idCli"].HeaderText = "Cod. Cliente";
            dtgSolicitudes.Columns["cNombre"].HeaderText = "Nombres";
            dtgSolicitudes.Columns["cWinUser"].HeaderText = "Usu. Reg.";
            dtgSolicitudes.Columns["nAtraso"].HeaderText = "Atraso";
            dtgSolicitudes.Columns["nSaldo"].HeaderText = "Saldo";

            dtgSolicitudes.Columns["lAprobado"].Width = 40;
            dtgSolicitudes.Columns["idCuenta"].Width = 50;
            dtgSolicitudes.Columns["dFechaReg"].Width = 80;
            dtgSolicitudes.Columns["idCli"].Width =70;
            dtgSolicitudes.Columns["cNombre"].Width = 250;
            dtgSolicitudes.Columns["cWinUser"].Width = 90;
            dtgSolicitudes.Columns["nAtraso"].Width = 40;
            dtgSolicitudes.Columns["nSaldo"].Width = 100;

            dtgSolicitudes.Columns["idCuenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgSolicitudes.Columns["idCli"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgSolicitudes.Columns["nAtraso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgSolicitudes.Columns["nSaldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgSolicitudes.Columns["nSaldo"].DefaultCellStyle.Format = "N2";
        }

        private bool validar()
        {
            bool lVal = false;
            int nContador=0;

            foreach (DataRow item in dtSolPendientes.Rows)
            {
                if (Convert.ToBoolean(item["lAprobado"])==true)
                {
                    nContador++;
                }
            }
            if (nContador==0)
            {
                MessageBox.Show("Debe seleccionar al menos una solicitud", "Validación de aprobación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }

            lVal = true;
            return lVal;
        }

        private string crearEstructuraXml(int idEstadoSolRec)
        {
            string xmlSolRecupera = "";
            DataTable dt = new DataTable("dtSolRecupera");
            DataSet ds = new DataSet("dsSolRecupera");

            dt.Columns.Add("idSolicitudRecuperacion",typeof(int));
            dt.Columns.Add("dFechaMod",typeof(DateTime));
            dt.Columns.Add("idUsuMod",typeof(int));
            dt.Columns.Add("idEstadoSolRec",typeof(int));
            dt.Columns.Add("idRecuperador", typeof(int));
            DataRow dr;

            foreach (DataRow item in this.dtSolPendientes.Rows)
            {
                if (Convert.ToBoolean(item["lAprobado"]) == true)
                {
                    dr = dt.NewRow();
                    dr["idSolicitudRecuperacion"] = item["idSolicitudRecuperacion"];
                    dr["dFechaMod"] = clsVarGlobal.dFecSystem;
                    dr["idUsuMod"] = clsVarGlobal.User.idUsuario;
                    dr["idEstadoSolRec"] = idEstadoSolRec;
                    dr["idRecuperador"] = Convert.ToInt32(cboPersonalCargo1.SelectedValue);
                    dt.Rows.Add(dr);
                }
            }

            ds.Tables.Add(dt);
            xmlSolRecupera = ds.GetXml();

            return xmlSolRecupera;
        }       

        #endregion

    }
}
