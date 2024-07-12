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
using CNT.CapaNegocio;
using EntityLayer;
using EntityLayer.CPE;
using CNT.Presentacion.CPE;
using System.Threading;
using System.IO;
using GEN.Funciones;

namespace CNT.Presentacion
{
    public partial class frmCPE : frmBase
    {

        #region Variable globales

        private const string _titulo = "Comprobantes de pago electrónico CPE";
        private readonly CNComprobantePagoElectronico _cnComprobantePagoElectronico = new CNComprobantePagoElectronico();

        #endregion

        #region Constructores

        public frmCPE()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos

        private void frmCPE_Load(object sender, EventArgs e)
        {
            DtgProcesos.AutoGenerateColumns = false;
            DtgArchivos.AutoGenerateColumns = false;

            DtpFiltroIni.Value = clsVarGlobal.dFecSystem.Date;
            DtpFiltroFin.Value = clsVarGlobal.dFecSystem.Date;
        
            CboEstadoProcesoCPE.CargarDatos();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (!ValidarBusqueda())
                return;

            Buscar(true);
        }

        private void DtgProcesos_SelectionChanged(object sender, EventArgs e)
        {
            if (DtgProcesos.SelectedRows.Count == 0)
                return;
            var proceso = DtgProcesos.SelectedRows[0].DataBoundItem as ProcesoCPE;

            BuscarArchivos(proceso.IdProcesoCPE);
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (!ValidarNuevo())
                return;


            var frm = new frmNuevoProcesoCPE();
            frm.ShowDialog();

            if (frm.Success) 
            {
                DtpFiltroIni.Value = clsVarGlobal.dFecSystem.Date;
                DtpFiltroIni.Value = clsVarGlobal.dFecSystem.Date;
                CboEstadoProcesoCPE.SelectedValue = 1;

                Buscar();
            }
        }

        private void BtnProcesar_Click(object sender, EventArgs e)
        {
            if (DtgProcesos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un proceso para procesar", _titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);           
                return;
            }

            var proceso = DtgProcesos.SelectedRows[0].DataBoundItem as ProcesoCPE;
            var idUsuario = clsVarGlobal.User.idUsuario;

            mostrarInformacion("Se estan procesando las operaciones, espere un momento...");
            var res = _cnComprobantePagoElectronico.ProcesarProceso(proceso.IdProcesoCPE, idUsuario);
            OcultarInfo();

            if (res.nMsje != 0)
            {
                MessageBox.Show(res.cMsje, _titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);                             
                return;
            }
            MessageBox.Show(res.cMsje, _titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);                
            Buscar();
        }

        private void BtnNumerar_Click(object sender, EventArgs e)
        {
            if (DtgProcesos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un proceso para numerar", _titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var proceso = DtgProcesos.SelectedRows[0].DataBoundItem as ProcesoCPE;
            var idUsuario = clsVarGlobal.User.idUsuario;

            mostrarInformacion("Se estan numerando las operaciones, espere un momento...");
            var res = _cnComprobantePagoElectronico.NumerarProceso(proceso.IdProcesoCPE, idUsuario);
            OcultarInfo();

            if (res.nMsje != 0)
            {
                MessageBox.Show(res.cMsje, _titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);             
                return;
            }
          
            MessageBox.Show(res.cMsje, _titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);          
            Buscar();
        }
        
        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            if (DtgProcesos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un proceso para generar archivos", _titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var proceso = DtgProcesos.SelectedRows[0].DataBoundItem as ProcesoCPE;

            if (proceso.IdEstadoProcesoCPE == (int)EstadoProcesoCPEEnum.NUMERADO || proceso.IdEstadoProcesoCPE == (int)EstadoProcesoCPEEnum.FINALIZADO || proceso.IdEstadoProcesoCPE == (int)EstadoProcesoCPEEnum.ENARCHIVO || proceso.IdEstadoProcesoCPE == (int)EstadoProcesoCPEEnum.ENVIOPARCIAL)
            {
                var idUsuario = clsVarGlobal.User.idUsuario;
                var defaultRoute = clsVarApl.dicVarGen["cRutaArchivoCPE"];
                FolderBrowserDialog.SelectedPath = defaultRoute;
                var dialogResult = FolderBrowserDialog.ShowDialog();

                if (dialogResult != DialogResult.OK)
                    return;
                if (proceso.IdEstadoProcesoCPE == (int)EstadoProcesoCPEEnum.NUMERADO)
                {
                    mostrarInformacion("Se estan generando los archivos, espere un momento...");
                    var res = _cnComprobantePagoElectronico.GenerarArchivos(proceso.IdProcesoCPE, idUsuario);
                    OcultarInfo();

                    if (res.nMsje != 0)
                    {
                        MessageBox.Show(res.cMsje, _titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                var dsRes = _cnComprobantePagoElectronico.ObtenerArchivos(proceso.IdProcesoCPE);
                var archivos = dsRes.Tables[0].ToList<ArchivoCPE>();
                var comprobantes = dsRes.Tables[1].ToList<ComprobanteCPE>();

                var ruta = FolderBrowserDialog.SelectedPath;

                foreach (var item in archivos)
                {
                    string nombreArchivo = ruta + "\\" + item.NombreArchivo;
                    var utf8EncoderSinBom = new UTF8Encoding(false);
                    using (StreamWriter sw = new StreamWriter(@nombreArchivo, false, utf8EncoderSinBom))
                    {
                        var comprobantesArchivo = comprobantes.Where(x => x.IdArchivoCPE == item.IdArchivoCPE);
                        string cadena = string.Empty;
                        foreach (var cp in comprobantesArchivo)
                        {
                            cadena = cp.Comprobante;
                            sw.WriteLine(cadena);
                        }
                        sw.Close();
                    }
                }
                MessageBox.Show("Se han generado los archivos correctamente", _titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Buscar();
            }
            else 
            {
                MessageBox.Show("Estado del proceso no valido para generar los archivos", _titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            if (DtgProcesos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un proceso para anular", _titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var proceso = DtgProcesos.SelectedRows[0].DataBoundItem as ProcesoCPE;
            var idUsuario = clsVarGlobal.User.idUsuario;

            var res = _cnComprobantePagoElectronico.AnularProceso(proceso.IdProcesoCPE, idUsuario);

            if (res.nMsje != 0)
            {
                MessageBox.Show(res.cMsje, _titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show(res.cMsje, _titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Buscar();
        }

        private void BtnRegistrarEnvio_Click(object sender, EventArgs e)
        {
            if (DtgArchivos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un archivo para registrar", _titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var archivo = DtgArchivos.SelectedRows[0].DataBoundItem as ArchivoCPE;

            var frm = new frmEnvioSunatCPE(archivo.IdArchivoCPE);
            frm.ShowDialog();

            if (frm.Success)
            {
                var proceso = DtgProcesos.SelectedRows[0].DataBoundItem as ProcesoCPE;
                BuscarArchivos(proceso.IdProcesoCPE);
            }
        }

        #endregion

        #region Metodos

        private bool ValidarBusqueda()
        {
            var fechaIni = DtpFiltroIni.Value.Date;
            var fechaFin = DtpFiltroFin.Value.Date;

            if (fechaIni > fechaFin)
            {
                MessageBox.Show("La fecha final tiene que ser mayor o igual a la fecha inicial", _titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);               
                return false;
            }

            if (CboEstadoProcesoCPE.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un estado", _titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);                
                return false;
            }

            return true;
        }

        private bool ValidarNuevo()
        {
            DataTable dtResultado = _cnComprobantePagoElectronico.ValidaRegNuevo();
            if (Convert.ToString(dtResultado.Rows[0]["idRespuesta"]) == "0")
            {
                MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), _titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void Buscar(bool lValida = false)
        {
            var fechaIni = DtpFiltroIni.Value.Date;
            var fechaFin = DtpFiltroFin.Value.Date;
            var idEstado = Convert.ToInt32(CboEstadoProcesoCPE.SelectedValue);

            var procesos = _cnComprobantePagoElectronico.GetProcesoCPE(fechaIni, fechaFin, idEstado);
            DtgProcesos.DataSource = procesos.ToList();

            if (procesos.Count() == 0 && lValida) 
            {
                MessageBox.Show("No se encontraron registros", _titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BuscarArchivos(int idProceso)
        {
            var archivos = _cnComprobantePagoElectronico.GetArchivoCPE(idProceso);
            DtgArchivos.DataSource = archivos.ToList();
        }

        private void mostrarInformacion(string texto)
        {
            LblInfo.Text = texto;
            Thread.Sleep(100);
            LblInfo.Refresh();
        }

        private void OcultarInfo()
        {
            LblInfo.Text = string.Empty;
        }

        #endregion
    }
}
