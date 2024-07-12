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
using CRE.CapaNegocio;
using ADM.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmCierreDia : frmBase
    {
        bool lValida = true;

        public frmCierreDia()
        {
            InitializeComponent();
            
            clsCNCierreCredito LisProCie = new clsCNCierreCredito();
            DataTable dtLisProCie = LisProCie.CNdtCierreCre();

            if (dtLisProCie.Rows[0]["idMsje"].ToString().In("0"))
            {
                MessageBox.Show(dtLisProCie.Rows[0]["cMsje"].ToString() + dtLisProCie.Rows[0]["cUsuario"].ToString().ToUpper() + " de " + dtLisProCie.Rows[0]["cAgencia"].ToString() + " Verifique por favor", "Valida Proceso Cierre", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnProcesar.Enabled = false;
                lValida = false;
                return;
            }

            else if (dtLisProCie.Rows[0]["idMsje"].ToString().In("2"))
            {
                MessageBox.Show(dtLisProCie.Rows[0]["cMsje"].ToString() + "\n Verifique por favor", "Valida Proceso Cierre", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnProcesar.Enabled = false;
                lValida = false;
                return;
            }
            else
            {
                dtgLisProCierre.DataSource = dtLisProCie;
                lValida = true;
            }            
        }

        private void FormatoGridCli()
        {
            dtgLisProCierre.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dtgLisProCierre.Columns["cProceso"].HeaderText="NOMBRE DE PROCESO";
            dtgLisProCierre.Columns["cProceso"].Width=307;
            dtgLisProCierre.Columns["dFechaProceso"].HeaderText = "FECHA";
            dtgLisProCierre.Columns["dFechaProceso"].Width = 80;


            dtgLisProCierre.Columns["idProceso"].HeaderText = "PROCESO";
            dtgLisProCierre.Columns["nOrdenEjecucion"].HeaderText = "ORDEN";

            dtgLisProCierre.Columns["idProceso"].DisplayIndex = 0;
            dtgLisProCierre.Columns["nOrdenEjecucion"].DisplayIndex = 1;

            dtgLisProCierre.Columns["idProceso"].Width = 80;
            dtgLisProCierre.Columns["nOrdenEjecucion"].Visible = false;

            dtgLisProCierre.Columns["idProceso"].DefaultCellStyle.Alignment= DataGridViewContentAlignment.MiddleCenter;

            dtgLisProCierre.Columns["idAplicativo"].Visible = false;
            dtgLisProCierre.Columns["cStoreProc"].Visible = false;            
            dtgLisProCierre.Columns["idMsje"].Visible = false;
            dtgLisProCierre.Columns["lEstado"].Visible = false;

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "img";
            img.Image = (System.Drawing.Image)Properties.Resources.warning;
            img.HeaderText = "ESTADO";
            img.Width = 80;
            img.DisplayIndex = 6;
            dtgLisProCierre.Columns.Add(img);
            dtgLisProCierre.ClearSelection();

            for (int i = 0; i < dtgLisProCierre.RowCount; i++)
            {
                if (!(bool)dtgLisProCierre.Rows[i].Cells["lEstado"].Value)
                {
                    dtgLisProCierre.Rows[i].Cells["img"].Value = (System.Drawing.Image)Properties.Resources.warning;
                }
                else
                {
                    dtgLisProCierre.Rows[i].Cells["img"].Value = (System.Drawing.Image)Properties.Resources.success;
                }
            }
        }

        private void frmCierreDia_Load(object sender, EventArgs e)
        {
            this.lblFechaSistema.Text = clsVarGlobal.dFecSystem.ToLongDateString();
            if (lValida)
            {
                FormatoGridCli();
                asignarTotalProcesos();
                dtgLisProCierre.ClearSelection();
            }            
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
           /*========================================================================================
           * REGISTRO DE RASTREO
           ========================================================================================*/
            this.registrarRastreo(clsVarGlobal.User.idUsuario, clsVarGlobal.User.idUsuario, "Inicio-Proceso de cierre de sistema", this.btnProcesar);

            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
            Int32 nRespuesta = (Int32) MessageBox.Show("El Proceso es irreversible" + " " + "¿Estás seguro de procesar?", "Proceso de Cierre de Día", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (nRespuesta != 6)
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            clsCNCierreCredito EjeSpCierre = new clsCNCierreCredito();

            int nEjecucionCierre = EjeSpCierre.CNCodigoEjecucionCierrePorFecha(Convert.ToDateTime(dtgLisProCierre.Rows[0].Cells["dFechaProceso"].Value));

            clsCNMantenimiento objMant = new clsCNMantenimiento();
            var dtVariables = objMant.ListarVariables(0);
            var drVariable = dtVariables.AsEnumerable().FirstOrDefault(x => Convert.ToString(x["cVariable"]).Equals("lProcesandoCierre"));
            if(drVariable != null)
            {
                objMant.GrabarVariables(Convert.ToInt32(drVariable["idVariable"]), Convert.ToString(drVariable["cVariable"]), Convert.ToString(drVariable["cDescripcion"]),
                                        Convert.ToString(drVariable["cTipoVariable"]), "1", true, 0, false);
            }


            string cCtr="OK";
            for (int i = 0; i < dtgLisProCierre.RowCount; i++)
            {

                if (!(bool)dtgLisProCierre.Rows[i].Cells["lEstado"].Value)
                {
                    int nIdProceso = Convert.ToInt32(dtgLisProCierre.Rows[i].Cells["idProceso"].Value);
                    string cNomSp = dtgLisProCierre.Rows[i].Cells["cStoreProc"].Value.ToString().Trim();
                    string cMensaje = "";
                    DataTable dtRetornoPro = EjeSpCierre.ProcesoCieDia(cNomSp, nIdProceso);
                    if (dtRetornoPro.Rows[0][0].ToString()=="0")
                    {
                        cMensaje = dtRetornoPro.Rows[0][1].ToString();
                        MessageBox.Show(cMensaje,"Proceso de Cierre de Día", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cCtr="E";
                        this.Cursor = Cursors.Default;
                        break;
                    }
                    else
                    {
                        cMensaje = "Proceso Correcto";
                        dtgLisProCierre.Rows[i].Cells["lEstado"].Value = 1;
                        dtgLisProCierre.Rows[i].Cells["img"].Value = (System.Drawing.Image)Properties.Resources.success;
                        dtgLisProCierre.FirstDisplayedScrollingRowIndex = i;
                        dtgLisProCierre.Update();
                    }

                    EjeSpCierre.CNInsertarLogProcesoCierre(Convert.ToDateTime(dtgLisProCierre.Rows[0].Cells["dFechaProceso"].Value), nIdProceso, nEjecucionCierre, clsVarGlobal.User.idUsuario, cMensaje);
                }
            }

            this.Cursor = Cursors.Default;

            if (cCtr=="OK")
            {
                /*========================================================================================
                  * REGISTRO DE RASTREO
                  ========================================================================================*/

                this.registrarRastreo(clsVarGlobal.User.idUsuario, clsVarGlobal.User.idUsuario, "Fin-Proceso de cierre de sistema", this.btnProcesar);
                /*========================================================================================
                 * FIN DEL REGISTRO DE RASTREO
                 ========================================================================================*/
                if (drVariable != null)
                {
                    objMant.GrabarVariables(Convert.ToInt32(drVariable["idVariable"]), Convert.ToString(drVariable["cVariable"]), Convert.ToString(drVariable["cDescripcion"]),
                                            Convert.ToString(drVariable["cTipoVariable"]), "0", true, 0, false);
                }
                MessageBox.Show("Proceso de Cierre a Culminado Satisfactoriamente...","Proceso de Cierre de Día", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnProcesar.Enabled=false;
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
    
        private void asignarTotalProcesos()
        {
            lblTotalProcesos.Text = "Total Procesos: " + dtgLisProCierre.RowCount.ToString();
        }
    }
}
