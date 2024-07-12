using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CNT.CapaNegocio;
using GEN.ControlesBase;
using EntityLayer;

namespace CNT.Presentacion.CPE
{
    public partial class frmEnvioSunatCPE : frmBase
    {

        #region

        private int _idArchivo;
        private readonly CNComprobantePagoElectronico _cnComprobantePagoElectronico = new CNComprobantePagoElectronico();

        public bool Success { get; private set; }

        #endregion

        #region Constructores

        public frmEnvioSunatCPE(int idArchivo)
        {
            InitializeComponent();
            _idArchivo = idArchivo;
            Success = false;
        }

        #endregion

        #region Eventos

        private void frmEnvioSunatCPE_Load(object sender, EventArgs e)
        {
            DtpFecha.Value = clsVarGlobal.dFecSystem;
            CboEstadoEnvio.CargarDatos();
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            var fechaEnvio = DtpFecha.Value.Date;
            var idEstado = Convert.ToInt32(CboEstadoEnvio.SelectedValue);
            var nombreCDR = txtNombreCDR.Text;
            var idUsuario = clsVarGlobal.User.idUsuario;

            var res = _cnComprobantePagoElectronico.RegistrarEnvioSunat(_idArchivo, fechaEnvio, nombreCDR,
                idEstado, idUsuario);

            if (res.nMsje != 0)
            {
                MessageBox.Show(res.cMsje, "Envio Sunat", MessageBoxButtons.OK, MessageBoxIcon.Information);               
                return;
            }
            MessageBox.Show(res.cMsje, "Envio Sunat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Success = true;
            Dispose();
        }

        #endregion

        #region Metodos

        private bool Validar()
        {
            var idEstado = Convert.ToInt32(CboEstadoEnvio.SelectedValue);
            if (idEstado == 0)
            {
                MessageBox.Show("Seleccione un estado", "Envio Sunat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(txtNombreCDR.Text))
            {
                MessageBox.Show("Ingrese el nombre de CDR", "Envio Sunat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        #endregion
    }
}
