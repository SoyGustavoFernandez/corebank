using CNT.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNT.Presentacion
{
    public partial class frmCierreContable : frmBase
    {
        int nAnioCnt = clsVarApl.dicVarGen["nAnioCNT"];
        int nMesCnt = clsVarApl.dicVarGen["nMesCNT"];
        int nFrecuencia = 0;
        DateTime dFecPro;
        clsCNProcesosAsientos LisProcesos = new clsCNProcesosAsientos();
        public frmCierreContable()
        {
            InitializeComponent();

            if (nMesCnt == 12)
            {
                nFrecuencia = 2;
            }
            else
            {
                nFrecuencia = 0;

            }
            dFecPro = Convert.ToDateTime(nAnioCnt.ToString() + "-" + nMesCnt.ToString("00") + "-01");
            dFecPro = dFecPro.AddMonths(1).AddDays(-1);
        }

        private void frmCierreContable_Load(object sender, EventArgs e)
        {
            cboMeses1.SelectedValue = nMesCnt;
            txtAnioCNT.Text = nAnioCnt.ToString();
            DataTable dtLisProcesos;

            dtLisProcesos = LisProcesos.CargaProcesosCierreCNT(dFecPro,nFrecuencia);
            dtgProcesos.DataSource = dtLisProcesos;
            if (dtgProcesos.RowCount == 0)
            {
                btnProcesar.Enabled = false;
            }
            else
            {
                btnProcesar.Enabled = true;
            }
            dtgProcesos.ReadOnly = true;
            dtLisProcesos.Columns["lEstado"].ReadOnly = false;

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            btnProcesar.Enabled = false;

            /*========================================================================================
            * REGISTRO DE RASTREO
            ========================================================================================*/
            this.registrarRastreo(clsVarGlobal.User.idUsuario, clsVarGlobal.User.idUsuario, "Inicio-Proceso de cierre de sistema", this.btnProcesar);

            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
            Int32 nRespuesta = (Int32)MessageBox.Show("El Proceso es irreversible" + " " + "¿Estás seguro de procesar?", "Proceso de Cierre de Día", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (nRespuesta != 6)
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            LisProcesos.InsertaProcesosCierreCNT(dFecPro, nFrecuencia);

            string cCtr = "OK";
            for (int i = 0; i < dtgProcesos.RowCount; i++)
            {

                if (!(bool)dtgProcesos.Rows[i].Cells["lEstado"].Value)
                {
                    int nIdProceso = Convert.ToInt32(dtgProcesos.Rows[i].Cells["idProceso"].Value);
                    string cNomSp = dtgProcesos.Rows[i].Cells["cStoreProc"].Value.ToString().Trim();
                    string cMensaje = "";
                    DataTable dtRetornoPro = LisProcesos.ProcesoCierre(cNomSp, nIdProceso, nFrecuencia, dFecPro);
                    if (dtRetornoPro.Rows[0][0].ToString() == "0")
                    {
                        cMensaje = dtRetornoPro.Rows[0][1].ToString();
                        MessageBox.Show(cMensaje, "Proceso de Cierre de Día", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cCtr = "E";
                        this.Cursor = Cursors.Default;
                        break;
                    }
                    else
                    {
                        cMensaje = "Proceso Correcto";
                        dtgProcesos.Rows[i].Cells["lEstado"].Value = 1;
                        dtgProcesos.FirstDisplayedScrollingRowIndex = i;
                        dtgProcesos.Update();
                    }
                }
            }
            this.Cursor = Cursors.Default;

            if (cCtr == "OK")
            {
                /*========================================================================================
                  * REGISTRO DE RASTREO
                  ========================================================================================*/

                this.registrarRastreo(clsVarGlobal.User.idUsuario, clsVarGlobal.User.idUsuario, "Fin-Proceso de cierre contable", this.btnProcesar);
                /*========================================================================================
                 * FIN DEL REGISTRO DE RASTREO
                 ========================================================================================*/

                MessageBox.Show("Proceso de cierre contable culminado satisfactoriamente...", "Proceso de Cierre Contable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnProcesar.Enabled = false;
                this.Dispose();
            }
            else
            {
                /*========================================================================================
                  * REGISTRO DE RASTREO
                  ========================================================================================*/

                this.registrarRastreo(clsVarGlobal.User.idUsuario, clsVarGlobal.User.idUsuario, "Proceso de cierre de sistema incompleto", this.btnProcesar);
                /*========================================================================================
                 * FIN DEL REGISTRO DE RASTREO
                 ========================================================================================*/
            }

        }
    }
}
