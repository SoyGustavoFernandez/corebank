using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADM.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase.Model;
using Microsoft.Reporting.WinForms;
using System.IO;
using GEN.Funciones;
using System.Globalization;

namespace GEN.ControlesBase
{
    public partial class conAutDatosBase : UserControl
    {
        public event EventHandler ClicCargarDatos;
        public event EventHandler ClicEditarDatos;
        public string cTipoOpcion = string.Empty;
        public string titulo = string.Empty;
        private int opcionAcceso = 0;
        public bool esOpcionGestionAutUsoDatos = true;
        public int nroCambios = 0;
        ListaAutorizaTratamientoUsoDatos lstDataAutorizaciones = new ListaAutorizaTratamientoUsoDatos();
        public MaestroAutorizacion dataMaestro;
        public conAutDatosBase()
        {
            InitializeComponent();
        }
        public void cargarCanal()
        {
            cboCanal1.cargarCanalRegistro();

        }
        public void cargarDatosNuevo()
        {
            rbtPresencial.Checked = true;
            clsCNMantenimiento mantenimiento = new clsCNMantenimiento();
            lstDataAutorizaciones.Clear();
            var dataregio = mantenimiento.CNObtenerZonasAgenciaGeneral(clsVarGlobal.nIdAgencia);
            cboRegion.SelectedValue = dataregio.Rows[0]["idZona"].ToString();
            cboOficina.SelectedValue = clsVarGlobal.nIdAgencia;
            txtEstablecimiento.Text = clsVarGlobal.User.cEstablecimiento;
            cboCanal1.SelectedValue = 1;
            clsCNTipAutUsoDatos cnobjTipo = new clsCNTipAutUsoDatos();
            DataTable dtTipo = cnobjTipo.CNListaTipoAutUsoDatos();
            dataMaestro = new MaestroAutorizacion();
            dataMaestro.idUsuRegistro = clsVarGlobal.User.idUsuario;
            dataMaestro.dFecRegistro = clsVarGlobal.dFecSystem.Date;
            dataMaestro.idEstablecimiento = clsVarGlobal.User.idEstablecimiento;
            dataMaestro.cEstablecimiento = txtEstablecimiento.Text;
            foreach (DataRow row in dtTipo.Rows)
            {

                AutorizaTratamientoUsoDatos objDataFinal = new AutorizaTratamientoUsoDatos();
                objDataFinal.idAutTraDatos = 0; 
                objDataFinal.nTiempoVigencia = Convert.ToInt32(row["nTiempoVigencia"]); 
                objDataFinal.idTipoAutorizacion = Convert.ToInt32(row["idTipo"]);
                objDataFinal.cTipoAutorizacion = row["cTipo"].ToString();
                objDataFinal.idCanalRegistro = (int)cboCanal1.SelectedValue;
                objDataFinal.cCanalRegistro = cboCanal1.Text; 
                objDataFinal.dFechaInicio = clsVarGlobal.dFecSystem; 
                objDataFinal.idEstado = 5;// NO AUTORIZADO  
                objDataFinal.lVigente = true;
                objDataFinal.idUsuRegistro = clsVarGlobal.User.idUsuario;
                objDataFinal.dFecRegistro = clsVarGlobal.dFecSystem; 
                lstDataAutorizaciones.Add(objDataFinal); 
            } 
            dtgDatoAutorizacion.DataSource = lstDataAutorizaciones;
            if (lstDataAutorizaciones.Count()==3)
            {
                int index = 0;
                foreach (var item in lstDataAutorizaciones)
                {
                    
                    if(item.idTipoAutorizacion==3){
                        dtgDatoAutorizacion.Rows[index].DefaultCellStyle.BackColor = Color.LightGray;
                        dtgDatoAutorizacion.Rows[index].DefaultCellStyle.ForeColor = Color.Black;
                        dtgDatoAutorizacion.Rows[index].DefaultCellStyle.SelectionBackColor = Color.LightGray;
                        dtgDatoAutorizacion.Rows[index].DefaultCellStyle.SelectionForeColor = Color.Black;
                    }
                    index++;
                } 
                
            }
            this.habilitarControles();
        }
 
        public void deshabilitarControles( ){
            this.rbtPresencial.Enabled = false;
            this.rbtRemoto.Enabled = false;
            this.txtComentario.Enabled = false;
            this.cboMotivoAutUsoDatos1.Enabled = false;
            this.dtgDatoAutorizacion.ReadOnly = true;
            this.btnAdjuntarFile1.Enabled = false;
        }
        public void habilitarControles()
        {
            this.rbtPresencial.Enabled = true;
            this.rbtRemoto.Enabled = true;
            this.txtComentario.Enabled = true;
            this.cboMotivoAutUsoDatos1.Enabled = true;
            this.dtgDatoAutorizacion.ReadOnly = false;
            this.dtgDatoAutorizacion.Columns["lIndicadorConcentimientoDataGridViewCheckBoxColumn"].ReadOnly = false;
            foreach (DataGridViewColumn col in dtgDatoAutorizacion.Columns)
            {
                foreach (DataGridViewRow row in dtgDatoAutorizacion.Rows)
                { 
                    if (col.Name.Equals("lIndicadorConcentimientoDataGridViewCheckBoxColumn") && row.Index != 2)
                    { 
                        row.Cells[col.Index].ReadOnly = false;
                    }
                    else
                    {
                        row.Cells[col.Index].ReadOnly = true; 
                    }
                } 
            }
        }
        public void habilitarEdicion()
        {
            this.btnAdjuntarFile1.Enabled = true;
            this.btnAdjuntarFile1.Visible = true;
        }
        public void limpiarArchivoEdicion()
        {
            dataMaestro.cArchivo = null;
            dataMaestro.cArchivoBinary = null;          
        }
        public void limpiarTodoEdicion()
        {   
            dataMaestro.cArchivo = null;
            dataMaestro.cArchivoBinary = null;            
            dataMaestro.cDescripcion = string.Empty;
            dataMaestro.idMotivo = 1;
            cboMotivoAutUsoDatos1.SelectedIndex = -1;
            txtComentario.Clear();
            rbtPresencial.Checked = true;
        }

        public async Task<bool> grabarAutorizacionDatos(int idTipoDocumento,int IdTipoPersona, string cNroDoc, string cNombre, string cDireccion, string cTelefono, string cCodCliente, int idCli, bool lIngresaDatos, int idMaestroAutOrigen=0)
        {
            if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 1)
            {
                if (ValidarDatos(idTipoDocumento, cNroDoc,   cNombre,   cDireccion,   cTelefono,lIngresaDatos ).ToUpper().Equals("ERROR"))
                {
                    return false;
                }
              
                this.cprogressbar2.Visible = true;
                dataMaestro.idMaestroAutorizacion = idMaestroAutOrigen != 0 ? 0 : dataMaestro.idMaestroAutorizacion;
                dataMaestro.detalleAutorizacion = new List<AutorizaTratamientoUsoDatosDTO>(); 
                dataMaestro.cNroDocumento = cNroDoc.Trim();
                dataMaestro.cNomCliente = cNombre.Trim();
                dataMaestro.cDireccion = cDireccion.Trim();
                dataMaestro.idTipoDocumento = idTipoDocumento;
                dataMaestro.IdTipoPersona   = IdTipoPersona;
                dataMaestro.cTelefono = cTelefono ;
                dataMaestro.idCli = idCli;
                dataMaestro.cCodCliente = cCodCliente;
                dataMaestro.cDescripcion = txtComentario.Text.Trim();
                dataMaestro.idRegion = (int)cboRegion.SelectedValue;
                dataMaestro.cRegion = cboRegion.Text;
                dataMaestro.idOficina = (int)cboOficina.SelectedValue;
                dataMaestro.cOficina = cboOficina.Text;
                dataMaestro.idCanalRegistro = (int)cboCanal1.SelectedValue;
                dataMaestro.lVigente = true;
                dataMaestro.idUsuRegistro = clsVarGlobal.User.idUsuario;
                dataMaestro.dFecRegistro = clsVarGlobal.dFecSystem.Date;
                dataMaestro.idTipModAutTraDatos = rbtPresencial.Checked?1:2;
                dataMaestro.idMaestroAutOrigen = idMaestroAutOrigen;
               
             
                foreach (var item in lstDataAutorizaciones)
                {
                    AutorizaTratamientoUsoDatosDTO _det = new AutorizaTratamientoUsoDatosDTO();
                    _det.idAutTraDatos = item.idAutTraDatos; 
                    _det.idTipoAutorizacion = item.idTipoAutorizacion; 
                    _det.dFechaInicio =item.dFechaInicio;
                    _det.dFechaFin = item.dFechaFin;  
                    _det.nTiempoVigencia = item.nTiempoVigencia;
                    _det.idEstado = item.idEstado;
                    _det.lIndicadorConcentimiento = item.lIndicadorConcentimiento;
                    _det.lVigente = true;
                    if (_det.idAutTraDatos != 0)
                    {
                        _det.dFecModifica = clsVarGlobal.dFecSystem.Date;
                        _det.idUsuModifica = clsVarGlobal.User.idUsuario;
                    }
                    else if (_det.idAutTraDatos == 0)
                    {
                        _det.dFecRegistro = clsVarGlobal.dFecSystem.Date;
                        _det.idUsuRegistro = clsVarGlobal.User.idUsuario;
                    }
                    dataMaestro.detalleAutorizacion.Add(_det);
                } 
                byte[] bArchivoBinary = null;
                string cNombreArchivo="", carchivo="";
               
                if (dataMaestro.idTipModAutTraDatos == 1)
                {
                    if (dataMaestro.idTipoDocumento == 1)
                    {
                        if (ToolAutorizacion.validarHuella(0, idCli, cNroDoc, cNombre))
                        {
                            dataMaestro.idModalidad = 1;// AUTENTICACIÓN BIOMETRICO
                            dataMaestro.cArchivo = cNombreArchivo;
                            bArchivoBinary = generarInformePDF(cNroDoc, ref cNombreArchivo, ref carchivo);
                            dataMaestro.idMotivo = 0;
                            dataMaestro.cArchivoBinary = clsAuditoria.ByteArray2String(bArchivoBinary);
                            dataMaestro.cArchivo = carchivo;
                            RespuestaAutTraDatos respuesta = await this.guardarnuevo(dataMaestro);
                            return respuesta.lResultado;
                        }
                        else
                        {
                            dataMaestro.idModalidad = 2;
                            bArchivoBinary = generarInformePDF(cNroDoc, ref cNombreArchivo, ref carchivo);

                            frmMotivoAutUsoDatos frmMotAut = new frmMotivoAutUsoDatos(carchivo, bArchivoBinary);
                            frmMotAut.ShowDialog();
                            if (frmMotAut.lAceptar)
                            {
                                dataMaestro.cArchivo = frmMotAut.cNombreDocumento;

                                dataMaestro.idMotivo = frmMotAut.idMotivo;
                                dataMaestro.cArchivoBinary = clsAuditoria.ByteArray2String(frmMotAut.bArchivoBinary);
                                dataMaestro.cArchivo = carchivo;
                                RespuestaAutTraDatos respuesta = await this.guardarnuevo(dataMaestro);
                                return respuesta.lResultado;
                            }
                            else
                            {
                                this.cprogressbar2.Visible = false;
                                return false;
                            }
                        }
                    }else 
                    {
                        dataMaestro.idModalidad = 2;
                        bArchivoBinary = generarInformePDF(cNroDoc, ref cNombreArchivo, ref carchivo);

                        frmMotivoAutUsoDatos frmMotAut = new frmMotivoAutUsoDatos(carchivo, bArchivoBinary);
                        frmMotAut.ShowDialog();
                        if (frmMotAut.lAceptar)
                        {
                            dataMaestro.cArchivo = frmMotAut.cNombreDocumento;

                            dataMaestro.idMotivo = frmMotAut.idMotivo;
                            dataMaestro.cArchivoBinary = clsAuditoria.ByteArray2String(frmMotAut.bArchivoBinary);
                            dataMaestro.cArchivo = carchivo;
                            RespuestaAutTraDatos respuesta = await this.guardarnuevo(dataMaestro);
                            return respuesta.lResultado;
                        }
                        else
                        {
                            this.cprogressbar2.Visible = false;
                            return false;
                        }
                    }
                    
                }
                else
                {
                    dataMaestro.idModalidad = 2;// AUTENTICACIÓN SIN BIOMETRICO
                    if (!rbtRemoto.Checked)
                    {
                        bArchivoBinary = generarInformePDF(cNroDoc, ref cNombreArchivo, ref carchivo);
                        dataMaestro.cArchivo = cNombreArchivo;   
                        dataMaestro.cArchivoBinary = clsAuditoria.ByteArray2String(bArchivoBinary);
                        dataMaestro.cArchivo = carchivo;
                    }    
                    if (dataMaestro.idTipModAutTraDatos == 2)
                    {
                        dataMaestro.idMotivo = Convert.ToInt32(cboMotivoAutUsoDatos1.SelectedValue);
                    }
                    else
                    {
                        dataMaestro.idMotivo = 0;
                    }
                    RespuestaAutTraDatos respuesta = await this.guardarnuevo(dataMaestro);
                    return respuesta.lResultado; 
                }
                
            }
            else
            {
                MessageBox.Show("Servicio de autorización de uso de datos no habilitado.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }       
        }
        public async Task<bool> grabarEdicionArchivoAutorizacionDatos()
        {
            if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 1)
            { 
                this.cprogressbar2.Visible = true; 
                dataMaestro.idUsuModifica = clsVarGlobal.User.idUsuario;
                dataMaestro.dFecModifica = clsVarGlobal.dFecSystem.Date;
              
                if (rbtRemoto.Checked && string.IsNullOrEmpty(dataMaestro.cArchivoBinary))
                {
                    MessageBox.Show("Debe adjuntar documento de la autorización.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnAdjuntarFile1.Focus();
                    this.cprogressbar2.Visible = false;
                    return false;

                } 
                RespuestaAutTraDatos respuesta = await this.guardarnuevo(dataMaestro);
                return respuesta.lResultado;
            }
            else
            {
                MessageBox.Show("Servicio de autorización de uso de datos no habilitado.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
     
        private string ValidarDatos(int idTipoDocumento,string cNroDoc, string cNombre, string cDireccion,string cTelefono, bool lIngresarDatos)
        {
            if ((idTipoDocumento <= 0))
            {
                MessageBox.Show("Elija el tipo de documento.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return "ERROR";
            }
            if (string.IsNullOrEmpty(cNroDoc))
            {
                MessageBox.Show("Ingrese nro de documento del cliente.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                return "ERROR";
            }
            
            if ((idTipoDocumento == 1 && cNroDoc.Length != 8))
            {
                MessageBox.Show("Ingrese nro de documento válido.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                return "ERROR";
            }
            if (string.IsNullOrEmpty(cNombre) || cNombre.Length < 5)
            {
                MessageBox.Show("Ingrese nombres del cliente.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
                return "ERROR";
            }
            if (lIngresarDatos)
            {

                if (string.IsNullOrEmpty(cDireccion) || cDireccion.Length < 5)
                {
                    MessageBox.Show("Ingrese dirección del cliente.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                    return "ERROR";
                }
                if (string.IsNullOrEmpty(cTelefono))
                {
                    MessageBox.Show("Ingrese número de teléfono del cliente.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                    return "ERROR";
                }
            }
           if (lstDataAutorizaciones.Count(x => x.lIndicadorConcentimiento == true)<=0)
            {
                MessageBox.Show("Debe elegir por lo menos un tipo de autorización.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);  
                return "ERROR";
            }
            if (string.IsNullOrEmpty(cboRegion.Text.Trim()) || cboRegion.SelectedIndex == -1)
            {
                MessageBox.Show("Ingrese región.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboRegion.Focus();
                return "ERROR";
            }
            if (string.IsNullOrEmpty(cboOficina.Text.Trim()) || cboOficina.SelectedIndex == -1)
            {
                MessageBox.Show("Ingrese la oficina de autorización.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboOficina.Focus();
                return "ERROR";
            }
            if (rbtRemoto.Checked && cboMotivoAutUsoDatos1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe elegir un motivo.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCanal1.Focus();
                return "ERROR";
            }
            if (rbtRemoto.Checked && String.IsNullOrEmpty(txtComentario.Text.Trim()))
            {
                MessageBox.Show("Ingrese el comentario para la modalidad remoto.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCanal1.Focus();
                return "ERROR";
            }
            if (string.IsNullOrEmpty(cboCanal1.Text.Trim()) || cboCanal1.SelectedIndex == -1)
            {
                MessageBox.Show("Ingrese el canal de autorización.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCanal1.Focus();
                return "ERROR";
            }
            if (rbtRemoto.Checked && string.IsNullOrEmpty(dataMaestro.cArchivoBinary))
            {
                MessageBox.Show("Debe adjuntar documento de la autorización.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnAdjuntarFile1.Focus();
                return "ERROR";

            }           
            return "OK";
        }
        public void limpiarContenido(){
            lstDataAutorizaciones.Clear();
            cboCanal1.SelectedIndex=-1;
            cboRegion.SelectedIndex = -1;
            cboOficina.SelectedIndex = -1;
            cboMotivoAutUsoDatos1.SelectedIndex = -1;
            txtComentario.Clear();
            dataMaestro = null;
            lstDataAutorizaciones = new ListaAutorizaTratamientoUsoDatos();
        }
        private void dtgDatoAutorizacion_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 20) // Columna del checkbox
            {
                if (this.dtgDatoAutorizacion.ReadOnly)
                {
                    return;
                }

                dtgDatoAutorizacion.CommitEdit(DataGridViewDataErrorContexts.Commit);
                if (e.RowIndex<0)
                {
                    return;
                }
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dtgDatoAutorizacion.Rows[e.RowIndex].Cells[e.ColumnIndex];
                var datasel = (AutorizaTratamientoUsoDatos)dtgDatoAutorizacion.CurrentRow.DataBoundItem;
                if (chk.Value == null || (bool)chk.Value == false)
                {
                    if (datasel.idTipoAutorizacion == 1)
                    {
                        lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 3).FirstOrDefault().lIndicadorConcentimiento = false;
                        lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 3).FirstOrDefault().idEstado = 2;

                        lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 2).FirstOrDefault().lIndicadorConcentimiento = false;
                        lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 2).FirstOrDefault().idEstado = 2;
                    }
                    else if (datasel.idTipoAutorizacion == 2)
                    {
                        lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 2).FirstOrDefault().lIndicadorConcentimiento = false;
                        lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 2).FirstOrDefault().idEstado = 2;
                        if (dataMaestro.detalleAutorizacion != null)
                        {   
                            dataMaestro.detalleAutorizacion.Where(x => x.idTipoAutorizacion == 2).FirstOrDefault().lIndicadorConcentimiento = false;
                            dataMaestro.detalleAutorizacion.Where(x => x.idTipoAutorizacion == 2).FirstOrDefault().idEstado = 2; 
                        }

                        int idMaestroAutorizacion = dataMaestro.idMaestroAutorizacion;
                        dataMaestro.idMaestroAutorizacion = 0;
                        dataMaestro.idMaestroAutOrigen =dataMaestro.idMaestroAutOrigen != 0 ? dataMaestro.idMaestroAutOrigen : idMaestroAutorizacion;

                    }
                    dtgDatoAutorizacion.Refresh();
                }
                else
                {
                    if (dataMaestro != null)
                    {
                        if (dataMaestro.idMaestroAutorizacion > 0 )
                        {
                            if (datasel.idTipoAutorizacion == 2 && chk.ReadOnly == false)
                            {
                                lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 2).FirstOrDefault().lIndicadorConcentimiento = true;
                                lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 2).FirstOrDefault().idEstado = 1;
                                dataMaestro.detalleAutorizacion.Where(x => x.idTipoAutorizacion == 2).FirstOrDefault().lIndicadorConcentimiento = true;
                                dataMaestro.detalleAutorizacion.Where(x => x.idTipoAutorizacion == 2).FirstOrDefault().idEstado = 1; 

                                int idMaestroAutorizacion = dataMaestro.idMaestroAutorizacion; 
                                dataMaestro.idMaestroAutorizacion = 0; 
                                dataMaestro.idMaestroAutOrigen = dataMaestro.idMaestroAutOrigen != 0 ? dataMaestro.idMaestroAutOrigen : idMaestroAutorizacion;

                                if (ClicEditarDatos != null)
                                    ClicEditarDatos(sender, e);
                            }
                        }
                        else
                        {
                            if (datasel.idTipoAutorizacion == 1)
                            {
                                lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 3).FirstOrDefault().lIndicadorConcentimiento = true;
                                lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 3).FirstOrDefault().idEstado = 1;
                                datasel.idEstado = 1;
                                if (dataMaestro.detalleAutorizacion != null)
                                {
                                    dataMaestro.detalleAutorizacion.Where(x => x.idTipoAutorizacion == 1).FirstOrDefault().lIndicadorConcentimiento = true;
                                    dataMaestro.detalleAutorizacion.Where(x => x.idTipoAutorizacion == 1).FirstOrDefault().idEstado = 1;
                                }
                            }
                            else if (datasel.idTipoAutorizacion == 2 && lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 1).FirstOrDefault().lIndicadorConcentimiento == true){
                                 datasel.idEstado = 1;
                                 if (dataMaestro.detalleAutorizacion != null)
                                 {
                                     dataMaestro.detalleAutorizacion.Where(x => x.idTipoAutorizacion == 2).FirstOrDefault().lIndicadorConcentimiento = true;
                                     dataMaestro.detalleAutorizacion.Where(x => x.idTipoAutorizacion == 2).FirstOrDefault().idEstado = 1;
                                 }

                            }
                            else if (datasel.idTipoAutorizacion == 2 && lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 1).FirstOrDefault().lIndicadorConcentimiento == false)
                            {


                                lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 2).FirstOrDefault().lIndicadorConcentimiento = false;
                                datasel.idEstado = 2;

                                MessageBox.Show("Primero debe autorizar el tipo " + lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 1).FirstOrDefault().cTipoAutorizacion + ". ", "Autorización de uso de datos del cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            }

                        }
                    }
                    else
                    {
                        if (datasel.idTipoAutorizacion == 1)
                        {
                            lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 3).FirstOrDefault().lIndicadorConcentimiento = true;
                            lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 3).FirstOrDefault().idEstado = 1;
                            datasel.idEstado = 1;
                        }
                        else if (datasel.idTipoAutorizacion == 2 && lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 1).FirstOrDefault().lIndicadorConcentimiento == true)
                        {
                            datasel.idEstado = 1;
                        }
                        else if (datasel.idTipoAutorizacion == 2 && lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 1).FirstOrDefault().lIndicadorConcentimiento == false)
                        {


                            lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 2).FirstOrDefault().lIndicadorConcentimiento = false;
                            datasel.idEstado = 2;
                            MessageBox.Show("Primero debe autorizar el tipo " + lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 1).FirstOrDefault().cTipoAutorizacion + ". ", "Autorización de uso de datos del cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }

                    }
                    
                    dtgDatoAutorizacion.RefreshEdit();
                    dtgDatoAutorizacion.Refresh();
                }
            }
            dtgDatoAutorizacion.EndEdit();
            dtgDatoAutorizacion.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);

        }
        private async Task<RespuestaAutTraDatos> guardarnuevo(MaestroAutorizacion dato)
        {
            clsApiRespuesta oRespuesta = new clsApiRespuesta();
            RespuestaAutTraDatos respuesta = new RespuestaAutTraDatos();
            respuesta.lResultado = false;

            string Uri = clsVarApl.dicVarGen["CRUTAAUTUSODATOS"] + "AutTratamientoUsoDatos";

            //poblamos el objeto con el método generic Execute
            oRespuesta = await clsApiConsumer.Execute<RespuestaAutTraDatos>(Uri, methodHttp.POST, dato);
            //Poblamos el datagridview
            respuesta = (RespuestaAutTraDatos)oRespuesta.Data;
            //Mostramos el statuscode devuelto, podemos añadirle lógica de validación
            if (oRespuesta.StatusCode == "OK")
            {
                dataMaestro.idMaestroAutorizacion = Convert.ToInt32(respuesta.nCodigo);
                dataMaestro.idMaestroAutOrigen = 0;
                this.cprogressbar2.Visible = false;
                this.deshabilitarControles();
                MessageBox.Show(oRespuesta.StatusCode + ": " + respuesta.cMensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                return respuesta;
            }
            else
            {
                MessageBox.Show("Error al registrar los datos.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            this.cprogressbar2.Visible = false;
            return respuesta;
        }
        public byte[] generarInformePDF(string cNroDoc, ref string cNombreArchivo, ref string carchivo)
        {   
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            var autEnvioInfor = lstDataAutorizaciones.FirstOrDefault(x => x.idTipoAutorizacion == 2);
            paramlist.Add(new ReportParameter("cNombre", dataMaestro.cNomCliente, false));
            paramlist.Add(new ReportParameter("cDireccion", dataMaestro.cDireccion, false));
            paramlist.Add(new ReportParameter("IdTipoPersona", dataMaestro.IdTipoPersona.ToString(), false));
            paramlist.Add(new ReportParameter("cDocumentoID", dataMaestro.cNroDocumento, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("idEstadoConcentimiento", (autEnvioInfor.lIndicadorConcentimiento ? "1" : "2"), false));
            paramlist.Add(new ReportParameter("cTelefonico", dataMaestro.cTelefono, false));
            paramlist.Add(new ReportParameter("cCorreo", dataMaestro.cCorreo, false));
            paramlist.Add(new ReportParameter("idModAutTraDatos", dataMaestro.idModalidad.ToString(), false)); 
 
            var autUsoDatos = lstDataAutorizaciones.FirstOrDefault(x => x.idTipoAutorizacion == 1);
            string cOfina=cboOficina.Text;
            string dia = autUsoDatos.dFecRegistro.Day.ToString();
            string mes = autUsoDatos.dFecRegistro.Month.ToString();
            string año = autUsoDatos.dFecRegistro.Year.ToString();
            string cDescripcionFecha = String.Format("En la oficina de {0} a los {1} días del mes de {2} del año {3}.", cOfina.Trim().Replace("OFICINA - ", ""), dia, this.NombreMes(Convert.ToInt32(mes)), año);
            paramlist.Add(new ReportParameter("cDescripcionFecha", cDescripcionFecha, false));

            carchivo = "";
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            cNombreArchivo = cNroDoc + "" + clsVarGlobal.dFecSystem.Date.ToShortDateString().Replace("/", "");

         
            return  ToolAutorizacion.GenerarDocumento("rptFormatoAutUsoDatos.rdlc", cNombreArchivo, paramlist, dtslist, ref carchivo);

        }
        public string NombreMes(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }
        private void conAutDatosBase_Load(object sender, EventArgs e)
        {
            this.deshabilitarControles();
            cboRegion.SelectedIndex = -1;
            cboOficina.SelectedIndex = -1;
            cboCanal1.SelectedIndex = -1;
            txtComentario.Text = string.Empty;
            cboMotivoAutUsoDatos1.SelectedIndex = -1;
            rbtRemoto.Checked = false;
            rbtPresencial.Checked = true;
             lstDataAutorizaciones.Clear();
             cboMotivoAutUsoDatos1.Visible = false;
             lblMotivo.Visible = false;
             cboMotivoAutUsoDatos1.cboMotivoAutUsoDatosRemoto();
        }

        private void rbtRemoto_CheckedChanged(object sender, EventArgs e)
        {
            this.btnAdjuntarFile1.Enabled = rbtRemoto.Checked;
            this.lblBase5.Visible = true;
            this.txtComentario.Visible = true; 
            this.cboMotivoAutUsoDatos1.Visible = rbtRemoto.Checked;
            this.lblMotivo.Visible = rbtRemoto.Checked;
            if (rbtRemoto.Checked)
            {
                if (dataMaestro == null || dataMaestro.idMaestroAutorizacion==0)
                {
                    this.cboMotivoAutUsoDatos1.SelectedIndex = -1;
                    this.cboMotivoAutUsoDatos1.Enabled = true;
                    this.txtComentario.Enabled = true;
                }
            }
        
        }

        private void rbtPresencial_CheckedChanged(object sender, EventArgs e)
        {
            this.btnAdjuntarFile1.Enabled = !rbtPresencial.Checked;
            this.lblBase5.Visible = false;
            this.txtComentario.Visible = false;
        }

        private void btnAdjuntarFile1_Click(object sender, EventArgs e)
        {
            this.btnAdjuntarFile1.Enabled = false;
            dataMaestro.cArchivoBinary = string.Empty;
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Abrir archivo";
            fDialog.InitialDirectory = clsVarGlobal.cRutPathApp;
            fDialog.Multiselect = false;
            fDialog.Filter = "PDF Documents|*.pdf";

            if (fDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo fi = new FileInfo(fDialog.FileName);
                long fileSize = fi.Length;
                int maxSize = clsVarApl.dicVarGen["cMaxFileAutUsoDat"];
                if (fileSize > maxSize)
                {
                    MessageBox.Show("El archivo es de " + fileSize + " bytes, exedio el limite de subida de archivos, maximo de " + maxSize + " bytes", "Adjuntar Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.btnAdjuntarFile1.Enabled = true;
                }
                else
                {
                    string cArchivo = fDialog.FileName;
                    FileInfo fInfo = new FileInfo(cArchivo);
                    long numBytes = fInfo.Length;
                    FileStream fStream = new FileStream(cArchivo, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fStream);

                    string nameFile = cArchivo;
                    byte[] vDocumentoSesion = br.ReadBytes((int)numBytes);
                    fStream.Flush();
                    fStream.Close();
                    br.Close();
                    dataMaestro.cArchivo = fInfo.Name;
                    dataMaestro.cArchivoBinary = clsAuditoria.ByteArray2String(Compresion.CompressedByte(vDocumentoSesion));
                    this.btnAdjuntarFile1.Enabled = true;
                }
            }
            else
            {
                this.btnAdjuntarFile1.Enabled = true;
            }
        }

        public async Task<bool> BuscarAutTratamientoDatos(int nidTipoDocumento ,string nroDocumento, object sender, EventArgs e)
        {
            cprogressbar2.Visible = true;
            string Uri = clsVarApl.dicVarGen["CRUTAAUTUSODATOS"] + "AutTratamientoUsoDatos?id=" + nroDocumento + "&idEstado=0" + "&idTipoDoc=" + nidTipoDocumento.ToString();

            //Creamos el listado de Posts a llenar
            FiltroReporteAutorizacion dataFiltro = new FiltroReporteAutorizacion();
            //Instanciamos un objeto Reply
            clsApiRespuesta oRespuesta = new clsApiRespuesta();
            //poblamos el objeto con el método generic Execute
            oRespuesta = await clsApiConsumer.Execute<RespLisAutorizacionTraDatos>(Uri, methodHttp.GET, dataFiltro);
            //Poblamos el datagridview
            RespLisAutorizacionTraDatos respuesta = (RespLisAutorizacionTraDatos)oRespuesta.Data;


            //Mostramos el statuscode devuelto, podemos añadirle lógica de validación
            if (oRespuesta.StatusCode == "OK")
            {
                lstDataAutorizaciones.Clear();

                if (respuesta.MaestroAutTratamientoDatos != null)
                {
                    dataMaestro = respuesta.MaestroAutTratamientoDatos;
                    foreach (var item in respuesta.MaestroAutTratamientoDatos.detalleAutorizacion)
                    {
                        AutorizaTratamientoUsoDatos objDataFinal = new AutorizaTratamientoUsoDatos();
                        objDataFinal.idAutTraDatos = item.idAutTraDatos;
                         
                        objDataFinal.nTiempoVigencia = item.nTiempoVigencia; 
                        objDataFinal.idTipoAutorizacion = item.idTipoAutorizacion;
                        objDataFinal.cTipoAutorizacion = item.cTipoAutorizacion; 
                        objDataFinal.lIndicadorConcentimiento = item.lIndicadorConcentimiento;
                        objDataFinal.dFechaInicio = item.dFechaInicio;
                        objDataFinal.dFechaFin = item.dFechaFin;
                        objDataFinal.idEstado = item.idEstado;
                        objDataFinal.cEstado = item.cEstado;
                        objDataFinal.cResponsable = item.cResponsable; 
                        objDataFinal.lVigente = item.lVigente;
                        objDataFinal.idUsuRegistro = item.idUsuRegistro==0? clsVarGlobal.User.idUsuario : item.idUsuRegistro; 
                        objDataFinal.dFecRegistro = item.dFecRegistro == Convert.ToDateTime("01/01/0001") ? clsVarGlobal.dFecSystem : item.dFecRegistro;
                        objDataFinal.idUsuModifica = item.idUsuModifica;
                        objDataFinal.dFecModifica = item.dFecModifica;
                        lstDataAutorizaciones.Add(objDataFinal);
                    }
             
                    this.dtgDatoAutorizacion.DataSource = lstDataAutorizaciones; 
                    this.cargarDatos();
                    this.btnAdjuntarFile1.Enabled = false;
              
                }
                cprogressbar2.Visible = false;
                if (ClicCargarDatos != null)
                    ClicCargarDatos(sender, e);
                return true;
                
            }
            else
            {
                MessageBox.Show("Error al buscar los datos.", titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            cprogressbar2.Visible = false;
            return false;
        }
        public void habilitarBotonAdjuntar(bool lEstado )
        {
            this.btnAdjuntarFile1.Enabled = lEstado;

        }

        public void habilitarControlEdicion()
        {
            if (rbtRemoto.Checked)
            {
                this.btnAdjuntarFile1.Enabled = true;
                rbtPresencial.Enabled = true;
                if (rbtRemoto.Checked)
                {
                    cboMotivoAutUsoDatos1.Enabled = true;
                    txtComentario.Enabled = true;
                    txtComentario.Enabled = true;
                    // txtComentario.Clear();
                }
                rbtRemoto.Enabled = true;

            }
            else if (rbtPresencial.Checked)
            {
                rbtPresencial.Enabled = true;
                rbtRemoto.Enabled = true;

            }
        }
        public void habilitarControlesEdicionGestions()
        {
            opcionAcceso = 1;
            if (dataMaestro != null)
            {
                if (dataMaestro.idMaestroAutorizacion > 0)
                {
                    if (lstDataAutorizaciones.Count(x => x.idTipoAutorizacion == 2) > 0)
                    {
                        this.dtgDatoAutorizacion.ReadOnly = false;
                        this.dtgDatoAutorizacion.Columns["lIndicadorConcentimientoDataGridViewCheckBoxColumn"].ReadOnly = false;

                        foreach (DataGridViewColumn col in dtgDatoAutorizacion.Columns)
                        {
                            foreach (DataGridViewRow row in dtgDatoAutorizacion.Rows)
                            {

                                var idTipAut = Convert.ToInt32(row.Cells["idTipoAutorizacionDataGridViewTextBoxColumn"].Value);
                                if (idTipAut == 2 && col.Index == 20)
                                {
                                    row.Cells[col.Index].ReadOnly = false;
                                }
                                else
                                {
                                    row.Cells[col.Index].ReadOnly = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        public void habilitarControlesEdicion()
        {
            if (dataMaestro != null)
            {
                if (dataMaestro.idMaestroAutorizacion > 0)
                {
                    if (lstDataAutorizaciones.Count(x => x.idTipoAutorizacion == 2 && x.lIndicadorConcentimiento == false) > 0)
                    {
                        this.dtgDatoAutorizacion.ReadOnly = false;
                        this.dtgDatoAutorizacion.Columns["lIndicadorConcentimientoDataGridViewCheckBoxColumn"].ReadOnly = false;

                        foreach (DataGridViewColumn col in dtgDatoAutorizacion.Columns)
                        {
                            foreach (DataGridViewRow row in dtgDatoAutorizacion.Rows)
                            {

                                var idTipAut = Convert.ToInt32(row.Cells["idTipoAutorizacionDataGridViewTextBoxColumn"].Value);
                                if (col.Name.Equals("lIndicadorConcentimientoDataGridViewCheckBoxColumn") && idTipAut == 2 && !Convert.ToBoolean(row.Cells[col.Index].Value))
                                {
                                    row.Cells[col.Index].ReadOnly = false;
                                }
                                else
                                {
                                    row.Cells[col.Index].ReadOnly = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void dtgDatoAutorizacion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dtgDatoAutorizacion.CommitEdit(DataGridViewDataErrorContexts.Commit);

        }
        private void cargarDatos(){
            if(dataMaestro != null)
            {
                txtComentario.Text = dataMaestro.cDescripcion;
                cboRegion.SelectedValue = dataMaestro.idRegion;
                cboOficina.SelectedValue = dataMaestro.idOficina;
                cboCanal1.SelectedValue = dataMaestro.idCanalRegistro;
                rbtPresencial.Checked = dataMaestro.idTipModAutTraDatos == 1;
                rbtRemoto.Checked = dataMaestro.idTipModAutTraDatos == 2;
                txtEstablecimiento.Text = dataMaestro.cEstablecimiento;
                cboMotivoAutUsoDatos1.SelectedValue = dataMaestro.idMotivo;
            }
        
        }

        private void dtgDatoAutorizacion_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtgDatoAutorizacion.DataSource != null)
            {
                if (this.dtgDatoAutorizacion.ReadOnly)
                {
                    return;
                }

                if (e.ColumnIndex == dtgDatoAutorizacion.Columns["lIndicadorConcentimientoDataGridViewCheckBoxColumn"].Index && e.RowIndex != -1)
                {
                    ActualizaEstadoAutorizacion();
                    dtgDatoAutorizacion.EndEdit();

                }
            }
        }

        private void dtgDatoAutorizacion_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgDatoAutorizacion.CurrentCell is DataGridViewCheckBoxCell)
                dtgDatoAutorizacion.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void ActualizaEstadoAutorizacion()
        {
            var datasel = (AutorizaTratamientoUsoDatos)dtgDatoAutorizacion.CurrentRow.DataBoundItem;
          
                if (datasel.idTipoAutorizacion == 1)
                {
                    lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 3).FirstOrDefault().lIndicadorConcentimiento = datasel.lIndicadorConcentimiento;
                    lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 3).FirstOrDefault().idEstado = datasel.lIndicadorConcentimiento? 1 : 2;
                    if (!datasel.lIndicadorConcentimiento)
                    {
                        lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 2).FirstOrDefault().lIndicadorConcentimiento = false;
                        lstDataAutorizaciones.Where(x => x.idTipoAutorizacion == 2).FirstOrDefault().idEstado = 2;
                    }
                   
                }
                if (datasel.idTipoAutorizacion == 2 && rbtRemoto.Checked)
                {
                    this.btnAdjuntarFile1.Enabled = true;
                    rbtPresencial.Enabled = true;
                    if (rbtRemoto.Checked)
                    {
                        cboMotivoAutUsoDatos1.Enabled = true;
                        txtComentario.Enabled = true;
                        txtComentario.Enabled = true;
                       // txtComentario.Clear();
                    }
                    rbtRemoto.Enabled = true;
                    if (!esOpcionGestionAutUsoDatos)
                    {
                        if (nroCambios==0)
                        {
                            dataMaestro.cArchivo = null;
                            dataMaestro.cArchivoBinary = null;
                            dataMaestro.cDescripcion = string.Empty;
                            dataMaestro.idMotivo = 1;
                            cboMotivoAutUsoDatos1.SelectedIndex = -1;
                            txtComentario.Clear();
                            rbtPresencial.Checked = true;
                            nroCambios++;
                        }                                 
                    }
                }
                else if (datasel.idTipoAutorizacion == 2 && rbtPresencial.Checked)
                {
                    rbtPresencial.Enabled = true;
                    rbtRemoto.Enabled = true;
                    if (!esOpcionGestionAutUsoDatos)
                    {
                        if (nroCambios == 0)
                        {
                            dataMaestro.cArchivo = null;
                            dataMaestro.cArchivoBinary = null;
                            dataMaestro.cDescripcion = string.Empty;
                            dataMaestro.idMotivo = 1;
                            cboMotivoAutUsoDatos1.SelectedIndex = -1;
                            txtComentario.Clear();
                            rbtPresencial.Checked = true;
                            nroCambios++;
                        }      
                    }
                }
                 
                dtgDatoAutorizacion.Refresh();
                dtgDatoAutorizacion.EndEdit();
           

        }
    }
}
