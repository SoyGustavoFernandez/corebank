using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using GEN.CapaNegocio;
using CRE.CapaNegocio;
using Microsoft.Reporting.WinForms;
using EntityLayer;
using ADM.CapaNegocio;

namespace CRE.Presentacion
{    
    public partial class frmLisSolAprob : frmBase
    {
        public Int32 nNumSolicitud = 0, idTipoPersona, idTipoDocumento;
        public string cNomCliente, cDireccion, cTelefono;
        public string cNomEstado, idCliente, cDocumentoID;
        public int idEstadoDefecto = 0;

        DataTable dtSolicitudesEst = new DataTable();
        DataTable dtEstSolicitud = new DataTable();
        public string cEstSolicitud = "cEstadosSolicitud";
        public frmLisSolAprob()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            poblarEstadosCredito();
            LlenarGrilla();
            FormatearGrilla();
            if (idEstadoDefecto != 0)
            {
                cboEstadoSolicitud.SelectedValue = idEstadoDefecto;
            }
            dtgBase1.ClearSelection();
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            try 
            { 
            if (dtgBase1.SelectedRows.Count > 0)
            {
                DataRowView dr = dtgBase1.SelectedRows[0].DataBoundItem as DataRowView;
                if (Convert.ToInt32(dr["IdEstado"]) != 2)
                {
                    return;
                }
                nNumSolicitud = Convert.ToInt32(dr["idSolicitud"]);
                cNomCliente = dr["cNombre"].ToString();
                cNomEstado = dr["cEstado"].ToString();
                idCliente = dr["cCodCliente"].ToString();
                cDocumentoID = dr["cDocumentoID"].ToString();
                this.Dispose();
            }
            else
            {
                nNumSolicitud = 0;
            }
            } catch{}
        }

        private void FormatearGrilla()
        {
            if (dtgBase1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dtgBase1.Rows)
                {
                    if (Convert.ToInt32(row.Cells["IdEstado"].Value) == 2)
                    {
                        row.Cells["cEstado"].Style.BackColor = Color.LightGreen;
                    }
                    else if (Convert.ToInt32(row.Cells["IdEstado"].Value) == 13)
                    {
                        row.Cells["cEstado"].Style.BackColor = Color.Red;
                    }
                    else if (Convert.ToInt32(row.Cells["IdEstado"].Value) == 1)
                    {
                        row.Cells["cEstado"].Style.BackColor = Color.Yellow;
                    }
                    else if (Convert.ToInt32(row.Cells["IdEstado"].Value) == 19)
                    {
                        row.Cells["cEstado"].Style.BackColor = Color.LightBlue;
                    }
                }
            }
        }

        private void LlenarGrilla()
        {
            string cEstados;
            clsCNPlanPago PlanPago = new clsCNPlanPago();

            if (cboEstadoSolicitud.Text == "**TODOS**") 
            { 
                btnAceptar1.Enabled = false;
                dtEstSolicitud = PlanPago.CNObtenerSolicitudEstado(cEstSolicitud);
                DataRow filaEstados = dtEstSolicitud.Rows[0];
                cEstados = Convert.ToString(filaEstados["cValVar"]);
            }
            else
            {
                cEstados = cboEstadoSolicitud.SelectedValue.ToString();
            }


            dtSolicitudesEst = PlanPago.CNListarSolicitudEstados(clsVarGlobal.nIdAgencia, cEstados);
            dtgBase1.DataSource = dtSolicitudesEst;
            dtgBase1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dtgBase1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dtgBase1.Columns["idSolicitud"].HeaderText = "N° Sol.";
            dtgBase1.Columns["idSolicitud"].Width = 50;
            dtgBase1.Columns["cNombre"].HeaderText = "Cliente";
            dtgBase1.Columns["cNombre"].Width = 230;
            dtgBase1.Columns["nCapitalSolicitado"].HeaderText = "Monto Sol.";
            dtgBase1.Columns["nCapitalSolicitado"].Width = 65;
            dtgBase1.Columns["nCapitalSolicitado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgBase1.Columns["nCapitalSolicitado"].DefaultCellStyle.Format = "###,##0.00";
            dtgBase1.Columns["dFechaRegistro"].HeaderText = "Fecha Sol.";
            dtgBase1.Columns["dFechaRegistro"].Width = 68;
            dtgBase1.Columns["hFechaRegistro"].HeaderText = "Hora Sol.";
            dtgBase1.Columns["hFechaRegistro"].Width = 68;
            dtgBase1.Columns["cProducto"].HeaderText = "Producto";
            dtgBase1.Columns["cProducto"].Width = 180;
            dtgBase1.Columns["dFechaAprobacion"].HeaderText = "Fecha de Aprobación";
            dtgBase1.Columns["dFechaAprobacion"].Width = 80;
            dtgBase1.Columns["dHoraAprobacion"].HeaderText = "Hora de Aprobación";
            dtgBase1.Columns["dHoraAprobacion"].Width = 80;
            dtgBase1.Columns["cEstado"].HeaderText = "Estado";
            dtgBase1.Columns["cEstado"].Width = 120;
            dtgBase1.Columns["cAsesor"].HeaderText = "Nombre Asesor";
            dtgBase1.Columns["cAsesor"].Width = 220;
            dtgBase1.Columns["cCodCliente"].Visible = false;
            dtgBase1.Columns["cDocumentoID"].Visible = false;
            dtgBase1.Columns["IdEstado"].Visible = false;
            dtgBase1.Columns["nCuotas"].Visible = false;
        }

        private void dtgBase1_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgBase1.Focused)
            {
                if (dtgBase1.SelectedRows.Count == 0)
                {
                    return;
                }

                DataGridViewRow fila = dtgBase1.SelectedRows[0];
                if (fila != null)
                {
                    if (Convert.ToInt32(fila.Cells["IdEstado"].Value) == 2)
                    {
                        btnAceptar1.Enabled = true;
                    }
                    else
                    {
                        btnAceptar1.Enabled = false;
                    }
                }
            }
        }

        private void dtgBase1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FormatearGrilla();
        }

        private void poblarEstadosCredito()
        {
            clsCNMantenimiento obtenerEstadosSolicitud = new clsCNMantenimiento();
            DataTable dtEstadosSol = new DataTable();
            dtEstadosSol = obtenerEstadosSolicitud.CNObtenerSolicitudEstados(cEstSolicitud);
            DataRow filaEstados = dtEstadosSol.Rows[0];
            string estadosSolicitud = Convert.ToString(filaEstados["cValVar"]);
            clsCNCreditoCargaSeguro objCNCreditoCargaSeguro = new clsCNCreditoCargaSeguro();
            DataTable dtEstados = new DataTable();
            dtEstados = objCNCreditoCargaSeguro.CNListarEstadosSolicitud(estadosSolicitud);
            DataRow row = dtEstados.NewRow();
            row["IdEstado"] = estadosSolicitud;
            row["cEstado"] = "**TODOS**";
            dtEstados.Rows.InsertAt(row, 0);
            cboEstadoSolicitud.ValueMember = dtEstados.Columns["IdEstado"].ColumnName;
            cboEstadoSolicitud.DisplayMember = dtEstados.Columns["cEstado"].ColumnName;
            cboEstadoSolicitud.DataSource = dtEstados;

        }

        private void cboEstadoSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarGrilla();
            FormatearGrilla();
            btnAceptar1.Enabled = false;
            dtgBase1.ClearSelection();
        }
    }
}
