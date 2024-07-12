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
using EntityLayer;
using GEN.Funciones;
using CRE.CapaNegocio;
using System.Xml.Linq;

namespace GEN.ControlesBase
{
    public partial class frmRegistroDocumentoObs : frmBase
    {
        private int idUsuarioReg = clsVarGlobal.User.idUsuario;
        private int idCargo = clsVarGlobal.User.idCargo;   
        private int idTipoArchivo = 0;
        private int idSolicitud = 0;
        private int idEstablecimiento = 0;
        private int idTipoSolicitudObs;
        private int nfilas = 0;
        private string cTipoArchivo;
        private bool lAbsuelto = false;
        private bool lObservar = false;
        private bool lDetalleSolCredObs = true;
        private DataTable dtGrupoArchivo;
        private CRE.CapaNegocio.clsCNAdministracionFiles clsFiles = new CRE.CapaNegocio.clsCNAdministracionFiles();
         
        public frmRegistroDocumentoObs()
        {
            InitializeComponent();
        }

        public frmRegistroDocumentoObs(int idUsuarioRegistra, int idSolicitud_, int idTipoSolicitudObs_, int idTipoArchivo_, int idEstablecimiento_, bool lAbsuelto_ = false)
        {
            InitializeComponent();
            idTipoArchivo = idTipoArchivo_;
            idSolicitud = idSolicitud_;
            idTipoSolicitudObs = idTipoSolicitudObs_;
            idEstablecimiento = idEstablecimiento_;
            lAbsuelto = lAbsuelto_;
        }
        
        #region Eventos
        private void frmRegistroDocumentoObs_Load(object sender, EventArgs e)
        {      
            cargardatos();
        }

        private void cargardatos()
        {
            btnGrabar1.Enabled = false;
            DataSet dtRes = clsFiles.listarDetallesCreditoObs(idSolicitud, idTipoArchivo);
                if (dtRes.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron detalles de solicitudes de crédito para su perfil", "Solicitudes de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Dispose();
                    return;
                }
                else
                {
                    DataTable dtGrupoArchivoRes = dtRes.Tables[0];
                    nfilas = dtGrupoArchivoRes.Rows.Count;
                    foreach (DataColumn column in dtGrupoArchivoRes.Columns)
                    {
                        column.ReadOnly = false;                    
                    }
                    dtGrupoArchivo = dtGrupoArchivoRes;

                    if (dtGrupoArchivo.Rows.Count > 0)
                    {                      
                        dtgRegDocObs.DataSource = dtGrupoArchivoRes;                    
                        FormatoRegDocObs();                        
                    }    
                }                
        }

        private void FormatoRegDocObs()
        {

            foreach (DataGridViewColumn item in dtgRegDocObs.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dtgRegDocObs.ReadOnly = false;           
          
            dtgRegDocObs.Columns["cTipoArchivo"].Visible = true;
            dtgRegDocObs.Columns["cDetalleObservacion"].Visible = true;
            dtgRegDocObs.Columns["cDetalleDescargo"].Visible = true;

            dtgRegDocObs.Columns["cTipoArchivo"].HeaderText = "Tipo de Observación";
            dtgRegDocObs.Columns["cDetalleObservacion"].HeaderText = "Detalle Observación";
            dtgRegDocObs.Columns["cDetalleDescargo"].HeaderText = "Detalle Descargo";            

            dtgRegDocObs.Columns["cTipoArchivo"].DisplayIndex = 0;
            dtgRegDocObs.Columns["cDetalleObservacion"].DisplayIndex = 1;
            dtgRegDocObs.Columns["cDetalleDescargo"].DisplayIndex = 2;

            dtgRegDocObs.Columns["cTipoArchivo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgRegDocObs.Columns["cDetalleObservacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgRegDocObs.Columns["cDetalleDescargo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgRegDocObs.Columns["cTipoArchivo"].ReadOnly = true;

            if (VerificarPerfilVBObservaChecklist()) // RSC
            {
                btnGrabar1.Visible = false;
                btnVistoBueno.Enabled = false;  
                dtgRegDocObs.Columns["cDetalleObservacion"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
                dtgRegDocObs.Columns["cDetalleDescargo"].ReadOnly = true;
                
            }

            if (VerificarPerfilAbsuelveChecklist()) // Asesor
            {
                btnVistoBueno.Visible = false;
                btnObservar.Visible = false;                
                dtgRegDocObs.Columns["cDetalleDescargo"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
                dtgRegDocObs.Columns["cDetalleObservacion"].ReadOnly = true;
                tsmAgregarDetalle.Visible = false;
                tsmQuitarDetalle.Visible = false;
            }
            
            if (lAbsuelto)
            {
                if (!lObservar)
                {
                    btnVistoBueno.Enabled = true;                    
                }               
            }

            btnObservar.Enabled = false;
            dtgRegDocObs.Columns["cTipoArchivo"].ReadOnly = true;

            if (dtgRegDocObs.Rows[0].Cells["cDetalleObservacion"].Value.ToString() == "")
            {
                nfilas = 0;
                btnObservar.Enabled = true;
            }
            cTipoArchivo = dtgRegDocObs.Rows[0].Cells["cTipoArchivo"].Value.ToString();

            validarDetalleObservacion();

            if (validarDescargoCompletado())
            {
                btnGrabar1.Enabled = true;
            }
            if (nfilas == 0)
            {
                btnGrabar1.Enabled = false;
                dtgRegDocObs["cDetalleDescargo", 0].ReadOnly = true;
            }
            
        }

        private void tsmAgregarDetalle_Click(object sender, EventArgs e)
        {            
            btnObservar.Enabled = true;
            btnVistoBueno.Enabled = false;
            dtgRegDocObs.ClearSelection();
            dtgRegDocObs.CurrentCell = null;
            DataTable dataTable = (DataTable)dtgRegDocObs.DataSource;
            DataRow dtgRegDocObsAdd = dataTable.NewRow();

            dtgRegDocObsAdd["cTipoArchivo"] = cTipoArchivo;
            dtgRegDocObsAdd["cDetalleObservacion"] = "";
            dtgRegDocObsAdd["cDetalleDescargo"] = "";

            dataTable.Rows.Add(dtgRegDocObsAdd);
            dataTable.AcceptChanges();
            validarDetalleObservacion();
        }
        
        private void tsmQuitarDetalle_Click(object sender, EventArgs e)
        {            
            if (dtgRegDocObs.RowCount > nfilas)
            {                
                foreach (DataGridViewRow row in dtgRegDocObs.SelectedRows)
                {
                    if (row.Cells["idDetalleSolCredObs"].Value.ToString() == "")
                    {
                        dtgRegDocObs.Rows.Remove(row);
                    }                                  
                }
            }

            else
            {
                MessageBox.Show("El registro que intenta quitar ya ha sido guardado anteriormente", "Registro de Observaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (dtgRegDocObs.RowCount == 0 )
            {
              btnObservar.Enabled = false;              
              btnVistoBueno.Enabled = false;              
            }
         
            if (dtgRegDocObs.RowCount == nfilas && nfilas > 0)
            {                
              btnObservar.Enabled = false;
              if (lAbsuelto == true && lObservar == false)
              {                  
                btnVistoBueno.Enabled = true;                  
              }
            }
            dtgRegDocObs.ClearSelection();
            dtgRegDocObs.CurrentCell = null;
        }

        private void btnObservar_Click(object sender, EventArgs e)
        {
            bool lCambios = false;

            for (int i = nfilas; i < dtgRegDocObs.Rows.Count; i++)
            {
                if (dtgRegDocObs.Rows[i].Cells["cDetalleObservacion"].Value.ToString() != "")
                {
                    lCambios = true;
                }
            }

            if (!lCambios)
            {
                MessageBox.Show("No se encontraron cambios para ser Guardados.", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                int idEstadoCreditoObs = 2; //2 estado Observado
                int idRegistroSolCredObs = 0;
                bool lConfirmar = true;
                DataTable dtRes = clsFiles.guardarRegistroSolCredObs(
                            idUsuarioReg,
                            idSolicitud,
                            idTipoSolicitudObs,
                            idTipoArchivo,
                            idEstadoCreditoObs,
                            idRegistroSolCredObs,
                            "",
                            0
                        );
                idRegistroSolCredObs = Convert.ToInt32(dtRes.Rows[0]["idRegistroSolCredObs"]);

                if (idRegistroSolCredObs > 0)
                {
                    for (int i = nfilas; i < dtgRegDocObs.Rows.Count; i++)
                    {

                        if (dtgRegDocObs.Rows[i].Cells["cDetalleObservacion"].Value.ToString() != "")
                        {
                            DataTable dtResDetalle = clsFiles.guardarRegistroSolCredObs(
                            idUsuarioReg,
                            idSolicitud,
                            idTipoSolicitudObs,
                            idTipoArchivo,
                            idEstadoCreditoObs,
                            idRegistroSolCredObs,
                            dtgRegDocObs.Rows[i].Cells["cDetalleObservacion"].Value.ToString(),
                            0
                            );

                            lDetalleSolCredObs = Convert.ToBoolean(dtResDetalle.Rows[0]["idDetalleSolCredObs"]);
                            if (!lDetalleSolCredObs) 
                            {
                                lConfirmar = false;
                            }
                        }
                    }
                }
                if (lConfirmar)
                {
                    btnVistoBueno.Enabled = false;
                    lObservar = true;
                    MessageBox.Show("Se guardó correctamente el/los registro(s).", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al guardar el/los registro(s).", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }                
            }
            cargardatos();
            btnObservar.Enabled = false;
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            bool lCambios = false;
            bool lValidarAbsuelto = false;

            for (int i = 0; i < dtgRegDocObs.Rows.Count; i++)
            {
                if (dtgRegDocObs.Rows[i].Cells["cDetalleDescargo"].Value.ToString() != "" && dtgRegDocObs.Rows[i].Cells["idRegistroSolCredObsDes"].Value.ToString()=="")
                {
                    lCambios = true;            
                }
                if (dtgRegDocObs.Rows[i].Cells["cDetalleObservacion"].Value.ToString() == "" && dtgRegDocObs.Rows[i].Cells["cDetalleDescargo"].Value.ToString() != "")
                {
                    lValidarAbsuelto = true;
                }
            }
            if (lValidarAbsuelto)
            {
                MessageBox.Show("No se puede continuar con el proceso porque no hay una observación registrada.", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!lCambios)
            {
                MessageBox.Show("No se agregaron cambios en el Detalle Descargo para Absolver la observación.", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                bool lConfirmar = true;
                int idEstadoCreditoObs = 3; //3 estado Absuelto
                int idRegistroSolCredObs = 0;
                DataTable dtRes = clsFiles.guardarRegistroSolCredObs(
                            idUsuarioReg,
                            idSolicitud,
                            idTipoSolicitudObs,
                            idTipoArchivo,
                            idEstadoCreditoObs,
                            idRegistroSolCredObs,
                            "",
                            0
                        );
                idRegistroSolCredObs = Convert.ToInt32(dtRes.Rows[0]["idRegistroSolCredObs"]);

                if (idRegistroSolCredObs > 0)
                {
                    for (int i = 0; i < dtgRegDocObs.Rows.Count; i++)
                    {
                        if (dtgRegDocObs.Rows[i].Cells["cDetalleDescargo"].Value.ToString() != "" && dtgRegDocObs.Rows[i].Cells["idRegistroSolCredObsDes"].Value.ToString() == "")
                        {
                            DataTable dtResDetalle = clsFiles.guardarRegistroSolCredObs(
                            idUsuarioReg,
                            idSolicitud,
                            idTipoSolicitudObs,
                            idTipoArchivo,
                            idEstadoCreditoObs,
                            idRegistroSolCredObs,
                            dtgRegDocObs.Rows[i].Cells["cDetalleDescargo"].Value.ToString(),
                            Convert.ToInt32(dtgRegDocObs.Rows[i].Cells["idDetalleSolCredObs"].Value)                              
                            );

                            if (idRegistroSolCredObs != Convert.ToInt32(dtResDetalle.Rows[0]["idRegistroSolCredObsDes"]))
                            {
                                lConfirmar = false;
                            }
                        }
                    }
                }
                if (lConfirmar)
                {
                    MessageBox.Show("El descargo se registró correctamente, coordinar con el Representante del Servicio al Cliente para su absolución.", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al guardar el/los registro(s).", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }          
                cargardatos();
            }
        }

        private void btnVistoBueno_Click(object sender, EventArgs e)
        {
            int idEstadoCreditoObs = 1; //Visto Bueno
            int idRegistroSolCredObs = 0;
            bool lConfirmar = false;
            DialogResult dialogResult = MessageBox.Show("Declaro que he revisado este documento siendo conforme, por lo cual doy Visto Bueno bajo mi responsabilidad.", "Checklist de documentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                DataTable dtResDetalle = clsFiles.guardarRegistroSolCredObs(
                        idUsuarioReg,
                        idSolicitud,
                        idTipoSolicitudObs,
                        idTipoArchivo,
                        idEstadoCreditoObs,
                        idRegistroSolCredObs,
                        "",
                        0
                        );

                if (Convert.ToInt32(dtResDetalle.Rows[0]["idRegistroSolCredObs"]) > 0)
                {
                    lConfirmar = true;
                }

                if (lConfirmar)
                {
                    MessageBox.Show("El Visto Bueno se registró correctamente.", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargardatos();
                    lAbsuelto = false;
                    btnVistoBueno.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al guardar el/los registro(s).", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }   

        private void pbxAyuda_Click(object sender, EventArgs e)
        {
            frmRegistroDocumentoObsAyuda frmRegistroDocumentoObsAyuda = new frmRegistroDocumentoObsAyuda();
            frmRegistroDocumentoObsAyuda.ShowDialog();
        }

        private bool validarDescargoCompletado()
        {
            bool ldescargo = false;
            foreach (DataGridViewRow row in dtgRegDocObs.Rows)
            {          
                if (row.Cells["idRegistroSolCredObsDes"].Value == DBNull.Value)
                    {
                        ldescargo = true;
                    }                                  
                }           
            return ldescargo;
        }       

        private void validarDetalleObservacion()
        {           
            for (int i = 0; i < nfilas; i++)
            {
                if (dtgRegDocObs.Rows[i].Cells["cDetalleObservacion"].Value.ToString() != "")
                {
                    dtgRegDocObs["cDetalleObservacion", i].ReadOnly = true;
                }

                if (dtgRegDocObs.Rows[i].Cells["cDetalleDescargo"].Value.ToString() != "")
                {
                    dtgRegDocObs["cDetalleDescargo", i].ReadOnly = true;
                }
            }
        }

        private bool VerificarPerfilVBObservaChecklist()
        {
            bool lPerfil = false;
            DataTable dtPerfil = clsFiles.ListarPerfilVBObservaChecklist();
            foreach (DataRow item in dtPerfil.Rows)
            {
                if (Convert.ToInt32(item["idPerfil"]) == clsVarGlobal.PerfilUsu.idPerfil)
                {
                    lPerfil = true;
                    break;
                }
            }
            return lPerfil;
        }

        private bool VerificarPerfilAbsuelveChecklist()
        {
            bool lPerfil = false;
            DataTable dtPerfil = clsFiles.ListarPerfilAbsuelveChecklist();
            foreach (DataRow item in dtPerfil.Rows)
            {
                if (Convert.ToInt32(item["idPerfil"]) == clsVarGlobal.PerfilUsu.idPerfil)
                {
                    lPerfil = true;
                    break;
                }
            }
            return lPerfil;
        }
        #endregion

    }
}