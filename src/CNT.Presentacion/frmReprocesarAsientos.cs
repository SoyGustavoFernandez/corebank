using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using CNT.CapaNegocio;

namespace CNT.Presentacion
{
    public partial class frmReprocesarAsientos : frmBase
    {
        DataTable dtLisProcesos;
        clsCNBalance objBalance = new clsCNBalance();
        public frmReprocesarAsientos()
        {
            InitializeComponent();
        }

        private void frmReprocesarAsientos_Load(object sender, EventArgs e)
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

            dtFecReproceso.Value = Convert.ToDateTime(clsVarGlobal.dFecSystem);
            dtFecRepFin.Value = Convert.ToDateTime(clsVarGlobal.dFecSystem);

            clsCNProcesosAsientos LisProcesos = new clsCNProcesosAsientos();
            dtLisProcesos = LisProcesos.ListarProcAsientos();
            dtLisProcesos.Columns.Add("lEstado", typeof(Boolean)); 

            dtgLisProCierre.DataSource = dtLisProcesos;
            if (dtgLisProCierre.RowCount == 0)
            {
                btnProcesar.Enabled = false;
            }
            else
            {
                for (int n = 0; n < dtgLisProCierre.Rows.Count; n++)
                    dtgLisProCierre.Rows[n].Cells["lEstado"].Value = 0; 
            }
            FormatoGridCli();

            dtgLisProCierre.ReadOnly=false;
            dtgLisProCierre.Columns["cNombreProceso"].ReadOnly=true;
            dtgLisProCierre.Columns["lEstado"].ReadOnly=false;
        }


        private void FormatoGridCli()
        {            
            dtgLisProCierre.Columns["idProAsiento"].Visible = false;
            dtgLisProCierre.Columns["cNombreProceso"].HeaderText = "NOMBRE DEL PROCESO";
            dtgLisProCierre.Columns["cNombreProceso"].Width = 240;
            dtgLisProCierre.Columns["cNombreProceso"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dtgLisProCierre.Columns["cNombreSP"].Visible = false;
            dtgLisProCierre.Columns["lEstado"].HeaderText = "REPROCESAR";
            dtgLisProCierre.Columns["lEstado"].Width = 80;
            dtgLisProCierre.Columns["lEstado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                       
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            int nAnioCnt = clsVarApl.dicVarGen["nAnioCNT"];
            int nMesCnt = clsVarApl.dicVarGen["nMesCNT"];

            string cFecCNT = nAnioCnt.ToString() + "/" + nMesCnt.ToString() + "/01";
            DateTime dFecCNT = Convert.ToDateTime(cFecCNT);

            if (dtFecReproceso.Value < dFecCNT)
            {
                MessageBox.Show("La fecha inicial no corresponde al período contable", "Reproceso de Asientos Contables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dtFecReproceso.Value>dtFecRepFin.Value)
            {
                MessageBox.Show("La fecha final debe ser mayor o igual a la inicial", "Reproceso de Asientos Contables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //VALIDAR : NO SE PUEDE REPROCESAR LOS ASIENTOS CON LA FECHA POSTERIOR
            if ((clsVarGlobal.dFecSystem.Date - dtFecRepFin.Value.Date).TotalDays < 0) {
                MessageBox.Show("No se puede reprocesar los Asientos Contables con fecha posterior a ésta", "Reproceso de Asientos Contables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;             
            }

            //VALIDACION SI NO EXISTE NINGÚN PROCESO MARCADO
            Boolean lMarcarProceso=false;
            for(int n=0;n<dtgLisProCierre.Rows.Count; n++){
                if(Convert.ToInt32(dtgLisProCierre.Rows[n].Cells["lEstado"].Value)==1)
                     lMarcarProceso=true;              
            }
            if(lMarcarProceso==false){
                MessageBox.Show("Debe seleccionar al menos un Proceso de la Lista","Reproceso de Asientos Contables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;            
            }

            Int32 nRespuesta = (Int32) MessageBox.Show("¿Estás seguro de procesar?", "Reproceso de Asientos Contables", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (nRespuesta != 6)
            {
                return;
            }
                                   
            string cNomSp,cCtr="OK";
            DateTime dFecReproc=Convert.ToDateTime(dtFecReproceso.Value);
            DateTime dFecFin = Convert.ToDateTime(dtFecRepFin.Value);
            Cursor.Current = Cursors.WaitCursor;

            for (DateTime dFecTMP = dFecReproc; dFecTMP <= dFecFin; dFecTMP = dFecTMP.AddDays(1))
            {
                for (int i = 0; i < dtgLisProCierre.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dtgLisProCierre.Rows[i].Cells["lEstado"].Value) == true)
                    {
                        clsCNProcesosAsientos EjeSpCierre = new clsCNProcesosAsientos();
                        cNomSp = dtgLisProCierre.Rows[i].Cells["cNombreSP"].Value.ToString().Trim();

                        DataTable dtRetornoPro = EjeSpCierre.ReProcesoAsiento(cNomSp, dFecTMP);
                        if (dtRetornoPro.Rows[0]["nResultado"].ToString() == "0")
                        {
                            string cMnesaje = dtRetornoPro.Rows[0]["cMensaje"].ToString();
                            MessageBox.Show(cMnesaje + ", Proceso: " + dtgLisProCierre.Rows[i].Cells["cNombreProceso"].Value.ToString(), "Reproceso de Asientos Contables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cCtr = "ERROR";
                            break;
                        }
                        else
                        {
                            dtgLisProCierre.Rows[i].Cells["lEstado"].Value = 1;
                        }
                    }
                }
            }

            if (cCtr=="OK")
            {
                MessageBox.Show("El Reproceso de los Asientos contables ha Culminado Satisfactoriamente...","Reproceso de Asientos Contables", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnProcesar.Enabled=true;                
            }
            Cursor.Current = Cursors.Default;
        }

        private void chcTodos_CheckedChanged(object sender, EventArgs e)
        {
            dtLisProcesos.Columns["lEstado"].ReadOnly = false;
            foreach (DataRow item in dtLisProcesos.Rows)
                {
                    item["lEstado"] = chcTodos.Checked;
                }
        }
        private void LiberaProceso()
        {
            objBalance.LiberaProcesoEEFF(this.Name, clsVarGlobal.User.idUsuario);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            LiberaProceso();
        }

        private void frmReprocesarAsientos_FormClosed(object sender, FormClosedEventArgs e)
        {
            LiberaProceso();
        }
    }
}
