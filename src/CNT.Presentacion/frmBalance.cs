using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CNT.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;

namespace CNT.Presentacion
{
    public partial class frmBalance : frmBase
    {
        int nAnioCnt = clsVarApl.dicVarGen["nAnioCNT"];
        int nMesCnt = clsVarApl.dicVarGen["nMesCNT"];
        clsCNBalance objBalance = new clsCNBalance();

        public frmBalance()
        {
            InitializeComponent();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            DateTime dFecIni = dtpFecInicio.Value.Date;
            DateTime dFecFin = dtpFecFin.Value.Date;

            if (Valida(dFecIni, dFecFin))
            {
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            //=================  Registro Inicio Rastreo ===================================
            this.registrarRastreo(0, 0, "Inicio - Procesa EEFF", btnProcesar);
            //==============================================================================
            int nValor = 0;
            for (DateTime dIni = dFecIni; dIni <= dFecFin; dIni = dIni.AddDays(1))
            {
                DataTable dtProBG = objBalance.CNProcesaBG(dIni);
                DataTable dtActualizaSaldoEnPres = objBalance.CNActualizaSaldoEnPresupuesto(dIni);
                if (Convert.ToInt32(dtProBG.Rows[0]["lProceso"])==0)
                {
                    MessageBox.Show("Error en el proceso de EEFF", "Procesa EEFF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nValor = 0;
                    break;
                }
                else
                {
                    nValor = 1;
                }
            }

            //=================   Registro Fin Rastreo    ================================
            this.registrarRastreo(0, 0, "Fin - Procesa EEFF", btnProcesar);
            //============================================================================
            Cursor.Current = Cursors.Default;
            if (nValor == 1)
            {
            MessageBox.Show("Proceso realizado correctamente", "Proceso EEFF", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.btnProcesar.Enabled = false;
        }

        private void frmBalance_Load(object sender, EventArgs e)
        {
            //Bloqueo de proceso
            string cFrm = this.Name;

            DataTable dtBloqueo = objBalance.ValidaProcesoEEFF(cFrm, clsVarGlobal.User.idUsuario);
            if (!string.IsNullOrEmpty(dtBloqueo.Rows[0]["cWinUser"].ToString()))
            {
                MessageBox.Show("Ejecutando la opción: " + dtBloqueo.Rows[0]["cMenu"].ToString() + "," + Environment.NewLine + 
                             "por el usuario: " + dtBloqueo.Rows[0]["cWinUser"].ToString(), "Valida Proceso EEFF", 
                             MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
                return;
            }
            dtpFecInicio.Value = clsVarGlobal.dFecSystem;
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
        }

        private Boolean Valida(DateTime dfecIni, DateTime dFecFin)
        {
            string cFecCNT = nAnioCnt.ToString() + "/" + nMesCnt.ToString() + "/01";
            DateTime dFecCNT = Convert.ToDateTime(cFecCNT);

            if (dfecIni < dFecCNT)
            {
                MessageBox.Show("La fecha de Inicio no corresponde al período contable activo", "Proceso EEFF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (dfecIni > dFecFin)
            {
                MessageBox.Show("La fecha final no puede ser menor a la fecha inicial", "Proceso EEFF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            LiberaProceso();
        }
        private void LiberaProceso()
        {
            objBalance.LiberaProcesoEEFF(this.Name, clsVarGlobal.User.idUsuario);
        }

        private void frmBalance_FormClosed(object sender, FormClosedEventArgs e)
        {
            LiberaProceso();
        }
    }
}
