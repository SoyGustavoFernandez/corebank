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
    public partial class frmCargarVoucherTramite : frmBase
    {        
        public int idCuenta;
        private DataTable dtGrupoArchivo;
        private CRE.CapaNegocio.clsCNAdministracionFiles clsFiles = new CRE.CapaNegocio.clsCNAdministracionFiles();
        private CRE.CapaNegocio.clsCNCargaArchivo objCNCargaArchivo = new CRE.CapaNegocio.clsCNCargaArchivo();
        private List<string> fileVistos = new List<string>();
        private List<int> lstTipoArchivoEscaneadoSustento = new List<int>();
        private List<clsSustentoArchivoPagare> lstSustentoVinculacionArchivo = new List<clsSustentoArchivoPagare>();        
        private int idUsuarioReg = clsVarGlobal.User.idUsuario;
        private int idSolicitud = 0;
        private DateTime dFechaSys = clsVarGlobal.dFecSystem;

        public frmCargarVoucherTramite()
        {
            InitializeComponent();       
        }
        
        public frmCargarVoucherTramite(int idSolicitud_ )
        {
            InitializeComponent();
            idSolicitud = idSolicitud_;
        }
        
        private void frmCargarVoucherTramite_Load(object sender, EventArgs e)
        {
            if (idSolicitud == 0)
            {
                ListarVoucher(idUsuarioReg, 0);
            }
            else
            {
                btnGrabar1.Visible = false;
                ListarVoucher(0, idSolicitud);
            }
        }  
        
        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormatoPrePago()
        {         
            foreach (DataGridViewColumn item in dtgListaVoucher.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgListaVoucher.Columns["idSolicitudTramite"].Visible = true;
            dtgListaVoucher.Columns["cTipoOperacion"].Visible = true;
            dtgListaVoucher.Columns["idPlanPagos"].Visible = true;
            dtgListaVoucher.Columns["cNombreArchivo"].Visible = true;
            dtgListaVoucher.Columns["dFechaReg"].Visible = true;

            dtgListaVoucher.Columns["idSolicitudTramite"].HeaderText = "Nro. Solicitud";
            dtgListaVoucher.Columns["cTipoOperacion"].HeaderText = "Tipo Solicitud";
            dtgListaVoucher.Columns["idPlanPagos"].HeaderText = "Plan Pagos";
            dtgListaVoucher.Columns["cNombreArchivo"].HeaderText = "Nombre Archivo";
            dtgListaVoucher.Columns["dFechaReg"].HeaderText = "Fecha Registro";

            dtgListaVoucher.Columns["idSolicitudTramite"].DisplayIndex = 0;
            dtgListaVoucher.Columns["cTipoOperacion"].DisplayIndex = 1;
            dtgListaVoucher.Columns["idPlanPagos"].DisplayIndex = 2;
            dtgListaVoucher.Columns["cNombreArchivo"].DisplayIndex = 3;
            dtgListaVoucher.Columns["dFechaReg"].DisplayIndex = 4;

            dtgListaVoucher.Columns["idSolicitudTramite"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgListaVoucher.Columns["cTipoOperacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
  
            DataGridViewButtonColumn btnVerArchivo = new DataGridViewButtonColumn();
            {
                btnVerArchivo.Name = "btnVerArchivo";
                btnVerArchivo.HeaderText = "Ver";
                btnVerArchivo.Text = "Ver";
                btnVerArchivo.UseColumnTextForButtonValue = true;
                btnVerArchivo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnVerArchivo.FlatStyle = FlatStyle.Standard;
                btnVerArchivo.CellTemplate.Style.BackColor = Color.Honeydew;                
                dtgListaVoucher.Columns.Add(btnVerArchivo);
            }
            
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            {
                btnEditar.Name = "btnEditar";
                btnEditar.HeaderText = "Editar";
                btnEditar.Text = "+";
                btnEditar.UseColumnTextForButtonValue = true;
                btnEditar.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnEditar.FlatStyle = FlatStyle.Standard;
                btnEditar.CellTemplate.Style.BackColor = Color.Honeydew;
                dtgListaVoucher.Columns.Add(btnEditar);
            }                           

            if (idSolicitud != 0)
            {
                this.dtgListaVoucher.Columns["btnEditar"].Visible = false;
            }

            DataGridViewButtonColumn btnImprimir = new DataGridViewButtonColumn();
            {
                btnImprimir.Name = "btnImprimir";
                btnImprimir.HeaderText = "Imprimir";
                btnImprimir.Text = "-";
                btnImprimir.UseColumnTextForButtonValue = true;
                btnImprimir.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnImprimir.FlatStyle = FlatStyle.Standard;
                btnImprimir.CellTemplate.Style.BackColor = Color.Honeydew;
                dtgListaVoucher.Columns.Add(btnImprimir);
            }
        }      
             
        private void dtgListaVoucher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int verArchivo = dtgListaVoucher.Columns["btnVerArchivo"].Index;
            int agregarArchivo = dtgListaVoucher.Columns["btnEditar"].Index;
            int imprimirArchivo = dtgListaVoucher.Columns["btnImprimir"].Index;
            
            if (dtgListaVoucher.CurrentCell == null)
                return;
            
            bool lInsertado = Convert.ToBoolean(dtgListaVoucher.CurrentRow.Cells["lInsertado"].Value);
            string cArchivoNombre = Convert.ToString(dtgListaVoucher.CurrentRow.Cells["cArchivo"].Value);
                           
            if (dtgListaVoucher.CurrentCell.ColumnIndex.Equals(agregarArchivo))
            {
                               
                if (DateTime.Compare(dFechaSys, Convert.ToDateTime(dtgListaVoucher.CurrentRow.Cells["dFechaRegistroTramite"].Value)) == 0)
                {                    
                    OpenFileDialog fDialog = new OpenFileDialog();
                    fDialog.Title = "Abrir archivo";
                    fDialog.InitialDirectory = clsVarGlobal.cRutPathApp;
                    fDialog.Multiselect = false;
                    fDialog.Filter = "PDF Documents|*.pdf";

                    if (fDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        FileInfo fi = new FileInfo(fDialog.FileName);
                        long fileSize = fi.Length;
                        int maxSize = clsVarApl.dicVarGen["cMaxFile"];
                        if (fileSize > maxSize)
                            MessageBox.Show("El archivo es de " + fileSize + "bytes, excedió el límite de subida de archivos, máximo de " + maxSize + " bytes", "Adjuntar Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        else
                        {
                            string cArchivo = fDialog.FileName;
                            FileInfo fInfo = new FileInfo(cArchivo);
                            long numBytes = fInfo.Length;
                            FileStream fStream = new FileStream(cArchivo, FileMode.Open, FileAccess.Read);
                            BinaryReader br = new BinaryReader(fStream);

                            string nameFile = cArchivo;
                            string cDocumentoSesion = fInfo.Name;
                            byte[] vDocumentoSesion = br.ReadBytes((int)numBytes);
                            string cExtension = fInfo.Extension;
                            fStream.Flush();
                            fStream.Close();
                            br.Close();
                        
                            dtgListaVoucher.Rows[dtgListaVoucher.CurrentCell.RowIndex].Cells["cArchivo"].Value = cDocumentoSesion;
                            dtgListaVoucher.Rows[dtgListaVoucher.CurrentCell.RowIndex].Cells["cNombreArchivo"].Value = cDocumentoSesion;
                            dtgListaVoucher.Rows[dtgListaVoucher.CurrentCell.RowIndex].Cells["cExtension"].Value = cExtension;
                            dtgListaVoucher.Rows[dtgListaVoucher.CurrentCell.RowIndex].Cells["bArchivoBinary"].Value = Compresion.CompressedByte(vDocumentoSesion);
                            dtgListaVoucher.Rows[dtgListaVoucher.CurrentCell.RowIndex].Cells["lInsertado"].Value = 0;  
                        }                    
                    }
                }
                else
                {
                    panelFile.Visible = false;
                    MessageBox.Show("Para esta solicitud, no puede editar o agregar documento", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else if (dtgListaVoucher.CurrentCell.ColumnIndex.Equals(imprimirArchivo))
            {
                ReImprimirVoucherHojaTramite(
                    Convert.ToInt32(dtgListaVoucher.Rows[dtgListaVoucher.CurrentCell.RowIndex].Cells["idSolicitudTramite"].Value),
                    Convert.ToInt32(dtgListaVoucher.Rows[dtgListaVoucher.CurrentCell.RowIndex].Cells["idTipoOperacion"].Value));               
            }

            else if (dtgListaVoucher.CurrentCell.ColumnIndex.Equals(verArchivo))
            {
                if (dtgListaVoucher.Rows[dtgListaVoucher.CurrentCell.RowIndex].Cells["cNombreArchivo"].Value.ToString() != "")
                {

                    byte[] bits;
                    if (dtgListaVoucher.Rows[dtgListaVoucher.CurrentCell.RowIndex].Cells["cExtension"].Value.ToString() == "")
                    {

                        DataTable res = clsFiles.mostrarVoucherArchivo(
                            Convert.ToInt32(dtgListaVoucher.Rows[dtgListaVoucher.CurrentCell.RowIndex].Cells["idSolicitudTramite"].Value));

                        dtgListaVoucher.Rows[dtgListaVoucher.CurrentCell.RowIndex].Cells["cExtension"].Value = res.Rows[0]["cExtension"].ToString();

                        dtgListaVoucher.Rows[dtgListaVoucher.CurrentCell.RowIndex].Cells["bArchivoBinary"].Value = (byte[])res.Rows[0]["bArchivoBinary"];

                    }
                    bits = Compresion.DescompressedByte((byte[])dtgListaVoucher.Rows[dtgListaVoucher.CurrentCell.RowIndex].Cells["bArchivoBinary"].Value);

                    string sFile = dtgListaVoucher.Rows[dtgListaVoucher.CurrentCell.RowIndex].Cells["cArchivo"].Value.ToString() +
                                    "-" + clsVarGlobal.User.idUsuario.ToString() +
                                    dtgListaVoucher.Rows[dtgListaVoucher.CurrentCell.RowIndex].Cells["cExtension"].Value.ToString()
                                    ;
                    string ruta = Directory.GetCurrentDirectory() + "\\documentosTmp";
                    if (!Directory.Exists(ruta))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(ruta);
                    }

                    FileStream fs = new FileStream("documentosTmp\\" + sFile, FileMode.Create);
                    fs.Write(bits, 0, Convert.ToInt32(bits.Length));

                    fs.Close();

                    ruta = ruta + "\\" + sFile;
                    contPdf.src = ruta;
                    panelFile.Visible = true;

                    int i = 0;
                    for (i = 0; i < fileVistos.Count(); i++)
                    {
                        if (fileVistos[i] == ruta.ToString())
                            break;
                    }
                    if (fileVistos.Count() == i)
                        fileVistos.Add(ruta.ToString());
                }
                else
                {
                    panelFile.Visible = false;
                    MessageBox.Show("No se cargó ningún Archivo", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void btnGrabar2_Click(object sender, EventArgs e)
        {
            bool lCambios = false;
            for (int i = 0; i < dtgListaVoucher.Rows.Count; i++)
            {
                if (!Convert.ToBoolean(dtgListaVoucher.Rows[i].Cells["lInsertado"].Value))
                {
                    lCambios = true;
                }
            }
           
            if (!lCambios)
            {
                MessageBox.Show("No se encontraron cambios para ser Guardados", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            for (int i = 0; i < dtgListaVoucher.Rows.Count; i++)
            {
                if (!Convert.ToBoolean(dtgListaVoucher.Rows[i].Cells["lInsertado"].Value))
                {
                    DataTable res = clsFiles.cargarVoucherArchivo(                                               
                        dtgListaVoucher.Rows[i].Cells["cArchivo"].Value.ToString(),
                        dtgListaVoucher.Rows[i].Cells["cExtension"].Value.ToString(),
                        clsVarGlobal.User.idUsuario,
                        Convert.ToInt32(dtgListaVoucher.Rows[i].Cells["idSolicitudTramite"].Value), 
                        (byte[])dtgListaVoucher.Rows[i].Cells["bArchivoBinary"].Value
                    );
                    if (res.Rows.Count > 0)
                        dtgListaVoucher.Rows[i].Cells["lInsertado"].Value = res.Rows[0]["idEstado"];
                    else dtgListaVoucher.Rows[i].Cells["lInsertado"].Value = 0;                
     

                }
            }
            if (verificarEnvios())
            {
                MessageBox.Show("Se registró correctamente los archivos", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
                MessageBox.Show("Ocurrió un error al subir uno de los archivos, intente de nuevo", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          
        }           
        
        private bool verificarEnvios()
        {
            for (int i = 0; i < dtgListaVoucher.Rows.Count; i++)
            {
                if (dtgListaVoucher.Rows[i].Cells["bArchivoBinary"].Value.ToString() != "" && !Convert.ToBoolean(dtgListaVoucher.Rows[i].Cells["lInsertado"].Value))
                    return false;
            }

            return true;
        }

        private void ReImprimirVoucherHojaTramite(int idSolicitudHojaTramite, int idTipoOperacion)
        {
            clsCNPlanPago objCNPlanPago = new clsCNPlanPago();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            paramlist.Add(new ReportParameter("idSolicitudTramite", idSolicitudHojaTramite.ToString(), false));
            paramlist.Add(new ReportParameter("idTipoOperacion", idTipoOperacion.ToString(), false));

            string reportpath;
            if (idTipoOperacion == 1)
            { 
                reportpath = "rptVoucherPrePago.rdlc";
                dtslist.Add(new ReportDataSource("DataSet1", objCNPlanPago.CNObtenerVoucherHojaTramite(idSolicitudHojaTramite, idTipoOperacion)));
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }

            if (idTipoOperacion == 2)
            {
                reportpath = "rptVoucherAdelantoCuota.rdlc";
                dtslist.Add(new ReportDataSource("DataSet1", objCNPlanPago.CNObtenerVoucherHojaTramite(idSolicitudHojaTramite, idTipoOperacion)));
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }    

        }

        private void ListarVoucher(int idUsuarioReg, int idSolicitud_)
        {
            DataSet dtRes = clsFiles.getVoucherArchivoPrepago(idUsuarioReg, idSolicitud_);
            Application.EnableVisualStyles();

            if (dtRes.Tables[0].Rows.Count == 0)
            {           
                MessageBox.Show("No se encontraron voucher registrados de Operación Prepago o Adelanto de Cuota para ser mostrados", "Mostrar Registros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
                return;
            }

            else
            {
                DataTable dtGrupoArchivoRes = dtRes.Tables[0];

                foreach (DataColumn column in dtGrupoArchivoRes.Columns)
                {
                    column.ReadOnly = false;
                }
                dtGrupoArchivo = dtGrupoArchivoRes;

                if (dtGrupoArchivo.Rows.Count > 0)
                {
                    dtgListaVoucher.DataSource = dtGrupoArchivoRes;
                    FormatoPrePago();
                }
            }
        }            
    }

}
