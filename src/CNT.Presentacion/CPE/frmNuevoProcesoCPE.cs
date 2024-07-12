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

namespace CNT.Presentacion.CPE
{
    public partial class frmNuevoProcesoCPE : frmBase
    {

        #region Variable globales

        private const string _titulo = "Comprobantes de pago electrónico CPE";
        private readonly CNComprobantePagoElectronico _cnComprobantePagoElectronico = new CNComprobantePagoElectronico();

        public bool Success { get; private set; }

        #endregion

        #region Constructores

        public frmNuevoProcesoCPE()
        {
            InitializeComponent();
            Success = false;
        }

        #endregion

        #region Eventos

        private void frmNuevoProcesoCPE_Load(object sender, EventArgs e)
        {
            DtpFechaIni.Value = Convert.ToDateTime("01-"+clsVarGlobal.dFecSystem.Month+"-"+clsVarGlobal.dFecSystem.Year);
            DtpFechaIni.MaxDate = clsVarGlobal.dFecSystem;
            DtpFechaFin.Value = clsVarGlobal.dFecSystem;
            DtpFechaFin.MaxDate = clsVarGlobal.dFecSystem;
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarRegistro())
                return;

            var fechaIni = DtpFechaIni.Value.Date;
            var fechaFin = DtpFechaFin.Value.Date;
            var idUsuario = clsVarGlobal.User.idUsuario;

            var res = _cnComprobantePagoElectronico.GuardarProceso(fechaIni, fechaFin, idUsuario);

            if (res.nMsje != 0)
            {
                MessageBox.Show(res.cMsje, _titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (fechaFin < fechaIni)
            {
                MessageBox.Show("La fecha final no puede ser mayor a la fecha inicial", _titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show(res.cMsje, _titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Success = true;
            Dispose();
        }

        #endregion

        #region Metodos

        private bool ValidarRegistro()
        {
            var fechaIni = DtpFechaIni.Value.Date;
            var fechaFin = DtpFechaIni.Value.Date;

            if (fechaIni > fechaFin)
            {
                MessageBox.Show("La fecha final tiene que ser mayor o igual a la fecha inicial", _titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        #endregion
    }
}
