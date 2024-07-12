using GEN.ControlesBase;
using SPL.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using CLI.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using CLI.Presentacion;

namespace SPL.Presentacion
{
    public partial class frmActualizarDatos : frmBase
    {

        #region Variables Globales

        string cTituloMsjes = "Actualizar Datos";

        #endregion


        public frmActualizarDatos()
        {
            InitializeComponent();
        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            
            string cIdMesU  = this.conFechaAñoMes1.idMes.ToString();
            string cIdAnioU = this.conFechaAñoMes1.anio.ToString();
            string cFechaS = clsVarGlobal.dFecSystem.ToShortDateString();

            
            DateTime myDateTime = DateTime.Parse(cFechaS);
            string dia = Convert.ToString(myDateTime.Day);
            string mes = Convert.ToString(myDateTime.Month);
            string anio = Convert.ToString(myDateTime.Year);

            int nDiasActualizacion = Convert.ToInt32(clsVarApl.dicVarGen["nDiasActualizacion"]);
               
                    clsDBResp objDbResp = new clsCNScoring().CNProcesaDatos(cIdMesU, cIdAnioU);
                    if (objDbResp.nMsje == 1)
                    {
                        MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
           
           
        }
    }
}
