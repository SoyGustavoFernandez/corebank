using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ADM.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using CRE.CapaNegocio;
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using GEN.Servicio;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GEN.BotonesBase;

namespace CRE.Presentacion
{
    public partial class frmDocumentosCreditosObs : frmBase
    {
        private int idUsuarioReg = clsVarGlobal.User.idUsuario;
        private DataTable dtGrupoArchivo;
        private CRE.CapaNegocio.clsCNAdministracionFiles clsFiles = new CRE.CapaNegocio.clsCNAdministracionFiles();     
        private bool lChecklist = true;
        private bool lChecklistMenu = true;

        public frmDocumentosCreditosObs()
        {
            InitializeComponent();  
        }        

        private void frmDocumentosCreditosObs_Load(object sender, EventArgs e)
        {
            CargaDatos();
        }  

        private void CargaDatos()
        {
            DataSet dsRes = clsFiles.listarSolicitudesCreditoObs(idUsuarioReg);

            if (dsRes.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron documentos observados para absolver las solicitudes de créditos para su perfil.", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
                return;
            }

            else
            {
                DataTable dtGrupoArchivoRes = dsRes.Tables[0];
                foreach (DataColumn column in dtGrupoArchivoRes.Columns)
                {
                    column.ReadOnly = false;
                }
                dtGrupoArchivo = dtGrupoArchivoRes;

                string cXmlCheckList = "";
                DataTable dtResCheckListTemp = new DataTable("dtLista");
                bool idTipoSolicitudObs = false;
                for (int i = 0; i < dtGrupoArchivo.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dtGrupoArchivo.Rows[i]["idTipoSolicitudObs"]) == 1)
                    {
                        idTipoSolicitudObs = false;
                    }
                    else
                    {
                        idTipoSolicitudObs = true;
                    }   
                
                    DataTable dtResCheckList = clsFiles.DtObtenerTipoGrupoArchivoCheckList(
                                                Convert.ToInt32(dtGrupoArchivo.Rows[i]["idSolicitud"]),
                                                idTipoSolicitudObs);
                    dtResCheckListTemp.Merge(dtResCheckList);
                }

                DataSet dsResCheckListTemp = new DataSet("dsCheckList");
                dsResCheckListTemp.Tables.Add(dtResCheckListTemp);
                cXmlCheckList = dsResCheckListTemp.GetXml();
                bool lLista = true;
                DataSet dsResPendientes = clsFiles.listarSolicitudesCreditoObsPendientes(cXmlCheckList, lLista);
                DataTable dtGrupoArchivoPen = dsResPendientes.Tables[0];
                if (dsResPendientes.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron documentos observados para absolver las solicitudes de créditos para su perfil.", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Dispose();
                    return;
                }

                foreach (DataColumn column in dtGrupoArchivoPen.Columns)
                {
                    column.ReadOnly = false;
                }

                dtgListaSolicitudes.DataSource = dtGrupoArchivoPen;
                FormatoSolicitudes();                
            }
        }

        private void FormatoSolicitudes()
        {          
            foreach (DataGridViewColumn item in dtgListaSolicitudes.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }    
        
            dtgListaSolicitudes.Columns["idSolicitud"].Visible = true;
            dtgListaSolicitudes.Columns["idSolicitud"].HeaderText = "Nro. Solicitud";
            dtgListaSolicitudes.Columns["idSolicitud"].DisplayIndex = 0;
            dtgListaSolicitudes.Columns["idSolicitud"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            DataGridViewButtonColumn btnVer = new DataGridViewButtonColumn();
            {
                btnVer.Name = "btnVer";
                btnVer.HeaderText = "Ver";
                btnVer.Text = "Ver";
                btnVer.UseColumnTextForButtonValue = true;
                btnVer.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnVer.FlatStyle = FlatStyle.Standard;
                btnVer.CellTemplate.Style.BackColor = Color.Honeydew;
                dtgListaSolicitudes.Columns.Add(btnVer);
            }
        }

        private void dtgListaSolicitudes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int verSolicitud = dtgListaSolicitudes.Columns["btnVer"].Index;   
            if (dtgListaSolicitudes.CurrentCell == null)
                return;

            if (dtgListaSolicitudes.CurrentCell.ColumnIndex.Equals(verSolicitud))
            {               
                bool lGrupoSolidario = Convert.ToBoolean(dtgListaSolicitudes.CurrentRow.Cells["lGrupoSolidario"].Value);
                frmCargaArchivo frmCargaArchivo = new frmCargaArchivo(Convert.ToInt32(dtgListaSolicitudes.Rows[dtgListaSolicitudes.CurrentCell.RowIndex].Cells["idSolicitud"].Value), false, lChecklist, lGrupoSolidario, lChecklistMenu);
                frmCargaArchivo.ShowDialog();
                dtgListaSolicitudes.Columns.Clear();                
                CargaDatos();
            }
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Close();
        }                 

    }
}
