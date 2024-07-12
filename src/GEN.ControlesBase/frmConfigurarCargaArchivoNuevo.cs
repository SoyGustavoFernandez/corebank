using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GEN.BotonesBase;
using EntityLayer;
using GEN.Funciones;
using CRE.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class frmConfigurarCargaArchivoNuevo : frmBase
    {
        #region Variables
        private int idAgencia = clsVarGlobal.nIdAgencia, indexSelDocumento;
        private clsListaTipoArchivoEscaneado listaDocumento = new clsListaTipoArchivoEscaneado();  
        private clsTipoArchivoEscaneado datasel; 
        private clsCNCargaArchivo clsConfiguracion = new clsCNCargaArchivo();
        #endregion
        
        #region Eventos

        public frmConfigurarCargaArchivoNuevo()
        {
            InitializeComponent();
        }
        private void frmConfigurarCargaArchivo_Load(object sender, EventArgs e)
        {
            this.cboGrupoCargaArchivo1.SelectedIndexChanged -= cboGrupoCargaArchivo1_SelectedIndexChanged;
            this.cboGrupoCargaArchivo1.ListarGrupoCargaArchivo();
            this.cboGrupoCargaArchivo1.SelectedIndex = -1;
            this.cancelarConfiguracion();
            this.cboGrupoCargaArchivo1.SelectedIndexChanged += cboGrupoCargaArchivo1_SelectedIndexChanged;
            this.chcOrdenar.Enabled = true;
            this.btnGuardarDocumento.Enabled = false;
            this.btnDownDocumento.Enabled = false;
            this.btnUpDocumento.Enabled = false;
            this.btnCancelOrden.Enabled = false;
            this.conConfiguracionArchivos1.CargarDatosIniciales();
            dtgArchivoxGrupo.Columns["lConFechaVigenciaDataGridViewCheckBoxColumn"].DefaultCellStyle.BackColor = Color.LightGray; 
            dtgArchivoxGrupo.Columns["lConFechaVigenciaDataGridViewCheckBoxColumn"].DefaultCellStyle.ForeColor = Color.Black;
            dtgArchivoxGrupo.Columns["lConFechaVigenciaDataGridViewCheckBoxColumn"].DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dtgArchivoxGrupo.Columns["lConFechaVigenciaDataGridViewCheckBoxColumn"].DefaultCellStyle.SelectionForeColor = Color.Black;
         

        }

        private void cboGrupoCargaArchivo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (habilitarBusqueda())
            {
                this.btnBusqueda1();
            }
        }
        
        private void dtgArchivoxGrupo_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            indexSelDocumento = e.RowIndex;
            this.MostrarDatos(e.RowIndex); 
    
        }
             
       

        private void btnDownDocumento_Click(object sender, EventArgs e)
        {
            this.btnGuardarDocumento.Enabled = true;


            int _indice = indexSelDocumento;
            var Datafila = listaDocumento[_indice];
            if (listaDocumento.Count() == _indice + 1)
            {
                return;
            }
            var DatafilaSiguiente = listaDocumento[indexSelDocumento + 1];

            listaDocumento.Remove(Datafila);
            listaDocumento.Remove(DatafilaSiguiente);

            Datafila.nOrden += 1;
            DatafilaSiguiente.nOrden -= 1;
            listaDocumento.Insert(_indice, DatafilaSiguiente);

            listaDocumento.Insert(_indice + 1, Datafila); 

            dtgArchivoxGrupo.RefreshEdit();
            dtgArchivoxGrupo.Refresh();

        }

        private void btnUpDocumento_Click(object sender, EventArgs e)
        {
            if (indexSelDocumento == 0)
            {
                return;
            }
            int _indice = indexSelDocumento;
            this.btnGuardarDocumento.Enabled = true;

            var Datafila = listaDocumento[_indice];
            var DatafilaAnterior = listaDocumento[_indice - 1];

            listaDocumento.Remove(Datafila);
            listaDocumento.Remove(DatafilaAnterior);
            int orden1 = Datafila.nOrden;
            int orden2 = DatafilaAnterior.nOrden;

            Datafila.nOrden = orden2;
            DatafilaAnterior.nOrden = orden1;
            listaDocumento.Insert(_indice - 1, DatafilaAnterior);

            listaDocumento.Insert(_indice - 1, Datafila);
     
            dtgArchivoxGrupo.RefreshEdit();
            dtgArchivoxGrupo.Refresh();
        }

        private void btnGuardarDocumento_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de guardar el nuevo orden?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                clsDBResp dtRes = clsConfiguracion.ActualizarConfiguracionTipoArchivo(listaDocumento);


                if (dtRes.nMsje == 0)
                {
                    MessageBox.Show(dtRes.cMsje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.activar_btnarchivo(true);
                    this.btnGuardarDocumento.Enabled = false;
                    this.chcOrdenar.Checked = false;
                    if (habilitarBusqueda())
                    {
                        this.btnBusqueda1();
                    }
                }
                else
                {
                    MessageBox.Show(dtRes.cMsje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                } 
            }
        }

        private void btnCancelOrden_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cancelar el ordenamiento?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.activar_btnarchivo(true);
                btnGuardarDocumento.Enabled = false;
                 
                chcOrdenar.Enabled = true;
                chcOrdenar.Checked = false;
                if (habilitarBusqueda())
                {
                    this.btnBusqueda1();
                    this.conConfiguracionArchivos1.btnCancelar1.Enabled = false;
                    this.conConfiguracionArchivos1.btnGrabar1.Enabled = false;
                }
                else
                {
                    this.listaDocumento = new clsListaTipoArchivoEscaneado(); 
                    this.conConfiguracionArchivos1.btnCancelar1.Enabled = false;
                    this.conConfiguracionArchivos1.btnGrabar1.Enabled = false;
                    this.conConfiguracionArchivos1.btnNuevo1.Enabled = false;
                    this.conConfiguracionArchivos1.btnEditar1.Enabled = false;

                    dtgArchivoxGrupo.DataSource = listaDocumento;
                     
                }

            }

        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            frmRegDocConfiguracion frmCarga = new frmRegDocConfiguracion();
            frmCarga.ShowDialog(); 
            if (frmCarga.lGuardado)
            {
                if (Convert.ToInt32(cboGrupoCargaArchivo1.SelectedValue) == frmCarga.pDocumento.idGrupoArchivo)
                {
                    listaDocumento.Add(new clsTipoArchivoEscaneado()
                    {
                        idTipoArchivo     =  frmCarga.pDocumento.idTipoArchivo,
                        nOrden            =  frmCarga.pDocumento.nOrden,
                        cTipoArchivo      =  frmCarga.pDocumento.cTipoArchivo,
                        idGrupoArchivo    =  frmCarga.pDocumento.idGrupoArchivo,
                        dFechaVigencia    =  frmCarga.pDocumento.dFechaVigencia,
                        lConFechaVigencia =  frmCarga.pDocumento.lConFechaVigencia,
                        lIndefinido       =  frmCarga.pDocumento.lIndefinido,
                        idTipArcOrigen    =  frmCarga.pDocumento.idTipArcOrigen,
                        cTipArcOrigen     =  frmCarga.pDocumento.cTipArcOrigen,
                        idUsuReg          =  frmCarga.pDocumento.idUsuReg,
                        dFecRegistro      =  frmCarga.pDocumento.dFecRegistro

                    });
                }

                dtgArchivoxGrupo.RefreshEdit();
                dtgArchivoxGrupo.Refresh();
            }
        }

        private void btnEditarArchivo_Click(object sender, EventArgs e)
        {
            if (datasel == null)
            {
                MessageBox.Show("Sin datos para editar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmRegDocConfiguracion frmCarga = new frmRegDocConfiguracion(datasel);
            frmCarga.ShowDialog();
            if (frmCarga.lGuardado)
            {
               datasel.idTipoArchivo     =  frmCarga.pDocumento.idTipoArchivo;
               datasel.nOrden            =  frmCarga.pDocumento.nOrden;
               datasel.cTipoArchivo      =  frmCarga.pDocumento.cTipoArchivo;
               datasel.idGrupoArchivo    =  frmCarga.pDocumento.idGrupoArchivo;
               datasel.dFechaVigencia    =  frmCarga.pDocumento.dFechaVigencia;
               datasel.lConFechaVigencia =  frmCarga.pDocumento.lConFechaVigencia;
               datasel.lIndefinido       =  frmCarga.pDocumento.lIndefinido;
               datasel.idTipArcOrigen    =  frmCarga.pDocumento.idTipArcOrigen;
               datasel.cTipArcOrigen     =  frmCarga.pDocumento.cTipArcOrigen;
               datasel.idUsuAct          =  frmCarga.pDocumento.idUsuAct;
               datasel.dFecAct           =  frmCarga.pDocumento.dFecAct;
               dtgArchivoxGrupo.RefreshEdit();
               dtgArchivoxGrupo.Refresh();
               MostrarDatos(indexSelDocumento);
            }
        }

        private void btnQuitarArchivo_Click(object sender, EventArgs e)
        { 
                if (datasel == null)
                {
                    MessageBox.Show("Sin datos para eliminar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("¿Está seguro de eliminar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    clsDBResp dtRes = clsConfiguracion.CNEliminarTipoDocumento(datasel);


                    if (dtRes.nMsje == 0)
                    {
                        listaDocumento.Remove(datasel);
                        MessageBox.Show(dtRes.cMsje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(dtRes.cMsje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                } 
        } 
         
        private void conConfiguracionArchivos1_ClicEventosCancelar(object sender, EventArgs e)
        {
            menuStrip1.Enabled = true;
            dtgArchivoxGrupo.Enabled = true;
            cboGrupoCargaArchivo1.Enabled = true;
            
            clsListaConfiguracionTipoArchivoEscaneado listaConfiguracion = clsConfiguracion.CNListarConfiguracionArchivo(datasel.idTipoArchivo);
            conConfiguracionArchivos1.btnNuevo1.Enabled = listaConfiguracion.Count > 0 ? false : true;
            conConfiguracionArchivos1.btnEditar1.Enabled = listaConfiguracion.Count > 0 ? true : false;
            conConfiguracionArchivos1.cargarfigurarCargaArchivoNuevoReg(datasel, listaConfiguracion);

        }

        private void conConfiguracionArchivos1_ClicEventosEditar(object sender, EventArgs e)
        {
            menuStrip1.Enabled = false;
            dtgArchivoxGrupo.Enabled = false;
            cboGrupoCargaArchivo1.Enabled = false;
        }

        private void conConfiguracionArchivos1_ClicEventosGuardar(object sender, EventArgs e)
        {
            menuStrip1.Enabled = true;
            dtgArchivoxGrupo.Enabled = true;
            cboGrupoCargaArchivo1.Enabled = true;
        }

        private void conConfiguracionArchivos1_ClicEventosNuevo(object sender, EventArgs e)
        {
            menuStrip1.Enabled = false;
            dtgArchivoxGrupo.Enabled = false;
            cboGrupoCargaArchivo1.Enabled = false;
        }


        #endregion

        #region Metodos 

        private void cancelarConfiguracion()
        { 
            cboGrupoCargaArchivo1.SelectedIndex = -1; 
        }
        private void btnBusqueda1()
        {
            if (cboGrupoCargaArchivo1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un grupo de archivos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            conConfiguracionArchivos1.Visible = Convert.ToInt32(cboGrupoCargaArchivo1.SelectedValue) != 92;
            lblBase1.Visible = Convert.ToInt32(cboGrupoCargaArchivo1.SelectedValue) == 92;
            listaDocumento = clsConfiguracion.CNListarTipoArchivo(
                0,
                0,
                Convert.ToInt32(cboGrupoCargaArchivo1.SelectedValue)
                );
            this.dtgArchivoxGrupo.RowEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgArchivoxGrupo_RowEnter);
            this.dtgArchivoxGrupo.DataSource = listaDocumento;
            this.dtgArchivoxGrupo.CurrentCell = null;
            this.dtgArchivoxGrupo.ClearSelection();  
            this.dtgArchivoxGrupo.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgArchivoxGrupo_RowEnter); 

        }
        private void MostrarDatos(int filaseleccionada)
        {
            
            if (filaseleccionada >= 0)
            {
                datasel = listaDocumento[filaseleccionada];

                clsListaConfiguracionTipoArchivoEscaneado listaConfiguracion = clsConfiguracion.CNListarConfiguracionArchivo(datasel.idTipoArchivo);
                if (!chcOrdenar.Checked)
                {
                    conConfiguracionArchivos1.btnNuevo1.Enabled = listaConfiguracion.Count > 0 ? false : true;
                    conConfiguracionArchivos1.btnEditar1.Enabled = listaConfiguracion.Count > 0 ? true : false;
                }
                else
                {
                    conConfiguracionArchivos1.btnNuevo1.Enabled = false;
                    conConfiguracionArchivos1.btnEditar1.Enabled = false;
                }
            
                conConfiguracionArchivos1.cargarfigurarCargaArchivoNuevoReg(datasel, listaConfiguracion);
            }

        }
        private void activar(bool lVariable)
        { 
            menuStrip1.Enabled = lVariable;
            cboGrupoCargaArchivo1.Enabled = lVariable;

            dtgArchivoxGrupo.Enabled = lVariable;
        }
        private void activar_btnarchivo(bool lActivar)
        {
            this.chcOrdenar.Enabled = lActivar;
            this.btnGuardarDocumento.Enabled = lActivar;
            this.btnDownDocumento.Enabled = !lActivar;
            this.btnUpDocumento.Enabled = !lActivar;
            this.btnCancelOrden.Enabled = !lActivar;

            this.btnEditarArchivo.Enabled = lActivar;
            this.btnNuevoArchivo.Enabled = lActivar;
            this.btnQuitarArchivo.Enabled = lActivar;

            this.cboGrupoCargaArchivo1.Enabled = lActivar;
            this.cboGrupoCargaArchivo1.Enabled = lActivar; 

            this.conConfiguracionArchivos1.menuStrip1.Enabled = lActivar;
            this.conConfiguracionArchivos1.btnCancelar1.Enabled = lActivar;
            this.conConfiguracionArchivos1.btnGrabar1.Enabled = lActivar;
            this.conConfiguracionArchivos1.btnNuevo1.Enabled = lActivar;
            this.conConfiguracionArchivos1.btnEditar1.Enabled = lActivar;

        }
        private bool habilitarBusqueda()
        {
            if (cboGrupoCargaArchivo1.SelectedIndex == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }      

        #endregion

        private void chcOrdenar_CheckedChanged(object sender, EventArgs e)
        {
            if(chcOrdenar.Checked){ 
                chcOrdenar.Enabled = false;
                listaDocumento = clsConfiguracion.CNListarTipoArchivoGeneral();
                dtgArchivoxGrupo.DataSource = listaDocumento;

                if (listaDocumento.Count <= 0)
                {
                    return;
                }

                this.activar_btnarchivo(false);
            }
        }

   

    }
}
